Public Class frmSettings

    Private Sub btnPurple_Click(sender As Object, e As EventArgs) Handles btnPurple.Click
        SetScheme("p")
    End Sub

    Private Sub btnDark_Click(sender As Object, e As EventArgs) Handles btnDark.Click
        SetScheme("d")
    End Sub

    Private Sub btnLight_Click(sender As Object, e As EventArgs) Handles btnLight.Click
        SetScheme("l")
    End Sub

    Private Sub SetScheme(ByVal Color As Char)
        Scheme = Color
        Me.Close()
    End Sub

    Private Sub frmSettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ReturnAction = "scheme"
        CallingForm.Enabled = True
    End Sub

End Class