Imports System.ComponentModel

Public Class ManAFPs
    Implements iFormulario
    Private Sub ManUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xAFPs.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xAFPs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xAFPs.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xAFPs_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xAFPs.Validating
        Try
            If xAFPs.Text.Trim <> "" Then
                Dim sl = SQL("SELECT * FROM AFPs WHERE AFP = '" & Val(xAFPs.Text) & "'")
                If sl.RecordCount > 0 Then
                    xDescripcion.Text = sl.Fields("NombreAFP").Text.Trim
                    xPorcentaje.Text = sl.Fields("PorcentajeAFP").Text.Trim
                    dFecha.Value = sl.Fields("Fecha").Text
                    bGuardar.Text = "Modificar"
                Else
                    xAFPs.Text = SiguienteCorrelativo("AFPs")
                    xDescripcion.Focus()
                    bGuardar.Text = "Guardar"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If xAFPs.Text = "" Then
            MsgError("Ingrese Numero de AFP")
            xAFPs.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Nombre de AFP")
            xDescripcion.Focus()
            Exit Sub
        End If
        If xPorcentaje.Text = "" Then
            MsgError("Ingrese Porcentaje de AFP")
            xPorcentaje.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim sl = SQL("SELECT * FROM AFPs WHERE AFP = '" & Val(xAFPs.Text.Trim) & "'")
        If sl.RecordCount = 0 Then
            sl.AddNew()
            wMensaje = "AFPs guardado corretamente"
        Else
            wMensaje = "AFPS modificado correctamente"
        End If

        sl.Fields("AFP").Value = Val(xAFPs.Text)
        sl.Fields("NombreAFP").Value = xDescripcion.Text.Trim
        sl.Fields("PorcentajeAFP").Value = Val(xPorcentaje.Text)
        sl.Fields("Fecha").Value = FormatDateTime(dFecha.Value, 2)
        sl.Update()
        MsgBox(wMensaje)
        Limpiar()
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
    End Sub

    Private Sub Limpiar()
        xAFPs.Clear()
        xDescripcion.Clear()
        bGuardar.Text = "Guardar"
        xPorcentaje.Clear()
        xAFPs.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xAFPs.Text.Trim <> "" Then
                If ValidarEliminar("AFP", xAFPs.Text.Trim, "AFP") Then
                    MsgError("No se puede eliminar el AFP")
                Else
                    SQL("DELETE FROM AFPs WHERE AFP = '" & Val(xAFPs.Text) & "'")
                    MsgBox("AFP eliminado correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                    xAFPs.Focus()
                End If
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(xPorcentaje)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT AFP, NombreAFP FROM AFPs"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreAFP", Me, "AFPs", xAFPs)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xAFPs.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
    Private Sub xPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xPorcentaje.KeyPress
        ValidarDigitos(e)
        e.NextControl(bGuardar)
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        xAFPs.Text = SiguienteCorrelativo("AFPs")
    End Sub
End Class