Imports IDAutomation
Imports DTEBoxCliente
Public Class ContadoresDTE
    Dim qRecibidos As String = ""
    Dim qEmitidos As String = ""
    Private Sub ContadoresDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bTotales.Visible = True
        If UsuarioActual = "PED" Then
            gDatosCliente.Enabled = True
            bBuscarCli.Visible = True
        End If
    End Sub

    Private Sub Limpiar()
        xF1.Value = IniFecha(1, Now)
        xF2.Value = IniFecha(2, Now)
        xRut.Text = Formatea_Rut(FE_Rut_Emisor, 1)
        xNombre.Text = FE_Razon_Social

        xRecibidos.Text = ""
        xEmitidos.Text = ""
        xTotal.Text = ""
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub
    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim DTE_Consulta As String, tRecibidos As Double, tEmitidos As Double
        Dim PageSize As Integer = 300 'El tamaño máximo de página permitido es de 300 

        xEmitidos.Text = "0"
        xRecibidos.Text = "0"
        xTotal.Text = "0"
        xBVr.Text = "" : xFCr.Text = "" : xFEr.Text = "" : xFVr.Text = "" : xGDr.Text = "" : xNCr.Text = "" : xNDr.Text = "" : xOCr.Text = ""
        xBVe.Text = "" : xFCe.Text = "" : xFEe.Text = "" : xFVe.Text = "" : xGDe.Text = "" : xNCe.Text = "" : xNDe.Text = "" : xOCe.Text = ""
        tEmitidos = 0 : tRecibidos = 0
        qEmitidos = "" : qRecibidos = ""

        DoEvents()

        'Recibidos
        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim AmbienteDTE As DTEBoxCliente.Ambiente
        AmbienteDTE = FE_Ambiente

        If xF2.Value > Date.Now Then
            xF2.Value = Date.Now
        End If
        Dim FechaDesde As String = FE_Fecha(xF1.Value)
        Dim FechaHasta As String = FE_Fecha(xF2.Value)

        Cursor = Cursors.WaitCursor


        'Buscar Emitidos
        Dim DTE_GrupoEmitidos As DTEBoxCliente.GrupoBusqueda = DTEBoxCliente.GrupoBusqueda.Emitidos

        ' DTE_Consulta = "(TipoDTE:33 or TipoDTE:34 or TipoDTE:39 or TipoDTE:52 or TipoDTE:56 or TipoDTE:61) "
        ' DTE_Consulta += " AND (FchEmis:[" + FechaDesde + " TO " + FechaHasta + "]) "
        DTE_Consulta = "(FchEmis:[" + FechaDesde + " TO " + FechaHasta + "]) "
        DTE_Consulta += " AND (RUTEmisor:" + Formatea_Rut(xRut.Text, 0) + ") "

        tEmitidos = 0
        Dim ResultadoDTEe As ResultadoDocumentos = ServicioDTE.BuscarDocumentos(AmbienteDTE, DTE_GrupoEmitidos, DTE_Consulta, 0, PageSize)
        If (ResultadoDTEe.ResultadoServicio.Estado = 0) Then
            If (ResultadoDTEe.TotalDocumentos > 0) Then
                Dim TotalPaginas As Integer = ResultadoDTEe.TotalPages
                Dim Pagina As Integer = 0

                While ((Pagina < TotalPaginas) And (ResultadoDTEe.ResultadoServicio.Estado = 0))
                    For Each doc As ResumenDTE In ResultadoDTEe.ResumenDtes
                        DoEvents()
                        If doc.TipoDTE = 39 Then xBVe.Text = Val(xBVe.Text) + 1
                        If doc.TipoDTE = 46 Then xFCe.Text = Val(xFCe.Text) + 1
                        If doc.TipoDTE = 34 Then xFEe.Text = Val(xFEe.Text) + 1
                        If doc.TipoDTE = 33 Then xFVe.Text = Val(xFVe.Text) + 1
                        If doc.TipoDTE = 52 Then xGDe.Text = Val(xGDe.Text) + 1
                        If doc.TipoDTE = 61 Then xNCe.Text = Val(xNCe.Text) + 1
                        If doc.TipoDTE = 56 Then xNDe.Text = Val(xNDe.Text) + 1
                        If doc.TipoDTE = 801 Then xOCe.Text = Val(xOCe.Text) + 1
                        qEmitidos &= BuscarCampo("TipoDoc", "TipoDoc", "Cod_SII", doc.TipoDTE) & " " & doc.Folio & "  " & vbTab & Formatea_Rut(doc.RUTRecep, 1) & "  " & Format(doc.FchEmis, "dd/MM/yyyy") & "  $" & doc.MntTotal & vbCrLf
                        tEmitidos += 1
                    Next
                    Pagina = Pagina + 1
                    If (Pagina < TotalPaginas) Then
                        ResultadoDTEe = ServicioDTE.BuscarDocumentos(AmbienteDTE, DTE_GrupoEmitidos, DTE_Consulta, Pagina, PageSize)
                    End If
                End While

                tEmitidos = ResultadoDTEe.TotalDocumentos
            End If
        Else
            ' Si la llamada no fue satisfactoria
            Cursor = Cursors.Arrow
            MsgError(ResultadoDTEe.ResultadoServicio.Descripcion)
        End If


        'Buscar Recibidos
        Dim DTE_GrupoRecibidos As DTEBoxCliente.GrupoBusqueda = DTEBoxCliente.GrupoBusqueda.Recibidos

        'DTE_Consulta = "(TipoDTE:33 or TipoDTE:34 or TipoDTE:39 or TipoDTE:52 or TipoDTE:56 or TipoDTE:61) "
        DTE_Consulta = " (FchEmis:[" + FechaDesde + " TO " + FechaHasta + "]) "
        DTE_Consulta += " AND (RUTRecep:" + Formatea_Rut(xRut.Text, 0) + ") "

        tRecibidos = 0
        Dim ResultadoDTEr As ResultadoDocumentos = ServicioDTE.BuscarDocumentos(AmbienteDTE, DTE_GrupoRecibidos, DTE_Consulta, 0, PageSize)
        If (ResultadoDTEr.ResultadoServicio.Estado = 0) Then
            If (ResultadoDTEr.TotalDocumentos > 0) Then
                Dim TotalPaginas As Integer = ResultadoDTEr.TotalPages
                Dim Pagina As Integer = 0

                While ((Pagina < TotalPaginas) And (ResultadoDTEr.ResultadoServicio.Estado = 0))
                    For Each doc As ResumenDTE In ResultadoDTEr.ResumenDtes
                        DoEvents()
                        If doc.TipoDTE = 39 Then xBVr.Text = Val(xBVr.Text) + 1
                        If doc.TipoDTE = 46 Then xFCr.Text = Val(xFCr.Text) + 1
                        If doc.TipoDTE = 34 Then xFEr.Text = Val(xFEr.Text) + 1
                        If doc.TipoDTE = 33 Then xFVr.Text = Val(xFVr.Text) + 1
                        If doc.TipoDTE = 52 Then xGDr.Text = Val(xGDr.Text) + 1
                        If doc.TipoDTE = 61 Then xNCr.Text = Val(xNCr.Text) + 1
                        If doc.TipoDTE = 56 Then xNDr.Text = Val(xNDr.Text) + 1
                        If doc.TipoDTE = 801 Then xOCr.Text = Val(xOCr.Text) + 1
                        qRecibidos &= BuscarCampo("TipoDoc", "TipoDoc", "Cod_SII", doc.TipoDTE) & " " & doc.Folio & "  " & vbTab & Formatea_Rut(doc.RUTEmisor, 1) & "  " & Format(doc.FchEmis, "dd/MM/yyyy") & "  $" & doc.MntTotal & vbCrLf
                    Next
                    Pagina = Pagina + 1
                    If (Pagina < TotalPaginas) Then
                        ResultadoDTEr = ServicioDTE.BuscarDocumentos(AmbienteDTE, DTE_GrupoRecibidos, DTE_Consulta, Pagina, PageSize)
                    End If
                End While

                tRecibidos = ResultadoDTEr.TotalDocumentos
            End If
        Else
            ' Si la llamada no fue satisfactoria
            Cursor = Cursors.Arrow
            MsgError(ResultadoDTEr.ResultadoServicio.Descripcion)
        End If

        xRecibidos.Text = Format(tRecibidos, "###,###,##0")
        xEmitidos.Text = Format(tEmitidos, "###,###,##0")
        xTotal.Text = Format(tRecibidos + tEmitidos, "###,###,##0")
        Cursor = Cursors.Arrow
    End Sub

    Private Sub bEmitidos_Click(sender As Object, e As EventArgs) Handles bEmitidos.Click
        Dim qVentana As New VentanaResultados
        If xEmitidos.Text <> "" Then
            qVentana.xTexto.Text = qEmitidos
            qVentana.Show()
            qVentana.BringToFront()
        End If
    End Sub

    Private Sub bRecibidos_Click(sender As Object, e As EventArgs) Handles bRecibidos.Click
        Dim qVentana As New VentanaResultados
        If xRecibidos.Text <> "" Then
            qVentana.xTexto.Text = qRecibidos
            qVentana.Show()
            qVentana.BringToFront()
        End If
    End Sub

    Private Sub bTotales_Click(sender As Object, e As EventArgs) Handles bTotales.Click
        Dim qVentana As New VentanaResultados
        Dim qCalculo As String = ""
        Dim wUF As Double, wValorDoc As Double, wValorBol As Double
        Dim tDocum As Double, tBole As Double, ValorBoleta As Double


        If xTotal.Text = "" Then Exit Sub
        If xBVe.Text = "" Then xBVe.Text = 0

        tBole = CDbl(xBVe.Text)
        tDocum = CDbl(xTotal.Text) - tBole

        qCalculo += "CONSUMO DE FOLIOS PERÍODO: " & xF1.Text & " al " & xF2.Text & vbCrLf & vbCrLf
        qCalculo += "Documentos Electrónicos Emitidos  = " & xEmitidos.Text & vbCrLf
        qCalculo += "Documentos Electrónicos Recibidos = " & xRecibidos.Text & vbCrLf
        qCalculo += "Total de Documentos Electrónicos  = " & tDocum & vbCrLf
        If tBole > 0 Then
            qCalculo += "Total de Boletas Electrónicas  = " & tBole & vbCrLf
        End If
        qCalculo += "Total de General de Documentos Electrónicos  = " & xTotal.Text & vbCrLf
        qCalculo += vbCrLf

        Swap = SQL("Select * from UFs where Año = " & Year(xF2.Value) & " and Mes = " & Month(xF2.Value))
        If Swap.RecordCount = 0 Then
            MsgError("No se encuentra valor UF del mes a consultar")
            Exit Sub
        End If
        qCalculo += "Valor U.F. " & MES(Swap("Mes").Value) & "/" & Swap("Año").Value & ": " & Format(Swap("UF").Value, "###,###,###.##") & vbCrLf
        wUF = Swap("UF").Value

        'Sacar Valor de boletas
        ValorBoleta = 0
        Swap = SQL("Select Top 1 * from Valores where  Rango = 1")
        If Swap.RecordCount > 0 Then
            ValorBoleta = Swap("Valor").Value
        Else
            If tBole > 0 Then
                MsgError("No se encuentra valor para boletas electrónicas y posee boletas emitidas")
            End If
        End If

        'Sacar Valor de Documentos electrónicos segun el tramo
        Swap = SQL("Select Top 1 * from Valores where Rango >= " & Num(tDocum) & " and Rango > 1 order by Rango")
        If Swap.RecordCount = 0 Then
            MsgError("No se encuentra rango para la cantidad solicitada en tabla de valores")
            Exit Sub
        End If
        qCalculo += "Valor Tramo Documentos: " & Format(Swap("Valor").Value, "###,###,###.##") & " U.F." & vbCrLf
        If tBole > 0 Then
            qCalculo += "Valor Unitario Boleta Electrónica: " & Format(ValorBoleta, "##0.00000") & " U.F." & vbCrLf
        End If

        wValor = Swap("Valor").Value
        qCalculo += vbCrLf
        'wValor = Swap("Valor").Value / Swap("Rango").Value
        'qCalculo += "Valor Unidad: " & Format((wValor * wUF), "###,###,###.##") & vbCrLf
        'qCalculo += "TOTAL: " & Format((wValor * wUF * Val(xTotal.Text)), "###,###,###.##") & vbCrLf
        If tBole > 0 Then
            wValorDoc = wValor * wUF
            wValorBol = ValorBoleta * tBole * wUF
            qCalculo += "TOTAL Documentos: " & Format(wValorDoc, "###,###,###.##") & vbCrLf
            qCalculo += "TOTAL Boletas: " & Format(wValorBol, "###,###,###.##") & vbCrLf
            qCalculo += "TOTAL NETO: " & Format((wValorDoc + wValorBol), "###,###,###.##") & vbCrLf
        Else
            qCalculo += "TOTAL NETO: " & Format((wValor * wUF), "###,###,###.##") & vbCrLf
        End If

        qVentana.xTexto.Text = qCalculo
        qVentana.Show()
        qVentana.BringToFront()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub bBuscarCli_Click(sender As Object, e As EventArgs) Handles bBuscarCli.Click
        Modulo = "ContadoresDTE"
        BuscarClientes.Show()
        BuscarClientes.BringToFront()
    End Sub

    Private Sub xRut_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles xRut.MaskInputRejected

    End Sub

    Private Sub xRut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xRut.KeyPress
        If e.KeyChar = vbCr Then
            Swap = SQL("Select Cliente,Rut,Nombre from Clientes where Rut ='" + xRut.Text + "'")
            If Swap.RecordCount > 0 Then
                xNombre.Text = Swap("Nombre").Text.Trim
            Else
                xNombre.Text = ""
            End If
        End If
    End Sub
End Class