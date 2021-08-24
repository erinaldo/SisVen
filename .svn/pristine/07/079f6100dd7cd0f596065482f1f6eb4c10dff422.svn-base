Imports System.Collections
Imports System.Collections.Generic

Public Class CuadraturaCaja
    Const T_LOCAL = 0
    Const T_POS = 1
    Const T_TIPODOC = 2
    Const T_FPAGOS = 3
    Const T_TOTAL = 4
    Sub Titulos()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 5

        xTabla.Cols(T_LOCAL).Width = 150
        xTabla.Cols(T_TIPODOC).Width = 0
        xTabla.Cols(T_POS).Width = 100
        xTabla.Cols(T_FPAGOS).Width = 250
        xTabla.Cols(T_TOTAL).Width = 140

        xTabla.Cols(T_LOCAL).Caption = "Local"
        xTabla.Cols(T_POS).Caption = "Pos"
        xTabla.Cols(T_TIPODOC).Caption = "Tipo Doc."
        xTabla.Cols(T_FPAGOS).Caption = "Forma Pago"
        xTabla.Cols(T_TOTAL).Caption = "Total"

    End Sub
    Private Sub CuadraturaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cDesde.Value = IniFinFecha(1, Date.Now)
        cHasta.Value = IniFinFecha(2, Date.Now)
        MostrarCuadratura(False)
        LoadCombobox(cLocal, "Locales", "Local", "NombreLocal")
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        cDesde.Value = IniFinFecha(1, Date.Now)
        cHasta.Value = IniFinFecha(2, Date.Now)
        cLocal.SelectedIndex = 0
        xPOS.Clear()
        cLocal.Focus()
    End Sub
    Public Sub MostrarCuadratura(ByVal wMostrar As Boolean)
        Invalidate()
        StartPosition = FormStartPosition.CenterScreen
        DoEvents()
    End Sub
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        MostrarCuadratura(True)
        BotonesActivados(False)
        Me.Cursor = Cursors.WaitCursor
        If oDoc.Checked Then
            Calcular_Cuadratura_DOC()
        Else
            Calcular_Cuadratura_CAJA()
        End If
        Me.Cursor = Cursors.Default
        BotonesActivados(True)
    End Sub
    Sub BotonesActivados(ByVal wEstado As Boolean)
        bSalir.Enabled = wEstado
        bLimpiar.Enabled = wEstado
        bConsultar.Enabled = wEstado
        bImprimir.Enabled = wEstado
    End Sub

    Sub Calcular_Cuadratura_DOC()

        Titulos()
        Dim wNumPOS = SQL("SELECT DISTINCT POS FROM DocumentosG WHERE POS IS NOT NULL")

        While Not wNumPOS.EOF
            Dim wSum = SQL("Select Sum(G.Total) as Caja,G.FPago,FP.DescFPago ,G.TipoDoc,TD.DescTipoDoc,G.Local," &
                       " LO.NombreLocal,G.POS" &
                       " from DocumentosG G" &
                       " JOIN FPagos FP ON G.FPago = FP.FPago" &
                       " JOIN TipoDoc TD ON G.TipoDoc = TD.TipoDoc" &
                       " JOIN Locales LO ON G.Local = LO.Local" &
                       " where G.Local = 1  And G.Fecha Between '01/09/2018 00:00:00 '  And '30/09/2018 23:59:00 '" &
                       " And G.TipoDoc in ('FV','NC','ND','FE','BV','BE') AND G.POS = " & wNumPOS.Fields("POS").Text & "" &
                       " Group By G.FPago,G.TipoDoc,FP.DescFPago,TD.DescTipoDoc, LO.NombreLocal ,G.Local,G.POS" &
                       " Order by G.POS,G.FPago,G.TipoDoc")

            If wSum.RecordCount > 0 Then
                Dim wTipoDocI = {"FV", "ND", "FE", "BV", "BE"}
                Dim wTipoDocE = {"NC"}
                Dim wNombreLocal = wSum.Fields("NOmbreLocal").Text
                Dim wCheque = 0
                Dim wDeposito = 0
                Dim wEfectivo = 0
                Dim wTarjetaBancaria = 0
                Dim wCheque30 = 0
                Dim wVariosPago = 0
                Dim wTransferencia = 0

                While Not wSum.EOF
                    If wSum.Fields("FPago").Text = "E" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wEfectivo += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "E" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wEfectivo -= Val(wSum.Fields("Caja").Text)
                    End If

                    If wSum.Fields("FPago").Text = "C" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wCheque += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "C" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wCheque -= Val(wSum.Fields("Caja").Text)
                    End If

                    If wSum.Fields("FPago").Text = "D" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wDeposito += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "D" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wDeposito -= Val(wSum.Fields("Caja").Text)
                    End If

                    If wSum.Fields("FPago").Text = "T" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wTarjetaBancaria += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "T" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wTarjetaBancaria -= Val(wSum.Fields("Caja").Text)
                    End If

                    If wSum.Fields("FPago").Text = "V" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wVariosPago += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "V" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wVariosPago -= Val(wSum.Fields("Caja").Text)
                    End If

                    If wSum.Fields("FPago").Text = "B" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wTransferencia += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "B" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wTransferencia -= Val(wSum.Fields("Caja").Text)
                    End If

                    If wSum.Fields("FPago").Text = "3" And wTipoDocI.Contains(wSum.Fields("TipoDoc").Text) Then
                        wCheque30 += Val(wSum.Fields("Caja").Text)
                    ElseIf wSum.Fields("FPago").Text = "3" And wTipoDocE.Contains(wSum.Fields("TipoDoc").Text) Then
                        wCheque30 -= Val(wSum.Fields("Caja").Text)
                    End If
                    wSum.MoveNext()
                End While
                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_LOCAL, wNombreLocal)
                xTabla.SetData(xTabla.Rows.Count - 1, T_POS, wNumPOS.Fields("POS").Text)
                'xTabla.SetData(xTabla.Rows.Count - 1, T_TIPODOC, wSum.Fields("TipoDoc").Text.Trim)
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Cheque 30 días")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wCheque30 = 0, 0, Format(wCheque30, "###,###,###")))

                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Transferencia")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wTransferencia = 0, 0, Format(wTransferencia, "###,###,###")))

                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Cheque")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wCheque = 0, 0, Format(wCheque, "###,###,###")))

                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Depósito")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wDeposito = 0, 0, Format(wDeposito, "###,###,###")))

                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Efectivo")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wEfectivo = 0, 0, Format(wEfectivo, "###,###,###")))

                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Tarjeta Bancaria")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wTarjetaBancaria = 0, 0, Format(wTarjetaBancaria, "###,###,###")))

                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Varios Pagos")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, IIf(wVariosPago = 0, 0, Format(wVariosPago, "###,###,###")))

                Dim wTotalPagos = Format(wCheque30 + wTransferencia + wCheque + wDeposito + wEfectivo + wTarjetaBancaria + wVariosPago, "###,###,###")
                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_FPAGOS, "Total")
                xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL, wTotalPagos)
                xTabla.FondoCelda(xTabla.Rows.Count - 1, C_AMARILLO_CELDA)
            End If
            wNumPOS.MoveNext()
        End While







        'Dim wNumeroCaja = 0
        'Loc = SQL("Select Local,NombreLocal from Locales " & wFiltro & " Order by Local")

        'xCuadratura.Clear()

        'While Not Loc.EOF

        '    Dim wLocales As Double = Loc.Fields("Local").Value
        '    xCuadratura.Text = xCuadratura.Text & "LOCAL: " & Trim(Loc.Fields("NombreLocal").Value) & vbCrLf & vbCrLf
        '    DocG = SQL("SELECT Distinct Top 1 POS FROM DocumentosG WHERE Local=" & wLocales & " Order By POS Desc")
        '    If DocG.EOF Then
        '        wNumeroPos = 0
        '    Else
        '        wNumeroPos = DocG.Fields("POS").Value
        '    End If
        '    wTotalVendido = 0
        '    Titulos()
        '    For wNumeroCaja = 0 To wNumeroPos
        '        If xPOS.Text <> "" And Val(xPOS.Text) > 0 Then
        '            wNumeroCaja = Val(xPOS.Text)
        '        End If

        '        Caj = SQL("Select Sum(G.Total) as TCaja,G.FPago,FP.DescFPago ,G.TipoDoc,TD.DescTipoDoc,G.Local, LO.NombreLocal,G.POS " &
        '                  " from DocumentosG G" &
        '                  " JOIN FPagos FP ON G.FPago = FP.FPago" &
        '                  " JOIN TipoDoc TD ON G.TipoDoc = TD.TipoDoc" &
        '                  " JOIN Locales LO ON G.Local = LO.Local" &
        '                  " where G.Local = " & wLocales & " " &
        '                  " And G.Fecha Between '" & cDesde.Text & " 00:00:00 " & "' " &
        '                  " And '" & cHasta.Text & " 23:59:00 " & "' " &
        '                  " And G.TipoDoc in ('FV','NC','ND','FE','BV','BE') " &
        '                  " And G.POS=" & wNumeroCaja & "" &
        '                  " Group By G.FPago,G.TipoDoc,FP.DescFPago,TD.DescTipoDoc, LO.NombreLocal ,G.Local,G.POS" &
        '                  " Order by G.FPago,G.TipoDoc")

        '        xCuadratura.Text = xCuadratura.Text & "POS " & wNumeroCaja & ": " & vbCrLf

        '        If Caj.RecordCount > 0 Then

        '            Dim ValorP As Double
        '            wFPago = ""
        '            While Not Caj.EOF
        '                xTabla.AddItem("")
        '                xTabla.SetData(xTabla.Rows.Count - 1, T_LOCAL, Caj.Fields("NombreLocal").Value)
        '                xTabla.SetData(xTabla.Rows.Count - 1, T_LOCAL, Caj.Fields("POS").Value)
        '                xTabla.SetData(xTabla.Rows.Count - 1, T_LOCAL, Caj.Fields("DescFPago").Value)

        '                If Buscar("FPagos", "FPago", Caj.Fields("FPago").Value) Then
        '                    If Trim(Swap.Fields("DescFPago").Value) <> wFPago And wFPago <> "" Then
        '                        xCuadratura.Text = xCuadratura.Text & wFPago & ":" + vbTab & Format(ValorP, "###,###,###") & vbCrLf
        '                        ValorP = 0
        '                    End If
        '                    wFPago = Trim(Swap.Fields("DescFPago").Value)
        '                End If
        '                If Caj("TipoDoc").Value = "FV" Or Caj("TipoDoc").Value = "ND" Or Caj("TipoDoc").Value = "BV" Or Caj("TipoDoc").Value = "BE" Or Caj("TipoDoc").Value = "FE" Then
        '                    ValorP += Caj.Fields("TCaja").Value
        '                    wTotalVendido += Caj.Fields("TCaja").Value
        '                End If
        '                If Caj("TipoDoc").Value = "NC" Then
        '                    ValorP -= Caj.Fields("TCaja").Value
        '                    wTotalVendido -= Caj.Fields("TCaja").Value
        '                End If
        '                xTabla.SetData(xTabla.Rows.Count - 1, T_LOCAL, Format(ValorP, "###,###,###"))
        '                Caj.MoveNext()
        '            End While
        '            xCuadratura.Text = xCuadratura.Text & wFPago & ":" + vbTab & Format(ValorP, "###,###,###") & vbCrLf
        '        End If

        '        If Trim(xPOS.Text) <> "" Or Val(xPOS.Text) = 0 Then Exit For
        '    Next
        '    wFiltro = ""
        '    If xPOS.Text <> "" And Val(xPOS.Text) > 0 Then
        '        wFiltro = " And POS=" & Val(xPOS.Text) & ""
        '    End If

        '    Caj = SQL("Select Coalesce(Count(TipoDoc),0) as Cantidades from DocumentosG " &
        '                  " where Local = " & wLocales & " " &
        '                  " And Fecha Between '" & cDesde.Text & " 00:00:00 " & "' " &
        '                  " And '" & cHasta.Text & " 23:59:00 " & "' AND (1=1) " & wFiltro & "" &
        '                  " And TipoDoc in ('FV','NC','ND','FE','BV','BE') " &
        '                  " And POS=" & wNumeroCaja)

        '    wTotalCuadratura = IIf(wTotalVendido = 0, 0, Format(wTotalVendido, "###,###,###"))
        '    xCuadratura.Text = xCuadratura.Text & "-------------------------------" & vbCrLf
        '    xCuadratura.Text = xCuadratura.Text & "TOTAL $:" + vbTab & wTotalCuadratura & vbCrLf
        '    xCuadratura.Text = xCuadratura.Text & "N° Documentos:" + vbTab & CStr(Caj("Cantidades").Value) & vbCrLf
        '    xCuadratura.Text += vbCrLf + vbCrLf

        '    Loc.MoveNext()
        '    DoEvents()
        'End While
    End Sub

    Sub Calcular_Cuadratura_CAJA()
        'Dim wFPago As String
        'Dim wNumeroCaja As Integer
        'Dim wNumeroPos As Integer
        'Dim wTotalVendido As Double
        'Dim wTotalCuadratura As String
        'Dim wFiltro As String = IIf(cLocal.Text = "Seleccionar", "", " WHERE NombreLocal='" & Trim(cLocal.Text) & "'")
        'Loc = SQL("Select Local,NombreLocal from Locales " & wFiltro & " Order by Local")

        'While Not Loc.EOF
        '    Dim wLocales As Double = Loc.Fields("Local").Value
        '    'xCuadratura.Text = xCuadratura.Text & "LOCAL: " & Trim(Loc.Fields("NombreLocal").Value) & vbCrLf & vbCrLf
        '    Cli = SQL("SELECT Distinct Top 1 Caja FROM Ventas WHERE Local=" & wLocales & " Order By Caja Desc")
        '    If Cli.EOF Then
        '        wNumeroPos = 1
        '    Else
        '        wNumeroPos = Cli.Fields("Caja").Value
        '    End If
        '    For wNumeroCaja = 1 To wNumeroPos
        '        If xPOS.Text <> "" And Val(xPOS.Text) > 0 Then
        '            wNumeroCaja = Val(xPOS.Text)
        '        End If
        '        Caj = SQL("Select Sum(Total) as TCaja,Fpago from Ventas " &
        '                      " where Local = " & wLocales & " " &
        '                      " And Fecha Between '" & cDesde.Text & " 00:00:00 " & "' " &
        '                      " And '" & cHasta.Text & " 23:59:00 " & "' " &
        '                      " And Caja=" & wNumeroCaja & " Group By FPago")
        '        xCuadratura.Text = xCuadratura.Text & "Caja " & wNumeroCaja & ": " & vbCrLf

        '        While Not Caj.EOF
        '            If Buscar("FPagos", "FPago", Caj.Fields("FPago").Value) Then
        '                wFPago = Trim(Swap.Fields("DescFPago").Value)
        '            Else
        '                wFPago = " "
        '            End If
        '            xCuadratura.Text = xCuadratura.Text & wFPago & ": " & Format(Caj.Fields("TCaja").Value, "###,###,###") & vbCrLf
        '            Caj.MoveNext()
        '        End While

        '        xCuadratura.Text = xCuadratura.Text & vbCrLf
        '        If Trim(xPOS.Text) <> "" Or Val(xPOS.Text) = 0 Then Exit For
        '    Next
        '    wFiltro = ""
        '    If xPOS.Text <> "" And Val(xPOS.Text) > 0 Then
        '        wFiltro = " And Caja=" & Val(xPOS.Text) & ""
        '    End If

        '    Caj = SQL("Select Coalesce(Sum(Total),0) as Final from Ventas " &
        '                  " where Local = " & wLocales & " " &
        '                  " And Fecha Between '" & cDesde.Text & " 00:00:00 " & "' " &
        '                  " And '" & cHasta.Text & " 23:59:00 " & "' AND Caja<>0 " & wFiltro & "")

        '    wTotalVendido = Val(Caj.Fields("Final").Value)
        '    wTotalCuadratura = IIf(wTotalVendido = 0, 0, Format(wTotalVendido, "###,###,###"))
        '    xCuadratura.Text = xCuadratura.Text & "-----------------------------------" & vbCrLf
        '    xCuadratura.Text = xCuadratura.Text & "TOTAL : " & wTotalCuadratura & vbCrLf & vbCrLf
        '    Loc.MoveNext()
        '    DoEvents()
        'End While
    End Sub
    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wFiltro As String = ""
        wFiltro = " CONVERT(date,v.fecha,3) between '" & cDesde.Text & "' And '" & cHasta.Text & "'"
        If Trim(cLocal.Text) <> "Seleccionar" Then
            wFiltro += " AND l.NombreLocal='" & Trim(cLocal.Text) & "'"
        End If
        If Val(xPOS.Text) > 0 Then
            wFiltro += " AND v.Caja=" & Val(xPOS.Text)
        End If
        Dim wQuery As String = "SELECT v.Local,v.FPago,v.Caja,f.DescFPago,l.NombreLocal," &
                                " CONVERT(date,v.fecha,3) as Fecha,Sum(v.Total) as Total " &
                                " FROM Ventas v INNER JOIN Locales l on v.Local=l.Local " &
                                " INNER JOIN FPagos f on v.FPago=f.FPago " &
                                " WHERE " & wFiltro & " And v.caja<>0" &
                                " Group By CONVERT(date,v.fecha,3),v.Local,v.FPago,v.Caja, " &
                                " f.DescFPago,l.NombreLocal " &
                                " ORDER BY v.Local,v.Fecha"
        Dim wReporte As New ReporteCuadraturaCaja
        ModuloReporte = "CuadraturaCaja"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Cuadratura de Caja"
        Try
            VisorReportes.Show()
        Catch ex As Exception
        End Try
    End Sub
End Class