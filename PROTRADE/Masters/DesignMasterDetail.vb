
Imports BL

Public Class DesignMasterDetail

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub DesignMasterDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DESIGN MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub DesignMasterDetail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.A) Then   'for New
            showform(False, 0)
        End If
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("DESIGNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objClsCommon As New ClsCommonMaster
            Dim dttable As DataTable = objClsCommon.search(" DESIGN_NO AS DESIGNNO,ISNULL(MILLMASTER.MILL_NAME,'') AS MILLNAME, ISNULL(DESIGN_CADNO,'') AS CADNO, ISNULL(DESIGN_PURRATE, 0) AS PURRATE, ISNULL(DESIGN_SALERATE, 0) AS SALERATE, ISNULL(DESIGN_WRATE, 0) AS WRATE, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME ", "", "DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID  LEFT OUTER JOIN MILLMASTER ON DESIGNMASTER.DESIGN_MILLID = MILLMASTER.MILL_ID ", " and design_yearid = " & YearId)
            GRIDBILLDETAILS.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal NAME As String)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDESIGN As New DesignMaster
            OBJDESIGN.EDIT = EDITVAL
            OBJDESIGN.MdiParent = MDIMain
            OBJDESIGN.tempdesignno = Name
            OBJDESIGN.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("DESIGNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignMasterDetail_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                GFABRIC.Visible = True
                GDYEING.Visible = True
                GJOBWORK.Visible = True
                GFINISHING.Visible = True
                GEXTRA.Visible = True
                GTOTAL.Visible = True
            End If
            If FETCHITEMWISEDESIGN = True Then GITEMNAME.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Design Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Design Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Design Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            MsgBox("Design Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class