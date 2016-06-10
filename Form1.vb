Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Navigate(TextBox1.Text)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        RichTextBox1.Text = WebBrowser1.DocumentText
        Dim file As System.IO.StreamWriter
        Dim filename = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
        System.IO.Directory.CreateDirectory("C:\\WebSourceBrowser")
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\\WebSourceBrowser\\" + filename + ".html", True)
        file.WriteLine(WebBrowser1.DocumentText)
        file.Close()
        'MsgBox("CMDLINE is:  " + CMDLINE)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'WebBrowser1.Navigate(TextBox1.Text)
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        'Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim CMDLINE = ("NO")
        For Each arg As String In My.Application.CommandLineArgs
            'CMDLINE = ("YES")
            Me.Hide()
            WebBrowser1.Navigate(arg)
        Next
    End Sub
End Class
