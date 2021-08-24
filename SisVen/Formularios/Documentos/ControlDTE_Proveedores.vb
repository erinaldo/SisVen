Imports C1.Win.C1FlexGrid
Imports IDAutomation
Imports DTEBoxCliente

Public Class ControlDTE_Proveedores
    Const T_OK = 0
    Const T_ESTADO = 1
    Const T_TIPODOC = 2
    Const T_DOC = 3
    Const T_NUM = 4
    Const T_FECHA = 5
    Const T_FECHASII = 6
    Const T_LOCAL = 7
    Const T_NOMBRELOCAL = 8
    Const T_CLIENTE = 9
    Const T_RUT = 10
    Const T_NOMBRE = 11
    Const T_FPAGO = 12
    Const T_MONTO = 13
    Const T_APROBADO = 14
    Const T_ANULADO = 15
    Const T_CESION = 16
    Const T_ELIMINADO = 17
    Const T_DISTRIBUIDO = 18
    Const T_RECIBIDO = 19
    Const T_SEGUIMIENTO = 20
    Const T_NOMBRECONTACTO = 21
    Const T_TELEFONOCONTACTO = 22
    Const T_CORREOCONTACTO = 23
    Const T_OBSERVACIONES = 24

    Const NO = ""
    Const AP = "Aceptado"
    Const RE = "Rechazado"
    Const AL = "Aceptado Ley 19983"

    Dim wFila As Integer
    Dim wLocal As Integer

    Dim zContacto As String
    Dim zTelefonos As String
    Dim zCorreo As String
    Dim zObservacines As String

    Dim cEst As New ComboBox

    Private Sub ControlDTE_Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loc = SQL("Select NombreLocal from Locales WHERE FElectronica = 1 Order by Local")
        cLocal.Items.Add("")
        While Not Loc.EOF
            cLocal.Items.Add(Loc.Fields("NombreLocal").Value.ToString.Trim)
            If gMonoLocal Then
                cLocal.Text = Loc("NombreLocal").Value
            End If
            Loc.MoveNext()
        End While

        Titulos()

        cEstados.Items.Add(NO)
        cEstados.Items.Add(AP)
        cEstados.Items.Add(AL)
        cEstados.Items.Add(RE)

        cEst.Items.Add(NO)
        cEst.Items.Add(AP)
        cEst.Items.Add(AL)
        cEst.Items.Add(RE)

        xF1.Value = IniFecha(1, Now.Date)
        xF2.Value = Now.Date
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Titulos()
        cLocal.Text = ""
        cTipoDoc.Text = ""
        cEstados.Text = ""

        xF1.Value = IniFecha(1, Now.Date)
        xF2.Value = Now.Date

        cLocal.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Sub Titulos()
        xTabla.Redraw = True

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 25

        xTabla.SetData(0, T_OK, "Ok")
        xTabla.SetData(0, T_ESTADO, "Estado")
        xTabla.SetData(0, T_TIPODOC, "Tipo.Doc.")
        xTabla.SetData(0, T_DOC, "Documento")
        xTabla.SetData(0, T_NUM, "Número")
        xTabla.SetData(0, T_FECHA, "Fecha")
        xTabla.SetData(0, T_FECHASII, "Recepción SII")
        xTabla.SetData(0, T_LOCAL, "Local")
        xTabla.SetData(0, T_NOMBRELOCAL, "Local")
        xTabla.SetData(0, T_CLIENTE, "Cliente")
        xTabla.SetData(0, T_RUT, "Rut")
        xTabla.SetData(0, T_NOMBRE, "Nombre")
        xTabla.SetData(0, T_FPAGO, "F.Pago")
        xTabla.SetData(0, T_MONTO, "Monto")
        xTabla.SetData(0, T_APROBADO, "Autorizado")
        xTabla.SetData(0, T_ANULADO, "Anulado")
        xTabla.SetData(0, T_CESION, "Cesión")
        xTabla.SetData(0, T_ELIMINADO, "Eliminado")
        xTabla.SetData(0, T_DISTRIBUIDO, "Distribuido")
        xTabla.SetData(0, T_RECIBIDO, "Recibido")
        xTabla.SetData(0, T_SEGUIMIENTO, "Autorizado")
        xTabla.SetData(0, T_NOMBRECONTACTO, "Nombre Contacto")
        xTabla.SetData(0, T_TELEFONOCONTACTO, "Telefono Contacto")
        xTabla.SetData(0, T_CORREOCONTACTO, "Correo Contacto")
        xTabla.SetData(0, T_OBSERVACIONES, "Observaciones")

        xTabla.Cols(T_OK).Width = 30
        xTabla.Cols(T_ESTADO).Width = 110
        xTabla.Cols(T_TIPODOC).Width = 0
        xTabla.Cols(T_DOC).Width = 105
        xTabla.Cols(T_NUM).Width = 70
        xTabla.Cols(T_FECHA).Width = 75
        xTabla.Cols(T_FECHASII).Width = 0
        xTabla.Cols(T_LOCAL).Width = 0
        xTabla.Cols(T_NOMBRELOCAL).Width = 0
        xTabla.Cols(T_CLIENTE).Width = 60
        xTabla.Cols(T_RUT).Width = 80
        xTabla.Cols(T_NOMBRE).Width = 200
        xTabla.Cols(T_FPAGO).Width = 0
        xTabla.Cols(T_MONTO).Width = 80
        xTabla.Cols(T_APROBADO).Width = 60
        xTabla.Cols(T_ANULADO).Width = 60
        xTabla.Cols(T_CESION).Width = 0
        xTabla.Cols(T_ELIMINADO).Width = 60
        xTabla.Cols(T_DISTRIBUIDO).Width = 60
        xTabla.Cols(T_RECIBIDO).Width = 60
        xTabla.Cols(T_SEGUIMIENTO).Width = 0
        xTabla.Cols(T_NOMBRECONTACTO).Width = 50
        xTabla.Cols(T_TELEFONOCONTACTO).Width = 50
        xTabla.Cols(T_CORREOCONTACTO).Width = 50
        xTabla.Cols(T_OBSERVACIONES).Width = 200

        xTabla.Cols(T_OK).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHA).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHASII).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_MONTO).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_NUM).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_CLIENTE).TextAlignFixed = TextAlignEnum.RightCenter

        xTabla.Cols(T_OK).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHA).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHASII).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_NUM).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_CLIENTE).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_MONTO).TextAlign = TextAlignEnum.RightCenter

        xTabla.Cols(T_OK).DataType = GetType(Boolean)
        xTabla.Cols(T_MONTO).DataType = GetType(Double)
        xTabla.Cols(T_MONTO).Format = "N0"

        cEst.DropDownStyle = ComboBoxStyle.DropDownList
        xTabla.Cols(T_ESTADO).Editor = cEst
        AddHandler cEst.SelectedIndexChanged, AddressOf ComboGrilla_SelectedIndexChanged

    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        bConsultar.Enabled = False
        Consultar_Datos()
        bConsultar.Enabled = True
    End Sub

    Sub Consultar_Datos()
        Dim wReceptor As String
        Dim PageSize As Integer = 300 'El tamaño máximo de página permitido es de 300 

        lStatus.Text = ""
        wFila = 0
        Titulos()

        wReceptor = FE_Rut_Emisor
        If Trim(cLocal.Text) <> "" Then
            If Buscar("Locales", "NombreLocal", Trim(cLocal.Text), "Local,RutLocal") Then
                wLocal = Swap("Local").Value
                wReceptor = Rut_DTE(Swap("RutLocal").Value)
            End If
        End If

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim AmbienteDTE As DTEBoxCliente.Ambiente
        AmbienteDTE = FE_Ambiente

        If xF2.Value > Date.Now Then
            xF2.Value = Date.Now
        End If
        Dim FechaDesde As String = FE_Fecha(xF1.Value)
        Dim FechaHasta As String = FE_Fecha(xF2.Value)

        Cursor = Cursors.WaitCursor
        'Esta Funcion es para verificar documentos en SII que NO estan en el DTE
        'Dim ResultadoDTE As ResultadoDocumentos = ServicioDTE.ReconciliarDocumentos(FE_Ambiente, wReceptor, FechaDesde, FechaHasta)

        Dim DTE_GrupoRecibidos As DTEBoxCliente.GrupoBusqueda = DTEBoxCliente.GrupoBusqueda.Recibidos

        'DTE_Consulta = "(TipoDTE:33 or TipoDTE:34 or TipoDTE:39 or TipoDTE:52 or TipoDTE:56 or TipoDTE:61) "
        'DTE_Consulta += " AND (FchEmis:[" + FechaDesde + " TO " + FechaHasta + "]) "
        'DTE_Consulta += " AND (RUTRecep:" + FE_Rut_Emisor + ") "

        DTE_Consulta = "(FchEmis:[" + FechaDesde + " TO " + FechaHasta + "] AND RUTRecep:" + wReceptor + ")"
        ' DTE_Consulta = "(FchEmis:[" + FechaDesde + " TO " + FechaHasta + "] "

        Dim ResultadoDTE As ResultadoDocumentos = ServicioDTE.BuscarDocumentos(AmbienteDTE, DTE_GrupoRecibidos, DTE_Consulta, 0, PageSize)
        If (ResultadoDTE.ResultadoServicio.Estado = 0) Then
            If (ResultadoDTE.TotalDocumentos > 0) Then

                xTabla.Visible = False

                Call Cargar_Datos(ResultadoDTE)

                If xTabla.Rows.Count > 1 Then
                    xTabla.Col = 1 : xTabla.Row = 1
                End If

                lStatus.Text = "Documentos: " + Num(wFila)
                Cursor = Cursors.Arrow
                xTabla.Visible = True

            Else
                Cursor = Cursors.Arrow
                MsgError("No se encontraron documentos.")
            End If
        Else
            ' Si la llamada no fue satisfactoria
            Cursor = Cursors.Arrow
            MsgError(ResultadoDTE.ResultadoServicio.Descripcion)
        End If

    End Sub

    Sub Cargar_Datos(ResultadoDTE As ResultadoDocumentos)
        Dim wRut As String, wTipoDoc As String, wEstado As String

        wFila = 0

        For Each doc As ResumenDTE In ResultadoDTE.ResumenDtes
            DoEvents()
            If oTodos.Checked = False And (doc.TipoDTE = 39 Or doc.TipoDTE = 52 Or doc.TipoDTE = 46 Or doc.TipoDTE = 801) Then
                'No considerar estos documentos
            Else
                wTipoDoc = BuscarCampo("TipoDoc", "DescTipoDoc", "Cod_SII", doc.TipoDTE)
                If Trim(cTipoDoc.Text) = wTipoDoc Or wTipoDoc = "" Or Trim(cTipoDoc.Text) = "" Then
                    xTabla.AddItem("")
                    wFila = wFila + 1
                    xTabla.SetData(wFila, T_OK, UNCHECK)

                    'If doc.Aprobado Then
                    '    xTabla.SetData(wFila, T_ESTADO, "")
                    'End If
                    xTabla.SetData(wFila, T_TIPODOC, BuscarCampo("TipoDoc", "TipoDoc", "Cod_SII", doc.TipoDTE))
                    xTabla.SetData(wFila, T_DOC, wTipoDoc)
                    xTabla.SetData(wFila, T_NUM, doc.Folio)
                    xTabla.SetData(wFila, T_FECHA, Format(doc.FchEmis, "dd/MM/yyyy"))
                    xTabla.SetData(wFila, T_FECHASII, Format(doc.FchRecepSII, "dd/MM/yyyy"))
                    wRut = Formatea_Rut(doc.RUTEmisor, 1)
                    Cli = SQL("Select * from Clientes where Rut = '" + wRut + "'")
                    If Cli.RecordCount > 0 Then
                        xTabla.SetData(wFila, T_CLIENTE, Cli("Cliente").Value)
                        xTabla.SetData(wFila, T_NOMBRE, Cli("Nombre").Value)
                        xTabla.SetData(wFila, T_RUT, Cli("Rut").Value)
                    Else
                        xTabla.SetData(wFila, T_NOMBRE, doc.RznSoc)
                        xTabla.SetData(wFila, T_RUT, doc.RUTEmisor)
                    End If
                    xTabla.SetData(wFila, T_MONTO, doc.MntTotal)
                    xTabla.SetData(wFila, T_FPAGO, doc.Estructura)

                    'xTabla.SetData(wFila, T_APROBADO, doc.Aprobado)
                    xTabla.SetData(wFila, T_APROBADO, doc.AutorizadoSII)
                    xTabla.SetData(wFila, T_ANULADO, doc.Anulado)
                    xTabla.SetData(wFila, T_CESION, doc.Cesion)
                    xTabla.SetData(wFila, T_ELIMINADO, doc.Eliminado)
                    xTabla.SetData(wFila, T_DISTRIBUIDO, doc.Distribuido)
                    xTabla.SetData(wFila, T_RECIBIDO, doc.Recibido)
                    xTabla.SetData(wFila, T_SEGUIMIENTO, doc.Seguimiento)

                    wEstado = Status_Comercial("", xTabla.GetData(wFila, T_RUT), xTabla.GetData(wFila, T_TIPODOC), xTabla.GetData(wFila, T_NUM))
                    Select Case wEstado
                        Case 0
                            xTabla.SetData(wFila, T_ESTADO, NO)
                        Case 1
                            xTabla.SetData(wFila, T_ESTADO, AL)
                        Case 2
                            xTabla.SetData(wFila, T_ESTADO, AP)
                        Case 3
                            xTabla.SetData(wFila, T_ESTADO, RE)
                    End Select

                    xTabla.SetData(wFila, T_NOMBRECONTACTO, zContacto)
                    xTabla.SetData(wFila, T_TELEFONOCONTACTO, zTelefonos)
                    xTabla.SetData(wFila, T_CORREOCONTACTO, zCorreo)
                End If
            End If
        Next
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
            If xTabla.Col = T_ESTADO Then
                xTabla.StartEditing(xTabla.Row, T_ESTADO)
            End If
            If xTabla.Col >= T_DOC And xTabla.Col <= T_MONTO Then
                If Pregunta("Desea Ver/Imprimir Documentos del Proveedor" & vbCrLf & xTabla.GetData(xTabla.Row, T_DOC) & ": " & xTabla.GetData(xTabla.Row, T_NUM)) Then
                    Imprimir_Documento_Proveedor(xTabla.GetData(xTabla.Row, T_RUT), xTabla.GetData(xTabla.Row, T_TIPODOC), xTabla.GetData(xTabla.Row, T_NUM))
                End If
            End If
        End If
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Row > 0 Then

        End If
    End Sub

    Private Sub bProcesar_Click(sender As Object, e As EventArgs) Handles bProcesar.Click
        Dim Hay As Boolean, qRespuesta As String

        Hay = False
        Cursor = Cursors.WaitCursor
        For i = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(i, T_OK) = CHECK Then
                If xTabla.GetData(i, T_ESTADO) = AP Then
                    Hay = True
                    qRespuesta = Status_Comercial(AP, xTabla.GetData(i, T_RUT), xTabla.GetData(i, T_TIPODOC), xTabla.GetData(i, T_NUM), xTabla.GetData(i, T_NOMBRECONTACTO), xTabla.GetData(i, T_TELEFONOCONTACTO), xTabla.GetData(i, T_CORREOCONTACTO))
                    If qRespuesta <> "" Then
                        xTabla.SetData(i, T_OBSERVACIONES, qRespuesta)
                    End If
                End If
                If xTabla.GetData(i, T_ESTADO) = RE Then
                    Hay = True
                    qRespuesta = Status_Comercial(RE, xTabla.GetData(i, T_RUT), xTabla.GetData(i, T_TIPODOC), xTabla.GetData(i, T_NUM), xTabla.GetData(i, T_NOMBRECONTACTO), xTabla.GetData(i, T_TELEFONOCONTACTO), xTabla.GetData(i, T_CORREOCONTACTO))
                    If qRespuesta <> "" Then
                        xTabla.SetData(i, T_OBSERVACIONES, qRespuesta)
                    End If
                End If
            End If
        Next i
        Cursor = Cursors.Arrow
        If Not Hay Then
            MsgError("No hay documentos marcados para enviar")
        Else
            Mensaje("Datos enviados a SII.")
            'Volver a Cargar los Datos
            Consultar_Datos()
        End If
    End Sub
    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltro As String = ""
        Dim ListLocal = New List(Of LocalesReporte)

        Dim wReceptor As String
        Dim PageSize As Integer = 300 'El tamaño máximo de página permitido es de 300 

        wReceptor = FE_Rut_Emisor
        If Trim(cLocal.Text) <> "" Then
            If Buscar("Locales", "NombreLocal", Trim(cLocal.Text), "Local,RutLocal") Then
                wLocal = Swap("Local").Value
                wReceptor = Rut_DTE(Swap("RutLocal").Value)
            End If
        End If

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim AmbienteDTE As DTEBoxCliente.Ambiente
        AmbienteDTE = FE_Ambiente

        If xF2.Value > Date.Now Then
            xF2.Value = Date.Now
        End If
        Dim FechaDesde As String = FE_Fecha(xF1.Value)
        Dim FechaHasta As String = FE_Fecha(xF2.Value)

        Cursor = Cursors.WaitCursor

        Dim DTE_GrupoRecibidos As DTEBoxCliente.GrupoBusqueda = DTEBoxCliente.GrupoBusqueda.Recibidos

        DTE_Consulta = "(TipoDTE:33 or TipoDTE:34 or TipoDTE:39 or TipoDTE:52 or TipoDTE:56 or TipoDTE:61) "
        DTE_Consulta += " AND (FchEmis:[" + FechaDesde + " TO " + FechaHasta + "]) "
        DTE_Consulta += " AND (RUTRecep:" + FE_Rut_Emisor + ") "

        Dim ResultadoDTE As ResultadoDocumentos = ServicioDTE.BuscarDocumentos(AmbienteDTE, DTE_GrupoRecibidos, DTE_Consulta, 0, PageSize)
        If (ResultadoDTE.ResultadoServicio.Estado = 0) Then
            If (ResultadoDTE.TotalDocumentos > 0) Then
                Dim wLista As New List(Of ControlDTEProveedorReporte)
                Dim wCliente As String = ""
                Dim wRut As String = ""
                Dim WNombreCliente As String = ""
                For Each wC In ResultadoDTE.ResumenDtes

                    Cli = SQL("Select * from Clientes where Rut = '" & Formatea_Rut(wC.RUTEmisor, 1) & "'")

                    If Cli.RecordCount > 0 Then
                        wCliente = Cli("Cliente").Value
                        WNombreCliente = Cli("Nombre").Value
                        wRut = Cli("Rut").Value
                    Else
                        WNombreCliente = wC.RznSoc
                        wRut = wC.RUTEmisor
                    End If

                    wLista.Add(New ControlDTEProveedorReporte With {.TipoDoc = BuscarCampo("TipoDoc", "DescTipoDoc", "Cod_SII", wC.TipoDTE),
                                                                    .TipoDTE = If(wC.TipoDTE Is DBNull.Value, "", wC.TipoDTE),
                                                                    .Folio = wC.Folio,
                                                                    .FchEmis = If(wC.FchEmis.ToString = "", "", Format(wC.FchEmis, "dd/mm/yyyy")),
                                                                    .FchRecepSII = If(wC.FchRecepSII.ToString = "", "", Format(wC.FchRecepSII, "dd/MM/yyyy")),
                                                                    .RUTEmisor = If(wC.RUTEmisor Is DBNull.Value, "", wC.RUTEmisor),
                                                                    .Cliente = If(wCliente Is DBNull.Value, "", wCliente),
                                                                    .NombreCliente = If(WNombreCliente Is DBNull.Value, "", WNombreCliente),
                                                                    .Rut = If(wRut Is DBNull.Value, "", wRut),
                                                                    .MntTotal = If(wC.MntTotal Is DBNull.Value, "", wC.MntTotal),
                                                                    .Aprobado = If(wC.Aprobado Is DBNull.Value, "", wC.Aprobado),
                                                                    .Anulado = If(wC.Anulado Is DBNull.Value, "", wC.Anulado),
                                                                    .Cesion = If(wC.Cesion Is DBNull.Value, "", wC.Cesion),
                                                                    .Eliminado = If(wC.Eliminado Is DBNull.Value, "", wC.Eliminado),
                                                                    .Distribuido = If(wC.Distribuido Is DBNull.Value, "", wC.Distribuido),
                                                                    .Recibido = If(wC.Recibido Is DBNull.Value, "", wC.Recibido),
                                                                    .Seguimiento = If(wC.Seguimiento Is DBNull.Value, "", wC.Seguimiento)})
                Next

                Loc = SQL("SELECT Logo FROM Locales WHERE Local=" & LocalActual)
                If Not Loc.EOF Then
                    ListLocal.Add(New LocalesReporte With {.Logo = If(Loc.Fields("Logo").Value Is Nothing, Nothing, Loc.Fields("Logo").Value)})
                End If

                Dim wReporte As New ReporteControlDTEProveedores
                wReporte.Database.Tables("SisVen_ControlDTEProveedorReporte").SetDataSource(wLista)
                wReporte.Database.Tables("SisVen_LocalesReporte").SetDataSource(ListLocal)

                VisorReportes.Visor_Reporte.ReportSource = wReporte
                VisorReportes.Show()
            Else
                MsgError("No se encuentra Documentos")
            End If
        End If
        Cursor = Cursors.Arrow
    End Sub
    Private Sub ComboGrilla_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Function Status_Comercial(wModo As String, wRut As String, wTipoDoc As String, wNumDoc As Double, Optional wContactoNombre As String = "", Optional wContactoTelefono As String = "", Optional wContactoCorreo As String = "") As String
        Dim wObservaciones As String = "", wXML As String

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        zContacto = "" : zTelefonos = "" : zCorreo = ""

        If wModo = "" Then
            'Consulta de Estado             
            Dim Grupo As GrupoBusqueda = GrupoBusqueda.Recibidos
            Dim RetornarXML As Boolean = True

            'Se efectúa la llamada al servicio, el último parámetro es un boolean que indica si se desea que el servicio devuelva el xml de la respuesta comercial o no.
            Dim ResultadoEST As DTEBoxCliente.ResultadoConsultarEstadoComercial
            ResultadoEST = ServicioDTE.EstadoComercialDocumento(FE_Ambiente, Grupo, Formatea_Rut(wRut, 0), Codigo_Fiscal(wTipoDoc), wNumDoc, RetornarXML)
            If (ResultadoEST.ResultadoServicio.Estado = "0") Then
                'El código de estado comercial puede tomar los siguientes valores: 0-Sin aceptaci�n o rechazo comercial, 1-Aceptado Ley 19983, 2-Aceptado, 3-Rechazado
                Status_Comercial = ResultadoEST.CodigoEstadoComercial
                If Status_Comercial = Nothing Then Status_Comercial = NO
                Respuesta = ResultadoEST.DescripcionEstadoComercial
                zContacto = ResultadoEST.NombreContacto
                zCorreo = ResultadoEST.CorreoContacto
                zTelefonos = ResultadoEST.TelefonoContacto
                zObservacines = ResultadoEST.Observaciones
                wXML = ResultadoEST.ACKXml
            Else
                Status_Comercial = Trim(ResultadoEST.ResultadoServicio.Descripcion)
            End If
        Else
            If wModo = AP Then
                wObservaciones = "Documento Aprobado"
            End If
            If wModo = RE Then
                wObservaciones = "Documento Rechazado"
            End If

            Dim ResultadoDOC As DTEBoxCliente.ResultadoServicio
            ResultadoDOC = ServicioDTE.EnviarRespuestaComercial(FE_Ambiente, Formatea_Rut(wRut, 0), Codigo_Fiscal(wTipoDoc), wNumDoc, wContactoNombre, wContactoTelefono, wContactoCorreo, wObservaciones, IIf(wModo = "AP", TipoRespuestaComercial.Aceptacion, TipoRespuestaComercial.Rechazo))
            If (ResultadoDOC.Estado = "0") Then
                Status_Comercial = ""
            Else
                Status_Comercial = Trim(ResultadoDOC.Descripcion)
            End If
        End If
    End Function

    Sub Imprimir_Documento_Proveedor(wRut As String, wTipoDoc As String, wNumDoc As Double)
        Dim wNombreArchivo As String
        Dim Grupo As GrupoBusqueda = GrupoBusqueda.Recibidos

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim ResultadoDOC As DTEBoxCliente.ResultadoRecuperarPdf
        ResultadoDOC = ServicioDTE.RecuperarPdf(FE_Ambiente, Grupo, Formatea_Rut(wRut, 0), Codigo_Fiscal(wTipoDoc), wNumDoc)

        If (ResultadoDOC.ResultadoServicio.Estado = DTEBoxCliente.EstadoResultado.Ok) Then
            Dim Documento_PDF As Byte()
            Documento_PDF = ResultadoDOC.Datos
            wNombreArchivo = Directorio_PDF + "Proveedor " & wRut & " " & wTipoDoc & " " & wNumDoc & ".PDF"
            System.IO.File.WriteAllBytes(wNombreArchivo, Documento_PDF)
            Abrir_Documento(wNombreArchivo)
        Else
            MsgError(ResultadoDOC.ResultadoServicio.Descripcion)
        End If

    End Sub

    Sub Estado_Documento_Proveedor(wRut As String, wTipoDoc As String, wNumDoc As Double)
        Dim wNombreArchivo As String
        Dim Grupo As GrupoBusqueda = GrupoBusqueda.Recibidos

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim ResultadoDOC As DTEBoxCliente.ResultadoRecuperarPdf
        ResultadoDOC = ServicioDTE.RecuperarPdf(FE_Ambiente, Grupo, Formatea_Rut(wRut, 0), Codigo_Fiscal(wTipoDoc), wNumDoc)

        If (ResultadoDOC.ResultadoServicio.Estado = DTEBoxCliente.EstadoResultado.Ok) Then
            Dim Documento_PDF As Byte()
            Documento_PDF = ResultadoDOC.Datos
            wNombreArchivo = Directorio_PDF + "Proveedor " & wRut & " " & wTipoDoc & " " & wNumDoc & ".PDF"
            System.IO.File.WriteAllBytes(wNombreArchivo, Documento_PDF)
        Else
            MsgError(ResultadoDOC.ResultadoServicio.Descripcion)
        End If

    End Sub


End Class

