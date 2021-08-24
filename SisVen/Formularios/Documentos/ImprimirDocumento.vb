Public Class ImprimirDocumento
    Private Sub ImprimirDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cLocal.LoadItems("Locales", "NombreLocal")
        cTipoDoc.LoadItems("TipoDoc", "DescTipoDoc")
        cLocal.SelectedIndex = 0
        cTipoDoc.SelectedIndex = 0
    End Sub
    Sub LimpiarCampos()
        cLocal.SelectedIndex = 0
        cTipoDoc.SelectedIndex = 0
        xNumDoc.Clear()
        cLocal.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        Dim wReporte As Object
        Dim wTipoDoc, wLocal As String
        If Trim(cLocal.Text) = "" Then
            MsgError("Debes desigar un Local")
            cLocal.Focus()
            Exit Sub
        End If

        If Trim(cTipoDoc.Text) = "" Then
            MsgError("Debes desigar un Tipo de Documento")
            cTipoDoc.Focus()
            Exit Sub
        End If

        Doc = SQL("SELECT TipoDoc FROM TipoDoc WHERE DescTipoDoc='" & Trim(cTipoDoc.Text) & "'")
        If Doc.EOF Then
            MsgError("Tipo de Documento ingresado no Existe")
            cTipoDoc.Focus()
            Exit Sub
        Else
            wTipoDoc = Doc.Fields("TipoDoc").Text
        End If

        Loc = SQL("SELECT Local FROM Locales WHERE NombreLocal='" & Trim(cLocal.Text) & "'")
        If Loc.EOF Then
            MsgError("El Local ingresado no Existe")
            cLocal.Focus()
            Exit Sub
        Else
            wLocal = Loc.Fields("Local").Text
        End If


        Dim wQuery As String = "SELECT v.Local,v.FPago,v.Caja,f.DescFPago,l.NombreLocal," &
                                " CONVERT(date,v.fecha,3) as Fecha,Sum(v.Total) as Total " &
                                " FROM Ventas v INNER JOIN Locales l on v.Local=l.Local " &
                                " INNER JOIN FPagos f on v.FPago=f.FPago " &
                                " Group By CONVERT(date,v.fecha,3),v.Local,v.FPago,v.Caja, " &
                                " f.DescFPago,l.NombreLocal " &
                                " ORDER BY v.Local,v.Fecha"
        Select Case wTipoDoc
            Case "B" 'Boleta de Venta

            Case "C" 'Cotización

            Case "F" 'Factura de Venta
                wReporte = New ReporteFacturas
            Case "G" 'Guía de Despacho

            Case "H" 'Nota de Debito

            Case "J" 'Guía de Compra

            Case "K" 'Nota de Debito

            Case "N" 'Nota de Crédito

            Case "O" 'Orden de Compra

            Case "Q" 'Nota de Credito de Compra

            Case "S" 'Sin Documento

            Case "T" 'Nota de Venta

            Case "U" 'Factura de Compra

            Case "Z" 'Boleta de Compra

            Case Else
                MsgError("No hay reporte para esta opción")
                Exit Sub
        End Select

        ModuloReporte = "CuadraturaCaja"
        VisorReportes.VisorParametros(wQuery, wReporte)
        VisorReportes.WinDeco1.TituloVentana = "Listado de Cuadratura de Caja"
        VisorReportes.Show()
    End Sub
End Class