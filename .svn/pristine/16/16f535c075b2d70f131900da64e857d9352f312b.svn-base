Public Class MovimientoStockPOS
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
    Private Sub LlenarCombo()
        Dim wLista As New List(Of DateComboBox)
        Dim wBog = SQL("SELECT b.bodega, b.NombreBodega FROM Bodegas B" &
                       " JOIN Stocks S ON B.Bodega = s.Bodega" &
                       " WHERE Movil = 1 and s.Stock > 0 AND B.Local = " & LocalActual & "" &
                       " GROUP BY b.bodega, b.NombreBodega")

        While Not wBog.EOF
            wLista.Add(New DateComboBox With {.ID = wBog.Fields("Bodega").Text,
                                             .Descripcion = wBog.Fields("NombreBodega").Text})
            wBog.MoveNext()
        End While

        If wLista.Any Then
            cPOS.ValueMember = "ID"
            cPOS.DisplayMember = "Descripcion"
            cPOS.DataSource = wLista
        End If

        wLista = New List(Of DateComboBox)

        wBog = SQL("SELECT Bodega, NombreBodega FROM Bodegas" &
                   " WHERE Local = " & LocalActual & " AND Despacho = 1 Or Principal = 1 ")

        While Not wBog.EOF
            wLista.Add(New DateComboBox With {.ID = wBog.Fields("Bodega").Text,
                                             .Descripcion = wBog.Fields("NombreBodega").Text})
            wBog.MoveNext()
        End While

        If wLista.Any Then
            cBodegaDestino.ValueMember = "ID"
            cBodegaDestino.DisplayMember = "Descripcion"
            cBodegaDestino.DataSource = wLista
        End If
    End Sub

    Private Sub Movimiento_de_Stock_de_POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCombo()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If cPOS.Text = "" Then
            Exit Sub
        End If
        If cBodegaDestino.Text = "" Then
            Exit Sub
        End If
        Dim wStock = SQL("SELECT SUM(STOCK) as stock FROM STOCKS" &
                         " WHERE LOCAL = " & LocalActual & " AND BODEGA = " & Val(cPOS.SelectedValue))

        If wStock.RecordCount = 0 Then
            MsgError("POS no tiene mercancia para devolver")
            Exit Sub
        Else
            If Val(wStock.Fields("Stock").Text) = 0 Then
                MsgError("POS con stock en cero(0)")
                Exit Sub
            End If
        End If

        Swap = SQL("SELECT * FROM STOCKS WHERE LOCAL = " & LocalActual & " AND BODEGA = " & Val(cPOS.SelectedValue))

        While Not Swap.EOF
            Stocks(Swap.Fields("Articulo").Text, Val(cPOS.SelectedValue), LocalActual, Swap.Fields("Stock").Text, "-")
            Stocks(Swap.Fields("Articulo").Text, Val(cBodegaDestino.SelectedValue), LocalActual, Swap.Fields("Stock").Text, "+")
            Swap.MoveNext()
        End While

        MsgBox("Artículos cargados a Bodega " & cBodegaDestino.Text & " correctamente")

    End Sub

    Private Sub bVisualizar_Click(sender As Object, e As EventArgs) Handles bVisualizar.Click

        If cPOS.Text = "" Then
            MsgError("Debe seleccionar un POS")
            Exit Sub
        End If

        Dim wStock = SQL("SELECT SUM(STOCK) as stock FROM STOCKS" &
                         " WHERE LOCAL = " & LocalActual & " AND BODEGA = " & Val(cPOS.SelectedValue))

        If wStock.RecordCount = 0 Then
            MsgError("POS no tiene mercancia para devolver")
            Exit Sub
        Else
            If Val(wStock.Fields("Stock").Text) = 0 Then
                MsgError("POS con stock en cero(0)")
                Exit Sub
            End If
        End If

        wStock = SQL("SELECT S.*, A.Descripcion, L.NombreLocal FROM STOCKS S" &
                     " JOIN Articulos A ON S.Articulo = A.Articulo " &
                     " JOIN Locales L ON S.Local = L.Local" &
                     " WHERE S.Local = " & LocalActual & " AND S.Bodega = " & Val(cPOS.SelectedValue))

        If wStock.RecordCount = 0 Then
            MsgError("POS no tiene artículos cargados")
        End If

        Dim wLista As New List(Of POSStock)
        While Not wStock.EOF
            wLista.Add(New POSStock With {.Local = LocalActual,
                                         .POS = cPOS.Text,
                                         .Cantidad = wStock.Fields("Stock").Text,
                                         .Articulo = wStock.Fields("Articulo").Text,
                                         .NombreArticulo = wStock.Fields("Descripcion").Text,
                                         .Bodega = Val(cPOS.SelectedValue),
                                         .NombreLocal = wStock.Fields("NombreLocal").Text})
            wStock.MoveNext()
        End While

        Dim wListParametros As New List(Of ParametrosReporte)
        Par = SQL("SELECT * FROM Parametros")
        If Par.RecordCount = 1 Then wListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

        Dim wListParametrosLocal As New List(Of ParametrosLocal)
        Swap = SQL("SELECT * FROM Locales WHERE Local = " & LocalActual)
        If Swap.RecordCount > 0 Then
            wListParametrosLocal.Add(New ParametrosLocal With {.Local = Swap.Fields("Local").Text,
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

        Dim wReporte As New StockPOS
        wReporte.Database.Tables("SisVen_POSStock").SetDataSource(wLista)
        wReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(wListParametros)
        wReporte.Database.Tables("SisVen_ParametrosLocal").SetDataSource(wListParametrosLocal)

        VisorReportes.Visor_Reporte.ReportSource = wReporte
        VisorReportes.WinDeco1.TituloVentana = "Stock de " & cPOS.Text
        VisorReportes.Show()
        VisorReportes.BringToFront()
    End Sub
End Class