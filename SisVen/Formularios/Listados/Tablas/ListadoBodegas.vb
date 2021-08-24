Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class ListadoBodegas
    Implements iFormulario

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub ListadoArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""
        Dim wQuery = "SELECT B.Bodega,B.NombreBodega,L.Local,L.NombreLocal,C.Cliente,C.Nombre FROM Bodegas B" &
                     " JOIN Locales L ON B.Local = L.Local" &
                     " JOIN Clientes C ON L.Cliente = C.Cliente"

        If xLocal.Text <> "" Then wFiltros &= If(wFiltros = "", " WHERE ", " And ") & "L.LOCAL = '" & xLocal.Text.Trim & "'"

        Dim wReporte As New ReporteBodegas
        wQuery = wQuery & wFiltros
        ModuloReporte = "ListadoBodegas"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Bodegas"
        VisorReportes.Show()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        xLocal.Clear()
        cLocal.SelectedIndex = 0
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        ValidarDigitos(e)
        e.NextControl(cLocal)
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

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            xLocal.Text = cLocal.SelectedValue
        Else
            xLocal.Clear()
        End If
    End Sub

End Class