<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPriceListPrint
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.CMBPRICELIST = New System.Windows.Forms.ComboBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTHEADER = New System.Windows.Forms.TextBox()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTHEADERDESC = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTHEADERDESC)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTREMARKS)
        Me.BlendPanel1.Controls.Add(Me.CMBPRICELIST)
        Me.BlendPanel1.Controls.Add(Me.Label48)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTHEADER)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(579, 365)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 804
        Me.Label1.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(120, 191)
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(447, 118)
        Me.TXTREMARKS.TabIndex = 803
        '
        'CMBPRICELIST
        '
        Me.CMBPRICELIST.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPRICELIST.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPRICELIST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPRICELIST.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRICELIST.FormattingEnabled = True
        Me.CMBPRICELIST.Items.AddRange(New Object() {"RATE01", "RATE02", "RATE03", "RATE04", "RATE05", "RATE06", "RATE07", "RATE08", "RATE09", "RATE10"})
        Me.CMBPRICELIST.Location = New System.Drawing.Point(120, 10)
        Me.CMBPRICELIST.MaxDropDownItems = 14
        Me.CMBPRICELIST.Name = "CMBPRICELIST"
        Me.CMBPRICELIST.Size = New System.Drawing.Size(76, 22)
        Me.CMBPRICELIST.TabIndex = 0
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(67, 14)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(51, 14)
        Me.Label48.TabIndex = 802
        Me.Label48.Text = "Price List"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(73, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 15)
        Me.Label10.TabIndex = 800
        Me.Label10.Text = "Header"
        '
        'TXTHEADER
        '
        Me.TXTHEADER.Location = New System.Drawing.Point(120, 38)
        Me.TXTHEADER.Name = "TXTHEADER"
        Me.TXTHEADER.Size = New System.Drawing.Size(447, 23)
        Me.TXTHEADER.TabIndex = 1
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMDPRINT.Location = New System.Drawing.Point(214, 317)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(80, 28)
        Me.CMDPRINT.TabIndex = 2
        Me.CMDPRINT.Text = "&Print"
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(300, 317)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 806
        Me.Label2.Text = "Header Description"
        '
        'TXTHEADERDESC
        '
        Me.TXTHEADERDESC.Location = New System.Drawing.Point(120, 67)
        Me.TXTHEADERDESC.Multiline = True
        Me.TXTHEADERDESC.Name = "TXTHEADERDESC"
        Me.TXTHEADERDESC.Size = New System.Drawing.Size(447, 118)
        Me.TXTHEADERDESC.TabIndex = 805
        '
        'ItemPriceListPrint
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(579, 365)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemPriceListPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item Price List"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDPRINT As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents TXTHEADER As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents CMBPRICELIST As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTREMARKS As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTHEADERDESC As TextBox
End Class
