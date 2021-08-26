Imports System.ComponentModel
Imports SisVen

Public Class ModificarStock
    Implements iFormulario
    Const T_LOCAL = 0
    Const T_CODIGO = 1
    Const T_BODEGA = 2
    Const T_STOCK = 3

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub

    Private Sub ModificarStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        Bod = SQL("SELECT Bodega,NombreBodega From Bodegas Order by NombreBodega")
        cBodega.Items.Clear()
        cBodega.Items.Add("")
        If Bod.RecordCount > 0 Then
            While Not Bod.EOF
                cBodega.Items.Add(Bod.Fields("NombreBodega").Text.Trim)
                'If Bod("Bodega").Value = BodegaActual Then
                '    cBodega.Text = Bod.Fields("NombreBodega").Text.Trim
                'End If
                Bod.MoveNext()
            End While
        End If
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(xDescripcion)
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As CancelEventArgs) Handles xArticulo.Validating
        If xArticulo.Text <> "" Then
            Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & xArticulo.Text & "'")
            If Art.RecordCount > 0 Then
                xDescripcion.Text = Art.Fields("Descripcion").Text.Trim
                bConsultar.Focus()
            Else
                MsgError("Artículo no encontrado")
                xArticulo.Clear()
                xArticulo.Focus()
            End If
        End If
    End Sub

    Sub Titulos()

        xTabla.Redraw = False

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 4

        xTabla.Cols(T_LOCAL).Width = 180
        xTabla.Cols(T_CODIGO).Width = 60
        xTabla.Cols(T_BODEGA).Width = 200
        xTabla.Cols(T_STOCK).Width = 80

        xTabla.Cols(T_LOCAL).Caption = "Local"
        xTabla.Cols(T_CODIGO).Caption = "Código"
        xTabla.Cols(T_BODEGA).Caption = "Bodega"
        xTabla.Cols(T_STOCK).Caption = "Stock"

        xTabla.Redraw = True
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        Dim wfila = 1, Filtro As String = ""
        If xArticulo.Text.Trim = "" Then
            MsgError("No ha ingresado artículo a consultar")
            xArticulo.Focus()
            Exit Sub
        End If
        If Not Supervisor Then
            MsgError("No tiene permisos de Superviros para visualizar el stock")
            Exit Sub
        End If

        If cBodega.Text.Trim = "" Then
            Filtro = "(1=1)"
        Else
            Filtro = "Bodega = " + Num(BuscarCampo("Bodegas", "Bodega", "NombreBodega", cBodega.Text.Trim))
        End If

        Titulos()
        Bod = SQL("SELECT * FROM Bodegas WHERE Bodega > 0 and " + Filtro + " Order by Bodega")
        If Bod.RecordCount > 0 Then
            While Not Bod.EOF
                Stk = SQL("SELECT * FROM Stocks WHERE Articulo ='" & xArticulo.Text.Trim & "' AND Bodega= " & Bod.Fields("Bodega").Text.Trim & " and Local = " & Bod.Fields("Local").Text.Trim & "")
                If Stk.RecordCount = 0 Then
                    Stk.AddNew()
                    Stk.Fields("Articulo").Value = xArticulo.Text.Trim
                    Stk.Fields("Bodega").Value = Bod.Fields("Bodega").Text.Trim
                    Stk.Fields("Local").Value = Bod.Fields("Local").Text.Trim
                    Stk.Fields("stockmin").Value = 0
                    Stk.Fields("StockMax").Value = 100
                    Stk.Fields("Stock").Value = 0
                    Stk.Update()
                End If

                xTabla.AddItem("")
                xTabla.SetData(wfila, T_LOCAL, BuscarCampo("Locales", "NombreLocal", "Local", Stk.Fields("Local").Text))
                xTabla.SetData(wfila, T_CODIGO, Stk.Fields("Bodega").Text)
                xTabla.SetData(wfila, T_BODEGA, BuscarCampo("Bodegas", "NombreBodega", "Bodega", Stk.Fields("Bodega").Text))
                xTabla.SetData(wfila, T_STOCK, Stk.Fields("Stock").Text)

                wfila += 1
                Bod.MoveNext()
            End While
        End If
        xTabla.Focus()
    End Sub

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click
        If xTabla.Col = T_STOCK Then
            xTabla.StartEditing(xTabla.Row, T_STOCK)
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
        xArticulo.Focus()
    End Sub

    Sub Limpiar()
        xArticulo.Clear()
        xDescripcion.Clear()
        Titulos()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bActualizar_Click(sender As Object, e As EventArgs) Handles bActualizar.Click
        If Not Supervisor Then
            MsgError("Usuario sin autizacion a modificar stocks")
            Exit Sub
        End If

        If xTabla.Rows.Count - 1 > 0 Then
            If Pregunta("¿Desea modificar el stocks?") Then
                For wFila = 1 To xTabla.Rows.Count - 1
                    Dim wLocal = BuscarCampo("Locales", "Local", "NombreLocal", xTabla.GetData(wFila, T_LOCAL))
                    Dim wBodega = BuscarCampo("Bodegas", "Bodega", "NombreBodega", xTabla.GetData(wFila, T_BODEGA))

                    If xTabla.GetData(wFila, T_STOCK) = "" Then
                        xTabla.SetData(wFila, T_STOCK, 0)
                    End If

                    Stk = SQL("SELECT * FROM Stocks WHERE Articulo = '" & xArticulo.Text.Trim & "' AND Local ='" & wLocal & "' AND Bodega = '" & wBodega & "'")

                    If Stk.RecordCount > 0 Then
                        Stk.Fields("Stock").Value = xTabla.GetData(wFila, T_STOCK)
                        Stk.Update()
                    End If
                Next
                MsgBox("Stocks modificado correctamente")
                Auditoria(Me.Text, PR_MODIFICAR, "", 0)
                Titulos()
                Limpiar()
                xArticulo.Focus()
            End If
        End If
    End Sub
End Class