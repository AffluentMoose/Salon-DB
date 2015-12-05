Option Explicit On
Imports System.IO

Public Class frmService

    Dim ltvNoChange As Boolean = False

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(2, ServiceFilePath, OpenMode.Random, , , Len(ServiceRecord))

        lblTotalRecords.Text = LOF(2) / Len(ServiceRecord)

        UpdateRecords()

        If System.IO.File.Exists(IDFileName) Then    'check if ID file exists, if not make one

            Using Sreader As StreamReader = New StreamReader(IDFileName)
                ServiceMaxID = Sreader.ReadLine
            End Using

        Else

            ServiceMaxID = 0
            Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                Swriter.WriteLine(ServiceMaxID)
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

        ltvRecords.Items.Clear()

        Dim i As Integer

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

    End Sub

    Private Sub DisplayCurrentRecord(ByVal i As Integer)
        With ServiceRecord
            Dim Item As New ListViewItem(i.ToString("D3"), 0)
            Item.SubItems.Add(Trim(.Price.ToString("00.00")))
            Item.SubItems.Add(Trim(.Name))
            Item.SubItems.Add(Trim(.Description))
            ltvRecords.Items.Add(Item)
        End With
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

    Private Sub frmCustomer_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If ReturnAction <> "delete" And ReturnAction <> "scheme" Then

            Dim TempText As String = ""

            If Me.Enabled Then

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

            CurrentSerRNum = 1

            Select Case cboSearch.Text

                Case "Search Name"
                    DisplayRecords("n", SearchString)
                    ltvNoChange = True
                    If ltvRecords.Items.Count <> 0 Then
                        ltvRecords.Items(CurrentSerRNum - 1).Selected = True
                    End If
                    ltvNoChange = False

            End Select

        Else
            DisplayRecords("x", "")
            ltvNoChange = True
            If ltvRecords.Items.Count <> 0 Then
                ltvRecords.Items(CurrentSerRNum - 1).Selected = True
            End If
            ltvNoChange = False
            ltvRecords.Focus()
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnCustomerForm_Click(sender As Object, e As EventArgs) Handles btnCustomerForm.Click
        frmCustomer.Show()
        FileClose(2)
        Me.Close()
    End Sub

    Private Sub btnAppointmentForm_Click(sender As Object, e As EventArgs) Handles btnAppointmentForm.Click

        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))

        If LOF(1) / Len(CustomerRecord) <> 0 And LOF(2) / Len(ServiceRecord) <> 0 Then
            frmAppointment.Show()
            FileClose(2)
            Me.Close()
        End If

        FileClose(1)

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
        FileClose(2)
        frmReports.Show()
        Me.Close()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        CallingForm = Me
        frmSettings.Show()
        Me.Enabled = False
    End Sub

End Class