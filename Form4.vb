Public Class Form4
    Dim SQL As New sql
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        supplier.Enabled = True
        costhead.Enabled = True
        header.Enabled = True
        articleno.Enabled = True
        typecolor.Enabled = True
        description.Enabled = True
        min.Enabled = True
        monetary.Enabled = True
        unitprice.Enabled = True
        aveusage.Enabled = True
        location.Enabled = True
        unit.Enabled = True
        editbtn.Visible = False
        savebtn.Visible = True
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        supplier.Enabled = False
        costhead.Enabled = False
        header.Enabled = False
        articleno.Enabled = False
        typecolor.Enabled = False
        description.Enabled = False
        min.Enabled = False
        monetary.Enabled = False
        unitprice.Enabled = False
        aveusage.Enabled = False
        location.Enabled = False
        unit.Enabled = False
        editbtn.Visible = True
        savebtn.Visible = False
    End Sub

    Private Sub savebtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        If MessageBox.Show("save changes?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("operation cancelled", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        remove()
        SQL.updatestocks2(stockno.Text, supplier.Text,
        costhead.Text,
        header.Text,
        articleno.Text,
        typecolor.Text,
        description.Text,
        min.Text,
        monetary.Text,
        unitprice.Text,
        aveusage.Text,
        location.Text,
        unit.Text)
        SQL.loadstocks()
    End Sub
    Public Sub remove()
        supplier.Text = supplier.Text.Replace("'", "")
        supplier.Text = supplier.Text.Replace("""", "")
        costhead.Text = costhead.Text.Replace("'", "")
        costhead.Text = costhead.Text.Replace("""", "")
        header.Text = header.Text.Replace("'", "")
        header.Text = header.Text.Replace("""", "")
        articleno.Text = articleno.Text.Replace("'", "")
        articleno.Text = articleno.Text.Replace("""", "")
        typecolor.Text = typecolor.Text.Replace("'", "")
        typecolor.Text = typecolor.Text.Replace("""", "")
        description.Text = description.Text.Replace("'", "")
        description.Text = description.Text.Replace("""", "")
        min.Text = min.Text.Replace("'", "")
        min.Text = min.Text.Replace("""", "")
        monetary.Text = monetary.Text.Replace("'", "")
        monetary.Text = monetary.Text.Replace("""", "")
        unitprice.Text = unitprice.Text.Replace("'", "")
        unitprice.Text = unitprice.Text.Replace("""", "")
        aveusage.Text = aveusage.Text.Replace("'", "")
        aveusage.Text = aveusage.Text.Replace("""", "")
        location.Text = location.Text.Replace("'", "")
        location.Text = location.Text.Replace("""", "")
        unit.Text = unit.Text.Replace("'", "")
        unit.Text = unit.Text.Replace("""", "")
        supplier.Text = Trim(supplier.Text)
        costhead.Text = Trim(costhead.Text)
        header.Text = Trim(header.Text)
        articleno.Text = Trim(articleno.Text)
        typecolor.Text = Trim(typecolor.Text)
        description.Text = Trim(description.Text)
        min.Text = Trim(min.Text)
        monetary.Text = Trim(monetary.Text)
        unitprice.Text = Trim(unitprice.Text)
        aveusage.Text = Trim(aveusage.Text)
        location.Text = Trim(location.Text)
        unit.Text = Trim(unit.Text)

    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        reference.Text = reference.Text.Replace("'", "")
        reference.Text = reference.Text.Replace("""", "")
        transaction.Text = transaction.Text.Replace("'", "")
        transaction.Text = transaction.Text.Replace("""", "")
        Dim search As String
        If all.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf all.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf all.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf all.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "'"
            SQL.searchstockstransaction(search)
        End If

        If thisdate.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf thisdate.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf thisdate.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf thisdate.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        End If

        If before.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf before.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf before.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf before.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        End If

        If after.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf after.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf after.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf after.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search)
        End If

        If tomydate.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf tomydate.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf tomydate.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search)
        ElseIf tomydate.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = "select * from trans_tb where stockno='" & stockno.Text & "' and format(TRANSDATE,'yyyy-MMM-dd') between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search)
        End If

    End Sub





    Private Sub KryptonButton2_Click_1(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        SQL.srockstransactiontb(stockno.Text)
    End Sub

    Private Sub min_Leave(sender As Object, e As EventArgs) Handles min.Leave
        If IsNumeric(min.Text) Then
        Else
            MessageBox.Show("Minimum quantity must be valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            min.Focus()
        End If
    End Sub

    Private Sub unitprice_Leave(sender As Object, e As EventArgs) Handles unitprice.Leave
        If IsNumeric(unitprice.Text) Then
        Else
            MessageBox.Show("Unit price must be valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            unitprice.Focus()
        End If
    End Sub

    Private Sub aveusage_Leave(sender As Object, e As EventArgs) Handles aveusage.Leave
        If IsNumeric(aveusage.Text) Then
        Else
            MessageBox.Show("Average usage must be valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            aveusage.Focus()
        End If
    End Sub
End Class