Public Class Form1
    Public paleta As Paddle ' paleta cu care lovim mingea
    Public minge As Ball ' mingea propriu-zisa
    Public perete As Wall ' peretele nostru format din mai multe caramizi
    Public caramida As Brick ' caramida de care se loveste mingea
    Public vieti As Integer ' cate vieti au mai ramas jucatorului
    Public scor As Integer ' scorul acumulat
    Public paddleMovement As Integer = 25  ' cu cat se poate misca paleta stanga sau dreapta
    Public isGamePaused As Boolean = False ' daca jocul a fost pus pe pauza

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
                    minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius - 2)
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
                    minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius - 2)
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
        paleta = New Paddle(90, 15, Me.ClientSize.Width, Me.ClientSize.Height, Pens.LemonChiffon)
        minge = New Ball(20, Me.ClientSize.Width, Me.ClientSize.Height, Pens.Red)
        perete = New Wall(12, 8, 43, 20, 5, 5)
        vieti = 3

        'minge.SetPosition((Me.ClientSize.Width - minge.radius) \ 2, paleta.y - minge.radius)
        minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius - 2)
        Me.Text = "BrickBuster - " & vieti & " vieti - " & scor & " puncte"
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        caramida = perete.Collision(minge)

        ' Daca ne-am lovit de o caramida
        If IsNothing(caramida) = False Then
            Console.WriteLine("Am detectat caramida {0}", caramida.position)
            perete.SetBrickColor(caramida.position, Pens.YellowGreen)
        End If

        ' Daca cumva atingem partea de jos a ecranului, pierdem o viata
        If minge.stopped = True Then
            vieti -= 1
            Me.Text = "BrickBuster - " & vieti & " vieti - " & scor & " puncte"

            ' Am terminat toate vietile, afisam mesaj si terminam programul
            If vieti <= 0 Then
                Timer1.Stop()
                MsgBox("Draga jucator, ati pierdut toate vietile avute la dispozitie." & vbNewLine & "Mai mult noroc data viitoare", 0, "Final de joc")
                Me.Close()
            End If

            minge.stopped = False
            minge.isMoving = False
            minge.angle = Math.PI / 4

            ' Pozitionam mingea fix centrata pe mijlocul unde se regaseste in acel moment paleta
            minge.SetPosition(paleta.x + paleta.w \ 2 - minge.radius \ 2, paleta.y - minge.radius - 2)
        End If

        ' Daca am pus pauza nu mai miscam mingea
        If minge.isMoving = True And isGamePaused = False Then
            minge.Move()
            minge.Bounce(paleta)
        End If

        paleta.Draw(e)
        minge.Draw(e)
        perete.Draw(e)
    End Sub

    ' Functia prin care reimprospatam pozitia mingii, o data la 10ms (de 100x pe secunda)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Refresh()
    End Sub
End Class