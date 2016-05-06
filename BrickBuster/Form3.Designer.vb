<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOptionsOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbPlayer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbEasy = New System.Windows.Forms.RadioButton()
        Me.rbMedium = New System.Windows.Forms.RadioButton()
        Me.rbHard = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbKeyboard = New System.Windows.Forms.CheckBox()
        Me.cbMouse = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbOff = New System.Windows.Forms.RadioButton()
        Me.rbOn = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOptionsOk
        '
        Me.btnOptionsOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOptionsOk.Location = New System.Drawing.Point(295, 238)
        Me.btnOptionsOk.Name = "btnOptionsOk"
        Me.btnOptionsOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOptionsOk.TabIndex = 0
        Me.btnOptionsOk.Text = "Ok"
        Me.btnOptionsOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Player name:"
        '
        'tbPlayer
        '
        Me.tbPlayer.Location = New System.Drawing.Point(120, 25)
        Me.tbPlayer.Name = "tbPlayer"
        Me.tbPlayer.Size = New System.Drawing.Size(250, 22)
        Me.tbPlayer.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Sound effects:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Difficulty:"
        '
        'rbEasy
        '
        Me.rbEasy.AutoSize = True
        Me.rbEasy.Location = New System.Drawing.Point(120, 95)
        Me.rbEasy.Name = "rbEasy"
        Me.rbEasy.Size = New System.Drawing.Size(60, 21)
        Me.rbEasy.TabIndex = 7
        Me.rbEasy.Text = "Easy"
        Me.rbEasy.UseVisualStyleBackColor = True
        '
        'rbMedium
        '
        Me.rbMedium.AutoSize = True
        Me.rbMedium.Location = New System.Drawing.Point(120, 120)
        Me.rbMedium.Name = "rbMedium"
        Me.rbMedium.Size = New System.Drawing.Size(78, 21)
        Me.rbMedium.TabIndex = 8
        Me.rbMedium.Text = "Medium"
        Me.rbMedium.UseVisualStyleBackColor = True
        '
        'rbHard
        '
        Me.rbHard.AutoSize = True
        Me.rbHard.Location = New System.Drawing.Point(120, 145)
        Me.rbHard.Name = "rbHard"
        Me.rbHard.Size = New System.Drawing.Size(60, 21)
        Me.rbHard.TabIndex = 9
        Me.rbHard.Text = "Hard"
        Me.rbHard.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Input method:"
        '
        'cbKeyboard
        '
        Me.cbKeyboard.AutoSize = True
        Me.cbKeyboard.Location = New System.Drawing.Point(120, 175)
        Me.cbKeyboard.Name = "cbKeyboard"
        Me.cbKeyboard.Size = New System.Drawing.Size(91, 21)
        Me.cbKeyboard.TabIndex = 11
        Me.cbKeyboard.Text = "Keyboard"
        Me.cbKeyboard.UseVisualStyleBackColor = True
        '
        'cbMouse
        '
        Me.cbMouse.AutoSize = True
        Me.cbMouse.Location = New System.Drawing.Point(120, 200)
        Me.cbMouse.Name = "cbMouse"
        Me.cbMouse.Size = New System.Drawing.Size(72, 21)
        Me.cbMouse.TabIndex = 12
        Me.cbMouse.Text = "Mouse"
        Me.cbMouse.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbOff)
        Me.Panel1.Controls.Add(Me.rbOn)
        Me.Panel1.Location = New System.Drawing.Point(120, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(122, 29)
        Me.Panel1.TabIndex = 13
        '
        'rbOff
        '
        Me.rbOff.AutoSize = True
        Me.rbOff.Location = New System.Drawing.Point(58, 3)
        Me.rbOff.Name = "rbOff"
        Me.rbOff.Size = New System.Drawing.Size(48, 21)
        Me.rbOff.TabIndex = 7
        Me.rbOff.TabStop = True
        Me.rbOff.Text = "Off"
        Me.rbOff.UseVisualStyleBackColor = True
        '
        'rbOn
        '
        Me.rbOn.AutoSize = True
        Me.rbOn.Location = New System.Drawing.Point(3, 3)
        Me.rbOn.Name = "rbOn"
        Me.rbOn.Size = New System.Drawing.Size(48, 21)
        Me.rbOn.TabIndex = 6
        Me.rbOn.Text = "On"
        Me.rbOn.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 273)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbMouse)
        Me.Controls.Add(Me.cbKeyboard)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rbHard)
        Me.Controls.Add(Me.rbMedium)
        Me.Controls.Add(Me.rbEasy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbPlayer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOptionsOk)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOptionsOk As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tbPlayer As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents rbEasy As RadioButton
    Friend WithEvents rbMedium As RadioButton
    Friend WithEvents rbHard As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents cbKeyboard As CheckBox
    Friend WithEvents cbMouse As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbOff As RadioButton
    Friend WithEvents rbOn As RadioButton
End Class
