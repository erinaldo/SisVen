Public Class ConsultaCuadraturaCaja
    Private Sub bLimpiar_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bLimpiar.Click
        LimpiarCampos(Me)
        dDesde.Value = IniFinFecha(1, Now)
        dHasta.Value = IniFinFecha(2, Now)

    End Sub
    Private Sub ConsultaCuadraturaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bLimpiar_Click()
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub xCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCaja.KeyPress
        ValidarDigitos(e)
        e.NextControl(bImprimir)
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        If dDesde.Value > dHasta.Value Then
            MsgError("La fecha inicial no puede ser mayor a la final")
            Exit Sub
        ElseIf dHasta.Value < dDesde.Value Then
            MsgError("La fecha final no puede ser menor a la inicial")
            Exit Sub
        End If

        xCuadratura.Clear()
        ConsutarCuadratura()

        Auditoria(Me.Text, PR_CONSULTAR, "", 0)

    End Sub

    Sub ConsutarCuadratura()
        Dim wLocal = ""
        Dim wFPago = ""
        Dim wFiltro = ""
        Dim wTotalCaja As Double

        If Not ValidarCombo(cLocal) Then
            Dim Loc = SQL("SELECT Local,NombreLocal FROM Locales Order by Local")
            While Not Loc.EOF
                xCuadratura.Text = xCuadratura.Text & "LOCAL: " & Loc.Fields("NombreLocal").Text & vbCrLf & vbCrLf
                wTotalCaja = 0
                If xCaja.Text = "" Then
                    Dim caj = SQL("SELECT DISTINCT Caja FROM Ventas WHERE Local =  " & Loc.Fields("Local").Text)
                    While Not caj.EOF
                        xCuadratura.Text = xCuadratura.Text & "Caja " & caj.Fields("Caja").Text & ":    " & vbCrLf
                        Ven = SQL("Select Sum(Total) as TCaja,Fpago from Ventas where Local = " & Loc.Fields("Local").Text & " AND" &
                          " Fecha >= '" & dDesde.Value & "' And Fecha < '" & dHasta.Value & "' AND Caja = " & caj.Fields("Caja").Text & " Group By FPago")
                        While Not Ven.EOF
                            If Buscar("FPagos", "FPago", Ven.Fields("FPago").Text) Then
                                wFPago = Swap.Fields("DescFPago").Text.Trim
                            Else
                                wFPago = " "
                            End If
                            xCuadratura.Text = xCuadratura.Text + wFPago & ": " & FormatNumber(Ven.Fields("TCaja").Text, 1) & vbCrLf
                            wTotalCaja += Ven.Fields("TCaja").Text
                            Ven.MoveNext()
                        End While
                        caj.MoveNext()
                        xCuadratura.Text = xCuadratura.Text & vbCrLf
                    End While
                    Loc.MoveNext()
                    xCuadratura.Text = xCuadratura.Text & "-----------------------------------" & vbCrLf
                    xCuadratura.Text = xCuadratura.Text & "TOTAL : " & FormatNumber(wTotalCaja, 1) & vbCrLf & vbCrLf
                Else
                    xCuadratura.Text = xCuadratura.Text & "Caja " & xCaja.Text & ":    " & vbCrLf
                    Ven = SQL("Select Sum(Total) as TCaja,Fpago from Ventas where Local = " & Loc.Fields("Local").Text & " AND" &
                      " Fecha >= '" & dDesde.Value & "' And Fecha < '" & dHasta.Value & "' AND Caja = " & xCaja.Text & " Group By FPago")
                    While Not Ven.EOF
                        If Buscar("FPagos", "FPago", Ven.Fields("FPago").Text) Then
                            wFPago = Swap.Fields("DescFPago").Text.Trim
                        Else
                            wFPago = " "
                        End If
                        xCuadratura.Text = xCuadratura.Text + wFPago & ": " & FormatNumber(Ven.Fields("TCaja").Text, 1) & vbCrLf
                        wTotalCaja += Ven.Fields("TCaja").Text
                        Ven.MoveNext()
                    End While
                    Loc.MoveNext()
                    xCuadratura.Text = xCuadratura.Text & "-----------------------------------" & vbCrLf
                    xCuadratura.Text = xCuadratura.Text & "TOTAL : " & FormatNumber(wTotalCaja, 1) & vbCrLf & vbCrLf
                End If
            End While

        Else
            xCuadratura.Text = xCuadratura.Text & "LOCAL: " & cLocal.Text.Trim & vbCrLf & vbCrLf
            If xCaja.Text = "" Then
                Dim caj = SQL("SELECT DISTINCT Caja FROM Ventas WHERE Local =  " & Loc.Fields("Local").Text)
                While Not caj.EOF
                    xCuadratura.Text = xCuadratura.Text & "Caja " & caj.Fields("Caja").Text & ":    " & vbCrLf
                    Ven = SQL("Select Sum(Total) as TCaja,Fpago from Ventas where Local = " & cLocal.SelectedValue & " AND" &
                      " Fecha >= '" & dDesde.Value & "' And Fecha < '" & dHasta.Value & "' AND Caja = " & caj.Fields("Caja").Text & " Group By FPago")
                    While Not Ven.EOF
                        If Buscar("FPagos", "FPago", Ven.Fields("FPago").Text) Then
                            wFPago = Swap.Fields("DescFPago").Text.Trim
                        Else
                            wFPago = " "
                        End If
                        xCuadratura.Text = xCuadratura.Text + wFPago & ": " & FormatNumber(Ven.Fields("TCaja").Text, 1) & vbCrLf
                        wTotalCaja += Ven.Fields("TCaja").Text
                        Ven.MoveNext()
                    End While
                    caj.MoveNext()
                    xCuadratura.Text = xCuadratura.Text & vbCrLf
                End While
                xCuadratura.Text = xCuadratura.Text & "-----------------------------------" & vbCrLf
                xCuadratura.Text = xCuadratura.Text & "TOTAL : " & FormatNumber(wTotalCaja, 1) & vbCrLf & vbCrLf
            Else
                xCuadratura.Text = xCuadratura.Text & "Caja " & xCaja.Text & ":    " & vbCrLf
                Ven = SQL("Select Sum(Total) as TCaja,Fpago from Ventas where Local = " & cLocal.SelectedValue & " AND" &
                  " Fecha >= '" & dDesde.Value & "' And Fecha < '" & dHasta.Value & "' AND Caja = " & xCaja.Text & " Group By FPago")
                While Not Ven.EOF
                    If Buscar("FPagos", "FPago", Ven.Fields("FPago").Text) Then
                        wFPago = Swap.Fields("DescFPago").Text.Trim
                    Else
                        wFPago = " "
                    End If
                    xCuadratura.Text = xCuadratura.Text + wFPago & ": " & FormatNumber(Ven.Fields("TCaja").Text, 1) & vbCrLf
                    wTotalCaja += Ven.Fields("TCaja").Text
                    Ven.MoveNext()
                End While
                xCuadratura.Text = xCuadratura.Text & "-----------------------------------" & vbCrLf
                xCuadratura.Text = xCuadratura.Text & "TOTAL : " & FormatNumber(wTotalCaja, 1) & vbCrLf & vbCrLf
            End If
        End If



        'Loc = SQL("Select * from Locales Order by Local")
        'While Not Loc.EOF
        '    wLocal = ""
        '    If Buscar("Locales", "Local", cLocal.SelectedValue, "Local") Then
        '        wLocal = Val(Swap.Fields("Local").Text)
        '    End If
        '    If wLocal = "" Or Trim(cLocal.SelectedValue) = Loc.Fields("NombreLocal").Text Then
        '        xCuadratura.Text = xCuadratura.Text & "LOCAL: " + Loc.Fields("NombreLocal").Text & vbCrLf & vbCrLf
        '        For c = 1 To 3
        '            If xCaja.Text = 0 Or xCaja.Text = 1 Then
        '                Ven = SQL("Select Sum(Total) as TCaja,Fpago from Ventas where Local = " & Loc.Fields("Local").Text & " AND " &
        '                          " Fecha >= '" & dDesde.Value & "' And Fecha < '" & dHasta.Value & "' and " &
        '                          " Caja = " & xCaja.Text & " Group By FPago")

        '                xCuadratura.Text = xCuadratura.Text & "Caja " & xCaja.Text & ":    " & vbCrLf
        '                While Not Ven.EOF
        '                    If Buscar("FPagos", "FPago", Ven.Fields("FPago").Text) Then
        '                        wFPago = Swap.Fields("DescFPago").Text.Trim
        '                    Else
        '                        wFPago = " "
        '                    End If
        '                    xCuadratura.Text = xCuadratura.Text + wFPago & ": " & Ven.Fields("TCaja").Text & vbCrLf
        '                    Ven.MoveNext()
        '                End While
        '                xCuadratura.Text = xCuadratura.Text & vbCrLf
        '            End If
        '        Next c
        '        Ven = SQL("Select Sum(Total) as Final from Ventas where Local = " & Loc.Fields("Local").Text & " and" &
        '                  " Fecha >= '" & dDesde.Value & "' and Fecha < '" & dHasta.Value & "'")
        '        xCuadratura.Text = xCuadratura.Text & "-----------------------------------" & vbCrLf
        '        xCuadratura.Text = xCuadratura.Text & "TOTAL : " + Format(Ven.Fields("Final").Text, "###,###,###") & vbCrLf & vbCrLf
        '    End If
        '    Loc.MoveNext()
        'End While
    End Sub
End Class