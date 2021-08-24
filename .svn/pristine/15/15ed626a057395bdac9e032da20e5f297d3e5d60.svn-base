Public Class AnularEventoRem
    Private Sub AnularEventoRem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Auditoria(Me.Text, "Anular Evento de Remuneración")
    End Sub

    Private Sub xBoucher_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBoucher.KeyPress
        ValidarDigitos(e)
        e.NextControl(xFecha)
    End Sub

    Private Sub xBoucher_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xBoucher.Validating
        If xBoucher.Text <> "" Then
            RmD = SQL("Select * from Sueldos_Detalles where Id = " & Val(xBoucher.Text))
            If RmD.RecordCount = 0 Then
                MsgError("Boucher No Encontrado")
                bLimpiar_Click()
                Exit Sub
            End If
            If RmD.Fields("Estado").Text = 1 Then
                MsgError("Boucher ya procesado, Imposible de Anular.")
                bLimpiar_Click()
                Exit Sub
            End If

            Mostrar_Datos()
        End If
    End Sub

    Sub Mostrar_Datos()
        xFecha.Text = Format(RmD.Fields("Fecha").Text, "dd/mm/yyyy")
        Usr = SQL("Select NombreUsr from Usuarios where Usuario = '" & RmD.Fields("Usuario").Text & "'")
        If Usr.RecordCount > 0 Then
            xFuncionario.Text = Usr.Fields("NombreUsr").Text.Trim
        Else
            xFuncionario.Text = ""
        End If
        EvR = SQL("Select * from EventosRem where EventoRem = " & Val(RmD.Fields("EventoRem").Text))
        If EvR.RecordCount > 0 Then
            xEvento.Text = EvR.Fields("DescEventoRem").Text.Trim
        Else
            xEvento.Text = ""
        End If
        xMonto.Text = FormatNumber(RmD.Fields("Monto").Text)
        xGlosa.Text = RmD.Fields("Glosa").Text.Trim
    End Sub

    Private Sub bLimpiar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bLimpiar.Click
        LimpiarCampos(Me)
        xBoucher.Focus()
    End Sub

    Private Sub bAnular_Click(sender As Object, e As EventArgs) Handles bAnular.Click
        If xBoucher.Text.Trim = "" Then
            MsgError("Falta N° Boucher")
            Exit Sub
        End If
        If xFecha.Text = "" Then
            MsgError("Faltan Datos")
            Exit Sub
        End If

        If Pregunta("Desea Anular Boucher") Then
            Call Auditoria(Me.Text, "Anular Evento de Remuneración", xFuncionario.Text, Val(xBoucher.Text.Trim))
            RmD = SQL("Delete Sueldos_Detalles where Id = " & Val(xBoucher.Text.Trim))
            RmD = SQL("Select Id from Sueldos_Detalles where Id = " & Val(xBoucher.Text.Trim))
            If RmD.RecordCount > 0 Then
                MsgError("Boucher no pudo ser Anulado.")
            Else
                MsgBox("Boucher Anulado")
            End If
            bLimpiar_Click()
            Exit Sub
        End If
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class