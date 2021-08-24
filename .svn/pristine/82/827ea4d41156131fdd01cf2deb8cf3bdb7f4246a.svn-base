Public Class ConsultaDocumento
    Implements iFormulario
    Private Sub ConsultaDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        cDocumento.LoadCombobox("TipoDoc", "TipoDOc", "DescTipoDoc")
        cFormaPago.LoadCombobox("FPagos", "FPago", "DescFPago")

        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDocumento.KeyPress
        ValidarDigitos(e)
        e.NextControl(xCliente)
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        e.NextControl(xVendedor)
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text.Trim = "" Then Exit Sub

        Cli = SQL("SELECT Nombre From Clientes WHERE Cliente = '" & xCliente.Text.Trim & "'")
        If Cli.RecordCount > 0 Then
            xNombreC.Text = Cli.Fields("Nombre").Text
        Else
            MsgError("CLiente no registrado")
            xCliente.Clear()
            xNombreC.Clear()
            xCliente.Focus()
        End If
    End Sub

    Private Sub xVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVendedor.KeyPress
        e.NextControl(xTicket)
    End Sub

    Private Sub xVendedor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xVendedor.Validating
        If xVendedor.Text.Trim = "" Then Exit Sub

        Ven = SQL("SELECT NOmbreUsr FROM Usuarios WHERE Usuario = '" & xVendedor.Text & "'")
        If Ven.RecordCount > 0 Then
            xNombreV.Text = Ven.Fields("NombreUsr").Text
        Else
            MsgError("Vendedor no registrado")
            xVendedor.Clear()
            xNombreV.Clear()
            xVendedor.Focus()
        End If
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(oDetalle)
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If xArticulo.Text.Trim = "" Then Exit Sub

        Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & xArticulo.Text.Trim & "'")
        If Art.RecordCount > 0 Then
            xDescripcion.Text = Art.Fields("DEscripcion").Text.Trim
        Else
            MsgError("Artículo no registrado")
            xArticulo.Clear()
            xDescripcion.Clear()
            xArticulo.Focus()
        End If
    End Sub

    Private Sub bBuscarV_Click(sender As Object, e As EventArgs) Handles bBuscarV.Click
        Dim wQuery As String
        wQuery = "SELECT Usuario as 'Vendedor', NombreUsr as 'Nombre' From Usuarios"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreUsr", Me, "Vendedores", xVendedor)
    End Sub

    Private Sub bBuscarA_Click(sender As Object, e As EventArgs) Handles bBuscarA.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub

    Private Sub bBuscarC_Click(sender As Object, e As EventArgs) Handles bBuscarC.Click
        Dim wQuery As String
        wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre Cliente' From Clientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Nombre", Me, "Clientes", xCliente)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub xTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTicket.KeyPress
        ValidarDigitos(e)
        e.NextControl(cFormaPago)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""

        If dDesde.Value > dHasta.Value Then
            MsgError("La fecha inicial no pueder ser mayor a la final")
            Exit Sub
        End If
        If dHasta.Value < dDesde.Value Then
            MsgError("La fecha final no puede ser menor a la ficha inicial")
            Exit Sub
        End If

        If ValidarCombo(cLocal) Then wFiltros += " AND L.Local = '" & Val(cLocal.SelectedValue) & "'"
        If ValidarCombo(cDocumento) Then wFiltros += " AND DG.TipoDoc = '" & cDocumento.SelectedValue.ToString & "'"
        If xDocumento.Text.Trim <> "" Then wFiltros += " AND DG.Numero = '" & xDocumento.Text.Trim & "'"
        If xCliente.Text.Trim <> "" Then wFiltros += " AND DG.CLiente = '" & xCliente.Text.Trim & "'"
        If xVendedor.Text.Trim <> "" Then wFiltros += " AND DG.Vendedor = '" & xVendedor.Text.Trim & "'"
        If xTicket.Text.Trim <> "" Then wFiltros += " AND DG.Ticket = '" & xTicket.Text.Trim & "'"
        If ValidarCombo(cFormaPago) Then wFiltros += " AND DG.FPago = '" & cFormaPago.SelectedValue.ToString & "'"
        If xArticulo.Text.Trim <> "" Then wFiltros += " AND A.Articulo = '" & xArticulo.Text.Trim & "'"

        Dim Lista = New List(Of DocumentoListado)




        If oDetalle.Checked Then
            Swap = SQL("SELECT L.Local,C.CLiente,C.Nombre,DG.TipoDoc,DG.Numero,DG.Fecha,DG.Estado,DG.FPago,DG.Vendedor," &
                     " DG.SubTotal,DG.Neto,DG.Descuento,DG.IVA,DG.Total,A.Articulo ,A.Descripcion,DD.Cantidad,DD.PVenta,P.DescFPago" &
                     " From DocumentosG DG" &
                     " JOIN Locales L On DG.Local = L.Local" &
                     " JOIN Clientes C ON DG.Cliente = C.Cliente" &
                     " JOIN DocumentosD DD ON DG.Numero = DD.Numero" &
                     " JOIN Articulos A ON DD.Articulo = A.Articulo " &
                     " JOIN FPagos P ON DG.FPAgo = P.FPago" &
                     " WHERE DG.Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "' " & wFiltros)

            wReporte = New ReporteDocumentoDet
            While Not Swap.EOF
                Lista.Add(New DocumentoListado With {.Local = Swap.Fields("Local").Text,
                                                     .Cliente = Swap.Fields("Cliente").Text,
                                                     .NombreCliente = Swap.Fields("Nombre").Text,
                                                     .Documento = Swap.Fields("Numero").Text,
                                                     .Fecha = Swap.Fields("Fecha").Text,
                                                     .Estado = Swap.Fields("Estado").Text,
                                                     .FPago = Swap.Fields("FPAgo").Text,
                                                     .Vendedor = Swap.Fields("Vendedor").Text.ToUpper,
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
        Else
            Swap = SQL("SELECT L.Local,C.CLiente,C.Nombre,DG.TipoDoc,DG.Numero,DG.Fecha,DG.Estado,DG.FPago,DG.Vendedor," &
                     " DG.SubTotal,DG.Neto,DG.Descuento,DG.IVA,DG.Total,P.DescFPago" &
                     " From DocumentosG DG" &
                     " JOIN Locales L On DG.Local = L.Local" &
                     " JOIN Clientes C ON DG.Cliente = C.Cliente" &
                     " JOIN FPagos P ON DG.FPAgo = P.FPago" &
                     " WHERE DG.Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "' " & wFiltros)

            wReporte = New ReporteDocumento
            While Not Swap.EOF
                Lista.Add(New DocumentoListado With {.Local = Swap.Fields("Local").Text,
                                                     .Cliente = Swap.Fields("Cliente").Text,
                                                     .NombreCliente = Swap.Fields("Nombre").Text,
                                                     .Documento = Swap.Fields("Numero").Text,
                                                     .Fecha = Swap.Fields("Fecha").Text,
                                                     .Estado = Swap.Fields("Estado").Text,
                                                     .FPago = Swap.Fields("FPAgo").Text,
                                                     .Vendedor = Swap.Fields("Vendedor").Text.ToUpper,
                                                     .SubTotal = Swap.Fields("SubTotal").Text,
                                                     .Descuento = Swap.Fields("Descuento").Text,
                                                     .Neto = Swap.Fields("Neto").Text,
                                                     .Iva = Swap.Fields("IVA").Text,
                                                     .Total = Swap.Fields("Total").Text,
                                                     .TipoDoc = Swap.Fields("TipoDoc").Text})
                Swap.MoveNext()
            End While
        End If

        If Lista.Count > 0 Then
            Dim wParametros As New List(Of ParametrosReporte)
            Par = SQL("SELECT * FROM Parametros")
            If Par.RecordCount = 1 Then wParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

            wReporte.Database.Tables("SisVen_DocumentoListado").SetDataSource(Lista)
            wReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(wParametros)
            VisorReportes.WinDeco1.TituloVentana = "Listado de Documento"
            VisorReportes.Visor_Reporte.ReportSource = wReporte
            VisorReportes.Show()
        Else
            Cursor = Cursors.Arrow
            MsgError("No se encuentran datos para la selección indicada")
            Close()
        End If
        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
    End Sub
End Class