Public Class RellenarExport

    Private Sub RellenarExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Activate()
        Me.NuevoTexto.Select()
        Me.NuevoTexto.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Enviamos el valor del formulario a la variable global:
        valorExport = NuevoTexto.Text

        'Cerramos el formulario
        Me.Close()

    End Sub

End Class