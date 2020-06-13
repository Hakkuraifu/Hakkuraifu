Public Class Settings

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = My.Computer.Info.OSFullName

        If Label6.Text = My.Settings.Key Then
            Setup.Close()
            Home.Show()
            Me.Close()
        End If
    End Sub

    Private Sub HT_CheckedChanged(sender As Object, e As EventArgs) Handles HT.CheckedChanged
        BT.BackColor = Color.FromArgb(40, 22, 54)
        PT1.BackColor = Color.FromArgb(80, 0, 115)
        PT2.BackColor = Color.FromArgb(80, 0, 115)
        PT3.BackColor = Color.FromArgb(80, 0, 115)
        L.ForeColor = Color.White
        B.ForeColor = Color.Orchid
        Panel1.BackColor = Color.FromArgb(70, 0, 115)
        Me.Refresh()
    End Sub

    Private Sub DT_CheckedChanged(sender As Object, e As EventArgs) Handles DT.CheckedChanged
        BT.BackColor = Color.FromArgb(0, 0, 0)
        PT1.BackColor = Color.FromArgb(36, 36, 36)
        PT2.BackColor = Color.FromArgb(36, 36, 36)
        PT3.BackColor = Color.FromArgb(36, 36, 36)
        L.ForeColor = Color.White
        B.ForeColor = Color.Orchid
        Panel1.BackColor = Color.FromArgb(26, 36, 36)
        Me.Refresh()
    End Sub

    Private Sub WT_CheckedChanged(sender As Object, e As EventArgs) Handles WT.CheckedChanged
        BT.BackColor = Color.FromArgb(255, 255, 255)
        PT1.BackColor = Color.FromArgb(191, 191, 191)
        PT2.BackColor = Color.FromArgb(191, 191, 191)
        PT3.BackColor = Color.FromArgb(191, 191, 191)
        L.ForeColor = Color.Black
        B.ForeColor = Color.Purple
        Panel1.BackColor = Color.FromArgb(180, 191, 191)
        Me.Refresh()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        MsgBox("You maybe have to restart the software if you have apply a theme for fix graphic bug", MsgBoxStyle.Information, "Hakkuraifu")

        Home.Hide()
        Me.Hide()
        Home.Refresh()
        Wait.Show()

        Home.BackColor = BT.BackColor
        Home.ForeColor = L.ForeColor
        Home.Panel1.BackColor = PT1.BackColor
        Home.Panel2.BackColor = PT2.BackColor
        Home.Panel3.BackColor = PT3.BackColor
        Home.Panel5.BackColor = Panel1.BackColor
        Home.Panel1.ForeColor = L.ForeColor
        Home.Panel2.ForeColor = L.ForeColor
        Home.Panel3.ForeColor = L.ForeColor
        Home.Panel5.ForeColor = L.ForeColor
        Home.Button3.ForeColor = B.ForeColor
        Home.Button2.ForeColor = B.ForeColor
        Home.Panel4.BackColor = Panel1.BackColor
        Home.Panel4.ForeColor = L.ForeColor
        Home.GroupBox1.ForeColor = L.ForeColor
        Home.GroupBox2.ForeColor = L.ForeColor
        Home.GroupBox3.ForeColor = L.ForeColor

        My.Settings.BT = ColorTranslator.ToHtml(BT.BackColor)
        My.Settings.PT1 = ColorTranslator.ToHtml(PT1.BackColor)
        My.Settings.L = ColorTranslator.ToHtml(L.ForeColor)
        My.Settings.Button = ColorTranslator.ToHtml(B.ForeColor)
        My.Settings.B = ColorTranslator.ToHtml(Panel1.BackColor)
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            PT3.BackColor = ColorDialog1.Color
            PT1.BackColor = ColorDialog1.Color
            PT2.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ColorDialog2.ShowDialog = DialogResult.OK Then
            L.ForeColor = ColorDialog2.Color
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ColorDialog3.ShowDialog = DialogResult.OK Then
            B.ForeColor = ColorDialog3.Color
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ColorDialog4.ShowDialog = DialogResult.OK Then
            BT.BackColor = ColorDialog4.Color
            Panel1.BackColor = ColorDialog4.Color
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Port = InputBox("Put you'r new port number here", "Hakkuraifu", My.Settings.Port)
        My.Settings.Port = Port
        My.Settings.Save()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub
End Class