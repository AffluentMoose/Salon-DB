﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.chkGrid = New System.Windows.Forms.CheckBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.btnDisplayReport = New System.Windows.Forms.Button()
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.grpCustServHistory = New System.Windows.Forms.GroupBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.ltvCustName = New System.Windows.Forms.ListView()
        Me.ColName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpServiceReport = New System.Windows.Forms.GroupBox()
        Me.radSortProfit = New System.Windows.Forms.RadioButton()
        Me.radSortNumber = New System.Windows.Forms.RadioButton()
        Me.grpAppForDateRange = New System.Windows.Forms.GroupBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpAppForDate = New System.Windows.Forms.GroupBox()
        Me.lblDatePicked = New System.Windows.Forms.Label()
        Me.calDatePicker = New System.Windows.Forms.MonthCalendar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ltvReport = New System.Windows.Forms.ListView()
        Me.col1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpCustServHistory.SuspendLayout()
        Me.grpServiceReport.SuspendLayout()
        Me.grpAppForDateRange.SuspendLayout()
        Me.grpAppForDate.SuspendLayout()
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
        Me.Panel2.Controls.Add(Me.lbl1)
        Me.Panel2.Controls.Add(Me.btnDisplayReport)
        Me.Panel2.Controls.Add(Me.cboReportType)
        Me.Panel2.Controls.Add(Me.grpCustServHistory)
        Me.Panel2.Controls.Add(Me.grpServiceReport)
        Me.Panel2.Controls.Add(Me.grpAppForDateRange)
        Me.Panel2.Controls.Add(Me.grpAppForDate)
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(190, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(492, 916)
        Me.Panel2.TabIndex = 32
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
        'cboReportType
        '
        Me.cboReportType.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportType.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReportType.ForeColor = System.Drawing.Color.White
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Items.AddRange(New Object() {"View all Appointments for a Date", "Customer Service History", "Customer Appointment History", "Services by Popularity / Profit", "View All Appointments for Time Period"})
        Me.cboReportType.Location = New System.Drawing.Point(3, 9)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(484, 32)
        Me.cboReportType.TabIndex = 43
        '
        'grpCustServHistory
        '
        Me.grpCustServHistory.Controls.Add(Me.txtCustomerName)
        Me.grpCustServHistory.Controls.Add(Me.ltvCustName)
        Me.grpCustServHistory.Controls.Add(Me.Label1)
        Me.grpCustServHistory.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustServHistory.ForeColor = System.Drawing.Color.White
        Me.grpCustServHistory.Location = New System.Drawing.Point(3, 104)
        Me.grpCustServHistory.Name = "grpCustServHistory"
        Me.grpCustServHistory.Size = New System.Drawing.Size(484, 807)
        Me.grpCustServHistory.TabIndex = 44
        Me.grpCustServHistory.TabStop = False
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtCustomerName.ForeColor = System.Drawing.SystemColors.Info
        Me.txtCustomerName.Location = New System.Drawing.Point(6, 54)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(472, 30)
        Me.txtCustomerName.TabIndex = 98
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
        Me.ltvCustName.Location = New System.Drawing.Point(6, 59)
        Me.ltvCustName.MultiSelect = False
        Me.ltvCustName.Name = "ltvCustName"
        Me.ltvCustName.Size = New System.Drawing.Size(472, 742)
        Me.ltvCustName.TabIndex = 97
        Me.ltvCustName.UseCompatibleStateImageBehavior = False
        Me.ltvCustName.View = System.Windows.Forms.View.Details
        '
        'ColName
        '
        Me.ColName.Text = ""
        Me.ColName.Width = 470
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
        'grpServiceReport
        '
        Me.grpServiceReport.Controls.Add(Me.radSortProfit)
        Me.grpServiceReport.Controls.Add(Me.radSortNumber)
        Me.grpServiceReport.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpServiceReport.ForeColor = System.Drawing.Color.White
        Me.grpServiceReport.Location = New System.Drawing.Point(3, 104)
        Me.grpServiceReport.Name = "grpServiceReport"
        Me.grpServiceReport.Size = New System.Drawing.Size(484, 807)
        Me.grpServiceReport.TabIndex = 99
        Me.grpServiceReport.TabStop = False
        '
        'radSortProfit
        '
        Me.radSortProfit.AutoSize = True
        Me.radSortProfit.Location = New System.Drawing.Point(10, 56)
        Me.radSortProfit.Name = "radSortProfit"
        Me.radSortProfit.Size = New System.Drawing.Size(217, 26)
        Me.radSortProfit.TabIndex = 1
        Me.radSortProfit.TabStop = True
        Me.radSortProfit.Text = "Sort by Cash Grabbed"
        Me.radSortProfit.UseVisualStyleBackColor = True
        '
        'radSortNumber
        '
        Me.radSortNumber.AutoSize = True
        Me.radSortNumber.Location = New System.Drawing.Point(10, 24)
        Me.radSortNumber.Name = "radSortNumber"
        Me.radSortNumber.Size = New System.Drawing.Size(179, 26)
        Me.radSortNumber.TabIndex = 0
        Me.radSortNumber.TabStop = True
        Me.radSortNumber.Text = "Sort by Popularity"
        Me.radSortNumber.UseVisualStyleBackColor = True
        '
        'grpAppForDateRange
        '
        Me.grpAppForDateRange.Controls.Add(Me.dtpEndDate)
        Me.grpAppForDateRange.Controls.Add(Me.dtpStartDate)
        Me.grpAppForDateRange.Controls.Add(Me.Label6)
        Me.grpAppForDateRange.Controls.Add(Me.Label4)
        Me.grpAppForDateRange.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAppForDateRange.ForeColor = System.Drawing.Color.White
        Me.grpAppForDateRange.Location = New System.Drawing.Point(3, 104)
        Me.grpAppForDateRange.Name = "grpAppForDateRange"
        Me.grpAppForDateRange.Size = New System.Drawing.Size(484, 807)
        Me.grpAppForDateRange.TabIndex = 99
        Me.grpAppForDateRange.TabStop = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!)
        Me.dtpEndDate.Location = New System.Drawing.Point(10, 134)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(275, 33)
        Me.dtpEndDate.TabIndex = 93
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!)
        Me.dtpStartDate.Location = New System.Drawing.Point(10, 53)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(275, 33)
        Me.dtpStartDate.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 24)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Pick an End Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("HelveticaNeueLT Pro 55 Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 24)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Pick a Start Date"
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
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.Location = New System.Drawing.Point(1536, 66)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(45, 45)
        Me.btnSettings.TabIndex = 100
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.Location = New System.Drawing.Point(1536, 10)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(45, 45)
        Me.btnHelp.TabIndex = 99
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(1536, 883)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(45, 45)
        Me.btnExit.TabIndex = 101
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1592, 941)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.ltvReport)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
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
        Me.grpCustServHistory.ResumeLayout(False)
        Me.grpCustServHistory.PerformLayout()
        Me.grpServiceReport.ResumeLayout(False)
        Me.grpServiceReport.PerformLayout()
        Me.grpAppForDateRange.ResumeLayout(False)
        Me.grpAppForDateRange.PerformLayout()
        Me.grpAppForDate.ResumeLayout(False)
        Me.grpAppForDate.PerformLayout()
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
    Friend WithEvents ltvCustName As ListView
    Friend WithEvents ltvReport As ListView
    Friend WithEvents col1 As ColumnHeader
    Friend WithEvents grpAppForDate As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents calDatePicker As MonthCalendar
    Friend WithEvents lblDatePicked As Label
    Friend WithEvents chkGrid As CheckBox
    Friend WithEvents grpServiceReport As GroupBox
    Friend WithEvents radSortProfit As RadioButton
    Friend WithEvents radSortNumber As RadioButton
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents ColName As ColumnHeader
    Friend WithEvents grpAppForDateRange As GroupBox
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnExit As Button
End Class
