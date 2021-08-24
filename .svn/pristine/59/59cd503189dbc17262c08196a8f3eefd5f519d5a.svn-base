Public Class ImprimirLiquidaciones
    Private Sub ImprimirLiquidaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cAño.AñosMes("A")
        cMes.AñosMes("M")
        cAño.SelectedValue = "1"
        If Now.Month > 1 Then
            cMes.SelectedValue = Now.AddMonths(-1).Month.ToString
        Else
            cMes.SelectedValue = Now.Month.ToString
        End If
        LoadCombobox(cEmrpesa, "Locales", "Local", "NombreLocal", " WHERE Local IN (SELECT DISTINCT Local FROM usuarios WHERE funcionario=1)")
    End Sub

    Private Sub cEmrpesa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cEmrpesa.SelectedIndexChanged
        If ValidarCombo(cEmrpesa) Then
            LoadCombobox(cFuncionario, "USuarios", "Usuario", "NombreUsr", "WHERE Funcionario=1 and Empresa = " & cEmrpesa.SelectedValue)
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos(Me)
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click

        If Not ValidarCombo(cAño) Then
            MsgError("Indique año")
            cAño.Focus()
            Exit Sub
        End If
        If Not ValidarCombo(cMes) Then
            MsgError("Indique Mes")
            cMes.Focus()
            Exit Sub
        End If
        If Not ValidarCombo(cEmrpesa) Then
            MsgError("Indique Empresa")
            cEmrpesa.Focus()
            Exit Sub
        End If
        If Not ValidarCombo(cFuncionario) Then
            MsgError("Indique Funcionario")
            cFuncionario.Focus()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        bImprimir.Enabled = False

        Dim wListaParametros = New List(Of ParametrosLocal)
        Dim wReporte As New Liquidacion_Sueldo

        Swap = SQL("Select l.*,ci.NombreCiudad, co.NombreComuna  from Locales as l,Ciudades as ci, Comunas as co where l.local=" & LocalActual & " and l.Ciudad = ci.Ciudad and l.Comuna = co.Comuna ")

        While Not Swap.EOF
            wListaParametros.Add(New ParametrosLocal With {.Local = Swap.Fields("Local").Text,
                                                           .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                           .RazonLocal = Swap.Fields("RazonLocal").Text,
                                                           .GiroLocal = Swap.Fields("GiroLocal").Text,
                                                           .DirLocal = Swap.Fields("DirLocal").Text,
                                                           .Ciudad = Swap.Fields("NombreCiudad").Text,
                                                           .Comuna = Swap.Fields("NombreComuna").Text,
                                                           .RutLocal = Swap.Fields("RutLocal").Text,
                                                           .Periodo = cMes.Text.ToLower & " de " & cAño.Text,
                                                           .Logo = Swap.Fields("Logo").Value})

            Swap.MoveNext()
        End While

        Dim wQuery = "SELECT S.año,S.Mes,S.TLiquido,S.Dias,S.PorcentajeSalud,S.Base,S.TGratificacion,S.TImponible,S.TColacion,S.TMovilizacion,S.PorcentajeSalud,Us.Vigencia," &
                     " S.TCargas,S.Cargas,S.THaberes,S.TAFP,S.TSalud,S.Anticipos,S.Descuentos,S.TDescuentos,S.Ahorros,S.Seguros,S.Creditos,S.UF,S.NAFP,S.TBonos,S.TVariables," &
                     " S.NSalud,S.PorcentajeAFP,S.AFC,S.TAguinaldos,S.TBonos2,Us.NombreUsr,Us.Rut,Us.Pactado,Cl.Nombre,Cl.Direccion,ci.NombreCiudad,co.NombreComuna, S.ImpuestoUnico" &
                     " FROM SUELDOS S " &
                     " JOIN UFs UF ON S.UF = UF.UF" &
                     " JOIN Usuarios Us ON S.Usuario = Us.Usuario" &
                     " JOIN AFPs Af ON s.AFP = Af.AFP" &
                     " JOIN Salud Sa ON S.Salud = Sa.Salud" &
                     " JOIN Clientes Cl ON Us.Empresa = Cl.Cliente" &
                     " JOIN Ciudades Ci ON Cl.Ciudad = Ci.Ciudad" &
                     " JOIN Comunas Co ON Cl.Comuna = Co.comuna" &
                     " WHERE S.Año = " & cAño.Text & " AND S.Mes = " & cMes.SelectedValue & " AND S.Usuario = '" & cFuncionario.SelectedValue & "'"

        Dim wListaDatos = New List(Of LiquidacionReporte)
        Dim wLiquido = ""
        Swap = SQL(wQuery)

        While Not Swap.EOF
            wListaDatos.Add(New LiquidacionReporte With {.Año = Swap.Fields("Año").Text,
                                                   .Mes = Swap.Fields("Mes").Text,
                                                   .AFC = Swap.Fields("AFC").Text,
                                                   .Ahorros = Swap.Fields("Ahorros").Text,
                                                   .Anticipados = Swap.Fields("Anticipos").Text,
                                                   .Base = Swap.Fields("Base").Text,
                                                   .Descuentos = Swap.Fields("Descuentos").Text,
                                                   .Dias = Swap.Fields("Dias").Text,
                                                   .Direccion = Swap.Fields("Direccion").Text,
                                                   .NAFP = Swap.Fields("NAFP").Text,
                                                   .Nombre = Swap.Fields("Nombre").Text,
                                                   .NombreCiudad = Swap.Fields("NombreCiudad").Text,
                                                   .NombreComuna = Swap.Fields("NombreComuna").Text,
                                                   .Nombreusr = Swap.Fields("Nombreusr").Text,
                                                   .NSAlud = Swap.Fields("NSAlud").Text,
                                                   .Pactado = Swap.Fields("Pactado").Text,
                                                   .PorcentajeAFP = Swap.Fields("PorcentajeAFP").Text,
                                                   .Rut = Swap.Fields("Rut").Text,
                                                   .Seguros = Swap.Fields("Seguros").Text,
                                                   .TAFP = Swap.Fields("TAFP").Text,
                                                   .TAguinaldos = Swap.Fields("TAguinaldos").Text,
                                                   .TBonos2 = Swap.Fields("TBonos2").Text,
                                                   .TCargas = Swap.Fields("TCargas").Text,
                                                   .TColacion = Swap.Fields("TColacion").Text,
                                                   .TDescuentos = Swap.Fields("TDescuentos").Text,
                                                   .TGratificacion = Swap.Fields("TGratificacion").Text,
                                                   .THaberes = Swap.Fields("THaberes").Text,
                                                   .TImponible = Swap.Fields("TImponible").Text,
                                                   .TLiquido = Swap.Fields("TLiquido").Text,
                                                   .TMovilizacion = Swap.Fields("TMovilizacion").Text,
                                                   .TSalud = Swap.Fields("TSalud").Text,
                                                   .UF = Swap.Fields("UF").Text,
                                                   .Cargas = Swap.Fields("Cargas").Text,
                                                   .PorcentajeSalud = Swap.Fields("PorcentajeSalud").Text,
                                                   .TBonos = Swap.Fields("TBonos").Text,
                                                   .TVariables = Swap.Fields("TVariables").Text,
                                                   .Creditos = Swap.Fields("Creditos").Text,
                                                   .Vigencia = Swap.Fields("Vigencia").Text,
                                                   .Letras = Letras(Swap.Fields("TLiquido").Text).ToUpper,
                                                   .ImpuestoUnico = Swap.Fields("ImpuestoUnico").Text})
            Swap.MoveNext()
        End While
        ModuloReporte = ""
        wReporte.Database.Tables("SisVen_LocalesParametro").SetDataSource(wListaParametros)
        wReporte.Database.Tables("SisVen_LiquidacionReporte").SetDataSource(wListaDatos)
        wReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Directorio_PDF & "Sueldo " & cFuncionario.Text.Trim & " " & cMes.Text.Trim & " " & cAño.Text.Trim & ".pdf")
        VisorReportes.Visor_Reporte.ReportSource = wReporte

        VisorReportes.Show()
        VisorReportes.BringToFront()

        Cursor = Cursors.Arrow
        bImprimir.Enabled = True

    End Sub
End Class