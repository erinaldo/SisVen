<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Documentos))
        Me.fGeneral = New System.Windows.Forms.GroupBox()
        Me.xTipoDocRef = New System.Windows.Forms.TextBox()
        Me.xNombre = New System.Windows.Forms.TextBox()
        Me.xRut = New System.Windows.Forms.MaskedTextBox()
        Me.xFechaDocRef = New System.Windows.Forms.DateTimePicker()
        Me.xTipoDoc = New System.Windows.Forms.TextBox()
        Me.lMotivo = New System.Windows.Forms.Label()
        Me.cMotivo = New System.Windows.Forms.ComboBox()
        Me.xNumero = New System.Windows.Forms.TextBox()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.xLocal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cTipoDocRef = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bCrearCli = New System.Windows.Forms.Button()
        Me.bProcesarDoc = New System.Windows.Forms.Button()
        Me.xFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.xComuna = New System.Windows.Forms.TextBox()
        Me.xCiudad = New System.Windows.Forms.TextBox()
        Me.bBuscarCli = New System.Windows.Forms.Button()
        Me.xNomVen = New System.Windows.Forms.TextBox()
        Me.xVendedor = New System.Windows.Forms.TextBox()
        Me.oElectronica = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.xNumDocRef = New System.Windows.Forms.TextBox()
        Me.cTipoDoc = New System.Windows.Forms.ComboBox()
        Me.cFPago = New System.Windows.Forms.ComboBox()
        Me.xDireccion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lNombre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fDetalles = New System.Windows.Forms.GroupBox()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bLimpiarArt = New System.Windows.Forms.Button()
        Me.xArticulo = New System.Windows.Forms.TextBox()
        Me.BuscarArt = New System.Windows.Forms.Button()
        Me.bEliminar = New System.Windows.Forms.Button()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.xDescripcion = New System.Windows.Forms.TextBox()
        Me.fObservaciones = New System.Windows.Forms.GroupBox()
        Me.xObs = New System.Windows.Forms.TextBox()
        Me.fTotales = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.xTotal = New System.Windows.Forms.TextBox()
        Me.xImpuestos = New System.Windows.Forms.TextBox()
        Me.xIVA = New System.Windows.Forms.TextBox()
        Me.xNeto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.xDescuento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.xSubTotal = New System.Windows.Forms.TextBox()
        Me.fImpuestos = New System.Windows.Forms.GroupBox()
        Me.xFEP = New System.Windows.Forms.TextBox()
        Me.Tabacos = New System.Windows.Forms.Label()
        Me.xTAB = New System.Windows.Forms.TextBox()
        Me.xHAR = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.xCAR = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.xLIC = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.xVIN = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.xCER = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.xBEB = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.xMIN = New System.Windows.Forms.TextBox()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Limpiar = New System.Windows.Forms.Button()
        Me.nLineas = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Salir = New System.Windows.Forms.Button()
        Me.bDirectorio = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.xBodega = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.fGeneral.SuspendLayout()
        Me.fDetalles.SuspendLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fObservaciones.SuspendLayout()
        Me.fTotales.SuspendLayout()
        Me.fImpuestos.SuspendLayout()
        Me.SuspendLayout()
        '
        'fGeneral
        '
        Me.fGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fGeneral.BackColor = System.Drawing.Color.Transparent
        Me.fGeneral.Controls.Add(Me.xBodega)
        Me.fGeneral.Controls.Add(Me.Label29)
        Me.fGeneral.Controls.Add(Me.xTipoDocRef)
        Me.fGeneral.Controls.Add(Me.xNombre)
        Me.fGeneral.Controls.Add(Me.xRut)
        Me.fGeneral.Controls.Add(Me.xFechaDocRef)
        Me.fGeneral.Controls.Add(Me.xTipoDoc)
        Me.fGeneral.Controls.Add(Me.lMotivo)
        Me.fGeneral.Controls.Add(Me.cMotivo)
        Me.fGeneral.Controls.Add(Me.xNumero)
        Me.fGeneral.Controls.Add(Me.xCliente)
        Me.fGeneral.Controls.Add(Me.xLocal)
        Me.fGeneral.Controls.Add(Me.Label9)
        Me.fGeneral.Controls.Add(Me.cTipoDocRef)
        Me.fGeneral.Controls.Add(Me.Label10)
        Me.fGeneral.Controls.Add(Me.bCrearCli)
        Me.fGeneral.Controls.Add(Me.bProcesarDoc)
        Me.fGeneral.Controls.Add(Me.xFecha)
        Me.fGeneral.Controls.Add(Me.Label6)
        Me.fGeneral.Controls.Add(Me.Label5)
        Me.fGeneral.Controls.Add(Me.Label3)
        Me.fGeneral.Controls.Add(Me.Label2)
        Me.fGeneral.Controls.Add(Me.xComuna)
        Me.fGeneral.Controls.Add(Me.xCiudad)
        Me.fGeneral.Controls.Add(Me.bBuscarCli)
        Me.fGeneral.Controls.Add(Me.xNomVen)
        Me.fGeneral.Controls.Add(Me.xVendedor)
        Me.fGeneral.Controls.Add(Me.oElectronica)
        Me.fGeneral.Controls.Add(Me.Label8)
        Me.fGeneral.Controls.Add(Me.xNumDocRef)
        Me.fGeneral.Controls.Add(Me.cTipoDoc)
        Me.fGeneral.Controls.Add(Me.cFPago)
        Me.fGeneral.Controls.Add(Me.xDireccion)
        Me.fGeneral.Controls.Add(Me.Label11)
        Me.fGeneral.Controls.Add(Me.Label7)
        Me.fGeneral.Controls.Add(Me.lNombre)
        Me.fGeneral.Controls.Add(Me.Label4)
        Me.fGeneral.Controls.Add(Me.Label1)
        Me.fGeneral.Location = New System.Drawing.Point(12, 56)
        Me.fGeneral.Name = "fGeneral"
        Me.fGeneral.Size = New System.Drawing.Size(914, 171)
        Me.fGeneral.TabIndex = 98
        Me.fGeneral.TabStop = False
        Me.fGeneral.Text = "Datos Generales"
        '
        'xTipoDocRef
        '
        Me.xTipoDocRef.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xTipoDocRef.Location = New System.Drawing.Point(690, 140)
        Me.xTipoDocRef.Name = "xTipoDocRef"
        Me.xTipoDocRef.ReadOnly = True
        Me.xTipoDocRef.Size = New System.Drawing.Size(23, 20)
        Me.xTipoDocRef.TabIndex = 129
        Me.xTipoDocRef.TabStop = False
        Me.xTipoDocRef.Visible = False
        '
        'xNombre
        '
        Me.xNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xNombre.Location = New System.Drawing.Point(197, 93)
        Me.xNombre.MaxLength = 50
        Me.xNombre.Name = "xNombre"
        Me.xNombre.ReadOnly = True
        Me.xNombre.Size = New System.Drawing.Size(397, 20)
        Me.xNombre.TabIndex = 127
        '
        'xRut
        '
        Me.xRut.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xRut.Location = New System.Drawing.Point(116, 93)
        Me.xRut.Mask = "##,###,###-A"
        Me.xRut.Name = "xRut"
        Me.xRut.ReadOnly = True
        Me.xRut.Size = New System.Drawing.Size(75, 20)
        Me.xRut.TabIndex = 3
        '
        'xFechaDocRef
        '
        Me.xFechaDocRef.Enabled = False
        Me.xFechaDocRef.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.xFechaDocRef.Location = New System.Drawing.Point(600, 140)
        Me.xFechaDocRef.Name = "xFechaDocRef"
        Me.xFechaDocRef.Size = New System.Drawing.Size(86, 20)
        Me.xFechaDocRef.TabIndex = 128
        Me.xFechaDocRef.Value = New Date(2018, 1, 1, 0, 0, 0, 0)
        '
        'xTipoDoc
        '
        Me.xTipoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xTipoDoc.Location = New System.Drawing.Point(366, 21)
        Me.xTipoDoc.Name = "xTipoDoc"
        Me.xTipoDoc.ReadOnly = True
        Me.xTipoDoc.Size = New System.Drawing.Size(23, 20)
        Me.xTipoDoc.TabIndex = 126
        Me.xTipoDoc.TabStop = False
        Me.xTipoDoc.Visible = False
        '
        'lMotivo
        '
        Me.lMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lMotivo.AutoSize = True
        Me.lMotivo.Location = New System.Drawing.Point(716, 143)
        Me.lMotivo.Name = "lMotivo"
        Me.lMotivo.Size = New System.Drawing.Size(39, 13)
        Me.lMotivo.TabIndex = 125
        Me.lMotivo.Text = "Motivo"
        '
        'cMotivo
        '
        Me.cMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMotivo.FormattingEnabled = True
        Me.cMotivo.Location = New System.Drawing.Point(757, 140)
        Me.cMotivo.Name = "cMotivo"
        Me.cMotivo.Size = New System.Drawing.Size(151, 21)
        Me.cMotivo.TabIndex = 124
        '
        'xNumero
        '
        Me.xNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.xNumero.Location = New System.Drawing.Point(116, 42)
        Me.xNumero.MaxLength = 18
        Me.xNumero.Name = "xNumero"
        Me.xNumero.ReadOnly = True
        Me.xNumero.Size = New System.Drawing.Size(75, 24)
        Me.xNumero.TabIndex = 1
        Me.xNumero.TabStop = False
        Me.xNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xCliente
        '
        Me.xCliente.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.xCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.xCliente.Location = New System.Drawing.Point(116, 70)
        Me.xCliente.MaxLength = 18
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(75, 24)
        Me.xCliente.TabIndex = 2
        Me.xCliente.TabStop = False
        Me.xCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xLocal
        '
        Me.xLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xLocal.Location = New System.Drawing.Point(447, 21)
        Me.xLocal.Name = "xLocal"
        Me.xLocal.ReadOnly = True
        Me.xLocal.Size = New System.Drawing.Size(147, 20)
        Me.xLocal.TabIndex = 121
        Me.xLocal.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(408, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Local"
        '
        'cTipoDocRef
        '
        Me.cTipoDocRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTipoDocRef.FormattingEnabled = True
        Me.cTipoDocRef.Location = New System.Drawing.Point(116, 139)
        Me.cTipoDocRef.Name = "cTipoDocRef"
        Me.cTipoDocRef.Size = New System.Drawing.Size(244, 21)
        Me.cTipoDocRef.TabIndex = 118
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Doc. Referencia"
        '
        'bCrearCli
        '
        Me.bCrearCli.BackColor = System.Drawing.Color.White
        Me.bCrearCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCrearCli.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCrearCli.Image = Global.SisVen.My.Resources.Resources.new16
        Me.bCrearCli.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bCrearCli.Location = New System.Drawing.Point(280, 68)
        Me.bCrearCli.Name = "bCrearCli"
        Me.bCrearCli.Size = New System.Drawing.Size(80, 24)
        Me.bCrearCli.TabIndex = 116
        Me.bCrearCli.Text = "Nuevo"
        Me.bCrearCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCrearCli.UseVisualStyleBackColor = False
        '
        'bProcesarDoc
        '
        Me.bProcesarDoc.Location = New System.Drawing.Point(447, 138)
        Me.bProcesarDoc.Name = "bProcesarDoc"
        Me.bProcesarDoc.Size = New System.Drawing.Size(147, 22)
        Me.bProcesarDoc.TabIndex = 114
        Me.bProcesarDoc.Text = "Procesar Documento"
        Me.bProcesarDoc.UseVisualStyleBackColor = True
        '
        'xFecha
        '
        Me.xFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.xFecha.Location = New System.Drawing.Point(757, 25)
        Me.xFecha.Name = "xFecha"
        Me.xFecha.Size = New System.Drawing.Size(151, 20)
        Me.xFecha.TabIndex = 113
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(672, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Forma de Pago"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(672, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Fecha Emisión"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(754, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Comuna"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(597, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Ciudad"
        '
        'xComuna
        '
        Me.xComuna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xComuna.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xComuna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xComuna.Location = New System.Drawing.Point(757, 113)
        Me.xComuna.MaxLength = 50
        Me.xComuna.Name = "xComuna"
        Me.xComuna.ReadOnly = True
        Me.xComuna.Size = New System.Drawing.Size(151, 20)
        Me.xComuna.TabIndex = 107
        '
        'xCiudad
        '
        Me.xCiudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xCiudad.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xCiudad.Location = New System.Drawing.Point(600, 114)
        Me.xCiudad.MaxLength = 50
        Me.xCiudad.Name = "xCiudad"
        Me.xCiudad.ReadOnly = True
        Me.xCiudad.Size = New System.Drawing.Size(151, 20)
        Me.xCiudad.TabIndex = 106
        '
        'bBuscarCli
        '
        Me.bBuscarCli.BackColor = System.Drawing.Color.White
        Me.bBuscarCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarCli.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCli.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscarCli.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bBuscarCli.Location = New System.Drawing.Point(197, 68)
        Me.bBuscarCli.Margin = New System.Windows.Forms.Padding(0)
        Me.bBuscarCli.Name = "bBuscarCli"
        Me.bBuscarCli.Size = New System.Drawing.Size(80, 24)
        Me.bBuscarCli.TabIndex = 105
        Me.bBuscarCli.Text = "Buscar"
        Me.bBuscarCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarCli.UseVisualStyleBackColor = False
        '
        'xNomVen
        '
        Me.xNomVen.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xNomVen.Location = New System.Drawing.Point(447, 68)
        Me.xNomVen.Name = "xNomVen"
        Me.xNomVen.ReadOnly = True
        Me.xNomVen.Size = New System.Drawing.Size(147, 20)
        Me.xNomVen.TabIndex = 104
        Me.xNomVen.TabStop = False
        Me.xNomVen.Visible = False
        '
        'xVendedor
        '
        Me.xVendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xVendedor.Location = New System.Drawing.Point(757, 68)
        Me.xVendedor.MaxLength = 18
        Me.xVendedor.Name = "xVendedor"
        Me.xVendedor.Size = New System.Drawing.Size(151, 20)
        Me.xVendedor.TabIndex = 10
        '
        'oElectronica
        '
        Me.oElectronica.AutoSize = True
        Me.oElectronica.Checked = True
        Me.oElectronica.CheckState = System.Windows.Forms.CheckState.Checked
        Me.oElectronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oElectronica.ForeColor = System.Drawing.Color.Red
        Me.oElectronica.Location = New System.Drawing.Point(197, 49)
        Me.oElectronica.Name = "oElectronica"
        Me.oElectronica.Size = New System.Drawing.Size(158, 17)
        Me.oElectronica.TabIndex = 9
        Me.oElectronica.Text = "Documento Electrónico"
        Me.oElectronica.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Dirección"
        '
        'xNumDocRef
        '
        Me.xNumDocRef.Location = New System.Drawing.Point(366, 139)
        Me.xNumDocRef.MaxLength = 18
        Me.xNumDocRef.Name = "xNumDocRef"
        Me.xNumDocRef.Size = New System.Drawing.Size(75, 20)
        Me.xNumDocRef.TabIndex = 7
        '
        'cTipoDoc
        '
        Me.cTipoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cTipoDoc.FormattingEnabled = True
        Me.cTipoDoc.Location = New System.Drawing.Point(116, 19)
        Me.cTipoDoc.Name = "cTipoDoc"
        Me.cTipoDoc.Size = New System.Drawing.Size(244, 24)
        Me.cTipoDoc.TabIndex = 0
        '
        'cFPago
        '
        Me.cFPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cFPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cFPago.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cFPago.FormattingEnabled = True
        Me.cFPago.Location = New System.Drawing.Point(757, 46)
        Me.cFPago.Name = "cFPago"
        Me.cFPago.Size = New System.Drawing.Size(151, 21)
        Me.cFPago.TabIndex = 3
        '
        'xDireccion
        '
        Me.xDireccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xDireccion.Location = New System.Drawing.Point(116, 113)
        Me.xDireccion.MaxLength = 50
        Me.xDireccion.Name = "xDireccion"
        Me.xDireccion.ReadOnly = True
        Me.xDireccion.Size = New System.Drawing.Size(478, 20)
        Me.xDireccion.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(672, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Vendedor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Número Documento"
        '
        'lNombre
        '
        Me.lNombre.AutoSize = True
        Me.lNombre.Location = New System.Drawing.Point(9, 96)
        Me.lNombre.Name = "lNombre"
        Me.lNombre.Size = New System.Drawing.Size(44, 13)
        Me.lNombre.TabIndex = 81
        Me.lNombre.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Tipo de Documento"
        '
        'fDetalles
        '
        Me.fDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fDetalles.BackColor = System.Drawing.Color.Transparent
        Me.fDetalles.Controls.Add(Me.xTabla)
        Me.fDetalles.Controls.Add(Me.bLimpiarArt)
        Me.fDetalles.Controls.Add(Me.xArticulo)
        Me.fDetalles.Controls.Add(Me.BuscarArt)
        Me.fDetalles.Controls.Add(Me.bEliminar)
        Me.fDetalles.Controls.Add(Me.Agregar)
        Me.fDetalles.Controls.Add(Me.Label13)
        Me.fDetalles.Controls.Add(Me.Label12)
        Me.fDetalles.Controls.Add(Me.xDescripcion)
        Me.fDetalles.Location = New System.Drawing.Point(12, 233)
        Me.fDetalles.Name = "fDetalles"
        Me.fDetalles.Size = New System.Drawing.Size(914, 215)
        Me.fDetalles.TabIndex = 100
        Me.fDetalles.TabStop = False
        Me.fDetalles.Text = "Detalles"
        '
        'xTabla
        '
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = resources.GetString("xTabla.ColumnInfo")
        Me.xTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.xTabla.Location = New System.Drawing.Point(11, 68)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 19
        Me.xTabla.Size = New System.Drawing.Size(897, 141)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 115
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'bLimpiarArt
        '
        Me.bLimpiarArt.BackColor = System.Drawing.Color.White
        Me.bLimpiarArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiarArt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiarArt.Image = Global.SisVen.My.Resources.Resources.clean16
        Me.bLimpiarArt.Location = New System.Drawing.Point(529, 15)
        Me.bLimpiarArt.Name = "bLimpiarArt"
        Me.bLimpiarArt.Size = New System.Drawing.Size(80, 24)
        Me.bLimpiarArt.TabIndex = 113
        Me.bLimpiarArt.Text = "Limpiar"
        Me.bLimpiarArt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiarArt.UseVisualStyleBackColor = False
        '
        'xArticulo
        '
        Me.xArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xArticulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.xArticulo.Location = New System.Drawing.Point(116, 15)
        Me.xArticulo.MaxLength = 18
        Me.xArticulo.Name = "xArticulo"
        Me.xArticulo.Size = New System.Drawing.Size(161, 24)
        Me.xArticulo.TabIndex = 112
        Me.xArticulo.TabStop = False
        Me.xArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BuscarArt
        '
        Me.BuscarArt.BackColor = System.Drawing.Color.White
        Me.BuscarArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BuscarArt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarArt.Image = Global.SisVen.My.Resources.Resources.find
        Me.BuscarArt.Location = New System.Drawing.Point(446, 15)
        Me.BuscarArt.Name = "BuscarArt"
        Me.BuscarArt.Size = New System.Drawing.Size(80, 24)
        Me.BuscarArt.TabIndex = 111
        Me.BuscarArt.Text = "Buscar"
        Me.BuscarArt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarArt.UseVisualStyleBackColor = False
        '
        'bEliminar
        '
        Me.bEliminar.BackColor = System.Drawing.Color.White
        Me.bEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bEliminar.Image = Global.SisVen.My.Resources.Resources.remove
        Me.bEliminar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.bEliminar.Location = New System.Drawing.Point(363, 15)
        Me.bEliminar.Margin = New System.Windows.Forms.Padding(0)
        Me.bEliminar.Name = "bEliminar"
        Me.bEliminar.Size = New System.Drawing.Size(80, 24)
        Me.bEliminar.TabIndex = 110
        Me.bEliminar.Text = "Quitar"
        Me.bEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bEliminar.UseVisualStyleBackColor = False
        '
        'Agregar
        '
        Me.Agregar.BackColor = System.Drawing.Color.White
        Me.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Agregar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Agregar.Image = Global.SisVen.My.Resources.Resources.load
        Me.Agregar.Location = New System.Drawing.Point(280, 15)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(80, 24)
        Me.Agregar.TabIndex = 109
        Me.Agregar.Text = "Agregar"
        Me.Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Agregar.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 108
        Me.Label13.Text = "Descripción"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Artículo"
        '
        'xDescripcion
        '
        Me.xDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xDescripcion.Location = New System.Drawing.Point(116, 42)
        Me.xDescripcion.Name = "xDescripcion"
        Me.xDescripcion.ReadOnly = True
        Me.xDescripcion.Size = New System.Drawing.Size(792, 20)
        Me.xDescripcion.TabIndex = 106
        Me.xDescripcion.TabStop = False
        '
        'fObservaciones
        '
        Me.fObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fObservaciones.BackColor = System.Drawing.Color.Transparent
        Me.fObservaciones.Controls.Add(Me.xObs)
        Me.fObservaciones.Location = New System.Drawing.Point(12, 454)
        Me.fObservaciones.Name = "fObservaciones"
        Me.fObservaciones.Size = New System.Drawing.Size(282, 154)
        Me.fObservaciones.TabIndex = 101
        Me.fObservaciones.TabStop = False
        Me.fObservaciones.Text = "Observaciones"
        '
        'xObs
        '
        Me.xObs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xObs.Location = New System.Drawing.Point(11, 19)
        Me.xObs.MaxLength = 4000
        Me.xObs.Multiline = True
        Me.xObs.Name = "xObs"
        Me.xObs.Size = New System.Drawing.Size(260, 129)
        Me.xObs.TabIndex = 11
        '
        'fTotales
        '
        Me.fTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fTotales.BackColor = System.Drawing.Color.Transparent
        Me.fTotales.Controls.Add(Me.Label20)
        Me.fTotales.Controls.Add(Me.Label19)
        Me.fTotales.Controls.Add(Me.Label18)
        Me.fTotales.Controls.Add(Me.Label17)
        Me.fTotales.Controls.Add(Me.xTotal)
        Me.fTotales.Controls.Add(Me.xImpuestos)
        Me.fTotales.Controls.Add(Me.xIVA)
        Me.fTotales.Controls.Add(Me.xNeto)
        Me.fTotales.Controls.Add(Me.Label16)
        Me.fTotales.Controls.Add(Me.xDescuento)
        Me.fTotales.Controls.Add(Me.Label14)
        Me.fTotales.Controls.Add(Me.xSubTotal)
        Me.fTotales.Location = New System.Drawing.Point(671, 454)
        Me.fTotales.Name = "fTotales"
        Me.fTotales.Size = New System.Drawing.Size(255, 154)
        Me.fTotales.TabIndex = 102
        Me.fTotales.TabStop = False
        Me.fTotales.Text = "Totales"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label20.Location = New System.Drawing.Point(6, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 16)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "TOTAL"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label19.Location = New System.Drawing.Point(6, 106)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 16)
        Me.Label19.TabIndex = 133
        Me.Label19.Text = "Otros Impuestos"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label18.Location = New System.Drawing.Point(6, 84)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 16)
        Me.Label18.TabIndex = 132
        Me.Label18.Text = "IVA"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Location = New System.Drawing.Point(6, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 16)
        Me.Label17.TabIndex = 131
        Me.Label17.Text = "Neto"
        '
        'xTotal
        '
        Me.xTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTotal.BackColor = System.Drawing.Color.Red
        Me.xTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTotal.ForeColor = System.Drawing.Color.Yellow
        Me.xTotal.Location = New System.Drawing.Point(136, 123)
        Me.xTotal.MaxLength = 18
        Me.xTotal.Name = "xTotal"
        Me.xTotal.Size = New System.Drawing.Size(113, 24)
        Me.xTotal.TabIndex = 128
        Me.xTotal.TabStop = False
        Me.xTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xImpuestos
        '
        Me.xImpuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xImpuestos.BackColor = System.Drawing.Color.Blue
        Me.xImpuestos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xImpuestos.ForeColor = System.Drawing.Color.Yellow
        Me.xImpuestos.Location = New System.Drawing.Point(136, 101)
        Me.xImpuestos.MaxLength = 18
        Me.xImpuestos.Name = "xImpuestos"
        Me.xImpuestos.Size = New System.Drawing.Size(113, 24)
        Me.xImpuestos.TabIndex = 127
        Me.xImpuestos.TabStop = False
        Me.xImpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xIVA
        '
        Me.xIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xIVA.BackColor = System.Drawing.Color.Blue
        Me.xIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xIVA.ForeColor = System.Drawing.Color.Yellow
        Me.xIVA.Location = New System.Drawing.Point(136, 79)
        Me.xIVA.MaxLength = 18
        Me.xIVA.Name = "xIVA"
        Me.xIVA.Size = New System.Drawing.Size(113, 24)
        Me.xIVA.TabIndex = 126
        Me.xIVA.TabStop = False
        Me.xIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xNeto
        '
        Me.xNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xNeto.BackColor = System.Drawing.Color.Blue
        Me.xNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNeto.ForeColor = System.Drawing.Color.Yellow
        Me.xNeto.Location = New System.Drawing.Point(136, 57)
        Me.xNeto.MaxLength = 18
        Me.xNeto.Name = "xNeto"
        Me.xNeto.Size = New System.Drawing.Size(113, 24)
        Me.xNeto.TabIndex = 125
        Me.xNeto.TabStop = False
        Me.xNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label16.Location = New System.Drawing.Point(6, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 16)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "Descuentos"
        '
        'xDescuento
        '
        Me.xDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.xDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xDescuento.ForeColor = System.Drawing.Color.Yellow
        Me.xDescuento.Location = New System.Drawing.Point(136, 35)
        Me.xDescuento.MaxLength = 18
        Me.xDescuento.Name = "xDescuento"
        Me.xDescuento.Size = New System.Drawing.Size(113, 24)
        Me.xDescuento.TabIndex = 124
        Me.xDescuento.TabStop = False
        Me.xDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label14.Location = New System.Drawing.Point(6, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 16)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Sub Total"
        '
        'xSubTotal
        '
        Me.xSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xSubTotal.ForeColor = System.Drawing.Color.Yellow
        Me.xSubTotal.Location = New System.Drawing.Point(136, 14)
        Me.xSubTotal.MaxLength = 18
        Me.xSubTotal.Name = "xSubTotal"
        Me.xSubTotal.Size = New System.Drawing.Size(113, 24)
        Me.xSubTotal.TabIndex = 123
        Me.xSubTotal.TabStop = False
        Me.xSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fImpuestos
        '
        Me.fImpuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fImpuestos.BackColor = System.Drawing.Color.Transparent
        Me.fImpuestos.Controls.Add(Me.xFEP)
        Me.fImpuestos.Controls.Add(Me.Tabacos)
        Me.fImpuestos.Controls.Add(Me.xTAB)
        Me.fImpuestos.Controls.Add(Me.xHAR)
        Me.fImpuestos.Controls.Add(Me.Label27)
        Me.fImpuestos.Controls.Add(Me.xCAR)
        Me.fImpuestos.Controls.Add(Me.Label26)
        Me.fImpuestos.Controls.Add(Me.xLIC)
        Me.fImpuestos.Controls.Add(Me.Label25)
        Me.fImpuestos.Controls.Add(Me.xVIN)
        Me.fImpuestos.Controls.Add(Me.Label24)
        Me.fImpuestos.Controls.Add(Me.xCER)
        Me.fImpuestos.Controls.Add(Me.Label23)
        Me.fImpuestos.Controls.Add(Me.xBEB)
        Me.fImpuestos.Controls.Add(Me.Label22)
        Me.fImpuestos.Controls.Add(Me.Label21)
        Me.fImpuestos.Controls.Add(Me.Label15)
        Me.fImpuestos.Controls.Add(Me.xMIN)
        Me.fImpuestos.Location = New System.Drawing.Point(300, 454)
        Me.fImpuestos.Name = "fImpuestos"
        Me.fImpuestos.Size = New System.Drawing.Size(365, 13)
        Me.fImpuestos.TabIndex = 103
        Me.fImpuestos.TabStop = False
        Me.fImpuestos.Text = "Impuestos"
        Me.fImpuestos.Visible = False
        '
        'xFEP
        '
        Me.xFEP.Location = New System.Drawing.Point(277, 165)
        Me.xFEP.MaxLength = 18
        Me.xFEP.Name = "xFEP"
        Me.xFEP.Size = New System.Drawing.Size(75, 20)
        Me.xFEP.TabIndex = 100
        Me.xFEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tabacos
        '
        Me.Tabacos.AutoSize = True
        Me.Tabacos.BackColor = System.Drawing.Color.Transparent
        Me.Tabacos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabacos.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Tabacos.Location = New System.Drawing.Point(6, 149)
        Me.Tabacos.Name = "Tabacos"
        Me.Tabacos.Size = New System.Drawing.Size(56, 13)
        Me.Tabacos.TabIndex = 115
        Me.Tabacos.Text = "Tabacos"
        '
        'xTAB
        '
        Me.xTAB.Location = New System.Drawing.Point(277, 146)
        Me.xTAB.MaxLength = 18
        Me.xTAB.Name = "xTAB"
        Me.xTAB.Size = New System.Drawing.Size(75, 20)
        Me.xTAB.TabIndex = 108
        Me.xTAB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xHAR
        '
        Me.xHAR.Location = New System.Drawing.Point(277, 127)
        Me.xHAR.MaxLength = 18
        Me.xHAR.Name = "xHAR"
        Me.xHAR.Size = New System.Drawing.Size(75, 20)
        Me.xHAR.TabIndex = 107
        Me.xHAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label27.Location = New System.Drawing.Point(6, 130)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 13)
        Me.Label27.TabIndex = 112
        Me.Label27.Text = "Harinas"
        '
        'xCAR
        '
        Me.xCAR.Location = New System.Drawing.Point(277, 108)
        Me.xCAR.MaxLength = 18
        Me.xCAR.Name = "xCAR"
        Me.xCAR.Size = New System.Drawing.Size(75, 20)
        Me.xCAR.TabIndex = 106
        Me.xCAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label26.Location = New System.Drawing.Point(6, 112)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 13)
        Me.Label26.TabIndex = 110
        Me.Label26.Text = "Carnes"
        '
        'xLIC
        '
        Me.xLIC.Location = New System.Drawing.Point(277, 89)
        Me.xLIC.MaxLength = 18
        Me.xLIC.Name = "xLIC"
        Me.xLIC.Size = New System.Drawing.Size(75, 20)
        Me.xLIC.TabIndex = 105
        Me.xLIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label25.Location = New System.Drawing.Point(6, 92)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(252, 13)
        Me.Label25.TabIndex = 108
        Me.Label25.Text = "Licores, Piscos, Whisky y otras alcohólicas"
        '
        'xVIN
        '
        Me.xVIN.Location = New System.Drawing.Point(277, 70)
        Me.xVIN.MaxLength = 18
        Me.xVIN.Name = "xVIN"
        Me.xVIN.Size = New System.Drawing.Size(75, 20)
        Me.xVIN.TabIndex = 104
        Me.xVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label24.Location = New System.Drawing.Point(6, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(119, 13)
        Me.Label24.TabIndex = 106
        Me.Label24.Text = "Vinos y espumantes"
        '
        'xCER
        '
        Me.xCER.Location = New System.Drawing.Point(277, 51)
        Me.xCER.MaxLength = 18
        Me.xCER.Name = "xCER"
        Me.xCER.Size = New System.Drawing.Size(75, 20)
        Me.xCER.TabIndex = 103
        Me.xCER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label23.Location = New System.Drawing.Point(6, 54)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(187, 13)
        Me.Label23.TabIndex = 104
        Me.Label23.Text = "Cervezas y Bebidas Alcohólicas"
        '
        'xBEB
        '
        Me.xBEB.Location = New System.Drawing.Point(277, 32)
        Me.xBEB.MaxLength = 18
        Me.xBEB.Name = "xBEB"
        Me.xBEB.Size = New System.Drawing.Size(75, 20)
        Me.xBEB.TabIndex = 102
        Me.xBEB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label22.Location = New System.Drawing.Point(6, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(166, 13)
        Me.Label22.TabIndex = 102
        Me.Label22.Text = "Bebidas, Jugos e Isotónicos"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(243, 13)
        Me.Label21.TabIndex = 100
        Me.Label21.Text = "Bebidas analcohólicas, aguas y minerales"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label15.Location = New System.Drawing.Point(6, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Combustibles"
        '
        'xMIN
        '
        Me.xMIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xMIN.Location = New System.Drawing.Point(277, 13)
        Me.xMIN.MaxLength = 18
        Me.xMIN.Name = "xMIN"
        Me.xMIN.Size = New System.Drawing.Size(75, 20)
        Me.xMIN.TabIndex = 101
        Me.xMIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Aceptar
        '
        Me.Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Aceptar.BackColor = System.Drawing.Color.White
        Me.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Aceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aceptar.Image = Global.SisVen.My.Resources.Resources.ok24
        Me.Aceptar.Location = New System.Drawing.Point(744, 628)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(88, 36)
        Me.Aceptar.TabIndex = 105
        Me.Aceptar.Text = "Aceptar"
        Me.Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Aceptar.UseVisualStyleBackColor = False
        '
        'Limpiar
        '
        Me.Limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Limpiar.BackColor = System.Drawing.Color.White
        Me.Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Limpiar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Limpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.Limpiar.Location = New System.Drawing.Point(12, 628)
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(88, 36)
        Me.Limpiar.TabIndex = 106
        Me.Limpiar.Text = "Limpiar"
        Me.Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Limpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Limpiar.UseVisualStyleBackColor = False
        '
        'nLineas
        '
        Me.nLineas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nLineas.BackColor = System.Drawing.Color.Yellow
        Me.nLineas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nLineas.ForeColor = System.Drawing.Color.Black
        Me.nLineas.Location = New System.Drawing.Point(379, 635)
        Me.nLineas.MaxLength = 18
        Me.nLineas.Name = "nLineas"
        Me.nLineas.Size = New System.Drawing.Size(46, 22)
        Me.nLineas.TabIndex = 108
        Me.nLineas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Yellow
        Me.Label28.Location = New System.Drawing.Point(431, 640)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 13)
        Me.Label28.TabIndex = 111
        Me.Label28.Text = "N° Lineas"
        '
        'Salir
        '
        Me.Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Salir.BackColor = System.Drawing.Color.White
        Me.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Salir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Salir.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.Salir.Location = New System.Drawing.Point(838, 628)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(88, 36)
        Me.Salir.TabIndex = 112
        Me.Salir.Text = "Cancelar"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Salir.UseVisualStyleBackColor = False
        '
        'bDirectorio
        '
        Me.bDirectorio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bDirectorio.BackColor = System.Drawing.Color.White
        Me.bDirectorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bDirectorio.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDirectorio.Image = Global.SisVen.My.Resources.Resources.report24
        Me.bDirectorio.Location = New System.Drawing.Point(111, 628)
        Me.bDirectorio.Name = "bDirectorio"
        Me.bDirectorio.Size = New System.Drawing.Size(251, 37)
        Me.bDirectorio.TabIndex = 120
        Me.bDirectorio.Text = "Abrir Directorio de Documentos"
        Me.bDirectorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bDirectorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bDirectorio.UseVisualStyleBackColor = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(938, 50)
        Me.WinDeco1.TabIndex = 97
        Me.WinDeco1.TituloVentana = "Emisión de Documentos"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = True
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'xBodega
        '
        Me.xBodega.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xBodega.Location = New System.Drawing.Point(447, 45)
        Me.xBodega.Name = "xBodega"
        Me.xBodega.ReadOnly = True
        Me.xBodega.Size = New System.Drawing.Size(147, 20)
        Me.xBodega.TabIndex = 131
        Me.xBodega.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(397, 50)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(44, 13)
        Me.Label29.TabIndex = 130
        Me.Label29.Text = "Bodega"
        '
        'Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 676)
        Me.ControlBox = False
        Me.Controls.Add(Me.bDirectorio)
        Me.Controls.Add(Me.Salir)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.nLineas)
        Me.Controls.Add(Me.Limpiar)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.fImpuestos)
        Me.Controls.Add(Me.fTotales)
        Me.Controls.Add(Me.fObservaciones)
        Me.Controls.Add(Me.fDetalles)
        Me.Controls.Add(Me.fGeneral)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1364, 724)
        Me.Name = "Documentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos"
        Me.fGeneral.ResumeLayout(False)
        Me.fGeneral.PerformLayout()
        Me.fDetalles.ResumeLayout(False)
        Me.fDetalles.PerformLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fObservaciones.ResumeLayout(False)
        Me.fObservaciones.PerformLayout()
        Me.fTotales.ResumeLayout(False)
        Me.fTotales.PerformLayout()
        Me.fImpuestos.ResumeLayout(False)
        Me.fImpuestos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Friend WithEvents fGeneral As GroupBox
    Public WithEvents bBuscarCli As Button
    Friend WithEvents xNomVen As TextBox
    Friend WithEvents xVendedor As TextBox
    Friend WithEvents oElectronica As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents xNumDocRef As TextBox
    Friend WithEvents xRut As MaskedTextBox
    Friend WithEvents cTipoDoc As ComboBox
    Friend WithEvents cFPago As ComboBox
    Friend WithEvents xDireccion As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lNombre As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents xComuna As TextBox
    Friend WithEvents xCiudad As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents xFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents bProcesarDoc As Button
    Public WithEvents bCrearCli As Button
    Friend WithEvents cTipoDocRef As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents fDetalles As GroupBox
    Friend WithEvents xLocal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents xDescripcion As TextBox
    Public WithEvents Agregar As Button
    Public WithEvents bEliminar As Button
    Friend WithEvents xNumero As TextBox
    Friend WithEvents xCliente As TextBox
    Friend WithEvents xArticulo As TextBox
    Public WithEvents BuscarArt As Button
    Public WithEvents bLimpiarArt As Button
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lMotivo As Label
    Friend WithEvents cMotivo As ComboBox
    Friend WithEvents fObservaciones As GroupBox
    Friend WithEvents xObs As TextBox
    Friend WithEvents fTotales As GroupBox
    Friend WithEvents fImpuestos As GroupBox
    Friend WithEvents Label15 As Label
    Public WithEvents Aceptar As Button
    Public WithEvents Limpiar As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents xTotal As TextBox
    Friend WithEvents xImpuestos As TextBox
    Friend WithEvents xIVA As TextBox
    Friend WithEvents xNeto As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents xDescuento As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Tabacos As Label
    Friend WithEvents xTAB As TextBox
    Friend WithEvents xHAR As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents xCAR As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents xLIC As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents xVIN As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents xCER As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents xBEB As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents xMIN As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents xFEP As TextBox
    Friend WithEvents nLineas As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents xTipoDoc As TextBox
    Friend WithEvents xNombre As TextBox
    Friend WithEvents xFechaDocRef As DateTimePicker
    Friend WithEvents xSubTotal As TextBox
    Friend WithEvents xTipoDocRef As TextBox
    Public WithEvents Salir As Button
    Public WithEvents bDirectorio As Button
    Friend WithEvents xBodega As TextBox
    Friend WithEvents Label29 As Label
End Class
