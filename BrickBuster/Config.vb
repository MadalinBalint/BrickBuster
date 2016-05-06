Imports System.IO
Public Class Config
    Public filename, text As String
    Public data As List(Of String)
    Public input As StreamReader
    Public output As StreamWriter

    Public player As String
    Public soundfx As Boolean
    Public difficulty As String
    Public easy, medium, hard As Boolean
    Public keyboard, mouse As Boolean
    Public scoreboard As List(Of String)

    Public Sub New(name As String)
        filename = name
        data = New List(Of String)
        scoreboard = New List(Of String)

        ' Daca nu exista fisierul, il cream
        If Not File.Exists(filename) = True Then
            output = New StreamWriter(filename)
            output.Close()
        End If

        If File.Exists(filename) = True Then
            input = New StreamReader(filename)
            Do While input.Peek() <> -1
                text = input.ReadLine()
                data.Add(text)
            Loop
            input.Close()
        Else
            MessageBox.Show("File Does Not Exist")
        End If

        player = "Player"
        soundfx = False
        difficulty = "Easy"
        easy = True
        medium = False
        hard = False
        keyboard = True
        mouse = True

        Load()
    End Sub
    Public Function Load() As Boolean
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
                        If v.ToLower.Equals("hard") Then
                            hard = True
                            medium = False
                            easy = False
                            difficulty = "Hard"
                        ElseIf v.ToLower.Equals("medium") Then
                            hard = False
                            medium = True
                            easy = False
                            difficulty = "Medium"
                        Else
                            hard = False
                            medium = False
                            easy = True
                            difficulty = "Easy"
                        End If
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

    Public Function Save() As Boolean
        'If Not File.Exists(filename) = True Then
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
        'End If

        Return True
    End Function

    Public Sub AddScore(score As Integer)
        Dim s As String
        s = player & "," & score & "," & difficulty
        scoreboard.Add(s)

        Save()
    End Sub
End Class
