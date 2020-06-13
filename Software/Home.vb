Option Strict Off
Imports System.Threading.Thread
Imports System.IO
Imports System.Net

Public Class Home

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private curB As Integer
    Private curR As Integer
    Private curG As Integer
    Private dirB As Integer = 1
    Private dirR As Integer = 1
    Private dirG As Integer = -1
    Private rd As New Random

    Private StartLocation As Integer = -1000

    Public WithEvents pd As WebClient


    Sub Downloadwp(url As String, Save As String)
        pd = New WebClient
        pd.DownloadFileAsync(New Uri(url), Save)
    End Sub

    Sub colorChange()
        Me.BackColor = ColorTranslator.FromHtml(My.Settings.BT)
        Me.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        Panel1.BackColor = ColorTranslator.FromHtml(My.Settings.PT1)
        Panel2.BackColor = ColorTranslator.FromHtml(My.Settings.PT1)
        Panel3.BackColor = ColorTranslator.FromHtml(My.Settings.PT1)
        Panel1.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        Panel2.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        Panel3.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        Panel5.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        Panel4.BackColor = ColorTranslator.FromHtml(My.Settings.B)
        Panel4.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        GroupBox1.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        GroupBox2.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        GroupBox3.ForeColor = ColorTranslator.FromHtml(My.Settings.L)
        Button2.ForeColor = ColorTranslator.FromHtml(My.Settings.Button)
        Button3.ForeColor = ColorTranslator.FromHtml(My.Settings.Button)
        Me.Refresh()
    End Sub

    Sub LoadSet()

        My.Settings.Key = ""

        If My.Settings.Setup = 0 Then
            Settings.Show()
            Setup.Show()
        Else
            colorChange()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim ln As Integer = TextBox1.Text.Length
        TextBox1.SelectionStart = ln
        TextBox1.ScrollToCaret()
    End Sub

    Private Sub UpdateBackground()
        curB += 13 * dirB
        curR += 7 * dirR
        curG += 11 * dirG

        If curB > 255 Then
            curB = 255 - (curB - 255)
            dirB = -1
        ElseIf curB < 0 Then
            curB = -curB
            dirB = 1
        End If

        If curR > 255 Then
            curR = 255 - (curR - 255)
            dirR = -1
        ElseIf curR < 0 Then
            curR = -curR
            dirR = 1
        End If

        If curG > 255 Then
            curG = 255 - (curG - 255)
            dirG = -1
        ElseIf curG < 0 Then
            curG = -curG
            dirG = 1
        End If

        Label8.ForeColor = System.Drawing.Color.FromArgb(curR, curG, curB)
        Label8.Refresh()
    End Sub

    Private Sub Panel15_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel5.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel5.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel5.MouseUp
        drag = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Welcome : " & System.Environment.UserName
        Settings.Label2.Text = "Welcome : " & System.Environment.UserName
        LoadSet()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Settings.Show()
    End Sub

    Private Sub FlatButton8_Click(sender As Object, e As EventArgs) Handles FlatButton8.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.Height = 595 Then
            Me.Height = 475
            Button2.Text = "Log ▼"
        Else
            Me.Height = 595
            Button2.Text = "Log ▲"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.paypal.me/NazkyOfficial")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://www.patreon.com/Nazky")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://twitter.com/NazkyYT")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateBackground()

        Label2.Left += 1
        If Label2.Left > Me.ClientSize.Width Then Label2.Left = StartLocation

    End Sub

    Private Sub FlatButton3_Click(sender As Object, e As EventArgs) Handles FlatButton3.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Sub IOS123()
        Shell("py -2 bin\SSHUSB\tcprelay.py -t 44:" & My.Settings.Port, vbHide)
        Dim connInfo As New Renci.SshNet.PasswordConnectionInfo("127.0.0.1", My.Settings.Port, "root", "alpine")
        Dim sshClient As New Renci.SshNet.SshClient(connInfo)
        Dim cmd As Renci.SshNet.SshCommand

        If ProgressBar1.Value = 0 Then
            Using sshClient
                Try

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & Environment.NewLine & "Trying to connect to iDevice"
                    ProgressBar1.Value = 10

                    sshClient.Connect()

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "iDevice Connected"
                    ProgressBar1.Value = 20
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Prepare for bypass..."
                    ProgressBar1.Value = 25

                    cmd = sshClient.RunCommand("mount -o rw,union,update /")
                    ProgressBar1.Value = 30

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Delete IcloudLock..."
                    ProgressBar1.Value = 35

                    cmd = sshClient.RunCommand("rm -rf /Applications/Setup.app")
                    ProgressBar1.Value = 40

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "IcloudLock Delete √"
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Uicache..."
                    ProgressBar1.Value = 75

                    cmd = sshClient.RunCommand("uicache -p /Applications/Setup.app")
                    ProgressBar1.Value = 80

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Respring..."
                    ProgressBar1.Value = 95

                    cmd = sshClient.RunCommand("killall backboardd")
                    ProgressBar1.Value = 100


                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Sucess :D"

                Catch ex As Exception
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Error :" & Environment.NewLine & ex.Message & Environment.NewLine & "Make sur you'r iDevice is jailbreak or try change port number"

                    MsgBox("Error during ssh connection please retry or contact me on Twitter", MsgBoxStyle.Critical)

                    Sleep(50)

                End Try

                Dim p() As Process

                p = Process.GetProcessesByName("python")
                If p.Count > 0 Then
                    Process.GetProcessesByName("python")(0).Kill()
                End If
            End Using

        End If


    End Sub

    Sub PythonCheck()

        MsgBox("You need python2 and python3 !", MsgBoxStyle.Information)

        TextBox1.Text = TextBox1.Text & Environment.NewLine & Environment.NewLine & "Checking Python2..."
        If Directory.Exists("C:\Python27") Then
            TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 Found"
            IOS123()
        Else
            TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 Not Found"
            TextBox1.Text = TextBox1.Text & Environment.NewLine & "Start Download Python2..."
            Try
                Downloadwp("https://www.python.org/ftp/python/2.7.17/python-2.7.17.msi", "bin\Download\Python2.7.msi")
                If ProgressBar1.Value = 100 Then
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 isntall..."
                    Try
                        Shell("msiexec.exe /i " & Application.StartupPath & "bin\Download\Python2.7.msi /quiet", , True)
                        TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 sucess install"
                        PythonCheck()
                    Catch ex As Exception
                        MsgBox("Error during installtion please retry or contact me on Twitter", MsgBoxStyle.Critical)
                        TextBox1.Text = TextBox1.Text & Environment.NewLine & "Error :" & Environment.NewLine & ex.Message
                    End Try

                    ProgressBar1.Value = 0
                    Label6.Visible = False
                End If
            Catch ex As Exception
                MsgBox("Error during download please retry or contact me on Twitter", MsgBoxStyle.Critical)
                TextBox1.Text = TextBox1.Text & Environment.NewLine & "Error :" & Environment.NewLine & ex.Message
                ProgressBar1.Value = 0
            End Try
        End If
        IOS123()
    End Sub

    Sub PythonCheck2()
        MsgBox("You need python2 and python3 !", MsgBoxStyle.Information)
        TextBox1.Text = TextBox1.Text & Environment.NewLine & Environment.NewLine & "Checking Python2..."
        If Directory.Exists("C:\Python27") Then
            TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 Found"
            IOS1243()
        Else
            TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 Not Found"
            TextBox1.Text = TextBox1.Text & Environment.NewLine & "Start Download Python2..."
            Try
                Downloadwp("https://www.python.org/ftp/python/2.7.17/python-2.7.17.msi", "bin\Download\Python2.7.msi")
                If ProgressBar1.Value = 100 Then
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 isntall..."
                    Try
                        Shell("msiexec.exe /i " & Application.StartupPath & "bin\Download\Python2.7.msi /quiet", , True)
                        TextBox1.Text = TextBox1.Text & Environment.NewLine & "Python2 sucess install"
                        PythonCheck()
                    Catch ex As Exception
                        MsgBox("Error during installtion please retry or contact me on Twitter", MsgBoxStyle.Critical)
                        TextBox1.Text = TextBox1.Text & Environment.NewLine & "Error :" & Environment.NewLine & ex.Message
                    End Try

                    ProgressBar1.Value = 0
                    Label6.Visible = False
                End If
            Catch ex As Exception
                MsgBox("Error during download please retry or contact me on Twitter", MsgBoxStyle.Critical)
                TextBox1.Text = TextBox1.Text & Environment.NewLine & "Error :" & Environment.NewLine & ex.Message
                ProgressBar1.Value = 0
            End Try
        End If
        IOS1243()
    End Sub

    Private Sub pd_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles pd.DownloadProgressChanged
        Label6.Visible = True
        ProgressBar1.Value = e.ProgressPercentage
        Label6.Text = ProgressBar1.Value & " %"
    End Sub

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        ProgressBar1.Value = 0
        TextBox1.Text = ""
        TextBox1.Text = "| Bypass for IOS 12.3 to IOS 13.2.3 |"
        PythonCheck()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Sub IOS1243()

        Shell("py -2 bin\SSHUSB\tcprelay.py -t 44:" & My.Settings.Port, vbHide)
        Dim connInfo As New Renci.SshNet.PasswordConnectionInfo("127.0.0.1", My.Settings.Port, "root", "alpine")
        Dim sshClient As New Renci.SshNet.SshClient(connInfo)
        Dim cmd As Renci.SshNet.SshCommand

        If ProgressBar1.Value = 0 Then
            Using sshClient
                Try
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & Environment.NewLine & "Trying to connect to iDevice"
                    ProgressBar1.Value = 10

                    sshClient.Connect()

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "iDevice Connected"
                    ProgressBar1.Value = 20
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Prepare for bypass..."
                    ProgressBar1.Value = 25

                    cmd = sshClient.RunCommand("mount -o rw,union,update /")
                    ProgressBar1.Value = 30

                    Shell("bin\Ressource\Program\OpenSSH\scp.exe -rP " & My.Settings.Port & " bin\Ressource\Files\HakkuraifuBypass root@localhost:/usr/libexec/", AppWinStyle.NormalFocus, True)

                    cmd = sshClient.RunCommand("mv /usr/libexec/mobileactivationd /usr/libexec/mobileactivationdbak")
                    ProgressBar1.Value = 40

                    cmd = sshClient.RunCommand("mv /usr/libexec/HakkuraifuBypass /usr/libexec/mobileactivationd")
                    ProgressBar1.Value = 45

                    cmd = sshClient.RunCommand("chmod 755 /usr/libexec/mobileactivationd")
                    ProgressBar1.Value = 50

                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Bypass..."

                    cmd = sshClient.RunCommand("launchctl unload /System/Library/LaunchDaemons/com.apple.mobileactivationd.plist")
                    ProgressBar1.Value = 70

                    cmd = sshClient.RunCommand("launchctl load /System/Library/LaunchDaemons/com.apple.mobileactivationd.plist")
                    ProgressBar1.Value = 100


                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Sucess :D"
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "You can now unlock and configure you'r iDevice"

                Catch ex As Exception
                    TextBox1.Text = TextBox1.Text & Environment.NewLine & "Error :" & Environment.NewLine & ex.Message & Environment.NewLine & "Make sur you'r iDevice is jailbreak or try change port number"

                    MsgBox("Error during ssh connection please retry or contact me on Twitter", MsgBoxStyle.Critical)

                    Sleep(50)

                End Try

                Dim p() As Process

                p = Process.GetProcessesByName("python")
                If p.Count > 0 Then
                    Process.GetProcessesByName("python")(0).Kill()
                End If
            End Using

        End If

    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        ProgressBar1.Value = 0
        MsgBox("MAKE SURE TO CONFIGURE WIFI BEFORE CONTINUE !!!!!!", MsgBoxStyle.Information)
        TextBox1.Text = ""
        TextBox1.Text = "| Bypass for IOS 12.4.5 to IOS 13.3.x |"
        PythonCheck2()
    End Sub

    Private Sub FlatButton5_Click(sender As Object, e As EventArgs) Handles FlatButton5.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Private Sub FlatButton6_Click(sender As Object, e As EventArgs) Handles FlatButton6.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Private Sub FlatButton7_Click(sender As Object, e As EventArgs) Handles FlatButton7.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Private Sub FlatButton9_Click(sender As Object, e As EventArgs) Handles FlatButton9.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("no working for now :(", MsgBoxStyle.Information)
    End Sub
End Class
