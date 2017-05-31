Imports System.Data.SqlClient
Public Class sql
    Public sqlcon As New SqlConnection With {.ConnectionString = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='HERETOSAVE';User ID='kmdiadmin';Password='kmdiadmin';"}
    Dim da As New SqlDataAdapter
    Dim sqlcmd As New SqlCommand
    Public Sub loadstocks()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select * from stocks_tb ORDER BY COSTHEAD ASC"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Form2.stocksBindingSource.DataSource = ds
            Form2.stocksBindingSource.DataMember = "stocks_tb"
            Form2.stocksgridview.DataSource = Form2.stocksBindingSource
            Form2.stocksgridview.Columns("SUPPLIER").Visible = False
            Form2.stocksgridview.Columns("COSTHEAD").Visible = False
            Form2.stocksgridview.Columns("UFACTOR").Visible = False
            Form2.stocksgridview.Columns("MONETARY").Visible = False
            Form2.stocksgridview.Columns("UNITPRICE").Visible = False
            Form2.stocksgridview.Columns("DESCRIPTION").Visible = False
            Form2.stocksgridview.Columns("UNIT").Visible = False
            Form2.stocksgridview.Columns("LOCATION").Visible = False
            Form2.stocksgridview.Columns("HEADER").Visible = False
            Form2.stocksgridview.Columns("AVEUSAGE").Visible = False
            Form2.stocksgridview.Columns("QTY").Visible = False
            loadsearchbox()
            fillform()
            notifycritical()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchstocks(ByVal search As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            sqlcmd = New SqlCommand(search, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.stocksgridview.DataSource = bs
            Form2.stocksgridview.Columns("SUPPLIER").Visible = False
            Form2.stocksgridview.Columns("COSTHEAD").Visible = False
            Form2.stocksgridview.Columns("UFACTOR").Visible = False
            Form2.stocksgridview.Columns("MONETARY").Visible = False
            Form2.stocksgridview.Columns("UNITPRICE").Visible = False
            Form2.stocksgridview.Columns("DESCRIPTION").Visible = False
            Form2.stocksgridview.Columns("UNIT").Visible = False
            Form2.stocksgridview.Columns("LOCATION").Visible = False
            Form2.stocksgridview.Columns("HEADER").Visible = False
            Form2.stocksgridview.Columns("AVEUSAGE").Visible = False
            Form2.stocksgridview.Columns("QTY").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub notifycritical()
        Try
            Dim str As String = "select count(status) from stocks_tb where status = 'Critical'"
            sqlcmd = New SqlCommand(str, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            Dim x As String
            While read.Read
                x = read(0).ToString
            End While
            read.Close()

            Dim str1 As String = "select count(physical) from stocks_tb where physical<=0"
            sqlcmd = New SqlCommand(str1, sqlcon)
            Dim read2 As SqlDataReader = sqlcmd.ExecuteReader
            Dim y As String
            While read2.Read
                y = read2(0).ToString
            End While
            read2.Close()

            Dim str3 As String = "select count(duedate) from trans_tb where transtype='Order' and xyzref='' and duedate<=getdate()"
            sqlcmd = New SqlCommand(str3, sqlcon)
            Dim read3 As SqlDataReader = sqlcmd.ExecuteReader
            Dim o As String
            While read3.Read
                o = read3(0).ToString
            End While
            read3.Close()

            If x = "0" Then
                x = 0
            End If
            If y = "0" Then
                y = 0
            End If
            If o = "" Then
                o = 0
            End If
            Dim num1 As Double = x
            Dim num2 As Double = y
            Dim num3 As Double = o
            Dim z As Double = num1 + num2 + num3

            If z = "0" Then
                Form2.notification.Text = "Notification"
                Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Black
            ElseIf z = "1" Then
                Form2.notification.Text = "" & z & " " + "Notification"
                Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                Form2.notification.Text = "" & z & " " + "Notifications"
                Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Red
            End If

            If num1 = "0" Then
                NotiForm.KryptonButton1.Text = "Critical Status"
                NotiForm.KryptonButton1.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                NotiForm.KryptonButton1.Text = "" & num1 & " " + "Critical Status"
                NotiForm.KryptonButton1.StateCommon.Content.ShortText.Color1 = Color.Red
            End If
            If num2 = "0" Then
                NotiForm.KryptonButton2.Text = "Out of Stock"
                NotiForm.KryptonButton2.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                NotiForm.KryptonButton2.Text = "" & num2 & " " + "Out of Stock"
                NotiForm.KryptonButton2.StateCommon.Content.ShortText.Color1 = Color.Red
            End If
            If num3 = "0" Then
                NotiForm.KryptonButton3.Text = "Order Due"
                NotiForm.KryptonButton3.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                NotiForm.KryptonButton3.Text = "" & num3 & " " + "Order Due"
                NotiForm.KryptonButton3.StateCommon.Content.ShortText.Color1 = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub loadcostheadsearch()
        Try
            sqlcon.Open()
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            Form2.costheadsearch.DataSource = costheadbindingsource
            Form2.costheadsearch.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadtypecolorsearch(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb where costhead='" & costhead & "'"
            sqlcmd = New SqlCommand(str1, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            Form2.typecolorsearch.DataSource = typecolorbs
            Form2.typecolorsearch.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadarticlesearch(ByVal costhead As String, ByVal typec As String)
        Try
            sqlcon.Open()
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb where costhead='" & costhead & "' and typecolor='" & typec & "'"
            sqlcmd = New SqlCommand(str2, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            Form2.articlenosearch.DataSource = articlebs
            Form2.articlenosearch.DisplayMember = "articleno"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadsearchbox()
        Try
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            Form3.costhead.DataSource = costheadbindingsource
            Form3.costhead.DisplayMember = "costhead"
            Form3.costhead.SelectedIndex = -1
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb"
            sqlcmd = New SqlCommand(str1, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            Form3.typecolor.DataSource = typecolorbs
            Form3.typecolor.DisplayMember = "typecolor"
            Form3.typecolor.SelectedIndex = -1
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb"
            sqlcmd = New SqlCommand(str2, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            Form3.articleno.DataSource = articlebs
            Form3.articleno.DisplayMember = "articleno"
            Form3.articleno.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub fillform()
        Try
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            Form3.costhead.DataSource = costheadbindingsource
            Form3.costhead.DisplayMember = "costhead"
            Form3.costhead.SelectedIndex = -1

            Form4.costhead.DataSource = costheadbindingsource
            Form4.costhead.DisplayMember = "costhead"
            Form4.costhead.SelectedIndex = -1
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb"
            sqlcmd = New SqlCommand(str1, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            Form3.typecolor.DataSource = typecolorbs
            Form3.typecolor.DisplayMember = "typecolor"
            Form3.typecolor.SelectedIndex = -1

            Form4.typecolor.DataSource = typecolorbs
            Form4.typecolor.DisplayMember = "typecolor"
            Form4.typecolor.SelectedIndex = -1
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb"
            sqlcmd = New SqlCommand(str2, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            Form3.articleno.DataSource = articlebs
            Form3.articleno.DisplayMember = "articleno"
            Form3.articleno.SelectedIndex = -1

            Form4.articleno.DataSource = articlebs
            Form4.articleno.DisplayMember = "articleno"
            Form4.articleno.SelectedIndex = -1
            Dim headerds As New DataSet
            Dim headerbs As New BindingSource
            headerds.Clear()
            Dim str3 As String = "select distinct header from stocks_tb"
            sqlcmd = New SqlCommand(str3, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(headerds, "stocks_tb")
            headerbs.DataSource = headerds
            headerbs.DataMember = "stocks_tb"
            Form3.header.DataSource = headerbs
            Form3.header.DisplayMember = "header"
            Form3.header.SelectedIndex = -1

            Form4.header.DataSource = headerbs
            Form4.header.DisplayMember = "header"
            Form4.header.SelectedIndex = -1
            Dim supplierds As New DataSet
            Dim supplierbs As New BindingSource
            supplierds.Clear()
            Dim str4 As String = "select distinct supplier from stocks_tb"
            sqlcmd = New SqlCommand(str4, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(supplierds, "stocks_tb")
            supplierbs.DataSource = supplierds
            supplierbs.DataMember = "stocks_tb"
            Form3.supplier.DataSource = supplierbs
            Form3.supplier.DisplayMember = "supplier"
            Form3.supplier.SelectedIndex = -1

            Form4.supplier.DataSource = supplierbs
            Form4.supplier.DisplayMember = "supplier"
            Form4.supplier.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Newstock(ByVal supplier As String,
                 ByVal costhead As String,
                 ByVal ufactor As String,
                 ByVal typecolor As String,
                 ByVal monetary As String,
                 ByVal articleno As String,
                 ByVal unitprice As String,
                 ByVal description As String,
                 ByVal QTY As String,
                 ByVal unit As String,
                 ByVal location As String,
                 ByVal header As String)
        Try
            sqlcon.Open()
            Dim str As String = "insert into stocks_tb (supplier,
costhead,
ufactor,
typecolor,
monetary,
articleno,
unitprice,
description,
QTY,
unit,
location,
header,
physical,
allocation,
free,
stockorder,
minimum,
ISSUE)values('" & supplier & "'," &
                            "'" & costhead & "'," &
                            "'" & ufactor & "'," &
                            "'" & typecolor & "'," &
                            "'" & monetary & "'," &
                            "'" & articleno & "'," &
                            "'" & unitprice & "'," &
                            "'" & description & "'," &
                            "'" & QTY & "'," &
                            "'" & unit & "'," &
                            "'" & location & "'," &
                            "'" & header & "'," &
                            "'" & QTY & "'," &
                            "'0'," &
                           "'" & QTY & "'," &
                            "'0'," &
                               "'0'," &
                            "'0')"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("New stocks Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestocks(ByVal stockno As String,
               ByVal ufactor As String,
               ByVal monetary As String,
               ByVal unitprice As String,
               ByVal description As String,
               ByVal unit As String,
               ByVal location As String,
               ByVal min As String)
        Try
            sqlcon.Open()
            Dim str As String = "update stocks_tb set 
ufactor='" & ufactor & "',
monetary='" & monetary & "',
unitprice='" & unitprice & "',
description='" & description & "',
unit='" & unit & "',
location='" & location & "',
minimum='" & min & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("Stocks Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestocks2(ByVal stockno As String,
               ByVal supplier As String,
               ByVal costhead As String,
               ByVal header As String,
               ByVal articleno As String,
               ByVal typecolor As String,
               ByVal description As String,
               ByVal min As String,
                             ByVal monetary As String,
                             ByVal unitprice As String,
                             ByVal aveusage As String,
                             ByVal location As String,
                             ByVal unit As String)
        Try
            sqlcon.Open()
            Dim str As String = "update stocks_tb set 
supplier='" & supplier & "',
costhead='" & costhead & "',
header='" & header & "',
articleno='" & articleno & "',
typecolor='" & typecolor & "',
description='" & description & "',
minimum='" & min & "',
monetary='" & monetary & "',
unitprice = '" & unitprice & "',
aveusage='" & aveusage & "',
location='" & location & "',
UNIT='" & unit & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("Stocks Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form4.supplier.Enabled = False
            Form4.costhead.Enabled = False
            Form4.header.Enabled = False
            Form4.articleno.Enabled = False
            Form4.typecolor.Enabled = False
            Form4.description.Enabled = False
            Form4.min.Enabled = False
            Form4.monetary.Enabled = False
            Form4.unitprice.Enabled = False
            Form4.aveusage.Enabled = False
            Form4.location.Enabled = False
            Form4.unit.Enabled = False
            Form4.editbtn.Visible = True
            Form4.savebtn.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadtransactions()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select a.TRANSNO,
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
A.XYZ
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            Form2.transbindingsource.datasource = ds
            Form2.transbindingsource.datamember = "trans_tb"
            Form2.transgridview.DataSource = Form2.transBindingSource
            Form2.transgridview.Columns("DESCRIPTION").Visible = False
            Form2.transgridview.Columns("COSTHEAD").Visible = False
            Form2.transgridview.Columns("TYPECOLOR").Visible = False
            Form2.transgridview.Columns("REFERENCE").Visible = False
            Form2.transgridview.Columns("xyz").Visible = False
            Form2.transgridview.Columns("TRANSDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form2.transgridview.Columns("DUEDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Dim referenceds As New DataSet
            referenceds.Clear()
            Dim transbs As New BindingSource
            Dim ref As String = "select distinct reference from trans_tb"
            sqlcmd = New SqlCommand(ref, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(referenceds, "trans_tb")
            transbs.DataSource = referenceds
            transbs.DataMember = "trans_tb"
            Form2.transreference.DataSource = transbs
            Form2.transreference.DisplayMember = "reference"
            Form2.transreference.SelectedIndex = -1

            Dim costheadds As New DataSet
            Dim costheadbs As New BindingSource
            costheadds.Clear()

            Dim costhead As String = "select distinct b.costhead from stocks_tb as b inner join trans_tb as a on a.stockno = b.stockno"
            sqlcmd = New SqlCommand(costhead, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbs.DataSource = costheadds
            costheadbs.DataMember = "stocks_tb"
            Form2.transactioncosthead.DataSource = costheadbs
            Form2.transactioncosthead.DisplayMember = "costhead"
            Form2.transactioncosthead.SelectedIndex = -1

            notifycritical()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadreference(ByVal source As String)
        Try
            sqlcon.Open()
            If source = "Trans" Then
                Dim ds As New DataSet
                Dim bs As New BindingSource
                ds.Clear()
                Dim str As String = "select distinct reference from trans_tb"
                sqlcmd = New SqlCommand(str, sqlcon)
                da.SelectCommand = sqlcmd
                da.Fill(ds, "trans_tb")
                bs.DataSource = ds
                bs.DataMember = "trans_tb"
                Form2.reference.DataSource = bs
                Form2.reference.ValueMember = "reference"
                Form2.reference.DisplayMember = "reference"
                Form2.reference.SelectedIndex = -1
            ElseIf source = "Contracts" Then
                Dim ds As New DataSet
                Dim bs As New BindingSource
                ds.Clear()
                Dim str As String = "select distinct project_label from addendum_to_contract_tb"
                sqlcmd = New SqlCommand(str, sqlcon)
                da.SelectCommand = sqlcmd
                da.Fill(ds, "addendum_to_contract_tb")
                bs.DataSource = ds
                bs.DataMember = "addendum_to_contract_tb"
                Form2.reference.DataSource = bs
                Form2.reference.ValueMember = "project_label"
                Form2.reference.DisplayMember = "project_label"
                Form2.reference.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadinputsearch()
        'Try
        '    sqlcon.Open()
        '    Dim ds As New DataSet
        '    Dim str As String = "select * from stocks_tb"
        '    sqlcmd = New SqlCommand(str, sqlcon)
        '    da.SelectCommand = sqlcmd
        '    da.Fill(ds, "stocks_tb")
        '    Form2.loadinputBindingSource.DataSource = ds
        '    Form2.loadinputBindingSource.DataMember = "stocks_tb"
        '    Form2.transcosthead.DataSource = Form2.loadinputBindingSource
        '    Form2.transarticleno.DataSource = Form2.loadinputBindingSource
        '    Form2.transtypecolor.DataSource = Form2.loadinputBindingSource
        '    Form2.transcosthead.DisplayMember = "COSTHEAD"
        '    Form2.transarticleno.DisplayMember = "ARTICLENO"
        '    Form2.transtypecolor.DisplayMember = "TYPECOLOR"
        '    Form2.transdescription.DataBindings.Clear()
        '    Form2.transphysical.DataBindings.Clear()
        '    Form2.transfree.DataBindings.Clear()
        '    Form2.transunit.DataBindings.Clear()
        '    Form2.transstockno.DataBindings.Clear()
        '    Form2.transdescription.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "DESCRIPTION")
        '    Form2.transphysical.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "PHYSICAL")
        '    Form2.transfree.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "FREE")
        '    Form2.transunit.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "UNIT")
        '    Form2.transstockno.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "STOCKNO")
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'Finally
        '    sqlcon.Close()
        'End Try
    End Sub
    Public Sub costheadinput()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transcosthead.DataSource = bs
            Form2.transcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub costheadreceipt()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptcosthead.DataSource = bs
            Form2.receiptcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub costheadissue()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuecosthead.DataSource = bs
            Form2.issuecosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorinput(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb where costhead = '" & costhead & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transtypecolor.DataSource = bs
            Form2.transtypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorissue(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb where costhead = '" & costhead & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuetypecolor.DataSource = bs
            Form2.issuetypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorreceipt(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb where costhead = '" & costhead & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receipttypecolor.DataSource = bs
            Form2.receipttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoinput(ByVal costhead As String, ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "' and typecolor='" & typecolor & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transarticleno.DataSource = bs
            Form2.transarticleno.DisplayMember = "articleno"
            Form2.transdescription.DataBindings.Clear()
            Form2.transphysical.DataBindings.Clear()
            Form2.transfree.DataBindings.Clear()
            Form2.transunit.DataBindings.Clear()
            Form2.transstockno.DataBindings.Clear()
            Form2.transdescription.DataBindings.Add("TEXT", bs, "DESCRIPTION")
            Form2.transphysical.DataBindings.Add("TEXT", bs, "PHYSICAL")
            Form2.transfree.DataBindings.Add("TEXT", bs, "FREE")
            Form2.transunit.DataBindings.Add("TEXT", bs, "UNIT")
            Form2.transstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoreceipt(ByVal costhead As String, ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "' and typecolor='" & typecolor & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptarticleno.DataSource = bs
            Form2.receiptarticleno.DisplayMember = "articleno"
            Form2.receiptstockno.DataBindings.Clear()
            Form2.receiptstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreference(Form2.receiptreference.Text, Form2.receiptstockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoissue(ByVal costhead As String, ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "' and typecolor='" & typecolor & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuearticleno.DataSource = bs
            Form2.issuearticleno.DisplayMember = "articleno"
            Form2.issuestockno.DataBindings.Clear()
            Form2.issuestockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreferenceissue(Form2.issuereference.Text, Form2.issuestockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub referencereceipt()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct reference from trans_tb where transtype = 'Order'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptreference.DataSource = bs
            Form2.receiptreference.DisplayMember = "reference"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub referenceissue()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct reference from trans_tb where transtype = 'Allocation'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuereference.DataSource = bs
            Form2.issuereference.DisplayMember = "reference"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub newtransaction(ByVal stockno As String,
                          ByVal transtype As String,
                          ByVal transdate As String,
                          ByVal duedate As String,
                          ByVal qty As String,
                          ByVal reference As String,
                          ByVal account As String,
                          ByVal controlno As String, ByVal xyz As String,
                              ByVal XYZREF As String,
                              ByVal remarks As String)
        Try
            sqlcon.Open()
            Dim str As String = "insert into trans_tb 
            (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS) values ('" & stockno & "'," &
            "'" & transtype & "'," &
            "'" & transdate & "'," &
            "'" & duedate & "'," &
            "'" & qty & "'," &
            "'" & reference & "'," &
            "'" & account & "'," &
            "'" & controlno & "'," &
               "'" & xyz & "'," &
                 "'" & XYZREF & "'," &
            "'" & remarks & "')"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()

            Dim find As String = "select * from reference_tb where reference='" & reference & "' and stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(find, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
            Else
                read.Close()
                Dim insert As String = "insert into reference_tb (reference,stockno) values('" & reference & "','" & stockno & "')"
                sqlcmd = New SqlCommand(insert, sqlcon)
                sqlcmd.ExecuteNonQuery()
            End If

            MessageBox.Show("Stocks Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchreference(ByVal reference As String, ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "
select TRANSNO,
STOCKNO,
TRANSTYPE,
TRANSDATE,
DUEDATE,
QTY,
REFERENCE,
ACCOUNT,
CONTROLNO,
XYZ
 from trans_tb where reference='" & reference & "' and transtype = 'Order' AND XYZREF=''"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.receiptGridView.DataSource = bs


            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.receiptDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectsubreference(ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.receiptDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectsubreferenceissue(ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.issueDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchreferenceissue(ByVal reference As String, ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "select REFERENCE,STOCKNO,ALLOCATION,TOTALISSUE from reference_tb where reference='" & reference & "' and stockno ='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.issueDataGridView.DataSource = bs


            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.issueDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectreceiptreferencerecord(ByVal reference As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim Str As String = "select TRANSNO,
STOCKNO,
TRANSTYPE,
TRANSDATE,
DUEDATE,
QTY,
REFERENCE,
ACCOUNT,
CONTROLNO,
XYZ
 from trans_tb where reference='" & reference & "' and transtype = 'Order' and xyzref=''"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.receiptGridView.DataSource = bs
            Form2.receiptGridView.Columns("xyz").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectissuereferencerecord(ByVal reference As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim Str As String = "select REFERENCE,
STOCKNO,
ALLOCATION,
TOTALISSUE
from
reference_tb
 where reference='" & reference & "'"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.issueDataGridView.DataSource = bs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub srockstransactiontb(ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "select * from trans_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form4.mytransgridview.DataSource = bs
            Form4.mytransgridview.Columns("TRANSDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("DUEDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("xyz").Visible = False
            Form4.mytransgridview.Columns("stockno").Visible = False
            Form4.mytransgridview.Columns("xyzref").Visible = False

            Dim referenceds As New DataSet
            Dim referencebs As New BindingSource
            Dim v As String = "select distinct reference from trans_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(v, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(referenceds, "trans_tb")
            referencebs.DataSource = referenceds
            referencebs.DataMember = "trans_tb"
            Form4.reference.DataSource = referencebs
            Form4.reference.DisplayMember = "reference"
            Form4.reference.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Public Sub searchstockstransaction(ByVal search As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(search, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form4.mytransgridview.DataSource = bs
            Form4.mytransgridview.Columns("xyzref").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchtransaction(ByVal search As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(search, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.transgridview.DataSource = bs
            Form2.transgridview.Columns("DESCRIPTION").Visible = False
            Form2.transgridview.Columns("COSTHEAD").Visible = False
            Form2.transgridview.Columns("TYPECOLOR").Visible = False
            Form2.transgridview.Columns("REFERENCE").Visible = False
            Form2.transgridview.Columns("xyz").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadaccount()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "select distinct account from trans_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.issueaccount.DataSource = bs
            Form2.issueaccount.ValueMember = "account"
            Form2.issueaccount.DisplayMember = "account"
            Form2.issueaccount.SelectedIndex = -1

            Form2.account.DataSource = bs
            Form2.account.ValueMember = "account"
            Form2.account.DisplayMember = "account"
            Form2.account.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectreference(ByVal stockno As String, ByVal reference As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim Str As String = "select reference as [REFERENCE]
      ,stockno as [STOCKNO]
      ,STOCKORDER as [ORDER]
      ,ALLOCATION as [ALLOCATION]
      ,TOTALRECEIPT as [RECEIPT]
      ,TOTALISSUE as [ISSUE],
        TOTALRETURN AS [RETURN] from reference_tb where stockno='" & stockno & "' and reference='" & reference & "'"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form5.referencegridview.DataSource = bs
            Form5.referencegridview.Columns("stockno").Visible = False


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updatetransdates(ByVal transno As String, ByVal transdate As String, ByVal duedate As String, ByVal qty As String, ByVal xyzref As String)
        Try
            sqlcon.Open()
            Dim str As String = ""
            'order
            If Form5.transtype.Text = "Order" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Order" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "' where transno = '" & transno & "'"
                'receipt
            ElseIf Form5.transtype.Text = "Receipt" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Receipt" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "',qty = '" & qty & "' where transno = '" & transno & "'
                       update trans_tb set qty = '" & qty & "' where transno = '" & xyzref & "'"
                'allocation
            ElseIf Form5.transtype.Text = "Allocation" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Allocation" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "' where transno = '" & transno & "'"
                'issue
            ElseIf Form5.transtype.Text = "Issue" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Issue" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                'return
            ElseIf Form5.transtype.Text = "Return" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Return" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                'Supply
            ElseIf Form5.transtype.Text = "Supply" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Supply" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                'Spare
            ElseIf Form5.transtype.Text = "Spare" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Spare" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                '+Adjustment
            ElseIf Form5.transtype.Text = "+Adjustment" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "+Adjustment" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                '-Adjustment
            ElseIf Form5.transtype.Text = "-Adjustment" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "-Adjustment" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            End If

            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("transaction updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form5.initialqty.Text = Form5.qty.Text
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub


    Public Sub selecttransrec(ByVal transno As String)
        Try
            sqlcon.Open()
            Dim str As String = "select a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
B.ARTICLENO,
B.DESCRIPTION,
a.TRANSTYPE,
format(a.TRANSDATE,'yyyy-MMM-dd') AS [TRANSDATE],
format(a.DUEDATE,'yyyy-MMM-dd') AS [DUEDATE],
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.xyzref
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno where a.transno='" & transno & "'"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"

            Form5.stockno.DataBindings.Clear()
            Form5.costhead.DataBindings.Clear()
            Form5.typecolor.DataBindings.Clear()
            Form5.articleno.DataBindings.Clear()
            Form5.description.DataBindings.Clear()
            Form5.transtype.DataBindings.Clear()
            Form5.transdate.DataBindings.Clear()
            Form5.duedate.DataBindings.Clear()
            Form5.qty.DataBindings.Clear()
            Form5.initialqty.DataBindings.Clear()
            Form5.reference.DataBindings.Clear()
            Form5.account.DataBindings.Clear()
            Form5.controlno.DataBindings.Clear()
            Form5.xyzref.DataBindings.Clear()
            Form5.stockno.DataBindings.Add("text", bs, "stockno")
            Form5.costhead.DataBindings.Add("text", bs, "COSTHEAD")
            Form5.typecolor.DataBindings.Add("text", bs, "TYPECOLOR")
            Form5.articleno.DataBindings.Add("text", bs, "ARTICLENO")
            Form5.description.DataBindings.Add("text", bs, "DESCRIPTION")
            Form5.transtype.DataBindings.Add("text", bs, "TRANSTYPE")
            Form5.transdate.DataBindings.Add("text", bs, "TRANSDATE")
            Form5.duedate.DataBindings.Add("text", bs, "DUEDATE")
            Form5.qty.DataBindings.Add("text", bs, "QTY")
            Form5.initialqty.DataBindings.Add("text", bs, "QTY")
            Form5.reference.DataBindings.Add("text", bs, "REFERENCE")
            Form5.account.DataBindings.Add("text", bs, "ACCOUNT")
            Form5.controlno.DataBindings.Add("text", bs, "CONTROLNO")
            Form5.xyzref.DataBindings.Add("text", bs, "xyzref")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub referencetb()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.STOCKORDER,
a.ALLOCATION,
a.TOTALRECEIPT,
a.TOTALISSUE,
A.TOTALRETURN
from reference_tb as a
inner join
stocks_tb as b
on a.stockno=b.stockno"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            Form2.referencebs.DataSource = ds
            Form2.referencebs.DataMember = "reference_tb"
            Form2.referenceDataGridView.DataSource = Form2.referencebs
            loadreffromreference()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadreffromreference()
        Try
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select distinct reference from reference_tb"
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.reffromreference.DataSource = bs
            Form2.reffromreference.DisplayMember = "reference"
            Form2.reffromreference.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub removefromref(ByVal ref As String, ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim str As String = "delete from reference_tb where reference='" & ref & "' and stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub refsearch(ByVal where As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.STOCKORDER,
a.ALLOCATION,
a.TOTALRECEIPT,
a.TOTALISSUE,
A.TOTALRETURN
from reference_tb as a
inner join
stocks_tb as b
on a.stockno=b.stockno " & where & ""
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.referencebs.DataMember = "reference_tb"
            Form2.referenceDataGridView.DataSource = bs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub alltransaction()
        Try
            sqlcon.Open()
            Dim ds As New inventoryds
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim str As String = "select a.TRANSNO,
a.STOCKNO,
b.TYPECOLOR,
b.ARTICLENO,
a.TRANSTYPE,
format(a.TRANSDATE,'yyyy-MMM-dd') as TRANSDATE,
format(a.DUEDATE,'yyyy-MMM-dd') AS DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.XYZ,
a.XYZREF
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno ORDER BY a.TRANSDATE DESC"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds.TRANS_TB)
            AllTrans.TRANS_TBBindingSource.DataSource = ds.TRANS_TB.DefaultView
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
End Class
