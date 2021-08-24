Imports System.ComponentModel

Public Class ManTipoDoc
    Implements iFormulario
    Private Sub ManTipoDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xTipoDoc.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xFamilia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTipoDoc.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xTipoDoc_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xTipoDoc.Validating
        Try
            If xTipoDoc.Text.Trim <> "" Then
                Dim fm = SQL("SELECT * FROM TipoDoc WHERE TipoDoc = '" & xTipoDoc.Text.Trim & "'")

                If fm.RecordCount > 0 Then
                    xDescripcion.Text = fm.Fields("DescTipoDoc").Text.Trim
                    xModulo.Text = fm.Fields("Modulo").Text.Trim
                    bGuardar.Text = "Modificar"
                Else
                    xDescripcion.Focus()
                    bGuardar.Text = "Guardar"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wAuditoria = ""

        If xTipoDoc.Text = "" Then
            MsgError("Ingrese Familia")
            xTipoDoc.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
        End If
        If xModulo.Text = "" Then
            MsgError("Ingrese Modulo")
            xModulo.Focus()
        End If
        Dim wMensaje As String
        Dim td = SQL("SELECT * FROM TIPODOC WHERE TIPODOC = '" & xTipoDoc.Text.Trim & "'")
        If td.RecordCount = 0 Then
            td.AddNew()
            wMensaje = "Tipo de Documento guardado corretamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "Tipo de Documento modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        td.Fields("TipoDoc").Value = xTipoDoc.Text.Trim
        td.Fields("DescTipoDoc").Value = xDescripcion.Text.Trim
        td.Fields("Modulo").Value = xModulo.Text.Trim
        td.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xTipoDoc.Clear()
        xDescripcion.Clear()
        xModulo.Clear()
        bGuardar.Text = "Guardar"
        xTipoDoc.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xTipoDoc.Text.Trim <> "" Then
                If ValidarEliminar("TipoDoc", xTipoDoc.Text.Trim, "TipoDoc") Then
                    MsgError("No se puede eliminar el Tipo de Documento")
                Else
                    SQL("DELETE FROM TIPODOC WHERE TIPODOC = '" & xTipoDoc.Text.Trim & "'")
                    MsgBox("Tipo de Documento eliminada correctamente")
                    Auditoria(Me.Text, PR_GUARDAR, "", 0)
                    Limpiar()
                    xTipoDoc.Focus()
                End If
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(xModulo)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT TipoDoc as Documento, DescTipoDoc as Descripcion FROM TipoDoc"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescTipoDoc", Me, "Clientes", xTipoDoc)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub xModulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xModulo.KeyPress
        e.NextControl(bGuardar)
    End Sub

    Private Sub xTipoDoc_TextChanged(sender As Object, e As EventArgs) Handles xTipoDoc.TextChanged

    End Sub

    Private Sub xModulo_TextChanged(sender As Object, e As EventArgs) Handles xModulo.TextChanged

    End Sub
End Class