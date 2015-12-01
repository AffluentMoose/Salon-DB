Option Explicit On
Imports System.IO

Public Class frmAppointmentEdit

    Private Sub frmAppointmentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(4, AppServFilePath, OpenMode.Random, , , Len(AppSerRecord))

        MaxAppServiceRecordNumber = 1

        If LOF(4) / Len(AppSerRecord) <> 0 Then
            MaxAppServiceRecordNumber = LOF(4) / Len(AppSerRecord) + 1
        End If

        cboCustomer.DisplayMember = "Name"
        cboCustomer.ValueMember = "Id"

        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))
        Dim AddString As String
        For i = 1 To LOF(1) / Len(CustomerRecord)
            FileGet(1, CustomerRecord, i)
            AddString = Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)
            cboCustomer.Items.Add(New With {.Name = AddString, .Id = CustomerRecord.ID})
        Next

        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))
        For i = 1 To LOF(2) / Len(ServiceRecord)
            FileGet(2, ServiceRecord, i)
            cboService1.Items.Add(Trim(ServiceRecord.Name))
            cboService2.Items.Add(Trim(ServiceRecord.Name))
            cboService3.Items.Add(Trim(ServiceRecord.Name))
            cboService4.Items.Add(Trim(ServiceRecord.Name))
        Next

        cboCustomer.SelectedIndex = 0

        If Editing = False Then
            dtpDate.MinDate = Date.Today
            cboService1.SelectedIndex = 0
        End If

        If Editing = True Then

            cboService1.SelectedIndex = -1
            lblCurrentRecord.Text = CurrentAppRNum
            ReadRecord()

        Else

            lblCurrentRecord.Text = LOF(3) / Len(AppointmentRecord) + 1
            lblRecordID.Text = AppMaxID + 1

        End If

    End Sub

    Private Sub ReadRecord()

        Dim ServiceName As String

        FileGet(3, AppointmentRecord, CInt(lblCurrentRecord.Text))

        For i = 1 To LOF(4) / Len(AppSerRecord)

            FileGet(4, AppSerRecord, i)

            If AppSerRecord.AppID = AppointmentRecord.ID Then

                ServiceName = AppSerRecord.ServiceName

                For j = 1 To LOF(2) / Len(ServiceRecord)

                    FileGet(2, ServiceRecord, j)

                    If ServiceRecord.Name = ServiceName Then

                        Select Case AppSerRecord.RecordNumber
                            Case 1
                                cboService1.SelectedIndex = j - 1
                            Case 2
                                cboService2.SelectedIndex = j - 1
                            Case 3
                                cboService3.SelectedIndex = j - 1
                            Case 4
                                cboService4.SelectedIndex = j - 1
                        End Select

                        Exit For

                    End If

                Next

            End If

        Next

        With AppointmentRecord

            lblRecordID.Text = .ID
            dtpDate.Text = .AppDate
            dtpTime.Text = .AppTime
            For i = 1 To LOF(1) / Len(CustomerRecord)
                FileGet(1, CustomerRecord, i)
                If (Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)) = Trim(.CustomerName) Then
                    cboCustomer.SelectedIndex = i - 1
                    Exit For
                End If
            Next

        End With

        CleanUpBoxes()

    End Sub

    Private Sub SaveService(ByVal ServiceName As String, ByVal RecordNumber As Integer, ByVal AppointmentID As Integer)

        Dim DeleteService As Boolean = False
        Dim RecordSaved As Boolean = False
        Dim CurrentRNum As Integer = 0

        If ServiceName = "" Then
            ServiceName = "x"
            DeleteService = True
        End If

        If LOF(4) / Len(AppSerRecord) <> 0 Then

            For i = 1 To LOF(4) / Len(AppSerRecord)
                FileGet(4, AppSerRecord, i)
                CurrentRNum = i

                If AppSerRecord.AppID = AppointmentID Then

                    If Trim(AppSerRecord.ServiceName) = ServiceName Then

                        If AppSerRecord.RecordNumber <> RecordNumber Then
                            AppSerRecord.RecordNumber = RecordNumber
                            FilePut(4, AppSerRecord, CurrentRNum)
                            RecordSaved = True
                            Exit For
                        Else
                            RecordSaved = True
                            Exit For
                        End If

                    ElseIf AppSerRecord.RecordNumber = RecordNumber

                        If DeleteService = False Then
                            AppSerRecord.ServiceName = ServiceName
                            FilePut(4, AppSerRecord, CurrentRNum)
                            RecordSaved = True
                            Exit For
                        Else
                            '      DELETE THE FOUND RECORD
                            '------------------------------------
                            AppSerRecord.ServiceName = "x"
                            FilePut(4, AppSerRecord, CurrentRNum)
                            '------------------------------------
                            RecordSaved = True
                            Exit For
                        End If

                    End If

                End If

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
            .CustomerID = cboCustomer.SelectedItem.Id
            .ID = lblRecordID.Text
            .AppDate = dtpDate.Text
            .AppTime = dtpTime.Text
            .CustomerName = cboCustomer.Text
        End With

        If Editing = False Then

            AppMaxID += 1
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(AppMaxID)
            End Using

        End If

        FilePut(3, AppointmentRecord, CInt(lblCurrentRecord.Text)) 'Save the record

        CurrentAppRNum = lblCurrentRecord.Text
        CloseEditForm()

    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click

        If Editing = True Then

            Dim UnsavedChanges As Boolean = False

            With AppointmentRecord
                If .AppDate <> dtpDate.Text Then UnsavedChanges = True
                If Trim(.AppTime) <> Trim(dtpTime.Text) Then UnsavedChanges = True
                If Trim(.CustomerName) <> Trim(cboCustomer.Text) Then UnsavedChanges = True
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
            AlertType = "notSaved"
            CallingForm = Me
            frmUnsavedAlert.Show()
            Me.Enabled = False

        End If

    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveRecord()
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

End Class