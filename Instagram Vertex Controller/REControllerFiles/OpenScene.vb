Public Class OpenScene

    Private Sub OpenSceneBtn_Click(sender As Object, e As EventArgs) Handles OpenSceneBtn.Click

        If (LoadScene.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            escena = LoadScene.SelectedPath
        End If

        Dim inicioRuta As String = "G:\Projects\"

        Dim posicion As Integer

        posicion = InStr(escena, inicioRuta)

        If posicion <> 1 Then
            MsgBox("Selecciona la carpeta de la escena dentro de G:\Projects")
        Else
            'Quitamos de la ruta G:\Projects\
            escena = escena.Replace("G:\Projects\", "")
            'Cambiamos \ por / :
            escena = escena.Replace("\", "/")

            'Cerramos el formulario
            Me.Close()
        End If

    End Sub

End Class