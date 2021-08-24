Public Class ManUF
    Private Sub ManUF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cAño.AñosMes("A")
        cMes.AñosMes("M")
        cAño.SelectedValue = "1"
        If Now.Month > 1 Then
            cMes.SelectedValue = Now.AddMonths(-1).Month.ToString
        Else
            cMes.SelectedValue = Now.Month.ToString
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If Val(xUF.Text) = 0 Or Not IsNumeric(xUF.Text) Then
            MsgError("Debe ingresar el valor de la UF")
            xUF.Focus()
            Exit Sub
        End If
        If Val(xUTM.Text) = 0 Or Not IsNumeric(xUTM.Text) Then
            MsgError("Debe ingresar el valor de la UTM")
            xUTM.Focus()
            Exit Sub
        End If


        Dim ufs = SQL("select * from ufs where año=" & Val(cAño.Text) & " and mes=" & cMes.SelectedValue.ToString & "")
        If UFS.RecordCount > 0 Then
            If Pregunta("¿Desea modificar el registro?") Then
                ufs.Fields("año").Value = Val(cAño.Text)
                ufs.Fields("mes").Value = Val(cMes.SelectedValue.ToString)
                ufs.Fields("uf").Value = CDbl(xUF.Text)
                ufs.Fields("utm").Value = CDbl(xUTM.Text)
                ufs.Update()
                MsgBox("La UF fue modificada")
                Call Auditoria(Me.Name, "Modificó UF/UTM", Val(cAño.Text) & "-" & cMes.SelectedValue.ToString & "-" & xUF.Text, CDbl(LocalActual))
                bLimpiar_Click()
            Else
                Exit Sub
            End If
        Else
            ufs.AddNew()
            ufs.Fields("año").Value = Val(cAño.Text)
            ufs.Fields("mes").Value = Val(cMes.SelectedValue.ToString)
            ufs.Fields("uf").Value = CDbl(xUF.Text)
            ufs.Fields("utm").Value = CDbl(xUTM.Text)
            ufs.Update()
            MsgBox("La UF / UTM fueron registradas")
            Auditoria(Me.Name, "Creó UF/UTM", Val(cAño.Text) & "-" & cMes.SelectedValue.ToString & "-" & xUF.Text, CDbl(LocalActual))
            bLimpiar_Click()
        End If

    End Sub

    Private Sub bLimpiar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bLimpiar.Click
        xUF.Clear()
        xUTM.Clear()
        cMes.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub cMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cMes.SelectedIndexChanged
        cAño.Focus()
    End Sub

    Private Sub cAño_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cAño.SelectedIndexChanged
        xUF.Focus()
    End Sub

    Private Sub xUF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xUF.KeyPress
        e.NextControl(xUTM)
    End Sub

    Private Sub xUTM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xUTM.KeyPress
        e.NextControl(bGuardar)
    End Sub
End Class