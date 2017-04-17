Public Class frmGraph

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        For Each Val As Double In Form1.UpArray
            Chart1.Series(1).Points.AddXY(Nothing, Val)
        Next
        For Each Val As Double In Form1.DownArray
            Chart1.Series(0).Points.AddXY(Nothing, Val)
        Next
    End Sub

    Private Sub ShowLegendsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLegendsToolStripMenuItem.Click
        On Error Resume Next
        If ShowLegendsToolStripMenuItem.Checked = True Then
            Chart1.Legends(0).Enabled = False
            ShowLegendsToolStripMenuItem.Checked = False
        Else
            ShowLegendsToolStripMenuItem.Checked = True
            Chart1.Legends(0).Enabled = True
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub HoldThisPositionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoldThisPositionToolStripMenuItem.Click
        On Error Resume Next
        If HoldThisPositionToolStripMenuItem.Checked = False Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            HoldThisPositionToolStripMenuItem.Checked = True
        Else
            HoldThisPositionToolStripMenuItem.Checked = False
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        End If
    End Sub

    Private Sub frmGraph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        For Each Val As Double In Form1.UpArray
            Chart1.Series(1).Points.AddXY(Nothing, Val)
        Next
        For Each Val As Double In Form1.DownArray
            Chart1.Series(0).Points.AddXY(Nothing, Val)
        Next
    End Sub
End Class