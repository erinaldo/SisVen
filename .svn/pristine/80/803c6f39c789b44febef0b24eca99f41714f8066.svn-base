Public Class ConsultaAuditoria
    Implements iFormulario
    Const T_ID = 0
    Const T_LUGAR = 1
    Const T_FECHA = 2
    Const T_HORA = 3
    Const T_LOCAL = 4
    Const T_USUARIO = 5
    Const T_PROCESO = 6
    Const T_EVENTO = 7

    Private Sub ConsultaAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        cLocal.LoadCombobox("Locales", "Local", "NombreLocal")
        CargarCombos()
    End Sub
    Sub CargarCombos()
        cProceso.Items.Clear()
        cEvento.Items.Clear()

        Aud = SQL("SELECT DISTINCT Proceso FROM Auditoria WHERE Proceso <> '' ORDER BY Proceso")
        cProceso.Items.Add("")
        While Not Aud.EOF
            cProceso.Items.Add(Aud.Fields("Proceso").Text)
            Aud.MoveNext()
        End While

        Aud = SQL("SELECT DISTINCT Evento FROM Auditoria ORDER BY Evento")
        cEvento.Items.Add("")
        While Not Aud.EOF
            cEvento.Items.Add(Aud.Fields("Evento").Text)
            Aud.MoveNext()
        End While
    End Sub
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)
        Titulos()
    End Sub
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
    Private Sub bBuscarV_Click(sender As Object, e As EventArgs) Handles bBuscarV.Click
        Dim wQuery As String
        wQuery = "SELECT Usuario as 'Vendedor', NombreUsr as 'Nombre' From Usuarios"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombreUsr", Me, "Usuarios", xUsuario)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        Dim wFiltros = ""

        If ValidarCombo(cLocal) Then wFiltros += " AND Local = '" & cLocal.SelectedValue & "'"
        If xUsuario.Text.Trim <> "" Then wFiltros += " AND Usuario = '" & xUsuario.Text.Trim & "'"
        If cProceso.Text <> "" Then wFiltros += " AND Proceso = '" & cProceso.Text & "'"
        If cEvento.Text <> "" Then wFiltros += " AND Evento = '" & cEvento.Text & "'"



        Aud = SQL("SELECT * FROM Auditoria WHERE Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "' " & wFiltros)

        If Aud.RecordCount > 0 Then
            Titulos()
            While Not Aud.EOF
                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_ID, Aud.Fields("ID").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_LUGAR, Aud.Fields("Lugar").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_FECHA, FormatDateTime(Aud.Fields("Fecha").Text, 2))
                xTabla.SetData(xTabla.Rows.Count - 1, T_HORA, Aud.Fields("Hora").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_LOCAL, Aud.Fields("Local").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_USUARIO, Aud.Fields("Usuario").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_PROCESO, Aud.Fields("Proceso").Text)
                xTabla.SetData(xTabla.Rows.Count - 1, T_EVENTO, Aud.Fields("Evento").Text)
                Aud.MoveNext()
            End While
        Else
            MsgError("No se encuentran registros")
        End If


    End Sub
    Sub Titulos()

        xTabla.Redraw = False
        xTabla.Clear()
        xTabla.Cols.Count = 8
        xTabla.Rows.Count = 1

        xTabla.Cols(T_ID).Caption = "ID"
        xTabla.Cols(T_LUGAR).Caption = "Lugar"
        xTabla.Cols(T_FECHA).Caption = "Fecha"
        xTabla.Cols(T_HORA).Caption = "Hora"
        xTabla.Cols(T_LOCAL).Caption = "Local"
        xTabla.Cols(T_USUARIO).Caption = "Usuario"
        xTabla.Cols(T_PROCESO).Caption = "Proceso"
        xTabla.Cols(T_EVENTO).Caption = "Evento"

        xTabla.Cols(T_ID).Width = 50
        xTabla.Cols(T_LUGAR).Width = 70
        xTabla.Cols(T_FECHA).Width = 70
        xTabla.Cols(T_HORA).Width = 60
        xTabla.Cols(T_LOCAL).Width = 50
        xTabla.Cols(T_USUARIO).Width = 70
        xTabla.Cols(T_PROCESO).Width = 300
        xTabla.Cols(T_EVENTO).Width = 200
        xTabla.Redraw = True

    End Sub

    Private Sub xUsuario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xUsuario.Validating
        If xUsuario.Text.Trim = "" Then
            xNombre.Clear()
            Exit Sub
        End If

        Ven = SQL("SELECT NombreUsr FROM Usuarios WHERE Usuario = '" & xUsuario.Text.Trim & "'")
        If Ven.RecordCount > 0 Then
            xNombre.Text = Ven.Fields("NombreUsr").Text
        Else
            MsgError("Usuario no registrado")
            xUsuario.Clear()
            xNombre.Clear()
            xUsuario.Focus()
        End If
    End Sub

    Private Sub xUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xUsuario.KeyPress
        e.NextControl(cProceso)
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltros = ""

        If ValidarCombo(cLocal) Then wFiltros += " AND Local = '" & cLocal.SelectedValue & "'"
        If xUsuario.Text.Trim <> "" Then wFiltros += " AND Usuario = '" & xUsuario.Text.Trim & "'"
        If cProceso.Text <> "" Then wFiltros += " AND Proceso = '" & cProceso.Text & "'"
        If cEvento.Text <> "" Then wFiltros += " AND Evento = '" & cEvento.Text & "'"

        Dim wQuery = "SELECT * FROM Auditoria WHERE Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "' " & wFiltros

        Swap = SQL(wQuery)

        If Swap.RecordCount > 0 Then
            Dim wReporte As New ReporteAuditoria

            ModuloReporte = "Reporte_Auditoria"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Reporte de Auditoría"
            VisorReportes.Show()
        Else
            MsgError("No se encuentra registro")
            Exit Sub
        End If

        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
    End Sub
End Class