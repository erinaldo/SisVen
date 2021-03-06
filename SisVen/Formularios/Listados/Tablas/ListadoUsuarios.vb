Public Class ListadoUsuarios
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click
        Dim ListParametros = New List(Of ParametrosReporte)
        Dim Lista = New List(Of UsuarioListado)
        Dim wFiltro = ""

        If ValidarCombo(cLocal) Then wFiltro += IIf(wFiltro = "", " WHERE ", " AND ") & " U.Local = " & cLocal.SelectedValue
        If ValidarCombo(cAcceso) Then wFiltro += IIf(wFiltro = "", " WHERE ", " AND ") & " A.Acceso = " & cAcceso.SelectedValue
        If ValidarCombo(cLocal) Then
            If ValidarCombo(cBodega) Then
                wFiltro += IIf(wFiltro = "", " WHERE ", " AND ") & " B.Bodega = " & cBodega.SelectedValue
            End If
        End If


        If oFuncionario.Checked Then wFiltro += IIf(wFiltro = "", " WHERE ", " AND ") & " U.Funcionario = 1"


        Swap = SQL("Select U.Usuario,U.NombreUsr,U.Rut,A.NombreAcceso,L.NombreLocal,B.NombreBodega" &
                   " FROM Usuarios U" &
                   " JOIN Locales L ON U.Local = L.Local" &
                   " JOIN Bodegas B ON U.Bodega = B.Bodega" &
                   " JOIN Accesos A ON U.Acceso = A.Acceso" & wFiltro)

        While Not Swap.EOF
            Lista.Add(New UsuarioListado With {.Usuario = Swap.Fields("Usuario").Text,
                                               .Nombre = Swap.Fields("NombreUsr").Text,
                                               .Rut = Swap.Fields("Rut").Text,
                                               .Local = Swap.Fields("NombreLocal").Text,
                                               .Bodega = Swap.Fields("NombreBodega").Text,
                                               .Acceso = Swap.Fields("NombreAcceso").Text})
            Swap.MoveNext()
        End While

        If Swap.RecordCount > 0 Then
            Dim gReporte = New ReporteUsuarios
            Par = SQL("SELECT * FROM Parametros")
            If Par.RecordCount = 1 Then ListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

            gReporte.Database.Tables("SisVen_ParametrosReporte").SetDataSource(ListParametros)
            gReporte.Database.Tables("SisVen_UsuarioListado").SetDataSource(Lista)
            Visor.ReportSource = gReporte
        End If
    End Sub

    Private Sub ListadoUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        cAcceso.LoadCombobox("Accesos", "Acceso", "NombreAcceso")
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            cBodega.LoadCombobox("Bodegas", "Bodega", "NombreBodega", " WHERE Local = " & cLocal.SelectedValue)
        End If
    End Sub
End Class