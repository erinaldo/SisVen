Imports System.ComponentModel

Public Class ManCiudades
    Implements iFormulario
    Private Sub ManBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xCiudad.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCiudad.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xCiudad_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xCiudad.Validating
        Try
            If xCiudad.Text.Trim <> "" Then
                Dim cd = SQL("SELECT * FROM Ciudades WHERE Ciudad = '" & xCiudad.Text.Trim & "'")
                If cd.RecordCount > 0 Then
                    xDescripcion.Text = cd.Fields("NombreCiudad").Text.Trim
                    xRegion.Text = cd.Fields("Region").Text.Trim
                    xArea.Text = cd.Fields("CodigoArea").Text.Trim
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

        If xCiudad.Text = "" Then
            MsgError("Ingrese Ciudad")
            xCiudad.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Nombre Ciudad")
            xDescripcion.Focus()
            Exit Sub
        End If
        If xRegion.Text = "" Then
            MsgError("Ingrese Región")
            xRegion.Focus()
            Exit Sub
        End If
        If xArea.Text = "" Then
            MsgError("Ingrese Área")
            xRegion.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        Dim cd = SQL("SELECT * FROM Ciudades WHERE Ciudad = '" & xCiudad.Text.Trim & "'")
        If cd.RecordCount = 0 Then
            cd.AddNew()
            wMensaje = "Ciudad guardado corretamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "Ciudad modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        cd.Fields("Ciudad").Value = xCiudad.Text.Trim
        cd.Fields("NombreCiudad").Value = xDescripcion.Text.Trim
        cd.Fields("Region").Value = xRegion.Text.Trim
        cd.Fields("CodigoArea").Value = xArea.Text.Trim
        cd.Update()
        Auditoria(Me.Text, wAuditoria, "", 0)
        MsgBox(wMensaje)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xCiudad.Clear()
        xDescripcion.Clear()
        xRegion.Clear()
        xArea.Clear()
        bGuardar.Text = "Guardar"
        xCiudad.Focus()

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xCiudad.Text.Trim <> "" Then
                If ValidarEliminar("Cliente", xCiudad.Text.Trim, "Ciudades") Then
                    MsgError("No se puede eliminar la Ciudad")
                Else
                    SQL("DELETE FROM Ciudades WHERE Ciudad = '" & xCiudad.Text.Trim & "'")
                    MsgBox("Ciudad eliminada correctamente")
                    Limpiar()
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    xCiudad.Focus()
                End If
                End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(xRegion)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT Ciudad, NombreCiudad as 'Nombre Ciudad' FROM Ciudades"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreCiudad", Me, "Ciudades", xCiudad)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManCiudades_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xCiudad.Focus()
    End Sub
    Private Sub xRegion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xRegion.KeyPress
        e.NextControl(xArea)
    End Sub
End Class