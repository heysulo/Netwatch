Imports Shell32
Module UpdateCenter
    Public Function IsUpdateAvailable()
        On Error GoTo ErrorHandler
        Dim Code As String
        Dim webReq As New System.Net.WebClient
        Dim TempVTB As TextBox = New TextBox
        TempVTB.Multiline = True
        Code = System.Text.Encoding.ASCII.GetString((webReq.DownloadData("http://infinityresearches.coffeecup.com/Netwatch/version.txt")))
        TempVTB.Text = Code
        If IsNew(TempVTB.Lines(0)) = True Then
            Return True
        Else
            Return False
        End If
        Exit Function
ErrorHandler:
        Return False
    End Function
    Public Sub GoForUpdate()

        Dim procStartInfo As New ProcessStartInfo
        Dim procExecuting As New Process
        If MsgBox("An update is available. In order to install the updates, you must close Netwatch. Do you wish to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Install Updates") = MsgBoxResult.Yes Then
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Updater\Updater.exe") = True Then

                'Run the shit as admin
                With procStartInfo
                    .UseShellExecute = True
                    .FileName = Application.StartupPath & "\Updater\Updater.exe"
                    .WindowStyle = ProcessWindowStyle.Normal
                    .Verb = "runas" 'add this to prompt for elevation
                End With

                procExecuting = Process.Start(procStartInfo)
                Form1.NotifyIcon1.Visible = False
                End
            Else
                MsgBox("There are missing files among the program files of Netwatch which are mandatory in update process. You are advised to uninstall this product and download & install the latest version of Netwatch manually. Or you can just turn off the updates in the settings window, but that is not a good option. If it’s a critical update the developer might give sometime for the users to update to its latest version and then block the buggy version from being executed without prior notice.", MsgBoxStyle.Critical, "Download Updater")
            End If
        End If
        Exit Sub
ErrorHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub

    Function IsNew(ByVal data As String)
        data = data.Replace("<ver>", Nothing)
        data = data.Replace("</ver>", Nothing)
        If Val(data) > Val(B3.B3Version) Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub UnZip(ByVal ZIPFile As String, ByVal Dest As String)
        On Error GoTo ErrorHandler
Start:
        Dim Shell As New Shell32.Shell()
        If My.Computer.FileSystem.DirectoryExists(Dest) Then
            My.Computer.FileSystem.DeleteDirectory(Dest, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If
        IO.Directory.CreateDirectory(Dest)
        'destination folder
        Dim output As Shell32.Folder = Shell.NameSpace(Dest)
        'zip file
        Dim input As Shell32.Folder = Shell.NameSpace(ZIPFile)
        'Extract
        output.CopyHere(input.Items, 4)
        Exit Sub
ErrorHandler:
        Dim MsgRes As MsgBoxResult
        MsgRes = MsgBox("Unable to decompress the downloaded update package. Please try again later. If the problem precist, contact the developer." & vbCrLf & "Error: " & ErrorToString() & vbCrLf & vbCrLf & "Number: " & Err.Number & vbCrLf & "Help Context: " & Err.HelpContext, MsgBoxStyle.Critical + MsgBoxStyle.AbortRetryIgnore, "Unexpected error occured")
        Select Case MsgRes
            Case MsgBoxResult.Abort
                Application.Restart()
            Case MsgBoxResult.Retry
                Err.Clear()
                Resume start
            Case MsgBoxResult.Ignore
                Resume Next
        End Select
    End Sub
End Module
