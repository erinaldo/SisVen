Public Class VentanaResultados
    Private Sub VentanaResultados_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        xTexto.Focus()
        SendKeys("{ESC}")
        Call xTexto_Click(sender, e)
    End Sub

    Private Sub VentanaResultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub xTexto_Click(sender As Object, e As EventArgs) Handles xTexto.Click
        SendKeys("{PgDn}")
    End Sub
End Class