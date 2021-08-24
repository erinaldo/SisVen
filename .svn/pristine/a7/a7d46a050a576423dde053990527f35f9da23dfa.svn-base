Public Class Pruebas
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For Each wItem In Menu_Principal.Barra.Items.OfType(Of ToolStripMenuItem)

            Dim wName = wItem.Name
            Dim wTexto = wItem.Text

            Dim a = SQL("SELECT TOP 1 * FROM MODULOS")
            a.AddNew()
            a.Fields("Menu").Value = wName
            a.Fields("Texto").Value = wTexto
            a.Update()

            If wItem.HasDropDownItems Then

                For Each wItemSub In wItem.DropDownItems.OfType(Of ToolStripMenuItem)
                    wName = wItemSub.Name
                    wTexto = wItemSub.Text
                    Dim i = SQL("SELECT TOP 1 * FROM MODULOS")
                    i.AddNew()
                    i.Fields("Menu").Value = wName
                    i.Fields("Texto").Value = wTexto
                    i.Update()
                Next

            End If
        Next
    End Sub
End Class