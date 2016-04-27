Public Class Form1
    Public paleta As Paddle ' paleta cu care lovim mingea
    Public minge As Ball ' mingea propriu-zisa
    Public perete As Wall ' peretele nostru format din mai multe caramizi
    Public caramizi As List(Of Brick) ' caramida de care se loveste mingea
    Public paddleMovement As Integer = 35  ' cu cat se poate misca paleta stanga sau dreapta
    Public isGamePaused As Boolean = False ' daca jocul a fost pus pe pauza

    Public Function titlu() As String
        Return "BrickBuster - " & perete.vieti & " vieti - " & perete.scor & " puncte"
    End Function

    ' Functie pentru miscarea paletei
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        ' Tasta stanga
        If keyData = Keys.Left Then
            ' Daca am pus pauza ignoram tasta
            If isGamePaused = True Then Return True

            paleta.Move(-paddleMovement, 0)
            If minge.isMoving = False Then
                ' Miscam mingea odata cu paleta, doar daca si paleta se misca
                If paleta.isMoving = True Then
                    minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
                End If
            End If
            Return True
        End If

        ' Tasta dreapta
        If keyData = Keys.Right Then
            ' Daca am pus pauza ignoram tasta
            If isGamePaused = True Then Return True

            paleta.Move(paddleMovement, 0)
            If minge.isMoving = False Then
                ' Miscam mingea odata cu paleta, doar daca si paleta se misca
                If paleta.isMoving = True Then
                    minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
                End If
            End If
            Return True
        End If

        ' Tasta Spacebar = elibereaza mingea si aceasta incepe sa se miste
        If keyData = Keys.Space Then
            ' Daca am pus pauza ignoram tasta
            If isGamePaused = True Then Return True

            If minge.isMoving = True Then Return True
            minge.isMoving = True

            ' Lasam in stanga si dreapta o margine de 40 pixeli unde unghiul mingii va fi acelasi
            ' Vom avea un FOV de 120 grade
            'minge.angle = Math.PI / 2.0 'paleta.GetAngle(40, Math.PI / 1.5)
            minge.angle = Math.PI
            My.Computer.Audio.Play(My.Resources.Peow, AudioPlayMode.Background)
            Return True
        End If

        ' Tasta P = pauza
        If keyData = Keys.P Then
            isGamePaused = Not isGamePaused
            Return True
        End If

        Return False
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        paleta = New Paddle(80, 15, Me.ClientSize.Width, Me.ClientSize.Height, Pens.LemonChiffon)
        minge = New Ball(20, Me.ClientSize.Width, Me.ClientSize.Height, Pens.Red)
        perete = New Wall(12, 8, 43, 25, 5, 5)
        perete.vieti = 10

        minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
        Me.Text = titlu()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        caramizi = perete.Collision(minge)

        ' Daca am pus pauza nu mai miscam mingea
        If minge.isMoving = True And isGamePaused = False Then
            ' Tinem cont de pozitia paletei si de caramizile existente
            minge.Bounce(paleta, caramizi, perete)
            minge.Move()
        End If

        ' Daca cumva atingem partea de jos a ecranului, pierdem o viata
        If minge.stopped = True Then
            perete.vieti -= 1

            ' Am terminat toate vietile, afisam mesaj si terminam programul
            If perete.vieti <= 0 Then
                Timer1.Stop()
                MsgBox("Draga jucator, ati pierdut toate vietile avute la dispozitie." & vbNewLine & "Mai mult noroc data viitoare", 0, "Final de joc")
                Me.Close()
            End If

            minge.stopped = False
            minge.isMoving = False

            minge.angle = Math.PI
            minge.multiplier = 1.0
            perete.PowerUp = Wall.TipuriCaramizi.EMPTY
            paleta.multiplier = 1.0
            'minge.angle = paleta.GetAngle(40, Math.PI / 1.5)

            ' Pozitionam mingea fix centrata pe mijlocul unde se regaseste in acel moment paleta
            minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
        End If

        paleta.Draw(e)
        minge.Draw(e)
        perete.Draw(e)
    End Sub

    ' Functia prin care reimprospatam pozitia mingii, o data la 10ms (de 100x pe secunda)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If isGamePaused = True Then Me.Text = titlu() + " - PAUZA" Else Me.Text = titlu()
        Me.Refresh()
    End Sub
End Class