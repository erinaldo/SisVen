Imports System.ComponentModel
Imports SisVen

Public Class ManUsuarios
    Implements iFormulario

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Limpiar()
        xCodigo.Clear()
        LimpiarNuevo()
        xCodigo.Focus()
    End Sub

    Private Sub LimpiarNuevo()
        xNombreUsr.Clear()
        xRut.Text = "__.___.___-_"
        xAcceso.Text = ""
        cAcceso.Text = ""
        xClave.Clear()
        zClave.Text = ""
        cLocal.Text = ""
        oFuncionario.Checked = False
        xCliente.Clear()
        xNumero.Clear()
        xNombreCliente.Clear()
        Aceptar.Enabled = True
        Eliminar.Enabled = False
        xLocal.Clear()
        cLocal.Text = ""
        Aceptar.Text = "Ingresar"
    End Sub



    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar_Empresa.Click
        Modulo = "Mantenedor_Usuarios"
        BuscarClientes.Show()
    End Sub

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Me.Close()
    End Sub

    Private Sub ManUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Accesos()
        Cargar_Locales()
        xCodigo.Focus()
        Auditoria(Text, "Ingreso", "", 0)
        If UsuarioActual = "PED" Then
            zClave.Visible = True
        End If
    End Sub

#Region "Cargar_Campos"
    Private Sub xAcceso_Validating(sender As Object, e As EventArgs) Handles xAcceso.Validating
        If Trim(xAcceso.Text <> "") Then
            xAcceso.Text.Replace("-", "")
            xAcceso.Text = Val(xAcceso.Text)
            If Programador = True Then
                Acc = SQL("SELECT NombreAcceso FROM Accesos WHERE Acceso = " & Val(xAcceso.Text) & "")
            Else
                Acc = SQL("SELECT NombreAcceso FROM Accesos WHERE Acceso <> 9 and acceso = " & Val(xAcceso.Text) & "")
            End If
            If Acc.EOF = True Then
                xAcceso.Focus()
                xAcceso.SelectAll()
                cAcceso.Text = ""
                MsgError("No existe el Acceso")
                Exit Sub
            Else
                cAcceso.Text = Acc.Fields("NombreAcceso").Text
            End If
        End If
    End Sub
    Private Sub Cargar_Accesos()
        cAcceso.Items.Clear()
        cAcceso.Items.Add("")
        If Programador = True Then
            Swap = SQL("SELECT NombreAcceso FROM Accesos")
        Else
            Swap = SQL("SELECT NombreAcceso FROM Accesos WHERE Acceso <> 9")
        End If
        If Swap.RecordCount > 0 Then
            While Not Swap.EOF
                cAcceso.Items.Add(Swap.Fields("NombreAcceso").Value)
                Swap.MoveNext()
            End While
            cAcceso.SelectedIndex = -1
        End If
    End Sub

    Private Sub Cargar_Locales()
        cLocal.Items.Clear()
        cLocal.Items.Add("")
        Swap = SQL("SELECT Nombrelocal FROM locales")
        If Swap.RecordCount > 0 Then
            While Not Swap.EOF
                cLocal.Items.Add(Swap.Fields("nombrelocal").Text)
                Swap.MoveNext()
            End While
            cLocal.SelectedIndex = -1
        End If
    End Sub
    Private Sub xLocal_Validating(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles xLocal.Validating
        If xLocal.Text <> "" Then
            Loc = SQL("SELECT * FROM locales WHERE local=" & Val(xLocal.Text) & "")
            If Loc.EOF = True Then
                xLocal.Focus()
                xLocal.SelectAll()
                cLocal.Text = ""
                MsgError("No existe el Local")
                Exit Sub
            Else
                cLocal.SelectedItem = Loc.Fields("NombreLocal").Text
            End If
        End If
    End Sub


    Private Sub cLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If Trim(cLocal.Text <> "") Then
            If Not Buscar("Locales", "NombreLocal", Trim(cLocal.Text), "*", "") Then
                cLocal.Focus()
                xLocal.Clear()
                MsgError("No existe el Local")
                Exit Sub
            Else
                Cli = Swap
                Cli = SQL("SELECT Local,NombreLocal FROM Locales WHERE NombreLocal='" + cLocal.Text + "'")
                xLocal.Text = Trim(Cli.Fields("Local").Value)
            End If
        End If
    End Sub

    Private Sub cAcceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cAcceso.SelectedIndexChanged
        If Trim(cAcceso.Text <> "") Then
            If Programador = True Then
                Acc = SQL("SELECT Acceso FROM Accesos WHERE NombreAcceso='" & Trim(cAcceso.Text) & "'")
            Else
                Acc = SQL("SELECT Acceso FROM Accesos WHERE Acceso<>9 and NombreAcceso='" & Trim(cAcceso.Text) & "'")
            End If
            If Acc.EOF = True Then
                cAcceso.Focus()
                xAcceso.Text = ""
                MsgError("No Existe el Tipo de Acceso")
                Exit Sub
            Else
                xAcceso.Text = Acc.Fields("Acceso").Text
            End If
        End If
    End Sub

#End Region

    Public Sub xCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCodigo.KeyPress
        If e.KeyChar = vbCr Then
            xNombreUsr.Focus()
        End If
    End Sub


    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        If Pregunta("¿Desea eliminar este usuario?") Then
            If xCodigo.Text = "" Then
                MsgError("Debe Especificar el Usuario")
                xCodigo.Focus()
            Else
                Usr = SQL("SELECT Usuario FROM Usuarios WHERE usuario='" & Trim(xCodigo.Text) & "' except SELECT Usuario FROM Auditoria")
                If Usr.EOF = False Then
                    If Buscar("Usuarios", "Usuario", xCodigo.Text, "*", "") Then
                        Swap.Delete()
                        Auditoria(Text, "Eliminación de Usuario", "", 0)
                        Limpiar()
                        Mensaje("Usuario Eliminado")
                    End If
                Else
                    MsgError("No Puedes eliminar este Usuario ya que se esta siendo Utilizado")
                    xCodigo.Focus()
                    Exit Sub
                End If

            End If

        End If
    End Sub


    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click

        Dim wAccesoAnterior As Double = -1

        If xNombreUsr.Text = "" Then
            MsgError("Debes Especificar un Nombre")
            xNombreUsr.Focus()
            Exit Sub
        End If

        If Not ValidarRut(xRut.Text) Then
            MsgError("Rut Incorrecto")
            xRut.Focus()
            Exit Sub
        End If
        If xRut.Text = "" Then
            MsgError("Debes Especificar un Rut")
            xRut.Focus()
            Exit Sub
        End If

        If Val(xAcceso.Text) = 0 Then
            xAcceso.Text = 0
        End If

        If xClave.Text = "" Then
            MsgError("Debes especificar una Contraseña")
            xClave.Focus()
            Exit Sub
        End If

        If xLocal.Text = "" Or cLocal.Text = "" Then
            MsgError("Ingrese Local")
            xLocal.Focus()
            Exit Sub
        End If

        If Val(xCliente.Text) = 0 Then
            xCliente.Text = 0
        End If

        If Val(xNumero.Text) = 0 Then
            MsgError("Debe ingresar un Código de Vendedor")
            xNumero.Focus()
            Exit Sub
        End If

        If Not Buscar("Clientes", "Cliente", Trim(xCliente.Text), "*", "") Then
            xCliente.Focus()
            xCliente.SelectAll()
            xNombreCliente.Clear()
            MsgError("No existe la Empresa")
            Exit Sub
        End If

        If xCodigo.Text <> "" And xNombreUsr.Text <> "" Then
            If Not Buscar("Usuarios", "Usuario", xCodigo.Text, "*", "") Then
                Usr = Swap
                If Pregunta("Esta seguro de crear al Usuario " & xCodigo.Text) Then
                    Usr.AddNew()
                    Usr.Fields("Usuario").Value = Trim(xCodigo.Text)
                    Usr.Fields("NombreUsr").Value = Trim(xNombreUsr.Text)
                    Usr.Fields("Rut").Value = Trim(xRut.Text)
                    Usr.Fields("Acceso").Value = Trim(xAcceso.Text)
                    Usr.Fields("Clave").Value = Crypt(xClave.Text)
                    Usr.Fields("Local").Value = Trim(xLocal.Text)
                    Usr.Fields("Base").Value = "0"
                    Usr.Fields("Bruto").Value = "0"
                    Usr.Fields("Funcionario").Value = If(oFuncionario.Checked, 1, 0)
                    Usr.Fields("AFP").Value = "0"
                    Usr.Fields("Salud").Value = "0"
                    Usr.Fields("Vigencia").Value = CDate("01/01/3000 00:00:00.000")
                    Usr.Fields("Gratificacion").Value = "0"
                    Usr.Fields("Movilizacion").Value = "0"
                    Usr.Fields("Cargas").Value = "0"
                    Usr.Fields("Pactado").Value = "0"
                    Usr.Fields("Empresa").Value = Val(xCliente.Text)
                    Usr.Fields("Codigo").Value = Val(xNumero.Text)
                    Usr.Update()

                    ActualizarPermisosUsuario(Usr.Fields("Usuario").Value, Val(Usr.Fields("Acceso").Value))

                    Mensaje("Usuario Creado")
                    Auditoria(Text, "Creación de Usuario", "", 0)
                    Limpiar()
                Else
                    xCodigo.Focus()
                End If
            Else
                Usr = Swap
                If Pregunta("Esta seguro de modificar el Usuario " & xCodigo.Text) Then
                    Usr.Fields("NombreUsr").Value = Trim(xNombreUsr.Text)
                    Usr.Fields("Rut").Value = Trim(xRut.Text)

                    wAccesoAnterior = Usr.Fields("Acceso").Value

                    Usr.Fields("Acceso").Value = Trim(xAcceso.Text)
                    Usr.Fields("Clave").Value = Crypt(Trim(xClave.Text))
                    Usr.Fields("Local").Value = Trim(xLocal.Text)
                    Usr.Fields("Base").Value = "0"
                    Usr.Fields("Bruto").Value = "0"
                    Usr.Fields("Funcionario").Value = If(oFuncionario.Checked, 1, 0)
                    Usr.Fields("AFP").Value = "0"
                    Usr.Fields("Salud").Value = "0"
                    Usr.Fields("Vigencia").Value = CDate("01/01/3000 00:00:00.000")
                    Usr.Fields("Gratificacion").Value = "0"
                    Usr.Fields("Movilizacion").Value = "0"
                    Usr.Fields("Cargas").Value = "0"
                    Usr.Fields("Pactado").Value = "0"
                    Usr.Fields("Empresa").Value = Val(xCliente.Text)
                    Usr.Fields("Codigo").Value = Val(xNumero.Text)
                    Usr.Update()
                    Mensaje("Datos Modificados")
                    Auditoria(Text, "Modificación de Usuario", "", 0)

                    If wAccesoAnterior <> Usr.Fields("Acceso").Value Then
                        ActualizarPermisosUsuario(Usr.Fields("Usuario").Value, Val(Usr.Fields("Acceso").Value))
                    End If

                    Limpiar()

                Else
                    xCodigo.Focus()
                End If



            End If
        Else
            Mensaje("Debe ingresar un Nombre")
            xNombreUsr.Focus()
        End If

    End Sub


    Private Sub ActualizarPermisosUsuario(ByVal wUsuario As String, ByVal wAcceso As Double)

        Usr = SQL("SELECT Distinct Usuario FROM Usuarios WHERE Usuario = '" & wUsuario & "'")
        If Usr.RecordCount > 0 Then
            While Not Usr.EOF
                SQL("DELETE FROM PermisosUSuario WHERE Usuario = '" & wUsuario & "'")
                SQL("INSERT INTO PermisosUsuario (Usuario, Modulo) " &
                "SELECT '" & Usr.Fields("Usuario").Text & "' AS Usuario, Modulo FROM PermisosAcceso WHERE Acceso = " & wAcceso)
                Usr.MoveNext()
            End While
        End If

    End Sub

    Private Sub xRut_Validating(sender As Object, e As EventArgs) Handles xRut.Validating
        If xRut.Text <> "  .   .   -" Then
            If Not ValidarRut(xRut.Text) Then
                MsgError("Rut Incorrecto")
                xRut.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Public Sub xCodigo_Validating(sender As Object, e As EventArgs) Handles xCodigo.Validating

        If xCodigo.Text <> "" Then
            If Not Buscar("Usuarios", "usuario", Trim(xCodigo.Text), "*", "") Then
                Usr = Swap
                Aceptar.Enabled = True
                Aceptar.Text = "Ingresar"
                Eliminar.Enabled = False
                LimpiarNuevo()
            Else
                Usr = Swap
                xNombreUsr.Text = Trim(Usr("NombreUsr").Value)
                xRut.Text = Usr("Rut").Value
                xAcceso.Text = Trim(Usr("Acceso").Value)
                If Buscar("Accesos", "Acceso", xAcceso.Text, "*", "") Then
                    cAcceso.Text = Swap("NombreAcceso").Value
                End If
                xNumero.Text = Trim(Usr("Codigo").Value)
                xClave.Text = Trim(Descripta(Usr("Clave").Value))
                zClave.Text = Trim(Descripta(Usr("Clave").Value))
                If Not IsDBNull(Usr("Local").Value) Then
                    'xLocal.Text = Usr("Local").Value
                    If Buscar("Locales", "Local", Usr("Local").Value) Then
                        Loc = Swap
                        cLocal.SelectedItem = Loc.Fields("NombreLocal").Text
                    End If
                Else
                    xLocal.Text = ""
                    cLocal.SelectedIndex = -1
                End If

                oFuncionario.Checked = Usr.Fields("Funcionario").Value

                If Buscar("Clientes", "Cliente", Usr("Empresa").Value, "Nombre", "") Then
                    xCliente.Text = Trim(Usr("Empresa").Value)
                    xNombreCliente.Text = Trim(Swap("Nombre").Value)
                End If
                Aceptar.Enabled = True
                Eliminar.Enabled = True
                Aceptar.Text = "Modificar"
                Eliminar.Text = "Eliminar"
            End If
            xCodigo.Text = UCase(xCodigo.Text)
        Else
            Limpiar()
        End If

    End Sub

    Private Sub xNombreUsr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xNombreUsr.KeyPress
        If e.KeyChar = vbCr Then
            xRut.Focus()
        End If
    End Sub

    Private Sub xRut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xRut.KeyPress
        If e.KeyChar = vbCr Then
            xAcceso.Focus()
        End If
    End Sub

    Private Sub xAcceso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xAcceso.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            xClave.Focus()
        End If
    End Sub

    Private Sub xClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xClave.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            xLocal.Focus()
        End If
    End Sub

    Private Sub xLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xLocal.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            xCliente.Focus()
        End If
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            Aceptar.Focus()
        End If
    End Sub

    Private Sub xRut_Enter(sender As Object, e As EventArgs) Handles xRut.Enter
        xRut.SelectAll()
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As CancelEventArgs) Handles xCliente.Validating
        ValidarDigitos(sender)
        If Val(xCliente.Text) > 0 Then

            If ValidarCliente(Val(xCliente.Text)) Then
                xNombreCliente.Text = Cli.Fields("Nombre").Text
            Else
                MsgError("El Cliente ingresado no existe o no corresponde al Centro de Distribución actual.")
                xCliente.Clear()
                xNombreCliente.Clear()
                xCliente.Focus()
            End If
        Else
            xCliente.Clear()
            xNombreCliente.Clear()
        End If
    End Sub

    Private Sub xCodigo_TextChanged(sender As Object, e As EventArgs) Handles xCodigo.TextChanged

    End Sub

    Private Sub xNombreUsr_TextChanged(sender As Object, e As EventArgs) Handles xNombreUsr.TextChanged

    End Sub

    Private Sub xRut_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles xRut.MaskInputRejected

    End Sub

    Private Sub xAcceso_TextChanged(sender As Object, e As EventArgs) Handles xAcceso.TextChanged

    End Sub

    Private Sub xClave_TextChanged(sender As Object, e As EventArgs) Handles xClave.TextChanged

    End Sub

    Private Sub xLocal_TextChanged(sender As Object, e As EventArgs) Handles xLocal.TextChanged

    End Sub

    Private Sub xNombreCliente_TextChanged(sender As Object, e As EventArgs) Handles xNombreCliente.TextChanged

    End Sub

    Private Sub Ver_Click(sender As Object, e As EventArgs) Handles Ver.Click
        Dim wQuery As String
        wQuery = "SELECT Usuario as 'Usuario', NombreUSR as 'Nombre Usuario', Rut as 'Rut Usuario', Acceso From Usuarios"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Usuario", Me, "Usuarios", xCodigo)
    End Sub

    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub

    Private Sub xAcceso_Validating(sender As Object, e As CancelEventArgs) Handles xAcceso.Validating

    End Sub
End Class