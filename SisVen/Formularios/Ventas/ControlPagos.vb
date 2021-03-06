Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class ControlPagos
    Implements iFormulario
    Const T_OK = 0
    Const T_LOCAL = 1
    Const T_DOCUMENTO = 2
    Const T_NUMERO = 3
    Const T_FANTASIA = 4
    Const T_CLIENTE = 5
    Const T_CODIGO = 6
    Const T_FECHAEMI = 7
    Const T_MONTO = 8
    Const T_FPAGO = 9
    Const T_FECHAVEN = 10
    Const T_ESTADO = 11
    Const T_FECHACAN = 12
    Const T_OBSER = 13
    Const T_CHEQUE = 14
    Const T_CUENTA = 15
    Const T_BANCO = 16
    Const T_TITULAR = 17
    Const T_ID = 18
    Const T_MODIF = 19

    Dim cEst As New ComboBox
    Dim cBancos As New ComboBox
    Dim cCuentas As New ComboBox
    Dim FiltroOpcion As String

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub Pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarCombos()
        Titulos()
        cTipoDoc.LoadCombobox("TipoDoc", "TipoDoc", "DescTipoDoc", "WHERE Pagos = 1")
        cFormaPago.LoadCombobox("FPagos", "FPago", "DescFPago", "", "ORDER by Orden")
        cEstado.LoadCombobox("Estados", "Estado", "DescEstado", " WHERE Tipo = 'P'")
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        If gMonoLocal Then
            xLocal.Text = LocalActual
        End If
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
        'Dim wQuery As String
        'wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre Cliente' From Clientes"
        'Buscador.Show()
        'Buscador.Configurar(wQuery, "Nombre", Me, "Clientes", xCliente)
        Modulo = "ControlPagos"
        BuscarClientes.Show()
        BuscarClientes.BringToFront()
    End Sub

    Private Sub xCliente_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xCliente.Validating
        If xCliente.Text <> "" Then
            Dim cl = SQL("SELECT NOMBRE FROM CLIENTES WHERE CLIENTE = " & Val(xCliente.Text) & "")
            If cl.RecordCount > 0 Then
                xNombre.Text = cl.Fields("Nombre").Text
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
        xTabla.Cols.Count = 20

        xTabla.Cols(T_OK).Width = 30
        xTabla.Cols(T_LOCAL).Width = 80
        xTabla.Cols(T_DOCUMENTO).Width = 120
        xTabla.Cols(T_NUMERO).Width = 60
        xTabla.Cols(T_CODIGO).Width = 45
        xTabla.Cols(T_FANTASIA).Width = 100
        xTabla.Cols(T_CLIENTE).Width = 230
        xTabla.Cols(T_FECHAEMI).Width = 80
        xTabla.Cols(T_MONTO).Width = 80
        xTabla.Cols(T_FPAGO).Width = 100
        xTabla.Cols(T_FECHAVEN).Width = 80
        xTabla.Cols(T_ESTADO).Width = 70
        xTabla.Cols(T_FECHACAN).Width = 80
        xTabla.Cols(T_OBSER).Width = 200
        xTabla.Cols(T_CHEQUE).Width = 150
        xTabla.Cols(T_CUENTA).Width = 120
        xTabla.Cols(T_BANCO).Width = 150
        xTabla.Cols(T_TITULAR).Width = 180
        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_MODIF).Width = 0

        xTabla.Cols(T_OK).Caption = "OK"
        xTabla.Cols(T_LOCAL).Caption = "Local"
        xTabla.Cols(T_DOCUMENTO).Caption = "Documento"
        xTabla.Cols(T_NUMERO).Caption = "Número"
        xTabla.Cols(T_CODIGO).Caption = "Código"
        xTabla.Cols(T_FANTASIA).Caption = "Cliente"
        xTabla.Cols(T_CLIENTE).Caption = "Nombre Cliente"
        xTabla.Cols(T_FECHAEMI).Caption = "Fecha Emi."
        xTabla.Cols(T_MONTO).Caption = "Monto"
        xTabla.Cols(T_FPAGO).Caption = "F.Pago"
        xTabla.Cols(T_FECHAVEN).Caption = "Fecha Ven."
        xTabla.Cols(T_ESTADO).Caption = "Estado"
        xTabla.Cols(T_FECHACAN).Caption = "Fecha Can."
        xTabla.Cols(T_OBSER).Caption = "Observaciones"
        xTabla.Cols(T_CHEQUE).Caption = "Cheque"
        xTabla.Cols(T_CUENTA).Caption = "Cuenta"
        xTabla.Cols(T_BANCO).Caption = "Banco"
        xTabla.Cols(T_TITULAR).Caption = "Titular"
        xTabla.Cols(T_ID).Caption = "ID"
        xTabla.Cols(T_MODIF).Caption = "MODIF"

        xTabla.Cols(T_OK).DataType = GetType(Boolean)
        xTabla.Cols(T_MONTO).DataType = GetType(Double)
        xTabla.Cols(T_NUMERO).DataType = GetType(Double)
        xTabla.Cols(T_MONTO).Format = "N0"

        xTabla.Cols(T_OK).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_MONTO).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_NUMERO).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_CODIGO).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_FECHACAN).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHAVEN).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHAEMI).TextAlignFixed = TextAlignEnum.CenterCenter
        xTabla.Cols(T_LOCAL).TextAlignFixed = TextAlignEnum.CenterCenter

        xTabla.Cols(T_OK).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHACAN).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHAVEN).TextAlign = TextAlignEnum.CenterCenter
        xTabla.Cols(T_FECHAEMI).TextAlign = TextAlignEnum.CenterCenter
        'xTabla.Cols(T_LOCAL).TextAlign = TextAlignEnum.CenterCenter

        Dim cFechaCan As New DateTimePicker
        cFechaCan.Format = DateTimePickerFormat.Short
        xTabla.Cols(T_FECHACAN).Editor = cFechaCan

        Dim cFPagos As New ComboBox
        cFPagos.DropDownStyle = ComboBoxStyle.DropDownList
        LoadComboGrilla(cFPagos, "FPagos", "FPago", "DescFPago")
        xTabla.Cols(T_FPAGO).Editor = cFPagos

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

    Private Sub bMostrar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bMostrar.Click
        FiltroOpcion = "Mostrar"
        Mostrar_Datos()
    End Sub

    Private Sub Mostrar_Datos()
        Dim Filtros As String = ""
        Dim wFila As Integer, wTipoDocs As String
        Dim wNeto As New Double, wIva As New Double, wTotal As New Double

        xNeto.Text = 0
        xIva.Text = 0
        xTotal.Text = 0
        xCantSeleccionado.Text = 0
        xTotalSeleccionado.Text = 0.00
        xRegistro.Text = 0
        Titulos()

        Filtros = " (1=1) "
        If xCliente.Text.Trim <> "" Then
            Filtros += " AND Cliente = " & Val(xCliente.Text.Trim) & ""
        End If

        If FiltroOpcion = "Adeudado" Then
            wTipoDocs = " TipoDoc in ('BV','FV','NC','ND','FE','BE') "
            Filtros += " AND " + wTipoDocs
        Else
            If ValidarCombo(cTipoDoc) Then
                wTipoDocs = "TipoDoc = '" + cTipoDoc.SelectedValue + "'"
                Filtros += " AND " + wTipoDocs
            End If
        End If

        If xNumero.Text <> "" Then Filtros += " AND NUMERO = " & Val(xNumero.Text.Trim) & ""
        If xVendedor.Text.Trim <> "" Then Filtros += " AND Vendedor = '" & xVendedor.Text.Trim & "'"
        If ValidarCombo(cFormaPago) Then Filtros += " AND FPago = '" & cFormaPago.SelectedValue & "'"

        If ValidarCombo(cEstado) Then
            Filtros += " AND Estado = '" & cEstado.SelectedValue & "'"
        End If

        Filtros += " AND Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"

        DocP = SQL("SELECT * FROM DocumentosP WHERE " & Filtros + " Order by Local,TipoDoc,Numero")
        If DocP.RecordCount > 0 Then
            Habilitar_Botones(False)
            wFila = 1
            xTabla.Redraw = False
            While Not DocP.EOF
                DoEvents()
                xTabla.AddItem("")
                If gMonoLocal Then
                    xTabla.SetData(wFila, T_LOCAL, NombreLocalActual)
                Else
                    xTabla.SetData(wFila, T_LOCAL, BuscarCampo("Locales", "NombreLocal", "Local", DocP.Fields("Local").Text))
                End If
                Doc = SQL("Select DescTipoDoc from TipoDoc where TipoDoc = '" + DocP.Fields("TipoDoc").Text + "'")
                If Doc.RecordCount > 0 Then
                    xTabla.SetData(wFila, T_DOCUMENTO, Doc.Fields("DescTipoDoc").Text)
                End If
                xTabla.SetData(wFila, T_NUMERO, DocP.Fields("Numero").Text)
                xTabla.SetData(wFila, T_CODIGO, DocP.Fields("Cliente").Text)
                Cli = SQL("Select Nombre,Fantasia from Clientes where Cliente = " + Num(DocP.Fields("Cliente").Text))
                If Cli.RecordCount > 0 Then
                    xTabla.SetData(wFila, T_FANTASIA, Cli.Fields("Fantasia").Text.Trim)
                    xTabla.SetData(wFila, T_CLIENTE, Cli.Fields("Nombre").Text.Trim)
                End If
                xTabla.SetData(wFila, T_FECHAEMI, Formatea_Fecha(CDate((DocP.Fields("Fecha").Text))))

                wTotal += Val(DocP.Fields("Monto").Text) * IIf(DocP.Fields("TipoDoc").Value = "NC", -1, 1)
                xTabla.SetData(wFila, T_MONTO, Val(DocP.Fields("Monto").Text) * IIf(DocP.Fields("TipoDoc").Value = "NC", -1, 1))
                Swap = SQL("SELECT DescFPAGO FROM FPAGOS WHERE Fpago = '" & DocP.Fields("Fpago").Text & "'")
                If Swap.RecordCount > 0 Then
                    xTabla.SetData(wFila, T_FPAGO, Swap.Fields("DescFPago").Text)
                End If
                xTabla.SetData(wFila, T_FECHAVEN, Formatea_Fecha(DocP.Fields("FechaPago").Text))
                If DocP.Fields("FechaCanc").Text <> CDate("01/01/2000") Then
                    xTabla.SetData(wFila, T_FECHACAN, Formatea_Fecha(DocP.Fields("FechaCanc").Text))
                End If

                Swap = SQL("SELECT DescEstado From Estados WHERE Estado = '" & DocP.Fields("Estado").Text & "' AND Tipo = 'P'")
                If Swap.RecordCount > 0 Then
                    xTabla.SetData(wFila, T_ESTADO, Swap.Fields("DescEstado").Text)
                End If
                xTabla.SetData(wFila, T_OBSER, DocP.Fields("Obs").Text)
                xTabla.SetData(wFila, T_CHEQUE, DocP.Fields("NumeroPago").Text)
                xTabla.SetData(wFila, T_CUENTA, DocP.Fields("Cuenta").Text)
                Swap = SQL("SELECT DescBanco FROM Bancos WHERE Banco = '" & DocP.Fields("Banco").Text & "'")
                If Swap.RecordCount > 0 Then
                    xTabla.SetData(wFila, T_BANCO, Swap.Fields("DescBanco").Text)
                End If
                xTabla.SetData(wFila, T_TITULAR, DocP.Fields("Titular").Text)

                xTabla.SetData(wFila, T_ID, DocP.Fields("ID").Text)
                xTabla.SetData(wFila, T_MODIF, 0)

                If DocP("FechaPago").Value <= Now.Date Then
                    xTabla.FondoCelda(wFila, Color.Yellow)
                End If

                wFila += 1
                DocP.MoveNext()
            End While

            xTabla.Redraw = True
            xNeto.Text = FormatNumber(wTotal / (1 + (IvaGlobal / 100)), 0)
            If xNeto.Text.Trim = "" Then xNeto.Text = 0
            xIva.Text = FormatNumber(wTotal - CDbl(xNeto.Text), 0)
            xTotal.Text = FormatNumber(wTotal, 0)
            xRegistro.Text = xTabla.Rows.Count - 1
            Habilitar_Botones(True)
        Else
            Mensaje("No se encuentran datos con el filtro ingresado")
        End If

    End Sub

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click
        If xTabla.Rows.Count > 1 AndAlso xTabla.Row > 0 Then

            If xTabla.Col = T_OK Then
                Dim wCheck = Not (xTabla.GetData(xTabla.Row, T_OK))
                xTabla.SetData(xTabla.Row, T_OK, wCheck)
            ElseIf xTabla.Col = T_ESTADO Then
                xTabla.StartEditing(xTabla.Row, T_ESTADO)
            ElseIf xTabla.Col = T_FECHACAN Then
                If BuscarCampo("Estados", "Estado", "DescEstado", xTabla.GetData(xTabla.Row, T_ESTADO), "Tipo='P'") = "C" Then
                    xTabla.StartEditing(xTabla.Row, T_FECHACAN)
                End If
            ElseIf xTabla.Col = T_ESTADO Then
                xTabla.StartEditing(xTabla.Row, T_ESTADO)
            ElseIf xTabla.Col = T_FPAGO Then
                xTabla.StartEditing(xTabla.Row, T_FPAGO)
            ElseIf xTabla.Col = T_OBSER Then
                xTabla.StartEditing(xTabla.Row, T_OBSER)
            ElseIf xTabla.Col = T_CHEQUE Then
                xTabla.StartEditing(xTabla.Row, T_CHEQUE)
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
                Total += xTabla.GetData(wFila, T_MONTO)
                Cont += 1
            End If
        Next

        xTotalSeleccionado.Text = FormatNumber(Total, 0)
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

        xCliente.Text = ""
        xNombre.Text = ""
        xNumero.Text = ""
        cFormaPago.Text = ""
        cEstado.Text = ""
        xVendedor.Text = ""
        xVNombre.Text = ""
        Solo_Deudas = False

        FiltroOpcion = "Mes"
        Mostrar_Datos()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If xTabla.Rows.Count - 1 > 0 Then
            If Pregunta("Desea guardar cambios en pagos") = True Then
                Habilitar_Botones(False)
                For wFila As Integer = 1 To xTabla.Rows.Count - 1
                    'Solo procesar registros modificados
                    If Val(xTabla.GetData(wFila, T_MODIF)) = 1 Then
                        DocP = SQL("SELECT * FROM DocumentosP Where ID = " & Num(xTabla.GetData(wFila, T_ID)))
                        If DocP.RecordCount > 0 Then
                            DocP.Fields("Fecha").Value = xTabla.GetData(wFila, T_FECHAEMI)
                            If BuscarCampo("Estados", "Estado", "DescEstado", xTabla.GetData(wFila, T_ESTADO), "Tipo='P'") = "C" Then
                                DocP.Fields("FechaCanc").Value = xTabla.GetData(wFila, T_FECHACAN)
                            End If

                            DocP.Fields("FPago").Value = BuscarCampo("FPagos", "FPago", "DescFPago", xTabla.GetData(wFila, T_FPAGO))
                            DocP.Fields("Estado").Value = BuscarCampo("Estados", "Estado", "DescEstado", xTabla.GetData(wFila, T_ESTADO), "Tipo='P'")
                            DocP.Fields("Obs").Value = Trim(xTabla.GetData(wFila, T_OBSER))
                            DocP.Fields("NumeroPago").Value = Trim(xTabla.GetData(wFila, T_CHEQUE))
                            DocP.Fields("Cuenta").Value = Trim(xTabla.GetData(wFila, T_CUENTA))
                            DocP.Fields("Banco").Value = BuscarCampo("Bancos", "Banco", "DescBanco", xTabla.GetData(wFila, T_BANCO))
                            DocP.Fields("Titular").Value = Trim(xTabla.GetData(wFila, T_TITULAR))
                            DocP.Fields("Usuario").Value = UsuarioActual
                            DocP.Update()
                        Else
                            MsgError("Error al actualizar ID: " + Num(xTabla.GetData(wFila, T_ID)) + " en Documentos Pagos")
                        End If
                    End If
                Next
                Habilitar_Botones(True)
                Mensaje("Pagos actualizados correctamente")
                Auditoria(Me.Text, PR_MODIFICAR, "", 0)
                Mostrar_Datos()
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
        Habilitar_Botones(True)

        If gMonoLocal Then
            xLocal.Text = LocalActual
            cLocal.Text = NombreLocalActual
        End If
    End Sub

    Private Sub bListado_Click(sender As Object, e As EventArgs) Handles bListado.Click
        Dim wQuery As String
        Dim wReporte As New ReportePagos
        Dim wFiltro As String = ""

        'wQuery = "SELECT Td.DescTipoDoc,Dp.Numero,Cl.Rut,Cl.Nombre,Dp.Monto, Fp.DescFPago, Es.DescEstado, Dp.FechaCanc, Dp.Obs  FROM DocumentosP Dp" &
        '         " JOIN TipoDoc Td ON DP.TipoDoc = Td.TipoDoc" &
        '         " JOIN Clientes Cl ON Dp.CLiente = Cl.CLiente" &
        '         " JOIN FPagos Fp ON Dp.FPago = Fp.FPago" &
        '         " JOIN Estados Es ON Dp.Estado = Es.Estado WHERE Dp.FechaCanc BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"

        'Habilitar_Botones(False)
        ''If xCliente.Text <> "" Then wFiltro &= If(wFiltro = "", " WHERE ", " AND ") & " Cl.Cliente   = '" & xCliente.Text.Trim & "'"

        'If xCliente.Text <> "" Then wFiltro &= " AND " & " Cl.Cliente   = '" & xCliente.Text.Trim & "'"

        'If ValidarCombo(cTipoDoc) Then wFiltro &= " AND " & " Td.TipoDoc   = '" & cTipoDoc.SelectedValue & "'"

        'If xNumero.Text <> "" Then wFiltro &= " AND " & " Dp.Numero   = '" & xNumero.Text.Trim & "'"

        'If ValidarCombo(cFormaPago) Then wFiltro &= " AND " & " Fp.FPago   = '" & cFormaPago.SelectedValue & "'"

        'If ValidarCombo(cEstado) Then wFiltro &= " AND " & " Es.Estado   = '" & cEstado.SelectedValue & "'"

        'If xVendedor.Text <> "" Then wFiltro &= " AND " & " Dp.Vendedor   = '" & xVendedor.Text.Trim & "'"

        wFiltro &= "Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"

        If xCliente.Text <> "" Then wFiltro &= " AND " & " C.Cliente   = '" & xCliente.Text.Trim & "'"
        If cTipoDoc.Text <> W_SELECCIONAR Then wFiltro &= " AND " & " T.TipoDoc   = '" & cTipoDoc.SelectedValue.ToString & "'"
        If xNumero.Text <> "" Then wFiltro &= " AND " & " DP.Numero   = '" & xNumero.Text.Trim & "'"
        If cFormaPago.Text <> W_SELECCIONAR Then wFiltro &= " AND " & " F.FPago   = '" & cFormaPago.SelectedValue.ToString & "'"
        If cEstado.Text <> W_SELECCIONAR Then wFiltro &= " AND " & " E.Estado   = '" & cEstado.SelectedValue.ToString & "'"
        If xVendedor.Text <> "" Then wFiltro &= " AND " & " DP.Vendedor   = '" & xVendedor.Text.Trim & "'"



        wQuery = "SELECT DP.*,T.DescTipoDoc,C.Nombre, F.DescFPago, B.DescBanco, E.DescEstado, C.Rut" &
                         " FROM DocumentosP  DP" &
                         " JOIN TipoDoc T ON DP.TipoDoc = T.TipoDoc" &
                         " JOIN Clientes C ON DP.Cliente = C.Cliente" &
                         " JOIN FPagos F ON DP.FPago = F.FPago" &
                         " JOIN Estados E ON DP.Estado = E.Estado And E.Tipo = 'P'" &
                         " JOIN Bancos B ON DP.Banco = B.Banco" &
                         " WHERE " & wFiltro & " ORDER BY DP.Local,DP.TipoDoc,DP.Numero"

        'wQuery = wQuery & wFiltro
        ModuloReporte = "Pagos"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Reporte de Pagos"
        Try
            VisorReportes.Show()
        Catch ex As Exception
        End Try
        Habilitar_Botones(True)
    End Sub

    Private Sub ComboGrilla_SelectedIndexChanged(sender As Object, e As EventArgs)
        If xTabla.Row > 0 And xTabla.Rows.Count > 0 Then
            If cEst.SelectedIndex <> -1 Then
                If BuscarCampo("Estados", "Estado", "DescEstado", cEst.Text, "Tipo='P'") <> "C" Then
                    xTabla.SetData(xTabla.Row, T_FECHACAN, "")
                Else
                    xTabla.SetData(xTabla.Row, T_FECHACAN, Formatea_Fecha(Now.ToShortDateString))
                End If
            End If
        End If
    End Sub

    Private Sub Habilitar_Botones(qOpcion As Boolean)
        If qOpcion Then
            Cursor = Cursors.Arrow
        Else
            Cursor = Cursors.WaitCursor
        End If
        bDeudas.Enabled = qOpcion
        bConsultar.Enabled = qOpcion
        bListado.Enabled = qOpcion
        bMostrar.Enabled = qOpcion
        bGuardar.Enabled = qOpcion
    End Sub
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub xTabla_StartEdit(sender As Object, e As RowColEventArgs) Handles xTabla.StartEdit
        'Marcar que la celda fue modificada para porteriormente solo procesar las modificadas
        xTabla.SetData(xTabla.Row, T_MODIF, 1)
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick

    End Sub

    Private Sub bDeudas_Click(sender As Object, e As EventArgs) Handles bDeudas.Click
        If gClave = "W" Then
            cTipoDoc.Text = "Factura de Venta"
        End If
        dDesde.Value = IniFecha(1, CDate("01/01/2000"))
        dHasta.Value = IniFecha(2, Now.Date)
        xCliente.Text = ""
        xNombre.Text = ""
        xNumero.Text = ""
        cFormaPago.Text = ""
        cEstado.Text = "Pendiente"
        xVendedor.Text = ""
        xVNombre.Text = ""
        Solo_Deudas = True

        FiltroOpcion = "Adeudado"
        Mostrar_Datos()

        Solo_Deudas = False

    End Sub

    Private Sub bCopiar_Click(sender As Object, e As EventArgs) Handles bCopiar.Click
        Dim CopyPaste As String = ""
        'xTabla.ClipboardCopyMode = ClipboardCopyModeEnum.DataAndAllHeaders
        'xTabla.Copy()
        Try
            For Fil = 0 To xTabla.Rows.Count
                For Col = T_OK To T_TITULAR
                    CopyPaste = CopyPaste + CStr(xTabla.GetData(Fil, Col)) + vbTab
                    DoEvents()
                Next Col
                CopyPaste = CopyPaste + vbNewLine
            Next Fil
        Catch ex As Exception
        End Try


        Clipboard.Clear()
        Clipboard.SetText(CopyPaste)
        Mensaje("Datos Copiados")
    End Sub

    Private Sub bDirectorio_Click(sender As Object, e As EventArgs) Handles bDirectorio.Click
        Abrir_Documento(Directorio_PDF)
    End Sub

    Private Sub xTabla_MouseDown(sender As Object, e As MouseEventArgs) Handles xTabla.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim xTabla = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
            MostrarMenu(xTabla, e.Location, mMenuPopUp)
        End If
    End Sub

    Public Sub MostrarMenu(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByRef wUbicacion As Point, ByRef mMenu As ContextMenuStrip)
        Dim wHit As C1.Win.C1FlexGrid.HitTestInfo = xTabla.HitTest(wUbicacion)
        xTabla.Row = wHit.Row
        xTabla.Col = wHit.Column

        If xTabla.Row < 1 Then Exit Sub
        mMenuPopUp.Tag = xTabla.GetData(xTabla.Row, T_NUMERO)
        mMenu.Show(xTabla, wHit.Point)
    End Sub

    Private Sub mMenuPopUp_Opening(sender As Object, e As CancelEventArgs) Handles mMenuPopUp.Opening

    End Sub

    Private Sub popImprimir_Click(sender As Object, e As EventArgs) Handles popImprimir.Click
        Dim wTipoDoc As String, wLocal As Double
        If xTabla.Col = T_NUMERO Or xTabla.Col = T_CLIENTE Or xTabla.Col = T_DOCUMENTO Then
            wTipoDoc = BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(xTabla.Row, T_DOCUMENTO))
            If gMonoLocal Then
                wLocal = LocalActual
            Else
                wLocal = BuscarCampo("Locales", "Local", "NombreLocal", xTabla.GetData(xTabla.Row, T_LOCAL))
            End If
            Imprimir_Documento(wLocal, wTipoDoc, xTabla.GetData(xTabla.Row, T_NUMERO), xTabla.GetData(xTabla.Row, T_DOCUMENTO), True)
        End If
    End Sub

    Private Sub popAbrir_Click(sender As Object, e As EventArgs) Handles popAbrir.Click
        Dim wTipoDoc As String, wLocal As Double
        wTipoDoc = BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(xTabla.Row, T_DOCUMENTO))
        If gMonoLocal Then
            wLocal = LocalActual
        Else
            wLocal = BuscarCampo("Locales", "Local", "NombreLocal", xTabla.GetData(xTabla.Row, T_LOCAL))
        End If
        Respuesta = Abrir_Documento(Archivo_Fiscal(gPDF, wLocal, wTipoDoc, xTabla.GetData(xTabla.Row, T_NUMERO), 0))
    End Sub

    Private Sub popEMail_Click(sender As Object, e As EventArgs) Handles popEMail.Click
        Dim wTipoDoc As String, wLocal As Double
        Dim mailParametros As String = "", mailPara As String = "", mailAsunto As String = "", mailMensaje As String = "", mailArchivo As String = ""

        wTipoDoc = BuscarCampo("TipoDoc", "TipoDoc", "DescTipoDoc", xTabla.GetData(xTabla.Row, T_DOCUMENTO))
        If gMonoLocal Then
                wLocal = LocalActual
            Else
                wLocal = BuscarCampo("Locales", "Local", "NombreLocal", xTabla.GetData(xTabla.Row, T_LOCAL))
            End If
        If Busca_Archivo(Archivo_Fiscal(gPDF, wLocal, wTipoDoc, xTabla.GetData(xTabla.Row, T_NUMERO), 0)) Then
            Cli = SQL("Select Nombre,Contacto,EMail from Clientes where Cliente = " + xTabla.GetData(xTabla.Row, T_CODIGO))
            If Cli.RecordCount > 0 Then
                mailPara = Cli("Email").Text.Trim.ToLower
                mailAsunto = xTabla.GetData(xTabla.Row, T_DOCUMENTO) & " " & xTabla.GetData(xTabla.Row, T_NUMERO)
                mailMensaje = "" & vbCrLf & vbCrLf
            End If
            mailArchivo = Archivo_Fiscal(gPDF, wLocal, wTipoDoc, xTabla.GetData(xTabla.Row, T_NUMERO), 0)
            mailParametros = "mailto:" & mailPara & "?subject=" & mailAsunto & "&body=" & mailMensaje & "&Attachment=" & mailArchivo
            System.Diagnostics.Process.Start(mailParametros)
        End If
    End Sub
End Class