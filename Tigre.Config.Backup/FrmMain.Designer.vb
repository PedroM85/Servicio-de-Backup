<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fbPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnsearch1 = New System.Windows.Forms.Button()
        Me.lblPathLog = New System.Windows.Forms.Label()
        Me.txtPathLog = New System.Windows.Forms.TextBox()
        Me.lblDatabasename = New System.Windows.Forms.Label()
        Me.txtDataBase = New System.Windows.Forms.TextBox()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtMaximum = New System.Windows.Forms.RadioButton()
        Me.rbtHigh = New System.Windows.Forms.RadioButton()
        Me.rbtNormal = New System.Windows.Forms.RadioButton()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblMinutos = New System.Windows.Forms.Label()
        Me.txtMinutos = New System.Windows.Forms.TextBox()
        Me.lblDaily = New System.Windows.Forms.Label()
        Me.txtDaily = New System.Windows.Forms.TextBox()
        Me.lblIntervalo = New System.Windows.Forms.Label()
        Me.lblDirectoryPath = New System.Windows.Forms.Label()
        Me.txtPathD = New System.Windows.Forms.TextBox()
        Me.cmbInterval = New System.Windows.Forms.ComboBox()
        Me.lblComprimir = New System.Windows.Forms.Label()
        Me.chkComprimir = New System.Windows.Forms.CheckBox()
        Me.lblExp = New System.Windows.Forms.Label()
        Me.txtExp = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(297, 443)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(75, 23)
        Me.btnModify.TabIndex = 12
        Me.btnModify.Text = "Modificar"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnEnd
        '
        Me.btnEnd.Location = New System.Drawing.Point(378, 443)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(75, 23)
        Me.btnEnd.TabIndex = 9
        Me.btnEnd.Text = "Salir"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(297, 443)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnsearch1)
        Me.GroupBox1.Controls.Add(Me.lblPathLog)
        Me.GroupBox1.Controls.Add(Me.txtPathLog)
        Me.GroupBox1.Controls.Add(Me.lblDatabasename)
        Me.GroupBox1.Controls.Add(Me.txtDataBase)
        Me.GroupBox1.Controls.Add(Me.lblServer)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 113)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'btnsearch1
        '
        Me.btnsearch1.Location = New System.Drawing.Point(357, 80)
        Me.btnsearch1.Name = "btnsearch1"
        Me.btnsearch1.Size = New System.Drawing.Size(24, 21)
        Me.btnsearch1.TabIndex = 18
        Me.btnsearch1.Text = "..."
        Me.btnsearch1.UseVisualStyleBackColor = True
        '
        'lblPathLog
        '
        Me.lblPathLog.AutoSize = True
        Me.lblPathLog.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPathLog.Location = New System.Drawing.Point(20, 83)
        Me.lblPathLog.Name = "lblPathLog"
        Me.lblPathLog.Size = New System.Drawing.Size(124, 16)
        Me.lblPathLog.TabIndex = 20
        Me.lblPathLog.Text = "Ubicación del LOG:"
        '
        'txtPathLog
        '
        Me.txtPathLog.Location = New System.Drawing.Point(182, 80)
        Me.txtPathLog.Name = "txtPathLog"
        Me.txtPathLog.Size = New System.Drawing.Size(199, 20)
        Me.txtPathLog.TabIndex = 19
        Me.txtPathLog.TabStop = False
        '
        'lblDatabasename
        '
        Me.lblDatabasename.AutoSize = True
        Me.lblDatabasename.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabasename.Location = New System.Drawing.Point(20, 49)
        Me.lblDatabasename.Name = "lblDatabasename"
        Me.lblDatabasename.Size = New System.Drawing.Size(106, 16)
        Me.lblDatabasename.TabIndex = 8
        Me.lblDatabasename.Text = "Base de Datos:"
        '
        'txtDataBase
        '
        Me.txtDataBase.Location = New System.Drawing.Point(184, 46)
        Me.txtDataBase.Name = "txtDataBase"
        Me.txtDataBase.Size = New System.Drawing.Size(197, 20)
        Me.txtDataBase.TabIndex = 7
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServer.Location = New System.Drawing.Point(20, 16)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(68, 16)
        Me.lblServer.TabIndex = 6
        Me.lblServer.Text = "Servidor:"
        '
        'txtServer
        '
        Me.txtServer.AccessibleDescription = ""
        Me.txtServer.Location = New System.Drawing.Point(184, 13)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(197, 20)
        Me.txtServer.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtMaximum)
        Me.GroupBox2.Controls.Add(Me.rbtHigh)
        Me.GroupBox2.Controls.Add(Me.rbtNormal)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.lblMinutos)
        Me.GroupBox2.Controls.Add(Me.txtMinutos)
        Me.GroupBox2.Controls.Add(Me.lblDaily)
        Me.GroupBox2.Controls.Add(Me.txtDaily)
        Me.GroupBox2.Controls.Add(Me.lblIntervalo)
        Me.GroupBox2.Controls.Add(Me.lblDirectoryPath)
        Me.GroupBox2.Controls.Add(Me.txtPathD)
        Me.GroupBox2.Controls.Add(Me.cmbInterval)
        Me.GroupBox2.Controls.Add(Me.lblComprimir)
        Me.GroupBox2.Controls.Add(Me.chkComprimir)
        Me.GroupBox2.Controls.Add(Me.lblExp)
        Me.GroupBox2.Controls.Add(Me.txtExp)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 227)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(441, 210)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'rbtMaximum
        '
        Me.rbtMaximum.AutoSize = True
        Me.rbtMaximum.Location = New System.Drawing.Point(292, 184)
        Me.rbtMaximum.Name = "rbtMaximum"
        Me.rbtMaximum.Size = New System.Drawing.Size(61, 17)
        Me.rbtMaximum.TabIndex = 37
        Me.rbtMaximum.TabStop = True
        Me.rbtMaximum.Text = "Maximo"
        Me.rbtMaximum.UseVisualStyleBackColor = True
        '
        'rbtHigh
        '
        Me.rbtHigh.AutoSize = True
        Me.rbtHigh.Location = New System.Drawing.Point(243, 184)
        Me.rbtHigh.Name = "rbtHigh"
        Me.rbtHigh.Size = New System.Drawing.Size(43, 17)
        Me.rbtHigh.TabIndex = 36
        Me.rbtHigh.TabStop = True
        Me.rbtHigh.Text = "Alto"
        Me.rbtHigh.UseVisualStyleBackColor = True
        '
        'rbtNormal
        '
        Me.rbtNormal.AutoSize = True
        Me.rbtNormal.Location = New System.Drawing.Point(179, 184)
        Me.rbtNormal.Name = "rbtNormal"
        Me.rbtNormal.Size = New System.Drawing.Size(58, 17)
        Me.rbtNormal.TabIndex = 35
        Me.rbtNormal.TabStop = True
        Me.rbtNormal.Text = "Normal"
        Me.rbtNormal.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(357, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(24, 21)
        Me.btnSearch.TabIndex = 26
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblMinutos
        '
        Me.lblMinutos.AutoSize = True
        Me.lblMinutos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinutos.Location = New System.Drawing.Point(17, 96)
        Me.lblMinutos.Name = "lblMinutos"
        Me.lblMinutos.Size = New System.Drawing.Size(64, 16)
        Me.lblMinutos.TabIndex = 34
        Me.lblMinutos.Text = "Minutos:"
        '
        'txtMinutos
        '
        Me.txtMinutos.Location = New System.Drawing.Point(179, 93)
        Me.txtMinutos.Name = "txtMinutos"
        Me.txtMinutos.Size = New System.Drawing.Size(71, 20)
        Me.txtMinutos.TabIndex = 28
        Me.txtMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDaily
        '
        Me.lblDaily.AutoSize = True
        Me.lblDaily.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaily.Location = New System.Drawing.Point(15, 96)
        Me.lblDaily.Name = "lblDaily"
        Me.lblDaily.Size = New System.Drawing.Size(40, 16)
        Me.lblDaily.TabIndex = 33
        Me.lblDaily.Text = "Dias:"
        '
        'txtDaily
        '
        Me.txtDaily.Location = New System.Drawing.Point(179, 93)
        Me.txtDaily.Name = "txtDaily"
        Me.txtDaily.Size = New System.Drawing.Size(71, 20)
        Me.txtDaily.TabIndex = 30
        Me.txtDaily.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblIntervalo
        '
        Me.lblIntervalo.AutoSize = True
        Me.lblIntervalo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntervalo.Location = New System.Drawing.Point(15, 63)
        Me.lblIntervalo.Name = "lblIntervalo"
        Me.lblIntervalo.Size = New System.Drawing.Size(80, 16)
        Me.lblIntervalo.TabIndex = 32
        Me.lblIntervalo.Text = "Intervalos:"
        '
        'lblDirectoryPath
        '
        Me.lblDirectoryPath.AutoSize = True
        Me.lblDirectoryPath.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirectoryPath.Location = New System.Drawing.Point(15, 28)
        Me.lblDirectoryPath.Name = "lblDirectoryPath"
        Me.lblDirectoryPath.Size = New System.Drawing.Size(161, 16)
        Me.lblDirectoryPath.TabIndex = 31
        Me.lblDirectoryPath.Text = "Directorio de Ubicación:"
        '
        'txtPathD
        '
        Me.txtPathD.Location = New System.Drawing.Point(179, 25)
        Me.txtPathD.Name = "txtPathD"
        Me.txtPathD.Size = New System.Drawing.Size(202, 20)
        Me.txtPathD.TabIndex = 29
        Me.txtPathD.TabStop = False
        Me.txtPathD.Tag = ""
        '
        'cmbInterval
        '
        Me.cmbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInterval.FormattingEnabled = True
        Me.cmbInterval.Location = New System.Drawing.Point(179, 59)
        Me.cmbInterval.Name = "cmbInterval"
        Me.cmbInterval.Size = New System.Drawing.Size(121, 21)
        Me.cmbInterval.TabIndex = 27
        '
        'lblComprimir
        '
        Me.lblComprimir.AutoSize = True
        Me.lblComprimir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprimir.Location = New System.Drawing.Point(17, 160)
        Me.lblComprimir.Name = "lblComprimir"
        Me.lblComprimir.Size = New System.Drawing.Size(77, 16)
        Me.lblComprimir.TabIndex = 25
        Me.lblComprimir.Text = "Comprimir:"
        '
        'chkComprimir
        '
        Me.chkComprimir.AutoSize = True
        Me.chkComprimir.Location = New System.Drawing.Point(179, 164)
        Me.chkComprimir.Name = "chkComprimir"
        Me.chkComprimir.Size = New System.Drawing.Size(15, 14)
        Me.chkComprimir.TabIndex = 24
        Me.chkComprimir.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.chkComprimir.UseVisualStyleBackColor = True
        '
        'lblExp
        '
        Me.lblExp.AutoSize = True
        Me.lblExp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExp.Location = New System.Drawing.Point(17, 129)
        Me.lblExp.Name = "lblExp"
        Me.lblExp.Size = New System.Drawing.Size(78, 16)
        Me.lblExp.TabIndex = 23
        Me.lblExp.Text = "Expiración:"
        '
        'txtExp
        '
        Me.txtExp.Location = New System.Drawing.Point(179, 131)
        Me.txtExp.Name = "txtExp"
        Me.txtExp.Size = New System.Drawing.Size(71, 20)
        Me.txtExp.TabIndex = 22
        Me.txtExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 102)
        Me.Panel1.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackgroundImage = Global.Ewave.Backup.My.Resources.Resources.Backup3
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(122, 77)
        Me.Panel2.TabIndex = 25
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(467, 478)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnModify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnEnd As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents fbPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnsearch1 As System.Windows.Forms.Button
    Friend WithEvents lblPathLog As System.Windows.Forms.Label
    Friend WithEvents txtPathLog As System.Windows.Forms.TextBox
    Friend WithEvents lblDatabasename As System.Windows.Forms.Label
    Friend WithEvents txtDataBase As System.Windows.Forms.TextBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblMinutos As System.Windows.Forms.Label
    Friend WithEvents txtMinutos As System.Windows.Forms.TextBox
    Friend WithEvents lblDaily As System.Windows.Forms.Label
    Friend WithEvents txtDaily As System.Windows.Forms.TextBox
    Friend WithEvents lblIntervalo As System.Windows.Forms.Label
    Friend WithEvents lblDirectoryPath As System.Windows.Forms.Label
    Friend WithEvents txtPathD As System.Windows.Forms.TextBox
    Friend WithEvents cmbInterval As System.Windows.Forms.ComboBox
    Friend WithEvents lblComprimir As System.Windows.Forms.Label
    Friend WithEvents chkComprimir As System.Windows.Forms.CheckBox
    Friend WithEvents lblExp As System.Windows.Forms.Label
    Friend WithEvents txtExp As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtMaximum As System.Windows.Forms.RadioButton
    Friend WithEvents rbtHigh As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNormal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
