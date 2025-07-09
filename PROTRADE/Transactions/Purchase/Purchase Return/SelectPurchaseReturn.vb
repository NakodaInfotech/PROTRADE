Imports BL
Imports System.Windows.Forms

Public Class SelectPurchaseReturn

    Dim tempindex, i As Integer
    Dim SELECTIONFORMULA As String = ""
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public DT As New DataTable
    Public PARTYNAME As String = ""

    Private Sub SelectPurchaseReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMBQUALITY.SelectedItem = Nothing
        CMBDESIGN.SelectedItem = Nothing
        CMBSHADE.SelectedItem = Nothing
        CMBQUALITY.Focus()
        fillgrid(" ")
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPurchaseReturn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            If PARTYNAME <> "" Then WHERE = WHERE & " AND LEDGERS.Acc_cmpname = '" & PARTYNAME & "'"

            Dim objclspreq As New ClsCommon()
            'Dim DT As DataTable = objclspreq.search(" PURCHASEMASTER.BILL_NO AS BILLNO, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_DATE AS DATE, ISNULL(PURCHASEMASTER.BILL_PARTYBILLNO, '') AS PARTYBILL, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYDATE, ISNULL(AGENT.Acc_cmpname, '') AS AGENT, ISNULL(PURCHASEMASTER.BILL_REFNO, '') AS REFNO, ISNULL(FORMTYPE.FORM_NAME, '') AS FORM, ISNULL(TRANS.Acc_cmpname, '') AS TRANS, ISNULL(PURCHASEMASTER.BILL_LRNO, '') AS LRNO, PURCHASEMASTER.BILL_LRDATE AS LRDATE, ISNULL(AGENT.Acc_add, '') AS ADDRESS, PURCHASEMASTER.BILL_TOTALQTY AS PCS, PURCHASEMASTER.BILL_TOTALMTRS AS MTRS, PURCHASEMASTER.BILL_BILLAMT AS BILLAMT, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS PURREGNAME ", "", "  FORMTYPE RIGHT OUTER JOIN LEDGERS AS AGENT RIGHT OUTER JOIN PURCHASEMASTER_FORMTYPE RIGHT OUTER JOIN PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id ON PURCHASEMASTER_FORMTYPE.BILL_NO = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_FORMTYPE.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID LEFT OUTER JOIN LEDGERS AS TRANS ON PURCHASEMASTER.BILL_TRANSNAMEID = TRANS.Acc_id ON AGENT.Acc_id = PURCHASEMASTER.BILL_AGENTID ON FORMTYPE.FORM_ID = PURCHASEMASTER_FORMTYPE.BILL_FORMID AND FORMTYPE.FORM_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID ", " " & WHERE & " AND PURCHASEMASTER.BILL_YEARID = " & YearId & " AND PURCHASEMASTER.BILL_RETURN = 0 AND PURCHASEMASTER.BILL_AMTPAID = 0 AND PURCHASEMASTER.BILL_EXTRAAMT = 0 ORDER BY PURCHASEMASTER.BILL_NO ")
            Dim DT As DataTable = objclspreq.search("*", "", " (SELECT OPENINGBILL.BILL_NO AS BILLNO, LEDGERS.Acc_cmpname AS NAME, OPENINGBILL.BILL_DATE AS DATE, ISNULL(OPENINGBILL.BILL_INITIALS, '') AS PARTYBILL, OPENINGBILL.BILL_DATE AS PARTYDATE, ISNULL(AGENT.Acc_cmpname, '') AS AGENT, '' AS REFNO, '' AS FORM, '' AS TRANS, '' AS LRNO, GETDATE() AS LRDATE, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS, 0 AS PCS, 0 AS MTRS, OPENINGBILL.BILL_AMT AS BILLAMT, OPENINGBILL.BILL_AMT AS GRANDTOTAL, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS PURREGNAME, 'OPENING' AS INVOICETYPE, OPENINGBILL.BILL_INITIALS AS BILLINITIALS  FROM OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN LEDGERS AS AGENT ON OPENINGBILL.BILL_AGENTID = AGENT.ACC_ID INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id WHERE OPENINGBILL.BILL_YEARID = " & YearId & WHERE & " AND OPENINGBILL.BILL_BALANCE > 0 UNION ALL SELECT PURCHASEMASTER.BILL_NO AS BILLNO, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_DATE AS DATE, ISNULL(PURCHASEMASTER.BILL_PARTYBILLNO, '') AS PARTYBILL, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYDATE, ISNULL(AGENT.Acc_cmpname, '') AS AGENT, ISNULL(PURCHASEMASTER.BILL_REFNO, '') AS REFNO, ISNULL(FORMTYPE.FORM_NAME, '') AS FORM, ISNULL(TRANS.Acc_cmpname, '') AS TRANS, ISNULL(PURCHASEMASTER.BILL_LRNO, '') AS LRNO, PURCHASEMASTER.BILL_LRDATE AS LRDATE, ISNULL(AGENT.Acc_add, '') AS ADDRESS, PURCHASEMASTER.BILL_TOTALQTY AS PCS, PURCHASEMASTER.BILL_TOTALMTRS AS MTRS, PURCHASEMASTER.BILL_BILLAMT AS BILLAMT, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS PURREGNAME, 'PURCHASE' AS INVOICETYPE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS  FROM FORMTYPE RIGHT OUTER JOIN LEDGERS AS AGENT RIGHT OUTER JOIN PURCHASEMASTER_FORMTYPE RIGHT OUTER JOIN PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id ON PURCHASEMASTER_FORMTYPE.BILL_NO = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_FORMTYPE.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID LEFT OUTER JOIN LEDGERS AS TRANS ON PURCHASEMASTER.BILL_TRANSNAMEID = TRANS.Acc_id ON AGENT.Acc_id = PURCHASEMASTER.BILL_AGENTID ON FORMTYPE.FORM_ID = PURCHASEMASTER_FORMTYPE.BILL_FORMID AND FORMTYPE.FORM_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID WHERE PURCHASEMASTER.BILL_YEARID = " & YearId & WHERE & " AND PURCHASEMASTER.BILL_BALANCE > 0) AS T ", "  ORDER BY T.BILLNO ")
            GRIDRET.DataSource = DT
            If DT.Rows.Count > 0 Then

                If ADDCOL = False Then
                    GRIDRET.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                Dim I As Integer = 0
                GRIDRET.Columns(I).Width = 40 'CHECK BOK
                I = I + 1

                GRIDRET.Columns(I).Width = 50 'BILL NO
                GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                I = I + 1

                GRIDRET.Columns(I).Width = 140 'NAME
                I = I + 1

                GRIDRET.Columns(I).Width = 80 'DATE
                I = I + 1
            
                GRIDRET.Columns(I).Width = 70 'PARTY BILL NO
                I = I + 1
                GRIDRET.Columns(I).Width = 80 'PARTY DATE
                I = I + 1
                GRIDRET.Columns(I).Width = 100 'AGENT
                I = I + 1
                GRIDRET.Columns(I).Width = 60 'REFF NO
                I = I + 1
                GRIDRET.Columns(I).Width = 60 'FORM
                I = I + 1

                GRIDRET.Columns(I).Visible = False 'TRANS
                I = I + 1
                GRIDRET.Columns(I).Visible = False 'LRNO
                I = I + 1
                GRIDRET.Columns(I).Visible = False 'LRDATE
                I = I + 1
                GRIDRET.Columns(I).Visible = False 'ADDRESS
                I = I + 1

                GRIDRET.Columns(I).Width = 50 'PCS
                GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRET.Columns(I).DefaultCellStyle.Format = "N2"
                I = I + 1

                GRIDRET.Columns(I).Width = 50 'MTRS
                GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRET.Columns(I).DefaultCellStyle.Format = "N2"
                I = I + 1

                GRIDRET.Columns(I).Width = 80 'BILL AMT
                GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRET.Columns(I).DefaultCellStyle.Format = "N2"
                I = I + 1

                GRIDRET.Columns(I).Width = 80 'GRAND TOTAL
                GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRET.Columns(I).DefaultCellStyle.Format = "N2"
                I = I + 1

                GRIDRET.Columns(I).Visible = False 'PURREGNAME
                I = I + 1
                GRIDRET.Columns(I).Visible = False 'INVOICETYPE
                I = I + 1
                GRIDRET.Columns(I).Visible = False 'BILLINITIALS
                I = I + 1


                GRIDRET.FirstDisplayedScrollingRowIndex = GRIDRET.RowCount - 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub gridWO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRET.CellClick
        If e.RowIndex >= 0 Then
            With GRIDRET.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim objclspreq As New ClsCommon()
            DT.Columns.Add("BILLNO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("DATE")
            DT.Columns.Add("PARTYBILL")
            DT.Columns.Add("PARTYDATE")
            DT.Columns.Add("AGENT")
            DT.Columns.Add("REFNO")
            DT.Columns.Add("FORM")
            DT.Columns.Add("TRANS")
            DT.Columns.Add("LRNO")
            DT.Columns.Add("LRDATE")
            DT.Columns.Add("ADDRESS")
            DT.Columns.Add("PCS")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("BILLAMT")
            DT.Columns.Add("GRANDTOTAL")
            DT.Columns.Add("PURREGNAME")
            DT.Columns.Add("INVOICETYPE")
            DT.Columns.Add("BILLINITIALS")

            For Each ROW As DataGridViewRow In GRIDRET.Rows
                If ROW.Cells(0).Value = True Then
                    DT.Rows.Add(ROW.Cells(1).Value, ROW.Cells(2).Value, ROW.Cells(3).Value, ROW.Cells(4).Value, ROW.Cells(5).Value, ROW.Cells(6).Value, ROW.Cells(7).Value, ROW.Cells(8).Value, ROW.Cells(9).Value, ROW.Cells(10).Value, ROW.Cells(11).Value, ROW.Cells(12).Value, ROW.Cells(13).Value, ROW.Cells(14).Value, ROW.Cells(15).Value, ROW.Cells(16).Value, ROW.Cells(17).Value, ROW.Cells(18).Value, ROW.Cells(19).Value)
                End If
            Next
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class