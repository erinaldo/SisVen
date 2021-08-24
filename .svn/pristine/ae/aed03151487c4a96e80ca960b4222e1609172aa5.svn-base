Imports System.ComponentModel

Public Class ListadoMovimientos
    Implements iFormulario
    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        e.NextControl(xLocal)
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text.Trim <> "" Then
            Cli = SQL("SELECT Nombre From Clientes WHERE Cliente = '" & xCliente.Text.Trim & "'")
            If Cli.RecordCount > 0 Then
                xNombreCliente.Text = Cli.Fields("Nombre").Text
            Else
                MsgError("Cliente no encontrado")
                xCliente.Clear()
                xCliente.Focus()
            End If
        Else
            xNombreCliente.Clear()
        End If
    End Sub

    Private Sub bBuscarC_Click(sender As Object, e As EventArgs) Handles bBuscarC.Click
        Dim wQuery = "SELECT Cliente, Nombre, Rut FROM CLientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Nombre", Me, "Clientes", xCliente)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        e.NextControl(xBodega)
    End Sub

    Private Sub xLocal_Validating(sender As Object, e As CancelEventArgs) Handles xLocal.Validating
        If xLocal.Text.Trim <> "" Then
            cLocal.SelectedValue = xLocal.Text.Trim
            If cLocal.Text = W_SELECCIONAR Then
                MsgError("Local no encontrado")
                xLocal.Clear()
                xLocal.Focus()
            End If
            xBodega.Focus()
        End If
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If ValidarCombo(cLocal) Then
            xLocal.Text = cLocal.SelectedValue
            xBodega.Focus()
        Else
            xLocal.Clear()
        End If
    End Sub

    Private Sub xBodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xBodega.KeyPress
        e.NextControl(cTipoMov)
    End Sub

    Private Sub xBodega_Validating(sender As Object, e As CancelEventArgs) Handles xBodega.Validating
        If xBodega.Text.Trim <> "" Then
            cBodega.SelectedValue = xBodega.Text.Trim
            If cBodega.Text = W_SELECCIONAR Then
                MsgError("Local no encontrado")
                xBodega.Clear()
                xBodega.Focus()
            End If
            cTipoMov.Focus()
        End If
    End Sub

    Private Sub cBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBodega.SelectedIndexChanged
        If ValidarCombo(cBodega) Then
            xBodega.Text = cBodega.SelectedValue
            cTipoMov.Focus()
        Else
            xBodega.Clear()
        End If
    End Sub

    Private Sub cTipoMov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoMov.SelectedIndexChanged
        If ValidarCombo(cTipoMov) Then
            cTipoDoc.Focus()
        End If
    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        If ValidarCombo(cTipoDoc) Then
            dDesde.Focus()
        End If
    End Sub

    Private Sub xUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xUsuario.KeyPress
        e.NextControl(xResponsable)
    End Sub

    Private Sub xUsuario_Validating(sender As Object, e As CancelEventArgs) Handles xUsuario.Validating
        If xUsuario.Text.Trim <> "" Then
            Usr = SQL("SELECT  NombreUsr FROM Usuarios WHERE Usuario = '" & xUsuario.Text.Trim & "'")
            If Usr.RecordCount > 0 Then
                xNombreUsuario.Text = Usr.Fields("NombreUsr").Text.Trim
            Else
                MsgError("Usuario no encontrado")
                xUsuario.Clear()
                xNombreUsuario.Clear()
                xUsuario.Focus()
            End If
        End If
    End Sub

    Private Sub bBuscarU_Click(sender As Object, e As EventArgs) Handles bBuscarU.Click
        Dim wQuery = "SELECT Usuario, Nombreusr as Nombre FROM Usuarios"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreUsr", Me, "Usuario", xUsuario)
    End Sub

    Private Sub xResponsable_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xResponsable.KeyPress
        e.NextControl(bImprimir)
    End Sub

    Private Sub xResponsable_Validating(sender As Object, e As CancelEventArgs) Handles xResponsable.Validating
        If xResponsable.Text.Trim <> "" Then
            Usr = SQL("SELECT NombreUsr FROM Usuarios WHERE Usuario = '" & xResponsable.Text.Trim & "'")
            If Usr.RecordCount > 0 Then
                xNombreResponsable.Text = Usr.Fields("NombreUsr").Text.Trim
            Else
                MsgError("Usuario responsable no encontrado")
                xResponsable.Clear()
                xNombreResponsable.Clear()
                xResponsable.Focus()
            End If
        End If
    End Sub
    Private Sub bBuscarR_Click(sender As Object, e As EventArgs) Handles bBuscarR.Click
        Dim wQuery = "SELECT Usuario, Nombreusr as Nombre FROM Usuarios"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreUsr", Me, "Usuario", xResponsable)
    End Sub
    Private Sub ListadoMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
        LoadCombobox(cBodega, "Bodegas", "Bodega", "NombreBodega")
        LoadCombobox(cTipoDoc, "TipoDoc", "TipoDoc", "DescTipoDoc")
        LoadCombobox(cTipoMov, "TipoMov", "TipoMov", "DescTipo")
        LoadCombobox(cEstado, "Estados", "Estado", "DescEstado", " WHERE Tipo = 'V'")

        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        Auditoria(Me.Text, PR_INGRESAR, "", 0)

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""
        Dim wQuery = "SELECT MG.Movimiento,MG.Fecha,TM.DescTipo,TD.DescTipoDoc ,L.NombreLocal,B.NombreBodega,U.NombreUsr as UsrCreador,UR.NombreUsr as UsrResponsable," &
                     " E.DescEstado,MG.NumDoc,C.Nombre,MG.ObsTra,MG.Total" &
                     " FROM MovGen MG" &
                     " JOIN TipoMov TM ON MG.TipoMov = TM.TipoMov" &
                     " JOIN TipoDoc TD ON MG.TipoDoc = TD.TipoDoc" &
                     " JOIN Locales L On MG.Local = L.Local" &
                     " JOIN Bodegas B ON MG.Bodega = B.Bodega" &
                     " JOIN Usuarios U ON MG.Usuario = U.Usuario" &
                     " JOIN Usuarios UR ON MG.Responsable = UR.Usuario" &
                     " JOIN Estados E ON MG.Estado = E.Estado And E.Tipo = 'V'" &
                     " JOIN Clientes C ON MG.Cliente = C.Cliente" &
                     " WHERE Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "'"

        If xCliente.Text.Trim <> "" Then wFiltros += " AND C.Cliente = '" & xCliente.Text.Trim & "'"

        If xLocal.Text.Trim <> "" Then wFiltros += " AND L.Local = '" & xLocal.Text.Trim & "'"

        If xBodega.Text.Trim <> "" Then wFiltros += "AND B.Bodega = '" & xBodega.Text.Trim & "'"

        If ValidarCombo(cTipoMov) Then wFiltros += " AND TM.TipoMov = '" & cTipoMov.SelectedValue & "'"

        If ValidarCombo(cTipoDoc) Then wFiltros += " AND TD.TipoDoc = '" & cTipoDoc.SelectedValue & "'"

        If xUsuario.Text.Trim <> "" Then wFiltros += " AND U.Usuario = '" & xUsuario.Text.Trim & "'"

        If xResponsable.Text.Trim <> "" Then wFiltros += " AND UR.Usuario = '" & xResponsable.Text.Trim & "'"

        If ValidarCombo(cEstado) Then wFiltros += " AND E.Estado = '" & cEstado.SelectedValue & "'"

        Dim wReporte As New ReporteMovimientos

        wQuery = wQuery & wFiltros
        ModuloReporte = "ListadoMovimientos"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Movimientos"
        Try
            VisorReportes.Show()
            Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class