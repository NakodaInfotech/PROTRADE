
Imports BL
Imports System.Windows.Forms

Public Class GRNCheckingDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
           
            fillgrid(" and dbo.CHECKINGMASTER.CHECK_CMPID=" & CmpId & " and dbo.CHECKINGMASTER.CHECK_locationid=" & Locationid & " and dbo.CHECKINGMASTER.CHECK_yearid=" & YearId & " order by dbo.CHECKINGMASTER.CHECK_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CHECKINGMASTER.CHECK_NO AS CHECKNO, CHECKINGMASTER.CHECK_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, CHECKINGMASTER.CHECK_LOTNO AS LOTNO, CHECKINGMASTER.CHECK_BALPCS AS PCS, CHECKINGMASTER.CHECK_BALMTRS AS MTRS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY ", "", "  CHECKINGMASTER INNER JOIN LEDGERS AS JOBBERLEDGERS ON CHECKINGMASTER.CHECK_LEDGERID = JOBBERLEDGERS.Acc_id AND CHECKINGMASTER.CHECK_CMPID = JOBBERLEDGERS.Acc_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = JOBBERLEDGERS.Acc_locationid AND CHECKINGMASTER.CHECK_YEARID = JOBBERLEDGERS.Acc_yearid LEFT OUTER JOIN DESIGNMASTER ON CHECKINGMASTER.CHECK_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON CHECKINGMASTER.CHECK_YEARID = QUALITYMASTER.QUALITY_yearid AND CHECKINGMASTER.CHECK_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND CHECKINGMASTER.CHECK_CMPID = QUALITYMASTER.QUALITY_cmpid AND CHECKINGMASTER.CHECK_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON CHECKINGMASTER.CHECK_YEARID = ITEMMASTER.item_yearid AND CHECKINGMASTER.CHECK_LOCATIONID = ITEMMASTER.item_locationid AND CHECKINGMASTER.CHECK_CMPID = ITEMMASTER.item_cmpid AND CHECKINGMASTER.CHECK_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON CHECKINGMASTER.CHECK_VENDORID = LEDGERS.Acc_id AND CHECKINGMASTER.CHECK_CMPID = LEDGERS.Acc_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = LEDGERS.Acc_locationid AND CHECKINGMASTER.CHECK_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal GRNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objCHECKINGMASTER As New GRNChecking
                objCHECKINGMASTER.MdiParent = MDIMain
                objCHECKINGMASTER.edit = editval
                objCHECKINGMASTER.TEMPCHECKINGNO = GRNNO
                objCHECKINGMASTER.Show()
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CHECKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CHECKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   
    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Checking Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Checking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Checking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Checking Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class