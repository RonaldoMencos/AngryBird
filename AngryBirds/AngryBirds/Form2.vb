Imports System.Math
Public Class Form2
    'Oscar Ronaldo Mencos Chamalé
    Dim CoordX As Double
    Dim CoordY As Double
    Dim velocidad As Double = 0
    Dim angulo As Double
    Dim tiempo As Double = 0
    Dim gravedad As Double = 9.8
    Dim mover As Boolean = False
    Dim mousePosX As Integer
    Dim mousePosY As Integer
    Dim X As Integer = 65
    Dim Y As Integer = 250
    Dim picturebox1 As New PictureBox
    Dim Timer1 As New Timer
    Dim Timer2 As New Timer
    Dim angulo1 As Double
    Dim contador As Integer = 1
    Dim con As Integer
    Dim conta As Integer
    Dim puntaje As Integer

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        tiempo += 0.1
        CoordX = velocidad * tiempo * Cos(angulo)
        CoordY = (velocidad * tiempo * Sin(angulo)) - ((gravedad / 2) * tiempo * tiempo)
        picturebox1.Invalidate()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim deltaY As Integer = 80 - mousePosY
        Dim deltaX As Integer = mousePosX - 80
        Dim convertir As Single
        convertir = Math.Atan2(deltaY, deltaX) * 180 / Math.PI
        If Not convertir >= 0 Then
            convertir += 360
        End If
        angulo1 = convertir

    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If Timer1.Enabled = True Then
            mover = False
        Else

            CoordX = 0
            CoordY = 0
            tiempo = 0
            velocidad = 0
            X = mousePosX - 15
            Y = mousePosY - 15
            mover = True
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If Timer1.Enabled = False Then
            mover = False
            X = mousePosX - 15
            Y = mousePosY - 15
            Timer1.Interval = 10
            ObtenerAngulo()
            Timer1.Start()


        End If

    End Sub
    Public Sub ObtenerAngulo()

        Dim deltaY As Integer = 250 - mousePosY
        Dim deltaX As Integer = mousePosX - 86
        Dim convertir As Single
        convertir = Math.Atan2(deltaY, deltaX) * 180 / Math.PI

        If Not convertir >= 0 Then
            convertir += 360
        End If

        If convertir + 180 > 360 Then
            convertir += 180
        Else
            convertir -= 180
        End If

        convertir = convertir * PI / 180
        angulo = convertir
    End Sub
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If mover = True Then
            mousePosX = e.X
            mousePosY = e.Y
            picturebox1.Invalidate()


        End If
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If contador = 2 Or contador = 3 Then
            con += 1

            If contador = 2 Or contador = 3 And con > 0 Then
            tiempo += 1.0
        End If
        End If
        If contador = 4 Or contador = 5 Or contador = 6 Then
            conta += 1
        End If



    End Sub
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim point1 As New Point(mousePosX - 15, mousePosY - 15)
        Dim point2 As New Point(118, mousePosY - -15)
        Dim point3 As New Point(12, mousePosY - 15)
        Dim point4 As New Point(X + CoordX, Y - CoordY)
        Dim point5 As New Point(80, 250)
        Dim point6 As New Point(X + CoordX + 5, Y - CoordY + 40)
        Dim point7 As New Point(X + CoordX + 5, Y - CoordY - 40)


        If PictureBox13.Visible = False And PictureBox14.Visible = False And PictureBox15.Visible = False Then
            Label2.Visible = True

            My.Computer.Audio.Play(My.Resources.La_musica_de_Los_minions_papaya_remix__i___mp3cut_net_, AudioPlayMode.Background)
        Else
            If contador < 10 Then

                If contador = 1 Then



                    If mover = True Then

                        PictureBox18.Visible = True

                        If mousePosX - 8 < 120 And mousePosX - 8 > 10 Then

                            PictureBox18.Location = point1

                        Else
                            If mousePosX - 8 > 120 Then
                                PictureBox18.Location = point2
                                mousePosX = 118
                            Else
                                PictureBox18.Location = point3
                                mousePosX = 12
                            End If
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim velocix As Integer
                        Dim velociy As Integer
                        If mousePosX > 80 Then
                            velocix = mousePosX - 70
                        Else
                            velocix = 70 - mousePosX
                        End If
                        If mousePosY > 250 Then
                            velociy = mousePosY - 240
                        Else
                            velociy = 240 - mousePosY
                        End If
                        If velociy > velocix Then
                            velocidad = velociy
                        Else
                            velocidad = velocix
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else

                        If PictureBox18.Bounds.IntersectsWith(PictureBox13.Bounds) Then
                            PictureBox13.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox18.Bounds.IntersectsWith(PictureBox15.Bounds) Then
                            PictureBox15.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox18.Bounds.IntersectsWith(PictureBox14.Bounds) Then
                            PictureBox14.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        PictureBox18.Location = point4

                        If Y - CoordY > 315 Then

                            Timer1.Stop()
                            tiempo = 0
                            X = X + CoordX
                            Y = Y - CoordY
                            velocidad -= 35

                            If velocidad < 1 Then

                                Timer1.Stop()
                                velocidad = 0
                                PictureBox18.Location = point5
                                contador = contador + 1
                                PictureBox18.Visible = False
                            Else

                                Timer1.Start()
                            End If
                        End If

                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf contador = 2 Or contador = 3 Then

                    If mover = True Then

                        PictureBox19.Visible = True

                        If mousePosX - 8 < 120 And mousePosX - 8 > 10 Then

                            PictureBox19.Location = point1


                        Else
                            If mousePosX - 8 > 120 Then
                                PictureBox19.Location = point2
                                mousePosX = 118
                            Else
                                PictureBox19.Location = point3
                                mousePosX = 12
                            End If
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim velocix As Integer
                        Dim velociy As Integer
                        If mousePosX > 80 Then
                            velocix = mousePosX - 70
                        Else
                            velocix = 70 - mousePosX
                        End If
                        If mousePosY > 250 Then
                            velociy = mousePosY - 240
                        Else
                            velociy = 240 - mousePosY
                        End If
                        If velociy > velocix Then
                            velocidad = velociy
                        Else
                            velocidad = velocix
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        If PictureBox19.Bounds.IntersectsWith(PictureBox13.Bounds) Then
                            PictureBox13.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox19.Bounds.IntersectsWith(PictureBox15.Bounds) Then
                            PictureBox15.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox19.Bounds.IntersectsWith(PictureBox14.Bounds) Then
                            PictureBox14.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        End If
                        PictureBox19.Location = point4

                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Y - CoordY > 315 Then

                        Timer1.Stop()
                        tiempo = 0
                        X = X + CoordX
                        Y = Y - CoordY
                        velocidad -= 35
                        contador = contador + 1
                        If velocidad < 1 Then

                            Timer1.Stop()
                            velocidad = 0

                            PictureBox19.Location = point5
                            PictureBox19.Visible = False
                        Else

                            Timer1.Start()
                        End If
                    End If






                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf contador = 4 Or contador = 5 Or contador = 6 Then


                    If mover = True Then

                        PictureBox20.Visible = True

                        If mousePosX - 8 < 120 And mousePosX - 8 > 10 Then
                            PictureBox20.Location = point1

                        Else
                            If mousePosX - 8 > 120 Then
                                PictureBox20.Location = point2
                                mousePosX = 118

                            Else
                                PictureBox20.Location = point3
                                mousePosX = 12

                            End If
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim velocix As Integer
                        Dim velociy As Integer
                        If mousePosX > 80 Then
                            velocix = mousePosX - 70
                        Else
                            velocix = 70 - mousePosX
                        End If
                        If mousePosY > 250 Then
                            velociy = mousePosY - 240
                        Else
                            velociy = 240 - mousePosY
                        End If
                        If velociy > velocix Then
                            velocidad = velociy
                        Else
                            velocidad = velocix
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ElseIf conta >= 2 Then
                        PictureBox6.Visible = True
                        PictureBox7.Visible = True
                        If PictureBox20.Bounds.IntersectsWith(PictureBox13.Bounds) Then
                            PictureBox13.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox20.Bounds.IntersectsWith(PictureBox15.Bounds) Then
                            PictureBox15.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox20.Bounds.IntersectsWith(PictureBox14.Bounds) Then
                            PictureBox14.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        End If
                        PictureBox20.Location = point4
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If PictureBox7.Bounds.IntersectsWith(PictureBox13.Bounds) Then
                            PictureBox13.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox7.Bounds.IntersectsWith(PictureBox15.Bounds) Then
                            PictureBox15.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox7.Bounds.IntersectsWith(PictureBox14.Bounds) Then
                            PictureBox14.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        End If
                        PictureBox7.Location = point7
                        '''''''''''''''''''''''''''''''''''''''''
                        If PictureBox6.Bounds.IntersectsWith(PictureBox13.Bounds) Then
                            PictureBox13.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox6.Bounds.IntersectsWith(PictureBox15.Bounds) Then
                            PictureBox15.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox6.Bounds.IntersectsWith(PictureBox14.Bounds) Then
                            PictureBox14.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        End If

                        PictureBox6.Location = point6


                    Else
                        If PictureBox20.Bounds.IntersectsWith(PictureBox13.Bounds) Then
                            PictureBox13.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox20.Bounds.IntersectsWith(PictureBox15.Bounds) Then
                            PictureBox15.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        ElseIf PictureBox20.Bounds.IntersectsWith(PictureBox14.Bounds) Then
                            PictureBox14.Visible = False
                            puntaje = puntaje + 100
                            TextBox3.Text = puntaje
                        End If
                        PictureBox20.Location = point4



                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If Y - CoordY > 315 Then
                        Timer1.Stop()
                        tiempo = 0
                        X = X + CoordX
                        Y = Y - CoordY

                        velocidad -= 35
                        If velocidad < 1 Then
                            Timer1.Stop()
                            velocidad = 0
                            contador = contador + 1
                            PictureBox20.Location = point5
                            PictureBox20.Visible = False


                        Else
                            Timer1.Start()
                        End If
                    End If



                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf contador > 6 Then
                    Label3.Visible = True

                    My.Computer.Audio.Play(My.Resources.level_failed, AudioPlayMode.Background)
                    contador = contador + 1

                End If
            End If
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox3.Enabled = False
        TextBox3.ForeColor = Color.Yellow
        picturebox1.Location = New Point(0, 0)
        picturebox1.Size = New Size(1008, 639)
        picturebox1.BackColor = Color.Transparent
        picturebox1.Name = "Picturebox1"
        Me.Controls.Add(picturebox1)
        AddHandler picturebox1.Paint, AddressOf PictureBox1_Paint
        AddHandler picturebox1.MouseMove, AddressOf PictureBox1_MouseMove
        AddHandler picturebox1.MouseUp, AddressOf PictureBox1_MouseUp
        AddHandler picturebox1.MouseDown, AddressOf PictureBox1_MouseDown
        AddHandler picturebox1.Click, AddressOf PictureBox1_Click
        AddHandler Timer1.Tick, AddressOf Timer1_Tick
        AddHandler Timer2.Tick, AddressOf Timer2_Tick
        Timer2.Start()
        My.Computer.Audio.Play(My.Resources.ANGRY_BIRDS_Soundtrack_Remix_2016__ELECTRODUBSTEP_, AudioPlayMode.Background)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Computer.Audio.Play(My.Resources.menu_back, AudioPlayMode.Background)
        Application.Restart()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        My.Computer.Audio.Play(My.Resources.ANGRY_BIRDS_Soundtrack_Remix_2016__ELECTRODUBSTEP_, AudioPlayMode.Background)

        My.Computer.Audio.Play(My.Resources.menu_back, AudioPlayMode.Background)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        My.Computer.Audio.Play(My.Resources.menu_back, AudioPlayMode.Background)
        My.Computer.Audio.Play(My.Resources.menu_back, AudioPlayMode.Background)
        Dim a As New Form3
        a.Show()
        My.Computer.Audio.Stop()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        My.Computer.Audio.Play(My.Resources.menu_back, AudioPlayMode.Background)
        My.Computer.Audio.Stop()
    End Sub


End Class