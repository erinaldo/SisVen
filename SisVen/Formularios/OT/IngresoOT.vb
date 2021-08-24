Imports System.ComponentModel

Public Class IngresoOT
    Implements iFormulario
    Dim wOT As Double
    Const T_ELIMINAR = 0
    Const T_ARTICULO_SERVICIO = 1
    Const T_DESCRIPCION_SERVICIO = 2
    Const T_COSTO_SERVICIO = 3

    Const T_ARTICULO = 1
    Const T_DESCRIPCION = 2
    Const T_STOCK = 3
    Const T_COSTO = 4

    Dim NARANJO As Long
    Dim NARANJO_TXT As Long
    Dim BLANCO As Long
    Dim NEGRO As Long
    Dim wEstadoOT As String
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub IngresoOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NuevaOT()
        Titulos()
        TitulosArt()
        Swap = SQL("SELECT DescEstado,Estado FROM Estados WHERE ESTADO = 'I' AND TIPO = 'O'")
        If Swap.RecordCount = 1 Then
            xEstado.Text = UCase(Swap.Fields("DescEstado").Value)
            wEstadoOT = Swap.Fields("Estado").Value
        End If
        dFecha.Value = Now
        dFechaEntrega.Value = Now
    End Sub


    Sub NuevaOT()
        OT = SQL("SELECT TOP 1 OT FROM OT ORDER BY OT DESC")
        If OT.EOF Then
            wOT = 1
        Else
            wOT = Val(OT.Fields("OT").Value) + 1
        End If

        xOT.Text = wOT
        dFecha.Value = Now
    End Sub

    Private Sub bAgregar_Click(sender As Object, e As EventArgs) Handles bAgregar.Click
        If Trim(xServicio.Text) <> "" Then
            Swap = SQL("Select * From Articulos WHERE Articulo = '" & Trim(xServicio.Text) & "' AND Familia = 6")
            If Swap.RecordCount > 0 Then
                xTabla.AddItem("")
                xTabla.SetCellImage(xTabla.Rows.Count - 1, T_ELIMINAR, My.Resources.remove_table)
                xTabla.SetData(xTabla.Rows.Count - 1, T_ARTICULO_SERVICIO, Swap.Fields("Articulo").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_DESCRIPCION_SERVICIO, Swap.Fields("Descripcion").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_COSTO_SERVICIO, Swap.Fields("PVenta").Text)
            Else
                MsgError("Servicio no encontrado")
            End If

            xServicio.Text = ""
            xNombreServicio.Text = ""
            xServicio.Focus()
        End If
        TotalOT()
    End Sub

    Private Sub bAgregarA_Click(sender As Object, e As EventArgs) Handles bAgregarA.Click
        Dim wStock As Integer
        Dim wStockTabla As Integer
        Dim wArticulos As String
        wStock = 0
        wStockTabla = 0

        If Trim(xArticulo.Text) = "" Then
            MsgError("Debe ingresar codigo de artículo")
            xArticulo.Focus()
            Exit Sub
        End If


        Swap = SQL("Select * From Articulos WHERE Articulo = '" & Trim(xArticulo.Text) & "' AND Familia <> 6")

        If Swap.RecordCount > 0 Then
            xTablaArticulos.AddItem("")
            xTablaArticulos.SetCellImage(xTablaArticulos.Rows.Count - 1, T_ELIMINAR, My.Resources.remove_table)
            xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_ARTICULO, Swap.Fields("Articulo").Text)
            xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_DESCRIPCION, Swap.Fields("Descripcion").Text)
            xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_COSTO, Swap.Fields("PVenta").Text)

            For i = 1 To xTablaArticulos.Rows.Count - 1
                wArticulos = xTablaArticulos.GetData(i, T_ARTICULO)
                If Trim(xArticulo.Text) = wArticulos Then
                    wStockTabla = wStockTabla + 1
                End If
            Next
            Stk = SQL("SELECT (Case  WHEN Stock<=0 THEN 0 ELSE Stock END) as Stock " &
                      " FROM Stocks WHERE Local=" & LocalActual & " AND Articulo='" & Trim(xArticulo.Text) & "'")
            If Stk.EOF Then
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_STOCK, "Sin Stock")
                xTablaArticulos.FondoCelda(xTablaArticulos.Rows.Count - 1, C_NARANJO)
                wStock = 0
            Else
                wStock = Stk.Fields("Stock").Value
            End If
            wStock = wStock - wStockTabla

            If wStock <= 0 Then
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_STOCK, "Sin Stock")
                xTablaArticulos.FondoCelda(xTablaArticulos.Rows.Count - 1, C_NARANJO)
            Else
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_STOCK, "Disponible")
            End If

            xTablaArticulos.Row = xTablaArticulos.Rows.Count - 1
            xTablaArticulos.Col = 0
            TotalOT()
            xArticulo.Clear()
            xDescripcion.Clear()
            xArticulo.Focus()
        Else
            MsgError("Artículo no encontrado")
            xArticulo.Text = ""
            xDescripcion.Text = ""
            xArticulo.Focus()
        End If
    End Sub

    Private Sub bBuscarS_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bBuscarS.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos WHERE Familia = 6"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub

    Private Sub bBuscarA_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bBuscarA.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub

    Private Sub bBuscarOT_Click(sender As Object, e As EventArgs) Handles bBuscarOT.Click

    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        If xOT.Text.Trim <> "" Then
            OT = SQL("SELECT * FROM OT WHERE OT = '" & xOT.Text.Trim & "'")
            If OT.RecordCount > 0 Then
                ImprimirOT.wOT = xOT.Text.Trim
                ImprimirOT.WinDeco1.Titulo.Text = "Impresión de OT N° " & Val(xOT.Text)
                ImprimirOT.Show()
                ImprimirOT.BringToFront()
            Else
                MsgError("OT no encontrada")
            End If
        Else
            MsgError("Debe ingresar numero de OT")
            xOT.Focus()
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If xOT.Text.Trim = "" Then
            MsgError("El Campo OT no puede estar vacío")
            xOT.Focus()
            Exit Sub
        End If
        If dFecha.Value > Now Then
            MsgError("No puedes ingresar una OT con Fecha mayor a la actual")
            Exit Sub
        End If
        If xCliente.Text.Trim = "" Then
            MsgError("El Campo Cliente no puede estar vacío")
            xCliente.Focus()
            Exit Sub
        End If
        If xProductoR.Text.Trim = "" Then
            MsgError("El campo producto recibido no puede estar vacío")
            xProductoR.Focus()
            Exit Sub
        End If
        If xTabla.Rows.Count - 1 = 0 Then
            MsgError("No se puede ingresar la OT sin servicios")
            Exit Sub
        End If

        If Format(dFechaEntrega.Value, "dd/MM/yyyy") < Format(dFecha.Value, "dd/MM/yyy") Then
            MsgError("La fecha de entrega no puede ser menor a la fecha de creacion de la OT")
            Exit Sub
        End If

        IngresoOT()

        ImprimirOT.wOT = xOT.Text
        ImprimirOT.WinDeco1.Titulo.Text = "Impresión de OT N° " & Val(xOT.Text)
        ImprimirOT.Show()
        ImprimirOT.BringToFront()

        LimpiarCampos(Me)
    End Sub
    Sub IngresoOT()
        Dim wMensaje = ""
        Dim wEstad = ""
        Dim wTipoDoc = ""

        OT = SQL("Select Top 1 *  From OT Where OT=" & Val(xOT.Text.Trim) & "")
        If OT.EOF Then
            OT.AddNew()
            wMensaje = "ingresados"
        Else
            wMensaje = "actualizados"
        End If

        TotalOT()
        DoEvents()

        OT.Fields("OT").Value = Val(xOT.Text.Trim)
        OT.Fields("Fecha").Value = dFecha.Value
        OT.Fields("Cliente").Value = xCliente.Text.Trim
        OT.Fields("FechaEntrega").Value = dFechaEntrega.Value
        OT.Fields("ObsCliente").Value = xObsCliente.Text.Trim
        OT.Fields("ObsTecnico").Value = xObsTecnico.Text.Trim
        OT.Fields("TipoDoc").Value = ""
        OT.Fields("NumDoc").Value = 0
        OT.Fields("TotalOT").Value = Val(xTotalOT.Text)
        OT.Fields("Tecnico").Value = xTecnico.Text.Trim
        OT.Fields("Usuario").Value = UsuarioActual
        OT.Fields("Local").Value = LocalActual
        OT.Fields("Recepcion").Value = xProductoR.Text.Trim
        OT.Fields("Codigo").Value = xCodigoR.Text.Trim

        If xTecnico.Text <> "" Then
            OT.Fields("Tecnico").Value = xTecnico.Text.Trim
            OT.Fields("FechaAsignacion").Value = Now
            OT.Fields("Estado").Value = "A"
        Else
            OT.Fields("Estado").Value = "I"
        End If

        OT.Update()

        SQL("DELETE FROM OTDET WHERE OT = '" & Val(xOT.Text.Trim) & "'")

        For i = 1 To xTabla.Rows.Count - 1
            OTR = SQL("Select TOP 1 * FROM OTDet")
            OTR.AddNew()
            OTR.Fields("OT").Value = Val(xOT.Text.Trim)
            OTR.Fields("Fecha").Value = dFecha.Value
            OTR.Fields("Articulo").Value = xTabla.GetData(i, T_ARTICULO_SERVICIO)
            OTR.Fields("Cantidad").Value = 1
            OTR.Fields("FechaSol").Value = Now
            OTR.Fields("Estado").Value = "E"
            OTR.Fields("Tipo").Value = "S"
            OTR.Update()
        Next

        For i = 1 To xTablaArticulos.Rows.Count - 1
            OTR = SQL("Select TOP 1 * FROM OTDet")
            OTR.AddNew()
            OTR.Fields("OT").Value = Val(xOT.Text.Trim)
            OTR.Fields("Fecha").Value = dFecha.Value
            OTR.Fields("Articulo").Value = xTablaArticulos.GetData(i, T_ARTICULO)
            OTR.Fields("Cantidad").Value = 1
            OTR.Fields("FechaSol").Value = Now
            OTR.Fields("Estado").Value = "E"
            OTR.Fields("Tipo").Value = "A"
            OTR.Fields("Disponible").Value = IIf(xTablaArticulos.GetData(i, T_STOCK) = "Disponible", 1, 0)
            OTR.Update()
        Next


        MsgBox("Datos " & wMensaje & " Correctamente")

        'If La_Pregunta("¿Desea imprimir la OT?") = True Then
        '    Me.MousePointer = vbHourglass
        '    Salida.Reset
        '    Dim wFiltro As String
        '    wFiltro = "({ADO.OT} = " & Val(xOT.Text) & ")"
        '    Salida.SelectionFormula = wFiltro
        '    Salida.ReportFileName = Ruta_Imprimir("OT.RPT")
        '    Salida.Connect = ConectaReporte
        '    Salida.DiscardSavedData = True
        '    Salida.Destination = crptToPrinter
        '    Salida.Action = 1
        '    Me.MousePointer = vbDefault
        'End If


    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bNuevo_Click(sender As Object, e As EventArgs) Handles bNuevo.Click
        OT = SQL("SELECT TOP 1 OT FROM OT ORDER BY OT DESC")
        If OT.EOF Then
            wOT = 1
        Else
            wOT = Val(OT.Fields("OT").Value) + 1
        End If
        LimpiarCampos(Me)
        xOT.Text = wOT
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(bAgregarA)
    End Sub

    Private Sub xCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles xCliente.KeyDown
        If e.KeyCode = Keys.F3 Then
            bBuscar_Click()
        End If
    End Sub

    Private Sub bBuscar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bBuscar.Click
        Dim wQuery As String
        wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre' From Clientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Cliente", Me, "Clientes", xCliente)
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        If e.KeyChar = vbCr Then
            If xProductoR.Enabled Then xProductoR.Focus()
            DoEvents()
            Exit Sub
        End If
        ValidarDigitos(e)
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text <> "" Then
            Cli = SQL("SELECT Nombre FROM Clientes WHERE Cliente=" & Val(xCliente.Text) & "")
            If Cli.EOF Then
                MsgError("El Cliente ingresado no existe")
                xCliente.Focus()
                Exit Sub
            End If
            xNombre.Text = Trim(Cli.Fields("Nombre").Value)
        Else
            xNombre.Text = ""
        End If
        DoEvents()
    End Sub
    Sub Titulos()
        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 4

        xTabla.Cols(T_ELIMINAR).Width = 60
        xTabla.Cols(T_ELIMINAR).TextAlign = C1.Win.C1FlexGrid.ImageAlignEnum.LeftCenter
        xTabla.Cols(T_ARTICULO_SERVICIO).Width = 130
        xTabla.Cols(T_ARTICULO_SERVICIO).TextAlign = C1.Win.C1FlexGrid.ImageAlignEnum.LeftCenter
        xTabla.Cols(T_DESCRIPCION_SERVICIO).Width = 480
        xTabla.Cols(T_COSTO_SERVICIO).Width = 90


        xTabla.Cols(T_ELIMINAR).Caption = "Eliminar"
        xTabla.Cols(T_ARTICULO_SERVICIO).Caption = "Servicio"
        xTabla.Cols(T_DESCRIPCION_SERVICIO).Caption = "Descripción"
        xTabla.Cols(T_COSTO_SERVICIO).Caption = "Costo"
    End Sub
    Sub TitulosArt()
        xTablaArticulos.Clear()
        xTablaArticulos.Rows.Count = 1
        xTablaArticulos.Cols.Count = 5

        xTablaArticulos.Cols(T_ELIMINAR).Width = 60
        xTablaArticulos.Cols(T_ELIMINAR).TextAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
        xTablaArticulos.Cols(T_ARTICULO).Width = 130
        xTablaArticulos.Cols(T_ARTICULO_SERVICIO).TextAlign = C1.Win.C1FlexGrid.ImageAlignEnum.LeftCenter
        xTablaArticulos.Cols(T_DESCRIPCION).Width = 390
        xTablaArticulos.Cols(T_COSTO).Width = 90
        xTablaArticulos.Cols(T_STOCK).Width = 90

        xTablaArticulos.Cols(T_ELIMINAR).Caption = "Eliminar"
        xTablaArticulos.Cols(T_ARTICULO).Caption = "Artículo"
        xTablaArticulos.Cols(T_DESCRIPCION).Caption = "Descripción"
        xTablaArticulos.Cols(T_COSTO).Caption = "Costo"
        xTablaArticulos.Cols(T_STOCK).Caption = "Stock"
    End Sub
    Sub TotalOT()
        Dim TotalOT As Double

        If xTabla.Rows.Count - 1 > 0 Then
            For i = 1 To xTabla.Rows.Count - 1
                TotalOT = TotalOT + Num(xTabla.GetData(i, T_COSTO_SERVICIO))
            Next
            xTotalOT.Text = Math.Round(TotalOT, 0)
        Else
            xTotalOT.Text = 0
        End If

        If xTablaArticulos.Rows.Count - 1 > 0 Then
            For i = 1 To xTablaArticulos.Rows.Count - 1
                TotalOT = TotalOT + Num(xTablaArticulos.GetData(i, T_COSTO))
            Next
            xTotalOT.Text = Math.Round(TotalOT, 0)
        Else
            xTotalOT.Text = 0
        End If


    End Sub

    Private Sub xCodigoR_KeyDown(sender As Object, e As KeyEventArgs) Handles xCodigoR.KeyDown
        If e.KeyCode = Keys.F3 Then
            bConsultarP_Click()
        End If
    End Sub

    Private Sub bConsultarP_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bConsultarP.Click
        Modulo = "IngresarOT"
        If xCliente.Text.Trim <> "" Then
            Cli = SQL("SELECT * FROM CLIENTES WHERE CLIENTE = '" & xCliente.Text.Trim & "'")
            If Cli.RecordCount > 0 Then
                ConsultarRepciones.xCliente.Text = Cli.Fields("Cliente").Text
                ConsultarRepciones.xNombre.Text = Cli.Fields("Nombre").Text
                ConsultarRepciones.ShowDialog()
                ConsultarRepciones.BringToFront()
            Else
                MsgError("Cliente no encontrado")
                xCliente.Clear()
                xNombre.Clear()
                xCliente.Focus()
            End If
        Else
            MsgError("Debe ingresar Cliente")
            xCliente.Focus()
        End If

    End Sub

    Private Sub xCodigoR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCodigoR.KeyPress
        e.NextControl(xTecnico)
    End Sub

    Private Sub xNombre_TextChanged(sender As Object, e As EventArgs) Handles xNombre.TextChanged
        If xNombre.Text <> "" Then
            bConsultarP.Visible = True
        Else
            bConsultarP.Visible = False
        End If
        If xProductoR.Enabled Then xProductoR.Focus()
        DoEvents()
    End Sub

    Private Sub xServicio_TextChanged(sender As Object, e As EventArgs) Handles xServicio.TextChanged
        If Len(xServicio.Text) = 3 Or Len(xServicio.Text) = 5 Or Len(xServicio.Text) = 7 Then
            SugServicios.Items.Clear()
            Art = SQL("SELECT (Articulo + ' ~ ' + Descripcion) AS Art FROM Articulos " &
                      " WHERE Familia = 6 AND (Descripcion LIKE '%" & xServicio.Text.Trim & "%'" &
                      " OR Articulo LIKE '%" & xServicio.Text.Trim & "%')")
            If Art.RecordCount > 0 Then
                SugServicios.Visible = True
                While Not Art.EOF
                    SugServicios.Items.Add(Art.Fields("Art").Text)
                    Art.MoveNext()
                End While
            Else
                SugServicios.Visible = False
            End If
        End If
    End Sub

    Private Sub xServicio_KeyDown(sender As Object, e As KeyEventArgs) Handles xServicio.KeyDown
        If e.KeyCode = Keys.F3 Then
            bBuscarS_Click()
        End If

        If e.KeyCode = Keys.Down And SugServicios.Visible Then
            SugServicios.Focus()
            SugServicios.SelectedIndex = 0
        End If

        If e.KeyCode = Keys.Escape Then
            SugServicios.Visible = False
            xServicio.Focus()
            DoEvents()
            xServicio.SelectionStart = 0
            xServicio.SelectionLength = Len(xServicio.Text)
        End If
    End Sub

    Private Sub SugServicios_DoubleClick(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles SugServicios.DoubleClick
        Dim output() As String
        Dim wIndice As Integer

        wIndice = SugServicios.SelectedIndex

        output = Split(SugServicios.Items(wIndice), " ~ ")

        xServicio.Text = output(0)
        xNombreServicio.Text = output(1)
        DoEvents()
        SugServicios.Visible = False
        bAgregar.Focus()
    End Sub

    Private Sub SugServicios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SugServicios.KeyPress
        If e.KeyChar = vbCr Then
            SugServicios_DoubleClick()
        End If
    End Sub

    Private Sub SugServicios_KeyDown(sender As Object, e As KeyEventArgs) Handles SugServicios.KeyDown
        If e.KeyCode = Keys.Escape Then
            SugServicios.Visible = False
            xServicio.Focus()
            DoEvents()
            xServicio.SelectionStart = 0
            xServicio.SelectionLength = Len(xServicio.Text)
        End If

        If e.KeyCode = Keys.Up Then
            If SugServicios.SelectedIndex = 0 Then
                xServicio.Focus()
                DoEvents()
                xServicio.SelectionStart = 0
                xServicio.SelectionLength = Len(xServicio.Text)
            End If
        End If
    End Sub

    Private Sub xArticulo_TextChanged(sender As Object, e As EventArgs) Handles xArticulo.TextChanged
        If Len(xArticulo.Text) = 3 Or Len(xArticulo.Text) = 5 Or Len(xArticulo.Text) = 7 Then
            SugArticulos.Items.Clear()
            Art = SQL("SELECT (Articulo + ' ~ ' + Descripcion) AS Art FROM Articulos " &
                      " WHERE Familia <> 6 AND (Descripcion LIKE '%" & xArticulo.Text.Trim & "%'" &
                      " OR Articulo LIKE '%" & xArticulo.Text.Trim & "%')")
            If Art.RecordCount > 0 Then
                SugArticulos.Visible = True
                While Not Art.EOF
                    SugArticulos.Items.Add(Art.Fields("Art").Text)
                    Art.MoveNext()
                End While
            Else
                SugArticulos.Visible = False
            End If
        End If
    End Sub

    Private Sub xArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles xArticulo.KeyDown
        If e.KeyCode = Keys.F3 Then
            bBuscarA_Click()
        End If

        If e.KeyCode = Keys.Down And SugArticulos.Visible Then
            SugArticulos.Focus()
            SugArticulos.SelectedIndex = 0
        End If

        If e.KeyCode = Keys.Escape Then
            SugArticulos.Visible = False
            xArticulo.Focus()
            DoEvents()
            xArticulo.SelectionStart = 0
            xArticulo.SelectionLength = Len(xArticulo.Text)
        End If
    End Sub
    Private Sub SugArticulos_DoubleClick(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles SugArticulos.DoubleClick
        Dim output() As String
        Dim wIndice As Integer

        wIndice = SugArticulos.SelectedIndex

        output = Split(SugArticulos.Items(wIndice), " ~ ")

        xArticulo.Text = output(0)
        xDescripcion.Text = output(1)
        DoEvents()
        SugArticulos.Visible = False
        bAgregarA.Focus()
    End Sub

    Private Sub SugArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SugArticulos.KeyPress
        If e.KeyChar = vbCr Then
            SugArticulos_DoubleClick()
        End If
    End Sub

    Private Sub SugArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles SugArticulos.KeyDown
        If e.KeyCode = Keys.Escape Then
            SugArticulos.Visible = False
            xArticulo.Focus()
            DoEvents()
            xArticulo.SelectionStart = 0
            xArticulo.SelectionLength = Len(xArticulo.Text)
        End If

        If e.KeyCode = Keys.Up Then
            If SugArticulos.SelectedIndex = 0 Then
                xArticulo.Focus()
                DoEvents()
                xArticulo.SelectionStart = 0
                xArticulo.SelectionLength = Len(xArticulo.Text)
            End If
        End If
    End Sub

    Private Sub xServicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xServicio.KeyPress
        e.NextControl(bAgregar)
    End Sub

    Private Sub xObsCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xObsCliente.KeyPress
        e.NextControl(xObsTecnico)
    End Sub

    Private Sub xOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xOT.KeyPress
        If e.KeyChar = vbCr Then
            If xCliente.Enabled Then
                xCliente.Focus()
            Else
                xEstado.Focus()
            End If
        End If
        ValidarDigitos(e)
    End Sub

    Public Sub xOT_Validating(sender As Object, e As CancelEventArgs) Handles xOT.Validating
        If xOT.Text.Trim <> "" Then
            OT = SQL("SELECT * FROM OT WHERE OT=" & Num(xOT.Text) & "")
            If OT.EOF Then
                LimpiarCampos(Me)
                bGuardar.Text = "Ingresar"
            Else
                LlenarCampos()
                CargarServicios()
                CargarArticulos()
                TotalOT()
                bGuardar.Text = "Modificar"
            End If
        Else
            LimpiarCampos(Me)
        End If
    End Sub

    Sub CargarServicios()
        Dim wFilas = 1
        Titulos()
        Swap = SQL("SELECT RO.OT,RO.Articulo,A.Descripcion,A.PVenta FROM OTDet RO JOIN " &
               "Articulos A ON Ro.Articulo = A.Articulo WHERE OT = '" & xOT.Text.Trim & "' AND A.Familia = 6")

        If Swap.RecordCount > 0 Then
            While Not Swap.EOF
                xTabla.AddItem("")
                xTabla.SetCellImage(xTabla.Rows.Count - 1, T_ELIMINAR, My.Resources.remove_table)
                xTabla.SetData(wFilas, T_ARTICULO_SERVICIO, Swap.Fields("Articulo").Text.Trim)
                xTabla.SetData(wFilas, T_DESCRIPCION_SERVICIO, Swap.Fields("Descripcion").Text.Trim)
                xTabla.SetData(wFilas, T_COSTO_SERVICIO, Swap.Fields("PVenta").Text.Trim)
                Swap.MoveNext()
            End While
        End If
    End Sub

    Sub CargarArticulos()
        Dim wDisponible As Boolean

        TitulosArt()
        Swap = SQL("SELECT RO.OT,RO.Articulo,A.Descripcion,A.PVenta,Ro.Disponible FROM OTDet RO JOIN " &
               "Articulos A ON Ro.Articulo = A.Articulo WHERE OT = '" & Trim(xOT.Text) & "' AND A.Familia <> 6")

        If Swap.RecordCount > 0 Then
            While Not Swap.EOF
                xTablaArticulos.AddItem("")
                xTablaArticulos.SetCellImage(xTablaArticulos.Rows.Count - 1, T_ELIMINAR, My.Resources.remove_table)
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_ARTICULO, Swap.Fields("Articulo").Value)
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_DESCRIPCION, Swap.Fields("Descripcion").Value)
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_COSTO, Swap.Fields("PVenta").Value)
                xTablaArticulos.SetData(xTablaArticulos.Rows.Count - 1, T_STOCK, IIf(Swap.Fields("Disponible").Value, "Disponible", "Sin Stock"))
                wDisponible = IIf(Swap.Fields("Disponible").Value, True, False)
                If Not wDisponible Then
                    'xTablaArticulos.Cell(flexcpBackColor, xTablaArticulos.Rows - 1, T_ID, xTablaArticulos.Rows - 1, T_COSTO) = NARANJO
                    'xTablaArticulos.Cell(flexcpForeColor, xTablaArticulos.Rows - 1, T_ID, xTablaArticulos.Rows - 1, T_COSTO) = NARANJO_TXT
                End If
                Swap.MoveNext()
            End While
        End If



    End Sub
    Sub LlenarCampos()
        Est = SQL("SELECT DescEstado,Estado FROM Estados " &
                  " WHERE Estado = '" & OT.Fields("Estado").Text.Trim & "' and Tipo='O'")

        Doc = SQL("SELECT DescTipoDoc FROM TipoDoc " &
                  " WHERE TipoDoc ='" & OT.Fields("TipoDoc").Text.Trim & "'")

        Usr = SQL("SELECT NombreUsr FROM Usuarios " &
                  " WHERE Usuario ='" & OT.Fields("Tecnico").Text.Trim & "'")

        Cli = SQL("SELECT Nombre FROM Clientes " &
                  " WHERE Cliente ='" & OT.Fields("Cliente").Text.Trim & "'")

        dFecha.Value = OT.Fields("Fecha").Text
        xCliente.Text = Trim(OT.Fields("Cliente").Text)
        xNombre.Text = Trim(Cli.Fields("Nombre").Text)
        If Est.RecordCount > 0 Then
            xEstado.Text = UCase(Est.Fields("DescEstado").Text)
            wEstadoOT = Trim(Est.Fields("Estado").Text)
        End If
        dFechaEntrega.Value = OT.Fields("FechaEntrega").Text
        xObsCliente.Text = OT.Fields("ObsCliente").Text.Trim
        xObsTecnico.Text = OT.Fields("ObsTecnico").Text
        xTotalOT.Text = Val(OT.Fields("TotalOT").Text.Trim)
        xTecnico.Text = OT.Fields("Tecnico").Text.Trim
        xProductoR.Text = OT.Fields("Recepcion").Text
        xCodigoR.Text = OT.Fields("Codigo").Text
        If Usr.RecordCount > 0 Then
            xNombreTecnico.Text = Usr.Fields("NombreUsr").Text.Trim
        End If

        If wEstadoOT = "D" Or wEstadoOT = "F" Then
            DesactivarBotones(False)
        Else
            DesactivarBotones(True)
            xCliente.Focus()
        End If
    End Sub

    Sub DesactivarBotones(ByRef wActivado As Boolean)
        gServicio.Enabled = wActivado
        gObservacionCliente.Enabled = wActivado
        gObservacionTecnico.Enabled = wActivado
        bGuardar.Enabled = wActivado
        xCliente.Enabled = wActivado
        xProductoR.Enabled = wActivado
        xCodigoR.Enabled = wActivado
        xTecnico.Enabled = wActivado
        dFecha.Enabled = wActivado
        dFechaEntrega.Enabled = wActivado
        xTabla.Enabled = wActivado
        xNombre.Enabled = wActivado
        bBuscar.Enabled = wActivado
        bCrear.Enabled = wActivado
    End Sub

    Private Sub xProductoR_KeyDown(sender As Object, e As KeyEventArgs) Handles xProductoR.KeyDown
        If e.KeyCode = Keys.F3 Then
            bConsultarP_Click()
        End If
    End Sub

    Private Sub xProductoR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xProductoR.KeyPress
        e.NextControl(xCodigoR)
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 > 0 And xTabla.Col = 0 Then
            xTabla.RemoveItem(xTabla.Row)
        End If
        TotalOT()
    End Sub

    Private Sub xTablaArticulos_DoubleClick(sender As Object, e As EventArgs) Handles xTablaArticulos.DoubleClick

        If xTablaArticulos.Rows.Count - 1 = 0 Then Exit Sub

        If xTablaArticulos.Rows.Count - 1 > 0 And xTablaArticulos.Col = 0 Then
            xTablaArticulos.RemoveItem(xTablaArticulos.Row)
            TotalOT()
        End If

        If xTablaArticulos.ColSel = T_STOCK Then
            If xTablaArticulos.GetData(xTablaArticulos.RowSel, T_STOCK) = "Disponible" Then
                xTablaArticulos.SetData(xTablaArticulos.RowSel, T_STOCK, "Sin Stock")
                xTablaArticulos.FondoCelda(xTablaArticulos.Rows.Count - 1, C_NARANJO)
            Else
                xTablaArticulos.SetData(xTablaArticulos.RowSel, T_STOCK, "Disponible")
                xTablaArticulos.FondoCelda(xTablaArticulos.Rows.Count - 1, C_BLANCO)
            End If
        End If


    End Sub

    Private Sub xTecnico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTecnico.KeyPress
        e.NextControl(xServicio)
    End Sub

    Private Sub xTecnico_Validating(sender As Object, e As CancelEventArgs) Handles xTecnico.Validating
        If xTecnico.Text = "" Then
            xNombreTecnico.Text = ""
            Exit Sub
        End If

        TEC = SQL("SELECT * FROM Usuarios WHERE Usuario='" & Trim(xTecnico.Text) & "'")
        If TEC.EOF Then
            MsgError("El Técnico ingresado no existe")
            xNombreTecnico.Text = ""
            xTecnico.Focus()
            Exit Sub
        Else
            xNombreTecnico.Text = Trim(TEC.Fields("NombreUsr").Value)
        End If
    End Sub

    Private Sub xTotalOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTotalOT.KeyPress
        e.NextControl(xTecnico)
    End Sub

    Private Sub bCrear_Click(sender As Object, e As EventArgs) Handles bCrear.Click
        ManCliente.Show()
        ManCliente.BringToFront()
    End Sub


End Class