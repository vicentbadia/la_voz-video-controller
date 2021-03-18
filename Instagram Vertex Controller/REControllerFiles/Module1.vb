Public Module Module1


    Public WithEvents reTalkXML As ReTalkXMLLib.ReTalkXMLAx
    Public cmdId As Integer

    'Var para detectar si la app está conectada al servidor
    Public conectado As Boolean = False

    'Var para detectar si la escena está cargada
    Public escenaCargada As Boolean = False

    'Boolean para seleccionar si queremos que la escena se active automáticamente al cargarla:
    Public cargaAutomatica As Boolean = True

    'Var para detectar si la escena está activada
    Public escenaActivada As Boolean = False


    'Ruta de la Escena:
    Public escena As String = "Instagram/Instagram_Vertex3"

    'IP de conexión
    Public IP As String = "10.30.5.185"

    'Exports de la escena:
    Public exports As Object
    'Tipos de cada export de la escena:
    Public tiposExports As Object

    'Animaciones de la escena:
    Public animaciones As Object

    'Nombre de las animaciones:
    Public anim01 As String
    Public anim02 As String
    Public anim03 As String
    Public anim04 As String

    'Animaciones seleccionadas en los combos:
    Public animINsel As String = ""
    Public animOUTsel As String = ""
    Public animOtrasSel As String = ""

    'Num total de animaciones:
    Public totalAnim As Integer = 0

    'Tipo de animación: entrada, salida, otra:
    Public tipoAnim As String = "Otra"

    'Total textos en los Exports:
    Public totalTextos As Integer = 0

    'Export de texto seleccionado en el dropdown list:
    Public exportTextoSel As String = ""

    'Nombre del Export Texto:
    Public nombreTexto01 As String = ""
    Public nombreTexto02 As String = ""
    'Variable para guardar el valor del texto de la animación
    Public valorExport As String = ""


    'Num de ventana:
    Public ventanaNum As Integer = 0

    'Exports Single Child fondos (Safe Area / Instagram):
    Public exportSC1 As String = ""
    Public exportSC2 As String = ""

    Public exportImagenSC1 As String = "Texture_Background_Safe_Area_Image_Load"
    Public exportClipSC1 As String = "Texture_Background_Safe_Area_Clip_ClipParam_Name"
    Public exportVideoSC1 As String = "Texture_Background_Safe_Area_Linea_MappingImage_Video_Nr"

    Public exportImagenSC2 As String = "Texture_Background_Instagram_Image_Load"
    Public exportClipSC2 As String = "Texture_Background_Instagram-001_ClipParam_Name"
    Public exportVideoSC2 As String = "Texture_Background_Instagram_MappingImage_Video_Nr"

    'Imagenes fondos Single Child:
    Public imagenSC1 As String = ""
    Public imagenSC2 As String = ""

    'Path clip fondos Single Child:
    Public clipSC1 As String = ""
    Public clipSC2 As String = ""

    'Línea de vídeo fondos Single Child:
    Public videoSC1 As Integer = 0
    Public videoSC2 As Integer = 0




    'Nombre SINGLE CHILD VENTANAS
    Public scVentana1 As String = "WIN01_SC"
    Public scVentana2 As String = "WIN02_SC"
    Public scVentana3 As String = "WIN03_SC"
    Public scVentana4 As String = "WIN04_SC"

    'Líneas de vídeo de las ventanas. Nombre exports:
    Public inputV1name As String = "Texture_Windows_001_MappingImage_Video_Nr"
    Public inputV2name As String = "Texture_Windows_002_MappingImage_Video_Nr"
    Public inputV3name As String = "Texture_Windows_003_MappingImage_Video_Nr"
    Public inputV4name As String = "Texture_Windows_004_MappingImage_Video_Nr"

    'Export clip de las ventanas:
    Public clipVentana1 As String = "WIN01_CLIP_RUTA"
    Public clipVentana2 As String = "WIN02_CLIP_RUTA"
    Public clipVentana3 As String = "WIN03_CLIP_RUTA"
    Public clipVentana4 As String = "WIN04_CLIP_RUTA"

    'Export imagen de las ventanas:
    Public imgVentana1 As String = "WIN01_IMAGE"
    Public imgVentana2 As String = "WIN02_IMAGE"
    Public imgVentana3 As String = "WIN03_IMAGE"
    Public imgVentana4 As String = "WIN04_IMAGE"



    'Var para la linea de video seleccionada en el formulario Select Input Video
    Public inputSelec As Integer = 0
    'Detectar si se ha seleccionado algo en la lista de Select Input Video
    Public itemSel As Boolean = False

    'Boolean True cuando cargamos el texto en el Export
    Public cargarTexto As Boolean = False
    'Boolean True cuando cargamos la ruta del clip en el Export
    Public cargarRutaClip As Boolean = False
    'Variable para detectar el clip a cargar (safety area / background):
    Public clipACargar As String = ""


    'Variable para referenciar al formulario Control Panel:
    Dim panel As New ControlPanelForm()

    'Variable para referenciar a la ventana con la lista de IPs:
    Dim listaIP As New SelectIP()


    'SELECCIÓN DE TRANSICIONES

    'Boolean para saber si hay una transición seleccionada:
    Public transSeleccionada As Boolean = False
    Public transSeleccionada2 As Boolean = False
    'Transición seleccionada:
    Public transSeleccionadaNombre As String = ""
    Public transSeleccionadaNombre2 As String = ""

    'Nombres transiciones ventanas 1-2  3-4
    Public trans1_2Cut As String = "cut_1_to_2"
    Public trans2_1Cut As String = "cut_2_to_1"
    Public trans1_2Disolve As String = "fade_1_to_2"
    Public trans2_1Disolve As String = "fade_2_to_1"
    Public trans1_2Voz As String = "voz_1_to_2"
    Public trans2_1Voz As String = "voz_2_to_1"

    Public trans3_4Cut As String = "cut_3_to_4"
    Public trans4_3Cut As String = "cut_4_to_3"
    Public trans3_4Disolve As String = "fade_3_to_4"
    Public trans4_3Disolve As String = "fade_4_to_3"
    Public trans3_4Voz As String = "voz_3_to_4"
    Public trans4_3Voz As String = "voz_4_to_3"


    'POSICIÓN INICIAL VENTANAS
    Public exportGrupoPosX As String = "Transformation_Group_Full_Position_X"
    Public exportGrupoPosY As String = "Transformation_Group_Full_Position_Y"
    Public exportGrupoEscala As String = "Transformation_Group_Full_Scale_X"

    Public grupoPosInicialX As Double = 0
    Public grupoPosInicialY As Double = 0
    Public grupoEscalaInicial As Double = 1.004

    Public grupoUltimaPosX As Double = 0
    Public grupoUltimaPosY As Double = 0
    Public grupoUltimaEscala As Double = 1.004

    Public exportBackgroundPosX As String = "Transformation_Group_Background_Instagram_Position_X"
    Public exportBackgroundPosY As String = "Transformation_Group_Background_Instagram_Position_Y"
    Public exportBackgroundEscala As String = "Transformation_Group_Background_Instagram_Scale_X"

    Public backgroundPosInicialX As Double = 0
    Public backgroundPosInicialY As Double = 0
    Public backgroundEscalaInicial As Double = 1

    Public backgroundUltimaPosX As Double = 0
    Public backgroundUltimaPosY As Double = 0
    Public backgroundUltimaEscala As Double = 1

    Public exportVentanas12PosX As String = "Transformation_Up_Windows_Position_X"
    Public exportVentanas12PosY As String = "Transformation_Up_Windows_Position_Y"
    Public exportVentanas12Escala As String = "Transformation_Up_Windows_Scale_X"

    Public ventanas12PosInicialX As Double = 0
    Public ventanas12PosInicialY As Double = -1.477
    Public ventanas12EscalaInicial As Double = 1

    Public ventanas12UltimaPosX As Double = 0
    Public ventanas12UltimaPosY As Double = -1.477
    Public ventanas12UltimaEscala As Double = 1

    Public exportVentanas34PosX As String = "Transformation_Down_Windows_Position_X"
    Public exportVentanas34PosY As String = "Transformation_Down_Windows_Position_Y"
    Public exportVentanas34Escala As String = "Transformation_Down_Windows_Scale_X"

    Public ventanas34PosInicialX As Double = 0
    Public ventanas34PosInicialY As Double = 0.114
    Public ventanas34EscalaInicial As Double = 1

    Public ventanas34UltimaPosX As Double = 0
    Public ventanas34UltimaPosY As Double = 0.114
    Public ventanas34UltimaEscala As Double = 1

    'SELECCIÓN DE VENTANAS PARA LOS CONTROLES DE ESCALA Y POSICIÓN:
    Public grupoParaControles As String = ""

    'Cargar los valores de la escena para posición y escala de las ventanas:
    Public valorInicialControles As Boolean = True

    'Boolean para definir si en la ventana se ha seleccionado un clip en lugar de una línea de vídeo:
    Public clipVentana As Boolean = False

    'Clip a cargar en la ventana:
    Public rutaClipVentana As String = ""

    Public clipVentanaCargado As Boolean = False


    'VISIBILIDAD DE LAS VENTANAS (GRUPO)
    Public visiVentanasExport As String = "VISI_VENTANAS"
    'barra central
    Public visiBarra As String = "BARRA_CENTRAL_VISI"

    'Estado de las ventanas 1 / 2:
    Public ventanas As Integer = 2

    'IMAGENES POR DEFECTO PARA EL FOREGROUND
    Public img2ventanas As String = "G:\Projects\Instagram\img\2ventanas.png"
    Public img1ventana As String = "G:\Projects\Instagram\img\1ventana.png"
    Public img2ventanasKids As String = "G:\Projects\Instagram\img\2ventanasKids.png"
    Public img1ventanaKids As String = "G:\Projects\Instagram\img\1ventanaKids.png"

    'IMAGENES POR DEFECTO PARA EL FOREGROUND - NUEVAS - BOTONES 1, 2, 3, 4
    Public imgBoton01 As String = "G:\Projects\Instagram\img2\ventana01.png"
    Public imgBoton02 As String = "G:\Projects\Instagram\img2\ventana02.png"
    Public imgBoton03 As String = "G:\Projects\Instagram\img2\ventana03.png"
    Public imgBoton04 As String = "G:\Projects\Instagram\img2\ventana04.png"

    'Confirmación para cargar la imagen 4 del foreground
    Public cargarImagen4 As Boolean = False

    'Var para diferenciar operaciones PVW y PGM
    Public operacion As String = "PVW"


    'Variables para guardar las entradas que tenemos en las 4 ventanas y poder pasarlas todas a PGM
    Public entrada1video, entrada2video, entrada3video, entrada4video As String
    Public entrada1clip, entrada2clip, entrada3clip, entrada4clip As String


    Private Sub Connected() Handles reTalkXML.ReConnected

        Console.WriteLine("Hecho!")
        'Activa el panel de estadísticas del RE:
        'reTalkXML.showStatisticPanel(True, cmdId)
        Console.WriteLine("RE Conectado")

        conectado = True

        'Descargamos todas las escenas por si se ha quedado cargada en la ejecución anterior:
        Console.WriteLine("Descargando escenas...")
        reTalkXML.unloadAllScenes(cmdId)
        Console.WriteLine("Hecho!")

        'Establecer la salida por defecto - Output 8 - PREVIO
        'Salida 0 > PGM
        'Salida 1 > PVW
        reTalkXML.setDefaultOutput(1, cmdId)

        'Abrir el panel de control:
        panel.ShowDialog()

    End Sub


    Private Sub SceneLoaded(ByVal scene As String, ByVal reCmdId As Integer) Handles reTalkXML.ReSceneLoaded
        Console.WriteLine("Hecho!")

        If operacion = "PVW" Then

            'Activamos el botón para descargar la escena:
            panel.BtnUnload.Enabled = True

            escenaCargada = True

            'Activamos los botones para modificar pos y escala de las ventanas:
            panel.CheckControlesFull.Enabled = True
            panel.CheckControlesBg.Enabled = True
            panel.CheckControles1_2.Enabled = True
            panel.CheckControles3_4.Enabled = True

            'deshabilitamos el botón para cargar escenas. lo habilitaremos cuando la escena se haya descargado:
            panel.BtnLoadScene.Enabled = False

            'iniciamos botones para 2 / 1 ventana:
            panel.Btn2Ventanas.Enabled = False
            panel.Btn1Ventana.Enabled = True
            panel.CheckKids.Enabled = True
            panel.CheckKids.Checked = False

            'Consultamos los Exports que utiliza la escena:
            reTalkXML.askForSceneExports(escena, cmdId)

        End If

    End Sub

    Private Sub reSceneExports(ByVal aScene As String, ByRef aExports As Object, ByRef aTypes As Object, ByVal aRECmdId As Integer) Handles reTalkXML.ReSceneExports

        exports = aExports
        tiposExports = aTypes

        'Llamamos al procedimiento de ControlPanelForm que carga los Exports y los tipos de los exports:
        panel.CargarExports(exports, tiposExports)


        Console.WriteLine("Valores de los Exports de la escena " + escena + " cargados")

        'Consultamos las animaciones de la escena:
        reTalkXML.askForSceneAnimations(escena, cmdId)

    End Sub

    Private Sub SceneAnimations(ByVal aScene As String, ByRef aAnims As Object, ByVal aRECmdId As Integer) Handles reTalkXML.ReSceneAnimations

        animaciones = aAnims

        'Llamamos al procedimiento de ControlPanelForm para cargar los nombres de las animaciones y activar los botones:
        panel.CargarAnimaciones(animaciones)

        If cargaAutomatica = False Then
            'Activamos de nuevo el panel de control:
            panel.Activate()
        End If

        If cargaAutomatica = True Then

            'Cargamos la escena en PVW (1)
            ActivarEscena(1)

        End If

    End Sub

    'Método que se ejecuta cuando hacemos getSceneExportValue para consultar el valor de un Export:
    Private Sub ValoresExports(ByVal escena As String, ByVal export As String, ByVal valor As String, ByVal aRECmdId As Integer) Handles reTalkXML.ReGetSceneExportValue

        If export = exportGrupoPosX Then
            If valorInicialControles = True Then
                grupoPosInicialX = valor
            End If
            grupoUltimaPosX = valor
            panel.BarPosX.Value = grupoUltimaPosX * 50  'factor de división que aplicamos a la barra
        End If
        If export = exportGrupoPosY Then
            If valorInicialControles = True Then
                grupoPosInicialY = valor
            End If
            grupoUltimaPosY = valor
            panel.BarPosY.Value = grupoUltimaPosY * -50
        End If
        If export = exportGrupoEscala Then
            If valorInicialControles = True Then
                grupoEscalaInicial = valor
            End If
            grupoUltimaEscala = valor
            panel.BarEscala.Value = grupoUltimaEscala * 100
        End If

        If export = exportBackgroundPosX Then
            If valorInicialControles = True Then
                backgroundPosInicialX = valor
            End If
            backgroundUltimaPosX = valor
            panel.BarPosX.Value = backgroundUltimaPosX * 50
        End If
        If export = exportBackgroundPosY Then
            If valorInicialControles = True Then
                backgroundPosInicialY = valor
            End If
            backgroundUltimaPosY = valor
            panel.BarPosY.Value = backgroundUltimaPosY * -50
        End If
        If export = exportBackgroundEscala Then
            If valorInicialControles = True Then
                backgroundEscalaInicial = valor
            End If
            backgroundUltimaEscala = valor
            panel.BarEscala.Value = backgroundUltimaEscala * 100
        End If

        If export = exportVentanas12PosX Then
            If valorInicialControles = True Then
                ventanas12PosInicialX = valor
            End If
            ventanas12UltimaPosX = valor
            panel.BarPosX.Value = ventanas12UltimaPosX * 50
        End If
        If export = exportVentanas12PosY Then
            If valorInicialControles = True Then
                ventanas12PosInicialY = valor
            End If
            ventanas12UltimaPosY = valor
            panel.BarPosY.Value = ventanas12UltimaPosY * -50
        End If
        If export = exportVentanas12Escala Then
            If valorInicialControles = True Then
                ventanas12EscalaInicial = valor
            End If
            ventanas12UltimaEscala = valor
            panel.BarEscala.Value = ventanas12UltimaEscala * 100
        End If

        If export = exportVentanas34PosX Then
            If valorInicialControles = True Then
                ventanas34PosInicialX = valor
            End If
            ventanas34UltimaPosX = valor
            panel.BarPosX.Value = ventanas34UltimaPosX * 50
        End If
        If export = exportVentanas34PosY Then
            If valorInicialControles = True Then
                ventanas34PosInicialY = valor
            End If
            ventanas34UltimaPosY = valor
            panel.BarPosY.Value = ventanas34UltimaPosY * -50
        End If
        If export = exportVentanas34Escala Then
            If valorInicialControles = True Then
                ventanas34EscalaInicial = valor
            End If
            ventanas34UltimaEscala = valor
            panel.BarEscala.Value = ventanas34UltimaEscala * 100
        End If


        If valorInicialControles = True Then
            'Ponemos la variable a false para que solo se cargen los valores iniciales la primera vez:
            valorInicialControles = False
        End If

    End Sub

    'Método que se ejecuta cuando se ha cargado el valor de un export en el RE:
    Private Sub SceneExportSet(ByVal scene As String, ByVal export As String, ByVal val As String, ByVal aRECmdId As Integer) Handles reTalkXML.ReSceneExportSet


        If exportTextoSel <> "" Then
            'Se ha cargado un export de texto
            MsgBox("Export de texto seleccionado: " + exportTextoSel + ". Valor cargado: " + valorExport)

            exportTextoSel = ""
            cargarTexto = False
        End If

        'Activamos de nuevo el panel de control:
        panel.Activate()

        'Esperamos a que el usuario cargue los valores de los Exports y haga clic en alguna animación

    End Sub

    Public Sub ActivarClip(ByRef ruta As String)

        'Si hay un Clip, configuramos el RE antes de hacer Play:

        If cargarRutaClip = True Then

            'Establecer el número de loops del vídeo
            '0 - repetir indefinidamente
            '1 - play una vez
            '2 - play dos veces
            '3 - play tres veces, etc.
            reTalkXML.setClipRepeatCount(0, cmdId)

            'Establecer tipo de clip (tiene vídeo, tiene audio (clip de audio wav), IdRE)
            reTalkXML.setClipType(True, False, cmdId)

            'Cachear el clip
            reTalkXML.cacheClip(ruta, cmdId)

            'Hacemos Rewind & Play:
            reTalkXML.callClipFunction(ruta, 4, cmdId)
            '0 - Pause
            '1 - Play
            '2 - Pause & Recue
            '3 - Recue & Play
            '4 - Rewind & Play
            '5 - Pause & Rewind
            '6 - Rewind

            cargarRutaClip = False

            'Activamos los botones de control del clip:

            If clipACargar = "Safe Area" Then
                panel.ClipPlay.Enabled = False
                panel.ClipPause.Enabled = True
                panel.ClipRewind.Enabled = True
                panel.ClipStop.Enabled = True
            End If

            If clipACargar = "Background" Then
                panel.ClipPlay2.Enabled = False
                panel.ClipPause2.Enabled = True
                panel.ClipRewind2.Enabled = True
                panel.ClipStop2.Enabled = True
            End If

            If clipVentana = True Then
                'el clip a cargar es el de la ventana
                clipVentanaCargado = True
                'activamos los controles de clip de Foreground
                panel.ClipPlay2.Enabled = False
                panel.ClipPause2.Enabled = True
                panel.ClipRewind2.Enabled = True
                panel.ClipStop2.Enabled = True
            End If

        End If

    End Sub

    Public Sub ActivarEscena(ByRef num As Integer)

        'Activamos la escena:
        Console.WriteLine("Activando la escena...")
        reTalkXML.activateSceneOnSlot(escena, "Full", num, cmdId)

    End Sub

    Private Sub SceneActivated(ByVal scene As String, ByVal channelId As Short, ByVal reCmdId As Integer) Handles reTalkXML.ReSceneActivated

        escenaActivada = True
        Console.WriteLine("Hecho!")


        'habilitamos los botones de las 4 ventanas:
        panel.V1Texto.Enabled = True
        panel.V2Texto.Enabled = True
        panel.V3Texto.Enabled = True
        panel.V4Texto.Enabled = True

        'Activamos los botones de las transiciones de las ventanas:
        panel.BtnTrans1_2.Enabled = True
        panel.BtnTrans3_4.Enabled = True

        'Activamos de nuevo el panel de control:
        panel.Activate()

    End Sub

    'Rutina para establecer la línea de vídeo de las ventanas
    Public Sub SetInputVentana(ByRef scExport As String, ByRef export As String, ByRef input As Integer)

        'Establecer el valor del Single Child:
        reTalkXML.sendSceneIntExport(escena, scExport, 1, cmdId)

        'Enviar el valor del export para el input de la ventana:
        reTalkXML.sendSceneIntExport(escena, export, input, cmdId)

    End Sub

    'Establecer un clip en la ventana
    Public Sub SetClipVentana(ByRef scExport As String, ByRef clipExport As String, ByRef clip As String)

        'Establecer el valor del Single Child:  video 1, clip 2, imagen 3
        'Set scExport
        reTalkXML.sendSceneIntExport(escena, scExport, 2, cmdId)

        'Enviar el valor del export para el clip de la ventana:
        reTalkXML.sendSceneStringExport(escena, clipExport, clip, cmdId)

    End Sub

    Private Sub AnimationFinished(ByVal scene As String, ByVal animation As String) Handles reTalkXML.ReCallbackAnimationFinished

        'Activamos de nuevo el panel de control:
        panel.Activate()

    End Sub

    Private Sub SceneDeactivated(ByVal scene As String, ByVal channelId As Short, ByVal reCmdId As Integer) Handles reTalkXML.ReSceneDeactivated
        Console.WriteLine("Hecho!")

        escenaActivada = False

        'Activamos de nuevo el panel de control:
        panel.Activate()

    End Sub

    Private Sub ClipsDescargados(ByVal reCmdId As Integer) Handles reTalkXML.ReAllClipsUnloaded
        MsgBox("Clips descargados de la caché del RE")

        'Activamos de nuevo el panel de control:
        panel.Activate()
    End Sub

    Private Sub SceneUnloaded(ByVal scene As String, ByVal reCmdId As Integer) Handles reTalkXML.ReSceneUnloaded
        Console.WriteLine("Hecho!")

        'Desactivar botones y activar botón de cargar Escenas:
        panel.ResetBotones()

        escenaCargada = False
        transSeleccionada = False
        transSeleccionada2 = False

        grupoParaControles = ""

        'Activamos el formulario Panel de Control:
        panel.Activate()

    End Sub

    Private Sub Disconnected() Handles reTalkXML.ReDisconnected
        Console.WriteLine("RE Desconectado")

        conectado = False

        panel.Hide()

        Console.WriteLine("Pulsa ENTER para finalizar.")
        'Console.ReadLine()

    End Sub

    Private Sub _Error(ByVal anErrorCode As Integer, ByVal _error As String, ByVal reCmdId As Integer) Handles reTalkXML.ReError

        Dim i As Integer
        i = InStr(_error, "Connect RE first")

        If (anErrorCode <> 0 And i < 1) Then
            'Console.WriteLine("Error: " + anErrorCode + " - " + _error)
            'Console.WriteLine("Error: " + anErrorCode.ToString + " - " + _error.ToString)
            'Console.WriteLine("Press ENTER to finish.")
            'Console.ReadLine()

            MsgBox("Error: " + anErrorCode.ToString + " - " + _error.ToString)

            'Activamos de nuevo el panel de control:
            panel.Activate()

        End If
    End Sub

    Private Sub StartThread()

        'Conexión al RE:
        If conectado = False Then
            reTalkXML = New ReTalkXMLLib.ReTalkXMLAx()
            Console.WriteLine("Conectando NRE...")
            'reTalkXML.connect("localhost", 8745)

            'Seleccionar la IP de una lista:
            listaIP.ShowDialog()

            'Puerto 8745 (default) - TXT
            reTalkXML.connect(IP, 8745)
            'Puerto 8765 - API 3
            'reTalkXML.connect(IP, 8765)
            Console.ReadLine()
        End If

    End Sub

    Sub Main()
        Dim thread As New Threading.Thread(AddressOf StartThread)
        thread.Start()
        thread.Join()
    End Sub

End Module
