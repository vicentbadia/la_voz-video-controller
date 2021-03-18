Public Class Animaciones

    Private Sub Animaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.PlayAnim01.Enabled = False
        Me.PlayAnim02.Enabled = False
        Me.PlayAnim03.Enabled = False
        Me.PlayAnim04.Enabled = False

    End Sub

    Private Sub PlayAnim01_Click(sender As Object, e As EventArgs) Handles PlayAnim01.Click

        PlayAnimacion(anim01)

    End Sub

    Private Sub PlayAnim02_Click(sender As Object, e As EventArgs) Handles PlayAnim02.Click

        PlayAnimacion(anim02)

    End Sub

    Private Sub PlayAnim03_Click(sender As Object, e As EventArgs) Handles PlayAnim03.Click

        PlayAnimacion(anim03)

    End Sub

    Private Sub PlayAnim04_Click(sender As Object, e As EventArgs) Handles PlayAnim04.Click

        PlayAnimacion(anim04)

    End Sub

    Private Sub PlayAnimacion(ByRef nombre As String)

        'Comprobamos el tipo de animación:
        Dim i As Integer

        i = InStr(nombre, "in")

        If i > 0 Then
            tipoAnim = "Entrada"
        End If

        i = InStr(nombre, "out")

        If i > 0 Then
            tipoAnim = "Salida"
        End If

        'En cualquier otro caso, tipoAnim tiene el valor por defecto, "Otra"


        'Si no está activada, activamos la escena primero:

        If escenaActivada = False Then
            Module1.ActivarEscena(1)
            escenaActivada = True
        End If

        'Play animación:
        Console.WriteLine("Playing " + nombre + " animation...")

        reTalkXML.registerAnimationCallbacks(escena, cmdId)
        reTalkXML.startSceneAnimation(escena, nombre, cmdId)

    End Sub

    Private Sub ComboAnimIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAnimIN.SelectedIndexChanged

        animINsel = ComboAnimIN.SelectedItem.ToString

        'Habilitamos el botón Play IN
        Me.PlayAnimIN.Enabled = True

    End Sub

    Private Sub ComboAnimOUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAnimOUT.SelectedIndexChanged

        animOUTsel = ComboAnimOUT.SelectedItem.ToString

        'habilitamos el botón Play OUT
        Me.PlayAnimOUT.Enabled = True

    End Sub

    Private Sub ComboAnimOtras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAnimOtras.SelectedIndexChanged

        animOtrasSel = ComboAnimOtras.SelectedItem.ToString

        'habilitamos el botón Play otras animaciones
        Me.PlayAnimOtras.Enabled = True

    End Sub

    Private Sub PlayAnimIN_Click(sender As Object, e As EventArgs) Handles PlayAnimIN.Click

        'Play animación IN seleccionada en la lista:
        PlayAnimacion(animINsel)

    End Sub

    Private Sub PlayAnimOUT_Click(sender As Object, e As EventArgs) Handles PlayAnimOUT.Click

        'Play animación OUT seleccionada en la lista:
        PlayAnimacion(animOUTsel)

    End Sub

    Private Sub PlayAnimOtras_Click(sender As Object, e As EventArgs) Handles PlayAnimOtras.Click

        'Play animación Otras seleccionada en la lista:
        PlayAnimacion(animOtrasSel)

    End Sub

End Class