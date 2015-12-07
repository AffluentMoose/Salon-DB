Option Explicit On
Imports System.IO

Public Class frmCustomer

    Dim CustomerRecordsCount As Integer = 0
    Dim Customers As New List(Of Customer)
    Dim CurrentRecord As Integer
    Dim ltvNoChange As Boolean = False

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))
        RefreshScheme()

        If System.IO.File.Exists(IDFileName) Then    'check if ID file exists, if not make one
            Using Sreader As StreamReader = New StreamReader(IDFileName)
                CustMaxID = Sreader.ReadLine
            End Using
        Else
            CustMaxID = 0
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(CustMaxID)
            End Using
        End If

        cboSearch.SelectedIndex = 0

        CurrentCustRNum = 0
        UpdateRecords()
        DisplayRecords("x", "")

        If ltvRecords.Items.Count <> 0 Then
            ltvNoChange = True
            ltvRecords.Items(0).Selected = True
            ltvNoChange = False
            ltvRecords.Focus()
        End If

    End Sub

    Private Sub DisplayRecords(SearchType As Char, SearchString As String) 'takes in 2 parameters for searching records

        Dim i As Integer = 0
        ltvRecords.Items.Clear()

        For Each Customer In Customers

            'FileGet(1, CustomerRecord, i)

            Select Case SearchType
                Case "n"

                    Dim SearchedString As String = Customer.Forename & Customer.Surname

                    If SearchedString.ToLower.Contains(SearchString.ToLower) Then
                        DisplayCurrentRecord(i)
                    End If

                Case "t"

                    Dim SearchedString As String = Customer.Telephone

                    If SearchedString.ToLower.Contains(SearchString.ToLower) Then
                        DisplayCurrentRecord(i)
                    End If

                Case "e"

                    Dim SearchedString As String = Customer.Email

                    If SearchedString.ToLower.Contains(SearchString.ToLower) Then
                        DisplayCurrentRecord(i)
                    End If

                Case Else
                    DisplayCurrentRecord(i)

            End Select
            i += 1
        Next

    End Sub

    Private Sub DisplayCurrentRecord(ByVal i As Integer)
        With Customers(i)
            Dim Item As New ListViewItem((i + 1).ToString("D3"), 0)
            Item.SubItems.Add(Trim(.Forename))
            Item.SubItems.Add(Trim(.Surname))
            Item.SubItems.Add(Trim(.Telephone))
            Item.SubItems.Add(Trim(.Email))
            Item.SubItems.Add(Trim(.Address1))
            Item.SubItems.Add(Trim(.Address2))
            ltvRecords.Items.Add(Item)
        End With
    End Sub

    Private Sub ReadRecord()

        'FileGet(1, CustomerRecord, CInt(lblCurrentRecord.Text))
        'lblCustomerName.Text = Trim(CustomerRecord.Forename) & " " & Trim(CustomerRecord.Surname)
        lblCustomerName.Text = Trim(Customers(CurrentCustRNum).Forename) & " " & Trim(Customers(CurrentCustRNum).Surname)

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

    Private Sub MarkDeleted()

        CustomerRecord.Deleted = 1
        FilePut(1, CustomerRecord, CInt(lblCurrentRecord.Text))

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If ltvRecords.SelectedItems.Count > 0 Then
            CurrentRecord = ltvRecords.SelectedItems(0).Index
            Editing = True
            CurrentCustRNum += 1
            frmCustomerEdit.Show()
            Me.Enabled = False
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If ltvRecords.SelectedItems.Count > 0 Then
            CurrentRecord = ltvRecords.SelectedItems(0).Index
        End If
        Editing = False
        CurrentCustRNum += 1
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

        Customers.Clear()
        For i = 1 To LOF(1) / Len(CustomerRecord)
            FileGet(1, CustomerRecord, i)
            Customers.Add(CustomerRecord)
        Next
        CustomerRecordsCount = Customers.Count - 1

        lblTotalRecords.Text = CustomerRecordsCount + 1
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        lblCurrentRecord.Text = CurrentCustRNum

        If CustomerRecordsCount > 0 Then
            lblCurrentRecord.Text = 1
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            ReadRecord()
        End If

    End Sub

    Private Sub frmCustomer_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If ReturnAction <> "delete" And ReturnAction <> "scheme" Then

            If Me.Enabled Then
                Dim TempCustNumber As Integer = CurrentCustRNum - 1
                CurrentCustRNum = TempCustNumber
                UpdateRecords()
                DisplayRecords("x", "")
                SearchRecords()
                CurrentCustRNum = TempCustNumber
                ltvNoChange = True
                If ltvRecords.Items.Count <> 0 Then
                    ltvRecords.Items(CurrentRecord).Selected = True
                End If
                ltvNoChange = False
                lblCurrentRecord.Text = CurrentCustRNum + 1
                ReadRecord()
                ltvRecords.Focus()
            End If

        ElseIf ReturnAction = "delete"

            ReturnAction = ""
            MarkDeleted()
            DisplayRecords("x", "")

        ElseIf ReturnAction = "scheme"
            RefreshScheme()
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

            CurrentCustRNum = 0

            Select Case cboSearch.Text

                Case "Search Name"
                    DisplayRecords("n", SearchString)
                    SelectCorrectRecord()
                Case "Search Telephone"
                    DisplayRecords("t", SearchString)
                    SelectCorrectRecord()
                Case "Search Email"
                    DisplayRecords("e", SearchString)
                    SelectCorrectRecord()
            End Select

        Else
            DisplayRecords("x", "")
            SelectCorrectRecord()
        End If

        ltvNoChange = True
        If ltvRecords.Items.Count <> 0 Then
            ltvRecords.Items(0).Selected = True
            CurrentCustRNum = Val(ltvRecords.Items(0).Text) - 1
        End If
        ltvNoChange = False
        ReadRecord()
        lblCurrentRecord.Text = CurrentCustRNum + 1

    End Sub

    Private Sub SelectCorrectRecord()
        ltvNoChange = True
        If ltvRecords.Items.Count <> 0 Then
            ltvRecords.Items(CurrentCustRNum).Selected = True
        End If
        ltvNoChange = False
    End Sub

    Private Sub ltvRecords_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ltvRecords.ItemSelectionChanged
        If e.IsSelected Then
            If Not ltvNoChange Then
                CurrentCustRNum = Val(ltvRecords.FocusedItem.Text) - 1
                lblCurrentRecord.Text = CurrentCustRNum + 1
                ReadRecord()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FileOpen(9, SettingsFilePath, OpenMode.Random, , , Len(SettingsRecord))
        FileGet(9, SettingsRecord, 1)
        SettingsRecord.Scheme = Scheme
        FilePut(9, SettingsRecord, 1)
        FileClose(9)
        Application.Exit()
    End Sub

    Private Sub btnServiceForm_Click(sender As Object, e As EventArgs) Handles btnServiceForm.Click
        frmService.Show()
        FileClose(1)
        Me.Close()
    End Sub

    Private Sub btnAppointmentForm_Click(sender As Object, e As EventArgs) Handles btnAppointmentForm.Click

        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))

        If LOF(1) / Len(CustomerRecord) <> 0 And LOF(2) / Len(ServiceRecord) <> 0 Then
            frmAppointment.Show()
            FileClose(1)
            Me.Close()
        End If

        FileClose(2)

    End Sub

    Private Sub cboSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch.SelectedIndexChanged
        txtSearchItem.Text = ""
        txtSearchItem.Focus()
    End Sub

    Private Sub btnReportForm_Click(sender As Object, e As EventArgs) Handles btnReportForm.Click
        FileClose(1)
        frmReports.Show()
        Me.Close()
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
            ElseIf TypeOf Ctrl Is Panel
                For Each Ctrol As Control In Ctrl.Controls
                    Ctrol.ForeColor = Color.White
                    If TypeOf Ctrol Is Button Then
                        Ctrol.BackColor = Color1
                        Ctrol.ForeColor = Color1
                    ElseIf TypeOf Ctrol Is Label
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is ComboBox
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is Panel
                        Ctrol.BackColor = Color3
                        For Each Cntrol As Control In Ctrol.Controls
                            Cntrol.ForeColor = Color.White
                            If TypeOf Cntrol Is Button Or TypeOf Cntrol Is PictureBox Then
                                Cntrol.BackColor = Color3
                                Cntrol.ForeColor = Color3
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
            ElseIf TypeOf Ctrl Is Panel
                For Each Ctrol As Control In Ctrl.Controls
                    Ctrol.ForeColor = Color.Black
                    If TypeOf Ctrol Is Button Then
                        Ctrol.BackColor = Color.DarkGray
                        Ctrol.ForeColor = Color.Black
                    ElseIf TypeOf Ctrol Is Label
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is ComboBox
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is Panel
                        Ctrol.BackColor = Color.FromArgb(255, 210, 210, 210)
                        For Each Cntrol As Control In Ctrol.Controls
                            Cntrol.ForeColor = Color.Black
                            If TypeOf Cntrol Is Button Or TypeOf Cntrol Is PictureBox Then
                                Cntrol.BackColor = Color.DarkGray
                                Cntrol.ForeColor = Color.Black
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

End Class