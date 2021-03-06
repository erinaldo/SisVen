Public Class BuscarArticulos
    Const T_ID As Integer = 0
    Const T_CLIENTE As Integer = 1
    Const T_RUT As Integer = 2
    Const T_NOMBRE As Integer = 3

    Dim wFila As Integer
    Dim wFiltro As String

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        wFiltro = ""
        If IsNumeric(xDato.Text) Then
            wFiltro = " or Costo like '%" & Val(xDato.Text) & "' or PVenta like '%" & Val(xDato.Text) & "'"
        End If
        Art = SQL("SELECT a.Articulo as 'Artículos',a.Descripcion as 'Descripción'," &
                  " f.DescFamilia as 'Familia', s.DescSubFamilia as 'SubFamilia'," &
                  " a.Costo as 'Precio Costo',a.PVenta as 'Precio Venta' " &
                  " FROM Articulos A " &
                  " INNER JOIN Familias F on a.Familia=f.Familia " &
                  " INNER JOIN SubFamilias s on a.SubFamilia=s.SubFamilia" &
                  " WHERE Articulo Like '%" & Trim(xDato.Text) & "%' or Descripcion Like '%" & Trim(xDato.Text) & "%'" &
                  " " & wFiltro & "")

        If Art.EOF Then
            MsgError("No hay datos para Mostrar")
            xTabla.Clear()
            xTabla.Rows.Count = 1
            lCantidadArticulos.Text = 0
            xDato.Focus()
            Exit Sub
        End If


        xProgreso.Visible = True
        bBuscar.Enabled = False
        bSalir.Enabled = False
        xProgreso.Value = 1
        xProgreso.Minimum = 1
        xProgreso.Maximum = Art.RecordCount
        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = Art.Fields.Count
        'Se obtiene el Nombre de las Columnas desde la consulta SQL
        For i = 0 To Art.Fields.Count - 1
            xTabla.SetData(0, i, Art.Fields(i).Name)
            xTabla.Cols(i).Width = 1
        Next
        wFila = 1
        xTabla.Redraw = False
        'Se llenan las Columnas con los Datos de la Consulta
        For i = 1 To Art.RecordCount
            DoEvents()
            xTabla.AddItem("")
            For Col = 0 To xTabla.Cols.Count - 1
                xTabla.SetData(wFila, Col, Art.Fields(Col).Text)
            Next Col
            Art.MoveNext()
            xProgreso.Value = wFila
            wFila += 1
        Next i
        xTabla.Rows.Fixed = 1
        xTabla.AjustarColumnas
        lCantidadArticulos.Text = wFila - 1
        xTabla.Redraw = True
        xProgreso.Value = 1
        xProgreso.Visible = False
        bBuscar.Enabled = True
        bSalir.Enabled = True
        xDato.Focus()
    End Sub

    Private Sub BuscarArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xDato.Clear()
        xTabla.Clear()
        xTabla.Cols.Count = 0
        xTabla.Rows.Count = 0
        xDato.Focus()
        Auditoria(Text, "Ingresó", "", 0)
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        Dim wArticulo As String = xTabla.GetData(xTabla.RowSel, 0)
        Select Case Modulo
            Case "MantenedorArticulo"
                ManArticulos.xArticulo.Text = wArticulo
                ManArticulos.xArticulo_Validating(Nothing, Nothing)
            Case "VentaSucursal"
                VentaSucursal.xArticulo.Text = wArticulo
                VentaSucursal.xArticulo_Validating(Nothing, Nothing)
            Case "Documentos"
                Documentos.xArticulo.Text = wArticulo
                Documentos.xArticulo.Focus()
                SendKeys("{ENTER}")
            Case Else

        End Select

        Close()
    End Sub
    Private Sub xDato_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDato.KeyPress
        If e.KeyChar = vbCr Then
            bBuscar_Click(sender, e)
        End If
    End Sub
    Private Sub xTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTabla.KeyPress
        If xTabla.Rows.Count > 1 Then
            xTabla_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click

    End Sub
End Class