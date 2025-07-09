
Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class UpdateProgGivenDate

    Private Sub UpdateProgGivenDate_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateProgGivenDate_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = ""
            If RBPENDING.Checked = True Then
                WHERECLAUSE = " AND (ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE,'') = '' OR ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE,'') = '__/__/____')"
                gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 0
                gridbill.OptionsSelection.MultiSelect = False
                gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
            Else
                WHERECLAUSE = " AND ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE,'') <> '' AND ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE,'') <> '__/__/____'"
                gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
                gridbill.OptionsSelection.MultiSelect = True
                gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            End If

            Dim OBJCMN As New ClsCommonMaster
            'Dim dt As DataTable = OBJCMN.search(" ALLPROGRAMMASTER.PROGRAM_NO AS SRNO, ALLPROGRAMMASTER_DESC.PROGRAM_GRIDSRNO AS GRIDSRNO, ALLPROGRAMMASTER.PROGRAM_DATE AS DATE, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE, '') AS PROGISSDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(DESIGNMASTER.DESIGN_CADNO,'') AS CADNO, ISNULL(ITEMMASTER.ITEM_GREYWIDTH,'') AS GREYWIDTH, ISNULL(ITEMMASTER.ITEM_WIDTH,'') AS WIDTH,  ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PCS,0) AS MTRS, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_LOTNO,0) AS LOTNO,  ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE,'') AS PROGISSDATE, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_STATUS,'') AS STATUS, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PRODCUTTING,'') AS PRODCUTTING,  ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_FINISHCUTTING,'') AS FINISHCUTTING, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_INWARDDATE,'') AS INWARDDATE, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_RECDPCS,0) AS RECDPCS ", "", " ALLPROGRAMMASTER INNER JOIN ALLPROGRAMMASTER_DESC ON ALLPROGRAMMASTER.PROGRAM_NO = ALLPROGRAMMASTER_DESC.PROGRAM_NO AND  ALLPROGRAMMASTER.PROGRAM_YEARID = ALLPROGRAMMASTER_DESC.PROGRAM_YEARID INNER JOIN ITEMMASTER ON ALLPROGRAMMASTER_DESC.PROGRAM_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ALLPROGRAMMASTER.PROGRAM_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON ALLPROGRAMMASTER_DESC.PROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON ALLPROGRAMMASTER_DESC.PROGRAM_DESIGNID = DESIGNMASTER.DESIGN_id  ", WHERECLAUSE & " AND ISNULL(PROGRAM_LEDGERID,0) <> 0 AND ALLPROGRAMMASTER.PROGRAM_YEARID = " & YearId & " ORDER BY ALLPROGRAMMASTER.PROGRAM_NO, ALLPROGRAMMASTER_DESC.PROGRAM_GRIDSRNO")
            Dim dt As DataTable = OBJCMN.search(" ALLPROGRAMMASTER.PROGRAM_NO AS SRNO, ALLPROGRAMMASTER_DESC.PROGRAM_GRIDSRNO AS GRIDSRNO, ALLPROGRAMMASTER.PROGRAM_DATE AS DATE, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE, '') AS PROGISSDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(DESIGNMASTER.DESIGN_CADNO,'') AS CADNO, ISNULL(ITEMMASTER.ITEM_GREYWIDTH,'') AS GREYWIDTH, ISNULL(ITEMMASTER.ITEM_WIDTH,'') AS WIDTH,  ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PCS,0) AS MTRS, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_LOTNO,0) AS LOTNO,  ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PROGISSDATE,'') AS PROGISSDATE, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_STATUS,'') AS STATUS, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_PRODCUTTING,'') AS PRODCUTTING,  ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_FINISHCUTTING,'') AS FINISHCUTTING, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_INWARDDATE,'') AS INWARDDATE, ISNULL(ALLPROGRAMMASTER_DESC.PROGRAM_RECDPCS,0) AS RECDPCS, ALLPROGRAMMASTER.PROGRAM_TYPE AS TYPE ", "", " ALLPROGRAMMASTER INNER JOIN ALLPROGRAMMASTER_DESC ON ALLPROGRAMMASTER.PROGRAM_NO = ALLPROGRAMMASTER_DESC.PROGRAM_NO  AND ALLPROGRAMMASTER.PROGRAM_TYPE = ALLPROGRAMMASTER_DESC.PROGRAM_TYPE AND  ALLPROGRAMMASTER.PROGRAM_YEARID = ALLPROGRAMMASTER_DESC.PROGRAM_YEARID INNER JOIN ITEMMASTER ON ALLPROGRAMMASTER_DESC.PROGRAM_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ALLPROGRAMMASTER.PROGRAM_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON ALLPROGRAMMASTER_DESC.PROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON ALLPROGRAMMASTER_DESC.PROGRAM_DESIGNID = DESIGNMASTER.DESIGN_id  ", WHERECLAUSE & " AND ALLPROGRAMMASTER.PROGRAM_YEARID = " & YearId & " ORDER BY ALLPROGRAMMASTER.PROGRAM_NO, ALLPROGRAMMASTER_DESC.PROGRAM_GRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            For I As Integer = 0 To Val(gridbill.RowCount - 1)
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If IsDBNull(DTROW("PROGISSDATE")) = False AndAlso DTROW("PROGISSDATE") <> "" Then
                    If DTROW("TYPE") = "PROGRAM" Then
                        DT = OBJCMN.Execute_Any_String("UPDATE PROGRAMMASTER_DESC SET PROGRAM_PROGISSDATE = '" & DTROW("PROGISSDATE") & "' WHERE PROGRAM_NO = " & Val(DTROW("SRNO")) & " AND PROGRAM_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " And PROGRAM_YEARID = " & YearId, "", "")
                    Else
                        DT = OBJCMN.Execute_Any_String("UPDATE OPENINGPROGRAMMASTER_DESC SET OPPROGRAM_PROGISSDATE = '" & DTROW("PROGISSDATE") & "' WHERE OPPROGRAM_NO = " & Val(DTROW("SRNO")) & " AND OPPROGRAM_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " And OPPROGRAM_YEARID = " & YearId, "", "")
                    End If
                End If
            Next

            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "PROGISSDATE")) = False Then

                If gridbill.GetRowCellValue(e.RowHandle, "PROGISSDATE") <> "" Then
                    'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                    Dim TEMP As DateTime
                    If Not DateTime.TryParse(gridbill.GetRowCellValue(e.RowHandle, "PROGISSDATE"), TEMP) Then
                        e.Valid = False
                        gridbill.SetColumnError(GPROGISSDATE, "Invalid Date")
                        Exit Sub
                    Else
                        If gridbill.GetRowCellValue(e.RowHandle, "PROGISSDATE") < Convert.ToDateTime(gridbill.GetRowCellValue(e.RowHandle, "DATE")).Date Then
                            e.Valid = False
                            gridbill.SetColumnError(GPROGISSDATE, "Date must be After Card Date")
                            Exit Sub
                        End If
                    End If
                End If

            End If
            'If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "PROGISSDATE")) = False And gridbill.GetRowCellValue(e.RowHandle, "PROGISSDATE") <> "" Then If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If RBENTERED.Checked = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    Dim DYEINGID As Integer = 0
                    If DTROW("TYPE") = "PROGRAM" Then
                        DT = OBJCMN.Execute_Any_String("UPDATE PROGRAMMASTER_DESC SET PROGRAM_PROGISSDATE = '' WHERE PROGRAM_NO = " & Val(DTROW("SRNO")) & " AND PROGRAM_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND PROGRAM_YEARID = " & YearId, "", "")
                    Else
                        DT = OBJCMN.Execute_Any_String("UPDATE OPENINGPROGRAMMASTER_DESC SET OPPROGRAM_PROGISSDATE = '' WHERE OPPROGRAM_NO = " & Val(DTROW("SRNO")) & " AND OPPROGRAM_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND OPPROGRAM_YEARID = " & YearId, "", "")
                    End If
                Next

                fillgrid()
                gridbill.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.F12 AndAlso gridbill.FocusedRowHandle - 1 >= 0 Then
                'COPY DATA FROM UPPER LINE

                Dim DTROWUP As DataRow = gridbill.GetDataRow(gridbill.FocusedRowHandle - 1)
                Dim DTROW As DataRow = gridbill.GetFocusedDataRow
                DTROW("PROGISSDATE") = DTROWUP("PROGISSDATE")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class