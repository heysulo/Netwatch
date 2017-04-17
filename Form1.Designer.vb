<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.lblTD = New System.Windows.Forms.Label()
        Me.lblTU = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StayConnectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupGuideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.HistoryGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblDeact = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrMouse = New System.Windows.Forms.Timer(Me.components)
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.bg_RemoteB3 = New System.ComponentModel.BackgroundWorker()
        Me.bg_StartupAssist = New System.ComponentModel.BackgroundWorker()
        Me.lblInitializing = New System.Windows.Forms.Label()
        Me.bg_UpdateChecker = New System.ComponentModel.BackgroundWorker()
        Me.lblOff = New System.Windows.Forms.Label()
        Me.lblPeak = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.offpeakporgbar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.peakporgbar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTD
        '
        Me.lblTD.AutoSize = True
        Me.lblTD.BackColor = System.Drawing.Color.Transparent
        Me.lblTD.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTD.ForeColor = System.Drawing.Color.White
        Me.lblTD.Location = New System.Drawing.Point(143, 20)
        Me.lblTD.Name = "lblTD"
        Me.lblTD.Size = New System.Drawing.Size(31, 13)
        Me.lblTD.TabIndex = 17
        Me.lblTD.Text = "0000"
        '
        'lblTU
        '
        Me.lblTU.AutoSize = True
        Me.lblTU.BackColor = System.Drawing.Color.Transparent
        Me.lblTU.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTU.ForeColor = System.Drawing.Color.White
        Me.lblTU.Location = New System.Drawing.Point(33, 20)
        Me.lblTU.Name = "lblTU"
        Me.lblTU.Size = New System.Drawing.Size(31, 13)
        Me.lblTU.TabIndex = 16
        Me.lblTU.Text = "0000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(109, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "▼ :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Aqua
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "▲ : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(143, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "0000 bitsps"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(104, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Down :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Aqua
        Me.Label5.Location = New System.Drawing.Point(33, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "0000 bitsps"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Up :"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Netwatch"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.ContextMenuStrip1.DropShadowEnabled = False
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ToolStripMenuItem2, Me.StayConnectedToolStripMenuItem, Me.ToolStripMenuItem1, Me.SetupGuideToolStripMenuItem, Me.ToolStripSeparator1, Me.TestToolStripMenuItem, Me.UpdateCenterToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator3, Me.HistoryGraphToolStripMenuItem, Me.ToolStripSeparator2, Me.lblDeact, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.ShowItemToolTips = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(142, 264)
        Me.ContextMenuStrip1.Text = "Netwatch"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AboutToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        Me.AboutToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.Yellow
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(141, 22)
        Me.ToolStripMenuItem2.Text = "Report a Problem"
        '
        'StayConnectedToolStripMenuItem
        '
        Me.StayConnectedToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua
        Me.StayConnectedToolStripMenuItem.Name = "StayConnectedToolStripMenuItem"
        Me.StayConnectedToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.StayConnectedToolStripMenuItem.Text = "Stay Connected"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.ToolStripMenuItem1.Text = "Send Feedback"
        '
        'SetupGuideToolStripMenuItem
        '
        Me.SetupGuideToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SetupGuideToolStripMenuItem.Name = "SetupGuideToolStripMenuItem"
        Me.SetupGuideToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SetupGuideToolStripMenuItem.Text = "Setup Guide"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetAllToolStripMenuItem})
        Me.TestToolStripMenuItem.ForeColor = System.Drawing.Color.LightCoral
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.TestToolStripMenuItem.Text = "Developer"
        '
        'ResetAllToolStripMenuItem
        '
        Me.ResetAllToolStripMenuItem.Name = "ResetAllToolStripMenuItem"
        Me.ResetAllToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ResetAllToolStripMenuItem.Text = "Reset All"
        '
        'UpdateCenterToolStripMenuItem
        '
        Me.UpdateCenterToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.UpdateCenterToolStripMenuItem.Name = "UpdateCenterToolStripMenuItem"
        Me.UpdateCenterToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.UpdateCenterToolStripMenuItem.Text = "Update Center"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(138, 6)
        '
        'HistoryGraphToolStripMenuItem
        '
        Me.HistoryGraphToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HistoryGraphToolStripMenuItem.Name = "HistoryGraphToolStripMenuItem"
        Me.HistoryGraphToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.HistoryGraphToolStripMenuItem.Text = "History Graph"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(138, 6)
        '
        'lblDeact
        '
        Me.lblDeact.ForeColor = System.Drawing.Color.White
        Me.lblDeact.Name = "lblDeact"
        Me.lblDeact.Size = New System.Drawing.Size(141, 22)
        Me.lblDeact.Text = "Deactivate"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'tmrMouse
        '
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.IsMarginVisible = False
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.LineColor = System.Drawing.Color.White
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.White
        ChartArea1.AxisX2.IsMarginVisible = False
        ChartArea1.AxisX2.LabelStyle.Enabled = False
        ChartArea1.AxisX2.LineColor = System.Drawing.Color.White
        ChartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisX2.MajorTickMark.Enabled = False
        ChartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.0!)
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea1.AxisY.LineColor = System.Drawing.Color.White
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.White
        ChartArea1.AxisY2.IsLabelAutoFit = False
        ChartArea1.AxisY2.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.0!)
        ChartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.White
        ChartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY2.MajorTickMark.Enabled = False
        ChartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY2.Title = "Speed (KB/s)"
        ChartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 98.0!
        ChartArea1.Position.Width = 99.0!
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.White
        Legend1.BorderColor = System.Drawing.Color.Black
        Legend1.DockedToChartArea = "ChartArea1"
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Legend1.Enabled = False
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(-1, 39)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Color = System.Drawing.Color.DodgerBlue
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Series1.LabelForeColor = System.Drawing.Color.White
        Series1.LabelFormat = "{0.0}"
        Series1.Legend = "Legend1"
        Series1.LegendText = "Download"
        Series1.Name = "D"
        Series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No
        Series1.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Round
        Series1.SmartLabelStyle.IsMarkerOverlappingAllowed = True
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Color = System.Drawing.Color.LimeGreen
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Series2.LabelForeColor = System.Drawing.Color.White
        Series2.LabelFormat = "{0.0}"
        Series2.Legend = "Legend1"
        Series2.LegendText = "Upload"
        Series2.Name = "U"
        Series2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No
        Series2.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Round
        Series2.SmartLabelStyle.IsMarkerOverlappingAllowed = True
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(210, 113)
        Me.Chart1.TabIndex = 18
        Me.Chart1.Text = "Chart1"
        '
        'bg_RemoteB3
        '
        '
        'bg_StartupAssist
        '
        '
        'lblInitializing
        '
        Me.lblInitializing.BackColor = System.Drawing.Color.Transparent
        Me.lblInitializing.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInitializing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitializing.ForeColor = System.Drawing.Color.White
        Me.lblInitializing.Location = New System.Drawing.Point(0, 0)
        Me.lblInitializing.Name = "lblInitializing"
        Me.lblInitializing.Size = New System.Drawing.Size(212, 10)
        Me.lblInitializing.TabIndex = 19
        Me.lblInitializing.Text = "Initializing"
        Me.lblInitializing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bg_UpdateChecker
        '
        '
        'lblOff
        '
        Me.lblOff.ForeColor = System.Drawing.Color.Aqua
        Me.lblOff.Location = New System.Drawing.Point(112, 33)
        Me.lblOff.Name = "lblOff"
        Me.lblOff.Size = New System.Drawing.Size(95, 13)
        Me.lblOff.TabIndex = 4
        Me.lblOff.Text = "N\A"
        Me.lblOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPeak
        '
        Me.lblPeak.ForeColor = System.Drawing.Color.Aqua
        Me.lblPeak.Location = New System.Drawing.Point(112, 4)
        Me.lblPeak.Name = "lblPeak"
        Me.lblPeak.Size = New System.Drawing.Size(95, 13)
        Me.lblPeak.TabIndex = 3
        Me.lblPeak.Text = "N\A"
        Me.lblPeak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DarkGray
        Me.Label8.Location = New System.Drawing.Point(3, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Off-Peak : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkGray
        Me.Label7.Location = New System.Drawing.Point(4, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Peak : "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.Netwatch.My.Resources.Resources.bg_backloop
        Me.Panel1.Controls.Add(Me.lblOff)
        Me.Panel1.Controls.Add(Me.lblPeak)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 152)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(212, 63)
        Me.Panel1.TabIndex = 20
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.offpeakporgbar, Me.RectangleShape3, Me.peakporgbar, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(212, 63)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'offpeakporgbar
        '
        Me.offpeakporgbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.offpeakporgbar.BorderColor = System.Drawing.Color.Transparent
        Me.offpeakporgbar.FillColor = System.Drawing.Color.Lime
        Me.offpeakporgbar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.offpeakporgbar.Location = New System.Drawing.Point(7, 49)
        Me.offpeakporgbar.Name = "offpeakporgbar"
        Me.offpeakporgbar.Size = New System.Drawing.Size(130, 4)
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.Silver
        Me.RectangleShape3.Location = New System.Drawing.Point(6, 48)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(200, 5)
        '
        'peakporgbar
        '
        Me.peakporgbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.peakporgbar.BorderColor = System.Drawing.Color.Transparent
        Me.peakporgbar.FillColor = System.Drawing.Color.Lime
        Me.peakporgbar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.peakporgbar.Location = New System.Drawing.Point(7, 22)
        Me.peakporgbar.Name = "peakporgbar"
        Me.peakporgbar.Size = New System.Drawing.Size(130, 4)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Silver
        Me.RectangleShape1.Location = New System.Drawing.Point(6, 21)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(200, 5)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.BackgroundImage = Global.Netwatch.My.Resources.Resources.png
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(212, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblInitializing)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.lblTD)
        Me.Controls.Add(Me.lblTU)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Netwatch"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTD As System.Windows.Forms.Label
    Friend WithEvents lblTU As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrMouse As System.Windows.Forms.Timer
    Friend WithEvents HistoryGraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bg_RemoteB3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents UpdateCenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bg_StartupAssist As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblInitializing As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StayConnectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bg_UpdateChecker As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblDeact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblOff As System.Windows.Forms.Label
    Friend WithEvents lblPeak As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents offpeakporgbar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents peakporgbar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents SetupGuideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
