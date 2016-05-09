Imports System.IO
Public Class Config
    Public filename, text As String
    Public data As List(Of String)
    Public input As StreamReader ' Folosit la citirea din fisier
    Public output As StreamWriter ' Folosit la scriere in fisier

    Public player As String ' Numele jucatorului
    Public soundfx As Boolean ' Daca folosim efecte de sunet
    Public difficulty As String ' Gradul de dificultate - modifica dimensiunea si viteza bilei
    Public easy, medium, hard As Boolean
    Public keyboard, mouse As Boolean ' Daca folosim tastatura si/sau mouse-ul ca input
    Public scoreboard As List(Of String) ' Tabela cu scorurile jucatorilor
    Public difficultySizeMultiplier As Single ' Folosit pt gradul de dificultate - marime
    Public difficultySpeedMultiplier As Single ' Folosit pt gradul de dificultate - viteza

    ' Contructorul pt clasa Config
    Public Sub New(name As String)
        filename = name
        data = New List(Of String)
        scoreboard = New List(Of String)

        ' Daca nu exista fisierul, il cream
        If Not File.Exists(filename) = True Then
            output = New StreamWriter(filename)
            output.Close()
        End If

        ' Incarcam datele din fisier
        If File.Exists(filename) = True Then
            input = New StreamReader(filename)
            Do While input.Peek() <> -1
                text = input.ReadLine()
                data.Add(text)
            Loop
            input.Close()
        Else
            MessageBox.Show("Fisierul " & filename & "nu exista !!!")
        End If

        player = "Player"
        soundfx = False
        difficulty = "Easy"
        easy = True
        medium = False
        hard = False
        keyboard = True
        mouse = True

        ' Procesam datele incarcate si setam variabilele corespunzator
        Process()
    End Sub

    ' Seteaza variabilele pentru dificultate
    Public Sub SetDifficulty(dificultate As String)
        If dificultate.ToLower.Equals("hard") Then
            hard = True
            medium = False
            easy = False
            difficulty = "Hard"
            difficultySizeMultiplier = 0.6
            difficultySpeedMultiplier = 1.6
        ElseIf dificultate.ToLower.Equals("medium") Then
            hard = False
            medium = True
            easy = False
            difficulty = "Medium"
            difficultySizeMultiplier = 0.9
            difficultySpeedMultiplier = 1.2
        Else
            hard = False
            medium = False
            easy = True
            difficulty = "Easy"
            difficultySizeMultiplier = 1.0
            difficultySpeedMultiplier = 1.0
        End If
    End Sub

    ' Proceseaza setarile, linie cu linie
    Public Function Process() As Boolean
        Dim n = data.Count
        Dim s, v As String
        Dim separator() As String = {"="}
        Dim rezultat() As String

        If n <= 0 Then Return True

        For i As Integer = 0 To n - 1
            s = data(i)

            rezultat = s.Split(separator, StringSplitOptions.RemoveEmptyEntries)

            If rezultat.Length = 2 Then
                v = rezultat(1)
                Select Case rezultat(0).ToLower
                    Case "player"
                        player = v
                    Case "soundfx"
                        If v.ToLower.Equals("false") Then
                            soundfx = False
                        Else
                            soundfx = True
                        End If
                    Case "difficulty"
                        SetDifficulty(v)
                    Case "keyboard"
                        If v.ToLower.Equals("false") Then
                            keyboard = False
                        Else
                            keyboard = True
                        End If
                    Case "mouse"
                        If v.ToLower.Equals("false") Then
                            mouse = False
                        Else
                            mouse = True
                        End If
                    Case "score"
                        scoreboard.Add(v)
                End Select
            End If
        Next

        Return True
    End Function

    ' Salveaza setarile programului, impreuna cu tabela de scoruri
    Public Function Save() As Boolean
        output = New StreamWriter(filename)

        output.WriteLine("player={0}", player)
        output.WriteLine("soundfx={0}", soundfx)
        output.WriteLine("difficulty={0}", difficulty)
        output.WriteLine("keyboard={0}", keyboard)
        output.WriteLine("mouse={0}", mouse)
        Dim n = scoreboard.Count
        Dim s As String

        ' Scriem tabela cu scoruri
        If n > 0 Then
            For i As Integer = 0 To n - 1
                s = scoreboard(i)
                output.WriteLine("score={0}", s)
            Next
        End If

        output.Close()

        Return True
    End Function

    ' Adauga un scor la tabela
    Public Sub AddScore(score As Integer)
        Dim s As String
        s = player & "," & score & "," & difficulty
        scoreboard.Add(s)

        ' Salvam scorul nou introdus
        Save()
    End Sub
End Class