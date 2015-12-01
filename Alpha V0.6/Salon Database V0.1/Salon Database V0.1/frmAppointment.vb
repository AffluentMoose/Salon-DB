Option Explicit On
Imports System.IO

Public Class frmAppointment

    Private Sub frmAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(3, AppointmentFilePath, OpenMode.Random, , , Len(AppointmentRecord))

        lblTotalRecords.Text = LOF(3) / Len(AppointmentRecord)

        UpdateRecords()

        If System.IO.File.Exists(IDFileName) = True Then    'check if ID file exists, if not make one

            Using Sreader As StreamReader = New StreamReader(IDFileName)
                AppMaxID = Sreader.ReadLine
            End Using

        Else

            AppMaxID = 0
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(AppMaxID)
            End Using

        End If

        cboSearch.SelectedIndex = 0

    End Sub

    Private Sub DisplayRecords(SearchType As Char, SearchString As String) 'takes in 2 parameters for searching records

        Dim i As Integer

        ltvRecords.Items.Clear()

        For i = 1 To LOF(3) / Len(AppointmentRecord)

            FileGet(3, AppointmentRecord, i)

            Select Case SearchType
                Case "n"

                    Dim SearchedString As String = AppointmentRecord.CustomerName

                    If SearchedString.ToLower.Contains(SearchString.ToLower) Then
                        DisplayCurrentRecord(i)
                    End If

                Case "d"

                    Dim SearchedString As String = AppointmentRecord.AppDate

                    If SearchedString.ToLower.Contains(SearchString.ToLower) Then
                        DisplayCurrentRecord(i)
                    End If

                Case Else
                    DisplayCurrentRecord(i)

            End Select

        Next i

    End Sub

    Private Sub DisplayCurrentRecord(ByVal i As Integer)
        With AppointmentRecord
            Dim Item As New ListViewItem(i.ToString("D3"), 0)
            Item.SubItems.Add(Trim(.AppDate))
            Item.SubItems.Add(Trim(.AppTime.ToString("hh:mm")))
            Item.SubItems.Add(Trim(.CustomerName))
            ltvRecords.Items.Add(Item)
        End With
    End Sub

    Private Sub ReadRecord()

        FileGet(3, AppointmentRecord, CInt(lblCurrentRecord.Text))
        lblCustomerName.Text = Trim(AppointmentRecord.CustomerName)

    End Sub

    Private Sub DeleteRecord()

        AppointmentRecord.CustomerName = "DELETE"
        FilePut(3, AppointmentRecord, CInt(lblCurrentRecord.Text))

        Dim i As Integer
        Dim NewNumOfRecords As Integer = 1

        TempFilePath = CurDir() & "\Temp.dat"
        FileOpen(9, TempFilePath, OpenMode.Random, , , Len(AppointmentRecord))

        For i = 1 To lblTotalRecords.Text

            FileGet(3, AppointmentRecord, i)

            If Trim(AppointmentRecord.CustomerName) <> "DELETE" Then

                FilePut(9, AppointmentRecord, NewNumOfRecords)
                NewNumOfRecords += 1

            End If

        Next

        FileClose(3)
        FileClose(9)

        Kill(AppointmentFilePath)
        FileCopy(TempFilePath, AppointmentFilePath)
        Kill(TempFilePath)

        FileOpen(3, AppointmentFilePath, OpenMode.Random, , , Len(AppointmentRecord))

        lblTotalRecords.Text -= 1
        CurrentAppRNum = 1

        txtSearchItem.Text = ""
        UpdateRecords()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Editing = True
        CurrentAppRNum = CInt(lblCurrentRecord.Text)
        frmAppointmentEdit.Show()
        Me.Enabled = False

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Editing = False
        CurrentAppRNum = CInt(lblCurrentRecord.Text)
        frmAppointmentEdit.Show()
        Me.Enabled = False

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        CurrentAppRNum = lblCurrentRecord.Text
        AlertType = "delete"
        CallingForm = Me
        frmUnsavedAlert.Show()
        Me.Enabled = False
    End Sub

    Private Sub UpdateRecords()

        btnDelete.Enabled = False
        btnEdit.Enabled = False
        lblCurrentRecord.Text = 0

        If lblTotalRecords.Text > 0 Then
            lblCurrentRecord.Text = 1
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            ReadRecord()
        End If

        DisplayRecords("x", "")

    End Sub

    Private Sub frmAppointment_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If ReturnAction <> "delete" Then

            Dim TempText As String = ""

            If Me.Enabled = True Then

                lblTotalRecords.Text = LOF(3) / Len(AppointmentRecord)
                btnDelete.Enabled = False
                btnEdit.Enabled = False

                If lblTotalRecords.Text > 0 Then

                    lblCurrentRecord.Text = CurrentAppRNum
                    btnEdit.Enabled = True
                    btnDelete.Enabled = True
                    ReadRecord()
                    SearchRecords()

                End If

            End If

        ElseIf ReturnAction = "delete"

            ReturnAction = ""
            DeleteRecord()

        End If

    End Sub

    Private Sub btnCancelSearch_Click(sender As Object, e As EventArgs) Handles btnCancelSearch.Click
        txtSearchItem.Text = ""
        txtSearchItem.Focus()
    End Sub

    Private Sub txtSearchItem_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItem.TextChanged
        SearchRecords()
    End Sub

    Private Sub SearchRecords()

        Dim SearchString As String = txtSearchItem.Text

        If Trim(txtSearchItem.Text) <> "" Then

            CurrentAppRNum = 1

            Select Case cboSearch.Text

                Case "Search Name"
                    DisplayRecords("n", SearchString)
                Case "Search Date"
                    DisplayRecords("d", SearchString)

            End Select

        Else
            DisplayRecords("x", "")
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub


    Private Sub lstRecords_KeyUp(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode

            Case Keys.Enter
                btnEdit.PerformClick()
                e.Handled = False

            Case Keys.Delete
                btnDelete.PerformClick()
                e.Handled = False

        End Select

    End Sub

    Private Sub btnServiceForm_Click(sender As Object, e As EventArgs) Handles btnServiceForm.Click
        frmService.Show()
        FileClose(3)
        Me.Close()
    End Sub

    Private Sub btnCustomerForm_Click(sender As Object, e As EventArgs) Handles btnCustomerForm.Click
        frmCustomer.Show()
        FileClose(3)
        Me.Close()
    End Sub

    Private Sub lblLen_Click(sender As Object, e As EventArgs) Handles lblLen.Click
        FileOpen(4, AppServFilePath, OpenMode.Random, , , Len(AppSerRecord))
        lblLen.Text = "Records in AppSer File: " & LOF(4) / Len(AppSerRecord)
        FileClose(4)
    End Sub

    Private Sub cboSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch.SelectedIndexChanged
        txtSearchItem.Text = ""
        txtSearchItem.Focus()
    End Sub

    Private Sub ltvRecords_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ltvRecords.ItemSelectionChanged
        If e.IsSelected = True Then
            lblCurrentRecord.Text = Val(ltvRecords.FocusedItem.Text)
            ReadRecord()
        End If
    End Sub

End Class