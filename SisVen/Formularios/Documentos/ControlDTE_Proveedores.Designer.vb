<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlDTE_Proveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlDTE_Proveedores))
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.gFiltro = New System.Windows.Forms.GroupBox()
        Me.oTodos = New System.Windows.Forms.CheckBox()
        Me.bConsultar = New System.Windows.Forms.Button()
        Me.xF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xF1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cEstados = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cLocal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.xTexto = New System.Windows.Forms.TextBox()
        Me.bProcesar = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.WinDeco1 = New SisVen.WinDeco()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gFiltro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(1028, 484)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(99, 36)
        Me.bCancelar.TabIndex = 101
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.Location = New System.Drawing.Point(12, 484)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 36)
        Me.bLimpiar.TabIndex = 99
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'xTabla
        '
        Me.xTabla.AllowDelete = True
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = "0,0,0,0,0,95,Columns:"
        Me.xTabla.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.xTabla.Location = New System.Drawing.Point(9, 195)
        Me.xTabla.Margin = New System.Windows.Forms.Padding(0)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 19
        Me.xTabla.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.xTabla.Size = New System.Drawing.Size(1123, 269)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 116
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'gFiltro
        '
        Me.gFiltro.BackColor = System.Drawing.Color.Transparent
        Me.gFiltro.Controls.Add(Me.oTodos)
        Me.gFiltro.Controls.Add(Me.bConsultar)
        Me.gFiltro.Controls.Add(Me.xF2)
        Me.gFiltro.Controls.Add(Me.Label4)
        Me.gFiltro.Controls.Add(Me.xF1)
        Me.gFiltro.Controls.Add(Me.Label5)
        Me.gFiltro.Controls.Add(Me.cEstados)
        Me.gFiltro.Controls.Add(Me.Label3)
        Me.gFiltro.Controls.Add(Me.cLocal)
        Me.gFiltro.Controls.Add(Me.Label2)
        Me.gFiltro.Controls.Add(Me.cTipoDoc)
        Me.gFiltro.Controls.Add(Me.Label1)
        Me.gFiltro.Location = New System.Drawing.Point(9, 56)
        Me.gFiltro.Name = "gFiltro"
        Me.gFiltro.Size = New System.Drawing.Size(580, 136)
        Me.gFiltro.TabIndex = 117
        Me.gFiltro.TabStop = False
        '
        'oTodos
        '
        Me.oTodos.AutoSize = True
        Me.oTodos.BackColor = System.Drawing.Color.Gainsboro
        Me.oTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.oTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oTodos.Location = New System.Drawing.Point(404, 106)
        Me.oTodos.Name = "oTodos"
        Me.oTodos.Size = New System.Drawing.Size(170, 17)
        Me.oTodos.TabIndex = 13
        Me.oTodos.Text = "Mostrar Todos los Documentos"
        Me.oTodos.UseVisualStyleBackColor = False
        '
        'bConsultar
        '
        Me.bConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bConsultar.BackColor = System.Drawing.Color.White
        Me.bConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConsultar.Image = Global.SisVen.My.Resources.Resources.find24
        Me.bConsultar.Location = New System.Drawing.Point(471, 10)
        Me.bConsultar.Name = "bConsultar"
        Me.bConsultar.Size = New System.Drawing.Size(103, 68)
        Me.bConsultar.TabIndex = 12
        Me.bConsultar.Text = "Consultar Documentos"
        Me.bConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bConsultar.UseVisualStyleBackColor = False
        '
        'xF2
        '
        Me.xF2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.xF2.Location = New System.Drawing.Point(273, 9)
        Me.xF2.Name = "xF2"
        Me.xF2.Size = New System.Drawing.Size(97, 23)
        Me.xF2.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(241, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "al"
        '
        'xF1
        '
        Me.xF1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.xF1.Location = New System.Drawing.Point(133, 10)
        Me.xF1.Name = "xF1"
        Me.xF1.Size = New System.Drawing.Size(97, 23)
        Me.xF1.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Rango de Fechas"
        '
        'cEstados
        '
        Me.cEstados.BackColor = System.Drawing.Color.White
        Me.cEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEstados.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cEstados.FormattingEnabled = True
        Me.cEstados.Location = New System.Drawing.Point(133, 99)
        Me.cEstados.Name = "cEstados"
        Me.cEstados.Size = New System.Drawing.Size(237, 24)
        Me.cEstados.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Estado Documento"
        '
        'cLocal
        '
        Me.cLocal.BackColor = System.Drawing.Color.White
        Me.cLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cLocal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cLocal.FormattingEnabled = True
        Me.cLocal.Location = New System.Drawing.Point(133, 39)
        Me.cLocal.Name = "cLocal"
        Me.cLocal.Size = New System.Drawing.Size(237, 24)
        Me.cLocal.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Local Receptor"
        '
        'cTipoDoc
        '
        Me.cTipoDoc.BackColor = System.Drawing.Color.White
        Me.cTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTipoDoc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cTipoDoc.FormattingEnabled = True
        Me.cTipoDoc.Location = New System.Drawing.Point(133, 69)
        Me.cTipoDoc.Name = "cTipoDoc"
        Me.cTipoDoc.Size = New System.Drawing.Size(237, 24)
        Me.cTipoDoc.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo Documento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.xTexto)
        Me.GroupBox1.Location = New System.Drawing.Point(595, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(532, 136)
        Me.GroupBox1.TabIndex = 118
        Me.GroupBox1.TabStop = False
        '
        'xTexto
        '
        Me.xTexto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTexto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xTexto.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTexto.Location = New System.Drawing.Point(6, 13)
        Me.xTexto.Multiline = True
        Me.xTexto.Name = "xTexto"
        Me.xTexto.Size = New System.Drawing.Size(520, 67)
        Me.xTexto.TabIndex = 14
        Me.xTexto.Text = resources.GetString("xTexto.Text")
        '
        'bProcesar
        '
        Me.bProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bProcesar.BackColor = System.Drawing.Color.White
        Me.bProcesar.Enabled = False
        Me.bProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bProcesar.Image = Global.SisVen.My.Resources.Resources.execute24
        Me.bProcesar.Location = New System.Drawing.Point(901, 484)
        Me.bProcesar.Name = "bProcesar"
        Me.bProcesar.Size = New System.Drawing.Size(121, 36)
        Me.bProcesar.TabIndex = 12
        Me.bProcesar.Text = "Procesar"
        Me.bProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bProcesar.UseVisualStyleBackColor = False
        '
        'bImprimir
        '
        Me.bImprimir.BackColor = System.Drawing.Color.White
        Me.bImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bImprimir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.Image = Global.SisVen.My.Resources.Resources.print24
        Me.bImprimir.Location = New System.Drawing.Point(106, 484)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(147, 36)
        Me.bImprimir.TabIndex = 120
        Me.bImprimir.Text = "Imprimir Datos"
        Me.bImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bImprimir.UseVisualStyleBackColor = False
        '
        'lStatus
        '
        Me.lStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lStatus.AutoSize = True
        Me.lStatus.BackColor = System.Drawing.Color.Transparent
        Me.lStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatus.ForeColor = System.Drawing.Color.Yellow
        Me.lStatus.Location = New System.Drawing.Point(279, 484)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(11, 13)
        Me.lStatus.TabIndex = 119
        Me.lStatus.Text = "."
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
        Me.WinDeco1.Size = New System.Drawing.Size(1139, 50)
        Me.WinDeco1.TabIndex = 98
        Me.WinDeco1.TituloVentana = "Control Documentos DTE Proveedores"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = True
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'ControlDTE_Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 532)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bProcesar)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gFiltro)
        Me.Controls.Add(Me.xTabla)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1364, 724)
        Me.Name = "ControlDTE_Proveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ControlDTE Proveedores"
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gFiltro.ResumeLayout(False)
        Me.gFiltro.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Public WithEvents bCancelar As Button
    Public WithEvents bLimpiar As Button
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents gFiltro As GroupBox
    Friend WithEvents cEstados As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cLocal As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cTipoDoc As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents xF2 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents xF1 As DateTimePicker
    Friend WithEvents Label5 As Label
    Public WithEvents bConsultar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents bProcesar As Button
    Friend WithEvents xTexto As TextBox
    Friend WithEvents oConsultar As RadioButton
    Public WithEvents bImprimir As Button
    Friend WithEvents oTodos As CheckBox
    Friend WithEvents lStatus As Label
End Class
