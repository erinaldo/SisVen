<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consulta_Stock))
        Me.gPedidos = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xBloqueado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xReservado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.xDisponible = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.xTotal = New System.Windows.Forms.TextBox()
        Me.gPedido = New System.Windows.Forms.GroupBox()
        Me.xArticulo = New System.Windows.Forms.TextBox()
        Me.bCalcular = New System.Windows.Forms.Button()
        Me.cBodega = New System.Windows.Forms.ComboBox()
        Me.xBodega = New System.Windows.Forms.TextBox()
        Me.bBuscarCliente = New System.Windows.Forms.Button()
        Me.bBuscarArticulo = New System.Windows.Forms.Button()
        Me.xDescripcion = New System.Windows.Forms.TextBox()
        Me.xSKU = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.xNombreCliente = New System.Windows.Forms.TextBox()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.VerInforme = New System.Windows.Forms.Button()
        Me.gStockBodega = New System.Windows.Forms.GroupBox()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bListadoArt = New System.Windows.Forms.Button()
        Me.bListadoPaq = New System.Windows.Forms.Button()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.gPedidos.SuspendLayout()
        Me.gPedido.SuspendLayout()
        Me.gStockBodega.SuspendLayout()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gPedidos
        '
        Me.gPedidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gPedidos.BackColor = System.Drawing.Color.Transparent
        Me.gPedidos.Controls.Add(Me.Label5)
        Me.gPedidos.Controls.Add(Me.xBloqueado)
        Me.gPedidos.Controls.Add(Me.Label4)
        Me.gPedidos.Controls.Add(Me.xReservado)
        Me.gPedidos.Controls.Add(Me.Label2)
        Me.gPedidos.Controls.Add(Me.xDisponible)
        Me.gPedidos.Controls.Add(Me.Label3)
        Me.gPedidos.Controls.Add(Me.xTotal)
        Me.gPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gPedidos.Location = New System.Drawing.Point(12, 451)
        Me.gPedidos.Name = "gPedidos"
        Me.gPedidos.Size = New System.Drawing.Size(397, 135)
        Me.gPedidos.TabIndex = 0
        Me.gPedidos.TabStop = False
        Me.gPedidos.Text = "Stock Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(82, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Bloqueado"
        '
        'xBloqueado
        '
        Me.xBloqueado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.xBloqueado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xBloqueado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.xBloqueado.Location = New System.Drawing.Point(175, 101)
        Me.xBloqueado.MaxLength = 18
        Me.xBloqueado.Name = "xBloqueado"
        Me.xBloqueado.ReadOnly = True
        Me.xBloqueado.Size = New System.Drawing.Size(143, 24)
        Me.xBloqueado.TabIndex = 119
        Me.xBloqueado.TabStop = False
        Me.xBloqueado.Text = "0"
        Me.xBloqueado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(81, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Reservado"
        '
        'xReservado
        '
        Me.xReservado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.xReservado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xReservado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.xReservado.Location = New System.Drawing.Point(175, 73)
        Me.xReservado.MaxLength = 18
        Me.xReservado.Name = "xReservado"
        Me.xReservado.ReadOnly = True
        Me.xReservado.Size = New System.Drawing.Size(143, 24)
        Me.xReservado.TabIndex = 117
        Me.xReservado.TabStop = False
        Me.xReservado.Text = "0"
        Me.xReservado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Disponible"
        '
        'xDisponible
        '
        Me.xDisponible.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.xDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xDisponible.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.xDisponible.Location = New System.Drawing.Point(175, 45)
        Me.xDisponible.MaxLength = 18
        Me.xDisponible.Name = "xDisponible"
        Me.xDisponible.ReadOnly = True
        Me.xDisponible.Size = New System.Drawing.Size(143, 24)
        Me.xDisponible.TabIndex = 115
        Me.xDisponible.TabStop = False
        Me.xDisponible.Text = "0"
        Me.xDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(81, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 20)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Total"
        '
        'xTotal
        '
        Me.xTotal.BackColor = System.Drawing.SystemColors.Window
        Me.xTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.xTotal.Location = New System.Drawing.Point(175, 16)
        Me.xTotal.MaxLength = 18
        Me.xTotal.Name = "xTotal"
        Me.xTotal.ReadOnly = True
        Me.xTotal.Size = New System.Drawing.Size(143, 26)
        Me.xTotal.TabIndex = 115
        Me.xTotal.TabStop = False
        Me.xTotal.Text = "0"
        Me.xTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gPedido
        '
        Me.gPedido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gPedido.BackColor = System.Drawing.Color.Transparent
        Me.gPedido.Controls.Add(Me.xArticulo)
        Me.gPedido.Controls.Add(Me.bCalcular)
        Me.gPedido.Controls.Add(Me.cBodega)
        Me.gPedido.Controls.Add(Me.xBodega)
        Me.gPedido.Controls.Add(Me.bBuscarCliente)
        Me.gPedido.Controls.Add(Me.bBuscarArticulo)
        Me.gPedido.Controls.Add(Me.xDescripcion)
        Me.gPedido.Controls.Add(Me.xSKU)
        Me.gPedido.Controls.Add(Me.Label16)
        Me.gPedido.Controls.Add(Me.Label9)
        Me.gPedido.Controls.Add(Me.xNombreCliente)
        Me.gPedido.Controls.Add(Me.xCliente)
        Me.gPedido.Controls.Add(Me.Label1)
        Me.gPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gPedido.Location = New System.Drawing.Point(12, 56)
        Me.gPedido.Name = "gPedido"
        Me.gPedido.Size = New System.Drawing.Size(540, 159)
        Me.gPedido.TabIndex = 0
        Me.gPedido.TabStop = False
        Me.gPedido.Text = "Datos de Artículo"
        '
        'xArticulo
        '
        Me.xArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xArticulo.Location = New System.Drawing.Point(107, 103)
        Me.xArticulo.Name = "xArticulo"
        Me.xArticulo.ReadOnly = True
        Me.xArticulo.Size = New System.Drawing.Size(310, 21)
        Me.xArticulo.TabIndex = 4
        Me.xArticulo.TabStop = False
        '
        'bCalcular
        '
        Me.bCalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCalcular.BackColor = System.Drawing.Color.White
        Me.bCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCalcular.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCalcular.Image = Global.SisVen.My.Resources.Resources.refresh_update24
        Me.bCalcular.Location = New System.Drawing.Point(425, 106)
        Me.bCalcular.Name = "bCalcular"
        Me.bCalcular.Size = New System.Drawing.Size(106, 44)
        Me.bCalcular.TabIndex = 5
        Me.bCalcular.Text = "Actualizar"
        Me.bCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bCalcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCalcular.UseVisualStyleBackColor = False
        '
        'cBodega
        '
        Me.cBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBodega.FormattingEnabled = True
        Me.cBodega.Location = New System.Drawing.Point(169, 45)
        Me.cBodega.Name = "cBodega"
        Me.cBodega.Size = New System.Drawing.Size(248, 23)
        Me.cBodega.TabIndex = 2
        '
        'xBodega
        '
        Me.xBodega.BackColor = System.Drawing.Color.White
        Me.xBodega.Location = New System.Drawing.Point(107, 46)
        Me.xBodega.Name = "xBodega"
        Me.xBodega.Size = New System.Drawing.Size(56, 21)
        Me.xBodega.TabIndex = 2
        Me.xBodega.TabStop = False
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.BackColor = System.Drawing.Color.White
        Me.bBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = CType(resources.GetObject("bBuscarCliente.Image"), System.Drawing.Image)
        Me.bBuscarCliente.Location = New System.Drawing.Point(425, 17)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(75, 26)
        Me.bBuscarCliente.TabIndex = 1
        Me.bBuscarCliente.Text = "Buscar"
        Me.bBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarCliente.UseVisualStyleBackColor = False
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.BackColor = System.Drawing.Color.White
        Me.bBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticulo.Image = CType(resources.GetObject("bBuscarArticulo.Image"), System.Drawing.Image)
        Me.bBuscarArticulo.Location = New System.Drawing.Point(425, 71)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(75, 26)
        Me.bBuscarArticulo.TabIndex = 4
        Me.bBuscarArticulo.Text = "Buscar"
        Me.bBuscarArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarArticulo.UseVisualStyleBackColor = False
        '
        'xDescripcion
        '
        Me.xDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xDescripcion.Location = New System.Drawing.Point(107, 129)
        Me.xDescripcion.Name = "xDescripcion"
        Me.xDescripcion.ReadOnly = True
        Me.xDescripcion.Size = New System.Drawing.Size(310, 21)
        Me.xDescripcion.TabIndex = 5
        Me.xDescripcion.TabStop = False
        '
        'xSKU
        '
        Me.xSKU.BackColor = System.Drawing.Color.White
        Me.xSKU.Location = New System.Drawing.Point(107, 76)
        Me.xSKU.MaxLength = 50
        Me.xSKU.Name = "xSKU"
        Me.xSKU.Size = New System.Drawing.Size(310, 21)
        Me.xSKU.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 15)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Artículo (SKU)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Bodega"
        '
        'xNombreCliente
        '
        Me.xNombreCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.xNombreCliente.Location = New System.Drawing.Point(169, 19)
        Me.xNombreCliente.Name = "xNombreCliente"
        Me.xNombreCliente.ReadOnly = True
        Me.xNombreCliente.Size = New System.Drawing.Size(248, 21)
        Me.xNombreCliente.TabIndex = 1
        Me.xNombreCliente.TabStop = False
        '
        'xCliente
        '
        Me.xCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.xCliente.Location = New System.Drawing.Point(107, 19)
        Me.xCliente.MaxLength = 18
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(56, 21)
        Me.xCliente.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(464, 608)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(88, 36)
        Me.bCancelar.TabIndex = 106
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
        Me.bLimpiar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.Location = New System.Drawing.Point(8, 607)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 36)
        Me.bLimpiar.TabIndex = 105
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'VerInforme
        '
        Me.VerInforme.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VerInforme.BackColor = System.Drawing.Color.White
        Me.VerInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.VerInforme.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VerInforme.Image = Global.SisVen.My.Resources.Resources.report_open24
        Me.VerInforme.Location = New System.Drawing.Point(295, 719)
        Me.VerInforme.Name = "VerInforme"
        Me.VerInforme.Size = New System.Drawing.Size(163, 36)
        Me.VerInforme.TabIndex = 108
        Me.VerInforme.Text = "Ver Informe de Stock"
        Me.VerInforme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.VerInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.VerInforme.UseVisualStyleBackColor = False
        '
        'gStockBodega
        '
        Me.gStockBodega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gStockBodega.BackColor = System.Drawing.Color.Transparent
        Me.gStockBodega.Controls.Add(Me.xTabla)
        Me.gStockBodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gStockBodega.Location = New System.Drawing.Point(12, 216)
        Me.gStockBodega.Name = "gStockBodega"
        Me.gStockBodega.Size = New System.Drawing.Size(540, 231)
        Me.gStockBodega.TabIndex = 109
        Me.gStockBodega.TabStop = False
        Me.gStockBodega.Text = "Stock por Bodegas"
        '
        'xTabla
        '
        Me.xTabla.AllowDelete = True
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = resources.GetString("xTabla.ColumnInfo")
        Me.xTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.xTabla.Location = New System.Drawing.Point(9, 22)
        Me.xTabla.Margin = New System.Windows.Forms.Padding(0)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 19
        Me.xTabla.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.xTabla.Size = New System.Drawing.Size(522, 197)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 1
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'bListadoArt
        '
        Me.bListadoArt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListadoArt.BackColor = System.Drawing.Color.White
        Me.bListadoArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bListadoArt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListadoArt.Image = Global.SisVen.My.Resources.Resources.stock_art321
        Me.bListadoArt.Location = New System.Drawing.Point(415, 457)
        Me.bListadoArt.Name = "bListadoArt"
        Me.bListadoArt.Size = New System.Drawing.Size(136, 59)
        Me.bListadoArt.TabIndex = 110
        Me.bListadoArt.Text = "Listado de Stock por Artículos"
        Me.bListadoArt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bListadoArt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bListadoArt.UseVisualStyleBackColor = False
        '
        'bListadoPaq
        '
        Me.bListadoPaq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListadoPaq.BackColor = System.Drawing.Color.White
        Me.bListadoPaq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bListadoPaq.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListadoPaq.Image = Global.SisVen.My.Resources.Resources.stock_paq32
        Me.bListadoPaq.Location = New System.Drawing.Point(415, 526)
        Me.bListadoPaq.Name = "bListadoPaq"
        Me.bListadoPaq.Size = New System.Drawing.Size(136, 59)
        Me.bListadoPaq.TabIndex = 110
        Me.bListadoPaq.Text = "Listado de Stock por Paquetes"
        Me.bListadoPaq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bListadoPaq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bListadoPaq.UseVisualStyleBackColor = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(564, 50)
        Me.WinDeco1.TabIndex = 104
        Me.WinDeco1.TituloVentana = "Consulta de Stock por Artículo"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'Consulta_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 656)
        Me.Controls.Add(Me.bListadoPaq)
        Me.Controls.Add(Me.bListadoArt)
        Me.Controls.Add(Me.gStockBodega)
        Me.Controls.Add(Me.gPedido)
        Me.Controls.Add(Me.VerInforme)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.WinDeco1)
        Me.Controls.Add(Me.gPedidos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1283, 768)
        Me.MinimumSize = New System.Drawing.Size(564, 656)
        Me.Name = "Consulta_Stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Stock por Artículo"
        Me.gPedidos.ResumeLayout(False)
        Me.gPedidos.PerformLayout()
        Me.gPedido.ResumeLayout(False)
        Me.gPedido.PerformLayout()
        Me.gStockBodega.ResumeLayout(False)
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents WinDeco1 As SisVen.WinDeco
    Public WithEvents bCancelar As System.Windows.Forms.Button
    Public WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents xNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents xCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gPedido As System.Windows.Forms.GroupBox
    Public WithEvents VerInforme As System.Windows.Forms.Button
    Friend WithEvents bBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents xDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents xSKU As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cBodega As System.Windows.Forms.ComboBox
    Friend WithEvents xBodega As System.Windows.Forms.TextBox
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents xBloqueado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents xReservado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents xDisponible As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents xTotal As System.Windows.Forms.TextBox
    Public WithEvents bCalcular As System.Windows.Forms.Button
    Friend WithEvents xArticulo As System.Windows.Forms.TextBox
    Friend WithEvents gStockBodega As GroupBox
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents bListadoArt As Button
    Public WithEvents bListadoPaq As Button
End Class
