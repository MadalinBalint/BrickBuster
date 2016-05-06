<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.btnScoreboardOk = New System.Windows.Forms.Button()
        Me.tabelScoruri = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tabelScoruri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnScoreboardOk
        '
        Me.btnScoreboardOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScoreboardOk.Location = New System.Drawing.Point(396, 316)
        Me.btnScoreboardOk.Name = "btnScoreboardOk"
        Me.btnScoreboardOk.Size = New System.Drawing.Size(75, 25)
        Me.btnScoreboardOk.TabIndex = 0
        Me.btnScoreboardOk.Text = "Ok"
        Me.btnScoreboardOk.UseVisualStyleBackColor = True
        '
        'tabelScoruri
        '
        Me.tabelScoruri.AllowUserToAddRows = False
        Me.tabelScoruri.AllowUserToDeleteRows = False
        Me.tabelScoruri.AllowUserToResizeColumns = False
        Me.tabelScoruri.AllowUserToResizeRows = False
        Me.tabelScoruri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabelScoruri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tabelScoruri.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tabelScoruri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabelScoruri.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.tabelScoruri.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.tabelScoruri.Location = New System.Drawing.Point(12, 12)
        Me.tabelScoruri.MultiSelect = False
        Me.tabelScoruri.Name = "tabelScoruri"
        Me.tabelScoruri.ReadOnly = True
        Me.tabelScoruri.RowTemplate.Height = 24
        Me.tabelScoruri.Size = New System.Drawing.Size(459, 285)
        Me.tabelScoruri.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "Jucator"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.ToolTipText = "Numele jucatorului"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Scor"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.ToolTipText = "Scorul realizat de jucator"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Dificultate"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.ToolTipText = "Gradul de dificultate al jocului"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 353)
        Me.Controls.Add(Me.tabelScoruri)
        Me.Controls.Add(Me.btnScoreboardOk)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scoreboard"
        CType(Me.tabelScoruri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnScoreboardOk As Button
    Friend WithEvents tabelScoruri As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
