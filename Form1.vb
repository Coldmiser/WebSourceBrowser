Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Navigate(TextBox1.Text)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        RichTextBox1.Text = WebBrowser1.DocumentText
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'WebBrowser1.Navigate(TextBox1.Text)
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim file As System.IO.StreamWriter
        Dim filename = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\\WebSourceBrowser\\" + filename + ".html", True)
        file.WriteLine(RichTextBox1.Text)
        file.Close()
        'Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each arg As String In My.Application.CommandLineArgs
            Me.Hide()
            WebBrowser1.Navigate(arg)

            'Select Case Trim(LCase(arg))
            'Case "/?"
            'MsgBox("Usage:  one\ntwo\hthree\hfour\tfive\n")
            'Application.Exit()
            'End Select
        Next
    End Sub
End Class
