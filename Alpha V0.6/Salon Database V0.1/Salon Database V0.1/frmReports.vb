﻿Imports System.IO

Public Class frmReports

    Dim CustomerRecordsCount As Integer = 0
    Dim ServiceRecordsCount As Integer = 0
    Dim AppRecordsCount As Integer = 0
    Dim AppSerRecordsCount As Integer = 0

    Dim Customers As New List(Of Customer)
    Dim Services As New List(Of Service)
    Dim Appointments As New List(Of Appointment)
    Dim AppServices As New List(Of AppService)

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RefreshScheme()

        '--------- PREPARE STUFF ------------------------------------------------------
        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))
        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))
        FileOpen(3, AppointmentFilePath, OpenMode.Random, , , Len(AppointmentRecord))
        FileOpen(4, AppServFilePath, OpenMode.Random, , , Len(AppSerRecord))

        cboReportType.SelectedIndex = 1

        For i = 1 To LOF(1) / Len(CustomerRecord)
            FileGet(1, CustomerRecord, i)
            Customers.Add(CustomerRecord)
        Next

        For i = 1 To LOF(2) / Len(ServiceRecord)
            FileGet(2, ServiceRecord, i)
            Services.Add(ServiceRecord)
        Next

        For i = 1 To LOF(3) / Len(AppointmentRecord)
            FileGet(3, AppointmentRecord, i)
            Appointments.Add(AppointmentRecord)
        Next

        For i = 1 To LOF(4) / Len(AppSerRecord)
            FileGet(4, AppSerRecord, i)
            AppServices.Add(AppSerRecord)
        Next

        CustomerRecordsCount = Customers.Count - 1
        ServiceRecordsCount = Services.Count - 1
        AppRecordsCount = Appointments.Count - 1
        AppSerRecordsCount = AppServices.Count - 1
        '------------------------------------------------------------------------------

        '--------- CUSTOMER SERVICE HISTORY -------------------------------------------
        For Each Customer In Customers
            Dim Item As New ListViewItem(Trim(Customer.Forename) & " " & Trim(Customer.Surname), 0)
            Item.SubItems.Add(Customer.ID)
            ltvCustName.Items.Add(Item)
        Next

        ltvCustName.Items(0).Selected = True
        '------------------------------------------------------------------------------

    End Sub

    '--------- SELECTING REPORT TYPE --------------------------------------------------------------
    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged

        ltvReport.Sorting = SortOrder.None
        btnDisplayReport.Visible = True
        grpCustServHistory.Visible = False
        grpAppForDate.Visible = False
        grpServiceReport.Visible = False
        grpAppForDateRange.Visible = False
        btnDisplayReport.Visible = False
        lbl1.Visible = False
        ltvReport.Columns.Clear()
        ltvReport.Items.Clear()

        Select Case cboReportType.SelectedIndex
            Case 0
                grpAppForDate.Visible = True
                lblDatePicked.Text = calDatePicker.SelectionRange.Start
                ReportAppointmentsForDate(calDatePicker.SelectionRange.Start)
            Case 1
                grpCustServHistory.Visible = True
                ltvReport.Columns.Add("", 800, HorizontalAlignment.Left)
                '---- show report straight away ---------------------------------------------------
                If ltvCustName.Items.Count <> 0 Then
                    Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                    Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                    ReportCustomerServiceHistory(CustomerID, CustomerName)
                End If
                ltvCustName.Focus()
            Case 2
                grpCustServHistory.Visible = True
                ltvReport.Columns.Add("", 800, HorizontalAlignment.Left)
                '---- show report straight away ---------------------------------------------------
                If ltvCustName.Items.Count <> 0 Then
                    Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                    Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                    ReportCustomerAppHistory(CustomerID, CustomerName)
                End If
                ltvCustName.Focus()
            Case 3
                grpServiceReport.Visible = True
                ServicesByPopularityReport()
                ltvReport.Focus()
            Case 4
                grpAppForDateRange.Visible = True
                dtpStartDate.Value = Today
                dtpEndDate.Value = Today.AddDays(1)
                ReportAppointmentsForDateRange(dtpStartDate.Value, dtpEndDate.Value)
                ltvReport.Focus()
            Case 5
        End Select

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- DISPLAY REPORT ---------------------------------------------------------------------
    Private Sub btnDisplayReport_Click(sender As Object, e As EventArgs) Handles btnDisplayReport.Click

        Select Case cboReportType.SelectedIndex
            Case 1
                Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                ReportCustomerServiceHistory(CustomerID, CustomerName)
                txtCustomerName.Focus()
            Case 2
                Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                ReportCustomerAppHistory(CustomerID, CustomerName)
                txtCustomerName.Focus()
            Case 3
            Case 4
            Case 5
        End Select

    End Sub
    '----------------------------------------------------------------------------------------------

    '################################################################### ALL REPORTS ################################################################

    '--------- APPOINTMENTS FOR A DATE REPORT -----------------------------------------------------
    Private Sub ReportAppointmentsForDate(ByVal AppDate As Date)

        ltvReport.Items.Clear()
        ltvReport.Columns.Clear()

        ltvReport.Columns.Add("Time", 100, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Customer", 200, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Services", 320, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Total Price", 180, HorizontalAlignment.Left)

        For Each Appointment In Appointments

            If Appointment.AppDate = AppDate Then

                Dim Item As New ListViewItem(Appointment.AppTime.ToShortTimeString, 0)
                Item.SubItems.Add(Trim(Appointment.CustomerName))

                Dim ServiceString As String = ""
                Dim TotalPrice As Decimal = 0

                For Each AppService In AppServices

                    If AppService.AppID = Appointment.ID And Trim(AppService.ServiceName) <> "x" Then

                        If ServiceString = "" Then
                            ServiceString += Trim(AppService.ServiceName)
                        Else
                            ServiceString += ", " & Trim(AppService.ServiceName)
                        End If

                        For Each Service In Services
                            If Trim(Service.Name) = Trim(AppService.ServiceName) Then
                                TotalPrice += Service.Price
                            End If
                        Next

                    End If

                Next

                Item.SubItems.Add(ServiceString)
                Item.SubItems.Add("£" & TotalPrice)
                ltvReport.Items.Add(Item)

            End If

        Next

        ltvReport.Sorting = SortOrder.Ascending

        If ltvReport.Items.Count = 0 Then
            ltvReport.Columns.Clear()
            ltvReport.Columns.Add("", 500, HorizontalAlignment.Left)
            ltvReport.Items.Add("No Appointments booked for " & AppDate.ToLongDateString)
        End If

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- CUSTOMER SERVICE HISTORY REPORT ----------------------------------------------------
    Private Sub ReportCustomerServiceHistory(ByVal CustomerID As Integer, ByVal CustName As String)

        ltvReport.Items.Clear()
        ltvReport.Items.Add("SERVICE HSTORY  :  " & Trim(CustName).ToUpper)
        Dim ServicePrice As Integer

        Dim AppointmentID As Integer

        For Each Appointment In Appointments

            If Appointment.CustomerID = CustomerID Then

                AppointmentID = Appointment.ID

                ltvReport.Items.Add("")
                ltvReport.Items.Add(Trim(Appointment.AppDate.ToLongDateString))

                For Each AppService In AppServices

                    If AppService.AppID = AppointmentID Then
                        If Trim(AppService.ServiceName) <> "x" Then

                            For Each Service In Services
                                If Service.Name = AppService.ServiceName Then
                                    ServicePrice = Service.Price
                                    Exit For
                                End If
                            Next
                            ltvReport.Items.Add(Space(1) & Trim(AppService.ServiceName) & "  -  £" & ServicePrice.ToString("00.00"))
                        End If
                    End If

                Next

            End If

        Next

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- CUSTOMER APPOINTMENT HISTORY REPORT ------------------------------------------------
    Private Sub ReportCustomerAppHistory(ByVal CustomerID As Integer, ByVal CustName As String)

        ltvReport.Items.Clear()
        ltvReport.Items.Add("APPOINTMENT HSTORY  :  " & Trim(CustName).ToUpper)

        Dim AppointmentID As Integer

        For Each Appointment In Appointments

            If Appointment.CustomerID = CustomerID Then

                AppointmentID = Appointment.ID

                ltvReport.Items.Add("")
                ltvReport.Items.Add(Trim(Appointment.AppDate.ToLongDateString))
                ltvReport.Items.Add(Trim(" - " & Appointment.Comment))

            End If

        Next

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- SERVICE TREND REPORT ---------------------------------------------------------------
    Private Sub ServicesByPopularityReport()

        ltvReport.Items.Clear()
        ltvReport.Columns.Clear()

        ltvReport.Columns.Add("Ranking", 90, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Service", 200, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Times Booked", 150, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Total cash grabbed", 180, HorizontalAlignment.Left)
        Dim Rank As Integer = 1
        For Each Service In Services

            Dim CashGrabbed As Decimal = 0
            Dim TimesBooked As Integer = 0
            Dim Item As New ListViewItem(Rank.ToString("D3"), 0)

            For Each AppService In AppServices

                If Trim(AppService.ServiceName) = Trim(Service.Name) Then
                    CashGrabbed += Service.Price
                    TimesBooked += 1
                End If

            Next

            Item.SubItems.Add(Trim(Service.Name))
            Item.SubItems.Add(TimesBooked)
            Item.SubItems.Add("£" & CashGrabbed)
            ltvReport.Items.Add(Item)

            Rank += 1
        Next

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- APPOINTMENTS FOR RANGE OF DATES REPORT ---------------------------------------------
    Private Sub ReportAppointmentsForDateRange(ByVal StartDate As Date, ByVal EndDate As Date)

        If EndDate >= StartDate Then

            ltvReport.Items.Clear()
            ltvReport.Columns.Clear()

            ltvReport.Columns.Add("Date", 130, HorizontalAlignment.Left)
            ltvReport.Columns.Add("Time", 100, HorizontalAlignment.Left)
            ltvReport.Columns.Add("Customer", 200, HorizontalAlignment.Left)
            ltvReport.Columns.Add("Services", 250, HorizontalAlignment.Left)
            ltvReport.Columns.Add("Total Price", 140, HorizontalAlignment.Left)

            For Each Appointment In Appointments

                If (Appointment.AppDate >= StartDate) And (Appointment.AppDate <= EndDate) Then

                    Dim Item As New ListViewItem(Appointment.AppDate.ToShortDateString, 0)
                    Item.SubItems.Add(Trim(Appointment.AppTime))
                    Item.SubItems.Add(Trim(Appointment.CustomerName))

                    Dim ServiceString As String = ""
                    Dim TotalPrice As Decimal = 0

                    For Each AppService In AppServices

                        If AppService.AppID = Appointment.ID And Trim(AppService.ServiceName) <> "x" Then

                            If ServiceString = "" Then
                                ServiceString += Trim(AppService.ServiceName)
                            Else
                                ServiceString += ", " & Trim(AppService.ServiceName)
                            End If

                            For Each Service In Services
                                If Trim(Service.Name) = Trim(AppService.ServiceName) Then
                                    TotalPrice += Service.Price
                                End If
                            Next

                        End If

                    Next

                    Item.SubItems.Add(ServiceString)
                    Item.SubItems.Add("£" & TotalPrice)
                    ltvReport.Items.Add(Item)

                End If

            Next

            ltvReport.Sorting = SortOrder.Ascending
            If ltvReport.Items.Count = 0 Then
                ltvReport.Columns.Clear()
                ltvReport.Columns.Add("", 750, HorizontalAlignment.Left)
                ltvReport.Items.Add("No Appointments booked for " & StartDate.ToLongDateString & " to " & EndDate.ToLongDateString)
            End If

        End If

    End Sub
    '----------------------------------------------------------------------------------------------

    '################################################################### REPORTS END ################################################################

    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerName.TextChanged
        RefreshltvCustName(Trim(txtCustomerName.Text))
    End Sub

    '--------- DISPLAY REPORTS ON CUSTOMER LIST VIEW CLICK ----------------------------------------
    Private Sub ltvCustName_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ltvCustName.ItemSelectionChanged

        If e.IsSelected = True Then
            Select Case cboReportType.SelectedIndex
                Case 1
                    Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                    Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                    ReportCustomerServiceHistory(CustomerID, CustomerName)
                Case 2
                    Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                    Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                    ReportCustomerAppHistory(CustomerID, CustomerName)
                Case 3
                Case 4
                Case 5
            End Select
        End If

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- called when search box text is changed to update customer list view ----------------
    Private Sub RefreshltvCustName(ByVal SearchString As String)

        ltvCustName.Items.Clear()

        For Each Customer In Customers
            If (Trim(Customer.Forename) & " " & Trim(Customer.Surname)).ToLower.Contains(SearchString.ToLower) Then
                Dim Item As New ListViewItem(Trim(Customer.Forename) & " " & Trim(Customer.Surname), 0)
                Item.SubItems.Add(Customer.ID)
                ltvCustName.Items.Add(Item)
            End If
        Next
        If ltvCustName.Items.Count <> 0 Then
            ltvCustName.Items(0).Selected = True
        End If

    End Sub
    '----------------------------------------------------------------------------------------------

    Private Sub CloseFiles()
        FileClose(1)
        FileClose(2)
        FileClose(3)
        FileClose(4)
    End Sub

    Private Sub btnCustomerForm_Click(sender As Object, e As EventArgs) Handles btnCustomerForm.Click
        CloseFiles()
        frmCustomer.Show()
        Me.Close()
    End Sub

    Private Sub btnAppointmentForm_Click(sender As Object, e As EventArgs) Handles btnAppointmentForm.Click
        CloseFiles()
        frmAppointment.Show()
        Me.Close()
    End Sub

    Private Sub btnServiceForm_Click(sender As Object, e As EventArgs) Handles btnServiceForm.Click
        CloseFiles()
        frmService.Show()
        Me.Close()
    End Sub

    Private Sub calDatePicker_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calDatePicker.DateChanged
        lblDatePicked.Text = calDatePicker.SelectionRange.Start
        ReportAppointmentsForDate(calDatePicker.SelectionRange.Start)
    End Sub

    Private Sub chkGrid_CheckedChanged(sender As Object, e As EventArgs) Handles chkGrid.CheckedChanged
        If chkGrid.Checked = True Then
            ltvReport.GridLines = True
        Else
            ltvReport.GridLines = False
        End If
    End Sub

    Private Sub radSortNumber_CheckedChanged(sender As Object, e As EventArgs) Handles radSortNumber.CheckedChanged
        If radSortNumber.Checked = True Then
            'SORT SERVICES BY POP

        End If
    End Sub

    Private Sub radSortProfit_CheckedChanged(sender As Object, e As EventArgs) Handles radSortProfit.CheckedChanged
        If radSortProfit.Checked = True Then
            'SORT SERVICES BY CASH
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        If dtpStartDate.Value <= dtpEndDate.Value Then
            ReportAppointmentsForDateRange(dtpStartDate.Value, dtpEndDate.Value)
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If dtpStartDate.Value <= dtpEndDate.Value Then
            ReportAppointmentsForDateRange(dtpStartDate.Value, dtpEndDate.Value)
        End If
    End Sub

    Private Sub RefreshScheme()

        Select Case Scheme
            Case "d"
                SetScheme(Color.FromArgb(255, 33, 33, 33), Color.FromArgb(255, 48, 48, 48), Color.FromArgb(255, 66, 66, 66), Color.Black)
            Case "p"
                SetScheme(Color.FromArgb(255, 61, 37, 124), Color.FromArgb(255, 40, 18, 98), Color.FromArgb(255, 40, 18, 98), Color.FromArgb(255, 83, 59, 145))
            Case Else
                SetSchemeWhite(Color.FromArgb(255, 245, 245, 245), Color.FromArgb(255, 250, 250, 250), Color.FromArgb(255, 250, 250, 250), Color.FromArgb(255, 224, 224, 224))
        End Select

    End Sub

    Private Sub SetScheme(ByVal Color1 As Color, ByVal Color2 As Color, ByVal Color3 As Color, ByVal Color4 As Color)
        For Each Ctrl As Control In Me.Controls
            Me.BackColor = Color4
            Ctrl.BackColor = Color1
            Ctrl.ForeColor = Color.White
            If TypeOf Ctrl Is Button Then
                Ctrl.BackColor = Color4
                Ctrl.ForeColor = Color4
            ElseIf TypeOf Ctrl Is Label
                Ctrl.BackColor = Color4
            ElseIf TypeOf Ctrl Is TextBox Or TypeOf Ctrl Is ComboBox
                Ctrl.BackColor = Color2
            ElseIf TypeOf Ctrl Is Panel Or TypeOf Ctrl Is GroupBox
                For Each Ctrol As Control In Ctrl.Controls
                    Ctrol.ForeColor = Color.White
                    If TypeOf Ctrol Is Button Then
                        Ctrol.BackColor = Color1
                        Ctrol.ForeColor = Color1
                    ElseIf TypeOf Ctrol Is Label
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is ComboBox
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is Panel Or TypeOf Ctrol Is GroupBox
                        Ctrol.BackColor = Color3
                        For Each Cntrol As Control In Ctrol.Controls
                            Cntrol.ForeColor = Color.White
                            If TypeOf Cntrol Is Button Or TypeOf Cntrol Is Label Or TypeOf Cntrol Is RadioButton Then
                                Cntrol.BackColor = Color3
                                Cntrol.ForeColor = Color.White
                            ElseIf TypeOf Cntrol Is ListView Or TypeOf Cntrol Is TextBox
                                Cntrol.BackColor = Color1
                            End If
                        Next
                    End If
                Next
            ElseIf TypeOf Ctrl Is ListView
                If Scheme = "p" Then
                    Ctrl.BackColor = Color.FromArgb(255, 40, 18, 98)
                End If

            End If
        Next
    End Sub

    Private Sub SetSchemeWhite(ByVal Color1 As Color, ByVal Color2 As Color, ByVal Color3 As Color, ByVal Color4 As Color)
        For Each Ctrl As Control In Me.Controls
            Me.BackColor = Color4
            Ctrl.BackColor = Color1
            Ctrl.ForeColor = Color.Black
            If TypeOf Ctrl Is Button Then
                Ctrl.BackColor = Color.DarkGray
                Ctrl.ForeColor = Color.Black
            ElseIf TypeOf Ctrl Is Label
                Ctrl.BackColor = Color4
            ElseIf TypeOf Ctrl Is TextBox Or TypeOf Ctrl Is ComboBox
                Ctrl.BackColor = Color2
            ElseIf TypeOf Ctrl Is Panel Or TypeOf Ctrl Is GroupBox
                For Each Ctrol As Control In Ctrl.Controls
                    Ctrol.ForeColor = Color.Black
                    If TypeOf Ctrol Is Button Then
                        Ctrol.BackColor = Color.DarkGray
                        Ctrol.ForeColor = Color.Black
                    ElseIf TypeOf Ctrol Is Label
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is ComboBox
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is Panel Or TypeOf Ctrol Is GroupBox
                        Ctrol.BackColor = Color.FromArgb(255, 190, 190, 190)
                        For Each Cntrol As Control In Ctrol.Controls
                            Cntrol.ForeColor = Color.Black
                            Cntrol.BackColor = Color.FromArgb(255, 215, 215, 215)
                            If TypeOf Cntrol Is Button Or TypeOf Cntrol Is Label Or TypeOf Cntrol Is RadioButton Then
                                Cntrol.BackColor = Color.FromArgb(255, 190, 190, 190)
                                Cntrol.ForeColor = Color.Black
                            ElseIf TypeOf Cntrol Is TextBox
                                Cntrol.BackColor = Color.FromArgb(255, 150, 150, 150)
                            End If
                        Next
                    End If
                Next
            ElseIf TypeOf Ctrl Is ListView
                Ctrl.BackColor = Color.FromArgb(255, 215, 215, 215)
            End If
        Next
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        CallingForm = Me
        frmSettings.Show()
        Me.Enabled = False
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FileOpen(9, SettingsFilePath, OpenMode.Random, , , Len(SettingsRecord))
        FileGet(9, SettingsRecord, 1)
        SettingsRecord.Scheme = Scheme
        FilePut(9, SettingsRecord, 1)
        Application.Exit()
    End Sub

    Private Sub frmReports_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If ReturnAction = "scheme" Then
            RefreshScheme()
        End If
    End Sub

End Class