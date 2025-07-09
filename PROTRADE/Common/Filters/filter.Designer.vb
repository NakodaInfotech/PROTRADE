<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class filter
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTempName = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.gridledger = New System.Windows.Forms.DataGridView()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.LBLCOMM = New System.Windows.Forms.Label()
        Me.TXTCOMM = New System.Windows.Forms.TextBox()
        Me.cmdShowReport = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.lblreg = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(25, 471)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 2
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(208, 19)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(92, 22)
        Me.dtto.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 190
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(179, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(70, 19)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(92, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(26, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtTempName)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.gridledger)
        Me.GroupBox1.Controls.Add(Me.chkall)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(14, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 390)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ledgers"
        '
        'txtTempName
        '
        Me.txtTempName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txtTempName.Location = New System.Drawing.Point(88, 44)
        Me.txtTempName.Name = "txtTempName"
        Me.txtTempName.Size = New System.Drawing.Size(231, 22)
        Me.txtTempName.TabIndex = 112
        Me.txtTempName.Visible = False
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txtName.Location = New System.Drawing.Point(9, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(310, 22)
        Me.txtName.TabIndex = 1
        '
        'gridledger
        '
        Me.gridledger.AllowUserToAddRows = False
        Me.gridledger.AllowUserToDeleteRows = False
        Me.gridledger.AllowUserToResizeColumns = False
        Me.gridledger.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridledger.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridledger.BackgroundColor = System.Drawing.Color.White
        Me.gridledger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridledger.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridledger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridledger.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridledger.GridColor = System.Drawing.SystemColors.Control
        Me.gridledger.Location = New System.Drawing.Point(9, 69)
        Me.gridledger.Margin = New System.Windows.Forms.Padding(2)
        Me.gridledger.MultiSelect = False
        Me.gridledger.Name = "gridledger"
        Me.gridledger.ReadOnly = True
        Me.gridledger.RowHeadersVisible = False
        Me.gridledger.RowHeadersWidth = 30
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.gridledger.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridledger.RowTemplate.Height = 20
        Me.gridledger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridledger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridledger.Size = New System.Drawing.Size(310, 316)
        Me.gridledger.TabIndex = 0
        Me.gridledger.TabStop = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(11, 46)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(77, 18)
        Me.chkall.TabIndex = 1
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 475)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 48)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.LBLCOMM)
        Me.BlendPanel1.Controls.Add(Me.TXTCOMM)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.lblreg)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(352, 562)
        Me.BlendPanel1.TabIndex = 8
        '
        'LBLCOMM
        '
        Me.LBLCOMM.AutoSize = True
        Me.LBLCOMM.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOMM.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.LBLCOMM.Location = New System.Drawing.Point(32, 438)
        Me.LBLCOMM.Name = "LBLCOMM"
        Me.LBLCOMM.Size = New System.Drawing.Size(52, 14)
        Me.LBLCOMM.TabIndex = 287
        Me.LBLCOMM.Text = "Comm %"
        '
        'TXTCOMM
        '
        Me.TXTCOMM.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTCOMM.Location = New System.Drawing.Point(88, 434)
        Me.TXTCOMM.Name = "TXTCOMM"
        Me.TXTCOMM.Size = New System.Drawing.Size(53, 22)
        Me.TXTCOMM.TabIndex = 113
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.ForeColor = System.Drawing.Color.Black
        Me.cmdShowReport.Location = New System.Drawing.Point(80, 529)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(96, 28)
        Me.cmdShowReport.TabIndex = 3
        Me.cmdShowReport.Text = "&Show Report"
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(180, 529)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 28)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(88, 406)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(232, 22)
        Me.cmbregister.TabIndex = 1
        '
        'lblreg
        '
        Me.lblreg.AutoSize = True
        Me.lblreg.BackColor = System.Drawing.Color.Transparent
        Me.lblreg.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblreg.Location = New System.Drawing.Point(32, 410)
        Me.lblreg.Name = "lblreg"
        Me.lblreg.Size = New System.Drawing.Size(52, 14)
        Me.lblreg.TabIndex = 286
        Me.lblreg.Text = "Register"
        '
        'filter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(352, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "filter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTempName As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents gridledger As System.Windows.Forms.DataGridView
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents lblreg As System.Windows.Forms.Label
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents LBLCOMM As System.Windows.Forms.Label
    Friend WithEvents TXTCOMM As System.Windows.Forms.TextBox
End Class
