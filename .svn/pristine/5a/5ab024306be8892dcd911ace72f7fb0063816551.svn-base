Public Class ConsultaOT
    Implements iFormulario
    Const T_ID = 0
    Const T_SHOW = 1
    Const T_IMPRIMIR = 2
    Const T_SERVICIO = 3
    Const T_OT = 4
    Const T_CLIENTE = 5
    Const T_TECNICO = 6
    Const T_ESTADO = 7
    Const T_FECHAING = 8
    Const T_FECHAENT = 9
    Const T_TIPODOC = 10
    Const T_NUMDOC = 11
    Dim wDesde, wHasta As Date
    Private Sub ConsultaOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cDesde.Value = IniFinFecha(1, Now)
        cHasta.Value = IniFinFecha(2, Now)
        cTecnicos.LoadCombobox("Usuarios", "Usuario", "NombreUsr", " WHERE Acceso = 3")
        cEstados.LoadCombobox("Estados", "Estado", "DescEstado", " WHERE Tipo = 'O'")
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        If cDesde.Value > cHasta.Value Then
            MsgError("La fecha inicial debe ser inferior a la final.")
            cDesde.Focus()
            Exit Sub
        End If
        wDesde = cDesde.Value
        wHasta = cHasta.Value
        Consultar()
        Auditoria(Me.Name, "Consultó OT", xOT.Text, CDbl(LocalActual))
    End Sub
    Sub Consultar()

        Dim wFiltro = "WHERE o.Local=" & LocalActual & " "

        If xOT.Text <> "" Then
            wFiltro = IIf(wFiltro = "", " WHERE ", wFiltro & " AND") & " O.OT=" & Val(xOT.Text) & " "
        End If

        If oFechaOT.Checked Then
            wFiltro = IIf(wFiltro = "", " WHERE ", wFiltro & " AND") & " Fecha BETWEEN '" & wDesde & "' AND '" & wHasta & "'"
        Else
            wFiltro = IIf(wFiltro = "", " WHERE ", wFiltro & " AND") & " FechaEntrega BETWEEN '" & wDesde & "' AND '" & wHasta & "'"
        End If


        If cTecnicos.Text <> "" Then
            wFiltro = IIf(wFiltro = "", " WHERE ", wFiltro & " AND") & " o.Tecnico ='" & Trim(xTecnico.Text) & "' "
        End If

        If xNombreCliente.Text <> "" Then
            wFiltro = IIf(wFiltro = "", " WHERE ", wFiltro & " AND") & " o.Cliente ='" & Trim(xCliente.Text) & "' "
        End If

        If ValidarCombo(cEstados) Then
            Est = SQL("Select Estado From Estados Where DescEstado Like '%" & cEstados.Text.Trim & "%'")
            If Not Est.EOF Then
                wFiltro = IIf(wFiltro = "", " WHERE ", wFiltro & " AND") & " o.Estado='" & Trim(Est.Fields("Estado").Value) & "' "
            End If
        End If


        OT = SQL("SELECT o.OT,c.Nombre ,ISNULL(u.NombreUsr,'')as NombreUsr,e.DescEstado,o.Fecha, " &
                 " o.FechaEntrega,o.NumDoc,ISNULL(t.DescTipoDoc,'') as DescTipoDoc " &
                 " FROM OT o Inner Join Clientes c on o.Cliente=c.Cliente " &
                 " LEFT Join Usuarios u on o.Tecnico=u.Usuario " &
                 " LEFT Join Estados e on o.Estado=e.Estado and Tipo = 'O' " &
                 " LEFT Join TipoDoc t on o.TipoDoc=t.TipoDoc " &
                 "  " & wFiltro & "")
        Titulos()

        If OT.EOF Then
            MsgError("No hay datos para mostrar")
            xOT.Focus()
            Exit Sub
        End If
        xProgreso.Maximum = OT.RecordCount
        xProgreso.Value = 0
        xProgreso.Visible = True
        While Not OT.EOF
            xTabla.AddItem("")
            xTabla.SetCellImage(xTabla.Rows.Count - 1, T_SHOW, My.Resources.edit_table)
            xTabla.SetCellImage(xTabla.Rows.Count - 1, T_IMPRIMIR, My.Resources.print)
            xTabla.SetCellImage(xTabla.Rows.Count - 1, T_SERVICIO, My.Resources.tool)
            xTabla.SetData(xTabla.Rows.Count - 1, T_OT, OT.Fields("OT").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_CLIENTE, OT.Fields("Nombre").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_TECNICO, OT.Fields("NombreUsr").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_ESTADO, OT.Fields("DescEstado").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_TIPODOC, OT.Fields("DescTipoDoc").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_NUMDOC, OT.Fields("NumDoc").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_FECHAING, OT.Fields("Fecha").Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_FECHAENT, OT.Fields("FechaEntrega").Text.Trim)

            xTabla.Row = xTabla.Rows.Count - 1
            xTabla.Col = T_SHOW
            OT.MoveNext()
            xProgreso.Value += 1
        End While
        lCantidadOT.Text = xTabla.Rows.Count - 1
        xProgreso.Visible = False
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery As String
        wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre Cliente' From Clientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Nombre", Me, "Clientes", xCliente)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub bIngresoOT_Click(sender As Object, e As EventArgs) Handles bIngresoOT.Click
        IngresoOT.Show()
        IngresoOT.BringToFront()
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text.Trim <> "" Then
            Cli = SQL("SELECT Nombre FROM Clientes WHERE Cliente = " & xCliente.Text.Trim)
            If Cli.RecordCount > 0 Then
                xNombreCliente.Text = Cli.Fields("Nombre").Text
            Else
                MsgError("Cliente no encontrado")
                xCliente.Clear()
                xNombreCliente.Clear()
                xCliente.Focus()
            End If
        Else
            xNombreCliente.Clear()
        End If
    End Sub

    Private Sub xTecnico_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xTecnico.Validating
        If xTecnico.Text.Trim <> "" Then
            cTecnicos.SelectedValue = xTecnico.Text.Trim
            If cTecnicos.Text = W_SELECCIONAR Then
                MsgError("Técnico no encontrado")
                xTecnico.Clear()
                xTecnico.Focus()
            End If
            cEstados.Focus()
        End If
    End Sub

    Private Sub cTecnicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTecnicos.SelectedIndexChanged
        If ValidarCombo(cTecnicos) Then
            xTecnico.Text = cTecnicos.SelectedValue
            cEstados.Focus()
        Else
            xTecnico.Clear()
        End If
    End Sub

    Private Sub xTecnico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTecnico.KeyPress
        e.NextControl(cEstados)
    End Sub

    Private Sub xOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xOT.KeyPress
        ValidarDigitos(e)
        e.NextControl(xTecnico)
    End Sub

    Private Sub cEstados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cEstados.SelectedIndexChanged
        If ValidarCombo(cEstados) Then
            xCliente.Focus()
        End If
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        e.NextControl(bConsultar)
    End Sub

    Private Sub oFechaOT_CheckedChanged(sender As Object, e As EventArgs) Handles oFechaOT.CheckedChanged, oFechaEnt.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click

    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Col = T_SHOW Then
            IngresoOT.xOT.Text = xTabla.GetData(xTabla.Row, T_OT)
            IngresoOT.xOT_Validating(Nothing, Nothing)
            IngresoOT.Show()
            IngresoOT.BringToFront()
        End If
    End Sub

    Private Sub bAnulacionOT_Click(sender As Object, e As EventArgs) Handles bAnulacionOT.Click
        AnularOT.Show()
        AnularOT.BringToFront()
    End Sub

    Sub Titulos()
        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 12

        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_SHOW).Width = 50
        xTabla.Cols(T_IMPRIMIR).Width = 45
        xTabla.Cols(T_SERVICIO).Width = 45
        xTabla.Cols(T_OT).Width = 100
        xTabla.Cols(T_CLIENTE).Width = 300
        xTabla.Cols(T_TECNICO).Width = 200
        xTabla.Cols(T_ESTADO).Width = 200
        xTabla.Cols(T_TIPODOC).Width = 200
        xTabla.Cols(T_NUMDOC).Width = 100
        xTabla.Cols(T_FECHAING).Width = 120
        xTabla.Cols(T_FECHAENT).Width = 120

        xTabla.Cols(T_ID).Caption = ""
        xTabla.Cols(T_SHOW).Caption = "Modificar"
        xTabla.Cols(T_IMPRIMIR).Caption = "Imprimir"
        xTabla.Cols(T_SERVICIO).Caption = "Servicio"
        xTabla.Cols(T_OT).Caption = "OT"
        xTabla.Cols(T_CLIENTE).Caption = "Cliente"
        xTabla.Cols(T_TECNICO).Caption = "Técnico"
        xTabla.Cols(T_ESTADO).Caption = "Estado"
        xTabla.Cols(T_TIPODOC).Caption = "Tipo Doc."
        xTabla.Cols(T_NUMDOC).Caption = "N° Documento"
        xTabla.Cols(T_FECHAING).Caption = "F. Ingreso"
        xTabla.Cols(T_FECHAENT).Caption = "F. Entrega"

        xTabla.Cols(T_SHOW).ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
        xTabla.Cols(T_IMPRIMIR).ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
        xTabla.Cols(T_SERVICIO).ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter

    End Sub
End Class