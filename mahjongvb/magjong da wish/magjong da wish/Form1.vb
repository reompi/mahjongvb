Public Class Form1
    Dim random As New Random
    Dim flagPrimeiroClick As Boolean = True
    Dim percentagemFeita
    Dim valorCadaTilePercentagem As Decimal = 5.5
    Dim valorTotalPercentagem As Decimal
    Dim flagDeclararLabel As Boolean = True
    Dim lablePercentagem As New Label()
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        criarPictureBoxes()
        labelPercentagem()
    End Sub

    Private Sub labelPercentagem()
        If flagDeclararLabel = True Then


            lablePercentagem.Font = New Font("Arial", 12, FontStyle.Bold)
            lablePercentagem.ForeColor = Color.Black
            lablePercentagem.BackColor = Color.White
            lablePercentagem.Location = New Point(260, 10)
            lablePercentagem.AutoSize = True
            Me.Controls.Add(lablePercentagem)
            flagDeclararLabel = False
        End If



        lablePercentagem.Text = Math.Round(valorTotalPercentagem) & " %"
    End Sub
    Private Sub criarPictureBoxes()
        Dim _randomY As Integer
        Dim _randomX As Integer
        Dim pecaAtual As Bitmap
        Dim ticker As Integer

        For y As Integer = 0 To 5
            For x As Integer = 0 To 5
                ticker += 1
                tiles(x, y).picturebox = CreatePictureBox(135 + y * 70, 60 + x * 70, "PictureBoxLayer1 " & ticker)
                Me.Controls.Add(tiles(x, y).picturebox)
                ticker += 1
                AddHandler tiles(x, y).picturebox.Click, AddressOf _pictureboxClick


            Next
        Next


        For Each tile As tile In tiles

            If tile.visibilidade = visibilidade.visivel Then

            Else

                pecaAtual = getPecaAleatoria()


                tile.picturebox.Image = pecaAtual
                tile.visibilidade = visibilidade.visivel

                Do
                    _randomX = random.Next(6)
                    _randomY = random.Next(6)
                Loop While tiles(_randomX, _randomY).visibilidade = visibilidade.visivel

                tiles(_randomX, _randomY).picturebox.Image = pecaAtual
                tiles(_randomX, _randomY).visibilidade = visibilidade.visivel

            End If

            pecaAtual = Nothing
        Next

    End Sub
    Private Sub _pictureboxClick(sender As Object, e As EventArgs)



        tileListaQueue.Enqueue(sender)


        If flagPrimeiroClick = False Then
            If getImagemIgual(tileListaQueue(0), tileListaQueue(1)) = True And tileListaQueue(0).name <> tileListaQueue(1).name Then
                valorTotalPercentagem += valorCadaTilePercentagem
                For i = 0 To 1
                    tileListaQueue(i).hide
                Next

                tileListaQueue.Clear()
                flagPrimeiroClick = True

                labelPercentagem()
            Else
                tileListaQueue.Dequeue()
            End If
        Else
            flagPrimeiroClick = False
        End If
    End Sub
    Private Function CreatePictureBox(top As Integer, left As Integer, name As String) As PictureBox
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
            .BorderStyle = BorderStyle.FixedSingle

        End With
        Return pictureBox
    End Function

    Private Function getImagemIgual(image1 As PictureBox, image2 As PictureBox)

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


    Private Function getPecaAleatoria()

        Dim _random As Integer = Random.Next(12)
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
