Public Class EnviarDTE

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub EnviarDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loc = SQL("Select NombreLocal from Locales WHERE FElectronica = 1 Order by Local")
        While Not Loc.EOF
            cLocal.Items.Add(Loc.Fields("NombreLocal").Value.ToString.Trim)
            If gMonoLocal Then
                cLocal.Text = Loc("NombreLocal").Value
            End If
            Loc.MoveNext()
        End While

        Doc = SQL("Select DescTipoDoc from TipoDoc WHERE Cod_SII > 0 Order by DescTipoDoc")
        While Not Doc.EOF
            cTipoDoc.Items.Add(Doc.Fields("DescTipoDoc").Value.ToString.Trim)
            Doc.MoveNext()
        End While
    End Sub

    Private Sub Enviar_Click(sender As Object, e As EventArgs) Handles Enviar.Click
        Dim wLocal As Double, wTipoDoc As String, wPrimeraLinea As String

        If cLocal.Text.Trim = "" Then
            MsgError("Falta Local")
            Exit Sub
        End If
        If cTipoDoc.Text.Trim = "" Then
            MsgError("Falta Tipo Documento")
            Exit Sub
        End If
        If Val(xNumero.Text.Trim) = 0 Then
            MsgError("Falta Número de Documento")
            Exit Sub
        End If

        Loc = SQL("Select * from Locales WHERE NombreLocal = '" + cLocal.Text.Trim + "'")
        If Loc.RecordCount > 0 Then
            wLocal = Loc.Fields("Local").Value
        Else
            MsgError("Local Incorrecto")
            Exit Sub
        End If

        Doc = SQL("Select * from TipoDoc WHERE DescTipoDoc = '" + cTipoDoc.Text.Trim + "'")
        If Doc.RecordCount > 0 Then
            wTipoDoc = Doc.Fields("TipoDoc").Value.ToString.Trim
        Else
            MsgError("Tipo Documento Incorrecto")
            Exit Sub
        End If

        DocG = SQL("Select * from DocumentosG WHERE Local = " + Num(wLocal) + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + Num(xNumero.Text))
        If DocG.RecordCount = 0 Then
            MsgError("Documento no encontrado")
            Exit Sub
        End If
        DocD = SQL("Select * from DocumentosD WHERE Local = " + Num(wLocal) + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + Num(xNumero.Text))
        If DocG.RecordCount = 0 Then
            MsgError("Detalles del Documento no encontrados")
            Exit Sub
        End If
        wPrimeraLinea = Formatea_Texto(DocD.Fields("Glosa").Value.ToString.Trim)

        Cli = SQL("Select * from Clientes WHERE Cliente = " + Num(DocG.Fields("Cliente").Value))
        If Cli.RecordCount = 0 Then
            MsgError("Cliente del documento no encontrado")
            Exit Sub
        End If

        'Parametrizar FE con datos del Local
        If Not Parametros_DTE(wLocal) Then
            MsgError("Error al sacar parámetros del Local")
            Exit Sub
        End If
        xStatus.Text = "DTE Parametrizado"
        DoEvents()

        Cursor = Cursors.WaitCursor
        Enviar.Enabled = False

        If Es_Electronico(wTipoDoc) Then
            'Generar TED
            If Not Generar_TED(wLocal, wTipoDoc, Val(xNumero.Text), DocG.Fields("Fecha").Value, Rut_DTE(DocG.Fields("Rut").Value), Formatea_Texto(Cli.Fields("Nombre").Value), DocG.Fields("Total").Value, wPrimeraLinea) Then
                Cursor = Cursors.Arrow
                Enviar.Enabled = True
                MsgError("Error al Generar TED")
                Exit Sub
            End If
            xStatus.Text = xStatus.Text + vbCrLf + "TED Generado"
            DoEvents()

            If Emitir_DTE(wLocal, wTipoDoc, Val(xNumero.Text)) Then
                Cursor = Cursors.Arrow
                Enviar.Enabled = True
                xStatus.Text = xStatus.Text + vbCrLf + MensajeDTE
                xStatus.Text = xStatus.Text + vbCrLf + "Documento Enviado"
                Mensaje("Documento Enviado Exitosamente" + vbCrLf + "Debe esperar unos minutos para tener la respuesta del estado de este documento.")
            Else
                Cursor = Cursors.Arrow
                Enviar.Enabled = True
                xStatus.Text = xStatus.Text + vbCrLf + MensajeDTE
                xStatus.Text = xStatus.Text + vbCrLf + "Error al enviar Documento"
                MsgError("Error al enviar documento")
            End If
        Else
            Cursor = Cursors.Arrow
            Enviar.Enabled = True
            MsgError("Documento no es electrónico, no se envía al DTE")
        End If
        Cursor = Cursors.Arrow
        Enviar.Enabled = True
    End Sub

End Class