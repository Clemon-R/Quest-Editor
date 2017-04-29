<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class afficheur
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(afficheur))
        Me.NsTheme1 = New Quests_Editor.NSTheme()
        Me.NsLabel2 = New Quests_Editor.NSLabel()
        Me.NsLabel1 = New Quests_Editor.NSLabel()
        Me.swf = New Quests_Editor.NSTextBox()
        Me.sql = New Quests_Editor.NSTextBox()
        Me.NsControlButton1 = New Quests_Editor.NSControlButton()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New Quests_Editor.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsLabel2)
        Me.NsTheme1.Controls.Add(Me.NsLabel1)
        Me.NsTheme1.Controls.Add(Me.swf)
        Me.NsTheme1.Controls.Add(Me.sql)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(739, 314)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Afficheur"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsLabel2
        '
        Me.NsLabel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.NsLabel2.Location = New System.Drawing.Point(692, 277)
        Me.NsLabel2.Name = "NsLabel2"
        Me.NsLabel2.Size = New System.Drawing.Size(35, 23)
        Me.NsLabel2.TabIndex = 4
        Me.NsLabel2.Text = "NsLabel2"
        Me.NsLabel2.Value1 = " "
        Me.NsLabel2.Value2 = "SWF"
        '
        'NsLabel1
        '
        Me.NsLabel1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.NsLabel1.Location = New System.Drawing.Point(692, 142)
        Me.NsLabel1.Name = "NsLabel1"
        Me.NsLabel1.Size = New System.Drawing.Size(35, 23)
        Me.NsLabel1.TabIndex = 3
        Me.NsLabel1.Text = "NsLabel1"
        Me.NsLabel1.Value1 = " "
        Me.NsLabel1.Value2 = "SQL"
        '
        'swf
        '
        Me.swf.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.swf.Location = New System.Drawing.Point(12, 171)
        Me.swf.MaxLength = 32767
        Me.swf.Multiline = True
        Me.swf.Name = "swf"
        Me.swf.ReadOnly = False
        Me.swf.Size = New System.Drawing.Size(715, 129)
        Me.swf.TabIndex = 2
        Me.swf.Text = "SWF"
        Me.swf.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.swf.UseSystemPasswordChar = False
        '
        'sql
        '
        Me.sql.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sql.Location = New System.Drawing.Point(12, 36)
        Me.sql.MaxLength = 32767
        Me.sql.Multiline = True
        Me.sql.Name = "sql"
        Me.sql.ReadOnly = False
        Me.sql.Size = New System.Drawing.Size(715, 129)
        Me.sql.TabIndex = 1
        Me.sql.Text = "SQL"
        Me.sql.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.sql.UseSystemPasswordChar = False
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Quests_Editor.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(712, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'afficheur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 314)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "afficheur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Afficheur"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsTheme1 As Quests_Editor.NSTheme
    Friend WithEvents NsControlButton1 As Quests_Editor.NSControlButton
    Friend WithEvents NsLabel2 As Quests_Editor.NSLabel
    Friend WithEvents NsLabel1 As Quests_Editor.NSLabel
    Friend WithEvents swf As Quests_Editor.NSTextBox
    Friend WithEvents sql As Quests_Editor.NSTextBox
End Class
