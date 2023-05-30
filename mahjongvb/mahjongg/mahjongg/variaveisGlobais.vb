Module variaveisGlobais
    Public tilesLayer(14, 7) As tiles
    Public tilesLayer1(14, 7) As tiles
    Public tilesLayer2(14, 7) As tiles
    Public tilesLayer3(14, 7) As tiles
    Public tilesLayer4(14, 7) As tiles
    Public tilesLayerAssimetricas(14, 7) As tiles
    Public tilesList As New ArrayList
    Public meioX As Integer
    Public meioY As Integer

    Enum visibilidade
        escondido
        visivel
        removido
    End Enum

    Public Structure tiles
        Dim picturebox As PictureBox
        Dim Assinalada As Boolean
        Dim visibilidade As visibilidade
    End Structure

End Module
