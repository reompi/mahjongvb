Class baralharPecas
    Dim random As New Random
    Dim pecaAtual As Bitmap
    Dim posicaoAleatoriaX As Integer
    Dim posicaoAleatoriaY As Integer
    Dim ticker As Integer = 0
    Dim meioX As Integer = 6
    Dim meioY As Integer = 3
    Dim flag As Boolean
    Dim y As Integer
    Sub baralharInicio()
        'layer 0

        flag = False
        For diagonal As Integer = meioX To 3 Step -1

            ticker += 1



            pecaAtual = getPecaAleatoria()


            For parDePecas = 0 To 1

                Do

                    posicaoAleatoriaX = getPosicaoAleatoriaX(diagonal)
                    posicaoAleatoriaY = getPosicaoAleatoriaY(diagonal - 3)



                Loop While tilesLayer(posicaoAleatoriaX, posicaoAleatoriaY).visibilidade = visibilidade.visivel

                tilesLayer(posicaoAleatoriaX, posicaoAleatoriaY).visibilidade = visibilidade.visivel
                tilesLayer(posicaoAleatoriaX, posicaoAleatoriaY).picturebox.Image = pecaAtual
            Next

        Next
        flag = True
        ticker = 1
        For diagonal As Integer = meioX To 4 Step -1

            ticker += 1



            pecaAtual = getPecaAleatoria()


            For parDePecas = 0 To 1

                Do

                    posicaoAleatoriaX = getPosicaoAleatoriaX(diagonal)
                    posicaoAleatoriaY = getPosicaoAleatoriaY(diagonal - 3)



                Loop While tilesLayer(posicaoAleatoriaX, posicaoAleatoriaY).visibilidade = visibilidade.visivel

                tilesLayer(posicaoAleatoriaX, posicaoAleatoriaY).visibilidade = visibilidade.visivel
                tilesLayer(posicaoAleatoriaX, posicaoAleatoriaY).picturebox.Image = pecaAtual
            Next

        Next

        'For Each tile As tiles In tilesLayer

        'If tile.visibilidade = visibilidade.escondido Then
        'pecaAtual = getPecaAleatoria()

        'tile.picturebox.Image = pecaAtual
        'tile.visibilidade = visibilidade.visivel

        'For Each _tile As tiles In tilesLayer

        'If _tile.visibilidade = visibilidade.escondido Then
        '_tile.picturebox.Image = pecaAtual
        '_tile.visibilidade = visibilidade.visivel
        'Exit For
        'End If
        'Next
        'End If
        'Next
    End Sub
    Private Function getPosicaoAleatoriaX(x As Integer) As Integer
        Dim _random As Integer

        _random = random.Next(2)

        Select Case _random
            Case 0
                Return x
            Case 1
                If flag = True Then
                    Return meioX + ticker - 1
                End If
                Return meioX + ticker
        End Select


    End Function
    Private Function getPosicaoAleatoriaY(y As Integer) As Integer

        Dim _random As Integer


        _random = random.Next(2)


        Select Case _random
            Case 0
                If flag = True Then

                    Return y - 1
                End If
                Return y
            Case 1
                Return meioY + ticker






        End Select



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