<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaTabla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaTabla))
        Me.bMostrar = New System.Windows.Forms.Button()
        Me.bCancelar = New System.Windows.Forms.Button()
        Me.xTabla = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.WinDeco1 = New SisVen.WinDeco()
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bMostrar
        '
        Me.bMostrar.BackColor = System.Drawing.Color.White
        Me.bMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bMostrar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMostrar.Image = Global.SisVen.My.Resources.Resources.up24
        Me.bMostrar.Location = New System.Drawing.Point(12, 464)
        Me.bMostrar.Name = "bMostrar"
        Me.bMostrar.Size = New System.Drawing.Size(90, 36)
        Me.bMostrar.TabIndex = 74
        Me.bMostrar.Text = "Mostrar"
        Me.bMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bMostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bMostrar.UseVisualStyleBackColor = False
        '
        'bCancelar
        '
        Me.bCancelar.BackColor = System.Drawing.Color.White
        Me.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancelar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Image = Global.SisVen.My.Resources.Resources.cancel24
        Me.bCancelar.Location = New System.Drawing.Point(519, 464)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(100, 36)
        Me.bCancelar.TabIndex = 73
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bCancelar.UseVisualStyleBackColor = False
        '
        'xTabla
        '
        Me.xTabla.AllowEditing = False
        Me.xTabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xTabla.ColumnInfo = "0,0,0,0,0,110,Columns:"
        Me.xTabla.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.xTabla.Location = New System.Drawing.Point(12, 56)
        Me.xTabla.Name = "xTabla"
        Me.xTabla.Rows.Count = 1
        Me.xTabla.Rows.DefaultSize = 22
        Me.xTabla.Size = New System.Drawing.Size(607, 386)
        Me.xTabla.StyleInfo = resources.GetString("xTabla.StyleInfo")
        Me.xTabla.TabIndex = 205
        Me.xTabla.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black
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
        Me.WinDeco1.Size = New System.Drawing.Size(631, 50)
        Me.WinDeco1.TabIndex = 0
        Me.WinDeco1.TituloVentana = "Listados"
        Me.WinDeco1.VerCerrar = True
        Me.WinDeco1.VerLogo = True
        Me.WinDeco1.VerMaximizar = False
        Me.WinDeco1.VerMinimizar = True
        Me.WinDeco1.VerTitulo = True
        '
        'ConsultaTabla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 512)
        Me.Controls.Add(Me.xTabla)
        Me.Controls.Add(Me.bMostrar)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.WinDeco1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1302, 900)
        Me.Name = "ConsultaTabla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisVen - Listados"
        CType(Me.xTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WinDeco1 As WinDeco
    Public WithEvents bMostrar As Button
    Public WithEvents bCancelar As Button
    Friend WithEvents xTabla As C1.Win.C1FlexGrid.C1FlexGrid
End Class
