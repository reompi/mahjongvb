Public Class mainForm
    Dim pecas As New Template
    Dim baralhar As New baralharPecas


    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pecas.criarPictureBoxes()
        baralhar.baralharInicio()


    End Sub
End Class
