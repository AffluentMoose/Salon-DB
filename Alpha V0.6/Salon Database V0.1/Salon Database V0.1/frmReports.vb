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
        cboCustomerName.Focus()

        CustomerRecordsCount = LOF(1) / Len(CustomerRecord)
        ServiceRecordsCount = LOF(2) / Len(ServiceRecord)
        AppRecordsCount = LOF(3) / Len(AppointmentRecord)
        AppSerRecordsCount = LOF(4) / Len(AppSerRecord)

        For i = 1 To CustomerRecordsCount
            FileGet(1, CustomerRecord, i)
            Customers.Add(CustomerRecord)
        Next

        For i = 1 To ServiceRecordsCount
            FileGet(2, ServiceRecord, i)
            Services.Add(ServiceRecord)
        Next

        For i = 1 To AppRecordsCount
            FileGet(3, AppointmentRecord, i)
            Appointments.Add(AppointmentRecord)
        Next

        For i = 1 To AppSerRecordsCount
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

    '--------- SELECTING REPORT TYPE - LAYOUT CHANGES ---------------------------------------------
    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged

        btnDisplayReport.Visible = True
        grpCustServHistory.Visible = False
        grpAppForDate.Visible = False

        Select Case cboReportType.SelectedIndex
            Case 0
                grpAppForDate.Visible = True
                btnDisplayReport.Visible = False
                lbl1.Visible = False
                lblDatePicked.Text = calDatePicker.SelectionRange.Start
                ReportAppointmentsForDate(calDatePicker.SelectionRange.Start)
            Case 1
                grpCustServHistory.Visible = True
            Case 2
                grpCustServHistory.Visible = True
            Case 3
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

    '--------- APPOINTMENTS FOR A DATE REPORT -----------------------------------------------------
    Private Sub ReportAppointmentsForDate(ByVal AppDate As String)

        ltvReport.Items.Clear()
        ltvReport.Items.Add("APPOINTMENTS  :  " & AppDate)

        For Each Appointment In Appointments

            If Appointment.AppDate = AppDate Then
                ltvReport.Items.Add("")
                ltvReport.Items.Add(Trim(Appointment.CustomerName))
                ltvReport.Items.Add(" - " & Trim(Appointment.AppTime.ToShortTimeString))
            End If

        Next

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
                            ltvReport.Items.Add(" - " & Trim(AppService.ServiceName) & "")
                        End If
                    End If

                Next

            End If

        Next

    End Sub
    '----------------------------------------------------------------------------------------------

    '--------- CUSTOMER APPOINTMENT HISTORY REPORT ----------------------------------------------------
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
    '----------------------------------------------------------------------------------------------

    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerName.TextChanged
        RefreshltvCustName(Trim(cboCustomerName.Text))
    End Sub

    Private Sub RefreshltvCustName(ByVal SearchString As String) 'called when search box text is changed

        ltvCustName.Items.Clear()

        For Each Customer In Customers
            If (Trim(Customer.Forename) & " " & Trim(Customer.Surname)).Contains(SearchString) Then
                Dim Item As New ListViewItem(Trim(Customer.Forename) & " " & Trim(Customer.Surname), 0)
                Item.SubItems.Add(Customer.ID)
                ltvCustName.Items.Add(Item)
            End If
        Next
        ltvCustName.Items(0).Selected = True

    End Sub

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

End Class