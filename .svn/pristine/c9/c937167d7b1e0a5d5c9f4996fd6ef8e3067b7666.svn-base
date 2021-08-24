Public Class InputPersonalizado
    Private Shared wFormulario As New InputMensaje()
    Public Shared Function Inputbox(Mensaje As String, Titulo As String, ByRef Texto_Textbox As String, Icono As Icon,
                                    Optional ByVal ValidarNumero As Boolean = False) As MsgBoxResult
        Inputbox = MsgBoxResult.Cancel
        wFormulario.Text = Titulo
        wFormulario.WinDeco1.Titulo.Text = Titulo
        wFormulario.lMensaje.Text = Mensaje
        wFormulario.xTextoRecibido.Text = Texto_Textbox
        'wFormulario.Left = Left
        'wFormulario.Top = Top
        wFormulario.Icon = Icono
        wFormulario.wValidacion = ValidarNumero
        wFormulario.TamañoAutomatico()
        wFormulario.ShowDialog()
        Inputbox = wFormulario.lResponse.Text
        wFormulario.xTextoRecibido.Focus()
    End Function

    Public Shared ReadOnly Property RetornoTexto As String
        Get
            Return wFormulario.xTextoRecibido.Text
        End Get
    End Property

    Public Shared ReadOnly Property Response As MsgBoxResult
        Get
            Return CType(wFormulario.lResponse.Text, MsgBoxResult)
        End Get
    End Property

    Public Sub Dispose()
        wFormulario = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        wFormulario = Nothing
        MyBase.Finalize()
    End Sub
End Class
