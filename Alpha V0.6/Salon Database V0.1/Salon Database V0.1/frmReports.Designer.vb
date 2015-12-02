<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnServiceForm = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAppointmentForm = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCustomerForm = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpAppForDate = New System.Windows.Forms.GroupBox()
        Me.lblDatePicked = New System.Windows.Forms.Label()
        Me.calDatePicker = New System.Windows.Forms.MonthCalendar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.btnDisplayReport = New System.Windows.Forms.Button()
        Me.grpCustServHistory = New System.Windows.Forms.GroupBox()
        Me.ltvCustName = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCustomerName = New System.Windows.Forms.ComboBox()
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.dtpAppDate = New System.Windows.Forms.DateTimePicker()
        Me.ltvReport = New System.Windows.Forms.ListView()
        Me.col1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkGrid = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpAppForDate.SuspendLayout()
        Me.grpCustServHistory.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(172, 263)
        Me.Panel1.TabIndex = 31
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Panel6.Controls.Add(Me.btnServiceForm)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Location = New System.Drawing.Point(4, 177)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(165, 81)
        Me.Panel6.TabIndex = 20
        '
        'btnServiceForm
        '
        Me.btnServiceForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnServiceForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnServiceForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnServiceForm.Image = CType(resources.GetObject("btnServiceForm.Image"), System.Drawing.Image)
        Me.btnServiceForm.Location = New System.Drawing.Point(3, 3)
        Me.btnServiceForm.Name = "btnServiceForm"
        Me.btnServiceForm.Size = New System.Drawing.Size(45, 45)
        Me.btnServiceForm.TabIndex = 18
        Me.btnServiceForm.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "SERVICES"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Panel5.Controls.Add(Me.btnAppointmentForm)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Location = New System.Drawing.Point(4, 90)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(165, 81)
        Me.Panel5.TabIndex = 19
        '
        'btnAppointmentForm
        '
        Me.btnAppointmentForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnAppointmentForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAppointmentForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnAppointmentForm.Image = CType(resources.GetObject("btnAppointmentForm.Image"), System.Drawing.Image)
        Me.btnAppointmentForm.Location = New System.Drawing.Point(3, 3)
        Me.btnAppointmentForm.Name = "btnAppointmentForm"
        Me.btnAppointmentForm.Size = New System.Drawing.Size(45, 45)
        Me.btnAppointmentForm.TabIndex = 18
        Me.btnAppointmentForm.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 17)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "APPOINTMENTS"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnCustomerForm)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(4, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(165, 81)
        Me.Panel3.TabIndex = 1
        '
        'btnCustomerForm
        '
        Me.btnCustomerForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnCustomerForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomerForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnCustomerForm.Image = CType(resources.GetObject("btnCustomerForm.Image"), System.Drawing.Image)
        Me.btnCustomerForm.Location = New System.Drawing.Point(3, 3)
        Me.btnCustomerForm.Name = "btnCustomerForm"
        Me.btnCustomerForm.Size = New System.Drawing.Size(45, 45)
        Me.btnCustomerForm.TabIndex = 18
        Me.btnCustomerForm.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "CUSTOMERS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkGrid)
        Me.Panel2.Controls.Add(Me.grpAppForDate)
        Me.Panel2.Controls.Add(Me.lbl1)
        Me.Panel2.Controls.Add(Me.btnDisplayReport)
        Me.Panel2.Controls.Add(Me.grpCustServHistory)
        Me.Panel2.Controls.Add(Me.cboReportType)
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(190, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(492, 916)
        Me.Panel2.TabIndex = 32
        '
        'grpAppForDate
        '
        Me.grpAppForDate.Controls.Add(Me.lblDatePicked)
        Me.grpAppForDate.Controls.Add(Me.calDatePicker)
        Me.grpAppForDate.Controls.Add(Me.Label3)
        Me.grpAppForDate.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAppForDate.ForeColor = System.Drawing.Color.White
        Me.grpAppForDate.Location = New System.Drawing.Point(3, 104)
        Me.grpAppForDate.Name = "grpAppForDate"
        Me.grpAppForDate.Size = New System.Drawing.Size(484, 807)
        Me.grpAppForDate.TabIndex = 98
        Me.grpAppForDate.TabStop = False
        '
        'lblDatePicked
        '
        Me.lblDatePicked.AutoSize = True
        Me.lblDatePicked.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatePicked.ForeColor = System.Drawing.Color.White
        Me.lblDatePicked.Location = New System.Drawing.Point(348, 26)
        Me.lblDatePicked.Name = "lblDatePicked"
        Me.lblDatePicked.Size = New System.Drawing.Size(120, 24)
        Me.lblDatePicked.TabIndex = 89
        Me.lblDatePicked.Text = "11/11/2015"
        '
        'calDatePicker
        '
        Me.calDatePicker.BackColor = System.Drawing.SystemColors.Window
        Me.calDatePicker.CalendarDimensions = New System.Drawing.Size(2, 5)
        Me.calDatePicker.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!)
        Me.calDatePicker.Location = New System.Drawing.Point(10, 59)
        Me.calDatePicker.MaxSelectionCount = 1
        Me.calDatePicker.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.calDatePicker.Name = "calDatePicker"
        Me.calDatePicker.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 24)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Pick a Date"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.White
        Me.lbl1.Location = New System.Drawing.Point(54, 68)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(149, 24)
        Me.lbl1.TabIndex = 46
        Me.lbl1.Text = "Display Report"
        '
        'btnDisplayReport
        '
        Me.btnDisplayReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnDisplayReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisplayReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnDisplayReport.Image = CType(resources.GetObject("btnDisplayReport.Image"), System.Drawing.Image)
        Me.btnDisplayReport.Location = New System.Drawing.Point(3, 53)
        Me.btnDisplayReport.Name = "btnDisplayReport"
        Me.btnDisplayReport.Size = New System.Drawing.Size(45, 45)
        Me.btnDisplayReport.TabIndex = 45
        Me.btnDisplayReport.UseVisualStyleBackColor = False
        '
        'grpCustServHistory
        '
        Me.grpCustServHistory.Controls.Add(Me.ltvCustName)
        Me.grpCustServHistory.Controls.Add(Me.Label1)
        Me.grpCustServHistory.Controls.Add(Me.cboCustomerName)
        Me.grpCustServHistory.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustServHistory.ForeColor = System.Drawing.Color.White
        Me.grpCustServHistory.Location = New System.Drawing.Point(3, 104)
        Me.grpCustServHistory.Name = "grpCustServHistory"
        Me.grpCustServHistory.Size = New System.Drawing.Size(484, 807)
        Me.grpCustServHistory.TabIndex = 44
        Me.grpCustServHistory.TabStop = False
        '
        'ltvCustName
        '
        Me.ltvCustName.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ltvCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ltvCustName.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName})
        Me.ltvCustName.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 12.0!)
        Me.ltvCustName.ForeColor = System.Drawing.Color.White
        Me.ltvCustName.FullRowSelect = True
        Me.ltvCustName.HideSelection = False
        Me.ltvCustName.Location = New System.Drawing.Point(6, 91)
        Me.ltvCustName.MultiSelect = False
        Me.ltvCustName.Name = "ltvCustName"
        Me.ltvCustName.Size = New System.Drawing.Size(472, 710)
        Me.ltvCustName.TabIndex = 97
        Me.ltvCustName.UseCompatibleStateImageBehavior = False
        Me.ltvCustName.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.Text = "Customer Name"
        Me.colName.Width = 470
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 24)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Pick a Customer"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboCustomerName.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerName.ForeColor = System.Drawing.Color.White
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(6, 53)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(472, 32)
        Me.cboCustomerName.TabIndex = 47
        '
        'cboReportType
        '
        Me.cboReportType.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportType.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReportType.ForeColor = System.Drawing.Color.White
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Items.AddRange(New Object() {"View all Appointments for a Date", "Customer Service History", "Customer Appointment History", "Services by Popularity", "Services by Profit", "View All Appointments for Time Period"})
        Me.cboReportType.Location = New System.Drawing.Point(3, 9)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(484, 32)
        Me.cboReportType.TabIndex = 43
        '
        'dtpAppDate
        '
        Me.dtpAppDate.Location = New System.Drawing.Point(12, 420)
        Me.dtpAppDate.Name = "dtpAppDate"
        Me.dtpAppDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpAppDate.TabIndex = 0
        Me.dtpAppDate.Visible = False
        '
        'ltvReport
        '
        Me.ltvReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ltvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ltvReport.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col1})
        Me.ltvReport.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltvReport.ForeColor = System.Drawing.Color.White
        Me.ltvReport.FullRowSelect = True
        Me.ltvReport.HideSelection = False
        Me.ltvReport.Location = New System.Drawing.Point(688, 12)
        Me.ltvReport.MultiSelect = False
        Me.ltvReport.Name = "ltvReport"
        Me.ltvReport.Size = New System.Drawing.Size(842, 916)
        Me.ltvReport.TabIndex = 98
        Me.ltvReport.UseCompatibleStateImageBehavior = False
        Me.ltvReport.View = System.Windows.Forms.View.Details
        '
        'col1
        '
        Me.col1.Text = ""
        Me.col1.Width = 400
        '
        'chkGrid
        '
        Me.chkGrid.AutoSize = True
        Me.chkGrid.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!)
        Me.chkGrid.ForeColor = System.Drawing.Color.White
        Me.chkGrid.Location = New System.Drawing.Point(356, 67)
        Me.chkGrid.Name = "chkGrid"
        Me.chkGrid.Size = New System.Drawing.Size(135, 28)
        Me.chkGrid.TabIndex = 99
        Me.chkGrid.Text = "Show Grid "
        Me.chkGrid.UseVisualStyleBackColor = True
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1542, 941)
        Me.Controls.Add(Me.ltvReport)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtpAppDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReports"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grpAppForDate.ResumeLayout(False)
        Me.grpAppForDate.PerformLayout()
        Me.grpCustServHistory.ResumeLayout(False)
        Me.grpCustServHistory.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnServiceForm As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnAppointmentForm As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnCustomerForm As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grpCustServHistory As GroupBox
    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents lbl1 As Label
    Friend WithEvents btnDisplayReport As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCustomerName As ComboBox
    Friend WithEvents ltvCustName As ListView
    Friend WithEvents dtpAppDate As DateTimePicker
    Friend WithEvents ltvReport As ListView
    Friend WithEvents col1 As ColumnHeader
    Friend WithEvents colName As ColumnHeader
    Friend WithEvents grpAppForDate As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents calDatePicker As MonthCalendar
    Friend WithEvents lblDatePicked As Label
    Friend WithEvents chkGrid As CheckBox
End Class
