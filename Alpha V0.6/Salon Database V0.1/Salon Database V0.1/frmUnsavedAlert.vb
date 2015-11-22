Public Class frmUnsavedAlert

    Private Sub frmUnsavedAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReturnAction = ""

        If AlertType = "notSaved" Then

            lblAlert.Text = "Do you want to save the" & vbNewLine & "changes to this record?"
            btnCancel.Enabled = True
            btnCancel.Visible = True
            btnSave.Enabled = True
            btnSave.Visible = True
            btnNoSave.Enabled = True
            btnNoSave.Visible = True
            btnDelete.Enabled = False
            btnDelete.Visible = False
            btnNoDelete.Enabled = False
            btnNoDelete.Visible = False

        ElseIf AlertType = "delete"

            lblAlert.Text = "Are you sure you want to" & vbNewLine & "delete this record?"
            btnCancel.Enabled = False
            btnCancel.Visible = False
            btnSave.Enabled = False
            btnSave.Visible = False
            btnNoSave.Enabled = False
            btnNoSave.Visible = False
            btnDelete.Enabled = True
            btnDelete.Visible = True
            btnNoDelete.Enabled = True
            btnNoDelete.Visible = True

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ReturnAction = ""
        CallingForm.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmUnsavedAlert_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyCode

            Case Keys.Escape
                btnCancel.PerformClick()

        End Select

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ReturnAction = "save"
        CallingForm.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnNoSave_Click(sender As Object, e As EventArgs) Handles btnNoSave.Click
        ReturnAction = "nosave"
        CallingForm.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnNoDelete_Click(sender As Object, e As EventArgs) Handles btnNoDelete.Click
        CallingForm.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ReturnAction = "delete"
        CallingForm.Enabled = True
        Me.Close()
    End Sub

End Class