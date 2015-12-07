Option Explicit On
Imports System.IO

Public Class frmAppointment

    Dim ltvNoChange As Boolean = False

    Private Sub frmAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(3, AppointmentFilePath, OpenMode.Random, , , Len(AppointmentRecord))

        lblTotalRecords.Text = LOF(3) / Len(AppointmentRecord)

        UpdateRecords()

        If System.IO.File.Exists(IDFileName) Then    'check if ID file exists, if not make one

            Using Sreader As StreamReader = New StreamReader(IDFileName)
                Sreader.ReadLine()
                AppMaxID = Sreader.ReadLine
            End Using

        Else

            AppMaxID = 0
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(CustMaxID)
                Swriter.WriteLine(AppMaxID)
            End Using

        End If
        RefreshScheme()
        cboSearch.SelectedIndex = 0

        If ltvRecords.Items.Count <> 0 Then
            ltvNoChange = True
            ltvRecords.Items(0).Selected = True
            ltvNoChange = False
            ltvRecords.Focus()
        End If


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

        If ReturnAction <> "delete" And ReturnAction <> "scheme" Then

            Dim TempText As String = ""

            If Me.Enabled Then

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

            CurrentAppRNum = 1

            Select Case cboSearch.Text

                Case "Search Name"
                    DisplayRecords("n", SearchString)
                    ltvNoChange = True
                    If ltvRecords.Items.Count <> 0 Then
                        ltvRecords.Items(CurrentAppRNum - 1).Selected = True
                    End If
                    ltvNoChange = False
                Case "Search Date"
                    DisplayRecords("d", SearchString)
                    ltvNoChange = True
                    If ltvRecords.Items.Count <> 0 Then
                        ltvRecords.Items(CurrentAppRNum - 1).Selected = True
                    End If
                    ltvNoChange = False

            End Select

        Else
            DisplayRecords("x", "")
            ltvNoChange = True
            If ltvRecords.Items.Count <> 0 Then
                ltvRecords.Items(CurrentAppRNum - 1).Selected = True
            End If
            ltvNoChange = False
            ltvRecords.Focus()

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
        If e.IsSelected Then
            If Not ltvNoChange Then
                lblCurrentRecord.Text = Val(ltvRecords.FocusedItem.Text)
                ReadRecord()
            End If
        End If
    End Sub

    Private Sub btnReportForm_Click(sender As Object, e As EventArgs) Handles btnReportForm.Click
        FileClose(3)
        frmReports.Show()
        Me.Close()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        CallingForm = Me
        frmSettings.Show()
        Me.Enabled = False
    End Sub

End Class