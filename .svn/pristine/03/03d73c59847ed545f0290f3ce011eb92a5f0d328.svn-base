Public Class ConsultarRepciones
    Const T_PRODUCTO = 0
    Const T_CODIGO = 1
    Const T_SERVICIO = 2
    Private Sub ConsultarRepciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
    End Sub
    Sub Titulos()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 3
        xTabla.Cols(T_PRODUCTO).Caption = "Producto"
        xTabla.Cols(T_CODIGO).Caption = "Codigo"
        xTabla.Cols(T_SERVICIO).Caption = "Último Servicio"
        xTabla.Cols(T_PRODUCTO).Width = 3200
        xTabla.Cols(T_CODIGO).Width = 5200
        xTabla.Cols(T_SERVICIO).Width = 1600
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        e.NextControl(bCancelar)
    End Sub

    Private Sub xTabla_DoubleClick(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 > 0 Then
            If Modulo = "IngresoOT" Then
                IngresoOT.xCodigoR.Text = xTabla.GetData(xTabla.Row, T_CODIGO)
                IngresoOT.xProductoR.Text = xTabla.GetData(xTabla.Row, T_PRODUCTO)
                IngresoOT.xTecnico.Focus()
                Close()
            End If
        End If
    End Sub

    Private Sub xTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTabla.KeyPress
        If e.KeyChar = vbCr Then
            xTabla_DoubleClick()
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click

        Swap = SQL("SELECT Recepcion, Codigo, max(Fecha) FechaOT FROM OT WHERE Cliente = " & Val(xCliente.Text) &
                  " AND (Recepcion Like '%" & xDescripcion.Text.Trim & "%' OR Codigo LIKE '%" & xDescripcion.Text.Trim & "%')" &
                  " GROUP BY Recepcion, Codigo, OT ORDER BY OT DESC")

        If Swap.RecordCount > 0 Then

            Titulos()
            Dim wFila As Double
            wFila = 1
            While Not Swap.EOF
                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_CODIGO, Swap.Fields("Codigo").Value)
                xTabla.SetData(xTabla.Rows.Count - 1, T_PRODUCTO, Swap.Fields("Recepcion").Value)
                xTabla.SetData(xTabla.Rows.Count - 1, T_SERVICIO, Swap.Fields("FechaOT").Value)
                wFila = wFila + 1
                Swap.MoveNext()
            End While
            xTabla.Row = 1
            xTabla.Focus()
        Else
            MsgBox("No se han encontrado registros.")
            xDescripcion.Focus()
        End If


    End Sub
End Class