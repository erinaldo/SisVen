Public Class ManCliente

    Implements iFormulario

    Dim wMensaje As String = ""
    Dim wCiudad, wComuna, wTipo As String
    Public wFormulario As String

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        wFormulario = "Cancelar"
        Close()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos()
        xCliente.Clear()
        xCliente.Focus()
    End Sub

    Sub LimpiarCampos()
        xNombre.Clear()
        xRut.Text = "  .   .   -"
        xFantasia.Clear()
        xDireccion.Clear()
        xCiudad.Clear()
        cCiudad.SelectedIndex = 0
        xComuna.Clear()
        cComuna.SelectedIndex = 0
        xGiro.Clear()
        xSucursal.Clear()
        xTelefono.Clear()
        xContacto.Clear()
        xEmail.Clear()
        oProveedor.Checked = False
        oComision.Checked = False
        wTipo = ""
        wCiudad = ""
        wComuna = ""
        xCupoMax.Clear()
        xVencimiento.Clear()
        xCiudad.Tag = ""
        xComuna.Tag = ""
        cEstado.SelectedIndex = 1
        xCliente.Tag = -1
    End Sub

    Private Sub ManCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cCiudad.LoadItems("Ciudades", "NombreCiudad")
        cCiudad.SelectedIndex = 0
        cComuna.LoadItems("Comunas", "NombreComuna")
        cComuna.SelectedIndex = 0
        cEstado.LoadItems("Estados", "DescEstado", " Tipo='A'")
        cEstado.SelectedIndex = 1
        Auditoria(Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub cCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cCiudad.SelectedIndexChanged
        If Trim(cCiudad.Text) = "" Then
            xCiudad.Clear()
            Exit Sub
        End If
        Ciu = SQL("SELECT Ciudad FROM Ciudades WHERE NombreCiudad='" & Trim(cCiudad.Text) & "'")
        If Ciu.EOF Then
            MsgError("La Ciudad Seleccionada no está Disponible")
            cCiudad.LoadItems("Ciudades", "NombreCiudad")
            cCiudad.SelectedIndex = 0
            Exit Sub
        End If
        wCiudad = Ciu.Fields("Ciudad").Text
        xCiudad.Text = wCiudad
        xCiudad.Tag = wCiudad
        cCiudad.Tag = Trim(cCiudad.Text)
    End Sub

    Private Sub xCiudad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCiudad.Validating
        If Trim(xCiudad.Text) = "" Then
            cCiudad.SelectedIndex = -1
            Exit Sub
        End If
        If xCiudad.Tag = Trim(xCiudad.Text) Then Exit Sub

        Uni = SQL("SELECT NombreCiudad FROM Ciudades WHERE Ciudad='" & Trim(xCiudad.Text) & "'")
        If Uni.EOF Then
            MsgError("La Ciudad Ingresada no Existe")
            xCiudad.Clear()
            cCiudad.SelectedIndex = -1
            Exit Sub
        End If
        wCiudad = Uni.Fields("NombreCiudad").Text
        cCiudad.Text = wCiudad
        cCiudad.Tag = wCiudad
        xCiudad.Tag = Trim(xCiudad.Text)
    End Sub

    Private Sub cComuna_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cComuna.SelectedIndexChanged
        If Trim(cComuna.Text) = "" Then
            xComuna.Clear()
            Exit Sub
        End If
        Ciu = SQL("SELECT Comuna FROM Comunas WHERE NombreComuna='" & Trim(cComuna.Text) & "'")
        If Ciu.EOF Then
            MsgError("La Comuna Seleccionada no está Disponible")
            cComuna.LoadItems("Comunas", "NombreComuna")
            cComuna.SelectedIndex = 0
            Exit Sub
        End If
        wComuna = Ciu.Fields("Comuna").Text
        xComuna.Text = wComuna
        xComuna.Tag = wComuna
        cCiudad.Tag = Trim(cCiudad.Text)
    End Sub

    Private Sub xComuna_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xComuna.Validating
        If Trim(xComuna.Text) = "" Then
            cComuna.SelectedIndex = -1
            Exit Sub
        End If
        If xComuna.Tag = Trim(xComuna.Text) Then Exit Sub

        Uni = SQL("SELECT NombreComuna FROM Comunas WHERE Comuna='" & Trim(xComuna.Text) & "'")
        If Uni.EOF Then
            MsgError("La Comuna Ingresada no Existe")
            xComuna.Clear()
            cComuna.SelectedIndex = -1
            Exit Sub
        End If
        wComuna = Uni.Fields("NombreComuna").Text
        cComuna.Text = wComuna
        cComuna.Tag = wComuna
        xComuna.Tag = Trim(xComuna.Text)
    End Sub

    Private Sub cEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cEstado.SelectedIndexChanged
        If Trim(cEstado.Text) = "" Then
            Exit Sub
        End If
        Est = SQL("SELECT Estado FROM Estados WHERE DescEstado='" & Trim(cEstado.Text) & "' and Tipo='A'")
        If Est.EOF Then
            MsgError("El Estado Seleccionado no está Disponible")
            cEstado.LoadItems("Estados", "DescEstado", " Tipo='A'")
            cEstado.SelectedIndex = 0
            Exit Sub
        End If
        cEstado.Tag = Est.Fields("Estado").Text
    End Sub

    Sub GuardarDatos()
        Cli.Fields("Cliente").Value = Trim(xCliente.Text)
        Cli.Fields("Nombre").Value = Trim(xNombre.Text)
        Cli.Fields("Rut").Value = Trim(xRut.Text)
        Cli.Fields("Fantasia").Value = Trim(xFantasia.Text)
        Cli.Fields("Direccion").Value = Trim(xDireccion.Text)
        Cli.Fields("Ciudad").Value = Trim(xCiudad.Text)
        Cli.Fields("Comuna").Value = Trim(xComuna.Text)
        Cli.Fields("Giro").Value = Trim(xGiro.Text)
        Cli.Fields("Telefonos").Value = Trim(xTelefono.Text)
        Cli.Fields("Contacto").Value = Trim(xContacto.Text)
        Cli.Fields("Email").Value = Trim(xEmail.Text)
        Cli.Fields("Proveedor").Value = oProveedor.Checked
        Cli.Fields("Comision").Value = oComision.Checked
        Cli.Fields("CupoMax").Value = Val(xCupoMax.Text)
        Cli.Fields("Vencimiento").Value = Val(xVencimiento.Text)
        Cli.Fields("Estado").Value = cEstado.Tag
        Cli.Fields("Tipo").Value = wTipo
        Cli.Fields("Glosa").Value = xSucursal.Text.Trim
        Cli.Update()
    End Sub

    Sub CargarDatos()
        xCliente.Text = Val(Cli.Fields("Cliente").Value)
        xNombre.Text = Trim(Cli.Fields("Nombre").Value)
        xRut.Text = Trim(Cli.Fields("Rut").Value)
        xFantasia.Text = Trim(Cli.Fields("Fantasia").Value)
        xDireccion.Text = Trim(Cli.Fields("Direccion").Value)
        xCiudad.Text = Trim(Cli.Fields("Ciudad").Value)
        xCiudad_Validating(Nothing, Nothing)
        xComuna.Text = Trim(Cli.Fields("Comuna").Value)
        xComuna_Validating(Nothing, Nothing)
        xGiro.Text = Trim(Cli.Fields("Giro").Value)
        xTelefono.Text = Trim(Cli.Fields("Telefonos").Value)
        xContacto.Text = Trim(Cli.Fields("Contacto").Value)
        xEmail.Text = Trim(Cli.Fields("Email").Value)
        oProveedor.Checked = Cli.Fields("Proveedor").Value
        oComision.Checked = Cli.Fields("Comision").Value
        xCupoMax.Text = Trim(Cli.Fields("CupoMax").Value)
        xVencimiento.Text = Trim(Cli.Fields("Vencimiento").Value)
        LlenarEstado(Cli.Fields("Estado").Text)
        cEstado.Tag = Cli.Fields("Estado").Text
        xSucursal.Text = Cli.Fields("Glosa").Value
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating

        If Trim(xCliente.Text) = "" Then Exit Sub
        ValidarDigitos(sender, 0)
        If xCliente.Tag = Val(xCliente.Text) Then Exit Sub
        xCliente.Tag = Val(xCliente.Text)
        Cli = SQL("SELECT * FROM Clientes WHERE Cliente=" & Val(xCliente.Text) & "")
        If Cli.EOF Then
            LimpiarCampos()
            Exit Sub
        End If
        CargarDatos()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If Val(xCliente.Text) <= 0 Then
            MsgError("Debe ingresar un Cliente")
            xCliente.Focus()
            Exit Sub
        End If
        If Trim(xNombre.Text) = "" Then
            MsgError("Debe ingresar un Nombre")
            xNombre.Focus()
            Exit Sub
        End If
        If Trim(xRut.Text) = ".   .   -" Then
            MsgError("Debe ingresar un Rut")
            xRut.Focus()
            Exit Sub
        Else
            If Not ValidarRut(xRut.Text) Then
                MsgError("Rut Incorrecto")
                xRut.Focus()
                Exit Sub
            End If
        End If
        'If Not wTipo = "P" AndAlso Not wTipo = "M" Then
        '    If Trim(xFantasia.Text) = "" Then
        '        MsgError("Debe ingresar una Fantasia")
        '        xFantasia.Focus()
        '        Exit Sub
        '    End If

        '    Swap = SQL("SELECT Cliente,Nombre FROM Clientes WHERE Fantasia = '" & Trim(xFantasia.Text) & "' and Cliente <> " & Num(xCliente.Text) & "")
        '    If Swap.RecordCount > 0 Then
        '        MsgError("Nombre de Fantasía ya está utilizado en el Cliente: " & Trim(Swap.Fields("Cliente").Value) & vbCrLf + "Nombre Cliente: " & Trim(Swap.Fields("Nombre").Value))
        '        xFantasia.Focus()
        '        Exit Sub
        '    End If
        'End If

        If xDireccion.Text = "" Then
            MsgError("Debe ingresar una Dirección")
            xDireccion.Focus()
            Exit Sub
        End If
        If xCiudad.Text = "" Then
            MsgError("Debe ingresar una Ciudad")
            cCiudad.Focus()
            Exit Sub
        End If
        If xComuna.Text = "" Then
            MsgError("Debe ingresar una Comuna")
            cComuna.Focus()
            Exit Sub
        End If

        If cEstado.Text = "" Then
            MsgError("Debe ingresar un Estado")
            cEstado.Focus()
            Exit Sub
        End If
        If xGiro.Text = "" Then
            MsgError("Debe ingresar  un Giro")
            xGiro.Focus()
            Exit Sub
        End If
        Cli = SQL("SELECT * FROM Clientes WHERE Cliente=" & Val(xCliente.Text) & "")
        If Cli.EOF Then
            If Pregunta("¿Desea Agregar este Cliente?") Then
                Cli.AddNew()
                wMensaje = "Cliente creado correctamente"
                Auditoria(Text, PR_INGRESAR, "", 0)
            Else
                Exit Sub
            End If
        Else
            If Pregunta("¿Desea Modificar este Cliente?") Then
                wMensaje = "Cliente modificado correctamente"
                Auditoria(Text, PR_MODIFICAR, "", 0)
            Else
                Exit Sub
            End If
        End If
        GuardarDatos()
        Mensaje(wMensaje)
        If wFormulario = "Ingreso_Atencion_Paciente" Or wFormulario = "Ingreso_Atencion_Medico" Then
            Close()
            Exit Sub
        End If
        xCliente.Clear()
        LimpiarCampos()
        xCliente.Focus()
    End Sub

    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        If Trim(xCliente.Text) = "" Then
            MsgError("No hay un Cliente cargado")
            xCliente.Focus()
            Exit Sub
        End If
        Cli = SQL("SELECT Cliente FROM Clientes WHERE Cliente=" & Val(xCliente.Text) & "")
        If Cli.EOF Then
            MsgError("El Cliente ingresado no existe")
            LimpiarCampos()
            xCliente.Clear()
            xCliente.Focus()
            Exit Sub
        End If
        Cli = SQL("SELECT TOP 1 Cliente FROM DocumentosG WHERE Cliente=" & Val(xCliente.Text) & "")

        If Not Cli.EOF Then
            MsgError("No se Puede eliminar este Cliente, Se encuentra utilizado en otra Tabla")
            Exit Sub
        End If

        Cli = SQL("SELECT TOP 1 Cliente FROM DocumentosP WHERE Cliente=" & Val(xCliente.Text) & "")

        If Not Cli.EOF Then
            MsgError("No se Puede eliminar este Cliente, Se encuentra utilizado en otra Tabla")
            Exit Sub
        End If

        If Cli.EOF Then
            If Pregunta("¿Desea eliminar este Cliente?") Then
                SQL("DELETE Clientes WHERE Cliente=" & Val(xCliente.Text) & "")
                Auditoria(Text, "Eliminó Cliente", "", 0)
                Mensaje("Cliente eliminado correctamente")
                LimpiarCampos()
                xCliente.Clear()
                xCliente.Focus()
            End If
        End If
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVencimiento.KeyPress, xCupoMax.KeyPress, xCliente.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
    End Sub

    Private Sub xCupoMax_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xVencimiento.Validating, xCupoMax.Validating
        ValidarDigitos(sender, 0)
    End Sub

    Private Sub xNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTelefono.KeyPress, xRut.KeyPress, xNombre.KeyPress, xGiro.KeyPress, xFantasia.KeyPress, xEmail.KeyPress, xDireccion.KeyPress, xContacto.KeyPress, xComuna.KeyPress, xCiudad.KeyPress, xSucursal.KeyPress
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
    End Sub

    Private Sub xRut_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xRut.Validating
        If xRut.Text <> "  .   .   -" Then
            If Not ValidarRut(Trim(xRut.Text)) Then
                MsgError("El Rut es Incorrecto")
                xRut.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Modulo = "ManCliente"
        BuscarClientes.Show()
        BuscarClientes.BringToFront()
    End Sub
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub bNuevo_Click(sender As Object, e As EventArgs) Handles bNuevo.Click
        xCliente.Text = SacaUltimo("Clientes", "Cliente")
    End Sub

    Private Sub xNombre_TextChanged(sender As Object, e As EventArgs) Handles xNombre.TextChanged

    End Sub

    Sub LlenarEstado(ByVal wEstado As String)
        Est = SQL("SELECT DescEstado FROM Estados WHERE Estado='" & wEstado & "' AND Tipo='A'")
        If Est.EOF Then
            MsgError("El Estado no está disponible")
            Exit Sub
        End If
        cEstado.Text = Est.Fields("DescEstado").Text
    End Sub

    Private Sub xRut_GotFocus(sender As Object, e As EventArgs) Handles xRut.GotFocus
        xRut.SelectAll()
    End Sub
End Class