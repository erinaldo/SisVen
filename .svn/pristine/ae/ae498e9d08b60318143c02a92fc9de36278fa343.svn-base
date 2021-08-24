Public Class CreditoPersona
    Private Sub CreditoPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cFuncionario, "Usuarios", "Usuario", "Nombreusr", " WHERE Funcionario = 1 Order by NombreUsr")
        Auditoria(Me.Text, "Ingresar", UsuarioActual)
    End Sub

    Private Sub xMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMonto.KeyPress
        ValidarDigitos(e)
        e.NextControl(xCuota)
    End Sub

    Private Sub xCuota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCuota.KeyPress
        ValidarDigitos(e)
        e.NextControl(xValorCuota)
    End Sub

    Private Sub xValorCuota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xValorCuota.KeyPress
        ValidarDigitos(e)
        e.NextControl(xGlosa)
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wUsuario As String

        If Not IsDate(dFechaCuota.Value) Then
            MsgError("Error en Fecha")
            Exit Sub
        End If

        If Buscar("Usuarios", "NombreUsr", Trim(cFuncionario.Text), "Usuario") Then
            wUsuario = Swap.Fields("Usuario").Text
        Else
            MsgError("Funcionario No Encontrado")
            Exit Sub
        End If
        If Val(xMonto.Text) = 0 Then
            MsgError("Deve ingrsar un Monto")
            Exit Sub
        End If

        Auditoria(Me.Text, "Crear Créditos para Personal", cFuncionario.SelectedValue, xMonto.Text)

        Dim RmD = SQL("Select Top 1 * from Sueldos_Detalles")
        RmD.AddNew
        RmD.Fields("Fecha").Value = dFechaCuota.Value
        RmD.Fields("Usuario").Value = cFuncionario.SelectedValue
        RmD.Fields("Estado").Value = 0
        RmD.Fields("EventoRem").Value = 22
        RmD.Fields("Monto").Value = Val(xMonto.Text.Trim)
        RmD.Fields("Glosa").Value = xGlosa.Text.Trim
        RmD.Fields("UsuarioRem").Value = UsuarioActual
        RmD.Update

        Dim wBoucher = Val(SiguienteCorrelativo("Sueldos_Detalles")) - 1

        MsgBox("Datos Ingresados" + vbCrLf + "Boucher N° " & wBoucher)
        bLimpiar_Click()
    End Sub

    Private Sub bLimpiar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class