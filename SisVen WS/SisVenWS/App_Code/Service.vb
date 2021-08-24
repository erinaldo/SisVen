Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Linq
Imports System.Net.Mail
Imports System.Web.Services
Imports Parametros
Imports DTE
Imports Stock
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports Funciones



'<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<WebService(Namespace:="http://wikets.cl/")>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class Service

    Inherits WebService
    Dim wCON As SqlConnection

    <WebMethod()>
    Public Function Version_WebService() As DataTable
        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Dato", GetType(String))
        wDT.Rows.Add(1, P_VERSION)
        Return wDT
    End Function

    <WebMethod(MessageName:="Iniciar_Sesion", Description:="")>
    Public Function IniciarSesion(wIdKey As String, wIdUsuario As String, wContrasena As String) As DataTable
        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Local", GetType(Integer))
        wDT.Columns.Add("Cliente", GetType(Integer))
        wDT.Columns.Add("Nombre", GetType(String))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        If Not ValidarTexto(wIdUsuario, 3, True, "") Then
            wDT.Rows.Add(0, "Error en el usuario. " & wIdUsuario, 0, 0)
            Return wDT
        End If

        If Not ValidarTexto(wContrasena, 50, True, "") Then
            wDT.Rows.Add(0, "Error en la contraseña.", 0, 0)
            Return wDT
        End If

        Dim Usuario = wDC.Usuarios.FirstOrDefault(Function(x) x.Usuario = wIdUsuario)

        If Usuario Is Nothing Then
            wDT.Rows.Add(0, "No se pudo encontrar el usuario: " & wIdUsuario, 0, 0)
            Return wDT
        End If

        If UCase(wContrasena) <> UCase(Descripta(Usuario.Clave)) Then
            wDT.Rows.Add(0, "Contraseña incorrecta: " & wIdUsuario, 0, 0)
            Return wDT
        End If

        wDT.Rows.Add(1, "Usuario y contraseña correctos: " & wIdUsuario, Usuario.Local, Usuario.Empresa, Usuario.NombreUsr.Trim)

        Return wDT
    End Function

    <WebMethod(MessageName:="Consultar_Bodegas_Moviles", Description:="")>
    Public Function ConsultarBodegasMoviles(wIdKey As String, wCliente As Double, wLocal As Double) As DataTable
        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Bodegas", GetType(List(Of Bodega)))

        Dim wBodegas As New List(Of Bodega)

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", Nothing)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, Nothing)
            Return wDT
        End If

        If Not ValidarNum(wLocal, False, 0) Then
            wDT.Rows.Add(0, "Error en el local. " & wLocal, Nothing)
            Return wDT
        End If

        Dim Bodegas = wDC.Bodegas.Where(Function(x) x.Local = wLocal And x.Movil = True).ToList

        For Each wBod In Bodegas
            wBodegas.Add(New Bodega With {.Bodega = wBod.Bodega, .NombreBodega = wBod.NombreBodega.Trim, .Local = wLocal})
        Next

        If wBodegas.Any Then
            wDT.Rows.Add(1, "Bodegas encontradas.", wBodegas)
        Else
            wDT.Rows.Add(0, "No se han encontrado bodegas. " & wLocal, Nothing)
        End If

        Return wDT
    End Function




    <WebMethod(MessageName:="Consultar_Articulos", Description:="")>
    Public Function ConsultarArticulos(wIdKey As String, wCliente As Double, wLocal As Double, wBodega As Double) As DataTable

        Dim wDT As New DataTable
        wDT.TableName = "ConsultarArticulos"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Stock", GetType(List(Of StockArticulo)))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", Nothing)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, Nothing)
            Return wDT
        End If

        If Not ValidarNum(wBodega, False, 0) Then
            wDT.Rows.Add(0, "Bodega inválida", Nothing)
            Return wDT
        End If

        If Not ValidarNum(wLocal, False, 0) Then
            wDT.Rows.Add(0, "Error en el local. " & wLocal, Nothing)
            Return wDT
        End If

        Dim wStock = New List(Of StockArticulo)
        Dim wStockBodega = wDC.Stocks.Where(Function(x) x.Bodega = wBodega And x.Local = wLocal And x.Articulo <> "0").ToList
        Dim wArticulos = wDC.Articulos.ToList
        Dim wUnidades = wDC.Unidades.ToList

        For Each Art In wArticulos
            Dim wStk = New StockArticulo
            wStk.Articulo = Art.Articulo
            wStk.Descripcion = Art.Descripcion
            wStk.PrecioVenta = Art.PVenta
            Dim wStockArt = wStockBodega.FirstOrDefault(Function(x) x.Articulo = Art.Articulo)
            Dim wUnidad = wUnidades.FirstOrDefault(Function(x) x.Unidad = Art.Unidad)
            If wUnidad Is Nothing Then
                wStk.UnidadMedida = ""
            Else
                wStk.UnidadMedida = wUnidad.DescUnidad
            End If
            If wStockArt Is Nothing Then
                wStk.CantidadStock = 0
            Else
                wStk.CantidadStock = wStockArt.Stock
            End If
            If Art.Estado = "A" Then wStock.Add(wStk)
        Next

        wDT.Rows.Add(1, "Stock encontrado", wStock)
        Return wDT
    End Function


    <WebMethod(MessageName:="Consultar_Precios_ZPL", Description:="")>
    Public Function ConsultarPreciosZPL(wIdKey As String, wCliente As Double) As DataTable

        Dim wDT As New DataTable
        wDT.TableName = "ConsultarArticulos"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Precios", GetType(String))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", "")
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, "")
            Return wDT
        End If

        wDT.Rows.Add(1, "Precios encontrados.", Stock.Generar_Lista_Precios_ZPL)

        Return wDT

    End Function

    <WebMethod(MessageName:="Consultar_Stock_ZPL", Description:="")>
    Public Function ConsultarStockZPL(wIdKey As String, wCliente As Double, wLocal As Double, wBodega As Double) As DataTable

        Dim wDT As New DataTable
        wDT.TableName = "ConsultarArticulos"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Stock", GetType(String))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", "")
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, "")
            Return wDT
        End If

        If Not ValidarNum(wBodega, False, 0) Then
            wDT.Rows.Add(0, "Bodega inválida", "")
            Return wDT
        End If

        If Not ValidarNum(wLocal, False, 0) Then
            wDT.Rows.Add(0, "Error en el local. " & wLocal, "")
            Return wDT
        End If

        If Not ValidarNum(wBodega, False, 0) Then
            wDT.Rows.Add(0, "Error en la bodega. " & wBodega, "")
            Return wDT
        End If

        wDT.Rows.Add(1, "Stock encontrado.", Stock.Generar_Stocks_ZPL(wBodega, wLocal))

        Return wDT

    End Function


    '<WebMethod(MessageName:="Consulta_Stock", Description:="")>
    'Public Function ConsultaStock(wIdKey As String, wCliente As Double, wLocal As Double, wBodega As Double, wArticulo As String) As DataTable
    '    Return New DataTable

    '    'Consultar Stock de Artículo

    'End Function

    <WebMethod(MessageName:="Consultar_Clientes", Description:="")>
    Public Function ConsultarClientes(wIdKey As String, wCliente As Double) As DataTable

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Correlativo", GetType(List(Of DatosCliente)))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wListaClientes As New List(Of DatosCliente)

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", 0)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, 0)
            Return wDT
        End If

        Dim wComunas = wDC.Comunas.ToList
        Dim wCiudades = wDC.Ciudades.ToList
        Dim wClientes = wDC.Clientes.ToList

        For Each wCli In wClientes
            Dim wDatosCliente As New DatosCliente

            wDatosCliente.Cliente = wCli.Cliente
            wDatosCliente.RazonSocial = wCli.Nombre
            wDatosCliente.Rut = wCli.Rut
            Dim Ciudad = wCiudades.FirstOrDefault(Function(x) x.Ciudad = wCli.Ciudad)
            Dim Comuna = wComunas.FirstOrDefault(Function(x) x.Ciudad = wCli.Comuna)
            wDatosCliente.Ciudad = wCli.Ciudad
            wDatosCliente.NombreCiudad = Ciudad.NombreCiudad
            wDatosCliente.Direccion = wCli.Direccion
            wDatosCliente.Email = wCli.Email

            wListaClientes.Add(wDatosCliente)
        Next

        wDT.Rows.Add(1, "Clientes encontrados", wListaClientes)

        Return wDT
    End Function


    <WebMethod(MessageName:="Ingresar_Cliente", Description:="")>
    Public Function IngresarCliente(wIdKey As String, wCliente As Double, wClienteRef As Double, wRut As String, wRazonSocial As String, wFantasia As String,
                                    wDireccion As String, wCiudad As String, wComuna As String, wGiro As String, wEmail As String, wNuevo As Boolean) As DataTable

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("IdCliente", GetType(Integer))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wComunas = wDC.Comunas.ToList
        Dim wCiudades = wDC.Ciudades.ToList
        Dim wClientes = wDC.Clientes.ToList

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", 0)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, 0)
            Return wDT
        End If

        If Not ValidarTexto(wRazonSocial, 200, False, "") Then
            wDT.Rows.Add(0, "Error en la Razón Social. " & wRazonSocial, 0)
            Return wDT
        End If

        If Not ValidarTexto(wFantasia, 50, False, "") Then
            wDT.Rows.Add(0, "Error en la fantasía. " & wFantasia, 0)
            Return wDT
        End If

        wRut = FormatoRut(wRut)

        If Not ValidarRut(wRut) Then
            wDT.Rows.Add(0, "Rut inválido. " & wRut, 0)
            Return wDT
        End If

        If Not ValidarTexto(wDireccion, 255, False, "") Then
            wDT.Rows.Add(0, "Error en la Dirección. " & wDireccion, 0)
            Return wDT
        End If

        If Not ValidarTexto(wCiudad, 3, False, "") Then
            wDT.Rows.Add(0, "Error en la Ciudad. " & wCiudad, 0)
            Return wDT
        End If

        If Not wCiudades.Any(Function(x) x.Ciudad = wCiudad) Then
            wDT.Rows.Add(0, "Ciudad no encontrada. " & wCiudad, 0)
            Return wDT
        End If

        If Not ValidarTexto(wComuna, 3, False, "") Then
            wDT.Rows.Add(0, "Error en la Comuna. " & wComuna, 0)
            Return wDT
        End If

        If Not wComunas.Any(Function(x) x.Comuna = wComuna) Then
            wDT.Rows.Add(0, "Comuna no encontrada. " & wComuna, 0)
            Return wDT
        End If

        If Not ValidarTexto(wGiro, 100, False, "") Then
            wDT.Rows.Add(0, "Error en el Giro. " & wGiro, 0)
            Return wDT
        End If

        If Not ValidarEmail(wEmail) Then
            wDT.Rows.Add(0, "Email inválido. " & wEmail, 0)
            Return wDT
        End If

        Dim wOperacion = "ingresado"
        Dim wNuevoCliente As New Clientes

        If wClientes.Any(Function(x) x.Cliente <> wClienteRef And x.Rut <> wRut And x.Fantasia = wFantasia) Then
            wDT.Rows.Add(0, "Ya existe un cliente con esta fantasía.", 0)
            Return wDT
        End If

        If wNuevo Then

            If wClientes.Any(Function(x) x.Nombre = wRazonSocial) Then
                wDT.Rows.Add(0, "Ya existe un cliente con este nombre.", 0)
                Return wDT
            End If

            If wClientes.Any(Function(x) x.Rut = wRut And x.Direccion = wDireccion) Then
                wDT.Rows.Add(0, "Ya existe un cliente con esta dirección.", 0)
                Return wDT
            End If

            Dim Ultimo = wDC.Clientes.OrderByDescending(Function(x) x.Cliente).FirstOrDefault
            If Ultimo IsNot Nothing Then
                wNuevoCliente.Cliente = Ultimo.Cliente + 1
            Else
                wNuevoCliente.Cliente = 1
            End If

        Else
            wOperacion = "modificado"

            If Val(wClienteRef) = 0 Then
                wDT.Rows.Add(0, "Cliente de referencia inválido.", 0)
                Return wDT
            End If

            Dim CLIRef = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wClienteRef)
            If CLIRef Is Nothing Then
                wDT.Rows.Add(0, "Cliente de referencia no encontrado. " & wCliente, 0)
                Return wDT
            End If

            wNuevoCliente = CLIRef

            If wClientes.Any(Function(x) x.Rut <> wRut And x.Nombre = wRazonSocial) Then
                wDT.Rows.Add(0, "Ya existe otro cliente con este nombre.", 0)
                Return wDT
            End If

            If wClientes.Any(Function(x) x.Cliente <> wClienteRef And x.Rut = wRut And x.Direccion = wDireccion) Then
                wDT.Rows.Add(0, "Ya existe un cliente con esta dirección.", 0)
                Return wDT
            End If

        End If

        'If wClientes.Any(Function(x) x.Rut = wRut) Then
        '    wDT.Rows.Add(0, "Ya existe un cliente con este Rut.", 0)
        '    Return wDT
        'End If

        wNuevoCliente.Rut = wRut
        wNuevoCliente.Nombre = wRazonSocial
        wNuevoCliente.Ciudad = wCiudad
        wNuevoCliente.Comuna = wComuna
        wNuevoCliente.Giro = wGiro
        wNuevoCliente.Direccion = wDireccion
        wNuevoCliente.Email = wEmail
        wNuevoCliente.Fantasia = wFantasia
        wNuevoCliente.Estado = "A"
        wNuevoCliente.MaxDescuento = 0
        wNuevoCliente.Proveedor = False
        wNuevoCliente.Telefonos = ""
        wNuevoCliente.Tipo = ""
        wNuevoCliente.Vencimiento = 30
        wNuevoCliente.CupoMax = 0
        wNuevoCliente.Comision = 0
        wNuevoCliente.Contacto = ""

        If wNuevo Then
            wDC.Clientes.InsertOnSubmit(wNuevoCliente)
        End If

        wDC.SubmitChanges()

        wDT.Rows.Add(1, "Cliente " & wOperacion & " correctamente", wNuevoCliente.Cliente)

        Return wDT
    End Function


    <WebMethod(MessageName:="Anular_Documento", Description:="")>
    Public Function AnularDocumento(wIdKey As String, wCliente As Double, wLocal As Integer, wTipoDoc As String, wNumero As Double, wFechaAnulacion As DateTime, wMotivo As String) As DataTable

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Double))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("TipoDoc", GetType(String))
        wDT.Columns.Add("Correlativo", GetType(Integer))
        wDT.Columns.Add("TotalAnulado", GetType(String))
        wDT.Columns.Add("formaPago", GetType(String))

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)


        Dim wTiposDOc = wDC.TipoDoc.ToList

        Dim wNumDocAnulacion As Double = 0
        Dim wTipoDocAnulacion As String = ""
        Dim wTotalAnulado As Double = 0
        Dim wFormaPago As String = ""

        Dim wStep As Double = 0

        Try

            wStep = 1

            If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
                wDT.Rows.Add(0, "Cliente Inválido.", "", 0, 0, "")
                Return wDT
            End If

            wStep = 2

            If Not Parametros_DTE(wLocal) Then
                wDT.Rows.Add(0, "Error al obtener parámetros del Local.", "", 0, 0, "")
                Return wDT
            End If

            wStep = 3

            Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
            If DocG Is Nothing Then
                wDT.Rows.Add(0, "Documento no encontrado.", "", 0, 0, "")
                Return wDT
            End If
            'Validación de documento aprobado antes de Anular

            If DocG.STATUS_DTE = 0 Or DocG.STATUS_DTE = 2 Or DocG.STATUS_DTE = 9 Then
                wDT.Rows.Add(0, "No se puede anular un documento que no está aprobado por SII.", "", 0, 0, "")
                Return wDT
            End If

            Dim wListaDetalle = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero).ToList
            If Not wListaDetalle.Any Then
                wDT.Rows.Add(0, "Error al obtener el detalle de documento", "", 0, 0, "")
                Return wDT
            End If

            Dim wListaPagos = wDC.DocumentosP.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero).ToList
            If Not wListaPagos.Any Then
                wDT.Rows.Add(0, "Error al obtener el detalle de pagos", "", 0, 0, "")
                Return wDT
            End If

            Dim wListaVentas = wDC.Ventas.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.NumDoc = wNumero).ToList
            If Not wListaVentas.Any Then
                wDT.Rows.Add(0, "Error al obtener el detalle de venta", "", 0, 0, "")
                Return wDT
            End If

            Dim TipoDoc = wTiposDOc.FirstOrDefault(Function(x) x.TipoDoc = DocG.TipoDoc)
            If TipoDoc Is Nothing Then
                wDT.Rows.Add(0, "El Tipo de Documento es inválido.", "", 0, 0, "")
                Return wDT
            End If

            Dim wCorrelativo = Correlativo(ModoCorrelativo.ConsultarEstablecer, wLocal, TipoDoc.Anula, wFechaAnulacion, 0)
            wNumDocAnulacion = wCorrelativo.Item1
            If wNumDocAnulacion = 0 Then
                wDT.Rows.Add(0, wCorrelativo.Item2, "", 0, 0, "")
                Return wDT
            End If

            Dim DocAnul = wDC.DocumentosG.FirstOrDefault(Function(x) x.TipoDoc = TipoDoc.Anula And x.Numero = wNumDocAnulacion)
            If DocAnul IsNot Nothing Then
                wDT.Rows.Add(0, "El Documento ya fue Ingresado en el Sistema. Intente nuevamente.", "", 0, 0, "")
                Return wDT
            End If

            If TipoDoc.Anula.Trim = "" Then
                wDT.Rows.Add(0, "El Documento ingresado no es anulable.", "", 0, 0, "")
                Return wDT
            End If

            DocAnul = DocG.Clonar()
            DocAnul.Numero = wNumDocAnulacion
            DocAnul.TipoDoc = TipoDoc.Anula

            wTipoDocAnulacion = TipoDoc.Anula
            wTotalAnulado = DocG.Total
            wFormaPago = DocG.FPago

            DocAnul.TipoDocReferencia = DocG.TipoDoc
            DocAnul.NumDocReferencia = DocG.Numero
            DocAnul.FechaDocReferencia = DocG.Fecha
            DocAnul.Motivo = wMotivo

            DocAnul.STATUS_DTE = 0

            wDC.DocumentosG.InsertOnSubmit(DocAnul)

            Dim wListaDetalleAnul = New List(Of DocumentosD)
            For Each wItem As DocumentosD In wListaDetalle
                Dim wNuevo = wItem.Clonar
                wNuevo.Numero = wNumDocAnulacion
                wNuevo.TipoDoc = DocAnul.TipoDoc
                wListaDetalleAnul.Add(wNuevo)
                If wItem.Articulo <> "0" Then
                    Stock.Stocks(Trim(wItem.Articulo), DocG.Bodega, wLocal, wItem.Cantidad, Operacion.Sumar)
                End If
            Next

            wDC.DocumentosD.InsertAllOnSubmit(wListaDetalleAnul)

            Dim wListaPagosAnul = New List(Of DocumentosP)
            For Each wItem In wListaPagos
                Dim wNuevo = wItem.Clonar
                wNuevo.Numero = wNumDocAnulacion
                wNuevo.TipoDoc = DocAnul.TipoDoc
                wListaPagosAnul.Add(wNuevo)
            Next

            wDC.DocumentosP.InsertAllOnSubmit(wListaPagosAnul)

            Dim wListaVentasAnul = New List(Of Ventas)
            For Each wItem In wListaVentas
                Dim wNuevo = wItem.Clonar
                wNuevo.NumDoc = wNumDocAnulacion
                wNuevo.TipoDoc = DocAnul.TipoDoc
                wNuevo.SubTotal = wNuevo.SubTotal * -1
                wNuevo.Total = wNuevo.Total * -1
                wNuevo.Descuento = wNuevo.Descuento * -1
                wListaVentasAnul.Add(wNuevo)
            Next

            wDC.Ventas.InsertAllOnSubmit(wListaVentasAnul)

            wDC.SubmitChanges()
            wDC.Refresh(Data.Linq.RefreshMode.OverwriteCurrentValues)

        Catch ex As Exception
            Log(wCliente, ex, Nothing, "EmitirDocumento " & "Step: " & wStep)
            wDT.Rows.Add(0, wStep & " Excepción al intentar guardar: " & ex.ToString, wTipoDocAnulacion, wNumDocAnulacion, 0, "")
            Return wDT
        End Try

        wDT.Rows.Add(1, "Documento anulado", wTipoDocAnulacion, wNumDocAnulacion, wTotalAnulado, wFormaPago)

        Return wDT

    End Function


    <WebMethod(MessageName:="Emitir_Documento", Description:="")>
    Public Function EmitirDocumento(wIdKey As String, wClienteEmisor As String, wPOS As Double, wCaja As Double, wUsuario As String, wVendedor As String, wLocal As Double,
                                    wTipoDoc As String, wNumero As Double, wFecha As DateTime, wElectronico As Boolean,
                                    wTipoDocRef As String, wNumDocRef As Double, wFechaDocRef As DateTime,
                                    wClienteRef As Double, wBodega As String, wFormaPago As String, wObservacion As String, wMotivo As String,
                                    wSubTotal As Double, wNeto As Double, wDescuento As Double, wIVA As Double, wTotal As Double,
                                    xMIN As Double, xBEB As Double, xVIN As Double, xCER As Double, xLIC As Double,
                                    xCAR As Double, xHAR As Double, xTAB As Double, xFEP As Double, xOTRO As Double, wDetalle As String) As DataTable ', wDetalle As String) As DataTable

        Dim wRutRef As String = "00.000.000-0"

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Double))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Correlativo", GetType(Integer))

        Dim wCliente = Val(wClienteEmisor)

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)
        Dim wArticulos = wDC.Articulos.ToList()
        Dim wFPagos = wDC.FPagos.ToList()

        Dim wStep As Double = 0

        GuardarUltimoEvento(wClienteEmisor, "Emitir Documento " & wTipoDoc & " " & wNumero & " Cli: " & wCliente, "")

        Try

            wStep = 1

            If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
                wDT.Rows.Add(0, "Cliente Inválido.", 0)
                Return wDT
            End If

            wStep = 2

            If Not Parametros_DTE(wLocal) Then
                wDT.Rows.Add(0, "Error al obtener parámetros del Local.", 0)
                Return wDT
            End If

            wStep = 3

            Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
            If CLI Is Nothing Then
                wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, 0)
                Return wDT
            End If

            wStep = 4

            Dim CLIRef = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wClienteRef)
            If CLIRef Is Nothing Then
                wDT.Rows.Add(0, "Cliente de Referencia no encontrado.", 0)
                Return wDT
            End If

            Dim wFPagoRef = wFPagos.FirstOrDefault(Function(x) x.FPago.Trim = wFormaPago.Trim)
            If wFPagoRef Is Nothing Then
                wDT.Rows.Add(0, "Forma de pago inválida", 0)
                Return wDT
            End If

            If Not ValidarNum(wBodega, False, 0) Then
                wDT.Rows.Add(0, "Bodega inválida", 0)
                Return wDT
            End If

            wStep = 5

            If wDetalle = "" Then
                wDT.Rows.Add(0, "No existe un detalle para el documento.", 0)
                Return wDT
            End If

            Dim Usuario = wDC.Usuarios.FirstOrDefault(Function(x) x.Usuario = wUsuario)
            If Usuario Is Nothing Then
                wDT.Rows.Add(0, "Error al identificar el usuario " & wUsuario, 0)
                Return wDT
            End If

            Dim Vendedor = wDC.Usuarios.FirstOrDefault(Function(x) x.Usuario = wVendedor)
            If Vendedor Is Nothing Then
                wDT.Rows.Add(0, "Error al identificar el vendedor " & wVendedor, 0)
                Return wDT
            End If

            Dim wMotivos = wDC.Motivos.ToList
            If Not wMotivos.Any(Function(x) x.Motivo = wMotivo.Trim) Then
                wMotivo = "X"
            End If

            wRutRef = CLIRef.Rut

            Dim wDocumentoElectronico = False

            wStep = 6

            'Correlativo
            Dim wCorrelativo = Correlativo(ModoCorrelativo.ConsultarEstablecer, wLocal, wTipoDoc, wFecha, 0)
            wNumero = wCorrelativo.Item1
            Dim wFechaCaF As String = wCorrelativo.Item3

            Dim wFechaCorrelativo As Date = Date.Parse(wFechaCaF)
            Dim wFechaActual As Date = Now

            Dim wDiferenciaMes As Long = DateDiff(DateInterval.Month, wFechaCorrelativo, wFechaActual)
            Dim wDiasDiferencia As String = DiferencialDias(wFechaCaF, wFechaActual)
            If wDiferenciaMes = 6 Then
                If wDiasDiferencia = 0 Then
                    wDT.Rows.Add(0, "Caf vencidos, no se puede obtener correlativo para el documento.", 0)
                    Return wDT
                End If
            ElseIf wDiferenciaMes > 6 Then
                wDT.Rows.Add(0, "Caf vencidos, no se puede obtener correlativo para el documento.", 0)
                Return wDT
            End If
            If wNumero = 0 Then
                wDT.Rows.Add(0, wCorrelativo.Item2, 0)
                Return wDT
            End If

            'wDT.Rows.Add(wStep, "DIE DIE DIE", 0)
            'Return wDT

            wStep = 7

            'Verificar Documento Repetido
            Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
            If DocG IsNot Nothing Then
                wDT.Rows.Add(0, "El Documento ya fue Ingresado en el Sistema. Intente nuevamente.", 0)
                Return wDT
            End If

            Dim ObjDetalle = Funciones.DeserializarXML(Of Detalle)(wDetalle)

            If ObjDetalle Is Nothing Then
                wDT.Rows.Add(0, "El Detalle del documento es inválido.", 0)
                GuardarUltimoEvento(wCliente, wDetalle, "")
                Return wDT
            End If

            If Not ObjDetalle.DetalleDocumento.Any Then
                wDT.Rows.Add(0, "El Detalle del documento se encuentra vacío.", 0)
                Return wDT
            End If

            If ObjDetalle.DetalleDocumento.Count <> ObjDetalle.DetalleDocumento.Select(Function(x) x.Articulo).Distinct.Count Then
                wDT.Rows.Add(0, "El Detalle del documento contiene artículos repetidos. " & ObjDetalle.DetalleDocumento.Count & " <> " & ObjDetalle.DetalleDocumento.Select(Function(x) x.Articulo).Distinct.Count, 0)
                Return wDT
            End If


            If P_CONTROL_STOCK Then
                For Each wItem In ObjDetalle.DetalleDocumento
                    If Stock.ConsultarStock(wItem.Articulo, wBodega, wLocal) < wItem.Cantidad Then
                        wDT.Rows.Add(0, "No hay stock suficiente para el artículo: " & wItem.Articulo, 0)
                        Return wDT
                    End If
                Next
            End If

            For Each wItem In ObjDetalle.DetalleDocumento
                wItem.Articulo = wItem.Articulo.Trim
                Dim wArt = wArticulos.FirstOrDefault(Function(x) x.Articulo.Trim = wItem.Articulo)
                If wArt Is Nothing Then
                    wArt = wArticulos.FirstOrDefault(Function(x) x.SKU.Trim = wItem.Articulo)
                    If wArt IsNot Nothing Then
                        wItem.Articulo = wArt.SKU.Trim
                    Else
                        wDT.Rows.Add(0, "No existe el artículo: " & wItem.Articulo, 0)
                        Return wDT
                    End If
                End If
            Next

            wStep = 8

            DocG = New DocumentosG()

            If FE_EsElectronica Then
                If Es_Electronico(wTipoDoc) Then
                    DocG.DTE = True
                    wDocumentoElectronico = True
                Else
                    DocG.DTE = False
                End If
            End If

            wStep = 9

            DocG.Local = wLocal
            DocG.TipoDoc = wTipoDoc
            DocG.Numero = Val(wNumero)
            DocG.Electronica = wElectronico
            DocG.Fecha = wFecha
            DocG.Estado = "A"
            DocG.Bodega = wBodega
            DocG.Cliente = wClienteRef
            DocG.Rut = wRutRef
            DocG.Aprobado = True
            DocG.FPago = wFormaPago
            DocG.Observaciones = If(String.IsNullOrEmpty(wObservacion.Trim), "sin observación", wObservacion.Trim)
            DocG.Usuario = wUsuario
            DocG.Vendedor = wVendedor
            DocG.SubTotal = wSubTotal
            DocG.Descuento = wDescuento
            DocG.OC = 0
            DocG.Ticket = 0

            If wTipoDocRef = "OC" Then
                DocG.OC = wNumDocRef
            End If

            DocG.Motivo = If(String.IsNullOrEmpty(wMotivo.Trim), "sin motivo", wMotivo.Trim)
            DocG.Neto = wNeto
            DocG.IVA = wIVA
            DocG.iMIN = xMIN
            DocG.iBEB = xBEB
            DocG.iVIN = xVIN
            DocG.iCER = xCER
            DocG.iLIC = xLIC
            DocG.iCAR = xCAR
            DocG.iHAR = xHAR
            DocG.iTAB = xTAB
            DocG.iFEP = xFEP
            DocG.iOTRO = xOTRO
            DocG.Total = wTotal
            DocG.POS = wPOS
            DocG.StockTraspasado = False

            If String.IsNullOrEmpty(wTipoDocRef) Then
                DocG.TipoDocReferencia = ""
                DocG.NumDocReferencia = 0
                DocG.FechaDocReferencia = CDate("01/01/2000")
            Else
                DocG.TipoDocReferencia = wTipoDocRef
                DocG.NumDocReferencia = wNumDocRef
                DocG.FechaDocReferencia = wFechaDocRef
            End If

            DocG.RutTransporte = "00.000.000-0"
            DocG.NombreTransporte = ""
            DocG.RutChofer = "00.000.000-0"
            DocG.NombreChofer = ""
            DocG.PatenteMovil = ""
            DocG.STATUS_DTE = 0

            wDC.DocumentosG.InsertOnSubmit(DocG)

            wStep = 10



            If wFormaPago <> "V" Then

                Dim wDocP = New DocumentosP()

                wDocP.Banco = "000"
                wDocP.Cliente = wClienteRef
                wDocP.Cuenta = ""

                If wFormaPago = "E" Then
                    wDocP.Estado = "C"
                    wDocP.Fecha = wFecha
                    wDocP.FechaCanc = Now.Date
                    wDocP.FechaPago = Now.Date
                    wDocP.Obs = "PAGO EFECTIVO"
                Else
                    wDocP.Estado = "P"
                    wDocP.Fecha = wFecha
                    wDocP.FechaCanc = New Date(2000, 1, 1)
                    wDocP.FechaPago = wFecha.AddMonths(1)
                    wDocP.Obs = ""
                End If

                wDocP.FPago = wFormaPago
                wDocP.Local = wLocal
                wDocP.Monto = wTotal
                wDocP.Numero = wNumero
                wDocP.NumeroPago = 0
                wDocP.TipoDoc = wTipoDoc
                wDocP.Titular = ""
                wDocP.Usuario = wUsuario
                wDocP.Vendedor = wVendedor

                wDC.DocumentosP.InsertOnSubmit(wDocP)

            End If

            wStep = 11

            wDC.SubmitChanges()

            For Each wItem In ObjDetalle.DetalleDocumento

                wDC.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues)

                Dim wDocD = New DocumentosD()

                wDocD.Local = wLocal
                wDocD.TipoDoc = wTipoDoc
                wDocD.Numero = wNumero
                wDocD.Articulo = wItem.Articulo
                wDocD.Cantidad = wItem.Cantidad
                wDocD.Neto = wItem.Neto
                wDocD.Glosa = If(String.IsNullOrEmpty(wItem.Descripcion), "", wItem.Descripcion)
                wDocD.IVA = wItem.IVA
                wDocD.iMIN = xMIN
                wDocD.iBEB = xBEB
                wDocD.iVIN = xVIN
                wDocD.iCER = xCER
                wDocD.iLIC = xLIC
                wDocD.iCAR = xCAR
                wDocD.iHAR = xHAR
                wDocD.iTAB = xTAB
                wDocD.iFEP = xFEP
                wDocD.iOTRO = xOTRO
                wDocD.PVenta = wItem.PrecioVenta

                If wItem.Articulo = "0" Then
                    wDocD.Glosa = wItem.Descripcion
                End If

                wDC.DocumentosD.InsertOnSubmit(wDocD)

                If P_CONTROL_STOCK Then
                    'Actualizar Stocks
                    If wItem.Articulo <> "0" Then
                        Stock.Stocks(Trim(wItem.Articulo), wBodega, wLocal, wItem.Cantidad, Operacion.Restar)
                    End If
                End If

                wDC.SubmitChanges()

            Next

            wStep = 12

            If wTipoDoc = "FV" Or wTipoDoc = "BV" Then
                'Actualizar Ventas
                Dim wVen = New Ventas()

                wVen.Ticket = wNumDocRef
                wVen.Fecha = Now
                wVen.Usuario = wVendedor
                wVen.Local = wLocal
                wVen.Caja = wCaja
                wVen.TipoDoc = wTipoDoc
                wVen.NumDoc = wNumero
                wVen.FPago = wFormaPago
                wVen.SubTotal = wNeto
                wVen.Descuento = wDescuento
                wVen.Total = wTotal

                wDC.Ventas.InsertOnSubmit(wVen)
            End If
            wDC.SubmitChanges()

        Catch ex As Exception
            Log(wCliente, ex, Nothing, "EmitirDocumento " & "Step: " & wStep)
            wDT.Rows.Add(0, wStep & " Excepción al intentar guardar: " & ex.ToString, wNumero)
            Return wDT
        End Try

        wDT.Rows.Add(1, "Documento guardado", wNumero)
        Return wDT
    End Function



    '<WebMethod(MessageName:="Cuadratura_Venta", Description:="")>
    'Public Function CuadraturaVenta() As DataTable
    '    Return New DataTable
    'End Function
    '<WebMethod(MessageName:="Cargar_Productos", Description:="")>
    'Public Function CargarProductos() As DataTable
    '    Return New DataTable
    'End Function
    '<WebMethod(MessageName:="Cargar_CAF", Description:="")>
    'Public Function CargarCAF() As DataTable
    '    Return New DataTable
    'End Function
    '<WebMethod(MessageName:="Cargar_Correlativos", Description:="")>
    'Public Function CargarCorrelativos() As DataTable
    '    Return New DataTable
    'End Function

    <WebMethod(MessageName:="Enviar_Documentos_DTE", Description:="")>
    Public Function EnviarDocumentosDTE(wIdKey As String, wCliente As Double, wLocal As Integer, wTipoDoc As String, wNumero As Double) As DataTable

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", 0)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, 0)
            Return wDT
        End If

        If Not Parametros_DTE(wLocal) Then
            wDT.Rows.Add(0, "Error al obtener parámetros del Local.")
            Return wDT
        End If

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
        If DocG Is Nothing Then
            wDT.Rows.Add(0, "Documento no encontrado.")
            Return wDT
        End If

        If Not Emitir_DTE(wLocal, wTipoDoc, wNumero) Then
            wDT.Rows.Add(0, "Error al enviar documento.")
            Return wDT
        End If

        wDT.Rows.Add(1, "Envio exitoso")
        Return wDT
    End Function


    <WebMethod(MessageName:="Consultar_Documentos", Description:="")>
    Public Function ConsultarDocumentos(wIdKey As String, wCliente As Double, wFechaIni As DateTime, wFechaFin As DateTime, wTipoDoc As String) As DataTable

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Documentos", GetType(ListadoDocumentos))

        Dim wTiposDoc = wDC.TipoDoc.ToList
        Dim wMotivos = wDC.Motivos.ToList
        Dim wClientes = wDC.Clientes.ToList

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", Nothing)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, Nothing)
            Return wDT
        End If

        Dim qDocG = wDC.DocumentosG.Where(Function(x) x.Fecha >= wFechaIni.Date & " 00:00:00" And x.Fecha <= wFechaFin.Date & " 23:49:49")
        If wTiposDoc.Any(Function(x) x.TipoDoc = wTipoDoc.Trim) Then
            qDocG = qDocG.Where(Function(x) x.TipoDoc = wTipoDoc.Trim)
        End If


        Dim ListadoDocumentos As New ListadoDocumentos
        ListadoDocumentos.Documentos = New List(Of DatosDocumento)

        For Each wDoc In qDocG.ToList

            ListadoDocumentos.Documentos.Add(New DatosDocumento With
                {
                    .Fecha = wDoc.Fecha,
                    .Cliente = wDoc.Cliente,
                    .NombreCliente = wClientes.DefaultIfEmpty(New Clientes With {.Nombre = ""}).FirstOrDefault(Function(x) x.Cliente = wDoc.Cliente).Nombre,
                    .RutCliente = wClientes.DefaultIfEmpty(New Clientes With {.Rut = ""}).FirstOrDefault(Function(x) x.Cliente = wDoc.Cliente).Rut,
                    .NumDoc = wDoc.Numero,
                    .TipoDoc = wDoc.TipoDoc.Trim,
                    .IVA = wDoc.IVA,
                    .Neto = wDoc.Neto,
                    .Total = wDoc.Total
                })
        Next

        wDT.Rows.Add(1, "Clientes encontrados.", ListadoDocumentos)
        Return wDT
    End Function

    <WebMethod(MessageName:="Obtener_Documento", Description:="")>
    Public Function ObtenerDocumento(wIdKey As String, wCliente As Double, wLocal As Integer,
                                     wTipoDoc As String, wNumero As Double, wModo As Integer) As DataTable

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("ZPL", GetType(String))

        Dim wParametros = wDC.Parametros.First
        Dim wComunas = wDC.Comunas.ToList
        Dim wCiudades = wDC.Ciudades.ToList
        Dim wTiposDoc = wDC.TipoDoc.ToList
        Dim wMotivos = wDC.Motivos.ToList
        Dim wLocales = wDC.Locales.ToList

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", 0)
            Return wDT
        End If

        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado. " & wCliente, 0)
            Return wDT
        End If

        If Not Parametros_DTE(wLocal) Then
            wDT.Rows.Add(0, "Error al obtener parámetros del Local.", "")
            Return wDT
        End If

        Dim wDatosLocal = wLocales.FirstOrDefault(Function(x) x.Local = wLocal)
        Dim wDatosParametros = wDC.Parametros.FirstOrDefault()

        If wDatosLocal Is Nothing OrElse wDatosParametros Is Nothing Then
            wDT.Rows.Add(0, "Error al obtener parámetros del Local.", "")
            Return wDT
        End If

        Dim G_CLAVE = wDatosParametros.Clave

        Dim wClienteEmisor = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
        If wClienteEmisor Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado.", "")
            Return wDT
        End If

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
        If DocG Is Nothing Then
            wDT.Rows.Add(0, "Documento no encontrado.", "")
            Return wDT
        End If

        Dim wClienteDoc = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
        If wClienteEmisor Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar Cliente de referencia.", "")
            Return wDT
        End If

        Dim CiudadEm = wCiudades.FirstOrDefault(Function(x) x.Ciudad = wDatosLocal.Ciudad)
        If CiudadEm Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar la ciudad del cliente emisor: " & wClienteEmisor.Ciudad, "")
            Return wDT
        End If

        Dim CiudadDoc = wCiudades.FirstOrDefault(Function(x) x.Ciudad = wClienteDoc.Ciudad)
        If CiudadDoc Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar la ciudad del cliente de referencia: " & wClienteDoc.Ciudad, "")
            Return wDT
        End If

        Dim ComunaDoc = wComunas.FirstOrDefault(Function(x) x.Comuna = wClienteDoc.Comuna)
        If ComunaDoc Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar la comuna del cliente de referencia: " & wClienteDoc.Comuna, "")
            Return wDT
        End If

        Dim TipoDoc = wDC.TipoDoc.FirstOrDefault(Function(x) x.TipoDoc = wTipoDoc)
        If TipoDoc Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar el tipo de documento " & wTipoDoc, "")
            Return wDT
        End If

        Dim FPago = wDC.FPagos.FirstOrDefault(Function(x) x.FPago = DocG.FPago)
        If FPago Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar la forma de pago " & DocG.FPago, "")
            Return wDT
        End If

        Dim Vendedor = wDC.Usuarios.FirstOrDefault(Function(x) x.Usuario = DocG.Vendedor)
        If Vendedor Is Nothing Then
            wDT.Rows.Add(0, "Error al identificar el vendedor " & DocG.Vendedor, "")
            Return wDT
        End If

        Dim Articulos = wDC.Articulos.ToList

        Dim wListaDocD = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero).ToList
        If Not wListaDocD.Any Then
            wDT.Rows.Add(0, "Error al obtener el detalle de documento", "")
            Return wDT
        End If

        Dim wEnc As New EncabezadoDocumento
        Dim wListaDet As New List(Of DetalleDocumento)

        wEnc.NombreDocumento = FormatoCaracteres(TipoDoc.DescTipoDoc)
        wEnc.TipoDoc = DocG.TipoDoc
        wEnc.NumDoc = DocG.Numero
        wEnc.CiudadEmisor = FormatoCaracteres(CiudadEm.NombreCiudad)
        wEnc.RazonSocialEmisor = FormatoCaracteres(wDatosLocal.RazonLocal)
        wEnc.DireccionEmisor = FormatoCaracteres(wDatosLocal.DirLocal)
        wEnc.FonoEmisor = wDatosLocal.TelefonosLocal
        wEnc.EmailEmisor = FormatoCaracteres(wDatosLocal.EMailLocal)
        wEnc.WebEmisor = ""
        wEnc.RazonSocial = FormatoCaracteres(wClienteDoc.Nombre)
        wEnc.Giro = FormatoCaracteres(wClienteDoc.Giro)
        wEnc.Rut = wClienteDoc.Rut
        wEnc.Direccion = FormatoCaracteres(wClienteDoc.Direccion)
        wEnc.NombreCiudad = FormatoCaracteres(CiudadDoc.NombreCiudad)
        wEnc.NombreComuna = FormatoCaracteres(ComunaDoc.NombreComuna)
        wEnc.Email = FormatoCaracteres(wClienteDoc.Email)
        wEnc.Telefonos = FormatoCaracteres(wClienteDoc.Telefonos)
        wEnc.FechaEmision = DocG.Fecha
        wEnc.FormaPago = FormatoCaracteres(FPago.DescFPago)
        wEnc.Vendedor = FormatoCaracteres(Vendedor.Usuario)
        wEnc.Neto = DocG.Neto
        wEnc.IVA = DocG.IVA
        wEnc.Total = DocG.Total
        wEnc.TED = DocG.TED
        wEnc.NumDocReferencia = DocG.NumDocReferencia
        Dim wDescTipoDoc = wTiposDoc.FirstOrDefault(Function(x) x.TipoDoc = DocG.TipoDocReferencia)
        wEnc.TipoDocReferencia = If(wDescTipoDoc Is Nothing, "", wDescTipoDoc.DescTipoDoc).Trim
        wEnc.FechaDocReferencia = FechaTexto(DocG.FechaDocReferencia)
        Dim wMotivoDoc = wMotivos.FirstOrDefault(Function(x) x.Motivo = DocG.Motivo)
        wEnc.Motivo = If(wMotivoDoc Is Nothing, "", wMotivoDoc.DescMotivo)

        For Each wItem In wListaDocD
            Dim wDet As New DetalleDocumento
            Dim wArt = Articulos.DefaultIfEmpty(New Articulos With {.Articulo = "0", .Descripcion = ""}).FirstOrDefault(Function(x) x.Articulo = wItem.Articulo)
            wDet.Articulo = FormatoCaracteres(wItem.Articulo)
            wDet.Descripcion = FormatoCaracteres(If(IsNothing(wArt), "", wArt.Descripcion))
            wDet.PrecioVenta = wItem.Neto
            wDet.Cantidad = wItem.Cantidad
            wDet.Total = wItem.Cantidad * wItem.Neto
            wListaDet.Add(wDet)
        Next

        Dim wLinea = 0


        Dim wLargo = 900 + (wListaDocD.Count * 40)
        If wModo = 3 Then wLargo += 150

        Dim CodigoZPL As String = ""


        CodigoZPL &= "^XA" & vbCrLf
        CodigoZPL &= "^PRD" & vbCrLf
        CodigoZPL &= "^FOI" & vbCrLf
        CodigoZPL &= "^LH0,0" & vbCrLf
        CodigoZPL &= "^LL" & wLargo & vbCrLf

        'Logo y Membrete
        CodigoZPL &= "^FO280,00^GB260,100,5^FS" & vbCrLf
        CodigoZPL &= "^FB300,1,,C,0^A0N20,20^FO260,20^FDRUT: " & FE_Rut_Emisor & "^FS" & vbCrLf
        CodigoZPL &= "^FB300,1,,C,0^A0N20,20^FO260,45^FD" & NombreDocumento(wEnc.TipoDoc) & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO370,70^FDN^FS" & vbCrLf
        CodigoZPL &= "^A0N10,10^FO382,65^FDo^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO460,70,1^FD" & wEnc.NumDoc & "^FS" & vbCrLf

        CodigoZPL &= "^A0N40,40^FO10,10^FD" & FormatoCaracteres(wParametros.Fantasia) & "^FS" & vbCrLf
        CodigoZPL &= "^A0N15,15^FO10,50^FD" & FormatoCaracteres(wParametros.Slogan) & "^FS" & vbCrLf
        CodigoZPL &= "^A0N25,25^FO10,115^FD" & FormatoCaracteres(FE_Razon_Social) & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,140^FD" & FormatoCaracteres(FE_Giro) & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,160^FD" & FE_Direccion & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,180^FD" & FE_Comuna & ", " & FE_Ciudad & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,200^FD" & FormatoCaracteres(wParametros.Email) & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO320,200^FD" & FormatoCaracteres(wParametros.Telefonos) & "^FS" & vbCrLf

        CodigoZPL &= "^FO10,225^GB620,1,1^FS" & vbCrLf

        'Datos del Receptor
        CodigoZPL &= "^A0N20,20^FO10,240^FDFecha Emision:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO370,240^FDF.Pago:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,260^FDSenores:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,280^FDR.U.T.:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO370,280^FDVendedor:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,300^FDGiro:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,320^FDDireccion:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,340^FDCiudad:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO370,340^FDComuna:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,360^FDCorreo:^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO370,360^FDTelefonos:^FS" & vbCrLf

        CodigoZPL &= "^A0N20,20^FO130,240^FD" & Format(wEnc.FechaEmision, "dd/MM/yyyy") & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO450,240^FD" & wEnc.FormaPago & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO130,260^FD" & wEnc.RazonSocial & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO130,280^FD" & wEnc.Rut & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO450,280^FD" & wEnc.Vendedor & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO130,300^FD" & wEnc.Giro & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO130,320^FD" & wEnc.Direccion & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO130,340^FD" & wEnc.NombreComuna & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO450,340^FD" & wEnc.NombreCiudad & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO130,360^FD" & wEnc.Email & "^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO450,360^FD" & wEnc.Telefonos & "^FS" & vbCrLf

        CodigoZPL &= "^FO10,380^GB620,1,1^FS" & vbCrLf

        'Titulos de Articulos
        CodigoZPL &= "^FO10,390^GB620,1,1^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO10,400^FDArticulo^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO300,400,1^FDCantidad^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO420,400,1^FDP.Unitario^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO540,400,1^FDTotal^FS" & vbCrLf

        CodigoZPL &= "^FO10,420^GB620,1,1^FS" & vbCrLf

        'Detalles de Articulos        
        wLinea = 430


        For Each wItem In wListaDet
            CodigoZPL &= "^A0N20,20^FO10," & Num(wLinea) & "^FD" & wItem.Descripcion & "^FS" & vbCrLf
            CodigoZPL &= "^A0N20,20^FO300," & Num(wLinea + 20) & ",1^FD" & Format(wItem.Cantidad, "###,###,##0.00") & "^FS" & vbCrLf
            CodigoZPL &= "^A0N20,20^FO420," & Num(wLinea + 20) & ",1^FD" & Format(wItem.PrecioVenta, "###,###,##0.00") & "^FS" & vbCrLf
            CodigoZPL &= "^A0N20,20^FO540," & Num(wLinea + 20) & ",1^FD" & Format(wItem.Total, "###,###,##0.00") & "^FS" & vbCrLf
            wLinea += 40
        Next

        'Totales
        wLinea += 40
        CodigoZPL &= "^FO10," & Num(wLinea) & "^GB620,1,1^FS" & vbCrLf
        wLinea += 10
        If G_CLAVE = "G" Then CodigoZPL += "^A0N20,20^FO10," & Num(wLinea) & "^FDTotal Cajas:  " & wListaDet.Sum(Function(x) x.Cantidad) & "^FS" + vbCrLf
        CodigoZPL &= "^A0N20,20^FO350," & Num(wLinea) & "^FDNETO $^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO540," & Num(wLinea) & ",1^FD" & Format(wEnc.Neto, "###,###,###") & "^FS" & vbCrLf
        wLinea += 20
        CodigoZPL &= "^A0N20,20^FO350," & Num(wLinea) & "^FDIVA $^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO540," & Num(wLinea) & ",1^FD" & Format(wEnc.IVA, "###,###,###") & "^FS" & vbCrLf
        wLinea += 20
        CodigoZPL &= "^A0N20,20^FO350," & Num(wLinea) & "^FDTOTAL $^FS" & vbCrLf
        CodigoZPL &= "^A0N20,20^FO540," & Num(wLinea) & ",1^FD" & Format(wEnc.Total, "###,###,###") & "^FS" & vbCrLf

        'Referencias
        If wEnc.NumDocReferencia > 0 Then
            wLinea += 40
            CodigoZPL &= "^A0N20,20^FO10," & wLinea & "^FDDOCUMENTO REFERENCIA:^FS"
            wLinea += 20
            CodigoZPL &= "^A0N20,20^FO10," & wLinea & "^FD" & FormatoTexto(wEnc.TipoDocReferencia) & ":  " & wEnc.NumDocReferencia & "  del  " & wEnc.FechaDocReferencia & "^FS"
            wLinea += 20
            CodigoZPL &= "^A0N20,20^FO10," & wLinea & "^FDMOTIVO: " & FormatoTexto(wEnc.Motivo) & "^FS"
        End If


        'Modos:  0=Sin Referencias, 1=Copia Cliente, 2=Control Tributario, 3=Cedible

        'Modo
        If wModo > 0 Then 'Sin referencia
            If wModo = 1 Then 'Cliente
                'No se imprime nada cuando la copia es para cliente
            End If
            If wModo = 2 Then 'Control Tributario
                wLinea += 40
                CodigoZPL &= "^A0N20,20,25^FO530," & wLinea & ",1^FD   ^FS"
            End If
            If wModo = 3 Then 'Cedible
                wLinea += 40
                CodigoZPL &= "^FO10," & wLinea & "^GB520,180,1^FS"
                wLinea += 120
                CodigoZPL &= "^FO10," & wLinea & "^GB520,1,1^FS"
                wLinea -= 110
                CodigoZPL &= "^A0N20,20^FO20," & wLinea & "^FDNombre:^FS"
                wLinea += 15
                CodigoZPL &= "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                CodigoZPL &= "^A0N20,20^FO20," & wLinea & "^FDRUT:^FS"
                wLinea += 15
                CodigoZPL &= "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                CodigoZPL &= "^A0N20,20^FO20," & wLinea & "^FDFecha:^FS"
                wLinea += 15
                CodigoZPL &= "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                CodigoZPL &= "^A0N20,20^FO20," & wLinea & "^FDRecinto:^FS"
                wLinea += 15
                CodigoZPL &= "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                CodigoZPL &= "^A0N20,20^FO20," & wLinea & "^FDFirma:^FS"
                wLinea += 15
                CodigoZPL &= "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5

                wLinea += 20
                CodigoZPL &= "^A0N10,10^FO20," & wLinea & "^FDEl acuse de recibo que se declara en este acto, de acuerdo a lo dispuesto en las letra b) del Art. 4   , y la ^FS"
                wLinea -= 5
                CodigoZPL &= "^A0N6,6^FO447," & wLinea & "^FDo^FS"
                wLinea += 20
                CodigoZPL &= "^A0N10,10^FO20," & wLinea & "^FDletra c) del Art. 5   de la Ley 19.983, acredita que la entrega de mercaderias o servicio(s) prestado(s) ^FS"
                wLinea -= 5
                CodigoZPL &= "^A0N6,6^FO92," & wLinea & "^FDo^FS"
                wLinea += 20
                CodigoZPL &= "^A0N10,10^FO20," & wLinea & "^FDha(n) sido recibido(s).^FS"
                wLinea += 30
                CodigoZPL &= "^A0N20,20,25^FO530," & wLinea & ",1^FDCEDIBLE^FS"
            End If
        End If

        'Timbre Electronico
        wLinea += 40
        CodigoZPL &= "^BY2,3" & vbCrLf
        CodigoZPL &= "^FO50," & Num(wLinea) & "^B7N,2,5,,83,N" & vbCrLf
        CodigoZPL &= "^FD" & wEnc.TED & "^FS" & vbCrLf
        wLinea += 190
        CodigoZPL &= "^A0N15,15^FO200," & Num(wLinea) & "^FDTimbre electronico SII^FS" & vbCrLf
        wLinea += 15
        CodigoZPL &= "^A0N15,15^FO100," & Num(wLinea) & "^FDRes. " & Num(FE_NResolucion) & " de " & Format(FE_FResolucion, "dd/MM/yyyy") & " - Verifique documento: www.sii.cl^FS" & vbCrLf
        CodigoZPL &= "^XZ" & vbCrLf


        wDT.Rows.Add(1, "Documento encontrado", CodigoZPL)

        Return wDT

    End Function

    Public Enum ModoDocumento
        SinReferencias = 0
        CopiaCliente = 1
        ControlTributario = 2
        Cedible = 3
    End Enum


    Public Function NombreDocumento(wTipoDoc As String) As String
        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wNombre = wTipoDoc

        Dim TipoDoc = wDC.TipoDoc.FirstOrDefault(Function(x) x.TipoDoc = wTipoDoc)
        If TipoDoc Is Nothing Then
            'LogTxt("NombreDocumento", wTipoDoc & " " & wNombre)
            Return wNombre
        End If

        If TipoDoc.Electronica Then
            If TipoDoc.Nombre_Documento.Trim <> "" Then
                wNombre = TipoDoc.Nombre_Documento.Trim
            Else
                wNombre = TipoDoc.DescTipoDoc.Trim
            End If
        Else
            wNombre = TipoDoc.DescTipoDoc.Trim
        End If

        'LogTxt("NombreDocumento", wTipoDoc & " " & wNombre & " " & TipoDoc.Electronica)
        Return wNombre

    End Function


    'Public Function ObtenerDocumento(wIdKey As String, wCliente As Double, wLocal As Integer,
    '                                 wTipoDoc As String, wNumero As Double) As DataTable

    '    Dim wDC As New BaseSisVenDataContext(P_CONEXION)

    '    Dim wDT As New DataTable
    '    wDT.TableName = "Respuesta"
    '    wDT.Columns.Add("Respuesta", GetType(Integer))
    '    wDT.Columns.Add("Mensaje", GetType(String))
    '    wDT.Columns.Add("Encabezado", GetType(List(Of EncabezadoDocumento)))
    '    wDT.Columns.Add("Detalle", GetType(List(Of DetalleDocumento)))

    '    Dim wParametros = wDC.Parametros.First

    '    If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
    '        wDT.Rows.Add(0, "Cliente Inválido.", Nothing, Nothing)
    '    End If

    '    If Not Parametros_DTE(wLocal) Then
    '        wDT.Rows.Add(0, "Error al sacar parámetros del Local.", Nothing, Nothing)
    '        Return wDT
    '    End If

    '    Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
    '    If DocG Is Nothing Then
    '        wDT.Rows.Add(0, "Documento no encontrado.", Nothing, Nothing)
    '        Return wDT
    '    End If

    '    Dim wClienteEmisor = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = wCliente)
    '    If wClienteEmisor Is Nothing Then
    '        wDT.Rows.Add(0, "Cliente no encontrado.", Nothing, Nothing)
    '        Return wDT
    '    End If

    '    Dim wClienteDoc = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
    '    If wClienteEmisor Is Nothing Then
    '        wDT.Rows.Add(0, "Error al identificar Cliente de referencia.", Nothing, Nothing)
    '        Return wDT
    '    End If

    '    Dim CiudadEm = wDC.Ciudades.FirstOrDefault(Function(x) x.Ciudad = wClienteEmisor.Ciudad)
    '    Dim CiudadDoc = wDC.Ciudades.FirstOrDefault(Function(x) x.Ciudad = wClienteDoc.Ciudad)
    '    Dim ComunaDoc = wDC.Comunas.FirstOrDefault(Function(x) x.Ciudad = wClienteDoc.Comuna)
    '    Dim TipoDoc = wDC.TipoDoc.FirstOrDefault(Function(x) x.TipoDoc = wTipoDoc)
    '    Dim FPago = wDC.FPagos.FirstOrDefault(Function(x) x.FPago = DocG.FPago)
    '    Dim Vendedor = wDC.Usuarios.FirstOrDefault(Function(x) x.Usuario = DocG.Usuario)
    '    Dim Articulos = wDC.Articulos.ToList

    '    Dim wListaDocD = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero).ToList
    '    If Not wListaDocD.Any Then
    '        wDT.Rows.Add(0, "Error al obtener el detalle de documento", Nothing, Nothing)
    '        Return wDT
    '    End If

    '    Dim wEnc As New EncabezadoDocumento
    '    Dim wListaDet As New List(Of DetalleDocumento)

    '    wEnc.NombreDocumento = FormatoCaracteres(TipoDoc.DescTipoDoc)
    '    wEnc.TipoDoc = DocG.TipoDoc
    '    wEnc.NumDoc = DocG.Numero
    '    wEnc.CiudadEmisor = FormatoCaracteres(CiudadEm.NombreCiudad)
    '    wEnc.RazonSocialEmisor = FormatoCaracteres(wClienteEmisor.Nombre)
    '    wEnc.DireccionEmisor = FormatoCaracteres(wClienteEmisor.Direccion)
    '    wEnc.FonoEmisor = wClienteEmisor.Telefonos
    '    wEnc.EmailEmisor = FormatoCaracteres(wClienteEmisor.Email)
    '    wEnc.WebEmisor = ""
    '    wEnc.RazonSocial = FormatoCaracteres(wClienteDoc.Nombre)
    '    wEnc.Giro = FormatoCaracteres(wClienteDoc.Giro)
    '    wEnc.Rut = wClienteDoc.Rut
    '    wEnc.Direccion = FormatoCaracteres(wClienteDoc.Direccion)
    '    wEnc.NombreCiudad = FormatoCaracteres(CiudadDoc.NombreCiudad)
    '    wEnc.NombreComuna = FormatoCaracteres(ComunaDoc.NombreComuna)
    '    wEnc.Email = FormatoCaracteres(wClienteDoc.Email)
    '    wEnc.Telefonos = FormatoCaracteres(wClienteDoc.Telefonos)
    '    wEnc.FechaEmision = DocG.Fecha
    '    wEnc.FormaPago = FormatoCaracteres(FPago.DescFPago)
    '    wEnc.Vendedor = FormatoCaracteres(Vendedor.NombreUsr)
    '    wEnc.Neto = DocG.Neto
    '    wEnc.IVA = DocG.IVA
    '    wEnc.Total = DocG.Total
    '    wEnc.TED = DocG.TED

    '    For Each wItem In wListaDocD
    '        Dim wDet As New DetalleDocumento
    '        Dim wArt = Articulos.DefaultIfEmpty(New Articulos With {.Articulo = "0", .Descripcion = ""}).FirstOrDefault(Function(x) x.Articulo = wItem.Articulo)
    '        wDet.Articulo = FormatoCaracteres(wItem.Articulo)
    '        wDet.Descripcion = FormatoCaracteres(wItem.Articulo)
    '        wDet.PrecioVenta = wItem.PVenta
    '        wDet.Cantidad = wItem.Cantidad
    '        wDet.Total = wItem.Cantidad * wItem.PVenta
    '        wListaDet.Add(wDet)
    '    Next


    '    wDT.Rows.Add(1, "Documento encontrado", {wEnc}.ToList, wListaDet)

    '    Return wDT

    'End Function



    <WebMethod(MessageName:="Consultar_Documento_DTE", Description:="")>
    Public Function ConsultarDocumentoDTE(wIdKey As String, wCliente As Double, wLocal As Integer, wTipoDoc As String, wNumero As Double) As DataTable

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("CodigoResultado", GetType(Integer))


        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", -1)
        End If

        If Not Parametros_DTE(wLocal) Then
            wDT.Rows.Add(0, "Error al sacar parámetros del Local.", -1)
            Return wDT
        End If

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
        If DocG Is Nothing Then
            wDT.Rows.Add(0, "Documento no encontrado.", -1)
            Return wDT
        End If


        Dim CLI = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
        If CLI Is Nothing Then
            wDT.Rows.Add(0, "Cliente no encontrado.", -1)
            Return wDT
        End If

        Dim wRespuesta = Consultar_DTE(1, wTipoDoc, wNumero)
        wDT.Rows.Add(1, wRespuesta.Item2, wRespuesta.Item1)

        wRespuesta = Consultar_DTE(1, wTipoDoc, wNumero)
        wDT.Rows.Add(2, wRespuesta.Item2, wRespuesta.Item1)

        wRespuesta = Consultar_DTE(1, wTipoDoc, wNumero)
        wDT.Rows.Add(3, wRespuesta.Item2, wRespuesta.Item1)

        Return wDT

    End Function

    <WebMethod(MessageName:="Emitir_TED", Description:="")>
    Public Function EmitirTED(wIdKey As String, wCliente As Double, wLocal As Integer, wTipoDoc As String, wNumero As Double) As DataTable

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wImagen As Byte() = Nothing
        Dim wXML As String = ""

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Timbre", GetType(String))

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", "")
            Return wDT
        End If

        If Not Parametros_DTE(wLocal) Then
            wDT.Rows.Add(0, "Error al sacar parámetros del Local.", "")
            Return wDT
        End If

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
        If DocG Is Nothing Then
            wDT.Rows.Add(0, "Documento no encontrado.", "")
            Return wDT
        End If

        Dim wDocumentoElectronico = False

        If FE_EsElectronica Then
            If Es_Electronico(wTipoDoc) Then
                DocG.DTE = True
                wDocumentoElectronico = True
            Else
                DocG.DTE = False
            End If
        End If

        'Facturación Electrónica

        Dim wStep = 0

        Try
            wStep = 1
            If Not wDocumentoElectronico Then
                wDT.Rows.Add(0, "El documento no tiene habilitada emisión electrónica.", "")
                Return wDT
            End If

            wStep = 2

            Dim Cliente = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
            If Cliente Is Nothing Then
                wDT.Rows.Add(0, "Error al identificar Cliente de referencia.", "")
                Return wDT
            End If

            wStep = 2

            Dim RUT_DTE = UCase(DocG.Rut).Replace("_", "").Replace(".", "")

            'Generar TED
            Dim wGlosa = ""

            wStep = 3

            Dim ListaDocD = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero).ToList
            If Not ListaDocD.Any Then
                wDT.Rows.Add(0, "Error al obtener el detalle de documento", "")
                Return wDT
            End If

            wStep = 4

            wGlosa = ListaDocD.First.Glosa

            wStep = 4.1

            If wGlosa.Trim = "" Then
                wStep = 4.2
                Dim Art = wDC.Articulos.FirstOrDefault(Function(x) x.Articulo = ListaDocD.First.Articulo.Trim)
                wStep = 4.3
                If Art IsNot Nothing Then
                    wStep = 4.4
                    wGlosa = Art.Descripcion.Trim
                Else
                    wStep = 4.5
                    wGlosa = "ARTICULO"
                End If
            End If

            wStep = 5

            Dim wResultadoGeneracion = Generar_TED(wCliente, wLocal, wTipoDoc, wNumero, DocG.Fecha, RUT_DTE, Cliente.Nombre.Trim, DocG.Total, wGlosa)
            If Not wResultadoGeneracion.Estado Then

                wStep = 6

                wDT.Rows.Add(0, "Error al generar TED (" & wStep & ") " & wResultadoGeneracion.Mensaje, "")
                Return wDT
            Else
                wStep = 7

                If P_ENVIO_AUTOMATICO Then
                    'Envio al DTE                        
                    If Not Emitir_DTE(wLocal, wTipoDoc, wNumero) Then
                        wDT.Rows.Add(0, "Error al enviar documento.", "")
                        Return wDT
                    End If
                End If


                'wDC = New BaseSisVenDataContext(P_CONEXION)
                'CARGAR IMAGEN

                'DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
                'If DocG Is Nothing Then
                '    wDT.Rows.Add(0, "Documento no encontrado.", Nothing)
                '    Return wDT
                'End If

                'Dim Firma As Byte() = DocG.Firma.ToArray
                'Dim MemoryStream As New IO.MemoryStream(Firma)
                'wImagen = New Bitmap(MemoryStream)

                wStep = 8

                wImagen = wResultadoGeneracion.Imagen
                wXML = wResultadoGeneracion.XML



                'DocG.TED = wXML
                'DocG.Firma = wImagen
                'wDC.SubmitChanges()

            End If

        Catch ex As Exception
            wDT.Rows.Add(0, "Error al generar DTE, revise el documento en portal DTE. (" & wStep & ") " & ex.ToString, Nothing)
            Return wDT
        End Try

        wDT.Rows.Add(1, "Generación de DET exitosa", wXML)

        Return wDT

    End Function
    <WebMethod(MessageName:="Consultar_TED", Description:="")>
    Public Function ConsultarTED(wIdKey As String, wCliente As Double, wLocal As Integer, wTipoDoc As String, wNumero As Double) As DataTable

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wImagen As Byte() = Nothing
        Dim wXML As String = ""

        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))
        wDT.Columns.Add("Timbre", GetType(String))

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.", "")
            Return wDT
        End If

        If Not Parametros_DTE(wLocal) Then
            wDT.Rows.Add(0, "Error al sacar parámetros del Local.", "")
            Return wDT
        End If

        Dim DocG = wDC.DocumentosG.FirstOrDefault(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero)
        If DocG Is Nothing Then
            wDT.Rows.Add(0, "Documento no encontrado.", "")
            Return wDT
        End If

        Dim wDocumentoElectronico = False

        If FE_EsElectronica Then
            If Es_Electronico(wTipoDoc) Then
                DocG.DTE = True
                wDocumentoElectronico = True
            Else
                DocG.DTE = False
            End If
        End If

        'Facturación Electrónica

        Dim wStep = 0

        Try
            wStep = 1
            If Not wDocumentoElectronico Then
                wDT.Rows.Add(0, "El documento no tiene habilitada emisión electrónica.", "")
                Return wDT
            End If

            wStep = 2

            Dim Cliente = wDC.Clientes.FirstOrDefault(Function(x) x.Cliente = DocG.Cliente)
            If Cliente Is Nothing Then
                wDT.Rows.Add(0, "Error al identificar Cliente de referencia.", "")
                Return wDT
            End If

            wStep = 2

            Dim RUT_DTE = UCase(DocG.Rut).Replace("_", "").Replace(".", "")
            If RUT_DTE(0) = "0" Then
                RUT_DTE = RUT_DTE.Substring(1)
            End If

            'Generar TED
            Dim wGlosa = ""

            wStep = 3

            Dim ListaDocD = wDC.DocumentosD.Where(Function(x) x.Local = wLocal And x.TipoDoc = wTipoDoc And x.Numero = wNumero).ToList
            If Not ListaDocD.Any Then
                wDT.Rows.Add(0, "Error al obtener el detalle de documento", "")
                Return wDT
            End If

            wStep = 4

            wGlosa = If(ListaDocD.First.Glosa, "")

            wStep = 4.1

            If wGlosa.Trim = "" Then
                wStep = 4.2
                Dim Art = wDC.Articulos.FirstOrDefault(Function(x) x.Articulo = ListaDocD.First.Articulo.Trim)
                wStep = 4.3
                If Art IsNot Nothing Then
                    wStep = 4.4
                    wGlosa = Art.Descripcion.Trim
                Else
                    wStep = 4.5
                    wGlosa = "ARTICULO"
                End If
            End If

            wStep = 5

            Dim wResultadoGeneracion = Generar_TED(wCliente, wLocal, wTipoDoc, wNumero, DocG.Fecha, RUT_DTE, Cliente.Nombre.Trim, DocG.Total, wGlosa)
            If Not wResultadoGeneracion.Estado Then

                wStep = 6

                wDT.Rows.Add(0, "Error al generar TED (" & wStep & ") " & wResultadoGeneracion.Mensaje, "")
                Return wDT
            Else
                wStep = 7
                wDC = New BaseSisVenDataContext(P_CONEXION)

                wStep = 8

                wImagen = wResultadoGeneracion.Imagen
                wXML = wResultadoGeneracion.XML

                DocG.TED = wXML
                DocG.Firma = wImagen
                wDC.SubmitChanges()

            End If

        Catch ex As Exception
            wDT.Rows.Add(0, "Error al generar DTE, revise el documento en portal DTE. (" & wStep & ") " & ex.ToString, Nothing)
            Return wDT
        End Try

        wDT.Rows.Add(1, "Generación de DET exitosa", wXML)

        Return wDT

    End Function


    <WebMethod(MessageName:="Consultar_Correlativo", Description:="")>
    Public Function ConsultarCorrelativo(wIdKey As String, wCliente As Double, wLocal As Integer, wTipoDoc As String,
                                wFecha As Date, wCaja As Integer) As DataTable
        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))

        If Not Verificar_ID_Cliente(wIdKey, wCliente) Or Not Estado_Cliente(wIdKey) Then
            wDT.Rows.Add(0, "Cliente Inválido.")
        End If

        Dim wRespuesta = Correlativo(ModoCorrelativo.Consultar, wLocal, wTipoDoc, wFecha, wCaja)

        wDT.Rows.Add(wRespuesta.Item1, wRespuesta.Item2)
        Return wDT
    End Function



    '<WebMethod(MessageName:="Consultar_Stock", Description:="")>
    'Public Function ConsultarStock() As DataTable
    '    Return New DataTable
    'End Function

    '<WebMethod(MessageName:="Enviar_Correo", Description:="")>
    'Public Function EnviarCorreo(ByVal wIDKey As String, ByVal wDestinatario As String, ByVal wAsunto As String, wMensaje As String) As DataTable

    '    Dim wDT As New DataTable
    '    wDT.TableName = "Respuesta"
    '    wDT.Columns.Add("Respuesta", GetType(Integer))
    '    wDT.Columns.Add("Mensaje", GetType(String))

    '    Try

    '        If wIDKey <> P_IDKEY Then
    '            wDT.Rows.Add(0, "Error: ID Key inválido")
    '            Return wDT
    '        End If

    '        If wDestinatario.Trim.Length = 0 Then
    '            wDT.Rows.Add(0, "Error: Destinatario vacío")
    '            Return wDT
    '        End If

    '        Try
    '            Dim address = New MailAddress(wDestinatario)
    '        Catch ex As Exception
    '            wDT.Rows.Add(0, "Error: Formato de correo incorrecto")
    '            Return wDT
    '        End Try

    '        If wAsunto.Trim.Length = 0 Then
    '            wDT.Rows.Add(0, "Error: Asunto vacío")
    '            Return wDT
    '        End If

    '        If wMensaje.Trim.Length = 0 Then
    '            wDT.Rows.Add(0, "Error: Mensaje vacío")
    '            Return wDT
    '        End If

    '        If EnviarCorreoSmtp(wDestinatario, wAsunto, wMensaje) Then
    '            wDT.Rows.Add(1, "Envío de correo correcto")
    '        Else
    '            wDT.Rows.Add(0, "Envío de correo fallido")
    '        End If

    '    Catch ex As Exception
    '        wDT.Rows.Add(0, "Error en Procedimiento. Revisar Log")
    '        Log(0, ex, {""}.ToList, "Enviar_Correo")
    '    End Try
    '    Return wDT

    'End Function


    <WebMethod()>
    Public Function Verificar_Estado_Cliente(wIDKey As String, wCliente As Decimal) As DataTable
        Dim wDT As New DataTable
        wDT.TableName = "Respuesta"
        wDT.Columns.Add("Respuesta", GetType(Integer))
        wDT.Columns.Add("Mensaje", GetType(String))

        If Verificar_ID_Cliente(wIDKey, wCliente) Then

            If Estado_Cliente(wIDKey) Then
                wDT.Rows.Add(2, "Cliente Activo")
            Else
                wDT.Rows.Add(1, "Cliente Inactivo")
            End If
        Else
            wDT.Rows.Add(0, "Cliente Inválido")
        End If
        Return wDT
    End Function

    Public Function Verificar_ID_Cliente(wIDKey As String, wCliente As Decimal) As Boolean
        'wCON = New SqlConnection(P_CONEXION)
        'wCON.Open()
        'Verificar_ID_Cliente = True
        'Dim wCMD As New SqlCommand("SELECT Count(K.Cliente) FROM Clientes C JOIN Key_Accesos K ON " &
        '                           " K.Cliente = C.Cliente WHERE K.Cliente = " & wCliente & " AND K.IDKey = '" & wIDKey & "'", wCON)
        'If Num(wCMD.ExecuteScalar) <> 1 Then
        '    Verificar_ID_Cliente = False
        'End If


        'wCON.Close()
        'SqlConnection.ClearPool(wCON)

        Return True

    End Function

    Public Function Estado_Cliente(wIDKey As String) As Boolean
        'wCON = New SqlConnection(P_CONEXION)
        'wCON.Open()
        'Estado_Cliente = True
        'Dim wCMD As New SqlCommand("SELECT ESTADO FROM Key_Accesos WHERE IDKey = '" & wIDKey & "'", wCON)

        'Dim dr = wCMD.ExecuteReader

        'If dr.HasRows Then
        '    dr.Read()
        '    Estado_Cliente = dr.Item("Estado")
        'Else
        '    Estado_Cliente = False
        'End If

        'wCON.Close()
        'SqlConnection.ClearPool(wCON)

        Return True
    End Function


    'Function EnviarCorreoSmtp(ByVal wDestinatario As String, ByVal wAsunto As String, ByVal wMensaje As String) As Boolean
    '    'PROCEDIMIENTO ESTANDAR DE ENVIO DE CORREOS
    '    Dim wUsuario As String = P_CORREO
    '    Dim wContraseña As String = P_CONTRASENA
    '    Dim wPuerto As Integer = P_PUERTO
    '    Dim wHost As String = P_HOST
    '    Dim wSSL As Boolean = P_SSL
    '    Dim wTimeOUT As Integer = P_TIMEOUT
    '    Dim wSMTP As New Net.Mail.SmtpClient(wHost, wPuerto)

    '    Dim wCorreo As New MailMessage

    '    Try

    '        wCorreo.From = New Net.Mail.MailAddress(wUsuario)
    '        wCorreo.To.Add(wDestinatario)
    '        wCorreo.Subject = wAsunto
    '        wCorreo.Body = wMensaje

    '        wCorreo.SubjectEncoding = System.Text.Encoding.UTF8
    '        wCorreo.BodyEncoding = System.Text.Encoding.UTF8
    '        wCorreo.IsBodyHtml = False

    '        wSMTP.UseDefaultCredentials = False
    '        wSMTP.Credentials = New System.Net.NetworkCredential(wUsuario, wContraseña)
    '        wSMTP.Port = wPuerto
    '        wSMTP.Host = wHost
    '        wSMTP.EnableSsl = False
    '        wSMTP.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

    '        If wTimeOUT <> 0 Then
    '            wSMTP.Timeout = wTimeOUT
    '        End If
    '        If P_IGNORAR_CERTIFICADOS Then
    '            ' ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As Security.SslPolicyErrors) True
    '        End If
    '        wSMTP.Send(wCorreo)
    '        EnviarCorreoSmtp = True
    '    Catch ex As Exception
    '        EnviarCorreoSmtp = False
    '    End Try
    'End Function



End Class