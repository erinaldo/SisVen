﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Acerca
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Acerca))
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lUltimoDespliegue = New System.Windows.Forms.Label()
        Me.lSistema = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.White
        Me.Logo.Image = Global.SisVen.My.Resources.Resources.Logo_Wikets_300
        Me.Logo.Location = New System.Drawing.Point(17, 5)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(300, 153)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Logo.TabIndex = 0
        Me.Logo.TabStop = False
        '
        'Aceptar
        '
        Me.Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Aceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Aceptar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aceptar.ForeColor = System.Drawing.Color.White
        Me.Aceptar.Image = Global.SisVen.My.Resources.Resources.ok24
        Me.Aceptar.Location = New System.Drawing.Point(213, 236)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(118, 50)
        Me.Aceptar.TabIndex = 46
        Me.Aceptar.Text = "Aceptar"
        Me.Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Aceptar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lUltimoDespliegue)
        Me.Panel1.Controls.Add(Me.lSistema)
        Me.Panel1.Controls.Add(Me.Aceptar)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 164)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 286)
        Me.Panel1.TabIndex = 47
        '
        'lUltimoDespliegue
        '
        Me.lUltimoDespliegue.AutoSize = True
        Me.lUltimoDespliegue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lUltimoDespliegue.ForeColor = System.Drawing.Color.Yellow
        Me.lUltimoDespliegue.Location = New System.Drawing.Point(17, 36)
        Me.lUltimoDespliegue.Name = "lUltimoDespliegue"
        Me.lUltimoDespliegue.Size = New System.Drawing.Size(113, 15)
        Me.lUltimoDespliegue.TabIndex = 49
        Me.lUltimoDespliegue.Text = "Últma Actualización"
        '
        'lSistema
        '
        Me.lSistema.AutoSize = True
        Me.lSistema.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lSistema.ForeColor = System.Drawing.Color.Yellow
        Me.lSistema.Location = New System.Drawing.Point(17, 10)
        Me.lSistema.Name = "lSistema"
        Me.lSistema.Size = New System.Drawing.Size(48, 15)
        Me.lSistema.TabIndex = 49
        Me.lSistema.Text = "Versión"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SisVen.My.Resources.Resources.banner3
        Me.PictureBox1.Location = New System.Drawing.Point(0, 236)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(130, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 167)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Acerca
        '
        Me.AcceptButton = Me.Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(331, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(331, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(331, 450)
        Me.Name = "Acerca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Acerca de"
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Logo As System.Windows.Forms.PictureBox
    Public WithEvents Aceptar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lSistema As System.Windows.Forms.Label
    Friend WithEvents lUltimoDespliegue As Label
End Class
