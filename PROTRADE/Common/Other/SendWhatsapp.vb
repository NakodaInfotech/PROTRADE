
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports BL

Public Class SendWhatsapp

    Public PARTYNAME As String = ""
    Public AGENTNAME As String = ""
    Public OTHERNAME1 As String = ""
    Public OTHERNAME2 As String = ""
    Public OTHERNAME3 As String = ""
    Public PATH As New ArrayList
    Public FILENAME As New ArrayList
    Dim RESPONSE As String = ""

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub SendWhatsapp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'IF AUTOCC IS TRUE THEN GET THE MOBILE NO FROM CMPMASTER AND SHOW IN AUTOCC
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If WHATSAPPAUTOCC = True Then
                DT = OBJCMN.search("ISNULL(CMP_TEL,'') AS MOBILENO", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
                If DT.Rows.Count > 0 Then TXTAUTOCC.Text = DT.Rows(0).Item("MOBILENO")
            End If

            fillname(CMBNAME, False, " AND LEDGERS.ACC_TYPE='ACCOUNTS'")
            fillname(CMBAGENTNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
            fillname(CMBOTHERNAME1, False, " AND LEDGERS.ACC_TYPE='ACCOUNTS'")
            fillname(CMBOTHERNAME2, False, " AND LEDGERS.ACC_TYPE='ACCOUNTS'")
            fillname(CMBOTHERNAME3, False, " AND LEDGERS.ACC_TYPE='ACCOUNTS'")

            CMBNAME.Text = PARTYNAME
            CMBAGENTNAME.Text = AGENTNAME
            CMBOTHERNAME1.Text = OTHERNAME1
            CMBOTHERNAME2.Text = OTHERNAME2
            CMBOTHERNAME3.Text = OTHERNAME3

            'GETSALESMAN NO FOR KOTHARI
            If ClientName = "KOTHARI" Then
                DT = OBJCMN.Execute_Any_String("SELECT ISNULL(SALESMAN_MOBILENO,'') AS MOBILENO FROM LEDGERS INNER JOIN SALESMANMASTER ON LEDGERS.ACC_SALESMANID = SALESMAN_ID WHERE LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "' AND LEDGERS.ACC_YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then TXTOTHERNO2.Text = DT.Rows(0).Item("MOBILENO")
            End If


            Dim EN As New CancelEventArgs
            If PARTYNAME <> "" Then CMBNAME_Validating(CMBNAME, EN)
            If AGENTNAME <> "" Then CMBAGENTNAME_Validating(CMBAGENTNAME, EN)
            If OTHERNAME1 <> "" Then CMBOTHERNAME1_Validating(CMBOTHERNAME1, EN)
            If OTHERNAME2 <> "" Then CMBOTHERNAME2_Validating(CMBOTHERNAME2, EN)
            If OTHERNAME3 <> "" Then CMBOTHERNAME3_Validating(CMBOTHERNAME3, EN)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND LEDGERS.ACC_TYPE='ACCOUNTS'", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTPARTYNO.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBAGENTNAME.Validating
        Try
            If CMBAGENTNAME.Text.Trim <> "" Then namevalidate(CMBAGENTNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'", "SUNDRY CREDITORS", "ACCOUNTS", "", "", TXTAGENTNO.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERNAME1_Validating(sender As Object, e As CancelEventArgs) Handles CMBOTHERNAME1.Validating
        Try
            If CMBOTHERNAME1.Text.Trim <> "" Then namevalidate(CMBOTHERNAME1, CMBCODE, e, Me, TXTADD, " AND LEDGERS.ACC_TYPE='ACCOUNTS'", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTOTHERNO1.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERNAME2_Validating(sender As Object, e As CancelEventArgs) Handles CMBOTHERNAME2.Validating
        Try
            If CMBOTHERNAME2.Text.Trim <> "" Then namevalidate(CMBOTHERNAME2, CMBCODE, e, Me, TXTADD, " AND LEDGERS.ACC_TYPE='ACCOUNTS'", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTOTHERNO2.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERNAME3_Validating(sender As Object, e As CancelEventArgs) Handles CMBOTHERNAME3.Validating
        Try
            If CMBOTHERNAME3.Text.Trim <> "" Then namevalidate(CMBOTHERNAME3, CMBCODE, e, Me, TXTADD, " AND LEDGERS.ACC_TYPE='ACCOUNTS'", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTOTHERNO3.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Async Sub CMDSEND_Click(sender As Object, e As EventArgs) Handles CMDSEND.Click
        Try
            If PATH.Count = 0 Then Exit Sub

            'FIRST CHECK STATUS OF MOBILE CONNECTION
            Dim CONNECTSTATUS As String = JObject.Parse(Await CHECKMOBILECONNECTSTATUS())("success")
            If CONNECTSTATUS = "False" Then
                MsgBox("Mobile Not connected, Please Check Connection", MsgBoxStyle.Critical)
                Exit Sub
            End If

            For I As Integer = 0 To PATH.Count - 1
                If TXTPARTYNO.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTPARTYNO.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTPARTYNO.Text)
                End If
                If TXTAGENTNO.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTAGENTNO.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTAGENTNO.Text)
                End If
                If TXTOTHERNO1.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOTHERNO1.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOTHERNO1.Text)
                End If
                If TXTOTHERNO2.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOTHERNO2.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOTHERNO2.Text)
                End If
                If TXTOTHERNO3.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOTHERNO3.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOTHERNO3.Text)
                End If
                If TXTAUTOCC.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTAUTOCC.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTAUTOCC.Text)
                End If
            Next


            'TEXT MESSAGE SHOULD BE SEND ONLY ONCE
            If TXTMESSAGE.Text.Trim <> "" Then
                If TXTPARTYNO.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTPARTYNO.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTAGENTNO.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTAGENTNO.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOTHERNO1.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOTHERNO1.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOTHERNO2.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOTHERNO2.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOTHERNO3.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOTHERNO3.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTAUTOCC.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTAUTOCC.Text.Trim, TXTMESSAGE.Text.Trim)
            End If


            MsgBox("Message Sent", MsgBoxStyle.Information)
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ERRORMESSAGE(NO As String)
        Try
            If RESPONSE <> "" Then
                Dim STATUS As String = JObject.Parse(RESPONSE)("success")
                Dim ERRORMSG As String = JObject.Parse(RESPONSE)("message")
                If STATUS = "False" Then MsgBox("Error While Sending Msg to " & NO & ", Error - " & ERRORMSG & ", Response - " & RESPONSE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class