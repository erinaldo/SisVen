Public Class ListadoEstados

    Private Sub ListadoEstados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cEstado.LoadCombobox("TipoEstados", "Tipo", "DescTipo", "ORDER BY DescTipo")
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click
        Dim wfiltro = ""
        Dim ListParametros = New List(Of ParametrosReporte)
        Dim Lista = New List(Of EstadosReporte)

        If ValidarCombo(cEstado) Then
            wfiltro = " WHERE E.Tipo = '" & cEstado.SelectedValue & "'"
        End If

        Est = SQL("Select E.*,T.DescTipo From Estados E JOIN TipoEstados T ON E.Tipo = T.Tipo " & wfiltro)

        While Not Est.EOF
            Lista.Add(New EstadosReporte With {.Descripcion = Est("DescEstado").Text,
                                                 .DescTipo = Est.Fields("DescTipo").Text,
                                                 .Estado = Est.Fields("Estado").Text,
                                                 .Tipo = Est.Fields("Tipo").Text})
            Est.MoveNext()
        End While

        If Est.RecordCount > 0 Then
            Dim gReporte = New ReporteEstados
            Par = SQL("SELECT * FROM Parametros")
            If Par.RecordCount = 1 Then ListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(ListParametros)
            gReporte.Database.Tables("SisVen_EstadosReporte").SetDataSource(Lista)
            Visor.ReportSource = gReporte
        End If
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class