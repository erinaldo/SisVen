Public Class AnularDocumento
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub AnularDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        If Acceso_Usuario(UsuarioActual) >= 5 Then
            cTipoDoc.LoadCombobox("TipoDoc", "TipoDoc", "DescTipoDoc", "")
        Else
            cTipoDoc.LoadCombobox("TipoDoc", "TipoDoc", "DescTipoDoc", "Where Electronica=0")
        End If
    End Sub

    Private Sub xDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDocumento.KeyPress
        ValidarDigitos(e)
        e.NextControl(bAnular)
    End Sub

    Private Sub bAnular_Click(sender As Object, e As EventArgs) Handles bAnular.Click
        Dim wDatos = ""
        Dim xModo = ""

        If Not ValidarCombo(cLocal) Then
            MsgError("Indique Local")
            cLocal.Focus()
            Exit Sub
        End If

        If Not ValidarCombo(cTipoDoc) Then
            MsgError("Indique tipo documento")
            cTipoDoc.Focus()
            Exit Sub
        End If
        If xDocumento.Text.Trim = "" Then
            MsgError("Indique número de documento")
            xDocumento.Focus()
            Exit Sub
        End If

        DocG = SQL("SELECT * FROM DocumentosG WHERE Local = " & cLocal.SelectedValue & " AND TipoDoc = '" & cTipoDoc.SelectedValue & "' AND Numero = " & xDocumento.Text.Trim)
        If DocG.RecordCount = 0 Then
            MsgError("Documento no encontrado")
            Exit Sub
        Else
            wDatos = "Cliente: (" & (DocG.Fields("Cliente").Text) & ") "
            If Buscar("Clientes", "Cliente", DocG.Fields("Cliente").Text, "Nombre") Then
                wDatos = wDatos & " " & DocG.Fields("Rut").Text & " " & Swap.Fields("Nombre").Text
            End If
            wDatos = wDatos & vbCrLf
            wDatos = wDatos & "Fecha: " & Format(DocG("Fecha").Value, "dd/mm/yyyy") & vbCrLf
            wDatos = wDatos & "Monto: " & Format(DocG("Total").Value, "###,###,###")
        End If

        'Verificar Si es Electrónica
        If DocG("Status_DTE").Value = 0 Or DocG("STatus_DTE").Value = 3 Then
            'El documento no es electrónico o no se envio a SII
        Else
            MsgError("Documento es Electrónico o fué enviado a SII, no se puede anular")
            Exit Sub
        End If

        If oEliminar.Checked Then
            If DocG.Fields("Estado").Text = "N" Then
                MsgError("Documento ya Anulado")
                Exit Sub
            End If
        End If

        If oEliminar.Checked Then
            Pregunta("Seguro de Anular y Eliminar " & cTipoDoc.Text.Trim & " " & xDocumento.Text.Trim & vbCrLf & wDatos)
        Else
            Pregunta("Seguro de Anular " & cTipoDoc.Text & " " & xDocumento.Text.Trim & vbCrLf & wDatos)
        End If
        If Respuesta = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            If oEliminar.Checked Then
                Call Auditoria(Me.Name, "Anular y Eliminar Documento", cTipoDoc.Text, xDocumento.Text.Trim)
            Else
                Call Auditoria(Me.Name, "Anular Documento", cTipoDoc.Text, xDocumento.Text.Trim)
            End If
            'Invertir Modo
            Swap = SQL("Select * from TipoDoc where TipoDoc = '" + DocG("TipoDoc").Value + "'")
            If Swap.RecordCount > 0 Then
                xModo = Swap("Modo").Value
            End If
            If xModo = "+" Then
                xModo = "-"
            Else
                If xModo = "-" Then
                    xModo = "+"
                Else
                    xModo = "+"
                End If
            End If

            Dim xBodega = IIf(DocG.Fields("Bodega").Text = "", 0, DocG.Fields("Bodega").Text)

            DocG.Fields("Estado").Value = "N"
            DocG.Fields("Aprobado").Value = False
            DocG.Fields("SubTotal").Value = 0
            DocG.Fields("Descuento").Value = 0
            DocG.Fields("Neto").Value = 0
            DocG.Fields("IVA").Value = 0
            DocG.Fields("Total").Value = 0
            DocG.Update()

            If oEliminar.Checked Then
                DocG = SQL("Delete DocumentosG where Local = " & cLocal.SelectedValue & " and TipoDoc = '" & cTipoDoc.SelectedValue & "' and Numero = " & xDocumento.Text.Trim)
            End If

            DocD = SQL("Select * from DocumentosD where Local = " & cLocal.SelectedValue & " and TipoDoc = '" & cTipoDoc.SelectedValue & "' and Numero = " & xDocumento.Text.Trim)
            If DocD.RecordCount > 0 Then
                While Not DocD.EOF
                    'Actualizar Stocks
                    If DocD.Fields("Articulo").Text.Trim <> "X" Then
                        Dim Stock = Stocks(DocD.Fields("Articulo").Text, Val(xBodega), cLocal.SelectedValue, DocD.Fields("Cantidad").Text, xModo)
                    End If
                    DocD.MoveNext()
                End While
            End If
            'Eliminar Detalles
            DocD = SQL("Delete DocumentosD where Local = " & cLocal.SelectedValue & " and TipoDoc = '" & cTipoDoc.SelectedValue & "' and Numero = " & xDocumento.Text.Trim)
            'Eliminar Pagos
            DocP = SQL("Delete DocumentosP where Local = " & cLocal.SelectedValue & " and TipoDoc = '" & cTipoDoc.SelectedValue & "' and Numero = " & xDocumento.Text.Trim)

            If cTipoDoc.SelectedValue = "FV" Or cTipoDoc.SelectedValue = "BO" Then
                'Actualizar Ventas
                Ven = SQL("Delete Ventas where Local = " & cLocal.SelectedValue & " and TipoDoc = '" & cTipoDoc.SelectedValue & "' and NumDoc = " & xDocumento.Text.Trim)
                'Liberar Guias
                'Swap = SQL("Update DocumentosG set Factura=0 where TipoDoc = 'G' and Factura = " & xDocumento.Text.Trim)
            End If

            Me.Cursor = Cursors.Default
            If oEliminar.Checked Then
                MsgBox("Documento Anulado y Eliminado")
            Else
                MsgBox("Documento Anulado")
            End If
            'LimpiarCampos(Me)
            Limpiar
        End If

    End Sub

    Sub Limpiar()
        xDocumento.Text = ""
        oEliminar.Checked = False
        xDocumento.Focus()
    End Sub

    Private Sub oEliminar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged

    End Sub
End Class