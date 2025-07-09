<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GSTR2MatchGridReport
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDEXPORT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVNOBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVDATEBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVNOPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVDATEPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXABLEAMTBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMTBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMTBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMTBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGTOTALBOOKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXABLEAMTPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMTPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMTPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMTPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGTOTALPORTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECOSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMDEXPORT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(1020, 545)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 17)
        Me.Label1.TabIndex = 685
        Me.Label1.Text = "   "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(1041, 546)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 14)
        Me.Label4.TabIndex = 684
        Me.Label4.Text = "Value Mismatch"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(841, 548)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 683
        Me.Label2.Text = "Only In Books"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightGreen
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(920, 547)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 17)
        Me.Label3.TabIndex = 682
        Me.Label3.Text = "   "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(941, 548)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 14)
        Me.Label21.TabIndex = 681
        Me.Label21.Text = "Only In Portal"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(819, 547)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 680
        Me.Label22.Text = "   "
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(491, 543)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 27)
        Me.CMDREFRESH.TabIndex = 679
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(663, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 27)
        Me.cmdexit.TabIndex = 655
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDEXPORT
        '
        Me.CMDEXPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXPORT.FlatAppearance.BorderSize = 0
        Me.CMDEXPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXPORT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXPORT.Location = New System.Drawing.Point(577, 543)
        Me.CMDEXPORT.Name = "CMDEXPORT"
        Me.CMDEXPORT.Size = New System.Drawing.Size(80, 27)
        Me.CMDEXPORT.TabIndex = 654
        Me.CMDEXPORT.Text = "&Export"
        Me.CMDEXPORT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 524)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBILLNO, Me.GTYPE, Me.GGSTIN, Me.GNAME, Me.GINVNOBOOKS, Me.GINVDATEBOOKS, Me.GINVNOPORTAL, Me.GINVDATEPORTAL, Me.GTAXABLEAMTBOOKS, Me.GCGSTAMTBOOKS, Me.GSGSTAMTBOOKS, Me.GIGSTAMTBOOKS, Me.GGTOTALBOOKS, Me.GTAXABLEAMTPORTAL, Me.GCGSTAMTPORTAL, Me.GSGSTAMTPORTAL, Me.GIGSTAMTPORTAL, Me.GGTOTALPORTAL, Me.GRECOSTATUS})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 0
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 1
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "Party GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 2
        Me.GGSTIN.Width = 120
        '
        'GNAME
        '
        Me.GNAME.Caption = "Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GINVNOBOOKS
        '
        Me.GINVNOBOOKS.Caption = "Invoice No (Books)"
        Me.GINVNOBOOKS.FieldName = "INVNOBOOKS"
        Me.GINVNOBOOKS.Name = "GINVNOBOOKS"
        Me.GINVNOBOOKS.Visible = True
        Me.GINVNOBOOKS.VisibleIndex = 4
        Me.GINVNOBOOKS.Width = 120
        '
        'GINVDATEBOOKS
        '
        Me.GINVDATEBOOKS.Caption = "Inv Dt. (Books)"
        Me.GINVDATEBOOKS.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GINVDATEBOOKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GINVDATEBOOKS.FieldName = "INVDATEBOOKS"
        Me.GINVDATEBOOKS.Name = "GINVDATEBOOKS"
        Me.GINVDATEBOOKS.Visible = True
        Me.GINVDATEBOOKS.VisibleIndex = 5
        Me.GINVDATEBOOKS.Width = 100
        '
        'GINVNOPORTAL
        '
        Me.GINVNOPORTAL.Caption = "Invoice No (Portal)"
        Me.GINVNOPORTAL.FieldName = "INVNOPORTAL"
        Me.GINVNOPORTAL.Name = "GINVNOPORTAL"
        Me.GINVNOPORTAL.Visible = True
        Me.GINVNOPORTAL.VisibleIndex = 6
        Me.GINVNOPORTAL.Width = 120
        '
        'GINVDATEPORTAL
        '
        Me.GINVDATEPORTAL.Caption = "Inv Dt. (Portal)"
        Me.GINVDATEPORTAL.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GINVDATEPORTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GINVDATEPORTAL.FieldName = "INVDATEPORTAL"
        Me.GINVDATEPORTAL.Name = "GINVDATEPORTAL"
        Me.GINVDATEPORTAL.Visible = True
        Me.GINVDATEPORTAL.VisibleIndex = 7
        Me.GINVDATEPORTAL.Width = 100
        '
        'GTAXABLEAMTBOOKS
        '
        Me.GTAXABLEAMTBOOKS.Caption = "Taxable Amt (Books)"
        Me.GTAXABLEAMTBOOKS.DisplayFormat.FormatString = "0.00"
        Me.GTAXABLEAMTBOOKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXABLEAMTBOOKS.FieldName = "TAXABLEAMTBOOKS"
        Me.GTAXABLEAMTBOOKS.Name = "GTAXABLEAMTBOOKS"
        Me.GTAXABLEAMTBOOKS.Visible = True
        Me.GTAXABLEAMTBOOKS.VisibleIndex = 8
        Me.GTAXABLEAMTBOOKS.Width = 120
        '
        'GCGSTAMTBOOKS
        '
        Me.GCGSTAMTBOOKS.Caption = "CGST Amt (Books)"
        Me.GCGSTAMTBOOKS.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMTBOOKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMTBOOKS.FieldName = "CGSTAMTBOOKS"
        Me.GCGSTAMTBOOKS.Name = "GCGSTAMTBOOKS"
        Me.GCGSTAMTBOOKS.Visible = True
        Me.GCGSTAMTBOOKS.VisibleIndex = 9
        Me.GCGSTAMTBOOKS.Width = 120
        '
        'GSGSTAMTBOOKS
        '
        Me.GSGSTAMTBOOKS.Caption = "SGST Amt (Books)"
        Me.GSGSTAMTBOOKS.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMTBOOKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMTBOOKS.FieldName = "SGSTAMTBOOKS"
        Me.GSGSTAMTBOOKS.Name = "GSGSTAMTBOOKS"
        Me.GSGSTAMTBOOKS.Visible = True
        Me.GSGSTAMTBOOKS.VisibleIndex = 10
        Me.GSGSTAMTBOOKS.Width = 120
        '
        'GIGSTAMTBOOKS
        '
        Me.GIGSTAMTBOOKS.Caption = "IGST Amt (Books)"
        Me.GIGSTAMTBOOKS.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMTBOOKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMTBOOKS.FieldName = "IGSTAMTBOOKS"
        Me.GIGSTAMTBOOKS.Name = "GIGSTAMTBOOKS"
        Me.GIGSTAMTBOOKS.Visible = True
        Me.GIGSTAMTBOOKS.VisibleIndex = 11
        Me.GIGSTAMTBOOKS.Width = 120
        '
        'GGTOTALBOOKS
        '
        Me.GGTOTALBOOKS.Caption = "G Total (Books)"
        Me.GGTOTALBOOKS.DisplayFormat.FormatString = "0.00"
        Me.GGTOTALBOOKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGTOTALBOOKS.FieldName = "GRANDTOTALBOOKS"
        Me.GGTOTALBOOKS.Name = "GGTOTALBOOKS"
        Me.GGTOTALBOOKS.Visible = True
        Me.GGTOTALBOOKS.VisibleIndex = 12
        Me.GGTOTALBOOKS.Width = 120
        '
        'GTAXABLEAMTPORTAL
        '
        Me.GTAXABLEAMTPORTAL.Caption = "Taxable Amt (Portal)"
        Me.GTAXABLEAMTPORTAL.DisplayFormat.FormatString = "0.00"
        Me.GTAXABLEAMTPORTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXABLEAMTPORTAL.FieldName = "TAXABLEAMTPORTAL"
        Me.GTAXABLEAMTPORTAL.Name = "GTAXABLEAMTPORTAL"
        Me.GTAXABLEAMTPORTAL.Visible = True
        Me.GTAXABLEAMTPORTAL.VisibleIndex = 13
        Me.GTAXABLEAMTPORTAL.Width = 120
        '
        'GCGSTAMTPORTAL
        '
        Me.GCGSTAMTPORTAL.Caption = "CGST Amt (Portal)"
        Me.GCGSTAMTPORTAL.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMTPORTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMTPORTAL.FieldName = "CGSTAMTPORTAL"
        Me.GCGSTAMTPORTAL.Name = "GCGSTAMTPORTAL"
        Me.GCGSTAMTPORTAL.Visible = True
        Me.GCGSTAMTPORTAL.VisibleIndex = 14
        Me.GCGSTAMTPORTAL.Width = 120
        '
        'GSGSTAMTPORTAL
        '
        Me.GSGSTAMTPORTAL.Caption = "SGST Amt (Portal)"
        Me.GSGSTAMTPORTAL.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMTPORTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMTPORTAL.FieldName = "SGSTAMTPORTAL"
        Me.GSGSTAMTPORTAL.Name = "GSGSTAMTPORTAL"
        Me.GSGSTAMTPORTAL.Visible = True
        Me.GSGSTAMTPORTAL.VisibleIndex = 15
        Me.GSGSTAMTPORTAL.Width = 120
        '
        'GIGSTAMTPORTAL
        '
        Me.GIGSTAMTPORTAL.Caption = "IGST Amt (Portal)"
        Me.GIGSTAMTPORTAL.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMTPORTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMTPORTAL.FieldName = "IGSTAMTPORTAL"
        Me.GIGSTAMTPORTAL.Name = "GIGSTAMTPORTAL"
        Me.GIGSTAMTPORTAL.Visible = True
        Me.GIGSTAMTPORTAL.VisibleIndex = 16
        Me.GIGSTAMTPORTAL.Width = 120
        '
        'GGTOTALPORTAL
        '
        Me.GGTOTALPORTAL.Caption = "G Total (Portal)"
        Me.GGTOTALPORTAL.DisplayFormat.FormatString = "0.00"
        Me.GGTOTALPORTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGTOTALPORTAL.FieldName = "GRANDTOTALPORTAL"
        Me.GGTOTALPORTAL.Name = "GGTOTALPORTAL"
        Me.GGTOTALPORTAL.Visible = True
        Me.GGTOTALPORTAL.VisibleIndex = 17
        Me.GGTOTALPORTAL.Width = 120
        '
        'GRECOSTATUS
        '
        Me.GRECOSTATUS.Caption = "Reco Status"
        Me.GRECOSTATUS.FieldName = "RECOSTATUS"
        Me.GRECOSTATUS.Name = "GRECOSTATUS"
        Me.GRECOSTATUS.Visible = True
        Me.GRECOSTATUS.VisibleIndex = 18
        Me.GRECOSTATUS.Width = 120
        '
        'GSTR2MatchGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GSTR2MatchGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GSTR2 Match Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As Button
    Friend WithEvents CMDEXPORT As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVNOBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVDATEBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVNOPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVDATEPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMTBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMTBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMTBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMTBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGTOTALBOOKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMTPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMTPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMTPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMTPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGTOTALPORTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECOSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
