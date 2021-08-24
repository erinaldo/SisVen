Imports System.ComponentModel

Public Class ManCorrelativos
    Implements iFormulario
    Private Sub ManCorrelativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"

        Loc = SQL("Select * from Locales order by Local")
        cLocal.Items.Add("")
        While Not Loc.EOF
            cLocal.Items.Add(Loc.Fields("NombreLocal").Value.ToString.Trim)
            If gMonoLocal Then
                cLocal.Text = Loc("NombreLocal").Value
            End If
            Loc.MoveNext()
        End While

        LoadItems(cTipoDoc, "TipoDoc", "DescTipoDoc", "Cod_SII>0")
        xLocal.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        ValidarDigitos(e)
        e.NextControl(xCaja)
    End Sub

    Private Sub xLocal_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xLocal.Validating
        Try
            If xLocal.Text.Trim <> "" Then
                Dim sl = SQL("SELECT * FROM Locales WHERE Local = '" & Val(xLocal.Text) & "'")
                If sl.RecordCount > 0 Then
                    cLocal.Text = sl.Fields("NombreLocal").Text.Trim
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wAuditoria = "", xTD As String

        If xLocal.Text = "" Then
            MsgError("Ingrese Numero de Local")
            xLocal.Focus()
            Exit Sub
        End If
        If cTipoDoc.Text = "" Then
            MsgError("Ingrese Tipo de Documento")
            cTipoDoc.Focus()
            Exit Sub
        End If
        If xCorrelativo.Text = "" Then
            MsgError("Ingrese Correlativo")
            xCorrelativo.Focus()
            Exit Sub
        End If

        If Val(xInicial.Text) > Val(xFinal.Text) Then
            MsgError("Rango de Correlativos Incorrecto")
            xInicial.Focus()
            Exit Sub
        End If
        If Val(xCorrelativo.Text) < Val(xInicial.Text) Or Val(xCorrelativo.Text) > Val(xFinal.Text) Then
            MsgError("Correlativo fuera del rango permitido")
            xCorrelativo.Focus()
            Exit Sub
        End If
        If CDate(xFechaCAF.Value) > Now.Date Then
            MsgError("Fecha CAF no puede superior a la actual")
            xFechaCAF.Focus()
            Exit Sub
        End If
        xTD = BuscarTipoDoc(cTipoDoc.Text)

        Dim wMensaje As String
        Dim sl = SQL("SELECT * FROM Correlativos WHERE Local = '" & Val(xLocal.Text.Trim) & "' AND Caja = '" & xCaja.Text & "'" &
                     " AND TipoDoc = '" & xTD & "'")
        If sl.RecordCount = 0 Then
            sl.AddNew()
            wMensaje = "Correlativo guardado correctamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "Correlativo modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        sl.Fields("Local").Value = Val(xLocal.Text)
        sl.Fields("TipoDoc").Value = xTD
        sl.Fields("Caja").Value = Val(xCaja.Text)
        sl.Fields("Correlativo").Value = Val(xCorrelativo.Text)
        sl.Fields("Inicial").Value = Val(xInicial.Text)
        sl.Fields("Final").Value = Val(xFinal.Text)
        sl.Fields("FechaCAF").Value = xFechaCAF.Value
        sl.Update()
        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Public Function BuscarTipoDoc(ByVal wTipoDoc As String) As String
        If wTipoDoc.Trim = "" Then Return ""
        Dim td = SQL("SELECT TipoDoc From TipoDoc WHERE DescTipoDoc = '" & wTipoDoc.Trim & "'")
        Return td.Fields("TipoDoc").Value.ToString.Trim
    End Function
    Public Function BuscaNombrerTipoDoc(ByVal wTipoDoc As String) As String
        If wTipoDoc.Trim = "" Then Return ""
        Dim td = SQL("SELECT DescTipoDoc From TipoDoc WHERE TipoDoc = '" & wTipoDoc.Trim & "'")
        Return td.Fields("DescTipoDoc").Value.ToString.Trim
    End Function
    Private Sub Limpiar()
        xLocal.Clear()
        cLocal.SelectedIndex = -1
        xCorrelativo.Clear()
        xInicial.Clear()
        xFinal.Clear()
        xCaja.Clear()
        xFechaCAF.Value = Now.Date
        bGuardar.Text = "Guardar"
        cTipoDoc.SelectedIndex = -1
        xLocal.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub xCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCaja.KeyPress
        e.NextControl(xCorrelativo)
    End Sub

    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xLocal.Focus()
    End Sub
    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.NextControl(bGuardar)
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        ValidarDigitos(e)
        e.NextControl(bGuardar)
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs)
        xLocal.Focus()
        bGuardar.Text = "Guardar"
    End Sub

    Private Sub bEliminar_Click(sender As Object, e As EventArgs)
        Auditoria(Me.Text, PR_ELIMINAR, "", 0)
    End Sub

    Sub Sacar_Datos()
        If xCaja.Text = "" Then xCaja.Text = "0"
        Cor = SQL("SELECT * FROM Correlativos WHERE Local = '" & Val(xLocal.Text.Trim) & "' AND Caja = '" & xCaja.Text & "' AND TipoDoc = '" & BuscarTipoDoc(cTipoDoc.Text) & "'")
        If Cor.RecordCount = 1 Then
            xLocal.Text = Cor.Fields("Local").Value
            xLocal_Validating()
            xCaja.Text = Cor.Fields("Caja").Text
            cTipoDoc.Text = BuscaNombrerTipoDoc(Cor.Fields("TipoDoc").Value)
            xCorrelativo.Text = Cor.Fields("Correlativo").Value
            xInicial.Text = Cor.Fields("Inicial").Value
            xFinal.Text = Cor.Fields("Final").Value
            xFechaCAF.Value = Cor.Fields("FechaCAF").Value
            bGuardar.Text = "Modificar"
        Else
            xLocal_Validating()
            xCaja.Text = 0
            xCorrelativo.Text = 0
            xInicial.Text = 0
            xFinal.Text = 0
            xFechaCAF.Value = CDate("01/01/2000")
            bGuardar.Text = "Ingresar"
        End If
    End Sub


    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If cLocal.Text.ToString.Trim <> "" Then
            Loc = SQL("Select Local from Locales where NombreLocal = '" + cLocal.Text.ToString.Trim + "'")
            If Loc.RecordCount > 0 Then
                xLocal.Text = Loc.Fields("Local").Value
            End If
        End If
        Sacar_Datos()
    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        Sacar_Datos()
    End Sub

    Private Sub xCaja_TextChanged(sender As Object, e As EventArgs) Handles xCaja.TextChanged
        Sacar_Datos()
    End Sub

    Private Sub xCaja_LostFocus(sender As Object, e As EventArgs) Handles xCaja.LostFocus
        Sacar_Datos()
    End Sub
End Class