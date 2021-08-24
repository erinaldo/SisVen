Public Class Abastecimiento
    Implements iFormulario
    Const T_ID As Integer = 0
    Const T_ARTICULO As Integer = 1
    Const T_DESCRIPCION As Integer = 2
    Const T_CANTIDAD As Integer = 3
    Dim wTotalLocal As Integer
    Dim wFila As Integer
    Private Sub Abastecimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        cDesde.Value = IniFinFecha(1, Now)
        cHasta.Value = IniFinFecha(2, Now)
        Auditoria(Me.Name, "Ingresó al Módulo", UsuarioActual, CDbl(LocalActual))
    End Sub

    Private Sub bBuscarC_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bBuscarC.Click
        Dim wQuery As String
        wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre Cliente' From Clientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Nombre", Me, "Clientes", xCliente)
    End Sub
    Private Sub bBuscarA_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bBuscarA.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Sub Titulos()
        Loc = SQL("SELECT (SELECT COUNT(Local) FROM Locales)as Total,Local,NombreLocal " &
                  " FROM Locales Order by Local")
        If Loc.EOF Then
            wTotalLocal = 0
        Else
            wTotalLocal = Loc.Fields("Total").Value
        End If

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 4 + wTotalLocal

        xTabla.Cols(T_ID).Caption = ""
        xTabla.Cols(T_ARTICULO).Caption = "Artículo"
        xTabla.Cols(T_DESCRIPCION).Caption = "Descripción"
        xTabla.Cols(T_CANTIDAD).Caption = "C.Solicitado"

        wFila = T_CANTIDAD
        While Not Loc.EOF
            xTabla.Cols(wFila + 1).Caption = Trim(Loc.Fields("NombreLocal").Value)
            xTabla.Cols(wFila + 1).Width = 1000
            Loc.MoveNext()
            wFila = wFila + 1
        End While

        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_ARTICULO).Width = 2000
        xTabla.Cols(T_DESCRIPCION).Width = 1000
        xTabla.Cols(T_CANTIDAD).Width = 1000
    End Sub

    Private Sub xOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xOT.KeyPress
        e.NextControl(xCliente)
        ValidarDigitos(e)
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        e.NextControl(xArticulo)
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text <> "" Then
            Cli = SQL("SELECT Nombre FROM Clientes WHERE Cliente=" & Val(xCliente.Text) & "")
            If Cli.EOF Then
                MsgError("El Cliente ingresado no existe")
                xCliente.Focus()
                Exit Sub
            End If
            xNombreCliente.Text = Trim(Cli.Fields("Nombre").Value)
        Else
            xNombreCliente.Clear()
        End If
    End Sub

    Private Sub xCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles xCliente.KeyDown
        If e.KeyCode = Keys.F3 Then
            bBuscarC_Click()
        End If
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(cDesde)
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If Trim(xArticulo.Text) <> "" Then
            Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & Trim(xArticulo.Text) & "'")
            If Art.RecordCount > 0 Then
                xNombreArticulo.Text = Art.Fields("Descripcion").Value
            Else
                MsgError("Artículo no encontrado")
            End If
        Else
            xNombreArticulo.Clear()
        End If
    End Sub

    Private Sub xArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles xArticulo.KeyDown
        If e.KeyCode = Keys.F3 Then
            bBuscarA_Click()
        End If
    End Sub

    Private Sub oFechaSol_CheckedChanged(sender As Object, e As EventArgs) Handles oFechaSol.CheckedChanged, oFechaEnt.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        Dim wFiltro = ""
        Dim wQuery = ""
        Dim wNombreLocal = ""
        Dim wLocal, wTotalLocales As Integer

        If oFechaSol.Checked Then
            wFiltro = " od.FechaSol Between '" & cDesde.Value & "' AND '" & cHasta.Value & "'"
        Else
            wFiltro = " od.FechaEnt Between '" & cDesde.Value & "' AND '" & cHasta.Value & "'"
        End If

        If Val(xOT.Text) > 0 Then
            wFiltro = wFiltro & " AND od.OT=" & Val(xOT.Text)
        End If

        If Trim(xCliente.Text) <> "" And xNombreCliente.Text.Trim <> "" Then
            wFiltro = wFiltro & " AND o.Cliente=" & Val(xCliente.Text)
        End If

        If Trim(xArticulo.Text) <> "" And xNombreArticulo.Text.Trim <> "" Then
            wFiltro = wFiltro & " AND od.Articulo='" & Trim(xArticulo.Text) & "'"
        End If

        Stk = SQL("SELECT (SELECT COUNT(Local) FROM Locales)as Total,Local,NombreLocal" &
                  " FROM Locales Order by Local")
        While Not Stk.EOF
            wLocal = Stk.Fields("Local").Value
            wTotalLocales = Stk.Fields("Total").Value
            wNombreLocal = Trim(Stk.Fields("NombreLocal").Value)
            wQuery = wQuery + ",Coalesce((SELECT SUM(Stock) FROM Stocks WHERE Articulo=od.Articulo And Local=" & wLocal & " Group By Local),0) as '" & wNombreLocal & "'"
            Stk.MoveNext()
        End While
        Stk = SQL("SELECT od.Articulo,a.Descripcion,COUNT(a.Articulo) as TotalSolicitado " & wQuery & "  " &
                    " FROM OTDet od INNER JOIN Articulos a on od.Articulo=a.Articulo and od.Tipo='A' and od.Estado='E' " &
                    " INNER JOIN OT o on o.OT=od.OT " &
                    " WHERE " & wFiltro & "" &
                    " GROUP By od.Articulo,a.Descripcion")
        Titulos()

        If Stk.EOF Then
            MsgError("No hay datos para mostrar")
            Exit Sub
        End If
        wFila = 1
        While Not Stk.EOF
            xTabla.AddItem("")
            xTabla.SetData(wFila, T_ARTICULO, Stk.Fields("Articulo").Text.Trim)
            xTabla.SetData(wFila, T_DESCRIPCION, Stk.Fields("Descripcion").Text)
            xTabla.SetData(wFila, T_CANTIDAD, Stk.Fields("TotalSolicitado").Text.Trim)

            For i = 1 To wTotalLocales
                xTabla.SetData(wFila, i + 3, Stk.Fields(i + 2).Text.Trim)
            Next
            Stk.MoveNext()
            wFila = wFila + 1
        End While
        xTabla.AjustarColumnas
        Call Auditoria(Me.Name, "Consultó Abastecimiento", xOT.Text, CDbl(LocalActual))
    End Sub
End Class