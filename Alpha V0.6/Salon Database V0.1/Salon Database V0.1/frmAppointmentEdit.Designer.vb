<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAppointmentEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppointmentEdit))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClearServ4 = New System.Windows.Forms.Button()
        Me.btnClearServ3 = New System.Windows.Forms.Button()
        Me.btnClearServ2 = New System.Windows.Forms.Button()
        Me.cboService4 = New System.Windows.Forms.ComboBox()
        Me.cboService3 = New System.Windows.Forms.ComboBox()
        Me.cboService2 = New System.Windows.Forms.ComboBox()
        Me.cboService1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRecordID = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ltvCustName = New System.Windows.Forms.ListView()
        Me.ColName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblCurrentRecord = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtComment)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblRecordID)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.lblCurrentRecord)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(929, 493)
        Me.Panel1.TabIndex = 1
        '
        'txtComment
        '
        Me.txtComment.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtComment.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.ForeColor = System.Drawing.SystemColors.Info
        Me.txtComment.Location = New System.Drawing.Point(554, 267)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(342, 104)
        Me.txtComment.TabIndex = 101
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.btnClearServ4)
        Me.GroupBox2.Controls.Add(Me.btnClearServ3)
        Me.GroupBox2.Controls.Add(Me.btnClearServ2)
        Me.GroupBox2.Controls.Add(Me.cboService4)
        Me.GroupBox2.Controls.Add(Me.cboService3)
        Me.GroupBox2.Controls.Add(Me.cboService2)
        Me.GroupBox2.Controls.Add(Me.cboService1)
        Me.GroupBox2.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(456, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(440, 175)
        Me.GroupBox2.TabIndex = 95
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Services"
        '
        'btnClearServ4
        '
        Me.btnClearServ4.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClearServ4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearServ4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClearServ4.Image = CType(resources.GetObject("btnClearServ4.Image"), System.Drawing.Image)
        Me.btnClearServ4.Location = New System.Drawing.Point(399, 134)
        Me.btnClearServ4.Name = "btnClearServ4"
        Me.btnClearServ4.Size = New System.Drawing.Size(30, 30)
        Me.btnClearServ4.TabIndex = 99
        Me.btnClearServ4.UseVisualStyleBackColor = False
        '
        'btnClearServ3
        '
        Me.btnClearServ3.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClearServ3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearServ3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClearServ3.Image = CType(resources.GetObject("btnClearServ3.Image"), System.Drawing.Image)
        Me.btnClearServ3.Location = New System.Drawing.Point(399, 101)
        Me.btnClearServ3.Name = "btnClearServ3"
        Me.btnClearServ3.Size = New System.Drawing.Size(30, 30)
        Me.btnClearServ3.TabIndex = 98
        Me.btnClearServ3.UseVisualStyleBackColor = False
        '
        'btnClearServ2
        '
        Me.btnClearServ2.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClearServ2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearServ2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClearServ2.Image = CType(resources.GetObject("btnClearServ2.Image"), System.Drawing.Image)
        Me.btnClearServ2.Location = New System.Drawing.Point(399, 68)
        Me.btnClearServ2.Name = "btnClearServ2"
        Me.btnClearServ2.Size = New System.Drawing.Size(30, 30)
        Me.btnClearServ2.TabIndex = 96
        Me.btnClearServ2.UseVisualStyleBackColor = False
        '
        'cboService4
        '
        Me.cboService4.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboService4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboService4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboService4.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.cboService4.ForeColor = System.Drawing.Color.White
        Me.cboService4.FormattingEnabled = True
        Me.cboService4.Location = New System.Drawing.Point(14, 136)
        Me.cboService4.Name = "cboService4"
        Me.cboService4.Size = New System.Drawing.Size(381, 27)
        Me.cboService4.TabIndex = 97
        '
        'cboService3
        '
        Me.cboService3.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboService3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboService3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboService3.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.cboService3.ForeColor = System.Drawing.Color.White
        Me.cboService3.FormattingEnabled = True
        Me.cboService3.Location = New System.Drawing.Point(14, 103)
        Me.cboService3.Name = "cboService3"
        Me.cboService3.Size = New System.Drawing.Size(381, 27)
        Me.cboService3.TabIndex = 96
        '
        'cboService2
        '
        Me.cboService2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboService2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboService2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboService2.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.cboService2.ForeColor = System.Drawing.Color.White
        Me.cboService2.FormattingEnabled = True
        Me.cboService2.Location = New System.Drawing.Point(14, 70)
        Me.cboService2.Name = "cboService2"
        Me.cboService2.Size = New System.Drawing.Size(381, 27)
        Me.cboService2.TabIndex = 95
        '
        'cboService1
        '
        Me.cboService1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboService1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboService1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboService1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.cboService1.ForeColor = System.Drawing.Color.White
        Me.cboService1.FormattingEnabled = True
        Me.cboService1.Location = New System.Drawing.Point(14, 37)
        Me.cboService1.Name = "cboService1"
        Me.cboService1.Size = New System.Drawing.Size(381, 27)
        Me.cboService1.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(452, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 22)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Comment:"
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
        Me.Label5.Location = New System.Drawing.Point(215, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 19)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Appointment ID"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(812, 453)
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
        Me.btnCancel.Location = New System.Drawing.Point(761, 439)
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
        Me.Label12.Location = New System.Drawing.Point(812, 402)
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
        Me.btnSave.Location = New System.Drawing.Point(761, 388)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(45, 45)
        Me.btnSave.TabIndex = 80
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtCustName)
        Me.GroupBox1.Controls.Add(Me.dtpTime)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ltvCustName)
        Me.GroupBox1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(22, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 401)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Appointment Details"
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtCustName.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.SystemColors.Info
        Me.txtCustName.Location = New System.Drawing.Point(106, 36)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(297, 27)
        Me.txtCustName.TabIndex = 99
        '
        'dtpTime
        '
        Me.dtpTime.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dtpTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.dtpTime.CustomFormat = "00:00"
        Me.dtpTime.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(106, 352)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(111, 27)
        Me.dtpTime.TabIndex = 87
        '
        'dtpDate
        '
        Me.dtpDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.dtpDate.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.dtpDate.Location = New System.Drawing.Point(106, 315)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(188, 27)
        Me.dtpDate.TabIndex = 86
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 319)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 22)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 22)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 22)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Time"
        '
        'ltvCustName
        '
        Me.ltvCustName.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ltvCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ltvCustName.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColName})
        Me.ltvCustName.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.ltvCustName.ForeColor = System.Drawing.Color.White
        Me.ltvCustName.FullRowSelect = True
        Me.ltvCustName.HideSelection = False
        Me.ltvCustName.Location = New System.Drawing.Point(106, 36)
        Me.ltvCustName.MultiSelect = False
        Me.ltvCustName.Name = "ltvCustName"
        Me.ltvCustName.Size = New System.Drawing.Size(297, 252)
        Me.ltvCustName.TabIndex = 98
        Me.ltvCustName.UseCompatibleStateImageBehavior = False
        Me.ltvCustName.View = System.Windows.Forms.View.Details
        '
        'ColName
        '
        Me.ColName.Text = ""
        Me.ColName.Width = 450
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
        'frmAppointmentEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(953, 517)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAppointmentEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAppointmentEdit"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCurrentRecord As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboService4 As ComboBox
    Friend WithEvents cboService3 As ComboBox
    Friend WithEvents cboService2 As ComboBox
    Friend WithEvents cboService1 As ComboBox
    Friend WithEvents btnClearServ4 As Button
    Friend WithEvents btnClearServ3 As Button
    Friend WithEvents btnClearServ2 As Button
    Friend WithEvents ltvCustName As ListView
    Friend WithEvents ColName As ColumnHeader
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents txtComment As TextBox
    Friend WithEvents Label3 As Label
End Class
