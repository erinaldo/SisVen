Public Class ListadoTomaInventario
    Private Sub ListadoTomaInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cFamilia, "Familias", "Familia", "DescFamilia", " ORDER BY DescFamilia")
        cOrdenar.SelectedIndex = 0
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub cFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cFamilia.SelectedIndexChanged
        If ValidarCombo(cFamilia) Then
            cOrdenar.focus
        End If
    End Sub

    Private Sub rAsc_CheckedChanged(sender As Object, e As EventArgs) Handles rAsc.CheckedChanged, rDes.CheckedChanged
        Dim wRadioButton As RadioButton = DirectCast(sender, RadioButton)
        wRadioButton.ForeColor = If(wRadioButton.Checked, Color.White, Color.Black)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
        rAsc.Checked = True
        cFamilia.Focus()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""
        Dim wQuery = ""
        If ValidarCombo(cFamilia) Then
            wFiltros = " WHERE A.Familia = '" & cFamilia.SelectedValue & "'"
        End If

        If ValidarCombo(cOrdenar) Then
            If rAsc.Checked Then
                If cOrdenar.Text = "Artículo" Then wFiltros += " ORDER BY A.Articulo ASC"
                If cOrdenar.Text = "Descripción" Then wFiltros += " ORDER BY A.Descripcion ASC"
                If cOrdenar.Text = "Barra" Then wFiltros += " ORDER BY B.Barra ASC"
            Else
                If cOrdenar.Text = "Artículo" Then wFiltros += " ORDER BY A.Articulo DESC"
                If cOrdenar.Text = "Descripción" Then wFiltros += " ORDER BY A.Descripcion DESC"
                If cOrdenar.Text = "Barra" Then wFiltros += " ORDER BY B.Barra DESC"
            End If
        End If

        wQuery = "SELECT A.Articulo, A.Descripcion FROM Articulos A " & wFiltros


        Dim wReporte As New ReporteTomaInventario

        wQuery = wQuery
        ModuloReporte = "ListadoTomaInventario"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado Toma de Inventario"
        VisorReportes.Show()
        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class