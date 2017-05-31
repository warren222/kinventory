Imports System.Data.SqlClient
Public Class PhasedoutForm
    Dim sql As New sql
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
            Dim y As String = Form2.stocksStocksno.Items(i).ToString
            markphasedout(y)
        Next
        sql.loadstocks()
    End Sub
    Public Sub markphasedout(ByVal x As String)
        Try
            Dim sqlcmd As New SqlCommand
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set phasedout = '" & phasedout.Text & "' where stockno = '" & x & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class