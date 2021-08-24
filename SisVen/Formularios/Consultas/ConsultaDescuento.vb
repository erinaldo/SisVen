Public Class ConsultaDescuento
    Implements iFormulario
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
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ConsultaDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        cFormaPago.LoadCombobox("FPagos", "FPago", "DescFPago")
        cDocumento.LoadCombobox("TipoDoc", "TipoDoc", "DescTipoDoc", " WHERE TipoDoc = 'BV' Or TipoDoc = 'FV'")
    End Sub

    Private Sub xCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCaja.KeyPress
        ValidarDigitos(e)
        e.NextControl(xVendedor)
    End Sub
    Private Sub xVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVendedor.KeyPress
        e.NextControl(xArticulo)
    End Sub
    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(xTicket)
    End Sub

    Private Sub xTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTicket.KeyPress
        ValidarDigitos(e)
        e.NextControl(cFormaPago)
    End Sub

    Private Sub xVendedor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xVendedor.Validating
        If xVendedor.Text.Trim = "" Then
            xNombre.Clear()
            Exit Sub
        End If

        Ven = SQL("SELECT NombreUsr FROM Usuarios WHERE Usuario = '" & xVendedor.Text.Trim & "'")
        If Ven.RecordCount > 0 Then
            xNombre.Text = Ven.Fields("NombreUsr").Text
        Else
            MsgError("Vendedor no registrado")
            xVendedor.Clear()
            xNombre.Clear()
            xVendedor.Focus()
        End If
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If xArticulo.Text.Trim = "" Then
            xDescripcion.Clear()
            Exit Sub
        End If

        Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & xArticulo.Text.Trim & "'")

        If Art.RecordCount > 0 Then
            xDescripcion.Text = Art.Fields("Descripcion").Text
        Else
            MsgError("Artículo no registrado")
            xArticulo.Clear()
            xDescripcion.Clear()
            xArticulo.Focus()
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub xDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDocumento.KeyPress
        ValidarDigitos(e)
        e.NextControl(bImprimir)
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

        If ValidarCombo(cLocal) Then wFiltros += " AND V.Local = '" & cLocal.SelectedValue & "'"
        If xCaja.Text.Trim <> "" Then wFiltros += " AND V.Caja = '" & xCaja.Text.Trim & "'"
        If xVendedor.Text.Trim <> "" Then wFiltros += " AND V.Usuario = '" & xVendedor.Text.Trim & "'"
        If xArticulo.Text.Trim <> "" Then wFiltros += " AND TD.Articulo = '" & xArticulo.Text.Trim & "'"
        If xTicket.Text.Trim <> "" Then wFiltros += " AND V.Ticket = '" & xTicket.Text.Trim & "'"
        If ValidarCombo(cFormaPago) Then wFiltros += " AND V.FPago = '" & cFormaPago.SelectedValue & "'"
        If ValidarCombo(cDocumento) Then wFiltros += " AND V.TipoDoc = '" & cDocumento.SelectedValue & "'"
        If xDocumento.Text.Trim <> "" Then wFiltros += " AND V.NumDoc = '" & xDocumento.Text.Trim & "'"


        Dim wQuery = "SELECT V.Fecha,V.Local,V.Caja,V.Usuario,F.DescFPago,V.TipoDoc ,V.NumDoc,V.Ticket,TD.articulo,A.Descripcion, TG.Total,V.Descuento  From Ventas V" &
                     " JOIN TikGen TG ON V.Ticket = TG.Ticket" &
                     " JOIN TikDet TD ON TG.Ticket = TD.Ticket" &
                     " JOIN Articulos A ON TD.Articulo = A.Articulo" &
                     " JOIN FPagos F ON V.FPago = F.FPago" &
                     " WHERE V.Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "' " & wFiltros


        Swap = SQL(wQuery)

        If Swap.RecordCount > 0 Then
            Dim wReporte As New ReporteDescuento

            ModuloReporte = "ListadoDescuento"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Listado de Descuentos"
            VisorReportes.Show()
        Else
            MsgError("No se encuentra registro")
            Exit Sub
        End If

        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)

    End Sub
End Class