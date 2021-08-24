Public Class IngresoEventos
    Implements iFormulario
    Private Sub IngresoEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cEvento, "EventosRem", "EventoRem", "DescEventoRem", " ORDER BY CalculoRem,DescEventoRem")
        Auditoria(Me.Text, "Ingresar", UsuarioActual)
    End Sub

    Private Sub xMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMonto.KeyPress
        ValidarDigitos(e)
        e.NextControl(xGlosa)
    End Sub

    Private Sub xGlosa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xGlosa.KeyPress
        e.NextControl(bGuardar)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If Not IsDate(dFecha) Then
            MsgError("Error en Fecha")
            Exit Sub
        End If

        If Not Buscar("Usuarios", "NombreUsr", xIDFuncionario.Text.Trim, "Usuario") Then
            MsgError("Funcionario No Encontrado")
            Exit Sub
        End If
        If ValidarCombo(cEvento) Then
            MsgError("Debe seleccionar un Evento")
            Exit Sub
        End If
        If Val(xMonto.Text) = 0 Then
            MsgError("Deve ingresar un Monto")
            Exit Sub
        End If

        Auditoria(Me.Text, "Ingreso de Eventos de Remuneraciones", xIDFuncionario.Text.Trim, Val(xMonto.Text.Trim))

        Dim RmD = SQL("Select Top 1 * from Sueldos_Detalles")
        RmD.AddNew()
        RmD.Fields("Fecha").Value = dFecha.Value
        RmD.Fields("Usuario").Value = xIDFuncionario.Text.Trim
        RmD.Fields("Estado").Value = 0 'Pendiente
        RmD.Fields("EventoRem").Value = cEvento.SelectedValue
        RmD.Fields("Monto").Value = Val(xMonto.Text.Trim)
        RmD.Fields("Glosa").Value = xGlosa.Text.Trim
        RmD.Fields("UsuarioRem").Value = UsuarioActual
        RmD.Update()

        RmD.MoveLast()

        MsgError("Datos Ingresados" + vbCrLf + "Boucher N° " & RmD.Fields("Id").Text)
        Auditoria(Me.Text, "Guardar", UsuarioActual)
        LimpiarCampos(Me)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xIDFuncionario.KeyPress
        e.NextControl(cEvento)
    End Sub

    Private Sub xIDFuncionario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xIDFuncionario.Validating
        If xIDFuncionario.Text.Trim = "" Then
            Exit Sub
        End If

        Usr = SQL("SELECT NombreUsr From Usuarios WHERE Usuario = '" & xIDFuncionario.Text.Trim & "' AND Funcionario = 1")
        If Usr.RecordCount > 0 Then
            xFuncionario.Text = Usr.Fields("NombreUsr").Value
        Else
            MsgError("Funcionario no encontrado")
            xIDFuncionario.Clear()
            xFuncionario.Clear()
            xIDFuncionario.Focus()
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT Usuario, NombreUsr FROM Usuarios"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreUsr", Me, "Clientes", xIDFuncionario)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
End Class