Public Class StockPorDocumento
    Private Sub xNumDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNumDoc.KeyPress
        ValidarDigitos(e)
        e.NextControl(cBodegaIngreso)
    End Sub

    Private Sub xNumDoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xNumDoc.Validating
        If xNumDoc.Text.Trim = "" Then Exit Sub

        Dim wDoc = SQL("SELECT DG.Numero, Lo.Local,Bo.Bodega, Lo.NombreLocal, Bo.NombreBodega, DG.StockTraspasado" &
                       " FROM DocumentosG DG" &
                       " JOIN Locales Lo ON DG.Local = Lo.Local" &
                       " JOIN Bodegas Bo ON DG.Bodega = Bo.Bodega " &
                       " WHERE DG.Numero = " & xNumDoc.Text.Trim & "And DG.TipoDoc = '" & cTipoDoc.SelectedValue & "'" &
                       " AND DG.Local = " & LocalActual)

        If wDoc.RecordCount = 1 Then

            If wDoc.Fields("StockTraspasado").Text Then
                MsgError("Este documento ya fue ingresado en Stock")
                LimpiarCampos(Me)
                xNumDoc.Focus()
                Exit Sub
            End If

            Dim wBodD = SQL("SELECT * FROM Bodegas  WHERE Local = " & Val(wDoc.Fields("Local").Text) & "" &
                            " AND Despacho = 1")
            If wBodD.RecordCount > 0 Then
                xBodega.Text = wBodD.Fields("NombreBodega").Text
                xLocal.Text = wDoc.Fields("NombreLocal").Text
                xLocal.Tag = wDoc.Fields("Local").Text
                xBodega.Tag = wBodD.Fields("Bodega").Text
                cBodegaIngreso.LoadCombobox("Bodegas", "Bodega", "NombreBodega", " WHERE Local = " & Val(wDoc.Fields("Local").Text) & "" &
                                        " AND Movil = 1")
            Else
                MsgError("El local no tiene bodega de Despacho")
                Exit Sub
            End If

        Else
            MsgError("Documento no existente")
            xNumDoc.Clear()
            xNumDoc.Focus()
        End If
    End Sub
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
        xNumDoc.Focus()
        cTipoDoc.SelectedValue = "GD"
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If xNumDoc.Text.Trim = "" Then
            MsgError("Debe indicar número de documento")
            Exit Sub
        End If
        If Not ValidarCombo(cBodegaIngreso) Then
            MsgError("Debe indicar Bodega")
            cBodegaIngreso.Focus()
            Exit Sub
        End If

        Dim wDoc = SQL("SELECT Articulo, Cantidad FROM DocumentosD WHERE Local = " & LocalActual & " and TipoDoc = '" & BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", cTipoDoc.Text) & "' and Numero = " & xNumDoc.Text.Trim & "")
        If wDoc.RecordCount > 0 Then
            While Not wDoc.EOF
                Dim wStock = SQL("SELECT * FROM Stocks WHERE Local = " & Val(xLocal.Tag) & "" &
                           " AND Bodega = " & Val(xBodega.Tag) & "" &
                           " AND Stock >= " & Val(wDoc.Fields("Cantidad").Text) & "" &
                           " AND Articulo = '" & wDoc.Fields("Articulo").Text & "'")

                If wStock.RecordCount = 0 Then
                    Dim wArt = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & wDoc.Fields("Articulo").Text & "'")
                    MsgError("El Artículo " & wArt.Fields("Descripcion").Text & " no tiene existencia")
                    Exit Sub
                End If

                wDoc.MoveNext()
            End While

            wDoc.MoveFirst()

            While Not wDoc.EOF
                'Agregar a Bodega Seleccionada
                Stocks(wDoc.Fields("Articulo").Text, cBodegaIngreso.SelectedValue, Val(xLocal.Tag), wDoc.Fields("Cantidad").Text, "+")
                Stocks(wDoc.Fields("Articulo").Text, Val(xBodega.Tag), Val(xLocal.Tag), wDoc.Fields("Cantidad").Text, "-")
                wDoc.MoveNext()
            End While
            SQL("UPDATE DocumentosG SET StockTraspasado = 1 WHERE Numero = " & Val(xNumDoc.Text) & " AND TipoDoc = 'GD' AND Local = " & LocalActual)
            MsgBox("Stocks Ingresados Correctamente")
            LimpiarCampos(Me)
            xNumDoc.Focus()
            Exit Sub
        Else
            MsgError("Número de documento no existente")
        End If
    End Sub
    Private Sub StockPorDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cTipoDoc.LoadCombobox("TipoDoc", "TipoDoc", "DescTipoDoc")
        cTipoDoc.SelectedValue = "GD"
    End Sub

    Private Sub bVisualizar_Click(sender As Object, e As EventArgs) Handles bVisualizar.Click
        Dim wFiltros = ""
        Dim wQuery = ""
        Dim wTipoDoc As String = ""


        If ValidarCombo(cTipoDoc) = False Then
            MsgError("Ingrese Tipo de Documento")
            cTipoDoc.Focus()
            Exit Sub
        End If

        If xNumDoc.Text.Trim = "" Then
            MsgError("Ingrese Número de Documento")
            xNumDoc.Focus()
            Exit Sub
        End If

        If Buscar("TipoDoc", "DescTipoDoc", cTipoDoc.Text.Trim, "TipoDoc") Then
            wTipoDoc = Swap.Fields("TipoDoc").Value
        Else
            MsgError("Error en Tipo de Documento")
            cTipoDoc.Focus()
        End If

        wQuery = "Select Numero from DocumentosG where Local = " & LocalActual & " and TipoDoc = '" & cTipoDoc.SelectedValue & "' and Numero = " & xNumDoc.Text
        Swap = SQL(wQuery)

        If Swap.RecordCount = 0 Then
            MsgError("Documento No Encontrado")
            Exit Sub
        End If

        Auditoria(cTipoDoc.Text, PR_IMPRIMIR, Num(xNumDoc.Text))

        bVisualizar.Enabled = False
        Imprimir_Documento(LocalActual, wTipoDoc.Trim, Val(xNumDoc.Text), cTipoDoc.Text, True)
        bVisualizar.Enabled = True
    End Sub
End Class