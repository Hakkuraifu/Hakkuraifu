Imports System.Net

Public Class Setup

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Home.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Launch" Then
            Settings.Button4.PerformClick()
            Home.Opacity = 95
            Settings.Opacity = 100
            My.Settings.Setup = 1
            My.Settings.Save()
            Settings.Close()
            Me.Close()
        Else
            Panel1.Visible = True
            If Panel1.Visible = True Then
                Button1.Text = "Launch"
            End If
        End If




    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Settings.HT.Checked = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Settings.DT.Checked = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Settings.WT.Checked = True
    End Sub

    Private Sub Setup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Home.Opacity = 0
        Settings.Opacity = 0
        If Settings.Label6.Text = My.Settings.Key Then
            Home.Opacity = 100
            Settings.Opacity = 100
            Me.Close()
        End If
    End Sub
End Class