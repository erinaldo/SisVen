Public Class ListadoFPago
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click
        Dim ListParametros = New List(Of ParametrosReporte)
        Dim Lista = New List(Of FPagoListado)

        Est = SQL("Select * FROM FPagos")

        While Not Est.EOF
            Lista.Add(New FPagoListado With {.Descripcion = Est("DescFPago").Text,
                                                 .FPago = Est.Fields("FPago").Text})
            Est.MoveNext()
        End While

        If Est.RecordCount > 0 Then
            Dim gReporte = New ReporteFPago
            Par = SQL("SELECT * FROM Parametros")
            If Par.RecordCount = 1 Then ListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(ListParametros)
            gReporte.Database.Tables("SisVen_FPagoListado").SetDataSource(Lista)
            Visor.ReportSource = gReporte
        End If
    End Sub
End Class