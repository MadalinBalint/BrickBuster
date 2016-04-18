Public Class Form1
    Dim paleta As Paddle
    Dim minge As Ball
    Dim perete As Wall
    Dim ballTimer As Timer
    Dim vieti As Integer

    ' Functie pentru miscarea paletei
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'handle your keys here
        If keyData = Keys.Left Then
            paleta.Move(-15, 0)
            Me.Refresh()
            Return True
        End If

        If keyData = Keys.Right Then
            paleta.Move(15, 0)
            Me.Refresh()
            Return True
        End If

        Return False
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        paleta = New Paddle(80, 15, Me.Size.Width, Me.Size.Height, Pens.BlueViolet)
        minge = New Ball(25, Pens.Red)
        perete = New Wall(12, 8, 43, 20, 5, 5)
        vieti = 3

        minge.SetPosition(Me.Size.Width / 2 - 12, paleta.y - 20)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        minge.Move()
        paleta.Draw(e)
        minge.Draw(e)
        perete.Draw(e)
    End Sub
End Class