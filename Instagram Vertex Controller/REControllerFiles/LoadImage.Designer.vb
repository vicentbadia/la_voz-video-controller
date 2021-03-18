<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadImage))
        Me.BtnImg4Si = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoadScene = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnImg4No = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnImg4Si
        '
        Me.BtnImg4Si.BackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnImg4Si.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImg4Si.ForeColor = System.Drawing.Color.White
        Me.BtnImg4Si.Location = New System.Drawing.Point(127, 160)
        Me.BtnImg4Si.Name = "BtnImg4Si"
        Me.BtnImg4Si.Size = New System.Drawing.Size(80, 40)
        Me.BtnImg4Si.TabIndex = 6
        Me.BtnImg4Si.Text = "Sí"
        Me.BtnImg4Si.UseVisualStyleBackColor = False
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(144, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "¿Cargar la imagen 4?"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImg4No
        '
        Me.BtnImg4No.BackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnImg4No.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImg4No.ForeColor = System.Drawing.Color.White
        Me.BtnImg4No.Location = New System.Drawing.Point(238, 160)
        Me.BtnImg4No.Name = "BtnImg4No"
        Me.BtnImg4No.Size = New System.Drawing.Size(80, 40)
        Me.BtnImg4No.TabIndex = 10
        Me.BtnImg4No.Text = "No"
        Me.BtnImg4No.UseVisualStyleBackColor = False
        '
        'LoadImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 212)
        Me.Controls.Add(Me.BtnImg4No)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnImg4Si)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoadImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Instagram Controller · ATresMedia"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnImg4Si As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LoadScene As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnImg4No As System.Windows.Forms.Button
End Class
