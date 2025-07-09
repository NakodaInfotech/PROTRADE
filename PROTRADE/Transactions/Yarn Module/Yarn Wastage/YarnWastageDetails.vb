Imports BL

Public Class YarnWastageDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub CMDEXIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub YarnISSUETOWARPERDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDEDIT_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                TOOLEXCEL_Click(sender, e)
            ElseIf e.KeyCode = Keys.R And e.Alt = True Then
                TOOLREFRESH_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub YarnISSUETOWARPERDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

          
            If FRMSTRING = "WASTAGEGODOWN" Then
                Me.Text = "Yarn Wastage at Godown"
                GGODOWN.Visible = True
                GNAME.Visible = False
            ElseIf FRMSTRING = "WASTAGEJOBBER" Then
                Me.Text = "Yarn Wastage From Jobber"
            End If

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
          If FRMSTRING = "WASTAGEGODOWN" Then
                dt = objclsCMST.search("  YARNWASTAGEGODOWN.YWASGODOWN_NO AS SRNO, YARNWASTAGEGODOWN.YWASGODOWN_DATE AS DATE, YARNWASTAGEGODOWN_DESC.YWASGODOWN_TYPE AS TYPE,'' AS NAME, YARNQUALITYMASTER.YARN_NAME AS QUALITY, YARNWASTAGEGODOWN_DESC.YWASGODOWN_WT AS WT, YARNWASTAGEGODOWN_DESC.YWASGODOWN_NARRATION AS NARRATION, MILLMASTER.MILL_NAME AS MILLNAME, COLORMASTER.COLOR_name AS COLOR, DESIGNMASTER.DESIGN_NO AS DESIGN, YARNWASTAGEGODOWN_DESC.YWASGODOWN_LOTNO AS LOTNO, YARNWASTAGEGODOWN_DESC.YWASGODOWN_CONES AS CONES, GODOWNMASTER.GODOWN_name AS GODOWN ", "", "  YARNWASTAGEGODOWN INNER JOIN YARNWASTAGEGODOWN_DESC ON YARNWASTAGEGODOWN.YWASGODOWN_NO = YARNWASTAGEGODOWN_DESC.YWASGODOWN_NO AND YARNWASTAGEGODOWN.YWASGODOWN_YEARID = YARNWASTAGEGODOWN_DESC.YWASGODOWN_YEARID INNER JOIN YARNQUALITYMASTER ON YARNWASTAGEGODOWN_DESC.YWASGODOWN_QUALITYID = YARNQUALITYMASTER.YARN_ID INNER JOIN GODOWNMASTER ON YARNWASTAGEGODOWN.YWASGODOWN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN DESIGNMASTER ON YARNWASTAGEGODOWN_DESC.YWASGODOWN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON YARNWASTAGEGODOWN_DESC.YWASGODOWN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNWASTAGEGODOWN_DESC.YWASGODOWN_MILLID = MILLMASTER.MILL_ID", " AND dbo.YARNWASTAGEGODOWN.YWASGODOWN_yearid=" & YearId & " ORDER by dbo.YARNWASTAGEGODOWN.YWASGODOWN_NO ")
            ElseIf FRMSTRING = "WASTAGEJOBBER" Then
                dt = objclsCMST.search("YARNWASTAGEJOBBER.YWASJOBBER_NO AS SRNO, YARNWASTAGEJOBBER.YWASJOBBER_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, '' AS GODOWN, YARNWASTAGEJOBBER_DESC.YWASJOBBER_TYPE AS TYPE, YARNQUALITYMASTER.YARN_NAME AS QUALITY, YARNWASTAGEJOBBER_DESC.YWASJOBBER_WT AS WT, YARNWASTAGEJOBBER_DESC.YWASJOBBER_NARRATION AS NARRATION, MILLMASTER.MILL_NAME AS MILLNAME, COLORMASTER.COLOR_name AS COLOR, YARNWASTAGEJOBBER_DESC.YWASJOBBER_LOTNO AS LOTNO,  YARNWASTAGEJOBBER_DESC.YWASJOBBER_CONES AS CONES, YARNWASTAGEJOBBER_DESC.YWASJOBBER_CONES AS CONES, DESIGNMASTER.DESIGN_NO AS DESIGN  ", "", " YARNWASTAGEJOBBER INNER JOIN LEDGERS ON YARNWASTAGEJOBBER.YWASJOBBER_LEDGERID = LEDGERS.Acc_id INNER JOIN YARNWASTAGEJOBBER_DESC ON YARNWASTAGEJOBBER.YWASJOBBER_NO = YARNWASTAGEJOBBER_DESC.YWASJOBBER_NO AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = YARNWASTAGEJOBBER_DESC.YWASJOBBER_YEARID INNER JOIN YARNQUALITYMASTER ON YARNWASTAGEJOBBER_DESC.YWASJOBBER_QUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN DESIGNMASTER ON YARNWASTAGEJOBBER_DESC.YWASJOBBER_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON YARNWASTAGEJOBBER_DESC.YWASJOBBER_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN MILLMASTER ON YARNWASTAGEJOBBER_DESC.YWASJOBBER_MILLID = MILLMASTER.MILL_ID ", " AND dbo.YARNWASTAGEJOBBER.YWASJOBBER_yearid=" & YearId & " ORDER by dbo.YARNWASTAGEJOBBER.YWASJOBBER_NO ")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal WASTAGENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objDO As New YarnWastage
                objDO.MdiParent = MDIMain
                objDO.EDIT = editval
                objDO.TEMPWASTAGENO = WASTAGENO
                objDO.FRMSTRING = FRMSTRING
                objDO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADD.Click
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

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            
            If FRMSTRING = "WASTAGEGODOWN" Then

                Dim PATH As String = Application.StartupPath & "\Wastage From Godown Details.XLS"
                Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
                opti.ShowGridLines = True
                opti.SheetName = "Wastage From Godown Details"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "Wastage From Godown Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)

            ElseIf FRMSTRING = "WASTAGEJOBBER" Then

                Dim PATH As String = Application.StartupPath & "\Wastage From Jobber Details.XLS"
                Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
                opti.ShowGridLines = True
                opti.SheetName = "Wastage From Jobber Details"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "Wastage From Jobber Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)

            End If
        Catch ex As Exception
            MsgBox("Wastage Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class