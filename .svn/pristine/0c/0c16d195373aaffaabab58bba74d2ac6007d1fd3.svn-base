Imports C1.Win.C1FlexGrid

Public Class Mantenedor_Tarifas
    Const T_ELIMINAR As Integer = 0
    Const T_TIPO As Integer = 1
    Const T_FINANCIADOR As Integer = 2
    Const T_TIPO_FINANCIADOR As Integer = 3
    Const T_VALOR As Integer = 4
    Const T_CONTRASTE As Integer = 5
    Const T_URGENCIA As Integer = 6

    Sub TITULOS()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 7
        xTabla.Cols(T_ELIMINAR).Width = 40
        xTabla.Cols(T_TIPO).Width = 40
        xTabla.Cols(T_FINANCIADOR).Width = 40
        xTabla.Cols(T_TIPO_FINANCIADOR).Width = 40
        xTabla.Cols(T_VALOR).Width = 40
        xTabla.Cols(T_CONTRASTE).Width = 40
        xTabla.Cols(T_URGENCIA).Width = 40

        xTabla.Cols(T_ELIMINAR).Caption = " "
        xTabla.Cols(T_TIPO).Caption = "Tipo"
        xTabla.Cols(T_FINANCIADOR).Caption = "Financiador"
        xTabla.Cols(T_TIPO_FINANCIADOR).Caption = "Tipo Financiador"
        xTabla.Cols(T_VALOR).Caption = "Valor"
        xTabla.Cols(T_CONTRASTE).Caption = "Contraste"
        xTabla.Cols(T_URGENCIA).Caption = "Urgencia"
        xTabla.AjustarColumnas
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub Mantenedor_Tarifas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TITULOS()
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        If xTabla.ColSel = T_ELIMINAR Then
            If Pregunta("¿Desea eliminar este tipo?") Then
                xTabla.RemoveItem(xTabla.RowSel)
            End If
        End If
        If xTabla.ColSel = T_VALOR Then
            xTabla.StartEditing(xTabla.RowSel, T_VALOR)
        End If
        If xTabla.ColSel = T_CONTRASTE Then
            xTabla.StartEditing(xTabla.RowSel, T_CONTRASTE)
        End If
        If xTabla.ColSel = T_URGENCIA Then
            xTabla.StartEditing(xTabla.RowSel, T_URGENCIA)
        End If
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If Trim(xArticulo.Text) = "" Then
            xDescripcion.Clear()
            Exit Sub
        End If
        Art = SQL("SELECT Descripcion,Familia FROM Articulos " &
                  " WHERE Articulo='" & Trim(xArticulo.Text) & "'")
        If Art.EOF Then
            MsgError("El Artículo ingresado no existe")
            xArticulo.Clear()
            xDescripcion.Clear()
            xArticulo.Focus()
            Exit Sub
        End If

        If Not Art.Fields("Familia").Text = 3 AndAlso Not Art.Fields("Familia").Text = 2 Then
            MsgError("El Artículo ingresado no corresponde a la Familia de Exámenes")
            xDescripcion.Clear()
            xArticulo.Focus()
            Exit Sub
        End If
        TITULOS()
        xDescripcion.Text = Art.Fields("Descripcion").Text
    End Sub

    Private Sub bAgregar_Click(sender As Object, e As EventArgs) Handles bAgregar.Click
        If Trim(xArticulo.Text) = "" Or Trim(xDescripcion.Text) = "" Then
            MsgError("Debe cargar un artículo")
            xArticulo.Focus()
            Exit Sub
        End If
        'If Trim(cTipoFinanciador.Text) = "" Then
        '    MsgError("Debe seleccionar un Tipo de Financiador")
        '    cTipoFinanciador.Focus()
        '    Exit Sub
        'End If
        'If Trim(cFinanciador.Text) = "" Then
        '    MsgError("Debe seleccionar un Financiador")
        '    cFinanciador.Focus()
        '    Exit Sub
        'End If

        For i = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(i, T_FINANCIADOR) = Trim(cFinanciador.Text) Then
                If xTabla.GetData(i, T_TIPO_FINANCIADOR) = Trim(cTipoFinanciador.Text) Then
                    If xTabla.GetData(i, T_TIPO) = Trim(cTipo.Text) Then
                        MsgError("El Tipo ya se encuentra agregado para el Financiador")
                        Exit Sub
                    End If
                End If
            End If
        Next

        Dim wFila As Integer = 1

        xTabla.AddItem("")
        xTabla.SetCellImage(wFila, T_ELIMINAR, My.Resources.delete)
        xTabla.SetData(wFila, T_TIPO, cTipo.Text)
        xTabla.SetData(wFila, T_FINANCIADOR, cFinanciador.Text)
        xTabla.SetData(wFila, T_TIPO_FINANCIADOR, cTipoFinanciador.Text)
        xTabla.SetData(wFila, T_VALOR, "0")
        xTabla.SetData(wFila, T_CONTRASTE, "0")
        xTabla.SetData(wFila, T_URGENCIA, "0")
        xTabla.AjustarColumnas
    End Sub

    Private Sub xTabla_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles xTabla.ValidateEdit
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        Dim wCantidad As Integer = xTabla.Editor.Text
        Dim wCantidadAnterior As Integer = xTabla.GetData(e.Row, e.Col)

        If Not IsNumeric(wCantidad) Then
            MsgError("El valor ingresado debe ser numerico")
            xTabla.Editor.Text = wCantidadAnterior
            Exit Sub
        End If
        If wCantidad < 0 Then
            MsgError("El valor ingresado no puede ser negativo")
            xTabla.Editor.Text = wCantidadAnterior
            Exit Sub
        End If

    End Sub
End Class