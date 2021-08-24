Imports System.ComponentModel

Public Class ManUnidades
    Implements iFormulario
    Private Sub ManUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xUnidad.Focus()
    End Sub
    Private Sub xTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xUnidad.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xUnidad_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xUnidad.Validating
        Try
            If xUnidad.Text.Trim <> "" Then
                Dim et = SQL("SELECT * FROM Unidades WHERE Unidad = '" & xUnidad.Text.Trim & "'")
                If et.RecordCount > 0 Then
                    xDescripcion.Text = et.Fields("DescUnidad").Text.Trim
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

        If xUnidad.Text = "" Then
            MsgError("Ingrese Unidad")
            xUnidad.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim bg = SQL("SELECT * FROM Unidades WHERE Unidad = '" & xUnidad.Text.Trim & "'")
        If bg.RecordCount = 0 Then
            bg.AddNew()
            wMensaje = "Unidad guardado corretamente"
        Else
            wMensaje = "Unidad modificado correctamente"
        End If

        bg.Fields("Unidad").Value = xUnidad.Text.Trim
        bg.Fields("DescUnidad").Value = xDescripcion.Text.Trim
        bg.Update()
        MsgBox(wMensaje)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xUnidad.Clear()
        xDescripcion.Clear()
        bGuardar.Text = "Guardar"
        xUnidad.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xUnidad.Text.Trim <> "" Then
                If ValidarEliminar("Unidad", xUnidad.Text.Trim, "Unidades") Then
                    MsgError("No se puede eliminar la Unidad")
                Else
                    SQL("DELETE FROM Unidades WHERE Unidad = '" & xUnidad.Text.Trim & "'")
                    MsgBox("Unidad eliminada correctamente")
                    Limpiar()
                    xUnidad.Focus()
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
        Dim wQuery = "SELECT Unidad,DescUnidad as Descripcion FROM Unidades"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescUnidad", Me, "Unidades", xUnidad)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xUnidad.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
End Class