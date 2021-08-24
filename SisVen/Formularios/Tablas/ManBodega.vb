Imports System.ComponentModel

Public Class ManBodega
    Implements iFormulario
    Private Sub ManBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
        bGuardar.Text = "Guardar"
        xBodega.Focus()
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
    End Sub
    Private Sub xBodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBodega.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xBodega_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xBodega.Validating
        Try
            If xBodega.Text.Trim <> "" Then
                Dim bg = SQL("SELECT * FROM Bodegas WHERE Bodega = '" & xBodega.Text.Trim & "'")
                If bg.RecordCount > 0 Then
                    xDescripcion.Text = bg.Fields("NombreBodega").Text.Trim
                    xLocal.Text = bg.Fields("Local").Text.Trim
                    bGuardar.Text = "Modificar"
                    xLocal_Validating()
                Else
                    xDescripcion.Focus()
                    bGuardar.Text = "Guardar"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If xBodega.Text = "" Then
            MsgError("Ingrese Bodega")
            xBodega.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
        End If
        If xLocal.Text = "" Then
            MsgError("Ingrese Local")
            xLocal.Focus()
        End If
        Dim wMensaje As String
        Dim bg = SQL("SELECT * FROM Bodegas WHERE Bodega = '" & xBodega.Text.Trim & "'")
        If bg.RecordCount = 0 Then
            bg.AddNew()
            wMensaje = "Bodega guardado corretamente"
        Else
            wMensaje = "Bodega modificado correctamente"
        End If

        bg.Fields("Bodega").Value = xBodega.Text.Trim
        bg.Fields("NombreBodega").Value = xDescripcion.Text.Trim
        bg.Fields("Local").Value = xLocal.Text.Trim
        bg.Update()
        MsgBox(wMensaje)
        Limpiar()
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
    End Sub

    Private Sub Limpiar()
        xBodega.Clear()
        xDescripcion.Clear()
        xLocal.Clear()
        bGuardar.Text = "Guardar"
        xBodega.Focus()
        cLocal.SelectedIndex = -1
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xBodega.Text.Trim <> "" Then
                If ValidarEliminar("Bodega", xBodega.Text.Trim, "Bodegas") Then
                    MsgError("No se puede eliminar el Tipo de Movimiento")
                Else
                    SQL("DELETE FROM TIPOMOV WHERE TIPO = '" & xBodega.Text.Trim & "'")
                    MsgBox("Tipo de Movimiento eliminada correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xBodega.Focus()
                End If
                End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(xLocal)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT Bodega, NombreBodega as 'Nombre de Bodega' FROM Bodegas"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreBodega", Me, "Bodegas", xBodega)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
        xLocal_Validating()
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xBodega.Focus()
    End Sub

    Private Sub xLocal_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xLocal.Validating
        If xLocal.Text.Trim <> "" Then
            cLocal.SelectedValue = xLocal.Text.Trim
            If cLocal.Text = W_SELECCIONAR Then
                MsgError("Local no encontrado")
                xLocal.Clear()
                xLocal.Focus()
            End If
        End If
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            xLocal.Text = cLocal.SelectedValue
        Else
            xLocal.Clear()
        End If
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        e.NextControl(cLocal)
    End Sub

    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cLocal.KeyPress
        e.NextControl(bGuardar)
    End Sub
End Class