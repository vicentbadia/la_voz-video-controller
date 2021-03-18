<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenScene
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenSceneBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoadScene = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'OpenSceneBtn
        '
        Me.OpenSceneBtn.BackColor = System.Drawing.Color.DarkSlateGray
        Me.OpenSceneBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenSceneBtn.ForeColor = System.Drawing.Color.White
        Me.OpenSceneBtn.Location = New System.Drawing.Point(252, 128)
        Me.OpenSceneBtn.Name = "OpenSceneBtn"
        Me.OpenSceneBtn.Size = New System.Drawing.Size(140, 50)
        Me.OpenSceneBtn.TabIndex = 6
        Me.OpenSceneBtn.Text = "Seleccionar Escena"
        Me.OpenSceneBtn.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Humanst521 BT", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.Label2.Location = New System.Drawing.Point(33, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 39)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Control Panel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Humanst521 BT", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(35, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "RE Controller"
        '
        'LoadScene
        '
        Me.LoadScene.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.LoadScene.SelectedPath = "G:\Projects"
        Me.LoadScene.ShowNewFolderButton = False
        '
        'OpenScene
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 212)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OpenSceneBtn)
        Me.Name = "OpenScene"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Instagram Vertex Controller · Cargar Escena"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenSceneBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LoadScene As System.Windows.Forms.FolderBrowserDialog
End Class
