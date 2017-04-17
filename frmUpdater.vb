Imports Microsoft.Win32
Imports System.Net

Public Class frmUpdater
    Dim Source As Uri
    Dim Downloader As WebClient = New WebClient()
    Dim DesFile As String
    Private Sub frmUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblStats.Text = "Loading update details"
        LoadUpdateDetails()

    End Sub

    Private Sub LoadUpdateDetails()
        On Error GoTo ErrorHandler
Start:
        Dim Code As String = Nothing
        Dim webReq As New System.Net.WebClient
        Dim TempVTB As TextBox = New TextBox
        If My.Computer.Network.IsAvailable = False Then
            MsgBox("Your computer is not connected to any network. An internet connection is required to check updates", MsgBoxStyle.Exclamation, "No Internet connection")
            Exit Sub
        End If
        TempVTB.Multiline = True
        Code = System.Text.Encoding.ASCII.GetString((webReq.DownloadData("http://infinityresearches.coffeecup.com/Netwatch/version.txt")))
        TempVTB.Text = Code
        lblMyVer.Text = B3.B3Version
        For Each Line As String In TempVTB.Lines
            If Line.ToLower.StartsWith("<ver>") Then
                Line = Line.Replace("<ver>", Nothing)
                Line = Line.Replace("</ver>", Nothing)
                lblUpdateVer.Text = Line
            ElseIf Line.ToLower.StartsWith("<size>") Then
                Line = Line.Replace("<size>", Nothing)
                Line = Line.Replace("</size>", Nothing)
                lblFileSize.Text = Line
            ElseIf Line.ToLower.StartsWith("<link>") Then
                Line = Line.Replace("<link>", Nothing)
                Line = Line.Replace("</link>", Nothing)
                Source = New Uri(Line)

            ElseIf Line.ToLower.StartsWith("<des>") Then
                Line = Line.Replace("<des>", Nothing)
                Line = Line.Replace("</des>", Nothing)
                TextBox1.Text = Line.Replace("/n ", vbCrLf)
            End If
        Next
        If Val(lblUpdateVer.Text) > Val(lblMyVer.Text) Then
            lblStats.Text = "Updates Ready to download and install."
            Button1.Enabled = True
        Else
            lblStats.Text = "Application is upto date."
            Button1.Enabled = False
        End If
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to connect to IR servers and check for updates." & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                Me.Close()
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume start
            Case MsgBoxResult.Ignore
                Resume Next
        End Select


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UpdateCenter.GoForUpdate()
        Exit Sub
    End Sub

End Class