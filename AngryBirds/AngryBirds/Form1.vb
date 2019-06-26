Public Class Form1
    'Oscar Ronaldo Mencos Chamalé
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Computer.Audio.Play(My.Resources.menu_back, AudioPlayMode.Background)
        Dim a As New Form2
        a.Show()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.ANGRY_BIRDS_Soundtrack_Remix_2016__ELECTRODUBSTEP_, AudioPlayMode.Background)
        Me.Finalize()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Original_Main_Theme___Angry_Birds_Music, AudioPlayMode.Background)
    End Sub
End Class
