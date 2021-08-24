Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class Pagos
    Implements iFormulario
    Const T_OK = 0
    Const T_NUMERO = 1
    Const T_FECHAEMI = 2
    Const T_MONTO = 3
    Const T_FPAGO = 4
    Const T_FECHAVEN = 5
    Const T_ESTADO = 6
    Const T_FECHACAN = 7
    Const T_OBSER = 8
    Const T_NUMERO2 = 9
    Const T_CUENTA = 10
    Const T_BANCO = 11
    Const T_TITULAR = 12

    Dim cEst As New ComboBox
    Dim cBancos As New ComboBox
    Dim cCuentas As New ComboBox

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub Pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarCombos()
        Titulos()
        cTipoDoc.LoadCombobox("TipoDoc", "TipoDoc", "DescTipoDoc", "WHERE MODULO = 'V'")
        cFormaPago.LoadCombobox("FPagos", "FPago", "DescFPago")
        cEstado.LoadCombobox("Estados", "Estado", "DescEstado", " WHERE Tipo = 'P'")
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        xNeto.Text = 0
        xIva.Text = 0
        xTotal.Text = 0
        xCantSeleccionado.Text = 0
        xTotalSeleccionado.Text = 0.00
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery As String
        wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre Cliente' From Clientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Nombre", Me, "Clientes", xCliente)
    End Sub

    Private Sub xCliente_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xCliente.Validating
        If xCliente.Text <> "" Then
            Dim cl = SQL("SELECT NOMBRE FROM CLIENTES WHERE CLIENTE = " & Val(xCliente.Text) & "")
            If cl.RecordCount > 0 Then
                xCNombre.Text = cl.Fields("Nombre").Text
            Else
                MsgError("Cliente no existe")
                xCliente.Clear()
                xCliente.Focus()
            End If
        End If
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        e.NextControl(cTipoDoc)
    End Sub

    Private Sub xNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNumero.KeyPress
        ValidarDigitos(e)
        e.NextControl(dDesde)
    End Sub

    Private Sub xVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVendedor.KeyPress
        e.NextControl(bConsultar)
    End Sub

    Private Sub cTipoDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cTipoDoc.KeyPress
        e.NextControl(xNumero)
    End Sub

    Private Sub dDesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dDesde.KeyPress
        e.NextControl(dHasta)
    End Sub

    Private Sub dHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dHasta.KeyPress
        e.NextControl(cFormaPago)
    End Sub
    Private Sub cEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cEstado.KeyPress
        e.NextControl(xVendedor)
    End Sub
    Private Sub cFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cFormaPago.KeyDown
        e.NextControl(cEstado)
    End Sub

    Private Sub xVendedor_Validating(sender As Object, e As CancelEventArgs) Handles xVendedor.Validating
        If xVendedor.Text <> "" Then
            Dim ve = SQL("SELECT NombreUsr FROM Usuarios WHERE Usuario = '" & xVendedor.Text & "'")
            If ve.RecordCount > 0 Then
                xVNombre.Text = ve.Fields("Nombreusr").Text
            Else
                MsgError("Vendedor no encontrado")
                xVNombre.Clear()
                xVNombre.Focus()
            End If
        End If
    End Sub
    Sub Titulos()

        xTabla.Redraw = False

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 13

        xTabla.Cols(T_OK).Width = 30
        xTabla.Cols(T_NUMERO).Width = 100
        xTabla.Cols(T_FECHAEMI).Width = 80
        xTabla.Cols(T_MONTO).Width = 100
        xTabla.Cols(T_FPAGO).Width = 100
        xTabla.Cols(T_FECHAVEN).Width = 80
        xTabla.Cols(T_ESTADO).Width = 100
        xTabla.Cols(T_FECHACAN).Width = 80
        xTabla.Cols(T_OBSER).Width = 200
        xTabla.Cols(T_NUMERO2).Width = 150
        xTabla.Cols(T_CUENTA).Width = 120
        xTabla.Cols(T_BANCO).Width = 150
        xTabla.Cols(T_TITULAR).Width = 180


        xTabla.Cols(T_OK).Caption = "OK"
        xTabla.Cols(T_NUMERO).Caption = "Numero"
        xTabla.Cols(T_FECHAEMI).Caption = "Fecha Emi."
        xTabla.Cols(T_MONTO).Caption = "Monto"
        xTabla.Cols(T_FPAGO).Caption = "F.Pago"
        xTabla.Cols(T_FECHAVEN).Caption = "Fecha Ven."
        xTabla.Cols(T_ESTADO).Caption = "Estado"
        xTabla.Cols(T_FECHACAN).Caption = "Fecha Can."
        xTabla.Cols(T_OBSER).Caption = "Observación"
        xTabla.Cols(T_NUMERO2).Caption = "Numero"
        xTabla.Cols(T_CUENTA).Caption = "Cuenta"
        xTabla.Cols(T_BANCO).Caption = "Banco"
        xTabla.Cols(T_TITULAR).Caption = "Titular"

        xTabla.Cols(T_OK).DataType = GetType(Boolean)
        xTabla.Cols(T_MONTO).DataType = GetType(Double)
        xTabla.Cols(T_MONTO).Format = "N0"


        Dim cFechaCan As New DateTimePicker
        cFechaCan.Format = DateTimePickerFormat.Short
        xTabla.Cols(T_FECHACAN).Editor = cFechaCan

        Dim cFPAgos As New ComboBox
        cFPAgos.DropDownStyle = ComboBoxStyle.DropDownList
        LoadComboGrilla(cFPAgos, "FPagos", "FPago", "DescFPago")
        xTabla.Cols(T_FPAGO).Editor = cFPAgos


        cEst.DropDownStyle = ComboBoxStyle.DropDownList
        LoadComboGrilla(cEst, "Estados", "Estado", "DescEstado", " WHERE Tipo = 'P'")
        xTabla.Cols(T_ESTADO).Editor = cEst
        AddHandler cEst.SelectedIndexChanged, AddressOf ComboGrilla_SelectedIndexChanged


        cBancos.DropDownStyle = ComboBoxStyle.DropDownList
        LoadComboGrilla(cBancos, "Bancos", "Banco", "DescBanco")
        xTabla.Cols(T_BANCO).Editor = cBancos
        AddHandler cBancos.SelectedIndexChanged, AddressOf ComboGrilla_SelectedIndexChanged


        cCuentas.DropDownStyle = ComboBoxStyle.DropDownList
        cCuentas.Items.Clear()
        cCuentas.Items.Add("AHORRO")
        cCuentas.Items.Add("CORRIENTE")
        xTabla.Cols(T_CUENTA).Editor = cCuentas
        AddHandler cCuentas.SelectedIndexChanged, AddressOf ComboGrilla_SelectedIndexChanged

        xTabla.Redraw = True
    End Sub

    Private Sub oSoloPalets_CheckedChanged(sender As Object, e As EventArgs) Handles oSoloDeudas.CheckedChanged
        Dim wCheckBox As CheckBox = DirectCast(sender, CheckBox)
        wCheckBox.ForeColor = If(wCheckBox.Checked, Color.White, Color.Black)
    End Sub

    Private Sub bMostrar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bMostrar.Click

        Dim Filtros As String = ""
        Dim wFila As Integer
        Dim wNeto As New Double
        Dim wIva As New Double
        Dim wTotal As New Double


        If xCliente.Text.Trim = "" Then
            Mensaje("Debe seleccionar cliente")
            xCliente.Focus()
            Exit Sub
        Else
            Filtros += " WHERE Cliente = " & Val(xCliente.Text.Trim) & ""
        End If

        If ValidarCombo(cTipoDoc) Then
            Filtros += " AND TIPODOC = '" & cTipoDoc.SelectedValue & "'"
        End If

        If xNumero.Text <> "" Then Filtros += " AND NUMERO = " & Val(xNumero.Text.Trim) & ""
        If xVendedor.Text.Trim <> "" Then Filtros += " AND Vendedor = '" & xVendedor.Text.Trim & "'"
        If ValidarCombo(cFormaPago) Then Filtros += " AND FPago = '" & cFormaPago.SelectedValue & "'"

        If ValidarCombo(cEstado) Then
            Filtros += " AND Estado = '" & cEstado.SelectedValue & "'"
        Else
            If oSoloDeudas.Checked Then
                Filtros += " AND (Estado = 'P' or Estado = 'T')"
            End If
        End If

        Filtros += " AND Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"

        DocP = SQL("SELECT * FROM DocumentosP " & Filtros)

        If DocP.RecordCount > 0 Then
            bConsultar.Enabled = False
            bMostrar.Enabled = False
            xNeto.Text = 0
            xIva.Text = 0
            xTotal.Text = 0
            xCantSeleccionado.Text = 0
            xTotalSeleccionado.Text = 0.00
            Titulos()
            wFila = 1
            Cursor = Cursors.WaitCursor
            xTabla.Redraw = False
            While Not DocP.EOF
                xTabla.AddItem("")
                xTabla.SetData(wFila, T_NUMERO, DocP.Fields("Numero").Text)
                xTabla.SetData(wFila, T_FECHAEMI, Formatea_Fecha(CDate((DocP.Fields("Fecha").Text))))
                xTabla.SetData(wFila, T_MONTO, DocP.Fields("Monto").Text)
                Swap = SQL("SELECT DescFPAGO FROM FPAGOS WHERE Fpago = '" & DocP.Fields("Fpago").Text & "'")

                xTabla.SetData(wFila, T_FPAGO, Swap.Fields("DescFPago").Text)
                xTabla.SetData(wFila, T_FECHAVEN, Formatea_Fecha(DocP.Fields("FechaPago").Text))
                If DocP.Fields("FechaCanc").Text <> CDate("01/01/2000") Then
                    xTabla.SetData(wFila, T_FECHACAN, Formatea_Fecha(DocP.Fields("FechaCanc").Text))
                End If

                Swap = SQL("SELECT DescEstado From Estados WHERE Estado = '" & DocP.Fields("Estado").Text & "' AND Tipo = 'P'")

                xTabla.SetData(wFila, T_ESTADO, Swap.Fields("DescEstado").Text)
                xTabla.SetData(wFila, T_OBSER, DocP.Fields("Obs").Text)
                xTabla.SetData(wFila, T_NUMERO2, DocP.Fields("NumeroPago").Text)
                xTabla.SetData(wFila, T_CUENTA, DocP.Fields("Cuenta").Text)
                Swap = SQL("SELECT DescBanco FROM Bancos WHERE Banco = '" & DocP.Fields("Banco").Text & "'")



                xTabla.SetData(wFila, T_BANCO, Swap.Fields("DescBanco").Text)
                xTabla.SetData(wFila, T_TITULAR, DocP.Fields("Titular").Text)

                wFila += 1

                wTotal += Val(DocP.Fields("Monto").Text)
                DocP.MoveNext()
            End While

            Cursor = Cursors.Arrow
            xTabla.Redraw = True
            xNeto.Text = FormatNumber(wTotal / (1 + (ivaGlobal / 100)), 0)
            xIva.Text = FormatNumber(wTotal - Val(xNeto.Text))
            xTotal.Text = FormatNumber(wTotal)
            xRegistro.Text = xTabla.Rows.Count - 1

        Else
            Mensaje("No se encuentran datos asociados a este cliente")
        End If

        bMostrar.Enabled = True
        bConsultar.Enabled = True
    End Sub

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click
        If xTabla.Rows.Count > 1 AndAlso xTabla.Row > 0 Then

            If xTabla.Col = T_OK Then
                Dim wCheck = Not (xTabla.GetData(xTabla.Row, T_OK))
                xTabla.SetData(xTabla.Row, T_OK, wCheck)
            ElseIf xTabla.Col = T_ESTADO Then
                xTabla.StartEditing(xTabla.Row, T_ESTADO)
            ElseIf xTabla.Col = T_FECHACAN Then
                If BuscarCampo("Estados", "Estado", "DescEstado", xTabla.GetData(xTabla.Row, T_ESTADO)) = "C" Then
                    xTabla.StartEditing(xTabla.Row, T_FECHACAN)
                End If
            ElseIf xTabla.Col = T_ESTADO Then
                xTabla.StartEditing(xTabla.Row, T_ESTADO)
            ElseIf xTabla.Col = T_FPAGO Then
                xTabla.StartEditing(xTabla.Row, T_FPAGO)
            ElseIf xTabla.Col = T_OBSER Then
                xTabla.StartEditing(xTabla.Row, T_OBSER)
            ElseIf xTabla.Col = T_NUMERO2 Then
                xTabla.StartEditing(xTabla.Row, T_NUMERO2)
            ElseIf xTabla.Col = T_BANCO Then
                xTabla.StartEditing(xTabla.Row, T_BANCO)
            ElseIf xTabla.Col = T_TITULAR Then
                xTabla.StartEditing(xTabla.Row, T_TITULAR)
            ElseIf xTabla.Col = T_CUENTA Then
                xTabla.StartEditing(xTabla.Row, T_CUENTA)
            End If
        End If

        Dim Total As New Integer
        Dim Cont As New Integer

        For wFila As Integer = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(wFila, 0) = True Then
                Total += xTabla.GetData(wFila, 3)
                Cont += 1
            End If
        Next

        xTotalSeleccionado.Text = FormatNumber(Total)
        xCantSeleccionado.Text = Cont

    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        If cTipoDoc.Text <> W_SELECCIONAR Then
            xNumero.Focus()
        End If
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        bMostrar_Click()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If xTabla.Rows.Count - 1 > 0 Then
            If Pregunta("Desea guardar cambios en pagos") = True Then
                For wfila As Integer = 1 To xTabla.Rows.Count - 1
                    DocP = SQL("SELECT * FROM DocumentosP Where Numero = '" & xTabla.GetData(wfila, T_NUMERO) & "'")

                    DocP.Fields("Fecha").Value = xTabla.GetData(wfila, T_FECHAEMI)

                    If BuscarCampo("Estados", "Estado", "DescEstado", xTabla.GetData(wfila, T_ESTADO)) = "C" Then
                        DocP.Fields("FechaCanc").Value = xTabla.GetData(wfila, T_FECHACAN)
                    End If

                    DocP.Fields("FPago").Value = BuscarCampo("FPagos", "FPago", "DescFPago", xTabla.GetData(wfila, T_FPAGO))
                    DocP.Fields("Estado").Value = BuscarCampo("Estados", "Estado", "DescEstado", xTabla.GetData(wfila, T_ESTADO))
                    DocP.Fields("Obs").Value = xTabla.GetData(wfila, T_OBSER)
                    DocP.Fields("NumeroPago").Value = xTabla.GetData(wfila, T_NUMERO2)
                    DocP.Fields("Cuenta").Value = xTabla.GetData(wfila, T_CUENTA)
                    DocP.Fields("Banco").Value = BuscarCampo("Bancos", "Banco", "DescBanco", xTabla.GetData(wfila, T_BANCO))
                    DocP.Fields("Titular").Value = xTabla.GetData(wfila, T_TITULAR)
                    DocP.Fields("Usuario").Value = UsuarioActual
                    DocP.Update()
                Next
                Mensaje("Cambio en pagos actualizados correctamente")
                Auditoria(Me.Text, PR_MODIFICAR, "", 0)
                bMostrar_Click()
            End If
        Else
            MsgError("No hay datos ingresados para modificar")
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
        Titulos()
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
    End Sub

    Sub Limpiar()

        For Each wControl In GroupBox1.Controls
            If TypeOf wControl Is TextBox Then
                wControl.Clear
            End If
            If TypeOf wControl Is ComboBox Then
                wControl.SelectedIndex = 0
            End If
            If TypeOf wControl Is DateTimePicker Then
                wControl.value = Now
            End If
            If TypeOf wControl Is CheckBox Then
                wControl.Checked = False
            End If
        Next
        For Each wControl In GroupBox3.Controls
            If TypeOf wControl Is TextBox Then
                wControl.Clear
            End If
            If TypeOf wControl Is ComboBox Then
                wControl.SelectedIndex = 0
            End If
            If TypeOf wControl Is DateTimePicker Then
                wControl.value = Now
            End If
            If TypeOf wControl Is CheckBox Then
                wControl.Checked = False
            End If
        Next
    End Sub

    Private Sub bListado_Click(sender As Object, e As EventArgs) Handles bListado.Click
        Dim wQuery As String
        Dim wReporte As New ReportePagos
        Dim wFiltro As String = ""

        wQuery = "SELECT Td.DescTipoDoc,Dp.Numero,Cl.Rut,Cl.Nombre,Dp.Monto, Fp.DescFPago, Es.DescEstado, Dp.FechaCanc, Dp.Obs  FROM DocumentosP Dp" &
                 " JOIN TipoDoc Td ON DP.TipoDoc = Td.TipoDoc" &
                 " JOIN Clientes Cl ON Dp.CLiente = Cl.CLiente" &
                 " JOIN FPagos Fp ON Dp.FPago = Fp.FPago" &
                 " JOIN Estados Es ON Dp.Estado = Es.Estado WHERE Dp.FechaCanc BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"


        'If xCliente.Text <> "" Then wFiltro &= If(wFiltro = "", " WHERE ", " AND ") & " Cl.Cliente   = '" & xCliente.Text.Trim & "'"

        If xCliente.Text <> "" Then wFiltro &= " AND " & " Cl.Cliente   = '" & xCliente.Text.Trim & "'"

        If ValidarCombo(cTipoDoc) Then wFiltro &= " AND " & " Td.TipoDoc   = '" & cTipoDoc.SelectedValue & "'"

        If xNumero.Text <> "" Then wFiltro &= " AND " & " Dp.Numero   = '" & xNumero.Text.Trim & "'"

        If ValidarCombo(cFormaPago) Then wFiltro &= " AND " & " Fp.FPago   = '" & cFormaPago.SelectedValue & "'"

        If ValidarCombo(cEstado) Then wFiltro &= " AND " & " Es.Estado   = '" & cEstado.SelectedValue & "'"

        If xVendedor.Text <> "" Then wFiltro &= " AND " & " Dp.Vendedor   = '" & xVendedor.Text.Trim & "'"

        wQuery = wQuery & wFiltro
        ModuloReporte = "Pagos"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Reporte de Pagos"
        VisorReportes.Show()

    End Sub

    Private Sub ComboGrilla_SelectedIndexChanged(sender As Object, e As EventArgs)
        If xTabla.Row > 0 And xTabla.Rows.Count > 0 Then
            If cEst.SelectedIndex <> -1 Then
                If BuscarCampo("Estados", "Estado", "DescEstado", cEst.Text) <> "C" Then
                    xTabla.SetData(xTabla.Row, T_FECHACAN, "")
                Else
                    xTabla.SetData(xTabla.Row, T_FECHACAN, Now.ToShortDateString)
                End If
            End If
        End If
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
End Class