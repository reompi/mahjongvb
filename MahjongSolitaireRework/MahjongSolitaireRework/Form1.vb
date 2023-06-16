Imports System.IO

Public Class Form1
    Dim random As New Random
    Dim filePath As String = "C:\Users\123746\source\repos\MahjongSolitaireRework\MahjongSolitaireRework\map.txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vector1 As New Vector3i(0, 0, 0)

        Using reader As New StreamReader(filePath)
            Dim line As String = reader.ReadLine


            While line IsNot Nothing
                Dim columnIndex As Integer = 0
                For Each z As Integer In line
                    vector1.Z = z









                    vector1.X += 1
                Next
                vector1.Y += 1
            End While
        End Using

    End Sub

    Private Function getImagemIgual(image1 As PictureBox, image2 As PictureBox) As Boolean
        Dim bitmap1 As New Bitmap(image1.Image)
        Dim bitmap2 As New Bitmap(image2.Image)

        ' Iterate over each pixel in the images and compare their color values
        For x As Integer = 0 To bitmap1.Width - 1
            For y As Integer = 0 To bitmap1.Height - 1
                If bitmap1.GetPixel(x, y) <> bitmap2.GetPixel(x, y) Then
                    ' The color values of the pixels are not equal
                    Return False
                End If
            Next
        Next

        ' All pixels have the same color values, images are equal
        Return True
    End Function
    Private Function CreatePictureBox(top As Integer, left As Integer, name As String, layer As Integer) As PictureBox
        Dim pictureBox As New PictureBox()
        With pictureBox
            .Top = top
            .Left = left
            .Name = name
            .Size = New System.Drawing.Size(70, 70)
            .TabIndex = 0
            .TabStop = False
            .BorderStyle = BorderStyle.FixedSingle
            .SizeMode = PictureBoxSizeMode.StretchImage
            If layer Mod 2 = 0 Then
                .BorderStyle = BorderStyle.Fixed3D
            Else
                .BorderStyle = BorderStyle.FixedSingle
            End If
        End With
        Return pictureBox
    End Function
    Private Function getPecaAleatoria()

        Dim _random As Integer = random.Next(12)
        Select Case _random
            Case 0
                Return My.Resources.bolas__1_
            Case 1
                Return My.Resources.bolas__2_
            Case 2
                Return My.Resources.bolas__3_
            Case 3
                Return My.Resources.paus__1_
            Case 4
                Return My.Resources.paus__2_
            Case 5
                Return My.Resources.paus__3_
            Case 6
                Return My.Resources.s__1_
            Case 7
                Return My.Resources.s__2_
            Case 8
                Return My.Resources.s__3_
            Case 9
                Return My.Resources.x__1_
            Case 10
                Return My.Resources.x__2_
            Case 11
                Return My.Resources.x__3_
        End Select
        Return Nothing
    End Function
End Class
