<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManUsuarios))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.zClave = New System.Windows.Forms.Label()
        Me.Ver = New System.Windows.Forms.Button()
        Me.xNombreCliente = New System.Windows.Forms.TextBox()
        Me.oFuncionario = New System.Windows.Forms.CheckBox()
        Me.Buscar_Empresa = New System.Windows.Forms.Button()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.xClave = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.xLocal = New System.Windows.Forms.TextBox()
        Me.xAcceso = New System.Windows.Forms.TextBox()
        Me.xRut = New System.Windows.Forms.MaskedTextBox()
        Me.cLocal = New System.Windows.Forms.ComboBox()
        Me.cAcceso = New System.Windows.Forms.ComboBox()
        Me.xNombreUsr = New System.Windows.Forms.TextBox()
        Me.xCodigo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.xNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.xNumero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.zClave)
        Me.GroupBox1.Controls.Add(Me.Ver)
        Me.GroupBox1.Controls.Add(Me.xNombreCliente)
        Me.GroupBox1.Controls.Add(Me.oFuncionario)
        Me.GroupBox1.Controls.Add(Me.Buscar_Empresa)
        Me.GroupBox1.Controls.Add(Me.xCliente)
        Me.GroupBox1.Controls.Add(Me.xClave)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.xLocal)
        Me.GroupBox1.Controls.Add(Me.xAcceso)
        Me.GroupBox1.Controls.Add(Me.xRut)
        Me.GroupBox1.Controls.Add(Me.cLocal)
        Me.GroupBox1.Controls.Add(Me.cAcceso)
        Me.GroupBox1.Controls.Add(Me.xNombreUsr)
        Me.GroupBox1.Controls.Add(Me.xCodigo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 294)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'zClave
        '
        Me.zClave.AutoSize = True
        Me.zClave.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zClave.Location = New System.Drawing.Point(375, 121)
        Me.zClave.Name = "zClave"
        Me.zClave.Size = New System.Drawing.Size(0, 16)
        Me.zClave.TabIndex = 116
        Me.zClave.Visible = False
        '
        'Ver
        '
        Me.Ver.BackColor = System.Drawing.Color.White
        Me.Ver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ver.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ver.Image = Global.SisVen.My.Resources.Resources.find
        Me.Ver.Location = New System.Drawing.Point(186, 8)
        Me.Ver.Name = "Ver"
        Me.Ver.Size = New System.Drawing.Size(80, 28)
        Me.Ver.TabIndex = 105
        Me.Ver.Text = "Buscar"
        Me.Ver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Ver.UseVisualStyleBackColor = False
        '
        'xNombreCliente
        '
        Me.xNombreCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xNombreCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xNombreCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNombreCliente.Location = New System.Drawing.Point(179, 174)
        Me.xNombreCliente.Name = "xNombreCliente"
        Me.xNombreCliente.ReadOnly = True
        Me.xNombreCliente.Size = New System.Drawing.Size(302, 23)
        Me.xNombreCliente.TabIndex = 104
        Me.xNombreCliente.TabStop = False
        '
        'oFuncionario
        '
        Me.oFuncionario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.oFuncionario.Appearance = System.Windows.Forms.Appearance.Button
        Me.oFuncionario.BackColor = System.Drawing.Color.White
        Me.oFuncionario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.oFuncionario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oFuncionario.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oFuncionario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.oFuncionario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.oFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oFuncionario.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oFuncionario.ForeColor = System.Drawing.Color.Black
        Me.oFuncionario.Location = New System.Drawing.Point(98, 251)
        Me.oFuncionario.Name = "oFuncionario"
        Me.oFuncionario.Size = New System.Drawing.Size(150, 37)
        Me.oFuncionario.TabIndex = 115
        Me.oFuncionario.Text = "Funcionario"
        Me.oFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.oFuncionario.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.oFuncionario.UseVisualStyleBackColor = False
        '
        'Buscar_Empresa
        '
        Me.Buscar_Empresa.BackColor = System.Drawing.Color.White
        Me.Buscar_Empresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buscar_Empresa.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buscar_Empresa.Image = Global.SisVen.My.Resources.Resources.find
        Me.Buscar_Empresa.Location = New System.Drawing.Point(484, 171)
        Me.Buscar_Empresa.Name = "Buscar_Empresa"
        Me.Buscar_Empresa.Size = New System.Drawing.Size(81, 28)
        Me.Buscar_Empresa.TabIndex = 11
        Me.Buscar_Empresa.Text = "Buscar"
        Me.Buscar_Empresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buscar_Empresa.UseVisualStyleBackColor = False
        '
        'xCliente
        '
        Me.xCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xCliente.Location = New System.Drawing.Point(98, 174)
        Me.xCliente.MaxLength = 18
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(75, 23)
        Me.xCliente.TabIndex = 10
        '
        'xClave
        '
        Me.xClave.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xClave.Location = New System.Drawing.Point(98, 118)
        Me.xClave.MaxLength = 4
        Me.xClave.Name = "xClave"
        Me.xClave.Size = New System.Drawing.Size(168, 23)
        Me.xClave.TabIndex = 6
        Me.xClave.UseSystemPasswordChar = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Clave"
        '
        'xLocal
        '
        Me.xLocal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xLocal.Location = New System.Drawing.Point(98, 145)
        Me.xLocal.MaxLength = 18
        Me.xLocal.Name = "xLocal"
        Me.xLocal.Size = New System.Drawing.Size(75, 23)
        Me.xLocal.TabIndex = 7
        '
        'xAcceso
        '
        Me.xAcceso.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xAcceso.Location = New System.Drawing.Point(98, 89)
        Me.xAcceso.MaxLength = 1
        Me.xAcceso.Name = "xAcceso"
        Me.xAcceso.Size = New System.Drawing.Size(75, 23)
        Me.xAcceso.TabIndex = 4
        '
        'xRut
        '
        Me.xRut.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xRut.Location = New System.Drawing.Point(98, 65)
        Me.xRut.Mask = "##,###,###-A"
        Me.xRut.Name = "xRut"
        Me.xRut.Size = New System.Drawing.Size(168, 23)
        Me.xRut.TabIndex = 3
        '
        'cLocal
        '
        Me.cLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cLocal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cLocal.FormattingEnabled = True
        Me.cLocal.Location = New System.Drawing.Point(179, 143)
        Me.cLocal.Name = "cLocal"
        Me.cLocal.Size = New System.Drawing.Size(300, 24)
        Me.cLocal.TabIndex = 8
        '
        'cAcceso
        '
        Me.cAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cAcceso.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cAcceso.FormattingEnabled = True
        Me.cAcceso.Location = New System.Drawing.Point(179, 90)
        Me.cAcceso.Name = "cAcceso"
        Me.cAcceso.Size = New System.Drawing.Size(300, 24)
        Me.cAcceso.TabIndex = 5
        '
        'xNombreUsr
        '
        Me.xNombreUsr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xNombreUsr.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNombreUsr.Location = New System.Drawing.Point(98, 40)
        Me.xNombreUsr.MaxLength = 50
        Me.xNombreUsr.Name = "xNombreUsr"
        Me.xNombreUsr.Size = New System.Drawing.Size(381, 23)
        Me.xNombreUsr.TabIndex = 2
        '
        'xCodigo
        '
        Me.xCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xCodigo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xCodigo.Location = New System.Drawing.Point(98, 13)
        Me.xCodigo.MaxLength = 3
        Me.xCodigo.Name = "xCodigo"
        Me.xCodigo.Size = New System.Drawing.Size(75, 23)
        Me.xCodigo.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 16)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Cliente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 16)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Local"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Acceso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 16)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Rut"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Código"
        '
        'Cancelar
        '
        Me.Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancelar.BackColor = System.Drawing.Color.White
        Me.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.Cancelar.Location = New System.Drawing.Point(489, 374)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(99, 36)
        Me.Cancelar.TabIndex = 4
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cancelar.UseVisualStyleBackColor = False
        '
        'Aceptar
        '
        Me.Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Aceptar.BackColor = System.Drawing.Color.White
        Me.Aceptar.Enabled = False
        Me.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Aceptar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aceptar.Image = Global.SisVen.My.Resources.Resources.save24
        Me.Aceptar.Location = New System.Drawing.Point(271, 374)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(114, 36)
        Me.Aceptar.TabIndex = 2
        Me.Aceptar.Text = "Guardar"
        Me.Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Aceptar.UseVisualStyleBackColor = False
        '
        'Eliminar
        '
        Me.Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Eliminar.BackColor = System.Drawing.Color.White
        Me.Eliminar.Enabled = False
        Me.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Eliminar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eliminar.Image = Global.SisVen.My.Resources.Resources.delete24
        Me.Eliminar.Location = New System.Drawing.Point(390, 374)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(93, 36)
        Me.Eliminar.TabIndex = 3
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Eliminar.UseVisualStyleBackColor = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(600, 50)
        Me.WinDeco1.TabIndex = 96
        Me.WinDeco1.TituloVentana = "Mantención de Usuarios"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.Location = New System.Drawing.Point(12, 374)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 36)
        Me.bLimpiar.TabIndex = 106
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'xNumero
        '
        Me.xNumero.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNumero.Location = New System.Drawing.Point(98, 203)
        Me.xNumero.MaxLength = 4
        Me.xNumero.Name = "xNumero"
        Me.xNumero.Size = New System.Drawing.Size(75, 23)
        Me.xNumero.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Número"
        '
        'ManUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.Cancelar)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.Eliminar)
        Me.Controls.Add(Me.WinDeco1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1366, 724)
        Me.Name = "ManUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisVen - Mantención de Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents xClave As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents xAcceso As System.Windows.Forms.TextBox
    Friend WithEvents xRut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cAcceso As System.Windows.Forms.ComboBox
    Friend WithEvents xNombreUsr As System.Windows.Forms.TextBox
    Friend WithEvents xCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents xCliente As System.Windows.Forms.TextBox
    Public WithEvents Buscar_Empresa As System.Windows.Forms.Button
    Friend WithEvents WinDeco1 As SisVen.WinDeco
    Public WithEvents Cancelar As System.Windows.Forms.Button
    Public WithEvents Aceptar As System.Windows.Forms.Button
    Public WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents xLocal As TextBox
    Friend WithEvents cLocal As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents xNombreCliente As TextBox
    Public WithEvents Ver As Button
    Public WithEvents bLimpiar As Button
    Friend WithEvents oFuncionario As CheckBox
    Friend WithEvents zClave As Label
    Friend WithEvents xNumero As TextBox
    Friend WithEvents Label3 As Label
End Class
