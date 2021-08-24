Public Class Ingresar_Pagos
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Consulta_Atencion.Show()
        Consulta_Atencion.BringToFront()
    End Sub

End Class