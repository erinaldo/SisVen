Imports System
Imports System.IO
Imports System.Text
Imports DTEBoxCliente
Imports System.Threading
Imports System.Collections.Generic

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.BarcodeCodabar
Imports iTextSharp.text.pdf.BarcodePDF417
Imports Newtonsoft.Json

Module DTE
    Public FE_IP As String
    Public FE_EsElectronica As Boolean
    Public FE_Ambiente As String
    Public FE_Rut_Emisor As String
    Public FE_Razon_Social As String
    Public FE_Giro As String
    Public FE_Direccion As String
    Public FE_Comuna As String
    Public FE_Ciudad As String
    Public FE_Email As String
    Public FE_Ateco As Double
    Public FE_Llave As String
    Public FE_NResolucion As Double
    Public FE_FResolucion As Date
    Public FE_DTE As String
    Public FE_PDFColumnas As Integer
    Public FE_PDFNivel As Integer
    Public FE_PDFTruncado As Boolean
    Public FE_TipoDTE As Double
    Public FE_CodigoDTE As Double
    Public FE_CAF As String
    Public FE_FV As Boolean
    Public FE_GD As Boolean
    Public FE_NC As Boolean
    Public FE_FE As Boolean
    Public FE_ND As Boolean
    Public FE_BO As Boolean
    Public FE_BE As Boolean
    Public FE_FC As Boolean
    Public CAF As Byte()

    Public gPDF As String = "pdf"
    Public gXML As String = "xml"
    Public gJPG As String = "jpg"
    Public gTXT As String = "txt"

    Public MensajeDTE As String

    Public Directorio_CAF As String
    Public Directorio_TED As String
    Public Directorio_PDF As String
    Public Directorio_TXT As String

    Public Function Parametros_DTE(wLocal As Double) As Boolean
        Parametros_DTE = False
        Try
            Loc = SQL("Select * from Locales WHERE Local = " + wLocal.ToString)
            If Loc.RecordCount > 0 Then
                FE_IP = Loc.Fields("IP_DTE").Value.ToString.Trim
                FE_EsElectronica = Loc.Fields("FElectronica").Value
                FE_Rut_Emisor = Rut_DTE(Loc.Fields("RutLocal").Value)
                FE_Ambiente = IIf(Loc.Fields("Produccion").Value, DTEBoxCliente.Ambiente.Produccion, DTEBoxCliente.Ambiente.Homologacion)
                FE_Razon_Social = Formatea_Texto(Mid(Loc.Fields("RazonLocal").Value, 1, 100))
                FE_Giro = Formatea_Texto(Mid(Loc.Fields("GiroLocal").Value, 1, 80))
                FE_Direccion = Formatea_Texto(Mid(Loc.Fields("DirLocal").Value, 1, 60))
                FE_Comuna = Formatea_Texto(Saca_Comuna(Loc.Fields("Comuna").Value))
                FE_Ciudad = Formatea_Texto(Saca_Ciudad(Loc.Fields("Ciudad").Value))
                FE_Email = Loc.Fields("EmailLocal").Value.ToString.Trim
                FE_Ateco = Loc.Fields("Ateco").Value.ToString.Trim
                FE_Llave = Loc.Fields("Llave").Value.ToString.Trim
                FE_NResolucion = Loc.Fields("NResolucion").Value
                FE_FResolucion = Loc.Fields("FResolucion").Value
                FE_DTE = "http://" + FE_IP + "/api/Core.svc/Core"
                FE_FV = Loc.Fields("FV_Elect").Value
                FE_GD = Loc.Fields("GD_Elect").Value
                FE_NC = Loc.Fields("NC_Elect").Value
                FE_FE = Loc.Fields("FE_Elect").Value
                FE_ND = Loc.Fields("ND_Elect").Value
                FE_BO = Loc.Fields("BV_Elect").Value
                FE_BE = Loc.Fields("BE_Elect").Value
                FE_FC = Loc.Fields("FC_Elect").Value
                Directorio = Application.StartupPath
                Directorio_CAF = Application.StartupPath + "\CAF\"
                Directorio_TED = Application.StartupPath + "\TED\"
                Directorio_PDF = Application.StartupPath + "\PDF\"
                Directorio_TXT = Application.StartupPath + "\TXT\"
                Parametros_DTE = True
            Else
                FE_IP = "127.0.0.1"
                FE_EsElectronica = False
                FE_Ambiente = DTEBoxCliente.Ambiente.Homologacion
                FE_Rut_Emisor = "00.000.000.0"
                FE_Razon_Social = ""
                FE_Giro = ""
                FE_Direccion = ""
                FE_Comuna = ""
                FE_Ciudad = ""
                FE_Email = ""
                FE_Ateco = "0000"
                FE_Llave = ""
                FE_NResolucion = 0
                FE_FResolucion = "2000-01-01"
                FE_DTE = "http://" + FE_IP + "/api/Core.svc/Core"
                FE_FV = False
                FE_GD = False
                FE_NC = False
                FE_FE = False
                FE_ND = False
                FE_BO = False
                FE_BE = False
                FE_FC = False
                Directorio = Application.StartupPath
                Directorio_CAF = Application.StartupPath + "\CAF\"
                Directorio_TED = Application.StartupPath + "\TED\"
                Directorio_PDF = Application.StartupPath + "\PDF\"
                Directorio_TXT = Application.StartupPath + "\TXT\"
            End If
        Catch ex As Exception
            Parametros_DTE = False
        End Try
    End Function

    Public Function Emitir_DTE(wLocal As Double, wTipoDoc As String, wNumDoc As Double) As Boolean
        Dim wPrimeraLinea As String, wUnidad As String, wArticulo As String, Referencias As Double, wDescripcionLinea As String, wResto As String

        DoEvents()
        'Las Boletas de Venta tienen tratamiento especial
        If wTipoDoc = "BV" Then
            Respuesta = Emitir_Boleta(wLocal, wTipoDoc, wNumDoc)
            Emitir_DTE = Respuesta
            Return Respuesta
        End If

        Dim dte As DocumentoDTE.SiiDte.DTEDefType
        dte = New DocumentoDTE.SiiDte.DTEDefType()
        dte.DTE_Choice = New DocumentoDTE.SiiDte.DTE_Choice()

        'Documento
        dte.DTE_Choice.Documento = New DocumentoDTE.SiiDte.Documento()
        Dim doc As DocumentoDTE.SiiDte.Documento
        doc = dte.DTE_Choice.Documento

        'Documento/Encabezado
        doc.Encabezado = New DocumentoDTE.SiiDte.Encabezado()
        doc.Encabezado.IdDoc = New DocumentoDTE.SiiDte.IdDoc()

        'Recuperar Documento
        DocG = SQL("Select * from DocumentosG WHERE Local = " + wLocal.ToString + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + wNumDoc.ToString)
        If DocG.RecordCount = 0 Then
            Emitir_DTE = False
            Exit Function
        End If

        DocD = SQL("Select * from DocumentosD WHERE Local = " + wLocal.ToString + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + wNumDoc.ToString)
        If DocD.RecordCount = 0 Then
            Emitir_DTE = False
            Exit Function
        End If

        Cli = SQL("Select * from Clientes WHERE Cliente = " + DocG.Fields("Cliente").Value.ToString)
        If Cli.RecordCount = 0 Then
            Emitir_DTE = False
            Exit Function
        End If

        'Documento/Encabezado/IdDoc
        doc.Encabezado.IdDoc.TipoDTE = Codigo_DTE(wTipoDoc)
        doc.Encabezado.IdDoc.Folio = CInt(wNumDoc)
        doc.Encabezado.IdDoc.FchEmis = New LiquidTechnologies.Runtime.Net20.XmlDateTime(New DateTime(Year(DocG.Fields("Fecha").Value), Month(DocG.Fields("Fecha").Value), Microsoft.VisualBasic.DateAndTime.Day(DocG.Fields("Fecha").Value)))
        doc.Encabezado.IdDoc.FmaPago = IIf(DocG.Fields("FPago").Value.ToString.Trim.ToUpper = "E", DocumentoDTE.SiiDte.Enumerations.IdDoc_FmaPago.n1, DocumentoDTE.SiiDte.Enumerations.IdDoc_FmaPago.n2)

        If wTipoDoc = "GD" Then
            doc.Encabezado.IdDoc.TipoDespacho = DocumentoDTE.SiiDte.Enumerations.IdDoc_TipoDespacho.n1
            doc.Encabezado.IdDoc.IndTraslado = Codigo_Referencia(wTipoDoc, DocG.Fields("Motivo").Value.ToString.Trim)
            doc.Encabezado.IdDoc.IndServicio = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndServicio.n1
            doc.Encabezado.IdDoc.FchVenc = New LiquidTechnologies.Runtime.Net20.XmlDateTime(New DateTime(Year(DocG.Fields("Fecha").Value), Month(DocG.Fields("Fecha").Value), Microsoft.VisualBasic.DateAndTime.Day(DocG.Fields("Fecha").Value)))
        End If

        If wTipoDoc = "NC" Or wTipoDoc = "ND" Then
            doc.Encabezado.IdDoc.FmaPago = DocumentoDTE.SiiDte.Enumerations.IdDoc_FmaPago.n1
            doc.Encabezado.IdDoc.FchVenc = New LiquidTechnologies.Runtime.Net20.XmlDateTime(New DateTime(Year(DocG.Fields("FechaDocReferencia").Value), Month(DocG.Fields("FechaDocReferencia").Value), Microsoft.VisualBasic.DateAndTime.Day(DocG.Fields("FechaDocReferencia").Value)))
        End If


        'Documento/Encabezado/Emisor
        doc.Encabezado.Emisor = New DocumentoDTE.SiiDte.Emisor()
        doc.Encabezado.Emisor.RUTEmisor = FE_Rut_Emisor
        doc.Encabezado.Emisor.RznSoc = FE_Razon_Social
        doc.Encabezado.Emisor.GiroEmis = FE_Giro
        doc.Encabezado.Emisor.Acteco.Add(CInt(FE_Ateco))
        doc.Encabezado.Emisor.DirOrigen = FE_Direccion
        doc.Encabezado.Emisor.CmnaOrigen = FE_Comuna
        doc.Encabezado.Emisor.CiudadOrigen = FE_Ciudad
        doc.Encabezado.Emisor.CorreoEmisor = FE_Email

        'Documento/Encabezado/Receptor
        doc.Encabezado.Receptor = New DocumentoDTE.SiiDte.Receptor()
        doc.Encabezado.Receptor.RUTRecep = Rut_DTE(DocG.Fields("Rut").Value)
        doc.Encabezado.Receptor.RznSocRecep = Formatea_Texto(Mid(Cli.Fields("Nombre").Value, 1, 100))
        doc.Encabezado.Receptor.CdgIntRecep = Cli.Fields("Cliente").Value
        doc.Encabezado.Receptor.GiroRecep = Formatea_Texto(Mid(Cli.Fields("Giro").Value, 1, 40))
        doc.Encabezado.Receptor.Contacto = Formatea_Texto(Mid(Cli.Fields("Contacto").Value, 1, 80))
        doc.Encabezado.Receptor.DirRecep = Formatea_Texto(Mid(Cli.Fields("Direccion").Value, 1, 70))
        doc.Encabezado.Receptor.CmnaRecep = Formatea_Texto(Mid(Saca_Comuna(Cli.Fields("Comuna").Value), 1, 20))
        doc.Encabezado.Receptor.CiudadRecep = Formatea_Texto(Mid(Saca_Ciudad(Cli.Fields("Comuna").Value), 1, 20))
        doc.Encabezado.Receptor.CorreoRecep = Cli.Fields("Email").Value.ToString.Trim

        'Documento/Descuentos Generales
        If DocG.Fields("Descuento").Value > 0 Then
            Dim dscRcgGlobal As DocumentoDTE.SiiDte.DscRcgGlobal
            dscRcgGlobal = New DocumentoDTE.SiiDte.DscRcgGlobal()
            dscRcgGlobal.NroLinDR = 1
            dscRcgGlobal.TpoMov = DocumentoDTE.SiiDte.Enumerations.DscRcgGlobal_TpoMov.D
            dscRcgGlobal.TpoValor = DocumentoDTE.SiiDte.Enumerations.DineroPorcentajeType.Dollar  'Dollar = Descuento en Pesos,  Percent=Descuento por porcentaje
            dscRcgGlobal.ValorDR = DocG.Fields("Descuento").Value
            doc.DscRcgGlobal.Add(dscRcgGlobal)
        End If

        'Documento/Encabezado/Totales
        doc.Encabezado.Totales = New DocumentoDTE.SiiDte.Totales()
        doc.Encabezado.Totales.MntTotal = CInt(DocG.Fields("Total").Value)
        If wTipoDoc = "FE" Or DocG.Fields("TipoDocReferencia").Value = "FE" Then
            doc.Encabezado.Totales.MntExe = CInt(DocG.Fields("Neto").Value)
        Else
            doc.Encabezado.Totales.MntNeto = CInt(DocG.Fields("Neto").Value)
            doc.Encabezado.Totales.TasaIVA = CInt(gIVA)
            doc.Encabezado.Totales.IVA = CInt(DocG.Fields("IVA").Value)
        End If


        'Documento/Detalle
        Dim det As DocumentoDTE.SiiDte.Detalle

        Lineas = 1
        DocD.MoveFirst()
        wPrimeraLinea = "ARTICULO"
        While Not DocD.EOF
            wArticulo = "" : wDescripcionLinea = "" : wResto = ""

            det = New DocumentoDTE.SiiDte.Detalle()

            wUnidad = "UN"
            Art = SQL("Select * from Articulos WHERE Articulo = '" + DocD.Fields("Articulo").Value.ToString + "'")
            If Art.RecordCount > 0 Then
                wUnidad = Trim(Art.Fields("Unidad").Value.ToString.Trim)
            End If

            'Si hay Glosa, usar glosa en vez de la descripción del artículo
            wArticulo = Art.Fields("Descripcion").Value
            wDescripcionLinea = Art.Fields("Descripcion").Value
            If Not IsDBNull(DocD.Fields("Glosa").Value) Then
                If Trim(DocD.Fields("Glosa").Value) <> "" Then
                    wArticulo = Trim(Mid(DocD.Fields("Glosa").Value, 1, 70))
                    wDescripcionLinea = Art.Fields("Descripcion").Value
                End If
            End If

            If wPrimeraLinea = "ARTICULO" Then
                wPrimeraLinea = Trim(Mid(Formatea_Texto(wArticulo), 1, 70))
                wArticulo = wPrimeraLinea
            End If

            det.NroLinDet = Lineas
            If Lineas = 1 Then
                det.NmbItem = wPrimeraLinea
            Else
                det.NmbItem = wArticulo
            End If
            wResto = Mid(wDescripcionLinea, 71, 1000)
            If Trim(wResto) <> "" Then
                det.DscItem = wResto
            End If

            det.MontoItem = CInt(Math.Round(DocD.Fields("Cantidad").Value * DocD.Fields("Neto").Value, 0))
            det.QtyItem = DocD.Fields("Cantidad").Value
            det.UnmdItem = wUnidad
            If DocD.Fields("Neto").Value > 0 Then
                det.PrcItem = DocD.Fields("Neto").Value
            End If

            'Si es NC o ND y el Documento afecto es FE, debe tener este item especial de exento
            If DocG.Fields("TipoDocReferencia").Value = "FE" Then
                det.IndExe = 0   'En el DTE les llega como un 1
            End If

            'Para agregar codigo de producto 
            ''Documento/Detalle/CdgItem
            'Dim cdgItem As DocumentoDTE.SiiDte.CdgItem
            'cdgItem = New DocumentoDTE.SiiDte.CdgItem()
            'cdgItem.TpoCodigo = "INT"  'Intenro
            'cdgItem.VlrCodigo = "BUR-BURSTA"
            'det.CdgItem.Add(cdgItem)

            doc.Detalle.Add(det)
            DocD.MoveNext()
            Lineas += 1
        End While


        'Documento/Referencia
        If wTipoDoc <> "BV" Then
            If (DocG.Fields("TipoDocReferencia").Value.ToString.Trim <> "" And (wTipoDoc = "NC" Or wTipoDoc = "ND")) Or DocG.Fields("OC").Value.ToString.Trim <> "" Then
                Dim reference As DocumentoDTE.SiiDte.Referencia
                reference = New DocumentoDTE.SiiDte.Referencia()

                Referencias = 1
                If wTipoDoc = "NC" Or wTipoDoc = "ND" Then
                    reference.NroLinRef = CInt(Referencias)
                    reference.TpoDocRef = Codigo_SII(DocG.Fields("TipoDocReferencia").Value.ToString.Trim)
                    reference.FolioRef = CInt(DocG.Fields("NumDocReferencia").Value)
                    reference.FchRef = New LiquidTechnologies.Runtime.Net20.XmlDateTime(New DateTime(Year(DocG.Fields("FechaDocReferencia").Value), Month(DocG.Fields("FechaDocReferencia").Value), Microsoft.VisualBasic.DateAndTime.Day(DocG.Fields("FechaDocReferencia").Value)))
                    reference.CodRef = Codigo_Referencia(wTipoDoc, DocG.Fields("Motivo").Value.ToString.Trim)
                    reference.RazonRef = Formatea_Texto(Descripcion_Motivo(wTipoDoc, DocG.Fields("Motivo").Value.ToString.Trim))
                    doc.Referencia.Add(reference)
                    Referencias = Referencias + 1
                End If
                If wTipoDoc <> "BV" Then
                    If DocG.Fields("OC").Value.ToString.Trim <> "" And DocG.Fields("OC").Value.ToString.Trim <> "0" And Referencias = 1 Then
                        reference.NroLinRef = CInt(Referencias)
                        reference.TpoDocRef = Codigo_SII("OC")
                        reference.FolioRef = Trim(DocG.Fields("OC").Value)
                        reference.FchRef = New LiquidTechnologies.Runtime.Net20.XmlDateTime(New DateTime(Year(DocG.Fields("Fecha").Value), Month(DocG.Fields("Fecha").Value), Microsoft.VisualBasic.DateAndTime.Day(DocG.Fields("Fecha").Value)))
                        'reference.RazonRef = Formatea_Texto("ORDEN DE COMPRA")
                        doc.Referencia.Add(reference)
                        Referencias = Referencias + 1
                    End If
                End If
            End If
        End If

        'Llamada al Servicio
        MensajeDTE = ""
        Dim AmbienteDTE As DTEBoxCliente.Ambiente
        AmbienteDTE = FE_Ambiente
        Dim FechaResolucion As Date
        FechaResolucion = New DateTime(FE_FResolucion.Year, FE_FResolucion.Month, FE_FResolucion.Day)
        Dim NumeroResolucion As Integer
        NumeroResolucion = FE_NResolucion
        Dim TipoPDF417 As DTEBoxCliente.TipoPdf417
        TipoPDF417 = DTEBoxCliente.TipoPdf417.Fuente

        Dim GenerarFolio As Boolean
        GenerarFolio = False   'Es para que el DTE genere un correlativo automático o no


        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim ResultadoDTE As DTEBoxCliente.ResultadoEnvioDte

        'Try
        '    Dim json = JsonConvert.SerializeObject(dte, Formatting.Indented)
        '    SaveJson(json, "DTE_" & wTipoDoc & " " & wNumDoc)
        'Catch ex As Exception
        '    'No se pudo grabar el JSON
        'End Try

        ResultadoDTE = ServicioDTE.EnviarDocumento(dte, AmbienteDTE, FechaResolucion, NumeroResolucion, TipoPDF417, GenerarFolio)

        'Procesar Resultado del Servicio
        If (ResultadoDTE.ResultadoServicio.Estado = DTEBoxCliente.EstadoResultado.Ok) Then
            'Usar el data que viene en el resultado de la llamada
            Dim TED As String
            TED = ResultadoDTE.TED 'Xml que representa el elemento TED generado
            'Si tipoPdf417 = DTEBoxCliente.TipoPdf417.Fuente viene el código, 
            ' si es DTEBoxCliente.TipoPdf417.Grafico , Entonces arreglo de bytes codigificado en base64, 
            ' usar método result.Pdf417ComoArregloBytes()
            Dim PDF417 As String
            PDF417 = ResultadoDTE.Pdf417

            If DocG.Fields("Status_DTE").Value <> 1 Then
                'Grabar Cambio de Estado
                DocG.Fields("DTE").Value = True
                DocG.Fields("Status_DTE").Value = 1
                Try
                    'DocG.Fields("Firma").Value = Leer_JPG(Directorio_TED + wTipoDoc + "(" + Llena0(wLocal, 2) + ")" + Llena0(wNumDoc, 8) + ".jpg")
                    DocG.Fields("Firma").Value = Leer_JPG(Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumDoc, DocG("Cliente").Value))
                Catch ex As Exception
                    MsgError("Error al Leer Firma:" + vbCrLf + Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumDoc, DocG("Cliente").Value))
                End Try
                DocG.Fields("TED").Value = ResultadoDTE.TED
                DocG.Update()
            End If
            Emitir_DTE = True
        Else
            MensajeDTE = ResultadoDTE.ResultadoServicio.Descripcion

            'Grabar Cambio de Status
            If DocG.Fields("Status_DTE").Value = 0 Then
                'Grabar Cambio de Estado
                DocG.Fields("Status_DTE").Value = 2
                DocG.Update()
            End If

            Emitir_DTE = False
            MsgError(MensajeDTE)
        End If
    End Function

    Function Emitir_Boleta(wLocal As Double, wTipoDoc As String, wNumDoc As Double) As Boolean
        Dim wPrimeraLinea As String, wUnidad As String, wArticulo As String

        'MODULO SIMILAR A LA EMICION DE FACTURAS PERO ES ESPECIFICO PARA BOLETAS YA QUE TIENN TRATAMIENTO DISTINTO

        If wTipoDoc <> "BV" Then
            'No correspode módulo
            Return False
        End If

        Dim Boleta As DocumentoBoleta.SiiDte.BOLETADefType
        Boleta = New DocumentoBoleta.SiiDte.BOLETADefType()

        'Boleta/Documento
        Boleta.Documento = New DocumentoBoleta.SiiDte.Documento()
        Dim doc As DocumentoBoleta.SiiDte.Documento
        doc = Boleta.Documento

        'Boleta/Documento/Encabezado
        doc.Encabezado = New DocumentoBoleta.SiiDte.Encabezado()
        doc.Encabezado.IdDoc = New DocumentoBoleta.SiiDte.IdDoc()

        'Boleta/Recuperar Documento
        DocG = SQL("Select * from DocumentosG WHERE Local = " + wLocal.ToString + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + wNumDoc.ToString)
        If DocG.RecordCount = 0 Then
            Emitir_Boleta = False
            Exit Function
        End If

        DocD = SQL("Select * from DocumentosD WHERE Local = " + wLocal.ToString + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + wNumDoc.ToString)
        If DocD.RecordCount = 0 Then
            Emitir_Boleta = False
            Exit Function
        End If

        Cli = SQL("Select * from Clientes WHERE Cliente = " + DocG.Fields("Cliente").Value.ToString)
        If Cli.RecordCount = 0 Then
            Emitir_Boleta = False
            Exit Function
        End If

        'Documento/Encabezado/IdDoc
        doc.Encabezado.IdDoc.TipoDTE = DocumentoBoleta.SiiDte.Enumerations.DTEType.n39
        doc.Encabezado.IdDoc.Folio = CInt(wNumDoc)
        doc.Encabezado.IdDoc.FchEmis = New LiquidTechnologies.Runtime.Net20.XmlDateTime(New DateTime(Year(DocG.Fields("Fecha").Value), Month(DocG.Fields("Fecha").Value), Microsoft.VisualBasic.DateAndTime.Day(DocG.Fields("Fecha").Value)))
        doc.Encabezado.IdDoc.IndServicio = DocumentoBoleta.SiiDte.Enumerations.IdDoc_IndServicio.n1

        'Boleta/Documento/Encabezado/Emisor
        doc.Encabezado.Emisor = New DocumentoBoleta.SiiDte.Emisor()
        doc.Encabezado.Emisor.RUTEmisor = FE_Rut_Emisor
        doc.Encabezado.Emisor.RznSocEmisor = FE_Razon_Social
        doc.Encabezado.Emisor.GiroEmisor = FE_Giro
        doc.Encabezado.Emisor.DirOrigen = FE_Direccion
        doc.Encabezado.Emisor.CmnaOrigen = FE_Comuna
        doc.Encabezado.Emisor.CiudadOrigen = FE_Ciudad

        'Boleta/Documento/Encabezado/Receptor
        doc.Encabezado.Receptor = New DocumentoBoleta.SiiDte.Receptor()
        doc.Encabezado.Receptor.RUTRecep = Rut_DTE(DocG.Fields("Rut").Value)
        doc.Encabezado.Receptor.RznSocRecep = Formatea_Texto(Mid(Cli.Fields("Nombre").Value, 1, 100))
        doc.Encabezado.Receptor.CdgIntRecep = Cli.Fields("Cliente").Value
        doc.Encabezado.Receptor.Contacto = Formatea_Texto(Mid(Cli.Fields("Contacto").Value, 1, 80))
        doc.Encabezado.Receptor.DirRecep = Formatea_Texto(Mid(Cli.Fields("Direccion").Value, 1, 70))
        doc.Encabezado.Receptor.CmnaRecep = Formatea_Texto(Mid(Saca_Comuna(Cli.Fields("Comuna").Value), 1, 20))
        doc.Encabezado.Receptor.CiudadRecep = Formatea_Texto(Mid(Saca_Ciudad(Cli.Fields("Comuna").Value), 1, 20))

        'Boleta/Documento/Encabezado/Totales
        doc.Encabezado.Totales = New DocumentoBoleta.SiiDte.Totales()
        doc.Encabezado.Totales.MntTotal = CInt(DocG.Fields("Total").Value)


        'Documento/Detalle
        Dim det As DocumentoBoleta.SiiDte.Detalle

        Lineas = 1
        DocD.MoveFirst()
        wPrimeraLinea = "ARTICULO"
        While Not DocD.EOF
            det = New DocumentoBoleta.SiiDte.Detalle()

            wUnidad = "UN"
            Art = SQL("Select * from Articulos WHERE Articulo = '" + DocD.Fields("Articulo").Value.ToString + "'")
            If Art.RecordCount > 0 Then
                wUnidad = Trim(Art.Fields("Unidad").Value.ToString.Trim)
            End If

            If Trim(Mid(DocD.Fields("Glosa").Value, 1, 80)) = "" Then
                wArticulo = Trim(Art.Fields("Descripcion").Value)
            Else
                wArticulo = Trim(Mid(DocD.Fields("Glosa").Value, 1, 80))
            End If
            If wPrimeraLinea = "ARTICULO" Then
                wPrimeraLinea = Trim(Mid(Formatea_Texto(wArticulo), 1, 80))
                wArticulo = wPrimeraLinea
            End If

            det.NroLinDet = Lineas

            If Lineas = 1 Then
                det.NmbItem = wPrimeraLinea
            Else
                det.NmbItem = wArticulo
            End If

            det.MontoItem = CInt(Math.Round(DocD.Fields("Cantidad").Value * DocD.Fields("Neto").Value * (1 + (gIVA / 100)), 0))
            det.DscItem = wArticulo
            det.QtyItem = DocD.Fields("Cantidad").Value
            det.UnmdItem = wUnidad
            If DocD.Fields("Neto").Value > 0 Then
                det.PrcItem = CInt(Math.Round(DocD.Fields("Neto").Value * (1 + (gIVA / 100)), 0))
            End If

            'Para agregar codigo de producto 
            ''Documento/Detalle/CdgItem
            'Dim cdgItem As DocumentoDTE.SiiDte.CdgItem
            'cdgItem = New DocumentoDTE.SiiDte.CdgItem()
            'cdgItem.TpoCodigo = "INT"  'Intenro
            'cdgItem.VlrCodigo = "BUR-BURSTA"
            'det.CdgItem.Add(cdgItem)

            doc.Detalle.Add(det)
            DocD.MoveNext()
            Lineas += 1
        End While


        'Llamada al Servicio
        MensajeDTE = ""
        Dim AmbienteDTE As DTEBoxCliente.Ambiente
        AmbienteDTE = FE_Ambiente
        Dim FechaResolucion As Date
        FechaResolucion = New DateTime(FE_FResolucion.Year, FE_FResolucion.Month, FE_FResolucion.Day)
        Dim NumeroResolucion As Integer
        NumeroResolucion = FE_NResolucion
        Dim TipoPDF417 As DTEBoxCliente.TipoPdf417
        TipoPDF417 = DTEBoxCliente.TipoPdf417.Fuente

        Dim GenerarFolio As Boolean
        GenerarFolio = False   'Es para que el DTE genere correlativo automatico o no

        Dim apiURL As String
        Dim apiAuth As String
        apiURL = FE_DTE
        apiAuth = FE_Llave

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(apiURL, apiAuth)

        Dim ResultadoDTE As DTEBoxCliente.ResultadoEnvioBoleta
        ResultadoDTE = ServicioDTE.EnviarDocumento(Boleta, AmbienteDTE, FechaResolucion, NumeroResolucion, TipoPDF417, GenerarFolio)

        'Procesar Resultado del Servicio
        If (ResultadoDTE.ResultadoServicio.Estado = DTEBoxCliente.EstadoResultado.Ok) Then
            'Usar el data que viene en el resultado de la llamada
            Dim TED As String
            TED = ResultadoDTE.TED 'Xml que representa el elemento TED generado
            'Si tipoPdf417 = DTEBoxCliente.TipoPdf417.Fuente viene el código, 
            ' si es DTEBoxCliente.TipoPdf417.Grafico , Entonces arreglo de bytes codigificado en base64, 
            ' usar método result.Pdf417ComoArregloBytes()
            Dim PDF417 As String
            PDF417 = ResultadoDTE.Pdf417

            If DocG.Fields("Status_DTE").Value <> 1 Then
                'Grabar Cambio de Estado
                DocG.Fields("Status_DTE").Value = 1
                'DocG.Fields("Firma").Value = Leer_JPG(Directorio_TED + wTipoDoc + "(" + Llena0(wLocal, 2) + ")" + Llena0(wNumDoc, 8) + ".jpg")
                DocG.Fields("Firma").Value = Leer_JPG(Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumDoc, DocG("Cliente").Value))
                DocG.Fields("TED").Value = ResultadoDTE.TED
                DocG.Update()
            End If

            Emitir_Boleta = True

        Else
            MensajeDTE = ResultadoDTE.ResultadoServicio.Descripcion

            'Grabar Cambio de Status
            If DocG.Fields("Status_DTE").Value = 0 Then
                'Grabar Cambio de Estado
                DocG.Fields("Status_DTE").Value = 2
                DocG.Update()
            End If

            Emitir_Boleta = False
            MsgError(MensajeDTE)
        End If

    End Function

    Public Function Rut_DTE(pRut As String) As String
        Rut_DTE = UCase(Trim(pRut))
        Rut_DTE = Replace(Rut_DTE, "_", "").Replace(".", "")
        If Mid(Rut_DTE, 1, 1) = "0" Then Rut_DTE = Trim(Mid(Rut_DTE, 2, 12))
    End Function

    Public Function Formatea_Texto(wTexto As String, Optional wLargo As Integer = 0) As String
        Dim Car As String, i As Integer, Texto_Resultado As String

        Formatea_Texto = UCase(Trim(wTexto))
        Formatea_Texto = Replace(Formatea_Texto, "Á", "A")
        Formatea_Texto = Replace(Formatea_Texto, "Ä", "A")
        Formatea_Texto = Replace(Formatea_Texto, "É", "E")
        Formatea_Texto = Replace(Formatea_Texto, "Í", "I")
        Formatea_Texto = Replace(Formatea_Texto, "Ó", "O")
        Formatea_Texto = Replace(Formatea_Texto, "Ö", "O")
        Formatea_Texto = Replace(Formatea_Texto, "Ú", "U")
        Formatea_Texto = Replace(Formatea_Texto, "Ü", "U")
        Formatea_Texto = Replace(Formatea_Texto, "Ñ", "N")
        Formatea_Texto = Replace(Formatea_Texto, "²", "2")
        Formatea_Texto = Replace(Formatea_Texto, "º", "")
        Formatea_Texto = Replace(Formatea_Texto, "°", "")
        Formatea_Texto = Replace(Formatea_Texto, "°", "")
        Formatea_Texto = Replace(Formatea_Texto, "°", "")
        Formatea_Texto = Replace(Formatea_Texto, "º", "")
        Formatea_Texto = Replace(Formatea_Texto, "ª", "")
        Formatea_Texto = Replace(Formatea_Texto, "ª", "")
        Formatea_Texto = Replace(Formatea_Texto, "%", "")
        Formatea_Texto = Replace(Formatea_Texto, "$", "")
        Formatea_Texto = Replace(Formatea_Texto, "&", "")
        Formatea_Texto = Replace(Formatea_Texto, "*", "")
        Formatea_Texto = Replace(Formatea_Texto, "^", "")
        Formatea_Texto = Replace(Formatea_Texto, "~", "")
        Formatea_Texto = Replace(Formatea_Texto, "#", "")
        Formatea_Texto = Replace(Formatea_Texto, Chr(34), "")
        Formatea_Texto = Replace(Formatea_Texto, Chr(39), "")
        Formatea_Texto = Replace(Formatea_Texto, Chr(96), "")
        Formatea_Texto = Replace(Formatea_Texto, Chr(176), "")
        Formatea_Texto = Replace(Formatea_Texto, Chr(186), "")

        Texto_Resultado = ""
        'Sacar los caracteres no imprimibles despues de la limpieza de letras
        For i = 1 To Len(Formatea_Texto)
            Car = Mid(Formatea_Texto, i, 1)
            If Asc(Car) < 32 Or Asc(Car) > 122 Then
                'Eliminar si no es Imprimible
                Car = ""
            End If

            Car = Cambia_Car(Car, 34)   '"
            Car = Cambia_Car(Car, 35)   '#
            Car = Cambia_Car(Car, 39)   ''
            Car = Cambia_Car(Car, 58)   ':
            Car = Cambia_Car(Car, 59)   ';
            Car = Cambia_Car(Car, 64)   '@
            Car = Cambia_Car(Car, 94)   '^
            Car = Cambia_Car(Car, 96)   '´
            Car = Cambia_Car(Car, 60)   '<
            Car = Cambia_Car(Car, 61)   '=
            Car = Cambia_Car(Car, 62)   '>

            Texto_Resultado = Texto_Resultado + Car
        Next i

        Formatea_Texto = Texto_Resultado

        If Trim(Formatea_Texto) = "" Then
            Formatea_Texto = ""
        End If

        If wLargo > 0 Then
            Formatea_Texto = Mid(Formatea_Texto + Space(wLargo), 1, wLargo)
        End If

    End Function

    Public Function Cambia_Car(wCar As String, wAsc As Integer) As String
        Cambia_Car = wCar
        If Trim(wCar) <> "" Then
            If Asc(wCar) = wAsc Then
                Cambia_Car = ""
            End If
        End If
    End Function

    Public Function Codigo_DTE(wTipoDoc As String) As Integer
        Codigo_DTE = 0
        If wTipoDoc = "FV" Then
            Codigo_DTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n33
        End If
        If wTipoDoc = "GD" Then
            Codigo_DTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n52
        End If
        If wTipoDoc = "NC" Then
            Codigo_DTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n61
        End If
        If wTipoDoc = "ND" Then
            Codigo_DTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n56
        End If
        If wTipoDoc = "FE" Then
            Codigo_DTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n34
        End If
        If wTipoDoc = "BV" Then
            Codigo_DTE = 39
        End If
        If wTipoDoc = "FC" Then
            Codigo_DTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n46
        End If
    End Function

    Public Function Codigo_Fiscal(wTipoDoc As String) As Integer
        Codigo_Fiscal = 0
        If wTipoDoc = "FV" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_33
        End If
        If wTipoDoc = "GD" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_52
        End If
        If wTipoDoc = "NC" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_61
        End If
        If wTipoDoc = "ND" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_56
        End If
        If wTipoDoc = "FE" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_34
        End If
        If wTipoDoc = "BV" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_39
        End If
        If wTipoDoc = "FC" Then
            Codigo_Fiscal = DTEBoxCliente.TipoDocumento.TIPO_46
        End If
    End Function

    Public Function Codigo_SII(wTipoDoc As String) As String
        Codigo_SII = "0"
        wTipoDoc = Trim(UCase(wTipoDoc))
        TDo = SQL("Select Cod_SII from TipoDoc WHERE TipoDoc = '" + wTipoDoc + "'")
        If TDo.RecordCount > 0 Then
            Codigo_SII = TDo.Fields("Cod_SII").Value
        End If
    End Function

    Public Function Generar_TED(wLocal As Integer, wTipoDoc As String, wNumDoc As Double, wFecha As Date, wRut As String, wNombre As String, wMonto As Double, wPrimeraLinea As String) As Boolean
        Generar_TED = False

        Try
            'Datos del TED
            Dim tipoDocumento As TipoDocumento
            tipoDocumento = Nothing
            Select Case wTipoDoc
                Case "FV"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.FacturaElectronica
                Case "GD"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.GuiaDespachoElectronica
                Case "NC"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.NotaCreditoElectronica
                Case "ND"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.NotaDebitoElectronica
                Case "BV"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.BoletaElectronica
                Case "FC"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.FacturaCompraElectronica
                Case "FE"
                    tipoDocumento = GDEGateway.Timbre.TipoDocumento.FacturaElectronicaNoAfectaOExenta
                Case Else
                    tipoDocumento = Nothing
            End Select

            'Leer CAF
            CAF = Leer_CAF(wLocal, wTipoDoc, wNumDoc, wFecha)

            'Datos del PDF417
            Dim pdfTipo As GDEGateway.Timbre.TipoPdf417
            pdfTipo = GDEGateway.Timbre.TipoPdf417.Grafico
            Dim pdfColumnas As Integer
            pdfColumnas = 13
            Dim pdfNivelCorreccion As Integer
            pdfNivelCorreccion = 5
            Dim pdfTruncado As Boolean
            pdfTruncado = False
            Dim pdfFormato As GDEGateway.Timbre.FormatoPdf417
            pdfFormato = GDEGateway.Timbre.FormatoPdf417.Jpeg
            Dim directorioTemporal As String
            directorioTemporal = Directorio_TED
            'V1
            Dim tedGenerado As GDEGateway.Timbre.TED
            tedGenerado = GDEGateway.Timbre.Generador.GenerarTimbre(
            FE_Rut_Emisor,
                tipoDocumento,
                wFecha,
                wNumDoc,
                wRut,
                wNombre,
                wMonto,
                wPrimeraLinea,
                CAF,
                pdfTipo,
                pdfColumnas,
                pdfNivelCorreccion,
                pdfTruncado,
                pdfFormato,
                directorioTemporal)

            'v2
            'Dim tedGenerado As GDEGateway.Timbre.TED
            'tedGenerado = GDEGateway.Timbre.Generador.GenerarTimbre(
            'FE_Rut_Emisor,
            '    tipoDocumento,
            '    wFecha,
            '    wNumDoc,
            '    wRut,
            '    wNombre,
            '    wMonto,
            '    wPrimeraLinea,
            '    CAF)

            'Valor
            Dim tedValor As String
            tedValor = tedGenerado.Valor

            'Guardar el pdf417 en disco como imagen
            Dim pdf417CaminoFichero As String
            pdf417CaminoFichero = Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumDoc, 0)
            System.IO.File.WriteAllBytes(pdf417CaminoFichero, tedGenerado.CodigoComoBytes())


            'Dim BarCode As New BarcodePDF417
            'BarCode.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO
            'BarCode.ErrorLevel = 5
            'BarCode.SetText(tedValor)
            'Dim Escala = 1

            'Dim BitMap As New System.Drawing.Bitmap(BarCode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
            'Dim imgAncho As Integer = CType(BitMap.Width * Escala, Integer)
            'Dim imgAlto As Integer = CType(BitMap.Height * Escala, Integer)

            'Dim ImagenPDF417 As New Bitmap(imgAncho, imgAlto)
            'Dim Imagen As Graphics = Graphics.FromImage(ImagenPDF417)
            'Imagen.ScaleTransform(Escala, Escala)
            'Imagen.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'Imagen.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            'Imagen.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            'Imagen.DrawImage(BitMap, New Point(0, 0))

            'Dim ImagenResultado As New System.Drawing.Bitmap(ImagenPDF417)
            'ImagenResultado.Save(Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumDoc, 0))

            'Guardar el XML en disco como archivo
            Dim ArchivoXML As String
            ArchivoXML = Archivo_Fiscal(gXML, wLocal, wTipoDoc, wNumDoc, 0)
            System.IO.File.WriteAllText(ArchivoXML, tedValor)
            Generar_TED = True

        Catch ex As Exception
            MsgError(ex.Message.ToString.Trim)
            Return False
        End Try

    End Function

    Public Function Leer_CAF(wLocal As Double, wTipoDoc As String, wNumero As Double, wFecha As Date) As Byte()
        Dim wCorr As Double = 0
        'Leer CAF
        Try
            wCorr = Correlativo(0, wLocal, wTipoDoc, wFecha, 0, False)
            Leer_CAF = Encoding.ASCII.GetBytes(Cor("CAF").Text)
        Catch ex As Exception
            MsgError("Error al recuperar CAF")
            Return Nothing
        End Try

        ''Anteriormente se cargaba el CAF desde la ruta del directorio
        'Try
        'CAF = System.IO.File.ReadAllBytes(Directorio_CAF + wTipoDoc + Llena0(wLocal, 2) + ".xml")
        'Catch ex As Exception
        'MsgError("Error al recuperar CAF")
        'Return False
        'End Try
    End Function

    Public Function Leer_JPG(pArchivo As String) As Byte()
        Leer_JPG = Nothing
        Try
            Dim wArchivo As New FileStream(Trim(pArchivo), FileMode.Open, FileAccess.Read)
            Dim Lectura As New BinaryReader(wArchivo)
            Dim Imagen(wArchivo.Length) As Byte
            Lectura.Read(Imagen, 0, wArchivo.Length)
            wArchivo.Close()
            Leer_JPG = Imagen
        Catch ex As Exception
            'Mensaje(ex.Message.ToString)
        End Try
    End Function
    Public Function Leer_TED(pArchivo As String) As String
        Leer_TED = ""
        Try
            Dim wArchivo As New System.IO.StreamReader(Trim(pArchivo))
            Leer_TED = wArchivo.ReadToEnd()
            wArchivo.Close()
        Catch ex As Exception
            'Mensaje(ex.Message.ToString)
        End Try
    End Function

    Public Function Es_Electronico(wTipoDoc As String) As Boolean
        Es_Electronico = False
        If FE_EsElectronica Then
            If FE_FV And wTipoDoc = "FV" Then Es_Electronico = True
            If FE_GD And wTipoDoc = "GD" Then Es_Electronico = True
            If FE_NC And wTipoDoc = "NC" Then Es_Electronico = True
            If FE_FE And wTipoDoc = "FE" Then Es_Electronico = True
            If FE_ND And wTipoDoc = "ND" Then Es_Electronico = True
            If FE_BO And wTipoDoc = "BV" Then Es_Electronico = True
            If FE_BE And wTipoDoc = "BE" Then Es_Electronico = True
            If FE_FC And wTipoDoc = "FC" Then Es_Electronico = True
        End If
    End Function

    Public Function Codigo_Referencia(wTipoDoc As String, wMotivo As String) As Integer
        wMotivo = UCase(Trim(wMotivo))
        Codigo_Referencia = 0
        If wTipoDoc = "NC" Or wTipoDoc = "ND" Then
            If wMotivo = "A" Then
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.Referencia_CodRef.n1
            End If
            If wMotivo = "D" Then
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.Referencia_CodRef.n2
            End If
            If wMotivo = "O" Or wMotivo = "P" Then
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.Referencia_CodRef.n3
            End If
        End If

        If wTipoDoc = "GD" Then
            If Trim(UCase(wMotivo)) = "O" Then  'DEVOLUCION
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndTraslado.n7
            End If
            If Trim(UCase(wMotivo)) = "S" Then  'TRANSITO
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndTraslado.n5
            End If
            If Trim(UCase(wMotivo)) = "M" Then  'MERMA
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndTraslado.n6
            End If
            If Trim(UCase(wMotivo)) = "V" Then  'VENTA
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndTraslado.n1
            End If
            If Trim(UCase(wMotivo)) = "T" Then 'TRASPASO
                Codigo_Referencia = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndTraslado.n5
            End If
        End If
    End Function
    Public Function Consultar_DTE(pConsulta As String, pRut As String, pTipoDoc As String, pNumero As Double) As String
        Dim RutDF As String, Intentos As Integer
        'Consultar el Estado de un Documento electrónico
        'pConsulta = 1  -- Consultar Estado
        'pConsulta = 2  -- Consultar ID Seguimiento SII
        'pConsulta = 3  -- Consultar Comentario

        FE_TipoDTE = Codigo_Fiscal(pTipoDoc)

        On Error GoTo ReIntentos
        Intentos = 0
ReIntentos:
        Intentos = Intentos + 1
        If Intentos > 3 Then
            On Error GoTo 0
            Consultar_DTE = 7
            Exit Function
        End If

        Dim apiURL As String
        Dim apiAuth As String
        apiURL = FE_DTE
        apiAuth = FE_Llave

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(apiURL, apiAuth)

        Dim FE_Grupo As DTEBoxCliente.GrupoBusqueda
        FE_Grupo = DTEBoxCliente.GrupoBusqueda.Emitidos

        Dim FE_Resultado As DTEBoxCliente.ResultadoEstadoFiscal
        FE_Resultado = ServicioDTE.EstadoFiscal(FE_Ambiente, FE_Grupo, FE_Rut_Emisor, FE_TipoDTE, pNumero)
        On Error GoTo 0

        'Resultado de la operación, 0 exitosa, diferente de cero es error al cunsultar DTE (no es error del documento)
        If (FE_Resultado.ResultadoServicio.Estado = "0") Then
            If pConsulta = 1 Then
                Consultar_DTE = Num(FE_Resultado.Estado) + ": " + TiposEstado_DTE(FE_Resultado.Estado)
            End If

            If pConsulta = 2 Then
                'TrackId que entregó el SII con la autorización del documento.
                Consultar_DTE = Trim(FE_Resultado.IdSeguimiento)
            End If

            If pConsulta = 3 Then
                'Comentarios asociados al estado de autorización
                Consultar_DTE = Trim(FE_Resultado.Comentarios)
            End If
        Else
            Consultar_DTE = FE_Resultado.ResultadoServicio.Descripcion
        End If

    End Function

    Public Function TiposEstado_DTE(wEstado As Integer) As String
        Select Case wEstado
            Case 0
                TiposEstado_DTE = "El documento fue autorizado"
            Case 1
                TiposEstado_DTE = "La resolución del SII está pendiente"
            Case 2
                TiposEstado_DTE = "El documento fue autorizado, pero con observaciones o reparos"
            Case 9
                TiposEstado_DTE = "El documento fue rechazado"
            Case Else
                TiposEstado_DTE = "ID Retorno " + Num(wEstado)
        End Select
    End Function

    Function Archivo_Fiscal(qExtension As String, qLocal As Double, qTipoDoc As String, qNumero As Double, qCliente As Double) As String
        Dim wCliente As String = Trim(qCliente.ToString)
        If qCliente = 0 Then
            Paso = SQL("Select Cliente from DocumentosG where Local = " + Num(qLocal) + " and TipoDoc = '" + qTipoDoc + "' and Numero = " + Num(qNumero))
            If Paso.RecordCount > 0 Then
                qCliente = Paso.Fields("Cliente").Value
            End If
        End If
        If qCliente > 0 Then
            Paso = SQL("Select Fantasia from Clientes where Cliente = " + Num(qCliente))
            If Paso.RecordCount > 0 Then
                wCliente = Paso.Fields("Fantasia").Value.ToString.Trim
            End If
        End If
        Select Case qExtension
            Case gPDF
                Archivo_Fiscal = Directorio_PDF + Trim(qTipoDoc) + " (" + Llena0(qLocal, 2) + ") " + Llena0(qNumero, 8) + IIf(Trim(wCliente) = "", "", " " + Trim(wCliente)) + "." + LCase(gPDF)
            Case gXML
                Archivo_Fiscal = Directorio_TED + Trim(qTipoDoc) + " (" + Llena0(qLocal, 2) + ") " + Llena0(qNumero, 8) + IIf(Trim(wCliente) = "", "", " " + Trim(wCliente)) + "." + LCase(gXML)
            Case gJPG
                Archivo_Fiscal = Directorio_TED + Trim(qTipoDoc) + " (" + Llena0(qLocal, 2) + ") " + Llena0(qNumero, 8) + IIf(Trim(wCliente) = "", "", " " + Trim(wCliente)) + "." + LCase(gJPG)
            Case gTXT
                Archivo_Fiscal = Directorio_TXT + Trim(qTipoDoc) + " (" + Llena0(qLocal, 2) + ") " + Llena0(qNumero, 8) + IIf(Trim(wCliente) = "", "", " " + Trim(wCliente)) + "." + LCase(gTXT)
            Case Else
                Archivo_Fiscal = Directorio_TXT + Trim(qTipoDoc) + " (" + Llena0(qLocal, 2) + ") " + Llena0(qNumero, 8) + IIf(Trim(wCliente) = "", "", " " + Trim(wCliente)) + "." + LCase(qExtension)
        End Select

    End Function

    Public Function FE_Fecha(wFecha As Date) As String
        'El formato que reconoce el DTE es YYYY-MM-DD
        FE_Fecha = Mid(wFecha, 1, 10)
        FE_Fecha = Replace(FE_Fecha, "/", "")
        FE_Fecha = Replace(FE_Fecha, "-", "")
        FE_Fecha = Mid(FE_Fecha, 5, 5) + "-" + Mid(FE_Fecha, 3, 2) + "-" + Mid(FE_Fecha, 1, 2)
    End Function

    Public Function Crear_TED(wLocal As Double, wTipoDoc As String, wNumero As Double) As Boolean
        Dim qRuta As String = ""
        Crear_TED = False
        Try
            Swap = SQL("Select * from DocumentosG where Local = " & wLocal & " and TipoDoc = '" & wTipoDoc & "' and Numero = " & wNumero)
            If Swap.RecordCount > 0 Then
                If Trim(Swap("TED").Value) <> "" Then
                    'Guardar PDF417
                    qRuta = Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumero, 0)
                    System.IO.File.WriteAllBytes(qRuta, Swap("Firma").Value)

                    'Guardar el XML 
                    qRuta = Archivo_Fiscal(gXML, wLocal, wTipoDoc, wNumero, 0)
                    System.IO.File.WriteAllText(qRuta, Swap("TED").Value)
                    Crear_TED = True
                End If
            End If
        Catch ex As Exception
            Respuesta = ex.Message
        End Try
    End Function

    Public Function Grabar_TED(wLocal As Double, wTipoDoc As String, wNumero As Double) As Boolean
        'Pasar los archivos TED a los campos de las Tablas
        Dim DocX As New ADODB.Recordset
        Grabar_TED = False
        DocX = SQL("Select Cliente, Firma, TED from DocumentosG where Local = " & wLocal & " and TipoDoc = '" & wTipoDoc & "' and Numero = " & wNumero)
        If DocX.RecordCount > 0 Then
            DocX.Fields("Firma").Value = Leer_JPG(Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumero, DocX("Cliente").Value))
            DocX.Fields("TED").Value = Leer_TED(Archivo_Fiscal(gXML, wLocal, wTipoDoc, wNumero, DocX("Cliente").Value))
            DocX.Update()
            Grabar_TED = True
        End If
    End Function


End Module
