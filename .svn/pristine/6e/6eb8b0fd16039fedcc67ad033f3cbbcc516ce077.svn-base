Imports System.ComponentModel

Public Class ManPOS
    Implements iFormulario
    Private Sub ManPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        bGuardar.Text = "Guardar"
        xPOS.Focus()

        cTipoPOS.Items.Clear()
        Swap = SQL("Select * from TipoPOS Order by DescTipoPOS")
        While Not Swap.EOF
            DoEvents()
            cTipoPOS.Items.Add(Swap("DescTipoPOS").Value.ToString.Trim)
            Swap.MoveNext()
        End While
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Private Sub xPOS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xPOS.KeyPress
        If e.KeyChar = vbCr Then
            e.NextControl(xNombre)
        End If
    End Sub

    Private Sub xPOS_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xPOS.Validating
        Try
            If xPOS.Text.Trim <> "" Then
                POS = SQL("SELECT * FROM POS WHERE POS = '" & xPOS.Text.Trim & "'")
                If POS.RecordCount > 0 Then
                    xNombre.Text = POS.Fields("NombrePOS").Text.Trim
                    cTipoPOS.Text = BuscarCampo("TipoPOS", "DescTipoPOS", "TipoPOS", POS.Fields("TipoPOS").Text.Trim)
                    xNSerie.Text = POS.Fields("NSerie").Text.Trim
                    xCaja.Text = POS.Fields("Caja").Text.Trim
                    xFechaVenc.Value = POS.Fields("FechaVigencia").Text.Trim
                    oActivo.Checked = POS.Fields("Activo").Value
                    bGuardar.Text = "Modificar"
                Else
                    xNombre.Focus()
                    bGuardar.Text = "Guardar"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wAuditoria = ""

        If xPOS.Text = "" Then
            MsgError("Ingrese N° POS único")
            xPOS.Focus()
            Exit Sub
        End If
        If xNombre.Text = "" Then
            MsgError("Ingrese Nombre del POS")
            xNombre.Focus()
            Exit Sub
        End If

        Dim wMensaje As String
        POS = SQL("SELECT * FROM POS WHERE POS = " & xPOS.Text.Trim)
        If POS.RecordCount = 0 Then
            POS.AddNew()
            wMensaje = "POS guardado corretamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "POS modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        POS.Fields("POS").Value = xPOS.Text.Trim
        POS.Fields("NombrePOS").Value = xNombre.Text.Trim
        POS.Fields("TipoPOS").Value = BuscarCampo("TipoPOS", "TipoPOS", "DescTipoPOS", cTipoPOS.Text.Trim)
        POS.Fields("Caja").Value = Val(xCaja.Text.Trim)
        POS.Fields("NSerie").Value = xNSerie.Text.Trim
        POS.Fields("FechaVigencia").Value = CDate(Format(xFechaVenc.Value, "dd/MM/yyyy"))
        POS.Fields("Activo").Value = oActivo.Checked
        POS.Update()

        MsgBox(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xPOS.Clear()
        xNombre.Clear()
        cTipoPOS.Text = ""
        xFechaVenc.Value = Date.Now
        xNSerie.Clear()
        xCaja.Clear()
        oActivo.Checked = False

        bGuardar.Text = "Guardar"
        xPOS.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If xPOS.Text.Trim <> "" Then
                SQL("DELETE FROM POS WHERE POS = '" & xPOS.Text.Trim & "'")
                MsgBox("POS eliminado correctamente")
                Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                Limpiar()
                xPOS.Focus()
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNombre.KeyPress
        If e.KeyChar = vbCr Then
            e.NextControl(cTipoPOS)
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT POS, NombrePOS as Descripción FROM POS"
        Buscador.Show()
        Buscador.Configurar(wQuery, "NombrePOS", Me, "POS", xPOS)
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub ManTipoMov_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        xPOS.Focus()
    End Sub

    Private Sub xNSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNSerie.KeyPress
        If e.KeyChar = vbCr Then
            e.NextControl(xFechaVenc)
        End If
    End Sub
    Private Sub xCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCaja.KeyPress
        If e.KeyChar = vbCr Then
            e.NextControl(xNSerie)
        End If
    End Sub
End Class