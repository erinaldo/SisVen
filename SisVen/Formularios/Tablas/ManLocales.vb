Imports System.ComponentModel

Public Class ManLocales
    Implements iFormulario

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub ManLocales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItems(cCiudades, "Ciudades", "NombreCiudad")
        LoadItems(cComunas, "Comunas", "NombreComuna")
        bNuevo_Click()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
        xLocal.Focus()
    End Sub

    Private Sub bNuevo_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bNuevo.Click

    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Buscador.Show()
        ' Buscador.Configurar("L.Local AS 'Local', L.NombreLocal as 'Nombre Local',Cl.Nombre as 'Cliente',Ci.NombreCiudad as 'Ciudad', co.NombreComuna as 'Comuna'",
        '"Locales L JOIN Ciudades Ci on l.ciudad = ci.ciudad JOIN Comunas Co on L.Comuna = co.Comuna JOIN Clientes cl on l.cliente = cl.Cliente",
        '    "L.NombreLocal", Me, "Locales", xLocal)
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        ValidarDigitos(e)
        e.NextControl(xNombre)
    End Sub
    Private Sub xLocal_Validating(sender As Object, e As CancelEventArgs) Handles xLocal.Validating
        If xLocal.Text <> "" Then
            Dim lc = SQL("SELECT * FROM LOCALES WHERE LOCAL = " & xLocal.Text & "")
            If lc.RecordCount = 1 Then
                xNombre.Text = lc.Fields("NombreLocal").Text
                xCliente.Text = lc.Fields("Cliente").Text
                xCliente.Validate
                xRut.Text = lc.Fields("RutLocal").Text
                xGiroLocal.Text = lc.Fields("GiroLocal").Text
                xDireccion.Text = lc.Fields("DirLocal").Text
                cCiudades.Text = BuscarCampo("Ciudades", "NombreCiudad", "Ciudad", lc.Fields("Ciudad").Text)
                cComunas.Text = BuscarCampo("Comunas", "NombreComuna", "Comuna", lc.Fields("Comuna").Text)
                xTelefono.Text = lc.Fields("TelefonosLocal").Text
                oVenta.Checked = lc.Fields("EnvioPrecios").Text
                oPrecio.Checked = lc.Fields("CargadeVentas").Text
                oElectronica.Checked = lc.Fields("FElectronica").Text
                xIP.Text = lc.Fields("IP_DTE").Text
                xClave.Text = lc.Fields("Llave").Text
                xNumeroR.Text = lc.Fields("NResolucion").Text
                dFechaR.Value = lc.Fields("FResolucion").Text
                xAteco.Text = lc.Fields("ATECO").Text
                xSII.Text = lc.Fields("SII").Text
                oFV.Checked = lc.Fields("FV_Elect").Text
                oGD.Checked = lc.Fields("GD_Elect").Text
                oNC.Checked = lc.Fields("NC_Elect").Text
                oFE.Checked = lc.Fields("FE_Elect").Text
                oND.Checked = lc.Fields("ND_Elect").Text
                oFC.Checked = lc.Fields("FC_Elect").Text
                oBO.Checked = lc.Fields("BV_Elect").Text
                oBE.Checked = lc.Fields("BE_Elect").Text
                oEnvioAuto.Checked = lc.Fields("Envio_Automatico").Text
                If lc.Fields("Logo").Value.ToString <> Nothing Then pLogo.Image = ArrayImagen(lc.Fields("Logo").Value)
                bGuardar.Text = "Modificar"
                Else
                bGuardar.Text = "Guardar"
                Limpiar()
            End If
        End If
    End Sub

    Private Sub xClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        e.NextControl(xRut)
    End Sub

    Private Sub xClientes_Validating(Optional sender As Object = Nothing, Optional e As CancelEventArgs = Nothing) Handles xCliente.Validating
        If xCliente.Text <> "" Then
            xNombreCliente.Text = BuscarCampo("Clientes", "Nombre", "Cliente", xCliente.Text)
        End If
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        Buscador.Show()
        'Buscador.Configurar("Cliente,Nombre", "Clientes", "Cliente", Me, "Clientes", xCliente)
    End Sub

    Private Sub oVenta_CheckedChanged(sender As Object, e As EventArgs) Handles oVenta.CheckedChanged, oPrecio.CheckedChanged, oElectronica.CheckedChanged
        Dim wCheckBox As CheckBox = DirectCast(sender, CheckBox)
        wCheckBox.ForeColor = If(wCheckBox.Checked, Color.White, Color.Black)
        If oElectronica.Checked Then
            gElectronica.Enabled = True
        Else
            gElectronica.Enabled = False
        End If
    End Sub

    Private Sub xNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNombre.KeyPress
        e.NextControl(xCliente)
    End Sub

    Private Sub xRut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xRut.KeyPress
        e.NextControl(xGiroLocal)
    End Sub

    Private Sub xGiroLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xGiroLocal.KeyPress
        e.NextControl(xDireccion)
    End Sub

    Private Sub xDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDireccion.KeyPress
        e.NextControl(cCiudades)
    End Sub

    Private Sub cCiudades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cCiudades.KeyPress
        e.NextControl(cComunas)
    End Sub

    Private Sub cComunas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cComunas.KeyPress
        e.NextControl(xTelefono)
    End Sub
    Private Sub xIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xIP.KeyPress
        e.NextControl(xClave)
    End Sub

    Private Sub xClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xClave.KeyPress
        e.NextControl(xNumeroR)
    End Sub

    Private Sub xNumeroR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNumeroR.KeyPress
        e.NextControl(dFechaR)
    End Sub

    Private Sub dFechaR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dFechaR.KeyPress
        e.NextControl(xAteco)
    End Sub

    Private Sub xAteco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xAteco.KeyPress
        e.NextControl(xSII)
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub
    Sub Limpiar()
        For Each wcontrol In gPrincipal.Controls
            If wcontrol.GetType Is GetType(TextBox) Then wcontrol.Clear()
            If wcontrol.GetType Is GetType(ComboBox) Then wcontrol.SelectedIndex = -1
            If wcontrol.GetType Is GetType(CheckBox) Then wcontrol.checked = False
        Next
        For Each wcontrol In gElectronica.Controls
            If wcontrol.GetType Is GetType(TextBox) Then wcontrol.Clear()
            If wcontrol.GetType Is GetType(ComboBox) Then wcontrol.SelectedIndex = -1
            If wcontrol.GetType Is GetType(CheckBox) Then wcontrol.checked = False
        Next
        pLogo.Image = Nothing
        bGuardar.Text = "Guardar"
        bNuevo_Click()
    End Sub

    Private Sub ManLocales_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'xNombre.Focus()
    End Sub

    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        If xLocal.Text.Trim <> "" Then
            If ValidarEliminar("Local", xLocal.Text, "Locales") Then
                MsgError("No se puede eliminar el Local")
            Else
                SQL("DELETE FROM Locales WHERE Local = '" & xLocal.Text.Trim & "'")
                MsgBox("Local eliminada correctamente")
                Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                Limpiar()
            End If
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim wAuditoria = ""
        For Each wControl In gPrincipal.Controls
            If wControl.GetType Is GetType(TextBox) Or wControl.GetType Is GetType(ComboBox) Then
                If wControl.text = "" Then
                    MsgError("Indique " & wControl.Tag)
                    wControl.Focus
                    Exit Sub
                End If
            End If
        Next
        If oElectronica.Checked Then
            For Each wControl In gElectronica.Controls
                If wControl.GetType Is GetType(TextBox) Or wControl.GetType Is GetType(ComboBox) Then
                    If wControl.text = "" Then
                        MsgError("Indique " & wControl.Tag)
                        wControl.Focus
                        Exit Sub
                    End If
                End If
            Next
        End If
        Dim wMensaje As String
        Dim lc = SQL("SELECT * FROM LOCALES WHERE LOCAL = '" & xLocal.Text & "'")

        If lc.RecordCount = 0 Then
            lc.AddNew()
            wMensaje = "Local guardado correctamente"
            wAuditoria = PR_GUARDAR
        Else
            wMensaje = "Local Modificado correctamente"
            wAuditoria = PR_MODIFICAR
        End If

        lc.Fields("NombreLocal").Value = Trim(xNombre.Text)
        lc.Fields("Cliente").Value = Trim(xCliente.Text)
        lc.Fields("RutLocal").Value = Trim(xRut.Text)
        lc.Fields("GiroLocal").Value = Trim(xGiroLocal.Text)
        lc.Fields("DirLocal").Value = Trim(xDireccion.Text)
        lc.Fields("Ciudad").Value = BuscarCampo("Ciudades", "Ciudad", "NombreCiudad", Trim(cCiudades.Text))
        lc.Fields("Comuna").Value = BuscarCampo("Comunas", "Comuna", "NombreComuna", Trim(cComunas.Text))
        lc.Fields("TelefonosLocal").Value = Trim(xTelefono.Text)
        lc.Fields("EnvioPrecios").Value = oPrecio.Checked
        lc.Fields("CargadeVentas").Value = oVenta.Checked

        lc.Fields("FElectronica").Value = oElectronica.Checked
        lc.Fields("IP_DTE").Value = Trim(xIP.Text)
        lc.Fields("FV_Elect").Value = oFV.Checked
        lc.Fields("GD_Elect").Value = oGD.Checked
        lc.Fields("NC_Elect").Value = oNC.Checked
        lc.Fields("FE_Elect").Value = oFE.Checked
        lc.Fields("ND_Elect").Value = oND.Checked
        lc.Fields("FC_Elect").Value = oFC.Checked
        lc.Fields("BV_Elect").Value = oBO.Checked
        lc.Fields("BE_Elect").Value = oBE.Checked
        lc.Fields("Llave").Value = Trim(xClave.Text)
        lc.Fields("NResolucion").Value = Val(xNumeroR.Text)
        lc.Fields("FResolucion").Value = FormatDateTime(dFechaR.Value, 2)
        lc.Fields("ATECO").Value = Trim(xAteco.Text)
        If pLogo.Image IsNot Nothing Then lc.Fields("Logo").Value = ImagenArray(pLogo.Image)
        lc.Fields("SII").Value = Trim(xSII.Text)
        lc.Fields("Envio_Automatico").Value = oEnvioAuto.Checked

        lc.Update()
        Mensaje(wMensaje)
        Auditoria(Me.Text, wAuditoria, "", 0)
        Limpiar()
    End Sub

    Private Sub bCargar_Click(sender As Object, e As EventArgs) Handles bCargar.Click
        fLogo.Filter = "Imagen |*.bmp;*.jpg ;*.gif;*.png"
        fLogo.FileName = ""
        If fLogo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim img = fLogo.FileName
            pLogo.Image = System.Drawing.Bitmap.FromFile(img)
        End If
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub xNombreCliente_TextChanged(sender As Object, e As EventArgs) Handles xNombreCliente.TextChanged

    End Sub

    Private Sub xTelefono_TextChanged(sender As Object, e As EventArgs) Handles xTelefono.TextChanged

    End Sub

    Private Sub cComunas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cComunas.SelectedIndexChanged

    End Sub

    Private Sub cCiudades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cCiudades.SelectedIndexChanged

    End Sub

    Private Sub xDireccion_TextChanged(sender As Object, e As EventArgs) Handles xDireccion.TextChanged

    End Sub

    Private Sub xGiroLocal_TextChanged(sender As Object, e As EventArgs) Handles xGiroLocal.TextChanged

    End Sub

    Private Sub xCliente_TextChanged(sender As Object, e As EventArgs) Handles xCliente.TextChanged

    End Sub

    Private Sub xNombre_TextChanged(sender As Object, e As EventArgs) Handles xNombre.TextChanged

    End Sub

    Private Sub xLocal_TextChanged(sender As Object, e As EventArgs) Handles xLocal.TextChanged

    End Sub

    Private Sub xIP_TextChanged(sender As Object, e As EventArgs) Handles xIP.TextChanged

    End Sub

    Private Sub xClave_TextChanged(sender As Object, e As EventArgs) Handles xClave.TextChanged

    End Sub

    Private Sub xNumeroR_TextChanged(sender As Object, e As EventArgs) Handles xNumeroR.TextChanged

    End Sub

    Private Sub dFechaR_ValueChanged(sender As Object, e As EventArgs) Handles dFechaR.ValueChanged

    End Sub

    Private Sub xAteco_TextChanged(sender As Object, e As EventArgs) Handles xAteco.TextChanged

    End Sub
End Class