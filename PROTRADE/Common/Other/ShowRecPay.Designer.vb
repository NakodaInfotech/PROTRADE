<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowRecPay
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTTOTAL = New System.Windows.Forms.TextBox()
        Me.LBLBAL = New System.Windows.Forms.Label()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.GRIDRECPAY = New System.Windows.Forms.DataGridView()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDRECPAY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTAL)
        Me.BlendPanel1.Controls.Add(Me.LBLBAL)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.GRIDRECPAY)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(452, 360)
        Me.BlendPanel1.TabIndex = 10
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTAL.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTAL.Location = New System.Drawing.Point(245, 299)
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.ReadOnly = True
        Me.TXTTOTAL.Size = New System.Drawing.Size(90, 22)
        Me.TXTTOTAL.TabIndex = 723
        Me.TXTTOTAL.TabStop = False
        Me.TXTTOTAL.Text = "0.00"
        Me.TXTTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLBAL
        '
        Me.LBLBAL.AutoSize = True
        Me.LBLBAL.BackColor = System.Drawing.Color.Transparent
        Me.LBLBAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBAL.ForeColor = System.Drawing.Color.Red
        Me.LBLBAL.Location = New System.Drawing.Point(209, 303)
        Me.LBLBAL.Name = "LBLBAL"
        Me.LBLBAL.Size = New System.Drawing.Size(31, 14)
        Me.LBLBAL.TabIndex = 722
        Me.LBLBAL.Text = "Total"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(137, 327)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 6
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'GRIDRECPAY
        '
        Me.GRIDRECPAY.AllowUserToAddRows = False
        Me.GRIDRECPAY.AllowUserToDeleteRows = False
        Me.GRIDRECPAY.AllowUserToResizeColumns = False
        Me.GRIDRECPAY.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDRECPAY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDRECPAY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRECPAY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRECPAY.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRECPAY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDRECPAY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRECPAY.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDRECPAY.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDRECPAY.Location = New System.Drawing.Point(26, 27)
        Me.GRIDRECPAY.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRECPAY.MultiSelect = False
        Me.GRIDRECPAY.Name = "GRIDRECPAY"
        Me.GRIDRECPAY.ReadOnly = True
        Me.GRIDRECPAY.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDRECPAY.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDRECPAY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRECPAY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRECPAY.Size = New System.Drawing.Size(400, 267)
        Me.GRIDRECPAY.TabIndex = 5
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(224, 326)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 28)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'ShowRecPay
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(452, 360)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ShowRecPay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Show Rec/Pay"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDRECPAY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GRIDRECPAY As System.Windows.Forms.DataGridView
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents TXTTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents LBLBAL As System.Windows.Forms.Label
End Class
