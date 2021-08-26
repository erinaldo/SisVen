<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneracionArchivos
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bGenerar = New System.Windows.Forms.Button()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.oGeneral = New System.Windows.Forms.CheckBox()
        Me.oDetalles = New System.Windows.Forms.CheckBox()
        Me.oInventarios = New System.Windows.Forms.CheckBox()
        Me.oMaquinas = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.oMaquinas)
        Me.GroupBox1.Controls.Add(Me.oInventarios)
        Me.GroupBox1.Controls.Add(Me.oDetalles)
        Me.GroupBox1.Controls.Add(Me.oGeneral)
        Me.GroupBox1.Controls.Add(Me.dHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 186)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'dHasta
        '
        Me.dHasta.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dHasta.Location = New System.Drawing.Point(273, 29)
        Me.dHasta.Name = "dHasta"
        Me.dHasta.Size = New System.Drawing.Size(97, 23)
        Me.dHasta.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "al"
        '
        'dDesde
        '
        Me.dDesde.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dDesde.Location = New System.Drawing.Point(144, 29)
        Me.dDesde.Name = "dDesde"
        Me.dDesde.Size = New System.Drawing.Size(97, 23)
        Me.dDesde.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Rango de Fechas"
        '
        'bGenerar
        '
        Me.bGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGenerar.BackColor = System.Drawing.Color.White
        Me.bGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bGenerar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGenerar.Image = Global.SisVen.My.Resources.Resources.save24
        Me.bGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bGenerar.Location = New System.Drawing.Point(156, 264)
        Me.bGenerar.Name = "bGenerar"
        Me.bGenerar.Size = New System.Drawing.Size(175, 36)
        Me.bGenerar.TabIndex = 108
        Me.bGenerar.Text = "Generar Archivos"
        Me.bGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bGenerar.UseVisualStyleBackColor = False
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(345, 264)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(99, 36)
        Me.bCancelar.TabIndex = 109
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(456, 50)
        Me.WinDeco1.TabIndex = 5
        Me.WinDeco1.TituloVentana = "Generación de Archivos"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'oGeneral
        '
        Me.oGeneral.AutoSize = True
        Me.oGeneral.Checked = True
        Me.oGeneral.CheckState = System.Windows.Forms.CheckState.Checked
        Me.oGeneral.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oGeneral.Location = New System.Drawing.Point(11, 87)
        Me.oGeneral.Name = "oGeneral"
        Me.oGeneral.Size = New System.Drawing.Size(240, 19)
        Me.oGeneral.TabIndex = 15
        Me.oGeneral.Text = "Generar Archivo Encabecados (VTAS1) "
        Me.oGeneral.UseVisualStyleBackColor = True
        '
        'oDetalles
        '
        Me.oDetalles.AutoSize = True
        Me.oDetalles.Checked = True
        Me.oDetalles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.oDetalles.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oDetalles.Location = New System.Drawing.Point(11, 110)
        Me.oDetalles.Name = "oDetalles"
        Me.oDetalles.Size = New System.Drawing.Size(210, 19)
        Me.oDetalles.TabIndex = 16
        Me.oDetalles.Text = "Generar Archivo Detalles (VTAS2) "
        Me.oDetalles.UseVisualStyleBackColor = True
        '
        'oInventarios
        '
        Me.oInventarios.AutoSize = True
        Me.oInventarios.Checked = True
        Me.oInventarios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.oInventarios.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oInventarios.Location = New System.Drawing.Point(11, 133)
        Me.oInventarios.Name = "oInventarios"
        Me.oInventarios.Size = New System.Drawing.Size(192, 19)
        Me.oInventarios.TabIndex = 17
        Me.oInventarios.Text = "Generar Archivo de Inventarios"
        Me.oInventarios.UseVisualStyleBackColor = True
        '
        'oMaquinas
        '
        Me.oMaquinas.AutoSize = True
        Me.oMaquinas.Checked = True
        Me.oMaquinas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.oMaquinas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oMaquinas.Location = New System.Drawing.Point(11, 156)
        Me.oMaquinas.Name = "oMaquinas"
        Me.oMaquinas.Size = New System.Drawing.Size(186, 19)
        Me.oMaquinas.TabIndex = 18
        Me.oMaquinas.Text = "Generar Archivo de Máquinas"
        Me.oMaquinas.UseVisualStyleBackColor = True
        '
        'GeneracionArchivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 312)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bGenerar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.Name = "GeneracionArchivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeneracionArchivos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents bGenerar As Button
    Friend WithEvents dHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dDesde As DateTimePicker
    Friend WithEvents Label1 As Label
    Public WithEvents bCancelar As Button
    Friend WithEvents oMaquinas As CheckBox
    Friend WithEvents oInventarios As CheckBox
    Friend WithEvents oDetalles As CheckBox
    Friend WithEvents oGeneral As CheckBox
End Class
