Option Explicit On
Imports System.IO

Public Class frmService

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))

        lblTotalRecords.Text = LOF(2) / Len(ServiceRecord)

        UpdateRecords()

        If System.IO.File.Exists(IDFileName) = True Then    'check if ID file exists, if not make one

            Using Sreader As StreamReader = New StreamReader(IDFileName)
                ServiceMaxID = Sreader.ReadLine
            End Using

        Else

            ServiceMaxID = 0
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(ServiceMaxID)
            End Using

        End If

        lstRecords.SelectedIndex = 0

    End Sub

    Private Sub DisplayRecords(SearchType As Char, SearchString As String) 'takes in 2 parameters for searching records

        Dim i As Integer

        lstRecords.Items.Clear()

        If LOF(2) / Len(ServiceRecord) = 0 Then
            lstRecords.Items.Add("")
            lstRecords.Items.Add("                                  --- NO RECORDS TO DISPLAY ---")
            lblCustomerName.Text = ""
        Else

            For i = 1 To LOF(2) / Len(ServiceRecord)

                FileGet(2, ServiceRecord, i)

                Select Case SearchType
                    Case "n"

                        Dim NameString As String = ServiceRecord.Name

                        If NameString.ToLower.Contains(SearchString.ToLower) Then
                            DisplayCurrentRecord(i)
                        End If

                    Case Else
                        DisplayCurrentRecord(i)

                End Select


            Next i

        End If

        If lstRecords.Items.Count > 0 Then lstRecords.SelectedIndex = CurrentSerRNum - 1

    End Sub

    Private Sub DisplayCurrentRecord(ByVal i As Integer)
        lstRecords.Items.Add(" " & i.ToString("D3") & Space(4) & ServiceRecord.Price.ToString("00.00") & Space(5) & ServiceRecord.Name & Space(5) & ServiceRecord.Description)
    End Sub

    Private Sub ReadRecord()

        FileGet(2, ServiceRecord, CInt(lblCurrentRecord.Text))
        lblCustomerName.Text = Trim(ServiceRecord.Name)

    End Sub

    Private Sub DeleteRecord()

        ServiceRecord.Name = "DELETE"
        FilePut(2, ServiceRecord, CInt(lblCurrentRecord.Text))

        Dim i As Integer
        Dim NewNumOfRecords As Integer = 1

        TempFilePath = CurDir() & "\Temp.dat"
        FileOpen(9, TempFilePath, OpenMode.Random, , , Len(ServiceRecord))

        For i = 1 To lblTotalRecords.Text

            FileGet(2, ServiceRecord, i)

            If Trim(ServiceRecord.Name) <> "DELETE" Then

                FilePut(9, ServiceRecord, NewNumOfRecords)
                NewNumOfRecords += 1

            End If

        Next

        FileClose(2)
        FileClose(9)

        Kill(ServiceFilePath)
        FileCopy(TempFilePath, ServiceFilePath)
        Kill(TempFilePath)

        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))

        lblTotalRecords.Text -= 1
        CurrentSerRNum = 1

        txtSearchItem.Text = ""
        UpdateRecords()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Editing = True
        CurrentSerRNum = CInt(lblCurrentRecord.Text)
        frmServiceEdit.Show()
        Me.Enabled = False

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Editing = False
        CurrentSerRNum = CInt(lblCurrentRecord.Text)
        frmServiceEdit.Show()
        Me.Enabled = False

    End Sub

    Private Sub btnCustomerDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        CurrentSerRNum = lblCurrentRecord.Text
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

    Private Sub lstRecords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRecords.SelectedIndexChanged

        If IsNumeric(Mid(lstRecords.Text, 3, 3)) Then
            lblCurrentRecord.Text = Val(Mid(lstRecords.Text, 3, 3))
            ReadRecord()
        End If

    End Sub

    Private Sub frmCustomer_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If ReturnAction <> "delete" Then

            Dim TempText As String = ""

            If Me.Enabled = True Then

                lblTotalRecords.Text = LOF(2) / Len(ServiceRecord)
                btnDelete.Enabled = False
                btnEdit.Enabled = False

                If lblTotalRecords.Text > 0 Then

                    lblCurrentRecord.Text = CurrentSerRNum
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
    End Sub

    Private Sub txtSearchItem_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItem.TextChanged
        SearchRecords()
    End Sub

    Private Sub SearchRecords()

        Dim SearchString As String = txtSearchItem.Text

        If Trim(txtSearchItem.Text) <> "" Then

            CurrentSerRNum = 1

            Select Case cboSearch.Text

                Case "Search Name"
                    DisplayRecords("n", SearchString)
                Case "Search Telephone"
                    DisplayRecords("t", SearchString)
                Case "Search Email"
                    DisplayRecords("e", SearchString)

            End Select

        Else
            DisplayRecords("x", "")
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub


    Private Sub lstRecords_KeyUp(sender As Object, e As KeyEventArgs) Handles lstRecords.KeyUp

        Select Case e.KeyCode

            Case Keys.Enter
                btnEdit.PerformClick()
                e.Handled = False

            Case Keys.Delete
                btnDelete.PerformClick()
                e.Handled = False

        End Select

    End Sub

    Private Sub btnCustomerForm_Click(sender As Object, e As EventArgs) Handles btnCustomerForm.Click
        frmCustomer.Show()
        FileClose(2)
        Me.Close()
    End Sub

    Private Sub btnAppointmentForm_Click(sender As Object, e As EventArgs) Handles btnAppointmentForm.Click
        frmAppointment.Show()
        FileClose(2)
        Me.Close()
    End Sub

End Class