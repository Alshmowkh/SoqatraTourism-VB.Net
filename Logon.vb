Public Class Logon

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlog.Click
        Static itry3 As Integer = 0
        Dim tim3 As Integer = 0
        '   If Now.Minute >= tim3 + 2 Then

        If Me.txtnamlog.Text = Nothing Or Me.txtpasslog.Text = Nothing Then
            MsgBox("ÌÃ» ⁄·Ìﬂ ≈œŒ«· Ã„Ì⁄ «·»Ì«‰« ")
            Exit Sub
        End If
        itry3 += 1
        constr()
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter("select * from users where name_user='" & Me.txtnamlog.Text & "' and pass_user='" & Me.txtpasslog.Text & "'", conn)
        da.Fill(ds, "users")
        If ds.Tables("users").Rows.Count > 0 Then

            If ds.Tables("users").Rows(0).Item(3) = False Then
                bgusr = False '*
            Else
                bgusr = True
            End If
            If ds.Tables("users").Rows(0).Item(4) = False Then
                bgpro = False '*
            Else
                bgpro = True
            End If
            If ds.Tables("users").Rows(0).Item(5) = False Then
                bgrpt = False '*
            Else
                bgrpt = True
            End If
            If ds.Tables("users").Rows(0).Item(6) = False Then
                bgacnt = False '*
            Else
                bgacnt = True
            End If
            Me.Close()
            form1.Show()
            txtusr = Me.txtnamlog.Text
        Else
            MsgBox("ﬂ·„… «·”— √Ê «”„ «·„” Œœ„ «·–Ì «œŒ· Â €Ì— ’ÕÌÕ", MsgBoxStyle.Information, "note")
        End If
        If itry3 > 3 Then
            MsgBox("«·„” Œœ„ «·ﬂ—Ì„:·ﬁœ  „ «” ‰›«œ Ã„Ì⁄ „Õ«Ê·… «·œŒÊ· Ì—ÃÏ «· √ﬂœ „‰ »Ì«‰« ﬂ À„ Õ«Ê· «·œŒÊ· »⁄œ —»⁄ ”«⁄… ⁄·Ï «·√ﬁ·", MsgBoxStyle.Information, "close")
            tim3 = Now.Minute
        End If
        ' Else
        ' MsgBox("«‰ ÷— 5 œﬁ«∆ﬁ ⁄·Ï «·√ﬁ·")
        ' End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendlog.Click
        End
    End Sub

    Private Sub Logon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AxShockwaveFlash1.Movie = Application.StartupPath & "\homwork2.swf"
        '"e:\ ’«„Ì„\flash mx\project\homwork2.swf"
    End Sub
    Private Sub Logon_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Dim pth As New System.Drawing.Drawing2D.GraphicsPath()
        'Dim rec As New System.Drawing.Rectangle(0, 0, 30, 200)
        'pth.AddEllipse(rec)
        'Me.Region = New Region(pth)
        Dim path As New Drawing2D.GraphicsPath
        Dim w As Short = 250
        path.AddArc(0, 0, w, w, 110, 350)
        path.AddArc(0, 200, w, w, 325, 390)
        Me.Region = New Region(path)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
