Module TextEncryption
    Public Function TextEncrypt(ByVal Data As String)
        On Error GoTo erh
        Dim ASCIIcode As String = Nothing
        Dim TextBox1 As New TextBox
        TextBox1.Text = Data
        For Each Character As String In TextBox1.Text.ToCharArray
            If Asc(Character) < 10 Then
                ASCIIcode = ASCIIcode & "a" & Asc(Character)
            ElseIf Asc(Character) < 100 Then
                ASCIIcode = ASCIIcode & "b" & Asc(Character)
            Else
                ASCIIcode = ASCIIcode & "c" & Asc(Character)
            End If
        Next
        'Advanced Customization-----------------------------------------------------------------------------------------------------------
        '~~~~~~~~~~~~~~~~~~~~~~~~~METHOD
        Dim vtTokenList As ListBox = New ListBox
        Dim ManufactureCode As String = "zrxdeftsijpon"
        Dim EncryptionToken As String = Nothing
        Do Until ManufactureCode.Length = 0
            Randomize()
            Dim RandomValue As Integer = CInt(Int((ManufactureCode.Length * Rnd()) + 1))
            RandomValue = RandomValue - 1
            Dim SelectedCharacter As String = ManufactureCode.ElementAt(RandomValue)
            vtTokenList.Items.Add(SelectedCharacter)
            ManufactureCode = ManufactureCode.Remove(RandomValue, 1)
        Loop
        For Each tmp01 As String In vtTokenList.Items
            EncryptionToken = EncryptionToken & tmp01
        Next
        '~~~~~~~~~~~~~~~~~~~~~~~~~ADVANCED ENCRYPTION of ASCIIcode
        ASCIIcode = ASCIIcode.Replace("a", EncryptionToken.ElementAt(0))
        ASCIIcode = ASCIIcode.Replace("b", EncryptionToken.ElementAt(1))
        ASCIIcode = ASCIIcode.Replace("c", EncryptionToken.ElementAt(2))
        ASCIIcode = ASCIIcode.Replace("1", EncryptionToken.ElementAt(3))
        ASCIIcode = ASCIIcode.Replace("2", EncryptionToken.ElementAt(4))
        ASCIIcode = ASCIIcode.Replace("3", EncryptionToken.ElementAt(5))
        ASCIIcode = ASCIIcode.Replace("4", EncryptionToken.ElementAt(6))
        ASCIIcode = ASCIIcode.Replace("5", EncryptionToken.ElementAt(7))
        ASCIIcode = ASCIIcode.Replace("6", EncryptionToken.ElementAt(8))
        ASCIIcode = ASCIIcode.Replace("7", EncryptionToken.ElementAt(9))
        ASCIIcode = ASCIIcode.Replace("8", EncryptionToken.ElementAt(10))
        ASCIIcode = ASCIIcode.Replace("9", EncryptionToken.ElementAt(11))
        ASCIIcode = ASCIIcode.Replace("0", EncryptionToken.ElementAt(12))
        ASCIIcode = ASCIIcode & EncryptionToken
        Return ASCIIcode
        Exit Function
erh:
        MsgBox("Error occured while encrypting.", MsgBoxStyle.Critical)
        Return Nothing
    End Function

    Public Function TextDecrypt(ByVal Data As String)
        On Error GoTo erh
        Dim vtEncryptedCode As TextBox = New TextBox
        Dim DecryptedText As String = Nothing
        Dim Token As String
        vtEncryptedCode.Text = Data
        vtEncryptedCode.Select(vtEncryptedCode.Text.Length - 13, 13)
        Token = vtEncryptedCode.SelectedText
        vtEncryptedCode.Text = vtEncryptedCode.Text.Remove(vtEncryptedCode.Text.Length - 13, 13)

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~section01
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(0), "a")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(1), "b")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(2), "c")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(3), "1")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(4), "2")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(5), "3")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(6), "4")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(7), "5")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(8), "6")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(9), "7")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(10), "8")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(11), "9")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(Token.ElementAt(12), "0")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace("a", ".00")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace("b", ".0")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace("c", ".")
        vtEncryptedCode.Text = vtEncryptedCode.Text.Replace(".", vbCrLf)
        For Each Code As String In vtEncryptedCode.Lines
            If Val(Code) > 0 Then
                DecryptedText = DecryptedText & ChrW(Val(Code))
            End If
        Next
        Return DecryptedText
        Exit Function
erh:
        MsgBox("Error occured while decrypting.", MsgBoxStyle.Critical)
        Return Nothing
    End Function
End Module
