<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_Articulos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consulta_Articulos))
        Me.Datos = New System.Windows.Forms.StatusStrip()
        Me.Fecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Cargando = New System.Windows.Forms.ToolStripStatusLabel()
        Me.xFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.xCargando = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.xNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bBuscarCliente = New System.Windows.Forms.Button()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.xDescripcion = New System.Windows.Forms.TextBox()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Cargar = New System.Windows.Forms.Button()
        Me.mMenuTabla = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lCantidadArticulos = New System.Windows.Forms.Label()
        Me.Datos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mMenuTabla.SuspendLayout()
        Me.SuspendLayout()
        '
        'Datos
        '
        Me.Datos.BackColor = System.Drawing.Color.Transparent
        Me.Datos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Fecha, Me.Cargando})
        Me.Datos.Location = New System.Drawing.Point(0, 492)
        Me.Datos.Name = "Datos"
        Me.Datos.Size = New System.Drawing.Size(727, 22)
        Me.Datos.TabIndex = 12
        Me.Datos.Text = "Fecha"
        '
        'Fecha
        '
        Me.Fecha.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.ForeColor = System.Drawing.Color.White
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(44, 17)
        Me.Fecha.Text = "Fecha"
        '
        'Cargando
        '
        Me.Cargando.ForeColor = System.Drawing.Color.White
        Me.Cargando.Name = "Cargando"
        Me.Cargando.Size = New System.Drawing.Size(0, 17)
        '
        'xFecha
        '
        Me.xFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.xFecha.Name = "xFecha"
        Me.xFecha.Size = New System.Drawing.Size(36, 17)
        Me.xFecha.Text = "Fecha"
        '
        'xCargando
        '
        Me.xCargando.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.xCargando.Name = "xCargando"
        Me.xCargando.Size = New System.Drawing.Size(0, 17)
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(616, 453)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(100, 36)
        Me.bCancelar.TabIndex = 3
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
        '
        'WinDeco1
        '
        Me.WinDeco1.AlturaFooter = 70
        Me.WinDeco1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.WinDeco1.BordeVentana = 2
        Me.WinDeco1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WinDeco1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.WinDeco1.Location = New System.Drawing.Point(0, 0)
        Me.WinDeco1.MuestraBordeExterior = -1
        Me.WinDeco1.Name = "WinDeco1"
        Me.WinDeco1.Size = New System.Drawing.Size(727, 50)
        Me.WinDeco1.TabIndex = 98
        Me.WinDeco1.TituloVentana = "Consulta de Artículos"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = True
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.bLimpiar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.xCliente)
        Me.GroupBox1.Controls.Add(Me.xNombreCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.bBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.bBuscar)
        Me.GroupBox1.Controls.Add(Me.xDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(704, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'bLimpiar
        '
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean16
        Me.bLimpiar.Location = New System.Drawing.Point(516, 11)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(80, 28)
        Me.bLimpiar.TabIndex = 2
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 205
        Me.Label5.Text = "Cliente"
        '
        'xCliente
        '
        Me.xCliente.BackColor = System.Drawing.Color.White
        Me.xCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xCliente.Location = New System.Drawing.Point(105, 15)
        Me.xCliente.MaxLength = 18
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(69, 23)
        Me.xCliente.TabIndex = 0
        '
        'xNombreCliente
        '
        Me.xNombreCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xNombreCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNombreCliente.Location = New System.Drawing.Point(180, 15)
        Me.xNombreCliente.Name = "xNombreCliente"
        Me.xNombreCliente.ReadOnly = True
        Me.xNombreCliente.Size = New System.Drawing.Size(330, 23)
        Me.xNombreCliente.TabIndex = 206
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "Descripción"
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.BackColor = System.Drawing.Color.White
        Me.bBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscarCliente.Location = New System.Drawing.Point(602, 11)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(80, 28)
        Me.bBuscarCliente.TabIndex = 3
        Me.bBuscarCliente.Text = "Buscar"
        Me.bBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarCliente.UseVisualStyleBackColor = False
        '
        'bBuscar
        '
        Me.bBuscar.BackColor = System.Drawing.Color.White
        Me.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscar.Location = New System.Drawing.Point(602, 38)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(80, 28)
        Me.bBuscar.TabIndex = 4
        Me.bBuscar.Text = "Buscar"
        Me.bBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscar.UseVisualStyleBackColor = False
        '
        'xDescripcion
        '
        Me.xDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xDescripcion.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xDescripcion.Location = New System.Drawing.Point(105, 43)
        Me.xDescripcion.Name = "xDescripcion"
        Me.xDescripcion.Size = New System.Drawing.Size(491, 23)
        Me.xDescripcion.TabIndex = 1
        '
        'xTabla
        '
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = resources.GetString("xTabla.ColumnInfo")
        Me.xTabla.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.xTabla.Location = New System.Drawing.Point(12, 136)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 21
        Me.xTabla.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.xTabla.Size = New System.Drawing.Size(704, 300)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 1
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'Cargar
        '
        Me.Cargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cargar.BackColor = System.Drawing.Color.White
        Me.Cargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cargar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cargar.Image = Global.SisVen.My.Resources.Resources.load24
        Me.Cargar.Location = New System.Drawing.Point(12, 452)
        Me.Cargar.Name = "Cargar"
        Me.Cargar.Size = New System.Drawing.Size(97, 37)
        Me.Cargar.TabIndex = 2
        Me.Cargar.Text = "Cargar"
        Me.Cargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cargar.UseVisualStyleBackColor = False
        '
        'mMenuTabla
        '
        Me.mMenuTabla.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bCopiar})
        Me.mMenuTabla.Name = "mMenuTabla"
        Me.mMenuTabla.Size = New System.Drawing.Size(121, 34)
        '
        'bCopiar
        '
        Me.bCopiar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCopiar.Image = Global.SisVen.My.Resources.Resources.clipboard_copy
        Me.bCopiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.bCopiar.Name = "bCopiar"
        Me.bCopiar.Size = New System.Drawing.Size(120, 30)
        Me.bCopiar.Text = "Copiar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(129, 465)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 16)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Cantidad de Articulos"
        '
        'lCantidadArticulos
        '
        Me.lCantidadArticulos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lCantidadArticulos.AutoSize = True
        Me.lCantidadArticulos.BackColor = System.Drawing.Color.Transparent
        Me.lCantidadArticulos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCantidadArticulos.ForeColor = System.Drawing.Color.White
        Me.lCantidadArticulos.Location = New System.Drawing.Point(266, 465)
        Me.lCantidadArticulos.Name = "lCantidadArticulos"
        Me.lCantidadArticulos.Size = New System.Drawing.Size(16, 16)
        Me.lCantidadArticulos.TabIndex = 100
        Me.lCantidadArticulos.Text = "0"
        '
        'Consulta_Articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(727, 514)
        Me.ControlBox = False
        Me.Controls.Add(Me.lCantidadArticulos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cargar)
        Me.Controls.Add(Me.xTabla)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.WinDeco1)
        Me.Controls.Add(Me.Datos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1366, 724)
        Me.Name = "Consulta_Articulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisVen - Consulta de Artículos"
        Me.Datos.ResumeLayout(False)
        Me.Datos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mMenuTabla.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Datos As System.Windows.Forms.StatusStrip
    Friend WithEvents xFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents xCargando As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WinDeco1 As SisVen.WinDeco
    Public WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents Fecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Cargando As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents bLimpiar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents xCliente As TextBox
    Friend WithEvents xNombreCliente As TextBox
    Friend WithEvents Label1 As Label
    Public WithEvents bBuscarCliente As Button
    Public WithEvents bBuscar As Button
    Friend WithEvents xDescripcion As TextBox
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents Cargar As Button
    Friend WithEvents mMenuTabla As ContextMenuStrip
    Friend WithEvents bCopiar As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents lCantidadArticulos As Label
End Class
