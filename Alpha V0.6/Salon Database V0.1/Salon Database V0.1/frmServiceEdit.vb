Option Explicit On
Imports System.IO

Public Class frmServiceEdit

    Private Sub frmServiceEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Editing = True Then

            lblCurrentRecord.Text = CurrentSerRNum
            ReadRecord()

        Else

            lblCurrentRecord.Text = LOF(2) / Len(ServiceRecord) + 1
            lblRecordID.Text = ServiceMaxID + 1

        End If

    End Sub

    Private Sub ReadRecord()

        FileGet(2, ServiceRecord, CInt(lblCurrentRecord.Text))

        With ServiceRecord
            lblRecordID.Text = .ID
            txtName.Text = .Name
            txtDescription.Text = .Description
            numPrice.Value = .Price
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
                .ID = lblRecordID.Text
                .Name = txtName.Text
                .Description = txtDescription.Text
                .Price = Math.Round(numPrice.Value, 2, MidpointRounding.AwayFromZero)
            End With

            If Editing = False Then

                ServiceMaxID += 1
                Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                    Swriter.WriteLine(ServiceMaxID)
                End Using

            End If

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

End Class