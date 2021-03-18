Public Class SelectIP


    Private Sub IPlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles IPlist.SelectedIndexChanged

        IP = IPlist.SelectedItem.ToString
        Me.Close()

    End Sub
End Class