Module variaveisGlobais
    Enum visibilidade
        escondido
        visivel
    End Enum
    Public Structure tile
        Dim Picturebox As PictureBox
        Dim Visibilidade As visibilidade
    End Structure
    Public listTiles As New ArrayList
    Public tileListaQueue As New Queue
    Public tiles(5, 5) As tile
End Module
