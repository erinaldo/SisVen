Public Class ImprimirEventosRem
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
        dDesde.Value = IniFinFecha(1, DateAdd(DateInterval.Month, -1, Now))
        dHasta.Value = IniFinFecha(2, DateAdd(DateInterval.Month, -1, Now))
    End Sub

    Private Sub ImprimirEventosRem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cFuncionario, "Usuarios", "Usuario", "Nombreusr", " WHERE Funcionario = 1 Order by NombreUsr")
        LoadCombobox(cEvento, "EventosRem", "EventoRem", "DescEventoRem", " ORDER BY CalculoRem,DescEventoRem")

        dDesde.Value = IniFinFecha(1, DateAdd(DateInterval.Month, -1, Now))
        dHasta.Value = IniFinFecha(2, DateAdd(DateInterval.Month, -1, Now))
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        If dDesde.Value > dHasta.Value Then
            MsgError("La fecha inicio no puede ser mayor a la final")
            Exit Sub
        End If
        If dHasta.Value < dDesde.Value Then
            MsgError("La fecha final no puede ser menor a la de inicio")
            Exit Sub
        End If
        'If Not ValidarCombo(cFuncionario) Then
        '    MsgError("Indique Funcionario")
        '    Exit Sub
        'End If


        Dim wfiltro = ""

        If ValidarCombo(cFuncionario) Then wfiltro = " AND Us.Usuario = '" & cFuncionario.SelectedValue & "'"
        If ValidarCombo(cEvento) Then wfiltro += " AND ER.EventoRem = '" & cEvento.SelectedValue & "'"

        Dim wQuery = "Select ER.CalculoRem,SD.ID,SD.Fecha,SD.Estado, Us.NombreUsr,ER.DescEventoRem,SD.UsuarioRem,SD.Monto,SD.Glosa" &
        " FROM EventosRem ER" &
        " Join Sueldos_Detalles SD ON ER.EventoRem = SD.EventoRem " &
        " Join Usuarios Us ON SD.Usuario = Us.Usuario" &
        " Join Usuarios Ur ON SD.UsuarioRem = Ur.Usuario" &
        " WHERE Fecha BETWEEN '" & dDesde.Value & "' AND '" & dHasta.Value & "' " & wfiltro

        Dim wreporte As New ReporteEventosRem
        ModuloReporte = "Listado_EventosRem"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado Eventos de Remuneración"
        VisorReportes.Show()

    End Sub
End Class