Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Public Class VisorReportes
    Dim gQuery As String
    Dim gFiltros As String
    Dim gReporte As ReportClass
    Dim gParametros As New List(Of ParametrosReporte)
    Dim glocalParametro As New List(Of ParametrosLocal)
    Private Sub VisorReportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Cursor = Cursors.WaitCursor

        'Modulo=0 Invisible la ventana
        If Modulo = "0" Then
            Me.Visible = False
        End If

        Par = SQL("SELECT * FROM Parametros")
        If Par.RecordCount = 1 Then gParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

        Swap = SQL("SELECT * FROM Locales WHERE Local = " & LocalActual)
        If Swap.RecordCount > 0 Then
            glocalParametro.Add(New ParametrosLocal With {.Local = Swap.Fields("Local").Text,
                                                           .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                           .RazonLocal = Swap.Fields("RazonLocal").Text,
                                                           .GiroLocal = Swap.Fields("GiroLocal").Text,
                                                           .DirLocal = Swap.Fields("DirLocal").Text,
                                                           .Ciudad = Swap.Fields("Ciudad").Text,
                                                           .Comuna = Swap.Fields("Comuna").Text,
                                                           .RutLocal = Swap.Fields("RutLocal").Text,
                                                           .Logo = Swap.Fields("Logo").Value})

            Swap.MoveNext()
        End If

        Select Case ModuloReporte
            Case "Pagos"
                Listado_Pagos()
            Case "ListadoArticulos"
                Listado_Articulos()
            Case "ListadoClientes"
                Listado_Clientes()
            Case "ListadoPrecios"
                Listado_Precios()
            Case "ListadoBodegas"
                Listado_Bodegas()
            Case "CuadraturaCaja"
                ListadoCuadraturaCaja()
            Case "ReporteBoleta"
                Reporte_Boleta()
            Case "Movimientos"
                Listado_Movimiento()
            Case "ListadoStock"
                ListadoStock()
            Case "ListadoTomaInventario"
                Listado_TomaInventario()
            Case "ListadoMovimiento"
                Listado_Movimiento()
            Case "ListadoOT"
                Listado_OT()
            Case "ListadoRevisionOTMecanico"
                Listado_RevisionOTMecanico()
            Case "ListadoRepuestosPendientes"
                Listado_RepuestosPendientesOT()
            Case "ListadoMovimientos"
                Listado_Movimientos()
            Case "ReporteLiquidacion"
                Reporte_Liquidacion()
            Case "Listado_EventosRem"
                Listado_EventosREM()
            Case "ReporteLiquidaciones"
                Reporte_Liquidaciones()
            Case "ListadoVentasBoleta"
                Listado_VentasBoletas()
            Case "ListadoDescuento"
                Listado_Descuento()
            Case "Reporte_Auditoria"
                Reporte_Auditoria()
            Case "ListadoDocumento"
                Listado_Documento()
            Case "ReporteCiudades"
                Listado_Ciudades()
            Case "ImprimirDocumentos"
                Imprimir_Documentos()
            Case "Documentos"
                Imprimir_Documentos()
        End Select

        Cursor = Cursors.Arrow
        If Modulo = "0" Then
            Close()
        End If
    End Sub

    Sub Reporte_Boleta()
        Dim Lista = New List(Of BoletaReporte)
        Swap = SQL(gQuery)

        While Not Swap.EOF
            Lista.Add(New BoletaReporte With {.NumDoc = Swap.Fields("NumDoc").Text,
                                              .Ticket = Swap.Fields("Ticket").Text,
                                              .Fecha = Swap.Fields("FECHA").Text,
                                              .Total = Swap.Fields("TOTAL").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            Visor_Reporte.ReportSource = gReporte
            gReporte.PrintToPrinter(1, False, 0, 0)
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub ListadoCuadraturaCaja()
        Dim Lista = New List(Of CuadraturaReporte)
        Swap = SQL(gQuery)

        While Not Swap.EOF
            Lista.Add(New CuadraturaReporte With {.Local = Swap.Fields("LOCAL").Text,
                                              .FormaPago = Swap.Fields("FPAGO").Text,
                                              .Caja = Swap.Fields("CAJA").Text,
                                              .DescFPago = Swap.Fields("DESCFPAGO").Text,
                                              .NombreLocal = Swap.Fields("NOMBRELOCAL").Text,
                                              .Fecha = Swap.Fields("FECHA").Text,
                                              .Total = Swap.Fields("TOTAL").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub

    Sub Listado_Bodegas()
        Dim Lista = New List(Of BodegasListado)
        Swap = SQL(gQuery)

        While Not Swap.EOF
            Lista.Add(New BodegasListado With {.Bodega = Swap.Fields("Bodega").Text,
                                              .NombreBodega = Swap.Fields("NombreBodega").Text,
                                              .Local = Swap.Fields("Local").Text,
                                              .NombreLocal = Swap.Fields("NombreLocal").Text,
                                              .Cliente = Swap.Fields("Cliente").Text,
                                              .NombreCliente = Swap.Fields("Nombre").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            gReporte.Database.Tables(1).SetDataSource(Lista)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Precios()
        Dim Lista = New List(Of PreciosReporte)
        Swap = SQL(gQuery)

        While Not Swap.EOF
            Lista.Add(New PreciosReporte With {.Articulo = Swap.Fields("Articulo").Text,
                                              .NombreArticulo = Swap.Fields("Descripcion").Text,
                                              .PrecioMayorista = Swap.Fields("Costo").Text,
                                              .PrecioVenta = Swap.Fields("PVenta").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            gReporte.Database.Tables(1).SetDataSource(Lista)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Clientes()
        Dim Lista = New List(Of ClientesReporte)
        Swap = SQL(gQuery)

        While Not Swap.EOF
            Lista.Add(New ClientesReporte With {.Cliente = Swap.Fields("Cliente").Text,
                                                .NombreCliente = Swap.Fields("Nombre").Text,
                                                .Rut = Swap.Fields("Rut").Text,
                                                .Direcicon = Swap.Fields("Direccion").Text,
                                                .NombreCiudad = Swap.Fields("NombreCiudad").Text,
                                                .Nombrecomuna = Swap.Fields("NombreComuna").Text,
                                                .Estado = Swap.Fields("DescEstado").Text,
                                                .CupoMax = Swap.Fields("CupoMax").Text,
                                                .Proveedor = Swap.Fields("Proveedor").Text,
                                                .Vencimiento = Swap.Fields("Vencimiento").Text,
                                                .Comision = Swap.Fields("Comision").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            gReporte.Database.Tables(1).SetDataSource(Lista)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Articulos()
        Dim Lista = New List(Of ArticulosReporte)
        Swap = SQL(gQuery)

        While Not Swap.EOF
            Lista.Add(New ArticulosReporte With {.Articulo = Swap.Fields("Articulo").Text,
                                                 .DescArticulo = Swap.Fields("Descripcion").Text,
                                                 .DescEstado = Swap.Fields("DescEstado").Text,
                                                 .Descfamilia = Swap.Fields("DescFamilia").Text,
                                                 .DesSubfamilia = Swap.Fields("DescSubFamilia").Text,
                                                 .DescUnidad = Swap.Fields("DescUnidad").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            gReporte.Database.Tables(1).SetDataSource(Lista)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Pagos()
        Dim lista = New List(Of PagosReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            lista.Add(New PagosReporte With {.TipoDoc = Swap.Fields("DescTipoDoc").Text.Trim,
                                            .Numero = Val(Swap.Fields("Numero").Text),
                                            .Rut = Swap.Fields("Rut").Text.Trim,
                                            .NombreCliente = Swap.Fields("Nombre").Text.Trim,
                                            .Monto = Val(Swap.Fields("Monto").Text.Trim),
                                            .FPago = Swap.Fields("DescFPago").Text.Trim,
                                            .Estado = Swap.Fields("DescEstado").Text.Trim,
                                            .FechaCanc = CDate(Swap.Fields("FechaCanc").Text.Trim),
                                            .Obs = Swap.Fields("Obs").Text})
            Swap.MoveNext()
        End While

        If lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(lista)
            gReporte.Database.Tables(1).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Movimiento()
        Dim Lista = New List(Of MovimientoReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New MovimientoReporte With {.Movimiento = Swap.Fields("Movimiento").Text,
                                                  .TipoMov = Swap.Fields("DescTipo").Text,
                                                  .Fecha = Swap.Fields("Fecha").Text,
                                                  .Local = Swap.Fields("Local").Text,
                                                  .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                  .Bodega = Swap.Fields("Bodega").Text,
                                                  .NombreBodega = Swap.Fields("NombreBodega").Text,
                                                  .UsuarioC = Swap.Fields("UsrResponsable").Text,
                                                  .UsuarioR = Swap.Fields("UsrCreador").Text,
                                                  .Estado = Swap.Fields("DescEstado").Text,
                                                  .TipoDoc = Swap.Fields("DescTipoDoc").Text,
                                                  .NumDoc = Swap.Fields("NumDoc").Text,
                                                  .Cliente = Swap.Fields("Nombre").Text,
                                                  .Observacion = Swap.Fields("ObsTra").Text,
                                                  .Articulo = Swap.Fields("Articulo").Text,
                                                  .Descripcion = Swap.Fields("Descripcion").Text,
                                                  .Barra = Swap.Fields("Barra").Text,
                                                  .Cantidad = Swap.Fields("Cantidad").Text,
                                                  .PVenta = Swap.Fields("Precio").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            gReporte.Database.Tables(1).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If

    End Sub
    Sub ListadoStock()
        Dim Lista = New List(Of StockReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New StockReporte With {.Local = Swap.Fields("Local").Text,
                                             .NombreLocal = Swap.Fields("NombreLocal").Text,
                                             .Bodega = Swap.Fields("Bodega").Text,
                                             .NombreBodega = Swap.Fields("NombreBodega").Text,
                                             .Articulo = Swap.Fields("Articulo").Text,
                                             .Descripcion = Swap.Fields("Descripcion").Text,
                                             .Stock = Swap.Fields("Stock").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            gReporte.Database.Tables(1).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_TomaInventario()
        Dim Lista = New List(Of TomaInventarioReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New TomaInventarioReporte With {.Articulo = Swap.Fields("Articulo").Text,
                                                      .Descripcion = Swap.Fields("Descripcion").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            gReporte.Database.Tables(1).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_OT()
        Dim Lista = New List(Of OTReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New OTReporte With {.NumeroOT = Swap.Fields("OT").Text,
                                          .RUT = Swap.Fields("Rut").Text,
                                          .NombreCliente = Swap.Fields("Nombre").Text,
                                          .Direccion = Swap.Fields("Direccion").Text,
                                          .Ciudad = Swap.Fields("Ciudad").Text,
                                          .Telefono = Swap("Telefonos").Text,
                                          .FechaOT = Swap.Fields("Fecha").Text,
                                          .FechaEntrega = Swap.Fields("FechaEntrega").Text,
                                          .TecnicoR = Swap.Fields("TecnicoRevision").Text,
                                          .CodigoR = Swap.Fields("Codigo").Text,
                                          .ProductoR = Swap.Fields("Recepcion").Text,
                                          .ObsCliente = Swap.Fields("ObsCliente").Text,
                                          .ObsTecnico = Swap.Fields("obsTecnico").Text,
                                          .Articulo = Swap.Fields("Articulo").Text,
                                          .Descripcion = Swap.Fields("Descripcion").Text,
                                          .Cantidad = Swap.Fields("Cantidad").Text,
                                          .pVenta = Swap.Fields("PVenta").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            gReporte.Database.Tables(1).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub

    Sub Listado_RevisionOTMecanico()
        Dim Lista = New List(Of RevisionOTMecanicoListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New RevisionOTMecanicoListado With {.NumeroOT = Swap.Fields("OT").Text,
                                                              .tecnico = Swap.Fields("Tecnico").Text,
                                                              .Articulo = Swap.Fields("Articulo").Text,
                                                              .Descripcion = Swap.Fields("Descripcion").Text,
                                                              .Cantidad = Swap.Fields("Cantidad").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(1).SetDataSource(Lista)
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_RepuestosPendientesOT()
        Dim Lista = New List(Of RepuestosPendientesListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New RepuestosPendientesListado With {.NumeroOT = Swap.Fields("OT").Text,
                                                          .Fecha = Swap.Fields("FechaSol").Text,
                                                          .Articulo = Swap.Fields("Articulo").Text,
                                                          .Descripcion = Swap.Fields("Descripcion").Text,
                                                          .Cantidad = Swap.Fields("Cantidad").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(1).SetDataSource(Lista)
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Movimientos()
        Dim Lista = New List(Of MovimientosReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New MovimientosReporte With {.Movimiento = Swap.Fields("Movimiento").Text,
                                                   .Fecha = Swap.Fields("Fecha").Text,
                                                   .DescTipoMov = Swap.Fields("DescTipo").Text,
                                                   .DescTipoDoc = Swap.Fields("DescTipoDoc").Text,
                                                   .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                   .NombreBodega = Swap.Fields("NombreBodega").Text,
                                                   .NombreUsuario = Swap.Fields("UsrCreador").Text,
                                                   .nombreResponsable = Swap.Fields("UsrResponsable").Text,
                                                   .DescEstado = Swap.Fields("DescEstado").Text,
                                                   .NumDoc = Swap.Fields("NumDoc").Text,
                                                   .Cliente = Swap.Fields("Nombre").Text,
                                                   .ObsTra = Swap.Fields("ObsTra").Text,
                                                   .Total = Swap.Fields("Total").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(1).SetDataSource(Lista)
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Public Sub Reporte_Liquidacion()

        Dim wListaParametros = New List(Of ParametrosLocal)
        Dim wReporte As New Liquidacion_Sueldo

        Swap = SQL("SELECT * FROM Locales WHERE Local = " & gLocal)

        While Not Swap.EOF
            wListaParametros.Add(New ParametrosLocal With {.Local = Swap.Fields("Local").Text,
                                                           .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                           .RazonLocal = Swap.Fields("RazonLocal").Text,
                                                           .GiroLocal = Swap.Fields("GiroLocal").Text,
                                                           .DirLocal = Swap.Fields("DirLocal").Text,
                                                           .Ciudad = Swap.Fields("Ciudad").Text,
                                                           .Comuna = Swap.Fields("Comuna").Text})

            Swap.MoveNext()
        End While

        wReporte.Database.Tables("SisVen_LocalesParametros").SetDataSource(wListaParametros)
        Visor_Reporte.ReportSource = wReporte

    End Sub
    Sub Listado_EventosREM()
        Dim Lista = New List(Of EventosRemListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New EventosRemListado With {.CalculoRem = Swap.Fields("CalculoRem").Text,
                                                  .DescEvento = Swap.Fields("DescEventoRem").Text,
                                                  .Estado = Swap.Fields("Estado").Text,
                                                  .Fecha = Swap.Fields("Fecha").Text,
                                                  .Funcionario = Swap.Fields("NombreUsr").Text,
                                                  .Glosa = Swap.Fields("Glosa").Text,
                                                  .ID = Swap.Fields("ID").Text,
                                                  .Usuario = Swap.Fields("UsuarioRem").Text,
                                                  .Monto = Swap.Fields("Monto").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(0).SetDataSource(Lista)
            gReporte.Database.Tables(1).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub

    Sub Reporte_Liquidaciones()
        Dim Lista = New List(Of LiquidacionesReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New LiquidacionesReporte With {.AFC = Swap.Fields("AFP").Text,
                                                     .Ahorro = Swap.Fields("Ahorros").Text,
                                                     .Anticipos = Swap.Fields("Anticipos").Text,
                                                     .Base = Swap.Fields("Base").Text,
                                                     .Creditos = Swap.Fields("Creditos").Text,
                                                     .DescModoPago = Swap.Fields("DescModoPago").Text,
                                                     .Descuentos = Swap.Fields("Descuentos").Text,
                                                     .Funcionario = Swap.Fields("NombreUsr").Text,
                                                     .ModoPago = Swap.Fields("ModoPago").Text,
                                                     .Seguros = Swap.Fields("Seguros").Text,
                                                     .TAFP = Swap.Fields("TAFP").Text,
                                                     .TAguinaldos = Swap.Fields("TAguinaldos").Text,
                                                     .TBonos = Swap.Fields("TBonos").Text,
                                                     .TCargas = Swap.Fields("TCargas").Text,
                                                     .TColacion = Swap.Fields("TColacion").Text,
                                                     .TDescuentos = Swap.Fields("TDescuentos").Text,
                                                     .TGratificacion = Swap.Fields("TGratificacion").Text,
                                                     .THaberes = Swap.Fields("THAberes").Text,
                                                     .TImponible = Swap.Fields("TImponible").Text,
                                                     .TLiquido = Swap.Fields("TLiquido").Text,
                                                     .TMovilizacion = Swap.Fields("TMovilizacion").Text,
                                                     .TSalud = Swap.Fields("TSalud").Text,
                                                     .TVariables = Swap.Fields("TVariables").Text,
                                                     .Dia = Swap.Fields("Dias").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables("SisVen_LiquidacionesReporte").SetDataSource(Lista)
            gReporte.Database.Tables("SisVen_LocalesParametro").SetDataSource(glocalParametro)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub

    Sub Listado_VentasBoletas()
        Dim Lista = New List(Of VentasBoletaListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New VentasBoletaListado With {.Articulo = Swap.Fields("Articulo").Text,
                                                    .Caja = Swap.Fields("Caja").Text,
                                                    .Cantidad = Swap.Fields("Cantidad").Text,
                                                    .Descripcion = Swap.Fields("Descripcion").Text,
                                                    .Fecha = Swap.Fields("Fecha").Text,
                                                    .Fpago = Swap.Fields("DescFPago").Text,
                                                    .Local = Swap.Fields("Local").Text,
                                                    .NumDoc = Swap.Fields("NumDoc").Text,
                                                    .PVenta = Swap.Fields("PVenta").Text,
                                                    .Ticket = Swap.Fields("Ticket").Text,
                                                    .Usuario = Swap.Fields("Usuario").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables(1).SetDataSource(Lista)
            gReporte.Database.Tables(0).SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Descuento()
        Dim Lista = New List(Of DescuentoListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New DescuentoListado With {.Articulo = Swap.Fields("Articulo").Text,
                                                 .Caja = Swap.Fields("Caja").Text,
                                                 .Descripcion = Swap.Fields("Descripcion").Text,
                                                 .Descuento = Swap.Fields("Descuento").Text,
                                                 .Documento = Swap.Fields("NumDoc").Text,
                                                 .Fecha = Swap.Fields("Fecha").Text,
                                                 .FPago = Swap.Fields("DescFPago").Text,
                                                 .Local = Swap.Fields("Local").Text,
                                                 .Tickets = Swap.Fields("Ticket").Text,
                                                 .TotalOriginal = Swap.Fields("Total").Text,
                                                 .Usuario = Swap.Fields("Usuario").Text,
                                                 .TipoDoc = Swap.Fields("TipoDoc").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables("SisVen_DescuentoListado").SetDataSource(Lista)
            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub

    Sub Reporte_Auditoria()
        Dim Lista = New List(Of AuditoriaReporte)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New AuditoriaReporte With {.Evento = Swap.Fields("Evento").Text,
                                                 .Fecha = Swap.Fields("Fecha").Text,
                                                 .Hora = Swap.Fields("Hora").Text,
                                                 .ID = Swap.Fields("ID").Text,
                                                 .Local = Swap.Fields("Local").Text,
                                                 .Lugar = Swap.Fields("Lugar").Text,
                                                 .Proceos = Swap.Fields("Proceso").Text,
                                                 .Usuario = Swap.Fields("Usuario").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables("SisVen_AuditoriaReporte").SetDataSource(Lista)
            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Documento()
        Dim Lista = New List(Of DocumentoListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New DocumentoListado With {.Local = Swap.Fields("Local").Text,
                                                 .Cliente = Swap.Fields("Cliente").Text,
                                                 .NombreCliente = Swap.Fields("Nombre").Text,
                                                 .Documento = Swap.Fields("Numero").Text,
                                                 .Fecha = Swap.Fields("Fecha").Text,
                                                 .Estado = Swap.Fields("Estado").Text,
                                                 .FPago = Swap.Fields("FPAgo").Text,
                                                 .Vendedor = Swap.Fields("Vendedor").Text,
                                                 .SubTotal = Swap.Fields("SubTotal").Text,
                                                 .Descuento = Swap.Fields("Descuento").Text,
                                                 .Neto = Swap.Fields("Neto").Text,
                                                 .Iva = Swap.Fields("IVA").Text,
                                                 .Total = Swap.Fields("Total").Text,
                                                 .Articulo = Swap.Fields("Articulo").Text,
                                                 .Cantidad = Swap.Fields("Cantidad").Text,
                                                 .Descripcion = Swap.Fields("Descripcion").Text,
                                                 .TipoDoc = Swap.Fields("TipoDoc").Text,
                                                 .Precio = Swap.Fields("PVenta").Text,
                                                 .DescFPago = Swap.Fields("DescFPago").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables("SisVen_DocumentoListado").SetDataSource(Lista)
            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Sub Listado_Ciudades()
        Dim Lista = New List(Of CiudadesListado)
        Swap = SQL(gQuery)
        While Not Swap.EOF
            Lista.Add(New CiudadesListado With {.Ciudad = Swap("Ciudad").Text,
                                                 .NombreCiudad = Swap.Fields("NombreCiudad").Text,
                                                 .CodigoArea = Swap.Fields("CodigoArea").Text,
                                                 .Region = Swap.Fields("NombreRegion").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            gReporte.Database.Tables("SisVen_CiudadesListado").SetDataSource(Lista)
            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(gParametros)
            Visor_Reporte.ReportSource = gReporte
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub
    Public Sub Imprimir_Documentos()
        Dim gReporte As New Documentos_DTE
        Dim wFiltro As String
        Dim Lista = New List(Of DTE_Documentos)
        Dim ListLocal = New List(Of LocalesReporte)
        'Dim ListDocumentoG = New List(Of DocumentosG)

        wFiltro = "g.Local=" & Num(gLocal) & " And g.TipoDoc='" & gTipoDoc & "' And g.Numero=" & Num(gNumero)
        Dim wNombreDocumento = Nombre_Documento(gTipoDoc).Trim
        gQuery = "SELECT g.Local, g.TipoDoc, g.Numero, g.Fecha, g.OC, g.Cliente, g.TipoDocReferencia, g.NumDocReferencia, g.FechaDocReferencia, " &
                " g.Observaciones, g.Descuento, g.Neto, g.IVA, g.Total, d.Articulo, m.DescMotivo, g.TipoDocReferencia, d.Cantidad,  " &
                " d.Neto As Precio, Coalesce(d.PVenta,0) as PVenta, d.Glosa, l.NombreLocal, l.RazonLocal, l.RutLocal, l.GiroLocal, l.DirLocal, l.EMailLocal, " &
                " l.TelefonosLocal, l.HorarioLocal, l.SII, cil.NombreCiudad as NombreCiudad, l.NResolucion, l.BancoDeposito, l.CuentaDeposito, l.RutDeposito, l.TitularDeposito, l.CorreoDeposito, " &
                " l.FResolucion, col.NombreComuna as NombreComuna, a.Descripcion, u.DescUnidad, t.DescTipoDoc , c.Nombre, c.Fantasia, " &
                " c.Rut, c.Direccion, c.Giro, c.Telefonos, c.Contacto, c.Email, f.FPago, f.DescFPago, ci.NombreCiudad AS CiudadCli, " &
                " co.NombreComuna AS ComunaCli, isNull(r.DescTipoDoc,'') as DescTipoDocRef  " &
                " FROM DocumentosG AS g INNER JOIN DocumentosD AS d ON g.Local = d.Local AND g.TipoDoc = d.TipoDoc AND g.Numero = d.Numero " &
                " INNER JOIN Locales As l On g.Local = l.Local " &
                " INNER JOIN Articulos AS a ON d.Articulo = a.Articulo INNER JOIN Unidades AS u ON a.Unidad = u.Unidad " &
                " INNER JOIN TipoDoc AS t ON g.TipoDoc = t.TipoDoc INNER JOIN Clientes AS c ON g.Cliente = c.Cliente " &
                " INNER JOIN FPagos AS f ON g.FPago = f.FPago INNER JOIN Ciudades AS ci ON c.Ciudad = ci.Ciudad " &
                " INNER JOIN Comunas AS co ON c.Comuna = co.Comuna INNER JOIN Ciudades AS cil ON l.Ciudad = cil.Ciudad " &
                " INNER JOIN Comunas AS col ON l.Comuna = col.Comuna " &
                " INNER JOIN Motivos AS M ON g.Motivo = M.Motivo and M.TipoDoc = G.TipoDoc" &
                " LEFT JOIN TipoDoc AS r on g.TipoDocReferencia = r.TipoDoc  " &
                " WHERE " & wFiltro

        Swap = SQL(gQuery)
        If Swap.RecordCount = 0 Then
            MsgError("Error en consulta SQL, no retorna datos")
            Exit Sub
        End If

        Loc = SQL("SELECT Logo FROM Locales WHERE Local=" & gLocal)
        If Not Loc.EOF Then
            ListLocal.Add(New LocalesReporte With {.Logo = If(Loc.Fields("Logo").Value Is Nothing, Nothing, Loc.Fields("Logo").Value)})
        End If

        If IsDBNull(gTipoCopia) Or gTipoCopia Is Nothing Then
            Funciones.gTipoCopia = New List(Of Double)
            Funciones.gTipoCopia.Add(1)
        End If

        Try
            For i = 1 To gTipoCopia.Count
                While Not Swap.EOF
                    'Dim wObtenerFirma As New IO.MemoryStream(CType(Swap.Fields("Firma").Value, Byte()))
                    'wFirma = Image.FromStream(wObtenerFirma)
                    'Dim wObtenerLogo As New IO.MemoryStream(CType(Swap.Fields("Logo").Value, Byte()))
                    'wLogo = Image.FromStream(wObtenerLogo)
                    Lista.Add(New DTE_Documentos With {
                        .Local = If(Swap.Fields("Local").Value Is DBNull.Value, 0, Swap.Fields("Local").Value),
                        .RutLocal = If(Swap.Fields("RutLocal").Value Is DBNull.Value, "", Swap.Fields("RutLocal").Value),
                        .NombreLocal = If(Swap.Fields("NombreLocal").Value Is DBNull.Value, "", Swap.Fields("NombreLocal").Value),
                        .RazonLocal = If(Swap.Fields("RazonLocal").Value Is DBNull.Value, "", Swap.Fields("RazonLocal").Value),
                        .GiroLocal = If(Swap.Fields("GiroLocal").Value Is DBNull.Value, "", Swap.Fields("GiroLocal").Value),
                        .DireccionLocal = If(Swap.Fields("DirLocal").Value Is DBNull.Value, "", Swap.Fields("DirLocal").Value),
                        .CiudadLocal = If(Swap.Fields("NombreCiudad").Value Is DBNull.Value, "", Swap.Fields("NombreCiudad").Value),
                        .ComunaLocal = If(Swap.Fields("NombreComuna").Value Is DBNull.Value, "", Swap.Fields("NombreComuna").Value),
                        .EmailLocal = If(Swap.Fields("EMailLocal").Value Is DBNull.Value, "", Swap.Fields("EMailLocal").Value),
                        .FonoLocal = If(Swap.Fields("TelefonosLocal").Value Is DBNull.Value, "", Swap.Fields("TelefonosLocal").Value),
                        .Horarios = If(Swap.Fields("HorarioLocal").Value Is DBNull.Value, "", Swap.Fields("HorarioLocal").Value),
                        .SII = If(Swap.Fields("SII").Value Is DBNull.Value, "", Swap.Fields("SII").Value),
                        .BancoDeposito = If(Swap.Fields("BancoDeposito").Value Is DBNull.Value, "", Swap.Fields("BancoDeposito").Value),
                        .CuentaDeposito = If(Swap.Fields("CuentaDeposito").Value Is DBNull.Value, "", Swap.Fields("CuentaDeposito").Value),
                        .RutDeposito = If(Swap.Fields("RutDeposito").Value Is DBNull.Value, "", Swap.Fields("RutDeposito").Value),
                        .TitularDeposito = If(Swap.Fields("TitularDeposito").Value Is DBNull.Value, "", Swap.Fields("TitularDeposito").Value),
                        .CorreoDeposito = If(Swap.Fields("CorreoDeposito").Value Is DBNull.Value, "", Swap.Fields("CorreoDeposito").Value),
                        .TipoDoc = If(Swap.Fields("TipoDoc").Value Is DBNull.Value, "", Swap.Fields("TipoDoc").Value),
                        .DescTipoDoc = If(wNombreDocumento = "", "", wNombreDocumento), 'if(Swap.Fields("DescTipoDoc").Value),,),
                        .Numero = If(Swap.Fields("Numero").Value Is DBNull.Value, "", Swap.Fields("Numero").Value),
                        .Fecha = If(Swap.Fields("Fecha").Value Is DBNull.Value, "", Swap.Fields("Fecha").Value),
                        .Cliente = If(Swap.Fields("Cliente").Value Is DBNull.Value, "", Swap.Fields("Cliente").Value),
                        .Rut = If(Swap.Fields("Rut").Value Is DBNull.Value, "", Swap.Fields("Rut").Value),
                        .Nombre = If(Swap.Fields("Nombre").Value Is DBNull.Value, "", Swap.Fields("Nombre").Value),
                        .Direccion = If(Swap.Fields("Direccion").Value Is DBNull.Value, "", Swap.Fields("Direccion").Value),
                        .Giro = If(Swap.Fields("Giro").Value Is DBNull.Value, "", Swap.Fields("Giro").Value),
                        .Ciudad = If(Swap.Fields("CiudadCli").Value Is DBNull.Value, "", Swap.Fields("CiudadCli").Value),
                        .Comuna = If(Swap.Fields("ComunaCli").Value Is DBNull.Value, "", Swap.Fields("ComunaCli").Value),
                        .Telefono = If(Swap.Fields("Telefonos").Value Is DBNull.Value, "", Swap.Fields("Telefonos").Value),
                        .Contacto = If(Swap.Fields("Contacto").Value Is DBNull.Value, "", Swap.Fields("Contacto").Value),
                        .Correo = If(Swap.Fields("EMail").Value Is DBNull.Value, "", Swap.Fields("EMail").Value),
                        .FPago = If(Swap.Fields("DescFPago").Value Is DBNull.Value, "", Swap.Fields("DescFPago").Value),
                        .OC = If(Swap.Fields("OC").Value Is DBNull.Value, "", Swap.Fields("OC").Value),
                        .Motivo = If(Swap.Fields("DescMotivo").Value Is DBNull.Value, "", Swap.Fields("DescMotivo").Value),
                        .TipoDocRef = If(Swap.Fields("TipoDocReferencia").Value Is DBNull.Value, "", Swap.Fields("TipoDocReferencia").Value),
                        .DescTipoDocRef = If(Swap.Fields("DescTipoDocRef").Value Is DBNull.Value, "", Swap.Fields("DescTipoDocRef").Value),
                        .NumTipoDocRef = If(Swap.Fields("NumDocReferencia").Value Is DBNull.Value, "", Swap.Fields("NumDocReferencia").Value),
                        .FechaTipoDocRef = If(Swap.Fields("FechaDocReferencia").Value Is DBNull.Value, "", Swap.Fields("FechaDocReferencia").Value),
                        .Observaciones = If(Swap.Fields("Observaciones").Value Is DBNull.Value, "", Swap.Fields("Observaciones").Value),
                        .Articulo = If(Swap.Fields("Articulo").Value Is DBNull.Value, "", Swap.Fields("Articulo").Value),
                        .Descripcion = If(Swap.Fields("Descripcion").Value Is DBNull.Value, "", Swap.Fields("Descripcion").Value),
                        .Glosa = If(Swap.Fields("Glosa").Value Is DBNull.Value, "", Swap.Fields("Glosa").Value),
                        .Barra = "",
                        .Unidad = If(Swap.Fields("DescUnidad").Value Is DBNull.Value, "", Swap.Fields("DescUnidad").Value),
                        .Cantidad = If(Swap.Fields("Cantidad").Value Is DBNull.Value, "", Swap.Fields("Cantidad").Value),
                        .Precio = If(Swap.Fields("Precio").Value Is DBNull.Value, "", Swap.Fields("Precio").Value),
                        .PVenta = If(Swap.Fields("PVenta").Value Is DBNull.Value, "", Swap.Fields("PVenta").Value),
                        .Neto = If(Swap.Fields("Neto").Value Is DBNull.Value, "", Swap.Fields("Neto").Value),
                        .Descuento = If(Swap.Fields("Descuento").Value Is DBNull.Value, "", Swap.Fields("Descuento").Value),
                        .IVA = If(Swap.Fields("IVA").Value Is DBNull.Value, "", Swap.Fields("IVA").Value),
                        .Total = If(Swap.Fields("Total").Value Is DBNull.Value, "", Swap.Fields("Total").Value),
                        .NResolucion = If(Swap.Fields("NResolucion").Value Is DBNull.Value, "", Swap.Fields("NResolucion").Value),
                        .FResolucion = If(Swap.Fields("FResolucion").Value Is DBNull.Value, "", Swap.Fields("FResolucion").Value),
                        .Grupo = gTipoCopia(i - 1)})
                    Swap.MoveNext()
                End While
                Swap.MoveFirst()
            Next
        Catch ex As Exception
            MsgError(ex.Message)
        End Try

        Dim wArchivo As String
        Dim wFirma = SQL("SELECT Firma FROM DocumentosG WHERE Numero = " & gNumero & " AND TipoDoc = '" & gTipoDoc & "'")
        Dim wFir As New List(Of DocumentosG)
        If wFirma.RecordCount > 0 Then
            Try
                wFir.Add(New DocumentosG With {.Firma = wFirma.Fields("Firma").Value})
            Catch ex As Exception
                'Documento no es electrónico o no tiene firma
            End Try
        End If

        If Lista.Count > 0 Then
            gReporte.Database.Tables("SisVen_DTE_Documentos").SetDataSource(Lista)
            gReporte.Database.Tables("SisVen_LocalesReporte").SetDataSource(ListLocal)
            gReporte.Database.Tables("SisVen_DocumentosG").SetDataSource(wFir)

            Try
                wArchivo = Archivo_Fiscal(gPDF, gLocal, gTipoDoc, gNumero, 0)
                If Not Busca_Archivo(wArchivo) Then
                    gReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, wArchivo)
                Else
                    'No se crea porque existe
                End If
            Catch ex As Exception
                'No se pudo crear el PDF: Acceso restingido al directorio o archivo abierto
            End Try

            If ModuloReporte = "ImprimirDocumentos" Then
                Visor_Reporte.ReportSource = gReporte
            End If
            If ModuloReporte = "Documentos" Then
                Visor_Reporte.ReportSource = gReporte
            End If
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentraron datos")
            Close()
        End If
    End Sub

    Public Sub VisorParametros(ByVal wQuery As String, wReporte As ReportClass)
        gQuery = wQuery
        gReporte = wReporte
    End Sub

    Private Sub VisorReportes_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Cursor = Cursors.Arrow
        Modulo = ""
    End Sub

    Private Sub Visor_Reporte_Load(sender As Object, e As EventArgs) Handles Visor_Reporte.Load

    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        Me.Close()
    End Sub
End Class