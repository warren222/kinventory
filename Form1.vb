Public Class Form1
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Form2.Show()
        Form2.MdiParent = Me
    End Sub
End Class
