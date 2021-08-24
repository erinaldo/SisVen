Public Class ListadoCiudades
    Const T_CIIUDAD = 0
    Const T_NOMBRECIUDAD = 1
    Const T_CODIGOAREA = 2
    Private Sub ListadoCiudades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cRegion.LoadCombobox("Regiones", "Region", "NombreRegion", " ORDER BY Region")
    End Sub

    Private Sub cRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cRegion.SelectedIndexChanged
        If ValidarCombo(cRegion) Then
            Ciu = SQL("SELECT * FROM CIUDADES WHERE REGION = '" & cRegion.SelectedValue & "'")
            Titulos()

            While Not Ciu.EOF
                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_CIIUDAD, Ciu.Fields("Ciudad").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_NOMBRECIUDAD, Ciu.Fields("NombreCiudad").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_CODIGOAREA, Ciu.Fields("CodigoArea").Text)
                Ciu.MoveNext()
            End While
        End If
    End Sub
    Sub Titulos()

        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 3

        xTabla.Cols(T_CIIUDAD).Width = 50
        xTabla.Cols(T_NOMBRECIUDAD).Width = 200
        xTabla.Cols(T_CODIGOAREA).Width = 100

        xTabla.Cols(T_CIIUDAD).Caption = "Ciudad"
        xTabla.Cols(T_NOMBRECIUDAD).Caption = "Nombre"
        xTabla.Cols(T_CODIGOAREA).Caption = "Código Área"
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltro = ""
        If ValidarCombo(cRegion) Then
            wFiltro = " WHERE C.Region = '" & cRegion.SelectedValue & "'"
        End If

        Dim wQuery = "SELECT C.*, R.NombreRegion FROM Ciudades C JOIN Regiones R ON C.Region = R.Region"
        Dim wReporte As New ReporteCiudades
        wQuery = wQuery & wFiltro
        ModuloReporte = "ReporteCiudades"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Reporte de Ciudades"
        VisorReportes.Show()

    End Sub
End Class