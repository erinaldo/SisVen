Public Class InputMensaje
    Public wValidacion As Boolean
    Private Sub bAceptar_Click(sender As Object, e As EventArgs) Handles bAceptar.Click
        lResponse.Text = MsgBoxResult.Ok
        Me.Hide()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        lResponse.Text = MsgBoxResult.Cancel
        Me.Hide()
    End Sub

    Private Sub xTextoRecibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTextoRecibido.KeyPress
        If wValidacion Then
            ValidarDigitos(e)
        End If
        If e.KeyChar = ChrW(13) Then
            bAceptar.Focus()
        End If

    End Sub

    Private Sub xTextoRecibido_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xTextoRecibido.Validating
        If wValidacion Then
            ValidarDigitos(sender)
        End If
    End Sub

    Private Sub InputMensaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xTextoRecibido.Focus()
    End Sub

    Public Sub TamañoAutomatico()
        Dim wLargoTitulosWinDeco As Integer = (WinDeco1.Titulo.Size.Width + WinDeco1.Logo.Size.Width)
        Dim wLargoLabel As Integer = lMensaje.Size.Width
        Dim wTamaño As Size

        If wLargoTitulosWinDeco < wLargoLabel Then
            wTamaño.Width = wLargoLabel + 30
        Else
            wTamaño.Width = wLargoTitulosWinDeco + 30
        End If

        wTamaño.Height = Me.Size.Height
        Me.Size = wTamaño
    End Sub
End Class