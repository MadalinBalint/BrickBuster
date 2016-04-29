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
        Me.InformatiiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabelaDeOnoareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformatiAutorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetariJocToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.IesireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.SetariToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetariJocToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.IesireToolStripMenuItem})
        Me.SetariToolStripMenuItem.Name = "SetariToolStripMenuItem"
        Me.SetariToolStripMenuItem.Size = New System.Drawing.Size(59, 24)
        Me.SetariToolStripMenuItem.Text = "Setari"
        '
        'InformatiiToolStripMenuItem
        '
        Me.InformatiiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TabelaDeOnoareToolStripMenuItem, Me.InformatiAutorToolStripMenuItem})
        Me.InformatiiToolStripMenuItem.Name = "InformatiiToolStripMenuItem"
        Me.InformatiiToolStripMenuItem.Size = New System.Drawing.Size(86, 24)
        Me.InformatiiToolStripMenuItem.Text = "Informatii"
        '
        'TabelaDeOnoareToolStripMenuItem
        '
        Me.TabelaDeOnoareToolStripMenuItem.Name = "TabelaDeOnoareToolStripMenuItem"
        Me.TabelaDeOnoareToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.TabelaDeOnoareToolStripMenuItem.Text = "Tabela de onoare"
        '
        'InformatiAutorToolStripMenuItem
        '
        Me.InformatiAutorToolStripMenuItem.Name = "InformatiAutorToolStripMenuItem"
        Me.InformatiAutorToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.InformatiAutorToolStripMenuItem.Text = "Date autor"
        '
        'SetariJocToolStripMenuItem
        '
        Me.SetariJocToolStripMenuItem.Name = "SetariJocToolStripMenuItem"
        Me.SetariJocToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SetariJocToolStripMenuItem.Text = "Setari joc"
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
        Me.IesireToolStripMenuItem.Text = "Iesire"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 26)
        Me.ToolStripMenuItem1.Text = "Reseteaza joc"
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
    Friend WithEvents TabelaDeOnoareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformatiAutorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetariJocToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents IesireToolStripMenuItem As ToolStripMenuItem
End Class
