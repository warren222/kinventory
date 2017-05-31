<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotiForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotiForm))
        Me.stocksgridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton3 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        CType(Me.stocksgridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'stocksgridview
        '
        Me.stocksgridview.AllowUserToAddRows = False
        Me.stocksgridview.AllowUserToDeleteRows = False
        Me.stocksgridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.stocksgridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.stocksgridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stocksgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.stocksgridview.ColumnHeadersHeight = 30
        Me.stocksgridview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stocksgridview.Location = New System.Drawing.Point(11, 33)
        Me.stocksgridview.Name = "stocksgridview"
        Me.stocksgridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.stocksgridview.ReadOnly = True
        Me.stocksgridview.RowHeadersWidth = 25
        Me.stocksgridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.stocksgridview.Size = New System.Drawing.Size(423, 390)
        Me.stocksgridview.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.stocksgridview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.stocksgridview.StateCommon.DataCell.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.stocksgridview.StateCommon.DataCell.Border.Width = 0
        Me.stocksgridview.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.stocksgridview.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.stocksgridview.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.stocksgridview.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.stocksgridview.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.stocksgridview.StateCommon.HeaderColumn.Border.Width = 0
        Me.stocksgridview.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.stocksgridview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.stocksgridview.StateCommon.HeaderColumn.Content.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias
        Me.stocksgridview.TabIndex = 1
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton2.Location = New System.Drawing.Point(3, 45)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton2.Size = New System.Drawing.Size(149, 44)
        Me.KryptonButton2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton2.StateCommon.Border.Rounding = 0
        Me.KryptonButton2.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Bold)
        Me.KryptonButton2.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonButton2.TabIndex = 16
        Me.KryptonButton2.Values.Image = CType(resources.GetObject("KryptonButton2.Values.Image"), System.Drawing.Image)
        Me.KryptonButton2.Values.Text = "Out of Stock"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton1.Location = New System.Drawing.Point(3, 2)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton1.Size = New System.Drawing.Size(149, 44)
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 0
        Me.KryptonButton1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Bold)
        Me.KryptonButton1.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonButton1.TabIndex = 17
        Me.KryptonButton1.Values.Image = CType(resources.GetObject("KryptonButton1.Values.Image"), System.Drawing.Image)
        Me.KryptonButton1.Values.Text = "Critical Status"
        '
        'KryptonButton3
        '
        Me.KryptonButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton3.Location = New System.Drawing.Point(3, 88)
        Me.KryptonButton3.Name = "KryptonButton3"
        Me.KryptonButton3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton3.Size = New System.Drawing.Size(149, 44)
        Me.KryptonButton3.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton3.StateCommon.Border.Rounding = 0
        Me.KryptonButton3.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Bold)
        Me.KryptonButton3.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonButton3.TabIndex = 18
        Me.KryptonButton3.Values.Image = CType(resources.GetObject("KryptonButton3.Values.Image"), System.Drawing.Image)
        Me.KryptonButton3.Values.Text = "Order Due"
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonButton1)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonButton2)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonButton3)
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.SystemColors.Control
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.stocksgridview)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonHeader1)
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(594, 423)
        Me.KryptonSplitContainer1.SplitterDistance = 160
        Me.KryptonSplitContainer1.SplitterWidth = 0
        Me.KryptonSplitContainer1.TabIndex = 20
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonHeader1.AutoSize = False
        Me.KryptonHeader1.Location = New System.Drawing.Point(11, 1)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(423, 32)
        Me.KryptonHeader1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonHeader1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonHeader1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonHeader1.StateCommon.Border.Width = 0
        Me.KryptonHeader1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Bold)
        Me.KryptonHeader1.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonHeader1.TabIndex = 2
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = ""
        Me.KryptonHeader1.Values.Image = Nothing
        '
        'NotiForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 423)
        Me.Controls.Add(Me.KryptonSplitContainer1)
        Me.Name = "NotiForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notification"
        CType(Me.stocksgridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents stocksgridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton3 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
End Class
