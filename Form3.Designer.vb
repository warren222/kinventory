<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.articleno = New System.Windows.Forms.ComboBox()
        Me.typecolor = New System.Windows.Forms.ComboBox()
        Me.costhead = New System.Windows.Forms.ComboBox()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.stockno = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.supplier = New System.Windows.Forms.ComboBox()
        Me.unitprice = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.monetary = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.ufactor = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.description = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.location = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.qty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.unit = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.header = New System.Windows.Forms.ComboBox()
        Me.min = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.SuspendLayout()
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Location = New System.Drawing.Point(279, 244)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton2.Size = New System.Drawing.Size(67, 25)
        Me.KryptonButton2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton2.StateCommon.Border.Rounding = 0
        Me.KryptonButton2.TabIndex = 15
        Me.KryptonButton2.Values.Text = "OK"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(352, 244)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton1.Size = New System.Drawing.Size(67, 25)
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 0
        Me.KryptonButton1.TabIndex = 16
        Me.KryptonButton1.Values.Text = "Cancel"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(12, 124)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel3.Size = New System.Drawing.Size(73, 19)
        Me.KryptonLabel3.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.TabIndex = 15
        Me.KryptonLabel3.Values.Text = "Article No."
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 99)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel2.Size = New System.Drawing.Size(76, 19)
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.TabIndex = 14
        Me.KryptonLabel2.Values.Text = "Type/Color"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 70)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel1.Size = New System.Drawing.Size(68, 19)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 13
        Me.KryptonLabel1.Values.Text = "Costhead"
        '
        'articleno
        '
        Me.articleno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.articleno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.articleno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.articleno.FormattingEnabled = True
        Me.articleno.Location = New System.Drawing.Point(91, 124)
        Me.articleno.Name = "articleno"
        Me.articleno.Size = New System.Drawing.Size(143, 23)
        Me.articleno.TabIndex = 7
        '
        'typecolor
        '
        Me.typecolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.typecolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.typecolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typecolor.FormattingEnabled = True
        Me.typecolor.Location = New System.Drawing.Point(91, 97)
        Me.typecolor.Name = "typecolor"
        Me.typecolor.Size = New System.Drawing.Size(143, 23)
        Me.typecolor.TabIndex = 5
        '
        'costhead
        '
        Me.costhead.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.costhead.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.costhead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.costhead.FormattingEnabled = True
        Me.costhead.Location = New System.Drawing.Point(91, 70)
        Me.costhead.Name = "costhead"
        Me.costhead.Size = New System.Drawing.Size(143, 23)
        Me.costhead.TabIndex = 3
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(12, 41)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel4.Size = New System.Drawing.Size(69, 19)
        Me.KryptonLabel4.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel4.TabIndex = 16
        Me.KryptonLabel4.Values.Text = "Stock No."
        '
        'stockno
        '
        Me.stockno.Enabled = False
        Me.stockno.Location = New System.Drawing.Point(91, 41)
        Me.stockno.Multiline = True
        Me.stockno.Name = "stockno"
        Me.stockno.Size = New System.Drawing.Size(102, 23)
        Me.stockno.TabIndex = 1
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(205, 37)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel5.Size = New System.Drawing.Size(60, 19)
        Me.KryptonLabel5.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel5.TabIndex = 18
        Me.KryptonLabel5.Values.Text = "Supplier"
        '
        'supplier
        '
        Me.supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.FormattingEnabled = True
        Me.supplier.Location = New System.Drawing.Point(271, 37)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(148, 23)
        Me.supplier.TabIndex = 2
        '
        'unitprice
        '
        Me.unitprice.Location = New System.Drawing.Point(317, 124)
        Me.unitprice.Multiline = True
        Me.unitprice.Name = "unitprice"
        Me.unitprice.Size = New System.Drawing.Size(102, 23)
        Me.unitprice.TabIndex = 8
        Me.unitprice.Text = "0"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(246, 124)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel6.Size = New System.Drawing.Size(69, 19)
        Me.KryptonLabel6.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel6.TabIndex = 20
        Me.KryptonLabel6.Values.Text = "Unit Price"
        '
        'monetary
        '
        Me.monetary.Location = New System.Drawing.Point(317, 95)
        Me.monetary.Multiline = True
        Me.monetary.Name = "monetary"
        Me.monetary.Size = New System.Drawing.Size(102, 23)
        Me.monetary.TabIndex = 6
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(246, 95)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel7.Size = New System.Drawing.Size(67, 19)
        Me.KryptonLabel7.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel7.TabIndex = 22
        Me.KryptonLabel7.Values.Text = "Monetary"
        '
        'ufactor
        '
        Me.ufactor.Location = New System.Drawing.Point(317, 66)
        Me.ufactor.Multiline = True
        Me.ufactor.Name = "ufactor"
        Me.ufactor.Size = New System.Drawing.Size(102, 23)
        Me.ufactor.TabIndex = 4
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(246, 66)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel8.Size = New System.Drawing.Size(63, 19)
        Me.KryptonLabel8.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel8.TabIndex = 24
        Me.KryptonLabel8.Values.Text = "U-Factor"
        '
        'description
        '
        Me.description.Location = New System.Drawing.Point(91, 153)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(328, 23)
        Me.description.TabIndex = 9
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(11, 153)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel9.Size = New System.Drawing.Size(78, 19)
        Me.KryptonLabel9.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel9.TabIndex = 26
        Me.KryptonLabel9.Values.Text = "Description"
        '
        'location
        '
        Me.location.Location = New System.Drawing.Point(91, 215)
        Me.location.Multiline = True
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(328, 23)
        Me.location.TabIndex = 13
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(11, 215)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel10.Size = New System.Drawing.Size(62, 19)
        Me.KryptonLabel10.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel10.TabIndex = 28
        Me.KryptonLabel10.Values.Text = "Location"
        '
        'qty
        '
        Me.qty.Location = New System.Drawing.Point(91, 186)
        Me.qty.Multiline = True
        Me.qty.Name = "qty"
        Me.qty.Size = New System.Drawing.Size(78, 23)
        Me.qty.TabIndex = 10
        Me.qty.Text = "0"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(12, 186)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel11.Size = New System.Drawing.Size(61, 19)
        Me.KryptonLabel11.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel11.TabIndex = 30
        Me.KryptonLabel11.Values.Text = "Quantity"
        '
        'unit
        '
        Me.unit.Location = New System.Drawing.Point(341, 186)
        Me.unit.Multiline = True
        Me.unit.Name = "unit"
        Me.unit.Size = New System.Drawing.Size(78, 23)
        Me.unit.TabIndex = 12
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(300, 186)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel12.Size = New System.Drawing.Size(35, 19)
        Me.KryptonLabel12.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel12.TabIndex = 32
        Me.KryptonLabel12.Values.Text = "Unit"
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(12, 244)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel13.Size = New System.Drawing.Size(55, 19)
        Me.KryptonLabel13.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel13.TabIndex = 35
        Me.KryptonLabel13.Values.Text = "Header"
        '
        'header
        '
        Me.header.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.header.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.header.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.FormattingEnabled = True
        Me.header.Location = New System.Drawing.Point(91, 244)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(143, 23)
        Me.header.TabIndex = 14
        '
        'min
        '
        Me.min.Location = New System.Drawing.Point(216, 186)
        Me.min.Multiline = True
        Me.min.Name = "min"
        Me.min.Size = New System.Drawing.Size(78, 23)
        Me.min.TabIndex = 11
        Me.min.Text = "0"
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Location = New System.Drawing.Point(175, 186)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel14.Size = New System.Drawing.Size(32, 19)
        Me.KryptonLabel14.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel14.TabIndex = 37
        Me.KryptonLabel14.Values.Text = "Min"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 285)
        Me.Controls.Add(Me.min)
        Me.Controls.Add(Me.KryptonLabel14)
        Me.Controls.Add(Me.KryptonLabel13)
        Me.Controls.Add(Me.header)
        Me.Controls.Add(Me.unit)
        Me.Controls.Add(Me.KryptonLabel12)
        Me.Controls.Add(Me.qty)
        Me.Controls.Add(Me.KryptonLabel11)
        Me.Controls.Add(Me.location)
        Me.Controls.Add(Me.KryptonLabel10)
        Me.Controls.Add(Me.description)
        Me.Controls.Add(Me.KryptonLabel9)
        Me.Controls.Add(Me.ufactor)
        Me.Controls.Add(Me.KryptonLabel8)
        Me.Controls.Add(Me.monetary)
        Me.Controls.Add(Me.KryptonLabel7)
        Me.Controls.Add(Me.unitprice)
        Me.Controls.Add(Me.KryptonLabel6)
        Me.Controls.Add(Me.supplier)
        Me.Controls.Add(Me.KryptonLabel5)
        Me.Controls.Add(Me.stockno)
        Me.Controls.Add(Me.KryptonLabel4)
        Me.Controls.Add(Me.KryptonLabel3)
        Me.Controls.Add(Me.KryptonLabel2)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.articleno)
        Me.Controls.Add(Me.typecolor)
        Me.Controls.Add(Me.costhead)
        Me.Controls.Add(Me.KryptonButton1)
        Me.Controls.Add(Me.KryptonButton2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(448, 324)
        Me.MinimumSize = New System.Drawing.Size(448, 324)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form3"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents articleno As ComboBox
    Friend WithEvents typecolor As ComboBox
    Friend WithEvents costhead As ComboBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents stockno As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents supplier As ComboBox
    Friend WithEvents unitprice As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents monetary As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ufactor As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents description As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents location As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents qty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents unit As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents header As ComboBox
    Friend WithEvents min As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
