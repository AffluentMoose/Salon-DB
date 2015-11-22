Public Class frmError

    Private Sub frmErrorInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReturnAction = ""
        ShowError(ErrorMessages(0), ErrorMessages(1), ErrorMessages(2), ErrorMessages(3))

    End Sub

    Private Sub ShowError(ByVal ErrorType As Char, ByVal ErrorName As String, ByVal Problem As String, ByVal Solution As String)

        'change icon depending on error type

        lblErrorName.Text = ErrorName
        lblProblem.Text = Problem
        lblSolution.Text = Solution

        Dim ErrorMessage As String = ""

        For Each item In ErrorList
            ErrorMessage = ErrorMessage & "- " & item & vbNewLine
        Next

        lblMessage.Text = ErrorMessage

    End Sub

    Private Sub btnOkay_Click(sender As Object, e As EventArgs) Handles btnOkay.Click

        CallingForm.Enabled = True
        Me.Close()

    End Sub

End Class