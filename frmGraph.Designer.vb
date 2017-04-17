<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraph
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraph))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowLegendsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HoldThisPositionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.AxisX.IsMarginVisible = False
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX2.IsMarginVisible = False
        ChartArea1.AxisX2.LabelStyle.Enabled = False
        ChartArea1.AxisX2.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisX2.MajorTickMark.Enabled = False
        ChartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.Title = "Speed (KB/s)"
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY2.MajorTickMark.Enabled = False
        ChartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY2.Title = "Speed (KB/s)"
        ChartArea1.BackColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.BackColor = System.Drawing.Color.White
        Legend1.BorderColor = System.Drawing.Color.Black
        Legend1.DockedToChartArea = "ChartArea1"
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Color = System.Drawing.Color.DodgerBlue
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold)
        Series1.LabelForeColor = System.Drawing.Color.Gray
        Series1.LabelFormat = "{0.0}"
        Series1.Legend = "Legend1"
        Series1.LegendText = "Download"
        Series1.Name = "D"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Color = System.Drawing.Color.LimeGreen
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold)
        Series2.LabelForeColor = System.Drawing.Color.Gray
        Series2.LabelFormat = "{0.0}"
        Series2.Legend = "Legend1"
        Series2.LegendText = "Upload"
        Series2.Name = "U"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(543, 322)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowLegendsToolStripMenuItem, Me.HoldThisPositionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(169, 48)
        '
        'ShowLegendsToolStripMenuItem
        '
        Me.ShowLegendsToolStripMenuItem.Checked = True
        Me.ShowLegendsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowLegendsToolStripMenuItem.Name = "ShowLegendsToolStripMenuItem"
        Me.ShowLegendsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ShowLegendsToolStripMenuItem.Text = "Show Legends"
        '
        'HoldThisPositionToolStripMenuItem
        '
        Me.HoldThisPositionToolStripMenuItem.Name = "HoldThisPositionToolStripMenuItem"
        Me.HoldThisPositionToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.HoldThisPositionToolStripMenuItem.Text = "Hold this position"
        '
        'frmGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 322)
        Me.Controls.Add(Me.Chart1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGraph"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Netwatch Graph"
        Me.TopMost = True
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowLegendsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HoldThisPositionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
