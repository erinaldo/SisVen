Imports System.ComponentModel

Public Class ManAccesos
    Implements iFormulario
    Private Sub ManUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xAcceso.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xAcceso.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xUnidad_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xAcceso.Validating
        Try
            If xAcceso.Text.Trim <> "" Then
                Dim et = SQL("SELECT * FROM Accesos WHERE Acceso = '" & xAcceso.Text.Trim & "'")
                If et.RecordCount > 0 Then
                    xDescripcion.Text = et.Fields("DescAcceso").Text.Trim
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

        If xAcceso.Text = "" Then
            MsgError("Ingrese Numero Acceso")
            xAcceso.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim bg = SQL("SELECT * FROM Accesos WHERE Acceso = '" & Val(xAcceso.Text.Trim) & "'")
        If bg.RecordCount = 0 Then
            bg.AddNew()
            wMensaje = "Acceso guardado corretamente"
        Else
            wMensaje = "Acceso modificado correctamente"
        End If

        bg.Fields("Acceso").Value = Val(xAcceso.Text)
        bg.Fields("DescAcceso").Value = xDescripcion.Text.Trim

        bg.Update()
        MsgBox(wMensaje)
        Limpiar()
        Auditoria(Me.Text, PR_ELIMINAR, "", 0)
    End Sub

    Private Sub Limpiar()
        xAcceso.Clear()
        xDescripcion.Clear()
        bGuardar.Text = "Guardar"
        xAcceso.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xAcceso.Text.Trim <> "" Then
                If ValidarEliminar("Acceso", xAcceso.Text.Trim, "Accesos") Then
                    MsgError("No se puede eliminar el Acceso")
                Else
                    SQL("DELETE FROM Accesos WHERE Acceso = '" & xAcceso.Text.Trim & "'")
                    MsgBox("Acceso eliminado correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xAcceso.Focus()
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
        Buscador.Show()
        'Buscador.Configurar("Acceso,DescAcceso", "Accesos", "DescAcceso", Me, "Accesos", xAcceso)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xAcceso.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
End Class