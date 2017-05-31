Imports System.Data.SqlClient
Public Class Form2
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql.loadstocks()
        sql.loadtransactions()
        sql.referencetb()
        Timer1.Start()
    End Sub

    Private Sub stocksgridview_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles stocksgridview.RowPostPaint
        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        e.PaintHeader(DataGridViewPaintParts.Background)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Microsoft Sans Serif", 8.0!,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)

        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        stocksgridview.ClearSelection()
        Form3.Text = "New"
        Form3.ShowDialog()
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        Form3.Text = "Edit"
        Form3.ShowDialog()
    End Sub

    Private Sub stocksgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles stocksgridview.CellClick
        If stocksgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form3.stockno.Text = stocksgridview.Item(0, e.RowIndex).Value.ToString
            Form3.supplier.Text = stocksgridview.Item(1, e.RowIndex).Value.ToString
            Form3.costhead.Text = stocksgridview.Item(2, e.RowIndex).Value.ToString
            Form3.ufactor.Text = stocksgridview.Item(3, e.RowIndex).Value.ToString
            Form3.typecolor.Text = stocksgridview.Item(4, e.RowIndex).Value.ToString
            Form3.monetary.Text = stocksgridview.Item(5, e.RowIndex).Value.ToString
            Form3.articleno.Text = stocksgridview.Item(6, e.RowIndex).Value.ToString
            Form3.unitprice.Text = stocksgridview.Item(7, e.RowIndex).Value.ToString
            Form3.description.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            Form3.qty.Text = stocksgridview.Item(9, e.RowIndex).Value.ToString
            Form3.unit.Text = stocksgridview.Item(10, e.RowIndex).Value.ToString
            Form3.location.Text = stocksgridview.Item(11, e.RowIndex).Value.ToString
            Form3.header.Text = stocksgridview.Item(12, e.RowIndex).Value.ToString
            Form3.min.Text = stocksgridview.Item(17, e.RowIndex).Value.ToString

            Form4.stockno.Text = stocksgridview.Item(0, e.RowIndex).Value.ToString
            Form4.supplier.Text = stocksgridview.Item(1, e.RowIndex).Value.ToString
            Form4.costhead.Text = stocksgridview.Item(2, e.RowIndex).Value.ToString
            Form4.typecolor.Text = stocksgridview.Item(4, e.RowIndex).Value.ToString
            Form4.monetary.Text = stocksgridview.Item(5, e.RowIndex).Value.ToString
            Form4.articleno.Text = stocksgridview.Item(6, e.RowIndex).Value.ToString
            Form4.unitprice.Text = stocksgridview.Item(7, e.RowIndex).Value.ToString
            Form4.description.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            Form4.unit.Text = stocksgridview.Item(10, e.RowIndex).Value.ToString
            Form4.location.Text = stocksgridview.Item(11, e.RowIndex).Value.ToString
            Form4.header.Text = stocksgridview.Item(12, e.RowIndex).Value.ToString
            Form4.qty.Text = stocksgridview.Item(13, e.RowIndex).Value.ToString
            Form4.allocation.Text = stocksgridview.Item(14, e.RowIndex).Value.ToString
            Form4.free.Text = stocksgridview.Item(15, e.RowIndex).Value.ToString
            Form4.order.Text = stocksgridview.Item(16, e.RowIndex).Value.ToString
            Form4.min.Text = stocksgridview.Item(17, e.RowIndex).Value.ToString

            description.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            location.Text = stocksgridview.Item(11, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub stocksgridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles stocksgridview.CellDoubleClick
        sql.srockstransactiontb(Form4.stockno.Text)
        Form4.ShowDialog()
    End Sub

    Private Sub DateTimePicker8_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker8.ValueChanged
        duedate.Text = DateTimePicker8.Text
    End Sub

    Private Sub DateTimePicker8_MouseDown(sender As Object, e As MouseEventArgs) Handles DateTimePicker8.MouseDown
        duedate.Text = DateTimePicker8.Text
    End Sub

    Private Sub CheckBox38_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox38.CheckedChanged
        If CheckBox38.Checked = True Then
            DateTimePicker8.Visible = True
            duedate.Text = DateTimePicker8.Text
        ElseIf CheckBox38.Checked = False Then
            DateTimePicker8.Visible = False
        Else
            DateTimePicker8.Value = duedate.Text
        End If
    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        If transaction.Text = "Allocation" Then
            allocationproccess()
        ElseIf transaction.Text = "Order" Then
            orderprocess()
        ElseIf transaction.Text = "Receipt" Then
            receiptprocess()
        ElseIf transaction.Text = "Return" Then
            returnprocess()
        ElseIf transaction.Text = "Supply" Then
            supplyprocess()
        ElseIf transaction.Text = "Spare" Then
            spareprocess()
        ElseIf transaction.Text = "+Adjustment" Then
            addadjustmentprocess()
        ElseIf transaction.Text = "-Adjustment" Then
            minadjustmentprocess()
        ElseIf transaction.Text = "Issue" Then
            Try
                sql.sqlcon.Open()
                Dim FINDALLOC As String = "SELECT ALLOCATION FROM REFERENCE_TB WHERE REFERENCE='" & reference.Text & "' AND STOCKNO='" & transstockno.Text & "'"
                sqlcmd = New SqlCommand(FINDALLOC, sql.sqlcon)
                Dim read As SqlDataReader = sqlcmd.ExecuteReader
                If read.HasRows = True Then
                    read.Close()
                    Dim da As New SqlDataAdapter
                    Dim ds As New DataSet
                    ds.Clear()
                    Dim bs As New BindingSource
                    da.SelectCommand = sqlcmd
                    da.Fill(ds, "reference_tb")
                    bs.DataSource = ds
                    bs.DataMember = "reference_tb"
                    currentallocation.DataBindings.Clear()
                    currentallocation.DataBindings.Add("text", bs, "allocation")
                Else
                    read.Close()
                    currentallocation.DataBindings.Clear()
                    currentallocation.Text = "0"
                End If
                sql.sqlcon.Close()
                If currentallocation.Text = "0" Then
                    issueprocess()
                Else
                    If MessageBox.Show("Issue current allocation first!
Current Allocation:  " & currentallocation.Text & "
Go to Issue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                        Exit Sub
                    End If
                    TabControl1.SelectedIndex = 3
                    issuereference.Text = reference.Text
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Public Sub allocationproccess()
        Dim allocate As Double = transqty.Text
        Dim free As Double = transfree.Text
        If allocate <= 0 Then
            MessageBox.Show("Allocate more than 0 To Continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                      transaction.Text,
                      transdate.Text,
                      duedate.Text,
                      transqty.Text,
                      reference.Text,
                      account.Text,
                      controlno.Text,
                               XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub orderprocess()
        Dim myorder As Double = transqty.Text
        If myorder <= 0 Then
        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub receiptprocess()
        Dim myreceipt As Double = transqty.Text
        If myreceipt <= 0 Then
        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub returnprocess()
        Dim myreturn As Double = transqty.Text
        If myreturn <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub supplyprocess()
        Dim mysupply As Double = transqty.Text
        If mysupply <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub spareprocess()
        Dim myspare As Double = transqty.Text
        If myspare <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub addadjustmentprocess()
        Dim myadjustment As Double = transqty.Text
        If myadjustment <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub minadjustmentprocess()
        Dim myadjustment As Double = transqty.Text
        If myadjustment <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub issueprocess()
        Dim issue As Double = transqty.Text
        Dim free As Double = transfree.Text
        Dim physical As Double = transphysical.Text
        If issue <= 0 Then

        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions()
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If
    End Sub
    Public Sub loadinputgridviews()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim loadinput As String = "Declare @transno As varchar(50) = (select max(transno) from trans_tb) select * from trans_tb where transno = @transno"
            sqlcmd = New SqlCommand(loadinput, sql.sqlcon)
            Dim da As New SqlDataAdapter
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            inputGridView.DataSource = bs
            Dim ds1 As New DataSet
            Dim bs1 As New BindingSource
            ds1.Clear()
            Dim loadstocks As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where STOCKNO = '" & transstockno.Text & "'"
            sqlcmd = New SqlCommand(loadstocks, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds1, "stocks_tb")
            bs1.DataSource = ds1
            bs1.DataMember = "stocks_tb"
            inputDataGridView1.DataSource = bs1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatetransaction(ByVal qty As String, ByVal transno As String)
        Try
            sql.sqlcon.Open()
            Dim x As String = "
DECLARE @receipt as varchar(max)=(select transno from trans_tb where xyzref='" & transno & "')
update trans_tb set qty = '" & qty & "',xyzref=@receipt where transno = '" & transno & "'
"
            sqlcmd = New SqlCommand(x, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestock(ByVal stockno As String, ByVal reference As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Allocation')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Return')+0
                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Supply')+0
                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Spare')+0
                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='+Adjustment')+0
                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='-Adjustment')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
            update stocks_tb set 
                                    
                                    physical=(QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment),
                                    allocation = @allocation-@issueallocation,
                                    free=(((QTY+@totalreceipt+@return+@addadjustment)-@allocation))-(@issue+@minadjustment),
                                    stockorder=@order-@receiptorder,
                                    issue=@totalissue
                                    where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()


            Dim bny As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Allocation')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
                              
update reference_tb set 

                                    allocation=@allocation-@issueallocation,
                                    stockorder=@order-@receiptorder,
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "'"
            sqlcmd = New SqlCommand(bny, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

            'Dim NEWSTR As String = "
            '                        declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Allocation')+0
            '                        declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Order')+0
            '                        declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Receipt')+0
            '                        declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Issue')+0

            'update reference_tb set 

            '                        allocation=@allocation-@issue,
            '                        stockorder=@order-@receipt,
            '                        TOTALRECEIPT=@receipt,
            '                        totalissue=@issue
            '                        where stockno='" & stockno & "' and reference='" & reference & "'"
            'sqlcmd = New SqlCommand(NEWSTR, sql.sqlcon)
            'sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub refsource_TextChanged(sender As Object, e As EventArgs) Handles refsource.TextChanged
        sql.loadreference(refsource.Text)
    End Sub

    Private Sub transcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles transcosthead.MouseDown
        transtypecolor.Text = ""
        transarticleno.Text = ""
        transdescription.Text = ""
        transphysical.Text = 0
        transfree.Text = 0
        currentallocation.Text = 0
        sql.costheadinput()
    End Sub

    Private Sub transtypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles transtypecolor.MouseDown
        transarticleno.Text = ""
        transarticleno.Text = ""
        transdescription.Text = ""
        transphysical.Text = 0
        transfree.Text = 0
        currentallocation.Text = 0
        sql.typecolorinput(transcosthead.Text)
    End Sub

    Private Sub transarticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles transarticleno.MouseDown
        transdescription.Text = ""
        transphysical.Text = 0
        transfree.Text = 0
        currentallocation.Text = 0
        sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
    End Sub

    Private Sub receiptcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles receiptcosthead.MouseDown
        sql.costheadreceipt
    End Sub

    Private Sub receipttypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles receipttypecolor.MouseDown
        sql.typecolorreceipt(receiptcosthead.Text)
    End Sub

    Private Sub receiptarticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles receiptarticleno.MouseDown
        sql.articlenoreceipt(receiptcosthead.Text, receipttypecolor.Text)
    End Sub

    Private Sub receiptreference_MouseDown(sender As Object, e As MouseEventArgs) Handles receiptreference.MouseDown
        sql.referencereceipt()
    End Sub

    Private Sub KryptonButton6_Click(sender As Object, e As EventArgs) Handles KryptonButton6.Click
        sql.searchreference(receiptreference.Text, receiptstockno.Text)
    End Sub

    Private Sub receiptGridView_SelectionChanged(sender As Object, e As EventArgs) Handles receiptGridView.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = receiptGridView.SelectedRows
        receiptorder.Text = 0

        For Each selecteditems As DataGridViewRow In selecteditem
            receiptorder.Text = selecteditems.Cells("qty").Value.ToString
            receiptstockno.Text = selecteditems.Cells("stockno").Value.ToString
            receipttransno.Text = selecteditems.Cells("transno").Value.ToString
            sql.selectsubreference(receiptstockno.Text)
        Next
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        Dim myreceipt As Double = receiptqty.Text
        Dim order As Double = receiptorder.Text
        If myreceipt <= 0 Then
            MessageBox.Show("receipt more than 0 to continue", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ElseIf myreceipt > order Then
            MessageBox.Show("insufficient order", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            Dim transaction = "Receipt"
            Dim duedate As String = ""
            Dim account As String = ""
            Dim controlno As String = ""
            Dim XYZ As String = "Order"
            Dim remarks As String = ""
            sql.newtransaction(receiptstockno.Text,
                   transaction,
                   transdate.Text,
                   duedate,
                   receiptqty.Text,
                  receiptreference.Text,
                   account,
                   controlno, XYZ, receipttransno.Text, remarks)
            updatetransaction(receiptqty.Text, receipttransno.Text)
            updatestock(receiptstockno.Text, receiptreference.Text)
            sql.loadstocks()
            sql.loadtransactions()
            sql.searchreference(receiptreference.Text, receiptstockno.Text)
        End If
    End Sub

    Private Sub issuereference_MouseDown(sender As Object, e As MouseEventArgs) Handles issuereference.MouseDown
        sql.referenceissue()
    End Sub

    Private Sub issuecosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles issuecosthead.MouseDown
        sql.costheadissue()
    End Sub

    Private Sub issuetypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles issuetypecolor.MouseDown
        sql.typecolorissue(issuecosthead.Text)
    End Sub

    Private Sub issuearticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles issuearticleno.MouseDown
        sql.articlenoissue(issuecosthead.Text, issuetypecolor.Text)
    End Sub

    Private Sub KryptonButton7_Click(sender As Object, e As EventArgs) Handles KryptonButton7.Click
        sql.searchreferenceissue(issuereference.Text, issuestockno.Text)
    End Sub

    Private Sub issueDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles issueDataGridView.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = issueDataGridView.SelectedRows
        issueallocation.Text = 0

        For Each selecteditems As DataGridViewRow In selecteditem
            issueallocation.Text = selecteditems.Cells("allocation").Value.ToString
            issuestockno.Text = selecteditems.Cells("stockno").Value.ToString
            sql.selectsubreferenceissue(issuestockno.Text)
        Next
    End Sub

    Private Sub KryptonButton8_Click(sender As Object, e As EventArgs) Handles KryptonButton8.Click
        Dim myissue As Double = issueqty.Text
        Dim allocate As Double = issueallocation.Text
        Dim physical As Double = issuephysical.Text
        If myissue <= 0 Then
            MessageBox.Show("issue more than 0 to continue", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ElseIf myissue > allocate Then
            MessageBox.Show("insufficient allocation", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            Dim duedate As String = ""
            Dim transaction = "Issue"

            Dim XYZ As String = "Allocation"
            Dim xyzref As String = ""
            sql.newtransaction(issuestockno.Text,
                   transaction,
                   transdate.Text,
                   duedate,
                   issueqty.Text,
                 issuereference.Text,
                   issueaccount.Text,
                   issuecontrolno.Text, XYZ, xyzref, issueremarks.Text)
            updatestock(issuestockno.Text, issuereference.Text)
            sql.loadstocks()
            sql.loadtransactions()
            sql.searchreferenceissue(issuereference.Text, issuestockno.Text)
        End If
    End Sub

    Private Sub receiptreference_TextChanged(sender As Object, e As EventArgs) Handles receiptreference.TextChanged
        sql.selectreceiptreferencerecord(receiptreference.Text)
    End Sub

    Private Sub issuereference_TextChanged(sender As Object, e As EventArgs) Handles issuereference.TextChanged
        sql.selectissuereferencerecord(issuereference.Text)
    End Sub

    Private Sub KryptonButton9_Click(sender As Object, e As EventArgs) Handles KryptonButton9.Click
        issueDataGridView.Visible = True
        KryptonGroup5.Visible = False
    End Sub

    Private Sub issueDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles issueDataGridView.CellDoubleClick
        If issueDataGridView.RowCount > 0 And e.RowIndex >= 0 Then
            issueDataGridView.Visible = False
            KryptonGroup5.Visible = True
        End If
    End Sub

    Private Sub issueDataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles issueDataGridView1.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = issueDataGridView1.SelectedRows
        issuephysical.Text = 0
        For Each x As DataGridViewRow In selecteditem
            issuephysical.Text = x.Cells("Physical").Value.ToString
        Next
    End Sub

    Private Sub KryptonButton11_Click(sender As Object, e As EventArgs) Handles KryptonButton11.Click
        Dim search As String
        Dim selection As String = " a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
B.ARTICLENO,
B.DESCRIPTION,
a.TRANSTYPE,
a.TRANSDATE,
a.DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.xyz
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno"
        If all.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where  a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search)
        ElseIf all.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & ""
            sql.searchtransaction(search)
        End If

        If thisdate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf thisdate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where format(a.TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            sql.searchtransaction(search)
        End If

        If before.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf before.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where format(a.TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            sql.searchtransaction(search)
        End If

        If after.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        ElseIf after.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where format(a.TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            sql.searchtransaction(search)
        End If

        If tomydate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        ElseIf tomydate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where format(a.TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search)
        End If
    End Sub

    Private Sub transgridview_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles transgridview.RowPostPaint
        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        e.PaintHeader(DataGridViewPaintParts.Background)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Microsoft Sans Serif", 8.0!,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)

        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub KryptonButton10_Click(sender As Object, e As EventArgs) Handles KryptonButton10.Click
        sql.loadtransactions()
    End Sub

    Private Sub issueaccount_MouseDown(sender As Object, e As MouseEventArgs) Handles issueaccount.MouseDown
        sql.loadaccount
    End Sub

    Private Sub transgridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles transgridview.CellDoubleClick
        If transgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            sql.selecttransrec(Form5.transno.Text)
            sql.selectreference(Form5.stockno.Text, Form5.reference.Text)
            Form5.ShowDialog()
        End If
    End Sub

    Private Sub transgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles transgridview.CellClick
        If transgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.transno.Text = transgridview.Item(0, e.RowIndex).Value.ToString
            Form5.stockno.Text = transgridview.Item(1, e.RowIndex).Value.ToString
            Form5.reference.Text = transgridview.Item(10, e.RowIndex).Value.ToString
            Form5.XYZ.Text = transgridview.Item(13, e.RowIndex).Value.ToString
            description.Text = transgridview.Item(5, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub transgridview_MouseDown(sender As Object, e As MouseEventArgs) Handles transgridview.MouseDown
        If e.Button = MouseButtons.Right Then
            transactionmenustrip.Show(transgridview, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub transgridview_SelectionChanged(sender As Object, e As EventArgs) Handles transgridview.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = transgridview.SelectedRows
        Form6.transno.Items.Clear()
        For Each item As DataGridViewRow In selecteditem
            Dim x As String = item.Cells("transno").Value.ToString
            Form6.transno.Items.Add(x)
        Next
    End Sub

    Private Sub TransDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransDateToolStripMenuItem.Click
        Form6.KryptonLabel1.Text = "Edit Trans date"
        Form6.ShowDialog()
    End Sub

    Private Sub DueDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DueDateToolStripMenuItem.Click
        Form6.KryptonLabel1.Text = "Edit Due date"
        Form6.ShowDialog()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Or TabControl1.SelectedIndex = 2 Or TabControl1.SelectedIndex = 3 Or TabControl1.SelectedIndex = 5 Then
            description.Clear()
            location.Clear()
        ElseIf TabControl1.SelectedIndex = 0 Then
            description.Visible = True
            location.Visible = True
            KryptonLabel4.Visible = True
            KryptonLabel5.Visible = True
        ElseIf TabControl1.SelectedIndex = 4 Then
            description.Visible = True
            location.Visible = False
            KryptonLabel4.Visible = True
            KryptonLabel5.Visible = False
        End If
    End Sub

    Private Sub transaction_TextChanged(sender As Object, e As EventArgs) Handles transaction.TextChanged
        If transaction.Text = "Issue" Or transaction.Text = "Return" Or transaction.Text = "Spare" Or transaction.Text = "Supply" Or
            transaction.Text = "+Adjustment" Or transaction.Text = "-Adjustment" Then
            KryptonLabel17.Visible = True
            controlno.Visible = True
            KryptonLabel16.Visible = True
            account.Visible = True
            KryptonLabel49.Visible = True
            currentallocation.Visible = True
            KryptonLabel50.Visible = True
            remarks.Visible = True
        Else
            KryptonLabel17.Visible = False
            controlno.Visible = False
            controlno.Text = ""
            KryptonLabel16.Visible = False
            account.Visible = False
            account.Text = ""
            KryptonLabel49.Visible = False
            currentallocation.Visible = False
            currentallocation.Text = 0
            KryptonLabel50.Visible = False
            remarks.Visible = False
            remarks.Text = ""
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        KryptonLabel44.Text = TimeOfDay
    End Sub

    Private Sub referenceDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles referenceDataGridView.SelectionChanged
        refcombo.Items.Clear()
        refstock.Items.Clear()
        Dim selecteditems As DataGridViewSelectedRowCollection = referenceDataGridView.SelectedRows
        Dim x As String
        Dim y As String
        For Each selecteditem As DataGridViewRow In selecteditems
            x = selecteditem.Cells("reference").Value.ToString
            y = selecteditem.Cells("stockno").Value.ToString
            refcombo.Items.Add(x)
            refstock.Items.Add(y)
        Next

    End Sub

    Private Sub KryptonButton13_Click(sender As Object, e As EventArgs) Handles KryptonButton13.Click
        sql.referencetb()
    End Sub

    Private Sub KryptonButton14_Click(sender As Object, e As EventArgs) Handles KryptonButton14.Click
        If MessageBox.Show("Do you want to delete this record", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        For i As Integer = 0 To refcombo.Items.Count - 1
            Dim str As String = refcombo.Items(i).ToString
            Dim stockno As String = refstock.Items(i).ToString
            sql.removefromref(str, stockno)
        Next
        sql.referencetb()
    End Sub

    Private Sub KryptonButton12_Click(sender As Object, e As EventArgs) Handles KryptonButton12.Click
        Dim where As String = ""
        Dim a As String = reffromreference.Text
        Dim b As String = referencecosthead.Text
        Dim c As String = referencetypecolor.Text
        Dim d As String = referencearticleno.Text
        'a
        If Not a = "" And b = "" And c = "" And d = "" Then
            where = "where a.reference='" & a & "'"
        ElseIf Not a = "" And Not b = "" And c = "" And d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "'"
        ElseIf Not a = "" And b = "" And Not c = "" And d = "" Then
            where = "where a.reference='" & a & "' and b.typecolor='" & c & "'"
        ElseIf Not a = "" And b = "" And c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.articleno='" & d & "'"
            'b
        ElseIf a = "" And Not b = "" And c = "" And d = "" Then
            where = "where b.costhead='" & b & "'"
        ElseIf a = "" And Not b = "" And Not c = "" And d = "" Then
            where = "where b.costhead='" & b & "' and b.typecolor='" & c & "'"
        ElseIf a = "" And Not b = "" And c = "" And Not d = "" Then
            where = "where b.costhead='" & b & "' and b.articleno='" & d & "'"
            'c
        ElseIf a = "" And b = "" And Not c = "" And d = "" Then
            where = "where b.typecolor='" & c & "'"
        ElseIf a = "" And b = "" And Not c = "" And Not d = "" Then
            where = "where b.typecolor='" & c & "' and b.articleno='" & d & "'"
            'd
        ElseIf a = "" And b = "" And c = "" And Not d = "" Then
            where = "where b.articleno='" & d & "'"
            'triple
        ElseIf Not a = "" And Not b = "" And Not c = "" And d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "' and b.typecolor='" & c & "'"
        ElseIf Not a = "" And Not b = "" And c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "' and b.articleno='" & d & "'"
        ElseIf Not a = "" And b = "" And Not c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.typecolor='" & c & "' and b.articleno='" & d & "'"
        ElseIf a = "" And Not b = "" And Not c = "" And Not d = "" Then
            where = "where b.costhead='" & b & "' and b.typecolor='" & c & "' and b.articleno='" & d & "'"
            'quadro
        ElseIf Not a = "" And Not b = "" And Not c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "' and b.typecolor='" & c & "' and b.articleno='" & d & "'"
        ElseIf a = "" And b = "" And c = "" And d = "" Then
            where = ""
        End If
        sql.refsearch(where)
    End Sub

    Private Sub notification_Click(sender As Object, e As EventArgs) Handles notification.Click
        sql.sqlcon.Open()
        sql.notifycritical()
        sql.sqlcon.Close()

        If Not notification.Text = "Notification" Then
            NotiForm.Show()
            NotiForm.MdiParent = Form1
            notification.StateCommon.Content.ShortText.Color1 = Color.Black
            notification.Enabled = False
        Else
            MessageBox.Show("0 Result Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub stocksgridview_MouseDown(sender As Object, e As MouseEventArgs) Handles stocksgridview.MouseDown
        If stocksgridview.RowCount >= 0 Then
            If e.Button = MouseButtons.Right Then
                PhasedoutForm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub stocksgridview_SelectionChanged(sender As Object, e As EventArgs) Handles stocksgridview.SelectionChanged
        stocksStocksno.Items.Clear()
        Dim x As String = ""
        Dim selecteditems As DataGridViewSelectedRowCollection = stocksgridview.SelectedRows
        For Each selecteditem As DataGridViewRow In selecteditems
            x = selecteditem.Cells("stockno").Value.ToString
            stocksStocksno.Items.Add(x)
        Next
    End Sub

    Private Sub costheadsearch_MouseDown(sender As Object, e As MouseEventArgs) Handles costheadsearch.MouseDown
        sql.loadcostheadsearch()
        typecolorsearch.Text = ""
        articlenosearch.Text = ""
    End Sub

    Private Sub typecolorsearch_MouseDown(sender As Object, e As MouseEventArgs) Handles typecolorsearch.MouseDown
        sql.loadtypecolorsearch(costheadsearch.Text)
        articlenosearch.Text = ""
    End Sub

    Private Sub articlenosearch_MouseDown(sender As Object, e As MouseEventArgs) Handles articlenosearch.MouseDown
        sql.loadarticlesearch(costheadsearch.Text, typecolorsearch.Text)
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim phasedout As String
        If phasedoutsearch.Checked = True Then
            phasedout = "yes"
        Else
            phasedout = ""
        End If

        Dim search As String = ""
        Dim fields As String = ""
        If Not costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
            fields = "costhead ='" & costheadsearch.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
            fields = "costhead ='" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
            fields = "costhead ='" & costheadsearch.Text & "' and articleno='" & articlenosearch.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "costhead ='" & costheadsearch.Text & "' and articleno='" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
            fields = "typecolor ='" & typecolorsearch.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
            fields = "typecolor ='" & typecolorsearch.Text & "' and articleno = '" & articlenosearch.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "typecolor ='" & typecolorsearch.Text & "' and status = '" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
            fields = "articleno ='" & articlenosearch.Text & "'  and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "articleno ='" & articlenosearch.Text & "' and status = '" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "status = '" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
            fields = "costhead = '" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and articleno='" & articlenosearch.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "costhead = '" & costheadsearch.Text & "' and articleno='" & articlenosearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "costhead = '" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "typecolor='" & typecolorsearch.Text & "' and articleno = '" & articlenosearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
            fields = "costhead = '" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and articleno = '" & articlenosearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
            fields = " phasedout = '" & phasedout & "'"
        End If
        search = "select * from stocks_tb where " & fields & " order by costhead asc"
        sql.searchstocks(search)
    End Sub

    Private Sub KryptonButton15_Click(sender As Object, e As EventArgs) Handles KryptonButton15.Click
        sql.loadstocks()
    End Sub

    Private Sub account_MouseDown(sender As Object, e As MouseEventArgs) Handles account.MouseDown
        sql.loadaccount()
    End Sub

    Private Sub referencecosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles referencecosthead.MouseDown
        referencetypecolor.Text = ""
        referencearticleno.text = ""
        findcostheadforref()
    End Sub
    Public Sub findcostheadforref()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from STOCKS_TB where STOCKNO in (select stockno from reference_tb)"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "STOCKS_TB")
            bs.DataSource = ds
            bs.DataMember = "STOCKS_TB"
            referencecosthead.DataSource = bs
            referencecosthead.DisplayMember = "costhead"
            referencecosthead.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub referencetypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles referencetypecolor.MouseDown
        referencearticleno.text = ""
        findtypecolorforref(referencecosthead.Text)
    End Sub
    Public Sub findtypecolorforref(ByVal costhead As String)
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from STOCKS_TB where costhead= '" & costhead & "' and STOCKNO in (select stockno from reference_tb)"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "STOCKS_TB")
            bs.DataSource = ds
            bs.DataMember = "STOCKS_TB"
            referencetypecolor.DataSource = bs
            referencetypecolor.DisplayMember = "typecolor"
            referencetypecolor.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub referencearticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles referencearticleno.MouseDown
        findarticlenoforref(referencecosthead.Text, referencetypecolor.Text)
    End Sub
    Public Sub findarticlenoforref(ByVal costhead As String, ByVal typecolor As String)
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct articleno from STOCKS_TB where costhead= '" & costhead & "' and typecolor='" & typecolor & "' and STOCKNO in (select stockno from reference_tb)"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "STOCKS_TB")
            bs.DataSource = ds
            bs.DataMember = "STOCKS_TB"
            referencearticleno.DataSource = bs
            referencearticleno.DisplayMember = "articleno"
            referencearticleno.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton16_Click(sender As Object, e As EventArgs) Handles KryptonButton16.Click
        sql.alltransaction()
        AllTrans.ShowDialog()
    End Sub

    Private Sub referenceDataGridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles referenceDataGridView.RowPostPaint
        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        e.PaintHeader(DataGridViewPaintParts.Background)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Microsoft Sans Serif", 8.0!,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)

        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub KryptonButton17_Click(sender As Object, e As EventArgs) Handles KryptonButton17.Click
        sql.loadstocks()
        sql.loadtransactions()
        sql.referencetb()
    End Sub
End Class