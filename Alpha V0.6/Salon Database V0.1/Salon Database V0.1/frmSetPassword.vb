Public Class frmSetPassword

    Private Sub frmSetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If PassCallingForm Is frmLogin Then
            Label2.Visible = True
            Label1.Visible = False
        End If
        RefreshScheme()

    End Sub

    Private Sub RefreshScheme()
        Label1.ForeColor = Color.White
        txtPass.ForeColor = Color.White
        Select Case Scheme
            Case "p"
                Me.BackColor = Color.FromArgb(255, 83, 59, 145)
                Panel1.BackColor = Color.FromArgb(255, 61, 37, 124)
                txtPass.BackColor = Color.FromArgb(255, 40, 18, 98)
            Case "d"
                Me.BackColor = Color.Black
                txtPass.BackColor = Color.FromArgb(255, 33, 33, 33)
                Panel1.BackColor = Color.FromArgb(255, 48, 48, 48)
            Case Else
                txtPass.BackColor = Color.FromArgb(255, 250, 250, 250)
                Panel1.BackColor = Color.FromArgb(255, 245, 245, 245)
                Label1.ForeColor = Color.Black
                txtPass.ForeColor = Color.Black
                Me.BackColor = Color.FromArgb(255, 224, 224, 224)
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SetPassword = txtPass.Text
        If SetPassword.Length < 8 Then
            MsgBox("Please make sure your password is at least 8 characters")
        Else
            ReturnAction = "setPass"
            PassCallingForm.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub frmSetPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
            e.Handled = False
        End If
    End Sub

End Class