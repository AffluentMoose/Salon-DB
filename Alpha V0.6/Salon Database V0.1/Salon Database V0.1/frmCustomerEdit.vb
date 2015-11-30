Option Explicit On
Imports System.IO

Public Class frmCustomerEdit

    Private Sub frmCustomerEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Editing = True Then

            lblCurrentRecord.Text = CurrentCustRNum
            ReadRecord()

        Else

            lblCurrentRecord.Text = LOF(1) / Len(CustomerRecord) + 1
            lblRecordID.Text = CustMaxID + 1

        End If

    End Sub

    Private Sub ReadRecord()

        FileGet(1, CustomerRecord, CInt(lblCurrentRecord.Text))

        With CustomerRecord
            lblRecordID.Text = .ID
            txtForename.Text = Trim(.Forename)
            txtSurname.Text = Trim(.Surname)
            txtTelephone.Text = Trim(.Telephone)
            txtAddress1.Text = Trim(.Address1)
            txtAddress2.Text = Trim(.Address2)
            txtEmail.Text = Trim(.Email)
        End With

    End Sub

    Private Sub SaveRecord()

        Dim InvalidData As Boolean = False

        ErrorList.Clear()

        If Trim(txtForename.Text) = "" Then
            InvalidData = True
            ErrorList.Add("Forename")
        End If

        If Trim(txtSurname.Text) = "" Then
            InvalidData = True
            ErrorList.Add("Surname")
        End If

        If Trim(txtTelephone.Text) = "" Then
            InvalidData = True
            ErrorList.Add("Telephone")
        End If

        If InvalidData = False Then

            With CustomerRecord 'write into record
                .ID = lblRecordID.Text
                .Forename = txtForename.Text
                .Surname = txtSurname.Text
                .Telephone = txtTelephone.Text
                .Address1 = txtAddress1.Text
                If .Address1 = "" Then .Address1 = "-"
                .Address2 = txtAddress2.Text
                If .Address2 = "" Then .Address2 = "-"
                .Email = txtEmail.Text
                If .Email = "" Then .Email = "-"
            End With

            If Editing = False Then

                CustMaxID += 1
                Using Swriter As StreamWriter = New StreamWriter(IDFileName)
                    Swriter.WriteLine(CustMaxID)
                End Using

            End If

            FilePut(1, CustomerRecord, CInt(lblCurrentRecord.Text)) 'Save the record

            CurrentCustRNum = lblCurrentRecord.Text
            CloseEditForm()

        Else

            ErrorMessages(0) = "i"
            ErrorMessages(1) = "INPUT ERROR"
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

            With CustomerRecord
                If Trim(txtForename.Text) <> Trim(.Forename) Then UnsavedChanges = True
                If Trim(txtSurname.Text) <> Trim(.Surname) Then UnsavedChanges = True
                If Trim(txtTelephone.Text) <> Trim(.Telephone) Then UnsavedChanges = True
                If Trim(txtAddress1.Text) <> Trim(.Address1) Then UnsavedChanges = True
                If Trim(txtAddress2.Text) <> Trim(.Address2) Then UnsavedChanges = True
                If Trim(txtEmail.Text) <> Trim(.Email) Then UnsavedChanges = True
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
        frmCustomer.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmCustomerEdit_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyCode

            Case Keys.Escape
                btnCancel.PerformClick()
                e.Handled = False

            Case Keys.Enter
                btnSave.PerformClick()
                e.Handled = False

        End Select

    End Sub

    Private Sub frmCustomerEdit_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

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