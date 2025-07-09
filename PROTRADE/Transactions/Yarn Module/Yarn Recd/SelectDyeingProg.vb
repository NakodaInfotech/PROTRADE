
Imports BL

Public Class SelectDyeingProg

    Public PARTYNAME As String = ""
    Public PROGNO As Integer = 0
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectYarnPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectYarnPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = ""
            If PROGNO <> 0 Then where = where & " AND PROGNO = " & PROGNO
            If PARTYNAME <> "" Then where = where & " AND NAME = '" & PARTYNAME & "'"
            Dim OBJCMN As New ClsCommon()
            Dim dt As DataTable = OBJCMN.search(" YARNDYEINGPROGRAM.PROG_NO AS PROGNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, YARNDYEINGPROGRAM.PROG_DATE AS DATE, YARNDYEINGPROGRAM_DESC.PROG_GRIDSRNO AS GRIDSRNO, ISNULL(YARNQUALITYMASTER.YARN_name, '') AS YARNQUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ROUND(YARNDYEINGPROGRAM_DESC.PROG_WT - YARNDYEINGPROGRAM_DESC.PROG_RECDWT, 2) AS WT, 'YARNDYEINGPROGRAM' AS [TYPE] ", "", " YARNDYEINGPROGRAM INNER JOIN YARNDYEINGPROGRAM_DESC ON YARNDYEINGPROGRAM.PROG_YEARID = YARNDYEINGPROGRAM_DESC.PROG_YEARID AND YARNDYEINGPROGRAM.PROG_NO = YARNDYEINGPROGRAM_DESC.PROG_NO INNER JOIN LEDGERS ON YARNDYEINGPROGRAM.PROG_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON YARNDYEINGPROGRAM_DESC.PROG_COLORID= COLORMASTER.COLOR_id LEFT OUTER JOIN YARNQUALITYMASTER ON YARNDYEINGPROGRAM_DESC.PROG_YARNQUALITYID = YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN DESIGNMASTER ON YARNDYEINGPROGRAM_DESC.PROG_DESIGNID = DESIGNMASTER.DESIGN_id", " AND YARNDYEINGPROGRAM_DESC.PROG_CLOSED='False' AND ROUND(YARNDYEINGPROGRAM_DESC.PROG_WT - YARNDYEINGPROGRAM_DESC.PROG_RECDWT,2) > 0 AND YARNDYEINGPROGRAM.PROG_YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            DT.Columns.Add("PROGNO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("PROGDATE")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("YARNQUALITY")
            DT.Columns.Add("DESIGNNO")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("WT")
            DT.Columns.Add("TYPE")

            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                DT.Rows.Add(dtrow("PROGNO"), dtrow("NAME"), dtrow("DATE"), Val(dtrow("GRIDSRNO")), dtrow("YARNQUALITY"), dtrow("DESIGNNO"), dtrow("COLOR"), Val(dtrow("WT")), dtrow("TYPE"))
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridquotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class