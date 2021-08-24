Imports System.Drawing.Drawing2D
Imports System.Globalization

Public Class CalendarioAtencion
    Const T_HORA As Integer = 0
    Const T_LUNES As Integer = 1
    Const T_MARTES As Integer = 2
    Const T_MIERCOLES As Integer = 3
    Const T_JUEVES As Integer = 4
    Const T_VIERNES As Integer = 5
    Const T_SABADO As Integer = 6
    Const T_DOMINGO As Integer = 7
    Public C_RESERVADO = Color.FromArgb(82, 255, 181)
    Dim wMesCalendario As Integer = My.Settings.P_MES_CALENDARIO
    Dim wHoraEntrada As String = My.Settings.P_HORA_ENTRADA
    Dim wHoraSalida As String = My.Settings.P_HORA_SALIDA
    Dim wIntervalo As Integer = My.Settings.P_INTERVALO_HORA
    Dim wDiasHabiles() As String = My.Settings.P_DIAS_HABILES.Split(",")
    Dim wFechasReservas() As String
    Sub Titulos()
        Dim wAnchoTabla As Integer = xTabla.Width
        xTabla.Clear()

        xTabla.Rows.Count = 1
        xTabla.Cols.Count = wDiasHabiles.Count + 1 '+1 es por la Hora
        xTabla.Cols(T_HORA).Width = 40
        xTabla.Cols(T_HORA).Caption = "Hora"
        xTabla.FuenteCelda(0, T_HORA, C_GRISAZUL, C_TITULO, True)
        xTabla.Cols(T_HORA).AllowSorting = False
        Dim wPrimerDia() As String = cSemana.Text.Trim.Split("-")
        Dim wFechaDia As Date = wPrimerDia(0)
        For i = 0 To wDiasHabiles.Count - 1
            xTabla.Cols(i + 1).Caption = DiaSemana(wDiasHabiles(i), wFechaDia)
            xTabla.Rows(0).Height = 30
            xTabla.FuenteCelda(0, i + 1, C_GRISAZUL, C_TITULO, True)
            xTabla.Cols(i + 1).AllowSorting = False
        Next
        LlenarHoras()
        RedimenzionarTabla(xTabla, wDiasHabiles)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub CalendarioAtencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarSemanas()
        wFechasReservas = cSemana.Text.Split("-")
        If wFechasReservas.Count = 2 Then
            LlenarAtencion(wFechasReservas(0).Trim, wFechasReservas(1).Trim)
        End If
    End Sub

    Sub LlenarAtencion(ByVal wFechaIni As String, ByVal wFechaFin As String)
        wFechaIni += " 00:00:00"
        wFechaFin += " 23:59:59"
        'MsgError(wFechaIni & " " & wHoraEntrada & vbCrLf & wFechaFin & " " & wHoraSalida)
        Titulos()
        ATC = SQL("SELECT Atencion,CONVERT(varchar,FechaIni,103) as FechaINI,CONVERT(varchar(5),FechaIni,108) as HoraINI," &
                  " CONVERT(varchar,FechaFin,103) as FechaFIN,CONVERT(varchar(5),FechaFin,108) as HoraFIN," &
                  " a.Estado,Paciente,Medico,c.Nombre," &
                  " Financiador,Confirmado,Usuario,ValorTotal,Local,Lugar,ResultadoEntregado,Pagado " &
                  " FROM AtencionGen A INNER JOIN Clientes C on A.Paciente=c.Cliente And c.Tipo='P' " &
                  " WHERE FechaIni>='" & wFechaIni & "' and FechaFin<='" & wFechaFin & "'" &
                  " ORDER By FechaIni ")

        If ATC.EOF Then
            Exit Sub
        End If
        Dim wFechaEncontrada As Boolean = True
        Dim wFechaColumna() As String
        Dim wFechaInicial As String = ""
        Dim wHoraInicial As String = ""
        Dim wHoraFinal As String = ""
        Dim wPintaFondo As Boolean = False
        Dim wNombrePaciente As String = ""
        While Not ATC.EOF
            For i = 1 To xTabla.Cols.Count - 1
                If wFechaEncontrada Then
                    wFechaInicial = ATC.Fields("FechaIni").Text
                    wHoraInicial = ATC.Fields("HoraINI").Text
                    wHoraFinal = ATC.Fields("HoraFin").Text
                    wNombrePaciente = ATC.Fields("Atencion").Text & " - " & ATC.Fields("Nombre").Text
                End If
                wFechaColumna = xTabla.GetData(0, i).ToString.Split(vbCrLf)
                If wFechaColumna(0) = wFechaInicial Then
                    For gHora = 1 To xTabla.Rows.Count - 1
                        If wHoraInicial = xTabla.GetData(gHora, T_HORA) Then
                            wPintaFondo = True
                            xTabla.FondoCelda(gHora, i, C_RESERVADO)
                            xTabla.SetData(gHora, i, wNombrePaciente)
                        ElseIf wHoraFinal = xTabla.GetData(gHora, T_HORA) Then
                            wPintaFondo = False
                            xTabla.FondoCelda(gHora, i, C_RESERVADO)
                        ElseIf wPintaFondo Then
                            xTabla.FondoCelda(gHora, i, C_RESERVADO)
                        End If
                    Next
                    wFechaEncontrada = True
                Else
                    wFechaEncontrada = False
                    'Continue For
                End If
            Next
            ATC.MoveNext()
            wFechaEncontrada = True
        End While
    End Sub
    Sub LlenarHoras()
        Dim wHora As Date = wHoraEntrada
        Dim wFila As Integer = 1
        While wHora <= wHoraSalida
            xTabla.AddItem("")
            xTabla.SetData(wFila, T_HORA, wHora.ToShortTimeString.PadLeft(5, "0"))
            wHora = wHora.AddMinutes(wIntervalo)
            wFila += 1
        End While
    End Sub
    Sub LlenarSemanas()
        cSemana.Items.Clear()
        Dim wFinLlenado As Boolean = False
        Dim wFechaAnterior As DateTime = ObtenerMes("-" & wMesCalendario)
        Dim wFechaSiguiente As DateTime = ObtenerMes(wMesCalendario)
        Dim wDiaLunes As DateTime = ObtenerPrimerDiaSemana(wFechaAnterior)
        Dim wDiaDomingo As DateTime = ObtenerDia(6, wDiaLunes)
        Dim wFechaActual As DateTime = DateTime.Today
        Dim wLunes As DateTime
        cSemana.Items.Add(wDiaLunes & " - " & wDiaDomingo)
        Dim wUltimaFecha As DateTime = wDiaDomingo
        Dim wSemanaActual As Integer = -1

        While wLunes <= wFechaSiguiente
            wLunes = ObtenerDia(1, wUltimaFecha)
            Dim wDomingo As DateTime = ObtenerDia(6, wLunes)
            wUltimaFecha = wDomingo
            cSemana.Items.Add(wLunes & " - " & wDomingo)
            If wUltimaFecha <= wFechaActual Then
                wSemanaActual = cSemana.Items.Count
            End If
        End While
        cSemana.SelectedIndex = wSemanaActual

    End Sub
    Private Sub bAtras_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles batras.Paint
        BotonRedondo(batras, e)
    End Sub

    Private Sub bAdelante_Paint(sender As Object, e As PaintEventArgs) Handles bAdelante.Paint
        BotonRedondo(bAdelante, e)
    End Sub

    Private Sub xTabla_SizeChanged(sender As Object, e As EventArgs) Handles xTabla.SizeChanged
        RedimenzionarTabla(xTabla, wDiasHabiles)
    End Sub

    Private Sub bIngresarAtencion_Click(sender As Object, e As EventArgs) Handles bIngresarAtencion.Click
        Dim wFormulario As New Ingreso_Atencion 'Atencion_Paciente
        'Ingreso_Atencion
        wFormulario.Show()
        wFormulario.BringToFront()
    End Sub

    Private Sub cSemana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cSemana.SelectedIndexChanged
        If cSemana.Text = "" Then
            Exit Sub
        End If
        Titulos()
        wFechasReservas = cSemana.Text.Split("-")
        If wFechasReservas.Count = 2 Then
            LlenarAtencion(wFechasReservas(0).Trim, wFechasReservas(1).Trim)
        End If
    End Sub
    Dim wTag As String
    Private Sub xTabla_MouseMove(sender As Object, e As MouseEventArgs) Handles xTabla.MouseMove
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        Dim wValorCelda As String = xTabla.GetData(sender.MouseRow, sender.MouseCol)
        If wValorCelda = "" Then
            xInfo.Active = False
            wTag = ""
            Exit Sub
        End If
        Dim wAtencion() As String = wValorCelda.Trim.Split("-")
        If wAtencion.Length < 2 Then
            Exit Sub
        End If

        If wTag = wAtencion(0) Then
            Exit Sub
        End If
        xInfo.Active = True
        ATC = SQL("SELECT c.Nombre,ar.Descripcion,CONVERT(varchar(5),FechaIni,108) as HoraINI," &
                  " CONVERT(varchar(5),FechaFin,108) as HoraFin " &
                  " FROM AtencionGen A INNER JOIN Clientes C on A.Medico=c.Cliente " &
                  " INNER JOIN AtencionDet d on a.Atencion=d.Atencion " &
                  " INNER JOIN Articulos ar on d.Articulo=ar.Articulo " &
                  " WHERE a.Atencion=" & wAtencion(0))

        Dim wMensaje As String = ""
        wMensaje = " Médico " & ATC.Fields("Nombre").Text & vbCrLf
        wMensaje += " Exámen " & ATC.Fields("Descripcion").Text & vbCrLf
        wMensaje += " Hora inicio exámen " & ATC.Fields("HoraIni").Text & vbCrLf
        wMensaje += " Hora termino exámen " & ATC.Fields("HoraFin").Text

        xInfo.ToolTipTitle = wAtencion(1)
        xInfo.UseAnimation = True
        xInfo.SetToolTip(xTabla, wMensaje)

        wTag = wAtencion(0)
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        Dim wColor = sender.GetCellStyle(sender.RowSel, sender.ColSel)
        Dim wHoraAtencion = sender.GetData(sender.RowSel, T_HORA)
        Dim wFechaAtencion() As String = sender.GetData(0, sender.ColSel).Split(vbCrLf)
        Dim wFila As Integer
        Dim wNumeroAtencion() As String = Nothing
        If IsNothing(wColor) Then
            Exit Sub
        End If
        If wColor.BackColor = C_RESERVADO Then
            Label1.Text = wHoraAtencion & "  " & wFechaAtencion(0)
            wFila = xTabla.RowSel
            While Not wFila = 0
                Dim wTexto As String = sender.GetData(wFila, sender.ColSel)
                If wTexto <> "" Then
                    wNumeroAtencion = sender.GetData(wFila, sender.ColSel).trim.Split("-")
                    wFila = 0
                    Exit While
                End If
                wFila -= 1
            End While
            If wNumeroAtencion.Length < 2 Then
                MsgError("Error al cargar la atención")
                Exit Sub
            End If
            Label1.Text = wNumeroAtencion(0)
        End If
    End Sub
End Class