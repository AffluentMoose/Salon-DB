Imports System.Text
Imports System.Security.Cryptography

Public Class frmSettings

    Const Salt As String = "6xr_-o+*OKhJ96c|mK=y0J_QyX72"

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshScheme()
        FileOpen(9, SettingsFilePath, OpenMode.Random, , , Len(SettingsRecord))

        Select Case Scheme
            Case "p"
                radPurple.Checked = True
            Case "d"
                radDark.Checked = True
            Case Else
                radLight.Checked = True
        End Select

    End Sub

    Private Sub frmSettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FileClose(9)
        ReturnAction = "scheme"
        CallingForm.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub

    Private Sub radPurple_CheckedChanged(sender As Object, e As EventArgs) Handles radPurple.CheckedChanged
        If radPurple.Checked = True Then
            Scheme = "p"
            FileGet(9, SettingsRecord, 1)
            SettingsRecord.Scheme = Scheme
            FilePut(9, SettingsRecord, 1)
            RefreshScheme()
        End If
    End Sub

    Private Sub radDark_CheckedChanged(sender As Object, e As EventArgs) Handles radDark.CheckedChanged
        If radDark.Checked = True Then
            Scheme = "d"
            FileGet(9, SettingsRecord, 1)
            SettingsRecord.Scheme = Scheme
            FilePut(9, SettingsRecord, 1)
            RefreshScheme()
        End If
    End Sub

    Private Sub radLight_CheckedChanged(sender As Object, e As EventArgs) Handles radLight.CheckedChanged
        If radLight.Checked = True Then
            Scheme = "l"
            FileGet(9, SettingsRecord, 1)
            SettingsRecord.Scheme = Scheme
            FilePut(9, SettingsRecord, 1)
            RefreshScheme()
        End If
    End Sub

    Private Sub RefreshScheme()
        Label1.ForeColor = Color.White
        radPurple.ForeColor = Color.White
        radLight.ForeColor = Color.White
        radDark.ForeColor = Color.White
        Select Case Scheme
            Case "p"
                Me.BackColor = Color.FromArgb(255, 83, 59, 145)
            Case "d"
                Me.BackColor = Color.Black
            Case Else
                Label1.ForeColor = Color.Black
                radPurple.ForeColor = Color.Black
                radLight.ForeColor = Color.Black
                radDark.ForeColor = Color.Black
                Me.BackColor = Color.FromArgb(255, 224, 224, 224)
        End Select
    End Sub

    Private Sub btnPassChange_Click(sender As Object, e As EventArgs) Handles btnPassChange.Click
        PassCallingForm = Me
        frmSetPassword.Show()
        Me.Enabled = False
    End Sub

    Private Function GenerateHash(ByVal SourceText As String) As String
        ' Create an encoding object to ensure the encoding standard for the source text.
        Dim Ue As New UnicodeEncoding()
        ' Retrieve a byte array based on the source text.
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        ' Instantiate an MD5 Provider object.
        Dim Md5 As New MD5CryptoServiceProvider()
        ' Compute the hash value from the source.
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        ' And convert it to String format for return.
        Return Convert.ToBase64String(ByteHash)
    End Function

    Private Sub frmSettings_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If Me.Enabled = True Then
            If ReturnAction = "setPass" Then
                ReturnAction = ""
                Dim Password As String
                Password = SetPassword
                FileGet(9, SettingsRecord, 1)
                SettingsRecord.Password = GenerateHash(Password & Salt)
                FilePut(9, SettingsRecord, 1)
                FileClose(9)
            End If
        End If

    End Sub

End Class