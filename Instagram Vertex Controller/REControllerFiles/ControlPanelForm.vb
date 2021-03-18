Public Class ControlPanelForm


    'Declaración para crear labels y mostrar los nombres de los exports:
    Private lbl As Windows.Forms.Label

    'Clase para declarar ComboBoxes:
    Private combo As Windows.Forms.ComboBox

    'Posición inicial X Y para los label:
    Dim xPos As Integer = 51
    Dim yPos As Integer = 215

    'Boolean para el estado de los paneles Transicion 3-4 y Imagenes Foreground
    Dim transicion34 As Boolean = False


    'Lista de controles con los labels creados para poder borrarlos después de descargar la escena:
    Dim labelsBorrar As New List(Of Object)()
    Dim labelsAnimBorrar As New List(Of Object)()

    'Creamos un objeto para controlar la ventana de Animaciones:
    Dim boxAnimaciones As New Animaciones()

    'Objeto para el formulario de confirmación Imagen 4 Foreground
    Dim boxLoadImage As New LoadImage()

    Private Sub ControlPanelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ResetBotones()

        'Tamaño del panel Datos de la Escena:
        Me.SceneDataPanel.Size = New Drawing.Size(510, 662)

        'Iniciar las variables que guardar las entradas de las ventanas
        entrada1video = ""
        entrada2video = ""
        entrada3video = ""
        entrada4video = ""
        entrada1clip = ""
        entrada2clip = ""
        entrada3clip = ""
        entrada4clip = ""

    End Sub

    'Función para detectar si la ruta de un archivo está en G:
    Public Function RutaEnG(ruta As String) As Boolean

        Dim n As Integer
        n = InStr(ruta, "G:")

        If n = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub ResetBotones()

        'Activamos el botón para cargar escenas:
        Me.BtnLoadScene.Enabled = True

        'Desactivamos el resto de botones del panel de control:
        Me.BtnUnload.Enabled = False

        Me.TextExport01.Enabled = False
        Me.TextExport02.Enabled = False
        Me.TextExport01.Visible = False
        Me.TextExport02.Visible = False


        Me.ClipPlay.Enabled = False
        Me.ClipPause.Enabled = False
        Me.ClipRewind.Enabled = False
        Me.ClipStop.Enabled = False

        Me.ClipPlay2.Enabled = False
        Me.ClipPause2.Enabled = False
        Me.ClipRewind2.Enabled = False
        Me.ClipStop2.Enabled = False

        Me.V1Texto.Enabled = False
        Me.V2Texto.Enabled = False
        Me.V3Texto.Enabled = False
        Me.V4Texto.Enabled = False

        Me.BtnTrans1_2.Enabled = False
        Me.BtnTrans3_4.Enabled = False

        Me.TransCut.Checked = False
        Me.TransDisolve.Checked = False
        Me.TransLaVoz.Checked = False
        Me.TransCut.BackColor = Drawing.Color.Lavender
        Me.TransDisolve.BackColor = Drawing.Color.Lavender
        Me.TransLaVoz.BackColor = Drawing.Color.Lavender
        Me.TransCut.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransDisolve.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransLaVoz.ForeColor = Drawing.Color.DarkSlateGray

        Me.TransCut2.Checked = False
        Me.TransDisolve2.Checked = False
        Me.TransLaVoz2.Checked = False
        Me.TransCut2.BackColor = Drawing.Color.Lavender
        Me.TransDisolve2.BackColor = Drawing.Color.Lavender
        Me.TransLaVoz2.BackColor = Drawing.Color.Lavender
        Me.TransCut2.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransDisolve2.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransLaVoz2.ForeColor = Drawing.Color.DarkSlateGray

        'Ocultamos el panel que hace de Tally en las 4 ventanas:
        TallyReset()

        'Desactivar botones pos y escala ventanas:
        Me.CheckControlesFull.Enabled = False
        Me.CheckControlesBg.Enabled = False
        Me.CheckControles1_2.Enabled = False
        Me.CheckControles3_4.Enabled = False
        Me.CheckControlesFull.Checked = False
        Me.CheckControlesBg.Checked = False
        Me.CheckControles1_2.Checked = False
        Me.CheckControles3_4.Checked = False

    End Sub

    Public Sub CargarExports(ByRef exportsEscena As Object, ByRef tipos As Object)

        'Utilizamos un contador para los nombres de los label donde van los textos mostrando los Exports:
        Dim n As Integer = 10
        Dim numTexto As Integer = 1

        'Recorremos el objeto que contiene los nombres de los exports de la escena:
        For Each item As Object In exportsEscena
            Dim nombre As String = "label" + n.ToString
            'Crear label para mostrar nombre del Export
            lbl = New Windows.Forms.Label

            Me.Controls.Add(lbl)

            lbl.Name = nombre
            lbl.Text = item.ToString
            lbl.Parent = SceneDataPanel
            lbl.Left = xPos
            lbl.Top = yPos
            lbl.ForeColor = Drawing.Color.DarkSlateGray
            lbl.Font = New Drawing.Font(lbl.Font, Drawing.FontStyle.Bold)
            lbl.AutoSize = True

            'Guardamos el label en la lista:
            labelsBorrar.Add(lbl)

            'Pasamos el nombre del Export a minúsculas. Opcion 1 mayusculas, opcion 2 minusculas:
            Dim lowExport = StrConv(item.ToString, 2)

            'Detectar si es un Export de texto:
            Dim i As Integer = InStr(lowExport, "text")
            Dim j As Integer = InStr(lowExport, "texture")


            'Detectar si es un Export Single Child (Safety Area / Background):
            Dim l As Integer = InStr(lowExport, "childindex")


            If (i > 0 And j = 0) Then
                If numTexto = 1 Then
                    'Activamos el boton para cargar el texto:
                    Me.TextExport01.Enabled = True
                    Me.TextExport01.Visible = True
                    'Guardamos el nombre del Export:
                    nombreTexto01 = item.ToString
                    'Ponemos el nombre del export en el botón
                    Me.TextExport01.Text = item.ToString
                End If
                If numTexto = 2 Then
                    'Activamos el boton para cargar el texto:
                    Me.TextExport02.Enabled = True
                    Me.TextExport02.Visible = True
                    'Guardamos el nombre del Export:
                    nombreTexto02 = item.ToString
                    'Ponemos el nombre del export en el botón
                    Me.TextExport02.Text = item.ToString
                End If
                numTexto = numTexto + 1

                'Añadir export de Texto al dropdown:
                ComboTextos.Items.Add(item.ToString)

                'Sumamos uno al total de textos:
                totalTextos = totalTextos + 1
            End If


            If (l > 0) Then  'Single Child Background (Safe Area / Instagram)

                ventanaNum = ventanaNum + 1

                If ventanaNum = 1 Then
                    'Single Child fondo Safe Area
                    'exportSC1 = item.ToString
                    exportSC1 = "Object_Group_Background_Safe_Area_C_Enable_DrawingChildIndex"
                End If

                If ventanaNum = 2 Then
                    'Single Child fondo Instagram
                    'exportSC2 = item.ToString
                    exportSC2 = "Object_Group_Background_Instagram_C_Enable_DrawingChildIndex"
                End If

                'Mostrar el control para los valores de la ventana:
                MostrarCombo(ventanaNum)

            End If

            n = n + 1

            yPos = yPos + 20

        Next

        'Si hay más de 2 textos, cambiamos los botones por un dropdown para seleccionar el Export Texto a rellenar:
        If totalTextos > 2 Then

            ListaTextos()

        End If

        'Bajamos la posición Y de los label para la siguiente sección (animaciones):
        yPos = yPos + 30

    End Sub

    Public Sub IniciarControles(ByRef grupo As String)

        If grupo = "full" Then
            reTalkXML.getSceneExportValue(escena, exportGrupoPosX, cmdId)
            reTalkXML.getSceneExportValue(escena, exportGrupoPosY, cmdId)
            reTalkXML.getSceneExportValue(escena, exportGrupoEscala, cmdId)
        End If

        If grupo = "bg" Then
            reTalkXML.getSceneExportValue(escena, exportBackgroundPosX, cmdId)
            reTalkXML.getSceneExportValue(escena, exportBackgroundPosY, cmdId)
            reTalkXML.getSceneExportValue(escena, exportBackgroundEscala, cmdId)
        End If

        If grupo = "1-2" Then
            reTalkXML.getSceneExportValue(escena, exportVentanas12PosX, cmdId)
            reTalkXML.getSceneExportValue(escena, exportVentanas12PosY, cmdId)
            reTalkXML.getSceneExportValue(escena, exportVentanas12Escala, cmdId)
        End If

        If grupo = "3-4" Then
            reTalkXML.getSceneExportValue(escena, exportVentanas34PosX, cmdId)
            reTalkXML.getSceneExportValue(escena, exportVentanas34PosY, cmdId)
            reTalkXML.getSceneExportValue(escena, exportVentanas34Escala, cmdId)
        End If

    End Sub



    Private Sub ListaTextos()

        'Ocultamos los botones Texto 1 y 2:
        Me.TextExport01.Visible = False
        Me.TextExport02.Visible = False
        Me.TextExport01.Enabled = False
        Me.TextExport02.Enabled = False

        'Mostramos los controles para la lista de textos:
        Me.LblTextos.Visible = True
        Me.ComboTextos.Visible = True
        Me.BtnListaTextos.Visible = True

    End Sub

    Private Sub BotonesTextos()

        'Mostramos los botones Texto 1 y 2:
        Me.TextExport01.Visible = True
        Me.TextExport02.Visible = True
        Me.TextExport01.Enabled = False
        Me.TextExport02.Enabled = False

        'Ocultamos los controles para la lista de textos:
        Me.LblTextos.Visible = False
        Me.ComboTextos.Visible = False
        Me.BtnListaTextos.Visible = False

    End Sub

    Private Sub MostrarCombo(ByRef num As Integer)

        If num = 1 Then
            Me.LblSC1.Enabled = True
            Me.LblSC1.Visible = True
            Me.ComboSC1.Enabled = True
            Me.ComboSC1.Visible = True
            Me.LblSC1Path.Enabled = True
            Me.LblSC1Path.Visible = True
        End If

        If num = 2 Then
            Me.LblSC2.Enabled = True
            Me.LblSC2.Visible = True
            Me.ComboSC2.Enabled = True
            Me.ComboSC2.Visible = True
            Me.LblSC2Path.Enabled = True
            Me.LblSC2Path.Visible = True
        End If

    End Sub

    Private Sub OcultarCombosSC()

        Me.LblSC1.Enabled = False
        Me.LblSC1.Visible = False
        Me.ComboSC1.Enabled = False
        Me.ComboSC1.Visible = False
        Me.LblSC1Path.Enabled = False
        Me.LblSC1Path.Visible = False

        Me.LblSC2.Enabled = False
        Me.LblSC2.Visible = False
        Me.ComboSC2.Enabled = False
        Me.ComboSC2.Visible = False
        Me.LblSC2Path.Enabled = False
        Me.LblSC2Path.Visible = False

    End Sub

    Public Sub CargarAnimaciones(ByRef anim As Object)

        'Activamos el formulario Panel de Control:
        Me.Activate()

        If operacion = "PVW" Then

            'Creamos la sección Animaciones en el Panel de Control
            lbl = New Windows.Forms.Label

            Me.Controls.Add(lbl)

            lbl.Name = "animLbl"
            lbl.Text = "Animaciones:"
            lbl.Parent = SceneDataPanel
            lbl.ForeColor = Drawing.Color.DarkSlateGray
            lbl.AutoSize = True
            lbl.Left = xPos
            lbl.Top = yPos

            'Añadimos el label a la lista:
            labelsAnimBorrar.Add(lbl)

            yPos = yPos + 20

            Dim n As Integer = 1

            'Recorremos el array con el nombre de las animaciones
            For Each item As Object In anim
                'Creamos un label para que aparezca el nombre de la animación
                lbl = New Windows.Forms.Label

                Me.Controls.Add(lbl)

                lbl.Name = "lblAnim0" + n.ToString
                lbl.Text = item.ToString
                lbl.Parent = SceneDataPanel
                lbl.ForeColor = Drawing.Color.DarkSlateGray
                lbl.Font = New Drawing.Font(lbl.Font, Drawing.FontStyle.Bold)
                lbl.AutoSize = True
                lbl.Left = xPos
                lbl.Top = yPos

                'Añadimos el label a la lista:
                labelsAnimBorrar.Add(lbl)

                'Rebobinamos cada animación:
                reTalkXML.rewindSceneAnimation(escena, item.ToString, cmdId)

                'Activamos el botón Play de la animación y le cambiamos el texto con el nombre de la animación:
                If n = 1 Then
                    boxAnimaciones.PlayAnim01.Enabled = True
                    boxAnimaciones.PlayAnim01.Text = "Play " + item.ToString
                    'variable publica con el nombre de la animación:
                    anim01 = item.ToString
                End If
                If n = 2 Then
                    boxAnimaciones.PlayAnim02.Enabled = True
                    boxAnimaciones.PlayAnim02.Text = "Play " + item.ToString
                    'variable publica con el nombre de la animación:
                    anim02 = item.ToString
                End If
                If n = 3 Then
                    boxAnimaciones.PlayAnim03.Enabled = True
                    boxAnimaciones.PlayAnim03.Text = "Play " + item.ToString
                    'variable publica con el nombre de la animación:
                    anim03 = item.ToString
                End If
                If n = 4 Then
                    boxAnimaciones.PlayAnim04.Enabled = True
                    boxAnimaciones.PlayAnim04.Text = "Play " + item.ToString
                    'variable publica con el nombre de la animación:
                    anim04 = item.ToString
                End If


                'Pasamos el nombre del Export a minúsculas. Opcion 1 mayusculas, opcion 2 minusculas:
                Dim lowExport = StrConv(item.ToString, 2)

                'Detectar si es Animación de Entrada o de Salida:
                Dim i As Integer = InStr(lowExport, "in")
                Dim j As Integer = InStr(lowExport, "out")

                'Combo lista animaciones de Entrada:
                If i > 0 Then
                    boxAnimaciones.ComboAnimIN.Items.Add(item.ToString)
                End If

                'Combo lista animaciones de Salida:
                If j > 0 Then
                    boxAnimaciones.ComboAnimOUT.Items.Add(item.ToString)
                End If

                'Combo lista otras animaciones:
                If (i = 0 And j = 0) Then
                    boxAnimaciones.ComboAnimOtras.Items.Add(item.ToString)
                End If

                n = n + 1
                yPos = yPos + 20

                'Contador num total de animaciones:
                totalAnim = totalAnim + 1
            Next

            If totalAnim > 4 Then
                MostrarCombosAnim()
            End If

        End If

        If operacion = "PGM" Then

            'Recorremos el array con el nombre de las animaciones
            For Each item As Object In anim

                'Rebobinamos cada animación:
                reTalkXML.rewindSceneAnimation(escena, item.ToString, cmdId)

                'MsgBox("Animación " + item.ToString + " rebobinada")

            Next

        End If

    End Sub

    Private Sub MostrarCombosAnim()

        'Ocultamos los botones de las 4 animaciones primeras:
        boxAnimaciones.PlayAnim01.Visible = False
        boxAnimaciones.PlayAnim02.Visible = False
        boxAnimaciones.PlayAnim03.Visible = False
        boxAnimaciones.PlayAnim04.Visible = False

        'Mostramos los combos y los botones para más de 4 animaciones:
        boxAnimaciones.LlbIN.Visible = True
        boxAnimaciones.LblOUT.Visible = True
        boxAnimaciones.LblOtras.Visible = True

        boxAnimaciones.ComboAnimIN.Visible = True
        boxAnimaciones.ComboAnimOUT.Visible = True
        boxAnimaciones.ComboAnimOtras.Visible = True

        boxAnimaciones.ComboAnimIN.Enabled = True
        boxAnimaciones.ComboAnimOUT.Enabled = True
        boxAnimaciones.ComboAnimOtras.Enabled = True

        boxAnimaciones.PlayAnimIN.Visible = True
        boxAnimaciones.PlayAnimOUT.Visible = True
        boxAnimaciones.PlayAnimOtras.Visible = True

    End Sub

    Private Sub BotonesAnim()

        'Mostrar los botones de las 4 animaciones primeras:
        boxAnimaciones.PlayAnim01.Visible = True
        boxAnimaciones.PlayAnim02.Visible = True
        boxAnimaciones.PlayAnim03.Visible = True
        boxAnimaciones.PlayAnim04.Visible = True

        'Ocultamos los combos y los botones para más de 4 animaciones:
        boxAnimaciones.LlbIN.Visible = False
        boxAnimaciones.LblOUT.Visible = False
        boxAnimaciones.LblOtras.Visible = False

        boxAnimaciones.ComboAnimIN.Visible = False
        boxAnimaciones.ComboAnimOUT.Visible = False
        boxAnimaciones.ComboAnimOtras.Visible = False

        boxAnimaciones.ComboAnimIN.Enabled = False
        boxAnimaciones.ComboAnimOUT.Enabled = False
        boxAnimaciones.ComboAnimOtras.Enabled = False

        boxAnimaciones.PlayAnimIN.Visible = False
        boxAnimaciones.PlayAnimOUT.Visible = False
        boxAnimaciones.PlayAnimOtras.Visible = False

    End Sub

    Private Sub ResetCombos()

        'Setear los combos con los exports y las animaciones al cargar una nueva escena:
        Me.ComboTextos.Items.Clear()

        boxAnimaciones.ComboAnimIN.Items.Clear()
        boxAnimaciones.ComboAnimOUT.Items.Clear()
        boxAnimaciones.ComboAnimOtras.Items.Clear()

    End Sub

    Private Sub TextExport01_Click(sender As Object, e As EventArgs) Handles TextExport01.Click

        'Creamos un objeto para controlar la ventana de cargar texto:
        Dim box As New RellenarExport()

        'Comprobamos si ya hay un texto en el export y lo cargamos en el campo del formulario:
        If valorExport <> "" Then
            box.NuevoTexto.Text = valorExport
        End If


        'Abrir el formulario para rellenar el texto:
        box.ShowDialog()


        'If valorExport <> "" Then
        'Cargamos el nuevo texto aunque esté en blanco
        cargarTexto = True

        'cargamos el nuevo texto en el Export de la escena:
        reTalkXML.sendSceneStringExport(escena, nombreTexto01, valorExport, cmdId)

    End Sub

    Private Sub TextExport02_Click(sender As Object, e As EventArgs) Handles TextExport02.Click

        'Creamos un objeto para controlar la ventana de cargar texto:
        Dim box As New RellenarExport()

        'Comprobamos si ya hay un texto en el export y lo cargamos en el campo del formulario:
        If valorExport <> "" Then
            box.NuevoTexto.Text = valorExport
        End If


        'Abrir el formulario para rellenar el texto:
        box.ShowDialog()

        'If valorExport <> "" Then
        'Cargamos el texto aunque esté en blanco
        cargarTexto = True

        'cargamos el nuevo texto en el Export de la escena:
        reTalkXML.sendSceneStringExport(escena, nombreTexto02, valorExport, cmdId)

    End Sub

    

    Private Sub BtnUnload_Click(sender As Object, e As EventArgs) Handles BtnUnload.Click

        'Desactivar escena:

        If escenaActivada = True Then

            'Si hay un clip de vídeo, hacemos Rewind:
            If clipSC1 <> "" Then
                reTalkXML.callClipFunction(clipSC1, 6, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind
            End If

            If clipSC2 <> "" Then
                reTalkXML.callClipFunction(clipSC2, 6, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind
            End If

            'Desactivamos la escena:

            reTalkXML.unregisterAnimationCallbacks(escena, cmdId)
            Console.WriteLine("Deactivating scene...")
            reTalkXML.deactivateSceneOnSlot("Full", 1, cmdId)
           
        End If



        If escenaCargada = True Then

            'Borramos los labels que muestran información de la escena en el panel derecho:
            SceneNameLabel.Text = ""

            'Recorremos la lista de labels de los Exports para borrarlos:
            Dim n As Integer = 0
            For Each item As Object In labelsBorrar
                Me.Controls.Remove(item)
                item.Dispose()
                n = n + 1
            Next

            'MsgBox("Exports eliminados: " + n.ToString)


            'Recorremos la lista de labels de las Animaciones para borrarlos:
            Dim m As Integer = 0
            For Each item As Object In labelsAnimBorrar
                Me.Controls.Remove(item)
                item.Dispose()
                m = m + 1
            Next

            'MsgBox("Animaciones eliminadas: " + (m - 1).ToString)


            'Reseteamos la lista de controles a borrar:
            labelsBorrar.Clear()
            labelsAnimBorrar.Clear()

            'Desactivar botón TransAll:
            TransAll.Checked = False
            TransAll.BackColor = Drawing.Color.Lavender
            TransAll.ForeColor = Drawing.Color.DarkSlateGray

            'Posición inicial X Y para los label:
            xPos = 51
            yPos = 215

            'Botones transiciones al estado inicial de la escena:
            Me.BtnTrans1_2.Text = "2"
            Me.BtnTrans3_4.Text = "4"


            'Ocultamos las listas y mostramos los botones para Textos:
            BotonesTextos()

            'Ocultamos los combos de las animaciones y mostramos los 4 botones:
            If totalAnim > 4 Then
                BotonesAnim()
                totalAnim = 0
            End If

            'Ocultar combos con los fondos Single Child:
            OcultarCombosSC()

            LblSC1Path.Text = "Path"
            LblSC2Path.Text = "Path"


            'Reset combos con los exports y las animaciones:
            ResetCombos()

            'Reset contador de exports Texto:
            totalTextos = 0

            'Reset valor del export de Texto:
            valorExport = ""

            'Reset num de ventanas:
            ventanaNum = 0

            'Reset labels inputs ventanas:
            Me.V1Texto.Text = "Input _"
            Me.V2Texto.Text = "Input _"
            Me.V3Texto.Text = "Input _"
            Me.V4Texto.Text = "Input _"

            'Ocultamos el panel que hace de Tally en las 4 ventanas:
            TallyReset()

            'Ocultar el panel para los controles del clip de la ventana:
            LblControlesClip.Visible = False
            PanelControlesClip.Visible = False

            'Descachear los clips:
            If (clipSC1 <> "" Or clipSC2 <> "" Or rutaClipVentana <> "") Then
                clipSC1 = ""
                clipSC2 = ""
                rutaClipVentana = ""
                reTalkXML.unloadAllClips(cmdId)
            End If

            'Descargar Escena:
            Console.WriteLine("Descargando escena...")
            reTalkXML.unloadScene(escena, cmdId)
        End If

    End Sub




    Private Sub ClipPlay_Click(sender As Object, e As EventArgs) Handles ClipPlay.Click

        'Si hay un clip de vídeo, lo ponemos en Play:
        If clipSC1 <> "" Then

            'Si no se ha activado la escena, la activamos primero:
            If escenaActivada = False Then
                Module1.ActivarEscena(1)
            End If

            reTalkXML.callClipFunction(clipSC1, 1, cmdId)
            '0 - Pause
            '1 - Play
            '2 - Pause & Recue
            '3 - Recue & Play
            '4 - Rewind & Play
            '5 - Pause & Rewind
            '6 - Rewind

            'Activamos los botones Pause, Rewind y Stop
            Me.ClipPause.Enabled = True
            Me.ClipRewind.Enabled = True
            Me.ClipStop.Enabled = True

            'Desactivamos el botón Play
            Me.ClipPlay.Enabled = False
        Else
            MsgBox("Selecciona primero un clip de vídeo")
        End If

    End Sub


    Private Sub Rewind_Click(sender As Object, e As EventArgs) Handles ClipRewind.Click

        'Si hay un clip de vídeo, hacemos Rewind:
        If clipSC1 <> "" Then
            reTalkXML.callClipFunction(clipSC1, 6, cmdId)
            '0 - Pause
            '1 - Play
            '2 - Pause & Recue
            '3 - Recue & Play
            '4 - Rewind & Play
            '5 - Pause & Rewind
            '6 - Rewind

            'Activamos el botón Play:
            Me.ClipPlay.Enabled = True
        End If

    End Sub



    Private Sub BtnLoadScene_Click(sender As Object, e As EventArgs) Handles BtnLoadScene.Click

        'Abrimos la ventana para cargar la escena:
        'Dim openDialog As New OpenScene()
        'openDialog.ShowDialog()

        If escena <> "" Then
            SceneNameLabel.Text = escena

            'si hay alguna escena activa, la desactivamos y la descargamos primero:
            If escenaActivada = True Then
                'Desactivamos la escena:
                reTalkXML.unregisterAnimationCallbacks(escena, cmdId)
                Console.WriteLine("Deactivating scene...")
                reTalkXML.deactivateSceneOnSlot("Full", 1, cmdId)
                escenaActivada = False

                'Descargar Escena:
                Console.WriteLine("Descargando escena...")
                reTalkXML.unloadScene(escena, cmdId)
            End If

            Console.WriteLine("Cargando la escena actual...")
            'reTalkXML.loadScene("NewRE/scena3_new", cmdId)
            'reTalkXML.loadScene(escena, cmdId)

            'Cargar la escena para 2 salidas distintas (2 instancias de la escena):
            reTalkXML.loadSceneForOutputs(escena, 2, cmdId)

        End If

    End Sub


    Private Sub ControlPanelForm_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing

        If conectado = True Then
            'Desconectar del servidor:
            Console.WriteLine("Desconectando NRE...")
            reTalkXML.showStatisticPanel(False, cmdId)
            System.Threading.Thread.Sleep(100)
            reTalkXML.disconnect()
        End If

    End Sub

    Private Sub ClipPause_Click(sender As Object, e As EventArgs) Handles ClipPause.Click

        'Si hay un clip de vídeo, hacemos Pause:
        If clipSC1 <> "" Then
            reTalkXML.callClipFunction(clipSC1, 0, cmdId)
            '0 - Pause
            '1 - Play
            '2 - Pause & Recue
            '3 - Recue & Play
            '4 - Rewind & Play
            '5 - Pause & Rewind
            '6 - Rewind

            'Activamos el botón Play:
            Me.ClipPlay.Enabled = True
        End If

    End Sub

    Private Sub ClipStop_Click(sender As Object, e As EventArgs) Handles ClipStop.Click

        'Si hay un clip de vídeo, hacemos Pause & Rewind:
        If clipSC1 <> "" Then
            reTalkXML.callClipFunction(clipSC1, 2, cmdId)
            '0 - Pause
            '1 - Play
            '2 - Pause & Recue
            '3 - Recue & Play
            '4 - Rewind & Play
            '5 - Pause & Rewind
            '6 - Rewind

            'Activamos el botón Play:
            Me.ClipPlay.Enabled = True
        End If

    End Sub

    Private Sub ComboTextos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTextos.SelectedIndexChanged

        'Export de texto seleccionado
        exportTextoSel = ComboTextos.SelectedItem.ToString

        'Habilitamos el botón para cargar el valor del Export:
        Me.BtnListaTextos.Enabled = True

    End Sub

    Private Sub BtnListaTextos_Click(sender As Object, e As EventArgs) Handles BtnListaTextos.Click

        'Creamos un objeto para controlar la ventana de cargar texto:
        Dim box As New RellenarExport()

        'Comprobamos si ya hay un texto en el export y lo cargamos en el campo del formulario:
        If valorExport <> "" Then
            box.NuevoTexto.Text = valorExport
        End If


        'Abrir el formulario para rellenar el texto:
        box.ShowDialog()

        If valorExport <> "" Then
            cargarTexto = True

            'cargamos el nuevo texto en el Export de la escena:
            reTalkXML.sendSceneStringExport(escena, exportTextoSel, valorExport, cmdId)
        End If

    End Sub

   

    Private Sub ComboSC1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSC1.SelectedIndexChanged

        If ComboSC1.SelectedItem = "Imagen" Then

            If (SelectImage.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                imagenSC1 = SelectImage.FileName
                LblSC1Path.Text = imagenSC1
            End If

            If imagenSC1 <> "" Then

                'Detectar si la imagen seleccionada está en G:
                Dim rutaOk As Boolean = RutaEnG(imagenSC1)

                If rutaOk = True Then

                    'MsgBox("imagenSC1: " + imagenSC1 + " - exportImagenSC1: " + exportImagenSC1 + " - exportSC1: " + exportSC1)

                    'Poner el Single Child con el valor Imagen (3):
                    reTalkXML.sendSceneIntExport(escena, exportSC1, 3, cmdId)

                    'Asignar la ruta de la imagen al Export de la escena:
                    reTalkXML.sendSceneStringExport(escena, exportImagenSC1, imagenSC1, cmdId)

                Else
                    MsgBox("Selecciona una imagen dentro de la Unidad G")
                End If

            End If

        End If

        If ComboSC1.SelectedItem = "Clip" Then

            If (SelectClip.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                clipSC1 = SelectClip.FileName
                LblSC1Path.Text = clipSC1
            End If

            If clipSC1 <> "" Then

                'Detectar si el archivo seleccionado está en G:
                Dim rutaOk As Boolean = RutaEnG(clipSC1)

                If rutaOk = True Then

                    'MsgBox("clipSC1: " + clipSC1 + " - exportClipSC1: " + exportClipSC1 + " - exportSC1: " + exportSC1)

                    'Poner el Single Child con el valor Clip (2):
                    reTalkXML.sendSceneIntExport(escena, exportSC1, 2, cmdId)

                    'Asignar la ruta del clip al Export de la escena:
                    cargarRutaClip = True
                    clipACargar = "Safe Area"
                    reTalkXML.sendSceneStringExport(escena, exportClipSC1, clipSC1, cmdId)

                    Module1.ActivarClip(clipSC1)

                Else
                    MsgBox("Selecciona un clip dentro de la Unidad G")
                End If

            End If

        End If

        If ComboSC1.SelectedItem = "Video" Then
            'Creamos un objeto para controlar la ventana de seleccionar Input:
            Dim box As New SelectInputVideo()

            'Abrir el formulario:
            box.ShowDialog()

            videoSC1 = inputSelec
            inputSelec = 0

            If videoSC1 <> 0 Then

                'MsgBox("videoSC1: " + videoSC1.ToString + " - exportVideoSC1: " + exportVideoSC1 + " - exportSC1: " + exportSC1)

                LblSC1Path.Text = "Input " + videoSC1.ToString

                'Poner el Single Child con el valor Video (1):
                reTalkXML.sendSceneIntExport(escena, exportSC1, 1, cmdId)

                'cargamos el nuevo valor del Input de Video en el Export de la escena:
                reTalkXML.sendSceneStringExport(escena, exportVideoSC1, videoSC1, cmdId)

            End If

        End If

    End Sub

    Private Sub ComboSC2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSC2.SelectedIndexChanged

        If ComboSC2.SelectedItem = "Imagen" Then

            If (SelectImage.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                imagenSC2 = SelectImage.FileName
                LblSC2Path.Text = imagenSC2
            End If

            If imagenSC2 <> "" Then

                'Detectar si la imagen seleccionada está en G:
                Dim rutaOk As Boolean = RutaEnG(imagenSC2)

                If rutaOk = True Then

                    'MsgBox("imagenSC2: " + imagenSC2 + " - exportImagenSC2: " + exportImagenSC2 + " - exportSC2: " + exportSC2)

                    'Poner el Single Child con el valor Imagen (3):
                    reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

                    'Asignar la ruta de la imagen al Export de la escena:
                    reTalkXML.sendSceneStringExport(escena, exportImagenSC2, imagenSC2, cmdId)

                Else
                    MsgBox("Selecciona una imagen dentro de la Unidad G")
                End If

            End If

        End If

        If ComboSC2.SelectedItem = "Clip" Then

            If (SelectClip.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                clipSC2 = SelectClip.FileName
                LblSC2Path.Text = clipSC2
            End If

            If clipSC2 <> "" Then

                'Detectar si la imagen seleccionada está en G:
                Dim rutaOk As Boolean = RutaEnG(clipSC2)

                If rutaOk = True Then

                    'MsgBox("clipSC2: " + clipSC2 + " - exportClipSC2: " + exportClipSC2 + " - exportSC2: " + exportSC2)

                    'Poner el Single Child con el valor Clip (2):
                    reTalkXML.sendSceneIntExport(escena, exportSC2, 2, cmdId)

                    'Asignar la ruta del clip al Export de la escena:
                    cargarRutaClip = True
                    clipACargar = "Background"
                    reTalkXML.sendSceneStringExport(escena, exportClipSC2, clipSC2, cmdId)

                    Module1.ActivarClip(clipSC2)

                    'Ocultar el panel con los controles para el clip de la ventana:
                    Me.LblControlesClip.Visible = False
                    Me.PanelControlesClip.Visible = False

                    clipVentanaCargado = False

                Else
                    MsgBox("Selecciona un clip dentro de la Unidad G")
                End If

            End If

        End If

        If ComboSC2.SelectedItem = "Video" Then
            'Creamos un objeto para controlar la ventana de seleccionar Input:
            Dim box As New SelectInputVideo()

            'Abrir el formulario:
            box.ShowDialog()

            videoSC2 = inputSelec
            inputSelec = 0

            If videoSC2 <> 0 Then

                'MsgBox("videoSC2: " + videoSC2.ToString + " - exportVideoSC2: " + exportVideoSC2 + " - exportSC2: " + exportSC2)

                LblSC2Path.Text = "Input " + videoSC2.ToString

                'Poner el Single Child con el valor Video (1):
                reTalkXML.sendSceneIntExport(escena, exportSC2, 1, cmdId)

                'cargamos el nuevo valor del Input de Video en el Export de la escena:
                reTalkXML.sendSceneStringExport(escena, exportVideoSC2, videoSC2, cmdId)

            End If

        End If

    End Sub

    Private Sub ClipPlay2_Click(sender As Object, e As EventArgs) Handles ClipPlay2.Click

        If clipVentanaCargado = False Then

            'El clip que controlamos es el del Foreground

            'Si hay un clip de vídeo, lo ponemos en Play:
            If clipSC2 <> "" Then

                'Si no se ha activado la escena, la activamos primero:
                If escenaActivada = False Then
                    Module1.ActivarEscena(1)
                End If

                reTalkXML.callClipFunction(clipSC2, 1, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos los botones Pause, Rewind y Stop
                Me.ClipPause2.Enabled = True
                Me.ClipRewind2.Enabled = True
                Me.ClipStop2.Enabled = True

                'Desactivamos el botón Play
                Me.ClipPlay2.Enabled = False
            Else
                MsgBox("Selecciona primero un clip de vídeo")
            End If

        Else

            'El clip que vamos a controlar es el de la ventana

            'Si hay un clip de vídeo, lo ponemos en Play:
            If rutaClipVentana <> "" Then

                'Si no se ha activado la escena, la activamos primero:
                If escenaActivada = False Then
                    Module1.ActivarEscena(1)
                End If

                reTalkXML.callClipFunction(rutaClipVentana, 1, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos los botones Pause, Rewind y Stop
                Me.ClipPause2.Enabled = True
                Me.ClipRewind2.Enabled = True
                Me.ClipStop2.Enabled = True

                'Desactivamos el botón Play
                Me.ClipPlay2.Enabled = False
            Else
                MsgBox("Selecciona primero un clip de vídeo")
            End If

        End If

    End Sub

    Private Sub ClipPause2_Click(sender As Object, e As EventArgs) Handles ClipPause2.Click

        If clipVentanaCargado = False Then

            'Controlamos el clip de Foreground:

            'Si hay un clip de vídeo, hacemos Pause:
            If clipSC2 <> "" Then
                reTalkXML.callClipFunction(clipSC2, 0, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos el botón Play:
                Me.ClipPlay2.Enabled = True
            End If

        Else

            'Controlamos el clip de la ventana:

            'Si hay un clip de vídeo, hacemos Pause:
            If rutaClipVentana <> "" Then
                reTalkXML.callClipFunction(rutaClipVentana, 0, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos el botón Play:
                Me.ClipPlay2.Enabled = True
            End If

        End If

    End Sub

    Private Sub ClipRewind2_Click(sender As Object, e As EventArgs) Handles ClipRewind2.Click

        If clipVentanaCargado = False Then

            'Controlamos el clip de Foreground

            'Si hay un clip de vídeo, hacemos Rewind:
            If clipSC2 <> "" Then
                reTalkXML.callClipFunction(clipSC2, 6, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos el botón Play:
                Me.ClipPlay2.Enabled = True
            End If

        Else

            'Controlamos el clip de la ventana

            'Si hay un clip de vídeo, hacemos Rewind:
            If rutaClipVentana <> "" Then
                reTalkXML.callClipFunction(rutaClipVentana, 6, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos el botón Play:
                Me.ClipPlay2.Enabled = True
            End If

        End If

    End Sub

    Private Sub ClipStop2_Click(sender As Object, e As EventArgs) Handles ClipStop2.Click

        If clipVentanaCargado = False Then

            'Controlamos el clip de Foreground

            'Si hay un clip de vídeo, hacemos Pause & Rewind:
            If clipSC2 <> "" Then
                reTalkXML.callClipFunction(clipSC2, 2, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos el botón Play:
                Me.ClipPlay2.Enabled = True
            End If

        Else

            'Controlamos el clip de la ventana

            'Si hay un clip de vídeo, hacemos Pause & Rewind:
            If rutaClipVentana <> "" Then
                reTalkXML.callClipFunction(rutaClipVentana, 2, cmdId)
                '0 - Pause
                '1 - Play
                '2 - Pause & Recue
                '3 - Recue & Play
                '4 - Rewind & Play
                '5 - Pause & Rewind
                '6 - Rewind

                'Activamos el botón Play:
                Me.ClipPlay2.Enabled = True
            End If

        End If

    End Sub

    Private Sub BtnMostrarDatos_Click(sender As Object, e As EventArgs) Handles BtnMostrarDatos.Click

        If SceneDataPanel.Visible = True Then
            SceneDataPanel.Visible = False
        Else
            SceneDataPanel.Visible = True
        End If

    End Sub

    Private Sub BtnMostrarAnim_Click(sender As Object, e As EventArgs) Handles BtnMostrarAnim.Click

        'Abrir el formulario:
        boxAnimaciones.ShowDialog()

    End Sub



    Private Sub CargarInputVentana(ByRef num As Integer)

        If ((escenaCargada = True) And (operacion = "PVW")) Then

            Dim ventanaInputs As New SelectInputVideo
            ventanaInputs.ShowDialog()

            If itemSel = True Then

                'Se ha seleccionado una línea de vídeo en la ventana:

                Select Case num
                    Case 1
                        V1Texto.Text = "Input " + inputSelec.ToString
                        Module1.SetInputVentana(scVentana1, inputV1name, inputSelec)
                        'guardar entrada para PGM
                        entrada1video = inputSelec
                    Case 2
                        V2Texto.Text = "Input " + inputSelec.ToString
                        Module1.SetInputVentana(scVentana2, inputV2name, inputSelec)
                        'guardar entrada para PGM
                        entrada2video = inputSelec
                    Case 3
                        V3Texto.Text = "Input " + inputSelec.ToString
                        Module1.SetInputVentana(scVentana3, inputV3name, inputSelec)
                        'guardar entrada para PGM
                        entrada3video = inputSelec
                    Case 4
                        V4Texto.Text = "Input " + inputSelec.ToString
                        Module1.SetInputVentana(scVentana4, inputV4name, inputSelec)
                        'guardar entrada para PGM
                        entrada4video = inputSelec
                End Select

                itemSel = False

            Else
                'Se ha seleccionado un clip en lugar de una línea de vídeo:
                If clipVentana = True Then
                    If rutaClipVentana <> "" Then

                        'Detectar si el archivo seleccionado está en G:
                        Dim rutaOk As Boolean = RutaEnG(rutaClipVentana)

                        If rutaOk = True Then

                            cargarRutaClip = True

                            Select Case num
                                Case 1
                                    V1Texto.Text = "Clip"
                                    Module1.SetClipVentana(scVentana1, clipVentana1, rutaClipVentana)
                                    Module1.ActivarClip(rutaClipVentana)
                                    'guardar entrada para PGM
                                    entrada1video = ""
                                    entrada1clip = rutaClipVentana
                                Case 2
                                    V2Texto.Text = "Clip"
                                    Module1.SetClipVentana(scVentana2, clipVentana2, rutaClipVentana)
                                    Module1.ActivarClip(rutaClipVentana)
                                    'guardar entrada para PGM
                                    entrada2video = ""
                                    entrada2clip = rutaClipVentana
                                Case 3
                                    V3Texto.Text = "Clip"
                                    Module1.SetClipVentana(scVentana3, clipVentana3, rutaClipVentana)
                                    Module1.ActivarClip(rutaClipVentana)
                                    'guardar entrada para PGM
                                    entrada3video = ""
                                    entrada3clip = rutaClipVentana
                                Case 4
                                    V4Texto.Text = "Clip"
                                    Module1.SetClipVentana(scVentana4, clipVentana4, rutaClipVentana)
                                    Module1.ActivarClip(rutaClipVentana)
                                    'guardar entrada para PGM
                                    entrada4video = ""
                                    entrada4clip = rutaClipVentana
                            End Select

                            'Mostrar el panel con los controles para el clip de la ventana:
                            Me.LblControlesClip.Visible = True
                            Me.PanelControlesClip.Visible = True

                        Else
                            MsgBox("Selecciona un clip dentro de la Unidad G")
                        End If

                    End If
                    clipVentana = False
                End If
            End If

        End If

        'Pasar las entradas de las 4 ventanas a PGM:
        If ((escenaCargada = True) And (operacion = "PGM")) Then

            If entrada1video <> "" Then
                Module1.SetInputVentana(scVentana1, inputV1name, entrada1video)
            ElseIf entrada1clip <> "" Then
                Module1.SetClipVentana(scVentana1, clipVentana1, entrada1clip)
                Module1.ActivarClip(entrada1clip)
            End If

            If entrada2video <> "" Then
                Module1.SetInputVentana(scVentana2, inputV2name, entrada2video)
            Else
                Module1.SetClipVentana(scVentana2, clipVentana2, entrada2clip)
                Module1.ActivarClip(entrada2clip)
            End If

            If entrada3video <> "" Then
                Module1.SetInputVentana(scVentana3, inputV3name, entrada3video)
            Else
                Module1.SetClipVentana(scVentana3, clipVentana3, entrada3clip)
                Module1.ActivarClip(entrada3clip)
            End If

            If entrada4video <> "" Then
                Module1.SetInputVentana(scVentana4, inputV4name, entrada4video)
            Else
                Module1.SetClipVentana(scVentana4, clipVentana4, entrada4clip)
                Module1.ActivarClip(entrada4clip)
            End If

        End If

    End Sub

    Private Sub V1Texto_Click(sender As Object, e As EventArgs) Handles V1Texto.Click, Ventana1.Click, V1Lbl.Click
        CargarInputVentana(1)
    End Sub

    Private Sub V2Texto_Click(sender As Object, e As EventArgs) Handles V2Texto.Click, Ventana2.Click, V2Lbl.Click
        CargarInputVentana(2)
    End Sub

    Private Sub V3Texto_Click(sender As Object, e As EventArgs) Handles V3Texto.Click, Ventana3.Click, V3Lbl.Click
        CargarInputVentana(3)
    End Sub

    Private Sub V4Texto_Click(sender As Object, e As EventArgs) Handles V4Texto.Click, Ventana4.Click, V4Lbl.Click
        CargarInputVentana(4)
    End Sub

    Private Sub TransSelect()

        'Comprobamos qué transición está seleccionada:
        If TransCut.Checked = True Then
            transSeleccionada = True
            transSeleccionadaNombre = TransCut.Name
        ElseIf TransDisolve.Checked = True Then
            transSeleccionada = True
            transSeleccionadaNombre = TransDisolve.Name
        ElseIf TransLaVoz.Checked = True Then
            transSeleccionada = True
            transSeleccionadaNombre = TransLaVoz.Name
        End If

    End Sub

    Private Sub TransSelect2()

        'Comprobamos qué transición está seleccionada:
        If TransCut2.Checked = True Then
            transSeleccionada2 = True
            transSeleccionadaNombre2 = TransCut2.Name
        ElseIf TransDisolve2.Checked = True Then
            transSeleccionada2 = True
            transSeleccionadaNombre2 = TransDisolve2.Name
        ElseIf TransLaVoz2.Checked = True Then
            transSeleccionada2 = True
            transSeleccionadaNombre2 = TransLaVoz2.Name
        End If

    End Sub

    Private Sub BtnTrans1_2_Click(sender As Object, e As EventArgs) Handles BtnTrans1_2.Click

        'Recuperar la transición seleccionada:
        TransSelect()

        If transSeleccionada = False Then
            MsgBox("Selecciona un tipo de transición")
        Else
            'Hay una transición seleccionada:

            Dim enPrograma As String = Me.BtnTrans1_2.Text

            If (enPrograma = "1" And TransCut.Checked = True) Then
                PlayAnimacion(trans1_2Cut)
                'Cambiamos el texto del botón
                Me.BtnTrans1_2.Text = "2"
                TallyVentanas(2)
            End If

            If (enPrograma = "2" And TransCut.Checked = True) Then
                PlayAnimacion(trans2_1Cut)
                'Cambiamos el texto del botón
                Me.BtnTrans1_2.Text = "1"
                TallyVentanas(1)
            End If

            If (enPrograma = "1" And TransDisolve.Checked = True) Then
                PlayAnimacion(trans1_2Disolve)
                'Cambiamos el texto del botón
                Me.BtnTrans1_2.Text = "2"
                TallyVentanas(2)
            End If

            If (enPrograma = "2" And TransDisolve.Checked = True) Then
                PlayAnimacion(trans2_1Disolve)
                'Cambiamos el texto del botón
                Me.BtnTrans1_2.Text = "1"
                TallyVentanas(1)
            End If

            If (enPrograma = "1" And TransLaVoz.Checked = True) Then
                PlayAnimacion(trans1_2Voz)
                'Cambiamos el texto del botón
                Me.BtnTrans1_2.Text = "2"
                TallyVentanas(2)
            End If

            If (enPrograma = "2" And TransLaVoz.Checked = True) Then
                PlayAnimacion(trans2_1Voz)
                'Cambiamos el texto del botón
                Me.BtnTrans1_2.Text = "1"
                TallyVentanas(1)
            End If

        End If

        If TransAll.Checked = True Then

            'Si Trans All está activo, hacemos la transición de las 4 ventanas a la vez:

            'Recuperar la transición seleccionada:
            TransSelect2()

            If transSeleccionada2 = False Then
                MsgBox("Selecciona un tipo de transición")
            Else
                'Hay una transición seleccionada:

                Dim enPrograma As String = Me.BtnTrans3_4.Text

                If (enPrograma = "3" And TransCut2.Checked = True) Then
                    PlayAnimacion(trans3_4Cut)
                    'Cambiamos el texto del botón
                    Me.BtnTrans3_4.Text = "4"
                    TallyVentanas(4)
                End If

                If (enPrograma = "4" And TransCut2.Checked = True) Then
                    PlayAnimacion(trans4_3Cut)
                    'Cambiamos el texto del botón
                    Me.BtnTrans3_4.Text = "3"
                    TallyVentanas(3)
                End If

                If (enPrograma = "3" And TransDisolve2.Checked = True) Then
                    PlayAnimacion(trans3_4Disolve)
                    'Cambiamos el texto del botón
                    Me.BtnTrans3_4.Text = "4"
                    TallyVentanas(4)
                End If

                If (enPrograma = "4" And TransDisolve2.Checked = True) Then
                    PlayAnimacion(trans4_3Disolve)
                    'Cambiamos el texto del botón
                    Me.BtnTrans3_4.Text = "3"
                    TallyVentanas(3)
                End If

                If (enPrograma = "3" And TransLaVoz2.Checked = True) Then
                    PlayAnimacion(trans3_4Voz)
                    'Cambiamos el texto del botón
                    Me.BtnTrans3_4.Text = "4"
                    TallyVentanas(4)
                End If

                If (enPrograma = "4" And TransLaVoz2.Checked = True) Then
                    PlayAnimacion(trans4_3Voz)
                    'Cambiamos el texto del botón
                    Me.BtnTrans3_4.Text = "3"
                    TallyVentanas(3)
                End If
            End If

        End If

    End Sub

    Private Sub BtnTrans3_4_Click(sender As Object, e As EventArgs) Handles BtnTrans3_4.Click

        'Recuperar la transición seleccionada:
        TransSelect2()

        If transSeleccionada2 = False Then
            MsgBox("Selecciona un tipo de transición")
        Else
            'Hay una transición seleccionada:

            Dim enPrograma As String = Me.BtnTrans3_4.Text

            If (enPrograma = "3" And TransCut2.Checked = True) Then
                PlayAnimacion(trans3_4Cut)
                'Cambiamos el texto del botón
                Me.BtnTrans3_4.Text = "4"
                TallyVentanas(4)
            End If

            If (enPrograma = "4" And TransCut2.Checked = True) Then
                PlayAnimacion(trans4_3Cut)
                'Cambiamos el texto del botón
                Me.BtnTrans3_4.Text = "3"
                TallyVentanas(3)
            End If

            If (enPrograma = "3" And TransDisolve2.Checked = True) Then
                PlayAnimacion(trans3_4Disolve)
                'Cambiamos el texto del botón
                Me.BtnTrans3_4.Text = "4"
                TallyVentanas(4)
            End If

            If (enPrograma = "4" And TransDisolve2.Checked = True) Then
                PlayAnimacion(trans4_3Disolve)
                'Cambiamos el texto del botón
                Me.BtnTrans3_4.Text = "3"
                TallyVentanas(3)
            End If

            If (enPrograma = "3" And TransLaVoz2.Checked = True) Then
                PlayAnimacion(trans3_4Voz)
                'Cambiamos el texto del botón
                Me.BtnTrans3_4.Text = "4"
                TallyVentanas(4)
            End If

            If (enPrograma = "4" And TransLaVoz2.Checked = True) Then
                PlayAnimacion(trans4_3Voz)
                'Cambiamos el texto del botón
                Me.BtnTrans3_4.Text = "3"
                TallyVentanas(3)
            End If
        End If

        If TransAll.Checked = True Then

            'Si Trans All está seleccionado, hacemos la transición de las 4 ventanas a la vez:
            'Recuperar la transición seleccionada:
            TransSelect()

            If transSeleccionada = False Then
                MsgBox("Selecciona un tipo de transición")
            Else
                'Hay una transición seleccionada:

                Dim enPrograma As String = Me.BtnTrans1_2.Text

                If (enPrograma = "1" And TransCut.Checked = True) Then
                    PlayAnimacion(trans1_2Cut)
                    'Cambiamos el texto del botón
                    Me.BtnTrans1_2.Text = "2"
                    TallyVentanas(2)
                End If

                If (enPrograma = "2" And TransCut.Checked = True) Then
                    PlayAnimacion(trans2_1Cut)
                    'Cambiamos el texto del botón
                    Me.BtnTrans1_2.Text = "1"
                    TallyVentanas(1)
                End If

                If (enPrograma = "1" And TransDisolve.Checked = True) Then
                    PlayAnimacion(trans1_2Disolve)
                    'Cambiamos el texto del botón
                    Me.BtnTrans1_2.Text = "2"
                    TallyVentanas(2)
                End If

                If (enPrograma = "2" And TransDisolve.Checked = True) Then
                    PlayAnimacion(trans2_1Disolve)
                    'Cambiamos el texto del botón
                    Me.BtnTrans1_2.Text = "1"
                    TallyVentanas(1)
                End If

                If (enPrograma = "1" And TransLaVoz.Checked = True) Then
                    PlayAnimacion(trans1_2Voz)
                    'Cambiamos el texto del botón
                    Me.BtnTrans1_2.Text = "2"
                    TallyVentanas(2)
                End If

                If (enPrograma = "2" And TransLaVoz.Checked = True) Then
                    PlayAnimacion(trans2_1Voz)
                    'Cambiamos el texto del botón
                    Me.BtnTrans1_2.Text = "1"
                    TallyVentanas(1)
                End If

            End If

        End If

    End Sub

    Private Sub TallyVentanas(ByRef num As Integer)

        Select Case num
            Case 1
                TallyVentana1.Visible = True
                TallyVentana2.Visible = False
            Case 2
                TallyVentana2.Visible = True
                TallyVentana1.Visible = False
            Case 3
                TallyVentana3.Visible = True
                TallyVentana4.Visible = False
            Case 4
                TallyVentana4.Visible = True
                TallyVentana3.Visible = False
        End Select

    End Sub

    Private Sub TallyReset()
        TallyVentana1.Visible = False
        TallyVentana2.Visible = False
        TallyVentana3.Visible = False
        TallyVentana4.Visible = False
    End Sub

    Private Sub TransCut_CheckedChanged(sender As Object, e As EventArgs) Handles TransCut.CheckedChanged

        Me.TransCut.BackColor = Drawing.Color.LightSeaGreen
        Me.TransDisolve.BackColor = Drawing.Color.Lavender
        Me.TransLaVoz.BackColor = Drawing.Color.Lavender

        Me.TransCut.ForeColor = Drawing.Color.White
        Me.TransDisolve.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransLaVoz.ForeColor = Drawing.Color.DarkSlateGray

    End Sub

    Private Sub TransDisolve_CheckedChanged(sender As Object, e As EventArgs) Handles TransDisolve.CheckedChanged

        Me.TransCut.BackColor = Drawing.Color.Lavender
        Me.TransDisolve.BackColor = Drawing.Color.LightSeaGreen
        Me.TransLaVoz.BackColor = Drawing.Color.Lavender

        Me.TransCut.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransDisolve.ForeColor = Drawing.Color.White
        Me.TransLaVoz.ForeColor = Drawing.Color.DarkSlateGray

    End Sub

    Private Sub TransLaVoz_CheckedChanged(sender As Object, e As EventArgs) Handles TransLaVoz.CheckedChanged

        Me.TransCut.BackColor = Drawing.Color.Lavender
        Me.TransDisolve.BackColor = Drawing.Color.Lavender
        Me.TransLaVoz.BackColor = Drawing.Color.LightSeaGreen

        Me.TransCut.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransDisolve.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransLaVoz.ForeColor = Drawing.Color.White

    End Sub

    Private Sub TransCut2_CheckedChanged(sender As Object, e As EventArgs) Handles TransCut2.CheckedChanged

        Me.TransCut2.BackColor = Drawing.Color.LightSeaGreen
        Me.TransDisolve2.BackColor = Drawing.Color.Lavender
        Me.TransLaVoz2.BackColor = Drawing.Color.Lavender

        Me.TransCut2.ForeColor = Drawing.Color.White
        Me.TransDisolve2.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransLaVoz2.ForeColor = Drawing.Color.DarkSlateGray

    End Sub

    Private Sub TransDisolve2_CheckedChanged(sender As Object, e As EventArgs) Handles TransDisolve2.CheckedChanged

        Me.TransCut2.BackColor = Drawing.Color.Lavender
        Me.TransDisolve2.BackColor = Drawing.Color.LightSeaGreen
        Me.TransLaVoz2.BackColor = Drawing.Color.Lavender

        Me.TransCut2.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransDisolve2.ForeColor = Drawing.Color.White
        Me.TransLaVoz2.ForeColor = Drawing.Color.DarkSlateGray

    End Sub

    Private Sub TransLaVoz2_CheckedChanged(sender As Object, e As EventArgs) Handles TransLaVoz2.CheckedChanged

        Me.TransCut2.BackColor = Drawing.Color.Lavender
        Me.TransDisolve2.BackColor = Drawing.Color.Lavender
        Me.TransLaVoz2.BackColor = Drawing.Color.LightSeaGreen

        Me.TransCut2.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransDisolve2.ForeColor = Drawing.Color.DarkSlateGray
        Me.TransLaVoz2.ForeColor = Drawing.Color.White

    End Sub

    Private Sub PlayAnimacion(ByRef nombre As String)

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

    Private Sub TransAll_CheckedChanged(sender As Object, e As EventArgs) Handles TransAll.CheckedChanged

        If TransAll.Checked = True Then
            TransAll.BackColor = Drawing.Color.Red
            TransAll.ForeColor = Drawing.Color.White
        Else
            TransAll.BackColor = Drawing.Color.Lavender
            TransAll.ForeColor = Drawing.Color.DarkSlateGray
        End If

    End Sub

    Private Sub BtnConroles_Click(sender As Object, e As EventArgs) Handles BtnConroles.Click

        If PanelControles.Visible = True Then
            PanelControles.Visible = False
            LabelControles.Visible = False
        Else
            PanelControles.Visible = True
            LabelControles.Visible = True
        End If

    End Sub

    Private Sub CheckControlesFull_CheckedChanged(sender As Object, e As EventArgs) Handles CheckControlesFull.CheckedChanged

        If CheckControlesFull.Checked = True Then
            DesactivarCheckControles("full")
            CheckControlesFull.BackColor = Drawing.Color.DarkSlateGray
            CheckControlesFull.ForeColor = Drawing.Color.Lavender
        Else
            CheckControlesFull.BackColor = Drawing.Color.Lavender
            CheckControlesFull.ForeColor = Drawing.Color.DarkSlateGray
        End If

        If CheckControlesFull.Checked = True Then
            grupoParaControles = "full"
            'Recuperamos el utimo valor guardado de posición y escala de las ventanas:
            IniciarControles("full")
        Else
            grupoParaControles = ""
        End If

    End Sub

    Private Sub DesactivarCheckControles(ByRef activo As String)

        If activo = "full" Then

            CheckControlesBg.BackColor = Drawing.Color.Lavender
            CheckControlesBg.ForeColor = Drawing.Color.DarkSlateGray
            CheckControles1_2.BackColor = Drawing.Color.Lavender
            CheckControles1_2.ForeColor = Drawing.Color.DarkSlateGray
            CheckControles3_4.BackColor = Drawing.Color.Lavender
            CheckControles3_4.ForeColor = Drawing.Color.DarkSlateGray

            CheckControlesBg.Checked = False
            CheckControles1_2.Checked = False
            CheckControles3_4.Checked = False
        End If

        If activo = "bg" Then

            CheckControlesFull.BackColor = Drawing.Color.Lavender
            CheckControlesFull.ForeColor = Drawing.Color.DarkSlateGray
            CheckControles1_2.BackColor = Drawing.Color.Lavender
            CheckControles1_2.ForeColor = Drawing.Color.DarkSlateGray
            CheckControles3_4.BackColor = Drawing.Color.Lavender
            CheckControles3_4.ForeColor = Drawing.Color.DarkSlateGray

            CheckControlesFull.Checked = False
            CheckControles1_2.Checked = False
            CheckControles3_4.Checked = False
        End If

        If activo = "1-2" Then

            CheckControlesBg.BackColor = Drawing.Color.Lavender
            CheckControlesBg.ForeColor = Drawing.Color.DarkSlateGray
            CheckControlesFull.BackColor = Drawing.Color.Lavender
            CheckControlesFull.ForeColor = Drawing.Color.DarkSlateGray
            CheckControles3_4.BackColor = Drawing.Color.Lavender
            CheckControles3_4.ForeColor = Drawing.Color.DarkSlateGray

            CheckControlesBg.Checked = False
            CheckControlesFull.Checked = False
            CheckControles3_4.Checked = False
        End If

        If activo = "3-4" Then

            CheckControlesBg.BackColor = Drawing.Color.Lavender
            CheckControlesBg.ForeColor = Drawing.Color.DarkSlateGray
            CheckControles1_2.BackColor = Drawing.Color.Lavender
            CheckControles1_2.ForeColor = Drawing.Color.DarkSlateGray
            CheckControlesFull.BackColor = Drawing.Color.Lavender
            CheckControlesFull.ForeColor = Drawing.Color.DarkSlateGray

            CheckControlesBg.Checked = False
            CheckControles1_2.Checked = False
            CheckControlesFull.Checked = False
        End If

    End Sub

    Private Sub CheckControles1_2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckControles1_2.CheckedChanged

        If CheckControles1_2.Checked = True Then
            DesactivarCheckControles("1-2")
            CheckControles1_2.BackColor = Drawing.Color.DarkSlateGray
            CheckControles1_2.ForeColor = Drawing.Color.Lavender
        Else
            CheckControles1_2.BackColor = Drawing.Color.Lavender
            CheckControles1_2.ForeColor = Drawing.Color.DarkSlateGray
        End If

        If CheckControles1_2.Checked = True Then
            grupoParaControles = "1-2"
            'Cargamos los valores iniciales de posición de estala de las ventanas 1 y 2:
            IniciarControles("1-2")
        Else
            grupoParaControles = ""
        End If

    End Sub

    Private Sub CheckControles3_4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckControles3_4.CheckedChanged

        If CheckControles3_4.Checked = True Then
            DesactivarCheckControles("3-4")
            CheckControles3_4.BackColor = Drawing.Color.DarkSlateGray
            CheckControles3_4.ForeColor = Drawing.Color.Lavender
        Else
            CheckControles3_4.BackColor = Drawing.Color.Lavender
            CheckControles3_4.ForeColor = Drawing.Color.DarkSlateGray
        End If

        If CheckControles3_4.Checked = True Then
            grupoParaControles = "3-4"
            'Cargamos los valores iniciales posición y escala ventanas 3 y 4:
            IniciarControles("3-4")
        Else
            grupoParaControles = ""
        End If

    End Sub

    Private Sub CheckControlesBg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckControlesBg.CheckedChanged

        If CheckControlesBg.Checked = True Then
            DesactivarCheckControles("bg")
            CheckControlesBg.BackColor = Drawing.Color.DarkSlateGray
            CheckControlesBg.ForeColor = Drawing.Color.Lavender
        Else
            CheckControlesBg.BackColor = Drawing.Color.Lavender
            CheckControlesBg.ForeColor = Drawing.Color.DarkSlateGray
        End If

        If CheckControlesBg.Checked = True Then
            grupoParaControles = "bg"
            'Recuperamos el valor inicial de posición y escala de las ventanas:
            IniciarControles("bg")
        Else
            grupoParaControles = ""
        End If

    End Sub

    Private Sub BarPosX_Scroll(sender As Object, e As Windows.Forms.ScrollEventArgs) Handles BarPosX.Scroll

        'aplicamos un factor de división al valor de la barra, que va de -200 a 200
        Dim valor As Double = BarPosX.Value / 50
        Dim valorString As String = valor.ToString

        Select Case grupoParaControles
            Case "full"
                reTalkXML.sendSceneStringExport(escena, exportGrupoPosX, valorString, cmdId)
            Case "bg"
                reTalkXML.sendSceneStringExport(escena, exportBackgroundPosX, valorString, cmdId)
            Case "1-2"
                reTalkXML.sendSceneStringExport(escena, exportVentanas12PosX, valorString, cmdId)
            Case "3-4"
                reTalkXML.sendSceneStringExport(escena, exportVentanas34PosX, valorString, cmdId)
        End Select

    End Sub


    Private Sub BarPosY_Scroll(sender As Object, e As Windows.Forms.ScrollEventArgs) Handles BarPosY.Scroll

        'Cambiamos el signo del valor en la barra:
        Dim valorInv As Integer = BarPosY.Value * -1
        'aplicamos un factor de división al valor de la barra, que va de -200 a 200
        Dim valor As Double = valorInv / 50
        Dim valorString As String = valor.ToString

        Select Case grupoParaControles
            Case "full"
                reTalkXML.sendSceneStringExport(escena, exportGrupoPosY, valorString, cmdId)
            Case "bg"
                reTalkXML.sendSceneStringExport(escena, exportBackgroundPosY, valorString, cmdId)
            Case "1-2"
                reTalkXML.sendSceneStringExport(escena, exportVentanas12PosY, valorString, cmdId)
            Case "3-4"
                reTalkXML.sendSceneStringExport(escena, exportVentanas34PosY, valorString, cmdId)
        End Select

    End Sub

    Private Sub BarEscala_Scroll(sender As Object, e As Windows.Forms.ScrollEventArgs) Handles BarEscala.Scroll

        'Aplicamos un factor de división:
        Dim valor As Double = BarEscala.Value / 100
        Dim valorString As String = valor.ToString

        Select Case grupoParaControles
            Case "full"
                reTalkXML.sendSceneStringExport(escena, exportGrupoEscala, valorString, cmdId)
            Case "bg"
                reTalkXML.sendSceneStringExport(escena, exportBackgroundEscala, valorString, cmdId)
            Case "1-2"
                reTalkXML.sendSceneStringExport(escena, exportVentanas12Escala, valorString, cmdId)
            Case "3-4"
                reTalkXML.sendSceneStringExport(escena, exportVentanas34Escala, valorString, cmdId)
        End Select

    End Sub

    Private Sub BtnInitControles_Click(sender As Object, e As EventArgs) Handles BtnInitControles.Click


        Me.BarPosX.Value = grupoPosInicialX * 50
        Me.BarPosY.Value = grupoPosInicialY * -50
        Me.BarEscala.Value = grupoEscalaInicial * 100
        'Escribir los valores en los exports:
        reTalkXML.sendSceneFloatExport(escena, exportGrupoPosX, grupoPosInicialX, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportGrupoPosY, grupoPosInicialY, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportGrupoEscala, grupoEscalaInicial, cmdId)

        reTalkXML.sendSceneFloatExport(escena, exportBackgroundPosX, backgroundPosInicialX, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportBackgroundPosY, backgroundPosInicialY, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportBackgroundEscala, backgroundEscalaInicial, cmdId)

        reTalkXML.sendSceneFloatExport(escena, exportVentanas12PosX, ventanas12PosInicialX, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportVentanas12PosY, ventanas12PosInicialY, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportVentanas12Escala, ventanas12EscalaInicial, cmdId)

        reTalkXML.sendSceneFloatExport(escena, exportVentanas34PosX, ventanas34PosInicialX, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportVentanas34PosY, ventanas34PosInicialY, cmdId)
        reTalkXML.sendSceneFloatExport(escena, exportVentanas34Escala, ventanas34EscalaInicial, cmdId)


    End Sub

    Private Sub Btn1Ventana_Click(sender As Object, e As EventArgs) Handles Btn1Ventana.Click

        ventanas = 1

        Me.Btn1Ventana.Enabled = False
        Me.Btn2Ventanas.Enabled = True

        'Quitar las ventanas. Export visibilidad = 0
        reTalkXML.sendSceneIntExport(escena, visiBarra, 0, cmdId)
        reTalkXML.sendSceneIntExport(escena, visiVentanasExport, 0, cmdId)


        'Canviar PNG background:

        'Poner el Single Child con el valor Imagen (3):
        reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

        'Asignar la ruta de la imagen al Export del foreground:
        If CheckKids.Checked = False Then
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img1ventana, cmdId)
        Else
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img1ventanaKids, cmdId)
        End If

    End Sub

    Private Sub Btn2Ventanas_Click(sender As Object, e As EventArgs) Handles Btn2Ventanas.Click

        ventanas = 2

        Me.Btn2Ventanas.Enabled = False
        Me.Btn1Ventana.Enabled = True

        'Mostrar las ventanas. Export visibilidad = 1
        reTalkXML.sendSceneIntExport(escena, visiVentanasExport, 1, cmdId)
        reTalkXML.sendSceneIntExport(escena, visiBarra, 1, cmdId)

        'Canviar PNG background:

        'Poner el Single Child con el valor Imagen (3):
        reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

        'Asignar la ruta de la imagen al Export del foreground:
        If CheckKids.Checked = False Then
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img2ventanas, cmdId)
        Else
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img2ventanasKids, cmdId)
        End If

    End Sub

    Private Sub CheckKids_CheckedChanged(sender As Object, e As EventArgs) Handles CheckKids.CheckedChanged

        'Poner el Single Child con el valor Imagen (3):
        reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

        If CheckKids.Checked = True Then

            Select Case ventanas
                Case 1
                    reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img1ventanaKids, cmdId)
                Case 2
                    reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img2ventanasKids, cmdId)
            End Select

        Else

            Select Case ventanas
                Case 1
                    reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img1ventana, cmdId)
                Case 2
                    reTalkXML.sendSceneStringExport(escena, exportImagenSC2, img2ventanas, cmdId)
            End Select

        End If

    End Sub

    Private Sub BtnFGTrans_Click(sender As Object, e As EventArgs) Handles BtnFGTrans.Click

        If transicion34 = False Then
            'Está visible el panel de imágenes del Foreground
            Me.PanelForeground.Visible = False
            Me.TransGrupo2.Visible = True
            transicion34 = True
            Me.BtnFGTrans.Text = "Imagen FG"
        Else
            'Está visible el panel de transiciones 3 - 4
            Me.PanelForeground.Visible = True
            Me.TransGrupo2.Visible = False
            transicion34 = False
            Me.BtnFGTrans.Text = "Transiciones 3 - 4"
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If Me.RadioButton1.Checked = True Then
            imagenSC2 = imgBoton01
            LblSC2Path.Text = imagenSC2

            'Poner el Single Child del Foreground con el valor Imagen (3):
            reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

            'Asignar la ruta de la imagen al Export de la escena:
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, imagenSC2, cmdId)
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If Me.RadioButton2.Checked = True Then
            imagenSC2 = imgBoton02
            LblSC2Path.Text = imagenSC2

            'Poner el Single Child del Foreground con el valor Imagen (3):
            reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

            'Asignar la ruta de la imagen al Export de la escena:
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, imagenSC2, cmdId)
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If Me.RadioButton3.Checked = True Then
            imagenSC2 = imgBoton03
            LblSC2Path.Text = imagenSC2

            'Poner el Single Child del Foreground con el valor Imagen (3):
            reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

            'Asignar la ruta de la imagen al Export de la escena:
            reTalkXML.sendSceneStringExport(escena, exportImagenSC2, imagenSC2, cmdId)
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

        If Me.RadioButton4.Checked = True Then

            'Abrir el formulario:
            boxLoadImage.ShowDialog()

            If cargarImagen4 = True Then
                imagenSC2 = imgBoton04
                LblSC2Path.Text = imagenSC2

                'Poner el Single Child del Foreground con el valor Imagen (3):
                reTalkXML.sendSceneIntExport(escena, exportSC2, 3, cmdId)

                'Asignar la ruta de la imagen al Export de la escena:
                reTalkXML.sendSceneStringExport(escena, exportImagenSC2, imagenSC2, cmdId)
            End If

        End If

    End Sub

    Private Sub BtnTrans_Click(sender As Object, e As EventArgs) Handles BtnTrans.Click

        operacion = "PGM"
        reTalkXML.setDefaultOutput(0, cmdId)

        'Cargamos la escena en PVW (1)
        ActivarEscena(0)

        'Cargar los valores para las ventanas que tenemos en PVW
        CargarInputVentana(1)

        'Rebobinar las animaciones
        CargarAnimaciones(Module1.animaciones)

        'Volver a poner la variable en PVW y la salida 1
        operacion = "PVW"
        reTalkXML.setDefaultOutput(1, cmdId)

    End Sub
End Class