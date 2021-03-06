Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class ListadoArticulos
    Implements iFormulario

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub oSoloPalets_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub ListadoArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cEstado, "Estados", "Estado", "DescEstado", " WHERE TIPO = 'A'")
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
        Dim wQuery = "SELECT A.Articulo, A.Descripcion, U.DescUnidad,DescFamilia,DescSubFamilia,E.DescEstado FROM ARTICULOS A" &
                     " JOIN Unidades U ON A.Unidad = U.Unidad" &
                     " JOIN Familias F On A.Familia = F.Familia" &
                     " JOIN SubFamilias SF ON A.SubFamilia = SF.Subfamilia" &
                     " JOIN Estados E ON A.Estado = E.Estado AND E.Tipo  = 'A'"

        If ValidarCombo(cEstado) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Estado = '" & cEstado.SelectedValue & "'"
        If ValidarCombo(cUnidad) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Unidad = '" & cUnidad.SelectedValue & "'"
        If ValidarCombo(CFamilia) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Familia = '" & CFamilia.SelectedValue & "'"
        If ValidarCombo(cSubFamilia) AndAlso cSubFamilia.SelectedIndex > -1 Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.SubFamilia = '" & cSubFamilia.SelectedValue & "'"
        If xClave.Text <> "" Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "A.Descripcion Like '%" & xClave.Text.Trim & "%'"

        Dim wReporte As New ReporteArticulos
        wQuery = wQuery & wFiltros
        ModuloReporte = "ListadoArticulos"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Articulos"
        Try
            VisorReportes.Show()
        Catch ex As Exception

        End Try

    End Sub
End Class