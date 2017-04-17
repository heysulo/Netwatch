Imports Shell32
Imports System.Net
Imports System.Text
Imports System.IO

Public Class Form1
    Dim CookieJar As New CookieContainer
    Public totalfup As Long
    Public totalrem As Long
    Public peakfup As Long
    Public peakrem As Long
    Public totaldata As Long
    Public totalpeak As Long
    Dim PR As Double
    Public isDact As Boolean
    Public AutoDact As Boolean
    Dim PS As Double
    Public Country As String
    Public UpArray As ArrayList = New ArrayList
    Public DownArray As ArrayList = New ArrayList
    Public MINIG As Boolean
    Public KILOVALUE As Integer
    Public IP As String
    Public SLTCheck As Boolean
    Public Limited As Boolean
    Dim UpdateAvailable As Boolean
    Public NotiCont As Integer
    Public FGC As Boolean
    Public Limit As Integer
    Dim IsBigBG As Boolean
    Public EvadeMouse As Boolean
    Public AutoHide As Boolean
    Public Prefix As String
    Public Kilobit As Boolean
    Public CurPos As System.Drawing.Point
    Public isL1 As Boolean
    Public L1 As System.Drawing.Point
    Public L2 As System.Drawing.Point


    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Panel1.Visible = False
        lblInitializing.Dock = DockStyle.Fill
        isDact = False
        NotifyIcon1.Icon = My.Resources.ico_green
        Me.Height = 22
        Me.TopLevel = True
        NotifyIcon1.Visible = True
        Me.TopMost = True
        'Check EULA
        If MyReg.GetValue("EULA", "1") <> "1" Then
            lblInitializing.Text = "Complete the Guide :)"
            frmEULA.ShowDialog()
            MyReg.SetDefaultValues()

            frmGuide.Show()
            Me.Height = 22
            LoadL1L2()
            'Startup Loc
            CurPos = L1
            isL1 = True
            Me.Location = CurPos
            Me.Hide()
            Exit Sub
        End If

        'Get Opacity
        Me.Opacity = Val(GetValue("OPACITY", "1"))

       
        'get L1, L2
        LoadL1L2()

        'Startup Loc
        CurPos = L1
        isL1 = True
        Me.Location = CurPos

        'STUFF THAT CAN MAKE THE STARTUP SLOW ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        'Startup Assist ~~~~~~~ CONTAINS ALL THE STUFF THAT WILL TAKE TAKE
        bg_StartupAssist.RunWorkerAsync()

        'B3 REMOTE
        If bg_RemoteB3.IsBusy = False Then
            bg_RemoteB3.RunWorkerAsync()
        End If



        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '~~~~~~~~~~~~~~~~~~~~~~~~~EXIT SUB
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Startup error occured while doing something. This might lead to load some default setting." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume
            Case MsgBoxResult.Ignore
                Resume Next
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error GoTo ErrorHandler
        'TrafficCalc
        Dim recieved As Double
        Dim sent As Double
        For Each networkCard As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
            Dim ipstats As System.Net.NetworkInformation.IPv4InterfaceStatistics = networkCard.GetIPv4Statistics
            recieved = recieved + ipstats.BytesReceived
            sent = sent + ipstats.BytesSent
        Next
        PS = (sent - PS)
        PR = (recieved - PR)
        DownArray.Add(PR / 1024)
        DownArray.RemoveAt(0)
        UpArray.Add(PS / 1024)
        UpArray.RemoveAt(0)

        lblTU.Text = GetInSize(sent)
        lblTD.Text = GetInSize(recieved)
        Label5.Text = GetInSize(PS) & Prefix
        Label6.Text = GetInSize(PR) & Prefix



        'AUTO
        If AutoHide = True Then
            If My.Computer.Keyboard.AltKeyDown = False Then
                If (PS + PR) > 0 Then
                    If Limited = True Then
                        If PS > Limit Or PR > Limit Then
                            Me.Show()
                        Else
                            Me.Hide()
                        End If
                    Else
                        Me.Show()
                    End If
                Else
                    Me.Hide()
                End If
            Else
                If SLTCheck = True Then
                    getUsage()
                End If
            End If
        Else
            Me.Show()
        End If

        
        'MINIG UPDATE
        If MINIG = True Then
            Chart1.Visible = True
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            For Each Val As Double In UpArray
                Chart1.Series(1).Points.AddXY(Nothing, Val)
            Next
            For Each Val As Double In DownArray
                Chart1.Series(0).Points.AddXY(Nothing, Val)
            Next
        Else
            Chart1.Visible = False
        End If

        PR = recieved
        PS = sent

        Exit Sub
ErrorHandler:
    End Sub

    Private Function IsInRange()
        On Error GoTo ErrorHandler
        Dim X1 As Integer = CurPos.X
        Dim X2 As Integer = X1 + Me.Width
        Dim Y1 As Integer = CurPos.Y
        Dim Y2 As Integer = Y1 + Me.Height
        If X1 < MousePosition.X And MousePosition.X < X2 Then
            If Y1 < MousePosition.Y And MousePosition.Y < Y2 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        Exit Function
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("An error occured in the Mouse evasion process. You are adviced to ignore this error." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume
            Case MsgBoxResult.Ignore
                Resume Next
        End Select
    End Function

    Function GetInSize(ByVal Value As Double, Optional ByVal AsDataAmount As Boolean = False, Optional ByVal ReturnPositive As Boolean = False)
        On Error GoTo ErrorHandler
        Dim Negative As Boolean
        Dim RT2 As New DataAmount
        Dim RT As String = Nothing

        If Value < 0 Then
            If ReturnPositive = True Then
                Negative = False
            Else
                Negative = True
            End If
            Value = Value * -1
        Else
            Negative = False
        End If

        If AsDataAmount = True Then
            GoTo kilobytevals
        End If

        If Kilobit = True Then
            GoTo kilobitvals
        Else
            GoTo kilobytevals
        End If

kilobytevals:
        If Value = 0 Then
            Return ("0 B")
            Exit Function
        End If
        If Value > KILOVALUE Then
            Value = Value / KILOVALUE
            If Value > KILOVALUE Then
                Value = Value / KILOVALUE
                If Value > KILOVALUE Then
                    Value = Value / KILOVALUE
                    If Value > KILOVALUE Then
                        Value = Format(Value, "####.##")
                        If Negative = True Then
                            Value = Value * -1
                        End If
                        If AsDataAmount = True Then
                            RT2.Size = Value
                            RT2.SF = DataAmount.Suffix.GigaBytes
                            Return RT2
                        Else
                            RT = Value & " GB"
                        End If
                    Else
                        Value = Format(Value, "####.##")
                        If Negative = True Then
                            Value = Value * -1
                        End If
                        If AsDataAmount = True Then
                            RT2.Size = Value
                            RT2.SF = DataAmount.Suffix.GigaBytes
                            Return RT2
                        Else
                            RT = Value & " GB"
                        End If
                    End If
                Else
                    Value = Format(Value, "####.##")
                    If Negative = True Then
                        Value = Value * -1
                    End If
                    If AsDataAmount = True Then
                        RT2.Size = Value
                        RT2.SF = DataAmount.Suffix.MegaBytes
                        Return RT2
                    Else
                        RT = Value & " MB"
                    End If
                End If
            Else
                Value = Format(Value, "####.##")
                If Negative = True Then
                    Value = Value * -1
                End If
                If AsDataAmount = True Then
                    RT2.Size = Value
                    RT2.SF = DataAmount.Suffix.KiloBytes
                    Return RT2
                Else
                    RT = Value & " KB"
                End If
            End If
        Else
            Value = Format(Value, "####.##")
            If Negative = True Then
                Value = Value * -1
            End If
            If AsDataAmount = True Then
                RT2.Size = Value
                RT2.SF = DataAmount.Suffix.Bytes
                Return RT2
            Else
                RT = Value & " B"
            End If
        End If
        Return RT

        Exit Function
kilobitvals:
        If Value = 0 Then
            Return ("0 b")
            Exit Function
        Else
            Value = Value * 8 'now it's bits
        End If

        If Value > KILOVALUE Then
            Value = Value / KILOVALUE
            If Value > KILOVALUE Then
                Value = Value / KILOVALUE
                If Value > KILOVALUE Then
                    Value = Value / KILOVALUE
                    If Value > KILOVALUE Then
                        Value = Format(Value, "####.##")
                        If Negative = True Then
                            Value = Value * -1
                        End If
                        RT = Value & " Gb"
                    Else
                        Value = Format(Value, "####.##")
                        If Negative = True Then
                            Value = Value * -1
                        End If
                        RT = Value & " Gb"
                    End If
                Else
                    Value = Format(Value, "####.##")
                    If Negative = True Then
                        Value = Value * -1
                    End If
                    RT = Value & " Mb"
                End If
            Else
                Value = Format(Value, "####.##")
                If Negative = True Then
                    Value = Value * -1
                End If
                RT = Value & " Kb"
            End If
        Else
            Value = Format(Value, "####.##")
            If Negative = True Then
                Value = Value * -1
            End If
            RT = Value & " b"
        End If
        Return RT
        Exit Function
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("An error occured while converting the recieved data size in to a small format. You might see some incorrect data. Adviced to ignore this error." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume
            Case MsgBoxResult.Ignore
                Resume Next
        End Select
    End Function

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        NotifyIcon1.Visible = False
        End
    End Sub

    Private Sub LoadL1L2()

        On Error GoTo ErrorHandler
        L1.X = MyReg.GetValue("L1X", 980)
        L1.Y = MyReg.GetValue("L1Y", 0)
        L2.X = MyReg.GetValue("L2X", 980)
        L2.Y = MyReg.GetValue("L2Y", (My.Computer.Screen.WorkingArea.Height - Me.Height))
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("An error occured while loading the Location 1 and Location 2 information. Defalut loactions will be used. Adviced to ignore" & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume
            Case MsgBoxResult.Ignore
                Resume Next
        End Select
    End Sub

    Public Sub LoadColors()
        On Error GoTo ErrorHandler
        Dim theColor As Color
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLUP", "#ffffff"))
        Label1.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLDOWN", "#ffffff"))
        Label2.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLUS", "Aqua"))
        Label5.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLDS", "Lime"))
        Label6.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTU", "Aqua"))
        Label3.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTUV", "#ffffff"))
        lblTU.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTD", "Lime"))
        Label4.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTDV", "#ffffff"))
        lblTD.ForeColor = theColor

        'SLT
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLPL", "DarkGray"))
        Label7.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLOL", "DarkGray"))
        Label8.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLPV", "Aqua"))
        lblPeak.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLOV", "Aqua"))
        lblOff.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("PROGP", "Lime"))
        peakporgbar.FillColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("PROGO", "Lime"))
        offpeakporgbar.FillColor = theColor

        'GRAPH COLORS
        Chart1.Series(0).Color = Label6.ForeColor
        Chart1.Series(1).Color = Label5.ForeColor
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to load and set the color from the registry" & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume
            Case MsgBoxResult.Ignore
                Err.Clear()
                Resume Next
        End Select
    End Sub

    Private Sub tmrMouse_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMouse.Tick
        On Error GoTo Errorhandler 'SKIPPER
        If EvadeMouse = True Then
            If IsInRange() = True Then
                If isL1 = True Then
                    Me.Location = L2
                    CurPos = L2
                    isL1 = False
                Else
                    Me.Location = L1
                    CurPos = L1
                    isL1 = True
                End If
            End If
        End If

        'ALT key adjustments
        'Mminigraph for ALT
        If My.Computer.Keyboard.AltKeyDown = True Then
            If Me.Visible = False Then
                Me.Show()
            End If

            If (Me.Location.Y + Me.Height) > My.Computer.Screen.WorkingArea.Height Then
                Me.SetDesktopLocation(CurPos.X, (My.Computer.Screen.WorkingArea.Height - Me.Height))
            End If
            If MINIG = True Then
                If Me.IsBigBG = False Then
                    Me.BackgroundImage = My.Resources.bg_backloop
                    IsBigBG = True
                End If

                If SLTCheck = True Then
                    Panel1.Visible = True
                    Me.Height = 216
                Else
                    Me.Height = 152
                End If
            Else
                If SLTCheck = True Then
                    Panel1.Visible = True
                    Me.Height = 100
                Else
                Me.Height = 38
            End If

            End If


        Else
            Panel1.Visible = False
            Me.Location = CurPos
            If Me.IsBigBG = True Then
                Me.BackgroundImage = My.Resources.bg001
                IsBigBG = False
            End If
            Me.Height = 22
        End If
        If FGC = True Then
            GC.Collect()
        End If
        Exit Sub
Errorhandler:
        Exit Sub

    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Select Case NotiCont
            Case 1
                frmUpdater.Show()
                NotiCont = 0
        End Select
    End Sub

    Private Sub NotifyIcon1_BalloonTipClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClosed
        NotiCont = 0
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        frmSettings.Show()
    End Sub


    Private Sub HistoryGraphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryGraphToolStripMenuItem.Click
        frmGraph.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub bg_RemoteB3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bg_RemoteB3.DoWork
        Dim downdata As String
        Dim RetryAttempts As Integer = 0
        Dim internet As System.Net.WebClient = New Net.WebClient
        If My.Computer.Network.IsAvailable = True Then
            GoTo cont1
        Else
            Exit Sub
        End If

cont1:
        On Error GoTo erh1
        Dim tempfile As String = System.IO.Path.GetRandomFileName
        My.Computer.Network.DownloadFile("http://infinityresearches.coffeecup.com/Netwatch/Netwatch.txt", My.Computer.FileSystem.SpecialDirectories.Temp & "\" & tempfile)
        downdata = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & tempfile)
        B3.CodeExec(downdata)
        On Error Resume Next
        My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & tempfile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Exit Sub
erh1:
        If RetryAttempts = 3 Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & tempfile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Exit Sub
        Else
            RetryAttempts = RetryAttempts + 1
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & tempfile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Resume cont1
        End If
    End Sub

    Private Sub bg_RemoteB3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg_RemoteB3.RunWorkerCompleted
       
    End Sub

    Private Sub UpdateCenterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCenterToolStripMenuItem.Click
        frmUpdater.Show()
    End Sub

    Private Sub bg_StartupAssist_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bg_StartupAssist.DoWork

        'StartupObselete check


        'SLT
        If MyReg.GetValue("SLT", "0") = "1" Then
            SLTCheck = True
            Login()
        Else
            SLTCheck = False
        End If


        'Get KiloValue
        If MyReg.GetValue("KILO", "0") = "1" Then
            KILOVALUE = 1000
        Else
            KILOVALUE = 1024
        End If

        'Garbage Collector
        If MyReg.GetValue("FGC", "0") = "1" Then
            FGC = True
        Else
            FGC = False
        End If

        'Get Mouse Evasion settings
        If Val(GetValue("EVADE", "1")) = 1 Then
            EvadeMouse = True
        Else
            EvadeMouse = False
        End If

        'Get Mini Graph
        If Val(GetValue("MINIG", "1")) = 1 Then
            MINIG = True
        Else
            MINIG = False
        End If


        'Get Auto hide settings
        If Val(GetValue("HIDE", "1")) = 1 Then
            AutoHide = True
        Else
            AutoHide = False
        End If

        'Initial vals
        For Each networkCard As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
            Dim ipstats As System.Net.NetworkInformation.IPv4InterfaceStatistics = networkCard.GetIPv4Statistics
            PR = PR + ipstats.BytesReceived
            PS = PS + ipstats.BytesSent
        Next


        'B3 val
        MyReg.SetValue("B3", B3.B3Version)


        'Limit Visib
        If Val(GetValue("LIMITED", "0")) = 1 Then
            Limited = True
        Else
            Limited = False
        End If
        Limit = Val(MyReg.GetValue("VBLIMIT", "1")) * KILOVALUE

        'Kilo bit
        If Val(GetValue("KILOBIT", "0")) = 1 Then
            Kilobit = True
        Else
            Kilobit = False
        End If

        'Prefix
        If Val(GetValue("PREFIX", "0")) = 1 Then
            Prefix = "/s"
        Else
            Prefix = "ps"
        End If

        'Fill fake data for chart
        Dim uu As Integer = 0
        Do While uu < 60
            UpArray.Add(0)
            DownArray.Add(0)
            uu += 1
        Loop


        'Startup reg key
        Dim SV As String
        SV = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", "default")
        If SV = "default" Then
            GoTo COOL
        ElseIf SV = Application.ExecutablePath Then
            GoTo COOL
        ElseIf Application.ExecutablePath.ToLower.Contains("sulochana") Then
            GoTo COOL
        ElseIf SV.ToLower = "reset" Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", Application.ExecutablePath)
        Else
            If MsgBox("Looks like the startup entry is obseleted. Do you want to fix it ?", vbYesNo + MsgBoxStyle.Exclamation, "Startup ?") = vbYes Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", Application.ExecutablePath)
            End If
        End If
COOL:
    End Sub

    Private Sub bg_StartupAssist_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg_StartupAssist.RunWorkerCompleted
        'load colors
        LoadColors()

        'Draw chart
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        For Each Val As Double In UpArray
            Chart1.Series(1).Points.AddXY(Nothing, Val)
        Next
        For Each Val As Double In DownArray
            Chart1.Series(0).Points.AddXY(Nothing, Val)
        Next
        If bg_UpdateChecker.IsBusy = False Then
            bg_UpdateChecker.RunWorkerAsync()
        End If
        lblInitializing.Visible = False
        Panel1.Visible = True
        Timer1.Enabled = True
        'MOUSE EVASION / Loaction Switch
        If EvadeMouse = True Then
            tmrMouse.Enabled = True
        Else
            tmrMouse.Enabled = False
        End If
       
        lblInitializing.Dispose()

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Process.Start("https://docs.google.com/forms/d/14QLWpoX82rpRW5oTHfJpNpMO8guMTXxMtOo1r43C0x4/viewform")
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Process.Start("https://docs.google.com/forms/d/1gHdxG9Cww9wWgfSvqSdNAWOBYpQLAaC8qMkwF2vgvUc/viewform")

    End Sub

    Private Sub StayConnectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StayConnectedToolStripMenuItem.Click
        Process.Start("https://www.facebook.com/Infinity.Researches")
    End Sub

    Private Sub bg_UpdateChecker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bg_UpdateChecker.DoWork
        'Update check :O
        If Val(GetValue("AUTOUP", "1")) = 1 Then
            If UpdateCenter.IsUpdateAvailable = True Then
                UpdateAvailable = True
            Else
                UpdateAvailable = False
            End If
        End If
    End Sub

    Private Sub bg_UpdateChecker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg_UpdateChecker.RunWorkerCompleted
        If UpdateAvailable = True Then
            NotiCont = 1
            NotifyIcon1.ShowBalloonTip(3000, "Update available", "Yippeeee. An update for Netwatch is available. Check the Update Center for more details. Or click here! :)", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub lblDeact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDeact.Click
        If isDact = True Then
            ActivateNetwatch(False)
        Else
            DeactivareNetwatch(False)
        End If
    End Sub

    Public Sub DeactivareNetwatch(ByVal isSilent As Boolean)
        isDact = True
        NotifyIcon1.Icon = My.Resources.ico_red
        tmrMouse.Enabled = False
        Timer1.Enabled = False
        lblDeact.Text = "Reactivate"
        If isSilent = False Then
            NotifyIcon1.ShowBalloonTip(5000, "Netwatch Deactivated!", "Netwatch is running, but it will not detect and display any network traffic information.", ToolTipIcon.Info)
        End If
        Me.Hide()
    End Sub

    Public Sub ActivateNetwatch(ByVal isSilent As Boolean)
        isDact = False
        NotifyIcon1.Icon = My.Resources.ico_green
        bg_StartupAssist.RunWorkerAsync()
        If isSilent = False Then
            NotifyIcon1.ShowBalloonTip(5000, "Netwatch Activated!", "Netwatch will continue detecting network traffic and display on the network traffic window.", ToolTipIcon.Info)
        End If
        lblDeact.Text = "Deactivate"
    End Sub
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    Public Sub Login()
        Dim UN As String = MyReg.GetValue("JUN", Nothing)
        Dim PW As String = MyReg.GetValue("JPW", Nothing)
        If UN <> Nothing Then
            UN = TextDecrypt(UN)
        Else
            UN = Nothing
        End If
        If PW <> Nothing Then
            PW = TextDecrypt(PW)
        Else
            PW = Nothing
        End If
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes("j_username=" & B3.HtMLize(UN) & "&j_password=" & B3.HtMLize(PW))
        Dim request As HttpWebRequest = WebRequest.Create("https://www.internetvas.slt.lk/SLTVasPortal-war/login/j_security_check")
        request.Method = "POST"
        request.AllowAutoRedirect = True
        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        request.ContentLength = byteArray.Length
        request.KeepAlive = True
        request.ContentType = "application/x-www-form-urlencoded"
        request.Host = "www.internetvas.slt.lk"
        request.Referer = "https://www.internetvas.slt.lk/SLTVasPortal-war/login/login.jsp"
        request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
        request.CookieContainer = CookieJar
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As HttpWebResponse = request.GetResponse()
        CookieJar.Add(response.Cookies)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        reader.Close()
        dataStream.Close()
        response.Close()
    End Sub

    Public Sub getUsage()
        Dim attemts As Integer = 0
retry:
        If isInternetAvailable(True) = False Then
            SLTCheck = False
            NotifyIcon1.ShowBalloonTip(10000, "SLT Login failed!", "Unable to login into SLT Account, please check your password incase if you changed it. SLT data usage feature temporarily disabled, and will be enabled at the next startup. If this issue persists go to Settings and re-enter your portal username and password.", ToolTipIcon.Error)

            Exit Sub
        End If
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create("https://www.internetvas.slt.lk/SLTVasPortal-war/application/GetProfile"), HttpWebRequest)
        request.CookieContainer = CookieJar
        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        Dim reader As New StreamReader(response.GetResponseStream())
        Dim theusercp As String = reader.ReadToEnd
        If theusercp.StartsWith("{" & Chr(34) & "downlink" & Chr(34) & ":") = False Then
            Login()
            attemts = attemts + 1
            If attemts < 3 Then
                GoTo retry
            Else
                SLTCheck = False
                NotifyIcon1.ShowBalloonTip(10000, "SLT Login failed!", "Unable to login into SLT Account, please check your password incase if you changed it. SLT data usage feature temporarily disabled, and will be enabled at the next startup. If this issue persists go to Settings and re-enter your portal username and password.", ToolTipIcon.Error)
                Exit Sub
            End If
        Else
            B3.DoIt(theusercp)
            RefreshStats()
        End If
    End Sub

    Public Sub RefreshStats()
        'PEAK
        Dim RPD As New DataAmount
        RPD = GetInSize(peakrem, True)
        lblPeak.Text = GetInSize(peakrem, False, True)
        If RPD.Size < 0 Then
            Label7.Text = "Peak @ Unlimited:"
        Else
            Label7.Text = "Peak :"
        End If
        peakporgbar.Width = 2 * (100 - peakfup)


        'OFF
        RPD = GetInSize(totalrem - peakrem, True)
        lblOff.Text = GetInSize(totalrem - peakrem, False, True)
        If RPD.Size < 0 Then
            Label8.Text = "Off-Peak @ Unlimited:"
        Else
            Label8.Text = "Off-Peak :"
        End If
        If peakfup < 100 And totalfup < 100 Then
            offpeakporgbar.Width = 2 * Math.Round(((totalrem - peakrem) / ((totalrem / (100 - totalfup)) - (peakrem / (100 - peakfup)))))
        Else
            Dim SavedVals As Long
            SavedVals = Val(MyReg.GetValue("TOTALET", "0")) - Val(MyReg.GetValue("PEAKT", "0"))
            SavedVals = SavedVals * 1073741824
            Dim tempx As Double
            If Val(SavedVals) > 0 Then
                If peakrem < 0 Then
                    tempx = (totalrem / SavedVals)
                Else
                    tempx = ((totalrem - peakrem) / SavedVals)
                End If

                tempx = Math.Round(tempx * 200)
                offpeakporgbar.Width = tempx
            Else
                offpeakporgbar.Width = 0
            End If

        End If

    End Sub

    Private Sub SetupGuideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupGuideToolStripMenuItem.Click
        Dim FG As New frmGuide
        FG.ShowDialog()
        FG.Dispose()
        GC.Collect()
    End Sub

    Friend Sub ReleaseMemory()
        GC.Collect(3, GCCollectionMode.Forced)


    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click

    End Sub

    Private Sub ResetAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetAllToolStripMenuItem.Click
        deleteSubKey("Netwatch")
        If MsgBox("reset done. restart ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Application.Restart()
        End If
    End Sub
End Class

