Public Class ConsultaBoleta
    Public wTipoDocumento As String
    Private Sub ConsultaBoleta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xTabla.Clear()
        xTabla.Rows.Count = 1
    End Sub

    Sub CargarDatos(ByVal wNumDoc As Double, ByVal wDocumento As String)
        Dim wFila As Integer = 0
        bBuscar.Enabled = False
        TkG = SQL("SELECT td.Articulo,a.Descripcion,td.Barra," &
          " td.Cantidad,td.PVenta,(td.Cantidad*td.PVenta) as Total" &
          " FROM Ventas v " &
          " INNER JOIN TikDet td on v.Ticket=td.Ticket " &
          " INNER JOIN Articulos a on td.Articulo=a.Articulo " &
          " WHERE NumDoc=" & wNumDoc & " and TipoDoc='" & wDocumento & "' and v.Local=" & LocalActual & "")

        xTabla.Clear()
        xTabla.Rows.Count = 1
        If TkG.EOF Then
            xTabla.Rows.Count = 0
            MsgError("No hay datos para mostrar")
            bBuscar.Enabled = True
            Exit Sub
        End If

        xTabla.Cols.Count = TkG.Fields.Count
        For wColumna = 0 To TkG.Fields.Count - 1
            xTabla.SetData(0, wColumna, TkG.Fields(wColumna).Name)
            xTabla.Cols(wColumna).Width = 10
        Next
        wFila = 1
        ' xTabla.Redraw = False
        Dim wTotales As Double
        For wRow = 1 To TkG.RecordCount
            DoEvents()
            xTabla.AddItem("")
            For Col = 0 To xTabla.Cols.Count - 1
                If Col = xTabla.Cols.Count - 1 Then
                    wTotales += Trim(TkG.Fields("Total").Value)
                End If
                xTabla.SetData(wFila, Col, Trim(TkG.Fields(Col).Value))
            Next Col
            wFila = wFila + 1
            TkG.MoveNext()
        Next
        xTotal.Text = wTotales
        xTabla.AjustarColumnas
        bBuscar.Enabled = True
        'xTabla.Redraw = True
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        If Trim(xBoleta.Text = "") Then Exit Sub
        CargarDatos(Val(xBoleta.Text), wTipoDocumento)
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub xBoleta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBoleta.KeyPress, xTotal.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = Chr(13) Then
            bBuscar.Focus()
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        xBoleta.Clear()
        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTotal.Text = 0
        xBoleta.Focus()
    End Sub
End Class