Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq
Imports DTEBoxCliente
Imports Microsoft.VisualBasic
Imports Parametros

Public Class DTE

    'Facturación Electrónica
    Public Shared FE_IP As String
    Public Shared FE_EsElectronica As Boolean
    Public Shared FE_Ambiente As String
    Public Shared FE_Rut_Emisor As String
    Public Shared FE_Razon_Social As String
    Public Shared FE_Giro As String
    Public Shared FE_Direccion As String
    Public Shared FE_Comuna As String
    Public Shared FE_Ciudad As String
    Public Shared FE_Email As String
    Public Shared FE_Ateco As Double
    Public Shared FE_Llave As String
    Public Shared FE_NResolucion As Double
    Public Shared FE_FResolucion As Date
    Public Shared FE_DTE As String
    Public Shared FE_PDFColumnas As Integer
    Public Shared FE_PDFNivel As Integer
    Public Shared FE_PDFTruncado As Boolean
    Public Shared FE_TipoDTE As Double
    Public Shared FE_CodigoDTE As Double
    Public Shared FE_FV As Boolean
    Public Shared FE_GD As Boolean
    Public Shared FE_NC As Boolean
    Public Shared FE_FE As Boolean
    Public Shared FE_ND As Boolean
    Public Shared FE_BO As Boolean
    Public Shared FE_BE As Boolean
    Public Shared FE_FC As Boolean

    Public Structure TipoArchivo
        Shared PDF As String = "pdf"
        Shared XML As String = "xml"
        Shared JPG As String = "jpg"
        Shared TXT As String = "txt"
    End Structure

    Public Shared MensajeDTE As String

    Public Shared Directorio_CAF As String
    Public Shared Directorio_TED As String
    Public Shared Directorio_PDF As String
    Public Shared Directorio_TXT As String

    Public Enum ModoCorrelativo
        Consultar = 0
        ConsultarEstablecer = 1
    End Enum

    Public Shared Function Correlativo(wModo As ModoCorrelativo, wLocal As Integer, wTipoDoc As String,
                                wFecha As Date, Optional wCaja As Integer = 0) As Tuple(Of Double, String, String)


        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim COR = wDC.Correlativos.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Caja = wCaja)

        If COR Is Nothing Then
            Return New Tuple(Of Double, String, String)(0, "No existe correlativo para Local:  " & wLocal & " Documento: " & wTipoDoc & " Caja: " & wCaja, "0")
        End If

        If CDate(wFecha) < CDate(COR.FechaCAF) Then
            Return New Tuple(Of Double, String, String)(0, "Fecha del Documento fuera del rango permitido en CAF: " & wFecha, "0")
        End If

        If COR.Correlativo < COR.Inicial Or COR.Correlativo > COR.Final Then
            Return New Tuple(Of Double, String, String)(0, "Correlativo Fuera de Rango Local: " & wLocal & " Documento: " & wTipoDoc & " Correlativo: " & COR.Correlativo & " Rango: " & COR.Inicial & " -> " & COR.Final, "0")
        End If

        Dim wCorrelativo = COR.Correlativo
        Dim wFechaCaf = COR.FechaCAF
        If wModo = ModoCorrelativo.ConsultarEstablecer Then
            wDC.ExecuteCommand("UPDATE CORRELATIVOS SET Correlativo = Correlativo + 1 WHERE Local = " & wLocal & " AND TipoDoc = '" & wTipoDoc & "' AND Caja = '" & wCaja & "'")
        End If

        Return New Tuple(Of Double, String, String)(wCorrelativo, If(wModo = ModoCorrelativo.ConsultarEstablecer, "Correlativo Incrementado " & wCorrelativo & " - " & COR.Correlativo, ""), wFechaCaf)
    End Function


    Public Class RespuestaTED

        Public Property Estado As Boolean
        Public Property Mensaje As String
        Public Property Imagen As Byte()
        Public Property XML As String

        Public Sub New(wEstado As Boolean, wMensaje As String)
            Estado = wEstado
            Mensaje = wMensaje
            Imagen = Nothing
            XML = ""
        End Sub

        Public Sub New(wEstado As Boolean, wMensaje As String, wImagen As Byte(), wXML As String)
            Estado = wEstado
            Mensaje = wMensaje
            Imagen = wImagen
            XML = wXML
        End Sub
    End Class

    Public Shared Function Generar_TED(wCliente As Double, wLocal As Integer, wTipoDoc As String, wNumDoc As Double, wFecha As Date,
                                       wRut As String, wNombre As String, wMonto As Double, wPrimeraLinea As String) As RespuestaTED

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim Imagen As Byte() = Nothing
        Dim XML As String


        Dim wStep = 0

        Try

            wStep = 1
            'Datos del TED
            Dim tipoDocumento As TipoDocumento
            tipoDocumento = Nothing
            If wTipoDoc = "FV" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.FacturaElectronica
            End If
            If wTipoDoc = "GD" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.GuiaDespachoElectronica
            End If
            If wTipoDoc = "NC" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.NotaCreditoElectronica
            End If
            If wTipoDoc = "ND" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.NotaDebitoElectronica
            End If
            If wTipoDoc = "BV" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.BoletaElectronica
            End If
            If wTipoDoc = "FC" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.FacturaCompraElectronica
            End If
            If wTipoDoc = "FE" Then
                tipoDocumento = GDEGateway.Timbre.TipoDocumento.FacturaElectronicaNoAfectaOExenta
            End If

            wStep = 2

            Dim CAF() As Byte = Nothing

            Try

                'CAF = System.IO.File.ReadAllBytes(Directorio_CAF & wTipoDoc + wLocal.ToString.PadLeft(2, "0") & ".xml")

                wStep = 4
                Dim wCorr = wDC.Correlativos.FirstOrDefault(Function(x) x.TipoDoc = wTipoDoc)
                'Dim reader = wCorr.CAF.CreateReader()
                'reader.MoveToContent()
                'Dim wTextoXML = reader.ReadInnerXml()
                Dim wTextoXML = wCorr.CAF
                If wCorr IsNot Nothing Then
                    CAF = Encoding.UTF8.GetBytes(wTextoXML)
                End If

            Catch ex As Exception
                Return New RespuestaTED(False, "Error al recuperar CAF")
            End Try

            wStep = 5

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

            Dim tedGenerado As GDEGateway.Timbre.TED
            wStep = 6


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

            'Valor
            Dim tedValor As String


            wStep = 7

            tedValor = tedGenerado.Valor

            Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumDoc)
            If DocG Is Nothing Then
                Return New RespuestaTED(False, "Error al recuperar CAF. Documento no existe")
            End If

            'Guardar el pdf417 en disco como imagen
            Dim pdf417FilePath As String
            pdf417FilePath = Ruta_Archivo_Fiscal(TipoArchivo.JPG, wLocal, wTipoDoc, wNumDoc, DocG.Cliente)
            System.IO.File.WriteAllBytes(pdf417FilePath, tedGenerado.CodigoComoBytes())

            Imagen = tedGenerado.CodigoComoBytes()

            'Guardar el XML en disco como archivo
            Dim ArchivoXML As String
            ArchivoXML = Ruta_Archivo_Fiscal(TipoArchivo.XML, wLocal, wTipoDoc, wNumDoc, DocG.Cliente)
            System.IO.File.WriteAllText(ArchivoXML, tedValor)



            XML = tedValor
            LogDTE(1, XML, New List(Of String), "Generar_TED")
            Funciones.LogTxt("Generar_TED", tedValor)

            If DocG IsNot Nothing Then
                DocG.TED = XML
                DocG.Firma = Imagen
                If Not {1, 2}.Contains(DocG.STATUS_DTE) Then DocG.STATUS_DTE = 3
                wDC.SubmitChanges()
                wDC.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues)
            End If

        Catch ex As Exception
            Return New RespuestaTED(False, "(" & wStep & ")" & " " & ex.ToString)
        End Try

        Return New RespuestaTED(True, "", Imagen, XML)

    End Function

    Public Shared Function Ruta_Archivo_Fiscal(wExtension As String, wLocal As Double, wTipoDoc As String, wNumero As Double, wCliente As Double) As String

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wFantasia As String = ""

        If wCliente = 0 Then
            Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
            If DocG IsNot Nothing Then
                wCliente = DocG.Cliente
            End If
        End If

        If wCliente > 0 Then
            Dim Cliente = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
            If Cliente IsNot Nothing Then
                wFantasia = Cliente.Fantasia.Trim
            End If
        End If

        Dim wRuta = Trim(wTipoDoc) & " (" & wLocal.ToString.PadLeft(2, "0") & ") " &
                    wNumero.ToString.PadLeft(8, "0") &
                    If(wFantasia = "", "", (" " & wFantasia)) & "." + LCase(wExtension)

        Select Case wExtension
            Case TipoArchivo.PDF
                Return Directorio_PDF & wRuta
            Case TipoArchivo.XML
                Return Directorio_TED & wRuta
            Case TipoArchivo.JPG
                Return Directorio_TED & wRuta
            Case TipoArchivo.TXT
                Return Directorio_TXT & wRuta
            Case Else
                Return P_DIRECTORIO & wRuta
        End Select

    End Function

    Public Shared Function Emitir_DTE(wLocal As Double, wTipoDoc As String, wNumDoc As Double) As Boolean
        Dim wPrimeraLinea As String, wUnidad As String, wArticulo As String, Referencias As Double

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        'Las Boletas de Venta tienen tratamiento especial
        If wTipoDoc = "BV" Then
            Dim Respuesta = Emitir_Boleta(wLocal, wTipoDoc, wNumDoc)
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

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumDoc)
        If DocG Is Nothing Then
            Return False
        End If


        Dim ListaDocD = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumDoc).ToList
        If Not ListaDocD.Any Then
            Return False
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
        If CLI Is Nothing Then
            Return False
        End If

        'Documento/Encabezado/IdDoc
        doc.Encabezado.IdDoc.TipoDTE = Codigo_DTE(wTipoDoc)
        doc.Encabezado.IdDoc.Folio = CInt(wNumDoc)
        doc.Encabezado.IdDoc.FchEmis = New LiquidTechnologies.Runtime.Net20.XmlDateTime(DocG.Fecha.Value.Date)
        doc.Encabezado.IdDoc.FmaPago = IIf(DocG.FPago.Trim.ToUpper = "E", DocumentoDTE.SiiDte.Enumerations.IdDoc_FmaPago.n1, DocumentoDTE.SiiDte.Enumerations.IdDoc_FmaPago.n2)

        If wTipoDoc = "GD" Then
            doc.Encabezado.IdDoc.TipoDespacho = DocumentoDTE.SiiDte.Enumerations.IdDoc_TipoDespacho.n1
            doc.Encabezado.IdDoc.IndTraslado = Codigo_Referencia(wTipoDoc, DocG.Motivo.ToString.Trim)
            doc.Encabezado.IdDoc.IndServicio = DocumentoDTE.SiiDte.Enumerations.IdDoc_IndServicio.n1
            doc.Encabezado.IdDoc.FchVenc = New LiquidTechnologies.Runtime.Net20.XmlDateTime(DocG.Fecha.Value.Date)
        End If

        If wTipoDoc = "NC" Or wTipoDoc = "ND" Then
            doc.Encabezado.IdDoc.FmaPago = DocumentoDTE.SiiDte.Enumerations.IdDoc_FmaPago.n1
            doc.Encabezado.IdDoc.FchVenc = New LiquidTechnologies.Runtime.Net20.XmlDateTime(DocG.FechaDocReferencia.Value.Date)
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
        doc.Encabezado.Receptor.RUTRecep = UCase(DocG.Rut).Replace("_", "").Replace(".", "")
        doc.Encabezado.Receptor.RznSocRecep = FormatoTexto(Mid(CLI.Nombre, 1, 100))
        doc.Encabezado.Receptor.CdgIntRecep = CLI.Cliente
        doc.Encabezado.Receptor.GiroRecep = FormatoTexto(Mid(CLI.Giro, 1, 40))
        doc.Encabezado.Receptor.Contacto = FormatoTexto(Mid(CLI.Contacto, 1, 80))
        doc.Encabezado.Receptor.DirRecep = FormatoTexto(Mid(CLI.Direccion, 1, 70))
        doc.Encabezado.Receptor.CmnaRecep = FormatoTexto(Mid(Saca_Comuna(CLI.Comuna), 1, 20))
        doc.Encabezado.Receptor.CiudadRecep = FormatoTexto(Mid(Saca_Ciudad(CLI.Comuna), 1, 20))
        doc.Encabezado.Receptor.CorreoRecep = CLI.Email.ToString.Trim

        'Documento/Descuentos Generales
        If DocG.Descuento > 0 Then
            Dim dscRcgGlobal As DocumentoDTE.SiiDte.DscRcgGlobal
            dscRcgGlobal = New DocumentoDTE.SiiDte.DscRcgGlobal()
            dscRcgGlobal.NroLinDR = 1
            dscRcgGlobal.TpoMov = DocumentoDTE.SiiDte.Enumerations.DscRcgGlobal_TpoMov.D
            dscRcgGlobal.TpoValor = DocumentoDTE.SiiDte.Enumerations.DineroPorcentajeType.Dollar  'Dollar = Descuento en Pesos,  Percent=Descuento por porcentaje
            dscRcgGlobal.ValorDR = DocG.Descuento
            doc.DscRcgGlobal.Add(dscRcgGlobal)
        End If

        'Documento/Encabezado/Totales
        doc.Encabezado.Totales = New DocumentoDTE.SiiDte.Totales()
        doc.Encabezado.Totales.MntTotal = CInt(DocG.Total)
        If wTipoDoc = "FE" Or DocG.TipoDocReferencia = "FE" Then
            doc.Encabezado.Totales.MntExe = CInt(DocG.Neto)
        Else
            doc.Encabezado.Totales.MntNeto = CInt(DocG.Neto)
            doc.Encabezado.Totales.TasaIVA = CInt(P_IVA)
            doc.Encabezado.Totales.IVA = CInt(DocG.IVA)
        End If


        'Documento/Detalle
        Dim det As DocumentoDTE.SiiDte.Detalle

        Dim Lineas = 1

        wPrimeraLinea = "ARTICULO"
        For Each DocD In ListaDocD
            det = New DocumentoDTE.SiiDte.Detalle()

            wUnidad = "UN"

            Dim Art = wDC.Articulos.FirstOrDefault(Function(x) x.Articulo = DocD.Articulo.Trim)

            If Art IsNot Nothing Then
                wUnidad = Art.Unidad.Trim
            End If

            wArticulo = Trim(Mid(DocD.Glosa, 1, 80))
            If wArticulo = "" Then wArticulo = Art.Descripcion
            If wPrimeraLinea = "ARTICULO" Then
                wPrimeraLinea = Trim(Mid(FormatoTexto(wArticulo), 1, 80))
                wArticulo = wPrimeraLinea
            End If

            det.NroLinDet = Lineas
            If Lineas = 1 Then
                det.NmbItem = wPrimeraLinea
            Else
                det.NmbItem = wArticulo
            End If
            det.MontoItem = CInt(Math.Round(DocD.Cantidad * DocD.Neto, 0))
            det.DscItem = wArticulo
            det.QtyItem = DocD.Cantidad
            det.UnmdItem = wUnidad
            If DocD.Neto > 0 Then
                det.PrcItem = DocD.Neto
            End If

            'Si es NC o ND y el Documento afecto es FE, debe tener este item especial de exento
            If DocG.TipoDocReferencia = "FE" Then
                det.IndExe = 0   'En el DTE les llega como un 1
            End If

            doc.Detalle.Add(det)
            Lineas += 1
        Next



        'Documento/Referencia
        If wTipoDoc <> "BV" Then
            If (DocG.TipoDocReferencia.Trim <> "" And (wTipoDoc = "NC" Or wTipoDoc = "ND")) Or DocG.OC.Trim <> "" Then
                Dim reference As DocumentoDTE.SiiDte.Referencia
                reference = New DocumentoDTE.SiiDte.Referencia()

                Referencias = 1
                If wTipoDoc = "NC" Or wTipoDoc = "ND" Then
                    reference.NroLinRef = CInt(Referencias)
                    reference.TpoDocRef = Codigo_SII(DocG.TipoDocReferencia.Trim)
                    reference.FolioRef = CInt(DocG.NumDocReferencia)
                    reference.FchRef = New LiquidTechnologies.Runtime.Net20.XmlDateTime(DocG.FechaDocReferencia.Value.Date)
                    reference.CodRef = Codigo_Referencia(wTipoDoc, DocG.Motivo.ToString.Trim)
                    reference.RazonRef = FormatoTexto(Descripcion_Motivo(wTipoDoc, DocG.Motivo.ToString.Trim))
                    doc.Referencia.Add(reference)
                    Referencias = Referencias + 1
                End If
                If wTipoDoc <> "BV" Then
                    If DocG.OC.Trim <> "" And Referencias = 1 Then
                        reference.NroLinRef = CInt(Referencias)
                        reference.TpoDocRef = Codigo_SII("OC")
                        reference.FolioRef = Trim(DocG.OC)
                        reference.FchRef = New LiquidTechnologies.Runtime.Net20.XmlDateTime(DocG.Fecha.Value.Date)
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
        GenerarFolio = False   'Es para que el DTE genere correlativo automatico o no

        Dim apiURL As String
        Dim apiAuth As String
        apiURL = FE_DTE
        apiAuth = FE_Llave

        Dim ServicioDTE As DTEBoxCliente.Servicio
        ServicioDTE = New DTEBoxCliente.Servicio(apiURL, apiAuth)

        Dim ResultadoDTE As DTEBoxCliente.ResultadoEnvioDte
        ResultadoDTE = ServicioDTE.EnviarDocumento(dte, AmbienteDTE, FechaResolucion, NumeroResolucion, TipoPDF417, GenerarFolio)

        LogDTE(0, "RESULTADO DTE " & ResultadoDTE.ResultadoServicio.Estado & " " & ResultadoDTE.ResultadoServicio.Descripcion, New List(Of String), "Emitir_DTE")
        Funciones.LogTxt("Resultado DTE", "RESULTADO DTE " & ResultadoDTE.ResultadoServicio.Estado & " " & ResultadoDTE.ResultadoServicio.Descripcion)
        'Procesar Resultado del Servicio
        If (ResultadoDTE.ResultadoServicio.Estado = DTEBoxCliente.EstadoResultado.Ok) Then
            'Usar el data que viene en el resultado de la llamada
            Dim TED As String
            TED = ResultadoDTE.TED
            'Xml que representa el elemento TED generado
            'Si tipoPdf417 = DTEBoxCliente.TipoPdf417.Fuente viene el código, 
            ' si es DTEBoxCliente.TipoPdf417.Grafico , Entonces arreglo de bytes codigificado en base64, 
            ' usar método result.Pdf417ComoArregloBytes()
            Dim PDF417 As String
            PDF417 = ResultadoDTE.Pdf417

            If DocG.STATUS_DTE <> 1 Then
                'Grabar Cambio de Estado
                DocG.DTE = True
                DocG.STATUS_DTE = 1
                Try
                    'DocG.Fields("Firma").Value = Leer_JPG(Directorio_TED + wTipoDoc + "(" + Llena0(wLocal, 2) + ")" + Llena0(wNumDoc, 8) + ".jpg")
                    DocG.Firma = Leer_JPG(Ruta_Archivo_Fiscal(TipoArchivo.JPG, wLocal, wTipoDoc, wNumDoc, DocG.Cliente))
                Catch ex As Exception
                    'MsgError("Error al Leer Firma:" + vbCrLf + Archivo_Fiscal(gJPG, wLocal, wTipoDoc, wNumDoc, DocG("Cliente").Value))
                End Try
                DocG.TED = TED
            End If

            wDC.SubmitChanges()
        Else
            MensajeDTE = ResultadoDTE.ResultadoServicio.Descripcion

            'Grabar Cambio de Status
            If DocG.STATUS_DTE = 0 Then
                'Grabar Cambio de Estado
                DocG.STATUS_DTE = 2
            End If
            wDC.SubmitChanges()


            Return False

        End If
        Return True

    End Function


    Public Shared Sub LogDTE(wCliente As Integer, wEx As String, wErrores As List(Of String), wMetodo As String)
        Dim wLogCON As New SqlConnection(P_CONEXION)

        wLogCON.Open()

        Dim wExcep As New SqlCommand("INSERT INTO Log VALUES(@Mensaje,@Fecha,@Cliente)", wLogCON)
        wExcep.Parameters.AddWithValue("@Mensaje", "DTE " & wMetodo & ": " & wEx)
        wExcep.Parameters.AddWithValue("@Fecha", Now)
        wExcep.Parameters.AddWithValue("@Cliente", wCliente)
        wExcep.ExecuteNonQuery()

        For Each wErr As String In wErrores

            wLogCON = New SqlConnection(P_CONEXION)
            wLogCON.Open()

            Dim wMSG As New SqlCommand("INSERT INTO Log VALUES(@Mensaje,@Fecha,@Cliente)", wLogCON)
            wMSG.Parameters.AddWithValue("@Mensaje", "DTE " & wMetodo & ": " & wErr)
            wMSG.Parameters.AddWithValue("@Fecha", Now)
            wMSG.Parameters.AddWithValue("@Cliente", wCliente)
            wMSG.ExecuteNonQuery()

        Next

        wLogCON.Close()
        SqlConnection.ClearPool(wLogCON)
    End Sub

    Public Shared Function Emitir_Boleta(wLocal As Double, wTipoDoc As String, wNumDoc As Double) As Boolean
        Dim wPrimeraLinea As String, wUnidad As String, wArticulo As String

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

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

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumDoc)
        If DocG Is Nothing Then
            Return False
        End If

        Dim ListaDocD = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumDoc).ToList
        If Not ListaDocD.Any Then
            Return False
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
        If CLI Is Nothing Then
            Return False
        End If

        'Documento/Encabezado/IdDoc
        doc.Encabezado.IdDoc.TipoDTE = DocumentoBoleta.SiiDte.Enumerations.DTEType.n39
        doc.Encabezado.IdDoc.Folio = CInt(wNumDoc)
        doc.Encabezado.IdDoc.FchEmis = New LiquidTechnologies.Runtime.Net20.XmlDateTime(DocG.Fecha.Value.Date)
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
        doc.Encabezado.Receptor.RUTRecep = UCase(DocG.Rut).Replace("_", "").Replace(".", "")
        doc.Encabezado.Receptor.RznSocRecep = FormatoTexto(Mid(CLI.Nombre, 1, 100))
        doc.Encabezado.Receptor.CdgIntRecep = CLI.Cliente
        doc.Encabezado.Receptor.Contacto = FormatoTexto(Mid(CLI.Contacto, 1, 80))
        doc.Encabezado.Receptor.DirRecep = FormatoTexto(Mid(CLI.Direccion, 1, 70))
        doc.Encabezado.Receptor.CmnaRecep = FormatoTexto(Mid(Saca_Comuna(CLI.Comuna), 1, 20))
        doc.Encabezado.Receptor.CiudadRecep = FormatoTexto(Mid(Saca_Ciudad(CLI.Comuna), 1, 20))

        'Boleta/Documento/Encabezado/Totales
        doc.Encabezado.Totales = New DocumentoBoleta.SiiDte.Totales()
        doc.Encabezado.Totales.MntTotal = CInt(DocG.Total)


        'Documento/Detalle
        Dim det As DocumentoBoleta.SiiDte.Detalle

        Dim Lineas = 1
        wPrimeraLinea = "ARTICULO"
        For Each DocD In ListaDocD

            det = New DocumentoBoleta.SiiDte.Detalle()

            wUnidad = "UN"

            Dim Art = wDC.Articulos.FirstOrDefault(Function(x) x.Articulo = DocD.Articulo.Trim)

            If Art IsNot Nothing Then
                wUnidad = Art.Unidad.Trim
            End If

            If Trim(Mid(DocD.Glosa, 1, 80)) = "" Then
                wArticulo = If(Art IsNot Nothing, Trim(Art.Descripcion), "")
            Else
                wArticulo = Trim(Mid(DocD.Glosa, 1, 80))
            End If
            If wPrimeraLinea = "ARTICULO" Then
                wPrimeraLinea = Trim(Mid(FormatoTexto(wArticulo), 1, 80))
                wArticulo = wPrimeraLinea
            End If

            det.NroLinDet = Lineas

            If Lineas = 1 Then
                det.NmbItem = wPrimeraLinea
            Else
                det.NmbItem = wArticulo
            End If

            det.MontoItem = CInt(Math.Round(DocD.Cantidad * DocD.Neto * (1 + (P_IVA / 100)), 0))
            det.DscItem = wArticulo
            det.QtyItem = DocD.Cantidad
            det.UnmdItem = wUnidad
            If DocD.Neto > 0 Then
                det.PrcItem = CInt(Math.Round(DocD.Neto * (1 + (P_IVA / 100)), 0))
            End If

            'Para agregar codigo de producto 
            ''Documento/Detalle/CdgItem
            'Dim cdgItem As DocumentoDTE.SiiDte.CdgItem
            'cdgItem = New DocumentoDTE.SiiDte.CdgItem()
            'cdgItem.TpoCodigo = "INT"  'Intenro
            'cdgItem.VlrCodigo = "BUR-BURSTA"
            'det.CdgItem.Add(cdgItem)

            doc.Detalle.Add(det)
            Lineas += 1

        Next


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

            If DocG.STATUS_DTE <> 1 Then
                'Grabar Cambio de Estado
                DocG.STATUS_DTE = 1
                'DocG.Firma = Leer_JPG(Directorio_TED + wTipoDoc + "(" + Llena0(wLocal, 2) + ")" + Llena0(wNumDoc, 8) + ".jpg")
                DocG.Firma = Leer_JPG(Ruta_Archivo_Fiscal(TipoArchivo.JPG, wLocal, wTipoDoc, wNumDoc, DocG.Cliente))
                DocG.TED = XElement.Parse(ResultadoDTE.TED)
            End If

            wDC.SubmitChanges()

        Else
            MensajeDTE = ResultadoDTE.ResultadoServicio.Descripcion
            'Grabar Cambio de Status
            If DocG.STATUS_DTE = 0 Then
                'Grabar Cambio de Estado
                DocG.STATUS_DTE = 2
                wDC.SubmitChanges()
            End If
            Return False
        End If

        Return True

    End Function

    Public Shared Function Consultar_DTE(pConsulta As String, pTipoDoc As String, pNumero As Double) As Tuple(Of Integer, String)
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
            Return New Tuple(Of Integer, String)(7, "3 Reintentos fallidos. Intente nuevamente.")
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
                Select Case FE_Resultado.Estado
                    Case 0
                        Return New Tuple(Of Integer, String)(0, "El documento fue autorizado")
                    Case 1
                        Return New Tuple(Of Integer, String)(1, "La resolución del SII está pendiente")
                    Case 2
                        Return New Tuple(Of Integer, String)(2, "El documento fue autorizado, pero con observaciones o reparos")
                    Case 9
                        Return New Tuple(Of Integer, String)(9, "El documento fue rechazado")
                    Case Else
                        Return New Tuple(Of Integer, String)(FE_Resultado.Estado, "")
                End Select
            End If

            If pConsulta = 2 Then
                'TrackId que entregó el SII con la autorización del documento.
                Return New Tuple(Of Integer, String)(22, Trim(FE_Resultado.IdSeguimiento))
            End If

            If pConsulta = 3 Then
                'Comentarios asociados al estado de autorización
                Return New Tuple(Of Integer, String)(33, Trim(FE_Resultado.Comentarios))
            End If
        Else
            Return New Tuple(Of Integer, String)(99, Trim(FE_Resultado.ResultadoServicio.Descripcion))
        End If

    End Function


    Public Shared Function Parametros_DTE(wLocal As Double) As Boolean

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Parametros_DTE = False
        Try
            Dim Loc = wDC.Locales.FirstOrDefault(Function(x) x.Local = wLocal)

            If Loc IsNot Nothing Then

                FE_IP = Loc.IP_DTE.ToString.Trim
                FE_EsElectronica = Loc.FElectronica
                FE_Rut_Emisor = UCase(Loc.RutLocal).Replace("_", "").Replace(".", "")
                FE_Ambiente = IIf(Loc.Produccion, DTEBoxCliente.Ambiente.Produccion, DTEBoxCliente.Ambiente.Homologacion)
                FE_Razon_Social = FormatoTexto(Mid(Loc.RazonLocal, 1, 100))
                FE_Giro = FormatoTexto(Mid(Loc.GiroLocal, 1, 80))
                FE_Direccion = FormatoTexto(Mid(Loc.DirLocal, 1, 60))
                FE_Comuna = FormatoTexto(Saca_Comuna(Loc.Comuna))
                FE_Ciudad = FormatoTexto(Saca_Ciudad(Loc.Ciudad))
                FE_Email = Loc.EMailLocal.ToString.Trim
                FE_Ateco = Loc.ATECO.ToString.Trim
                FE_Llave = Loc.Llave.ToString.Trim
                FE_NResolucion = Loc.NResolucion
                FE_FResolucion = Loc.FResolucion
                FE_DTE = "http://" + FE_IP + "/api/Core.svc/Core"
                FE_FV = Loc.FV_Elect
                FE_GD = Loc.GD_Elect
                FE_NC = Loc.NC_Elect
                FE_FE = Loc.FE_Elect
                FE_ND = Loc.ND_Elect
                FE_BO = Loc.BV_Elect
                FE_BE = Loc.BE_Elect
                FE_FC = Loc.FC_Elect

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
            End If

            Directorio_CAF = P_RUTA & "\CAF\"
            Directorio_TED = P_RUTA & "\TED\"
            Directorio_PDF = P_RUTA & "\PDF\"
            Directorio_TXT = P_RUTA & "\TXT\"
            P_DIRECTORIO = Environment.CurrentDirectory

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function


    Public Shared Function Es_Electronico(wTipoDoc As String) As Boolean
        Es_Electronico = False
        If FE_EsElectronica Then
            If FE_FV And wTipoDoc = "FV" Then Es_Electronico = True
            If FE_GD And wTipoDoc = "GD" Then Es_Electronico = True
            If FE_NC And wTipoDoc = "NC" Then Es_Electronico = True
            If FE_FE And wTipoDoc = "FE" Then Es_Electronico = True
            If FE_ND And wTipoDoc = "ND" Then Es_Electronico = True
            If FE_BO And wTipoDoc = "BV" Then Es_Electronico = True
            If FE_BE And wTipoDoc = "BE" Then Es_Electronico = True
            If FE_FC And wTipoDoc = "FV" Then Es_Electronico = True
        End If
    End Function

    Public Shared Function Codigo_Fiscal(wTipoDoc As String) As Integer
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

    Public Shared Function Codigo_DTE(wTipoDoc As String) As Integer
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

    Public Shared Function Codigo_Referencia(wTipoDoc As String, wMotivo As String) As Integer
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

    Public Shared Function Codigo_SII(wTipoDoc As String) As String
        If wTipoDoc = "" Then Return "0"
        Dim wDC As New BaseSisVenDataContext(P_CONEXION)
        Dim TipoDoc = wDC.TipoDoc.FirstOrDefault(Function(x) x.TipoDoc = wTipoDoc)
        If TipoDoc Is Nothing Then Return "0"
        Return TipoDoc.Cod_SII
    End Function

    Public Shared Function FormatoTexto(wTexto As String, Optional wLargo As Integer = 0) As String
        Dim Car As String, i As Integer, Texto_Resultado As String

        FormatoTexto = UCase(Trim(wTexto))
        FormatoTexto = Replace(FormatoTexto, "Á", "A")
        FormatoTexto = Replace(FormatoTexto, "Ä", "A")
        FormatoTexto = Replace(FormatoTexto, "É", "E")
        FormatoTexto = Replace(FormatoTexto, "Í", "I")
        FormatoTexto = Replace(FormatoTexto, "Ó", "O")
        FormatoTexto = Replace(FormatoTexto, "Ö", "O")
        FormatoTexto = Replace(FormatoTexto, "Ú", "U")
        FormatoTexto = Replace(FormatoTexto, "Ü", "U")
        FormatoTexto = Replace(FormatoTexto, "Ñ", "N")
        FormatoTexto = Replace(FormatoTexto, "²", "2")
        FormatoTexto = Replace(FormatoTexto, "º", "")
        FormatoTexto = Replace(FormatoTexto, "°", "")
        FormatoTexto = Replace(FormatoTexto, "ª", "")
        FormatoTexto = Replace(FormatoTexto, "%", "")
        FormatoTexto = Replace(FormatoTexto, "$", "")
        FormatoTexto = Replace(FormatoTexto, "&", "")
        FormatoTexto = Replace(FormatoTexto, "*", "")
        FormatoTexto = Replace(FormatoTexto, "^", "")
        FormatoTexto = Replace(FormatoTexto, "~", "")
        FormatoTexto = Replace(FormatoTexto, "#", "")
        FormatoTexto = Replace(FormatoTexto, Chr(34), "")
        FormatoTexto = Replace(FormatoTexto, Chr(39), "")
        FormatoTexto = Replace(FormatoTexto, Chr(96), "")
        FormatoTexto = Replace(FormatoTexto, Chr(176), "")
        FormatoTexto = Replace(FormatoTexto, Chr(186), "")

        Texto_Resultado = ""
        'Sacar los caracteres no imprimibles despues de la limpieza de letras
        For i = 1 To Len(FormatoTexto)
            Car = Mid(FormatoTexto, i, 1)
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

        FormatoTexto = Texto_Resultado

        If Trim(FormatoTexto) = "" Then
            FormatoTexto = ""
        End If

        If wLargo > 0 Then
            FormatoTexto = Mid(FormatoTexto + Space(wLargo), 1, wLargo)
        End If

    End Function

    Public Shared Function Cambia_Car(wCar As String, wAsc As Integer) As String
        Cambia_Car = wCar
        If Trim(wCar) <> "" Then
            If Asc(wCar) = wAsc Then
                Cambia_Car = ""
            End If
        End If
    End Function

    Public Shared Function Saca_Ciudad(wCiudad As String) As String
        If wCiudad = "" Then Return ""
        Dim wDC As New BaseSisVenDataContext(P_CONEXION)
        Dim Ciudad = wDC.Ciudades.FirstOrDefault(Function(x) x.Ciudad = wCiudad)
        If Ciudad Is Nothing Then Return wCiudad
        Return Ciudad.NombreCiudad
    End Function

    Public Shared Function Saca_Comuna(wComuna As String) As String
        If wComuna = "" Then Return ""
        Dim wDC As New BaseSisVenDataContext(P_CONEXION)
        Dim Comuna = wDC.Comunas.FirstOrDefault(Function(x) x.Comuna = wComuna)
        If Comuna Is Nothing Then Return wComuna
        Return Comuna.NombreComuna
    End Function

    Public Shared Function Descripcion_Motivo(wTipoDoc As String, wMotivo As String) As String
        Dim wDC As New BaseSisVenDataContext(P_CONEXION)
        Dim Motivo = wDC.Motivos.FirstOrDefault(Function(x) x.Motivo = wMotivo And x.TipoDoc = wTipoDoc)
        If Motivo Is Nothing Then Return ""
        Return Mid(Motivo.DescMotivo, 1, 50)
    End Function

    Public Shared Function Leer_JPG(pArchivo As String) As Byte()
        Try
            Dim wArchivo As New FileStream(pArchivo, FileMode.Open, FileAccess.Read)
            Dim Lectura As New BinaryReader(wArchivo)
            Dim Imagen(wArchivo.Length) As Byte
            Lectura.Read(Imagen, 0, wArchivo.Length)
            wArchivo.Close()
            Return Imagen
        Catch ex As Exception
            Return Nothing
        End Try
    End Function




End Class
