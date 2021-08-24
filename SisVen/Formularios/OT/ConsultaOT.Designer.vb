<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultaOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaOT))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.oFechaEnt = New System.Windows.Forms.RadioButton()
        Me.oFechaOT = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cDesde = New System.Windows.Forms.DateTimePicker()
        Me.xNombreCliente = New System.Windows.Forms.TextBox()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cEstados = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cTecnicos = New System.Windows.Forms.ComboBox()
        Me.xTecnico = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.xOT = New System.Windows.Forms.TextBox()
        Me.bConsultar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.xProgreso = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lCantidadOT = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bIngresoOT = New System.Windows.Forms.Button()
        Me.bAnulacionOT = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.bBuscar)
        Me.GroupBox4.Controls.Add(Me.oFechaEnt)
        Me.GroupBox4.Controls.Add(Me.oFechaOT)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.xNombreCliente)
        Me.GroupBox4.Controls.Add(Me.xCliente)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cEstados)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cTecnicos)
        Me.GroupBox4.Controls.Add(Me.xTecnico)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.xOT)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(802, 125)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'bBuscar
        '
        Me.bBuscar.BackColor = System.Drawing.Color.White
        Me.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscar.Location = New System.Drawing.Point(430, 87)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(95, 28)
        Me.bBuscar.TabIndex = 6
        Me.bBuscar.Text = "Buscar"
        Me.bBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscar.UseVisualStyleBackColor = False
        '
        'oFechaEnt
        '
        Me.oFechaEnt.Appearance = System.Windows.Forms.Appearance.Button
        Me.oFechaEnt.BackColor = System.Drawing.Color.White
        Me.oFechaEnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.oFechaEnt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oFechaEnt.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oFechaEnt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.oFechaEnt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.oFechaEnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oFechaEnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oFechaEnt.ForeColor = System.Drawing.Color.Black
        Me.oFechaEnt.Location = New System.Drawing.Point(685, 15)
        Me.oFechaEnt.Name = "oFechaEnt"
        Me.oFechaEnt.Size = New System.Drawing.Size(108, 32)
        Me.oFechaEnt.TabIndex = 8
        Me.oFechaEnt.Text = "Fecha Entrega"
        Me.oFechaEnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.oFechaEnt.UseVisualStyleBackColor = False
        '
        'oFechaOT
        '
        Me.oFechaOT.Appearance = System.Windows.Forms.Appearance.Button
        Me.oFechaOT.BackColor = System.Drawing.Color.White
        Me.oFechaOT.Checked = True
        Me.oFechaOT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.oFechaOT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oFechaOT.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oFechaOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.oFechaOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.oFechaOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oFechaOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oFechaOT.ForeColor = System.Drawing.Color.White
        Me.oFechaOT.Location = New System.Drawing.Point(577, 15)
        Me.oFechaOT.Name = "oFechaOT"
        Me.oFechaOT.Size = New System.Drawing.Size(108, 32)
        Me.oFechaOT.TabIndex = 7
        Me.oFechaOT.TabStop = True
        Me.oFechaOT.Text = "Fecha OT"
        Me.oFechaOT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.oFechaOT.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cHasta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(577, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(217, 92)
        Me.GroupBox1.TabIndex = 236
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 251
        Me.Label6.Text = "Hasta"
        '
        'cHasta
        '
        Me.cHasta.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cHasta.Location = New System.Drawing.Point(61, 57)
        Me.cHasta.Name = "cHasta"
        Me.cHasta.Size = New System.Drawing.Size(103, 23)
        Me.cHasta.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 249
        Me.Label5.Text = "Desde"
        '
        'cDesde
        '
        Me.cDesde.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cDesde.Location = New System.Drawing.Point(61, 28)
        Me.cDesde.Name = "cDesde"
        Me.cDesde.Size = New System.Drawing.Size(103, 23)
        Me.cDesde.TabIndex = 0
        '
        'xNombreCliente
        '
        Me.xNombreCliente.Location = New System.Drawing.Point(140, 92)
        Me.xNombreCliente.Name = "xNombreCliente"
        Me.xNombreCliente.Size = New System.Drawing.Size(284, 23)
        Me.xNombreCliente.TabIndex = 5
        '
        'xCliente
        '
        Me.xCliente.Location = New System.Drawing.Point(71, 92)
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(63, 23)
        Me.xCliente.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 245
        Me.Label4.Text = "Cliente"
        '
        'cEstados
        '
        Me.cEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEstados.FormattingEnabled = True
        Me.cEstados.Location = New System.Drawing.Point(71, 66)
        Me.cEstados.Name = "cEstados"
        Me.cEstados.Size = New System.Drawing.Size(185, 24)
        Me.cEstados.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 243
        Me.Label3.Text = "Estado"
        '
        'cTecnicos
        '
        Me.cTecnicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTecnicos.FormattingEnabled = True
        Me.cTecnicos.Location = New System.Drawing.Point(140, 40)
        Me.cTecnicos.Name = "cTecnicos"
        Me.cTecnicos.Size = New System.Drawing.Size(284, 24)
        Me.cTecnicos.TabIndex = 2
        '
        'xTecnico
        '
        Me.xTecnico.Location = New System.Drawing.Point(71, 40)
        Me.xTecnico.Name = "xTecnico"
        Me.xTecnico.Size = New System.Drawing.Size(63, 23)
        Me.xTecnico.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 240
        Me.Label2.Text = "Técnico"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "OT"
        '
        'xOT
        '
        Me.xOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.xOT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.xOT.Location = New System.Drawing.Point(71, 16)
        Me.xOT.MaxLength = 18
        Me.xOT.Name = "xOT"
        Me.xOT.Size = New System.Drawing.Size(110, 21)
        Me.xOT.TabIndex = 0
        Me.xOT.Tag = "99"
        '
        'bConsultar
        '
        Me.bConsultar.BackColor = System.Drawing.Color.White
        Me.bConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bConsultar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConsultar.Image = Global.SisVen.My.Resources.Resources.up32
        Me.bConsultar.Location = New System.Drawing.Point(820, 123)
        Me.bConsultar.Name = "bConsultar"
        Me.bConsultar.Size = New System.Drawing.Size(82, 58)
        Me.bConsultar.TabIndex = 236
        Me.bConsultar.Text = "Mostrar"
        Me.bConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bConsultar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.xProgreso)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.xTabla)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(890, 305)
        Me.GroupBox2.TabIndex = 237
        Me.GroupBox2.TabStop = False
        '
        'xProgreso
        '
        Me.xProgreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xProgreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xProgreso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.xProgreso.Location = New System.Drawing.Point(6, 278)
        Me.xProgreso.Margin = New System.Windows.Forms.Padding(0)
        Me.xProgreso.Name = "xProgreso"
        Me.xProgreso.Size = New System.Drawing.Size(713, 22)
        Me.xProgreso.Step = 20
        Me.xProgreso.TabIndex = 235
        Me.xProgreso.Value = 50
        Me.xProgreso.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lCantidadOT)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(722, 274)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(161, 26)
        Me.GroupBox3.TabIndex = 234
        Me.GroupBox3.TabStop = False
        '
        'lCantidadOT
        '
        Me.lCantidadOT.AutoSize = True
        Me.lCantidadOT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCantidadOT.Location = New System.Drawing.Point(139, 7)
        Me.lCantidadOT.Name = "lCantidadOT"
        Me.lCantidadOT.Size = New System.Drawing.Size(16, 16)
        Me.lCantidadOT.TabIndex = 241
        Me.lCantidadOT.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 16)
        Me.Label7.TabIndex = 240
        Me.Label7.Text = "Cantidad de OT"
        '
        'xTabla
        '
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = resources.GetString("xTabla.ColumnInfo")
        Me.xTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.xTabla.Location = New System.Drawing.Point(6, 15)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 19
        Me.xTabla.Size = New System.Drawing.Size(878, 261)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 233
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.Location = New System.Drawing.Point(12, 511)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(100, 36)
        Me.bLimpiar.TabIndex = 1
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'bIngresoOT
        '
        Me.bIngresoOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bIngresoOT.BackColor = System.Drawing.Color.White
        Me.bIngresoOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bIngresoOT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bIngresoOT.Image = Global.SisVen.My.Resources.Resources.new24
        Me.bIngresoOT.Location = New System.Drawing.Point(118, 511)
        Me.bIngresoOT.Name = "bIngresoOT"
        Me.bIngresoOT.Size = New System.Drawing.Size(133, 36)
        Me.bIngresoOT.TabIndex = 2
        Me.bIngresoOT.Text = "Ingreso de OT"
        Me.bIngresoOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bIngresoOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bIngresoOT.UseVisualStyleBackColor = False
        '
        'bAnulacionOT
        '
        Me.bAnulacionOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bAnulacionOT.BackColor = System.Drawing.Color.White
        Me.bAnulacionOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bAnulacionOT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAnulacionOT.Image = Global.SisVen.My.Resources.Resources.null24
        Me.bAnulacionOT.Location = New System.Drawing.Point(257, 511)
        Me.bAnulacionOT.Name = "bAnulacionOT"
        Me.bAnulacionOT.Size = New System.Drawing.Size(100, 36)
        Me.bAnulacionOT.TabIndex = 3
        Me.bAnulacionOT.Text = "Anular"
        Me.bAnulacionOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bAnulacionOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bAnulacionOT.UseVisualStyleBackColor = False
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.BackColor = System.Drawing.Color.White
        Me.bImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bImprimir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.Image = Global.SisVen.My.Resources.Resources.print24
        Me.bImprimir.Location = New System.Drawing.Point(698, 511)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(100, 36)
        Me.bImprimir.TabIndex = 4
        Me.bImprimir.Text = "Imprimir"
        Me.bImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bImprimir.UseVisualStyleBackColor = False
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(804, 511)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(100, 36)
        Me.bCancelar.TabIndex = 5
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(484, 520)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(208, 20)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Imprimir Automáticamente"
        Me.CheckBox1.UseVisualStyleBackColor = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(916, 50)
        Me.WinDeco1.TabIndex = 0
        Me.WinDeco1.TituloVentana = "Consulta de OT"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = True
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'ConsultaOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 559)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bAnulacionOT)
        Me.Controls.Add(Me.bIngresoOT)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bConsultar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1295, 768)
        Me.Name = "ConsultaOT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisVen - Consulta OT"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents xOT As TextBox
    Friend WithEvents xNombreCliente As TextBox
    Friend WithEvents xCliente As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cEstados As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cTecnicos As ComboBox
    Friend WithEvents xTecnico As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cHasta As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents cDesde As DateTimePicker
    Friend WithEvents oFechaOT As RadioButton
    Friend WithEvents oFechaEnt As RadioButton
    Public WithEvents bBuscar As Button
    Public WithEvents bConsultar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents bLimpiar As Button
    Public WithEvents bIngresoOT As Button
    Public WithEvents bAnulacionOT As Button
    Public WithEvents bImprimir As Button
    Public WithEvents bCancelar As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lCantidadOT As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents xProgreso As ProgressBar
End Class
