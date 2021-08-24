<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContadoresDTE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.gDatosCliente = New System.Windows.Forms.GroupBox()
        Me.bBuscarCli = New System.Windows.Forms.Button()
        Me.xNombre = New System.Windows.Forms.TextBox()
        Me.xRut = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.xF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xF1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.bTotales = New System.Windows.Forms.Button()
        Me.bRecibidos = New System.Windows.Forms.Button()
        Me.bEmitidos = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.xOCr = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.xNDr = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.xNCr = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.xGDr = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.xFVr = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.xFEr = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.xFCr = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.xBVr = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.xOCe = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.xNDe = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.xNCe = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.xGDe = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.xFVe = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.xFEe = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.xFCe = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.xBVe = New System.Windows.Forms.TextBox()
        Me.xTotal = New System.Windows.Forms.TextBox()
        Me.xRecibidos = New System.Windows.Forms.TextBox()
        Me.xEmitidos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.gDatosCliente.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(617, 365)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(99, 36)
        Me.bCancelar.TabIndex = 74
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
        '
        'gDatosCliente
        '
        Me.gDatosCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gDatosCliente.BackColor = System.Drawing.Color.Transparent
        Me.gDatosCliente.Controls.Add(Me.bBuscarCli)
        Me.gDatosCliente.Controls.Add(Me.xNombre)
        Me.gDatosCliente.Controls.Add(Me.xRut)
        Me.gDatosCliente.Controls.Add(Me.Label1)
        Me.gDatosCliente.Enabled = False
        Me.gDatosCliente.Location = New System.Drawing.Point(12, 123)
        Me.gDatosCliente.Name = "gDatosCliente"
        Me.gDatosCliente.Size = New System.Drawing.Size(704, 49)
        Me.gDatosCliente.TabIndex = 75
        Me.gDatosCliente.TabStop = False
        '
        'bBuscarCli
        '
        Me.bBuscarCli.Location = New System.Drawing.Point(677, 18)
        Me.bBuscarCli.Name = "bBuscarCli"
        Me.bBuscarCli.Size = New System.Drawing.Size(21, 20)
        Me.bBuscarCli.TabIndex = 130
        Me.bBuscarCli.Text = "+"
        Me.bBuscarCli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bBuscarCli.UseVisualStyleBackColor = True
        Me.bBuscarCli.Visible = False
        '
        'xNombre
        '
        Me.xNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xNombre.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.xNombre.Location = New System.Drawing.Point(174, 18)
        Me.xNombre.MaxLength = 50
        Me.xNombre.Name = "xNombre"
        Me.xNombre.ReadOnly = True
        Me.xNombre.Size = New System.Drawing.Size(501, 23)
        Me.xNombre.TabIndex = 129
        '
        'xRut
        '
        Me.xRut.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xRut.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.xRut.Location = New System.Drawing.Point(71, 18)
        Me.xRut.Mask = "##,###,###-A"
        Me.xRut.Name = "xRut"
        Me.xRut.ReadOnly = True
        Me.xRut.Size = New System.Drawing.Size(95, 23)
        Me.xRut.TabIndex = 128
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.bBuscar)
        Me.GroupBox2.Controls.Add(Me.xF2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.xF1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(704, 61)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscar.Location = New System.Drawing.Point(562, 13)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(113, 42)
        Me.bBuscar.TabIndex = 9
        Me.bBuscar.Text = "Buscar Información"
        Me.bBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscar.UseVisualStyleBackColor = False
        '
        'xF2
        '
        Me.xF2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.xF2.Location = New System.Drawing.Point(312, 13)
        Me.xF2.Name = "xF2"
        Me.xF2.Size = New System.Drawing.Size(106, 22)
        Me.xF2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(284, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "al"
        '
        'xF1
        '
        Me.xF1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.xF1.Location = New System.Drawing.Point(174, 13)
        Me.xF1.Name = "xF1"
        Me.xF1.Size = New System.Drawing.Size(104, 22)
        Me.xF1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Rango de Fechas"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.bTotales)
        Me.GroupBox3.Controls.Add(Me.bRecibidos)
        Me.GroupBox3.Controls.Add(Me.bEmitidos)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.xOCr)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.xNDr)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.xNCr)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.xGDr)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.xFVr)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.xFEr)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.xFCr)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.xBVr)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.xOCe)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.xNDe)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.xNCe)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.xGDe)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.xFVe)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.xFEe)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.xFCe)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.xBVe)
        Me.GroupBox3.Controls.Add(Me.xTotal)
        Me.GroupBox3.Controls.Add(Me.xRecibidos)
        Me.GroupBox3.Controls.Add(Me.xEmitidos)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(704, 161)
        Me.GroupBox3.TabIndex = 78
        Me.GroupBox3.TabStop = False
        '
        'bTotales
        '
        Me.bTotales.Location = New System.Drawing.Point(677, 128)
        Me.bTotales.Name = "bTotales"
        Me.bTotales.Size = New System.Drawing.Size(21, 21)
        Me.bTotales.TabIndex = 43
        Me.bTotales.Text = "+"
        Me.bTotales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bTotales.UseVisualStyleBackColor = True
        Me.bTotales.Visible = False
        '
        'bRecibidos
        '
        Me.bRecibidos.Location = New System.Drawing.Point(677, 87)
        Me.bRecibidos.Name = "bRecibidos"
        Me.bRecibidos.Size = New System.Drawing.Size(21, 20)
        Me.bRecibidos.TabIndex = 42
        Me.bRecibidos.Text = "+"
        Me.bRecibidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bRecibidos.UseVisualStyleBackColor = True
        '
        'bEmitidos
        '
        Me.bEmitidos.Location = New System.Drawing.Point(677, 34)
        Me.bEmitidos.Name = "bEmitidos"
        Me.bEmitidos.Size = New System.Drawing.Size(21, 20)
        Me.bEmitidos.TabIndex = 41
        Me.bEmitidos.Text = "+"
        Me.bEmitidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bEmitidos.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(644, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 40
        Me.Label24.Text = "Total"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(547, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "OC"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xOCr
        '
        Me.xOCr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xOCr.Location = New System.Drawing.Point(524, 87)
        Me.xOCr.Name = "xOCr"
        Me.xOCr.Size = New System.Drawing.Size(44, 20)
        Me.xOCr.TabIndex = 38
        Me.xOCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(497, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "ND"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xNDr
        '
        Me.xNDr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xNDr.Location = New System.Drawing.Point(474, 87)
        Me.xNDr.Name = "xNDr"
        Me.xNDr.Size = New System.Drawing.Size(44, 20)
        Me.xNDr.TabIndex = 36
        Me.xNDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(447, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "NC"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xNCr
        '
        Me.xNCr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xNCr.Location = New System.Drawing.Point(424, 87)
        Me.xNCr.Name = "xNCr"
        Me.xNCr.Size = New System.Drawing.Size(44, 20)
        Me.xNCr.TabIndex = 34
        Me.xNCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(397, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(23, 13)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "GD"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xGDr
        '
        Me.xGDr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xGDr.Location = New System.Drawing.Point(374, 87)
        Me.xGDr.Name = "xGDr"
        Me.xGDr.Size = New System.Drawing.Size(44, 20)
        Me.xGDr.TabIndex = 32
        Me.xGDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(347, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 13)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "FV"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xFVr
        '
        Me.xFVr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xFVr.Location = New System.Drawing.Point(324, 87)
        Me.xFVr.Name = "xFVr"
        Me.xFVr.Size = New System.Drawing.Size(44, 20)
        Me.xFVr.TabIndex = 30
        Me.xFVr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(297, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 13)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "FE"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xFEr
        '
        Me.xFEr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xFEr.Location = New System.Drawing.Point(274, 87)
        Me.xFEr.Name = "xFEr"
        Me.xFEr.Size = New System.Drawing.Size(44, 20)
        Me.xFEr.TabIndex = 28
        Me.xFEr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(247, 72)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(20, 13)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "FC"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xFCr
        '
        Me.xFCr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xFCr.Location = New System.Drawing.Point(224, 87)
        Me.xFCr.Name = "xFCr"
        Me.xFCr.Size = New System.Drawing.Size(44, 20)
        Me.xFCr.TabIndex = 26
        Me.xFCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(197, 72)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(21, 13)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "BV"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xBVr
        '
        Me.xBVr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xBVr.Location = New System.Drawing.Point(174, 87)
        Me.xBVr.Name = "xBVr"
        Me.xBVr.Size = New System.Drawing.Size(44, 20)
        Me.xBVr.TabIndex = 24
        Me.xBVr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(644, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Total"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(547, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "OC"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xOCe
        '
        Me.xOCe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xOCe.Location = New System.Drawing.Point(524, 34)
        Me.xOCe.Name = "xOCe"
        Me.xOCe.Size = New System.Drawing.Size(44, 20)
        Me.xOCe.TabIndex = 21
        Me.xOCe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(497, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "ND"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xNDe
        '
        Me.xNDe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xNDe.Location = New System.Drawing.Point(474, 34)
        Me.xNDe.Name = "xNDe"
        Me.xNDe.Size = New System.Drawing.Size(44, 20)
        Me.xNDe.TabIndex = 19
        Me.xNDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(447, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "NC"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xNCe
        '
        Me.xNCe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xNCe.Location = New System.Drawing.Point(424, 34)
        Me.xNCe.Name = "xNCe"
        Me.xNCe.Size = New System.Drawing.Size(44, 20)
        Me.xNCe.TabIndex = 17
        Me.xNCe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(397, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "GD"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xGDe
        '
        Me.xGDe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xGDe.Location = New System.Drawing.Point(374, 34)
        Me.xGDe.Name = "xGDe"
        Me.xGDe.Size = New System.Drawing.Size(44, 20)
        Me.xGDe.TabIndex = 15
        Me.xGDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(347, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "FV"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xFVe
        '
        Me.xFVe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xFVe.Location = New System.Drawing.Point(324, 34)
        Me.xFVe.Name = "xFVe"
        Me.xFVe.Size = New System.Drawing.Size(44, 20)
        Me.xFVe.TabIndex = 13
        Me.xFVe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(297, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "FE"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xFEe
        '
        Me.xFEe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xFEe.Location = New System.Drawing.Point(274, 34)
        Me.xFEe.Name = "xFEe"
        Me.xFEe.Size = New System.Drawing.Size(44, 20)
        Me.xFEe.TabIndex = 11
        Me.xFEe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(247, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "FC"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xFCe
        '
        Me.xFCe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xFCe.Location = New System.Drawing.Point(224, 34)
        Me.xFCe.Name = "xFCe"
        Me.xFCe.Size = New System.Drawing.Size(44, 20)
        Me.xFCe.TabIndex = 9
        Me.xFCe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(197, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "BV"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xBVe
        '
        Me.xBVe.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xBVe.Location = New System.Drawing.Point(174, 34)
        Me.xBVe.Name = "xBVe"
        Me.xBVe.Size = New System.Drawing.Size(44, 20)
        Me.xBVe.TabIndex = 7
        Me.xBVe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xTotal
        '
        Me.xTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTotal.Location = New System.Drawing.Point(584, 128)
        Me.xTotal.Name = "xTotal"
        Me.xTotal.Size = New System.Drawing.Size(91, 21)
        Me.xTotal.TabIndex = 6
        Me.xTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xRecibidos
        '
        Me.xRecibidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xRecibidos.Location = New System.Drawing.Point(584, 87)
        Me.xRecibidos.Name = "xRecibidos"
        Me.xRecibidos.Size = New System.Drawing.Size(91, 20)
        Me.xRecibidos.TabIndex = 5
        Me.xRecibidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xEmitidos
        '
        Me.xEmitidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xEmitidos.Location = New System.Drawing.Point(584, 34)
        Me.xEmitidos.Name = "xEmitidos"
        Me.xEmitidos.Size = New System.Drawing.Size(91, 20)
        Me.xEmitidos.TabIndex = 4
        Me.xEmitidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(448, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Total Documentos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(13, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Documentos Recibidos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Documentos Emitidos"
        '
        'WinDeco1
        '
        Me.WinDeco1.AlturaFooter = 60
        Me.WinDeco1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.WinDeco1.BordeVentana = 2
        Me.WinDeco1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WinDeco1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.WinDeco1.Location = New System.Drawing.Point(0, 0)
        Me.WinDeco1.MuestraBordeExterior = -1
        Me.WinDeco1.Name = "WinDeco1"
        Me.WinDeco1.Size = New System.Drawing.Size(728, 50)
        Me.WinDeco1.TabIndex = 12
        Me.WinDeco1.TituloVentana = "Contadores DTE"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = False
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'ContadoresDTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 413)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gDatosCliente)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(1364, 724)
        Me.Name = "ContadoresDTE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ContadoresDTE"
        Me.gDatosCliente.ResumeLayout(False)
        Me.gDatosCliente.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Public WithEvents bCancelar As Button
    Friend WithEvents gDatosCliente As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents xNombre As TextBox
    Friend WithEvents xRut As MaskedTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents xF2 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents xF1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents xTotal As TextBox
    Friend WithEvents xRecibidos As TextBox
    Friend WithEvents xEmitidos As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Public WithEvents bBuscar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents xFCe As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents xBVe As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents xNCe As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents xGDe As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents xFVe As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents xFEe As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents xOCe As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents xNDe As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents xOCr As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents xNDr As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents xNCr As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents xGDr As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents xFVr As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents xFEr As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents xFCr As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents xBVr As TextBox
    Friend WithEvents bRecibidos As Button
    Friend WithEvents bEmitidos As Button
    Friend WithEvents bTotales As Button
    Friend WithEvents bBuscarCli As Button
End Class
