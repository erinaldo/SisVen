Imports System.ComponentModel

Public Class Consulta_Stock

    Const T_BODEGA = 0
    Const T_NOMBRE = 1
    Const T_TOTAL = 2
    Const T_DISPONIBLE = 3
    Const T_RESERVADO = 4
    Const T_BLOQUEADO = 5


    Private Sub Titulos()

        xTabla.Redraw = False

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 6

        xTabla.Cols(T_BODEGA).Width = 60
        xTabla.Cols(T_NOMBRE).Width = 60
        xTabla.Cols(T_TOTAL).Width = 60
        xTabla.Cols(T_DISPONIBLE).Width = 100
        xTabla.Cols(T_RESERVADO).Width = 150
        xTabla.Cols(T_BLOQUEADO).Width = 140

        xTabla.Cols(T_BODEGA).Caption = "Bodega"
        xTabla.Cols(T_NOMBRE).Caption = "Nombre"
        xTabla.Cols(T_TOTAL).Caption = "Total"
        xTabla.Cols(T_DISPONIBLE).Caption = "Disponible"
        xTabla.Cols(T_RESERVADO).Caption = "Reservado"
        xTabla.Cols(T_BLOQUEADO).Caption = "Bloqueado"

        xTabla.Redraw = True

    End Sub



    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Public Sub CargarBodegas()
        cBodega.Items.Clear()

        Bod = SQL("SELECT * FROM Bodegas BO JOIN Bodegas_Busqueda BU ON BO.Bodega = BU.Bodega" &
                  " WHERE BO.Local IN(" & LocalActual & ", 0) AND Cliente = " & xCliente.Text)

        If Bod.RecordCount > 0 Then
            cBodega.Items.Add("TODAS")
            cBodega.Items.Add("ANDENES")
            While Not Bod.EOF
                cBodega.Items.Add(Bod.Fields("NombreBodega").Text)
                If Bod.Fields("Principal").Text = True Then
                    xBodega.Text = Bod.Fields("Bodega").Text
                    cBodega.Text = Bod.Fields("NombreBodega").Text
                End If
                Bod.MoveNext()
            End While
            cBodega.Focus()
        Else
            MsgError("El Cliente no tiene bodegas habilitadas.")
            Limpiar()
            xCliente.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub xCliente__KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            cBodega.Focus()
        End If
    End Sub

    Private Sub xCliente_Validating(Optional sender As Object = Nothing, Optional e As System.ComponentModel.CancelEventArgs = Nothing) Handles xCliente.Validating
        ValidarDigitos(sender)

        If Val(xCliente.Text) > 0 Then
            If xNombreCliente.SelectItem("Clientes", "Cliente", Val(xCliente.Text), "Nombre") Then
                CargarBodegas()
            Else
                MsgError("El Cliente ingresado no existe o no corresponde al Centro de Distribución actual.")
                xCliente.Clear()
                xNombreCliente.Clear()
                xCliente.Focus()
            End If
        Else
            xCliente.Clear()
            xNombreCliente.Clear()
            xCliente.Focus()
        End If

    End Sub


    Private Sub cBodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cBodega.KeyPress
        If e.KeyChar = vbCr Then
            xSKU.Focus()
        End If
    End Sub
    Private Sub xSKU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xSKU.KeyPress
        If e.KeyChar = vbCr Then
            bCalcular.Focus()
        End If
    End Sub

    Public Sub xSKU_Validating(Optional sender As Object = Nothing, Optional e As System.ComponentModel.CancelEventArgs = Nothing) Handles xSKU.Validating

        Dim wCliente As Double
        Dim wBodega As Integer

        If xSKU.Text <> "" Then

            wCliente = Val(xCliente.Text)
            wBodega = Val(xBodega.Text)

            If wCliente = 0 Then
                MsgError("Debe ingresar un Cliente.")
                xSKU.Text = ""
                xCliente.Focus()
                Exit Sub
            End If

            If wBodega = 0 And Not cBodega.Text = "TODAS" Then
                MsgError("Debe indicar una bodega.")
                xSKU.Text = ""
                cBodega.Focus()
                Exit Sub
            End If
            CargarArticulo(xSKU.Text, wCliente)
        Else
            xArticulo.Clear()
            xDescripcion.Clear()
        End If
    End Sub

    Public Sub CargarArticulo(ByVal wId As String)
        CargarArticulo(wId, Val(xCliente.Text))
        xSKU_Validating()
        bCalcular.Focus()
    End Sub
    Private Function CargarArticulo(ByVal wId As String, ByVal wCliente As Double) As Boolean

        wId = wId.Trim
        xDescripcion.Clear()
        xArticulo.Clear()

        Art = SQL("SELECT Articulo, SKU, Descripcion FROM Articulos WHERE SKU = '" & wId & "' and Cliente = " & Num(wCliente))
        If Art.RecordCount <> 0 Then
            xArticulo.Text = Art.Fields("Articulo").Text
            xSKU.Text = Art.Fields("SKU").Text
            xDescripcion.Text = Art.Fields("Descripcion").Text
        Else
            Art = SQL("SELECT Articulo, SKU, Descripcion FROM Articulos WHERE Articulo = '" & Val(wId) & "' and Cliente = " & Num(wCliente))
            If Art.RecordCount <> 0 Then
                xArticulo.Text = Art.Fields("Articulo").Text
                xSKU.Text = Art.Fields("SKU").Text
                xDescripcion.Text = Art.Fields("Descripcion").Text
            Else
                Cursor = Cursors.Arrow
                MsgError("Artículo o SKU no Encontrado: " + wId + vbCrLf + "Cliente: " + Num(wCliente))
                xSKU.Text = ""
                xSKU.Focus()
                Return False
            End If
        End If
        Return True
    End Function



    Public Sub Calcular_Stock(wCliente, wBodega, wArticulo)
        xCliente.Text = wCliente
        xCliente_Validating()

        If wBodega = 0 Then
            xBodega.Clear()
            cBodega.Text = "TODAS"
        Else
            xBodega.Text = wBodega
            xBodega_Validating()
        End If

        xSKU.Text = wArticulo
        xSKU_Validating()

        bCalcular_Click()

    End Sub

    Public Sub xBodega_Validating(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles xBodega.Validating
        ValidarDigitos(sender)

        If Not cBodega.SelectItem("Bodegas", "Bodega", Val(xBodega.Text), "NombreBodega") Then
            xBodega.Clear()
            xBodega.Focus()
        End If

    End Sub


    Private Sub bCalcular_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bCalcular.Click
        Dim wCliente, wBodega, wArticulo As Double
        Dim wFila As Integer
        Dim wFiltro As String = ""

        wCliente = Val(xCliente.Text)
        wBodega = Val(xBodega.Text)
        wArticulo = Val(xArticulo.Text)

        If wCliente = 0 Then MsgError("Debe ingresar un Cliente") : Exit Sub
        If wArticulo = 0 Then MsgError("Debe ingresar un Artículo") : Exit Sub
        If wBodega > 0 Then wFiltro = " AND Paquetes.Bodega = " & wBodega

        Titulos()

        Bod = SQL("SELECT DISTINCT Bodegas.Bodega, Bodegas.NombreBodega FROM Paquetes JOIN Bodegas ON Paquetes.Bodega = Bodegas.Bodega WHERE Paquetes.Bodega <> 9999 AND Cliente = " & wCliente & " AND Articulo = " & wArticulo & wFiltro)
        If Bod.RecordCount = 0 Then
            MsgError("No se han encontrado paquetes para este Artículo.")
        Else
            While Not Bod.EOF


                wBodega = Bod.Fields("Bodega").Value

                xTabla.AddItem("")

                wFila = xTabla.Rows.Count - 1

                xTabla.SetData(wFila, T_BODEGA, wBodega)
                xTabla.SetData(wFila, T_NOMBRE, Bod.Fields("NombreBodega").Text)

                'xTabla.SetData(wFila, T_DISPONIBLE, CalcularStock(wCliente, wArticulo, wBodega, EstadoPaquete.Disponible))
                'xTabla.SetData(wFila, T_RESERVADO, CalcularStock(wCliente, wArticulo, wBodega, EstadoPaquete.Reservado))
                'xTabla.SetData(wFila, T_BLOQUEADO, CalcularStock(wCliente, wArticulo, wBodega, EstadoPaquete.Bloqueado))

                Bod.MoveNext()
            End While
        End If

        xTabla.AjustarColumnas

        xTotal.Text = xTabla.SumarValoresColumna(T_TOTAL)
        xDisponible.Text = xTabla.SumarValoresColumna(T_DISPONIBLE)
        xReservado.Text = xTabla.SumarValoresColumna(T_RESERVADO)
        xBloqueado.Text = xTabla.SumarValoresColumna(T_BLOQUEADO)

        Auditoria(Me.Text, "Consulta de Stock", "", 0)

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Consulta_Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xCliente.Clear()
        xNombreCliente.Clear()
        xSKU.Clear()
        xArticulo.Clear()
        xDescripcion.Clear()
        xTotal.Text = 0
        xDisponible.Text = 0
        xReservado.Text = 0
        xBloqueado.Text = 0
        xBodega.Text = ""
        cBodega.Text = ""
        cBodega.Items.Clear()
        xCliente.Focus()

        Titulos()

    End Sub





    Private Sub cBodega_Validating(sender As Object, e As CancelEventArgs) Handles cBodega.Validating
        If Trim(cBodega.Text) <> "" Then

            If cBodega.Text = "TODAS" Then
                xBodega.Text = ""
                DoEvents()
                Exit Sub
            End If

            Dim wFiltro As String = ""
            If LocalActual <> 0 Then
                wFiltro = " And Local =" & LocalActual
            End If

            xBodega.Text = cBodega.GetValue("Bodegas", "NombreBodega", "Bodega")
            If xBodega.Text = "" Then
                MsgError("No se encuentra la bodega indicada.")
                xBodega.Text = ""
                cBodega.Text = ""
                cBodega.Focus()
                Exit Sub
            End If



            'Bod = SQL("SELECT Bodega FROM Bodegas WHERE NombreBodega='" & Trim(cBodega.Text) & "'" & wFiltro)
            'If Bod.RecordCount <> 0 Then
            '    xBodega.Text = Bod.Fields("Bodega").Value
            'Else
            '    MsgError("No se encuentra la bodega indicada.")
            '    xBodega.Text = ""
            '    cBodega.Text = ""
            '    cBodega.Focus()
            '    Exit Sub
            'End If
        Else
            xBodega.Text = ""
        End If
    End Sub







    Private Sub xBodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBodega.KeyPress
        If e.KeyChar = vbCr Then
            cBodega.Focus()
        End If
    End Sub
End Class
