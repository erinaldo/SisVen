Imports System.ComponentModel

Public Class ImprimirDocumentos
    Private Sub ImprimirDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
        LoadCombobox(cTipoDoc, "TipoDoc", "TipoDoc", "DescTipoDoc", " ORDER BY DescTipoDoc")
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        ValidarDigitos(e)
        e.NextControl(cTipoDoc)
    End Sub

    Private Sub xLocal_Validating(sender As Object, e As CancelEventArgs) Handles xLocal.Validating
        If xLocal.Text.Trim <> "" Then
            cLocal.SelectedValue = xLocal.Text.Trim
            If cLocal.Text = W_SELECCIONAR Then
                MsgError("Local no encontrado")
                xLocal.Clear()
                xLocal.Focus()
            End If
        End If
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            xLocal.Text = cLocal.SelectedValue
        Else
            xLocal.Clear()
        End If
    End Sub

    Private Sub xNumDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNumDoc.KeyPress
        ValidarDigitos(e)
        e.NextControl(bImprimir)
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        xLocal.Clear()
        xNumDoc.Clear()
        cTipoDoc.SelectedIndex = 0
        cLocal.SelectedIndex = 0
        xLocal.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Imprimir_Datos
    End Sub

    Sub Imprimir_Datos()
        Dim wFiltros = "", wQuery = "", wTipoDoc As String = ""

        If xLocal.Text.Trim = "" Then
            MsgError("Ingrese Local")
            xLocal.Focus()
            Exit Sub
        End If

        If ValidarCombo(cTipoDoc) = False Then
            MsgError("Ingrese Tipo de Documento")
            cTipoDoc.Focus()
            Exit Sub
        End If

        If xNumDoc.Text.Trim = "" Then
            MsgError("Ingrese Número de Documento")
            xNumDoc.Focus()
            Exit Sub
        End If

        If Buscar("TipoDoc", "DescTipoDoc", cTipoDoc.Text.Trim, "TipoDoc") Then
            wTipoDoc = Swap.Fields("TipoDoc").Value
        Else
            MsgError("Error en Tipo de Documento")
            cTipoDoc.Focus()
        End If

        wQuery = "Select Numero from DocumentosG where Local = " + Num(xLocal.Text) + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + Num(xNumDoc.Text)
        Swap = SQL(wQuery)
        If Swap.RecordCount = 0 Then
            MsgError("Documento No Encontrado")
            Exit Sub
        End If

        Auditoria(cTipoDoc.Text, PR_IMPRIMIR, Num(xNumDoc.Text))
        Funciones.gTipoCopia = New List(Of Double)

        If gTipoCopia.Visible = False Then
            Funciones.gTipoCopia.Add(0)
        Else
            If oCliente.Checked Then Funciones.gTipoCopia.Add(1)
            If oControlTributario.Checked Then Funciones.gTipoCopia.Add(2)
            If oCedible.Checked Then Funciones.gTipoCopia.Add(3)
        End If


        If Not Funciones.gTipoCopia.Any Then
            MsgError("Debe indicar un tipo de copia a imprimir")
            Exit Sub
        End If
        bImprimir.Enabled = False
        Imprimir_Documento(Val(xLocal.Text), wTipoDoc.Trim, Val(xNumDoc.Text), cTipoDoc.Text, True)
        bImprimir.Enabled = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub oCliente_CheckedChanged(sender As Object, e As EventArgs) Handles oCliente.CheckedChanged, oCedible.CheckedChanged, oControlTributario.CheckedChanged
        Dim wCheckBox As CheckBox = DirectCast(sender, CheckBox)
        wCheckBox.ForeColor = If(wCheckBox.Checked, Color.White, Color.FromArgb(29, 73, 140))

        wCheckBox.Image = If(wCheckBox.Checked, My.Resources.Resources.check16true_b,
                                                    My.Resources.Resources.check16false_b)
    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        If cTipoDoc.Text <> "" Then
            Dim wListTipoDoc = {"FV", "NC", "ND", "FE"}
            If wListTipoDoc.Contains(cTipoDoc.SelectedValue.ToString) Then
                gTipoCopia.Visible = True
            Else
                gTipoCopia.Visible = False
            End If
        End If
    End Sub
End Class