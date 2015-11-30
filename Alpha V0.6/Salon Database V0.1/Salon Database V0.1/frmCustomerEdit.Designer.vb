<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomerEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerEdit))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRecordID = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtForename = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblCurrentRecord = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblRecordID)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblCurrentRecord)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(652, 462)
        Me.Panel1.TabIndex = 0
        '
        'lblRecordID
        '
        Me.lblRecordID.AutoSize = True
        Me.lblRecordID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecordID.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordID.ForeColor = System.Drawing.Color.White
        Me.lblRecordID.Location = New System.Drawing.Point(341, 26)
        Me.lblRecordID.Name = "lblRecordID"
        Me.lblRecordID.Size = New System.Drawing.Size(20, 21)
        Me.lblRecordID.TabIndex = 85
        Me.lblRecordID.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(236, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 19)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Customer ID"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(533, 405)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 19)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Cancel"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(482, 391)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(45, 45)
        Me.btnCancel.TabIndex = 82
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(533, 343)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 19)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Save Record"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(482, 329)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(45, 45)
        Me.btnSave.TabIndex = 80
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtForename)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTelephone)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSurname)
        Me.GroupBox1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(22, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 175)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Required fields"
        '
        'txtForename
        '
        Me.txtForename.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtForename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtForename.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForename.ForeColor = System.Drawing.SystemColors.Info
        Me.txtForename.Location = New System.Drawing.Point(157, 51)
        Me.txtForename.MaxLength = 20
        Me.txtForename.Name = "txtForename"
        Me.txtForename.Size = New System.Drawing.Size(244, 27)
        Me.txtForename.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 19)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Forename"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 19)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Telephone"
        '
        'txtTelephone
        '
        Me.txtTelephone.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelephone.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelephone.ForeColor = System.Drawing.SystemColors.Info
        Me.txtTelephone.Location = New System.Drawing.Point(157, 125)
        Me.txtTelephone.MaxLength = 14
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(244, 27)
        Me.txtTelephone.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Surname"
        '
        'txtSurname
        '
        Me.txtSurname.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurname.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurname.ForeColor = System.Drawing.SystemColors.Info
        Me.txtSurname.Location = New System.Drawing.Point(157, 88)
        Me.txtSurname.MaxLength = 20
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(244, 27)
        Me.txtSurname.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtEmail)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtAddress1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtAddress2)
        Me.Panel2.Location = New System.Drawing.Point(22, 279)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(440, 145)
        Me.Panel2.TabIndex = 79
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.SystemColors.Info
        Me.txtEmail.Location = New System.Drawing.Point(162, 90)
        Me.txtEmail.MaxLength = 40
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(244, 27)
        Me.txtEmail.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 19)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Address Line 1"
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Info
        Me.txtAddress1.Location = New System.Drawing.Point(162, 16)
        Me.txtAddress1.MaxLength = 25
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(244, 27)
        Me.txtAddress1.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 19)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Email"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 19)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Address Line 2"
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Info
        Me.txtAddress2.Location = New System.Drawing.Point(162, 53)
        Me.txtAddress2.MaxLength = 25
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(244, 27)
        Me.txtAddress2.TabIndex = 27
        '
        'lblCurrentRecord
        '
        Me.lblCurrentRecord.AutoSize = True
        Me.lblCurrentRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentRecord.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentRecord.ForeColor = System.Drawing.Color.White
        Me.lblCurrentRecord.Location = New System.Drawing.Point(147, 26)
        Me.lblCurrentRecord.Name = "lblCurrentRecord"
        Me.lblCurrentRecord.Size = New System.Drawing.Size(47, 21)
        Me.lblCurrentRecord.TabIndex = 77
        Me.lblCurrentRecord.Text = "0036"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(18, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 19)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Record Number"
        '
        'frmCustomerEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(676, 486)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmCustomerEdit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblRecordID As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtForename As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAddress1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAddress2 As TextBox
    Friend WithEvents lblCurrentRecord As Label
    Friend WithEvents Label4 As Label
End Class
