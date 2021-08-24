Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class ListadoPrecios
    Implements iFormulario

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub ListadoArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(CFamilia, "Familias", "Familia", "DescFamilia")
        LoadCombobox(cUnidad, "Unidades", "Unidad", "DescUnidad")
    End Sub

    Private Sub CFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CFamilia.SelectedIndexChanged
        If ValidarCombo(CFamilia) Then
            LoadCombobox(cSubFamilia, "SubFamilias", "SubFamilia", "DescSubFamilia", " WHERE Familia = " & CFamilia.SelectedValue)
        End If
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""
        Dim wQuery = "SELECT A.Articulo, A.Descripcion, A.Costo, A.PVenta FROM ARTICULOS A" &
                     " JOIN Unidades U ON A.Unidad = U.Unidad" &
                     " JOIN Familias F On A.Familia = F.Familia" &
                     " JOIN SubFamilias SF ON A.SubFamilia = SF.Subfamilia"

        If ValidarCombo(cUnidad) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Unidad = '" & cUnidad.SelectedValue & "'"
        If ValidarCombo(CFamilia) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Familia = '" & CFamilia.SelectedValue & "'"
        If ValidarCombo(cSubFamilia) AndAlso cSubFamilia.SelectedIndex > -1 Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.SubFamilia = '" & cSubFamilia.SelectedValue & "'"
        If xClave.Text <> "" Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Descripcion Like '%" & xClave.Text.Trim & "%'"

        Dim wReporte As New ReportePrecios
        wQuery += wFiltros
        ModuloReporte = "ListadoPrecios"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Articulos"
        VisorReportes.Show()
    End Sub
End Class