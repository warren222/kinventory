Imports System.Data.SqlClient
Public Class Form6
    Dim sql As New sql
    Private Sub cancelorderbtn_Click(sender As Object, e As EventArgs) Handles cancelorderbtn.Click
        If KryptonLabel1.Text = "Edit Trans date" Then
            For i As Integer = 0 To transno.Items.Count - 1
                Dim trno As String = transno.Items(i)
                Dim str As String = "update trans_tb set transdate='" & transdate.Text & "' where transno = '" & trno & "'"
                update(str)
            Next
            sql.loadtransactions()
        ElseIf KryptonLabel1.Text = "Edit Due date" Then
            For i As Integer = 0 To transno.Items.Count - 1
                Dim trno As String = transno.Items(i)
                Dim str As String = "update trans_tb set duedate='" & transdate.Text & "' where transno = '" & trno & "'"
                update(str)
            Next
            sql.loadtransactions()
        Else
        End If
    End Sub
    Public Sub update(ByVal str As String)
        Try
            Dim sqlcmd As New SqlCommand
            sql.sqlcon.Open()
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub
End Class