Imports C1.Win.C1FlexGrid

Public Class Buscador
    Dim gFormulario As iFormulario
    Dim gCampos As String
    Dim gTablas As String
    Dim gIndice As String
    Dim gControl As Control
    Dim gQuery As String
    Dim wFila As Integer


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
    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Buscar_Datos()
    End Sub
    Sub Buscar_Datos()
        Dim wWhere As String = ""
        Try
            xTabla.Redraw = False
            Cursor = Cursors.WaitCursor
            bBuscar.Enabled = False
            xTabla.Rows.Count = 1
            xTabla.Cols.Count = 1

            If xBuscar.Text.Trim = "" Then
                wWhere = ""
            Else
                wWhere = " WHERE " & gIndice & " Like '%" & xBuscar.Text & "%'"
            End If

            Dim REG = SQL(gQuery & wWhere)

            If REG.RecordCount > 0 Then

                xProgreso.Visible = True
                bBuscar.Enabled = False
                bCancelar.Enabled = False
                xProgreso.Value = 1
                xProgreso.Minimum = 1
                xProgreso.Maximum = REG.RecordCount
                xTabla.Clear()
                xTabla.Rows.Count = 1
                xTabla.Cols.Count = REG.Fields.Count

                For i = 0 To REG.Fields.Count - 1
                    xTabla.SetData(0, i, REG.Fields(i).Name)
                    xTabla.Cols(i).Width = 1
                Next

                wFila = 1
                xTabla.Redraw = False

                For i = 1 To REG.RecordCount
                    DoEvents()
                    xTabla.AddItem("")
                    For Col = 0 To xTabla.Cols.Count - 1
                        xTabla.SetData(wFila, Col, REG.Fields(Col).Text)
                    Next Col
                    REG.MoveNext()
                    xProgreso.Value = wFila
                    wFila += 1
                Next i
                xTabla.AjustarColumnas
                lCantidadArticulos.Text = wFila - 1
                xTabla.Redraw = True
                xProgreso.Value = 1
                xProgreso.Visible = False
                bBuscar.Enabled = True
                bCancelar.Enabled = True
                Auditoria(Text, "Consultó Tabla Artículos", "", 0)
                xBuscar.Focus()
            Else
                MsgError("No hay datos para Mostrar")
                xTabla.Clear()
                xTabla.Rows.Count = 1
                lCantidadArticulos.Text = 0
                xBuscar.Focus()
            End If
            xTabla.AjustarColumnas
            xTabla.Focus()
        Catch ex As Exception
        Finally
            xTabla.Redraw = True
            Cursor = Cursors.Arrow
            bBuscar.Enabled = True
        End Try

    End Sub

    Public Sub Configurar(ByVal wQuery As String, ByVal wClave As String, wFormulario As iFormulario, ByVal wTitulo As String, wControl As Control)
        gFormulario = wFormulario
        gQuery = wQuery
        gIndice = wClave
        gControl = wControl
        WinDeco1.Titulo.Text = "Buscar " & wTitulo
    End Sub
    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        Dim wRegistro As String = xTabla.GetData(xTabla.Row, 0)
        gFormulario.CargarRegistro(gControl, wRegistro)
        Close()
    End Sub

    Private Sub xTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTabla.KeyPress
        If e.KeyChar = vbCr AndAlso xTabla.Rows.Count > 1 Then
            Dim wRegistro As String = xTabla.GetData(xTabla.Row, 0)
            gFormulario.CargarRegistro(gControl, wRegistro)
            Close()
            'Dim wRegistro As String = xTabla.GetData(xTabla.Row, xTabla.indiceNombreColumna(gIndice))
            'gFormulario.CargarRegistro(gControl, wRegistro)
            'Close()
        End If
    End Sub

    Private Sub xBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBuscar.KeyPress
        If e.KeyChar = vbCr Then
            Buscar_Datos()
        End If
    End Sub
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click

    End Sub

#End Region
End Class

