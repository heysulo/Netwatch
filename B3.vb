Imports System.Net
Module B3

    Public B3Version As String = "03"
    Public Sub CodeExec(ByVal Code As String)
        Dim TempVTB As TextBox = New TextBox
        TempVTB.Multiline = True
        'replacements
        Code = Code.Replace("@username ", Environment.UserName)
        Code = Code.Replace("@today ", DateString)
        Code = Code.Replace("@country ", Form1.Country)
        Code = Code.Replace("@pcname ", My.Computer.Name)
        Code = Code.Replace("@os ", My.Computer.Info.OSFullName)

        TempVTB.Text = Code
        For Each Line As String In TempVTB.Lines
            If Line.ToLower.StartsWith("<msg>") Then
                ShowMessage(Line)
            ElseIf Line.ToLower.StartsWith("<ver>") Then
                If VersionIsNew(Line) = False Then
                    Exit Sub
                End If
            ElseIf Line.ToLower.StartsWith("<bv>") Then

                VersionBlockCheck(Line)
            ElseIf Line.ToLower.StartsWith("<reg>") Then
                RegSet(Line)
            ElseIf Line.ToLower.StartsWith("<q>") Then
                Question(Line)
            ElseIf Line.ToLower.StartsWith("<proc>") Then
                StartProcess(Line)
            End If
        Next
    End Sub

    Sub Question(ByVal Data As String)
        Dim VirtualTextBox As TextBox = New TextBox
        VirtualTextBox.Multiline = True
        Dim MessageText As String
        Dim QCOD As String = Nothing
        Data = Data.Replace("<q>", Nothing)
        Data = Data.Replace("</q>", Nothing)
        VirtualTextBox.Text = Data.Replace("||", vbCrLf)
        MessageText = VirtualTextBox.Lines(0)
        MessageText = MessageText.Replace("/n ", vbCrLf)
        If MsgBox(MessageText, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            QCOD = VirtualTextBox.Lines(1).Replace("~", vbCrLf)
            MsgBox(QCOD)
            CodeExec(QCOD)
        End If
    End Sub


    Public Sub ShowMessage(ByVal Data As String)
        On Error GoTo erh
        Dim VirtualTextBox As TextBox = New TextBox
        VirtualTextBox.Multiline = True
        Dim MessageText As String
        Data = Data.Replace("<msg>", Nothing)
        Data = Data.Replace("</msg>", Nothing)
        VirtualTextBox.Text = Data.Replace("|", vbCrLf)
        MessageText = VirtualTextBox.Lines(0)
        MessageText = MessageText.Replace("/n ", vbCrLf)
        Select Case VirtualTextBox.Lines(1)
            Case "i"
                MsgBox(MessageText, MsgBoxStyle.Information, VirtualTextBox.Lines(2))
            Case "e"
                MsgBox(MessageText, MsgBoxStyle.Exclamation, VirtualTextBox.Lines(2))
            Case "c"
                MsgBox(MessageText, MsgBoxStyle.Critical, VirtualTextBox.Lines(2))
        End Select
        Exit Sub
erh:

    End Sub

    Public Sub RegSet(ByVal Data As String)
        On Error GoTo erh
        Dim VirtualTextBox As TextBox = New TextBox
        VirtualTextBox.Multiline = True
        Data = Data.Replace("<reg>", Nothing)
        Data = Data.Replace("</reg>", Nothing)
        Data = Data.Replace("|", vbCrLf)
        VirtualTextBox.Text = Data
        MyReg.SetValue(VirtualTextBox.Lines(0), VirtualTextBox.Lines(1))
        Exit Sub
erh:
    End Sub

    Public Sub StartProcess(ByVal Data As String)
        On Error GoTo erh
        Data = Data.Replace("<proc>", Nothing)
        Data = Data.Replace("</proc>", Nothing)
        Process.Start(Data)
        Exit Sub
erh:
    End Sub

    Public Function VersionIsNew(ByRef Data As String)
        Dim CV As Integer
        CV = Val(MyReg.GetValue("VER", "0"))
        Data = Data.Replace("<ver>", Nothing)
        Data = Data.Replace("</ver>", Nothing)
        If CV = Val(Data) Then
            Return False
        Else
            MyReg.SetValue("VER", Data)
            Return True
        End If
    End Function

    Public Sub VersionBlockCheck(ByVal Data As String)
        Data = Data.Replace("<bv>", Nothing)
        Data = Data.Replace("</bv>", Nothing)
        If Data.Contains(B3Version) = True Then
            Form1.Timer1.Enabled = False
            Form1.tmrMouse.Enabled = False
            MsgBox("It appears to be that the developer has blocked this version of Netwatch being executed. This might be due to a correction of a critical error in the software. Please download and install the latest version of Netwatch." & vbCrLf & vbCrLf & "For more details visit following pages :" & vbCrLf & vbCrLf & "http://infinityresearches.tk/" & vbCrLf & "https://www.facebook.com/Infinity.Researches" & vbCrLf & "infinityresearches.webs.com" & vbCrLf & vbCrLf & "When you contact the developer please inform that your version of B3 is " & B3Version, MsgBoxStyle.Critical, "Update to a newer version of Netwatch")
            End
        End If
    End Sub


    Public Sub UpdateCountry()
        On Error GoTo erh
        Dim txtBox As TextBox = New TextBox
        txtBox.Multiline = True
        Dim webReq As New System.Net.WebClient
        txtBox.Text = System.Text.Encoding.ASCII.GetString((webReq.DownloadData("http://www.geobytes.com/IpLocator.htm?GetLocation&template=php3.txt&IpAddress=" & Form1.IP)))
        For Each Line As String In txtBox.Lines
            If Line.StartsWith(My.Resources.MetaStart) = True Then
                Line = Line.Replace(My.Resources.MetaStart, Nothing)
                Line = Line.Replace(My.Resources.MetaEnd, Nothing)
                Form1.Country = Line.Trim
                Exit For
            End If
        Next
        Exit Sub
erh:
        Form1.Country = "N\A"
        Exit Sub
    End Sub

    Public Function GetIPAddress()
        On Error GoTo errorhondler
        Dim output As String
        Dim theIP As IPAddress = Nothing
        Dim webReq As New System.Net.WebClient
        output = System.Text.Encoding.ASCII.GetString((webReq.DownloadData("http://myip.dnsomatic.com/")))
        webReq.Dispose()
        If IPAddress.TryParse(output, theIP) = True Then
            Return theIP.ToString
        Else
            Return "0.0.0.0"
        End If
        Exit Function
errorhondler:
        Resume Next
    End Function

    Public Function HtMLize(ByVal OriginalText As String)
        Dim tempTxt As String
        Dim HEX As String
        'remove alpha chars
        If OriginalText = Nothing Then
            Return Nothing
            Exit Function
        End If
        tempTxt = OriginalText.ToLower
        For Each item As String In "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray
            tempTxt = tempTxt.Replace(item, Nothing)
        Next
        For Each symbol As String In tempTxt.ToCharArray
            HEX = "%" & HEXCode(symbol)
            OriginalText = OriginalText.Replace(symbol, HEX)
        Next
        Return OriginalText
    End Function

    Public Function HEXCode(ByVal input As String)
        input = Asc(input)
        input = Microsoft.VisualBasic.Conversion.Hex(Val(input))
        Return input
    End Function

    Public Sub DoIt(ByVal data As String, Optional ByVal Testing As Boolean = False)
        Dim itotalrem, ipeakrem As Long
        Dim itotalfup, ipeakfup As Integer
        Dim NewEstimatedTotal As Long
        Dim NewEstimatedPeakTotal As Long
        Dim VText As TextBox = New TextBox
        VText.Text = data.Replace(",", vbCrLf)
        For Each txtLine As String In VText.Lines
            txtLine = txtLine.Replace(Chr(34), "")
            If txtLine.StartsWith("totalfup:") Then
                Form1.totalfup = Val(txtLine.Replace("totalfup:", Nothing))
                itotalfup = Form1.totalfup
            ElseIf txtLine.StartsWith("totalrem:") Then
                Form1.totalrem = Val(txtLine.Replace("totalrem:", Nothing))
                itotalrem = Form1.totalrem
            ElseIf txtLine.StartsWith("peakfup:") Then
                Form1.peakfup = Val(txtLine.Replace("peakfup:", Nothing))
                ipeakfup = Form1.peakfup
            ElseIf txtLine.StartsWith("peakrem") Then
                Form1.peakrem = Val(txtLine.Replace("peakrem:", Nothing))
                ipeakrem = Form1.peakrem
            End If
        Next

        If Testing = False Then
            If 0 < itotalfup And itotalfup < 92 Then
                If Val(MyReg.GetValue("TAUTOMATED", "1")) = "1" Then
                    Dim PreEstimatedTotal As Long
                    PreEstimatedTotal = Val(MyReg.GetValue("TOTALET", 0)) * 1073741824 'convert to byte
                    NewEstimatedTotal = (100 * itotalrem) / (100 - itotalfup)
                    NewEstimatedTotal = (NewEstimatedTotal + PreEstimatedTotal) / 2 'get average
                    NewEstimatedTotal = NewEstimatedTotal / 1073741824 'turn into GB
                    NewEstimatedTotal = Math.Round(NewEstimatedTotal)
                    If NewEstimatedTotal > 0 Then
                        MyReg.SetValue("TOTALET", NewEstimatedTotal)
                    End If
                End If
            End If

            If 0 < ipeakfup And ipeakfup < 92 Then
                If Val(MyReg.GetValue("PAUTOMATED", "1")) = "1" Then
                    Dim OldEstimatedPeakTotal As Long
                    OldEstimatedPeakTotal = Val(MyReg.GetValue("PEAKET", 0)) * 1073741824 'convert to byte
                    NewEstimatedPeakTotal = (itotalrem - ipeakrem) / ((itotalrem / (100 - itotalfup)) - (ipeakrem / (100 - ipeakfup)))
                    NewEstimatedPeakTotal = (OldEstimatedPeakTotal + NewEstimatedPeakTotal) / 2
                    NewEstimatedPeakTotal = NewEstimatedPeakTotal / 1073741824
                    NewEstimatedPeakTotal = Math.Round(NewEstimatedPeakTotal)
                    If NewEstimatedPeakTotal > 0 Then
                        MyReg.SetValue("PEAKET", NewEstimatedPeakTotal)
                    End If

                End If
            End If


        End If

        'apply new data
        Form1.totaldata = Val(MyReg.GetValue("TOTALET", 0)) * 1073741824
        Form1.totalpeak = Val(MyReg.GetValue("PEAKET", 0)) * 1073741824
    End Sub


    Public Function isInternetAvailable(Optional ByVal SLT As Boolean = False) As Boolean
        If SLT = True Then
            Try
                Using client = New WebClient()
                    Using stream = client.OpenRead("https://www.internetvas.slt.lk/SLTVasPortal-war/application/index.jsp?page=usage")
                        Return True
                    End Using
                End Using
            Catch
                Return False
            End Try
        Else
            Try
                If My.Computer.Network.Ping("8.8.8.8") Then
                    Return True
                Else
                    Return False
                End If
            Catch
                Return False
            End Try
        End If

    End Function

  
End Module

