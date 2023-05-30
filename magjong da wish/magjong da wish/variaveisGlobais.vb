Module variaveisGlobais
    Enum visibilidade
        escondido
        visivel
    End Enum
    Public Structure tile
        Dim picturebox As PictureBox
        Dim visibilidade As visibilidade
        Dim simbolo As String
    End Structure
    Public listTiles As New ArrayList
    Public tileCicadaQueue As New Queue
    Public tiles(5, 5) As tile
End Module
