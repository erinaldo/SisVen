Public Class CalculoRem
    Private Sub CalculoRem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer, nMes As Integer

        Auditoria(Me.Text, PR_INGRESAR, "", 0)

        For i = Year(Now) - 1 To Year(Now)
            cAño.Items.Add(Num(i))
        Next i

        For i = 1 To 12
            cMes.Items.Add(Trim(MES(i)))
        Next i

        nMes = Month(Now)

        If nMes > 1 Then
            nMes = nMes - 1
        End If

        cAño.Text = Num(Year(Now))
        cMes.Text = Trim(MES(nMes))
    End Sub

    Private Sub bCalcular_Click(sender As Object, e As EventArgs) Handles bCalcular.Click
        Dim xAño As Integer, xMes As Integer

        xAño = Val(cAño.Text)
        xMes = cMes.SelectedIndex + 1

        If Not Pregunta("Esta seguro de Liquidar" + vbCrLf + "Año: " + cAño.Text + vbCrLf + "Mes: " + cMes.Text) Then
            Exit Sub
        End If

        Call Auditoria(Me.Name, "Cálculo de Remuneración", cMes.Text, cAño.Text)

        xMensaje.Text = ""
        bCalcular.Enabled = False

        Auditoria(Me.Text, "Remuneraciones", cAño.Text, Val(xMes))
        Procesar_Remuneraciones(xAño, xMes)

        bCalcular.Enabled = True

    End Sub

    Sub Procesar_Remuneraciones(xAño As Integer, xMes As Integer)
        Dim Dias_Trabajados As Integer, F1 As String, F2 As String
        Dim TBase As Double, TGratificacion As Double, TAguinaldos As Double
        Dim TVariables, TCesantia As Double, TBonos As Double, TBonos2 As Double, xUF As Double
        Dim TAnticipos As Double, TCreditos As Double, TSeguros As Double, TDescuentos As Double, TAhorros As Double ', TCargas As Double
        Dim TColacion As Double, TMovilizacion As Double, Total_General As Double

        'Verificar que se haya ingresado la UF/UTM
        Dim wUFS = SQL("Select * from UFs where Año = " + Num(xAño) + " and Mes = " + Num(xMes))
        If wUFS.RecordCount = 0 Then
            MsgError("No se pueden procesar remuneraciones por no existir el ingreso de la UF para ese mes.")
            Exit Sub
        End If

        UFGlobal = wUFS("UF").Value
        UTMGlobal = wUFS("UTM").Value

        'Verificar actualización de AFP
        'Afp = Sql("Select top 1 * from AFPs where Año = " + NUM(xAño) + " and Mes = " + NUM(xMes))
        'If Afp.RecordCount = 0 Then
        '    El_Error ("No se pueden procesar remuneraciones por no existir el ingreso de las AFPs para ese mes.")
        '    Exit Sub
        'End If

        F1 = IniFecha(1, CDate("01/" + Num(xMes) + "/" + Num(xAño))) + " 00:00:00"
        F2 = IniFecha(2, CDate("01/" + Num(xMes) + "/" + Num(xAño))) + " 23:59:59"

        'Eliminar Remuneraciones no canceladas en el periodo
        Swap = SQL("Delete Sueldos where Estado = 0 and Año = " + Num(xAño) + " and Mes = " + Num(xMes))

        Total_General = 0
        Usr = SQL("Select * from Usuarios where Funcionario = 1 Order by Usuario")
        While Not Usr.EOF
            DoEvents()

            'If Usr("Usuario").Value = "RAB" Then
            '    a = 1
            'End If

            'Saltarse el Funcionario que ya se le cancelo ese mes su liquidacion
            Swap = SQL("Select Usuario from Sueldos where Estado=1 and Año = " + Num(xAño) + " and Mes = " + Num(xMes) + " and Usuario = '" + Usr("Usuario").Value + "'")
            If Swap.RecordCount = 0 Then
                Dias_Trabajados = 30
                TVariables = 0 : TBonos = 0 : TBonos2 = 0 : TAguinaldos = 0 : TMovilizacion = 0 : TColacion = 0
                TAnticipos = 0 : TDescuentos = 0 : TCreditos = 0 : TSeguros = 0 : TAhorros = 0 : TCesantia = 0 'se utilizará cargas desde el usuario: TCargas = 0
                'Recorrer Eventos del Mes
                RmD = SQL("Select * from Sueldos_Detalles where Fecha >= '" + F1 + "' and Fecha <= '" + F2 + "' and Estado = 0 and Usuario = '" + Usr("Usuario").Value + "'")
                If RmD.RecordCount > 0 Then
                    While Not RmD.EOF
                        DoEvents()

                        If RmD("EventoRem").Value = 0 Then 'Sin Evento
                            'Procedimiento es una Observacion
                        End If
                        If RmD("EventoRem").Value = 1 Then  'Orden de Transporte (Variable)
                            TVariables = TVariables + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 2 Then 'Bono
                            TBonos = TBonos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 3 Then 'Ajuste Sencillo
                            TBonos2 = TBonos2 + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 4 Then 'Anticipo 1
                            TAnticipos = TAnticipos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 5 Then 'Anticipo 2
                            TAnticipos = TAnticipos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 6 Then 'Anticipo 3
                            TAnticipos = TAnticipos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 7 Then 'Descuento 1
                            TDescuentos = TDescuentos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 8 Then 'Descuento 2
                            TDescuentos = TDescuentos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 9 Then 'Descuento 3
                            TDescuentos = TDescuentos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 10 Then 'Prestamo 1
                            TCreditos = TCreditos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 11 Then 'Prestamo 2
                            TCreditos = TCreditos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 12 Then 'Prestamo 3
                            TCreditos = TCreditos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 13 Then 'Otros Anticipos
                            TAnticipos = TAnticipos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 14 Then 'Otros Descuentos
                            TDescuentos = TDescuentos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 15 Then 'Otros Prestamos
                            TCreditos = TCreditos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 16 Then 'Otros Bonos
                            TBonos = TBonos + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 17 Then 'Ahorro Voluntario
                            TAhorros = TAhorros + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 18 Then 'Seguro de Vida
                            TSeguros = TSeguros + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 19 Then 'Seguro de Cesantia
                            TCesantia = TCesantia + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 20 Then 'Descontar Dia
                            Dias_Trabajados = Dias_Trabajados - RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 21 Then 'Aguinaldo
                            TAguinaldos = TAguinaldos + RmD("Monto").Value
                        End If

                        'Se grabarán las cargas familiares en los datos del usuario y no como evento
                        'If RmD("EventoRem").Value = 22 Then 'Asignacion Familiar}
                        '    TCargas = TCargas + RmD("Monto").Value
                        'End If

                        If RmD("EventoRem").Value = 23 Then 'Aguinaldo Especial
                            TVariables = TVariables + RmD("Monto").Value
                        End If


                        If RmD("EventoRem").Value = 25 Then 'Bono de Movilizacion
                            TMovilizacion = TMovilizacion + RmD("Monto").Value
                        End If
                        If RmD("EventoRem").Value = 26 Then 'Bono de Colacion
                            TColacion = TColacion + RmD("Monto").Value
                        End If

                        RmD.MoveNext()
                    End While
                End If

                ' Crear Sueldo
                If Dias_Trabajados >= 0 Then
                    RmG = SQL("Select Top 1 * from Sueldos")
                    RmG.AddNew()
                    RmG("Año").Value = xAño
                    RmG("Mes").Value = xMes
                    RmG("Usuario").Value = Usr("Usuario").Value

                    RmG("Estado").Value = 0
                    If Dias_Trabajados > 0 Then
                        RmG("Base").Value = Math.Round(Usr("Base").Value / 30 * Dias_Trabajados, 0)
                    Else
                        RmG("Base").Value = 0
                    End If
                    RmG("Bruto").Value = Usr("Bruto").Value
                    RmG("Dias").Value = Dias_Trabajados
                    TBase = ((Usr("Base").Value / 30) * Dias_Trabajados)
                    TGratificacion = Math.Round((TBase * Usr("Gratificacion").Value / 100))
                    RmG("TImponible").Value = TBase + TGratificacion + TBonos + TBonos2 + TAguinaldos
                    RmG("Gratificacion").Value = Usr("Gratificacion").Value
                    RmG("TGratificacion").Value = TGratificacion
                    RmG("Colacion").Value = Usr("Colacion").Value
                    RmG("TColacion").Value = (Usr("Colacion").Value * Dias_Trabajados) + TColacion

                    RmG("Movilizacion").Value = Usr("Movilizacion").Value
                    RmG("TMovilizacion").Value = (Usr("Movilizacion").Value * Dias_Trabajados) + TMovilizacion

                    RmG("Cargas").Value = Usr("Cargas").Value
                    RmG("TCargas").Value = Usr("MontoCargas").Value
                    RmG("TVariables").Value = TVariables
                    RmG("TBonos").Value = TBonos
                    RmG("TBonos2").Value = TBonos2
                    RmG("TAguinaldos").Value = TAguinaldos

                    RmG("AFP").Value = Usr("AFP").Value
                    If Buscar("AFPs", "AFP", Usr("AFP").Value, "PorcentajeAFP,NombreAFP") Then
                        RmG("PorcentajeAFP").Value = Swap("PorcentajeAFP").Value
                        RmG("NAFP").Value = Swap("NombreAFP").Value
                    Else
                        RmG("PorcentajeAFP").Value = 0
                    End If
                    RmG("TAFP").Value = Math.Round(RmG("TImponible").Value * (RmG("PorcentajeAFP").Value / 100))
                    RmG("Salud").Value = Usr("Salud").Value
                    Dim wUF = SQL("Select * from UFs where Año = " + Num(xAño) + " and Mes = " + Num(xMes))
                    If wUF.RecordCount > 0 Then
                        RmG("UF").Value = wUF("UF").Value
                    End If

                    RmG("SIS").Value = Usr("SIS").Value

                    If Usr("Pactado").Value > 0 Then
                        xUF = 0
                        wUF = SQL("Select * from UFs where Año = " + Num(xAño) + " and Mes = " + Num(xMes))
                        If wUF.RecordCount > 0 Then
                            xUF = wUF("UF").Value
                        End If
                        RmG("PorcentajeSalud").Value = Usr("Pactado").Value
                        If Buscar("Salud", "Salud", Usr("Salud").Value, "PorcentajeSalud,NombreSalud") Then
                            RmG("NSalud").Value = Swap("NombreSalud").Value
                        End If

                        'El valor pactado no depende de los dias trabajados
                        'If Dias_Trabajados < 30 Then
                        '    RmG("TSalud").Value = ((RmG("PorcentajeSalud").Value * xUF) / 30) * Dias_Trabajados
                        'Else
                        RmG("TSalud").Value = RmG("PorcentajeSalud").Value * xUF
                        'End If
                    Else
                        If Buscar("Salud", "Salud", Usr("Salud").Value, "PorcentajeSalud,NombreSalud") Then
                            RmG("PorcentajeSalud").Value = Swap("PorcentajeSalud").Value
                            RmG("NSalud").Value = Swap("NombreSalud").Value
                        Else
                            RmG("PorcentajeSalud").Value = 0
                        End If
                        RmG("TSalud").Value = Math.Round(RmG("TImponible").Value * (RmG("PorcentajeSalud").Value / 100))
                    End If

                    RmG("Anticipos").Value = TAnticipos
                    RmG("Descuentos").Value = TDescuentos
                    RmG("Creditos").Value = TCreditos
                    RmG("Seguros").Value = TSeguros
                    If TCesantia > 0 Then
                        RmG("AFC").Value = TCesantia
                    Else
                        If CDate(Usr("vigencia").Value) = CDate("01/01/3000") Then
                            RmG("AFC").Value = Math.Round(RmG("Timponible").Value * 0.006)
                        Else
                            RmG("AFC").Value = 0
                        End If
                    End If
                    RmG("Ahorros").Value = TAhorros
                    RmG("ImpuestoUnico").Value = CalculoImpuestoUnico(RmG("TImponible").Value, RmG("TAFP").Value, RmG("TSalud").Value, RmG("AFC").Value)
                    RmG("TDescuentos").Value = RmG("TAFP").Value + RmG("TSalud").Value + TAnticipos + TCreditos + TDescuentos + TSeguros + TAhorros + RmG("AFC").Value + RmG("ImpuestoUnico").Value

                    'En Wikets Software se regala la movilizacion para compensar el valor del impuesto unico
                    If gClave = "W" Then
                        RmG("Movilizacion").Value = RmG("ImpuestoUnico").Value + RmG("Movilizacion").Value
                        RmG("TMovilizacion").Value = RmG("ImpuestoUnico").Value + RmG("TMovilizacion").Value
                    Else
                        'Para otros clientes se calcula la movilizacion
                        RmG("Movilizacion").Value = Usr("Movilizacion").Value
                        RmG("TMovilizacion").Value = (Usr("Movilizacion").Value * Dias_Trabajados) + TMovilizacion
                    End If
                    RmG("THaberes").Value = RmG("TImponible").Value + RmG("TColacion").Value + RmG("TMovilizacion").Value + RmG("TCargas").Value + TVariables

                    RmG("TLiquido").Value = RmG("THaberes").Value - RmG("TDescuentos").Value

                    RmG("Cancelado").Value = False
                    RmG("ModoPago").Value = ""
                    RmG("FechaPago").Value = Now
                    RmG("UsuarioPago").Value = UsuarioActual
                    RmG("Empresa").Value = Usr("Empresa").Value
                    RmG.Update()

                    Total_General += RmG("TLiquido").Value

                    xMensaje.Text = xMensaje.Text + Trim(Usr("NombreUsr").Value) + " $" + Format(RmG("TLiquido").Value, "###,###,###") + vbCrLf
                Else
                    MsgError("Error en días trabajados, la cantidad es negativa (Solucionar y recalcular Remuneraciones). Usuario:" + Usr("usuario").Value)
                    Exit Sub
                End If

            End If
            Usr.MoveNext()
        End While

        xMensaje.Text = xMensaje.Text + "--------------------------------------------------------" + vbCrLf
        xMensaje.Text = xMensaje.Text & "Total Sueldos: " + " $" + Format(Total_General, "###,###,###") + vbCrLf
    End Sub

    Function CalculoImpuestoUnico(wTotalImponible As Double, wAFP As Double, wSalud As Double, wSeguros As Double) As Double
        Dim ValorImpuestoUnico As Double, FactorImpuestoUnico As Double, ValorDescuentoImpuestoUnico As Double, Valor_a_Usar As Double, Valor_Tope As Double

        CalculoImpuestoUnico = 0 : ValorImpuestoUnico = 0 : FactorImpuestoUnico = 0 : ValorDescuentoImpuestoUnico = 0 : Valor_a_Usar = 0 : Valor_Tope = 0

        Valor_a_Usar = wTotalImponible - wAFP - wSalud

        TIU = SQL("Select * from ImpuestoUnico Order by Tope Asc")
        While Not TIU.EOF
            Valor_Tope = TIU.Fields("Tope").Value * UTMGlobal
            If Valor_a_Usar <= Valor_Tope Then
                FactorImpuestoUnico = TIU.Fields("Factor").Value
                ValorDescuentoImpuestoUnico = TIU.Fields("Rebaja").Value * UTMGlobal
                GoTo SalirIU
            End If
            TIU.MoveNext
        End While

SalirIU:
        'Si no encontro ningun rango, es porque supera el tope maximo, para ello se calcula con el valor maximo que haya en la tabla
        If FactorImpuestoUnico = 0 Then
            TIU = SQL("Select * from ImpuestoUnico Order by Tope Desc")
            Valor_Tope = TIU.Fields("Tope").Value * UTMGlobal
            If Valor_a_Usar > Valor_Tope Then
                FactorImpuestoUnico = TIU.Fields("Factor").Value
                ValorDescuentoImpuestoUnico = TIU.Fields("Rebaja").Value * UTMGlobal
            End If
        End If

        ValorImpuestoUnico = ((wTotalImponible - wAFP - wSalud - 0) * FactorImpuestoUnico) - ValorDescuentoImpuestoUnico
        If ValorImpuestoUnico < 0 Then
            ValorImpuestoUnico = 0
        End If

        CalculoImpuestoUnico = ValorImpuestoUnico
    End Function

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class