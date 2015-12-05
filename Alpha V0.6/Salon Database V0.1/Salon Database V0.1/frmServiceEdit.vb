Option Explicit On
Imports System.IO

Public Class frmServiceEdit

    Private Sub frmServiceEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshScheme()
        If Editing = True Then
            lblCurrentRecord.Text = CurrentSerRNum
            ReadRecord()
        Else
            lblCurrentRecord.Text = LOF(2) / Len(ServiceRecord) + 1
        End If

    End Sub

    Private Sub ReadRecord()

        FileGet(2, ServiceRecord, CInt(lblCurrentRecord.Text))

        With ServiceRecord
            txtName.Text = Trim(.Name)
            txtDescription.Text = Trim(.Description)
            numPrice.Value = Trim(.Price)
        End With

    End Sub

    Private Sub SaveRecord()

        Dim InvalidData As Boolean = False

        ErrorList.Clear()

        If Trim(txtName.Text) = "" Then
            InvalidData = True
            ErrorList.Add("Name")
        End If

        If Trim(txtDescription.Text) = "" Then
            InvalidData = True
            ErrorList.Add("Description")
        End If

        If InvalidData = False Then

            With ServiceRecord 'write into record
                .Name = txtName.Text
                .Description = txtDescription.Text
                .Price = Math.Round(numPrice.Value, 2, MidpointRounding.AwayFromZero)
            End With

            FilePut(2, ServiceRecord, CInt(lblCurrentRecord.Text)) 'Save the record

            CurrentSerRNum = lblCurrentRecord.Text
            CloseEditForm()

        Else

            ErrorMessages(0) = "i"
            ErrorMessages(2) = "INPUT ERROR"
            ErrorMessages(2) = "Required field(s) left empty"
            ErrorMessages(3) = "Please fill in the following field(s):"
            CallingForm = Me
            frmError.Show()
            Me.Enabled = False

        End If

    End Sub


    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click

        If Editing = True Then

            Dim UnsavedChanges As Boolean = False

            With ServiceRecord
                If Trim(txtName.Text) <> Trim(.Name) Then UnsavedChanges = True
                If Trim(txtDescription.Text) <> Trim(.Description) Then UnsavedChanges = True
                If numPrice.Value <> .Price Then UnsavedChanges = True
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
        frmService.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmServiceEdit_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyCode

            Case Keys.Escape
                btnCancel.PerformClick()
                e.Handled = False

            Case Keys.Enter
                btnSave.PerformClick()
                e.Handled = False

        End Select

    End Sub

    Private Sub frmServiceEdit_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

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
            ElseIf TypeOf Ctrl Is Panel Or TypeOf Ctrl Is GroupBox
                For Each Ctrol As Control In Ctrl.Controls
                    Ctrol.ForeColor = Color.White
                    If TypeOf Ctrol Is Button Then
                        Ctrol.BackColor = Color1
                        Ctrol.ForeColor = Color1
                    ElseIf TypeOf Ctrol Is Label
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is ComboBox Or TypeOf Ctrol Is NumericUpDown
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is Panel Or TypeOf Ctrol Is GroupBox
                        Ctrol.BackColor = Color3
                        For Each Cntrol As Control In Ctrol.Controls
                            Cntrol.ForeColor = Color.White
                            If TypeOf Cntrol Is Button Or TypeOf Cntrol Is PictureBox Then
                                Cntrol.BackColor = Color3
                                Cntrol.ForeColor = Color3
                            ElseIf TypeOf Cntrol Is TextBox Or TypeOf Cntrol Is ComboBox Or TypeOf Cntrol Is NumericUpDown
                                Cntrol.BackColor = Color1
                            ElseIf TypeOf Cntrol Is ListView
                                If Scheme = "d" Then
                                    Cntrol.BackColor = Color1
                                End If
                            End If
                        Next
                    End If

                Next

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
            ElseIf TypeOf Ctrl Is Panel Or TypeOf Ctrl Is GroupBox
                For Each Ctrol As Control In Ctrl.Controls
                    Ctrol.ForeColor = Color.Black
                    If TypeOf Ctrol Is Button Then
                        Ctrol.BackColor = Color.DarkGray
                        Ctrol.ForeColor = Color.Black
                    ElseIf TypeOf Ctrol Is Label
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is TextBox Or TypeOf Ctrol Is ComboBox Or TypeOf Ctrol Is NumericUpDown
                        Ctrol.BackColor = Color1
                    ElseIf TypeOf Ctrol Is Panel Or TypeOf Ctrol Is GroupBox
                        Ctrol.BackColor = Color.FromArgb(255, 210, 210, 210)
                        For Each Cntrol As Control In Ctrol.Controls
                            Cntrol.ForeColor = Color.Black
                            If TypeOf Cntrol Is Button Or TypeOf Cntrol Is PictureBox Then
                                Cntrol.BackColor = Color.DarkGray
                                Cntrol.ForeColor = Color.Black
                            ElseIf TypeOf Cntrol Is TextBox Or TypeOf Cntrol Is ComboBox Or TypeOf Cntrol Is NumericUpDown
                                Cntrol.BackColor = Color1
                            ElseIf TypeOf Cntrol Is ListView
                                Cntrol.BackColor = Color.FromArgb(255, 215, 215, 215)
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

End Class