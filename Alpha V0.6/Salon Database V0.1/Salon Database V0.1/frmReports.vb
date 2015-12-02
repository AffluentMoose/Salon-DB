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

        '--------- APPOINTMENT FOR DATE -----------------------------------------------
        dtpAppDate.Value = Today
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

        btnDisplayReport.Visible = True
        grpCustServHistory.Visible = False
        grpAppForDate.Visible = False
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
                ServicesByPopularityReport()
                ltvReport.Focus()
            Case 4
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
                If Trim(cboCustomerName.Text) <> "" Then cboCustomerName.Items.Add(Trim(cboCustomerName.Text))
                cboCustomerName.Focus()
            Case 2
                Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                Dim CustomerName As String = ltvCustName.SelectedItems(0).Text
                ReportCustomerAppHistory(CustomerID, CustomerName)
                If Trim(cboCustomerName.Text) <> "" Then cboCustomerName.Items.Add(Trim(cboCustomerName.Text))
                cboCustomerName.Focus()
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

        Dim AppointmentID As Integer

        For Each Appointment In Appointments

            If Appointment.CustomerID = CustomerID Then

                AppointmentID = Appointment.ID

                ltvReport.Items.Add("")
                ltvReport.Items.Add(Trim(Appointment.AppDate.ToLongDateString))

                For Each AppService In AppServices

                    If AppService.AppID = AppointmentID Then
                        If Trim(AppService.ServiceName) <> "x" Then
                            ltvReport.Items.Add(Space(1) & Trim(AppService.ServiceName) & "")
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

            End If

        Next

    End Sub

    Private Sub ServicesByPopularityReport()

        ltvReport.Items.Clear()
        ltvReport.Columns.Clear()

        ltvReport.Columns.Add("Service", 300, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Times Booked", 180, HorizontalAlignment.Left)
        ltvReport.Columns.Add("Total cash grabbed", 180, HorizontalAlignment.Left)

        For Each Service In Services

            Dim CashGrabbed As Decimal = 0
            Dim TimesBooked As Integer = 0
            Dim Item As New ListViewItem(Trim(Service.Name), 0)

            For Each AppService In AppServices

                If Trim(AppService.ServiceName) = Trim(Service.Name) Then
                    CashGrabbed += Service.Price
                    TimesBooked += 1
                End If

            Next

            Item.SubItems.Add(TimesBooked)
            Item.SubItems.Add("£" & CashGrabbed)
            ltvReport.Items.Add(Item)
        Next

    End Sub
    '----------------------------------------------------------------------------------------------

    '################################################################### REPORTS END ################################################################

    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerName.TextChanged
        RefreshltvCustName(Trim(cboCustomerName.Text))
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
            If (Trim(Customer.Forename) & " " & Trim(Customer.Surname)).Contains(SearchString) Then
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

End Class