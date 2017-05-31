Imports System.Data.SqlClient
Public Class Form5
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Private Sub referencegridview_SelectionChanged(sender As Object, e As EventArgs) Handles referencegridview.SelectionChanged



    End Sub
    Public Sub GETBALANCEALLOCISSUE(ByVal stock As String, ByVal ref As String, ByVal xyz As String)
        Try
            sql.sqlcon.Open()
            Dim x As String = "     declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Allocation')+0
                                            declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
          "
            Dim allocationstr As String = "declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Allocation')+0
        select @allocation from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Allocation'"
            sqlcmd = New SqlCommand(allocationstr, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                REFALLOC.Text = read(0).ToString
            End While
            read.Close()

            Dim issuestr As String = "declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
        select @issueallocation AS XA from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation'"
            sqlcmd = New SqlCommand(issuestr, sql.sqlcon)
            Dim read2 As SqlDataReader = sqlcmd.ExecuteReader
            While read2.Read
                REFISSUE.Text = read2(0).ToString
            End While
            read2.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonGroup1_Panel_Paint(sender As Object, e As PaintEventArgs) Handles KryptonGroup1.Panel.Paint

    End Sub

    Private Sub KryptonDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles KryptonDateTimePicker1.ValueChanged
        duedate.Text = KryptonDateTimePicker1.Text
    End Sub

    Private Sub KryptonDateTimePicker1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonDateTimePicker1.MouseDown
        duedate.Text = KryptonDateTimePicker1.Text
    End Sub

    Private Sub DateTimePicker9_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker9.ValueChanged
        transdate.Text = DateTimePicker9.Text
    End Sub

    Private Sub DateTimePicker9_MouseDown(sender As Object, e As MouseEventArgs) Handles DateTimePicker9.MouseDown
        transdate.Text = DateTimePicker9.Text
    End Sub

    Private Sub KryptonCheckButton1_CheckedChanged(sender As Object, e As EventArgs) Handles KryptonCheckButton1.CheckedChanged
        If KryptonCheckButton1.Checked = True Then
            KryptonDateTimePicker1.Visible = True
            duedate.Text = KryptonDateTimePicker1.Text
        ElseIf KryptonCheckButton1.Checked = False Then
            KryptonDateTimePicker1.Visible = False
        Else
            KryptonDateTimePicker1.Value = duedate.Text
        End If
    End Sub

    Private Sub CheckBox39_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox39.CheckedChanged
        If CheckBox39.Checked = True Then
            DateTimePicker9.Visible = True
            transdate.Text = DateTimePicker9.Text
        ElseIf CheckBox39.Checked = False Then
            DateTimePicker9.Visible = False
        Else
            DateTimePicker9.Value = transdate.Text
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        REFALLOC.Text = 0
        REFISSUE.Text = 0
        minadj.Text = 0
        KryptonLabel23.Text = "Minimum Qty"
        Timer1.Start()
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        sql.updatetransdates(transno.Text, transdate.Text, duedate.Text, qty.Text, xyzref.Text)
        updatestock(stockno.Text, reference.Text)
        sql.loadtransactions()
        sql.selectreference(stockno.Text, reference.Text)
        KryptonButton3.PerformClick()
        Form2.KryptonButton17.PerformClick()
    End Sub
    Public Sub updatestock(ByVal stockno As String, ByVal reference As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
                                    Declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Allocation')+0
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub


    Private Sub transtype_TextChanged(sender As Object, e As EventArgs) Handles transtype.TextChanged
        'If transtype.Text = "Allocation" Then
        '    deallocate.Enabled = True
        '    deallocatebtn.Enabled = True
        '    cancelorder.Enabled = False
        '    cancelorderbtn.Enabled = False
        'ElseIf transtype.Text = "Order" Then
        '    deallocate.Enabled = False
        '    deallocatebtn.Enabled = False
        '    cancelorder.Enabled = True
        'cancelorderbtn.Enabled = True
        'Else
        '    deallocate.Enabled = False
        '    deallocatebtn.Enabled = False
        '    cancelorder.Enabled = False
        '    cancelorderbtn.Enabled = False
        If transtype.Text = "Order" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Order" And Not xyzref.Text = "" Then
            qty.Enabled = False
        ElseIf transtype.Text = "Receipt" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Receipt" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Allocation" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Allocation" And Not xyzref.Text = "" Then
            qty.Enabled = False
        ElseIf transtype.Text = "Issue" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Issue" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Return" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Return" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Supply" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Supply" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Spare" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Spare" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "+Adjustment" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "+Adjustment" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "-Adjustment" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "-Adjustment" And Not xyzref.Text = "" Then
            qty.Enabled = True
        End If
    End Sub
    Private Sub xyzref_TextChanged(sender As Object, e As EventArgs) Handles xyzref.TextChanged
        If transtype.Text = "Order" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Order" And Not xyzref.Text = "" Then
            qty.Enabled = False
        ElseIf transtype.Text = "Receipt" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Receipt" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Allocation" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Allocation" And Not xyzref.Text = "" Then
            qty.Enabled = False
        ElseIf transtype.Text = "Issue" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Issue" And Not xyzref.Text = "" Then
            qty.Enabled = True
        End If
    End Sub

    Private Sub qty_Leave(sender As Object, e As EventArgs) Handles qty.Leave
        If IsNumeric(qty.Text) And transtype.Text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text

            Dim cancelled As Double = (alloc - initial)
            Dim minimum As Double = issue - cancelled
            If minimum < 0 Then
                minimum = 0
            End If
            minadj.Text = minimum
            KryptonLabel23.Text = "Minimum Qty"
            Dim allocation = (alloc - initial) + newqty
            If allocation < issue Then

                MessageBox.Show("allocation must be greater tha or equal to issue qty
minimum adjustmment for this transaction is " & minimum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If
        ElseIf IsNumeric(qty.text) And transtype.text = "Issue" And xyz.text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text
            Dim pscal As Double = physical.Text

            Dim cancelled As Double = (issue - initial)
            Dim maximum As Double = alloc - cancelled
            minadj.Text = maximum
            KryptonLabel23.Text = "Maximum Qty"
            Dim iss = cancelled + newqty
            If iss > alloc Then
                Timer1.Stop()
                MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If
        ElseIf IsNumeric(qty.text) And transtype.text = "Issue" And xyz.text = "" Then
            'Dim initial As Double = initialqty.Text
            'Dim newqty As Double = qty.Text
            'Dim pscal As Double = physical.Text

            'Dim cancelled As Double = (pscal - initial)
            'Dim maximum As Double = pscal - cancelled
            'minadj.Text = maximum
            'KryptonLabel23.Text = "Maximum Qty"
            'Dim iss = cancelled + newqty
            'If iss > pscal Then
            '    Timer1.Stop()
            '    MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    qty.Focus()
            'End If
        ElseIf IsNumeric(qty.Text) Then

        Else

            qty.Focus()
            MessageBox.Show("invalid qty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        GETBALANCEALLOCISSUE(stockno.Text, reference.Text, XYZ.Text)

        If IsNumeric(qty.Text) And transtype.Text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text

            Dim cancelled As Double = (alloc - initial)
            Dim minimum As Double = issue - cancelled
            If minimum < 0 Then
                minimum = 0
            End If
            minadj.Text = minimum
            KryptonLabel23.Text = "Minimum Qty"
            Dim allocation = (alloc - initial) + newqty
            If allocation < issue Then
                Timer1.Stop()
                MessageBox.Show("minimum quantity is " & minimum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If
        ElseIf IsNumeric(qty.text) And transtype.text = "Issue" And xyz.text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text
            Dim pscal As Double = physical.Text

            Dim cancelled As Double = (issue - initial)
            Dim maximum As Double = alloc - cancelled
            minadj.Text = maximum
            KryptonLabel23.Text = "Maximum Qty"
            Dim iss = cancelled + newqty
            If iss > alloc Then
                Timer1.Stop()
                MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If
        ElseIf IsNumeric(qty.text) And transtype.text = "Issue" And xyz.text = "" Then
            'Dim initial As Double = initialqty.Text
            'Dim newqty As Double = qty.Text
            'Dim pscal As Double = physical.Text

            'Dim cancelled As Double = (pscal - initial)
            'Dim maximum As Double = pscal - cancelled
            'minadj.Text = maximum
            'KryptonLabel23.Text = "Maximum Qty"
            'Dim iss = cancelled + newqty
            'If iss > pscal Then
            '    Timer1.Stop()
            '    MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    qty.Focus()
            'End If
        ElseIf IsNumeric(qty.Text) Then
            Timer1.Stop()
        Else
            Timer1.Stop()
            qty.Focus()
            MessageBox.Show("invalid qty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        KryptonButton3.PerformClick()
    End Sub

    Private Sub stockno_TextChanged(sender As Object, e As EventArgs) Handles stockno.TextChanged
        getphysical(stockno.Text)
    End Sub
    Public Sub getphysical(ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "select physical from stocks_tb where stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                Dim x As String = read(0).ToString
                physical.Text = x
            End While
            read.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class