Imports System.ComponentModel
Imports SisVen

Public Class TransformarArticulo
    Implements iFormulario
    Const T_ELIMINAR = 0
    Const T_ARTICULOS = 1
    Const T_DESCRIPCIONS = 2
    Const T_CANTIDADS = 3
    Const T_ARTICULOE = 4
    Const T_DESCRIPCIONE = 5
    Const T_CANTIDADE = 6

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub TransformarArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
        LoadCombobox(cBodega, "Bodegas", "Bodega", "NombreBodega")
        xLocal.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        e.NextControl(xBodega)
    End Sub

    Private Sub xLocal_Validating(sender As Object, e As CancelEventArgs) Handles xLocal.Validating
        If xLocal.Text.Trim <> "" Then
            cLocal.SelectedValue = xLocal.Text.Trim
            If cLocal.Text = W_SELECCIONAR Then
                MsgError("Local no encontrado")
                xLocal.Clear()
                xLocal.Focus()
            End If
        End If
    End Sub

    Private Sub xBodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBodega.KeyPress
        e.NextControl(xArticuloS)
    End Sub

    Private Sub xBodega_Validating(sender As Object, e As CancelEventArgs) Handles xBodega.Validating
        If xBodega.Text.Trim <> "" Then
            cBodega.SelectedValue = xBodega.Text.Trim
            If cBodega.Text = W_SELECCIONAR Then
                MsgError("Bodega no encontrado")
                xBodega.Clear()
                xBodega.Focus()
            End If
        End If
    End Sub

    Private Sub xArticuloS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticuloS.KeyPress
        e.NextControl(xCantidadS)
    End Sub

    Private Sub xArticuloS_Validating(sender As Object, e As CancelEventArgs) Handles xArticuloS.Validating
        If ValidarCombo(cLocal) = False Then
            MsgError("Debe seleccionar un local")
            xLocal.Focus()
            Exit Sub
        End If
        If ValidarCombo(cBodega) = False Then
            MsgError("Debe seleccionar una bodega")
            xBodega.Focus()
            Exit Sub
        End If

        If xArticuloS.Text.Trim <> "" Then
            Art = SQL("SELECT A.Descripcion, S.Stock FROM Articulos A JOIN Stocks S ON A.Articulo = S.Articulo AND" &
                      " S.Local = '" & cLocal.SelectedValue & "' AND S.Bodega = '" & cBodega.SelectedValue & "'" &
                      " WHERE A.Articulo = '" & xArticuloS.Text.Trim & "'")

            If Art.RecordCount > 0 Then
                If Art.Fields("Stock").Text < 1 Then
                    MsgError("Artículo sin stock")
                    xDescripcionS.Clear()
                    xArticuloS.Clear()
                    xArticuloS.Focus()
                    Exit Sub
                End If
                xDescripcionS.Text = Art.Fields("Descripcion").Text
                xStockS.Text = Art.Fields("Stock").Text
            Else
                MsgError("Artículo no encontrado")
                xArticuloS.Clear()
                xArticuloS.Focus()
            End If
        End If
    End Sub
    Private Sub xCantidadS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCantidadS.KeyPress
        ValidarDigitos(e)
        e.NextControl(xArticuloE)
    End Sub

    Private Sub xArticuloE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticuloE.KeyPress
        e.NextControl(xCantidadE)
    End Sub

    Private Sub bBuscarS_Click(sender As Object, e As EventArgs) Handles bBuscarS.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticuloS)
    End Sub

    Private Sub bBuscarE_Click(sender As Object, e As EventArgs) Handles bBuscarE.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticuloE)
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            xLocal.Text = cLocal.SelectedValue
        End If
    End Sub

    Private Sub cBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBodega.SelectedIndexChanged
        If ValidarCombo(cBodega) Then
            xBodega.Text = cBodega.SelectedValue
        End If
    End Sub


    Private Sub xArticuloE_Validating(sender As Object, e As CancelEventArgs) Handles xArticuloE.Validating
        If xArticuloE.Text.Trim <> "" Then
            Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & xArticuloE.Text.Trim & "'")
            If Art.RecordCount > 0 Then
                xDescripcionE.Text = Art.Fields("Descripcion").Text
            Else
                MsgError("Artículo no encontrado")
                xDescripcionE.Clear()
                xArticuloE.Clear()
                xArticuloE.Focus()
            End If
        End If
    End Sub
    Private Sub xCantidadE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCantidadE.KeyPress
        ValidarDigitos(e)
        e.NextControl(bCargar)
    End Sub

    Private Sub bCargar_Click(sender As Object, e As EventArgs) Handles bCargar.Click
        If xArticuloE.Text.Trim = "" Then
            MsgError("Debe ingresar artículo de salida")
            xArticuloS.Focus()
            Exit Sub
        End If
        If xArticuloE.Text.Trim = "" Then
            MsgError("Debe ingresar artículo de entrada")
            xArticuloE.Focus()
            Exit Sub
        End If

        If xCantidadS.Text.Trim = "" Then
            MsgError("Debe ingresar cantidad en artículo de Salida")
            xCantidadS.Focus()
            Exit Sub
        End If
        If xCantidadE.Text.Trim = "" Then
            MsgError("Debe ingresar cantidad en artículo de Entrada")
            xCantidadE.Focus()
            Exit Sub
        End If

        If ValidarGrilla() Then
            xTabla.AddItem("")
            xTabla.SetCellImage(xTabla.Rows.Count - 1, T_ELIMINAR, My.Resources.remove_table)
            xTabla.SetData(xTabla.Rows.Count - 1, T_ARTICULOS, xArticuloS.Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_DESCRIPCIONS, xDescripcionS.Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_CANTIDADS, xCantidadS.Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_ARTICULOE, xArticuloE.Text.Trim)
            xTabla.SetData(xTabla.Rows.Count - 1, T_DESCRIPCIONE, xDescripcionE.Text)
            xTabla.SetData(xTabla.Rows.Count - 1, T_CANTIDADE, xCantidadE.Text)
            LimpiarCarga()
            xArticuloE.Focus()
        End If
    End Sub
    Private Sub xCantidadS_Validating(sender As Object, e As CancelEventArgs) Handles xCantidadS.Validating
        If xCantidadS.Text.Trim <> "" And xStockS.Text <> "" Then
            If Val(xCantidadS.Text) > Val(xStockS.Text) Then
                MsgError("La cantidad ingresada supera el stock disponible")
                xCantidadS.Clear()
                xCantidadS.Focus()
            End If
        End If
    End Sub

    Sub Titulos()
        xTabla.Redraw = False

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 7

        xTabla.Cols(T_ELIMINAR).Width = 50
        xTabla.Cols(T_ARTICULOS).Width = 100
        xTabla.Cols(T_DESCRIPCIONS).Width = 233
        xTabla.Cols(T_CANTIDADS).Width = 80
        xTabla.Cols(T_ARTICULOE).Width = 100
        xTabla.Cols(T_DESCRIPCIONE).Width = 233
        xTabla.Cols(T_CANTIDADE).Width = 80

        xTabla.Cols(T_ELIMINAR).Caption = "Eliminar"
        xTabla.Cols(T_ARTICULOS).Caption = "Artículo Salida"
        xTabla.Cols(T_DESCRIPCIONS).Caption = "Descripción"
        xTabla.Cols(T_CANTIDADS).Caption = "Cantidad"

        xTabla.Cols(T_ARTICULOE).Caption = "Artículo Entrada"
        xTabla.Cols(T_DESCRIPCIONE).Caption = "Descripción"
        xTabla.Cols(T_CANTIDADE).Caption = "Cantidad"

        xTabla.Redraw = True
    End Sub
    Sub LimpiarCarga()
        xArticuloE.Clear()
        xDescripcionE.Clear()
        xCantidadE.Clear()
    End Sub
    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 > 0 And xTabla.Col = 0 Then
            xTabla.RemoveItem(xTabla.Row)
        End If
    End Sub
    Private Function ValidarGrilla() As Boolean
        Dim wCantidadGrila As New Double

        For i = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(i, T_ARTICULOS) = xArticuloS.Text Then
                wCantidadGrila += xTabla.GetData(i, T_CANTIDADE)
            End If
        Next
        If wCantidadGrila <> 0 Then
            wCantidadGrila += Val(xCantidadE.Text)

            If wCantidadGrila > Val(xStockS.Text) Then
                MsgError("Lo ingresado pasa la cantidad ya cargada")
                xCantidadE.Focus()
                Return False
            End If
        End If
        Return True

    End Function

    Private Sub bProcesar_Click(sender As Object, e As EventArgs) Handles bProcesar.Click
        If xTabla.Rows.Count - 1 > 0 Then
            Dim wFila = 1
            For i = 1 To xTabla.Rows.Count - 1
                Stk = SQL("SELECT * FROM Stocks WHERE Articulo = '" & xTabla.GetData(wFila, T_ARTICULOS) & "'" &
                          " AND Local = '" & xLocal.Text.Trim & "' AND Bodega = '" & xBodega.Text.Trim & "'")

                If Stk.RecordCount > 0 Then
                    Stk.Fields("Stock").Value = Val(Stk.Fields("Stock").Text) - (xTabla.GetData(wFila, T_CANTIDADS))
                    Stk.Update()
                    Auditoria(Me.Text, PR_MODIFICAR, "", 0)
                End If

                Stk = SQL("SELECT * FROM Stocks WHERE Articulo = '" & xTabla.GetData(wFila, T_ARTICULOE) & "'" &
                          " AND Local = '" & xLocal.Text.Trim & "' AND Bodega = '" & xBodega.Text.Trim & "'")

                If Stk.RecordCount = 0 Then
                    CrearStock(xTabla.GetData(wFila, T_ARTICULOE), xLocal.Text.Trim, xBodega.Text.Trim, xTabla.GetData(wFila, T_CANTIDADE))
                    Auditoria(Me.Text, PR_GUARDAR, "", 0)
                Else
                    Stk.Fields("Stock").Value = Val(Stk.Fields("Stock").Text) + Val(xTabla.GetData(wFila, T_CANTIDADE))
                    Stk.Update()
                    Auditoria(Me.Text, PR_MODIFICAR, "", 0)
                End If
                wFila += 1
            Next
            MsgBox("Artículos modificado correctamente")
            Limpiar()
            Titulos()
            xLocal.Focus()
        Else
            MsgError("Debe ingresar artículo de Salida y Entrada")
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
        Titulos()
        xLocal.Focus()
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
        For Each wControl In GroupBox2.Controls
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

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class