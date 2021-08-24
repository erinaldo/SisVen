Public Class AnularOT
    Private Sub bLimpiar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bLimpiar.Click
        LimpiarCampos(Me)
        xOT.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
    Private Sub xOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xOT.KeyPress
        ValidarDigitos(e)
        e.NextControl(xCliente)
    End Sub

    Public Sub xOT_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xOT.Validating
        If xOT.Text.Trim = "" Then
            Exit Sub
        End If

        OT = SQL("Select * from OT where OT = " & xOT.Text.Trim)
        If OT.RecordCount > 0 Then
            xCliente.Text = OT.Fields("Cliente").Text
            If Buscar("Clientes", "Cliente", OT.Fields("Cliente").Text, "Nombre") Then
                xNombre.Text = Swap.Fields("Nombre").Text
            Else
                xNombre.Clear()
            End If
            xProductoR.Text = OT.Fields("Recepcion").Text
            xFechaOT.Text = OT.Fields("Fecha").Text
            If Buscar("Estados", "Estado", OT.Fields("Estado").Text, "DescEstado") Then
                xEstado.Text = Swap.Fields("DescEstado").Text.ToUpper
            Else
                xEstado.Clear()
            End If
            xObsTecnico.Text = OT.Fields("ObsTecnico").Text
            xObsTecnico.Focus()

            If OT.Fields("Estado").Text = "N" Then
                MsgError("La OT ya se encuentra Anulada")
                bLimpiar_Click()
                Exit Sub
            End If
        Else
            MsgError("OT No Encontrada")
            bLimpiar_Click()
        End If
    End Sub

    Private Sub bAnular_Click(sender As Object, e As EventArgs) Handles bAnular.Click

    End Sub
End Class