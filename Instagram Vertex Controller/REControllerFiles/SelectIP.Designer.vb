<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectIP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectIP))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IPlist = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.IPlist)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(264, 249)
        Me.Panel1.TabIndex = 1
        '
        'IPlist
        '
        Me.IPlist.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"})
        Me.IPlist.DropDownHeight = 340
        Me.IPlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IPlist.DropDownWidth = 80
        Me.IPlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IPlist.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.IPlist.FormatString = "N0"
        Me.IPlist.FormattingEnabled = True
        Me.IPlist.IntegralHeight = False
        Me.IPlist.Items.AddRange(New Object() {"10.30.5.153", "10.30.5.154", "10.30.5.185"})
        Me.IPlist.Location = New System.Drawing.Point(59, 63)
        Me.IPlist.Name = "IPlist"
        Me.IPlist.Size = New System.Drawing.Size(140, 28)
        Me.IPlist.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(25, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar la IP de conexión:"
        '
        'SelectIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 249)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Instagram Controller"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents IPlist As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
