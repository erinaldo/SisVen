Imports C1.Win.C1FlexGrid

Public Class VentaSucursal
    Const T_ELIMINAR = 0
    Const T_ARTICULO = 1
    Const T_DESCRIPCION = 2
    Const T_BARRA = 3
    Const T_CANTIDAD = 4
    Const T_PRECIO = 5
    Const T_TOTAL = 6

    Dim wVisor As New VisorReportes
    Dim wIcono As Icon = My.Resources.Sisven
    Dim wArrayArticulo As List(Of String)
    Dim wSumarAbono As Double
    Dim wUltimoArticulo As String = ""
    Dim wTipoDocumento As String = ""
    Dim wPrimeraPalabraDocumento() As String
    Sub Titulos()
        xTabla.Clear()
        xTabla.Cols.Count = 7
        xTabla.Rows.Count = 1

        xTabla.Cols(T_ELIMINAR).Width = 100
        xTabla.Cols(T_ARTICULO).Width = 100
        xTabla.Cols(T_DESCRIPCION).Width = 100
        xTabla.Cols(T_BARRA).Width = 100
        xTabla.Cols(T_CANTIDAD).Width = 100
        xTabla.Cols(T_PRECIO).Width = 100
        xTabla.Cols(T_TOTAL).Width = 100

        xTabla.Cols(T_ELIMINAR).Caption = " "
        xTabla.Cols(T_ARTICULO).Caption = "Artículo"
        xTabla.Cols(T_DESCRIPCION).Caption = "Descripción"
        xTabla.Cols(T_BARRA).Caption = "Barra"
        xTabla.Cols(T_CANTIDAD).Caption = "Cantidad"
        xTabla.Cols(T_PRECIO).Caption = "Precio"
        xTabla.Cols(T_TOTAL).Caption = "Total"
        xTabla.AjustarColumnas
    End Sub

    Private Sub VentaSucursal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                cFormaPago.Focus()
            Case Keys.F2
                xArticulo.Focus()
            Case Keys.F3
                cDocumento.Focus()
            Case Keys.F4
                bLimpiar_Click(Nothing, Nothing)
            Case Keys.F5
                RepiteArticulo()
            Case Keys.F6
                EliminarArticulo()
            Case Keys.F7
                xDescuento.Text = 0
                xAbono.Text = CDbl(xTotal.Text)
            Case Keys.F8
                bBuscar_Click(Nothing, Nothing)
            Case Keys.F9
                xAbono.Focus()
            Case Keys.F10
                bEmitir_Click(Nothing, Nothing)
            Case Keys.F11
                If Pregunta("¿Desea Salir del Módulo?") Then
                    Close()
                    Menu_Principal.BringToFront()
                End If
            Case Else

        End Select
    End Sub
    Sub RepiteArticulo()
        Dim wIndice As Integer = xTabla.Rows.Count - 1
        If wIndice = 0 Then
            MsgError("No hay artículos agregados en la Tabla")
            Exit Sub
        End If
        xArticulo.Text = wUltimoArticulo
        xArticulo_Validating(Nothing, Nothing)
        xCantidad.Focus()
    End Sub

    Sub EliminarArticulo()
        Dim wFila As Integer
        If xTabla.Rows.Count - 1 = 0 Then
            MsgError("No hay artículos agregados en la Tabla")
            Exit Sub
        End If
        wFila = xTabla.Rows.Count - 1
        xTabla.RemoveItem(wFila)
        ObtenerTotales(False)
    End Sub

    Function ObtenerCorrelativo(ByVal wTipoDoc As String, Optional wCambiar As Boolean = False) As Double
        wTipoDoc = IIf(wTipoDocumento = "", "B", wTipoDocumento)
        Dim wCorrelativo As Double
        Cor = SQL("Select Local,TipoDoc,Caja ,Correlativo FROM Correlativos WHERE Local =" & LocalActual & " and TipoDoc = '" & wTipoDoc & "' and Caja = " & CajaActual & "")
        If Cor.EOF Then
            Cor.AddNew()
            Cor.Fields("Local").Value = LocalActual
            Cor.Fields("Caja").Value = CajaActual
            Cor.Fields("TipoDoc").Value = wTipoDoc
            Cor.Fields("Correlativo").Value = 1
            Cor.Update()
            Return 1
        End If
        wCorrelativo = Cor.Fields("Correlativo").Value
        If wCambiar Then
            Cor.Fields("Correlativo").Value = Val(Cor.Fields("Correlativo").Value) + 1
            Cor.Update()
        End If
        Return wCorrelativo
    End Function

    Sub CargarVendedor()
        Usr = SQL("SELECT NombreUsr FROM Usuarios WHERE Usuario='" & Trim(UsuarioActual) & "'")
        If Usr.EOF Then
            MsgError("El Vendedor ingresado no es válido" & vbCrLf & "Favor de cambiar vendedor")
            Close()
        End If
        xVendedor.Text = Usr.Fields("NombreUsr").Text
    End Sub

    Public Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If Trim(xArticulo.Text) = "" Then Exit Sub
        Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo='" & Trim(xArticulo.Text) & "'")
        If Art.EOF Then
            MsgError("Artículo ingresado no existe")
            xArticulo.Clear()
            xDescripcion.Clear()
            xArticulo.Focus()
            Exit Sub
        End If
        xDescripcion.Text = Art.Fields("Descripcion").Text
        xCantidad.Text = 1
        xCantidad.Focus()
    End Sub

    Private Sub xCantidad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCantidad.Validating
        ValidarDigitos(sender)
    End Sub

    Sub AgregarATabla()
        Dim wFila As Integer
        Dim wCantidad, wTotal, wPrecio As Double
        Dim wBarra As String = ""

        wFila = xTabla.FindRow(xArticulo.Text, 1, T_ARTICULO, False)
        If wFila > 0 Then
            wCantidad = xTabla.GetData(wFila, T_CANTIDAD) + Num(xCantidad.Text)
            wPrecio = xTabla.GetData(wFila, T_PRECIO)
            wBarra = xTabla.GetData(wFila, T_BARRA)
            wTotal = wCantidad * wPrecio
            xTabla.RemoveItem(wFila)
        Else
            Art = SQL("SELECT a.Descripcion,Coalesce(b.Barra,'') as Barra,a.PVenta,a.Estado " &
                      " FROM Articulos a " &
                      " LEFT JOIN Barras b on a.Articulo=b.Articulo " &
                      " WHERE A.Articulo='" & Trim(xArticulo.Text) & "'")

            If Art.EOF Then
                MsgError("El Artículo ingresado no existe")
                Exit Sub
            End If

            If Art.Fields("Estado").Text = "X" Then
                MsgError("El Artículo ingresado está bloqueado")
                Exit Sub
            End If

            If Art.Fields("PVenta").Text <= 0 Then
                MsgError("No se pueden agregar artículos con Precio de Venta menor o igual a 0")
                Exit Sub
            End If

            wPrecio = Art.Fields("PVenta").Text
            wCantidad = Num(xCantidad.Text)
            wTotal = wCantidad * wPrecio
            wBarra = Art.Fields("Barra").Text
        End If
        wFila = xTabla.Rows.Count

        xTabla.AddItem("")
        xTabla.SetCellImage(wFila, T_ELIMINAR, My.Resources.delete)
        xTabla.SetData(wFila, T_ARTICULO, Trim(xArticulo.Text))
        xTabla.SetData(wFila, T_DESCRIPCION, Trim(xDescripcion.Text))
        xTabla.SetData(wFila, T_BARRA, wBarra)
        xTabla.SetData(wFila, T_CANTIDAD, wCantidad)
        xTabla.SetData(wFila, T_PRECIO, wPrecio)
        xTabla.SetData(wFila, T_TOTAL, wTotal)

        wUltimoArticulo = Trim(xArticulo.Text)
        ObtenerTotales(False)
        xTabla.AjustarColumnas
    End Sub
    Sub ObtenerTotales(ByVal wValidaTabla As Boolean)
        Dim wTotal, wSaldo, wSubTotal, wCantidad, wPrecio As Double
        If xTotal.Text = "" Then xTotal.Text = 0
        If xSubTotal.Text = "" Then xSubTotal.Text = 0
        If xAbono.Text = "" Then xAbono.Text = 0
        If xDescuento.Text = "" Then xDescuento.Text = 0
        If xAbonado.Text = "" Then xAbonado.Text = 0
        If xSaldo.Text = "" Then xSaldo.Text = 0

        For i = 1 To xTabla.Rows.Count - 1
            If wValidaTabla Then
                wCantidad = xTabla.GetData(i, T_CANTIDAD)
                wPrecio = xTabla.GetData(i, T_PRECIO)
                xTabla.SetData(i, T_TOTAL, wCantidad * wPrecio)
            End If
            wTotal += xTabla.GetData(i, T_TOTAL)
        Next

        xTotal.Text = IIf(wTotal = 0, 0, Format(wTotal, "###,###"))
        xAbonado.Text = IIf(wSumarAbono = 0, 0, Format(wSumarAbono, "###,###"))
        wSubTotal = wTotal - CDbl(xAbonado.Text) - xDescuento.Text
        xSubTotal.Text = IIf(wSubTotal = 0, 0, Format(wSubTotal, "###,###"))
        xAbono.Text = IIf(wSubTotal = 0, 0, Format(wSubTotal, "###,###"))

        wSaldo = Val(xSubTotal.Text) - Val(xAbono.Text)
        xSaldo.Text = IIf(wSaldo = 0, 0, Format(wSaldo, "###,###"))
        xCantidadTabla.Text = xTabla.Rows.Count - 1
    End Sub

    Private Sub xCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Val(xCantidad.Text) <= 0 Then
                MsgError("La Cantidad no puede ser 0")
                xCantidad.Focus()
                Exit Sub
            End If
            If Trim(xArticulo.Text) = "" Or Trim(xDescripcion.Text) = "" Then
                MsgError("Falta designar un Artículo")
                xArticulo.Focus()
                Exit Sub
            End If
            AgregarATabla()
            xArticulo.Clear()
            xDescripcion.Clear()
            xCantidad.Text = 1
            xArticulo.Focus()
        End If
    End Sub

    Private Sub xDescuento_TextChanged(sender As Object, e As EventArgs) Handles xDescuento.TextChanged
        ValidarDigitos(sender)
        If Val(xDescuento.Text) <= -1 Or xTabla.Rows.Count - 1 = 0 Then Exit Sub
        ObtenerTotales(False)
    End Sub

    Private Sub xDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescuento.KeyPress
        ValidarDigitos(e)
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        If e.KeyChar = ChrW(13) Then
            NextControl(sender)
        End If
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        If xTabla.ColSel = T_CANTIDAD Then
            xTabla.StartEditing()
        End If

        If xTabla.ColSel = T_ELIMINAR Then
            If Pregunta("¿Desea quitar este Artículo de la Tabla?") Then
                xTabla.RemoveItem(xTabla.RowSel)
                ObtenerTotales(False)
            End If
        End If
    End Sub

    Private Sub xTabla_AfterEdit(sender As Object, e As RowColEventArgs) Handles xTabla.AfterEdit
        xTabla.AjustarColumnas
    End Sub

    Private Sub xTabla_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles xTabla.ValidateEdit
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        Dim wValorAnterior = xTabla.GetData(xTabla.RowSel, T_CANTIDAD)

        If xTabla.ColSel = T_CANTIDAD Then
            Dim wCantidad = xTabla.Editor.Text '
            If Not IsNumeric(wCantidad) Then
                MsgError("El dato ingresado debe ser numérico")
                xTabla.Editor.Text = wValorAnterior
                Exit Sub
            Else
                If wCantidad = 0 Then
                    MsgError("No puedes ingresar cantidad 0")
                    xTabla.Editor.Text = wValorAnterior
                    Exit Sub
                End If
                xTabla.SetData(xTabla.RowSel, T_CANTIDAD, wCantidad)
                ObtenerTotales(True)
            End If
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Modulo = "VentaSucursal"
        BuscarArticulos.ShowDialog()
    End Sub

    Private Sub bCargar_Click(sender As Object, e As EventArgs) Handles bCargar.Click
        Dim wTicket As String = ""

        While Not IsNumeric(wTicket)
            InputPersonalizado.Inputbox("Ingrese el N° de Ticket a Cargar", "Cargar Ticket", "", wIcono)
            If InputPersonalizado.Response = MsgBoxResult.Cancel Then
                wTicket = ""
                Exit Sub
            Else
                wTicket = InputPersonalizado.RetornoTexto
            End If
            If wTicket.Trim = "" Then
                MsgError("El Campo Ticket no puede estar vacío ")
                Continue While
            Else
                If Not IsNumeric(wTicket) Then
                    MsgError("El Dato ingresado debe ser numérico")
                    Continue While
                End If
            End If
        End While
        CargarTicket(wTicket)
    End Sub

    Sub CargarTicket(ByVal wTicket As Integer)
        Tkg = SQL("SELECT * FROM TikGen WHERE Ticket=" & wTicket & "")
        If Tkg.EOF Then
            MsgError("El Ticket ingresado no Existe")
            Exit Sub
        End If
        Tkd = SQL("SELECT t.Articulo,a.Descripcion,t.Barra,t.Cantidad,t.PVenta, (t.Cantidad*t.PVenta) as Total " &
                  " FROM TikDet t INNER JOIN Articulos a on t.Articulo=a.Articulo " &
                  " WHERE Ticket=" & wTicket & "")
        If Tkd.EOF Then
            MsgError("Ticket sin Arttículos asociados")
            Exit Sub
        End If

        Titulos()
        xArticulo.Clear()
        xDescripcion.Clear()
        xCantidad.Text = 1
        xArticulo.Focus()
        BloquearBotones(False)
        Dim wFila As Integer = 1
        While Not Tkd.EOF
            DoEvents()
            xTabla.AddItem("")
            xTabla.SetCellImage(wFila, T_ELIMINAR, My.Resources.delete)
            xTabla.SetData(wFila, T_ARTICULO, Tkd.Fields("Articulo").Text)
            xTabla.SetData(wFila, T_DESCRIPCION, Tkd.Fields("Descripcion").Text)
            xTabla.SetData(wFila, T_BARRA, Tkd.Fields("Barra").Text)
            xTabla.SetData(wFila, T_CANTIDAD, Tkd.Fields("Cantidad").Text)
            xTabla.SetData(wFila, T_PRECIO, Tkd.Fields("PVenta").Text)
            xTabla.SetData(wFila, T_TOTAL, Tkd.Fields("Total").Text)
            wFila += 1
            Tkd.MoveNext()
        End While
        xTabla.AjustarColumnas
        ObtenerTotales(False)
        BloquearBotones(True)
    End Sub

    Sub BloquearBotones(ByVal wEstado As Boolean)
        bCargar.Enabled = wEstado
        bimprimir.Enabled = wEstado
        bBuscar.Enabled = wEstado
        bEmitir.Enabled = wEstado
        bLimpiar.Enabled = wEstado
        bCambiarCorrelativo.Enabled = wEstado
        bConsultaBoleta.Enabled = wEstado
        bCuadraturaCaja.Enabled = wEstado
        bVentaEspecial.Enabled = wEstado
        Me.KeyPreview = wEstado
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos()
    End Sub

    Sub LimpiarCampos()
        BloquearBotones(True)
        xArticulo.Clear()
        xDescripcion.Clear()
        xCantidad.Text = 1
        Titulos()
        xCantidadTabla.Text = 0
        xTotal.Text = 0
        xAbonado.Text = 0
        xDescuento.Text = 0
        xSubTotal.Text = 0
        xAbono.Text = 0
        xSaldo.Text = 0
        cDocumento.SelectedIndex = 0
        xBoleta.Text = ObtenerCorrelativo(wTipoDocumento)
        xArticulo.Focus()
    End Sub

    Private Sub bimprimir_Click(sender As Object, e As EventArgs) Handles bimprimir.Click
        Dim wTicket As String = ""
        While wTicket = "" Or Val(wTicket) = 0
            InputPersonalizado.Inputbox("Ingrese un Ticket a Re Imprimir", "Ticket a Re Imprimir", "", wIcono, True)
            If InputPersonalizado.Response = MsgBoxResult.Cancel Then
                wTicket = ""
                Exit Sub
            Else
                wTicket = InputPersonalizado.RetornoTexto
            End If
            If wTicket.Trim = "" Then
                Continue While
            Else
                If Not IsNumeric(wTicket) Then
                        MsgError("El Dato ingresado debe ser numérico")
                        Continue While
                    End If
                End If
        End While


        Dim wReporte As New ReporteVale

        Dim Lista = New List(Of ValeReporte)
        Swap = SQL("SELECT tg.Ticket,tg.Fecha,u.NombreUsr,td.Articulo,td.Cantidad," &
                   " td.PVenta,a.Descripcion,(td.Cantidad*td.PVenta) as Total " &
                   " FROM TikGen tg " &
                   " INNER JOIN TikDet td on tg.Ticket=td.Ticket " &
                   " INNER JOIN Articulos a on td.Articulo=a.Articulo " &
                   " INNER JOIN Usuarios u on tg.Usuario=u.Usuario " &
                   " WHERE td.Ticket=" & wTicket)

        While Not Swap.EOF
            Lista.Add(New ValeReporte With {.Ticket = Swap.Fields("Ticket").Text,
                                              .Fecha = Swap.Fields("Fecha").Text,
                                              .NombreUsr = Swap.Fields("NombreUsr").Text,
                                              .Articulo = Swap.Fields("Articulo").Text,
                                              .Cantidad = Swap.Fields("Cantidad").Text,
                                              .PVenta = Swap.Fields("PVenta").Text,
                                              .Descripcion = Swap.Fields("Descripcion").Text,
                                              .Total = Swap.Fields("Total").Text
                      })
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            wReporte.Database.Tables(0).SetDataSource(Lista)
            wVisor.Visor_Reporte.ReportSource = wReporte
            wReporte.PrintToPrinter(1, False, 0, 0)
        Else
            Mensaje("No hay datos para imprimir")
        End If


    End Sub

    Private Sub bEmitir_Click(sender As Object, e As EventArgs) Handles bEmitir.Click
        If xTabla.Rows.Count - 1 = 0 Then
            MsgError("No hay artículos agregados en la Tabla")
            xArticulo.Focus()
            Exit Sub
        End If

        If Not ValidarVenta() Then
            Exit Sub
        End If

        If xTotal.Text = "" Then xTotal.Text = 0
        TkG = SQL("SELECT TOP 1 Ticket,Fecha,Local,Usuario,Total,Estado FROM TikGen")
        TkG.AddNew()
        TkG.Fields("Fecha").Value = Now
        TkG.Fields("Local").Value = LocalActual
        TkG.Fields("Usuario").Value = UsuarioActual
        TkG.Fields("Total").Value = Trim(xTotal.Text)
        TkG.Fields("Estado").Value = "E"
        TkG.Update()
        TkG.MoveLast()
        Dim wTicket As String = TkG.Fields("Ticket").Value

        TkD = SQL("SELECT TOP 1 Ticket,Articulo,Barra,Cantidad,PVenta FROM TikDet")
        For i = 1 To xTabla.Rows.Count - 1
            TkD.AddNew()
            TkD.Fields("Ticket").Value = wTicket
            TkD.Fields("Articulo").Value = xTabla.GetData(i, T_ARTICULO)
            TkD.Fields("Barra").Value = xTabla.GetData(i, T_BARRA)
            TkD.Fields("Cantidad").Value = xTabla.GetData(i, T_CANTIDAD)
            TkD.Fields("PVenta").Value = xTabla.GetData(i, T_PRECIO)
            TkD.Update()
        Next
        Realizar_Venta(True, wTicket)
        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
    End Sub

    Sub Realizar_Venta(ByVal wVentaNormal As Boolean, ByVal wTicket As String)
        Dim wCorrelativo As Decimal
        If wTicket = 0 Then
            MsgError("Error al generar boleta")
            Exit Sub
        End If

        If wVentaNormal Then
            If Not Pregunta("¿Desea Emitir " & Trim(cDocumento.Text) & " ?") Then
                Exit Sub
            End If
        Else
            If Not Pregunta("¿Desea Emitir Venta Sin Boleta?") Then
                Exit Sub
            End If
        End If

        If wVentaNormal Then
            wCorrelativo = ObtenerCorrelativo(wTipoDocumento, True)
        End If

        TkG = SQL("SELECT Estado,Credito FROM TikGen WHERE Ticket=" & wTicket)
        If TkG.EOF Then
            MsgError("Error al generar la Venta")
            Exit Sub
        End If

        TkG.Fields("Estado").Value = "V"
        If Val(xTotal.Text) = Val(xAbono.Text) Then
            TkG.Fields("Credito").Value = False
        Else
            TkG.Fields("Credito").Value = True
        End If
        TkG.Update()

        Ven = SQL("Select Top 1 * FROM Ventas")

        Ven.AddNew()
        Ven.Fields("Ticket").Value = wTicket
        Ven.Fields("Fecha").Value = Now
        Ven.Fields("Usuario").Value = UsuarioActual
        Ven.Fields("Local").Value = LocalActual
        Ven.Fields("Caja").Value = CajaActual
        If wVentaNormal Then
            Ven.Fields("TipoDoc").Value = Mid(cDocumento.Text, 1, 1)
            Ven.Fields("NumDoc").Value = wCorrelativo
            Ven.Fields("FPago").Value = Mid(cFormaPago.Text, 1, 1)
        Else
            Ven.Fields("TipoDoc").Value = "S"
            Ven.Fields("NumDoc").Value = 0
            Ven.Fields("FPago").Value = "G"
        End If
        Ven.Fields("SubTotal").Value = CDbl(xSubTotal.Text)
        Ven.Fields("Descuento").Value = CDbl(xDescuento.Text)
        Ven.Fields("Total").Value = CDbl(xAbono.Text)
        Ven.Update()
        If wVentaNormal Then
            ImprimirBoleta(wTicket)
        End If

        If Val(xAbonado.Text) = 0 Then
            For i = 1 To xTabla.Rows.Count - 1
                Stocks(Trim(xTabla.GetData(i, T_ARTICULO)), Val(LocalActual), Val(LocalActual), xTabla.GetData(i, T_CANTIDAD), "-")
            Next
        End If

        Mensaje(Trim(cDocumento.Text) & " " & wCorrelativo)

        If wVentaNormal Then
            xBoleta.Text = ObtenerCorrelativo(wTipoDocumento)
        End If
        LimpiarCampos()
    End Sub

    Sub ImprimirBoleta(ByVal wTickets As String)

        Dim wReporte As New ReporteBoleta
        ' ModuloReporte = "ReporteBoleta"
        Dim Lista = New List(Of BoletaReporte)
        Swap = SQL("SELECT Ticket,Fecha,NumDoc,Total FROM Ventas WHERE Ticket=" & wTickets)

        While Not Swap.EOF
            Lista.Add(New BoletaReporte With {.NumDoc = Swap.Fields("NumDoc").Text,
                                              .Ticket = Swap.Fields("Ticket").Text,
                                              .Fecha = Swap.Fields("FECHA").Text,
                                              .Total = Swap.Fields("TOTAL").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            wReporte.Database.Tables(0).SetDataSource(Lista)
            wVisor.Visor_Reporte.ReportSource = wReporte
            wReporte.PrintToPrinter(1, False, 0, 0)
        Else
            Mensaje("Error al imprimir el ticket")
        End If

    End Sub

    Function ValidarVenta() As Boolean
        If xDescuento.Text = "" Then xDescuento.Text = 0
        If xAbonado.Text = "" Then xAbonado.Text = 0

        If Val(xTotal.Text) = 0 Then
            MsgError("No se puede generar una boleta con total 0")
            Return False
        End If
        If Trim(cFormaPago.Text) = "" Then
            MsgError("Falta designar una Forma de Pago")
            Return False
        End If
        FPa = SQL("SELECT FPago,DescFPago FROM FPagos WHERE DescFPago='" & Trim(cFormaPago.Text) & "'")
        If FPa.EOF Then
            MsgError("Forma de Pago no válida")
            cFormaPago.Focus()
            Return False
        End If
        If Trim(cDocumento.Text) = "" Then
            MsgError("Falta designar un Documento")
            cDocumento.Focus()
            Return False
        End If
        If Val(xDescuento.Text) < 0 Then
            MsgError("El Descuento no puede tener valor negativo")
            Return False
        End If
        If Val(xSubTotal.Text) < 0 Then
            MsgError("El Sub Total no puede tener valor negativo")
            Return False
        End If

        If Val(xAbono.Text) <= 0 Then
            MsgError("Falta ingresar el Monto a Cancelar")
            xAbonado.Focus()
            Return False
        End If
        If CDbl(xAbono.Text) > CDbl(xSubTotal.Text) Then
            MsgError("Error en el Pago")
            xAbono.Focus()
            Return False
        End If
        If CDbl(xSaldo.Text) < 0 Or CDbl(xSaldo.Text) > CDbl(xTotal.Text) Then
            MsgError("Error en el Monto de la venta")
            Return False
        End If

        If CajaActual = 0 Then
            CambiarCaja()
        End If
        If CajaActual = 0 Then
            Return False
        End If
        Return True
    End Function
    Sub CambiarCaja()
        Dim wCaja As String

        While CajaActual = 0
            InputPersonalizado.Inputbox("Ingrese el número de la Caja", "Número de Caja", "", wIcono, True)
            If InputPersonalizado.Response = MsgBoxResult.Cancel Then
                wCaja = ""
            Else
                wCaja = InputPersonalizado.RetornoTexto
            End If
            If wCaja.Trim = "" Then
                CajaActual = 0
                My.Settings.CAJA = CajaActual
                My.Settings.Save()
                Exit Sub
            Else
                If Not IsNumeric(wCaja) Then
                    MsgError("El Dato ingresado debe ser numérico")
                    Continue While
                End If
            End If
            CajaActual = Mid(wCaja, 1, 12)
            My.Settings.CAJA = CajaActual
            My.Settings.Save()
        End While
    End Sub

    Function CambiaCorrelativo(cLocal As Integer, cCaja As Integer, cTipoDoc As String, Boleta As Double) As Double
        Dim wCorrelativo As String = ""

        wCorrelativo = "1"
        Cor = SQL("Select Correlativo,Local,Caja,TipoDoc from Correlativos " &
                  " Where Local = " & cLocal & " And Caja = " & cCaja & " And TipoDoc = '" & cTipoDoc & "'")
        If Not Cor.EOF Then
            wCorrelativo = IIf(Val(Cor.Fields("Correlativo").Value) = 0, 1, Val(Cor.Fields("Correlativo").Value))
        Else
            Cor.AddNew()
            Cor.Fields("Correlativo").Value = 1
            Cor.Fields("Local").Value = cLocal
            Cor.Fields("Caja").Value = cCaja
            Cor.Fields("TipoDoc").Value = cTipoDoc
            Cor.AddNew()
            wCorrelativo = 1
        End If

        InputPersonalizado.Inputbox("Correlativo", "Cambio de Correlativo - Caja: " + Num(cCaja), wCorrelativo, wIcono, True)
        If InputPersonalizado.Response = MsgBoxResult.Cancel Then
            MsgError("No se cambió el correlativo.")
            CambiaCorrelativo = Val(Boleta)
            Exit Function
        End If
        wCorrelativo = InputPersonalizado.RetornoTexto

        Cor = SQL("Update Correlativos Set Correlativo = " & Num(wCorrelativo) & " " &
                  " Where Local = " & Num(cLocal) & " And Caja = " & Num(cCaja) & " And TipoDoc = '" & cTipoDoc & "'")
        Mensaje("Correlativo Actualizado " & Num(wCorrelativo))
        CambiaCorrelativo = Val(wCorrelativo)
    End Function

    Private Sub bCambiarCorrelativo_Click(sender As Object, e As EventArgs) Handles bCambiarCorrelativo.Click
        xBoleta.Text = CambiaCorrelativo(LocalActual, CajaActual, wTipoDocumento, Val(xBoleta.Text))
        xArticulo.Focus()
    End Sub

    Private Sub cDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cDocumento.SelectedIndexChanged
        If Trim(cDocumento.Text) = "" Then Exit Sub

        Doc = SQL("SELECT TipoDoc FROM TipoDoc WHERE DescTipoDoc='" & Trim(cDocumento.Text) & "' and TipoDoc in ('F','B')")
        If Doc.EOF Then
            MsgError("Documento seleccionado incorrecto")
            cDocumento.SelectedIndex = 0
            Exit Sub
        End If
        wTipoDocumento = Trim(Doc.Fields("TipoDoc").Value)
        xBoleta.Text = ObtenerCorrelativo(wTipoDocumento)
        wPrimeraPalabraDocumento = Split(cDocumento.Text, " ")
        bConsultaBoleta.Text = "Consultar " & wPrimeraPalabraDocumento(0)
    End Sub

    Private Sub bConsultaBoleta_Click(sender As Object, e As EventArgs) Handles bConsultaBoleta.Click
        ConsultaBoleta.WinDeco1.TituloVentana = bConsultaBoleta.Text
        ConsultaBoleta.lDocumento.Text = wPrimeraPalabraDocumento(0)
        ConsultaBoleta.wTipoDocumento = wTipoDocumento
        ConsultaBoleta.ShowDialog()
    End Sub

    Private Sub bCuadraturaCaja_Click(sender As Object, e As EventArgs) Handles bCuadraturaCaja.Click
        If ADMINISTRADOR Then
            CuadraturaCaja.ShowDialog()
        Else
            MsgError("No tienes los permisos suficientes para ejecutar esta opción")
        End If
    End Sub

    Private Sub VentaSucursal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If CajaActual = 0 Then
            CambiarCaja()
        End If
        If CajaActual = 0 Then
            Close()
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        DoEvents()
        xCaja.Text = CajaActual
        Titulos()
        CargarVendedor()
        cFormaPago.LoadItems("FPagos", "DescFPago")
        cFormaPago.SelectedIndex = 0
        cDocumento.LoadItems("TipoDoc", "DescTipoDoc", "TipoDoc in ('F','B')")
        cDocumento.SelectedIndex = 0
        xBoleta.Text = ObtenerCorrelativo(wTipoDocumento)
        xCantidadTabla.Text = xTabla.Rows.Count - 1
        Cursor = Cursors.Default
    End Sub

    Private Sub VentaSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
End Class