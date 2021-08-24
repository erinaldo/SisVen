Imports System.ComponentModel

Public Class ManFamilia
    Implements iFormulario
    Private Sub ManFamilia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xFamilia.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub bNuevo_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bNuevo.Click
        Try
            Dim fm = SQL("SELECT TOP 1 Familia FROM Familias Order by Familia DESC")
            If fm.RecordCount > 0 Then
                xFamilia.Text = fm.Fields("Familia").Value + 1
            Else
                xFamilia.Text = 1
            End If
            xDescripcion.Clear()
            xDescripcion.Focus()
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xFamilia_KeyPress(Optional sender As Object = Nothing, Optional e As KeyPressEventArgs = Nothing) Handles xFamilia.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xFamilia_Validating(sender As Object, e As CancelEventArgs) Handles xFamilia.Validating
        Try
            If IsNumeric(xFamilia.Text) Then
                Dim fm = SQL("SELECT DescFamilia FROM Familias WHERE Familia = '" & xFamilia.Text & "'")

                If fm.RecordCount > 0 Then
                    xDescripcion.Text = fm.Fields("DescFamilia").Text.Trim
                    bGuardar.Text = "Modificar"
                Else
                    MsgError("Familia no encontrada")
                    bNuevo_Click()
                    xDescripcion.Focus()
                    bGuardar.Text = "Guardar"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If xFamilia.Text = "" Then
            MsgError("Ingrese Familia")
            xFamilia.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
        End If
        If bGuardar.Text = "Guardar" Then
            SQL("INSERT INTO FAMILIAS (Familia,DescFamilia) VALUES ( " & Val(xFamilia.Text) & ", '" & xDescripcion.Text & "')")
            MsgBox("Familia creada correctamente")
            Auditoria(Me.Text, PR_GUARDAR, "", 0)
        Else
            SQL("UPDATE FAMILIAS SET DescFamilia = '" & xDescripcion.Text & "' WHERE Familia = " & xFamilia.Text & "")
            MsgBox("Familia modificada correctamente")
            Auditoria(Me.Text, PR_MODIFICAR, "", 0)
        End If
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xFamilia.Clear()
        xDescripcion.Clear()
        bGuardar.Text = "Guardar"
        xFamilia.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If IsNumeric(xFamilia.Text) Then
                Dim fm = SQL("SELECT TOP 1 Familia FROM Articulos WHERE Familia =" & Val(xFamilia.Text) & "")
                If fm.RecordCount = 0 Then
                    SQL("DELETE FROM Familias WHERE Familia = " & Val(xFamilia.Text) & "")
                    MsgBox("Familia eliminada correctamente")
                    Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                    Limpiar()
                Else
                    MsgError("No se puede eliminar esta familia, esta siendo usada en Artículo")
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
        Dim wQuery = "SELECT Familia, DescFamilia as 'Nombre Familia' FROM Familias"
        Buscador.Show()
        Buscador.Configurar(wQuery, "DescFamilia", Me, "Familias", xFamilia)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
End Class