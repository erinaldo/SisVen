Imports System.Linq

Imports Parametros

Public Class Stock

    Public Enum Operacion
        Sumar = 0
        Restar = 1
        Igual = 2
    End Enum

    Public Shared Function ConsultarStock(wArticulo As String, wBodega As Double, wLocal As Double) As Double
        Dim wDC As New BaseSisVenDataContext(P_CONEXION)
        Dim wStk = wDC.Stocks.FirstOrDefault(Function(x) x.Articulo = wArticulo And x.Bodega = wBodega)
        If wStk Is Nothing OrElse wStk.Stock <= 0 Then
            Return 0
        End If
        Return wStk.Stock
    End Function
    Public Shared Function Stocks(wArticulo As String, wBodega As Double, wLocal As Double, wCantidad As Double, wOperacion As Operacion) As Double

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wRetorno As Double = 0


        Dim wSTK = wDC.Stocks.FirstOrDefault(Function(x) x.Articulo = wArticulo And x.Bodega = wBodega And x.Local = wLocal)

        If wSTK Is Nothing Then
            If wOperacion = Operacion.Igual Then
                Return wRetorno
            End If

            Dim wStock = New Stocks

            wStock.Articulo = Trim(wArticulo)
            wStock.Bodega = wBodega
            wStock.Local = wLocal
            If wOperacion = Operacion.Sumar Then
                wStock.Stock = wCantidad
            ElseIf wOperacion = Operacion.Restar Then
                wStock.Stock = wCantidad * -1
            End If
            wStock.StockMin = 0
            wStock.StockMax = 10000

            wDC.Stocks.InsertOnSubmit(wStock)

            wRetorno = wStock.Stock
        Else

            If wOperacion = Operacion.Sumar Then
                wSTK.Stock += wCantidad
            End If
            If wOperacion = Operacion.Restar Then
                wSTK.Stock -= wCantidad
            End If

            wRetorno = wSTK.Stock

        End If

        wDC.SubmitChanges()

        Return wRetorno
    End Function


    Public Shared Function Generar_Stocks_ZPL(wBodega As Integer, wLocal As Integer) As String

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wLinea As Integer

        Dim wRespuesta = ""

        Dim wStock = New List(Of StockArticulo)
        Dim wStockBodega = wDC.Stocks.Where(Function(x) x.Bodega = wBodega And x.Local = wLocal And x.Articulo <> "0") _
            .OrderBy(Function(x) x.Local).ThenBy(Function(x) x.Bodega).ThenBy(Function(x) x.Articulo).ToList
        Dim wArticulos = wDC.Articulos.ToList
        Dim wUnidades = wDC.Unidades.ToList


        For Each Stk In wStockBodega
            Dim wStk = New StockArticulo
            Dim wArt = wArticulos.FirstOrDefault(Function(x) x.Articulo = Stk.Articulo)
            wStk.Articulo = wArt.Articulo
            wStk.Descripcion = wArt.Descripcion
            wStk.PrecioVenta = wArt.PVenta

            Dim wUnidad = wUnidades.FirstOrDefault(Function(x) x.Unidad = wArt.Unidad)
            If wUnidad Is Nothing Then
                wStk.UnidadMedida = ""
            Else
                wStk.UnidadMedida = wUnidad.DescUnidad
            End If

            If wArt Is Nothing Then
                wStk.CantidadStock = 0
            Else
                wStk.CantidadStock = Stk.Stock
            End If

            If wArt.Estado = "A" Then wStock.Add(wStk)
        Next

        wStock = wStock.OrderBy(Function(x) x.Descripcion).ToList

        If Not wStock.Any Then Return ""

        Dim wLargo = 110 + (wStock.Count * 20)

        wRespuesta &= "^XA" & vbCrLf
        wRespuesta &= "^PRD" & vbCrLf
        wRespuesta &= "^FOI" & vbCrLf
        wRespuesta &= "^LH0, 0" & vbCrLf
        wRespuesta &= "^LL" & wLargo & vbCrLf

        wRespuesta &= "^A0N40,40^FO10,10^FDLISTADO DE STOCKS^FS"
        wRespuesta &= "^A0N20,20^FO540,20,1^FD" & Format(Now.Date, "dd/MM/yyyy") & "^FS"

        wRespuesta &= "^FO10,50^GB620,1,1^FS"
        wRespuesta &= "^A0N20,20^FO10,60^FDArticulo^FS"
        wRespuesta &= "^A0N20,20^FO100,60^FDDescripcion^FS"
        wRespuesta &= "^A0N20,20^FO460,60,1^FDU.M.^FS"
        wRespuesta &= "^A0N20,20^FO540,60,1^FDStock^FS"

        wRespuesta &= "^FO10,80^GB620,1,1^FS"

        'Detalles de Articulos        
        wLinea = 90
        For Each wStk In wStock
            wRespuesta &= "^A0N20,20^FO10," & wLinea & "^FD" & wStk.Articulo & "^FS"
            wRespuesta &= "^A0N20,20^FO100," & wLinea & "^FD" & DTE.FormatoTexto(Funciones.Truncate(wStk.Descripcion, 28)) & "^FS"
            'wRespuesta &= "^A0N20,20^FO460," & wLinea & ",1^FD" & wStk.UnidadMedida & "^FS"
            wRespuesta += "^A0N20,20^FO470," & wLinea & ",1^FD" & DTE.FormatoTexto(wStk.UnidadMedida) & "^FS"
            wRespuesta &= "^A0N20,20^FO540," & wLinea & ",1^FD" & Format(wStk.CantidadStock, "###,###,##0.00") & "^FS"

            wLinea += 20
        Next

        wRespuesta &= "^FO10," & wLinea & "^GB620,1,1^FS" & vbCrLf
        wRespuesta &= "^XZ" & vbCrLf


        Return wRespuesta
    End Function

    Public Shared Function Generar_Lista_Precios_ZPL() As String

        Dim wDC As New BaseSisVenDataContext(P_CONEXION)

        Dim wLinea As Integer

        Dim wRespuesta = ""

        Dim wStock = New List(Of StockArticulo)
        Dim wArticulos = wDC.Articulos.Where(Function(x) x.Articulo <> "0").OrderBy(Function(x) x.Descripcion).ToList
        Dim wUnidades = wDC.Unidades.ToList

        Dim wLargo = 110 + (wArticulos.Count * 20)

        wRespuesta &= "^XA" & vbCrLf
        wRespuesta &= "^PRD" & vbCrLf
        wRespuesta &= "^FOI" & vbCrLf
        wRespuesta &= "^LH0, 0" & vbCrLf
        wRespuesta &= "^LL" & wLargo & vbCrLf

        wRespuesta &= "^A0N40,40^FO10,10^FDLISTADO DE PRECIOS^FS"
        wRespuesta &= "^A0N20,20^FO540,20,1^FD" & Format(Now.Date, "dd/MM/yyyy") & "^FS"

        wRespuesta &= "^FO10,50^GB620,1,1^FS"
        wRespuesta &= "^A0N20,20^FO10,60^FDArticulo^FS"
        wRespuesta &= "^A0N20,20^FO100,60^FDDescripcion^FS"
        wRespuesta &= "^A0N20,20^FO460,60,1^FDU.M.^FS"
        wRespuesta &= "^A0N20,20^FO540,60,1^FDP.Venta^FS"

        wRespuesta &= "^FO10,80^GB620,1,1^FS"

        'Detalles de Articulos      




        wLinea = 90
        For Each wArt In wArticulos
            wRespuesta += "^A0N20,20^FO10," & wLinea & "^FD" & wArt.Articulo & "^FS"
            wRespuesta += "^A0N20,20^FO100," & wLinea & "^FD" & DTE.FormatoTexto(Funciones.Truncate(wArt.Descripcion.Trim, 28)) & "^FS"
            Dim wUnidad = wUnidades.FirstOrDefault(Function(x) x.Unidad = wArt.Unidad)
            wRespuesta += "^A0N20,20^FO470," & wLinea & ",1^FD" & DTE.FormatoTexto(If(wUnidad Is Nothing, "", wUnidad.DescUnidad)) & "^FS"
            wRespuesta += "^A0N20,20^FO540," & wLinea & ",1^FD" & Format(wArt.PVenta, "###,###,##0") & "^FS"
            wLinea += 20
        Next

        wRespuesta &= "^FO10," & wLinea & "^GB620,1,1^FS" & vbCrLf
        wRespuesta &= "^XZ" & vbCrLf

        Return wRespuesta

    End Function


End Class
