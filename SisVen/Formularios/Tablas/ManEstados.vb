Imports System.ComponentModel

Public Class ManEstados
    Implements iFormulario
    Private Sub ManBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xEstado.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xEstado.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xEstado_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xEstado.Validating
        Try
            If xEstado.Text.Trim <> "" Then
                Dim et = SQL("SELECT * FROM Estados WHERE Estado = '" & xEstado.Text.Trim & "'")
                If et.RecordCount > 0 Then
                    xDescripcion.Text = et.Fields("DescEstado").Text.Trim
                    xTipo.Text = et.Fields("Tipo").Text.Trim
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

        If xEstado.Text = "" Then
            MsgError("Ingrese Estado")
            xEstado.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If
        If xTipo.Text = "" Then
            MsgError("Ingrese Tipo")
            xTipo.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim bg = SQL("SELECT * FROM Estados WHERE Estado = '" & xEstado.Text.Trim & "'")
        If bg.RecordCount = 0 Then
            bg.AddNew()
            wMensaje = "Estado guardado corretamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "Estado modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        bg.Fields("Estado").Value = xEstado.Text.Trim
        bg.Fields("DescEstado").Value = xDescripcion.Text.Trim
        bg.Fields("Tipo").Value = xTipo.Text.Trim
        bg.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xEstado.Clear()
        xDescripcion.Clear()
        xTipo.Clear()
        bGuardar.Text = "Guardar"
        xEstado.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xEstado.Text.Trim <> "" Then
                If ValidarEliminar("Estado", xEstado.Text.Trim, "Estados") Then
                    MsgError("No se puede eliminar el Tipo de Movimiento")
                Else
                    SQL("DELETE FROM Estados WHERE Estado = '" & xEstado.Text.Trim & "'")
                    MsgBox("Estado eliminada correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xEstado.Focus()
                End If
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(xTipo)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT Estado, DescEstado as Descripción FROM Estados"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescEstado", Me, "Estados", xEstado)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xEstado.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
End Class