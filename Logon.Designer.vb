<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Logon
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtnamlog As System.Windows.Forms.TextBox
    Friend WithEvents txtpasslog As System.Windows.Forms.TextBox
    Friend WithEvents btnlog As System.Windows.Forms.Button
    Friend WithEvents btnendlog As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Logon))
        Me.UsernameLabel = New System.Windows.Forms.Label
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.txtnamlog = New System.Windows.Forms.TextBox
        Me.txtpasslog = New System.Windows.Forms.TextBox
        Me.btnlog = New System.Windows.Forms.Button
        Me.btnendlog = New System.Windows.Forms.Button
        Me.AxShockwaveFlash1 = New AxShockwaveFlashObjects.AxShockwaveFlash
        CType(Me.AxShockwaveFlash1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Maroon
        Me.UsernameLabel.ForeColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Location = New System.Drawing.Point(351, 9)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "«”„ «·„” Œœ„"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Maroon
        Me.PasswordLabel.ForeColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.Location = New System.Drawing.Point(351, 66)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "ﬂ·„… «·„—Ê—"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtnamlog
        '
        Me.txtnamlog.BackColor = System.Drawing.Color.Yellow
        Me.txtnamlog.ForeColor = System.Drawing.Color.Black
        Me.txtnamlog.Location = New System.Drawing.Point(353, 29)
        Me.txtnamlog.Name = "txtnamlog"
        Me.txtnamlog.Size = New System.Drawing.Size(220, 20)
        Me.txtnamlog.TabIndex = 1
        '
        'txtpasslog
        '
        Me.txtpasslog.BackColor = System.Drawing.Color.Yellow
        Me.txtpasslog.ForeColor = System.Drawing.Color.Black
        Me.txtpasslog.Location = New System.Drawing.Point(353, 86)
        Me.txtpasslog.Name = "txtpasslog"
        Me.txtpasslog.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpasslog.Size = New System.Drawing.Size(220, 20)
        Me.txtpasslog.TabIndex = 3
        '
        'btnlog
        '
        Me.btnlog.BackColor = System.Drawing.Color.Maroon
        Me.btnlog.ForeColor = System.Drawing.Color.Transparent
        Me.btnlog.Location = New System.Drawing.Point(365, 310)
        Me.btnlog.Name = "btnlog"
        Me.btnlog.Size = New System.Drawing.Size(94, 37)
        Me.btnlog.TabIndex = 4
        Me.btnlog.Text = "œŒÊ·"
        Me.btnlog.UseVisualStyleBackColor = False
        '
        'btnendlog
        '
        Me.btnendlog.BackColor = System.Drawing.Color.Maroon
        Me.btnendlog.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnendlog.ForeColor = System.Drawing.Color.Transparent
        Me.btnendlog.Location = New System.Drawing.Point(465, 310)
        Me.btnendlog.Name = "btnendlog"
        Me.btnendlog.Size = New System.Drawing.Size(94, 37)
        Me.btnendlog.TabIndex = 5
        Me.btnendlog.Text = "≈·€«¡"
        Me.btnendlog.UseVisualStyleBackColor = False
        '
        'AxShockwaveFlash1
        '
        Me.AxShockwaveFlash1.Enabled = True
        Me.AxShockwaveFlash1.Location = New System.Drawing.Point(222, 10)
        Me.AxShockwaveFlash1.Name = "AxShockwaveFlash1"
        Me.AxShockwaveFlash1.OcxState = CType(resources.GetObject("AxShockwaveFlash1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxShockwaveFlash1.Size = New System.Drawing.Size(358, 393)
        Me.AxShockwaveFlash1.TabIndex = 7
        '
        'Logon
        '
        Me.AcceptButton = Me.btnlog
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(583, 491)
        Me.Controls.Add(Me.btnendlog)
        Me.Controls.Add(Me.btnlog)
        Me.Controls.Add(Me.txtpasslog)
        Me.Controls.Add(Me.txtnamlog)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.AxShockwaveFlash1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Logon"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Logon"
        CType(Me.AxShockwaveFlash1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxShockwaveFlash1 As AxShockwaveFlashObjects.AxShockwaveFlash

End Class
