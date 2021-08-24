Imports C1.Win.C1FlexGrid

Public Class ControlDTE_Emitidos
    Const T_OK = 0
    Const T_ESTADO = 1
    Const T_TIPODOC = 2
    Const T_DOC = 3
    Const T_NUM = 4
    Const T_FECHA = 5
    Const T_USUARIO = 6
    Const T_LOCAL = 7
    Const T_NOMBRELOCAL = 8
    Const T_CLIENTE = 9
    Const T_RUT = 10
    Const T_NOMBRE = 11
    Const T_FPAGO = 12
    Const T_MONTO = 13
    Const T_OBS = 14
    Const T_LINEA = 15

    Const EI = "Emitido Incorrecto"
    Const ET = "Emitido con TED"
    Const AP = "Aprobado por SII"
    Const AR = "Aprobado con Reparos por SII"
    Const RE = "Rechazado por SII"
    Const RP = "Respuesta Pendiente"
    Const PT = "Pendiente de Timbraje"
    Const ST = "Documento sin Firma"
    Const SA = "Sin Archivos TED"

    Const NE = "No es Electrónico"
    Const ND = "No Definido"

    Dim wFila As Integer
    Dim wLocal As Integer

    Private Sub ControlDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FLoc = SQL("Select NombreLocal from Locales WHERE FElectronica = 1 Order by Local")
        cLocal.Items.Add("")
        Try
            While Not Loc.EOF
                cLocal.Items.Add(Loc.Fields("NombreLocal").Value.ToString.Trim)
                If gMonoLocal Then
                    cLocal.Text = Loc("NombreLocal").Value
                End If
                Loc.MoveNext()
            End While
        Catch ex As Exception
        End Try

        Doc = SQL("Select DescTipoDoc from TipoDoc WHERE Cod_SII > 0 Order by DescTipoDoc")
        cTipoDoc.Items.Add("")
        While Not Doc.EOF
            cTipoDoc.Items.Add(Doc.Fields("DescTipoDoc").Value.ToString.Trim)
            Doc.MoveNext()
        End While

        Titulos()

        cEstados.Items.Add("")
        cEstados.Items.Add(EI)
        cEstados.Items.Add(ET)
        cEstados.Items.Add(AP)
        cEstados.Items.Add(AR)
        cEstados.Items.Add(RE)
        cEstados.Items.Add(RP)
        cEstados.Items.Add(PT)
        cEstados.Items.Add(ST)

        'If UsuarioActual = "PED" Then
        gEspeciales.Visible = True
        cEstados.Items.Add(SA)
        'End If

        oRapido.Checked = True

        xF1.Value = IniFecha(1, Now.Date)
        xF2.Value = IniFecha(2, Now.Date)
    End Sub

    Private Sub bDesmarcar_Click()
        For i = 1 To xTabla.Rows.Count - 1
            xTabla.SetData(i, T_OK, UNCHECK)
        Next i
    End Sub

    Private Sub bEnviarM_Click()
        Dim Hay As Boolean

        Hay = False
        Cursor = Cursors.WaitCursor
        For i = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(i, T_ESTADO) = NE Then
                'El_Error ("No se puede enviar a DTE Documentos No electrónicos")
            Else
                If xTabla.GetData(i, T_ESTADO) = AP Or xTabla.GetData(i, T_ESTADO) = AR Then
                    'El_Error ("Documento Electrónico ya enviado a SII, no se puede volver a enviar")
                Else
                    If xTabla.GetData(i, T_OK) = CHECK Then
                        Hay = True
                        If Emitir_DTE(Val(xTabla.GetData(i, T_LOCAL)), BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(i, T_DOC)), xTabla.GetData(i, T_NUM)) Then
                            'Me.MousePointer = vbDefault
                            'El_Mensaje (Tabla.TextMatrix(Tabla.Row, T_DOC) + " " + Str(Tabla.TextMatrix(Tabla.Row, T_NUM)) + " Enviada Correctamente.")
                        Else
                            'Me.MousePointer = vbDefault
                            'El_Error ("Error al Enviar Documento Electrónico")
                        End If
                    End If
                End If
            End If
        Next i
        Cursor = Cursors.Arrow
        If Not Hay Then
            MsgError("No hay documentos marcados para enviar")
        Else
            Mensaje("Los Datos enviados a SII, demoran en algunos casos tener respuestas, " + vbCrLf + "deberá consultar los documentos en unos minutos mas para conocer su estado.")
            'Volver a Cargar los Datos
            Consultar_Datos()
        End If

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Titulos()
        cLocal.Text = ""
        cTipoDoc.Text = ""
        cEstados.Text = ""

        xF1.Value = IniFecha(1, Now.Date)
        xF2.Value = IniFecha(2, Now.Date)

        oRapido.Checked = True

        cLocal.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Sub Titulos()
        xTabla.Redraw = True

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 16

        xTabla.SetData(0, T_OK, "Ok")
        xTabla.SetData(0, T_ESTADO, "Estado")
        xTabla.SetData(0, T_TIPODOC, "Tipo.Doc.")
        xTabla.SetData(0, T_DOC, "Documento")
        xTabla.SetData(0, T_NUM, "Número")
        xTabla.SetData(0, T_FECHA, "Fecha")
        xTabla.SetData(0, T_USUARIO, "Usuario")
        xTabla.SetData(0, T_LOCAL, "Local")
        xTabla.SetData(0, T_NOMBRELOCAL, "Local")
        xTabla.SetData(0, T_CLIENTE, "Cliente")
        xTabla.SetData(0, T_RUT, "Rut")
        xTabla.SetData(0, T_NOMBRE, "Nombre")
        xTabla.SetData(0, T_FPAGO, "F.Pago")
        xTabla.SetData(0, T_MONTO, "Monto")
        xTabla.SetData(0, T_OBS, "Observaciones")
        xTabla.SetData(0, T_LINEA, "Primera Linea")

        xTabla.Cols(T_OK).Width = 30
        xTabla.Cols(T_ESTADO).Width = 160
        xTabla.Cols(T_TIPODOC).Width = 0
        xTabla.Cols(T_DOC).Width = 105
        xTabla.Cols(T_NUM).Width = 65
        xTabla.Cols(T_FECHA).Width = 70
        xTabla.Cols(T_USUARIO).Width = 50
        xTabla.Cols(T_LOCAL).Width = 0
        xTabla.Cols(T_NOMBRELOCAL).Width = 80
        xTabla.Cols(T_CLIENTE).Width = 60
        xTabla.Cols(T_RUT).Width = 80
        xTabla.Cols(T_NOMBRE).Width = 280
        xTabla.Cols(T_FPAGO).Width = 80
        xTabla.Cols(T_MONTO).Width = 80
        xTabla.Cols(T_OBS).Width = 1000
        xTabla.Cols(T_LINEA).Width = 0

        xTabla.Cols(T_OK).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHA).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_MONTO).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_NUM).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_CLIENTE).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_USUARIO).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_OBS).TextAlignFixed = TextAlignEnum.LeftCenter

        xTabla.Cols(T_OK).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHA).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_NUM).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_CLIENTE).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_USUARIO).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_MONTO).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_OBS).TextAlign = TextAlignEnum.LeftCenter

        xTabla.Cols(T_OK).DataType = GetType(Boolean)
        xTabla.Cols(T_MONTO).DataType = GetType(Double)
        xTabla.Cols(T_MONTO).Format = "N0"
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        bConsultar.Enabled = False
        Consultar_Datos()
        bConsultar.Enabled = True
    End Sub

    Sub Consultar_Datos()
        Dim wTipoDoc As String

        lStatus.Text = ""
        wFila = 0
        wLocal = 999
        Titulos()

        If Trim(cLocal.Text) <> "" Then
            If Buscar("Locales", "NombreLocal", Trim(cLocal.Text), "Local") Then
                wLocal = Swap("Local").Value
            End If
        End If

        Cursor = Cursors.WaitCursor
        xTabla.Visible = False

        wTipoDoc = BuscaDocumento(cTipoDoc.Text)
        If wTipoDoc = "FV" Or wTipoDoc = "" Then
            Call Cargar_Datos("FV")
        End If
        If wTipoDoc = "NC" Or wTipoDoc = "" Then
            Call Cargar_Datos("NC")
        End If
        If wTipoDoc = "ND" Or wTipoDoc = "" Then
            Call Cargar_Datos("ND")
        End If
        If wTipoDoc = "GD" Or wTipoDoc = "" Then
            Call Cargar_Datos("GD")
        End If
        If wTipoDoc = "BV" Or wTipoDoc = "" Then
            Call Cargar_Datos("BV")
        End If
        If wTipoDoc = "FE" Or wTipoDoc = "" Then
            Call Cargar_Datos("FE")
        End If
        If wTipoDoc = "FC" Or wTipoDoc = "" Then
            Call Cargar_Datos("FC")
        End If

        If xTabla.Rows.Count > 1 Then
            xTabla.Col = 1 : xTabla.Row = 1
        End If

        lStatus.Text = "Documentos: " + Num(wFila)
        Cursor = Cursors.Arrow
        xTabla.Visible = True

    End Sub

    Sub Cargar_Datos(wTipo As String)
        Dim Filtro As String, wDocumento As String, wEstado As String, wLocal As Integer, wRut As String

        wLocal = 999
        If Trim(cLocal.Text) <> "" Then
            If Buscar("Locales", "NombreLocal", Trim(cLocal.Text), "Local") Then
                wLocal = Swap("Local").Value
            End If
        End If

        If wLocal = 999 Then
            Filtro = "(1=1)"
        Else
            Filtro = "Local = " + Num(wLocal)
        End If

        If wTipo <> "" Then
            Filtro = Filtro + " and TipoDoc = '" + wTipo + "'"
        End If


        DocG = SQL("Select Local,TipoDoc,Numero,Fecha,Usuario,Cliente,FPago,Total,DTE,Status_DTE,TED,Firma from DocumentosG where " + Filtro + " and Fecha >= '" + Format(xF1.Value, "dd/MM/yyyy 00:00:00") + "' and Fecha <= '" + Format(xF2.Value, "dd/MM/yyyy 23:59:59") + "'  Order by Numero,Fecha")
        If DocG.RecordCount > 0 Then
            wDocumento = BuscaNombreDocumento(DocG("TipoDoc").Value).Trim
            While Not DocG.EOF
                DoEvents()
                wFila = wFila + 1
                xTabla.AddItem("")
                xTabla.SetData(wFila, T_OK, UNCHECK)
                If DocG("Numero").Value = 0 Then
                    Respuesta = 1
                End If
                If DocG("DTE").Value Then
                    If DocG("Status_DTE").Value = 0 Or IsDBNull(DocG("Status_DTE").Value) Then
                        xTabla.SetData(wFila, T_ESTADO, EI)
                        xTabla.FuenteCelda(wFila, Color.Magenta, Color.Black)
                        xTabla.FondoCelda(wFila, Color.Magenta)
                    End If
                    If DocG("Status_DTE").Value = 1 Then
                        xTabla.SetData(wFila, T_ESTADO, AP)
                        xTabla.FuenteCelda(wFila, Color.LightGreen, Color.Black)
                        xTabla.FondoCelda(wFila, Color.LightGreen)
                    End If
                    If DocG("Status_DTE").Value = 2 Then
                        xTabla.SetData(wFila, T_ESTADO, RE)
                        xTabla.FuenteCelda(wFila, Color.Red, Color.Yellow)
                        xTabla.FondoCelda(wFila, Color.Red)
                    End If
                    If DocG("Status_DTE").Value = 3 Then
                        xTabla.SetData(wFila, T_ESTADO, PT)
                        xTabla.FuenteCelda(wFila, Color.Bisque, Color.Black)
                        xTabla.FondoCelda(wFila, Color.Bisque)
                    End If
                    If IsDBNull(DocG("TED").Value) Or IsDBNull(DocG("Firma").Value) Then
                        xTabla.SetData(wFila, T_ESTADO, ST)
                        xTabla.FuenteCelda(wFila, Color.Red, Color.Yellow)
                        xTabla.FondoCelda(wFila, Color.Red)
                    Else
                        If Trim(DocG("TED").Value) = "" Then
                            xTabla.SetData(wFila, T_ESTADO, ST)
                            xTabla.FuenteCelda(wFila, Color.Red, Color.Yellow)
                            xTabla.FondoCelda(wFila, Color.Red)
                        End If
                    End If
                    'Verificar el status en SII
                    If Not oRapido.Checked Then
                        wEstado = 6
                        If DocG("Status_DTE").Value = 1 Or DocG("Status_DTE").Value = 2 Then
                            wRut = FE_Rut_Emisor
                            Loc = SQL("Select RutLocal from Locales where Local = " + Num(DocG("Local").Value))
                            If Loc.RecordCount > 0 Then
                                wRut = Rut_DTE(Loc("RutLocal").Value)
                            End If
                            Try
                                wEstado = Consultar_DTE(1, wRut, wTipo, Val(DocG("Numero").Value))
                                wEstado = Mid(wEstado, 1, 1)
                            Catch ex As Exception
                                wEstado = 7
                            End Try

                            If wEstado = "0" Then
                                xTabla.SetData(wFila, T_ESTADO, AP)
                                xTabla.FuenteCelda(wFila, Color.LightGreen, Color.Black)
                                xTabla.FondoCelda(wFila, Color.LightGreen)
                            End If
                            If wEstado = "1" Then
                                xTabla.SetData(wFila, T_OBS, Consultar_DTE(3, wRut, wTipo, Val(DocG("Numero").Value)))
                                xTabla.SetData(wFila, T_ESTADO, RP)
                                xTabla.FuenteCelda(wFila, Color.Orange, Color.Black)
                                xTabla.FondoCelda(wFila, Color.Orange)
                            End If
                            If wEstado = "2" Then
                                xTabla.SetData(wFila, T_OBS, Consultar_DTE(3, wRut, wTipo, Val(DocG("Numero").Value)))
                                xTabla.SetData(wFila, T_ESTADO, AR)
                                xTabla.FuenteCelda(wFila, Color.Orange, Color.Black)
                                xTabla.FondoCelda(wFila, Color.Yellow)
                            End If

                            If wEstado = "6" Then
                                xTabla.SetData(wFila, T_OBS, "Consulta Rápida")
                                xTabla.FuenteCelda(wFila, Color.White, Color.Black)
                                xTabla.FondoCelda(wFila, Color.White)
                            End If
                            If wEstado = "7" Then
                                xTabla.SetData(wFila, T_OBS, "No se pudo Consultar DTE")
                                xTabla.SetData(wFila, T_ESTADO, RP)
                                xTabla.FondoCelda(wFila, Color.Blue)
                            End If
                            If wEstado = "9" Then
                                xTabla.SetData(wFila, T_OBS, Consultar_DTE(3, wRut, wTipo, Val(DocG("Numero").Value)))
                                xTabla.SetData(wFila, T_ESTADO, RE)
                                xTabla.FuenteCelda(wFila, Color.Red, Color.Yellow)
                            End If
                            If wEstado = "3" Or wEstado = "4" Or wEstado = "5" Or wEstado = "8" Then
                                xTabla.SetData(wFila, T_OBS, Consultar_DTE(3, wRut, wTipo, Val(DocG("Numero").Value)))
                                xTabla.SetData(wFila, T_ESTADO, ND)
                                xTabla.FuenteCelda(wFila, Color.Black, Color.White)
                            End If
                        End If
                    Else
                        xTabla.SetData(wFila, T_OBS, "Consulta Rápida")
                    End If
                    'Código No Definido 
                    If DocG("Status_DTE").Value > 3 Then
                        xTabla.SetData(wFila, T_ESTADO, ND)
                        xTabla.FuenteCelda(wFila, Color.Black, Color.White)
                    End If

                    'Especiales
                    If oCheckTED.Checked Then
                        If Leer_JPG(Archivo_Fiscal(gJPG, DocG("Local").Value, DocG("TipoDoc").Value, DocG("Numero").Value, DocG("Cliente").Value)) Is Nothing Then
                            xTabla.SetData(wFila, T_ESTADO, SA)
                            xTabla.FuenteCelda(wFila, Color.Red, Color.Yellow)
                        End If
                        If Leer_TED(Archivo_Fiscal(gXML, DocG("Local").Value, DocG("TipoDoc").Value, DocG("Numero").Value, DocG("Cliente").Value)) = "" Then
                            xTabla.SetData(wFila, T_ESTADO, SA)
                            xTabla.FuenteCelda(wFila, Color.Red, Color.Yellow)
                        End If
                    End If
                Else
                    xTabla.SetData(wFila, T_ESTADO, "No es Electrónico")
                    xTabla.FondoCelda(wFila, Color.Silver)
                End If

                xTabla.SetData(wFila, T_TIPODOC, Codigo_DTE(wTipo))
                xTabla.SetData(wFila, T_DOC, wDocumento)
                xTabla.SetData(wFila, T_NUM, DocG("Numero").Value)
                xTabla.SetData(wFila, T_FECHA, Format(DocG("Fecha").Value, "dd/MM/yyyy"))
                xTabla.SetData(wFila, T_USUARIO, DocG("Usuario").Value)
                xTabla.SetData(wFila, T_LOCAL, DocG("Local").Value)
                xTabla.SetData(wFila, T_NOMBRELOCAL, BuscarCampo("Locales", "NombreLocal", "Local", DocG("Local").Value))
                xTabla.SetData(wFila, T_CLIENTE, DocG("Cliente").Value)
                If Buscar("Clientes", "Cliente", DocG("Cliente").Value, "Nombre,Rut") Then
                    xTabla.SetData(wFila, T_NOMBRE, Swap("Nombre").Value.trim)
                    xTabla.SetData(wFila, T_RUT, Swap("Rut").Value)
                End If
                xTabla.SetData(wFila, T_FPAGO, BuscarCampo("FPagos", "DescFPago", "FPago", DocG("FPago").Value))
                xTabla.SetData(wFila, T_MONTO, DocG("Total").Value)

                xTabla.SetData(wFila, T_LINEA, Primera_Linea(DocG("Local").Value, DocG("TipoDoc").Value, DocG("Numero").Value))

                DocG.MoveNext()
            End While
        End If
    End Sub

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click
        If xTabla.Rows.Count > 1 Then
            If xTabla.Col = T_OK Then
                If xTabla.GetData(xTabla.Row, T_OK) = CHECK Then
                    xTabla.SetData(xTabla.Row, T_OK, UNCHECK)
                Else
                    xTabla.SetData(xTabla.Row, T_OK, CHECK)
                End If
            End If
        End If
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Row > 0 Then
            If oImprimir.Checked Then
                ImprimirDocumentos.Show()
                ImprimirDocumentos.cLocal.Text = Trim(xTabla.GetData(xTabla.Row, T_NOMBRELOCAL))
                ImprimirDocumentos.cTipoDoc.Text = Trim(xTabla.GetData(xTabla.Row, T_DOC))
                ImprimirDocumentos.xNumDoc.Text = xTabla.GetData(xTabla.Row, T_NUM)
                ImprimirDocumentos.Imprimir_Datos()
            End If

            If oConsultar.Checked Then
                ConsultarDTE.Show()
                If Buscar("Locales", "Local", xTabla.GetData(xTabla.Row, T_LOCAL), "NombreLocal") Then
                    ConsultarDTE.cLocal.Text = Swap("NombreLocal").Text
                End If
                ConsultarDTE.cTipoDoc.Text = xTabla.GetData(xTabla.Row, T_DOC)
                ConsultarDTE.xNumero.Text = xTabla.GetData(xTabla.Row, T_NUM)
                ConsultarDTE.Consultar_Datos()
            End If

        End If
    End Sub

    Private Sub bProcesar_Click(sender As Object, e As EventArgs) Handles bProcesar.Click
        Dim Hay As Boolean

        Hay = False
        Cursor = Cursors.WaitCursor
        For i = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(i, T_OK) = CHECK Then
                If oCrearTED.Checked Then
                    Dim Opcion_Crear As Boolean = True, wDoc As String = BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(i, T_DOC))
                    If Leer_JPG(Archivo_Fiscal(gJPG, Val(xTabla.GetData(i, T_LOCAL)), wDoc, xTabla.GetData(i, T_NUM), Val(xTabla.GetData(i, T_CLIENTE)))) Is Nothing Then
                        Opcion_Crear = True
                    Else
                        If Leer_TED(Archivo_Fiscal(gXML, Val(xTabla.GetData(i, T_LOCAL)), wDoc, xTabla.GetData(i, T_NUM), Val(xTabla.GetData(i, T_CLIENTE)))) = "" Then
                            Opcion_Crear = True
                        End If
                    End If

                    If oWS.Checked Then
                        'WEBSERVICE                   
                        Dim WS = New SisVenWS1.Service
                        Dim wDT = WS.EmitirTED(1, ClienteLocalActual, Val(xTabla.GetData(i, T_LOCAL)), wDoc, Val(xTabla.GetData(i, T_NUM)))
                        If Val(wDT.Rows(0).Item(0)) = 1 Then '1 = Operación Exitosa
                            Dim wXML = wDT.Rows(0).Item(2)
                            'TED Generado correctamente.
                            TED_Generado = True
                            If Not Crear_TED(Val(xTabla.GetData(i, T_LOCAL)), wDoc, Val(xTabla.GetData(i, T_NUM))) Then
                                MsgError("Error al Grabar TED en disco")
                            End If
                        Else
                            MsgError("Error Generando TED: " & wDT.Rows(0).Item(1)) 'Item1 tiene el mensaje de error.                    
                        End If
                        If Opcion_Crear Then
                            'Crear Archivos a partir de los campos e las Tablas
                            If Not Crear_TED(Val(xTabla.GetData(i, T_LOCAL)), wDoc, xTabla.GetData(i, T_NUM)) Then
                                'El_Error("No se pudo crear TED")
                            End If
                        End If
                    Else
                        'TIMBRADOR
                        Generar_TED(Val(xTabla.GetData(i, T_LOCAL)), wDoc, xTabla.GetData(i, T_NUM), xTabla.GetData(i, T_FECHA), Rut_DTE(xTabla.GetData(i, T_RUT)), Formatea_Texto(xTabla.GetData(i, T_NOMBRE)), xTabla.GetData(i, T_MONTO), xTabla.GetData(i, T_LINEA))
                        Grabar_TED(Val(xTabla.GetData(i, T_LOCAL)), wDoc, xTabla.GetData(i, T_NUM))
                    End If
                End If

                If xTabla.GetData(i, T_ESTADO) = NE Then
                    'El_Error ("No se puede enviar a DTE Documentos No electrónicos")
                Else
                    If xTabla.GetData(i, T_ESTADO) = AP Or xTabla.GetData(i, T_ESTADO) = AR Then
                        'El_Error ("Documento Electrónico ya enviado a SII, no se puede volver a enviar")
                    Else
                        Hay = True
                        If xTabla.GetData(i, T_ESTADO) = ST Then
                            'No tiene TED, debe volver a crearse
                            ''Generar_TED(Val(xTabla.GetData(i, T_LOCAL)), BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(i, T_DOC)), xTabla.GetData(i, T_NUM), xTabla.GetData(i, T_FECHA), Rut_DTE(xTabla.GetData(i, T_RUT)), Formatea_Texto(xTabla.GetData(i, T_NOMBRE)), xTabla.GetData(i, T_MONTO), xTabla.GetData(i, T_LINEA))
                            Crear_TED(Val(xTabla.GetData(i, T_LOCAL)), BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(i, T_DOC)), xTabla.GetData(i, T_NUM))
                        Else
                            'Envio al DTE                        
                            If Emitir_DTE(Val(xTabla.GetData(i, T_LOCAL)), BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(i, T_DOC)), xTabla.GetData(i, T_NUM)) Then
                                'Me.MousePointer = vbDefault
                                'El_Mensaje (Tabla.TextMatrix(Tabla.Row, T_DOC) + " " + Str(Tabla.TextMatrix(Tabla.Row, T_NUM)) + " Enviada Correctamente.")
                            Else
                                'Me.MousePointer = vbDefault
                                'El_Error ("Error al Enviar Documento Electrónico")
                            End If
                        End If
                    End If
                End If
            End If
        Next i
        Cursor = Cursors.Arrow
        If Not Hay Then
            MsgError("No hay documentos marcados para enviar")
        Else
            Mensaje("Los datos enviados a SII, demoran en algunos casos tener respuestas, " + vbCrLf + "deberá consultar los documentos en unos minutos mas para conocer su estado.")
            'Volver a Cargar los Datos
            Consultar_Datos()
        End If
    End Sub

    Private Sub oConsultar_CheckedChanged(sender As Object, e As EventArgs) Handles oConsultar.CheckedChanged, oImprimir.CheckedChanged, oRapido.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.FromArgb(29, 73, 140))

        wRadioButton.Image = If(wRadioButton.Checked, My.Resources.Resources.check16true_b,
                                                    My.Resources.Resources.check16false_b)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles oWS.CheckedChanged

    End Sub

    Private Sub gFiltro_Enter(sender As Object, e As EventArgs) Handles gFiltro.Enter

    End Sub
End Class