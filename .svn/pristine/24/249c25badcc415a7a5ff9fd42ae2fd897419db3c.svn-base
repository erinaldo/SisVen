Public Class ManPermisos
    Implements iFormulario
    Const T_CHECK = 0
    Const T_MODULO = 1
    Const T_TEXTO = 2
    Private Sub ManPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Auditoria(Text, "Ingreso", "", 0)
        cAccesoUsuario.LoadCombobox("Accesos", "Acceso", "DescAcceso")
        cAccesoUsuarioImportar.LoadCombobox("Accesos", "Acceso", "DescAcceso")
    End Sub
    Sub Titulos()

        xTablaModulos.Redraw = False
        xTablaModulos.Clear()
        xTablaModulos.Rows.Count = 1
        xTablaModulos.Cols.Count = 10

        xTablaModulos.Cols(T_CHECK).Width = 50
        xTablaModulos.Cols(T_TEXTO).Width = 300
        xTablaModulos.Cols(T_MODULO).Width = 0

        xTablaModulos.Cols(T_CHECK).Caption = "Marcar"
        xTablaModulos.Cols(T_MODULO).Caption = "Módulo"
        xTablaModulos.Cols(T_TEXTO).Caption = "Módulo"

        xTablaModulos.Cols(T_CHECK).DataType = GetType(Boolean)
        xTablaModulos.AjustarColumnas

        xTablaModulos.Redraw = True
    End Sub

    Sub TitulosHabilitados()

        xTablaHabilitados.Redraw = False
        xTablaHabilitados.Clear()
        xTablaHabilitados.Rows.Count = 1
        xTablaHabilitados.Cols.Count = 10

        xTablaHabilitados.Cols(T_CHECK).Width = 50
        xTablaHabilitados.Cols(T_TEXTO).Width = 300
        xTablaHabilitados.Cols(T_MODULO).Width = 0

        xTablaHabilitados.Cols(T_CHECK).Caption = "Marcar"
        xTablaHabilitados.Cols(T_MODULO).Caption = "Módulo"
        xTablaHabilitados.Cols(T_TEXTO).Caption = "Módulo"

        xTablaHabilitados.Cols(T_CHECK).DataType = GetType(Boolean)
        xTablaHabilitados.AjustarColumnas
        xTablaHabilitados.Redraw = True
    End Sub

    Private Sub bCargarA_Click(sender As Object, e As EventArgs) Handles bCargarA.Click
        Dim wTabla As String = If(oAccesoA.Checked, "PermisosAcceso", "PermisosUsuario")
        Dim wCampo As String = If(oAccesoA.Checked, "Acceso", "Usuario")
        bCargarA.Enabled = False
        bImportarI.Enabled = False
        CargarModulos(wTabla, wCampo, xCodigoCargar.Text.Trim)
        bCargarA.Enabled = True
        bImportarI.Enabled = True
    End Sub

    Private Sub bImportarI_Click(sender As Object, e As EventArgs) Handles bImportarI.Click
        Dim wTabla As String = If(oAccesoI.Checked, "PermisosAcceso", "PermisosUsuario")
        Dim wCampo As String = If(oAccesoI.Checked, "Acceso", "Usuario")
        bCargarA.Enabled = False
        bImportarI.Enabled = False
        CargarModulos(wTabla, wCampo, xCodigoImportar.Text.Trim)
        bCargarA.Enabled = True
        bImportarI.Enabled = True
    End Sub
    Private Sub CargarModulos(ByVal wTabla As String, ByVal wCampo As String, ByVal wCodigo As String)

        Titulos()
        TitulosHabilitados()

        xProgreso.Visible = True
        DoEvents()
        xTablaHabilitados.Redraw = False
        xTablaModulos.Redraw = False

        Cursor = Cursors.WaitCursor

        Dim wFila As Integer
        Swap = SQL("SELECT Modulo, Texto, (SELECT COUNT(*) FROM " & wTabla &
           " R WHERE R.Modulo = M.Modulo AND " & wCampo & " = '" & wCodigo & "') " &
           " AS 'Habilitado' FROM Modulos M ORDER BY Texto")

        wFila = 1

        xProgreso.Minimum = wFila
        xProgreso.Maximum = Swap.RecordCount + 1

        While Not Swap.EOF
            If Swap.Fields("Habilitado").Value = 1 Then
                xTablaHabilitados.AddItem("")
                wFila = xTablaHabilitados.Rows.Count - 1
                xTablaHabilitados.SetData(wFila, T_CHECK, False)
                xTablaHabilitados.SetData(wFila, T_MODULO, Swap.Fields("Modulo").Value)
                xTablaHabilitados.SetData(wFila, T_TEXTO, Swap.Fields("Texto").Text)
            Else
                xTablaModulos.AddItem("")
                wFila = xTablaModulos.Rows.Count - 1
                xTablaModulos.SetData(wFila, T_CHECK, False)
                xTablaModulos.SetData(wFila, T_MODULO, Swap.Fields("Modulo").Value)
                xTablaModulos.SetData(wFila, T_TEXTO, Swap.Fields("Texto").Text)
            End If
            xProgreso.Value = wFila
            Swap.MoveNext()
        End While

        xProgreso.Value = xProgreso.Maximum
        xProgreso.Visible = False

        xTablaHabilitados.AjustarColumnas
        xTablaModulos.AjustarColumnas

        xTablaHabilitados.Redraw = True
        xTablaModulos.Redraw = True

        Cursor = Cursors.Arrow

    End Sub

    Private Sub xCodigoCargar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCodigoCargar.KeyPress
        e.NextControl(bCargarA)
        If oAccesoA.Checked Then
            ValidarDigitos(e)
        End If
    End Sub

    Private Sub xCodigoImportar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCodigoImportar.KeyPress
        e.NextControl(bImportarI)
        If oAccesoI.Checked Then
            ValidarDigitos(e)
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        bGuardar.Enabled = False
        GuardarPermisos()
        If oAccesoA.Checked Then bAplicarTodo.Enabled = True
        bGuardar.Enabled = True
    End Sub
    Private Sub GuardarPermisos()

        Cursor = Cursors.WaitCursor

        Dim wTabla As String = If(oAccesoA.Checked, "PermisosAcceso", "PermisosUsuario")
        Dim wCampo As String = If(oAccesoA.Checked, "Acceso", "Usuario")
        Dim wCodigo As String = xCodigoCargar.Text.Trim
        Dim wTexto As String = cAccesoUsuario.Text

        If xTablaHabilitados.Rows.Count = 1 Then Exit Sub

        SQL("DELETE FROM " & wTabla & " WHERE " & wCampo & " = '" & wCodigo & "'")
        For wFila As Integer = 1 To xTablaHabilitados.Rows.Count - 1
            Per = SQL("SELECT TOP 1 * FROM " & wTabla)
            Per.AddNew()
            Per.Fields(wCampo).Value = wCodigo
            Per.Fields("Modulo").Value = Val(xTablaHabilitados.GetData(wFila, T_MODULO))
            Per.Update()
        Next

        Mensaje("Se han establecido los Módulos Habilitados para el " & wCampo & " " & wTexto)

        If wCampo = "Acceso" Then
            Usr = SQL("SELECT * FROM (SELECT Usuario, (SELECT COUNT(*) FROM PermisosUsuario WHERE Usuario = Usuarios.Usuario) " &
                      "AS 'CantPermisos' FROM Usuarios WHERE Acceso = " & wCodigo & ") AS Usr WHERE CantPermisos = 0")
            If Usr.RecordCount > 0 Then
                While Not Usr.EOF
                    SQL("INSERT INTO PermisosUsuario (Usuario, Modulo) " &
                        "SELECT '" & Usr.Fields("Usuario").Text & "' AS Usuario, Modulo FROM PermisosAcceso WHERE Acceso = " & wCodigo)
                    Usr.MoveNext()
                End While
                Mensaje("Se han actualizado " & Usr.RecordCount & " Usuarios con el Acceso " & wTexto & "." &
                        " Estos usuarios no tenían permisos establecidos.")
            End If
        End If
        Cursor = Cursors.Arrow

    End Sub
    Private Sub bHabilitar_Click(sender As Object, e As EventArgs) Handles bHabilitar.Click
        Dim wFilaTraspaso As Integer
        Dim wFilasTraspasadas As New Stack(Of Integer)

        xTablaHabilitados.Redraw = False
        xTablaModulos.Redraw = False
        Cursor = Cursors.WaitCursor

        If xTablaModulos.Rows.Count > 1 Then
            For wFila As Integer = 1 To xTablaModulos.Rows.Count - 1
                If xTablaModulos.GetData(wFila, T_CHECK) = True Then
                    xTablaHabilitados.AddItem("")
                    wFilaTraspaso = xTablaHabilitados.Rows.Count - 1
                    xTablaHabilitados.SetData(wFilaTraspaso, T_CHECK, False)
                    xTablaHabilitados.SetData(wFilaTraspaso, T_TEXTO, xTablaModulos.GetData(wFila, T_TEXTO))
                    xTablaHabilitados.SetData(wFilaTraspaso, T_MODULO, xTablaModulos.GetData(wFila, T_MODULO))
                    wFilasTraspasadas.Push(wFila)
                End If
            Next

            For Each wFilaEliminar As Integer In wFilasTraspasadas
                xTablaModulos.RemoveItem(wFilaEliminar)
            Next
            xTablaHabilitados.AjustarColumnas
            xTablaModulos.AjustarColumnas
        End If
        xTablaHabilitados.Redraw = True
        xTablaModulos.Redraw = True
        Cursor = Cursors.Arrow
    End Sub

    Private Sub bDeshabilitar_Click(sender As Object, e As EventArgs) Handles bDeshabilitar.Click
        Dim wFilaTraspaso As Integer
        Dim wFilasTraspasadas As New Stack(Of Integer)

        xTablaHabilitados.Redraw = False
        xTablaModulos.Redraw = False
        Cursor = Cursors.WaitCursor

        If xTablaHabilitados.Rows.Count > 1 Then
            For wFila As Integer = 1 To xTablaHabilitados.Rows.Count - 1
                If xTablaHabilitados.GetData(wFila, T_CHECK) = True Then
                    xTablaModulos.AddItem("")
                    wFilaTraspaso = xTablaModulos.Rows.Count - 1
                    xTablaModulos.SetData(wFilaTraspaso, T_CHECK, False)
                    xTablaModulos.SetData(wFilaTraspaso, T_TEXTO, xTablaHabilitados.GetData(wFila, T_TEXTO))
                    xTablaModulos.SetData(wFilaTraspaso, T_MODULO, xTablaHabilitados.GetData(wFila, T_MODULO))
                    wFilasTraspasadas.Push(wFila)
                End If
            Next

            For Each wFilaEliminar As Integer In wFilasTraspasadas
                xTablaHabilitados.RemoveItem(wFilaEliminar)
            Next

            xTablaHabilitados.AjustarColumnas
            xTablaModulos.AjustarColumnas

        End If

        xTablaHabilitados.Redraw = True
        xTablaModulos.Redraw = True
        Cursor = Cursors.Arrow
    End Sub

    Private Sub xTablaModulos_Click(sender As Object, e As EventArgs) Handles xTablaModulos.Click
        If xTablaModulos.Rows.Count > 1 AndAlso xTablaModulos.Row > 0 Then
            Dim wCheck = (xTablaModulos.GetData(xTablaModulos.Row, T_CHECK))
            xTablaModulos.SetData(xTablaModulos.Row, T_CHECK, Not wCheck)
        End If
    End Sub

    Private Sub xTablaHabilitados_Click(sender As Object, e As EventArgs) Handles xTablaHabilitados.Click
        If xTablaHabilitados.Rows.Count > 1 AndAlso xTablaHabilitados.Row > 0 Then
            Dim wCheck = (xTablaHabilitados.GetData(xTablaHabilitados.Row, T_CHECK))
            xTablaHabilitados.SetData(xTablaHabilitados.Row, T_CHECK, Not wCheck)
        End If
    End Sub

    Private Sub xTablaModulos_DoubleClick(sender As Object, e As EventArgs) Handles xTablaModulos.DoubleClick
        Dim wFila As Integer
        If xTablaModulos.Rows.Count > 1 AndAlso xTablaModulos.Row > 0 Then
            xTablaHabilitados.AddItem("")
            wFila = xTablaHabilitados.Rows.Count - 1
            xTablaHabilitados.SetData(wFila, T_CHECK, False)
            xTablaHabilitados.SetData(wFila, T_MODULO, xTablaModulos.GetData(xTablaModulos.Row, T_MODULO))
            xTablaHabilitados.SetData(wFila, T_TEXTO, xTablaModulos.GetData(xTablaModulos.Row, T_TEXTO))
            xTablaModulos.RemoveItem(xTablaModulos.Row)

            xTablaHabilitados.AjustarColumnas
            xTablaModulos.AjustarColumnas

        End If
    End Sub

    Private Sub xTablaHabilitados_DoubleClick(sender As Object, e As EventArgs) Handles xTablaHabilitados.DoubleClick
        Dim wFila As Integer
        If xTablaHabilitados.Rows.Count > 1 AndAlso xTablaHabilitados.Row > 0 Then
            xTablaModulos.AddItem("")
            wFila = xTablaModulos.Rows.Count - 1
            xTablaModulos.SetData(wFila, T_CHECK, False)
            xTablaModulos.SetData(wFila, T_MODULO, xTablaHabilitados.GetData(xTablaHabilitados.Row, T_MODULO))
            xTablaModulos.SetData(wFila, T_TEXTO, xTablaHabilitados.GetData(xTablaHabilitados.Row, T_TEXTO))
            xTablaHabilitados.RemoveItem(xTablaHabilitados.Row)

            xTablaHabilitados.AjustarColumnas
            xTablaModulos.AjustarColumnas

        End If
    End Sub

    Private Sub bMarcarModulos_Click(sender As Object, e As EventArgs) Handles bMarcarModulos.Click
        If xTablaModulos.Rows.Count = 1 Then Exit Sub
        For wFila As Integer = 1 To xTablaModulos.Rows.Count - 1
            xTablaModulos.SetData(wFila, T_CHECK, True)
        Next
    End Sub

    Private Sub bMarcarHabilitados_Click(sender As Object, e As EventArgs) Handles bMarcarHabilitados.Click
        If xTablaHabilitados.Rows.Count = 1 Then Exit Sub
        For wFila As Integer = 1 To xTablaHabilitados.Rows.Count - 1
            xTablaHabilitados.SetData(wFila, T_CHECK, True)
        Next
    End Sub

    Private Sub bDesmarcarModulos_Click(sender As Object, e As EventArgs) Handles bDesmarcarModulos.Click
        If xTablaModulos.Rows.Count = 1 Then Exit Sub
        For wFila As Integer = 1 To xTablaModulos.Rows.Count - 1
            xTablaModulos.SetData(wFila, T_CHECK, False)
        Next
    End Sub

    Private Sub bDesmarcarHab_Click(sender As Object, e As EventArgs) Handles bDesmarcarHab.Click
        If xTablaHabilitados.Rows.Count = 1 Then Exit Sub
        For wFila As Integer = 1 To xTablaHabilitados.Rows.Count - 1
            xTablaHabilitados.SetData(wFila, T_CHECK, False)
        Next
    End Sub

    Private Sub bBuscarModulos_Click(sender As Object, e As EventArgs) Handles bBuscarModulos.Click

        If xTablaModulos.Rows.Count <= 1 Then Exit Sub
        Dim wFilaBuscada = xTablaModulos.BuscarFila(xBuscarMod.Text, T_TEXTO, xTablaModulos.Selection.BottomRow)
        If xTablaModulos.Selection.BottomRow = wFilaBuscada Then
            Buscar(xTablaModulos, xTablaModulos.Row + 1, xBuscarMod.Text, T_TEXTO)
        Else
            Buscar(xTablaModulos, 0, xBuscarMod.Text, T_TEXTO)
        End If
        bBuscarModulos.Focus()
    End Sub
    Private Sub Buscar(ByVal wTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wInicio As Integer, ByVal wTexto As String, ByVal wColumna As Integer)
        Dim wFilaBuscada = wTabla.BuscarFila(wTexto, T_TEXTO, wInicio)

        If wTabla.Selection.BottomRow = wTabla.Rows.Count - 1 Then
            Buscar(wTabla, 0, wTexto, wColumna)
        End If

        If wTabla.Selection.BottomRow = wFilaBuscada Then
            Buscar(wTabla, wTabla.Row + 1, wTexto, wColumna)
            Exit Sub
        End If

        If wFilaBuscada > 0 Then
            wTabla.Select(wFilaBuscada, T_CHECK)
        Else
            wTabla.Select(1, T_CHECK)
        End If
    End Sub

    Private Sub bAplicarTodo_Click(sender As Object, e As EventArgs) Handles bAplicarTodo.Click
        If Not oAccesoA.Checked Then Exit Sub

        Dim wCodigo As String = Val(xCodigoCargar.Text.Trim)
        Dim wTexto As String = cAccesoUsuario.Text

        If Not Pregunta("¿Desea aplicar los permisos a todos los usuarios del Acceso " & wTexto & "?") Then Exit Sub

        bAplicarTodo.Enabled = False
        bGuardar.Enabled = False
        Cursor = Cursors.WaitCursor

        Usr = SQL("SELECT Distinct Usuario FROM Usuarios WHERE Acceso = " & wCodigo & "")
        If Usr.RecordCount > 0 Then
            While Not Usr.EOF
                SQL("DELETE FROM PermisosUSuario WHERE Usuario = '" & Usr.Fields("Usuario").Text & "'")
                SQL("INSERT INTO PermisosUsuario (Usuario, Modulo) " &
                "Select '" & Usr.Fields("Usuario").Text & "' AS Usuario, Modulo FROM PermisosAcceso WHERE Acceso = " & wCodigo)
                Usr.MoveNext()
            End While
            Mensaje("Se han actualizado " & Usr.RecordCount & " Usuarios con el Acceso " & wTexto)
        End If

        bAplicarTodo.Enabled = False
        bGuardar.Enabled = True
        Cursor = Cursors.Arrow
    End Sub

    Private Sub bManUsuario_Click(sender As Object, e As EventArgs) Handles bManUsuario.Click
        Dim wCodigo As String = xCodigoCargar.Text

        Man_Usuarios.ShowDialog()

        xCodigoImportar.Clear()
        If oAccesoA.Checked Then
            cAccesoUsuario.LoadCombobox("Accesos", "Acceso", "DescAcceso")
        Else
            cAccesoUsuario.LoadCombobox("Usuarios", "Usuario", "NombreUsr")
        End If

        If oAccesoI.Checked Then
            cAccesoUsuarioImportar.LoadCombobox("Accesos", "Acceso", "DescAcceso")
        Else
            cAccesoUsuarioImportar.LoadCombobox("Usuarios", "Usuario", "NombreUsr")
        End If
        BringToFront()
    End Sub

    Private Sub bManAcceso_Click(sender As Object, e As EventArgs) Handles bManAcceso.Click
        Dim wCodigo As String = xCodigoCargar.Text

        ManAccesos.ShowDialog()
        If oAccesoA.Checked Then
            cAccesoUsuario.LoadCombobox("Accesos", "Acceso", "DescAcceso")
        End If
        xCodigoImportar.Clear()
        BringToFront()
    End Sub

    Private Sub oAccesoA_CheckedChanged(sender As Object, e As EventArgs) Handles oAccesoA.CheckedChanged, oUsuarioA.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
        If oAccesoA.Checked Then
            cAccesoUsuario.LoadCombobox("Accesos", "Acceso", "DescAcceso")
        ElseIf oUsuarioA.Checked Then
            cAccesoUsuario.LoadCombobox("Usuarios", "Usuario", "NombreUsr")
            bAplicarTodo.Visible = False
        End If
        xCodigoCargar.Clear()
    End Sub

    Private Sub oAccesoI_CheckedChanged(sender As Object, e As EventArgs) Handles oAccesoI.CheckedChanged, oUsuarioI.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
        If oAccesoI.Checked Then
            cAccesoUsuarioImportar.LoadCombobox("Accesos", "Acceso", "DescAcceso")
        ElseIf oUsuarioI.Checked Then
            cAccesoUsuarioImportar.LoadCombobox("Usuarios", "Usuario", "NombreUsr")
            bAplicarTodo.Visible = False
        End If
        xCodigoImportar.Clear()
    End Sub

    Private Sub xBuscarMod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBuscarMod.KeyPress
        e.NextControl(bBuscarModulos)
    End Sub

    Private Sub xBuscarHab_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBuscarHab.KeyPress
        e.NextControl(xBuscarHab)
    End Sub

    Private Sub xCodigoCargar_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCodigoCargar.Validating
        If xCodigoCargar.Text.Trim <> "" Then
            cAccesoUsuario.SelectedValue = xCodigoCargar.Text.Trim
            If cAccesoUsuario.Text = W_SELECCIONAR Then
                If oAccesoA.Checked Then MsgError("Acceso no encontrado")
                If oUsuarioA.Checked Then MsgError("Usuario no encontrado")
                xCodigoCargar.Clear()
                xCodigoCargar.Focus()
            End If
        End If
    End Sub

    Private Sub cAccesoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cAccesoUsuario.SelectedIndexChanged
        If ValidarCombo(cAccesoUsuario) Then
            xCodigoCargar.Text = cAccesoUsuario.SelectedValue
        Else
            xCodigoCargar.Clear()
        End If
    End Sub

    Private Sub xCodigoImportar_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCodigoImportar.Validating
        If xCodigoImportar.Text.Trim <> "" Then
            cAccesoUsuarioImportar.SelectedValue = xCodigoImportar.Text.Trim
            If cAccesoUsuarioImportar.Text = W_SELECCIONAR Then
                If oAccesoI.Checked Then MsgError("Acceso no encontrado")
                If oUsuarioI.Checked Then MsgError("Usuario no encontrado")
                xCodigoImportar.Clear()
                xCodigoImportar.Focus()
            End If
        End If
    End Sub

    Private Sub cAccesoUsuarioImportar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cAccesoUsuarioImportar.SelectedIndexChanged
        If ValidarCombo(cAccesoUsuarioImportar) Then
            xCodigoImportar.Text = cAccesoUsuarioImportar.SelectedValue
        Else
            xCodigoImportar.Clear()
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bBuscarA_Click(sender As Object, e As EventArgs) Handles bBuscarA.Click
        Dim wQuery As String
        If oAccesoA.Checked Then
            wQuery = "SELECT Acceso , DescAcceso as 'Descripción' From Accesos"
            Buscador.Show()
            Buscador.Configurar(wQuery, "Acceso", Me, "Accesos", xCodigoCargar)
        ElseIf oUsuarioA.Checked Then
            wQuery = "SELECT Usuario , NombreUsr as 'Nombre Usuario' From Usuarios"
            Buscador.Show()
            Buscador.Configurar(wQuery, "Usuario", Me, "Usuarios", xCodigoCargar)
        End If
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub bBuscarI_Click(sender As Object, e As EventArgs) Handles bBuscarI.Click
        Dim wQuery As String
        If oAccesoI.Checked Then
            wQuery = "SELECT Acceso , DescAcceso as 'Descripción' From Accesos"
            Buscador.Show()
            Buscador.Configurar(wQuery, "Acceso", Me, "Accesos", xCodigoImportar)
        ElseIf oUsuarioI.Checked Then
            wQuery = "SELECT Usuario , NombreUsr as 'Nombre Usuario' From Usuarios"
            Buscador.Show()
            Buscador.Configurar(wQuery, "Usuario", Me, "Usuarios", xCodigoImportar)
        End If
    End Sub
End Class