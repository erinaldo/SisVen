<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlDTE_Emitidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlDTE_Emitidos))
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.gFiltro = New System.Windows.Forms.GroupBox()
        Me.bConsultar = New System.Windows.Forms.Button()
        Me.oRapido = New System.Windows.Forms.RadioButton()
        Me.oConsultar = New System.Windows.Forms.RadioButton()
        Me.oImprimir = New System.Windows.Forms.RadioButton()
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
        Me.gEspeciales = New System.Windows.Forms.GroupBox()
        Me.oWS = New System.Windows.Forms.CheckBox()
        Me.oCrearTED = New System.Windows.Forms.CheckBox()
        Me.oCheckTED = New System.Windows.Forms.CheckBox()
        Me.xTexto = New System.Windows.Forms.TextBox()
        Me.bProcesar = New System.Windows.Forms.Button()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.WinDeco1 = New SisVen.WinDeco()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gFiltro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gEspeciales.SuspendLayout()
        Me.SuspendLayout()
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(958, 484)
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
        Me.xTabla.Size = New System.Drawing.Size(1048, 269)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 116
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'gFiltro
        '
        Me.gFiltro.BackColor = System.Drawing.Color.Transparent
        Me.gFiltro.Controls.Add(Me.bConsultar)
        Me.gFiltro.Controls.Add(Me.oRapido)
        Me.gFiltro.Controls.Add(Me.oConsultar)
        Me.gFiltro.Controls.Add(Me.oImprimir)
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
        Me.gFiltro.Size = New System.Drawing.Size(666, 136)
        Me.gFiltro.TabIndex = 117
        Me.gFiltro.TabStop = False
        '
        'bConsultar
        '
        Me.bConsultar.BackColor = System.Drawing.Color.White
        Me.bConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConsultar.Image = Global.SisVen.My.Resources.Resources.find24
        Me.bConsultar.Location = New System.Drawing.Point(557, 9)
        Me.bConsultar.Name = "bConsultar"
        Me.bConsultar.Size = New System.Drawing.Size(103, 89)
        Me.bConsultar.TabIndex = 12
        Me.bConsultar.Text = "Consultar Documentos"
        Me.bConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bConsultar.UseVisualStyleBackColor = False
        '
        'oRapido
        '
        Me.oRapido.Appearance = System.Windows.Forms.Appearance.Button
        Me.oRapido.BackColor = System.Drawing.Color.White
        Me.oRapido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.oRapido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oRapido.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oRapido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.oRapido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.oRapido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oRapido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oRapido.ForeColor = System.Drawing.Color.Black
        Me.oRapido.Image = Global.SisVen.My.Resources.Resources.check16false_b
        Me.oRapido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.oRapido.Location = New System.Drawing.Point(376, 72)
        Me.oRapido.Name = "oRapido"
        Me.oRapido.Size = New System.Drawing.Size(173, 26)
        Me.oRapido.TabIndex = 52
        Me.oRapido.Text = "Chequeo Rápido"
        Me.oRapido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.oRapido.UseVisualStyleBackColor = False
        '
        'oConsultar
        '
        Me.oConsultar.Appearance = System.Windows.Forms.Appearance.Button
        Me.oConsultar.BackColor = System.Drawing.Color.White
        Me.oConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.oConsultar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oConsultar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oConsultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.oConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.oConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oConsultar.ForeColor = System.Drawing.Color.Black
        Me.oConsultar.Image = Global.SisVen.My.Resources.Resources.check16false_b
        Me.oConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.oConsultar.Location = New System.Drawing.Point(376, 10)
        Me.oConsultar.Name = "oConsultar"
        Me.oConsultar.Size = New System.Drawing.Size(173, 26)
        Me.oConsultar.TabIndex = 51
        Me.oConsultar.Text = "Consultar Documento"
        Me.oConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.oConsultar.UseVisualStyleBackColor = False
        '
        'oImprimir
        '
        Me.oImprimir.Appearance = System.Windows.Forms.Appearance.Button
        Me.oImprimir.BackColor = System.Drawing.Color.White
        Me.oImprimir.Checked = True
        Me.oImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.oImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oImprimir.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.oImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.oImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.oImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oImprimir.ForeColor = System.Drawing.Color.White
        Me.oImprimir.Image = Global.SisVen.My.Resources.Resources.check16true_b
        Me.oImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.oImprimir.Location = New System.Drawing.Point(376, 42)
        Me.oImprimir.Name = "oImprimir"
        Me.oImprimir.Size = New System.Drawing.Size(173, 24)
        Me.oImprimir.TabIndex = 50
        Me.oImprimir.TabStop = True
        Me.oImprimir.Text = "Imprimir Documento"
        Me.oImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.oImprimir.UseVisualStyleBackColor = False
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
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Local"
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
        Me.GroupBox1.Controls.Add(Me.gEspeciales)
        Me.GroupBox1.Controls.Add(Me.xTexto)
        Me.GroupBox1.Controls.Add(Me.bProcesar)
        Me.GroupBox1.Location = New System.Drawing.Point(681, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 136)
        Me.GroupBox1.TabIndex = 118
        Me.GroupBox1.TabStop = False
        '
        'gEspeciales
        '
        Me.gEspeciales.Controls.Add(Me.oWS)
        Me.gEspeciales.Controls.Add(Me.oCrearTED)
        Me.gEspeciales.Controls.Add(Me.oCheckTED)
        Me.gEspeciales.Location = New System.Drawing.Point(9, 87)
        Me.gEspeciales.Name = "gEspeciales"
        Me.gEspeciales.Size = New System.Drawing.Size(231, 40)
        Me.gEspeciales.TabIndex = 15
        Me.gEspeciales.TabStop = False
        Me.gEspeciales.Text = "Especiales"
        Me.gEspeciales.Visible = False
        '
        'oWS
        '
        Me.oWS.AutoSize = True
        Me.oWS.Location = New System.Drawing.Point(188, 18)
        Me.oWS.Name = "oWS"
        Me.oWS.Size = New System.Drawing.Size(44, 17)
        Me.oWS.TabIndex = 56
        Me.oWS.Text = "WS"
        Me.oWS.UseVisualStyleBackColor = True
        '
        'oCrearTED
        '
        Me.oCrearTED.AutoSize = True
        Me.oCrearTED.Location = New System.Drawing.Point(111, 18)
        Me.oCrearTED.Name = "oCrearTED"
        Me.oCrearTED.Size = New System.Drawing.Size(76, 17)
        Me.oCrearTED.TabIndex = 55
        Me.oCrearTED.Text = "Crear TED"
        Me.oCrearTED.UseVisualStyleBackColor = True
        '
        'oCheckTED
        '
        Me.oCheckTED.AutoSize = True
        Me.oCheckTED.Location = New System.Drawing.Point(11, 18)
        Me.oCheckTED.Name = "oCheckTED"
        Me.oCheckTED.Size = New System.Drawing.Size(97, 17)
        Me.oCheckTED.TabIndex = 54
        Me.oCheckTED.Text = "Chequear TED"
        Me.oCheckTED.UseVisualStyleBackColor = True
        '
        'xTexto
        '
        Me.xTexto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTexto.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xTexto.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTexto.Location = New System.Drawing.Point(6, 13)
        Me.xTexto.Multiline = True
        Me.xTexto.Name = "xTexto"
        Me.xTexto.Size = New System.Drawing.Size(364, 67)
        Me.xTexto.TabIndex = 14
        Me.xTexto.Text = "Seleccione los documentos a enviar a SII que no esten enviados o con algún error." &
    "  Si el documento esta aprobado con reparos, rechazado o ya fué enviado anterior" &
    "mente, SII  lo rechazará de nuevo. "
        Me.xTexto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bProcesar
        '
        Me.bProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bProcesar.BackColor = System.Drawing.Color.White
        Me.bProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bProcesar.Image = Global.SisVen.My.Resources.Resources.execute24
        Me.bProcesar.Location = New System.Drawing.Point(249, 92)
        Me.bProcesar.Name = "bProcesar"
        Me.bProcesar.Size = New System.Drawing.Size(121, 36)
        Me.bProcesar.TabIndex = 12
        Me.bProcesar.Text = "Procesar"
        Me.bProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bProcesar.UseVisualStyleBackColor = False
        '
        'lStatus
        '
        Me.lStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lStatus.AutoSize = True
        Me.lStatus.BackColor = System.Drawing.Color.Transparent
        Me.lStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatus.ForeColor = System.Drawing.Color.Yellow
        Me.lStatus.Location = New System.Drawing.Point(112, 484)
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
        Me.WinDeco1.Size = New System.Drawing.Size(1066, 50)
        Me.WinDeco1.TabIndex = 98
        Me.WinDeco1.TituloVentana = "Control Documentos DTE Emitidos"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = True
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'ControlDTE_Emitidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 532)
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
        Me.Name = "ControlDTE_Emitidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ControlDTE"
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gFiltro.ResumeLayout(False)
        Me.gFiltro.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gEspeciales.ResumeLayout(False)
        Me.gEspeciales.PerformLayout()
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
    Friend WithEvents lStatus As Label
    Friend WithEvents xTexto As TextBox
    Friend WithEvents oImprimir As RadioButton
    Friend WithEvents oConsultar As RadioButton
    Friend WithEvents oRapido As RadioButton
    Friend WithEvents gEspeciales As GroupBox
    Friend WithEvents oCrearTED As CheckBox
    Friend WithEvents oCheckTED As CheckBox
    Friend WithEvents oWS As CheckBox
End Class
