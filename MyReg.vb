Imports Microsoft.Win32

Module MyReg
    Function GetValue(ByVal Subkey As String, ByVal DefValue As String) As String
start:
        On Error GoTo ErrorHandler
        Dim ret As String
        ret = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Infinity Researches\Netwatch\", Subkey, DefValue)
        Return ret
        Exit Function
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to retrive the value of the registry key loacted at HKEY_CURRENT_USER\Software\Infinity Researches\Netwatch\" & Subkey & "." & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume start
            Case MsgBoxResult.Ignore
                Return DefValue
        End Select

    End Function

    Function SetValue(ByVal Subkey As String, ByVal Value As String)
start:
        On Error GoTo ErrorHandler
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Infinity Researches\Netwatch\", Subkey, Value)
        Return Nothing
        Exit Function
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to set the value for the registry key loacted at HKEY_CURRENT_USER\Software\Infinity Researches\Netwatch\" & Subkey & "." & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                End
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume start
            Case MsgBoxResult.Ignore
                Return Nothing
        End Select
    End Function

    Public Sub SetDefaultValues()
        MyReg.SetValue("EULA", "1")
        MyReg.SetValue("KILO", "0")
        MyReg.SetValue("VER", "0")
        MyReg.SetValue("B3", B3.B3Version)
        MyReg.SetValue("AUTOUP", "1")
        MyReg.SetValue("MINIG", "0")
        MyReg.SetValue("KILOBIT", "0")
        MyReg.SetValue("FGC", "0")
        MyReg.SetValue("PREFIX", "0")
        MyReg.SetValue("LIMITED", "1") 'yes or no
        MyReg.SetValue("VBLIMIT", "1") 'value limit
        MyReg.SetValue("OPACITY", "0.9")
        MyReg.SetValue("EVADE", "1")
        MyReg.SetValue("HIDE", "1")
        MyReg.SetValue("L1X", (My.Computer.Screen.WorkingArea.Width - 362))
        MyReg.SetValue("L1Y", 0)
        MyReg.SetValue("L2X", (My.Computer.Screen.WorkingArea.Width - 362))
        MyReg.SetValue("L2Y", (My.Computer.Screen.WorkingArea.Height - 22))
        'color
        MyReg.SetValue("LBLUP", "#ffffff")
        MyReg.SetValue("LBLDOWN", "#ffffff")
        MyReg.SetValue("LBLUS", "Aqua")
        MyReg.SetValue("LBLDS", "Lime")
        MyReg.SetValue("LBLTU", "Aqua")
        MyReg.SetValue("LBLTUV", "#ffffff")
        MyReg.SetValue("LBLTD", "Lime")
        MyReg.SetValue("LBLTDV", "#ffffff")
        MyReg.SetValue("LBLPL", "DarkGray")
        MyReg.SetValue("LBLOL", "DarkGray")
        MyReg.SetValue("LBLPV", "Aqua")
        MyReg.SetValue("LBLOV", "Aqua")
        MyReg.SetValue("PROGP", "Lime")
        MyReg.SetValue("PROGO", "Lime")
        'SLT
        MyReg.SetValue("SLT", "0")
        MyReg.SetValue("PEAKET", "0")
        MyReg.SetValue("TOTALET", "0")
        MyReg.SetValue("TAUTOMATED", "1")
        MyReg.SetValue("PAUTOMATED", "1")
    End Sub

    Public Sub deleteSubKey(ByVal SubKey As String)
        Dim Base As String
        Base = "HKEY_CURRENT_USER\Software\Infinity Researches\"
retry:
        Try
            Dim key As RegistryKey
            key = Registry.CurrentUser.OpenSubKey(Base.Replace("HKEY_CURRENT_USER\", Nothing), True)
            key.DeleteSubKey(SubKey)
        Catch ex As Exception
            If MsgBox(ex.Message & vbCrLf & vbCrLf & "Occured while modifying(del sub key) Windows Registry" & vbCrLf & "Key : " & Base & "\" & SubKey, MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel, "Error Occured") = MsgBoxResult.Retry Then
                GoTo retry
            Else
                Exit Sub
            End If
        End Try
    End Sub
End Module
