Imports System.Threading
Public Class form1
    Dim cmd As New SqlClient.SqlCommand
    Dim rdr As SqlClient.SqlDataReader
    Dim ds As New DataSet
    Dim ds2 As New DataSet
    Dim i As Long
    Dim ch As String
    Private Sub slctrm() '***********************��� ����� ���� ������
        constr()
        Dim sqltrm As String = "select * from tourist"
        da = New SqlClient.SqlDataAdapter(sqltrm, conn)
        da.Fill(ds, "trm")
    End Sub
    Private Sub slcpro() '***********************��� ����� ���� ������ ������
        constr()
        Dim sqlpro As String = "select * from programm"
        da = New SqlClient.SqlDataAdapter(sqlpro, conn)
        da.Fill(ds, "pro")
    End Sub
    Private Sub slcgud()
        da = New SqlClient.SqlDataAdapter("select * from guide", conn)
        da.Fill(ds, "gud")
    End Sub
    Private Sub datgrdtrm1()
        datgrdtrm.Refresh()
        datgrdtrm.DataSource = ds
        datgrdtrm.DataMember = "trm"
    End Sub
    Private Sub clntrm()
        Me.cobgndtrm.Text = "" : Me.cobnotrm.Text = "" : Me.cobnamtrm.Text = "" : Me.cobnogrb.Text = ""
        Me.cobdsctrm.Text = "" : Me.cobarvordpt.Text = "" : Me.cobfor.Text = ""
        Me.txtnamtrm.Text = "" : Me.txtnogrb.Text = "" : Me.txtteltrm.Text = ""
        Me.txtadrtrm.Text = "" : Me.txtemltrm.Text = "" : Me.txtctytrm.Text = ""
        Me.txtplctrm.Text = "" : Me.txtcnttrm.Text = "" : Me.txtplctrm.Text = ""
        Me.chkcsh.Checked = False
    End Sub
    Private Sub grbno_lod()
        '��� ����� ��� ��������  ��� ���� ����� ��������
        constr()
        da = New SqlClient.SqlDataAdapter("select  distinct grb_pro  from programm ", conn)
        da.Fill(ds, "programm")
        For i = 0 To ds.Tables("programm").Rows.Count - 1
            cobnogrbpro.Items.Add(ds.Tables("programm").Rows(i).Item("grb_pro"))
        Next
    End Sub

    Private Sub form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Timer3.Interval = 100
        Me.Opacity = 0
        Me.Timer3.Enabled = True
        If Me.Opacity = 1 Then
            Me.Timer3.Enabled = False
        End If
        '*****************************************
        Logon.ShowDialog()

        ' grbno_lod()
        If bgusr = False Then tbpusr.Dispose()
        If bgpro = False Then tbppro.Dispose()
        If bgacnt = False Then tbpacnt.Dispose()
        If bgrpt = False Then

            btnrpttrm.Enabled = False
        End If

        '******************************************************
        ' path = TextBox1.Text
        ' Me.Top = True
        '******************************************'��� ����� ������ ������� ��� ���������� �� ���� ������
        constr()
        da = New SqlClient.SqlDataAdapter("select * from hotel", conn)
        da.Fill(ds, "hotel")
        For i = 0 To (ds.Tables("hotel").Rows.Count) - 1
            cobnamhtl.Items.Add(ds.Tables("hotel").Rows(i).Item(1))
        Next
        da = New SqlClient.SqlDataAdapter("select * from office_client", conn)
        da.Fill(ds, "ofc")
        For i = 0 To ds.Tables("ofc").Rows.Count - 1
            cobarvordpt.Items.Add(ds.Tables("ofc").Rows(i).Item(1))
        Next
        conn.Close()
        '******************************************************��� ����� ����
        strpdate.Text = Now.Date
        
        ' *********************************************************��� ��� ��� �������� ������ ��� ���� ������
        Me.curusr.Text = txtusr
        '******************************************'��� ����� ������ ������� ��� ���������� �� ���� ������� 
        constr()
        da = New SqlClient.SqlDataAdapter("select  distinct no_ofc , name_ofc  from office_client ", conn)
        da.Fill(ds, "office_client")
        For i = 0 To ds.Tables("office_client").Rows.Count - 1
            Me.cobnoofc.Items.Add(ds.Tables("office_client").Rows(i).Item("no_ofc"))
            Me.cobnameofc.Items.Add(ds.Tables("office_client").Rows(i).Item("name_ofc"))
        Next
        conn.Close()
        ''******************************************'��� ����� ������ ���������� ��� ���������� �� ���� ����������
        constr()
        da = New SqlClient.SqlDataAdapter("select  distinct name_user  from users ", conn)
        da.Fill(ds, "users")
        For i = 0 To ds.Tables("users").Rows.Count - 1
            Me.cobnameuser.Items.Add(ds.Tables("users").Rows(i).Item("name_user"))
        Next
        conn.Close()
        '******************************************'��� ����� ������ �������� ��� ����������
        constr()
        da = New SqlClient.SqlDataAdapter("select  distinct name_usert  from repay ", conn)
        da.Fill(ds, "repay")
        For i = 0 To ds.Tables("repay").Rows.Count - 1
            Me.cobnamere.Items.Add(ds.Tables("repay").Rows(i).Item("name_usert"))
            'Me.cobnorepay.items.add(ds.Tables("repay").Rows.Item("no_re"))
        Next
        conn.Close()
        '******************************************'��� ����� ������ �������� ��� ����������
        constr()
        da = New SqlClient.SqlDataAdapter("select  distinct name_gud  from guide ", conn)
        da.Fill(ds, "guide")
        For i = 0 To ds.Tables("guide").Rows.Count - 1
            Me.cobnamgud.Items.Add(ds.Tables("guide").Rows(i).Item("name_gud"))
        Next
        conn.Close()
        '******************************************'��� ����� ��� ����� ��� ����������
        constr()
        da = New SqlClient.SqlDataAdapter("select  distinct to_pa  from pay ", conn)
        da.Fill(ds, "pay")
        For i = 0 To ds.Tables("pay").Rows.Count - 1
            Me.cobtopay.Items.Add(ds.Tables("pay").Rows(i).Item("to_pa"))
        Next
        conn.Close()
        '******************************************'��� ����� ������ �������� ��� ���������� �� ���� ��������
        constr()
        da = New SqlClient.SqlDataAdapter("select   name_drv  from driver ", conn)
        da.Fill(ds, "driver")
        For i = 0 To ds.Tables("driver").Rows.Count - 1
            Me.cobdrv.Items.Add(ds.Tables("driver").Rows(i).Item("name_drv"))
        Next
        conn.Close()
        '******************************************'��� ����� ������ ������� �������� ��� ���������� �� ���� ������� ��������
        constr()
        da = New SqlClient.SqlDataAdapter("select   name_plc  from trsmplace ", conn)
        da.Fill(ds, "trsmplace")
        For i = 0 To ds.Tables("trsmplace").Rows.Count - 1
            Me.cobnameplc.Items.Add(ds.Tables("trsmplace").Rows(i).Item("name_plc"))
        Next
        conn.Close()
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddgud.Click
        '************************************************************* ��� ����� ���� ��� �������
        constr()

        If Me.cobnamgud.Text = Nothing Or Me.txttelgud.Text = Nothing Then
            MessageBox.Show("��� ���� ����� �������� ��������")
            Exit Sub
        End If
        Dim sql As String = "select * from guide"
        da = New SqlClient.SqlDataAdapter(sql, conn)
        da.Fill(ds, "guide")
        cmd = New SqlClient.SqlCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "insert into guide (name_gud,tel_gud,address_gud,type_gud,qulfc_gud,dterec_gud) values('" & Me.cobnamgud.Text & "'," & Val(Me.txttelgud.Text) & ",'" & Me.txtadrgud.Text & "','" & cobtypgud.Text & "','" & txtclfgud.Text & "'," & DateToNumber(Me.strpdate.Text) & ")"
        conn.Open()
        cmd.ExecuteNonQuery()

        conn.Close()
        MessageBox.Show("complet saveing data ")
        clearguide()

    End Sub

    Private Sub btndltgud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltgud.Click
        '**************************************��� ��� ������ ������ 
        If Me.cobnamgud.Text = "" Then
            MsgBox("��� ������ ���� ����� ������ ������ ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If btndltgud.Enabled = True Then
            constr()
            da = New SqlClient.SqlDataAdapter("select * from guide where name_gud='" & Me.cobnamgud.Text & "'", conn)
            da.Fill(ds, "gud")
            If ds.Tables("gud").Rows.Count = 0 Then MsgBox("������ ���� �� ���� ��� ����� ��������") : Exit Sub
            If Not IsDBNull(ds.Tables("gud").Rows(0).Item("no_gud")) Then Me.lblnbrgud.Text = ds.Tables("gud").Rows(0).Item("no_gud")
            If Not IsDBNull(ds.Tables("gud").Rows(0).Item(2)) Then Me.cobtypgud.Text = ds.Tables("gud").Rows(0).Item(4)
            If Not IsDBNull(ds.Tables("gud").Rows(0).Item(3)) Then Me.txttelgud.Text = ds.Tables("gud").Rows(0).Item(2)
            If Not IsDBNull(ds.Tables("gud").Rows(0).Item(4)) Then Me.txtadrgud.Text = ds.Tables("gud").Rows(0).Item(3)
            If Not IsDBNull(ds.Tables("gud").Rows(0).Item(5)) Then Me.txtclfgud.Text = ds.Tables("gud").Rows(0).Item(5)
            If Not IsDBNull(ds.Tables("gud").Rows(0).Item(6)) Then Me.Text = ds.Tables("gud").Rows(0).Item(6)
            If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
            Dim dltgud As New SqlClient.SqlCommand
            dltgud.Connection = conn
            dltgud.CommandType = CommandType.Text
            dltgud.CommandText = "delete from guide where name_gud='" & Me.cobnamgud.Text & "'"
            conn.Open()
            dltgud.ExecuteNonQuery()
            conn.Close()
            MsgBox("����� ����� �����")
            clearguide()

        End If




    End Sub

    Private Sub btnendgud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub cobnamhtl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamhtl.GotFocus
        Me.cobnamhtl.BackColor = Color.Yellow
    End Sub

    Private Sub cobnamhtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnamhtl.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnamhtl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamhtl.LostFocus
        Me.cobnamhtl.BackColor = Color.White
    End Sub

    Private Sub cobnamhtl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnamhtl.SelectedIndexChanged
        '****************** ��� ���� ������ ������ �������
        constr()
        Dim sqlt As String = "select * from hotel where name_htl='" & Me.cobnamhtl.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "hotel")
        conn.Close()
        Me.txttelhtl.Text = ds.Tables("hotel").Rows(0).Item(2).ToString
        Me.txtadrhtl.Text = ds.Tables("hotel").Rows(0).Item(3).ToString
        Me.cobtyphtl.Text = ds.Tables("hotel").Rows(0).Item(4).ToString
        Me.txtother.Text = ds.Tables("hotel").Rows(0).Item(5).ToString
        Me.btnshwhtl.Enabled = False


    End Sub

    Private Sub btnendhtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendhtl.Click
        End
    End Sub

    Private Sub btnaddhtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddhtl.Click
        ' *********************** ����� ��� ������ �������
        If Me.cobnamhtl.Text = Nothing Then
            MsgBox("��� ���� ����� ��� ������ ��� �����")
            Exit Sub
        End If
        constr()
        Dim sql As String = "select * from hotel"
        Dim da As New SqlClient.SqlDataAdapter(sql, conn)
        da.Fill(ds, "hotel")
        Dim savhtl As New SqlClient.SqlCommand
        savhtl.Connection = conn
        savhtl.CommandType = CommandType.Text
        savhtl.CommandText = "insert into hotel(name_htl,tel_htl,address_htl,class_htl,other_htl) values('" & Me.cobnamhtl.Text & "'," & Val(Me.txttelhtl.Text) & ",'" & Me.txtadrhtl.Text & "','" & Me.cobtyphtl.Text & "','" & Me.txtother.Text & "')"
        conn.Open()
        savhtl.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving")
        cleahtl()

    End Sub


    Private Sub btnaddudr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddusr.Click
        '*******************************  ��� ����� ������ ���� 
        If Me.cobnameuser.Text = Nothing Or Me.txtpasusr.Text = Nothing Then MsgBox("��� ���� ����� ���� ��������") : Exit Sub
        If Val(Me.txtpasusr.Text) <> Val(Me.txtspsusr.Text) Then
            MsgBox("���� ���� ��� �������")
        Else
            constr()
            Dim da As New SqlClient.SqlDataAdapter("select * from users", conn)
            da.Fill(ds, "users")
            Dim savusr As New SqlClient.SqlCommand
            savusr.Connection = conn
            savusr.CommandType = CommandType.Text
            savusr.CommandText = "insert into users values('" & Me.cobnameuser.Text & "'," & txtpasusr.Text & ",'" & Me.chkusr.Checked & "','" & Me.chkpro.Checked & "','" & Me.chkacnt.Checked & "','" & Me.chkrpt.Checked & "')"
            conn.Open()
            savusr.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("complet saving", MsgBoxStyle.Exclamation & "note")
        End If
    End Sub

    Private Sub btnsavtrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsavtrm.Click
        '*********************************************************** ��� ����� ������ �� ���� ������ ��� �������
        If Me.txtnogrb.Text = Nothing Or Me.txtnamtrm.Text = Nothing Then
            MsgBox("��� ���� ����� �������� ��������")
            Me.txtnogrb.Focus()
        End If

        da = New SqlClient.SqlDataAdapter("select * from tourist", conn)
        da.Fill(ds, "tourist")

        Dim savtrm As New SqlClient.SqlCommand
        savtrm.Connection = conn
        savtrm.CommandType = CommandType.Text
        savtrm.CommandText = "insert into tourist (passp_trm,name_trm,arvldate_trm,dptdate_trm,cash_trm,cstfor_trm,cost_trm,plctrv_trm,ofc_trv_rci,dst_trm,adrs_trm,gndr_trm,email_trm,tel_trm,cuntof_trm,cntry_trm,dsc_trm,grb_no_trm,daterec_trm) values(" & Val(txtpsstrm.Text) & ",'" & txtnamtrm.Text & "'," & DateToNumber(dterci.Text) & "," & DateToNumber(dtetrv.Text) & ",'" & chkcsh.Checked & "','" & cobfor.Text & "'," & Val(txtprs.Text) & ",'" & txtplctrm.Text & "','" & cobarvordpt.Text & "','" & cobdsttrm.Text & "','" & txtadrtrm.Text & "','" & cobgndtrm.Text & "','" & txtemltrm.Text & "'," & Val(txtteltrm.Text) & "," & Val(txtcnttrm.Text) & ",'" & txtctytrm.Text & "','" & cobdsctrm.Text & "','" & Val(txtnogrb.Text) & "', " & DateToNumber(strpdate.Text) & ")"
        conn.Open()
        savtrm.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saveing")
    End Sub

    Private Sub btnendtrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendtrm.Click
        End
    End Sub

    Private Sub cobdsttrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobdsttrm.GotFocus
        Me.cobdsttrm.BackColor = Color.Yellow
    End Sub

    Private Sub cobdsttrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobdsttrm.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobdsttrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobdsttrm.LostFocus
        Me.cobdsttrm.BackColor = Color.White
    End Sub

    Private Sub cobdsttrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobdsttrm.SelectedIndexChanged
        '**************************************��� ������ ���� ������
        If cobdsttrm.Text = "�����" Then
            txtplctrm.Visible = True
            btnplctrm.Enabled = False
        Else
            txtplctrm.Visible = False
            btnplctrm.Enabled = True
        End If
    End Sub

    Private Sub btnplctrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnplctrm.Click
        '*************�� ����� ������� �������� �������� �� ��� ������
        If txtnogrb.Text = Nothing Then MsgBox("you mast enter groub number") : Exit Sub
        ds.Clear()
        chklstbx1.Items.Clear()
        With chklstbx1
            .Location = New Point(20, 6)
            .Size = New Size(200, 300)
            .Visible = True
        End With
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from trsmplace ", conn)
        da.Fill(ds, "trmplc")
        Dim i As Integer

        For i = 0 To ds.Tables("trmplc").Rows.Count - 1
            chklstbx1.Items.Add(ds.Tables("trmplc").Rows(i).Item(1))
        Next
        Me.btnsavplce.Visible = True
        Me.btnplctrm.Visible = False
    End Sub

    Private Sub TabPage8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage8.Click

    End Sub

    Private Sub btnshwhtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshwhtl.Click

        '************************����� ����� ������ ������
        Me.cobnamhtl.Visible = True
        If Me.cobnamhtl.Text = Nothing Then
            MsgBox("��� ������ ���� ����� ������ ", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

    Private Sub cobnogrb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnogrb.GotFocus
        Me.cobnogrb.BackColor = Color.Yellow
    End Sub

    Private Sub cobnogrb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cobnogrb.KeyDown

    End Sub

    Private Sub cobnogrb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnogrb.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnogrb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnogrb.LostFocus
        Me.cobnogrb.BackColor = Color.White
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnogrb.SelectedIndexChanged
        '******************** ��� ��������� ���� �������� ������ ��������  ������ ��������� ��������
        constr()
        ds.Clear()
        cobnotrm.Items.Clear()
        cobnamtrm.Items.Clear()
        '****************************
        If cobnogrb.Text = "" Then MsgBox(" ��� �� ����� ��� ������ ���� ��������") : Exit Sub
        conn.Open()
        Dim da As New SqlClient.SqlDataAdapter("select * from tourist where grb_no_trm=" & Trim(cobnogrb.Text) & "", conn)
        da.Fill(ds, "trm")
        conn.Close()
        If ds.Tables("trm").Rows.Count > 0 Then
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("no_trm")) Then cobnotrm.Text = ds.Tables("trm").Rows(0).Item("no_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("name_trm")) Then cobnamtrm.Text = ds.Tables("trm").Rows(0).Item("name_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("passp_trm")) Then txtpsstrm.Text = ds.Tables("trm").Rows(0).Item("passp_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("dsc_trm")) Then cobdsctrm.Text = ds.Tables("trm").Rows(0).Item("dsc_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("tel_trm")) Then txtteltrm.Text = ds.Tables("trm").Rows(0).Item("tel_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("gndr_trm")) Then cobgndtrm.Text = ds.Tables("trm").Rows(0).Item("gndr_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("adrs_trm")) Then txtadrtrm.Text = ds.Tables("trm").Rows(0).Item("adrs_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("email_trm")) Then txtemltrm.Text = ds.Tables("trm").Rows(0).Item("email_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("cntry_trm")) Then txtctytrm.Text = ds.Tables("trm").Rows(0).Item("cntry_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("cuntof_trm")) Then txtcnttrm.Text = ds.Tables("trm").Rows(0).Item("cuntof_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("dst_trm")) Then cobdsttrm.Text = ds.Tables("trm").Rows(0).Item("dst_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("arvldate_trm")) Then dterci.Text = ds.Tables("trm").Rows(0).Item("arvldate_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("dptdate_trm")) Then dtetrv.Text = ds.Tables("trm").Rows(0).Item("dptdate_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("plctrv_trm")) Then txtplctrm.Text = ds.Tables("trm").Rows(0).Item("plctrv_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("ofc_trv_rci")) Then cobarvordpt.Text = ds.Tables("trm").Rows(0).Item("ofc_trv_rci")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("cost_trm")) Then txtprs.Text = ds.Tables("trm").Rows(0).Item("cost_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("cstfor_trm")) Then cobfor.Text = ds.Tables("trm").Rows(0).Item("cstfor_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("cash_trm")) Then chkcsh.Checked = ds.Tables("trm").Rows(0).Item("cash_trm")
        Else
            MsgBox("������ ������ ������ ���� ��������")
        End If
    End Sub

    Private Sub btnedttrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedttrm.Click

        '*****************************************��� ������ ����� ��� ������ ������ ��� ���� ������ �� ���� �� ��� �������� ���� ����� �����
        If cobnamtrm.Text = Nothing And cobnotrm.Text = Nothing And cobnogrb.Text = Nothing Then MsgBox("��� �� ����� ��� ���� �� ��� ������ �� ��� ���� ������ ����� ������� ") : Exit Sub

        lblshwtrm.Text = "������:������� ��� ������ ������ ���� ��� ������ �� ����..��� ������� ��� ����� �������� ����� ��� ��������."


        '*******************************************************************************************************
        If cobnamtrm.Items.Count <= 1 And cobnogrb.Items.Count <= 1 Then '������� ��� ��� ������
            slctrm()
            Dim updtrm As New SqlClient.SqlCommand
            updtrm.Connection = conn
            updtrm.CommandType = CommandType.Text
            updtrm.CommandText = "update tourist set passp_trm=" & Me.txtpsstrm.Text & ",name_trm='" & Me.cobnamtrm.Text & "' ,grb_no_trm=" & Me.cobnogrb.Text & ",dsc_trm='" & cobdsctrm.Text & "',cntry_trm='" & Me.txtctytrm.Text & "',cuntof_trm=" & Me.txtcnttrm.Text & ",tel_trm=" & txtteltrm.Text & ",email_trm='" & txtemltrm.Text & "',gndr_trm='" & cobgndtrm.Text & "',arvldate_trm=" & Me.dterci.Text & ",dptdate_trm=" & Me.dtetrv.Text & ",adrs_trm='" & Me.txtadrtrm.Text & "',dst_trm='" & Me.cobdsttrm.Text & "',ofc_trv_rci='" & Me.cobarvordpt.Text & "',plctrv_trm='" & Me.txtplctrm.Text & "',cash_trm='" & Me.chkcsh.Checked & "',cost_trm =" & Me.txtprs.Text & ",cstfor_trm='" & Me.cobfor.Text & "',daterec_trm=" & Me.strpdate.Text & "  where no_trm=" & Me.cobnotrm.Text & " "
            If MsgBox("�� ��� ����� �� ����� �������...����� ���  ����� ������� ���� ��� ��� ������ ������", MsgBoxStyle.YesNo, "warring" & MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            conn.Open()
            updtrm.ExecuteNonQuery()
            conn.Close()
            MsgBox("�� ����� �������")

            lblshwtrm.Text = ""
            '*******************************************************************************************************
        ElseIf cobnotrm.Items.Count < 1 And cobnamtrm.Items.Count <= 1 Then '������� ��� ��� ��������
            slctrm()
            Dim updtrm As New SqlClient.SqlCommand
            updtrm.Connection = conn
            updtrm.CommandType = CommandType.Text
            updtrm.CommandText = "update tourist set passp_trm=" & Me.txtpsstrm.Text & ",name_trm='" & Me.cobnamtrm.Text & "' ,grb_no_trm=" & Me.cobnogrb.Text & ",dsc_trm='" & cobdsctrm.Text & "',cntry_trm='" & Me.txtctytrm.Text & "',cuntof_trm=" & Me.txtcnttrm.Text & ",tel_trm=" & txtteltrm.Text & ",email_trm='" & txtemltrm.Text & "',gndr_trm='" & cobgndtrm.Text & "',arvldate_trm=" & Me.dterci.Text & ",dptdate_trm=" & Me.dtetrv.Text & ",adrs_trm='" & Me.txtadrtrm.Text & "',dst_trm='" & Me.cobdsttrm.Text & "',ofc_trv_rci='" & Me.cobarvordpt.Text & "',plctrv_trm='" & Me.txtplctrm.Text & "',cash_trm='" & Me.chkcsh.Checked & "',cost_trm =" & Me.txtprs.Text & ",cstfor_trm='" & Me.cobfor.Text & "',daterec_trm=" & Me.strpdate.Text & " where grb_no_trm=" & Me.cobnogrb.Text & ""
            If MsgBox(" �� ��� ����� �� ����� �������...����� ���  ����� ������� ���� ��� ����� ��������������", MsgBoxStyle.YesNo, "note") = MsgBoxResult.No Then Exit Sub
            conn.Open()
            updtrm.ExecuteNonQuery()
            conn.Close()
            MsgBox("�� ����� �������")

            lblshwtrm.Text = ""
            '*******************************************************************************************************
        ElseIf cobnotrm.Items.Count <= 1 And cobnogrb.Items.Count <= 1 Then '������� ��� ��� ������
            slctrm()
            Dim updtrm As New SqlClient.SqlCommand
            updtrm.Connection = conn
            updtrm.CommandType = CommandType.Text
            updtrm.CommandText = "update tourist set passp_trm=" & Me.txtpsstrm.Text & ",name_trm='" & Me.cobnamtrm.Text & "' ,grb_no_trm=" & Me.cobnogrb.Text & ",dsc_trm='" & cobdsctrm.Text & "',cntry_trm='" & Me.txtctytrm.Text & "',cuntof_trm=" & Me.txtcnttrm.Text & ",tel_trm=" & txtteltrm.Text & ",email_trm='" & txtemltrm.Text & "',gndr_trm='" & cobgndtrm.Text & "',arvldate_trm=" & Me.dterci.Text & ",dptdate_trm=" & Me.dtetrv.Text & ",adrs_trm='" & Me.txtadrtrm.Text & "',dst_trm='" & Me.cobdsttrm.Text & "',ofc_trv_rci='" & Me.cobarvordpt.Text & "',plctrv_trm='" & Me.txtplctrm.Text & "',cash_trm='" & Me.chkcsh.Checked & "',cost_trm =" & Me.txtprs.Text & ",cstfor_trm='" & Me.cobfor.Text & "',daterec_trm=" & Me.strpdate.Text & " where name_trm='" & Me.cobnamtrm.Text & "'"
            If MsgBox("�� ��� ����� �� ����� �������...����� ���  ����� ������� ���� ��� ��� ������ ������", MsgBoxStyle.YesNo, "warring" & MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            conn.Open()
            updtrm.ExecuteNonQuery()
            conn.Close()
            MsgBox("�� ����� �������")

            lblshwtrm.Text = ""
        End If
        btnsavtrm.Enabled = True
        btndlttrm.Enabled = True


        slctrm()
        For i = 0 To ds.Tables("trm").Rows.Count - 1
            cobnotrm.Items.Add(ds.Tables("trm").Rows(i).Item(0))
            cobnamtrm.Items.Add(ds.Tables("trm").Rows(i).Item("name_trm"))
            cobnogrb.Items.Add(ds.Tables("trm").Rows(i).Item("grb_no_trm"))
        Next

    End Sub

    Private Sub cobnotrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnotrm.GotFocus
        Me.cobnotrm.BackColor = Color.Yellow
    End Sub

    Private Sub cobnotrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnotrm.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnotrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnotrm.LostFocus
        Me.cobnotrm.BackColor = Color.White
    End Sub

    Private Sub cobnotrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnotrm.SelectedIndexChanged
        '**************************��� ��� ������ ������ ���� ������� ��� ������
        constr()
        ds.Clear()
        cobnogrb.Items.Clear()
        cobnamtrm.Items.Clear()
        Try
            Dim da As New SqlClient.SqlDataAdapter("select * from tourist where no_trm=" & Trim(cobnotrm.Text) & "", conn)
            da.Fill(ds, "trm")
            'On Error Resume Next
            If ds.Tables("trm").Rows.Count < 1 Then MsgBox(" �� ��� ����� ������ ���� ����� ��� ����") : Exit Sub
            cobnogrb.Text = ds.Tables("trm").Rows(0).Item("grb_no_trm")
            cobnamtrm.Text = ds.Tables("trm").Rows(0).Item("name_trm")
            txtpsstrm.Text = ds.Tables("trm").Rows(0).Item("passp_trm")
            cobgndtrm.Text = ds.Tables("trm").Rows(0).Item("gndr_trm")
            cobdsctrm.Text = ds.Tables("trm").Rows(0).Item("dsc_trm")
            txtteltrm.Text = ds.Tables("trm").Rows(0).Item("tel_trm")
            txtadrtrm.Text = ds.Tables("trm").Rows(0).Item("adrs_trm")
            txtemltrm.Text = ds.Tables("trm").Rows(0).Item("email_trm")
            txtctytrm.Text = ds.Tables("trm").Rows(0).Item("cntry_trm")
            txtcnttrm.Text = ds.Tables("trm").Rows(0).Item("cuntof_trm")
            cobdsttrm.Text = ds.Tables("trm").Rows(0).Item("dst_trm")
            dterci.Text = ds.Tables("trm").Rows(0).Item("arvldate_trm")
            dtetrv.Text = ds.Tables("trm").Rows(0).Item("dptdate_trm")
            txtplctrm.Text = ds.Tables("trm").Rows(0).Item("plctrv_trm")
            cobarvordpt.Text = ds.Tables("trm").Rows(0).Item("ofc_trv_rci")
            txtprs.Text = ds.Tables("trm").Rows(0).Item("cost_trm")
            cobfor.Text = ds.Tables("trm").Rows(0).Item("cstfor_trm")
            chkcsh.Checked = ds.Tables("trm").Rows(0).Item("cash_trm")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtoutpro.ValueChanged
        'If Me.dtoutpro.Value > Me.dtetrvpro.Value Then
        '    MessageBox.Show("������� �� ����� ����� ������ �� ������ ��� ����� ����� ��������")
        '    dtoutpro.Value = Me.dtvstpro.Value
        'End If
    End Sub

    Private Sub TabPage19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbppro.Click

    End Sub

    Private Sub cobnogrbpro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub qrytrmall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmall.CheckedChanged
        '********************** ��� ����� ��  ��������� ���� �� ���� ��� �������  
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide()
        lbl.Text = "���� ��� ������� "
        lbl.Location = New Point(150, 80)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        lbl.Show() : cmb.Hide()
    End Sub

    Private Sub qrytrmno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmno.CheckedChanged
        '********************************�������� ���� ���� �� ���� ��� ������   
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Items.Clear()
        lbl.Text = "���� ��� ������"
        lbl.Location = New Point(150, 70)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        '********************* ��� ����� ��������� 
        cmb.Location = New Point(115, 92)
        cmb.Size = New Size(150, 20)
        lbl.Show() : cmb.Show()
        Me.TabPage21.Controls.Add(cmb)
        '**************************��� ����� ����� �������� �� ��������� �� ���� ������
        slctrm()
        For i = 0 To ds.Tables("trm").Rows.Count - 1

            cmb.Items.Add(ds.Tables("trm").Rows(i).Item("no_trm"))

        Next
    End Sub

    Private Sub TabPage21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage21.Click

    End Sub

    Private Sub btnendqry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendqry.Click
        End
    End Sub

    Private Sub Button63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub qrytrmnam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmnam.CheckedChanged
        '********************************��� ����� ���� ���� �� ���� ��� ������   
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Items.Clear()
        lbl.Text = "���� ��� ������"
        lbl.Location = New Point(150, 70)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        '*********************************���  ������ ���� ������������
        cmb.Location = New Point(115, 92)
        cmb.Size = New Size(150, 20)
        Me.TabPage21.Controls.Add(cmb)
        lbl.Show() : cmb.Show()
        '**********************************��� ����� ����� ��������  �� ���� ������
        slctrm()
        For i = 0 To ds.Tables("trm").Rows.Count - 1
            cmb.Items.Add(ds.Tables("trm").Rows(i).Item("name_trm"))
        Next

    End Sub

    Private Sub qrytrmofc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmofc.CheckedChanged
        '********************************��� ����� ���� ���� �� ���� ��� ������   
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Items.Clear()
        lbl.Text = "���� ��� ������"
        lbl.Location = New Point(150, 70)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        '************************************ ��� ������ ����������� �����
        cmb.Location = New Point(115, 92)
        cmb.Size = New Size(150, 20)
        Me.TabPage21.Controls.Add(cmb)
        lbl.Show() : cmb.Show()
        '***************************************��� ����� ����� ������ �� ������
        slctrm()
        For i = 0 To ds.Tables("trm").Rows.Count - 1
            cmb.Items.Add(ds.Tables("trm").Rows(i).Item("ofc_trv_rci"))
        Next
    End Sub

    Private Sub qrytrmgrb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmgrb.CheckedChanged
        '********************************��� ����� ���� ���� �� ���� ��� ��������   
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Items.Clear()
        lbl.Text = "���� ��� ��������"
        lbl.Location = New Point(150, 70)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        '************************************��� ������ ����������� �����
        cmb.Location = New Point(115, 92)
        cmb.Size = New Size(150, 20)
        Me.TabPage21.Controls.Add(cmb)
        cmb.Show() : lbl.Show()
        '***************************************��� ����� ����� �������� �� ������
        da = New SqlClient.SqlDataAdapter("select distinct grb_no_trm from tourist ", conn)
        da.Fill(ds, "grbno")
        For i = 0 To ds.Tables("grbno").Rows.Count - 1
            cmb.Items.Add(ds.Tables("grbno").Rows(i).Item("grb_no_trm"))
        Next
    End Sub

    Private Sub qrytrmdst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmdst.CheckedChanged
        '********************************�������� ���� ���� �� ���� ���� ������   
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Items.Clear()
        lbl.Text = "���� ���� ������"
        lbl.Location = New Point(150, 70)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        lbl.Show()
        '************************************  ������ ���������� ����� ������ �������� ���� � ����� ��� �����������
        cmb.Location = New Point(115, 92)
        cmb.Size = New Size(150, 20)
        cmb.Items.Add("����")
        cmb.Items.Add("�����")
        Me.TabPage21.Controls.Add(cmb)
        cmb.Show()
    End Sub

    Private Sub qrytrmdte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmdte.CheckedChanged
        '********************************�������� ���� ���� �� ����  ������� ����� �������� ������   
        cmb.Hide() : rdocsh1.Hide() : rdocsh2.Hide()
        lbl.Text = "���� ������� ����� �� ������� ������"
        lbl.Location = New Point(135, 55)
        lbl.AutoSize = True
        Me.TabPage21.Controls.Add(lbl)
        '************************************datetimepicker,datetimepicker2 ,lbl ��� ������ 
        dte1.Location = New Point(115, 80)
        dte2.Location = New Point(115, 110)
        dte1.Format = DateTimePickerFormat.Short
        dte2.Format = DateTimePickerFormat.Short
        Me.TabPage21.Controls.Add(dte1)
        Me.TabPage21.Controls.Add(dte2)
        dte1.Show() : dte2.Show() : lbl.Show()
    End Sub

    Private Sub qrytrmcsh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrytrmcsh.CheckedChanged
        '********************************radiobutton2 ���� ��� ��� ����,radiobutton1 ������������ ��� ����     

        lbl.Hide() : dte1.Hide() : dte2.Hide() : cmb.Hide()
        rdocsh1.Text = "����"
        rdocsh1.AutoSize = True
        rdocsh1.Location = New Point(250, 80)
        rdocsh2.Text = "��� ����"
        rdocsh2.AutoSize = True
        rdocsh2.Location = New Point(100, 80)
        Me.TabPage21.Controls.Add(rdocsh1)
        Me.TabPage21.Controls.Add(rdocsh2)
        rdocsh1.Show()
        rdocsh2.Show()
    End Sub

    Private Sub TabPage21_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage21.Enter


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnqry.Click
        '********************* ��� ����� �������� �� ��� ����� �������� ��������
        Timer1.Enabled = True
        Timer1.Interval = 20
        prgress.Minimum = 0
        prgress.Value = 0
        prgress.Maximum = 100
        If prgress.Value = 100 Then prgress.Value = 0
        '*************************���������� ���� ������ �������� �� ����������
        Try
            If qrytrmall.Checked Then
                slctrm()
                datgrdtrm1()
                '***   ****   ******   **** ********��� ������� ���� ������ �� ���� ������
            ElseIf qrytrmno.Checked Then
                If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
                Dim sql As String = "select * from tourist where no_trm=" & Trim(cmb.Text) & ""
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm1")
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm1"
                '** *****  *****  *****  ****  ****��� ������� ���� ������ �� ���� ������
            ElseIf qrytrmnam.Checked Then
                If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
                Dim sql As String = "select * from tourist where name_trm='" & cmb.Text & "'"
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm2")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm2"
                '** *****  *****  *****  ****  **** ��� ������� ��� �������� �� ���� ������
            ElseIf qrytrmgrb.Checked Then
                If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
                Dim sql As String = "select * from tourist where grb_no_trm=" & cmb.Text & ""
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm3")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm3"
                '** *****  *****  *****  ****  ****��� ������� ���� ��� ������ ��� ��� ���� �� ��� ��� �����
            ElseIf qrytrmofc.Checked Then
                If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
                Dim sql As String = "select * from tourist where ofc_trv_rci='" & cmb.Text & "'and dst_trm='����'"
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm4")
                If ds.Tables("trm4").Rows.Count < 1 Then MessageBox.Show("��������� ��� ������ ��������  ", "���� �����")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm4"
                '*  ****'** *****  *****  *****  ****  ****��� ������� ����� ������ ���� ��� ����� �� ����
            ElseIf qrytrmdst.Checked Then
                If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
                Dim sql As String = "select * from tourist where dst_trm='" & cmb.Text & "'"
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm5")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm5"
                '*  ****'** *****  *****  *****  ****  ****��� ������� ��������� ��������
            ElseIf rdocsh1.Checked Then
                Dim sql As String = "select * from tourist where cash_trm='True '"
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm6")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm6"
                '*  ****'** *****  *****  *****  ****  ****��� ������� ��������� ����� ������
            ElseIf rdocsh2.Checked Then
                Dim sql As String = "select * from tourist where cash_trm='false' "
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "trm7")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm7"
                '*  ****'** *****  *****  *****  ****  ****datetimepicker1 And datertimepicker2 ��� ������� ������ ������� ������� �� 
            ElseIf qrytrmdte.Checked Then
                da = New SqlClient.SqlDataAdapter("select * from tourist where daterec_trm between '" & DateToNumber(dte1.Text) & " and " & DateToNumber(dte2.Text) & "", conn)
                da.Fill(ds, "trm8")
                datgrdtrm.Refresh()
                datgrdtrm.DataSource = ds
                datgrdtrm.DataMember = "trm8"
            End If

            With datgrdtrm
                .Columns(0).HeaderText = "�����" : .Columns(1).HeaderText = "��� ������"
                .Columns(3).HeaderText = "��� ��������" : .Columns(2).HeaderText = "�����"
                .Columns(4).HeaderText = "��� ������" : .Columns(5).HeaderText = "�����"
                .RowsDefaultCellStyle.BackColor = Color.Yellow
                .RowHeadersDefaultCellStyle.BackColor = Color.Blue
                .ColumnHeadersDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine
                ' .Columns(0).DefaultCellStyle.Format = "c"
            End With
        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhidgrd.Click
        'refresh for datagrid��� ���� �� ���� ���� ��� ������ ������ �������� ����
        ds.Clear()
        datgrdtrm.Refresh()
        Me.rprttrm.Visible = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '********************************��� ������ ������ �������� 
        prgress.Value = prgress.Value + 1
        If prgress.Value = 100 Then Timer1.Enabled = False
        If prgress.Value = 100 Then prgress.Value = 0

    End Sub

    Private Sub datgrdtrm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datgrdtrm.CellContentClick
        '****************��� ����� ������� �������
        Me.datgrdtrm.Sort(Me.datgrdtrm.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

    End Sub

    Private Sub qrypronow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qrypronow.CheckedChanged
        '***************��� ������ ���� ���� �� ���� ��������� ������ �����������
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide()
        lbl.Text = "���� ��� ������� "
        lbl.Location = New Point(150, 80)
        lbl.AutoSize = True
        Me.TabPage9.Controls.Add(lbl)
        lbl.Show() : cmb.Hide()
        ds.Clear()
    End Sub

    Private Sub qryproltr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qryproltr.CheckedChanged
        '***************��� ������ ���� ���� �� ���� ��������� ������ �����������
        ds.Clear()
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Hide()
        lbl.Text = "���� ��� ������� "
        lbl.Location = New Point(150, 80)
        lbl.AutoSize = True
        Me.TabPage9.Controls.Add(lbl)
        lbl.Show()
    End Sub

    Private Sub qryprogrb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qryprogrb.CheckedChanged
        ds.Clear()
        rdocsh1.Hide() : rdocsh2.Hide() : dte1.Hide() : dte2.Hide() : cmb.Items.Clear()
        lbl.Text = "���� ��� ��������"
        lbl.Location = New Point(150, 70)
        lbl.AutoSize = True
        Me.TabPage9.Controls.Add(lbl)
        '************************************
        cmb.Location = New Point(115, 92)
        cmb.Size = New Size(150, 20)
        Me.TabPage9.Controls.Add(cmb)
        cmb.Show() : lbl.Show()
        '***************************************
        constr()
        da = New SqlClient.SqlDataAdapter("select distinct grb_pro from programm ", conn)
        da.Fill(ds, "pro")
        For i = 0 To ds.Tables("pro").Rows.Count - 1
            cmb.Items.Add(ds.Tables("pro").Rows(i).Item(0))
        Next
    End Sub

    Private Sub qryprodte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qryprodte.CheckedChanged
        ds.Clear()
        cmb.Hide() : rdocsh1.Hide() : rdocsh2.Hide()
        lbl.Text = "���� ������� ����� �� ������� ������"
        lbl.Location = New Point(135, 55)
        lbl.AutoSize = True
        Me.TabPage9.Controls.Add(lbl)
        '************************************
        dte1.Location = New Point(115, 80)
        dte2.Location = New Point(115, 110)
        dte1.Format = DateTimePickerFormat.Short
        dte2.Format = DateTimePickerFormat.Short
        Me.TabPage9.Controls.Add(dte1)
        Me.TabPage9.Controls.Add(dte2)
        dte1.Show() : dte2.Show() : lbl.Show()

    End Sub

    Private Sub btnqrypro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnqrypro.Click
        '******************************************************��� ��� ������ ����
        Timer2.Enabled = True
        prgress.Visible = True
        Timer1.Enabled = True
        Timer1.Interval = 10
        prgress.Minimum = 0
        prgress.Value = 0
        prgress.Maximum = 100
        ds.Clear()
        '***********  ��� ������� ������ ������ ������ �������� ��������
        Try

            If qrypronow.Checked Then
                Dim dat As String = Now.Date
                Dim sql As String = "select  tourist.arvldate_trm,tourist.dptdate_trm,programm.* from programm,tourist  where tourist.dptdate_trm <=" & DateToNumber(Me.strpdate.Text) & " and tourist.arvldate_trm >=" & DateToNumber(Me.strpdate.Text) & ""
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "pro_trm")
                datgrdpro.Refresh()
                datgrdpro.DataSource = ds
                datgrdpro.DataMember = "pro_trm"
                '********************* ��� ��������� ���� �������� �� ���� ��������
            ElseIf qryprogrb.Checked Then
                da = New SqlClient.SqlDataAdapter("select * from programm where grb_pro=" & cmb.Text & "", conn)
                da.Fill(ds, "pro2")
                datgrdpro.Refresh()
                datgrdpro.DataSource = ds
                datgrdpro.DataMember = "pro2"
                '***********  ��� ������� ������ ������ ������ �������� ��������
            ElseIf qryproltr.Checked Then
                da = New SqlClient.SqlDataAdapter("select programm.*,tourist.arvldate_trm from programm,tourist where tourist.arvldate_trm > " & DateToNumber(Me.strpdate.Text) & "", conn)
                da.Fill(ds, "pro")
                datgrdpro.Refresh()
                datgrdpro.DataSource = ds
                datgrdpro.DataMember = "pro"
            ElseIf qryprodte.Checked Then
                da = New SqlClient.SqlDataAdapter("select * from programm where dterec_pro between " & DateToNumber(dte1.Value) & " and " & DateToNumber(dte2.Value) & "", conn)
                da.Fill(ds, "pro")
                datgrdpro.Refresh()
                datgrdpro.DataSource = ds
                datgrdpro.DataMember = "pro"
            End If
            With Me.datgrdpro
                .RowHeadersDefaultCellStyle.BackColor = Color.Blue
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine
                ' .Columns(0).DefaultCellStyle.Format = "c"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        '****************************��� ��� ������ ���� ������� 
        'Dim y As Integer = (Now.Second) / 2
        'datgrdpro.Size = datgrdpro.Size + New Size(772, y)
        'If y >= 8 Then Timer2.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub btndltfldtrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltfldtrm.Click
        clntrm()
    End Sub

    Private Sub btnendpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendpro.Click
        End
        'MsgBox(Me.dtvstpro.Value.ToShortDateString)
    End Sub

    Private Sub GroupBox24_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox24.Enter

    End Sub

    Private Sub cobnamtrmpro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub plc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc1.CheckedChanged
        ch = Me.plc1.Text
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged

    End Sub

    Private Sub cobnamtrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamtrm.GotFocus
        Me.cobnamtrm.BackColor = Color.Yellow
    End Sub

    Private Sub cobnamtrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnamtrm.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnamtrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamtrm.LostFocus
        Me.cobnamtrm.BackColor = Color.White
    End Sub

    Private Sub cobnamtrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnamtrm.SelectedIndexChanged
        '*************��� ��� ������ ������ ���� ������� ��� ������ �� �����������
        constr()
        ds.Clear()
        Me.cobnogrb.Items.Clear()
        Me.cobnotrm.Items.Clear()
        da = New SqlClient.SqlDataAdapter("select * from tourist where name_trm='" & Trim(Me.cobnamtrm.Text) & "'", conn)
        da.Fill(ds, "trm")
        Try
            If ds.Tables("trm").Rows.Count = 0 Then MsgBox("������ ������ ���� �����") : Exit Sub
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("grb_no_trm")) Then cobnogrb.Text = ds.Tables("trm").Rows(0).Item("grb_no_trm")
            If Not IsDBNull(ds.Tables("trm").Rows(0).Item("no_trm")) Then cobnotrm.Text = ds.Tables("trm").Rows(0).Item("no_trm")
            txtpsstrm.Text = ds.Tables("trm").Rows(0).Item("passp_trm")
            cobgndtrm.Text = ds.Tables("trm").Rows(0).Item("gndr_trm")
            cobdsctrm.Text = ds.Tables("trm").Rows(0).Item("dsc_trm")
            txtteltrm.Text = ds.Tables("trm").Rows(0).Item("tel_trm")
            txtadrtrm.Text = ds.Tables("trm").Rows(0).Item("adrs_trm")
            txtemltrm.Text = ds.Tables("trm").Rows(0).Item("email_trm")
            txtctytrm.Text = ds.Tables("trm").Rows(0).Item("cntry_trm")
            txtcnttrm.Text = ds.Tables("trm").Rows(0).Item("cuntof_trm")
            cobdsttrm.Text = ds.Tables("trm").Rows(0).Item("dst_trm")
            dterci.Text = ds.Tables("trm").Rows(0).Item("arvldate_trm")
            dtetrv.Text = ds.Tables("trm").Rows(0).Item("dptdate_trm")
            txtplctrm.Text = ds.Tables("trm").Rows(0).Item("plctrv_trm")
            cobarvordpt.Text = ds.Tables("trm").Rows(0).Item("ofc_trv_rci")
            txtprs.Text = ds.Tables("trm").Rows(0).Item("cost_trm")
            cobfor.Text = ds.Tables("trm").Rows(0).Item("cstfor_trm")
            chkcsh.Checked = ds.Tables("trm").Rows(0).Item("cash_trm")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cobnamtrm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamtrm.TextChanged
        constr()
        da = New SqlClient.SqlDataAdapter("select * from tourist where name_trm like '% &" & Me.cobnamtrm.Text & "'", conn)
        da.Fill(ds, "trm")
    End Sub

    Private Sub btndlttrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndlttrm.Click
        '************��� ������ ��� ������ ������ ������� �����
        constr()
        Me.cobnotrm.Show()
        Me.cobnamtrm.Show()
        Me.cobnogrb.Show()
        slctrm()

        Dim dlttrm As New SqlClient.SqlCommand
        dlttrm.Connection = conn
        dlttrm.CommandType = CommandType.Text
        If cobnamtrm.Items.Count <= 1 And cobnogrb.Items.Count <= 1 Then
            dlttrm.CommandText = "delete  from tourist where no_trm=" & Me.cobnotrm.Text & ""
            If MsgBox("�� ��� ����� �� ����� �����", MsgBoxStyle.YesNo, "warring") = MsgBoxResult.No Then Exit Sub
            conn.Open()
            dlttrm.ExecuteNonQuery()
            conn.Close()
            '************��� ������ ��� ������ ������ ������� �����

        ElseIf cobnotrm.Items.Count <= 1 And cobnogrb.Items.Count <= 1 Then
            dlttrm.CommandText = "delete  from tourist where name_trm='" & Me.cobnamtrm.Text & "'"
            If MsgBox("�� ��� ����� �� ����� �����", MsgBoxStyle.YesNo, "warring") = MsgBoxResult.No Then Exit Sub
            conn.Open()
            dlttrm.ExecuteNonQuery()
            conn.Close()
            '************��� ������ ��� ������ ������ ������� ��� ��������

        ElseIf cobnotrm.Items.Count <= 1 And cobnamtrm.Items.Count <= 1 Then
            dlttrm.CommandText = "delete from tourist where grb_no_trm=" & cobnogrb.Text & " "
            If MsgBox("�� ��� ����� �� ����� �����", MsgBoxStyle.YesNo, "warring") = MsgBoxResult.No Then Exit Sub
            If MsgBox(" ����� ����� ��� ���� ��� ����� ���� ��������", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
            conn.Open()
            dlttrm.ExecuteNonQuery()
            conn.Close()
        End If
        MsgBox("����� ����� �����")
        slctrm()
    End Sub

    Private Sub btnshwtrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshwtrm.Click
        '*********** ��� ���  ������ ������
        constr()
        If btnshwtrm.Text = "���" Then
            slctrm()
            For i = 0 To ds.Tables("trm").Rows.Count - 1
                cobnotrm.Items.Add(ds.Tables("trm").Rows(i).Item("no_trm"))
                cobnamtrm.Items.Add(ds.Tables("trm").Rows(i).Item("name_trm"))
                cobnogrb.Items.Add(ds.Tables("trm").Rows(i).Item("grb_no_trm"))
            Next
            cobnotrm.Show()
            cobnamtrm.Show()
            cobnogrb.Show()
            btnedttrm.Enabled = True
            btndlttrm.Enabled = True
            slctrm()
            btnshwtrm.Text = "����� �����"
        Else
            ds.Clear()
            cobnotrm.Items.Clear()
            cobnamtrm.Items.Clear()
            cobnogrb.Items.Clear()
            cobnotrm.Hide()
            cobnamtrm.Hide()
            cobnogrb.Hide()
            btnedttrm.Enabled = False
            btndlttrm.Enabled = False
            btnshwtrm.Text = "���"
        End If
    End Sub

    Private Sub btnsavpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsavpro.Click
        '**********************************��� ��� ��������  �� ���� ����� ��������
        constr()

        slcpro()
        Dim savpro As New SqlClient.SqlCommand
        savpro.Connection = conn
        savpro.CommandType = CommandType.Text
        Dim car As String = ""
        For i = 0 To chklstcar.CheckedItems.Count - 1
            car = car & " , " & (Me.chklstcar.CheckedItems(i))
        Next
        savpro.CommandText = "update programm set dtevst_pro=" & DateToNumber(dtvstpro.Text) & ",dteout_pro=" & DateToNumber(dtoutpro.Text) & ",gud1_pro='" & Me.cobgud1.Text & "',gud2_pro='" & Me.cobgud2.Text & "',htl_pro='" & Me.cobhtlpro.Text & "',valu_pro=" & Val(Me.valpro.Text) & ",spend_pro=" & Val(Me.cstpro.Text) & ",drvr_pro='" & car & "',dterec_pro=" & DateToNumber(Me.strpdate.Text) & " where grb_pro=" & Me.cobnogrbpro.Text & " and plce_pro='" & ch & "'"
        conn.Open()
        savpro.ExecuteNonQuery()
        conn.Close()
        lblsavpro.Show()
    End Sub

    Private Sub plc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc2.CheckedChanged
        ch = Me.plc2.Text
    End Sub

    Private Sub plc3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc3.CheckedChanged
        ch = Me.plc3.Text
    End Sub

    Private Sub plc4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc4.CheckedChanged
        ch = Me.plc5.Text
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub btnendgud_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendgud.Click
        End
    End Sub
    Private Sub clearguide()
        Me.cobnamgud.Text = ""
        Me.txttelgud.Text = ""
        Me.txtadrgud.Text = ""
        Me.cobtypgud.Text = ""
        Me.txtclfgud.Text = ""

    End Sub

    Private Sub cobnamgud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamgud.GotFocus
        Me.cobnamgud.BackColor = Color.Yellow
    End Sub

    Private Sub cobnamgud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnamgud.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnamgud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnamgud.LostFocus
        Me.cobnamgud.BackColor = Color.White
    End Sub

    Private Sub cobnamgud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnamgud.SelectedIndexChanged
        '*******************��� ���� ������ ������ ������� ��� ������
        constr()
        da = New SqlClient.SqlDataAdapter("select * from guide where name_gud='" & Me.cobnamgud.Text & "'", conn)
        da.Fill(ds, "guide")
        If ds.Tables("guide").Rows.Count = 0 Then MsgBox("������ ���� �� ���� ��� ����� ��������") : Exit Sub
        If Not IsDBNull(ds.Tables("guide").Rows(0).Item("no_gud")) Then Me.lblnbrgud.Text = ds.Tables("guide").Rows(0).Item("no_gud").ToString
        If Not IsDBNull(ds.Tables("guide").Rows(0).Item(2)) Then Me.cobtypgud.Text = ds.Tables("guide").Rows(0).Item(4).ToString
        If Not IsDBNull(ds.Tables("guide").Rows(0).Item(3)) Then Me.txttelgud.Text = ds.Tables("guide").Rows(0).Item(2).ToString
        If Not IsDBNull(ds.Tables("guide").Rows(0).Item(4)) Then Me.txtadrgud.Text = ds.Tables("guide").Rows(0).Item(3).ToString
        If Not IsDBNull(ds.Tables("guide").Rows(0).Item(5)) Then Me.txtclfgud.Text = ds.Tables("guide").Rows(0).Item(5).ToString

    End Sub


    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrpttrm.Click
        Me.TabControl1.SelectedTab = TabPage5
        Me.rprttrm.Visible = True
        Me.rppro.Visible = False
        constr()
        Me.rprttrm.Visible = True
        Dim rst As New Cry2
        If Me.qrytrmall.Checked Then
            slctrm()
            rst.SetDataSource(ds.Tables("trm"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
            '***********************��� ������ ������ ������ ������� ��� ������ ������ ��� ����� �����  �������

        ElseIf qrytrmno.Checked Then
            If cmb.Text = Nothing Then MsgBox("��� �� ����� ��� ���� ������ �������") : Exit Sub
            Dim sql As String = "select * from tourist where no_trm=" & Trim(cmb.Text) & ""
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm1")
            rst.SetDataSource(ds.Tables("trm1"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
            '***********************��� ������ ������ ������ ������� ��� ������ ������ ��� ����� �����  �������

        ElseIf qrytrmnam.Checked Then
            If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
            Dim sql As String = "select * from tourist where name_trm='" & cmb.Text & "'"
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm2")
            rst.SetDataSource(ds.Tables("trm2"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
            '***********************��� ������ ������ ������ ������� ��� ������ ������ ��� ����� �����  �������

        ElseIf qrytrmgrb.Checked Then
            If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
            Dim sql As String = "select * from tourist where grb_no_trm=" & cmb.Text & ""
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm3")
            rst.SetDataSource(ds.Tables("trm3"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
            '��� ����� ������ ������ �� ���� ������ ������� ��� ������  ������ ��� ������ ������ ��� ������� �������
        ElseIf qrytrmofc.Checked Then
            If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
            Dim sql As String = "select * from tourist where ofc_trv_rci='" & cmb.Text & "'and dst_trm='����'"
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm4")
            '��� ����� ������ ������ �� ���� ������ ������� ��� ������  ������� ���� ��� ������ ������ ��� ������� �������

            If ds.Tables("trm4").Rows.Count < 1 Then MessageBox.Show("��������� ��� ������ ��������  ", "���� �����")
            rst.SetDataSource(ds.Tables("trm4"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
        ElseIf qrytrmdst.Checked Then
            If cmb.Text = Nothing Then MsgBox("������ ���� ��������� ���") : Exit Sub
            Dim sql As String = "select * from tourist where dst_trm='" & cmb.Text & "'"
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm5")
            rst.SetDataSource(ds.Tables("trm5"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
        ElseIf rdocsh1.Checked Then
            Dim sql As String = "select * from tourist where cash_trm='True '"
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm6")
            rst.SetDataSource(ds.Tables("trm6"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
        ElseIf rdocsh2.Checked Then
            Dim sql As String = "select * from tourist where cash_trm='false' "
            da = New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "trm7")
            rst.SetDataSource(ds.Tables("trm7"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()
        ElseIf qrytrmdte.Checked Then
            Dim sql As String = "select * from tourist where daterec_trm between " & dte1.Text & " and " & dte2.Text & ""
            da.Fill(ds, "trm8")
            rst.SetDataSource(ds.Tables("trm8"))
            Me.rprttrm.ReportSource = rst
            Me.rprttrm.Refresh()

        End If

    End Sub

    Private Sub rpttrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dterci_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dterci.ValueChanged
        '' (************** ��� ������� ������ ������ 
        'If Me.dterci.Value < Now Then
        '    MsgBox("������� ���� ��� ����� �� ����� ������ ���� ������� �� ������")
        '    dterci.Value = Now
        'End If
        'MsgBox(DateToNumber(dterci.Text))
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnshwpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnedtpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cobnogrbpro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnogrbpro.Click
    End Sub

    Private Sub cobnogrbpro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnogrbpro.GotFocus
        Me.cobnogrbpro.BackColor = Color.Yellow
    End Sub

    Private Sub cobnogrbpro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnogrbpro.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnogrbpro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnogrbpro.LostFocus
        Me.cobnogrbpro.BackColor = Color.White
    End Sub

    Private Sub cobnogrbpro_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnogrbpro.SelectedIndexChanged
        '***************************
        ds.Clear()
        Me.lblcnttrm.Text = Nothing
        Me.lblnamtrmpro.Text = Nothing
        plc1.Hide() : plc2.Hide() : plc3.Hide() : plc4.Hide() : plc5.Hide() '.............
        Me.cobhtlpro.Items.Clear()
        Me.cobgud1.Items.Clear()
        Me.cobgud2.Items.Clear()
        Me.dtearvpro.Text = Now
        Me.dtetrvpro.Text = Now
        '******************************************************************
        Timer1.Enabled = True : Timer1.Interval = 10 : prgress.Minimum = 0 : prgress.Maximum = 100 : prgress.Value = 0 : prgress.Visible = True
        If prgress.Value = 100 Then
            prgress.Value = 0
            prgress.Visible = False
        End If
        '*********************************************************************
        constr()
        conn.Open()
        ds = New DataSet
        Dim sql3 As String = "select plce_pro from programm where grb_pro =" & Me.cobnogrbpro.Text & " "
        da = New SqlClient.SqlDataAdapter(sql3, conn)
        da.Fill(ds, "places")
        conn.Close()
        Dim n As Integer = ds.Tables("places").Rows.Count
        If n <= 0 Then MsgBox("�� ��� ������ ����� ���� ��������") : Exit Sub
        If Not IsDBNull(ds.Tables("places").Rows(0).Item(0)) Then
            Select Case n
                Case 1
                    Me.plc1.Visible = True : Me.plc1.Text = ds.Tables("places").Rows(0).Item(0)
                Case 2
                    Me.plc1.Visible = True : Me.plc1.Text = ds.Tables("places").Rows(0).Item(0)
                    Me.plc2.Visible = True : Me.plc2.Text = ds.Tables("places").Rows(1).Item(0)
                Case 3
                    Me.plc1.Visible = True : Me.plc1.Text = ds.Tables("places").Rows(0).Item(0)
                    Me.plc2.Visible = True : Me.plc2.Text = ds.Tables("places").Rows(1).Item(0)
                    Me.plc3.Visible = True : Me.plc3.Text = ds.Tables("places").Rows(2).Item(0)
                Case 4
                    Me.plc1.Visible = True : Me.plc1.Text = ds.Tables("places").Rows(0).Item(0)
                    Me.plc2.Visible = True : Me.plc2.Text = ds.Tables("places").Rows(1).Item(0)
                    Me.plc3.Visible = True : Me.plc3.Text = ds.Tables("places").Rows(2).Item(0)
                    Me.plc4.Visible = True : Me.plc4.Text = ds.Tables("places").Rows(3).Item(0)
                Case 5
                    Me.plc1.Visible = True : Me.plc1.Text = ds.Tables("places").Rows(0).Item(0)
                    Me.plc2.Visible = True : Me.plc2.Text = ds.Tables("places").Rows(1).Item(0)
                    Me.plc3.Visible = True : Me.plc3.Text = ds.Tables("places").Rows(2).Item(0)
                    Me.plc4.Visible = True : Me.plc4.Text = ds.Tables("places").Rows(3).Item(0)
                    Me.plc5.Visible = True : Me.plc5.Text = ds.Tables("places").Rows(4).Item(0)
                Case 6
                Case 7
                Case 8
                Case 9
                Case 10
                Case 11
                Case 12
                Case 13
                Case 14
                Case 15
                Case 16
                Case 17
                Case 18
                Case 19
                Case Else
                    MessageBox.Show("������ ����� ���� ��������")
            End Select
        Else
            MsgBox("������ ����� ����� ���� ��������") : Exit Sub
        End If
        '********************
        da = New SqlClient.SqlDataAdapter("select name_trm,cuntof_trm,arvldate_trm,dptdate_trm from tourist where grb_no_trm=" & Me.cobnogrbpro.Text & " and dsc_trm='����'", conn)
        da.Fill(ds, "namgud")
        If ds.Tables("namgud").Rows.Count > 1 Then
            Me.lblnamtrmpro.Text = "���� �������� ���� �� ����"
        ElseIf ds.Tables("namgud").Rows.Count = 0 Then
            Me.lblnamtrmpro.Text = "������ ���� ���� ��������"
        Else
            lblnamtrmpro.Text = ds.Tables("namgud").Rows(0).Item(0)

        End If
        If ds.Tables("namgud").Rows.Count > 0 Then
            If Not IsDBNull(ds.Tables("namgud").Rows(0).Item(1)) Then lblcnttrm.Text = ds.Tables("namgud").Rows(0).Item(1)
            If Not IsDBNull(ds.Tables("namgud").Rows(0).Item(2)) Then Me.dtearvpro.Text = ds.Tables("namgud").Rows(0).Item(2)
            If Not IsDBNull(ds.Tables("namgud").Rows(0).Item(3)) Then Me.dtetrvpro.Text = ds.Tables("namgud").Rows(0).Item(3)
        End If
        '*******************************************************************����� ����� ������� ��� ������
        da = New SqlClient.SqlDataAdapter("select * from hotel", conn)
        da.Fill(ds, "namhtl")
        For i = 0 To ds.Tables("namhtl").Rows.Count - 1
            Me.cobhtlpro.Items.Add(ds.Tables("namhtl").Rows(i).Item("name_htl"))
        Next
        '*******************************************************************��� ����� ����� �������� ��� ������
        da = New SqlClient.SqlDataAdapter("select * from guide", conn)
        da.Fill(ds, "guide")
        For i = 0 To ds.Tables("guide").Rows.Count - 1
            Me.cobgud1.Items.Add(ds.Tables("guide").Rows(i).Item("name_gud"))
            Me.cobgud2.Items.Add(ds.Tables("guide").Rows(i).Item("name_gud"))
        Next
        '***********************************************************************��� ����� ����� ��������
        da = New SqlClient.SqlDataAdapter("select * from driver", conn)
        da.Fill(ds, "nocar")
        For i = 0 To ds.Tables("nocar").Rows.Count - 1
            Me.chklstcar.Items.Add(ds.Tables("nocar").Rows(i).Item("no_car"))
        Next
        '***********************************************************************************
        'dtvstpro.MinDate = 
        'dtvstpro.Value = Date.FromOADate(Val(Me.dtearvpro.Text))
        'Me.dtoutpro.MaxDate = Date.FromOADate(Val(Me.dtetrvpro.Text))
        'Me.dtoutpro.Value = Date.FromOADate(Val(Me.dtetrvpro.Text))
    End Sub

    Private Sub btnsavplce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsavplce.Click
        '************** ��� ��� ����� �������� ���� ������ ��� ���� ��������
        Dim sav As New SqlClient.SqlCommand
        sav.Connection = conn
        sav.CommandType = CommandType.Text
        conn.Open()
        For i = 0 To Me.chklstbx1.CheckedItems.Count - 1
            sav.CommandText = "insert into programm(grb_pro,plce_pro)values(" & Me.txtnogrb.Text & ",'" & Me.chklstbx1.CheckedItems(i) & "')"
            sav.ExecuteNonQuery()
        Next
        conn.Close()
        chklstbx1.Visible = False
        MessageBox.Show("complete saveing")
        btnplctrm.Visible = True
        btnsavplce.Visible = False
        grbno_lod()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dtvstpro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtvstpro.ValueChanged

        'If dtvstpro.Value < Me.dtearvpro.Text Then
        '    MsgBox("��� ����� ������ ����� ���� �� ����� ����� �������� ")
        'End If
    End Sub

    Private Sub dtetrv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtetrv.ValueChanged
        'If Me.dtetrv.Value < dterci.Value Then
        '    MessageBox.Show("������ �� �� ����� ����� ������� ��� ����� �����")
        '    Me.dtetrv.Value = dterci.Value
        'End If
    End Sub

    Private Sub plc5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc5.CheckedChanged
        ch = plc5.Text
    End Sub

    Private Sub rdoedtnew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'constr()
        'da = New SqlClient.SqlDataAdapter("select distinct grb_pro from programm where dtevst_pro='""' and gud1_pro='' and drvr_pro=''", conn)
        'da.Fill(ds, "pronew")
        'For i = 0 To ds.Tables("pronew").Rows.Count - 1
        '    Me.cobnogrbpro.Items.Add(ds.Tables("pronew").Rows(i).Item(0))
        'Next
    End Sub

    Private Sub rprttrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rprttrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub dtearvpro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub prgress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prgress.Click

    End Sub

    Private Sub strpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles strpdate.Click

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabControl8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tbprpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub GroupBox8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub chkacnt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkacnt.CheckedChanged

    End Sub

    Private Sub chkrpt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkrpt.CheckedChanged

    End Sub

    Private Sub chkusr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkusr.CheckedChanged

    End Sub

    Private Sub chkpro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpro.CheckedChanged

    End Sub

    Private Sub GroupBox9_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox9.Enter

    End Sub

    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click

    End Sub

    Private Sub txtnamusr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cobnameuser.BackColor = Color.Yellow
    End Sub

    Private Sub txtnamusr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '***********************************************************��� ��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ����� �� ���� �� ��� �����", MsgBoxStyle.Exclamation & "note")

        End If
    End Sub

    Private Sub txtnamusr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cobnameuser.BackColor = Color.White
    End Sub

    Private Sub txtnamusr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpasusr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpasusr.GotFocus
        Me.txtpasusr.BackColor = Color.Yellow
    End Sub

    Private Sub txtpasusr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpasusr.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtpasusr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpasusr.LostFocus
        Me.txtpasusr.BackColor = Color.White
    End Sub

    Private Sub txtpasusr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpasusr.TextChanged

    End Sub

    Private Sub Label35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label35.Click

    End Sub

    Private Sub txtspsusr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtspsusr.TextChanged

    End Sub

    Private Sub Label36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label36.Click

    End Sub

    Private Sub btnendusr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendusr.Click
        End
    End Sub

    Private Sub btnedtusr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedtusr.Click
        constr()
        If Me.txtpasusr.Text <> Me.txtspsusr.Text Then
            MsgBox(" ���� ���� ��� �������")
            Exit Sub
        Else
            Dim edtusr As New SqlClient.SqlCommand
            edtusr.Connection = conn
            edtusr.CommandType = CommandType.Text
            edtusr.CommandText = "update users set name_user='" & Me.cobnameuser.Text & "',pass_user='" & Me.txtpasusr.Text & "',users_prm='" & Me.chkusr.Checked & "', pro_prm='" & Me.chkpro.Checked & "',rpt_prm='" & Me.chkrpt.Checked & "',acnt_prm='" & Me.chkacnt.Checked & "' where name_user='" & Me.cobnameuser.Text & "'"
            conn.Open()
            edtusr.ExecuteNonQuery()
            conn.Close()
            MsgBox("complete editting")
        End If
    End Sub

    Private Sub btndltusr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltusr.Click
        constr()
        If Me.cobnameuser.Text = Nothing Then
            MessageBox.Show("��� �������� ���� ���� �� ���� �������")
            Exit Sub

        ElseIf (MessageBox.Show("�� ��� ����� �� ����� �����", MsgBoxStyle.YesNo & "warring") = Windows.Forms.DialogResult.Yes) Then
            Try
                da = New SqlClient.SqlDataAdapter("select * from users", conn)
                da.Fill(ds, "user")
                Dim dltusr As New SqlClient.SqlCommand
                dltusr.Connection = conn
                dltusr.CommandType = CommandType.Text
                dltusr.CommandText = "delete  from users where name_user='" & Me.cobnameuser.Text & "'"

                conn.Open()
                dltusr.ExecuteNonQuery()
                conn.Close()
                MsgBox("complete deleting")
            Catch ex As Exception

            End Try
        Else
            Exit Sub
        End If

    End Sub

    Private Sub tbpusr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpusr.Click

    End Sub

    Private Sub DateTimePicker12_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtimpicker.ValueChanged

    End Sub

    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox27_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox27.Enter

    End Sub

    Private Sub Label106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label106.Click

    End Sub

    Private Sub TextBox64_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label105.Click

    End Sub

    Private Sub Label104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label104.Click

    End Sub

    Private Sub TextBox63_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwaypay.TextChanged

    End Sub

    Private Sub Label103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label103.Click

    End Sub

    Private Sub TextBox62_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpurpay.TextChanged

    End Sub

    Private Sub Label102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label102.Click

    End Sub

    Private Sub TextBox61_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbankpay.TextChanged

    End Sub

    Private Sub Label101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label101.Click

    End Sub

    Private Sub Label109_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label109.Click

    End Sub

    Private Sub txtmoney_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmoney.GotFocus
        Me.txtmoney.BackColor = Color.Yellow
    End Sub

    Private Sub txtmoney_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmoney.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtmoney_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmoney.LostFocus
        Me.txtmoney.BackColor = Color.White
    End Sub

    Private Sub TextBox54_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmoney.TextChanged

    End Sub

    Private Sub Label110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label110.Click

    End Sub

    Private Sub Button57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsavpay.Click
        '*******************************��� ����� ����� ����
        If Me.cobtopay.Text = Nothing Then
            MsgBox("��� ���� ����� ��� �����  ��� �����")
            Exit Sub
        End If
        constr()
        Dim sql As String = "select * from pay"
        Dim da As New SqlClient.SqlDataAdapter(sql, conn)
        da.Fill(ds, "pay")
        Dim savpay As New SqlClient.SqlCommand
        savpay.Connection = conn
        savpay.CommandType = CommandType.Text
        savpay.CommandText = "insert into pay(pur_pa,date_pa,to_pa,way_pa,bank_pa,mony_pa) values('" & Me.txtpurpay.Text & "','" & Me.dtimpicker.Value & "','" & Me.cobtopay.Text & "','" & Me.txtwaypay.Text & "','" & Me.txtbankpay.Text & "','" & Me.txtmoney.Text & "')"
        conn.Open()
        savpay.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving")
    End Sub

    Private Sub Button58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedtpay.Click
        '**********************��� ������� ��� ������ �������
        If Me.cobtopay.Text = "" Or Me.txtwaypay.Text = "" Then
            MsgBox("��� ������ ���� ����� ����� ����� �� ��� ����� ")
            Exit Sub
        End If
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from pay", conn)
        da.Fill(ds, "pay")
        Dim updatehtl As New SqlClient.SqlCommand
        updatehtl.Connection = conn
        updatehtl.CommandType = CommandType.Text
        updatehtl.CommandText = " UPDATE pay SET  pur_pa= '" & Me.txtpurpay.Text & "', date_pa = '" & Me.dtimpicker.Value & "', to_pa='" & Me.cobtopay.Text & "' , way_pa='" & Me.txtwaypay.Text & "', bank_pa='" & Me.txtbankpay.Text & "',mony_pa='" & Me.txtmoney.Text & "'  WHERE to_pa= '" & Me.cobtopay.Text & "'"
        conn.Open()
        updatehtl.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complete editing")
    End Sub

    Private Sub Button60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshowpay.Click
        '*************************��� ������ ����� ���� ��� ������ �������
        If Me.cobtopay.Text = "" Then
            MsgBox("��� ������ ����   ��� ����� ", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

    Private Sub Panel8_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub TabPage18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage18.Click

    End Sub

    Private Sub GroupBox28_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox28.Enter

    End Sub

    Private Sub Label94_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label94.Click

    End Sub

    Private Sub TextBox55_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label95_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label95.Click

    End Sub

    Private Sub Label96_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label96.Click

    End Sub

    Private Sub TextBox57_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label97.Click

    End Sub

    Private Sub TextBox58_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpur.TextChanged

    End Sub

    Private Sub Label98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label98.Click

    End Sub

    Private Sub DateTimePicker11_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtatimpiker.ValueChanged

    End Sub

    Private Sub TextBox59_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbank.TextChanged

    End Sub

    Private Sub Label99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label99.Click

    End Sub

    Private Sub money_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles money.GotFocus
        Me.money.BackColor = Color.Yellow
    End Sub

    Private Sub money_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles money.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub money_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles money.LostFocus
        Me.money.BackColor = Color.White
    End Sub

    Private Sub TextBox66_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles money.TextChanged

    End Sub

    Private Sub Label107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label107.Click

    End Sub

    Private Sub Label108_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label108.Click

    End Sub

    Private Sub Button56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button56.Click
        '*******************************��� ����� ����� ����
        If Me.cobnamere.Text = Nothing Then
            MsgBox("��� ���� ����� ��� ������ ��� �����")
            Exit Sub
        End If
        constr()
        Dim sql As String = "select * from repay"
        Dim da As New SqlClient.SqlDataAdapter(sql, conn)
        da.Fill(ds, "repay")
        Dim savhrepay As New SqlClient.SqlCommand
        savhrepay.Connection = conn
        savhrepay.CommandType = CommandType.Text
        savhrepay.CommandText = "insert into repay(name_usert,date_re,pur_re,way_re,bank_re,mony_re) values('" & Me.cobnamere.Text & "','" & Me.dtatimpiker.Value & "','" & Me.txtpur.Text & "','" & Me.txtway.Text & "','" & Me.txtbank.Text & "','" & Me.money.Text & "')"
        conn.Open()
        savhrepay.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        '************************ ��� ������ ������� ��� ������ �������
        If Me.cobnamere.Text = "" Or Me.txtway.Text = "" Then
            MsgBox("��� ������ ���� ����� ��� ������ �� ��� ������� ")
            Exit Sub
        End If
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from repay", conn)
        da.Fill(ds, "repay")
        Dim updaterepay As New SqlClient.SqlCommand
        updaterepay.Connection = conn
        updaterepay.CommandType = CommandType.Text
        updaterepay.CommandText = " UPDATE repay SET  name_usert= '" & Me.cobnamere.Text & "', date_re = '" & Me.dtatimpiker.Value & "', pur_re='" & Me.txtpur.Text & "' , way_re='" & Me.txtway.Text & "',bank_re='" & Me.txtbank.Text & "',mony_re='" & Me.money.Text & "'  WHERE name_usert= '" & Me.cobnamere.Text & "'"
        conn.Open()
        updaterepay.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complete editing")
    End Sub

    Private Sub Button59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button59.Click
        '*************************��� ������ ����� ���� ��� ������ �������
        If Me.cobnameuser.Text = "" Then
            MsgBox("��� ������ ���� ����� ������ ������ ", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub Panel9_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub TabPage17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage17.Click

    End Sub

    Private Sub TabControl7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl7.SelectedIndexChanged

    End Sub

    Private Sub tbpacnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpacnt.Click

    End Sub

    Private Sub GroupBox12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox12.Enter

    End Sub

    Private Sub TextBox32_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinfplc.TextChanged

    End Sub

    Private Sub GroupBox13_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox13.Enter

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub Label42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label42.Click

    End Sub

    Private Sub Label43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label43.Click

    End Sub

    Private Sub TextBox29_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox30_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label44.Click

    End Sub

    Private Sub TextBox31_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadrplc.TextChanged

    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendplc.Click
        End

    End Sub
    Private Sub clearplace()
        '*******************����� ���� �������� �������� ��� ������ 
        Me.cobnameplc.Text = ""
        Me.txtadrplc.Text = ""
        Me.txtinfplc.Text = ""

    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddplc.Click
        '************************** ��� ������ ���� ����� ���� ��� �������
        If Me.cobnameplc.Text = Nothing Then
            MsgBox("��� ���� ����� ��������", MsgBoxStyle.Information)
            Exit Sub
        End If
        constr()
        Dim sql As String = "select * from trsmplace"
        Dim da As New SqlClient.SqlDataAdapter(sql, conn)
        da.Fill(ds, "trsmplace")
        Dim savtourplc As New SqlClient.SqlCommand
        savtourplc.Connection = conn
        savtourplc.CommandType = CommandType.Text
        savtourplc.CommandText = "insert into trsmplace values('" & Me.cobnameplc.Text & "', '" & Me.txtadrplc.Text & "','" & Me.txtinfplc.Text & "')"
        conn.Open()
        savtourplc.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving place data")
        clearplace()
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltplc.Click
        '********************��� ������ ��� ������ ������� �������� ��� ������ ��� ������
        If Me.cobnameplc.Text = Nothing Then
            MsgBox("��� ���� ����� ��������")
            Exit Sub
        End If
        constr()
        da = New SqlClient.SqlDataAdapter("select * from trsmplace where name_plc='" & Me.cobnameplc.Text & "'", conn)
        da.Fill(ds, "trsmplace")
        If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then clearplace() : Exit Sub
        Dim dltgud As New SqlClient.SqlCommand
        dltgud.Connection = conn
        dltgud.CommandType = CommandType.Text
        dltgud.CommandText = "delete from trsmplace where name_plc='" & Me.cobnameplc.Text & "'"
        conn.Open()
        dltgud.ExecuteNonQuery()
        conn.Close()
        MsgBox("����� ����� �����")
        clearplace()


    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub TabPage14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage14.Click

    End Sub

    Private Sub TabControl4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl4.SelectedIndexChanged

    End Sub

    Private Sub TabPage13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage13.Click

    End Sub

    Private Sub txtadrdrv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrdrv.GotFocus
        Me.txtadrdrv.BackColor = Color.Yellow
    End Sub

    Private Sub txtadrdrv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrdrv.LostFocus
        Me.txtadrdrv.BackColor = Color.White
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadrdrv.TextChanged

    End Sub

    Private Sub Label23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label24.Click

    End Sub

    Private Sub txtiddrv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtiddrv.GotFocus
        Me.txtiddrv.BackColor = Color.Yellow
    End Sub

    Private Sub txtiddrv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiddrv.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtiddrv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtiddrv.LostFocus
        Me.txtiddrv.BackColor = Color.White
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiddrv.TextChanged

    End Sub

    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnodrv.Click

    End Sub

    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click

    End Sub

    Private Sub txtexdrv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtexdrv.GotFocus
        Me.txtexdrv.BackColor = Color.Yellow
    End Sub

    Private Sub txtexdrv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexdrv.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtexdrv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtexdrv.LostFocus
        Me.txtexdrv.BackColor = Color.White
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtexdrv.TextChanged

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub txtteldrv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtteldrv.GotFocus
        Me.txtteldrv.BackColor = Color.Yellow
    End Sub

    Private Sub txtteldrv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtteldrv.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtteldrv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtteldrv.LostFocus
        Me.txtteldrv.BackColor = Color.White
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtteldrv.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mdlcar.TextChanged

    End Sub

    Private Sub Label33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.Click

    End Sub

    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label32.Click

    End Sub

    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label29.Click

    End Sub

    Private Sub txttypcar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttypcar.GotFocus

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttypcar.TextChanged

    End Sub

    Private Sub txtnocar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnocar.GotFocus
        Me.txtnocar.BackColor = Color.Yellow
    End Sub

    Private Sub txtnocar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnocar.LostFocus
        Me.txtnocar.BackColor = Color.White
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnocar.TextChanged

    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cascar.TextChanged

    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub

    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedtdrv.Click
        '******************��� ����� ������ ������
        If Me.cobdrv.Text = "" Then
            MsgBox("����� ��� ������ ������ ������", MsgBoxStyle.Information)
        End If
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from driver", conn)
        da.Fill(ds, "driver")
        Dim updatedrv As New SqlClient.SqlCommand
        updatedrv.Connection = conn
        updatedrv.CommandType = CommandType.Text
        updatedrv.CommandText = " UPDATE driver SET  name_drv = '" & Me.cobdrv.Text & "',tel_drv=" & Val(Me.txtteldrv.Text) & ",id_drv=" & Val(Me.txtiddrv.Text) & ",plcid_drv='" & Me.txtexdrv.Text & "', address_drv='" & Me.txtadrdrv.Text & "',no_car = " & Val(Me.txtnocar.Text) & ", type_car='" & Me.txttypcar.Text & "' , model_car=" & Val(Me.mdlcar.Text) & ",case_car='" & Me.cascar.Text & "'  WHERE name_drv= '" & Me.cobdrv.Text & "'"
        conn.Open()
        updatedrv.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving")
        cleardrv()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadddrv.Click
        '************* ��� ��� ���� ���� ��� �������
        If Me.cobdrv.Text = Nothing Or Me.txtnocar.Text = Nothing Or Me.txtteldrv.Text = Nothing Or Me.txtiddrv.Text = Nothing Then
            MsgBox("��� ���� ����� �������� ��������")
            Exit Sub
        End If
        constr()
        Dim sql As String = "select * from driver"
        da = New SqlClient.SqlDataAdapter(sql, conn)
        da.Fill(ds, "driver")
        Dim savdrv As New SqlClient.SqlCommand
        savdrv.Connection = conn
        savdrv.CommandType = CommandType.Text
        savdrv.CommandText = "insert into driver(name_drv,tel_drv,id_drv,plcid_drv,address_drv,no_car,type_car,model_car,case_car)values('" & Me.cobdrv.Text & "'," & Val(Me.txtteldrv.Text) & "," & Val(Me.txtiddrv.Text) & ",'" & Me.txtexdrv.Text & "','" & Me.txtadrdrv.Text & "'," & Val(Me.txtnocar.Text) & ",'" & Me.txttypcar.Text & "'," & Val(Me.mdlcar.Text) & ",'" & Me.cascar.Text & "')"
        conn.Open()
        savdrv.ExecuteNonQuery()
        conn.Close()
        MsgBox("complete saving data")
        cleardrv()
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshwdrv.Click
        '*************** ��� ������ ����� ���� ������ ������
        If Me.cobdrv.Text = "" Then
            MsgBox("��� ������ ���� ����� ������ ������ ", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltdrv.Click
        '**************************************��� ��� ������ �������� 
        If Me.cobdrv.Text = "" Then
            MsgBox("��� ������ ���� ����� ������ ������ ", MsgBoxStyle.Information)
            Exit Sub
        End If
        constr()
        da = New SqlClient.SqlDataAdapter("select * from driver where name_drv='" & Me.cobdrv.Text & "'", conn)
        da.Fill(ds, "driver")
        If ds.Tables("driver").Rows.Count = 0 Then MsgBox("������ ���� �� ���� ��� ����� ��������") : Exit Sub
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item("no_drv")) Then Me.lblnodrv.Text = ds.Tables("driver").Rows(0).Item("no_gud").ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(2)) Then Me.txtteldrv.Text = ds.Tables("driver").Rows(0).Item(2).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(3)) Then Me.txtiddrv.Text = ds.Tables("driver").Rows(0).Item(3).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(3)) Then Me.txtexdrv.Text = ds.Tables("driver").Rows(0).Item(4).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(4)) Then Me.txtadrdrv.Text = ds.Tables("driver").Rows(0).Item(5).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(5)) Then Me.txtnocar.Text = ds.Tables("driver").Rows(0).Item(6).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(6)) Then Me.txttypcar.Text = ds.Tables("driver").Rows(0).Item(7).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(6)) Then Me.mdlcar.Text = ds.Tables("driver").Rows(0).Item(8).ToString
        If Not IsDBNull(ds.Tables("driver").Rows(0).Item(6)) Then Me.cascar.Text = ds.Tables("driver").Rows(0).Item(9).ToString

        If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
        Dim dltdrv As New SqlClient.SqlCommand
        dltdrv.Connection = conn
        dltdrv.CommandType = CommandType.Text
        dltdrv.CommandText = "delete from driver where name_drv='" & Me.cobdrv.Text & "'"
        conn.Open()
        dltdrv.ExecuteNonQuery()
        conn.Close()
        MsgBox("����� ����� �����")
        cleardrv()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenddrv.Click
        End
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclndrv.Click
        '*********��� ��� �������� ������� ��� ������ ����� �������
        cleardrv()
    End Sub
    Private Sub cleardrv()
        '**********����� ���� ������ ������
        Me.cobdrv.Text = ""
        Me.txtteldrv.Text = ""
        Me.txtiddrv.Text = ""
        Me.txtexdrv.Text = ""
        Me.txtadrdrv.Text = ""
        Me.txtnocar.Text = ""
        Me.txttypcar.Text = ""
        Me.mdlcar.Text = ""
        Me.cascar.Text = ""
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TabPage6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub txtnamgud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblnbrgud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnbrgud.Click

    End Sub

    Private Sub cobtypgud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobtypgud.SelectedIndexChanged

    End Sub

    Private Sub GroupBox15_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox15.Enter

    End Sub

    Private Sub txtclfgud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtclfgud.GotFocus
        Me.txtclfgud.BackColor = Color.Yellow
    End Sub

    Private Sub txtclfgud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtclfgud.LostFocus
        Me.txtclfgud.BackColor = Color.White
    End Sub

    Private Sub txtclfgud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclfgud.TextChanged

    End Sub

    Private Sub GroupBox14_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox14.Enter

    End Sub

    Private Sub Label45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label45.Click

    End Sub

    Private Sub Label47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label47.Click

    End Sub

    Private Sub Label48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label48.Click

    End Sub

    Private Sub Label49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label49.Click

    End Sub

    Private Sub Label50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label50.Click

    End Sub

    Private Sub Label51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label51.Click

    End Sub

    Private Sub txttelgud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelgud.GotFocus
        Me.txttelgud.BackColor = Color.Yellow
    End Sub

    Private Sub txttelgud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelgud.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txttelgud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelgud.LostFocus
        Me.txttelgud.BackColor = Color.White
    End Sub

    Private Sub txttelgud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttelgud.TextChanged

    End Sub

    Private Sub txtadrgud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrgud.GotFocus
        Me.txtadrgud.BackColor = Color.Yellow
    End Sub

    Private Sub txtadrgud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrgud.LostFocus
        Me.txtadrgud.BackColor = Color.White
    End Sub

    Private Sub txtadrgud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadrgud.TextChanged

    End Sub

    Private Sub TabPage16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage16.Click

    End Sub

    Private Sub TabControl5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl5.SelectedIndexChanged

    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub GroupBox17_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox17.Enter

    End Sub

    Private Sub GroupBox16_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox16.Enter

    End Sub

    Private Sub Label46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label46.Click

    End Sub

    Private Sub TextBox39_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox42_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label52.Click

    End Sub

    Private Sub Label53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label53.Click

    End Sub

    Private Sub Label54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label54.Click

    End Sub

    Private Sub Label55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label55.Click

    End Sub

    Private Sub Label56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label56.Click

    End Sub

    Private Sub Label69_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label69.Click

    End Sub

    Private Sub Label70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label70.Click

    End Sub

    Private Sub Label71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label71.Click

    End Sub

    Private Sub txtfaxofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfaxofc.GotFocus
        Me.txtfaxofc.BackColor = Color.Yellow
    End Sub

    Private Sub txtfaxofc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfaxofc.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtfaxofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfaxofc.LostFocus
        Me.txtfaxofc.BackColor = Color.White
    End Sub

    Private Sub TextBox43_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfaxofc.TextChanged

    End Sub

    Private Sub txtboxofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtboxofc.GotFocus
        Me.txtboxofc.BackColor = Color.Yellow
    End Sub

    Private Sub txtboxofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtboxofc.LostFocus
        Me.txtboxofc.BackColor = Color.White
    End Sub

    Private Sub TextBox44_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxofc.TextChanged

    End Sub

    Private Sub txttelofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelofc.GotFocus
        Me.txttelofc.BackColor = Color.Yellow
    End Sub

    Private Sub txttelofc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelofc.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txttelofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelofc.LostFocus
        Me.txttelofc.BackColor = Color.White
    End Sub

    Private Sub TextBox45_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttelofc.TextChanged

    End Sub

    Private Sub txtadrofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrofc.GotFocus
        Me.txtadrofc.BackColor = Color.Yellow
    End Sub

    Private Sub txtadrofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrofc.LostFocus
        Me.txtadrofc.BackColor = Color.White
    End Sub

    Private Sub TextBox46_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadrofc.TextChanged

    End Sub

    Private Sub txttwnofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttwnofc.GotFocus
        Me.txttwnofc.BackColor = Color.Yellow
    End Sub

    Private Sub txttwnofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttwnofc.LostFocus
        Me.txttwnofc.BackColor = Color.White
    End Sub

    Private Sub TextBox47_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttwnofc.TextChanged

    End Sub

    Private Sub txtctyofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctyofc.GotFocus
        Me.txtctyofc.BackColor = Color.Yellow
    End Sub

    Private Sub txtctyofc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctyofc.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtctyofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctyofc.LostFocus
        Me.txtctyofc.BackColor = Color.White
    End Sub

    Private Sub TextBox48_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctyofc.TextChanged

    End Sub

    Private Sub txtemlofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemlofc.GotFocus
        Me.txtemlofc.BackColor = Color.Yellow
    End Sub

    Private Sub txtemlofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemlofc.LostFocus
        Me.txtemlofc.BackColor = Color.White
    End Sub
    Private Sub TextBox49_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemlofc.TextChanged

    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclnofc.Click
        ofc()

    End Sub
    Private Sub ofc()
        '**************** ��� ���� �������� ������� �� ������
        Me.cobnameofc.Text = ""
        Me.txtctyofc.Text = ""
        Me.txttwnofc.Text = ""
        Me.txtadrofc.Text = ""
        Me.txttelofc.Text = ""
        Me.txtfaxofc.Text = ""
        Me.txtboxofc.Text = ""
        Me.txtemlofc.Text = ""

    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltofc.Click
        '*************************��� ���� ������ ������
        If Me.cobnameofc.Text = "" Then
            MsgBox(" ��� ���� ����� ��������� ��������", MsgBoxStyle.Information)
            Exit Sub
        Else
            constr()
            Dim sqlt As String = "select * from office_client where name_ofc='" & Me.cobnameofc.Text & "'"
            ds = New DataSet
            conn.Open()
            da = New SqlClient.SqlDataAdapter(sqlt, conn)
            da.Fill(ds, "office_client")
            conn.Close()
        End If
        If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
        Dim dltofc As New SqlClient.SqlCommand
        dltofc.Connection = conn
        dltofc.CommandType = CommandType.Text
        dltofc.CommandText = "delete office_client where name_ofc='" & Me.cobnameofc.Text & "'"
        conn.Open()
        dltofc.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet deleting")
        ofc()

    End Sub


    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedtofc.Click
        '"""""""""""'��� ����� ��� ������ ���� �������
        If Me.cobnameofc.Text = "" Then
            MsgBox(" ��� ���� ����� ��������� ��������", MsgBoxStyle.Information)
            Exit Sub
        End If
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from office_client", conn)
        da.Fill(ds, "office_client")
        Dim updateclnt As New SqlClient.SqlCommand
        updateclnt.Connection = conn
        updateclnt.CommandType = CommandType.Text
        updateclnt.CommandText = " UPDATE office_client SET  name_ofc= '" & Me.cobnameofc.Text & "', cntry_ofc = '" & Me.txtctyofc.Text & "', town_ofc='" & Me.txttwnofc.Text & "' , address_ofc='" & Me.txtadrofc.Text & "',tel_ofc=" & Val(txttelofc.Text) & ",fax_ofc=" & Val(txtfaxofc.Text) & ",box_ofc='" & Me.txtboxofc.Text & "',email_ofc='" & txtemlofc.Text & "'  WHERE name_ofc= '" & Me.cobnameofc.Text & "' "
        conn.Open()
        updateclnt.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving")
        ofc()

    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddofc.Click
        '**********************��� ����� ���� ������ ��� �������
        If Me.cobnameofc.Text = "" Then
            MsgBox(" ��� ���� ����� ��������� ��������")
            Exit Sub
        Else
            constr()
            Dim sql As String = "select * from office_client"
            Dim da As New SqlClient.SqlDataAdapter(sql, conn)
            da.Fill(ds, "office_client")
            Dim savoffice As New SqlClient.SqlCommand
            savoffice.Connection = conn
            savoffice.CommandType = CommandType.Text
            savoffice.CommandText = "insert into office_client(name_ofc,cntry_ofc,town_ofc,address_ofc,tel_ofc,fax_ofc,box_ofc,email_ofc) values('" & Me.cobnameofc.Text & "', '" & Me.txtctyofc.Text & "','" & Me.txttwnofc.Text & "','" & Me.txtadrofc.Text & "'," & Val(txttelofc.Text) & "," & Val(txtfaxofc.Text) & ",'" & Me.txtboxofc.Text & "','" & Me.txtemlofc.Text & "')"
            conn.Open()
            savoffice.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("complet saving")
            ofc()

        End If
    End Sub

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnendofc.Click
        End

    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub lblnohtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnohtl.Click

    End Sub

    Private Sub GroupBox10_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox10.Enter

    End Sub

    Private Sub GroupBox11_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox11.Enter

    End Sub

    Private Sub Label37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label37.Click

    End Sub

    Private Sub txtadrhtl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrhtl.GotFocus
        Me.txtadrhtl.BackColor = Color.Yellow
    End Sub

    Private Sub txtadrhtl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrhtl.LostFocus
        Me.txtadrhtl.BackColor = Color.White
    End Sub

    Private Sub txtadrhtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadrhtl.TextChanged

    End Sub

    Private Sub txttelhtl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelhtl.GotFocus
        Me.txttelhtl.BackColor = Color.Yellow
    End Sub

    Private Sub txttelhtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelhtl.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txttelhtl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelhtl.LostFocus
        Me.txttelhtl.BackColor = Color.White
    End Sub

    Private Sub txttelhtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttelhtl.TextChanged

    End Sub

    Private Sub txtnamhtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label38.Click

    End Sub

    Private Sub Label39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label39.Click

    End Sub

    Private Sub Label40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label40.Click

    End Sub

    Private Sub Label41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label41.Click

    End Sub

    Private Sub cobtyphtl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobtyphtl.GotFocus
        Me.cobtyphtl.BackColor = Color.Yellow
    End Sub

    Private Sub cobtyphtl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobtyphtl.LostFocus
        Me.cobtyphtl.BackColor = Color.White
    End Sub

    Private Sub cobtyphtl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobtyphtl.SelectedIndexChanged

    End Sub

    Private Sub btndlthtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndlthtl.Click
        '*********************** ��� ������ ������ ��� ������ ��� ������ ������ ����
        Me.cobnamhtl.Visible = True
        If Me.cobnamhtl.Text = Nothing Then
            MsgBox("��� ������ ���� ����� ��� ������ ", MsgBoxStyle.Information)
            Exit Sub
        End If
        constr()
        Dim sqlt As String = "select * from hotel where name_htl='" & Me.cobnamhtl.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "hotel")
        conn.Close()
        If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
        Dim dlhtl As New SqlClient.SqlCommand
        dlhtl.Connection = conn
        dlhtl.CommandType = CommandType.Text
        dlhtl.CommandText = "delete hotel where name_htl='" & Me.cobnamhtl.Text & "'"
        conn.Open()
        dlhtl.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("Data is deleted")
        cleahtl()

    End Sub

    Private Sub btnedthtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedthtl.Click
        '****************************����� ������� ��� ������ ������
        Me.cobnamhtl.Visible = True

        Me.btnedthtl.Text = "���"


        If Me.cobnamhtl.Text = Nothing Then
            MsgBox("��� ������ ���� ����� ��� ������ ")
            Exit Sub
        End If
        constr()

        Dim da As New SqlClient.SqlDataAdapter("select * from hotel", conn)
        da.Fill(ds, "hotel")

        Dim updatehtl As New SqlClient.SqlCommand

        updatehtl.Connection = conn
        updatehtl.CommandType = CommandType.Text


        updatehtl.CommandText = " UPDATE hotel SET  name_htl= '" & Me.cobnamhtl.Text & "', tel_htl = " & Val(txttelhtl.Text) & ", address_htl='" & Me.txtadrhtl.Text & "' , class_htl='" & Me.cobtyphtl.Text & "',other_htl='" & Me.txtother.Text & "'  WHERE name_htl= '" & Me.cobnamhtl.Text & "'"

        conn.Open()
        updatehtl.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complete editing")
        cleahtl()
        Me.btnedthtl.Text = "�����"


    End Sub
    Private Sub cleahtl()
        '****************��� ��� �������� ������� ��� ������ ������ �������
        Me.cobnamhtl.Text = ""
        Me.cobnamhtl.Text = ""
        Me.txtadrhtl.Text = ""
        Me.cobtyphtl.Text = ""
        Me.txttelhtl.Text = ""
        Me.txtother.Text = ""

    End Sub

    Private Sub txtother_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtother.GotFocus
        Me.txtother.BackColor = Color.Yellow
    End Sub

    Private Sub txtother_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtother.LostFocus
        Me.txtother.BackColor = Color.White
    End Sub

    Private Sub txtinfhtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtother.TextChanged

    End Sub

    Private Sub tbprchtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbprchtl.Click

    End Sub

    Private Sub TabControl3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl3.SelectedIndexChanged

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub GroupBox29_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox29.Enter

    End Sub

    Private Sub datgrdpro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datgrdpro.CellContentClick

    End Sub

    Private Sub Button64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button64.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TabControl1.SelectedTab = TabPage5
        Me.rppro.Visible = True
        Me.rprttrm.Visible = False
        Try
            Dim rpr As New Crypro1
            If qrypronow.Checked Then
                Dim sql As String = "select  tourist.arvldate_trm,tourist.dptdate_trm,programm.* from programm,tourist  where tourist.dptdate_trm <=" & DateToNumber(Me.strpdate.Text) & " and tourist.arvldate_trm >=" & DateToNumber(Me.strpdate.Text) & ""
                da = New SqlClient.SqlDataAdapter(sql, conn)
                da.Fill(ds, "pro_trm")
                rpr.SetDataSource(ds.Tables("pro_trm"))
                Me.rppro.ReportSource = rpr
                rppro.Refresh()
                '********************* ��� ��������� ���� �������� �� ���� ��������
            ElseIf qryprogrb.Checked Then
                da = New SqlClient.SqlDataAdapter("select * from programm where grb_pro=" & cmb.Text & "", conn)
                da.Fill(ds, "pro2")
                rpr.SetDataSource(ds.Tables("pro2"))
                Me.rppro.ReportSource = rpr
                rppro.Refresh()
                '***********  ��� ������� ������ ������ ������ �������� ��������
            ElseIf qryproltr.Checked Then
                da = New SqlClient.SqlDataAdapter("select programm.*,tourist.arvldate_trm from programm,tourist where tourist.arvldate_trm > " & DateToNumber(Me.strpdate.Text) & "", conn)
                da.Fill(ds, "pro")
                datgrdpro.Refresh()
                datgrdpro.DataSource = ds
                datgrdpro.DataMember = "pro"
            ElseIf qryprodte.Checked Then
                da = New SqlClient.SqlDataAdapter("select * from programm where dterec_pro between " & DateToNumber(dte1.Value) & " and " & DateToNumber(dte2.Value) & "", conn)
                da.Fill(ds, "pro")
                datgrdpro.Refresh()
                datgrdpro.DataSource = ds
                datgrdpro.DataMember = "pro"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TabPage9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage9.Click

    End Sub

    Private Sub GroupBox26_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox26.Enter

    End Sub

    Private Sub Label91_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label91.Click

    End Sub

    Private Sub Label86_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label86.Click

    End Sub

    Private Sub GroupBox23_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox23.Enter

    End Sub

    Private Sub valpro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valpro.GotFocus
        Me.valpro.BackColor = Color.Yellow
    End Sub

    Private Sub valpro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valpro.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub valpro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valpro.LostFocus
        Me.valpro.BackColor = Color.White
    End Sub

    Private Sub valpro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valpro.TextChanged

    End Sub

    Private Sub Label75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label75.Click

    End Sub

    Private Sub Label76_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label76.Click

    End Sub

    Private Sub Label77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label77.Click

    End Sub

    Private Sub chklstcar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstcar.MouseLeave
        Me.chklstcar.BackColor = Color.White
    End Sub

    Private Sub chklstcar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chklstcar.MouseMove
        Me.chklstcar.BackColor = Color.Yellow
    End Sub

    Private Sub chklstcar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklstcar.SelectedIndexChanged

    End Sub

    Private Sub cobgud2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobgud2.GotFocus
        Me.cobgud2.BackColor = Color.Yellow
    End Sub

    Private Sub cobgud2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobgud2.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobgud2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobgud2.LostFocus
        Me.cobgud2.BackColor = Color.White
    End Sub

    Private Sub cobgud2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobgud2.SelectedIndexChanged

    End Sub

    Private Sub cobgud1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobgud1.GotFocus
        Me.cobgud1.BackColor = Color.Yellow
    End Sub

    Private Sub cobgud1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobgud1.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobgud1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobgud1.LostFocus
        Me.cobgud1.BackColor = Color.White
    End Sub

    Private Sub cobgud1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobgud1.SelectedIndexChanged

    End Sub

    Private Sub Label80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label80.Click

    End Sub

    Private Sub Label81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label81.Click

    End Sub

    Private Sub Label82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label82.Click

    End Sub

    Private Sub cobhtlpro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobhtlpro.GotFocus
        Me.cobhtlpro.BackColor = Color.Yellow
    End Sub

    Private Sub cobhtlpro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobhtlpro.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobhtlpro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobhtlpro.LostFocus
        Me.cobhtlpro.BackColor = Color.White
    End Sub

    Private Sub cobhtlpro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobhtlpro.SelectedIndexChanged

    End Sub

    Private Sub Label83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label83.Click

    End Sub

    Private Sub Label84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label84.Click

    End Sub

    Private Sub cstpro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cstpro.GotFocus
        Me.cstpro.BackColor = Color.Yellow
    End Sub

    Private Sub cstpro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cstpro.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cstpro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cstpro.LostFocus
        Me.cstpro.BackColor = Color.White
    End Sub

    Private Sub cstpro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cstpro.TextChanged

    End Sub

    Private Sub plc7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc7.CheckedChanged

    End Sub

    Private Sub plc6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc6.CheckedChanged

    End Sub

    Private Sub plc11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc11.CheckedChanged

    End Sub

    Private Sub plc8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc8.CheckedChanged

    End Sub

    Private Sub plc12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc12.CheckedChanged

    End Sub

    Private Sub plc10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc10.CheckedChanged

    End Sub

    Private Sub plc9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc9.CheckedChanged

    End Sub

    Private Sub plc14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc14.CheckedChanged

    End Sub

    Private Sub plc17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc17.CheckedChanged

    End Sub

    Private Sub plc13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc13.CheckedChanged

    End Sub

    Private Sub plc15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc15.CheckedChanged

    End Sub

    Private Sub plc18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc18.CheckedChanged

    End Sub

    Private Sub plc19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc19.CheckedChanged

    End Sub

    Private Sub plc20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc20.CheckedChanged

    End Sub

    Private Sub plc16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plc16.CheckedChanged

    End Sub

    Private Sub GroupBox22_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox22.Enter

    End Sub

    Private Sub lblsavpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblsavpro.Click

    End Sub

    Private Sub Panel7_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Label72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label72.Click

    End Sub

    Private Sub Label73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label73.Click

    End Sub

    Private Sub Label78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label78.Click

    End Sub

    Private Sub lblcnttrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcnttrm.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub lblnopro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnopro.Click

    End Sub

    Private Sub lblnamtrmpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnamtrmpro.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub cobarvordpt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobarvordpt.GotFocus
        Me.cobarvordpt.BackColor = Color.Yellow
    End Sub

    Private Sub cobarvordpt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobarvordpt.LostFocus
        Me.cobarvordpt.BackColor = Color.White
    End Sub

    Private Sub cobarvordpt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobarvordpt.SelectedIndexChanged

    End Sub

    Private Sub txtplctrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtplctrm.GotFocus
        Me.txtplctrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtplctrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtplctrm.LostFocus
        Me.txtplctrm.BackColor = Color.White
    End Sub

    Private Sub txtplctrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtplctrm.TextChanged

    End Sub

    Private Sub txtctytrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctytrm.GotFocus
        Me.txtctytrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtctytrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctytrm.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtctytrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctytrm.LostFocus
        Me.txtctytrm.BackColor = Color.White
    End Sub

    Private Sub txtctytrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctytrm.TextChanged

    End Sub

    Private Sub txtteltrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtteltrm.GotFocus
        Me.txtteltrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtteltrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtteltrm.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtteltrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtteltrm.LostFocus
        Me.txtteltrm.BackColor = Color.White

    End Sub

    Private Sub txtteltrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtteltrm.TextChanged

    End Sub

    Private Sub Label74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label74.Click

    End Sub

    Private Sub txtemltrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemltrm.GotFocus
        Me.txtemltrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtemltrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemltrm.LostFocus
        Me.txtemltrm.BackColor = Color.White
    End Sub

    Private Sub txtemltrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemltrm.TextChanged

    End Sub

    Private Sub txtadrtrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrtrm.GotFocus
        Me.txtadrtrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtadrtrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadrtrm.LostFocus
        Me.txtadrtrm.BackColor = Color.White
    End Sub

    Private Sub txtadrtrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadrtrm.TextChanged

    End Sub

    Private Sub txtcnttrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcnttrm.GotFocus
        Me.txtcnttrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtcnttrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcnttrm.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtcnttrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcnttrm.LostFocus
        Me.txtcnttrm.BackColor = Color.White
    End Sub

    Private Sub txtcnttrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcnttrm.TextChanged

    End Sub

    Private Sub chklstbx1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstbx1.GotFocus

    End Sub

    Private Sub chklstbx1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstbx1.MouseLeave
        Me.chklstbx1.BackColor = Color.White
    End Sub

    Private Sub chklstbx1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chklstbx1.MouseMove
        Me.chklstbx1.BackColor = Color.Yellow
    End Sub

    Private Sub chklstbx1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklstbx1.SelectedIndexChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub txtnamtrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnamtrm.GotFocus
        Me.txtnamtrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtnamtrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnamtrm.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtnamtrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnamtrm.LostFocus
        Me.txtnamtrm.BackColor = Color.White
    End Sub

    Private Sub txtnamtrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnamtrm.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtnogrb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnogrb.GotFocus
        Me.txtnogrb.BackColor = Color.Yellow
    End Sub

    Private Sub txtnogrb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnogrb.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtnogrb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnogrb.LostFocus
        Me.txtnogrb.BackColor = Color.White
    End Sub

    Private Sub txtnogrb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnogrb.TextChanged

    End Sub

    Private Sub txtpsstrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpsstrm.GotFocus
        Me.txtpsstrm.BackColor = Color.Yellow
    End Sub

    Private Sub txtpsstrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpsstrm.LostFocus
        Me.txtpsstrm.BackColor = Color.White
    End Sub

    Private Sub txtpsstrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpsstrm.TextChanged

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub cobdsctrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobdsctrm.GotFocus
        Me.cobdsctrm.BackColor = Color.Yellow
    End Sub

    Private Sub cobdsctrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobdsctrm.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobdsctrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobdsctrm.LostFocus
        Me.cobdsctrm.BackColor = Color.White
    End Sub

    Private Sub cobdsctrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobdsctrm.SelectedIndexChanged
        '****************��� ������� ���� �������� ��� ������� ���� ��� �� ��� ��������
        constr()
        da = New SqlClient.SqlDataAdapter("select * from tourist where grb_no_trm='" & Me.txtnogrb.Text & "' and dsc_trm='����'", conn)
        da.Fill(ds, "onegud")
        If ds.Tables("onegud").Rows.Count > 0 Then
            MsgBox("������ ������ ���� �� ���� ��������")
            Me.cobdsctrm.ValueMember = "���"
        End If
    End Sub

    Private Sub cobgndtrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobgndtrm.GotFocus
        Me.cobgndtrm.BackColor = Color.Yellow
    End Sub

    Private Sub cobgndtrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobgndtrm.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobgndtrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobgndtrm.LostFocus
        Me.cobgndtrm.BackColor = Color.White
    End Sub

    Private Sub cobgndtrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobgndtrm.SelectedIndexChanged

    End Sub

    Private Sub txtprs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprs.GotFocus
        Me.txtprs.BackColor = Color.Yellow
    End Sub

    Private Sub txtprs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprs.KeyPress
        '***********************************************************************��� �������� �� ����� ��� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub txtprs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprs.LostFocus
        Me.txtprs.BackColor = Color.White
    End Sub

    Private Sub txtprs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprs.TextChanged

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub cobfor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobfor.GotFocus
        Me.cobfor.BackColor = Color.Yellow
    End Sub

    Private Sub cobfor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobfor.LostFocus
        Me.cobfor.BackColor = Color.White
    End Sub

    Private Sub cobfor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobfor.SelectedIndexChanged

    End Sub

    Private Sub chkcsh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcsh.CheckedChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub lblnotrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnotrm.Click

    End Sub

    Private Sub lblshwtrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblshwtrm.Click

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub rdoedtnew_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoedtnew.CheckedChanged
        ds.Clear()
        Me.lblcnttrm.Text = Nothing
        Me.lblnamtrmpro.Text = Nothing
        Me.lblnopro.Text = Nothing
        plc1.Hide() : plc2.Hide() : plc3.Hide() : plc4.Hide() : plc5.Hide() '.............
        Me.cobhtlpro.Items.Clear()
        Me.cobgud1.Items.Clear()
        Me.cobgud2.Items.Clear()
        Me.dtearvpro.Text = Now
        Me.dtetrvpro.Text = Now
        '****************************************************************************
        constr()
        da = New SqlClient.SqlDataAdapter("select distinct grb_pro from programm where dtevst_pro is null and gud1_pro is null", conn)
        da.Fill(ds, "pronew")
        For i = 0 To ds.Tables("pronew").Rows.Count - 1
            Me.cobnogrbpro.Items.Add(ds.Tables("pronew").Rows(i).Item(0))
        Next
    End Sub

    Private Sub rdoedtold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoedtold.CheckedChanged
        ds.Clear()
        Me.lblcnttrm.Text = Nothing
        Me.lblnamtrmpro.Text = Nothing
        Me.lblnopro.Text = Nothing
        plc1.Hide() : plc2.Hide() : plc3.Hide() : plc4.Hide() : plc5.Hide() '.............
        Me.cobhtlpro.Items.Clear()
        Me.cobgud1.Items.Clear()
        Me.cobgud2.Items.Clear()
        Me.dtearvpro.Text = Now
        Me.dtetrvpro.Text = Now
        '*******************************************************************
        constr()
        da = New SqlClient.SqlDataAdapter("select distinct grb_pro from programm where dtevst_pro='" & DBNull.Value & "' and gud1_pro='" & DBNull.Value & "'", conn)
        da.Fill(ds, "proold")
        For i = 0 To ds.Tables("proold").Rows.Count - 1
            Me.cobnogrbpro.Items.Add(ds.Tables("proold").Rows(i).Item(0))
        Next
    End Sub

    Private Sub form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub btnshwtrm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnshwtrm.Paint
        Dim path As New Drawing2D.GraphicsPath
        'path.AddArc(70, 10, 150, 150, 135, 195)
        'path.AddArc(200, 10, 150, 150, 210, 195)
        'path.AddLine(40, 0, 0, 250)
        'path.AddLine(0, 250, 288, 250)
        'path.AddLine(288, 250, 328, 0)
        'path.AddLine(328, 0, 0, 0)
        path.AddEllipse(141, 30, 80, 80)
        'Me.btnshwtrm.Region = New Region(path)
    End Sub

    Private Sub btnshowofc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshowofc.Click
        '**************��� ����� ����� ���� ������ ������
        If Me.cobnameofc.Text = "" Then
            MsgBox(" ��� ���� ����� ��������� ��������", MsgBoxStyle.Information)
            Exit Sub
        Else

        End If
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshowguide.Click
        '**************��� ����� ����� ���� ������ ������

        If Me.cobnamgud.Text = "" Then
            MsgBox("��� ������ ���� ����� ������ ������ ", MsgBoxStyle.Information)
            Exit Sub

        End If


    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedtguide.Click
        '********************* ��� ����� ��� ������ ������
        If Me.cobnamgud.Text = "" Then
            MsgBox(" ��� ���� ����� ��������� ��������", MsgBoxStyle.Information)
            Exit Sub
        End If
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from guide", conn)
        da.Fill(ds, "guide")
        Dim updateclnt As New SqlClient.SqlCommand
        updateclnt.Connection = conn
        updateclnt.CommandType = CommandType.Text
        updateclnt.CommandText = " UPDATE guide SET  name_gud= '" & Me.cobnamgud.Text & "', tel_gud = " & Val(Me.txttelgud.Text) & ", address_gud='" & Me.txtadrgud.Text & "',type_gud='" & Me.cobtypgud.Text & "' , qulfc_gud='" & Me.txtclfgud.Text & "' WHERE name_gud= '" & Me.cobnamgud.Text & "' "
        conn.Open()
        updateclnt.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complet saving")
        clearguide()
    End Sub

    Private Sub cobnameofc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnameofc.GotFocus
        Me.cobnameofc.BackColor = Color.Yellow
    End Sub

    Private Sub cobnameofc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnameofc.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobnameofc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnameofc.LostFocus
        Me.cobnameofc.BackColor = Color.White
    End Sub

    Private Sub cobnameofc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnameofc.SelectedIndexChanged
        '**************** ��� ���� ������ ������ ��� ������ ��� ������
        constr()
        Dim sqlt As String = "select * from office_client where name_ofc='" & Me.cobnameofc.Text & "'"
        ds = New DataSet
        conn.Open()

        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "office_client")
        conn.Close()

        Me.cobnameofc.Text = ds.Tables("office_client").Rows(0).Item(1).ToString
        Me.txtctyofc.Text = ds.Tables("office_client").Rows(0).Item(2).ToString
        Me.txttwnofc.Text = ds.Tables("office_client").Rows(0).Item(3).ToString
        Me.txtadrofc.Text = ds.Tables("office_client").Rows(0).Item(4).ToString
        Me.txttelofc.Text = ds.Tables("office_client").Rows(0).Item(5).ToString
        Me.txtfaxofc.Text = ds.Tables("office_client").Rows(0).Item(6).ToString
        Me.txtboxofc.Text = ds.Tables("office_client").Rows(0).Item(7).ToString
        Me.txtemlofc.Text = ds.Tables("office_client").Rows(0).Item(8).ToString
        Me.btnshowofc.Enabled = False

    End Sub

    Private Sub cobdrv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobdrv.GotFocus
        Me.cobdrv.BackColor = Color.Yellow
    End Sub

    Private Sub cobdrv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobdrv.KeyPress
        '***********************************************************************��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ��� �� ��� �����")
        End If
    End Sub

    Private Sub cobdrv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobdrv.LostFocus
        Me.cobdrv.BackColor = Color.White
    End Sub

    Private Sub cobdrv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobdrv.SelectedIndexChanged
        '***********��� ��� �������� ������ �������
        constr()
        Dim sqlt As String = "select * from driver where name_drv='" & Me.cobdrv.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "driver")
        conn.Close()
        Me.cobdrv.Text = ds.Tables("driver").Rows(0).Item(1)
        Me.txtteldrv.Text = ds.Tables("driver").Rows(0).Item(2).ToString
        Me.txtiddrv.Text = ds.Tables("driver").Rows(0).Item(3).ToString
        Me.txtexdrv.Text = ds.Tables("driver").Rows(0).Item(4).ToString
        Me.txtadrdrv.Text = ds.Tables("driver").Rows(0).Item(5).ToString
        Me.txtnocar.Text = ds.Tables("driver").Rows(0).Item(6).ToString
        Me.txttypcar.Text = ds.Tables("driver").Rows(0).Item(7).ToString
        Me.mdlcar.Text = ds.Tables("driver").Rows(0).Item(8).ToString
        Me.cascar.Text = ds.Tables("driver").Rows(0).Item(9).ToString
        Me.btnshwdrv.Enabled = False
    End Sub

    Private Sub cobnameplc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnameplc.SelectedIndexChanged
        '********** ��� ������ ����� ���� ������ ������� �������
        constr()
        Dim sqlt As String = "select * from trsmplace where name_plc='" & Me.cobnameplc.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "trsmplace")
        conn.Close()
        Me.cobdrv.Text = ds.Tables("trsmplace").Rows(0).Item(1)
        Me.txtadrplc.Text = ds.Tables("trsmplace").Rows(0).Item(2).ToString
        Me.txtinfplc.Text = ds.Tables("trsmplace").Rows(0).Item(3).ToString


    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        '******************** ��� ����� ��� ������ ������� ��������
        If Me.cobnameplc.Text = Nothing Then
            MsgBox("��� ������ ���� ����� ��� ������ ")
            Exit Sub
        End If
        constr()
        Dim da As New SqlClient.SqlDataAdapter("select * from trsmplace", conn)
        da.Fill(ds, "trsmplace")
        Dim updateplc As New SqlClient.SqlCommand
        updateplc.Connection = conn
        updateplc.CommandType = CommandType.Text
        updateplc.CommandText = " UPDATE trsmplace SET  name_plc= '" & Me.cobnameplc.Text & "', address_plc =' " & Me.txtadrplc.Text & "', other_plc='" & Me.txtinfplc.Text & "'  WHERE name_plc= '" & Me.cobnameplc.Text & "'"
        conn.Open()
        updateplc.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("complete editing")
        cleahtl()
        Me.btnedthtl.Text = "�����"
        clearplace()
    End Sub
    '
    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub curusr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles curusr.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnamere.SelectedIndexChanged
        '****************** ��� ���� ������ ���������
        constr()
        Dim sqlt As String = "select * from repay where name_usert='" & Me.cobnamere.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "repay")
        conn.Close()

        Me.dtatimpiker.Value = ds.Tables("repay").Rows(0).Item(2).ToString
        Me.txtpur.Text = ds.Tables("repay").Rows(0).Item(3).ToString
        Me.txtway.Text = ds.Tables("repay").Rows(0).Item(4).ToString
        Me.txtbank.Text = ds.Tables("repay").Rows(0).Item(5).ToString
        Me.money.Text = ds.Tables("repay").Rows(0).Item(6).ToString



    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        End

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        '*************��� ���� ������ �������
        If Me.cobnamere.Text = Nothing Then
            MsgBox("��� ������ ���� ����� ������ ")
            Exit Sub
        End If
        constr()
        Dim sqlt As String = "select * from hotel where name_htl='" & Me.cobnamhtl.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "hotel")
        conn.Close()
        If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
        Dim dltepay As New SqlClient.SqlCommand
        dltepay.Connection = conn
        dltepay.CommandType = CommandType.Text
        dltepay.CommandText = "delete repay where name_usert='" & Me.cobnamere.Text & "'"
        conn.Open()
        dltepay.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("Data is deleted")
    End Sub

    Private Sub cobtopay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobtopay.SelectedIndexChanged
        '************ ��� ���� ������ ������� 
        constr()
        Dim sqlt As String = "select * from pay where to_pa='" & Me.cobtopay.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqlt, conn)
        da.Fill(ds, "pay")
        conn.Close()

        Me.dtimpicker.Value = ds.Tables("pay").Rows(0).Item(2).ToString
        Me.txtpurpay.Text = ds.Tables("pay").Rows(0).Item(1).ToString
        Me.txtwaypay.Text = ds.Tables("pay").Rows(0).Item(4).ToString
        Me.txtbankpay.Text = ds.Tables("pay").Rows(0).Item(5).ToString
        Me.txtmoney.Text = ds.Tables("pay").Rows(0).Item(6).ToString

    End Sub

    Private Sub btndltepay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndltepay.Click
        '****************** ��� ������ ��� ������ �������
        If Me.cobtopay.Text = Nothing Then
            MsgBox("��� ������ ���� ��� ����� ", MsgBoxStyle.MsgBoxHelp)
            Exit Sub
        End If
        constr()
        Dim sqltl As String = "select * from pay where to_pa='" & Me.cobtopay.Text & "'"
        ds = New DataSet
        conn.Open()
        da = New SqlClient.SqlDataAdapter(sqltl, conn)
        da.Fill(ds, "pay")
        conn.Close()
        If MsgBox("�� ��� ����� �� ����� �����...���� ��� ��� ����� ����� ������� ����� ������� ��", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "warring") = MsgBoxResult.No Then Exit Sub
        Dim dltepaay As New SqlClient.SqlCommand
        dltepaay.Connection = conn
        dltepaay.CommandType = CommandType.Text
        dltepaay.CommandText = "delete pay where to_pa='" & Me.cobtopay.Text & "'"
        conn.Open()
        dltepaay.ExecuteNonQuery()
        conn.Close()
        MessageBox.Show("Data is deleted")
    End Sub

    Private Sub btnexitpay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexitpay.Click
        End

    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        Me.ComboBox1.BackColor = Color.Yellow
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress

    End Sub

    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        Me.ComboBox1.BackColor = Color.White
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Me.Opacity = Me.Opacity + 0.2
    End Sub

    Private Sub cobnameuser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnameuser.Click
        constr()
        ds.Clear()
        Me.cobnameuser.Items.Clear()
        da = New SqlClient.SqlDataAdapter("select * from users", conn)
        da.Fill(ds, "user")
        For i = 0 To ds.Tables("user").Rows.Count - 1
            Me.cobnameuser.Items.Add(ds.Tables("user").Rows(i).Item(1))
        Next
    End Sub

    Private Sub cobnameuser_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnameuser.GotFocus
        Me.cobnameuser.BackColor = Color.Yellow
    End Sub

    Private Sub cobnameuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobnameuser.KeyPress
        '***********************************************************��� ��� �������� �� ����� ���� ���
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Not Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MessageBox.Show("������ ����� ��� �� ���� �� ��� �����", MsgBoxStyle.Exclamation & "note")

        End If
    End Sub

    Private Sub cobnameuser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobnameuser.LostFocus
        Me.cobnameuser.BackColor = Color.White
    End Sub

    Private Sub cobnameuser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobnameuser.SelectedIndexChanged
        constr()
        ds.Clear()
        da = New SqlClient.SqlDataAdapter("select * from users where name_user='" & Me.cobnameuser.Text & "'", conn)
        da.Fill(ds, "users")
        If ds.Tables("users").Rows.Count < 1 Then
            MsgBox("������������ ���� �����")
        Else
            If Not IsDBNull(ds.Tables("users").Rows(0).Item(2)) Then Me.txtpasusr.Text = ds.Tables("users").Rows(0).Item(2)
            If Not IsDBNull(ds.Tables("users").Rows(0).Item(3)) Then Me.chkusr.Checked = ds.Tables("users").Rows(0).Item(3)
            If Not IsDBNull(ds.Tables("users").Rows(0).Item(4)) Then Me.chkpro.Checked = ds.Tables("users").Rows(0).Item(4)
            If Not IsDBNull(ds.Tables("users").Rows(0).Item(5)) Then Me.chkrpt.Checked = ds.Tables("users").Rows(0).Item(5)
            If Not IsDBNull(ds.Tables("users").Rows(0).Item(6)) Then Me.chkacnt.Checked = ds.Tables("users").Rows(0).Item(6)
        End If
    End Sub

    Private Sub �������������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �������������ToolStripMenuItem.Click
        Logon.ShowDialog()
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        constr()
        da = New SqlClient.SqlDataAdapter("select * from guide where dterec_gud = " & DateToNumber(Me.strpdate.Text) & "", conn)
        da.Fill(ds, "qury")
        datgrdtrm.Refresh()
        datgrdtrm.DataSource = ds
        datgrdtrm.DataMember = "qury"
    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.TabControl1.SelectedTab = TabPage5

    End Sub

    Private Sub rppro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rppro.Load

    End Sub
End Class