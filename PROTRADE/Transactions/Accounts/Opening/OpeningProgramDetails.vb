
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class OpeningProgramDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub OpeningProgramDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpeningProgramDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" OPENINGPROGRAMMASTER.OPPROGRAM_NO AS SRNO, OPENINGPROGRAMMASTER.OPPROGRAM_DATE AS DATE, ISNULL(OPENINGPROGRAMMASTER.OPPROGRAM_CARDRECDATE, '') AS CARDRECDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(DESIGNMASTER.DESIGN_CADNO,'') AS CADNO, ISNULL(ITEMMASTER.ITEM_GREYWIDTH,'') AS GREYWIDTH, ISNULL(ITEMMASTER.ITEM_WIDTH,'') AS WIDTH,  ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_URGENT,0) AS URGENT, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PCS,0) AS PCS, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_LOTNO,0) AS LOTNO,  ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PROGISSDATE,'') AS PROGISSDATE, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_STATUS,'') AS STATUS, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PRODCUTTING,'') AS PRODCUTTING,  ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_FINISHCUTTING,'') AS FINISHCUTTING, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_INWARDDATE,'') AS INWARDDATE, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_RECDPCS,0) AS RECDPCS, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_BARCODE,'') AS BARCODE ", "", " OPENINGPROGRAMMASTER INNER JOIN OPENINGPROGRAMMASTER_DESC ON OPENINGPROGRAMMASTER.OPPROGRAM_NO = OPENINGPROGRAMMASTER_DESC.OPPROGRAM_NO AND  OPENINGPROGRAMMASTER.OPPROGRAM_YEARID = OPENINGPROGRAMMASTER_DESC.OPPROGRAM_YEARID INNER JOIN ITEMMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON OPENINGPROGRAMMASTER.OPPROGRAM_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND OPENINGPROGRAMMASTER.OPPROGRAM_YEARID = " & YearId & " ORDER BY OPENINGPROGRAMMASTER.OPPROGRAM_NO, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_GRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PROGRAMNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJPROGRAM As New OpeningProgramMaster
                OBJPROGRAM.MdiParent = MDIMain
                OBJPROGRAM.EDIT = editval
                OBJPROGRAM.PROGRAMNO = PROGRAMNO
                OBJPROGRAM.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("RECDPCS"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELEXPORT.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Program Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Program Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Program Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Porgram Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub OpeningProgramDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName <> "AVIS" Then
                GCARDRECDATE.Visible = False
                GCADNO.Visible = False
                GGREYWIDTH.Visible = False
                GPROGISSDATE.Visible = False
                GSTATUS.Visible = False
                GPRODCUTTING.Visible = False
                GFINISHCUTTING.Visible = False
                GINWARDDATE.Visible = False
            Else
                GPCS.Caption = "Mtrs"
                GRECDPCS.Caption = "Recd Mtrs"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class