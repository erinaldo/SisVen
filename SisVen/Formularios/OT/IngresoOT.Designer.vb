<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IngresoOT))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bCrear = New System.Windows.Forms.Button()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.xNombreTecnico = New System.Windows.Forms.TextBox()
        Me.bNuevo = New System.Windows.Forms.Button()
        Me.xNombre = New System.Windows.Forms.TextBox()
        Me.xTecnico = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.xOT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bConsultarP = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.xTotalOT = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dFecha = New System.Windows.Forms.DateTimePicker()
        Me.xEstado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.xCodigoR = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xProductoR = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.gServicio = New System.Windows.Forms.GroupBox()
        Me.SugServicios = New System.Windows.Forms.ListBox()
        Me.bAgregar = New System.Windows.Forms.Button()
        Me.bBuscarS = New System.Windows.Forms.Button()
        Me.xNombreServicio = New System.Windows.Forms.TextBox()
        Me.xServicio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SugArticulos = New System.Windows.Forms.ListBox()
        Me.bAgregarA = New System.Windows.Forms.Button()
        Me.bBuscarA = New System.Windows.Forms.Button()
        Me.xDescripcion = New System.Windows.Forms.TextBox()
        Me.xArticulo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.xTablaArticulos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.gObservacionCliente = New System.Windows.Forms.GroupBox()
        Me.xObsCliente = New System.Windows.Forms.TextBox()
        Me.gObservacionTecnico = New System.Windows.Forms.GroupBox()
        Me.xObsTecnico = New System.Windows.Forms.TextBox()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bBuscarOT = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.GroupBox1.SuspendLayout()
        Me.gServicio.SuspendLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.xTablaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gObservacionCliente.SuspendLayout()
        Me.gObservacionTecnico.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.bCrear)
        Me.GroupBox1.Controls.Add(Me.bBuscar)
        Me.GroupBox1.Controls.Add(Me.xNombreTecnico)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.xNombre)
        Me.GroupBox1.Controls.Add(Me.xTecnico)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.xCliente)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.xOT)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'bCrear
        '
        Me.bCrear.BackColor = System.Drawing.Color.White
        Me.bCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCrear.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCrear.Image = Global.SisVen.My.Resources.Resources.agregar16
        Me.bCrear.Location = New System.Drawing.Point(492, 36)
        Me.bCrear.Name = "bCrear"
        Me.bCrear.Size = New System.Drawing.Size(28, 28)
        Me.bCrear.TabIndex = 89
        Me.bCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCrear.UseVisualStyleBackColor = False
        '
        'bBuscar
        '
        Me.bBuscar.BackColor = System.Drawing.Color.White
        Me.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscar.Location = New System.Drawing.Point(461, 36)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(28, 28)
        Me.bBuscar.TabIndex = 88
        Me.bBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscar.UseVisualStyleBackColor = False
        '
        'xNombreTecnico
        '
        Me.xNombreTecnico.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNombreTecnico.Location = New System.Drawing.Point(161, 63)
        Me.xNombreTecnico.Name = "xNombreTecnico"
        Me.xNombreTecnico.Size = New System.Drawing.Size(297, 23)
        Me.xNombreTecnico.TabIndex = 85
        '
        'bNuevo
        '
        Me.bNuevo.BackColor = System.Drawing.Color.White
        Me.bNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bNuevo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.Image = Global.SisVen.My.Resources.Resources.new16
        Me.bNuevo.Location = New System.Drawing.Point(161, 8)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(80, 28)
        Me.bNuevo.TabIndex = 80
        Me.bNuevo.Text = "Nuevo"
        Me.bNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bNuevo.UseVisualStyleBackColor = False
        '
        'xNombre
        '
        Me.xNombre.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNombre.Location = New System.Drawing.Point(161, 38)
        Me.xNombre.Name = "xNombre"
        Me.xNombre.Size = New System.Drawing.Size(297, 23)
        Me.xNombre.TabIndex = 12
        '
        'xTecnico
        '
        Me.xTecnico.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTecnico.Location = New System.Drawing.Point(65, 63)
        Me.xTecnico.Name = "xTecnico"
        Me.xTecnico.Size = New System.Drawing.Size(93, 23)
        Me.xTecnico.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Técnico"
        '
        'xCliente
        '
        Me.xCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xCliente.Location = New System.Drawing.Point(65, 38)
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(93, 23)
        Me.xCliente.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cliente"
        '
        'xOT
        '
        Me.xOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.xOT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xOT.Location = New System.Drawing.Point(65, 13)
        Me.xOT.Name = "xOT"
        Me.xOT.Size = New System.Drawing.Size(93, 23)
        Me.xOT.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OT"
        '
        'bConsultarP
        '
        Me.bConsultarP.BackColor = System.Drawing.Color.White
        Me.bConsultarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bConsultarP.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConsultarP.Image = Global.SisVen.My.Resources.Resources.find
        Me.bConsultarP.Location = New System.Drawing.Point(330, 38)
        Me.bConsultarP.Name = "bConsultarP"
        Me.bConsultarP.Size = New System.Drawing.Size(96, 28)
        Me.bConsultarP.TabIndex = 91
        Me.bConsultarP.Text = "Consultar"
        Me.bConsultarP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bConsultarP.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(284, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 16)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "(SKU)"
        '
        'xTotalOT
        '
        Me.xTotalOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xTotalOT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTotalOT.Location = New System.Drawing.Point(80, 65)
        Me.xTotalOT.Name = "xTotalOT"
        Me.xTotalOT.Size = New System.Drawing.Size(121, 23)
        Me.xTotalOT.TabIndex = 87
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Total OT"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Fecha OT"
        '
        'dFecha
        '
        Me.dFecha.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFecha.Location = New System.Drawing.Point(80, 39)
        Me.dFecha.Name = "dFecha"
        Me.dFecha.Size = New System.Drawing.Size(100, 23)
        Me.dFecha.TabIndex = 83
        '
        'xEstado
        '
        Me.xEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.xEstado.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xEstado.Location = New System.Drawing.Point(80, 13)
        Me.xEstado.Name = "xEstado"
        Me.xEstado.Size = New System.Drawing.Size(121, 23)
        Me.xEstado.TabIndex = 82
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Estado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha Entrega"
        '
        'xCodigoR
        '
        Me.xCodigoR.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xCodigoR.Location = New System.Drawing.Point(131, 38)
        Me.xCodigoR.Name = "xCodigoR"
        Me.xCodigoR.Size = New System.Drawing.Size(152, 23)
        Me.xCodigoR.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Codigo Producto"
        '
        'xProductoR
        '
        Me.xProductoR.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xProductoR.Location = New System.Drawing.Point(131, 13)
        Me.xProductoR.Name = "xProductoR"
        Me.xProductoR.Size = New System.Drawing.Size(295, 23)
        Me.xProductoR.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Producto Recibido"
        '
        'dFechaEntrega
        '
        Me.dFechaEntrega.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFechaEntrega.Location = New System.Drawing.Point(131, 63)
        Me.dFechaEntrega.Name = "dFechaEntrega"
        Me.dFechaEntrega.Size = New System.Drawing.Size(142, 23)
        Me.dFechaEntrega.TabIndex = 4
        Me.dFechaEntrega.Value = New Date(2017, 12, 22, 11, 20, 5, 0)
        '
        'gServicio
        '
        Me.gServicio.BackColor = System.Drawing.Color.Transparent
        Me.gServicio.Controls.Add(Me.SugServicios)
        Me.gServicio.Controls.Add(Me.bAgregar)
        Me.gServicio.Controls.Add(Me.bBuscarS)
        Me.gServicio.Controls.Add(Me.xNombreServicio)
        Me.gServicio.Controls.Add(Me.xServicio)
        Me.gServicio.Controls.Add(Me.Label11)
        Me.gServicio.Controls.Add(Me.xTabla)
        Me.gServicio.Location = New System.Drawing.Point(6, 146)
        Me.gServicio.Name = "gServicio"
        Me.gServicio.Size = New System.Drawing.Size(1175, 150)
        Me.gServicio.TabIndex = 2
        Me.gServicio.TabStop = False
        '
        'SugServicios
        '
        Me.SugServicios.FormattingEnabled = True
        Me.SugServicios.Location = New System.Drawing.Point(77, 42)
        Me.SugServicios.Name = "SugServicios"
        Me.SugServicios.Size = New System.Drawing.Size(371, 82)
        Me.SugServicios.TabIndex = 91
        Me.SugServicios.Visible = False
        '
        'bAgregar
        '
        Me.bAgregar.BackColor = System.Drawing.Color.White
        Me.bAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bAgregar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAgregar.Image = Global.SisVen.My.Resources.Resources.load
        Me.bAgregar.Location = New System.Drawing.Point(698, 10)
        Me.bAgregar.Name = "bAgregar"
        Me.bAgregar.Size = New System.Drawing.Size(80, 28)
        Me.bAgregar.TabIndex = 74
        Me.bAgregar.Text = "Cargar"
        Me.bAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bAgregar.UseVisualStyleBackColor = False
        '
        'bBuscarS
        '
        Me.bBuscarS.BackColor = System.Drawing.Color.White
        Me.bBuscarS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarS.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarS.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscarS.Location = New System.Drawing.Point(612, 10)
        Me.bBuscarS.Name = "bBuscarS"
        Me.bBuscarS.Size = New System.Drawing.Size(80, 28)
        Me.bBuscarS.TabIndex = 42
        Me.bBuscarS.Text = "Buscar"
        Me.bBuscarS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarS.UseVisualStyleBackColor = False
        '
        'xNombreServicio
        '
        Me.xNombreServicio.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xNombreServicio.Location = New System.Drawing.Point(205, 13)
        Me.xNombreServicio.Name = "xNombreServicio"
        Me.xNombreServicio.Size = New System.Drawing.Size(401, 23)
        Me.xNombreServicio.TabIndex = 1
        '
        'xServicio
        '
        Me.xServicio.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xServicio.Location = New System.Drawing.Point(77, 13)
        Me.xServicio.Name = "xServicio"
        Me.xServicio.Size = New System.Drawing.Size(122, 23)
        Me.xServicio.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Servicios"
        '
        'xTabla
        '
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = resources.GetString("xTabla.ColumnInfo")
        Me.xTabla.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.xTabla.Location = New System.Drawing.Point(9, 41)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 19
        Me.xTabla.Size = New System.Drawing.Size(1160, 103)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 105
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.SugArticulos)
        Me.GroupBox3.Controls.Add(Me.bAgregarA)
        Me.GroupBox3.Controls.Add(Me.bBuscarA)
        Me.GroupBox3.Controls.Add(Me.xDescripcion)
        Me.GroupBox3.Controls.Add(Me.xArticulo)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.xTablaArticulos)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 302)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1175, 169)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'SugArticulos
        '
        Me.SugArticulos.FormattingEnabled = True
        Me.SugArticulos.Location = New System.Drawing.Point(77, 42)
        Me.SugArticulos.Name = "SugArticulos"
        Me.SugArticulos.Size = New System.Drawing.Size(371, 82)
        Me.SugArticulos.TabIndex = 92
        Me.SugArticulos.Visible = False
        '
        'bAgregarA
        '
        Me.bAgregarA.BackColor = System.Drawing.Color.White
        Me.bAgregarA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bAgregarA.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAgregarA.Image = Global.SisVen.My.Resources.Resources.load
        Me.bAgregarA.Location = New System.Drawing.Point(698, 10)
        Me.bAgregarA.Name = "bAgregarA"
        Me.bAgregarA.Size = New System.Drawing.Size(80, 28)
        Me.bAgregarA.TabIndex = 106
        Me.bAgregarA.Text = "Cargar"
        Me.bAgregarA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bAgregarA.UseVisualStyleBackColor = False
        '
        'bBuscarA
        '
        Me.bBuscarA.BackColor = System.Drawing.Color.White
        Me.bBuscarA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarA.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarA.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscarA.Location = New System.Drawing.Point(612, 10)
        Me.bBuscarA.Name = "bBuscarA"
        Me.bBuscarA.Size = New System.Drawing.Size(80, 28)
        Me.bBuscarA.TabIndex = 42
        Me.bBuscarA.Text = "Buscar"
        Me.bBuscarA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarA.UseVisualStyleBackColor = False
        '
        'xDescripcion
        '
        Me.xDescripcion.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xDescripcion.Location = New System.Drawing.Point(205, 13)
        Me.xDescripcion.Name = "xDescripcion"
        Me.xDescripcion.Size = New System.Drawing.Size(401, 23)
        Me.xDescripcion.TabIndex = 1
        '
        'xArticulo
        '
        Me.xArticulo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xArticulo.Location = New System.Drawing.Point(77, 13)
        Me.xArticulo.Name = "xArticulo"
        Me.xArticulo.Size = New System.Drawing.Size(122, 23)
        Me.xArticulo.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 16)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Artículos"
        '
        'xTablaArticulos
        '
        Me.xTablaArticulos.AllowEditing = False
        Me.xTablaArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTablaArticulos.ColumnInfo = resources.GetString("xTablaArticulos.ColumnInfo")
        Me.xTablaArticulos.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.xTablaArticulos.Location = New System.Drawing.Point(9, 44)
        Me.xTablaArticulos.Name = "xTablaArticulos"
        Me.xTablaArticulos.Rows.Count = 1
        Me.xTablaArticulos.Rows.DefaultSize = 19
        Me.xTablaArticulos.Size = New System.Drawing.Size(1160, 119)
        Me.xTablaArticulos.StyleInfo = resources.GetString("xTablaArticulos.StyleInfo")
        Me.xTablaArticulos.TabIndex = 105
        Me.xTablaArticulos.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'gObservacionCliente
        '
        Me.gObservacionCliente.BackColor = System.Drawing.Color.Transparent
        Me.gObservacionCliente.Controls.Add(Me.xObsCliente)
        Me.gObservacionCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gObservacionCliente.Location = New System.Drawing.Point(6, 536)
        Me.gObservacionCliente.Name = "gObservacionCliente"
        Me.gObservacionCliente.Size = New System.Drawing.Size(1175, 67)
        Me.gObservacionCliente.TabIndex = 4
        Me.gObservacionCliente.TabStop = False
        Me.gObservacionCliente.Text = "Observación del Cliente"
        '
        'xObsCliente
        '
        Me.xObsCliente.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xObsCliente.Location = New System.Drawing.Point(9, 19)
        Me.xObsCliente.Multiline = True
        Me.xObsCliente.Name = "xObsCliente"
        Me.xObsCliente.Size = New System.Drawing.Size(1159, 40)
        Me.xObsCliente.TabIndex = 0
        '
        'gObservacionTecnico
        '
        Me.gObservacionTecnico.BackColor = System.Drawing.Color.Transparent
        Me.gObservacionTecnico.Controls.Add(Me.xObsTecnico)
        Me.gObservacionTecnico.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gObservacionTecnico.Location = New System.Drawing.Point(6, 609)
        Me.gObservacionTecnico.Name = "gObservacionTecnico"
        Me.gObservacionTecnico.Size = New System.Drawing.Size(1175, 67)
        Me.gObservacionTecnico.TabIndex = 5
        Me.gObservacionTecnico.TabStop = False
        Me.gObservacionTecnico.Text = "Observación del Técnico"
        '
        'xObsTecnico
        '
        Me.xObsTecnico.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xObsTecnico.Location = New System.Drawing.Point(6, 19)
        Me.xObsTecnico.Multiline = True
        Me.xObsTecnico.Name = "xObsTecnico"
        Me.xObsTecnico.Size = New System.Drawing.Size(1162, 40)
        Me.xObsTecnico.TabIndex = 0
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.Location = New System.Drawing.Point(12, 681)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 36)
        Me.bLimpiar.TabIndex = 52
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'bBuscarOT
        '
        Me.bBuscarOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bBuscarOT.BackColor = System.Drawing.Color.White
        Me.bBuscarOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarOT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarOT.Image = Global.SisVen.My.Resources.Resources.find24
        Me.bBuscarOT.Location = New System.Drawing.Point(106, 681)
        Me.bBuscarOT.Name = "bBuscarOT"
        Me.bBuscarOT.Size = New System.Drawing.Size(142, 36)
        Me.bBuscarOT.TabIndex = 53
        Me.bBuscarOT.Text = "Consultar OT"
        Me.bBuscarOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bBuscarOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarOT.UseVisualStyleBackColor = False
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.BackColor = System.Drawing.Color.White
        Me.bImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bImprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.Image = Global.SisVen.My.Resources.Resources.print24
        Me.bImprimir.Location = New System.Drawing.Point(896, 681)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 36)
        Me.bImprimir.TabIndex = 60
        Me.bImprimir.Text = "Imprimir"
        Me.bImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bImprimir.UseVisualStyleBackColor = False
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.BackColor = System.Drawing.Color.White
        Me.bGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bGuardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.Image = Global.SisVen.My.Resources.Resources.save24
        Me.bGuardar.Location = New System.Drawing.Point(990, 681)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(95, 36)
        Me.bGuardar.TabIndex = 84
        Me.bGuardar.Text = "Guardar"
        Me.bGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bGuardar.UseVisualStyleBackColor = False
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(1091, 681)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(93, 36)
        Me.bCancelar.TabIndex = 83
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.xTotalOT)
        Me.GroupBox2.Controls.Add(Me.dFecha)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.xEstado)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(973, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(211, 93)
        Me.GroupBox2.TabIndex = 85
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.bConsultarP)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.xCodigoR)
        Me.GroupBox4.Controls.Add(Me.dFechaEntrega)
        Me.GroupBox4.Controls.Add(Me.xProductoR)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(538, 51)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(432, 93)
        Me.GroupBox4.TabIndex = 90
        Me.GroupBox4.TabStop = False
        '
        'WinDeco1
        '
        Me.WinDeco1.AlturaFooter = 45
        Me.WinDeco1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.WinDeco1.BordeVentana = 2
        Me.WinDeco1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WinDeco1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.WinDeco1.Location = New System.Drawing.Point(0, 0)
        Me.WinDeco1.MuestraBordeExterior = -1
        Me.WinDeco1.Name = "WinDeco1"
        Me.WinDeco1.Size = New System.Drawing.Size(1193, 50)
        Me.WinDeco1.TabIndex = 0
        Me.WinDeco1.TituloVentana = "Ingreso de OT"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'IngresoOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 697)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bBuscarOT)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.gObservacionTecnico)
        Me.Controls.Add(Me.gObservacionCliente)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.WinDeco1)
        Me.Controls.Add(Me.gServicio)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1302, 900)
        Me.Name = "IngresoOT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisVen - Ingreso de OT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gServicio.ResumeLayout(False)
        Me.gServicio.PerformLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.xTablaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gObservacionCliente.ResumeLayout(False)
        Me.gObservacionCliente.PerformLayout()
        Me.gObservacionTecnico.ResumeLayout(False)
        Me.gObservacionTecnico.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents xNombre As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents xTecnico As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents xCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dFechaEntrega As DateTimePicker
    Friend WithEvents xOT As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents xTotalOT As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents xNombreTecnico As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dFecha As DateTimePicker
    Friend WithEvents xEstado As TextBox
    Friend WithEvents Label7 As Label
    Public WithEvents bNuevo As Button
    Public WithEvents bCrear As Button
    Public WithEvents bBuscar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents gServicio As GroupBox
    Friend WithEvents xNombreServicio As TextBox
    Friend WithEvents xServicio As TextBox
    Friend WithEvents Label11 As Label
    Public WithEvents bBuscarS As Button
    Public WithEvents bAgregar As Button
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents xTablaArticulos As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents bBuscarA As Button
    Friend WithEvents xDescripcion As TextBox
    Friend WithEvents xArticulo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents gObservacionCliente As GroupBox
    Friend WithEvents xObsCliente As TextBox
    Friend WithEvents gObservacionTecnico As GroupBox
    Friend WithEvents xObsTecnico As TextBox
    Public WithEvents bLimpiar As Button
    Public WithEvents bBuscarOT As Button
    Public WithEvents bImprimir As Button
    Public WithEvents bGuardar As Button
    Public WithEvents bCancelar As Button
    Friend WithEvents SugServicios As ListBox
    Friend WithEvents SugArticulos As ListBox
    Public WithEvents bAgregarA As Button
    Public WithEvents bConsultarP As Button
    Public WithEvents xCodigoR As TextBox
    Public WithEvents xProductoR As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
End Class
