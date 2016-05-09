Public Class Wall
    Public PowerUp As TipuriCaramizi = TipuriCaramizi.EMPTY ' Ce powerup este activ cand se distruge o caramida

    ' Variatia tipurilor de caramizi
    ' 50% = caramizi normale
    ' 50% = restul de caramizi, din care:
    '     - 2% - caramizi lipsa
    '     - 9% - caramizi cu HP=3
    '     - 2% - caramizi cu HP infinit
    '     - 2% - viata
    '     - 1% - minge mica
    '     - 1% - minge mare
    '     - 1% - paleta mica
    '     - 1% - paleta mare

    ' Tipuri de caramizi (de la 4 incolo avem POWERUP-uri)
    ' 0 - caramida obisnuita - HP=1
    ' 1 - nu exista (gol)
    ' 2 - caramida cu HP=3
    ' 3 - caramida cu HP=infinit
    ' 4 - viata
    ' 5 - minge mica 0.75x
    ' 6 - minge mare 1.50x
    ' 7 - paleta mica 0.50x
    ' 8 - paleta mare 2.00x
    ' 9 - minge inceata 0.50x
    '10 - minge rapida 1.50x
    '11 - mingea se lipeste de paleta
    '12 - distruge paleta
    Public Enum TipuriCaramizi As Integer
        NORMAL
        EMPTY ' 0 puncte
        TRIPLE
        INFINITE ' 0 puncte
        LIFE
        SMALL_BALL
        BIG_BALL
        SMALL_PADDLE
        BIG_PADDLE
        SLOW_BALL
        FAST_BALL
        STICKY_BALL ' anulat de PADDLE_DESTROYER
        PADDLE_DESTROYER
    End Enum

    ' Functie pentru generarea de numere aleatorii
    Private Function random(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        Return staticRandomGenerator.Next(Min, Max + 1)
    End Function

    Public HP() As Integer = {1, 0, 3, Integer.MaxValue, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    Public Points() As Integer = {100, 0, 150, 0, 500, 400, 300, 700, 600, 200, 200, 500, 500}
    Public Colors() As Pen = {Pens.LightGray, Pens.White, Pens.CadetBlue, Pens.Black, Pens.Red, Pens.Aqua, Pens.Azure, Pens.PaleVioletRed, Pens.PapayaWhip,
                              Pens.Crimson, Pens.Cornsilk, Pens.Chocolate, Pens.BurlyWood}
    Public Percentage() As Integer = {50, 2, 5, 1, 2, 1, 1, 1, 1, 2, 2, 1, 1}

    Public col, row As Integer ' Nr de coloane si de randuri ale peretelui format din caramizi
    Public matrixScreenPosition(,) As Brick  ' pozitia fiecarei caramizi pe ecran
    Public matrixBrickType(,) As Integer  ' tipul fiecarei caramizi
    Public matrixHitPoints(,) As Integer  ' de cate ori trebuie lovita fiecare caramida ca sa fie distrusa
    Public matrixCenter(,) As PointF  ' mijlocul fiecarei caramizi, utilizat in detectia coliziunii

    Public brickWidth, brickHeight As Integer ' Dimensiunea unei caramizi
    Public horizSpace, vertSpace As Integer ' Spatiile pe orizontala si pe verticala intre caramizi
    Public menuSpace As Integer = 20 ' Spatiul ocupat de meniul programului

    ' Constructorul pt clasa Wall
    Public Sub New(x As Integer, y As Integer, bw As Integer, bh As Integer, sh As Integer, sv As Integer)
        Dim xx, yy As Integer
        col = x
        row = y
        ReDim matrixScreenPosition(col, row)
        ReDim matrixBrickType(col, row)
        ReDim matrixHitPoints(col, row)
        ReDim matrixCenter(col, row)

        brickWidth = bw
        brickHeight = bh
        horizSpace = sh
        vertSpace = sv

        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                xx = horizSpace * (i + 1) + brickWidth * i
                yy = vertSpace * (j + 1) + brickHeight * j + menuSpace
                matrixBrickType(i, j) = TipuriCaramizi.NORMAL
                matrixHitPoints(i, j) = HP(matrixBrickType(i, j))
                matrixScreenPosition(i, j) = New Brick(xx, yy, brickWidth, brickHeight, Colors(matrixBrickType(i, j)), j * col + i)
                matrixCenter(i, j) = New PointF(xx + brickWidth / 2, yy + brickHeight / 2)
            Next
        Next

        ' Setam in mod aleatoriu caramizile speciale
        Dim total = row * col
        Dim nr, rnd As Integer
        Dim erow, ecol As Integer

        ' i = tipul caramizii speciale
        For i As Integer = 1 To Percentage.Length - 1
            nr = Percentage(i) * total / 100
            nr += 1
            For j As Integer = 0 To nr - 1
                rnd = random(0, total - 1)
                erow = rnd \ col
                ecol = rnd Mod col

                ' Evitam sa setam din nou o caramida speciala
                Do While matrixBrickType(ecol, erow) > TipuriCaramizi.NORMAL
                    rnd = random(0, total - 1)
                    erow = rnd \ col
                    ecol = rnd Mod col
                Loop

                ' Setam proprietatile caramizilor speciale
                matrixBrickType(ecol, erow) = i
                matrixHitPoints(ecol, erow) = HP(i)
                matrixScreenPosition(ecol, erow).SetColor(Colors(i))
                matrixScreenPosition(ecol, erow).SetType(i)
            Next
        Next
    End Sub

    ' Deseneaza caramizile pe ecran
    Public Sub Draw(e As PaintEventArgs)
        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                If matrixHitPoints(i, j) > 0 Then matrixScreenPosition(i, j).Draw(e)
            Next
        Next
    End Sub

    ' Verifica coliziunea mingii cu o caramida
    Public Function Intersection(minge As Ball, caramida As Brick, rectangleCenter As PointF) As Boolean
        Dim w As Single = caramida.w / 2
        Dim h As Single = caramida.h / 2

        Dim dx As Single = Math.Abs(minge.centerX - rectangleCenter.X)
        Dim dy As Single = Math.Abs(minge.centerY - rectangleCenter.Y)
        Dim radius As Single = minge.r * minge.sizeMultiplier

        If (dx > (radius + w)) Or (dy > (radius + h)) Then Return False
        Dim circleDistance As PointF = New PointF(Math.Abs(minge.centerX - caramida.x - w), Math.Abs(minge.centerY - caramida.y - h))

        If circleDistance.X <= w Then Return True
        If circleDistance.Y <= h Then Return True

        Dim cornerDistanceSq As Single = Math.Pow(circleDistance.X - w, 2) + Math.Pow(circleDistance.Y - h, 2)

        Return (cornerDistanceSq <= (Math.Pow(radius, 2)))
    End Function

    ' Determina cu ce caramida se intersecteaza mingea in pozitia ei actuala
    ' Returneaza o lista cu caramizile cu care se intersecteaza
    Public Function Collision(minge As Ball) As List(Of Brick)
        Dim caramida As Brick
        Dim mijloc As PointF
        Dim lista = New List(Of Brick)

        For j As Integer = row - 1 To 0 Step -1
            For i As Integer = 0 To col - 1
                ' Daca mai exista caramida (HP > 0) atunci o luam in considerare
                If matrixHitPoints(i, j) > 0 Then
                    caramida = matrixScreenPosition(i, j)
                    mijloc = matrixCenter(i, j)

                    ' Daca ne intersectam cu o caramida o returnam
                    If Intersection(minge, caramida, mijloc) = True Then lista.Add(caramida)
                End If
            Next
        Next

        Return lista
    End Function

    ' Seteaza culoarea caramizii
    Public Sub SetBrickColor(position As Integer, color As Pen)
        Dim j = position \ col
        Dim i = position Mod col
        matrixScreenPosition(i, j).SetColor(color)
    End Sub

    ' Marcheaza caramida ca fiind lovita si aplica powerup-urile necesare, de la caz la caz
    Public Sub HitBrick(position As Integer, hp As Integer)
        Dim j = position \ col
        Dim i = position Mod col

        If matrixHitPoints(i, j) > 0 Then
            matrixHitPoints(i, j) -= hp

            ' Pt fiecare HP distrus dam punctajul specific
            Form1.scor += Points(matrixBrickType(i, j))

            If matrixBrickType(i, j) = TipuriCaramizi.INFINITE Then
                If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Tank, AudioPlayMode.Background)
            ElseIf matrixBrickType(i, j) >= TipuriCaramizi.LIFE Then
                If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Orchestr, AudioPlayMode.Background)
            Else
                If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Glass, AudioPlayMode.Background)
            End If

            If matrixBrickType(i, j) = TipuriCaramizi.LIFE Then Form1.vieti += 1
            If matrixBrickType(i, j) >= TipuriCaramizi.SMALL_BALL Then PowerUp = matrixBrickType(i, j)

            Select Case PowerUp
                Case TipuriCaramizi.SMALL_BALL
                    Form1.minge.sizeMultiplier = 0.75
                Case TipuriCaramizi.BIG_BALL
                    Form1.minge.sizeMultiplier = 1.5
                Case TipuriCaramizi.BIG_PADDLE
                    Form1.paleta.sizeMultiplier = 2
                Case TipuriCaramizi.SMALL_PADDLE
                    Form1.paleta.sizeMultiplier = 0.5
                Case TipuriCaramizi.FAST_BALL
                    Form1.minge.speedMultiplier = 1.5
                Case TipuriCaramizi.SLOW_BALL
                    Form1.minge.speedMultiplier = 0.5
                Case TipuriCaramizi.STICKY_BALL
                    Form1.minge.isSticky = True
                Case TipuriCaramizi.PADDLE_DESTROYER
                    Form1.minge.isSticky = False
                    Form1.paleta.isVisible = False
            End Select

            If matrixHitPoints(i, j) < 0 Then matrixHitPoints(i, j) = 0
        End If
    End Sub

    ' Determina daca este sfarsitul jocului
    Public Function SfarsitJoc() As Boolean
        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                ' Daca mai exista caramida (HP > 0) atunci o luam in considerare
                If matrixHitPoints(i, j) > 0 And matrixBrickType(i, j) <> TipuriCaramizi.INFINITE Then Return False
            Next
        Next

        Return True
    End Function
End Class