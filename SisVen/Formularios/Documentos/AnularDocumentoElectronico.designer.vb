<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnularDocumentoElectronico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnularDocumentoElectronico))
        Me.Salir = New System.Windows.Forms.Button()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.xLocal = New System.Windows.Forms.TextBox()
        Me.bBuscarCli = New System.Windows.Forms.Button()
        Me.xDoc1 = New System.Windows.Forms.TextBox()
        Me.xNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cLocal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.xFolio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.xDoc2 = New System.Windows.Forms.TextBox()
        Me.xAnula = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.xCliente = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.xMonto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.xFecha = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.xNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xRut = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Salir
        '
        Me.Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Salir.BackColor = System.Drawing.Color.White
        Me.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Salir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Salir.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.Location = New System.Drawing.Point(402, 441)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(106, 36)
        Me.Salir.TabIndex = 5
        Me.Salir.Text = "Cancelar"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Salir.UseVisualStyleBackColor = False
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.BackColor = System.Drawing.Color.White
        Me.bGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bGuardar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.Image = Global.SisVen.My.Resources.Resources.delete24
        Me.bGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bGuardar.Location = New System.Drawing.Point(222, 441)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(174, 36)
        Me.bGuardar.TabIndex = 6
        Me.bGuardar.Text = "Anular Documento"
        Me.bGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bGuardar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.xLocal)
        Me.GroupBox1.Controls.Add(Me.bBuscarCli)
        Me.GroupBox1.Controls.Add(Me.xDoc1)
        Me.GroupBox1.Controls.Add(Me.xNumero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cTipoDoc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cLocal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 115)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'xLocal
        '
        Me.xLocal.Location = New System.Drawing.Point(390, 21)
        Me.xLocal.Name = "xLocal"
        Me.xLocal.Size = New System.Drawing.Size(22, 23)
        Me.xLocal.TabIndex = 9
        Me.xLocal.Visible = False
        '
        'bBuscarCli
        '
        Me.bBuscarCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBuscarCli.Image = Global.SisVen.My.Resources.Resources.find
        Me.bBuscarCli.Location = New System.Drawing.Point(227, 80)
        Me.bBuscarCli.Name = "bBuscarCli"
        Me.bBuscarCli.Size = New System.Drawing.Size(80, 25)
        Me.bBuscarCli.TabIndex = 8
        Me.bBuscarCli.Text = "Buscar"
        Me.bBuscarCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bBuscarCli.UseVisualStyleBackColor = True
        '
        'xDoc1
        '
        Me.xDoc1.Location = New System.Drawing.Point(390, 48)
        Me.xDoc1.Name = "xDoc1"
        Me.xDoc1.Size = New System.Drawing.Size(22, 23)
        Me.xDoc1.TabIndex = 5
        Me.xDoc1.Visible = False
        '
        'xNumero
        '
        Me.xNumero.Location = New System.Drawing.Point(121, 81)
        Me.xNumero.Name = "xNumero"
        Me.xNumero.Size = New System.Drawing.Size(100, 23)
        Me.xNumero.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "N° Documento"
        '
        'cTipoDoc
        '
        Me.cTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTipoDoc.FormattingEnabled = True
        Me.cTipoDoc.Location = New System.Drawing.Point(121, 51)
        Me.cTipoDoc.Name = "cTipoDoc"
        Me.cTipoDoc.Size = New System.Drawing.Size(263, 24)
        Me.cTipoDoc.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Documento"
        '
        'cLocal
        '
        Me.cLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cLocal.FormattingEnabled = True
        Me.cLocal.Location = New System.Drawing.Point(121, 21)
        Me.cLocal.Name = "cLocal"
        Me.cLocal.Size = New System.Drawing.Size(263, 24)
        Me.cLocal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Local"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.xFolio)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.xDoc2)
        Me.GroupBox2.Controls.Add(Me.xAnula)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 352)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 72)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'xFolio
        '
        Me.xFolio.Location = New System.Drawing.Point(122, 44)
        Me.xFolio.Name = "xFolio"
        Me.xFolio.Size = New System.Drawing.Size(100, 23)
        Me.xFolio.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "N° Folio"
        '
        'xDoc2
        '
        Me.xDoc2.Location = New System.Drawing.Point(391, 13)
        Me.xDoc2.Name = "xDoc2"
        Me.xDoc2.Size = New System.Drawing.Size(22, 23)
        Me.xDoc2.TabIndex = 6
        Me.xDoc2.Visible = False
        '
        'xAnula
        '
        Me.xAnula.BackColor = System.Drawing.SystemColors.MenuText
        Me.xAnula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xAnula.ForeColor = System.Drawing.Color.Yellow
        Me.xAnula.Location = New System.Drawing.Point(122, 16)
        Me.xAnula.Name = "xAnula"
        Me.xAnula.Size = New System.Drawing.Size(263, 23)
        Me.xAnula.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Anulación con"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.xCliente)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.xMonto)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.xFecha)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.xNombre)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.xRut)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 176)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(496, 133)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'xCliente
        '
        Me.xCliente.Location = New System.Drawing.Point(121, 17)
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(100, 23)
        Me.xCliente.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Cliente"
        '
        'xMonto
        '
        Me.xMonto.Location = New System.Drawing.Point(121, 104)
        Me.xMonto.Name = "xMonto"
        Me.xMonto.Size = New System.Drawing.Size(100, 23)
        Me.xMonto.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Monto"
        '
        'xFecha
        '
        Me.xFecha.Location = New System.Drawing.Point(121, 74)
        Me.xFecha.Name = "xFecha"
        Me.xFecha.Size = New System.Drawing.Size(100, 23)
        Me.xFecha.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha"
        '
        'xNombre
        '
        Me.xNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xNombre.Location = New System.Drawing.Point(121, 45)
        Me.xNombre.Name = "xNombre"
        Me.xNombre.Size = New System.Drawing.Size(369, 23)
        Me.xNombre.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Razón Social"
        '
        'xRut
        '
        Me.xRut.Location = New System.Drawing.Point(284, 16)
        Me.xRut.Name = "xRut"
        Me.xRut.Size = New System.Drawing.Size(100, 23)
        Me.xRut.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(248, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Rut"
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.BackColor = System.Drawing.Color.White
        Me.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bLimpiar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.SisVen.My.Resources.Resources.clean24
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLimpiar.Location = New System.Drawing.Point(12, 441)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(101, 36)
        Me.bLimpiar.TabIndex = 16
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bLimpiar.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cFecha)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 308)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(496, 46)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        '
        'cFecha
        '
        Me.cFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cFecha.CalendarForeColor = System.Drawing.Color.Red
        Me.cFecha.CustomFormat = "dd/MM/yyyy"
        Me.cFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cFecha.Location = New System.Drawing.Point(122, 15)
        Me.cFecha.Name = "cFecha"
        Me.cFecha.Size = New System.Drawing.Size(101, 23)
        Me.cFecha.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Fecha Anulación"
        '
        'WinDeco1
        '
        Me.WinDeco1.AlturaFooter = 60
        Me.WinDeco1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.WinDeco1.BordeVentana = 2
        Me.WinDeco1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WinDeco1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.WinDeco1.Location = New System.Drawing.Point(0, 0)
        Me.WinDeco1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WinDeco1.MuestraBordeExterior = -1
        Me.WinDeco1.Name = "WinDeco1"
        Me.WinDeco1.Size = New System.Drawing.Size(520, 50)
        Me.WinDeco1.TabIndex = 18
        Me.WinDeco1.TituloVentana = "Anular Documento Electrónico"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = False
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'AnularDocumentoElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.WinDeco1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.Salir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1364, 724)
        Me.Name = "AnularDocumentoElectronico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anular Documento Electrónico"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Salir As Button
    Friend WithEvents bGuardar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents xNumero As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cTipoDoc As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cLocal As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents xAnula As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents xMonto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents xFecha As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents xNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents xRut As TextBox
    Friend WithEvents xDoc1 As TextBox
    Friend WithEvents xDoc2 As TextBox
    Friend WithEvents bBuscarCli As Button
    Friend WithEvents xCliente As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents xLocal As TextBox
    Friend WithEvents bLimpiar As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cFecha As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents xFolio As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents WinDeco1 As WinDeco
End Class
