Public Class ConsultaVentaBoleta
    Implements iFormulario
    Private Sub ConsultaVentaBoleta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        cFormaPago.LoadCombobox("FPagos", "FPago", "DescFPago")
    End Sub

    Private Sub xCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCaja.KeyPress
        ValidarDigitos(e)
        e.NextControl(xVendedor)
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
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wfiltros = ""

        If dDesde.Value > dHasta.Value Then
            MsgError("Fecha inicio no puede ser mayor a final")
            Exit Sub
        End If
        If dHasta.Value < dDesde.Value Then
            MsgError("La fecha final no pueder menor al la inicial")
            Exit Sub
        End If

        wfiltros = " WHERE Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"

        If ValidarCombo(cLocal) Then
            wfiltros += IIf(wfiltros = "", " WHERE ", " AND ") & " L.Local = " & cLocal.SelectedValue
        End If
        If xCaja.Text.Trim <> "" Then
            wfiltros += IIf(wfiltros = "", " WHERE ", " AND ") & " V.Caja = " & xCaja.Text.Trim
        End If
        If xVendedor.Text.Trim <> "" Then
            wfiltros += IIf(wfiltros = "", " WHERE ", " AND ") & " U.Usuario = '" & xVendedor.Text.Trim & "'"
        End If
        If xArticulo.Text.Trim <> "" Then
            wfiltros += IIf(wfiltros = "", " WHERE ", " AND ") & " A.Articulo = '" & xArticulo.Text.Trim & "'"
        End If
        If xTicket.Text.Trim <> "" Then
            wfiltros += IIf(wfiltros = "", " WHERE ", " AND ") & " V.Ticket = " & xTicket.Text.Trim
        End If
        If ValidarCombo(cFormaPago) Then
            wfiltros = IIf(wfiltros = "", " WHERE ", " AND ") & " F.FPago = '" & cFormaPago.SelectedValue & "'"
        End If

        Dim wQuery = "SELECT V.Fecha,L.Local,V.Caja,U.Usuario,F.DescFPago,V.NumDoc," &
                     "V.Ticket,TD.Articulo,A.Descripcion,TD.Cantidad,TD.PVenta" &
                     " FROM Ventas V" &
                     " JOIN Locales L ON V.Local = L.Local" &
                     " JOIN Usuarios U On V.Usuario = U.Usuario" &
                     " JOIN FPagos F ON V.FPago = F.FPago" &
                     " JOIN TikDet  TD ON V.Ticket = TD.Ticket" &
                     " JOIN Articulos A ON TD.Articulo = A.Articulo " & wfiltros

        Swap = SQL(wQuery)

        If Swap.RecordCount > 0 Then
            Dim wReporte As New ReporteVentasBoleta

            ModuloReporte = "ListadoVentasBoleta"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Listado de Ventas con Boletas"
            VisorReportes.Show()
        Else
            MsgError("No se encuentra registro")
            Exit Sub
        End If

        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
    End Sub

    Private Sub xVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVendedor.KeyPress
        e.NextControl(xArticulo)
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
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
End Class