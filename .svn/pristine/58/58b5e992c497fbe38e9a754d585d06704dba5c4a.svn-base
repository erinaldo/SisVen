Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Consulta_Articulos
    Const T_SKU As Integer = 0
    Const T_ARTICULO As Integer = 1
    Const T_DESCRIPCION As Integer = 2
    Const T_ENVASE As Integer = 3
    Const T_NOMBRE As Integer = 5
    Const T_CLIENTE As Integer = 4


    Sub Titulos()
        xTabla.Clear()

        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 6

        xTabla.Cols(T_SKU).Width = 150
        xTabla.Cols(T_ARTICULO).Width = 150
        xTabla.Cols(T_DESCRIPCION).Width = 300
        xTabla.Cols(T_ENVASE).Width = 100
        xTabla.Cols(T_NOMBRE).Width = 100
        xTabla.Cols(T_CLIENTE).Width = 100

        xTabla.Cols(T_SKU).Caption = "SKU"
        xTabla.Cols(T_ARTICULO).Caption = "Artículo"
        xTabla.Cols(T_DESCRIPCION).Caption = "Descripción"
        xTabla.Cols(T_ENVASE).Caption = "Envase"
        xTabla.Cols(T_NOMBRE).Caption = "Nombre"
        xTabla.Cols(T_CLIENTE).Caption = "Cliente"

        xTabla.Cols(T_SKU).DataType = GetType(String)
        xTabla.Cols(T_SKU).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
    End Sub

    Private Sub Cargar_Datos()
        Dim wFila As Integer
        Dim wCliente As Double = Val(xCliente.Text)

        Titulos()
        wFila = 1
        Cursor = Cursors.WaitCursor
        'Buscar por Nombre y Cliente, si hay datos
        Cargando.Text = "Cargando Datos..."
        If IsNumeric(xDescripcion.Text) Then
            Swap = SQL("SELECT a.SKU, a.articulo, a.Descripcion,a.Envase,c.nombre,a.cliente " &
                       "FROM clientes AS c INNER JOIN articulos AS a ON c.Cliente=a.Cliente WHERE (c.LocalRuta=" &
                        LocalActual & " or c.PMultilocal=1) AND a.Articulo=" & Val(xDescripcion.Text) + "" &
                        If(wCliente > 0, " AND a.Cliente = " & wCliente, "") &
                        " ORDER BY a.Articulo")

            If Swap.RecordCount = 0 Then
                Swap = SQL("SELECT a.SKU, a.articulo,a.Descripcion,a.Envase,c.nombre,a.cliente " &
                       "FROM clientes AS c INNER JOIN articulos AS a ON c.Cliente=a.Cliente WHERE (c.LocalRuta=" &
                       LocalActual & " or c.PMultilocal=1) AND a.SKU = '" & Trim(xDescripcion.Text) & "'" &
                        If(wCliente > 0, " AND a.Cliente = " & wCliente, "") &
                        " ORDER BY a.Articulo")
            End If
        ElseIf wCliente = 0 And xDescripcion.Text = "" Then
            Swap = SQL("SELECT a.SKU, a.articulo,a.Descripcion,a.Envase,c.nombre,a.cliente " &
                  "FROM clientes AS c INNER JOIN articulos AS a ON c.Cliente=a.Cliente WHERE (c.LocalRuta=" &
                  LocalActual & " or c.PMultilocal=1) ORDER BY a.Articulo")
        Else
            Swap = SQL("SELECT a.SKU, a.articulo,a.Descripcion,a.Envase,c.nombre,a.cliente " &
                  "FROM clientes AS c INNER JOIN articulos AS a ON c.Cliente=a.Cliente WHERE (c.LocalRuta=" &
                  LocalActual & " or c.PMultilocal=1) AND a.SKU = '" + Trim(xDescripcion.Text) + "'" &
                   If(wCliente > 0, " AND a.Cliente = " & wCliente, "") &
                   " ORDER BY a.Articulo")

            If Swap.RecordCount = 0 Then
                Swap = SQL("SELECT a.SKU, a.articulo,a.Descripcion,a.Envase,c.nombre,a.cliente " &
                       "FROM clientes AS c INNER JOIN articulos AS a ON c.Cliente=a.Cliente WHERE (c.LocalRuta=" &
                       LocalActual & " or c.PMultiLocal=1 ) AND a.Descripcion LIKE '%" + Trim(xDescripcion.Text) + "%'" &
                        If(wCliente > 0, " AND a.Cliente = " & wCliente, "") &
                        " ORDER BY a.Articulo")
            End If
        End If



        xTabla.Redraw = False
        If Swap.RecordCount > 0 Then
            xTabla.Visible = False
            Swap.MoveFirst()
            While Not Swap.EOF
                xTabla.AddItem("")
                xTabla.SetData(wFila, T_SKU, Swap.Fields("SKU").Value)
                xTabla.SetData(wFila, T_ARTICULO, Swap.Fields("Articulo").Value)
                xTabla.SetData(wFila, T_DESCRIPCION, Swap.Fields("Descripcion").Value)
                xTabla.SetData(wFila, T_ENVASE, Swap.Fields("Envase").Value)
                xTabla.SetData(wFila, T_CLIENTE, Swap.Fields("Cliente").Value)
                xTabla.SetData(wFila, T_NOMBRE, Swap.Fields("Nombre").Value)
                Swap.MoveNext()
                wFila += 1
            End While
            xTabla.AjustarColumnas
            lCantidadArticulos.Text = Swap.RecordCount
        Else
            Mensaje("No Existen Datos a Mostrar")
            xDescripcion.Focus()
        End If
        Cargando.Text = ""
        xTabla.Redraw = True
        xTabla.Visible = True

        xTabla.Focus()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Cargar_Datos()
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDescripcion.KeyPress
        If e.KeyChar = vbCr Then
            Cargar_Datos()
        End If
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text <> "" Then
            xCliente.Text = Val(xCliente.Text)
            If ValidarCliente(Val(xCliente.Text)) Then
                xNombreCliente.Text = Cli.Fields("Nombre").Text
            Else
                xNombreCliente.Clear()
                xCliente.Clear()
                MsgError("No existe el Cliente ingresado")
                xCliente.Focus()
            End If
        Else
            xNombreCliente.Clear()
            xCliente.Clear()
        End If
    End Sub

    Private Sub xCliente__KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            xDescripcion.Focus()
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        xCliente.Clear()
        xNombreCliente.Clear()
    End Sub

    Private Sub bBuscarCliente_Click(sender As Object, e As EventArgs) Handles bBuscarCliente.Click
        Modulo = "ConsultaArticulos"
        BuscarClientes.Show()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub Cargar_Click(sender As Object, e As EventArgs) Handles Cargar.Click

        Cargar_Datos()
        Cargando.Text = ""
        Auditoria(Text, "Cargó Tabla", "", 0)
    End Sub

    Private Sub Consulta_Articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        Fecha.Text = Date.Now.ToString("dd/MM/yyyy")
        Auditoria(Text, "Ingreso", "", 0)
    End Sub

#Region "MenuCopiar"
    Private Sub bCopiar_Click(sender As Object, e As EventArgs) Handles bCopiar.Click
        If bCopiar.Tag IsNot Nothing Then
            Clipboard.SetText(bCopiar.Tag.ToString)
            mMenuTabla.Hide()
        End If
    End Sub

    Private Sub xTabla_MouseDown(sender As Object, e As MouseEventArgs) Handles xTabla.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim xTabla = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
            MostrarMenuCopiar(xTabla, e.Location, mMenuTabla, bCopiar)
        End If
    End Sub

    Private Sub xTabla_KeyDown(sender As Object, e As KeyEventArgs) Handles xTabla.KeyDown
        Dim xTabla = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.C Then
            CopiarSeleccion(xTabla)
            e.Handled = True
        End If
    End Sub
#End Region

End Class