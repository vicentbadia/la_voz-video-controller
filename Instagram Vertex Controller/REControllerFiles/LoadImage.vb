Public Class LoadImage

    Private Sub BtnImg4No_Click(sender As Object, e As EventArgs) Handles BtnImg4No.Click

        cargarImagen4 = False
        Me.Close()

    End Sub

    Private Sub BtnImg4Si_Click(sender As Object, e As EventArgs) Handles BtnImg4Si.Click

        cargarImagen4 = True
        Me.Close()

    End Sub
End Class