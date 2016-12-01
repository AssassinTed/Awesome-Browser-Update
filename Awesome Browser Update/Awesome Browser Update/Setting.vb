Public Class Setting
    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Homepage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.Homepage = TextBox1.Text
        MsgBox("Done")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.Homepage = ("http://www.google.com")
        TextBox1.Text = ("http://www.google.com")
        MsgBox("Done")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Visible = False
    End Sub
End Class