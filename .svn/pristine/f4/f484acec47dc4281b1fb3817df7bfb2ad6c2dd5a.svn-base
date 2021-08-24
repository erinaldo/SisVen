Imports System.ComponentModel
Imports SisVen

Public Class ListadoStock
    Implements iFormulario
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub rAsc_CheckedChanged(sender As Object, e As EventArgs) Handles rAsc.CheckedChanged, rDes.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
    End Sub

    Private Sub oMenorA_CheckedChanged(sender As Object, e As EventArgs)
        Dim wCheckBox As CheckBox = DirectCast(sender, CheckBox)
        wCheckBox.ForeColor = If(wCheckBox.Checked, Color.White, Color.Black)
    End Sub

    Private Sub ListadoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal", " ORDER BY NombreLocal")
        LoadCombobox(cBodega, "Bodegas", "Bodega", "NombreBodega", " ORDER BY NombreBodega")
        cOrdenar.SelectedIndex = 0
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(cLocal)
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As CancelEventArgs) Handles xArticulo.Validating
        If xArticulo.Text.Trim <> "" Then
            Art = SQL("SELECT DESCRIPCION FROM Articulos WHERE Articulo = '" & xArticulo.Text.Trim & "'")
            If Art.RecordCount > 0 Then
                xDescripcion.Text = Art.Fields("Descripcion").Text
                cLocal.Focus()
            Else
                MsgError("Artículo no encontrado")
                xArticulo.Clear()
                xDescripcion.Clear()
                xArticulo.Focus()
            End If
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub
    Sub Limpiar()
        LimpiarCampos(Me)
        rAsc.Checked = True
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
        xArticulo.Focus()
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            cBodega.Focus()
        End If
    End Sub

    Private Sub cBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBodega.SelectedIndexChanged
        If ValidarCombo(cBodega) Then
            cOrdenar.Focus()
        End If
    End Sub

    Private Sub cOrdenar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cOrdenar.SelectedIndexChanged
        If ValidarCombo(cOrdenar) Then

        End If
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltro = ""
        Dim wQuery = ""

        If xArticulo.Text.Trim <> "" Then
            wFiltro += If(wFiltro = "", " WHERE ", " AND ") & "A.Articulo = '" & xArticulo.Text.Trim & "'"
        End If

        If ValidarCombo(cLocal) Then
            wFiltro += If(wFiltro = "", " WHERE ", " AND ") & "S.Local = '" & cLocal.SelectedValue & "'"
        End If
        If ValidarCombo(cBodega) Then
            wFiltro += If(wFiltro = "", " WHERE ", " AND ") & "S.Bodega = '" & cBodega.SelectedValue & "'"
        End If

        If rAsc.Checked Then
            If cOrdenar.Text <> W_SELECCIONAR Then
                If cOrdenar.Text = "Artículo" Then wFiltro += " ORDER BY A.Articulo ASC"
                If cOrdenar.Text = "Descripción" Then wFiltro += " ORDER BY A.Descripcion ASC"
            End If
        Else
            If cOrdenar.Text <> W_SELECCIONAR Then
                If cOrdenar.Text = "Artículo" Then wFiltro += " ORDER BY A.Articulo DESC"
                If cOrdenar.Text = "Descripción" Then wFiltro += " ORDER BY A.Descripcion DESC"
            End If
        End If

        wQuery = "SELECT A.Articulo, A.Descripcion,S.Stock, L.Local,L.NombreLocal, B.Bodega,B.NombreBodega From Articulos A" &
                 " JOIN Stocks S ON A.Articulo = S.Articulo" &
                 " JOIN Locales L On S.Local = L.Local" &
                 " JOIN Bodegas B ON S.Bodega = B.Bodega " & wFiltro

        Dim wReporte As New ReporteStocks

        wQuery = wQuery
        ModuloReporte = "ListadoStock"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Stock"
        Try
            VisorReportes.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class