Public Class Template

    Public Sub criarPictureBoxes()
        'criarLayer4()
        'criarLayer3()
        'criarLayer2()
        'criarLayer1()
        criarLayer0()
        criarTilesAssimetricas()
    End Sub

    Private Sub criarLayer4()

        Dim layer = 4
        tilesLayer4(7, 4).picturebox = CreatePictureBox(135 + 4 * 70 - 35, 60 + 7 * 70 - 35, "PictureBoxlayer " & layer & "0", layer)
        mainForm.Controls.Add(tilesLayer4(7, 4).picturebox)
        tilesList.Add(tilesLayer4(7, 4))


    End Sub

    Private Sub criarLayer3()
        Dim ticker As Integer = 0
        Dim layer = 3
        For y As Integer = 3 To 4
            For x As Integer = 6 To 7
                tilesLayer3(x, y).picturebox = CreatePictureBox(135 + y * 70, 60 + x * 70, "PictureBoxLayer3 " & layer & ticker, layer)
                mainForm.Controls.Add(tilesLayer3(x, y).picturebox)
                tilesList.Add(tilesLayer3(x, y))
                ticker += 1

            Next
        Next
    End Sub

    Private Sub criarLayer2()
        Dim ticker As Integer = 0
        Dim layer = 2
        For y As Integer = 2 To 5
            For x As Integer = 5 To 8
                tilesLayer2(x, y).picturebox = CreatePictureBox(135 + y * 70, 60 + x * 70, "PictureBoxLayer2 " & layer & ticker, layer)
                mainForm.Controls.Add(tilesLayer2(x, y).picturebox)
                tilesList.Add(tilesLayer2(x, y))
                ticker += 1

            Next
        Next
    End Sub

    Private Sub criarLayer1()
        Dim ticker As Integer = 0
        Dim layer = 1
        For y As Integer = 1 To 6
            For x As Integer = 4 To 9
                tilesLayer1(x, y).picturebox = CreatePictureBox(135 + y * 70, 60 + x * 70, "PictureBoxLayer1 " & layer & ticker, layer)
                mainForm.Controls.Add(tilesLayer1(x, y).picturebox)
                tilesList.Add(tilesLayer1(x, y))
                ticker += 1

            Next
        Next
    End Sub

    Private Sub criarLayer0()
        Dim ticker As Integer = 0
        Dim layer = 0
        For y As Integer = 0 To 7
            For x As Integer = 0 To 14
                If Not getMapa(x, y) Then
                    tilesLayer(x, y).visibilidade = visibilidade.removido
                    Continue For
                End If

                tilesLayer(x, y).picturebox = CreatePictureBox(135 + y * 70, 60 + x * 70, "PictureBoxLayer" & layer & ticker, layer)
                mainForm.Controls.Add(tilesLayer(x, y).picturebox)
                tilesList.Add(tilesLayer(x, y))
                ticker += 1

            Next
        Next
    End Sub

    Private Sub criarTilesAssimetricas()
        Dim assimetricasTiles() As Integer = {0, 13, 14}

        For Each x As Integer In assimetricasTiles
            tilesLayerAssimetricas(x, 4).picturebox = CreatePictureBox(135 + 4 * 70 - 35, 60 + x * 70, "PictureBox" & x, 0)
            mainForm.Controls.Add(tilesLayerAssimetricas(x, 4).picturebox)
            tilesList.Add(tilesLayerAssimetricas(x, 4))

        Next
    End Sub

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

    Private Function getMapa(x As Integer, y As Integer) As Boolean
        Dim vazioYValores() As Integer = {0, 3, 4, 7}
        Dim vazioY1Vales() As Integer = {1, 6}
        Dim vazioY2Valores() As Integer = {2, 5}
        Dim vazioXValores() As Integer = {0, 13, 14}
        Dim vazioX1Valores() As Integer = {0, 1, 2, 11, 12, 13, 14}
        Dim vazioX2Valores() As Integer = {0, 1, 12, 13, 14}

        If vazioYValores.Contains(y) AndAlso vazioXValores.Contains(x) Then
            Return False
        End If

        If vazioY1Vales.Contains(y) AndAlso vazioX1Valores.Contains(x) Then
            Return False
        End If

        If vazioY2Valores.Contains(y) AndAlso vazioX2Valores.Contains(x) Then
            Return False
        End If

        Return True
    End Function

End Class
