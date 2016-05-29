Public Class Form1
    Public settings As Config ' setarile jocului
    Public scor As Integer ' scorul acumulat
    Public vieti As Integer ' cate vieti au mai ramas jucatorului
    Public paleta As Paddle ' paleta cu care lovim mingea
    Public minge As Ball ' mingea propriu-zisa
    Public perete As Wall ' peretele nostru format din mai multe caramizi
    Public caramizi As List(Of Brick) ' caramida de care se loveste mingea
    Public paddleMovement As Integer = 35  ' cu cat se poate misca paleta stanga sau dreapta
    Public isGamePaused As Boolean = False ' daca jocul a fost pus pe pauza
    Public isGameStarted As Boolean = False ' daca jocul a inceput
    Public isMouse As Boolean = True ' daca folosim mouse-ul pt input
    Public isKeyboard As Boolean = True ' daca folosim tastatura pt input
    Public mouseX As Integer ' pozitia mouse-ului pe X

    ' Textul care se afiseaza in titlul ferestrei: dificultate, vieti, puncte
    Public Function gameTitle() As String
        If isGameStarted = False Then Return "BrickBuster"
        Dim s = "BrickBuster - " & settings.difficulty & " - " & vieti & " vieti - " & scor & " puncte"
        If isGamePaused Then Return s & " - PAUZA" Else Return s
    End Function

    ' Elibereaza mingea si aceasta incepe sa se miste
    Public Sub throwBall()
        ' Daca am pus pauza ignoram tasta
        If isGamePaused = True Then Return

        If minge.isMoving = True Then Return
        minge.isMoving = True

        minge.angle = Math.PI / 1.1
        minge.SetPosition(paleta.x + paleta.w * paleta.sizeMultiplier \ 2 - minge.radius * minge.sizeMultiplier \ 2, paleta.y - minge.radius * minge.sizeMultiplier - 2)

        If settings.soundfx Then My.Computer.Audio.Play(My.Resources.Peow, AudioPlayMode.Background)
    End Sub

    ' Functie pentru miscarea paletei
    Public Sub MiscarePaleta(x As Integer)
        ' Daca am pus pauza ignoram
        If isGamePaused = True Then Return

        paleta.Move(x, 0)
        If minge.isMoving = False Then
            ' Miscam mingea odata cu paleta, doar daca si paleta se misca
            If paleta.isMoving = True Then
                minge.SetPosition(paleta.x + paleta.w * paleta.sizeMultiplier \ 2 - minge.radius * minge.sizeMultiplier \ 2, paleta.y - minge.radius * minge.sizeMultiplier - 2)
            End If
        End If
    End Sub

    ' Functie pentru datele introduse de la tastatura
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If Not settings.keyboard Then Return False
        ' Tasta stanga
        If keyData = Keys.Left Then
            MiscarePaleta(-paddleMovement)
            Return True
        End If

        ' Tasta dreapta
        If keyData = Keys.Right Then
            MiscarePaleta(paddleMovement)
            Return True
        End If

        ' Tasta Spacebar = elibereaza mingea si aceasta incepe sa se miste
        If keyData = Keys.Space Then
            throwBall()
            Return True
        End If

        ' Tasta P = pauza
        If keyData = Keys.P Then
            isGamePaused = Not isGamePaused
            Return True
        End If

        Return False
    End Function

    ' Determina un joc nou
    Public Sub NewGame()
        perete = New Wall(12, 8, 50, 30, 5, 5)
        Me.ClientSize = New Size(perete.brickWidth * perete.col + perete.horizSpace * (perete.col + 1), perete.brickHeight * (perete.row + 12))

        paleta = New Paddle(80, 15, Me.ClientSize.Width, Me.ClientSize.Height, Pens.LemonChiffon)
        minge = New Ball(25, Me.ClientSize.Width, Me.ClientSize.Height, Pens.Red)

        vieti = 3
        scor = 0

        minge.SetPosition(paleta.x + paleta.w * paleta.sizeMultiplier \ 2 - minge.radius * minge.sizeMultiplier \ 2, paleta.y - minge.radius * minge.sizeMultiplier - 2)
        mouseX = -1
        Me.Text = gameTitle()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        settings = New Config("brickbuster.txt")
        ballTimer.Stop()
    End Sub

    ' Functie pentru desenarea obiectelor pe ecran
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If isGameStarted = False Then Return

        caramizi = perete.Collision(minge)

        ' Daca am pus pauza nu mai miscam mingea
        If minge.isMoving = True And isGamePaused = False Then
            ' Tinem cont de pozitia paletei si de caramizile existente
            minge.Move()
            minge.Bounce(paleta, caramizi, perete)
        End If

        ' Daca cumva atingem partea de jos a ecranului, pierdem o viata
        If minge.isStopped = True Then
            vieti -= 1

            ' Am terminat toate vietile, afisam mesaj si terminam programul
            If vieti <= 0 Then
                ballTimer.Stop()
                If settings.soundfx Then My.Computer.Audio.Play(My.Resources.FunnyBoy, AudioPlayMode.Background)
                MsgBox("Draga jucator, ati pierdut toate vietile avute la dispozitie." & vbNewLine & "Mai mult noroc data viitoare", 0, "Final de joc")

                ' Adaugam automat scorul in tabela cu scoruri, daca este > 0
                If scor > 0 Then settings.AddScore(scor)
                ballTimer.Stop()
                isGameStarted = False

                miNewGame.Enabled = True
                miResetGame.Enabled = False
                miEndGame.Enabled = False

                ' Setam titlul si dam Refresh
                Me.Text = gameTitle()
                Me.Refresh()
                Return
            End If

            ' Aducem atributele fiecarei componente la valorile normale
            minge.isStopped = False
            minge.isMoving = False
            minge.angle = Math.PI / 6.0
            minge.speedMultiplier = 1.0
            minge.sizeMultiplier = 1.0
            minge.isSticky = False

            perete.PowerUp = Wall.TipuriCaramizi.EMPTY

            paleta.sizeMultiplier = 1.0
            paleta.isVisible = True

            ' Pozitionam mingea fix centrata pe mijlocul unde se regaseste in acel moment paleta
            minge.SetPosition(paleta.x + paleta.w * paleta.sizeMultiplier \ 2 - minge.radius * minge.sizeMultiplier \ 2, paleta.y - minge.radius * minge.sizeMultiplier - 2)
        End If

        paleta.Draw(e)
        minge.Draw(e)
        perete.Draw(e)
    End Sub

    ' Functia prin care reimprospatam pozitia mingii, o data la 10ms (de 100x pe secunda)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles ballTimer.Tick
        If isGameStarted = False Then Return

        If perete.SfarsitJoc() Then
            ballTimer.Stop()
            If settings.soundfx Then My.Computer.Audio.Play(My.Resources.EndFx, AudioPlayMode.Background)
            MsgBox("Draga jucator, ati terminat jocul cu bine." & vbNewLine & "Ati obtinut " & scor & " puncte", 0, "Felicitari")
            settings.AddScore(scor)
            isGameStarted = False
        End If

        Me.Text = gameTitle()
        Me.Refresh()
    End Sub

    ' Functie pentru miscarea mouse-ului
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If isGameStarted = False Then Return
        If Not settings.mouse Then Return

        If mouseX < 0 Then mouseX = e.X

        MiscarePaleta(e.X - mouseX)
        mouseX = e.X
    End Sub

    ' Functie pentru click mouse
    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        If isGameStarted = False Then Return
        If Not settings.mouse Then Return

        Select Case e.Button
            ' click stanga = eliberam mingea
            Case MouseButtons.Left
                throwBall()
            ' click dreapta = pauza joc
            Case MouseButtons.Right
                isGamePaused = Not isGamePaused
        End Select
    End Sub

    ' Meniul New Game
    Private Sub miNewGame_Click(sender As Object, e As EventArgs) Handles miNewGame.Click
        isGameStarted = True
        miNewGame.Enabled = False
        miResetGame.Enabled = True
        miEndGame.Enabled = True

        NewGame()
        ballTimer.Start()
    End Sub

    ' Meniul End Game
    Private Sub miEndGame_Click(sender As Object, e As EventArgs) Handles miEndGame.Click
        If isGameStarted = True Then
            If MsgBox("Doriti sa oprim jocul ?" & vbNewLine & "Veti pierde toate punctele acumulate pana acum.", MsgBoxStyle.YesNo, "Atentie") = MsgBoxResult.Yes Then
                ballTimer.Stop()
                isGameStarted = False

                miNewGame.Enabled = True
                miResetGame.Enabled = False
                miEndGame.Enabled = False

                Me.Text = gameTitle()
                Me.Refresh()
            End If
        End If
    End Sub

    ' Meniul Reset Game
    Private Sub miResetGame_Click(sender As Object, e As EventArgs) Handles miResetGame.Click
        If isGameStarted = True Then
            If MsgBox("Doriti sa reluam jocul de la inceput ?" & vbNewLine & "Veti pierde toate punctele acumulate pana acum.", MsgBoxStyle.YesNo, "Atentie") = MsgBoxResult.Yes Then
                ballTimer.Stop()
                NewGame()
                ballTimer.Start()
            End If
        End If
    End Sub

    ' Meniul Scoreboard
    Private Sub miScoreBoard_Click(sender As Object, e As EventArgs) Handles miScoreBoard.Click
        If isGameStarted = True Then
            isGamePaused = True
        End If

        Form2.ShowDialog()
    End Sub

    ' Meniul Options
    Private Sub miOptions_Click(sender As Object, e As EventArgs) Handles miOptions.Click
        If isGameStarted = True Then
            isGamePaused = True
        End If

        Form3.ShowDialog()
    End Sub

    ' Meniul Exit
    Private Sub miExit_Click(sender As Object, e As EventArgs) Handles miExit.Click
        If isGameStarted = True Then
            If MsgBox("Jocul tocmai a inceput !!!" & vbNewLine & "Doriti sa iesiti din joc ?", MsgBoxStyle.YesNo, "Atentie") = MsgBoxResult.Ok Then
                ballTimer.Stop()
                Me.Close()
            End If
        End If

        Me.Close()
    End Sub

    ' Meniul About
    Private Sub miAbout_Click(sender As Object, e As EventArgs) Handles miAbout.Click
        MsgBox("Balint Madalin" & vbNewLine & "Grupa 3121A", 0, "Informatii autor")
    End Sub

    Private Sub Form1_MouseLeave(sender As Object, e As EventArgs) 'Handles MyBase.MouseLeave
        If isGameStarted = False Then Return
        If Not settings.mouse Then Return

        If mouseX < minge.clientWidth \ 2 Then
            paleta.x = 0
        Else
            paleta.x = paleta.clientWidth - paleta.w * paleta.sizeMultiplier
        End If

        If minge.isMoving = False Then
            ' Miscam mingea odata cu paleta, doar daca si paleta se misca
            If paleta.isMoving = True Then
                'minge.SetPosition(paleta.x + paleta.w * paleta.sizeMultiplier \ 2 - minge.radius * minge.sizeMultiplier \ 2, paleta.y - minge.radius * minge.sizeMultiplier - 2)
            End If
        End If
    End Sub
End Class