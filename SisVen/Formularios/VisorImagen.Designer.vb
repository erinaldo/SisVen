<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorImagen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisorImagen))
        Me.xFirma = New System.Windows.Forms.PictureBox()
        Me.xLogo = New System.Windows.Forms.PictureBox()
        CType(Me.xFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xFirma
        '
        Me.xFirma.Location = New System.Drawing.Point(32, 25)
        Me.xFirma.Name = "xFirma"
        Me.xFirma.Size = New System.Drawing.Size(219, 231)
        Me.xFirma.TabIndex = 0
        Me.xFirma.TabStop = False
        '
        'xLogo
        '
        Me.xLogo.Location = New System.Drawing.Point(360, 25)
        Me.xLogo.Name = "xLogo"
        Me.xLogo.Size = New System.Drawing.Size(219, 231)
        Me.xLogo.TabIndex = 0
        Me.xLogo.TabStop = False
        '
        'VisorImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 434)
        Me.Controls.Add(Me.xLogo)
        Me.Controls.Add(Me.xFirma)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VisorImagen"
        Me.Text = "VisorImagen"
        CType(Me.xFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents xFirma As PictureBox
    Friend WithEvents xLogo As PictureBox
End Class
