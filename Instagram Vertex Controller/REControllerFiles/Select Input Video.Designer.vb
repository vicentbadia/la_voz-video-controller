<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectInputVideo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectInputVideo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClipVentana = New System.Windows.Forms.Button()
        Me.InputVideo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SelectClipVentana = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.BtnClipVentana)
        Me.Panel1.Controls.Add(Me.InputVideo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(285, 307)
        Me.Panel1.TabIndex = 0
        '
        'BtnClipVentana
        '
        Me.BtnClipVentana.BackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnClipVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClipVentana.ForeColor = System.Drawing.Color.White
        Me.BtnClipVentana.Location = New System.Drawing.Point(13, 255)
        Me.BtnClipVentana.Name = "BtnClipVentana"
        Me.BtnClipVentana.Size = New System.Drawing.Size(50, 40)
        Me.BtnClipVentana.TabIndex = 2
        Me.BtnClipVentana.Text = "Clip"
        Me.BtnClipVentana.UseVisualStyleBackColor = False
        '
        'InputVideo
        '
        Me.InputVideo.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"})
        Me.InputVideo.DropDownHeight = 340
        Me.InputVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InputVideo.DropDownWidth = 80
        Me.InputVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputVideo.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.InputVideo.FormatString = "N0"
        Me.InputVideo.FormattingEnabled = True
        Me.InputVideo.IntegralHeight = False
        Me.InputVideo.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"})
        Me.InputVideo.Location = New System.Drawing.Point(78, 63)
        Me.InputVideo.Name = "InputVideo"
        Me.InputVideo.Size = New System.Drawing.Size(121, 28)
        Me.InputVideo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(25, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar la entrada de vídeo:"
        '
        'SelectClipVentana
        '
        Me.SelectClipVentana.FileName = "Seleccionar Clip"
        '
        'SelectInputVideo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 307)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectInputVideo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Instagram Controller"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents InputVideo As System.Windows.Forms.ComboBox
    Friend WithEvents BtnClipVentana As System.Windows.Forms.Button
    Friend WithEvents SelectClipVentana As System.Windows.Forms.OpenFileDialog
End Class
