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
        Me.ballTimer = New System.Windows.Forms.Timer(Me.components)
        Me.menuBrickBuster = New System.Windows.Forms.MenuStrip()
        Me.miGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNewGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miResetGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEndGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.miScoreBoard = New System.Windows.Forms.ToolStripMenuItem()
        Me.miOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuBrickBuster.SuspendLayout()
        Me.SuspendLayout()
        '
        'ballTimer
        '
        Me.ballTimer.Enabled = True
        Me.ballTimer.Interval = 10
        '
        'menuBrickBuster
        '
        Me.menuBrickBuster.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.menuBrickBuster.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuBrickBuster.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGame, Me.miAbout})
        Me.menuBrickBuster.Location = New System.Drawing.Point(0, 0)
        Me.menuBrickBuster.Name = "menuBrickBuster"
        Me.menuBrickBuster.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuBrickBuster.Size = New System.Drawing.Size(772, 28)
        Me.menuBrickBuster.TabIndex = 0
        Me.menuBrickBuster.Text = "MenuStrip1"
        '
        'miGame
        '
        Me.miGame.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNewGame, Me.miResetGame, Me.miEndGame, Me.miScoreBoard, Me.miOptions, Me.ToolStripSeparator1, Me.miExit})
        Me.miGame.Name = "miGame"
        Me.miGame.ShortcutKeyDisplayString = ""
        Me.miGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.miGame.Size = New System.Drawing.Size(60, 24)
        Me.miGame.Text = "&Game"
        '
        'miNewGame
        '
        Me.miNewGame.Name = "miNewGame"
        Me.miNewGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.miNewGame.Size = New System.Drawing.Size(209, 26)
        Me.miNewGame.Text = "&New game"
        Me.miNewGame.ToolTipText = "Deschide un joc nou"
        '
        'miResetGame
        '
        Me.miResetGame.Enabled = False
        Me.miResetGame.Name = "miResetGame"
        Me.miResetGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.miResetGame.Size = New System.Drawing.Size(209, 26)
        Me.miResetGame.Text = "&Reset game"
        Me.miResetGame.ToolTipText = "Reseteaza jocul curent"
        '
        'miEndGame
        '
        Me.miEndGame.Enabled = False
        Me.miEndGame.Name = "miEndGame"
        Me.miEndGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.miEndGame.Size = New System.Drawing.Size(209, 26)
        Me.miEndGame.Text = "&End game"
        Me.miEndGame.ToolTipText = "Termina jocul curent"
        '
        'miScoreBoard
        '
        Me.miScoreBoard.Name = "miScoreBoard"
        Me.miScoreBoard.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.miScoreBoard.Size = New System.Drawing.Size(209, 26)
        Me.miScoreBoard.Text = "&Scoreboard"
        Me.miScoreBoard.ToolTipText = "Tabela cu scoruri"
        '
        'miOptions
        '
        Me.miOptions.Name = "miOptions"
        Me.miOptions.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.miOptions.Size = New System.Drawing.Size(209, 26)
        Me.miOptions.Text = "&Options"
        Me.miOptions.ToolTipText = "Optiunile disponibile pentru joc"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(206, 6)
        '
        'miExit
        '
        Me.miExit.Name = "miExit"
        Me.miExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.miExit.Size = New System.Drawing.Size(209, 26)
        Me.miExit.Text = "E&xit"
        Me.miExit.ToolTipText = "Iesire din program"
        '
        'miAbout
        '
        Me.miAbout.Name = "miAbout"
        Me.miAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.miAbout.Size = New System.Drawing.Size(62, 24)
        Me.miAbout.Text = "&About"
        Me.miAbout.ToolTipText = "Despre autorul acestui program"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(772, 553)
        Me.Controls.Add(Me.menuBrickBuster)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.menuBrickBuster
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BrickBuster"
        Me.menuBrickBuster.ResumeLayout(False)
        Me.menuBrickBuster.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ballTimer As Timer
    Friend WithEvents menuBrickBuster As MenuStrip
    Friend WithEvents miGame As ToolStripMenuItem
    Friend WithEvents miAbout As ToolStripMenuItem
    Friend WithEvents miNewGame As ToolStripMenuItem
    Friend WithEvents miResetGame As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miExit As ToolStripMenuItem
    Friend WithEvents miScoreBoard As ToolStripMenuItem
    Friend WithEvents miOptions As ToolStripMenuItem
    Friend WithEvents miEndGame As ToolStripMenuItem
End Class
