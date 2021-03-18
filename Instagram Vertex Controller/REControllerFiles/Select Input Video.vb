Public Class SelectInputVideo


    Private Sub RellenarExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Activate()
        Me.InputVideo.Select()
        Me.InputVideo.Focus()

        inputSelec = 0

        itemSel = False

    End Sub

    Private Sub InputVideo_GotFocus(sender As Object, e As EventArgs) Handles InputVideo.GotFocus
        'Sendkeys("{F4}", True)
        Me.InputVideo.DroppedDown = True
    End Sub

    Private Sub InputVideo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InputVideo.SelectedIndexChanged

        itemSel = True

        'Asignamos el valor seleccionado en el combo a la variable global inputSelec (integer):
        Dim itemText As String = Me.InputVideo.SelectedItem

        'Funciones para convertir un String a Integer:
        'inputSelec = Convert.ToInt32(itemText)
        'Int32.TryParse()
        'CInt()

        inputSelec = CInt(itemText)

        If (inputSelec >= 1 And inputSelec <= 16) Then
            'Cerramos el formulario
            Me.Close()
        End If

    End Sub

    Private Sub BtnClipVentana_Click(sender As Object, e As EventArgs) Handles BtnClipVentana.Click

        If (SelectClipVentana.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            rutaClipVentana = SelectClipVentana.FileName
            clipVentana = True
        End If

        Me.Close()

    End Sub
End Class