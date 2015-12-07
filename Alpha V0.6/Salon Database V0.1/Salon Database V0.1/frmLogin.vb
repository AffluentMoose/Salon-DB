Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class frmLogin

    Const Salt As String = "6xr_-o+*OKhJ96c|mK=y0J_QyX72"
    Dim FirstAccess As Boolean = True
    Dim RetrievedPass As String
    Dim RetrievedScehme As Char
    Dim Password As String

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileOpen(1, SettingsFilePath, OpenMode.Random, , , Len(SettingsRecord))

        FileGet(1, SettingsRecord, 1)

        With SettingsRecord
            RetrievedScehme = .Scheme
            If .FirstAccess = "y" Then
                FirstAccess = True
                .FirstAccess = "x"
                FilePut(1, SettingsRecord, 1)
            ElseIf .FirstAccess = "x"
                FirstAccess = False
                RetrievedPass = Trim(.Password)
            Else
                MsgBox("It appears one of the required files is corrupt. Please contact sonic the hedgehog")
                Application.Exit()
            End If
        End With

        Scheme = RetrievedScehme

        RefreshScheme()

    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If FirstAccess = True Then
            PassCallingForm = Me
            frmSetPassword.Show()
            Me.Enabled = False
        End If

    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        Dim InputPass As String = GenerateHash(txtPass.Text & Salt)
        If InputPass = RetrievedPass Then
            FileClose(1)
            frmCustomer.Show()
            Me.Close()
        Else
            MsgBox("Sorry, that password is incorrect.")
            txtPass.Focus()
        End If

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

    Private Sub RefreshScheme()
        Label1.ForeColor = Color.White
        Label2.ForeColor = Color.White
        Label3.ForeColor = Color.White
        txtPass.ForeColor = Color.White
        Select Case Scheme
            Case "p"
                Me.BackColor = Color.FromArgb(255, 83, 59, 145)
                Panel1.BackColor = Color.FromArgb(255, 61, 37, 124)
                txtPass.BackColor = Color.FromArgb(255, 40, 18, 98)
                btnEnter.BackColor = Color.FromArgb(255, 83, 59, 145)
                btnEnter.ForeColor = Color.FromArgb(255, 83, 59, 145)
            Case "d"
                Me.BackColor = Color.Black
                Panel1.BackColor = Color.FromArgb(255, 48, 48, 48)
                txtPass.BackColor = Color.FromArgb(255, 33, 33, 33)
                btnEnter.BackColor = Color.Black
                btnEnter.ForeColor = Color.Black
            Case Else
                txtPass.ForeColor = Color.Black
                Label1.ForeColor = Color.Black
                Label2.ForeColor = Color.Black
                Label3.ForeColor = Color.Black
                Me.BackColor = Color.FromArgb(255, 224, 224, 224)
                Panel1.BackColor = Color.FromArgb(255, 245, 245, 245)
                txtPass.BackColor = Color.FromArgb(255, 250, 250, 250)
                btnEnter.BackColor = Color.FromArgb(255, 170, 170, 170)
                btnEnter.ForeColor = Color.FromArgb(255, 170, 170, 170)
        End Select
    End Sub

    Private Sub frmLogin_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnEnter.PerformClick()
            e.Handled = False
        End If

    End Sub

    Private Sub frmLogin_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If Me.Enabled = True Then
            If ReturnAction = "setPass" Then
                ReturnAction = ""
                Password = SetPassword
                FileGet(1, SettingsRecord, 1)
                SettingsRecord.Password = GenerateHash(Password & Salt)
                RetrievedPass = SettingsRecord.Password
                FilePut(1, SettingsRecord, 1)
            End If
        End If

    End Sub

End Class