Imports System.ComponentModel

Public Class ManPrevisionSalud
    Implements iFormulario
    Private Sub ManUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xSalud.Focus()
        xSalud.Text = SiguienteCorrelativo("Salud")
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xSalud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xSalud.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xSalud_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xSalud.Validating
        Try
            If xSalud.Text.Trim <> "" Then
                Dim sl = SQL("SELECT * FROM Salud WHERE Salud = '" & Val(xSalud.Text) & "'")
                If sl.RecordCount > 0 Then
                    xDescripcion.Text = sl.Fields("DescSalud").Text.Trim
                    xPorcentaje.Text = sl.Fields("PorcentajeSalud").Text.Trim
                    bGuardar.Text = "Modificar"
                Else
                    xDescripcion.Focus()
                    bGuardar.Text = "Guardar"
                    xSalud.Text = SiguienteCorrelativo("Salud")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wAuditoria = ""
        If xSalud.Text = "" Then
            MsgError("Ingrese Numero de Tipo de Previsión de Salud")
            xSalud.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If
        If xPorcentaje.Text = "" Then
            MsgError("Ingrese Porcentaje de Previsión de Salud")
            xPorcentaje.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim sl = SQL("SELECT * FROM Salud WHERE Salud = '" & Val(xSalud.Text.Trim) & "'")
        If sl.RecordCount = 0 Then
            sl.AddNew()
            wMensaje = "Tipo de Previsión de Salud guardado corretamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "Tipo de Previsión de Salud modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        sl.Fields("DescSalud").Value = xDescripcion.Text.Trim
        sl.Fields("PorcentajeSalud").Value = Val(xPorcentaje.Text)
        sl.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xSalud.Clear()
        xDescripcion.Clear()
        bGuardar.Text = "Guardar"
        xPorcentaje.Clear()
        xSalud.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
        xSalud.Text = SiguienteCorrelativo("Salud")
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xSalud.Text.Trim <> "" Then
                If ValidarEliminar("Salud", xSalud.Text.Trim, "Salud") Then
                    MsgError("No se puede eliminar el Tipo de Previsión de Salud")
                Else
                    SQL("DELETE FROM Salud WHERE Salud = '" & Val(xSalud.Text) & "'")
                    MsgBox("Tipo de Previsión de Salud eliminado correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xSalud.Focus()
                End If
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(bGuardar)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT Salud, DescSalud as Descripción, PorcentajeSalud as Porcentaje FROM Salud"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescSalud", Me, "Previsión de Salud", xSalud)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xSalud.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xPorcentaje.KeyPress
        ValidarDigitos(e)
        e.NextControl(bGuardar)
    End Sub

    Private Sub bNuevo_Click(sender As Object, e As EventArgs) Handles bNuevo.Click
        xSalud.Text = SiguienteCorrelativo("Salud")
        xDescripcion.Focus()
    End Sub
End Class