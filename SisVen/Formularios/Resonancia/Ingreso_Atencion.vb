Public Class Ingreso_Atencion
    Const T_HORA As Integer = 0

    Dim wHoraEntrada As String = My.Settings.P_HORA_ENTRADA
    Dim wHoraSalida As String = My.Settings.P_HORA_SALIDA
    Dim wIntervalo As Integer = My.Settings.P_INTERVALO_HORA
    Dim wDiasHabiles() As String = My.Settings.P_DIAS_HABILES.Split(",")
    Sub Titulos()
        Dim wAnchoTabla As Integer = xTabla.Width
        xTabla.Clear()

        xTabla.Rows.Count = 1
        xTabla.Cols.Count = wDiasHabiles.Count + 1 '+1 es por la Hora
        xTabla.Cols(T_HORA).Width = 40
        xTabla.Cols(T_HORA).Caption = "Hora"
        For i = 0 To wDiasHabiles.Count - 1
            xTabla.Cols(i + 1).Caption = "" 'DiaSemana(wDiasHabiles(i))
        Next
        RedimenzionarTabla(xTabla, wDiasHabiles)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Sub LlenarHoras()
        Dim wHora As Date = wHoraEntrada
        Dim wFila As Integer = 1
        While wHora <= wHoraSalida
            xTabla.AddItem("")
            xTabla.SetData(wFila, T_HORA, wHora.ToShortTimeString)
            wHora = wHora.AddMinutes(wIntervalo)
            wFila += 1
        End While
    End Sub

    Private Sub Ingreso_Atencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        LlenarHoras()
        cTipoFinanciador.LoadItems("TipoFinanciador", "Nombre")
        cExamen.LoadItems("Articulos", "Descripcion", "Familia in (2,3)")
    End Sub

    Private Sub xTabla_SizeChanged(sender As Object, e As EventArgs) Handles xTabla.SizeChanged
        RedimenzionarTabla(xTabla, wDiasHabiles)
    End Sub

    Private Sub bPagos_Click(sender As Object, e As EventArgs) Handles bPagos.Click
        Ingresar_Pagos.Show()
        Ingresar_Pagos.BringToFront()
    End Sub

    Private Sub cTipoFinanciador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoFinanciador.SelectedIndexChanged
        If Trim(cTipoFinanciador.Text) = "" Then cFinanciador.Items.Clear() : Exit Sub
        Cli = SQL("SELECT Tipo FROM TipoFinanciador WHERE Nombre='" & Trim(cTipoFinanciador.Text) & "'")
        If Cli.EOF Then
            cFinanciador.Items.Clear()
            Exit Sub
        End If
        cFinanciador.LoadItems("Financiador", "Nombre", "Tipo=" & Cli.Fields("Tipo").Text)
    End Sub

    Private Sub xRut_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xRut.Validating
        If Trim(xRut.Text) = ".   .   -" Then
            xNombre.Clear()
            xEmail.Clear()
            xTelefono.Clear()
            Exit Sub
        End If
        If Not ValidarRut(xRut.Text) Then
            MsgError("El Rut ingresado no es válido")
            Exit Sub
        End If

        Cli = SQL("SELECT Nombre,Email,Telefonos FROM Clientes WHERE Rut='" & Trim(xRut.Text) & "' and Tipo='P'")
        If Cli.EOF Then
            If Not Pregunta("El Paciente ingresado no existe. ¿Desea crear un nuevo paciente?") Then
                Exit Sub
            End If
            Dim wMantenedorCliente As New ManCliente
            wMantenedorCliente.xCliente.Text = SacaUltimo("Clientes", "Cliente")
            wMantenedorCliente.xRut.Text = Trim(xRut.Text)
            wMantenedorCliente.xCliente.Enabled = False
            wMantenedorCliente.wFormulario = "Ingreso_Atencion_Paciente"
            wMantenedorCliente.xNombre.Focus()
            wMantenedorCliente.ShowDialog()
            If wMantenedorCliente.wFormulario = "Cancelar" Then
                Exit Sub
            End If
            xRut_Validating(Nothing, Nothing)
        End If
        xNombre.Text = Cli.Fields("Nombre").Text
        xEmail.Text = Cli.Fields("Email").Text
        xTelefono.Text = Cli.Fields("Telefonos").Text
    End Sub

    Private Sub xRut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xRut.KeyPress
        If e.KeyChar = ChrW(13) Then
            xNombre.Focus()
        End If
    End Sub

    Private Sub xNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNombre.KeyPress
        If e.KeyChar = ChrW(13) Then
            xEmail.Focus()
        End If
    End Sub

    Private Sub xEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xEmail.KeyPress
        If e.KeyChar = ChrW(13) Then
            xTelefono.Focus()
        End If
    End Sub

    Private Sub xTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTelefono.KeyPress
        If e.KeyChar = ChrW(13) Then
            cExamen.Focus()
        End If
    End Sub

    Private Sub cExamen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cExamen.KeyPress
        If e.KeyChar = ChrW(13) Then
            cTipoFinanciador.Focus()
        End If
    End Sub

    Private Sub cTipoFinanciador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cTipoFinanciador.KeyPress
        If e.KeyChar = ChrW(13) Then
            cFinanciador.Focus()
        End If
    End Sub

    Private Sub cFinanciador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cFinanciador.KeyPress
        If e.KeyChar = ChrW(13) Then
            xCodigoMedico.Focus()
        End If
    End Sub

    Private Sub xCodigoMedico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCodigoMedico.KeyPress
        If e.KeyChar = ChrW(13) Then
            bGuardar.Focus()
        End If
    End Sub

    Private Sub xCodigoMedico_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCodigoMedico.Validating
        If Trim(xCodigoMedico.Text) = "" Then xNombreMedico.Clear() : Exit Sub
        Cli = SQL("SELECT Tipo,Nombre FROM Clientes WHERE Cliente=" & Val(xCodigoMedico.Text))
        If Cli.EOF Then
            If Not Pregunta("El Médico ingresado no existe,¿Desea crear un nuevo médico?") Then
                xNombreMedico.Clear()
                Exit Sub
            End If

            Dim wMantenedorCliente As New ManCliente
            wMantenedorCliente.xCliente.Text = SacaUltimo("Clientes", "Cliente")
            wMantenedorCliente.xCliente.Enabled = False
            wMantenedorCliente.wFormulario = "Ingreso_Atencion_Medico"
            wMantenedorCliente.xNombre.Focus()
            wMantenedorCliente.ShowDialog()
            If wMantenedorCliente.wFormulario = "Cancelar" Then
                Exit Sub
            End If
            xCodigoMedico.Text = wMantenedorCliente.xCliente.Text
            xCodigoMedico_Validating(Nothing, Nothing)
        End If

        If Cli.Fields("Tipo").Text <> "M" Then
            MsgError("El código ingresado no pertenece a un médico")
            xCodigoMedico.Clear()
            xNombreMedico.Clear()
            Exit Sub
        End If
        xNombreMedico.Text = Cli.Fields("Nombre").Text
    End Sub
End Class