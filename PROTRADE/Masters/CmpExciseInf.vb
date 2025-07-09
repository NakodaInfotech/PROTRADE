
Imports System.ComponentModel
Imports BL

Public Class CmpExciseInf

    Public alParaval As New ArrayList
    Public EDIT As Boolean
    Public TEMPCMPNAME As String
    Public TEMPSTATENAME As String = ""

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        Try
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If
            alParaval.Add(TXTBUSINESSLINE.Text)
            alParaval.Add(txtcstno.Text)
            alParaval.Add(txtstno.Text)
            alParaval.Add(txtpanno.Text)
            alParaval.Add(txteccno.Text)
            alParaval.Add(txtexno.Text)
            alParaval.Add(txtplano.Text)
            alParaval.Add(txtdivision.Text)
            alParaval.Add(TXTBANKNAME.Text)
            alParaval.Add(TXTBANKACNO.Text)
            alParaval.Add(TXTIFSCCODE.Text)
            alParaval.Add(txtcommissionerate.Text)
            alParaval.Add(txtheadingno.Text)
            alParaval.Add(TXTGSTIN.Text)
            alParaval.Add(CMBFROMCITY.Text)
            alParaval.Add(TXTEWBUSER.Text)
            alParaval.Add(TXTEWBPASS.Text)
            alParaval.Add(TXTDISPATCHFROM.Text)
            alParaval.Add(TXTUPI.Text)

            Me.Hide()
            Cmppassword.alParaval = alParaval
            Cmppassword.EDIT = EDIT
            Cmppassword.TEMPCMPNAME = TEMPCMPNAME
            Cmppassword.ShowDialog()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTGSTIN.Text.Trim.Length > 0 Then
            If txtpanno.Text.Trim = "" Then
                EP.SetError(txtpanno, "Enter Pan No")
                bln = False
            End If

            If txtpanno.Text.Trim.Length <> 10 Then
                EP.SetError(txtpanno, "Insert Proper PAN No")
                bln = False
            End If

            'CHECKING 2ND TO 11TH ALPHABETS WITH PANNO
            If TXTGSTIN.Text.Trim.Length = 15 Then
                If txtpanno.Text.Trim <> TXTGSTIN.Text.Substring(2, 10) Then
                    EP.SetError(txtpanno, "Enter Proper PAN Details")
                    bln = False
                End If
            End If

            If TXTGSTIN.Text.Trim.Length <> 15 Then
                EP.SetError(TXTGSTIN, "Enter Proper GST No")
                bln = False
            End If
        End If

        'CHECKING 1ST TWO ALPHABETS WITH STATE
        If TEMPSTATENAME <> "" And TXTGSTIN.Text.Trim <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" cast(state_remark as varchar(5)) AS STATECODE ", "", " STATEMASTER", " AND state_name = '" & TEMPSTATENAME & "'  and STATE_YEARID = " & YearId)
            If DT.Rows(0).Item("STATECODE") <> TXTGSTIN.Text.Substring(0, 2) Then
                EP.SetError(TXTGSTIN, "State Code does not match with GST No")
                bln = False
            End If
        End If

        If txtpanno.Text.Trim <> "" Then
            For x = 1 To Len(txtpanno.Text.Trim)
                If x <= 5 Or x = 10 Then
                    If Asc(txtpanno.Text.Substring(x - 1, 1)) < 65 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 90 Then
                        EP.SetError(txtpanno, "Insert Proper PAN No")
                        bln = False
                    End If
                Else
                    If Asc(txtpanno.Text.Substring(x - 1, 1)) < 48 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 57 Then
                        EP.SetError(txtpanno, "Insert Proper PAN No")
                        bln = False
                    End If
                End If
            Next
        End If

        Return bln
    End Function

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Try
            Dim obj As New Cmpmaster
            Me.Hide()
            obj.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrange_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBANKNAME.Validated
        pcase(TXTBANKNAME)
    End Sub

    Private Sub txtdivision_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdivision.Validated
        pcase(txtdivision)
    End Sub

    Private Sub txtcentralexoff_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBANKACNO.Validated
        pcase(TXTBANKACNO)
    End Sub

    Private Sub txtdivisionoff_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTIFSCCODE.Validated
        pcase(TXTIFSCCODE)
    End Sub

    Private Sub CmpExciseInf_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)

            If EDIT = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                DT = OBJCMN.search("CMP_BUSINESSLINE, CMP_CSTNO, CMP_STNO, CMP_PANNO, CMP_ECCNO, CMP_EXCISENO, CMP_PLANO, CMP_DIVISION, CMP_BANKNAME, CMP_BANKACNO, CMP_IFSCCODE,CMP_COMMISSIONERATE, CMP_HEADINGNO, CMP_GSTIN AS GSTIN, CMP_EWBUSER AS EWBUSER, CMP_EWBPASS AS EWBPASS, CMP_DISPATCHFROM AS DISPATCHFROM, ISNULL(CITY_NAME,'') AS FROMCITY, ISNULL(CMP_UPI,'') AS UPI ", "", " CMPMASTER LEFT OUTER JOIN CITYMASTER ON CMP_FROMCITYID = CITY_ID", " AND CMP_NAME = '" & TEMPCMPNAME & "'")
                Dim DTROW As DataRow = DT.Rows(0)

                TXTBUSINESSLINE.Text = DTROW(0).ToString
                txtcstno.Text = DTROW(1).ToString
                txtstno.Text = DTROW(2).ToString
                txtpanno.Text = DTROW(3).ToString
                txteccno.Text = DTROW(4).ToString
                txtexno.Text = DTROW(5).ToString
                txtplano.Text = DTROW(6).ToString
                txtdivision.Text = DTROW(7).ToString
                TXTBANKNAME.Text = DTROW(8).ToString
                TXTBANKACNO.Text = DTROW(9).ToString
                TXTIFSCCODE.Text = DTROW(10).ToString
                txtcommissionerate.Text = DTROW(11).ToString
                txtheadingno.Text = DTROW(12).ToString
                TXTGSTIN.Text = DTROW("GSTIN").ToString
                CMBFROMCITY.Text = DTROW("FROMCITY").ToString
                TXTEWBUSER.Text = DTROW("EWBUSER").ToString
                TXTEWBPASS.Text = DTROW("EWBPASS").ToString
                TXTDISPATCHFROM.Text = DTROW("DISPATCHFROM").ToString
                TXTUPI.Text = DTROW("UPI").ToString
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Enter(sender As Object, e As EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class