Public Class Form3
    Dim sql As New sql
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        If Me.Text = "New" Then
            remove()
            sql.Newstock(supplier.Text,
costhead.Text,
ufactor.Text,
typecolor.Text,
monetary.Text,
articleno.Text,
unitprice.Text,
description.Text,
qty.Text,
unit.Text,
location.Text,
header.Text)
            sql.loadstocks()
            Form2.KryptonButton17.PerformClick()
        ElseIf Me.Text = "Edit" Then
            remove()
            sql.updatestocks(stockno.Text,
ufactor.Text,
monetary.Text,
unitprice.Text,
description.Text,
unit.Text,
location.Text,
min.Text)
            sql.loadstocks()
            Form2.KryptonButton17.PerformClick()
        End If
    End Sub
    Public Sub remove()
        supplier.Text = supplier.Text.Replace("'", "")
        supplier.Text = supplier.Text.Replace("""", "")
        costhead.Text = costhead.Text.Replace("'", "")
        costhead.Text = costhead.Text.Replace("""", "")
        ufactor.Text = ufactor.Text.Replace("'", "")
        ufactor.Text = ufactor.Text.Replace("""", "")
        typecolor.Text = typecolor.Text.Replace("'", "")
        typecolor.Text = typecolor.Text.Replace("""", "")
        monetary.Text = monetary.Text.Replace("'", "")
        monetary.Text = monetary.Text.Replace("""", "")
        articleno.Text = articleno.Text.Replace("'", "")
        articleno.Text = articleno.Text.Replace("""", "")
        unitprice.Text = unitprice.Text.Replace("'", "")
        unitprice.Text = unitprice.Text.Replace("""", "")
        description.Text = description.Text.Replace("'", "")
        description.Text = description.Text.Replace("""", "")
        qty.Text = qty.Text.Replace("'", "")
        qty.Text = qty.Text.Replace("""", "")
        unit.Text = unit.Text.Replace("'", "")
        unit.Text = unit.Text.Replace("""", "")
        location.Text = location.Text.Replace("'", "")
        location.Text = location.Text.Replace("""", "")
        header.Text = header.Text.Replace("'", "")
        header.Text = header.Text.Replace("""", "")
        supplier.Text = Trim(supplier.Text)
        costhead.Text = Trim(costhead.Text)
        ufactor.Text = Trim(ufactor.Text)
        typecolor.Text = Trim(typecolor.Text)
        monetary.Text = Trim(monetary.Text)
        articleno.Text = Trim(articleno.Text)
        unitprice.Text = Trim(unitprice.Text)
        description.Text = Trim(description.Text)
        qty.Text = Trim(qty.Text)
        unit.Text = Trim(unit.Text)
        location.Text = Trim(location.Text)
        header.Text = Trim(header.Text)
    End Sub

    Private Sub unitprice_Leave(sender As Object, e As EventArgs) Handles unitprice.Leave
        Dim name As String = "Unit price"
        validnumber(unitprice, name)
    End Sub

    Private Sub totalreceipt_Leave(sender As Object, e As EventArgs) Handles qty.Leave
        Dim name As String = "Qty"
        validnumber(qty, name)
    End Sub
    Public Sub validnumber(ByVal x As Object, ByVal name As String)
        If IsNumeric(x.text) Then
        Else
            MessageBox.Show("" & name & " must be a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            x.Focus()
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Text = "New" Then
            stockno.Text = ""
            supplier.SelectedIndex = -1
            costhead.SelectedIndex = -1
            ufactor.Text = ""
            typecolor.SelectedIndex = -1
            monetary.Text = ""
            articleno.SelectedIndex = -1
            unitprice.Text = 0
            description.Text = ""
            qty.Text = 0
            unit.Text = ""
            location.Text = ""
            header.SelectedIndex = -1
            supplier.Enabled = True
            costhead.Enabled = True
            typecolor.Enabled = True
            articleno.Enabled = True
            qty.Enabled = True
            header.Enabled = True
            min.Visible = False
            KryptonLabel14.Visible = False
        ElseIf Me.Text = "Edit" Then
            supplier.Enabled = False
            costhead.Enabled = False
            typecolor.Enabled = False
            articleno.Enabled = False
            qty.Enabled = False
            header.Enabled = False
            min.Visible = True
            KryptonLabel14.Visible = True

        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub min_Leave(sender As Object, e As EventArgs) Handles min.Leave
        Dim name As String = "Minimum qty"
        validnumber(min, name)
    End Sub
End Class