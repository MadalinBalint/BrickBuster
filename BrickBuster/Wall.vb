Public Class Wall
    Public scor As Integer = 0 ' scorul acumulat
    Public vieti As Integer ' cate vieti au mai ramas jucatorului
    Public PowerUp As TipuriCaramizi = TipuriCaramizi.EMPTY

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
    '12 - distruge toate caramizile pe orizontala
    '13 - distruge toate caramizile pe verticala
    Public Enum TipuriCaramizi As Integer
        NORMAL
        EMPTY
        TRIPLE
        INFINITE
        LIFE
        SMALL_BALL
        BIG_BALL
        SMALL_PADDLE
        BIG_PADDLE
        SLOW_BALL
        FAST_BALL
    End Enum

    Private Function random(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        Return staticRandomGenerator.Next(Min, Max + 1)
    End Function

    Public HP() As Integer = {1, 0, 3, Integer.MaxValue, 1, 1, 1, 1, 1}
    Public Points() As Integer = {100, 0, 150, 10, 500, 400, 300, 700, 600}
    Public Colors() As Pen = {Pens.LightGray, Pens.White, Pens.CadetBlue, Pens.Black, Pens.Red, Pens.Aqua, Pens.Azure, Pens.PaleVioletRed, Pens.PapayaWhip}
    Public Percentage() As Integer = {50, 2, 9, 2, 2, 1, 1, 1, 1}

    Public col, row As Integer
    Public matrixPozitie(,) As Brick  ' pozitia fiecarei caramizi pe ecran
    Public matrixType(,) As Integer  ' tipul fiecarei caramizi
    Public matrixHP(,) As Integer  ' de cate ori trebuie lovita fiecare caramida ca sa fie distrusa
    Public matrixMiddle(,) As PointF  ' mijlocul fiecarei caramizi, utilizat in detectia coliziunii

    ' Dimensiunea unei caramizi
    Public brickw, brickh As Integer
    ' Spatiile pe orizontala si pe verticala intre caramizi
    Public spaceh, spacev As Integer

    Public Sub New(x As Integer, y As Integer, bw As Integer, bh As Integer, sh As Integer, sv As Integer)
        Dim xx, yy As Integer
        col = x
        row = y
        ReDim matrixPozitie(col, row)
        ReDim matrixType(col, row)
        ReDim matrixHP(col, row)
        ReDim matrixMiddle(col, row)

        brickw = bw
        brickh = bh
        spaceh = sh
        spacev = sv

        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                xx = spaceh * (i + 1) + brickw * i
                yy = spacev * (j + 1) + brickh * j
                matrixType(i, j) = TipuriCaramizi.NORMAL
                matrixHP(i, j) = HP(matrixType(i, j))
                matrixPozitie(i, j) = New Brick(xx, yy, brickw, brickh, Colors(matrixType(i, j)), j * col + i)
                matrixMiddle(i, j) = New PointF(xx + brickw / 2, yy + brickh / 2)
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
                Do While matrixType(ecol, erow) > TipuriCaramizi.NORMAL
                    rnd = random(0, total - 1)
                    erow = rnd \ col
                    ecol = rnd Mod col
                Loop

                ' Setam proprietatile caramizilor speciale
                matrixType(ecol, erow) = i
                matrixHP(ecol, erow) = HP(i)
                matrixPozitie(ecol, erow).SetColor(Colors(i))
                matrixPozitie(ecol, erow).SetType(i)
            Next
        Next
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                If matrixHP(i, j) > 0 Then matrixPozitie(i, j).Draw(e)
            Next
        Next
    End Sub

    Public Function Intersection(minge As Ball, caramida As Brick, rectangleCenter As PointF) As Boolean
        Dim w As Single = caramida.w / 2
        Dim h As Single = caramida.h / 2

        Dim dx As Single = Math.Abs(minge.mxx - rectangleCenter.X)
        Dim dy As Single = Math.Abs(minge.myy - rectangleCenter.Y)
        Dim radius As Single = minge.r * minge.multiplier

        If (dx > (radius + w)) Or (dy > (radius + h)) Then Return False
        Dim circleDistance As PointF = New PointF(Math.Abs(minge.mxx - caramida.x - w), Math.Abs(minge.myy - caramida.y - h))

        If circleDistance.X <= w Then Return True
        If circleDistance.Y <= h Then Return True

        Dim cornerDistanceSq As Single = Math.Pow(circleDistance.X - w, 2) + Math.Pow(circleDistance.Y - h, 2)

        Return (cornerDistanceSq <= (Math.Pow(radius, 2)))
    End Function

    ' Determina cu ce caramida se intersecteaza mingea in pozitia ei actuala
    ' Returneaza caramida cu care se intersecteaza, altfel NULL
    Public Function Collision(minge As Ball) As List(Of Brick)
        Dim caramida As Brick
        Dim mijloc As PointF
        Dim lista = New List(Of Brick)

        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                ' Daca mai exista caramida (HP > 0) atunci o luam in considerare
                If matrixHP(i, j) > 0 Then
                    caramida = matrixPozitie(i, j)
                    mijloc = matrixMiddle(i, j)

                    ' Daca ne intersectam cu o caramida o returnam
                    If Intersection(minge, caramida, mijloc) = True Then lista.Add(caramida)
                End If
            Next
        Next

        Return lista
    End Function

    Public Sub SetBrickColor(position As Integer, color As Pen)
        Dim j = position \ col
        Dim i = position Mod col
        matrixPozitie(i, j).SetColor(color)
    End Sub

    Public Sub HitBrick(position As Integer, hp As Integer)
        Dim j = position \ col
        Dim i = position Mod col

        If matrixHP(i, j) > 0 Then
            matrixHP(i, j) -= hp

            ' Pt fiecare HP distrus dam punctajul specific
            scor += Points(matrixType(i, j))

            If matrixType(i, j) = TipuriCaramizi.LIFE Then vieti += 1
            If matrixType(i, j) >= TipuriCaramizi.SMALL_BALL Then PowerUp = matrixType(i, j)

            Select Case PowerUp
                Case TipuriCaramizi.SMALL_BALL
                    Form1.minge.multiplier = 0.75
                Case TipuriCaramizi.BIG_BALL
                    Form1.minge.multiplier = 1.5
                Case TipuriCaramizi.BIG_PADDLE
                    Form1.paleta.multiplier = 2
                Case TipuriCaramizi.SMALL_PADDLE
                    Form1.paleta.multiplier = 0.5
            End Select

            If matrixHP(i, j) < 0 Then matrixHP(i, j) = 0
        End If
    End Sub

    ' Determinam daca e sfarsitul jocului/nivelului
    Public Function SfarsitJoc() As Boolean
        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                ' Daca mai exista caramida (HP > 0) atunci o luam in considerare
                If matrixHP(i, j) > 0 And matrixType(i, j) <> TipuriCaramizi.INFINITE Then Return False
            Next
        Next

        Return True
    End Function
End Class