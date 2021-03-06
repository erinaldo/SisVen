Imports C1.Win.C1FlexGrid

Public Class BuscarClientes
    Const T_ID As Integer = 0
    Const T_CLIENTE As Integer = 1
    Const T_RUT As Integer = 2
    Const T_FANTASIA As Integer = 3
    Const T_NOMBRE As Integer = 4
    Const T_DIRECCION As Integer = 5
    Const T_CIUDAD As Integer = 6
    Const T_COMUNA As Integer = 7


    Sub Titulos()
        xTabla.Redraw = False

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 8
        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_CLIENTE).Width = 100
        xTabla.Cols(T_RUT).Width = 100
        xTabla.Cols(T_FANTASIA).Width = 150
        xTabla.Cols(T_NOMBRE).Width = 400
        xTabla.Cols(T_DIRECCION).Width = 500
        xTabla.Cols(T_CIUDAD).Width = 100
        xTabla.Cols(T_COMUNA).Width = 100
        xTabla.SetData(0, T_ID, "ID")
        xTabla.SetData(0, T_CLIENTE, "Cliente")
        xTabla.SetData(0, T_RUT, "Rut")
        xTabla.SetData(0, T_FANTASIA, "Fantasía")
        xTabla.SetData(0, T_NOMBRE, "Nombre")
        xTabla.SetData(0, T_DIRECCION, "Dirección")
        xTabla.SetData(0, T_CIUDAD, "Ciudad")
        xTabla.SetData(0, T_COMUNA, "Comuna")

        xTabla.Redraw = True
    End Sub
    Private Sub BuscarClientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Titulos()
    End Sub

    Private Sub Cargar_Datos()
        Dim wFila As Integer
        Dim wCliente As Double, wCiudad As String, wComuna As String

        Titulos()
        wFila = 1
        Cursor = Cursors.WaitCursor

        wCliente = Val(xDato.Text)

        If wCliente = 0 Or InStr(xDato.Text, "-") > 0 Then
            Swap = SQL("SELECT Cliente, Rut, Nombre, Fantasia, Direccion, Ciudad, Comuna FROM Clientes WHERE Nombre Like '%" + UCase(Trim(xDato.Text)) + "%' or Fantasia Like '%" + UCase(Trim(xDato.Text)) + "%' or Rut = '" + xDato.Text + "'  Order by Nombre")
        Else
            Swap = SQL("SELECT Cliente, Rut, Nombre, Fantasia, Direccion, Ciudad, Comuna FROM Clientes WHERE Cliente = " & wCliente & " or Rut = '" + xDato.Text.Trim + "' Order by Nombre")
        End If

        xTabla.Redraw = False
        DoEvents()

        If Swap.RecordCount > 0 Then
            Try
                xTabla.Visible = False
                Swap.MoveFirst()
                While Not Swap.EOF
                    DoEvents()
                    wCiudad = BuscarCampo("Ciudades", "NombreCiudad", "Ciudad", Swap.Fields("Ciudad").Text.ToString.Trim())
                    wComuna = BuscarCampo("Comunas", "NombreComuna", "Comuna", Swap.Fields("Comuna").Text.ToString.Trim())
                    xTabla.AddItem(New Object() {"", Swap.Fields("Cliente").Text.ToString.Trim, Swap.Fields("Rut").Text.ToString.Trim, Swap.Fields("Fantasia").Text.ToString.Trim, Swap.Fields("Nombre").Text.ToString.Trim, Swap.Fields("Direccion").Text.ToString.Trim, wCiudad, wComuna})
                    Swap.MoveNext()
                    wFila += 1
                End While
            Catch ex As Exception
            End Try
        Else
            Mensaje("No existen datos a mostrar")
            xDato.Focus()
        End If

        'xTabla.AjustarColumnas
        xTabla.Rows.Fixed = 1
        xTabla.Redraw = True
        xTabla.Visible = True
        Cursor = Cursors.Default

        xTabla.Focus()

    End Sub

    Private Sub BuscarCli(Optional sender As System.Object = Nothing, Optional e As System.EventArgs = Nothing) Handles bBuscar.Click
        Cargar_Datos()
    End Sub

    Private Sub xDato_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles xDato.KeyPress
        If e.KeyChar = vbCr Then
            BuscarCli()
        End If
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If Modulo = "Documentos" Then
            Documentos.xCliente.Text = xTabla.GetData(xTabla.Row, T_CLIENTE)
            Documentos.xCliente.Focus()
            SendKeys("{ENTER}")
        End If

        If Modulo = "ManCliente" Then
            ManCliente.xCliente.Text = xTabla.GetData(xTabla.Row, T_CLIENTE)
            ManCliente.xCliente.Focus()
            SendKeys("{ENTER}")
        End If

        If Modulo = "ManMaquinas" Then
            ManMaquinas.xCliente.Text = xTabla.GetData(xTabla.Row, T_CLIENTE)
            ManMaquinas.xCliente.Focus()
            SendKeys("{ENTER}")
        End If

        If Modulo = "ControlPagos" Then
            ControlPagos.xCliente.Text = xTabla.GetData(xTabla.Row, T_CLIENTE)
            ControlPagos.xCliente.Focus()
            SendKeys("{ENTER}")
        End If

        If Modulo = "ContadoresDTE" Then
            ContadoresDTE.xRut.Text = xTabla.GetData(xTabla.Row, T_RUT)
            ContadoresDTE.xRut.Focus()
            SendKeys("{ENTER}")
        End If

        Me.Close()
    End Sub
    Private Sub xTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTabla.KeyPress
        If e.KeyChar = vbCr Then
            If xTabla.Rows.Count > 1 Then
                xTabla_DoubleClick(sender, e)
            End If
        End If
    End Sub
    Private Sub xDato_TextChanged(sender As Object, e As EventArgs) Handles xDato.TextChanged

    End Sub
End Class