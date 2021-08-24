<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Atencion_Paciente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Atencion_Paciente))
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cExamen = New System.Windows.Forms.ComboBox()
        Me.xRut = New System.Windows.Forms.MaskedTextBox()
        Me.xContacto = New System.Windows.Forms.TextBox()
        Me.xNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.oDialogo = New System.Windows.Forms.OpenFileDialog()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bAdjuntar = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.Button72 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.BackColor = System.Drawing.Color.White
        Me.bGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bGuardar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.Image = Global.SisVen.My.Resources.Resources.save24
        Me.bGuardar.Location = New System.Drawing.Point(259, 451)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(101, 36)
        Me.bGuardar.TabIndex = 109
        Me.bGuardar.Text = "Guardar"
        Me.bGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bGuardar.UseVisualStyleBackColor = False
        '
        'bCerrar
        '
        Me.bCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCerrar.BackColor = System.Drawing.Color.White
        Me.bCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCerrar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCerrar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCerrar.Location = New System.Drawing.Point(366, 451)
        Me.bCerrar.Name = "bCerrar"
        Me.bCerrar.Size = New System.Drawing.Size(100, 36)
        Me.bCerrar.TabIndex = 108
        Me.bCerrar.Text = "Cancelar"
        Me.bCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCerrar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cExamen)
        Me.GroupBox1.Controls.Add(Me.xRut)
        Me.GroupBox1.Controls.Add(Me.xContacto)
        Me.GroupBox1.Controls.Add(Me.xNombre)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 126)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Paciente"
        '
        'cExamen
        '
        Me.cExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cExamen.FormattingEnabled = True
        Me.cExamen.Location = New System.Drawing.Point(98, 97)
        Me.cExamen.Name = "cExamen"
        Me.cExamen.Size = New System.Drawing.Size(342, 21)
        Me.cExamen.TabIndex = 12
        '
        'xRut
        '
        Me.xRut.Location = New System.Drawing.Point(98, 19)
        Me.xRut.Mask = "##,###,###-A"
        Me.xRut.Name = "xRut"
        Me.xRut.Size = New System.Drawing.Size(100, 20)
        Me.xRut.TabIndex = 5
        '
        'xContacto
        '
        Me.xContacto.Location = New System.Drawing.Point(98, 71)
        Me.xContacto.Name = "xContacto"
        Me.xContacto.Size = New System.Drawing.Size(100, 20)
        Me.xContacto.TabIndex = 11
        '
        'xNombre
        '
        Me.xNombre.Location = New System.Drawing.Point(98, 45)
        Me.xNombre.Name = "xNombre"
        Me.xNombre.Size = New System.Drawing.Size(342, 20)
        Me.xNombre.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Examen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Contacto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Rut"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Nombre"
        '
        'oDialogo
        '
        Me.oDialogo.FileName = "OpenFileDialog1"
        '
        'xTabla
        '
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = "0,0,0,0,0,95,Columns:"
        Me.xTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.xTabla.Location = New System.Drawing.Point(12, 188)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 19
        Me.xTabla.Size = New System.Drawing.Size(454, 241)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 111
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'bAdjuntar
        '
        Me.bAdjuntar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bAdjuntar.BackColor = System.Drawing.Color.White
        Me.bAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bAdjuntar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAdjuntar.Image = Global.SisVen.My.Resources.Resources.AttatchFile24
        Me.bAdjuntar.Location = New System.Drawing.Point(12, 450)
        Me.bAdjuntar.Name = "bAdjuntar"
        Me.bAdjuntar.Size = New System.Drawing.Size(109, 37)
        Me.bAdjuntar.TabIndex = 112
        Me.bAdjuntar.Text = "Adjuntar"
        Me.bAdjuntar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bAdjuntar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bAdjuntar.UseVisualStyleBackColor = False
        '
        'WinDeco1
        '
        Me.WinDeco1.AlturaFooter = 60
        Me.WinDeco1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.WinDeco1.BordeVentana = 2
        Me.WinDeco1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WinDeco1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.WinDeco1.Location = New System.Drawing.Point(0, 0)
        Me.WinDeco1.MuestraBordeExterior = -1
        Me.WinDeco1.Name = "WinDeco1"
        Me.WinDeco1.Size = New System.Drawing.Size(478, 50)
        Me.WinDeco1.TabIndex = 2
        Me.WinDeco1.TituloVentana = "Atención de Paciente"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = True
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'Button72
        '
        Me.Button72.BackColor = System.Drawing.Color.White
        Me.Button72.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button72.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button72.Image = Global.SisVen.My.Resources.Resources.FinishPatient24
        Me.Button72.Location = New System.Drawing.Point(154, 451)
        Me.Button72.Name = "Button72"
        Me.Button72.Size = New System.Drawing.Size(99, 36)
        Me.Button72.TabIndex = 225
        Me.Button72.Text = "Finalizar"
        Me.Button72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button72.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button72.UseVisualStyleBackColor = False
        '
        'Atencion_Paciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 499)
        Me.Controls.Add(Me.Button72)
        Me.Controls.Add(Me.bAdjuntar)
        Me.Controls.Add(Me.xTabla)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bCerrar)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1263, 768)
        Me.Name = "Atencion_Paciente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atención de Paciente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Public WithEvents bGuardar As Button
    Public WithEvents bCerrar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cExamen As ComboBox
    Friend WithEvents xRut As MaskedTextBox
    Friend WithEvents xContacto As TextBox
    Friend WithEvents xNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents oDialogo As OpenFileDialog
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents bAdjuntar As Button
    Public WithEvents Button72 As Button
End Class
