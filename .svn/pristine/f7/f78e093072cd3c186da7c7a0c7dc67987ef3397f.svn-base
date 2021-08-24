Imports System.ComponentModel

Public Class ManEventosRem
    Implements iFormulario
    Private Sub ManEventosRem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xEvento.Focus()

        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xEvento.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xEvento_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xEvento.Validating
        Try
            If xEvento.Text.Trim <> "" Then
                Dim et = SQL("SELECT * FROM EventosRem WHERE EventoRem = " & xEvento.Text.Trim & "")
                If et.RecordCount > 0 Then
                    xDescripcion.Text = et.Fields("DesceventoRem").Text.Trim
                    xAccion.Text = et.Fields("CalculoRem").Text.Trim
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
        Dim wAuditoia = ""

        If xEvento.Text = "" Then
            MsgError("Ingrese Evento de Remuneración")
            xEvento.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If
        If xAccion.Text = "" Then
            MsgError("Ingrese Acción")
            xAccion.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim bg = SQL("SELECT * FROM EventosRem WHERE EventoRem = " & xEvento.Text.Trim & "")
        If bg.RecordCount = 0 Then
            bg.AddNew()
            wMensaje = "Evento guardado corretamente"
            wAuditoia = PR_GUARDAR
        Else
            wMensaje = "Evento modificado correctamente"
            wAuditoia = PR_MODIFICAR
        End If

        bg.Fields("EventoRem").Value = xEvento.Text.Trim
        bg.Fields("DescEventoRem").Value = xDescripcion.Text.Trim
        bg.Fields("CalculoRem").Value = xAccion.Text.Trim
        bg.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoia, "", 0)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xEvento.Clear()
        xDescripcion.Clear()
        xAccion.Clear()
        bGuardar.Text = "Guardar"
        xEvento.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xEvento.Text.Trim <> "" Then
                If ValidarEliminar("EventoRem", xEvento.Text.Trim, "EventosRem") Then
                    MsgError("No se puede eliminar el Evento de Remuneración")
                Else
                    SQL("DELETE FROM EventosRem WHERE EventoRem = " & xEvento.Text.Trim & "")
                    MsgBox("Evento eliminada correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xEvento.Focus()
                End If
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(xAccion)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT EventoRem as Evento, DescEventoRem as Descripción FROM EventosRem"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescEventoRem", Me, "Evenetos de Remuneración", xEvento)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xEvento.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
    Private Sub xAccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xAccion.KeyPress
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
        If (InStr("+-=" & Chr(8), e.KeyChar) = 0) Then
            e.KeyChar = ""
        End If
    End Sub
End Class