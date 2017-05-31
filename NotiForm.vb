Imports System.Data.SqlClient
Public Class NotiForm
    Dim sql As New sql
    Private Sub NotiForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form2.notification.Enabled = True
        If Not Form2.notification.Text = "Notification" Then
            Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Red
        Else
            Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Black
        End If
    End Sub

    Private Sub NotiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal

    End Sub
    Public Sub loadcritical()
        Try
            sql.sqlcon.Open()
            Dim sqlcmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim newstr As String = "select * from stocks_tb where status='Critical' order by costhead asc"
            sqlcmd = New SqlCommand(newstr, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "Stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "Stocks_tb"
            stocksgridview.DataSource = bs
            stocksgridview.Columns("SUPPLIER").Visible = False
            stocksgridview.Columns("COSTHEAD").Visible = False
            stocksgridview.Columns("UFACTOR").Visible = False
            stocksgridview.Columns("MONETARY").Visible = False
            stocksgridview.Columns("UNITPRICE").Visible = False
            stocksgridview.Columns("DESCRIPTION").Visible = False
            stocksgridview.Columns("UNIT").Visible = False
            stocksgridview.Columns("LOCATION").Visible = False
            stocksgridview.Columns("HEADER").Visible = False
            stocksgridview.Columns("AVEUSAGE").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadoutofstock()
        Try
            sql.sqlcon.Open()
            Dim sqlcmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim newstr As String = "select * from stocks_tb where physical<=0 order by costhead asc"
            sqlcmd = New SqlCommand(newstr, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "Stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "Stocks_tb"
            stocksgridview.DataSource = bs
            stocksgridview.Columns("SUPPLIER").Visible = False
            stocksgridview.Columns("COSTHEAD").Visible = False
            stocksgridview.Columns("UFACTOR").Visible = False
            stocksgridview.Columns("MONETARY").Visible = False
            stocksgridview.Columns("UNITPRICE").Visible = False
            stocksgridview.Columns("DESCRIPTION").Visible = False
            stocksgridview.Columns("UNIT").Visible = False
            stocksgridview.Columns("LOCATION").Visible = False
            stocksgridview.Columns("HEADER").Visible = False
            stocksgridview.Columns("AVEUSAGE").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadorderdue()
        Try
            sql.sqlcon.Open()
            Dim sqlcmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim newstr As String = "select * from trans_tb where transtype='Order' and xyzref='' and duedate<=getdate() order by duedate desc"
            sqlcmd = New SqlCommand(newstr, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            stocksgridview.DataSource = bs
            stocksgridview.Columns("xyz").Visible = False
            stocksgridview.Columns("xyzref").Visible = False

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        loadcritical()
        KryptonHeader1.Values.Heading = "Critical Status"
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        loadoutofstock()
        KryptonHeader1.Values.Heading = "Out of Stocks"
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        loadorderdue()
        KryptonHeader1.Values.Heading = "Order Due"
    End Sub
End Class