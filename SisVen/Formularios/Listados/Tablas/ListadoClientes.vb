Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class ListadoClientes
    Implements iFormulario
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub ListadoArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cEstado, "Estados", "Estado", "DescEstado", " WHERE Tipo = 'C'")
        LoadCombobox(cComuna, "Comunas", "Comuna", "NombreComuna", " WHERE Comuna IN(SELECT Comuna From Clientes) Order by NombreComuna ")
    End Sub

    Private Sub oProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles oProveedor.CheckedChanged, oComision.CheckedChanged
        Dim wCheckBox As CheckBox = DirectCast(sender, CheckBox)
        wCheckBox.ForeColor = If(wCheckBox.Checked, Color.White, Color.Black)
    End Sub

    Private Sub xCuponMax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCuponMax.KeyPress
        ValidarDigitos(e)
    End Sub
    Private Sub xVencimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVencimiento.KeyPress
        ValidarDigitos(e)
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub
    Sub Limpiar()
        For Each wControl In gContenedor.Controls
            If TypeOf wControl Is TextBox Then
                wControl.Clear
            ElseIf TypeOf wControl Is ComboBox Then
                wControl.SelectedIndex = 0
            ElseIf TypeOf wControl Is CheckBox Then
                wControl.Checked = False
            End If
        Next
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""
        Dim wReporte As New ReporteClientes
        Dim wQuery = "SELECT Cl.CLiente,Cl.Nombre,Cl.Rut,Cl.Direccion, Ci.NombreCiudad,Co.NombreComuna,Es.DescEstado,Cl.CupoMax," &
                     " Cl.Proveedor,Cl.Vencimiento,Cl.Comision  " &
                     " FROM Clientes CL" &
                     " JOIN Ciudades Ci ON Cl.Ciudad = Ci.Ciudad" &
                     " JOIN COmunas Co ON Cl.Comuna = Co.Comuna" &
                     " JOIN Estados Es ON Cl.Estado = Es.Estado AND Es.Tipo = 'C'"

        If ValidarCombo(cEstado) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.Estado = '" & cEstado.SelectedValue & "'"
        If ValidarCombo(cComuna) Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.Comuna = '" & cComuna.SelectedValue & "'"
        If xCuponMax.Text <> "" Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.CupoMax = '" & xCuponMax.Text.Trim & "'"
        If xVencimiento.Text <> "" Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.Vencimiento = '" & xVencimiento.Text.Trim & "'"
        If xClave.Text <> "" Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.Nombre Like '%" & xClave.Text.Trim & "%'"
        If oProveedor.Checked Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.Proveedor = 1"
        If oComision.Checked Then wFiltros &= If(wFiltros = "", " WHERE ", " AND ") & "Cl.Comision = 1"

        wQuery = wQuery & wFiltros
        ModuloReporte = "ListadoClientes"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Reporte de Pagos"
        Try
            VisorReportes.Show()
        Catch ex As Exception

        End Try

    End Sub
End Class