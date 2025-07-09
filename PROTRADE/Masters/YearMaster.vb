
Imports BL
Imports System.Windows.Forms

Public Class YearMaster

    Public alParaval As New ArrayList
    Public EDIT As Boolean
    Public TEMPCMPNAME As String
    Public FRMSTRING As String

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Try
            Dim objpassmaster As New Cmppassword
            Me.Hide()
            objpassmaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfinish.Click
        Try

            Dim IntResult As Integer
            Dim objyearmaster As New ClsYearMaster
            objyearmaster.alParaval = alParaval

            If EDIT = False Then

                If FRMSTRING = "" Then

                    alParaval.Add(Userid)
                    alParaval.Add("0")
                    alParaval.Add(startdate.Value)
                    alParaval.Add(enddate.Value)
                    alParaval.Add(Locationid)

                    alParaval.Add(CmpName)

                    'CHECK WHETHER ACCOUNTING YEAR WITH THIS DATE IS ALREADY PRESENT OR NOT IN SAME COMPANY
                    Dim OBJCMN As New ClsCommon
                    Dim DTYEAR As DataTable = OBJCMN.search("YEAR_ID AS YEARID", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(startdate.Value.Date, "MM/dd/yyyy") & "' AND YEAR_CMPID = " & CmpId)
                    If DTYEAR.Rows.Count > 0 Then
                        MsgBox("Accounting Year Already Created", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    IntResult = objyearmaster.save()

                    'Progress bar
                    Dim objprogressbar As New ProgressBar
                    objprogressbar.alParaval = alParaval
                    Me.Hide()
                    objprogressbar.Show()

                ElseIf FRMSTRING = "ADDYEAR" Then

                    Dim alp As New ArrayList
                    alp.Add(CmpName)
                    alp.Add(startdate.Value)
                    alp.Add(enddate.Value)
                    alp.Add(Userid)
                    alp.Add(0)
                    alp.Add(CmpName)
                    objyearmaster.alParaval = alp


                    'CHECK WHETHER ACCOUNTING YEAR WITH THIS DATE IS ALREADY PRESENT OR NOT IN SAME COMPANY
                    Dim OBJCMN As New ClsCommon
                    Dim DTYEAR As DataTable = OBJCMN.search("YEAR_ID AS YEARID", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(startdate.Value.Date, "MM/dd/yyyy") & "' AND YEAR_CMPID = " & CmpId)
                    If DTYEAR.Rows.Count > 0 Then
                        MsgBox("Accounting Year Already Created", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    IntResult = objyearmaster.saveyear()

                    'Progress bar
                    Dim objprogressbar As New ProgressBar
                    objprogressbar.alParaval = alp
                    Me.Hide()
                    objprogressbar.Show()

                End If

            Else

                alParaval.Add(Userid)
                alParaval.Add("0")
                alParaval.Add(startdate.Value)
                alParaval.Add(enddate.Value)
                alParaval.Add(Locationid)

                alParaval.Add(TEMPCMPNAME)
                IntResult = objyearmaster.UPDATE()
                Me.Close()

            End If



                'creating database
                'Dim objprogress As New ClsProgressBar
                'Dim dbname As String = alParaval(0)
                'dbname = dbname.Replace(" ", "")
                'dbname = dbname & Day(startdate.Value) & Month(startdate.Value) & Year(startdate.Value) & Day(enddate.Value) & Month(enddate.Value) & Year(enddate.Value)
                'IntResult = objprogress.CreateDatabase(dbname)

                'Dim objmain As New MDIMain
                'Me.Close()
                'objmain.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            startdate.Value = "01/04/" & Year(Mydate)
            enddate.Value = "31/03/" & Year(Mydate) + 1
            If EDIT = True Then
                startdate.Enabled = False
                enddate.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class