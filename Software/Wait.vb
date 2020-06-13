Public Class Wait
    Private Sub Wait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Sub showform()
        Me.Close()
        Home.Show()
        Settings.Show()
    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        System.Threading.Thread.Sleep(50)
        Timer1.Stop()
        showform()
    End Sub
End Class