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
        Me.btnPurple = New System.Windows.Forms.Button()
        Me.btnDark = New System.Windows.Forms.Button()
        Me.btnLight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPurple
        '
        Me.btnPurple.Location = New System.Drawing.Point(12, 12)
        Me.btnPurple.Name = "btnPurple"
        Me.btnPurple.Size = New System.Drawing.Size(119, 43)
        Me.btnPurple.TabIndex = 0
        Me.btnPurple.Text = "Purple"
        Me.btnPurple.UseVisualStyleBackColor = True
        '
        'btnDark
        '
        Me.btnDark.Location = New System.Drawing.Point(137, 12)
        Me.btnDark.Name = "btnDark"
        Me.btnDark.Size = New System.Drawing.Size(119, 43)
        Me.btnDark.TabIndex = 1
        Me.btnDark.Text = "Dark"
        Me.btnDark.UseVisualStyleBackColor = True
        '
        'btnLight
        '
        Me.btnLight.Location = New System.Drawing.Point(262, 12)
        Me.btnLight.Name = "btnLight"
        Me.btnLight.Size = New System.Drawing.Size(119, 43)
        Me.btnLight.TabIndex = 2
        Me.btnLight.Text = "Light "
        Me.btnLight.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 67)
        Me.Controls.Add(Me.btnLight)
        Me.Controls.Add(Me.btnDark)
        Me.Controls.Add(Me.btnPurple)
        Me.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 16.2!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "frmSettings"
        Me.ShowIcon = False
        Me.Text = "Change settings yo"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPurple As Button
    Friend WithEvents btnDark As Button
    Friend WithEvents btnLight As Button
End Class
