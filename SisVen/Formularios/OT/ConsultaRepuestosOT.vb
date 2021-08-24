Public Class ConsultaRepuestosOT
    Const T_ID As Integer = 0
    Const T_OT As Integer = 1
    Const T_ARTICULO As Integer = 2
    Const T_DESCRIPCION As Integer = 3
    Const T_CANTIDAD As Integer = 4
    Const T_FECHA_SOLICITADA As Integer = 5
    Const T_FECHA_ENTREGA As Integer = 6
    Const T_ESTADO As Integer = 7
    Const T_TECNICO As Integer = 8
    Private Sub xOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xOT.KeyPress
        ValidarDigitos(e)
        e.NextControl(cEstados)
    End Sub

    Private Sub cEstados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cEstados.SelectedIndexChanged
        xArticulo.Focus()
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(xTecnico)
    End Sub

    Private Sub xTecnico_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xTecnico.Validating
        If xTecnico.Text.Trim <> "" Then
            cTecnicos.SelectedValue = xTecnico.Text.Trim
            If cTecnicos.Text = W_SELECCIONAR Then
                MsgError("Técnico no encontrado")
                xTecnico.Clear()
                xTecnico.Focus()
            End If
            bBuscar.Focus()
        End If
    End Sub

    Private Sub cTecnicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTecnicos.SelectedIndexChanged
        If ValidarCombo(cEstados) Then
            xTecnico.Text = cTecnicos.SelectedValue
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click
        Dim wFiltro As String

        If oFechaSol.Checked Then
            wFiltro = " od.FechaSol Between '" & cDesde.Value & "' AND '" & cHasta.Value & "'"
        Else
            wFiltro = " od.FechaEnt Between '" & cDesde.Value & "' AND '" & cHasta.Value & "'"
        End If

        If xOT.Text.Trim <> "" Then
            wFiltro = wFiltro & " And O.OT=" & xOT.Text.Trim
        End If

        If ValidarCombo(cEstados) Then
            Est = SQL("SELECT Estado FROM Estados WHERE DescEstado='" & cEstados.SelectedValue & "' AND Tipo='O'")
            If Not Est.EOF Then
                wFiltro = wFiltro & " And od.Estado='" & Est.Fields("Estado").Text.Trim & "' "
            End If
        End If

        If xArticulo.Text.Trim <> "" Then
            wFiltro = wFiltro & " And od.Articulo='" & xArticulo.Text.Trim & "' "
        End If

        If ValidarCombo(cTecnicos) Then
            wFiltro = wFiltro & " And o.Tecnico='" & Trim(xTecnico.Text) & "' "
        End If

        OT = SQL("SELECT o.OT,od.Articulo,a.Descripcion,od.Cantidad,od.FechaSol, " &
                 " od.FechaEnt,e.DescEstado,u.NombreUsr " &
                 " FROM OT o INNER JOIN OTDet od on o.OT=od.OT AND od.Tipo='A'" &
                 " INNER JOIN Articulos A on od.Articulo=a.Articulo " &
                 " INNER JOIN Estados e on o.Estado=e.Estado AND e.Tipo='O' " &
                 " INNER JOIN Usuarios u on o.Tecnico=u.Usuario" &
                 " WHERE " & wFiltro)

        If OT.EOF Then
            MsgError("No hay Datos para Cargar")
            Exit Sub
        End If

        While Not OT.EOF
            xTabla.AddItem("")
            xTabla.SetData(xTabla.Rows.Count - 1, T_OT, OT.Fields("OT").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_ARTICULO, OT.Fields("Articulo").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_DESCRIPCION, OT.Fields("Descripcion").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_CANTIDAD, OT.Fields("Cantidad").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_FECHA_SOLICITADA, OT.Fields("FechaSol").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_FECHA_ENTREGA, OT.Fields("FechaEnt").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_ESTADO, OT.Fields("DescEstado").Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_TECNICO, OT.Fields("NombreUsr").Text)
            OT.MoveNext()
        End While
        xTabla.AjustarColumnas
    End Sub
    Sub Titulos()
        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 9

        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_OT).Width = 60
        xTabla.Cols(T_ARTICULO).Width = 100
        xTabla.Cols(T_DESCRIPCION).Width = 150
        xTabla.Cols(T_CANTIDAD).Width = 60
        xTabla.Cols(T_FECHA_SOLICITADA).Width = 120
        xTabla.Cols(T_FECHA_ENTREGA).Width = 120
        xTabla.Cols(T_ESTADO).Width = 100
        xTabla.Cols(T_TECNICO).Width = 130

        xTabla.Cols(T_ID).Caption = ""
        xTabla.Cols(T_OT).Caption = "OT"
        xTabla.Cols(T_ARTICULO).Caption = "Artículo"
        xTabla.Cols(T_DESCRIPCION).Caption = "Descripción"
        xTabla.Cols(T_CANTIDAD).Caption = "Cantidad"
        xTabla.Cols(T_FECHA_SOLICITADA).Caption = "F.Solicitada"
        xTabla.Cols(T_FECHA_ENTREGA).Caption = "F.Entrega"
        xTabla.Cols(T_ESTADO).Caption = "Estado OT"
        xTabla.Cols(T_TECNICO).Caption = "Técnico"

    End Sub

    Private Sub oFechaSol_CheckedChanged(sender As Object, e As EventArgs) Handles oFechaSol.CheckedChanged, oFechaEnt.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
    End Sub

    Private Sub ConsultaRepuestosOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cDesde.Value = IniFinFecha(1, Now)
        cHasta.Value = IniFinFecha(2, Now)
        cTecnicos.LoadCombobox("Usuarios", "Usuario", "NombreUsr", " WHERE Acceso = 3")
        cEstados.LoadCombobox("Estados", "Estado", "DescEstado", " WHERE Tipo = 'O'")
        Titulos()
    End Sub
End Class