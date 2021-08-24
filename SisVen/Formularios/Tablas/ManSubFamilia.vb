Imports System.ComponentModel

Public Class ManSubFamilia
    Implements iFormulario
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()

    End Sub

    Sub Limpiar()
        cFamilia.SelectedIndex = -1
        xSubFamilia.Clear()
        xDescripcion.Clear()
        xSubFamilia.Text = SiguienteCorrelativo("SubFamilias")
        xFamilia.Clear()
        xFamilia.Focus()
        bGuardar.Text = "Guardar"
    End Sub

    Private Sub ManSubFamilia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cFamilia, "Familias", "Familia", "DescFamilia")
        xSubFamilia.Text = SiguienteCorrelativo("SubFamilias")
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub cFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cFamilia.SelectedIndexChanged
        If ValidarCombo(cFamilia) Then
            xFamilia.Text = cFamilia.SelectedValue
            xDescripcion.Focus()
        Else
            xFamilia.Clear()
        End If
    End Sub
    Private Sub bNuevo_Click(sender As Object, e As EventArgs) Handles bNuevo.Click
        xSubFamilia.Text = SiguienteCorrelativo("SubFamilias")
        xFamilia.Focus()
        bGuardar.Text = "Guardar"
    End Sub
    Private Sub xSubFamilia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xSubFamilia.KeyPress
        ValidarDigitos(e)
        e.NextControl(xFamilia)
    End Sub

    Private Sub xSubFamilia_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xSubFamilia.Validating
        Try
            If xSubFamilia.Text <> "" Then
                xSubFamilia.Text = Val(xSubFamilia.Text)
                Dim fm = SQL("SELECT F.DescFamilia,S.DescSubFamilia FROM SubFamilias S JOIN Familias F on S.Familia = F.Familia WHERE SubFamilia = '" & xSubFamilia.Text & "'")
                If fm.RecordCount > 0 Then
                    cFamilia.Text = fm.Fields("DescFamilia").Text
                    xDescripcion.Text = fm.Fields("DescSubFamilia").Text.Trim
                    bGuardar.Text = "Modificar"
                Else
                    MsgError("SubFamilia no encontrada")
                    bGuardar.Text = "Guardar"
                    Limpiar()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub xFamilia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xFamilia.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xFamilia_Validating(sender As Object, e As CancelEventArgs) Handles xFamilia.Validating
        If xFamilia.Text.Trim <> "" Then
            cFamilia.SelectedValue = xFamilia.Text.Trim
            If cFamilia.Text = W_SELECCIONAR Then
                MsgError("Local no encontrado")
                xFamilia.Clear()
                xFamilia.Focus()
            End If
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wAuditoria = ""
        If xSubFamilia.Text = "" Then
            MsgError("Ingrese SubFamilia")
            xSubFamilia.Focus()
        End If
        If xFamilia.Text = "" Then
            MsgError("Ingrese Familia")
            xFamilia.Focus()
            Exit Sub
        End If
        If xDescripcion.Text = "" Then
            MsgError("Ingrese Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If

        Dim sf = SQL("SELECT * FROM SUBFAMILIAS WHERE SUBFAMILIA = '" & Val(xSubFamilia.Text) & "'")

        Dim wMensaje As String

        If sf.RecordCount = 0 Then
            sf.AddNew()
            wMensaje = "SubFamilia creada correctamente"
            wAuditoria = PR_INGRESAR
        Else
            wMensaje = "Subfamilia modificada correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        sf.Fields("Familia").Value = Val(xFamilia.Text)
        sf.Fields("DescSubFamilia").Value = xDescripcion.Text.Trim
        sf.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        If xSubFamilia.Text <> "" Then
            If Val(xSubFamilia.Text) <> 0 Then
                Dim sf = SQL("SELECT * FROM ARTICULOS WHERE SUBFAMILIA = " & Val(xSubFamilia.Text) & "")
                If sf.RecordCount = 0 Then
                    SQL("DELETE FROM SUBFAMILIAS WHERE SUBFAMILIA = " & Val(xSubFamilia.Text) & "")
                    MsgBox("SubFamilia eliminada correctamente")
                Else
                    MsgError("Subfamilia utilizada en Articulo, no se puede eliminar")
                End If
            End If
        End If
    End Sub
    Private Sub bBuscarC_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT SubFamilia as 'Sub-Familia', DescSubfamilia as 'Nombre Sub-Familia' FROM Subfamilias"
        Buscador.Show()
        Buscador.Configurar(wQuery, "descSubfamilia", Me, "Sub-Familia", xSubFamilia)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
End Class