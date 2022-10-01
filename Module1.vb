Module Module1
    Public conn As New SqlClient.SqlConnection
    Public da As New SqlClient.SqlDataAdapter
    Public path As String
    Public Sub constr()
        'conn.ConnectionString = "Data Source=.\sqlexpress;AttachDbFilename=" & Application.StartupPath & "\data2.mdf;Integrated Security=True"
        conn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\data2.mdf;Integrated Security=True;User Instance=True"

    End Sub
    Public Sub opnmenu()

    End Sub
    Public cmb As New ComboBox()
    Public lbl As New Label()
    Public dte1 As New DateTimePicker()
    Public dte2 As New DateTimePicker
    Public rdocsh1 As New RadioButton()
    Public rdocsh2 As New RadioButton()
    Public chklstbx As New CheckedListBox()
    Public namusr As String
    '***************************************************************
    Public bgusr As Boolean
    Public bgpro As Boolean
    Public bgrpt As Boolean
    Public bgacnt As Boolean
    Public txtusr As String
    
    Public Function DateToNumber(ByVal ToNumber As String) As String
        Dim Temp() As String = Split(ToNumber, "/")
        For i As Integer = 0 To Temp.GetUpperBound(0)
            If Len(Temp(i)) < 2 Then
                Temp(i) = "0" & Temp(i)
            End If
        Next
        Return Temp(2) & Temp(0) & Temp(1)
    End Function
End Module
