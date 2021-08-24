Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Runtime.InteropServices

<DebuggerNonUserCode()>
Public Class WinDeco
    <Category("### Banner ###"),
    Description("Texto del título de la ventana.")>
    Public Property TituloVentana As String
        Get
            Return Titulo.Text
        End Get
        Set(value As String)
            Titulo.Text = value
        End Set

    End Property

    <Category("### Banner ###"),
    Description("Muestra u oculta el título de la ventana.")>
    Public Property VerTitulo As Boolean
        Get
            Return Titulo.Visible
        End Get
        Set(value As Boolean)
            Titulo.Visible = value
        End Set

    End Property

    <Category("### Banner ###"),
    Description("Muestra u oculta el Logo.")>
    Public Property VerLogo As Boolean
        Get
            Return Logo.Visible
        End Get
        Set(value As Boolean)
            Logo.Visible = value
        End Set

    End Property

    <Category("### Banner ###"),
    Description("Muestra u oculta el botón maximizar.")>
    Public Property VerMaximizar As Boolean
        Get
            Return Maximizar.Visible
        End Get
        Set(value As Boolean)
            Maximizar.Visible = value
        End Set

    End Property
    <Category("### Banner ###"),
    Description("Muestra u oculta el botón minimizar.")>
    Public Property VerMinimizar As Boolean
        Get
            Return Minimizar.Visible
        End Get
        Set(value As Boolean)
            Minimizar.Visible = value
        End Set

    End Property
    <Category("### Banner ###"),
    Description("Muestra u oculta el botón cerrar.")>
    Public Property VerCerrar As Boolean
        Get
            Return Cerrar.Visible
        End Get
        Set(value As Boolean)
            Cerrar.Visible = value
        End Set

    End Property

    Private _alturaFooter As Integer = 60
    <Category("### Banner ###"),
    Description("Altura del footer.")>
    Public Property AlturaFooter As Integer
        Get
            Return _alturaFooter
        End Get
        Set(value As Integer)
            _alturaFooter = value
            Try
                If Not Me.Parent Is Nothing Then
                    Me.Parent.Invalidate()
                    Me.Invalidate()
                End If
            Catch ex As Exception

            End Try

        End Set

    End Property

    Private _bordeVentana As Integer = 2
    <Category("### Banner ###"),
    Description("Ancho del borde de la ventana.")>
    Public Property BordeVentana As Integer
        Get
            Return _bordeVentana
        End Get
        Set(value As Integer)
            _bordeVentana = value
            Try
                If Not Me.Parent Is Nothing Then
                    Me.Parent.Invalidate()
                    Me.Invalidate()
                End If
            Catch ex As Exception

            End Try

        End Set

    End Property

    Private _muestraBordeExterior As Boolean = True
    <Category("### Banner ###"),
    Description("Muestra u oculta el borde exterior")>
    Public Property MuestraBordeExterior As Integer
        Get
            Return _muestraBordeExterior
        End Get
        Set(value As Integer)
            _muestraBordeExterior = value
            Try
                If Not Me.Parent Is Nothing Then
                    Me.Parent.Invalidate()
                    Me.Invalidate()
                End If
            Catch ex As Exception

            End Try

        End Set

    End Property

#Region "Botones de Estado de Ventana"

    Private Sub Minimizar_Click(sender As Object, e As EventArgs) Handles Minimizar.Click

        If Not Minimizar.Visible Then
            Exit Sub
        End If

        Dim F As Form = Me.Parent
        F.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Cerrar_Click(sender As Object, e As EventArgs) Handles Cerrar.Click
        Dim F As Form = Me.Parent
        F.Close()
    End Sub

    Private Sub Maximizar_DoubleClick(sender As Object, e As EventArgs) Handles PanelBanner.DoubleClick, Logo.DoubleClick, Maximizar.Click, Titulo.DoubleClick

        If Not Maximizar.Visible Then
            Exit Sub
        End If

        Dim F As Form = Me.Parent
        If F.WindowState = FormWindowState.Maximized Then
            F.WindowState = FormWindowState.Normal
            Maximizar.Image = My.Resources.Resources.maximize12

        Else
            F.WindowState = FormWindowState.Maximized
            Maximizar.Image = My.Resources.Resources.restore12
        End If
        F.Invalidate()

    End Sub

#End Region

#Region "Movimiento de Ventana"

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Move_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, PanelBanner.MouseDown, Titulo.MouseDown, Logo.MouseDown
        Dim F As Form = Me.Parent
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - F.Left
        mousey = Windows.Forms.Cursor.Position.Y - F.Top
    End Sub

    Private Sub Move_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp, PanelBanner.MouseUp, Titulo.MouseUp, Logo.MouseUp
        drag = False
    End Sub

    Private Sub Move_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, PanelBanner.MouseMove, Titulo.MouseMove, Logo.MouseMove
        Dim F As Form = Me.Parent
        If drag Then
            F.Top = Windows.Forms.Cursor.Position.Y - mousey
            F.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

#End Region


    Private Sub Banner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Height = 50
            Logo.Location = New Point(Me.Width - (Logo.Width + ControlBox.Width), 1)

            Dim F As Form = Me.Parent

            Try
                F.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                AddHandler F.Paint, AddressOf Form_Paint
                'AddHandler F.Activated, AddressOf Form_Paint
                AddHandler PanelBanner.Paint, AddressOf Panel_OnPaint

            Catch ex As Exception

                If F.WindowState = FormWindowState.Normal Then
                    Maximizar.Image = My.Resources.Resources.maximize12
                Else
                    Maximizar.Image = My.Resources.Resources.restore12
                End If

            End Try

        Catch ex As Exception

        End Try

    End Sub

    Private SinDegradados As Boolean = False

    Private Sub Form_Paint(sender As Object, e As PaintEventArgs)
        Try
            Dim F As Form = Me.Parent
            Dim g As Graphics = F.CreateGraphics()
            g.SmoothingMode = SmoothingMode.AntiAlias

            'FONDO
            Dim rect As New Rectangle(0, Me.Height, F.Width, F.Height - (Me.Height + AlturaFooter))


            Using brushFondo As New LinearGradientBrush(rect, Color.FromArgb(29, 73, 140), Color.FromArgb(32, 44, 67), 90.0F)
                brushFondo.GammaCorrection = True
                e.Graphics.FillRectangle(brushFondo, rect)
            End Using



            'RELLENO
            rect.X += BordeVentana
            rect.Width -= (BordeVentana * 2)
            rect.Height -= (BordeVentana)

            If SinDegradados Then
                Using brushRelleno As New SolidBrush(Color.FromArgb(220, 230, 235))
                    e.Graphics.FillRectangle(brushRelleno, rect)
                End Using

            Else
                'Using brushRelleno As New LinearGradientBrush(rect, Color.Black, Color.Black, 90)
                '    Dim cb As New ColorBlend()
                '    cb.Positions = New Single() {0, 2 / 5.0F, 4 / 5.0F, 1}
                '    cb.Colors = New Color() {Color.White, Color.FromArgb(220, 230, 235), Color.FromArgb(220, 230, 235), Color.FromArgb(190, 205, 210)}
                '    brushRelleno.InterpolationColors = cb
                '    'brush.RotateTransform(90)
                '    e.Graphics.FillRectangle(brushRelleno, rect)
                'End Using


                Using brushRelleno As New LinearGradientBrush(rect, Color.White, Color.FromArgb(220, 230, 235), 90)
                    brushRelleno.GammaCorrection = True
                    e.Graphics.FillRectangle(brushRelleno, rect)
                End Using
            End If

            'FOOTER
            Dim rectF As New Rectangle(0, F.ClientRectangle.Height - AlturaFooter, F.ClientRectangle.Width, AlturaFooter)
            If SinDegradados Then
                Using brushFooter As New SolidBrush(Color.FromArgb(32, 44, 67))
                    e.Graphics.FillRectangle(brushFooter, rectF)
                End Using

            Else
                Using brushFooter As New LinearGradientBrush(rectF, Color.FromArgb(32, 44, 67), Color.FromArgb(20, 33, 55), 90.0F)
                    brushFooter.GammaCorrection = True
                    e.Graphics.FillRectangle(brushFooter, rectF)
                End Using
            End If


            Dim lightBorder As New Rectangle(0, 0, Parent.Width - 1, Parent.Height - 1)
            If MuestraBordeExterior Then
                Using brushRelleno As New Pen(Color.FromArgb(32, 44, 67), 1)
                    e.Graphics.DrawRectangle(brushRelleno, lightBorder)
                End Using
            End If


            'Dim hdc As IntPtr = GetWindowDC(Me.Handle)
            'g = Graphics.FromHdc(hdc)

            'If MuestraBordeExterior Then
            '    Using brushRelleno As New Pen(Color.FromArgb(32, 44, 67), 1)
            '        g.DrawRectangle(brushRelleno, New Rectangle(0, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height + 1))
            '    End Using
            'End If

            'g.Dispose()
            'ReleaseDC(Me.Handle, hdc)

        Catch ex As Exception

        End Try

    End Sub


    <DllImport("user32")>
    Private Shared Function GetWindowDC(hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32")>
    Private Shared Function ReleaseDC(hwnd As IntPtr, hdc As IntPtr) As IntPtr
    End Function

    Private Sub WinDeco_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'Try
        '    Dim hdc As IntPtr = GetWindowDC(sender.Handle)
        '    Dim g As Graphics = Graphics.FromHdc(hdc)

        '    If MuestraBordeExterior Then
        '        Using brushRelleno As New Pen(Color.FromArgb(32, 44, 67), 1)
        '            g.DrawRectangle(brushRelleno, New Rectangle(0, 0, sender.ClientRectangle.width - 1, sender.ClientRectangle.height + 1))
        '        End Using
        '    End If

        '    g.Dispose()
        '    ReleaseDC(sender.Handle, hdc)


        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Panel_OnPaint(sender As Object, e As PaintEventArgs)
        Try
            Dim hdc As IntPtr = GetWindowDC(sender.Handle)
            Dim g As Graphics = Graphics.FromHdc(hdc)

            If MuestraBordeExterior Then
                Using brushRelleno As New Pen(Color.FromArgb(32, 44, 67), 1)
                    g.DrawRectangle(brushRelleno, New Rectangle(0, 0, sender.ClientRectangle.width - 1, sender.ClientRectangle.height + 1))
                End Using
            End If

            g.Dispose()
            ReleaseDC(sender.Handle, hdc)


        Catch ex As Exception

        End Try

    End Sub
End Class
'@FFG
