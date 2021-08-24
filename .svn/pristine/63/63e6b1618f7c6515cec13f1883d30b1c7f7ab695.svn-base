Public Class ListadoTipoMov
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click
        Dim ListParametros = New List(Of ParametrosReporte)
        Dim Lista = New List(Of TipoMovListado)

        Swap = SQL("Select * FROM TipoMov")

        While Not Swap.EOF
            Lista.Add(New TipoMovListado With {.Descripcion = Swap("DescTipo").Text,
                                                 .TipoMov = Swap.Fields("TipoMov").Text,
                                                 .Ajuste = Swap.Fields("Ajuste").Text,
                                                 .Visible = Swap.Fields("Visible").Text})
            Swap.MoveNext()
        End While

        If Swap.RecordCount > 0 Then
            Dim gReporte = New ReporteTipoMov
            Par = SQL("SELECT * FROM Parametros")
            If Par.RecordCount = 1 Then ListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(ListParametros)
            gReporte.Database.Tables("SisVen_TipoMovListado").SetDataSource(Lista)
            Visor.ReportSource = gReporte
        End If
    End Sub
End Class