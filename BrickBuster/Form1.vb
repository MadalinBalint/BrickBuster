Public Class Form1
    Public paleta As Paddle
    Public minge As Ball
    Public perete As Wall
    Public vieti As Integer
    Public scor As Integer
    Public paddleMovement As Integer = 20

    ' Functie pentru miscarea paletei
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        ' Tasta stanga
        If keyData = Keys.Left Then
            paleta.Move(-paddleMovement, 0)
            If minge.isMoving = False Then
                ' Miscam mingea odata cu paleta, doar daca si paleta se misca
                If paleta.isMoving = True Then
                    minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius)
                End If
            End If
            Return True
        End If

        ' Tasta dreapta
        If keyData = Keys.Right Then
            paleta.Move(paddleMovement, 0)
            If minge.isMoving = False Then
                ' Miscam mingea odata cu paleta, doar daca si paleta se misca
                If paleta.isMoving = True Then
                    minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius)
                End If
            End If
            Return True
        End If

        ' Tasta Spacebar = elibereaza mingea si aceasta incepe sa se miste
        If keyData = Keys.Space Then
            If minge.isMoving = True Then Return True
            minge.isMoving = True
        End If

        Return False
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        paleta = New Paddle(90, 15, Me.ClientSize.Width, Me.ClientSize.Height, Pens.LemonChiffon)
        minge = New Ball(25, Me.ClientSize.Width, Me.ClientSize.Height, Pens.Red)
        perete = New Wall(12, 8, 43, 20, 5, 5)
        vieti = 3

        'minge.SetPosition((Me.ClientSize.Width - minge.radius) \ 2, paleta.y - minge.radius)
        minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Daca cumva atingem partea de jos a ecranului, pierdem o viata
        If minge.stopped = True Then
            vieti -= 1

            ' Am terminat toate vietile, afisam mesaj si terminam programul
            If vieti <= 0 Then
                Timer1.Stop()
                MsgBox("Draga jucator, ati pierdut toate vietile avute la dispozitie." & vbNewLine & "Mai mult noroc data viitoare", 0, "Final de joc")
                Me.Close()
            End If

            minge.stopped = False
            minge.isMoving = False

            ' Pozitionam mingea fix centrata pe mijlocul unde se regaseste in acel moment paleta
            minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius)
        End If
        If minge.isMoving = True Then
            minge.Move()
            minge.Bounce()
        End If

        paleta.Draw(e)
        minge.Draw(e)
        perete.Draw(e)
        Me.Text = "BrickBuster - " & vieti & " vieti - " & scor & " puncte"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Refresh()
    End Sub
End Class