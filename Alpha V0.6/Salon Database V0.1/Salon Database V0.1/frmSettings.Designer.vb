<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPassChange = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radPurple = New System.Windows.Forms.RadioButton()
        Me.radDark = New System.Windows.Forms.RadioButton()
        Me.radLight = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPassChange
        '
        Me.btnPassChange.Location = New System.Drawing.Point(12, 168)
        Me.btnPassChange.Name = "btnPassChange"
        Me.btnPassChange.Size = New System.Drawing.Size(216, 33)
        Me.btnPassChange.TabIndex = 3
        Me.btnPassChange.Text = "Change Password"
        Me.btnPassChange.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Theme:"
        '
        'radPurple
        '
        Me.radPurple.AutoSize = True
        Me.radPurple.ForeColor = System.Drawing.Color.White
        Me.radPurple.Location = New System.Drawing.Point(12, 48)
        Me.radPurple.Name = "radPurple"
        Me.radPurple.Size = New System.Drawing.Size(93, 30)
        Me.radPurple.TabIndex = 46
        Me.radPurple.TabStop = True
        Me.radPurple.Text = "Purple"
        Me.radPurple.UseVisualStyleBackColor = True
        '
        'radDark
        '
        Me.radDark.AutoSize = True
        Me.radDark.ForeColor = System.Drawing.Color.White
        Me.radDark.Location = New System.Drawing.Point(12, 84)
        Me.radDark.Name = "radDark"
        Me.radDark.Size = New System.Drawing.Size(75, 30)
        Me.radDark.TabIndex = 47
        Me.radDark.TabStop = True
        Me.radDark.Text = "Dark"
        Me.radDark.UseVisualStyleBackColor = True
        '
        'radLight
        '
        Me.radLight.AutoSize = True
        Me.radLight.ForeColor = System.Drawing.Color.White
        Me.radLight.Location = New System.Drawing.Point(12, 120)
        Me.radLight.Name = "radLight"
        Me.radLight.Size = New System.Drawing.Size(79, 30)
        Me.radLight.TabIndex = 48
        Me.radLight.TabStop = True
        Me.radLight.Text = "Light"
        Me.radLight.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(131, 221)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 36)
        Me.btnSave.TabIndex = 49
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(244, 272)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.radLight)
        Me.Controls.Add(Me.radDark)
        Me.Controls.Add(Me.radPurple)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPassChange)
        Me.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 16.2!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "frmSettings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change settings yo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPassChange As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents radPurple As RadioButton
    Friend WithEvents radDark As RadioButton
    Friend WithEvents radLight As RadioButton
    Friend WithEvents btnSave As Button
End Class
