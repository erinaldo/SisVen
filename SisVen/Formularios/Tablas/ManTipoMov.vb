Imports System.ComponentModel

Public Class ManTipoMov
    Implements iFormulario
    Private Sub ManTipoMov_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xTipoMov.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTipoMov.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xTipoMov_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xTipoMov.Validating
        Try
            If xTipoMov.Text.Trim <> "" Then
                Dim fm = SQL("SELECT * FROM TipoMov WHERE TipoMov = '" & xTipoMov.Text.Trim & "'")
                If fm.RecordCount > 0 Then
                    xDescripcion.Text = fm.Fields("DescTipo").Text.Trim
                    xAccion.Text = fm.Fields("Ajuste").Text.Trim
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

        If xTipoMov.Text = "" Then
            MsgError("Ingrese Tipo Movimiento")
            xTipoMov.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
        End If
        If xAccion.Text = "" Then
            MsgError("Ingrese Acción")
            xAccion.Focus()
        End If
        Dim wMensaje As String
        Dim td = SQL("SELECT * FROM TIPOMOV WHERE TIPOMOV = '" & xTipoMov.Text.Trim & "'")
        If td.RecordCount = 0 Then
            td.AddNew()
            wMensaje = "Tipo de Movimiento guardado corretamente"
            wAuditoria = PR_INGRESAR
        Else
            wMensaje = "Tipo de Movimiento modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        td.Fields("TipoMov").Value = xTipoMov.Text.Trim
        td.Fields("DescTipo").Value = xDescripcion.Text.Trim
        td.Fields("Ajuste").Value = xAccion.Text.Trim
        td.Fields("Visible").Value = 1
        td.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xTipoMov.Clear()
        xDescripcion.Clear()
        xAccion.Clear()
        bGuardar.Text = "Guardar"
        xTipoMov.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xTipoMov.Text.Trim <> "" Then
                If ValidarEliminar("TipoMov", xTipoMov.Text.Trim, "TipoMov") Then
                    MsgError("No se puede eliminar el Tipo de Movimiento")
                Else
                    SQL("DELETE FROM TIPOMOV WHERE TIPOMOV = '" & xTipoMov.Text.Trim & "'")
                    MsgBox("Tipo de Movimiento eliminada correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xTipoMov.Focus()
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
        Dim wQuery = "SELECT TipoMov as Movimiento, DescTipo as Descripción FROM TipoMov"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescTipo", Me, "Tipo de Movimiento", xTipoMov)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub xAccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xAccion.KeyPress
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
        If (InStr("+-" & Chr(8), e.KeyChar) = 0) Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xTipoMov.Focus()
    End Sub
End Class