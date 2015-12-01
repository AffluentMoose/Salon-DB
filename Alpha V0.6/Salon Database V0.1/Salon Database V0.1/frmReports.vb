Public Class frmReports

    'variables to save space and help readability later on
    Dim CustomerRecordsNum As Integer = 0
    Dim ServiceRecordsNum As Integer = 0
    Dim AppRecordsNum As Integer = 0
    Dim AppSerRecordsNum As Integer = 0

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '--------- PREPARE STUFF ------------------------------------------------------
        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))
        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))
        FileOpen(3, AppointmentFilePath, OpenMode.Random, , , Len(AppointmentRecord))
        FileOpen(4, AppServFilePath, OpenMode.Random, , , Len(AppSerRecord))

        cboReportType.SelectedIndex = 1
        cboCustomerName.Focus()

        CustomerRecordsNum = LOF(1) / Len(CustomerRecord)
        Dim Customers(CustomerRecordsNum) As Customer
        ServiceRecordsNum = LOF(2) / Len(ServiceRecord)
        AppRecordsNum = LOF(3) / Len(AppointmentRecord)
        AppSerRecordsNum = LOF(4) / Len(AppSerRecord)

        For i = 1 To CustomerRecordsNum

            FileGet(1, CustomerRecord, i)

            With Customers(i)
                .ID = CustomerRecord.ID
                .Forename = CustomerRecord.Forename
                .Surname = CustomerRecord.Surname
                .Telephone = CustomerRecord.Telephone
                .Email = CustomerRecord.Email
            End With

        Next
        '------------------------------------------------------------------------------

        '--------- APPOINTMENT FOR DATE -----------------------------------------------
        dtpAppDate.Value = Today
        '------------------------------------------------------------------------------

        '--------- CUSTOMER SERVICE HISTORY -------------------------------------------
        'For i = 1 To CustomerRecordsNum
        'FileGet(1, CustomerRecord, i)
        'Dim Item As New ListViewItem(Trim(Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)), 0)
        'Item.SubItems.Add(CustomerRecord.ID)
        'ltvCustName.Items.Add(Item)
        ' Next
        For i = 1 To Customers.Length - 1
            Dim Item As New ListViewItem(Trim(Customers(i).Forename) & " " & Trim(Customers(i).Surname), 0)
            Item.SubItems.Add(Customers(i).ID)
            ltvCustName.Items.Add(Item)
        Next
        '------------------------------------------------------------------------------


    End Sub

    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerName.TextChanged
        RefreshltvCustName(Trim(cboCustomerName.Text))
    End Sub

    Private Sub RefreshltvCustName(ByVal SearchString As String)

        ltvCustName.Items.Clear()
        For i = 1 To CustomerRecordsNum
            FileGet(1, CustomerRecord, i)
            If (Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)).Contains(SearchString) Then
                Dim Item As New ListViewItem(Trim(Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)), 0)
                Item.SubItems.Add(CustomerRecord.ID)
                ltvCustName.Items.Add(Item)
            End If
        Next

    End Sub

    Private Sub btnDisplayReport_Click(sender As Object, e As EventArgs) Handles btnDisplayReport.Click

        Select Case cboReportType.SelectedIndex
            Case 0
            Case 1
                Dim CustomerID As Integer = ltvCustName.SelectedItems(0).SubItems(1).Text
                ReportCustomerServiceHistory(CustomerID)
            Case 2
            Case 3
            Case 4
            Case 5
        End Select

    End Sub

    Private Sub ReportCustomerServiceHistory(ByVal ID As Integer)

    End Sub

End Class