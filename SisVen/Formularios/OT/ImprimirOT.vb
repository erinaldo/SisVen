Public Class ImprimirOT
    Public wOT As Integer
    Dim wVisor As New VisorReportes
    Private Sub ImprimirOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub bImprimirOT_Click(sender As Object, e As EventArgs) Handles bImprimirOT.Click
        Dim wFiltros = ""
        Dim wQuery = ""
        Dim wReporte As New ReporteOT

        wQuery = "SELECT O.OT, C.Rut,C.Nombre,C.Direccion,C.Ciudad,C.Telefonos,O.Fecha,O.FechaEntrega,O.TecnicoRevision,O.Codigo," &
                 " O.Recepcion,O.ObsCliente,O.ObsTecnico," &
                 " OD.Articulo,A.Descripcion,OD.Cantidad,A.PVenta" &
                 " FROM OT O" &
                 " JOIN Clientes C ON O.Cliente = C.Cliente" &
                 " JOIN OTDet OD ON O.OT = OD.OT" &
                 " JOIN Articulos A ON OD.Articulo = A.Articulo" &
                 " WHERE O.OT = '" & wOT & "'"

        If oAutomatico.Checked Then
            Dim Lista = New List(Of OTReporte)
            Swap = SQL(wQuery)
            While Not Swap.EOF
                Lista.Add(New OTReporte With {.NumeroOT = Swap.Fields("OT").Text,
                                              .RUT = Swap.Fields("Rut").Text,
                                              .NombreCliente = Swap.Fields("Nombre").Text,
                                              .Direccion = Swap.Fields("Direccion").Text,
                                              .Ciudad = Swap.Fields("Ciudad").Text,
                                              .Telefono = Swap("Telefono").Text,
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
            End While

            If Lista.Count > 0 Then
                wReporte.Database.Tables(0).SetDataSource(Lista)
                wVisor.Visor_Reporte.ReportSource = wReporte
                wReporte.PrintToPrinter(1, False, 0, 0)
            Else
                Mensaje("No se encuentran datos para la selección indicada")
                Close()
            End If
        Else
            wQuery = wQuery
            ModuloReporte = "ListadoOT"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Listado Toma de Inventario"
            VisorReportes.Show()
        End If

    End Sub

    Private Sub bImprimirRevision_Click(sender As Object, e As EventArgs) Handles bImprimirRevision.Click
        Dim wFiltros = ""
        Dim wQuery = ""
        Dim wReporte As New ReporteRevisionOTMecanico

        wQuery = "SELECT O.OT,O.Tecnico, OD.Articulo,A.Descripcion,OD.Cantidad,A.PVenta" &
                 " FROM OT O" &
                 " JOIN Clientes C ON O.Cliente = C.Cliente" &
                 " JOIN OTDet OD ON O.OT = OD.OT" &
                 " JOIN Articulos A ON OD.Articulo = A.Articulo" &
                 " WHERE O.OT = '" & wOT & "'"




        If oAutomatico.Checked Then
            Dim Lista = New List(Of RevisionOTMecanicoListado)
            Swap = SQL(wQuery)
            While Not Swap.EOF
                Lista.Add(New RevisionOTMecanicoListado With {.NumeroOT = Swap.Fields("OT").Text,
                                                              .tecnico = Swap.Fields("Tecnico").Text,
                                                              .Articulo = Swap.Fields("Articulo").Text,
                                                              .Descripcion = Swap.Fields("Descripcion").Text,
                                                              .Cantidad = Swap.Fields("Cantidad").Text})
            End While

            If Lista.Count > 0 Then
                wReporte.Database.Tables(0).SetDataSource(Lista)
                wVisor.Visor_Reporte.ReportSource = wReporte
                wReporte.PrintToPrinter(1, False, 0, 0)
            Else
                Mensaje("No se encuentran datos para la selección indicada")
                Close()
            End If
        Else
            wQuery = wQuery
            ModuloReporte = "ListadoRevisionOTMecanico"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Listado Revisión de OT - Mecanico"
            VisorReportes.Show()
        End If
    End Sub

    Private Sub bImprimirRepuestos_Click(sender As Object, e As EventArgs) Handles bImprimirRepuestos.Click
        Dim wFiltros = ""
        Dim wQuery = ""
        Dim wReporte As New ReporteRepuestosPendietes

        wQuery = "SELECT O.OT,OD.FechaSol, OD.Articulo,A.Descripcion,OD.Cantidad,A.PVenta" &
                 " FROM OT O" &
                 " JOIN Clientes C ON O.Cliente = C.Cliente" &
                 " JOIN OTDet OD ON O.OT = OD.OT" &
                 " JOIN Articulos A ON OD.Articulo = A.Articulo" &
                 " WHERE O.OT = '" & wOT & "' AND OD.Estado = 'E'"




        If oAutomatico.Checked Then
            Dim Lista = New List(Of RepuestosPendientesListado)
            Swap = SQL(wQuery)
            While Not Swap.EOF
                Lista.Add(New RepuestosPendientesListado With {.NumeroOT = Swap.Fields("OT").Text,
                                                              .Fecha = Swap.Fields("FechaSol").Text,
                                                              .Articulo = Swap.Fields("Articulo").Text,
                                                              .Descripcion = Swap.Fields("Descripcion").Text,
                                                              .Cantidad = Swap.Fields("Cantidad").Text})
            End While

            If Lista.Count > 0 Then
                wReporte.Database.Tables(0).SetDataSource(Lista)
                wVisor.Visor_Reporte.ReportSource = wReporte
                wReporte.PrintToPrinter(1, False, 0, 0)
            Else
                Mensaje("No se encuentran datos para la selección indicada")
                Close()
            End If
        Else
            ModuloReporte = "ListadoRepuestosPendientes"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Listado repuestos pendientes"
            VisorReportes.Show()
        End If
    End Sub
End Class