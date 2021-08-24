<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargaCAF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CargaCAF))
        Me.cdCAF = New System.Windows.Forms.OpenFileDialog()
        Me.xArchivo = New System.Windows.Forms.TextBox()
        Me.xStatus = New System.Windows.Forms.TextBox()
        Me.WinDeco1 = New SisVen.WinDeco()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.bCargar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cdCAF
        '
        Me.cdCAF.FileName = "OpenFileDialog1"
        '
        'xArchivo
        '
        Me.xArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xArchivo.Location = New System.Drawing.Point(6, 99)
        Me.xArchivo.Name = "xArchivo"
        Me.xArchivo.Size = New System.Drawing.Size(476, 20)
        Me.xArchivo.TabIndex = 0
        '
        'xStatus
        '
        Me.xStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xStatus.Location = New System.Drawing.Point(6, 125)
        Me.xStatus.Multiline = True
        Me.xStatus.Name = "xStatus"
        Me.xStatus.ReadOnly = True
        Me.xStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.xStatus.Size = New System.Drawing.Size(476, 145)
        Me.xStatus.TabIndex = 2
        Me.xStatus.WordWrap = False
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
        Me.WinDeco1.Size = New System.Drawing.Size(494, 50)
        Me.WinDeco1.TabIndex = 5
        Me.WinDeco1.TituloVentana = "Carga de Archivos CAF de SII"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.BackColor = System.Drawing.Color.White
        Me.bSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bSalir.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bSalir.Location = New System.Drawing.Point(383, 290)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(99, 36)
        Me.bSalir.TabIndex = 229
        Me.bSalir.Text = "Cancelar"
        Me.bSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bSalir.UseVisualStyleBackColor = False
        '
        'Guardar
        '
        Me.Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guardar.BackColor = System.Drawing.Color.White
        Me.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Guardar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar.Image = Global.SisVen.My.Resources.Resources.save24
        Me.Guardar.Location = New System.Drawing.Point(205, 56)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(101, 37)
        Me.Guardar.TabIndex = 230
        Me.Guardar.Text = "Cargar"
        Me.Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Guardar.UseVisualStyleBackColor = False
        '
        'bCargar
        '
        Me.bCargar.BackColor = System.Drawing.Color.White
        Me.bCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCargar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCargar.Image = Global.SisVen.My.Resources.Resources.clipadd
        Me.bCargar.Location = New System.Drawing.Point(6, 56)
        Me.bCargar.Name = "bCargar"
        Me.bCargar.Size = New System.Drawing.Size(193, 37)
        Me.bCargar.TabIndex = 231
        Me.bCargar.Text = "Seleccionar Archivo XML"
        Me.bCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCargar.UseVisualStyleBackColor = False
        '
        'CargaCAF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 338)
        Me.Controls.Add(Me.bCargar)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.WinDeco1)
        Me.Controls.Add(Me.xStatus)
        Me.Controls.Add(Me.xArchivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1364, 724)
        Me.MinimizeBox = False
        Me.Name = "CargaCAF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Correlativos CAF"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cdCAF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents xArchivo As System.Windows.Forms.TextBox
    Friend WithEvents xStatus As System.Windows.Forms.TextBox
    Friend WithEvents WinDeco1 As WinDeco
    Public WithEvents bSalir As Button
    Public WithEvents Guardar As Button
    Public WithEvents bCargar As Button
End Class
