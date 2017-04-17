Module PictureCheckBoxes
    Dim imgChecked As Bitmap = My.Resources.png_iON
    Dim imgUnChecked As Bitmap = My.Resources.png_iOFF
    Function isChecked(ByVal data As PictureBox) As Boolean
        Dim BM1 As Bitmap = data.Image
        For X = 0 To BM1.Width - 1
            For y = 0 To imgChecked.Height - 1
                If BM1.GetPixel(X, y) <> imgChecked.GetPixel(X, y) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Sub Check(ByVal data As PictureBox)
        data.Image = imgChecked
    End Sub
    Sub UnCheck(ByVal data As PictureBox)
        data.Image = imgUnChecked
    End Sub

    Sub SwitchCheck(ByVal data As CheckBox)
        If data.Checked = True Then
            data.Checked = False
        Else
            data.Checked = True
        End If
    End Sub
End Module
