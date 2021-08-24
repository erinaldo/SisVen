Imports ADODB
Public Class AnularDocumentoElectronico
    Private Sub AnulacionDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loc = SQL("Select NombreLocal from Locales WHERE FElectronica = 1 Order by Local")
        While Not Loc.EOF
            cLocal.Items.Add(Loc.Fields("NombreLocal").Value.ToString.Trim)
            If gMonoLocal Then
                cLocal.Text = Loc("NombreLocal").Value
            End If
            Loc.MoveNext()
        End While

        Doc = SQL("Select DescTipoDoc from TipoDoc WHERE electronica=1 and Anula <>'' Order by DescTipoDoc")
        While Not Doc.EOF
            cTipoDoc.Items.Add(Doc.Fields("DescTipoDoc").Value.ToString.Trim)
            Doc.MoveNext()
        End While

        cFecha.Value = Date.Now
    End Sub

    Sub Mostrar_Datos()
        xCliente.Text = Trim(DocG.Fields("Cliente").Value)
        xFecha.Text = Format(DocG.Fields("Fecha").Value, "dd/MM/yyyy")
        xMonto.Text = Format(DocG.Fields("Total").Value, "###,###,###")

        Cli = SQL("Select * from Clientes where Cliente = " + Num(DocG.Fields("Cliente").Value))
        If Cli.RecordCount = 0 Then
            xRut.Text = ""
        Else
            xRut.Text = Trim(Cli.Fields("Rut").Value)
            xNombre.Text = Trim(Cli.Fields("Nombre").Value)
        End If
    End Sub

    Sub Anular_Doc()
        Dim CorrelativoNuevo As Double, xDescripcion As String
        Dim DocO As New ADODB.Recordset
        Dim DocR As New ADODB.Recordset


        If cLocal.Text.Trim = "" Then
            MsgError("Falta Local")
            Exit Sub
        End If
        If xNombre.Text.Trim = "" Then
            MsgError("Falta Cliente")
            Exit Sub
        End If
        If cTipoDoc.Text.Trim = "" Then
            MsgError("Falta Tipo de Documento")
            Exit Sub
        End If
        If xAnula.Text.Trim = "" Then
            MsgError("Falta Documento de Anulación")
            Exit Sub
        End If
        If cFecha.Value < CDate(xFecha.Text) Then
            MsgError("No puede Anular un documento con fecha anterior a la creación del documento")
            Exit Sub
        End If

        If Not Pregunta("Desea Anular Documento") Then
            Exit Sub
        End If

        DocG = SQL("Select * from DocumentosG where Local = " + Num(xLocal.Text) + " and TipoDoc = '" + xDoc1.Text + "' and Numero = " + Num(xNumero.Text))
        If DocG.RecordCount = 0 Then
            MsgError("Documento a Anular No Encontrado")
            Exit Sub
        End If
        DocD = SQL("Select * from DocumentosD where Local = " + Num(xLocal.Text) + " and TipoDoc = '" + xDoc1.Text + "' and Numero = " + Num(xNumero.Text))
        If DocD.RecordCount = 0 Then
            MsgError("Documento a Anular sin detalles")
            Exit Sub
        End If
        DocP = SQL("Select * from DocumentosP where Local = " + Num(xLocal.Text) + " and TipoDoc = '" + xDoc1.Text + "' and Numero = " + Num(xNumero.Text))


        CorrelativoNuevo = Correlativo(1, LocalActual, xDoc2.Text, cFecha.Value, 0, True)
        xFolio.Text = CorrelativoNuevo
        If CorrelativoNuevo = 0 Then
            Exit Sub
        End If

        'Verificar que el documento nuevo no exista
        Swap = SQL("Select Top 1 Numero from DocumentosG where Local = " + Num(xLocal.Text) + " and TipoDoc = '" + xDoc2.Text + "' and Numero = " + Num(xFolio.Text))
        If Swap.RecordCount > 0 Then
            MsgError("Documento Nuevo: " + vbCrLf + xAnula.ToString.Trim + " N° " + xFolio.Text + vbCrLf + "Ya existe, favor de volver a intentar.")
            Exit Sub
        End If


        'Clonar Documento
        DocO = SQL("Select Top 1 * from DocumentosG")
        DocO.AddNew()

        For i = 0 To DocG.Fields.Count - 1
            If Trim(UCase(DocG.Fields(i).Name)) <> "ID" Then
                DocO.Fields(i).Value = DocG.Fields(i).Value
            End If
        Next i

        DocO.Fields("TipoDoc").Value = xDoc2.Text
        DocO.Fields("Numero").Value = CorrelativoNuevo
        DocO.Fields("Fecha").Value = CDate(Format(cFecha.Value, "dd/MM/yyyy"))
        DocO.Fields("TipoDocReferencia").Value = xDoc1.Text
        DocO.Fields("NumDocReferencia").Value = Val(xNumero.Text)
        DocO.Fields("FechaDocReferencia").Value = CDate(xFecha.Text)
        DocO.Fields("Motivo").Value = "A"
        DocO.Fields("Observaciones").Value = "Anula " & xDoc2.Text.Trim & " " & CorrelativoNuevo
        DocO.Fields("Status_DTE").Value = 0
        DocO.Fields("TED").Value = ""
        DocO.Update()

        'Detalles
        DocD = SQL("Select * from DocumentosD where Local = " + Num(xLocal.Text) + " And TipoDoc = '" + xDoc1.Text + "' and Numero = " + Num(xNumero.Text))
            If DocD.RecordCount = 0 Then
            MsgError("Documento a Anular sin detalles")
            Exit Sub
        End If

        xDescripcion = ""
        While Not DocD.EOF
            DoEvents()
            DocR = SQL("Select Top 1 * from DocumentosD")
            DocR.AddNew()
            For i = 1 To DocD.Fields.Count - 1
                If Trim(UCase(DocD.Fields(i).Name)) <> "ID" Then
                    DocR.Fields(i).Value = DocD.Fields(i).Value
                End If
            Next i
            DocR.Fields("TipoDoc").Value = xDoc2.Text
            DocR.Fields("Numero").Value = CorrelativoNuevo
            If xDescripcion = "" Then xDescripcion = DocR.Fields("Glosa").Value
            DocR.Update()
            DocD.MoveNext()
        End While

        'Pagos
        DocP = SQL("Select * from DocumentosP where Local = " + Num(xLocal.Text) + " And TipoDoc = '" + xDoc1.Text + "' and Numero = " + Num(xNumero.Text))
        If DocP.RecordCount > 0 Then
            xDescripcion = ""
            While Not DocP.EOF
                DoEvents()
                DocR = SQL("Select Top 1 * from DocumentosP")
                DocR.AddNew()
                For i = 1 To DocP.Fields.Count - 1
                    If Trim(UCase(DocP.Fields(i).Name)) <> "ID" Then
                        DocR.Fields(i).Value = DocP.Fields(i).Value
                    End If
                Next i
                DocR.Fields("TipoDoc").Value = xDoc2.Text
                DocR.Fields("Numero").Value = CorrelativoNuevo
                DocR.Update()
                DocP.MoveNext()
            End While
        End If

        Try
            'Parametrizar con datos del Local
            If Not Parametros_DTE(Val(xLocal.Text)) Then
                MsgError("Error al sacar parámetros del Local.")
                Exit Sub
            Else
                If Es_Electronico(xDoc2.Text) Then
                    DocO.Fields("DTE").Value = True
                    'Generar TED
                    Buscar("Clientes", "Cliente", Val(DocO.Fields("Cliente").Value))
                    If Not Generar_TED(Val(xLocal.Text), xDoc2.Text, CorrelativoNuevo, DocO.Fields("Fecha").Value, Rut_DTE(DocO.Fields("Rut").Text), Formatea_Texto(Swap.Fields("Nombre").Text), DocO.Fields("Total").Value, xDescripcion) Then
                        MsgError("Error al Generar TED.")
                    Else
                        'Envio al DTE
                        If Emitir_DTE(LocalActual, xDoc2.Text, CorrelativoNuevo) Then
                            'Mensaje eliminado por ser innecesario
                            'Mensaje("Documento Enviado Exitosamente.")
                        Else
                            MsgError("Error al enviar documento.")
                        End If
                    End If
                Else
                    DocG.Fields("DTE").Value = False
                End If
                DocG.Update()
            End If
        Catch ex As Exception
        End Try


        Auditoria(Me.Name, "Anulación Documento Contable", xDoc1.Text, Val(xNumero.Text))
        Auditoria(Me.Name, "Documento Contable Emitido", xDoc2.Text, CorrelativoNuevo)

        Cursor = Cursors.Arrow
        Mensaje("Documento Anulado con:" + vbCrLf + xAnula.Text + vbCrLf + "N° " + CorrelativoNuevo.ToString)

        DoEvents()

        If Pregunta("¿Desea ver el Documento Generado?") Then
            Imprimir_Documento(Val(xLocal.Text), xDoc2.Text, Val(CorrelativoNuevo), xAnula.Text, True)
        End If

        Limpiar()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        DocAnula()
    End Sub

    Sub DocAnula()
        Doc = SQL("Select * from TipoDoc where DescTipoDoc = '" + cTipoDoc.Text.Trim + "'")
        If Doc.RecordCount = 0 Then
            MsgError("Documento No Encontrado")
            cTipoDoc.Text = ""
            Exit Sub
        End If
        xDoc1.Text = Doc.Fields("TipoDoc").Value

        If Doc.Fields("Anula").Value.trim = "" Then
            MsgError("Documento sin Tipo de Anulación")
            cTipoDoc.Text = ""
            xAnula.Text = ""
            xDoc2.Text = ""
            Exit Sub
        End If

        Doc = SQL("Select * from TipoDoc where TipoDoc = '" + Doc.Fields("Anula").Value + "'")
        If Doc.RecordCount = 0 Then
            MsgError("Error al encontrar Tipo de Documento de Anulación")
            cTipoDoc.Text = ""
            Exit Sub
        End If

        xDoc2.Text = Doc.Fields("TipoDoc").Value
        xAnula.Text = Doc.Fields("DescTipoDoc").Value

        xFolio.Text = Correlativo(0, LocalActual, xDoc2.Text, cFecha.Value, 0, True)
    End Sub

    Private Sub bBuscarCli_Click(sender As Object, e As EventArgs) Handles bBuscarCli.Click
        Buscar_Datos()
    End Sub

    Sub Buscar_Datos()
        If cLocal.Text = "" Then
            MsgError("Falta Local")
            Exit Sub
        End If
        If cTipoDoc.Text = "" Then
            MsgError("Falta Tipo de Documento a Anular")
            Exit Sub
        End If
        If Val(xNumero.Text) = 0 Then
            MsgError("Falta Número de Documento a Anular")
            Exit Sub
        End If

        DocG = SQL("Select * from DocumentosG where Local = " + Num(xLocal.Text) + " and TipoDoc = '" + xDoc1.Text + "' and Numero = " + Num(xNumero.Text))
        If DocG.RecordCount = 0 Then
            MsgError("Documento a Anular No Encontrado")
            Exit Sub
        End If

        Mostrar_Datos()
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        Loc = SQL("Select Local from Locales where NombreLocal = '" + cLocal.Text + "'")
        If Loc.RecordCount = 0 Then
            xLocal.Text = ""
        Else
            xLocal.Text = Loc.Fields("Local").Value
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Sub Limpiar()
        xLocal.Text = ""
        cLocal.SelectedIndex = 0
        cTipoDoc.SelectedIndex = 0
        xNumero.Text = ""
        xDoc1.Text = ""
        xDoc2.Text = ""
        xCliente.Text = ""
        xNombre.Text = ""
        xRut.Text = ""
        xFecha.Text = ""
        xAnula.Text = ""
        xMonto.Text = ""
        xFolio.Text = ""
        cFecha.Value = Date.Now
        cLocal.Focus()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Anular_Doc()
    End Sub
    Private Sub xNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles xNumero.KeyDown
        If e.KeyCode = 13 Then
            If Val(xNumero.Text) > 0 Then
                Buscar_Datos()
            End If
        End If
    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub xCliente_TextChanged(sender As Object, e As EventArgs) Handles xCliente.TextChanged

    End Sub
End Class