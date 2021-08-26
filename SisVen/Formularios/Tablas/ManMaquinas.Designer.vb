<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManMaquinas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManMaquinas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.xRut = New System.Windows.Forms.TextBox()
        Me.bBuscarCli = New System.Windows.Forms.Button()
        Me.dFechaR = New System.Windows.Forms.DateTimePicker()
        Me.dFechaA = New System.Windows.Forms.DateTimePicker()
        Me.cEstado = New System.Windows.Forms.ComboBox()
        Me.cUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.xTerritorio = New System.Windows.Forms.TextBox()
        Me.lFecha = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.xGuia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.xGarantia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.xNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.xModelo = New System.Windows.Forms.TextBox()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.bNuevo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.xMarca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.xID = New System.Windows.Forms.TextBox()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bEliminar = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.fDialogo = New System.Windows.Forms.SaveFileDialog()
        Me.xSucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.xSucursal)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.xRut)
        Me.GroupBox1.Controls.Add(Me.bBuscarCli)
        Me.GroupBox1.Controls.Add(Me.dFechaR)
        Me.GroupBox1.Controls.Add(Me.dFechaA)
        Me.GroupBox1.Controls.Add(Me.cEstado)
        Me.GroupBox1.Controls.Add(Me.cUbicacion)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.xTerritorio)
        Me.GroupBox1.Controls.Add(Me.lFecha)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.xGuia)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.xGarantia)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.xNombre)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.xCliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.xModelo)
        Me.GroupBox1.Controls.Add(Me.bBuscar)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.xMarca)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.xID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 374)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(339, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 16)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "RUT"
        '
        'xRut
        '
        Me.xRut.BackColor = System.Drawing.SystemColors.ControlLight
        Me.xRut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xRut.Location = New System.Drawing.Point(381, 119)
        Me.xRut.Name = "xRut"
        Me.xRut.ReadOnly = True
        Me.xRut.Size = New System.Drawing.Size(122, 20)
        Me.xRut.TabIndex = 105
        '
        'bBuscarCli
        '
        Me.bBuscarCli.BackColor = System.Drawing.Color.White
        Me.bBuscarCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarCli.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCli.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscarCli.Location = New System.Drawing.Point(227, 119)
        Me.bBuscarCli.Name = "bBuscarCli"
        Me.bBuscarCli.Size = New System.Drawing.Size(28, 23)
        Me.bBuscarCli.TabIndex = 19
        Me.bBuscarCli.TabStop = False
        Me.bBuscarCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarCli.UseVisualStyleBackColor = False
        '
        'dFechaR
        '
        Me.dFechaR.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFechaR.Location = New System.Drawing.Point(149, 328)
        Me.dFechaR.Name = "dFechaR"
        Me.dFechaR.Size = New System.Drawing.Size(169, 20)
        Me.dFechaR.TabIndex = 12
        '
        'dFechaA
        '
        Me.dFechaA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFechaA.Location = New System.Drawing.Point(149, 249)
        Me.dFechaA.Name = "dFechaA"
        Me.dFechaA.Size = New System.Drawing.Size(169, 20)
        Me.dFechaA.TabIndex = 9
        '
        'cEstado
        '
        Me.cEstado.BackColor = System.Drawing.Color.White
        Me.cEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEstado.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cEstado.FormattingEnabled = True
        Me.cEstado.Location = New System.Drawing.Point(149, 298)
        Me.cEstado.Name = "cEstado"
        Me.cEstado.Size = New System.Drawing.Size(169, 24)
        Me.cEstado.TabIndex = 11
        Me.cEstado.TabStop = False
        '
        'cUbicacion
        '
        Me.cUbicacion.BackColor = System.Drawing.Color.White
        Me.cUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cUbicacion.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cUbicacion.FormattingEnabled = True
        Me.cUbicacion.Location = New System.Drawing.Point(149, 91)
        Me.cUbicacion.Name = "cUbicacion"
        Me.cUbicacion.Size = New System.Drawing.Size(169, 24)
        Me.cUbicacion.TabIndex = 3
        Me.cUbicacion.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 16)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "Fecha Recuperación"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 301)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 16)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Estado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Territorio"
        '
        'xTerritorio
        '
        Me.xTerritorio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xTerritorio.Location = New System.Drawing.Point(149, 275)
        Me.xTerritorio.Name = "xTerritorio"
        Me.xTerritorio.Size = New System.Drawing.Size(354, 20)
        Me.xTerritorio.TabIndex = 10
        '
        'lFecha
        '
        Me.lFecha.AutoSize = True
        Me.lFecha.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lFecha.Location = New System.Drawing.Point(6, 249)
        Me.lFecha.Name = "lFecha"
        Me.lFecha.Size = New System.Drawing.Size(120, 16)
        Me.lFecha.TabIndex = 98
        Me.lFecha.Text = "Fecha Asignación"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 224)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 16)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Guía de Despacho"
        '
        'xGuia
        '
        Me.xGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xGuia.Location = New System.Drawing.Point(149, 223)
        Me.xGuia.Name = "xGuia"
        Me.xGuia.Size = New System.Drawing.Size(169, 20)
        Me.xGuia.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 16)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Doc. Garantía"
        '
        'xGarantia
        '
        Me.xGarantia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xGarantia.Location = New System.Drawing.Point(149, 197)
        Me.xGarantia.Name = "xGarantia"
        Me.xGarantia.Size = New System.Drawing.Size(169, 20)
        Me.xGarantia.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Sucursal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 16)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Nombre"
        '
        'xNombre
        '
        Me.xNombre.BackColor = System.Drawing.SystemColors.ControlLight
        Me.xNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xNombre.Location = New System.Drawing.Point(149, 145)
        Me.xNombre.Name = "xNombre"
        Me.xNombre.ReadOnly = True
        Me.xNombre.Size = New System.Drawing.Size(354, 20)
        Me.xNombre.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Cliente"
        '
        'xCliente
        '
        Me.xCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xCliente.Location = New System.Drawing.Point(149, 119)
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(72, 20)
        Me.xCliente.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Ubicación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Modelo"
        '
        'xModelo
        '
        Me.xModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xModelo.Location = New System.Drawing.Point(149, 67)
        Me.xModelo.Name = "xModelo"
        Me.xModelo.Size = New System.Drawing.Size(354, 20)
        Me.xModelo.TabIndex = 2
        '
        'bBuscar
        '
        Me.bBuscar.BackColor = System.Drawing.Color.White
        Me.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscar.Location = New System.Drawing.Point(415, 10)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(88, 28)
        Me.bBuscar.TabIndex = 18
        Me.bBuscar.Text = "Buscar"
        Me.bBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscar.UseVisualStyleBackColor = False
        '
        'bNuevo
        '
        Me.bNuevo.BackColor = System.Drawing.Color.White
        Me.bNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bNuevo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.Image = Global.SisVen.My.Resources.Resources.new16
        Me.bNuevo.Location = New System.Drawing.Point(324, 10)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 28)
        Me.bNuevo.TabIndex = 17
        Me.bNuevo.Text = "Nuevo"
        Me.bNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bNuevo.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Marca"
        '
        'xMarca
        '
        Me.xMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xMarca.Location = New System.Drawing.Point(149, 41)
        Me.xMarca.Name = "xMarca"
        Me.xMarca.Size = New System.Drawing.Size(354, 20)
        Me.xMarca.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID Máquina"
        '
        'xID
        '
        Me.xID.Location = New System.Drawing.Point(149, 15)
        Me.xID.MaxLength = 10
        Me.xID.Name = "xID"
        Me.xID.Size = New System.Drawing.Size(169, 20)
        Me.xID.TabIndex = 0
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.BackColor = System.Drawing.Color.White
        Me.bGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bGuardar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.Image = Global.SisVen.My.Resources.Resources.save24
        Me.bGuardar.Location = New System.Drawing.Point(223, 454)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(103, 36)
        Me.bGuardar.TabIndex = 13
        Me.bGuardar.Text = "Guardar"
        Me.bGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bGuardar.UseVisualStyleBackColor = False
        '
        'bEliminar
        '
        Me.bEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEliminar.BackColor = System.Drawing.Color.White
        Me.bEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bEliminar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEliminar.Image = Global.SisVen.My.Resources.Resources.delete24
        Me.bEliminar.Location = New System.Drawing.Point(332, 454)
        Me.bEliminar.Name = "bEliminar"
        Me.bEliminar.Size = New System.Drawing.Size(98, 36)
        Me.bEliminar.TabIndex = 14
        Me.bEliminar.Text = "Eliminar"
        Me.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bEliminar.UseVisualStyleBackColor = False
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.Location = New System.Drawing.Point(12, 454)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 36)
        Me.bLimpiar.TabIndex = 16
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.BackColor = System.Drawing.Color.White
        Me.bSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bSalir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bSalir.Location = New System.Drawing.Point(436, 454)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(99, 36)
        Me.bSalir.TabIndex = 15
        Me.bSalir.Text = "Cancelar"
        Me.bSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bSalir.UseVisualStyleBackColor = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(541, 50)
        Me.WinDeco1.TabIndex = 4
        Me.WinDeco1.TituloVentana = "Mantención de Máquinas"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'fDialogo
        '
        Me.fDialogo.FileName = "Detalle"
        Me.fDialogo.Filter = "Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm"
        Me.fDialogo.Title = "Exportar detalle"
        '
        'xSucursal
        '
        Me.xSucursal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.xSucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.xSucursal.Location = New System.Drawing.Point(149, 172)
        Me.xSucursal.Name = "xSucursal"
        Me.xSucursal.ReadOnly = True
        Me.xSucursal.Size = New System.Drawing.Size(354, 20)
        Me.xSucursal.TabIndex = 107
        '
        'ManMaquinas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bSalir
        Me.ClientSize = New System.Drawing.Size(541, 503)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bEliminar)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1360, 740)
        Me.Name = "ManMaquinas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisVen - Mantenedor de Familias"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Friend WithEvents GroupBox1 As GroupBox
    Public WithEvents bGuardar As Button
    Public WithEvents bEliminar As Button
    Public WithEvents bLimpiar As Button
    Public WithEvents bSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents xID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents xMarca As TextBox
    Public WithEvents bNuevo As Button
    Public WithEvents bBuscar As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents xTerritorio As TextBox
    Friend WithEvents lFecha As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents xGuia As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents xGarantia As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents xNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents xCliente As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents xModelo As TextBox
    Friend WithEvents cEstado As ComboBox
    Friend WithEvents cUbicacion As ComboBox
    Friend WithEvents dFechaR As DateTimePicker
    Friend WithEvents dFechaA As DateTimePicker
    Public WithEvents bBuscarCli As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents xRut As TextBox
    Friend WithEvents fDialogo As SaveFileDialog
    Friend WithEvents xSucursal As TextBox
End Class
