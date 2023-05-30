Public Class Form1
    Dim random As New Random
    Dim flagPrimeiroClick As Boolean = True
    Dim percentagemFeita
    Dim valorCadaTilePercentagem As Decimal = 5.5
    Dim valorTotalPercentagem As Decimal

    Dim labelPercentagem As New Label()
    Dim recomecarBotao As New Button()

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeControls()
        Iniciar()
    End Sub

    Private Sub InitializeControls()
        ' Declarar botão
        recomecarBotao.Text = "Recomeçar"
        recomecarBotao.Size = New Size(100, 50)
        recomecarBotao.Location = New Point(240, 250)
        Me.Controls.Add(recomecarBotao)
        recomecarBotao.Hide()
        AddHandler recomecarBotao.Click, AddressOf RecomecarBotao_Click

        ' Declarar label
        labelPercentagem.Font = New Font("Arial", 12, FontStyle.Bold)
        labelPercentagem.ForeColor = Color.Black
        labelPercentagem.BackColor = Color.White
        labelPercentagem.Location = New Point(260, 10)
        labelPercentagem.AutoSize = True
        Me.Controls.Add(labelPercentagem)
    End Sub

    Private Sub CriarPictureBoxes()
        Dim pictureBoxCounter As Integer = 0

        For y As Integer = 0 To 5
            For x As Integer = 0 To 5
                pictureBoxCounter += 1
                tiles(x, y).Picturebox = CreatePictureBox(135 + y * 70, 60 + x * 70, "PictureBoxLayer1 " & pictureBoxCounter)
                Me.Controls.Add(tiles(x, y).Picturebox)
                pictureBoxCounter += 1
                AddHandler tiles(x, y).Picturebox.Click, AddressOf PictureBox_Click
            Next
        Next
    End Sub

    Private Sub Iniciar()
        CriarPictureBoxes()
        BaralharPecas()
        AtualizarLabelPercentagem()
    End Sub

    Private Sub AtualizarLabelPercentagem()
        If Math.Round(valorTotalPercentagem) <> 99 Then
            labelPercentagem.Text = Math.Round(valorTotalPercentagem) & " %"
        Else
            labelPercentagem.Text = "100 %"
            recomecarBotao.Show()
        End If
    End Sub

    Private Sub RecomecarBotao_Click(sender As Object, e As EventArgs)
        sender.Hide()
        tiles = New tile(5, 5) {}
        valorTotalPercentagem = 0
        Iniciar()
    End Sub

    Private Sub BaralharPecas()
        Dim _randomY As Integer
        Dim _randomX As Integer
        Dim pecaAtual As Bitmap

        For y As Integer = 0 To 5
            For x As Integer = 0 To 5
                If tiles(x, y).Visibilidade = visibilidade.visivel Then
                    Continue For
                Else
                    pecaAtual = getPecaAleatoria()

                    tiles(x, y).Picturebox.Image = pecaAtual
                    tiles(x, y).Visibilidade = visibilidade.visivel

                    Do
                        _randomX = random.Next(6)
                        _randomY = random.Next(6)
                    Loop While tiles(_randomX, _randomY).Visibilidade = variaveisGlobais.visibilidade.visivel

                    tiles(_randomX, _randomY).Picturebox.Image = pecaAtual
                    tiles(_randomX, _randomY).Visibilidade = visibilidade.visivel
                End If
            Next
        Next
    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs)
        tileListaQueue.Enqueue(sender)

        If Not flagPrimeiroClick Then
            If getImagemIgual(tileListaQueue(0), tileListaQueue(1)) = True AndAlso tileListaQueue(0).name <> tileListaQueue(1).name Then
                valorTotalPercentagem += valorCadaTilePercentagem
                For i = 0 To 1
                    tileListaQueue(i).hide
                Next

                tileListaQueue.Clear()
                flagPrimeiroClick = True

                AtualizarLabelPercentagem()
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

    Private Function getPecaAleatoria() As Bitmap
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
