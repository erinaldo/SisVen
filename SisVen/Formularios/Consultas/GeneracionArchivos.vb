Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports ClosedXML.Excel

Public Class GeneracionArchivos
    Implements iFormulario

    Dim wArchivo As String = ""
    Dim wRuta As String = ""

    Private Sub GeneracionArchivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dDesde.Value = CDate(Format(Now, "dd/MM/yyyy") + " 00:00:00")
        dHasta.Value = CDate(Format(Now, "dd/MM/yyyy") + " 23:59:59")
    End Sub

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub bGenerar_Click(sender As Object, e As EventArgs) Handles bGenerar.Click
        bGenerar.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        If oGeneral.Checked Then Generar_Cabecera()
        If oDetalles.Checked Then Generar_Detalles()
        If oInventarios.Checked Then Generar_Inventario()
        If oMaquinas.Checked Then Generar_Maquinas()

        bGenerar.Enabled = True
        Me.Cursor = Cursors.Default

        Mensaje("Archivos Generados")

        If Pregunta("Desea Visualizarlos") Then
            wPath = Environment.CurrentDirectory + "\Archivos"
            Shell("Explorer " & wPath, AppWinStyle.MaximizedFocus)
        End If
    End Sub

    Private Sub Generar_Cabecera()
        Dim wDC = New SisVenDataContext(P_CONEXION)
        Dim wFPagos = wDC.T_FPagos.ToList()
        Dim wClientes = wDC.T_Clientes.ToList()
        Dim wUsuarios = wDC.T_Usuarios.ToList()
        Dim wCiudades = wDC.T_Ciudades.ToList()
        Dim wComunas = wDC.T_Comunas.ToList()

        Dim wEncabezado = wDC.T_DocumentosG.Where(Function(x) x.Fecha >= dDesde.Value And x.Fecha <= dHasta.Value).OrderBy(Function(x) x.Numero).Select(Function(x) New CabeceraVentas With
        {
            .Cliente = x.Cliente,
            .TipoDoc = Tipo_Documento(x.TipoDoc),
            .NumDoc = x.Numero,
            .FechaEmi = x.Fecha,
            .FechaVen = x.Fecha,
            .FPago = x.FPago,
            .Vendedor = x.Vendedor.ToUpper,
            .Rut = "",
            .Nombre = "",
            .Comuna = "",
            .Ciudad = "",
            .Giro = "",
            .Telefonos = "",
            .Neto = x.Neto,
            .IVA = x.IVA,
            .Adicionales = 0,
            .Total = x.Total,
            .Bodega = x.Bodega,
            .Fantasia = "",
            .Sucursal = "",
            .DireccionSuc = "",
            .ComunaSuc = "",
            .CiudadSuc = "",
            .Direccion = "",
            .NombreVendedor = x.Vendedor
        }).ToList()

        If Not wEncabezado.Any() Then
            MsgError("No existen registros de Cabecera")
            Exit Sub
        End If

        wEncabezado.ForEach(Sub(x)
                                Dim wFPag = wFPagos.FirstOrDefault(Function(f) f.FPago = x.FPago)
                                If wFPag IsNot Nothing Then
                                    x.FPago = wFPag.DescFPago.ToUpper
                                End If
                            End Sub)

        wEncabezado.ForEach(Sub(x)
                                Dim wUsr = wUsuarios.FirstOrDefault(Function(u) u.Usuario = x.Vendedor)
                                If wUsr IsNot Nothing Then
                                    x.NombreVendedor = wUsr.NombreUsr.ToUpper
                                End If
                            End Sub)

        wEncabezado.ForEach(Sub(x)
                                Dim wCliente = wClientes.FirstOrDefault(Function(c) c.Cliente = x.Cliente)
                                If wCliente IsNot Nothing Then
                                    x.Rut = wCliente.Rut.Replace(".", "").ToUpper
                                    x.Nombre = wCliente.Nombre.ToUpper
                                    x.Comuna = Saca_Comuna(wCliente.Comuna).ToUpper
                                    x.Ciudad = Saca_Ciudad(wCliente.Ciudad).ToUpper
                                    x.Giro = wCliente.Giro.ToUpper
                                    x.Telefonos = wCliente.Telefonos
                                    x.Fantasia = wCliente.Fantasia.ToUpper
                                    x.Sucursal = wCliente.Glosa
                                    x.DireccionSuc = If(x.Sucursal.Trim = "" Or x.Sucursal = "0000", "", wCliente.Direccion.ToUpper)
                                    x.CiudadSuc = If(x.Sucursal.Trim = "" Or x.Sucursal = "0000", "", x.Ciudad)
                                    x.ComunaSuc = If(x.Sucursal.Trim = "" Or x.Sucursal = "0000", "", x.Comuna)
                                    x.Direccion = wCliente.Direccion
                                End If
                            End Sub)

        Try

            wArchivo = Nombre_Archivo("Vtas01")
            wPath = Environment.CurrentDirectory + "\Archivos\" + wArchivo
            Dim Stream = ExcelWorkbookService.GenerateExcel(Of CabeceraVentas)(wEncabezado, "Encabezado", Nothing)
            File.WriteAllBytes(wPath, Stream.ToArray)

        Catch ex As Exception
            MsgError("Error al intentar exportar Encabezado" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub Generar_Detalles()
        Dim wDC = New SisVenDataContext(P_CONEXION)
        Dim wArticulos = wDC.T_Articulos.ToList()
        Dim wUnidades = wDC.T_Unidades.ToList()

        Dim wDetallesVentas = wDC.V_DetalleDocumentos.Where(Function(x) x.Fecha >= dDesde.Value And x.Fecha <= dHasta.Value).OrderBy(Function(x) x.Numero).ToList()

        Dim wDetalles = wDetallesVentas.Select(Function(x) New DetalleVentas With
        {
            .TipoDoc = Tipo_Documento(x.TipoDoc),
            .NumDoc = x.Numero,
            .Articulo = x.Articulo,
            .Descripcion = x.Descripcion.ToUpper,
            .Unidad = x.DescUnidad.ToUpper,
            .Cantidad = x.Cantidad,
            .PVenta = x.Neto,
            .Total = (x.Neto * x.Cantidad)
        }).ToList()

        If Not wDetalles.Any() Then
            MsgError("No existen registros de Detalles")
            Exit Sub
        End If

        Try

            wArchivo = Nombre_Archivo("Vtas02")
            wPath = Environment.CurrentDirectory + "\Archivos\" + wArchivo
            Dim Stream = ExcelWorkbookService.GenerateExcel(Of DetalleVentas)(wDetalles, "Detalles", Nothing)
            File.WriteAllBytes(wPath, Stream.ToArray)

        Catch ex As Exception
            MsgError("Error al intentar exportar Detalles" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub Generar_Inventario()
        Dim wDC = New SisVenDataContext(P_CONEXION)
        Dim wArticulos = wDC.T_Articulos.ToList()

        Dim wStocks = wDC.T_Stocks.Where(Function(x) x.Stock > 0).OrderBy(Function(x) x.Articulo).Select(Function(x) New Inventarios With
        {
            .Articulo = x.Articulo,
            .Descripcion = "",
            .Bodega = x.Bodega,
            .Cantidad = x.Stock,
            .Neto = 0
        }).ToList()

        If Not wStocks.Any() Then
            MsgError("No existen registros de Inventario")
            Exit Sub
        End If

        wStocks.ForEach(Sub(x)
                            Dim wArticulo = wArticulos.FirstOrDefault(Function(a) a.Articulo = x.Articulo)
                            If wArticulo IsNot Nothing Then
                                x.Descripcion = wArticulo.Descripcion
                                x.Neto = Math.Round((Val(wArticulo.PVenta) / (1 + (G_IVA / 100))), 2)
                            End If
                        End Sub)
        Try

            wArchivo = Nombre_Archivo("Valorizado")
            wPath = Environment.CurrentDirectory + "\Archivos\" + wArchivo
            Dim Stream = ExcelWorkbookService.GenerateExcel(Of Inventarios)(wStocks, "Valorizado", Nothing)
            File.WriteAllBytes(wPath, Stream.ToArray)

        Catch ex As Exception
            MsgError("Error al intentar exportar Inventarios" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub Generar_Maquinas()
        Dim wDC = New SisVenDataContext(P_CONEXION)
        Dim wClientes = wDC.T_Clientes.ToList()

        Dim wMaquinas = wDC.T_Maquinas.Select(Function(x) New Maquinas With
        {
            .Mes = Month(Now),
            .Ano = Year(Now),
            .ID = x.ID,
            .Marca = x.Marca,
            .Modelo = x.Modelo,
            .Ubicacion = x.Ubicacion,
            .Cliente = x.Cliente,
            .Sucursal = x.Sucursal,
            .Garantia = x.Garantia,
            .Guia = x.Guia,
            .FechaAsignacion = x.FechaAsignacion,
            .Territorio = x.Territorio,
            .Estado = x.Estado,
            .FechaRecuperacion = x.FechaRecuperacion
        }).ToList()

        If Not wMaquinas.Any() Then
            MsgError("No existen registros de Máquinas")
            Exit Sub
        End If

        wMaquinas.ForEach(Sub(x)
                              Dim wCliente = wClientes.FirstOrDefault(Function(c) c.Cliente = x.Cliente)
                              If wCliente IsNot Nothing Then
                                  x.Rut = wCliente.Rut
                                  x.NombreSucursal = wCliente.Nombre
                              End If
                          End Sub)
        Try

            wArchivo = Nombre_Archivo("Maquinas")
            wPath = Environment.CurrentDirectory + "\Archivos\" + wArchivo
            Dim Stream = ExcelWorkbookService.GenerateExcel(Of Maquinas)(wMaquinas, "Maquinas", Nothing)
            File.WriteAllBytes(wPath, Stream.ToArray)

        Catch ex As Exception
            MsgError("Error al intentar exportar Máquinas" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Function Tipo_Documento(wTipoDoc As String) As String
        Dim qTD = wTipoDoc

        Select Case wTipoDoc
            Case "FV"
                qTD = "FE"
            Case "BV"
                qTD = "BE"
            Case "NC"
                qTD = "NE"
            Case "ND"
                qTD = "DE"
            Case "FE"
                qTD = "XE"
            Case Else
                qTD = wTipoDoc
        End Select

        Return (qTD)
    End Function

    Function Nombre_Archivo(wNombre As String) As String
        Nombre_Archivo = wNombre + "_" + Format(Now, "ddMMyyyy") + ".xlsx"
    End Function
End Class