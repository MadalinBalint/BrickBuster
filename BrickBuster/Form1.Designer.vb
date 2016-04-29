<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SetariToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miResetGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.IesireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformatiiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetariToolStripMenuItem, Me.InformatiiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(772, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SetariToolStripMenuItem
        '
        Me.SetariToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNewGame, Me.miResetGame, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripSeparator1, Me.IesireToolStripMenuItem})
        Me.SetariToolStripMenuItem.Name = "SetariToolStripMenuItem"
        Me.SetariToolStripMenuItem.Size = New System.Drawing.Size(60, 24)
        Me.SetariToolStripMenuItem.Text = "Game"
        '
        'miNewGame
        '
        Me.miNewGame.Name = "miNewGame"
        Me.miNewGame.Size = New System.Drawing.Size(181, 26)
        Me.miNewGame.Text = "New game"
        '
        'miResetGame
        '
        Me.miResetGame.Enabled = False
        Me.miResetGame.Name = "miResetGame"
        Me.miResetGame.ShowShortcutKeys = False
        Me.miResetGame.Size = New System.Drawing.Size(181, 26)
        Me.miResetGame.Text = "Reset game"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'IesireToolStripMenuItem
        '
        Me.IesireToolStripMenuItem.Name = "IesireToolStripMenuItem"
        Me.IesireToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.IesireToolStripMenuItem.Text = "Exit"
        '
        'InformatiiToolStripMenuItem
        '
        Me.InformatiiToolStripMenuItem.Name = "InformatiiToolStripMenuItem"
        Me.InformatiiToolStripMenuItem.Size = New System.Drawing.Size(62, 24)
        Me.InformatiiToolStripMenuItem.Text = "About"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(181, 26)
        Me.ToolStripMenuItem2.Text = "Scoreboard"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(181, 26)
        Me.ToolStripMenuItem3.Text = "Options"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(772, 553)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BrickBuster"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SetariToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformatiiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miNewGame As ToolStripMenuItem
    Friend WithEvents miResetGame As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents IesireToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class
