Public Class Acerca
    Private Sub Acerca_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lSistema.Text = "Versión " & Version.ToString
        lUltimoDespliegue.Text = "Última Actulización: " & IO.File.GetLastWriteTime(Application.ExecutablePath).ToString()
    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Me.Close()
    End Sub

    Private Sub Acerca_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Using pen As New Pen(Color.FromArgb(1, 26, 103))
            Dim rect As Rectangle = DisplayRectangle
            rect.Width -= 1
            rect.Height -= 1
            e.Graphics.DrawRectangle(pen, rect)
        End Using
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class