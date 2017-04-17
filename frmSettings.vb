Imports Microsoft.Win32
Imports System.Net
Imports System.IO
Imports System.Text

Public Class frmSettings
    Public IncCord As Point
    Dim L1 As Point
    Dim L2 As Point
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged


    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            MyReg.SetValue("HIDE", "1")
            Form1.AutoHide = True
        Else
            MyReg.SetValue("HIDE", "0")
            Form1.AutoHide = False
        End If
    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Get opacity
        NumericUpDown1.Value = Val(MyReg.GetValue("OPACITY", Form1.Opacity)) * 100

        'get Auto hide
        If MyReg.GetValue("HIDE", "1") = "1" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

        'get Mini graph
        If MyReg.GetValue("MINIG", "1") = "1" Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If

        'get Evade
        If MyReg.GetValue("EVADE", "1") = "1" Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        'FGC
        If MyReg.GetValue("FGC", "0") = "1" Then
            CheckBox6.Checked = True
        Else
            CheckBox6.Checked = False
        End If

        'get L1 L2
        L1.X = MyReg.GetValue("L1X", 980)
        L1.Y = MyReg.GetValue("L1Y", 0)
        L2.X = MyReg.GetValue("L2X", 980)
        L2.Y = MyReg.GetValue("L2Y", (My.Computer.Screen.WorkingArea.Height - Me.Height))
        lblLoc1.Text = "X : " & L1.X & vbCrLf & "Y : " & L1.Y
        lblLoc2.Text = "X : " & L2.X & vbCrLf & "Y : " & L2.Y

        'load colors
        LoadColors()

        'get kilo value
        If MyReg.GetValue("KILO", "0") = "1" Then
            chkKilo.Checked = True
        Else
            chkKilo.Checked = False
        End If

        'get SLT
        If MyReg.GetValue("SLT", "0") = "1" Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If
        If MyReg.GetValue("JUN", Nothing) <> Nothing Then
            txtUserName.Text = TextDecrypt(MyReg.GetValue("JUN", Nothing))
        End If
        If MyReg.GetValue("JPW", Nothing) <> Nothing Then
            txtPassword.Text = TextDecrypt(MyReg.GetValue("JPW", Nothing))
        End If



        'visiblity limit
        If Val(GetValue("LIMITED", "0")) = 1 Then
            chkLimit.Checked = True
        Else
            chkLimit.Checked = False
        End If
        NumericUpDown2.Value = Val(GetValue("VBLIMIT", "1"))

        'Kilo bit
        If Val(GetValue("KILOBIT", "0")) = 1 Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If

        'prefix
        If Val(GetValue("PREFIX", "0")) = 1 Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If

        'Startup :D
        Dim SV As String
        SV = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", "default")
        If SV = "default" Then
            chkStartUp.Checked = False
        ElseIf SV = Application.ExecutablePath Then
            chkStartUp.Checked = True
        Else
            If MsgBox("Looks like the startup entry is obseleted. Do you want to update it ?", vbYesNo + MsgBoxStyle.Exclamation, "Startup ?") = vbYes Then

                chkStartUp.Checked = True
            End If
        End If


        'Updates
        If Val(MyReg.GetValue("AUTOUP", "1")) = 1 Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub LoadColors()
        On Error GoTo ErrorHandler
        Dim theColor As Color
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLUP", "#ffffff"))
        Label9.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLDOWN", "#ffffff"))
        Label7.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLUS", "Aqua"))
        Label8.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLDS", "Lime"))
        Label6.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTU", "Aqua"))
        Label5.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTUV", "#ffffff"))
        lblTU.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTD", "Lime"))
        Label4.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLTDV", "#ffffff"))
        lblTD.ForeColor = theColor
        'SLT
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLPL", "DarkGray"))
        Label19.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLOL", "DarkGray"))
        Label18.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLPV", "Aqua"))
        lblPeak.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("LBLOV", "Aqua"))
        lblOff.ForeColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("PROGP", "Lime"))
        peakporgbar.FillColor = theColor
        theColor = ColorTranslator.FromHtml(MyReg.GetValue("PROGO", "Lime"))
        RectangleShape2.FillColor = theColor
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


    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            MyReg.SetValue("EVADE", "1")
            Form1.EvadeMouse = True
            GroupBox1.Enabled = True
        Else
            MyReg.SetValue("EVADE", "0")
            Form1.EvadeMouse = False
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error GoTo errh
        IncCord = Nothing
        Dim fakeWin As Form = New frmFakeNM
        fakeWin.StartPosition = FormStartPosition.Manual
        MsgBox("PLEASE READ THE INSTRUCTIONS :" & vbCrLf & vbCrLf & "• When you press the ‘OK’ button a fake Network Traffic window will appear on the previously used location 1." & vbCrLf & "• Drag it to the position where you wish to set as the location 1." & vbCrLf & "• Double click on that window to confirm your decision and save the new location." & vbCrLf & vbCrLf & " Press OK to continue.", MsgBoxStyle.Information, "Set New Location 1")
        fakeWin.DesktopLocation = L1
        Form1.DeactivareNetwatch(True)
        fakeWin.ShowDialog()
        Form1.L1 = IncCord
        L1 = IncCord
        lblLoc1.Text = "X : " & IncCord.X & vbCrLf & "Y : " & IncCord.Y
        MyReg.SetValue("L1X", L1.X)
        MyReg.SetValue("L1Y", L1.Y)
        Form1.ActivateNetwatch(True)
        MsgBox("Your new Location 1 saved, and will take effect immediately.", MsgBoxStyle.Information)
        Exit Sub
errh:
        MsgBox("Failed! please try again", MsgBoxStyle.Critical, "Error occured")
        Form1.ActivateNetwatch(True)
        Exit Sub
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error GoTo errh
        IncCord = Nothing
        Dim fakeWin As Form = New frmFakeNM
        fakeWin.StartPosition = FormStartPosition.Manual
        MsgBox("PLEASE READ THE INSTRUCTIONS :" & vbCrLf & vbCrLf & "• When you press the ‘OK’ button a fake Network Traffic window will appear on the previously used location 2." & vbCrLf & "• Drag it to the position where you wish to set as the location 2." & vbCrLf & "• Double click on that window to confirm your decision and save the new location." & vbCrLf & vbCrLf & " Press OK to continue.", MsgBoxStyle.Information, "Set New Location 2")
        Form1.DeactivareNetwatch(True)
        fakeWin.DesktopLocation = L2
        fakeWin.ShowDialog()
        Form1.L2 = IncCord
        L2 = IncCord
        lblLoc2.Text = "X : " & IncCord.X & vbCrLf & "Y : " & IncCord.Y
        MyReg.SetValue("L2X", L2.X)
        MyReg.SetValue("L2Y", L2.Y)
        Form1.ActivateNetwatch(True)
        MsgBox("Your new Location 2 saved, and will take effect immediately.", MsgBoxStyle.Information)
        Exit Sub
errh:
        MsgBox("Failed! please try again", MsgBoxStyle.Critical, "Error occured")
        Form1.ActivateNetwatch(True)
        Exit Sub
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        On Error GoTo errh
        MyReg.SetValue("OPACITY", ((NumericUpDown1.Value) / 100))
        Form1.Opacity = Val(MyReg.GetValue("OPACITY", "0.9"))
        Exit Sub
errh:
        MsgBox("Failed! please try again", MsgBoxStyle.Critical, "Error occured")
        Exit Sub
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label9.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label9.ForeColor = colordiag.Color
            MyReg.SetValue("LBLUP", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLUP." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label7.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label7.ForeColor = colordiag.Color
            MyReg.SetValue("LBLDOWN", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLDOWN." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label8.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label8.ForeColor = colordiag.Color
            MyReg.SetValue("LBLUS", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLUS." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label6.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label6.ForeColor = colordiag.Color
            MyReg.SetValue("LBLDS", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLDS." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label5.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label5.ForeColor = colordiag.Color
            MyReg.SetValue("LBLTU", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLTU." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub lblTU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTU.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = lblTU.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblTU.ForeColor = colordiag.Color
            MyReg.SetValue("LBLTUV", ColorTranslator.ToHtml(colordiag.Color))
        End If

        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLTUV." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label4.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label4.ForeColor = colordiag.Color
            MyReg.SetValue("LBLTD", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLTD." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub lblTD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTD.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = lblTD.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblTD.ForeColor = colordiag.Color
            MyReg.SetValue("LBLTDV", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLTDV." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        On Error GoTo errh
        If MsgBox("Are you sure that you want to reset the color values ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel, "Reset Color scheme") = vbYes Then
            MyReg.SetValue("LBLUP", "#ffffff")
            MyReg.SetValue("LBLDOWN", "#ffffff")
            MyReg.SetValue("LBLUS", "Aqua")
            MyReg.SetValue("LBLDS", "Lime")
            MyReg.SetValue("LBLTU", "Aqua")
            MyReg.SetValue("LBLTUV", "#ffffff")
            MyReg.SetValue("LBLTD", "Lime")
            MyReg.SetValue("LBLTDV", "#ffffff")
            'SLT
            MyReg.SetValue("LBLPL", "DarkGray")
            MyReg.SetValue("LBLOL", "DarkGray")
            MyReg.SetValue("LBLPV", "Aqua")
            MyReg.SetValue("LBLOV", "Aqua")
            MyReg.SetValue("PROGP", "Lime")
            MyReg.SetValue("PROGO", "Lime")
            LoadColors()
            MsgBox("Deault color settings applied", MsgBoxStyle.Information, "Color scheme changed")
        End If
        Exit Sub
errh:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to save some settings you modified." & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form1.LoadColors()
        MsgBox("Colors settings applied.", MsgBoxStyle.Information, "Color Load")
    End Sub

    Private Sub chkKilo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKilo.CheckedChanged
        If chkKilo.Checked = True Then
            MyReg.SetValue("KILO", "1")
            Form1.KILOVALUE = 1000
        Else
            MyReg.SetValue("KILO", "0")
            Form1.KILOVALUE = 1024
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If MsgBox("Are you sure that you want to discard all your current settings and load the defualt values provided by the developer?", MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel, "Reset All Settings") = vbYes Then
            MyReg.SetDefaultValues()
        End If
    End Sub

    Private Sub chkLimit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLimit.CheckedChanged
        If chkLimit.Checked = True Then
            pnlLimit.Enabled = True
            Form1.Limited = True
            MyReg.SetValue("LIMITED", "1")
        Else
            pnlLimit.Enabled = False
            Form1.Limited = False
            MyReg.SetValue("LIMITED", "0")
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MyReg.SetValue("VBLIMIT", NumericUpDown2.Value)
        Form1.Limit = (NumericUpDown2.Value) * Form1.KILOVALUE
        MsgBox("Saved", MsgBoxStyle.Information)
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            MyReg.SetValue("KILOBIT", "1")
            Form1.Kilobit = True
        Else
            MyReg.SetValue("KILOBIT", "0")
            Form1.Kilobit = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            MyReg.SetValue("PREFIX", "1")
            Form1.Prefix = "/s"
        Else
            MyReg.SetValue("PREFIX", "0")
            Form1.Prefix = "ps"
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            MyReg.SetValue("MINIG", "1")
            Form1.MINIG = True
        Else
            MyReg.SetValue("MINIG", "0")
            Form1.MINIG = False
        End If
    End Sub

    Private Sub chkStartUp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartUp.CheckedChanged
        On Error Resume Next
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        If chkStartUp.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", Application.ExecutablePath)
        Else
            key.DeleteValue("Netwatch", False)
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton1.Checked = True Then
            MyReg.SetValue("AUTOUP", "1")
        Else
            MyReg.SetValue("AUTOUP", "0")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            MyReg.SetValue("AUTOUP", "1")
        Else
            MyReg.SetValue("AUTOUP", "0")
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If UpdateCenter.IsUpdateAvailable = True Then
            frmUpdater.Show()
        Else
            MsgBox("This application is upto date! :)", MsgBoxStyle.Information, "No new updates")
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        CodeExec(TextBox1.Text)
        TextBox1.Text = "Done."
    End Sub


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Form1.Close()
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            Form1.FGC = True
            MyReg.SetValue("FGC", "1")
        Else
            Form1.FGC = False
            MyReg.SetValue("FGC", "0")
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        


    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim CookieJar As New CookieContainer
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes("j_username=" & txtUserName.Text & "&j_password=" & B3.HtMLize(txtPassword.Text))
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

        Dim request2 As HttpWebRequest = DirectCast(WebRequest.Create("https://www.internetvas.slt.lk/SLTVasPortal-war/application/GetProfile"), HttpWebRequest)
        request2.CookieContainer = CookieJar
        Dim response2 As HttpWebResponse = DirectCast(request2.GetResponse(), HttpWebResponse)
        Dim reader2 As New StreamReader(response2.GetResponseStream())
        Dim theusercp2 As String = reader2.ReadToEnd
        If theusercp2.StartsWith("{" & Chr(34) & "downlink" & Chr(34) & ":") = True Then
            If CheckBox7.Checked = True Then
                Form1.SLTCheck = True
                MyReg.SetValue("SLT", "1")
            Else
                Form1.SLTCheck = False
                MyReg.SetValue("SLT", "0")
            End If
            MyReg.SetValue("JPW", TextEncrypt(txtPassword.Text))
            MyReg.SetValue("JUN", TextEncrypt(txtUserName.Text))
            MsgBox("SLT Data usage settings saved!", MsgBoxStyle.Information)
        Else
            MsgBox("Login credentials appears to be invalid!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label19.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label19.ForeColor = colordiag.Color
            MyReg.SetValue("LBLPL", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLPL." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = Label18.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label18.ForeColor = colordiag.Color
            MyReg.SetValue("LBLOL", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLOL." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub lblPeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPeak.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = lblPeak.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblPeak.ForeColor = colordiag.Color
            MyReg.SetValue("LBLPV", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLPV." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub lblOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOff.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = lblOff.ForeColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblOff.ForeColor = colordiag.Color
            MyReg.SetValue("LBLOV", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key LBLOV." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub peakporgbar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles peakporgbar.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = peakporgbar.FillColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            peakporgbar.FillColor = colordiag.Color
            MyReg.SetValue("PROGP", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key PROGP." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub RectangleShape2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RectangleShape2.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = RectangleShape2.FillColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            RectangleShape2.FillColor = colordiag.Color
            MyReg.SetValue("PROGO", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key PROGO." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub RectangleShape3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape3.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = RectangleShape2.FillColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            RectangleShape2.FillColor = colordiag.Color
            MyReg.SetValue("PROGO", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key PROGO." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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

    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape1.Click
        On Error GoTo ErrorHandler
        Dim colordiag As ColorDialog = New ColorDialog
        colordiag.Color = peakporgbar.FillColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            peakporgbar.FillColor = colordiag.Color
            MyReg.SetValue("PROGP", ColorTranslator.ToHtml(colordiag.Color))
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to update registry values for the selected preference key PROGP." & vbCrLf & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
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
End Class