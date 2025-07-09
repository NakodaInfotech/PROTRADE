<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EwayBillFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GSUPPLYTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSUBTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDOCTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDOCNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDOCDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMPARTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMGSTIN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMADD1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMADD2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMPLACE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMPINCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMSTATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOPARTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOGSTIN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOADD1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOADD2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOPLACE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOPINCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOSTATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAXRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCESSAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTRANSMODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDISTANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTRANSID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTRANSDOCNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTRANSDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVEHICLENO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDEXPORT = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.BlendPanel2.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel2.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel2.Controls.Add(Me.CMDEXPORT)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1284, 581)
        Me.BlendPanel2.TabIndex = 1
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1260, 525)
        Me.gridbilldetails.TabIndex = 746
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSUPPLYTYPE, Me.GSUBTYPE, Me.GDOCTYPE, Me.GDOCNO, Me.GDOCDATE, Me.GFROMPARTY, Me.GFROMGSTIN, Me.GFROMADD1, Me.GFROMADD2, Me.GFROMPLACE, Me.GFROMPINCODE, Me.GFROMSTATE, Me.GTOPARTY, Me.GTOGSTIN, Me.GTOADD1, Me.GTOADD2, Me.GTOPLACE, Me.GTOPINCODE, Me.GTOSTATE, Me.GITEMNAME, Me.GDESC, Me.GHSNCODE, Me.GUNIT, Me.GQTY, Me.GTAXABLEAMT, Me.GTAXRATE, Me.GCGSTAMT, Me.GSGSTAMT, Me.GIGSTAMT, Me.GCESSAMT, Me.GTRANSMODE, Me.GDISTANCE, Me.GTRANSNAME, Me.GTRANSID, Me.GTRANSDOCNO, Me.GTRANSDATE, Me.GVEHICLENO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSUPPLYTYPE
        '
        Me.GSUPPLYTYPE.Caption = "Supply Type"
        Me.GSUPPLYTYPE.FieldName = "SUPPLYTYPE"
        Me.GSUPPLYTYPE.Name = "GSUPPLYTYPE"
        Me.GSUPPLYTYPE.Visible = True
        Me.GSUPPLYTYPE.VisibleIndex = 0
        '
        'GSUBTYPE
        '
        Me.GSUBTYPE.Caption = "Sub Type"
        Me.GSUBTYPE.FieldName = "SUBTYPE"
        Me.GSUBTYPE.Name = "GSUBTYPE"
        Me.GSUBTYPE.Visible = True
        Me.GSUBTYPE.VisibleIndex = 1
        '
        'GDOCTYPE
        '
        Me.GDOCTYPE.Caption = "Doc Type"
        Me.GDOCTYPE.FieldName = "DOCTYPE"
        Me.GDOCTYPE.Name = "GDOCTYPE"
        Me.GDOCTYPE.Visible = True
        Me.GDOCTYPE.VisibleIndex = 2
        '
        'GDOCNO
        '
        Me.GDOCNO.Caption = "Doc No"
        Me.GDOCNO.FieldName = "DOCNO"
        Me.GDOCNO.Name = "GDOCNO"
        Me.GDOCNO.Visible = True
        Me.GDOCNO.VisibleIndex = 3
        Me.GDOCNO.Width = 100
        '
        'GDOCDATE
        '
        Me.GDOCDATE.Caption = "Doc Date"
        Me.GDOCDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDOCDATE.FieldName = "DOCDATE"
        Me.GDOCDATE.Name = "GDOCDATE"
        Me.GDOCDATE.Visible = True
        Me.GDOCDATE.VisibleIndex = 4
        '
        'GFROMPARTY
        '
        Me.GFROMPARTY.Caption = "From Party"
        Me.GFROMPARTY.FieldName = "FROMPARTY"
        Me.GFROMPARTY.Name = "GFROMPARTY"
        Me.GFROMPARTY.Visible = True
        Me.GFROMPARTY.VisibleIndex = 5
        Me.GFROMPARTY.Width = 200
        '
        'GFROMGSTIN
        '
        Me.GFROMGSTIN.Caption = "From GSTIN"
        Me.GFROMGSTIN.FieldName = "FROMGSTIN"
        Me.GFROMGSTIN.Name = "GFROMGSTIN"
        Me.GFROMGSTIN.Visible = True
        Me.GFROMGSTIN.VisibleIndex = 6
        Me.GFROMGSTIN.Width = 100
        '
        'GFROMADD1
        '
        Me.GFROMADD1.Caption = "From Address 1"
        Me.GFROMADD1.FieldName = "FROMADDRESS1"
        Me.GFROMADD1.Name = "GFROMADD1"
        Me.GFROMADD1.Visible = True
        Me.GFROMADD1.VisibleIndex = 7
        Me.GFROMADD1.Width = 200
        '
        'GFROMADD2
        '
        Me.GFROMADD2.Caption = "From Address 2"
        Me.GFROMADD2.FieldName = "FROMADDRESS2"
        Me.GFROMADD2.Name = "GFROMADD2"
        Me.GFROMADD2.Visible = True
        Me.GFROMADD2.VisibleIndex = 8
        Me.GFROMADD2.Width = 200
        '
        'GFROMPLACE
        '
        Me.GFROMPLACE.Caption = "From Place"
        Me.GFROMPLACE.FieldName = "FROMPLACE"
        Me.GFROMPLACE.Name = "GFROMPLACE"
        Me.GFROMPLACE.Visible = True
        Me.GFROMPLACE.VisibleIndex = 9
        Me.GFROMPLACE.Width = 120
        '
        'GFROMPINCODE
        '
        Me.GFROMPINCODE.Caption = "From Pin Code"
        Me.GFROMPINCODE.FieldName = "FROMPINCODE"
        Me.GFROMPINCODE.Name = "GFROMPINCODE"
        Me.GFROMPINCODE.Visible = True
        Me.GFROMPINCODE.VisibleIndex = 10
        '
        'GFROMSTATE
        '
        Me.GFROMSTATE.Caption = "From State"
        Me.GFROMSTATE.FieldName = "FROMSTATE"
        Me.GFROMSTATE.Name = "GFROMSTATE"
        Me.GFROMSTATE.Visible = True
        Me.GFROMSTATE.VisibleIndex = 11
        Me.GFROMSTATE.Width = 120
        '
        'GTOPARTY
        '
        Me.GTOPARTY.Caption = "To Party"
        Me.GTOPARTY.FieldName = "TOPARTY"
        Me.GTOPARTY.Name = "GTOPARTY"
        Me.GTOPARTY.Visible = True
        Me.GTOPARTY.VisibleIndex = 12
        Me.GTOPARTY.Width = 200
        '
        'GTOGSTIN
        '
        Me.GTOGSTIN.Caption = "To GSTIN"
        Me.GTOGSTIN.FieldName = "TOGSTIN"
        Me.GTOGSTIN.Name = "GTOGSTIN"
        Me.GTOGSTIN.Visible = True
        Me.GTOGSTIN.VisibleIndex = 13
        Me.GTOGSTIN.Width = 100
        '
        'GTOADD1
        '
        Me.GTOADD1.Caption = "To Address 1"
        Me.GTOADD1.FieldName = "TOADDRESS1"
        Me.GTOADD1.Name = "GTOADD1"
        Me.GTOADD1.Visible = True
        Me.GTOADD1.VisibleIndex = 14
        Me.GTOADD1.Width = 200
        '
        'GTOADD2
        '
        Me.GTOADD2.Caption = "To Address 2"
        Me.GTOADD2.FieldName = "TOADDRESS2"
        Me.GTOADD2.Name = "GTOADD2"
        Me.GTOADD2.Visible = True
        Me.GTOADD2.VisibleIndex = 15
        Me.GTOADD2.Width = 200
        '
        'GTOPLACE
        '
        Me.GTOPLACE.Caption = "To Place"
        Me.GTOPLACE.FieldName = "TOPLACE"
        Me.GTOPLACE.Name = "GTOPLACE"
        Me.GTOPLACE.Visible = True
        Me.GTOPLACE.VisibleIndex = 16
        Me.GTOPLACE.Width = 120
        '
        'GTOPINCODE
        '
        Me.GTOPINCODE.Caption = "To Pin Code"
        Me.GTOPINCODE.FieldName = "TOPINCODE"
        Me.GTOPINCODE.Name = "GTOPINCODE"
        Me.GTOPINCODE.Visible = True
        Me.GTOPINCODE.VisibleIndex = 17
        '
        'GTOSTATE
        '
        Me.GTOSTATE.Caption = "To State"
        Me.GTOSTATE.FieldName = "TOSTATE"
        Me.GTOSTATE.Name = "GTOSTATE"
        Me.GTOSTATE.Visible = True
        Me.GTOSTATE.VisibleIndex = 18
        Me.GTOSTATE.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 19
        Me.GITEMNAME.Width = 200
        '
        'GDESC
        '
        Me.GDESC.Caption = "Description"
        Me.GDESC.FieldName = "ITEMDESCRIPTION"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.Visible = True
        Me.GDESC.VisibleIndex = 20
        Me.GDESC.Width = 200
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 21
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 22
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.DisplayFormat.FormatString = "0.00"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 23
        '
        'GTAXABLEAMT
        '
        Me.GTAXABLEAMT.Caption = "Value"
        Me.GTAXABLEAMT.FieldName = "TAXABLEAMT"
        Me.GTAXABLEAMT.Name = "GTAXABLEAMT"
        Me.GTAXABLEAMT.Visible = True
        Me.GTAXABLEAMT.VisibleIndex = 24
        Me.GTAXABLEAMT.Width = 100
        '
        'GTAXRATE
        '
        Me.GTAXRATE.Caption = "Tax Rate"
        Me.GTAXRATE.FieldName = "TAXRATE"
        Me.GTAXRATE.Name = "GTAXRATE"
        Me.GTAXRATE.Visible = True
        Me.GTAXRATE.VisibleIndex = 25
        Me.GTAXRATE.Width = 100
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt"
        Me.GCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 26
        Me.GCGSTAMT.Width = 100
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt"
        Me.GSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 27
        Me.GSGSTAMT.Width = 100
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt"
        Me.GIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 28
        Me.GIGSTAMT.Width = 100
        '
        'GCESSAMT
        '
        Me.GCESSAMT.Caption = "Cess Amt"
        Me.GCESSAMT.DisplayFormat.FormatString = "0.00"
        Me.GCESSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCESSAMT.FieldName = "CESSAMT"
        Me.GCESSAMT.Name = "GCESSAMT"
        Me.GCESSAMT.Visible = True
        Me.GCESSAMT.VisibleIndex = 29
        Me.GCESSAMT.Width = 100
        '
        'GTRANSMODE
        '
        Me.GTRANSMODE.Caption = "Trans Mode"
        Me.GTRANSMODE.FieldName = "TRANSMODE"
        Me.GTRANSMODE.Name = "GTRANSMODE"
        Me.GTRANSMODE.Visible = True
        Me.GTRANSMODE.VisibleIndex = 30
        Me.GTRANSMODE.Width = 150
        '
        'GDISTANCE
        '
        Me.GDISTANCE.Caption = "Distance (Kms)"
        Me.GDISTANCE.FieldName = "DISTANCE"
        Me.GDISTANCE.Name = "GDISTANCE"
        Me.GDISTANCE.Visible = True
        Me.GDISTANCE.VisibleIndex = 31
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Trans Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        Me.GTRANSNAME.Visible = True
        Me.GTRANSNAME.VisibleIndex = 32
        Me.GTRANSNAME.Width = 200
        '
        'GTRANSID
        '
        Me.GTRANSID.Caption = "Trans ID"
        Me.GTRANSID.FieldName = "TRANSID"
        Me.GTRANSID.Name = "GTRANSID"
        Me.GTRANSID.Visible = True
        Me.GTRANSID.VisibleIndex = 33
        '
        'GTRANSDOCNO
        '
        Me.GTRANSDOCNO.Caption = "Trans Doc No"
        Me.GTRANSDOCNO.FieldName = "TRANSDOCNO"
        Me.GTRANSDOCNO.Name = "GTRANSDOCNO"
        Me.GTRANSDOCNO.Visible = True
        Me.GTRANSDOCNO.VisibleIndex = 34
        '
        'GTRANSDATE
        '
        Me.GTRANSDATE.Caption = "Trans Date"
        Me.GTRANSDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GTRANSDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GTRANSDATE.FieldName = "TRANSDOCDATE"
        Me.GTRANSDATE.Name = "GTRANSDATE"
        Me.GTRANSDATE.Visible = True
        Me.GTRANSDATE.VisibleIndex = 35
        '
        'GVEHICLENO
        '
        Me.GVEHICLENO.Caption = "Vehicle No"
        Me.GVEHICLENO.FieldName = "VEHICLENO"
        Me.GVEHICLENO.Name = "GVEHICLENO"
        Me.GVEHICLENO.Visible = True
        Me.GVEHICLENO.VisibleIndex = 36
        '
        'CMDEXPORT
        '
        Me.CMDEXPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXPORT.FlatAppearance.BorderSize = 0
        Me.CMDEXPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXPORT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXPORT.Location = New System.Drawing.Point(551, 543)
        Me.CMDEXPORT.Name = "CMDEXPORT"
        Me.CMDEXPORT.Size = New System.Drawing.Size(88, 28)
        Me.CMDEXPORT.TabIndex = 8
        Me.CMDEXPORT.Text = "&Export"
        Me.CMDEXPORT.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(645, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(457, 543)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(88, 28)
        Me.CMDREFRESH.TabIndex = 747
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'EwayBillFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "EwayBillFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Eway Bill Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXPORT As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSUPPLYTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOCTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOCNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOCDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMPARTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMADD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMADD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMPLACE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMPINCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPARTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOADD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOADD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPLACE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPINCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCESSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSMODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISTANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSDOCNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEHICLENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
End Class
