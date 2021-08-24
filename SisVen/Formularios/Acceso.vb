Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Friend Class Acceso
    Inherits Windows.Forms.Form

    Private Sub Acceso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        xUsuario.Focus()
        If gProgramador Then
            xUsuario.Text = "PED"
            xClave.Text = "1623"
            Aceptar_Click(Nothing, Nothing)
            Me.Hide()
        End If
    End Sub

    Private Sub Acceso_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        If gServidores.Visible Then
            Me.Height = 390
            Me.Width = 372
            Me.gCentroDistribucion.Location = New Point(13, 195)
            Me.gUsuario.Location = New Point(13, 249)
        Else
            Me.Height = 304
            Me.Width = 372
            Me.gCentroDistribucion.Location = New Point(13, 108)
            Me.gUsuario.Location = New Point(13, 162)
        End If


        If Not Parametros() Then
            MsgError("Error al cargar parámetros del sistema (AppSettings)")
            End
        End If
        If Not Abrir() Then
            End
        End If

        If Not CargarLocales() Then
            MsgError("Ha ocurrido un error en la carga de Locales")
            End
        End If

        CargarServidores()

        AddHandler cServidor.SelectedIndexChanged, AddressOf cServidor_SelectedIndexChanged

    End Sub

    Sub CargarServidores()
        cServidor.LoadItems("Servidores", "Nombre", "IP", "~")
        cServidor.Items.Add("App.Config" & " ~ " & P_SERVIDOR.ToString)
        cServidor.SelectedItem = "App.Config" & " ~ " & P_SERVIDOR.ToString
    End Sub

    Function CargarLocales() As Boolean
        CargarLocales = True
        Try
            cLocal.LoadItems("Locales", "Local", "NombreLocal", "~")
            cLocal.SelectedIndex = 0
            If cLocal.Items.Count = 0 Then
                CargarLocales = False
            End If
        Catch ex As Exception
            CargarLocales = False
        End Try
    End Function
    Private Sub xClave_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles xClave.Enter
        With xClave
            .SelectionStart = 0
            .SelectionLength = Len(xClave.Text)
        End With
    End Sub

    Private Sub xClave_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles xClave.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            Aceptar.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub xUsuario_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles xUsuario.Enter

        xUsuario.SelectionStart = 0
        xUsuario.SelectionLength = Len(xUsuario.Text)

    End Sub
    Private Sub xUsuario_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles xUsuario.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        KeyAscii = Asc(UCase(Chr(KeyAscii)))
        If KeyAscii = System.Windows.Forms.Keys.Return Then System.Windows.Forms.SendKeys.Send("{TAB}")
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub xUsuario_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles xUsuario.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Try
            If xUsuario.Text <> "" Then
                If Not Buscar("Usuarios", "Usuario", Trim(xUsuario.Text), "*", "") Then
                    Usr = Swap
                    Mensaje("El usuario no existe")
                    xUsuario.Text = ""
                    Cancel = True
                Else
                    Usr = Swap
                    If Val(Usr.Fields("Local").Value) > 0 Then
                        Buscar("Locales", "Local", Usr.Fields("Local").Value, "*", "")
                        cLocal.SelectedItem = Swap.Fields("Local").Value.ToString.Trim & " - " & Swap.Fields("NombreLocal").Value.ToString.Trim
                        If Usr.Fields("Acceso").Text = 9 Then
                            cLocal.Enabled = True
                        Else
                            cLocal.Enabled = False
                        End If
                    Else
                        cLocal.Enabled = True
                    End If
                    If Val(Usr.Fields("Acceso").Value) = 9 Then
                        gServidores.Visible = True
                        Me.Height = 390
                        Me.Width = 372
                        Me.gCentroDistribucion.Location = New Point(13, 195)
                        Me.gUsuario.Location = New Point(13, 249)
                        If Usr.Fields("Local").Value <> 0 Then
                            cLocal.SelectedItem = Swap.Fields("Local").Text & " - " & Swap.Fields("NombreLocal").Text
                        End If
                    Else
                        gServidores.Visible = False
                        Me.Height = 304
                        Me.Width = 372
                        Me.gCentroDistribucion.Location = New Point(13, 108)
                        Me.gUsuario.Location = New Point(13, 162)
                        lIP.Text = ""
                        cServidor.Items.Clear()
                        P_SERVIDOR = My.Settings.SERVIDOR
                        If Not Abrir() Then
                            Exit Sub
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        End
    End Sub

    Private Sub Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aceptar.Click
        Dim zc As String

        'Setear si el sistema es Demo o no
        gDemo = oDemo.Checked

        Try
            If xUsuario.Text = "" Then
                MsgError(("Falta ingresar un Usuario"))
                xUsuario.Focus()
                Exit Sub
            End If

            If xClave.Text = "" Then
                MsgError(("Falta ingresar una Clave"))
                xClave.Focus()
                Exit Sub
            End If

            If cLocal.Text = "" Then
                MsgError("Debe seleccionar un Local.")
                cLocal.Focus()
                Exit Sub
            End If

            If Not Buscar("Usuarios", "Usuario", Trim(xUsuario.Text), "*", "") Then
                Auditoria(Me.Text, "Usuario No Existe", xUsuario.Text, xClave.Text)
                Usr = Swap
                Mensaje("El Usuario ingresado no Existe")
                xUsuario.Text = ""
                xClave.Text = ""
                xUsuario.Focus()
            Else
                Usr = Swap
                zc = Descripta(Swap.Fields("Clave").Text)
                If UCase(xClave.Text) = UCase(zc) Then
                    Ubicacion = 0
                    Dim wLocal As String
                    wLocal = cLocal.Text.Replace(" ~ ", "")
                    Loc = SQL("SELECT Local, RutLocal, NombreLocal FROM locales WHERE CAST(Local as varchar) + NombreLocal = '" & wLocal & "'")
                    If Loc.EOF = False Then
                        LocalUsuario = Usr.Fields("Local").Value
                        Ubicacion = Loc.Fields("Local").Value
                        LocalActual = Ubicacion
                        NombreLocalActual = Loc.Fields("NombreLocal").Text

                        If Not LocalUsuario = 0 AndAlso LocalUsuario <> Ubicacion Then
                            MsgError("El usuario ingresado no tiene autorización para seleccionar este Centro de Distribución")
                            Exit Sub
                        End If
                    Else
                        MsgError("Local No Encontrado.")
                        Exit Sub
                    End If

                    UsuarioActual = Usr.Fields("Usuario").Text
                    NombreUsuarioActual = Usr.Fields("NombreUsr").Text
                    ClienteUsuarioActual = Usr.Fields("Empresa").Text
                    LocalActual = Ubicacion
                    NombreLocalActual = Loc.Fields("NombreLocal").Text
                    AccesoUsuario = Val(Usr.Fields("Acceso").Text)


                    If AccesoUsuario > 5 Then
                        Supervisor = True
                    Else
                        Supervisor = False
                    End If

                    If AccesoUsuario >= 8 Then
                        ADMINISTRADOR = True
                    Else
                        ADMINISTRADOR = False
                    End If

                    Cli = SQL("SELECT TOP 1 * FROM Clientes WHERE Rut = '" & Loc.Fields("RutLocal").Value.ToString & "'")
                    If Cli.RecordCount = 0 Then
                        MsgError("El Rut asociado al Local no es válido, o no existe el Cliente.")
                        Exit Sub
                    End If

                    ClienteLocalActual = Cli.Fields("Cliente").Value
                    FantasiaClienteLocal = Cli.Fields("Fantasia").Text

                    If Usr.Fields("Acceso").Value = 9 Then
                        Programador = True
                    Else
                        Programador = False
                    End If

                    Auditoria(Me.Text, "Acceso al Sistema", xUsuario.Text, 0)
                    Me.Hide()
                    Menu_Principal.Show()
                Else
                    Auditoria(Me.Text, "Clave Incorrecta", xUsuario.Text, xClave.Text)
                    Mensaje("La Clave es Incorrecta")
                    xClave.Text = ""
                    xClave.Focus()
                End If
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

#Region "MoverVentana"

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Move_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, pbBanner.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Move_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp, pbBanner.MouseUp
        drag = False
    End Sub

    Private Sub Move_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, pbBanner.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

#End Region


    Private Sub Acceso_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Using pen As New Pen(Color.FromArgb(1, 26, 103))
            Dim rect As Rectangle = DisplayRectangle
            rect.Width -= 1
            rect.Height -= 1
            e.Graphics.DrawRectangle(pen, rect)
        End Using
    End Sub

    Private Sub cLocal_KeyDown(sender As Object, e As KeyEventArgs) Handles cLocal.KeyDown, cServidor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Aceptar.Focus()
        End If
    End Sub

    Private Sub cServidor_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cServidor.Text = "" Then Exit Sub

        If miBd.State = 0 Then
            lIP.Text = cServidor.Text.Split("~")(1).Trim
            P_SERVIDOR = cServidor.Text.Split("~")(1).Trim
            If Not Abrir() Then
                Exit Sub
            End If
        End If

        If Trim(cServidor.Text) = "App.Config" Then
            P_SERVIDOR = My.Settings.SERVIDOR
        Else
            Loc = SQL("SELECT * FROM Servidores WHERE Nombre+' ~ '+Ip='" & Trim(cServidor.Text) & "'")
            If Loc.RecordCount <= 0 Then
                MsgError("No se encontró el Servidor seleccionado")
                cServidor.SelectedIndex = -1
                lIP.Text = ""
                Exit Sub
            End If
            lIP.Text = Loc.Fields("IP").Text
            P_SERVIDOR = Loc.Fields("IP").Text
            If P_SERVIDOR = "25.12.227.182" Then
                P_DBASE = "Wikets"
            End If
        End If
        If Not Abrir() Then
            Exit Sub
        End If

        If Not CargarLocales() Then
            MsgError("Error al cargar Locales")
            Exit Sub
        End If
    End Sub



    <DllImport("user32")>
    Private Shared Function GetWindowDC(hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32")>
    Private Shared Function ReleaseDC(hwnd As IntPtr, hdc As IntPtr) As IntPtr
    End Function

    Private Sub Panel_OnPaint(sender As Object, e As PaintEventArgs) Handles gUsuario.Paint
        Try
            Dim hdc As IntPtr = GetWindowDC(sender.Handle)
            Dim g As Graphics = Graphics.FromHdc(hdc)

            Dim wListaControles = New List(Of Control)
            wListaControles.Add(xUsuario)
            wListaControles.Add(xClave)

            For Each wControl In wListaControles
                Using brushRelleno As New Pen(Color.FromArgb(255, 255, 255), 2)
                    g.DrawRectangle(brushRelleno, New Rectangle(wControl.Location.X, wControl.Location.Y, wControl.ClientRectangle.Width, wControl.ClientRectangle.Height))
                End Using

                DrawRoundedRectangle(g, New Rectangle(wControl.Location.X - 2, wControl.Location.Y - 2,
                                                      wControl.ClientRectangle.Width + 2, wControl.ClientRectangle.Height + 2),
                                     New Pen(Color.FromArgb(133, 157, 178), 1), 3)
            Next

            g.Dispose()
            ReleaseDC(sender.Handle, hdc)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles xClave.Leave, xUsuario.Leave, xUsuario.Enter, xClave.Enter
        gUsuario.Invalidate()
    End Sub

    Private Sub cServidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cServidor.KeyPress
        If e.KeyChar = vbCr Then
            xUsuario.Focus()
        End If
    End Sub

    Private Sub cLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cLocal.KeyPress
        If e.KeyChar = vbCr Then
            xUsuario.Focus()
        End If
    End Sub

    Private Sub xUsuario_TextChanged(sender As Object, e As EventArgs) Handles xUsuario.TextChanged

    End Sub

    Private Sub cServidor_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cServidor.SelectedIndexChanged

    End Sub
End Class