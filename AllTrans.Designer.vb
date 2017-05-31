<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllTrans
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TRANS_TBBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.inventoryds = New kinventory.inventoryds()
        CType(Me.TRANS_TBBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.inventoryds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.TRANS_TBBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "kinventory.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(695, 460)
        Me.ReportViewer1.TabIndex = 0
        '
        'TRANS_TBBindingSource
        '
        Me.TRANS_TBBindingSource.DataMember = "TRANS_TB"
        Me.TRANS_TBBindingSource.DataSource = Me.inventoryds
        '
        'inventoryds
        '
        Me.inventoryds.DataSetName = "inventoryds"
        Me.inventoryds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AllTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 460)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "AllTrans"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "All Transactions"
        CType(Me.TRANS_TBBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.inventoryds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TRANS_TBBindingSource As BindingSource
    Friend WithEvents inventoryds As inventoryds
End Class
