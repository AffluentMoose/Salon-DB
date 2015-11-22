Option Explicit On
Imports System.IO

Public Class frmCustomer

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))

        lblTotalRecords.Text = LOF(1) / Len(CustomerRecord)

        UpdateRecords()

        If System.IO.File.Exists(IDFileName) = True Then    'check if ID file exists, if not make one

            Using Sreader As StreamReader = New StreamReader(IDFileName)
                CustMaxID = Sreader.ReadLine
            End Using

        Else

            CustMaxID = 0
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(CustMaxID)
            End Using

        End If

        lstRecords.SelectedIndex = 0

    End Sub

    Private Sub DisplayRecords(SearchType As Char, SearchString As String) 'takes in 2 parameters for searching records

        Dim i As Integer

        lstRecords.Items.Clear()

        If LOF(1) / Len(CustomerRecord) = 0 Then
            lstRecords.Items.Add("")
            lstRecords.Items.Add("                                  --- NO RECORDS TO DISPLAY ---")
            lblCustomerName.Text = ""
        Else

            For i = 1 To LOF(1) / Len(CustomerRecord)

                FileGet(1, CustomerRecord, i)

                Select Case SearchType
                    Case "n"

                        Dim NameString As String = CustomerRecord.Forename & CustomerRecord.Surname

                        If NameString.ToLower.Contains(SearchString.ToLower) Then
                            DisplayCurrentRecord(i)
                        End If

                    Case Else
                        DisplayCurrentRecord(i)

                End Select


            Next i

        End If

        If lstRecords.Items.Count > 0 Then lstRecords.SelectedIndex = CurrentCustRNum - 1

    End Sub

    Private Sub DisplayCurrentRecord(ByVal i As Integer)
        lstRecords.Items.Add(" " & i.ToString("D3") & Space(4) & CustomerRecord.Forename & " " & CustomerRecord.Surname & " " & CustomerRecord.Telephone & " " & CustomerRecord.Address1 & " " & CustomerRecord.Address2 & Space(6) & CustomerRecord.Email)
    End Sub

    Private Sub ReadRecord()

        FileGet(1, CustomerRecord, CInt(lblCurrentRecord.Text))
        lblCustomerName.Text = Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)

    End Sub

    Private Sub DeleteRecord()

        CustomerRecord.Forename = "DELETE"
        FilePut(1, CustomerRecord, CInt(lblCurrentRecord.Text))

        Dim i As Integer
        Dim NewNumOfRecords As Integer = 1

        TempFilePath = CurDir() & "\Temp.dat"
        FileOpen(9, TempFilePath, OpenMode.Random, , , Len(CustomerRecord))

        For i = 1 To lblTotalRecords.Text

            FileGet(1, CustomerRecord, i)

            If Trim(CustomerRecord.Forename) <> "DELETE" Then

                FilePut(9, CustomerRecord, NewNumOfRecords)
                NewNumOfRecords += 1

            End If

        Next

        FileClose(1)
        FileClose(9)

        Kill(CustomerFilePath)
        FileCopy(TempFilePath, CustomerFilePath)
        Kill(TempFilePath)

        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))

        lblTotalRecords.Text -= 1
        CurrentCustRNum = 1

        txtSearchItem.Text = ""
        UpdateRecords()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Editing = True
        CurrentCustRNum = CInt(lblCurrentRecord.Text)
        frmCustomerEdit.Show()
        Me.Enabled = False

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Editing = False
        CurrentCustRNum = CInt(lblCurrentRecord.Text)
        frmCustomerEdit.Show()
        Me.Enabled = False

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        CurrentCustRNum = lblCurrentRecord.Text
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

                lblTotalRecords.Text = LOF(1) / Len(CustomerRecord)
                btnDelete.Enabled = False
                btnEdit.Enabled = False

                If lblTotalRecords.Text > 0 Then

                    lblCurrentRecord.Text = CurrentCustRNum
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

            CurrentCustRNum = 1

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

    Private Sub btnServiceForm_Click(sender As Object, e As EventArgs) Handles btnServiceForm.Click
        frmService.Show()
        FileClose(1)
        Me.Close()
    End Sub

    Private Sub btnAppointmentForm_Click(sender As Object, e As EventArgs) Handles btnAppointmentForm.Click
        frmAppointment.Show()
        FileClose(1)
        Me.Close()
    End Sub

End Class