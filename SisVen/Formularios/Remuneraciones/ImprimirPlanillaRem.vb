Public Class ImprimirPlanillaRem
    Private Sub ImprimirPlanillaRem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cAño.AñosMes("A")
        cMes.AñosMes("M")
        cAño.SelectedValue = "1"
        If Now.Month > 1 Then
            cMes.SelectedValue = Now.AddMonths(-1).Month.ToString
        Else
            cMes.SelectedValue = Now.Month.ToString
        End If
        LoadCombobox(cEmpresa, "Locales", "Local", "NombreLocal", " WHERE Local IN (SELECT DISTINCT Local FROM usuarios WHERE funcionario=1)")
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
        cAño.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        If Not ValidarCombo(cAño) Then
            MsgError("Indique Año")
            cAño.Focus()
            Exit Sub
        End If
        If Not ValidarCombo(cMes) Then
            MsgError("Indique Mes")
            cMes.Focus()
            Exit Sub
        End If
        If Not ValidarCombo(cEmpresa) Then
            MsgError("Indique Empresa")
            cEmpresa.Focus()
            Exit Sub
        End If

        Dim wReporte As New ReporteLiquidaciones

        Dim wListaParametros = New List(Of ParametrosLocal)

        Swap = SQL("SELECT * FROM Locales WHERE Local = " & LocalActual)

        While Not Swap.EOF
            wListaParametros.Add(New ParametrosLocal With {.Local = Swap.Fields("Local").Text,
                                                           .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                           .RazonLocal = Swap.Fields("RazonLocal").Text,
                                                           .GiroLocal = Swap.Fields("GiroLocal").Text,
                                                           .DirLocal = Swap.Fields("DirLocal").Text,
                                                           .Ciudad = Swap.Fields("Ciudad").Text,
                                                           .Comuna = Swap.Fields("Comuna").Text,
                                                           .RutLocal = Swap.Fields("RutLocal").Text,
                                                           .Periodo = cMes.Text.ToLower & " de " & cAño.Text,
                                                           .Logo = Swap.Fields("Logo").Value})

            Swap.MoveNext()
        End While


        Dim wQuery = "SELECT S.*, M.ModoPago,M.DescModoPago,U.NombreUsr FROM Sueldos S JOIN ModoPagos M ON S.ModoPago = M.ModoPago JOIN Usuarios U ON S.Usuario = U.Usuario " &
                     "  WHERE S.Año = " & cAño.Text.Trim & " AND S.Mes = " & cMes.SelectedValue & " AND S.Empresa = " & cEmpresa.SelectedValue


        Dim Lista = New List(Of LiquidacionesReporte)
        Swap = SQL(wQuery)
        While Not Swap.EOF
            Lista.Add(New LiquidacionesReporte With {.AFC = Swap.Fields("AFP").Text,
                                                     .Ahorro = Swap.Fields("Ahorros").Text,
                                                     .Anticipos = Swap.Fields("Anticipos").Text,
                                                     .Base = Swap.Fields("Base").Text,
                                                     .Creditos = Swap.Fields("Creditos").Text,
                                                     .DescModoPago = Swap.Fields("DescModoPago").Text,
                                                     .Descuentos = Swap.Fields("Descuentos").Text,
                                                     .Funcionario = Swap.Fields("NombreUsr").Text,
                                                     .ModoPago = Swap.Fields("ModoPago").Text,
                                                     .Seguros = Swap.Fields("Seguros").Text,
                                                     .TAFP = Swap.Fields("TAFP").Text,
                                                     .TAguinaldos = Swap.Fields("TAguinaldos").Text,
                                                     .TBonos = Swap.Fields("TBonos").Text,
                                                     .TCargas = Swap.Fields("TCargas").Text,
                                                     .TColacion = Swap.Fields("TColacion").Text,
                                                     .TDescuentos = Swap.Fields("TDescuentos").Text,
                                                     .TGratificacion = Swap.Fields("TGratificacion").Text,
                                                     .THaberes = Swap.Fields("THAberes").Text,
                                                     .TImponible = Swap.Fields("TImponible").Text,
                                                     .TLiquido = Swap.Fields("TLiquido").Text,
                                                     .TMovilizacion = Swap.Fields("TMovilizacion").Text,
                                                     .TSalud = Swap.Fields("TSalud").Text,
                                                     .TVariables = Swap.Fields("TVariables").Text,
                                                     .Dia = Swap.Fields("Dias").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            wReporte.Database.Tables("SisVen_LiquidacionesReporte").SetDataSource(Lista)
            wReporte.Database.Tables("SisVen_LocalesParametro").SetDataSource(wListaParametros)
            VisorReportes.Visor_Reporte.ReportSource = wReporte
            VisorReportes.Show()
            VisorReportes.BringToFront()
        Else
            Mensaje("No se encuentran datos para la selección indicada")
            Close()
        End If
        Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
    End Sub
End Class