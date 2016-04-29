Public Class Form1
    Public paleta As Paddle ' paleta cu care lovim mingea
    Public minge As Ball ' mingea propriu-zisa
    Public perete As Wall ' peretele nostru format din mai multe caramizi
    Public caramizi As List(Of Brick) ' caramida de care se loveste mingea
    Public paddleMovement As Integer = 35  ' cu cat se poate misca paleta stanga sau dreapta
    Public isGamePaused As Boolean = False ' daca jocul a fost pus pe pauza
    Public mousex As Integer ' pozitia mouse-ului pe X

    Public Function titlu() As String
        Return "BrickBuster - " & perete.vieti & " vieti - " & perete.scor & " puncte"
    End Function

    ' Elibereaza mingea si aceasta incepe sa se miste
    Public Sub SpaceBar()
        ' Daca am pus pauza ignoram tasta
        If isGamePaused = True Then Return

        If minge.isMoving = True Then Return
        minge.isMoving = True

        minge.angle = Math.PI
        minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
        'minge.Move()
        My.Computer.Audio.Play(My.Resources.Peow, AudioPlayMode.Background)
    End Sub

    ' Functie pentru miscarea paletei
    Public Sub MiscarePaleta(x As Integer)
        ' Daca am pus pauza ignoram
        If isGamePaused = True Then Return

        paleta.Move(x, 0)
        If minge.isMoving = False Then
            ' Miscam mingea odata cu paleta, doar daca si paleta se misca
            If paleta.isMoving = True Then
                minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
            End If
        End If
    End Sub

    ' Functie pentru datele introduse de la tastatura
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
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
            SpaceBar()
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
        perete = New Wall(12, 2, 43, 25, 5, 5)
        perete.vieti = 3

        minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
        mousex = -1
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
                My.Computer.Audio.Play(My.Resources.FunnyBoy, AudioPlayMode.Background)
                MsgBox("Draga jucator, ati pierdut toate vietile avute la dispozitie." & vbNewLine & "Mai mult noroc data viitoare", 0, "Final de joc")
                Me.Close()
            End If

            ' Aducem atributele fiecarei componente la valorile normale
            minge.stopped = False
            minge.isMoving = False
            minge.angle = Math.PI / 2.0
            minge.speed_multiplier = 1.0
            minge.multiplier = 1.0
            minge.sticky = False

            perete.PowerUp = Wall.TipuriCaramizi.EMPTY

            paleta.multiplier = 1.0
            paleta.visible = True

            ' Pozitionam mingea fix centrata pe mijlocul unde se regaseste in acel moment paleta
            minge.SetPosition(paleta.x + paleta.w * paleta.multiplier \ 2 - minge.radius * minge.multiplier \ 2, paleta.y - minge.radius * minge.multiplier - 2)
        End If

        paleta.Draw(e)
        minge.Draw(e)
        perete.Draw(e)
    End Sub

    ' Functia prin care reimprospatam pozitia mingii, o data la 10ms (de 100x pe secunda)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If perete.SfarsitJoc() Then
            Timer1.Stop()
            My.Computer.Audio.Play(My.Resources.EndFx, AudioPlayMode.Background)
            MsgBox("Draga jucator, ati terminat jocul cu bine." & vbNewLine & "Ati obtinut " & perete.scor & " puncte", 0, "Felicitari")
            Me.Close()
        End If
        If isGamePaused = True Then Me.Text = titlu() + " - PAUZA" Else Me.Text = titlu()
        Me.Refresh()
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If mousex < 0 Then mousex = e.X

        MiscarePaleta(e.X - mousex)
        mousex = e.X
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Select Case e.Button
            ' click stanga = eliberam mingea
            Case MouseButtons.Left
                SpaceBar()
            ' click dreapta = pauza joc
            Case MouseButtons.Right
                isGamePaused = Not isGamePaused
        End Select
    End Sub

    Private Sub SetariJocToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetariJocToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub IesireToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IesireToolStripMenuItem.Click

    End Sub

    Private Sub TabelaDeOnoareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TabelaDeOnoareToolStripMenuItem.Click

    End Sub

    Private Sub InformatiAutorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformatiAutorToolStripMenuItem.Click

    End Sub
End Class