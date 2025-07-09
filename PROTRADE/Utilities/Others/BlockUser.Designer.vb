<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlockUser
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label28 = New System.Windows.Forms.Label
        Me.CMBUSER = New System.Windows.Forms.ComboBox
        Me.CMDOK = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.GRIDYEAR = New System.Windows.Forms.DataGridView
        Me.GYEAR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GYEARID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDYEAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label28)
        Me.BlendPanel1.Controls.Add(Me.CMBUSER)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GRIDYEAR)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(329, 383)
        Me.BlendPanel1.TabIndex = 18
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(21, 53)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 14)
        Me.Label28.TabIndex = 622
        Me.Label28.Text = "User Name"
        '
        'CMBUSER
        '
        Me.CMBUSER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUSER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUSER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBUSER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUSER.FormattingEnabled = True
        Me.CMBUSER.Items.AddRange(New Object() {""})
        Me.CMBUSER.Location = New System.Drawing.Point(90, 49)
        Me.CMBUSER.Name = "CMBUSER"
        Me.CMBUSER.Size = New System.Drawing.Size(216, 22)
        Me.CMBUSER.TabIndex = 621
        '
        'CMDOK
        '
        Me.CMDOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(90, 347)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(71, 26)
        Me.CMDOK.TabIndex = 184
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(167, 347)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(71, 26)
        Me.CMDEXIT.TabIndex = 183
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'GRIDYEAR
        '
        Me.GRIDYEAR.AllowUserToAddRows = False
        Me.GRIDYEAR.AllowUserToDeleteRows = False
        Me.GRIDYEAR.AllowUserToResizeColumns = False
        Me.GRIDYEAR.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDYEAR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDYEAR.BackgroundColor = System.Drawing.Color.White
        Me.GRIDYEAR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDYEAR.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GRIDYEAR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDYEAR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDYEAR.ColumnHeadersHeight = 22
        Me.GRIDYEAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDYEAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GYEAR, Me.GYEARID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDYEAR.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDYEAR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDYEAR.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDYEAR.Location = New System.Drawing.Point(24, 105)
        Me.GRIDYEAR.MultiSelect = False
        Me.GRIDYEAR.Name = "GRIDYEAR"
        Me.GRIDYEAR.ReadOnly = True
        Me.GRIDYEAR.RowHeadersVisible = False
        Me.GRIDYEAR.RowHeadersWidth = 30
        Me.GRIDYEAR.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDYEAR.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDYEAR.RowTemplate.Height = 20
        Me.GRIDYEAR.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDYEAR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDYEAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDYEAR.Size = New System.Drawing.Size(283, 236)
        Me.GRIDYEAR.TabIndex = 18
        '
        'GYEAR
        '
        Me.GYEAR.HeaderText = "Year "
        Me.GYEAR.Name = "GYEAR"
        Me.GYEAR.ReadOnly = True
        Me.GYEAR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GYEAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GYEAR.Width = 250
        '
        'GYEARID
        '
        Me.GYEARID.HeaderText = "YEARID"
        Me.GYEARID.Name = "GYEARID"
        Me.GYEARID.ReadOnly = True
        Me.GYEARID.Visible = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(20, 11)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(268, 14)
        Me.lbl.TabIndex = 182
        Me.lbl.Text = "Select Accounting Year and User To Black Access "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 624
        Me.Label1.Text = "Type"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"Block", "Un-Block"})
        Me.CMBTYPE.Location = New System.Drawing.Point(90, 77)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(148, 22)
        Me.CMBTYPE.TabIndex = 623
        '
        'BlockUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(329, 383)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BlockUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Block User"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDYEAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GRIDYEAR As System.Windows.Forms.DataGridView
    Friend WithEvents GYEAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GYEARID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CMBUSER As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
End Class
