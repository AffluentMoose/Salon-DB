Option Explicit On
Imports System.IO

Public Class frmAppointmentEdit

    Dim CustomerRecordsCount As Integer = 0
    Dim ServiceRecordsCount As Integer = 0
    Dim AppRecordsCount As Integer = 0
    Dim AppSerRecordsCount As Integer = 0

    Dim Customers As New List(Of Customer)
    Dim Services As New List(Of Service)
    Dim Appointments As New List(Of Appointment)
    Dim AppServices As New List(Of AppService)

    Private Sub frmAppointmentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))
        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))
        FileOpen(4, AppServFilePath, OpenMode.Random, , , Len(AppSerRecord))

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

        MaxAppServiceRecordNumber = 1

        If LOF(4) / Len(AppSerRecord) <> 0 Then
            MaxAppServiceRecordNumber = LOF(4) / Len(AppSerRecord) + 1
        End If

        CustomerRecordsCount = Customers.Count - 1
        ServiceRecordsCount = Services.Count - 1
        AppRecordsCount = Appointments.Count - 1
        AppSerRecordsCount = AppServices.Count - 1

        For Each Customer In Customers
            Dim Item As New ListViewItem(Trim(Customer.Forename) & " " & Trim(Customer.Surname), 0)
            Item.SubItems.Add(Customer.ID)
            ltvCustName.Items.Add(Item)
        Next
        ltvCustName.Items(0).Selected = True

        For Each Service In Services
            cboService1.Items.Add(Trim(Service.Name))
            cboService2.Items.Add(Trim(Service.Name))
            cboService3.Items.Add(Trim(Service.Name))
            cboService4.Items.Add(Trim(Service.Name))
        Next

        If Editing = False Then
            dtpDate.MinDate = Date.Today
            cboService1.SelectedIndex = 0
        End If

        If Editing = True Then
            cboService1.SelectedIndex = -1
            lblCurrentRecord.Text = CurrentAppRNum
            ReadRecord()
        Else
            lblCurrentRecord.Text = AppRecordsCount + 2
            lblRecordID.Text = AppMaxID + 1
        End If

    End Sub

    Private Sub ReadRecord()

        FileGet(3, AppointmentRecord, CInt(lblCurrentRecord.Text))

        For Each AppService In AppServices

            If AppService.AppID = AppointmentRecord.ID Then

                Dim Index As Integer = 0

                For Each Service In Services

                    If Trim(Service.Name) = Trim(AppService.ServiceName) Then

                        Select Case AppService.RecordNumber
                            Case 1
                                cboService1.SelectedIndex = Index
                            Case 2
                                cboService2.SelectedIndex = Index
                            Case 3
                                cboService3.SelectedIndex = Index
                            Case 4
                                cboService4.SelectedIndex = Index
                        End Select

                        Exit For

                    End If

                    Index += 1

                Next

            End If

        Next

        With AppointmentRecord

            lblRecordID.Text = .ID
            dtpDate.Text = .AppDate
            dtpTime.Text = .AppTime
            Dim Index As Integer = 0
            For Each Customer In Customers
                If (Trim(Customer.Forename) & " " & Trim(Customer.Surname)) = Trim(.CustomerName) Then
                    ltvCustName.Items(Index).Selected = True
                    Exit For
                End If
                Index += 1
            Next

        End With

        CleanUpBoxes()

    End Sub

    Private Sub SaveService(ByVal ServiceName As String, ByVal RecordNumber As Integer, ByVal AppointmentID As Integer)

        Dim DeleteService As Boolean = False
        Dim RecordSaved As Boolean = False

        If ServiceName = "" Then
            ServiceName = "x"
            DeleteService = True
        End If

        If Services.Count <> 0 Then

            Dim Index As Integer = 1

            For Each AppService In AppServices

                FileGet(4, AppSerRecord, Index)

                If AppService.AppID = AppointmentID Then

                    If Trim(AppService.ServiceName) = ServiceName Then

                        If AppService.RecordNumber <> RecordNumber Then
                            AppSerRecord.RecordNumber = RecordNumber
                            FilePut(4, AppSerRecord, Index)
                            RecordSaved = True
                            Exit For
                        Else
                            RecordSaved = True
                            Exit For
                        End If

                    ElseIf AppService.RecordNumber = RecordNumber

                        If DeleteService = False Then
                            AppSerRecord.ServiceName = ServiceName
                            FilePut(4, AppSerRecord, Index)
                            RecordSaved = True
                            Exit For
                        Else
                            '      DELETE THE FOUND RECORD
                            '------------------------------------
                            AppSerRecord.ServiceName = "x"
                            FilePut(4, AppSerRecord, Index)
                            '------------------------------------
                            RecordSaved = True
                            Exit For
                        End If

                    End If

                End If

                Index += 1

            Next

            If RecordSaved = False Then
                With AppSerRecord
                    .AppID = AppointmentID
                    .ServiceName = ServiceName
                    .RecordNumber = RecordNumber
                End With

                FilePut(4, AppSerRecord, MaxAppServiceRecordNumber)
                MaxAppServiceRecordNumber += 1
            End If

        Else

            With AppSerRecord
                .AppID = AppointmentID
                .ServiceName = ServiceName
                .RecordNumber = RecordNumber
            End With

            FilePut(4, AppSerRecord, MaxAppServiceRecordNumber)
            MaxAppServiceRecordNumber += 1

        End If

    End Sub

    Private Sub SaveRecord()

        CleanUpBoxes()

        SaveService(Trim(cboService1.Text), 1, CInt(lblRecordID.Text))

        SaveService(Trim(cboService2.Text), 2, CInt(lblRecordID.Text))

        SaveService(Trim(cboService3.Text), 3, CInt(lblRecordID.Text))

        SaveService(Trim(cboService4.Text), 4, CInt(lblRecordID.Text))

        With AppointmentRecord 'write into record
            .CustomerID = ltvCustName.SelectedItems(0).SubItems(1).Text
            .ID = lblRecordID.Text
            .AppDate = dtpDate.Text
            .AppTime = dtpTime.Text
            .CustomerName = ltvCustName.SelectedItems(0).Text
        End With

        If Editing = False Then

            AppMaxID += 1
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(AppMaxID)
            End Using

        End If

        FilePut(3, AppointmentRecord, CInt(lblCurrentRecord.Text)) 'Save the record

        AppServices.Clear()
        For i = 1 To LOF(4) / Len(AppSerRecord)
            FileGet(4, AppSerRecord, i)
            AppServices.Add(AppSerRecord)
        Next
        AppSerRecordsCount = AppServices.Count - 1

        Appointments.Clear()
        For i = 1 To LOF(3) / Len(AppointmentRecord)
            FileGet(3, AppointmentRecord, i)
            Appointments.Add(AppointmentRecord)
        Next
        AppRecordsCount = Appointments.Count - 1

        CurrentAppRNum = lblCurrentRecord.Text
        CloseEditForm()

    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click

        If Editing = True Then

            Dim UnsavedChanges As Boolean = False

            With AppointmentRecord
                If .AppDate <> dtpDate.Text Then UnsavedChanges = True
                If Trim(.AppTime) <> Trim(dtpTime.Text) Then UnsavedChanges = True
            End With

            If UnsavedChanges = True Then 'if user hasn't saved their changes show alert
                AlertType = "notSaved"
                CallingForm = Me
                frmUnsavedAlert.Show()
                Me.Enabled = False
            Else
                CloseEditForm()
            End If

        Else

            'if user hasn't saved their changes show alert
            'AlertType = "notSaved"
            'CallingForm = Me
            'frmUnsavedAlert.Show()
            'Me.Enabled = False
            CloseEditForm()

        End If

    End Sub

    Private Sub RefreshltvCustName(ByVal SearchString As String)

        ltvCustName.Items.Clear()

        For i = 1 To LOF(1) / Len(CustomerRecord)
            FileGet(1, CustomerRecord, i)
            If (Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)).ToLower.Contains(SearchString) Then
                Dim Item As New ListViewItem(Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname), 0)
                Item.SubItems.Add(CustomerRecord.ID)
                ltvCustName.Items.Add(Item)
            End If
        Next

        If ltvCustName.Items.Count <> 0 Then
            ltvCustName.Items(0).Selected = True
        End If

    End Sub
    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        If ltvCustName.Items.Count <> 0 Then
            SaveRecord()
        End If
    End Sub

    Private Sub CloseEditForm()
        FileClose(1)
        FileClose(2)
        FileClose(4)
        frmAppointment.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmAppointmentEdit_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyCode

            Case Keys.Escape
                btnCancel.PerformClick()
                e.Handled = True

            Case Keys.Enter
                btnSave.PerformClick()
                e.Handled = False

        End Select

    End Sub

    Private Sub frmAppointmentEdit_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If Me.Enabled = True Then

            If ReturnAction = "save" Then
                ReturnAction = ""
                SaveRecord()
            ElseIf ReturnAction = "nosave"
                ReturnAction = ""
                CloseEditForm()
            End If

        End If

    End Sub

    Private Sub btnClearServ2_Click(sender As Object, e As EventArgs) Handles btnClearServ2.Click
        cboService2.SelectedIndex = -1
        CleanUpBoxes()
    End Sub

    Private Sub btnClearServ3_Click(sender As Object, e As EventArgs) Handles btnClearServ3.Click
        cboService3.SelectedIndex = -1
        CleanUpBoxes()
    End Sub

    Private Sub btnClearServ4_Click(sender As Object, e As EventArgs) Handles btnClearServ4.Click
        cboService4.SelectedIndex = -1
        CleanUpBoxes()
    End Sub

    Private Sub CleanUpBoxes()

        If cboService2.SelectedIndex = cboService1.SelectedIndex Or cboService2.SelectedIndex = cboService3.SelectedIndex Or cboService2.SelectedIndex = cboService4.SelectedIndex Then
            cboService2.SelectedIndex = -1
        End If

        If cboService3.SelectedIndex = cboService1.SelectedIndex Or cboService3.SelectedIndex = cboService2.SelectedIndex Or cboService3.SelectedIndex = cboService4.SelectedIndex Then
            cboService3.SelectedIndex = -1
        End If

        If cboService4.SelectedIndex = cboService1.SelectedIndex Or cboService4.SelectedIndex = cboService2.SelectedIndex Or cboService4.SelectedIndex = cboService3.SelectedIndex Then
            cboService4.SelectedIndex = -1
        End If

        For i = 1 To 3
            If cboService4.SelectedIndex <> -1 Then
                If cboService3.SelectedIndex = -1 Then
                    cboService3.SelectedIndex = cboService4.SelectedIndex
                    cboService4.SelectedIndex = -1
                End If
            End If

            If cboService3.SelectedIndex <> -1 Then
                If cboService2.SelectedIndex = -1 Then
                    cboService2.SelectedIndex = cboService3.SelectedIndex
                    cboService3.SelectedIndex = -1
                End If
            End If

            If cboService2.SelectedIndex <> -1 Then
                If cboService1.SelectedIndex = -1 Then
                    cboService1.SelectedIndex = cboService2.SelectedIndex
                    cboService2.SelectedIndex = -1
                End If
            End If
        Next

    End Sub

    Private Sub txtCustName_TextChanged(sender As Object, e As EventArgs) Handles txtCustName.TextChanged
        RefreshltvCustName(txtCustName.Text.ToLower)
    End Sub

End Class