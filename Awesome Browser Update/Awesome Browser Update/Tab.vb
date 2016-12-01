Imports Awesomium.Core

Public Class Tab
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Home
        WebControl1.Source = New Uri(My.Settings.Homepage)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        'Settings
        Setting.Show()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Tab_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Load Web Page
        WebControl1.Source = New Uri(My.Settings.Homepage)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Back
        If WebControl1.CanGoBack Then
            WebControl1.GoBack()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Forward
        If WebControl1.CanGoForward Then
            WebControl1.GoForward()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        'Enter
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text.Contains(".com") Or TextBox1.Text.Contains(".net") Or TextBox1.Text.Contains(".org") Then
                Try
                    WebControl1.Source = New Uri(TextBox1.Text)
                Catch ex As System.UriFormatException
                    WebControl1.Source = New Uri("http://" + TextBox1.Text)
                    TextBox1.Text = ("http://" + TextBox1.Text)
                End Try
            Else : WebControl1.Source = New Uri("https://www.google.gr/webhp#q=" & TextBox1.Text)

            End If
        End If
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles WebControl1.ShowCreatedWebView

    End Sub

    Private Sub WebControl1_LoadingFrameComplete(sender As Object, e As FrameEventArgs) Handles WebControl1.LoadingFrameComplete
        'Load Complete & Load Disable
        Combo.Text = "R"
        PictureBox1.Visible = False
        Parent.Text = WebControl1.Title
        TextBox1.Text = WebControl1.Source.ToString
    End Sub

    Private Sub WebControl1_LoadingFrame(sender As Object, e As LoadingFrameEventArgs) Handles WebControl1.LoadingFrame
        'Visibility of Load
        Combo.Text = "X"
        PictureBox1.Visible = True
    End Sub

    Private Sub NewTAbToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTAbToolStripMenuItem.Click
        'Add Tab
        Dim tab As New TabPage
        Dim newtab As New Tab
        newtab.Show()
        newtab.Dock = DockStyle.Fill
        newtab.TopLevel = False
        tab.Controls.Add(newtab)
        Form1.TabControl1.TabPages.Add(tab)
        Form1.TabControl1.SelectedTab = tab
    End Sub

    Private Sub RemoveTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTabToolStripMenuItem.Click
        If Form1.TabControl1.TabCount = 1 Then
            Dim tab As New TabPage
            Dim newtab As New Tab
            newtab.Show()
            newtab.Dock = DockStyle.Fill
            newtab.TopLevel = False
            tab.Controls.Add(newtab)
            Form1.TabControl1.TabPages.Add(tab)
            Form1.TabControl1.SelectedTab = tab
            Form1.TabControl1.SelectedTab.Dispose()
        Else : Form1.Tabcontrol1.SelectedTab.Dispose()


        End If
    End Sub

    Private Sub Combo_Click(sender As Object, e As EventArgs) Handles Combo.Click
        If WebControl1.IsNavigating Then
            WebControl1.Stop()
            PictureBox1.Visible = False
            Parent.Text = "Navigation Stop"
            Combo.Text = "R"

        End If
        If Not WebControl1.IsNavigating Then
            WebControl1.Reload(ignoreCache:=True)
            If TextBox1.Text.Contains(".com") Or TextBox1.Text.Contains(".net") Or TextBox1.Text.Contains(".org") Then
                Try
                    WebControl1.Source = New Uri(TextBox1.Text)
                Catch ex As System.UriFormatException
                    WebControl1.Source = New Uri("http://" + TextBox1.Text)
                    TextBox1.Text = ("http://" + TextBox1.Text)
                End Try
            Else : WebControl1.Source = New Uri("https://www.google.gr/webhp#q=" & TextBox1.Text)

            End If

        End If
    End Sub

    Private Sub TheProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TheProgramToolStripMenuItem.Click
        MsgBox("This is a average web browser...with no any original feature...thats it. ")
    End Sub

    Private Sub TheCreatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TheCreatorToolStripMenuItem.Click
        MsgBox("This program is named by Theodore Giannakidis,a dude that wached a tutorial and made this program...thats it.")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ThingsToFixToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThingsToFixToolStripMenuItem.Click
        MsgBox("First of all...there may be other bugs that i didnt noticed...To begin with,there is a bug that not allow to press enter when in webcontoller(right on the google search).Second,there is a small bug in the reload button,and in the url.")
    End Sub
End Class