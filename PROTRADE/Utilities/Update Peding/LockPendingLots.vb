
Imports BL

Public Class LockPendingLots

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LockPendingLots_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LockPendingLots_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable

            If RBPENDING.Checked = True Then
                If LOTSTATUSONMTRS = False Then
                    dt = objclsCMST.search("*", "", " LOT_VIEW ", " AND LOT_VIEW.YEARID=" & YearId & " AND LOT_VIEW.BALPCS > 0 AND LOT_VIEW.LOTCOMPLETED = 'FALSE' ORDER BY PARTYNAME, LOTNO")
                Else
                    dt = objclsCMST.search("*", "", " LOT_VIEW ", " AND LOT_VIEW.YEARID=" & YearId & " AND (LOT_VIEW.LOTCOMPLETED = 'FALSE') ORDER BY PARTYNAME, LOTNO")
                End If
            Else
                dt = objclsCMST.search("*", "", " LOT_VIEW ", " AND LOT_VIEW.YEARID=" & YearId & " AND (LOT_VIEW.LOTCOMPLETED = 'TRUE') ORDER BY PARTYNAME, LOTNO")
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Lock-Unlock Pending Lots.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Lock-Unlock Pending Lots"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Lock-Unlock Pending Lots", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Pending Lot Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                Dim DYEINGID As Integer = 0
                DT = OBJCMN.search("ACC_ID AS DYEINGID", "", " LEDGERS", " AND ACC_CMPNAME = '" & DTROW("JOBBERNAME") & "' AND ACC_YEARID = " & YearId)
                DYEINGID = Val(DT.Rows(0).Item("DYEINGID"))
                If RBPENDING.Checked = True Then
                    If DTROW("GRNTYPE") = "OPENING" Then DT = OBJCMN.Execute_Any_String(" UPDATE STOCKMASTER SET SM_LOTCOMPLETED = 1 WHERE SM_NO = " & DTROW("GRNNO") & " AND SM_LOTNO = " & DTROW("LOTNO") & " AND SM_YEARID = " & YearId, "", "")
                    If DTROW("GRNTYPE") = "CHECKING" Then DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_LOTCOMPLETED = 1 WHERE GRN_NO = " & DTROW("GRNNO") & " AND GRN_PLOTNO = " & DTROW("LOTNO") & " AND GRN_TYPE = 'Job Work' AND GRN_YEARID = " & YearId, "", "")
                    If DTROW("GRNTYPE") = "JOBOUT" Then DT = OBJCMN.Execute_Any_String(" UPDATE JOBOUT SET JO_LOTCOMPLETED = 1 WHERE JO_NO = " & DTROW("GRNNO") & " AND JO_LOTNO = " & DTROW("LOTNO") & " AND JO_YEARID = " & YearId, "", "")
                    DT = OBJCMN.Execute_Any_String("INSERT INTO LOTCOMPLETED VALUES (" & DTROW("LOTNO") & "," & DYEINGID & "," & DTROW("GRNNO") & ",'" & DTROW("GRNTYPE") & "'," & CmpId & "," & YearId & ")", "", "")
                Else
                    If DTROW("GRNTYPE") = "OPENING" Then DT = OBJCMN.Execute_Any_String(" UPDATE STOCKMASTER SET SM_LOTCOMPLETED = 0 WHERE SM_NO = " & DTROW("GRNNO") & " AND SM_LOTNO = " & DTROW("LOTNO") & " AND SM_YEARID = " & YearId, "", "")
                    If DTROW("GRNTYPE") = "CHECKING" Then DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_LOTCOMPLETED = 0 WHERE GRN_NO = " & DTROW("GRNNO") & " AND GRN_PLOTNO = " & DTROW("LOTNO") & " AND GRN_TYPE = 'Job Work' AND GRN_YEARID = " & YearId, "", "")
                    If DTROW("GRNTYPE") = "JOBOUT" Then DT = OBJCMN.Execute_Any_String(" UPDATE JOBOUT SET JO_LOTCOMPLETED = 0 WHERE JO_NO = " & DTROW("GRNNO") & " AND JO_LOTNO = " & DTROW("LOTNO") & " AND JO_YEARID = " & YearId, "", "")
                    DT = OBJCMN.Execute_Any_String("DELETE FROM LOTCOMPLETED WHERE LOTNO =" & DTROW("LOTNO") & " AND DYEINGID = " & DYEINGID & " AND GRNNO = " & Val(DTROW("GRNNO")) & " AND GRNTYPE = '" & DTROW("GRNTYPE") & "' AND YEARID = " & YearId, "", "")
                End If
            Next
            MsgBox("Details Updated Successfully")
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            fillgrid()
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


End Class