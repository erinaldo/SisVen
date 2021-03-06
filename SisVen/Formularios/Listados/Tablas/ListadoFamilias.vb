Public Class ListadoFamilias
    Private Sub ListadoFamilias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click

        Dim ListParametros = New List(Of ParametrosReporte)
        Dim Lista = New List(Of FamiliaReporte)

        Est = SQL("Select * FROM Familias")

        While Not Est.EOF
            Lista.Add(New FamiliaReporte With {.Descripcion = Est("DescFamilia").Text,
                                                 .Familia = Est.Fields("Familia").Text})
            Est.MoveNext()
        End While

        If Est.RecordCount > 0 Then
            Dim gReporte = New ReporteFamilias
            Par = SQL("SELECT * FROM Parametros")
            If Par.RecordCount = 1 Then ListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(ListParametros)
            gReporte.Database.Tables("SisVen_FamiliaReporte").SetDataSource(Lista)
            Visor.ReportSource = gReporte
        End If
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class