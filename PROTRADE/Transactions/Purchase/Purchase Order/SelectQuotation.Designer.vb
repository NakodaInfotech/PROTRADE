<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectQuotation
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmbselect = New System.Windows.Forms.ComboBox
        Me.lbl = New System.Windows.Forms.Label
        Me.gridquotation = New System.Windows.Forms.DataGridView
        Me.txttempname = New System.Windows.Forms.TextBox
        Me.txtsearch = New System.Windows.Forms.TextBox
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridquotation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label20)
        Me.BlendPanel1.Controls.Add(Me.cmbselect)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.gridquotation)
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Controls.Add(Me.txtsearch)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(920, 486)
        Me.BlendPanel1.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Green
        Me.Label20.Location = New System.Drawing.Point(431, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(168, 32)
        Me.Label20.TabIndex = 404
        Me.Label20.Text = "NOTE : One Quotation can be select at a time"
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"", "Sr No.", "Name"})
        Me.cmbselect.Location = New System.Drawing.Point(18, 46)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(72, 21)
        Me.cmbselect.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(21, 18)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(301, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Purchase Quotation to Make a Purchase Order"
        '
        'gridquotation
        '
        Me.gridquotation.AllowUserToAddRows = False
        Me.gridquotation.AllowUserToDeleteRows = False
        Me.gridquotation.AllowUserToResizeColumns = False
        Me.gridquotation.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.gridquotation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridquotation.BackgroundColor = System.Drawing.Color.White
        Me.gridquotation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridquotation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridquotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridquotation.DefaultCellStyle = DataGridViewCellStyle8
        Me.gridquotation.GridColor = System.Drawing.SystemColors.Control
        Me.gridquotation.Location = New System.Drawing.Point(18, 69)
        Me.gridquotation.Margin = New System.Windows.Forms.Padding(2)
        Me.gridquotation.MultiSelect = False
        Me.gridquotation.Name = "gridquotation"
        Me.gridquotation.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridquotation.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.gridquotation.RowHeadersVisible = False
        Me.gridquotation.RowHeadersWidth = 30
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.gridquotation.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridquotation.RowTemplate.Height = 20
        Me.gridquotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridquotation.Size = New System.Drawing.Size(877, 354)
        Me.gridquotation.TabIndex = 2
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(758, 47)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(137, 20)
        Me.txttempname.TabIndex = 254
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.White
        Me.txtsearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.Black
        Me.txtsearch.Location = New System.Drawing.Point(90, 46)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(153, 21)
        Me.txtsearch.TabIndex = 1
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(461, 428)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 29)
        Me.cmdexit.TabIndex = 449
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(384, 428)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(75, 29)
        Me.cmdok.TabIndex = 448
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'SelectQuotation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(920, 486)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectQuotation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Quotation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridquotation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents gridquotation As System.Windows.Forms.DataGridView
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
End Class
