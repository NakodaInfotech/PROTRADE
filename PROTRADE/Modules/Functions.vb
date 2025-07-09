
Imports System.Net.Mail
Imports BL
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports System.Web
Imports WAProAPI

Module Functions

#Region "WHATSAPP"

    Function CHECKWHASTAPPEXP() As Boolean
        Dim BLN As Boolean = True
        If Now.Date > WHATSAPPEXPDATE Then
            BLN = False
        End If
        Return BLN
    End Function

    Function GETWHATSAPPBASEURL() As String
        Dim WHATSAPPBASEURL As String = ""

        'READ BASEURL FROM C DRIVE
        If File.Exists("C:\WHATSAPPBASEURL.txt") Then
            Dim oRead As System.IO.StreamReader = File.OpenText("C:\WHATSAPPBASEURL.txt")
            WHATSAPPBASEURL = oRead.ReadToEnd
        End If
        Return WHATSAPPBASEURL
    End Function

    Async Function SENDWHATSAPPATTACHMENT(WHATSAPPNO As String, PATH As String, FILENAME As String) As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim waMediaMsgBody As SendMediaMsgJson = New SendMediaMsgJson()
        Dim Attachment As String = Convert.ToBase64String(File.ReadAllBytes(PATH))
        Dim AttachmentFileName As String = FILENAME
        waMediaMsgBody.base64data = Attachment
        waMediaMsgBody.mimeType = MimeMapping.GetMimeMapping(AttachmentFileName)
        waMediaMsgBody.caption = "APIMethod SendMediaMessage from CISPLWhatsAppAPI.dll"
        waMediaMsgBody.filename = AttachmentFileName
        Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendMediaMessageAsync(WHATSAPPNO, waMediaMsgBody)
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)

        Return RESPONSE
    End Function

    Async Function SENDWHATSAPPMESSAGE(WHATSAPPNO As String, TEXTMESSAGE As String) As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim Body As SendTextMsgJson = New SendTextMsgJson()
        Body.text = TEXTMESSAGE
        Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendTextMessageAsync(WHATSAPPNO, Body)
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Return RESPONSE
    End Function

    Async Function CHECKMOBILECONNECTSTATUS() As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim txnResp As TxnRespWithConnectionState = Await APIMethods.GetConnectionStateAsync()
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Return RESPONSE
    End Function

#End Region

    Sub BARCODEPRINTING(BARCODE As String, PIECETYPE As String, ITEMNAME As String, QUALITY As String, DESIGNNO As String, SHADE As String, UNIT As String, LOTNO As String, BALENO As String, GRIDDESC As String, MTRS As Double, QTY As Double, CUT As Double, Optional RACK As String = "", Optional TEMPHEADER As String = "", Optional SUPRIYAHEADER As String = "", Optional WHOLESALEBARCODE As Integer = 0, Optional WEAVERCHNO As String = "", Optional WEAVERNAME As String = "")
        Try

            Dim dirresults As String = ""
            Dim oWrite As System.IO.StreamWriter
            oWrite = File.CreateText(Application.StartupPath & "\Barcode.txt")

            'IF CLIENT WANT TO PRINT ALL THE BARCODE THEN USE THE CODE BELOW
            If ClientName = "TARUN" Then GoTo PRINTALL

            If (PIECETYPE <> "FRESH" And ClientName <> "KENCOT" And ClientName <> "KARAN" And ClientName <> "SPCORP") Or ((ClientName = "KARAN" Or ClientName = "SPCORP") And PIECETYPE <> "FRESH" And PIECETYPE <> "TP") Then
                oWrite.Dispose()
                Exit Sub
            End If

PRINTALL:
            If ClientName = "REAL" Then

                oWrite.WriteLine("SIZE 80.1 mm, 40 mm")
                oWrite.WriteLine("DIRECTION 0,0")
                oWrite.WriteLine("REFERENCE 0,0")
                oWrite.WriteLine("OFFSET 0 mm")
                oWrite.WriteLine("SET PEEL OFF")
                oWrite.WriteLine("SET CUTTER OFF")
                oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                oWrite.WriteLine("SET TEAR ON")
                oWrite.WriteLine("CLS")
                oWrite.WriteLine("CODEPAGE 1252")
                oWrite.WriteLine("TEXT 616,300,""ROMAN.TTF"",180,1,12,""DESIGN""")
                oWrite.WriteLine("TEXT 494,300,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 468,300,""ROMAN.TTF"",180,1,12,""" & DESIGNNO & """")
                oWrite.WriteLine("TEXT 616,251,""ROMAN.TTF"",180,1,12,""SHADE""")
                oWrite.WriteLine("TEXT 494,251,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 468,251,""ROMAN.TTF"",180,1,12,""" & SHADE & """")
                oWrite.WriteLine("TEXT 270,202,""ROMAN.TTF"",180,1,12,""LOTNO""")
                oWrite.WriteLine("TEXT 148,202,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 123,202,""ROMAN.TTF"",180,1,12,""" & LOTNO & """")

                'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
                Dim TEMPWIDTH As String
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(UNITMASTER.UNIT_ABBR,'') AS UNIT ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN UNITMASTER ON ITEM_UNITID = UNITMASTER.UNIT_ID", " AND ITEM_NAME = '" & ITEMNAME & "' AND ITEM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TEMPWIDTH = DT.Rows(0).Item("WIDTH")
                End If

                oWrite.WriteLine("TEXT 256,251,""ROMAN.TTF"",180,1,12,""WIDTH""")
                oWrite.WriteLine("TEXT 148,251,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 123,251,""ROMAN.TTF"",180,1,12,""" & TEMPWIDTH & """")
                oWrite.WriteLine("TEXT 616,202,""ROMAN.TTF"",180,1,12,""MTRS""")
                oWrite.WriteLine("TEXT 494,202,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 468,207,""ROMAN.TTF"",180,1,16,""" & Format(Val(MTRS), "0.00") & """")
                oWrite.WriteLine("TEXT 616,152,""ROMAN.TTF"",180,1,12,""PRE NO""")
                oWrite.WriteLine("TEXT 494,152,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 468,152,""ROMAN.TTF"",180,1,12,""" & BALENO & """")
                oWrite.WriteLine("TEXT 228,152,""ROMAN.TTF"",180,1,12,""UNIT""")
                oWrite.WriteLine("TEXT 148,152,""ROMAN.TTF"",180,1,12,"":""")
                oWrite.WriteLine("TEXT 123,152,""ROMAN.TTF"",180,1,12,""" & UNIT & """")
                oWrite.WriteLine("BARCODE 616,107,""128M"",58,0,180,3,6,""" & BARCODE & """") 'BARCODE
                oWrite.WriteLine("TEXT 449,43,""ROMAN.TTF"",180,1,12,""" & BARCODE & """")
                oWrite.WriteLine("PRINT 1,1")
                oWrite.Dispose()


            ElseIf ClientName = "MANALI" Then

                oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
                oWrite.WriteLine("DIRECTION 0,0")
                oWrite.WriteLine("REFERENCE 0,0")
                oWrite.WriteLine("OFFSET 0 mm")
                oWrite.WriteLine("SET PEEL OFF")
                oWrite.WriteLine("SET CUTTER OFF")
                oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                oWrite.WriteLine("SET TEAR ON")
                oWrite.WriteLine("CLS")
                oWrite.WriteLine("CODEPAGE 1252")

                If TEMPHEADER = 1 Then oWrite.WriteLine("TEXT 636,383,""ROMAN.TTF"",180,1,18,""MANALI MILLS (INDIA)""")
                oWrite.WriteLine("QRCODE 206,252,L,8,A,180,M2,S7,""" & BARCODE & """") 'BARCODE
                oWrite.WriteLine("TEXT 205,66,""ROMAN.TTF"",180,1,10,""" & BARCODE & """") 'BARCODE

                oWrite.WriteLine("TEXT 751,307,""ROMAN.TTF"",180,1,16,""ITEM""")
                oWrite.WriteLine("TEXT 595,307,""ROMAN.TTF"",180,1,16, "":""")
                oWrite.WriteLine("TEXT 566,307,""ROMAN.TTF"",180,1,16,""" & ITEMNAME & """")
                oWrite.WriteLine("TEXT 751,246,""ROMAN.TTF"",180,1,16,""D.NO""")
                oWrite.WriteLine("TEXT 595,246,""ROMAN.TTF"",180,1,16, "":""")
                oWrite.WriteLine("TEXT 566,246,""ROMAN.TTF"",180,1,16,""" & DESIGNNO & """")
                oWrite.WriteLine("TEXT 751,185,""ROMAN.TTF"",180,1,16,""SHADE""")
                oWrite.WriteLine("TEXT 595,185,""ROMAN.TTF"",180,1,16,"":""")
                oWrite.WriteLine("TEXT 566,185,""ROMAN.TTF"",180,1,18,""" & SHADE & """")
                oWrite.WriteLine("TEXT 751,124,""ROMAN.TTF"",180,1,16,""LOTNO""")
                oWrite.WriteLine("TEXT 595,124,""ROMAN.TTF"",180,1,16,"":""")
                oWrite.WriteLine("TEXT 566,124,""ROMAN.TTF"",180,1,16,""" & LOTNO & """")
                oWrite.WriteLine("TEXT 751,63,""ROMAN.TTF"",180,1,16,""MTRS""")
                oWrite.WriteLine("TEXT 595,63,""ROMAN.TTF"",180,1,16,"":""")
                oWrite.WriteLine("TEXT 566,63,""ROMAN.TTF"",180,1,16,""" & Format(Val(MTRS), "0.00") & """")

                oWrite.WriteLine("BAR 31,320, 726, 3")
                oWrite.WriteLine("PRINT 1,1")
                oWrite.Dispose()


            End If

            'Printing Barcode
            Dim psi As New ProcessStartInfo()
            psi.FileName = "cmd.exe"
            psi.RedirectStandardInput = False
            psi.RedirectStandardOutput = True
            'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
            psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
            'psi.Arguments = "print /d:\\admin-pc\ARGOX D:\Barcode.txt"    ' specify your command
            psi.UseShellExecute = False

            Dim proc As Process
            proc = Process.Start(psi)
            dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
            '// do something with result stream
            proc.WaitForExit()
            proc.Dispose()

            'THIS LINE IS WRITTEN TO DISPOSE THE BARCODE NOTEPAD OBJECT, WHEN CURSOR COMES DIRECTLY ON NEXTLINE CODE
            oWrite.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub VIEWFORM(ByVal TYPE As String, ByVal EDIT As Boolean, ByVal BILLNO As Integer, ByVal REGTYPE As String)
        Try
            If TYPE = "PURCHASE" Then

                Dim OBJPURCHASE As New PurchaseMaster
                OBJPURCHASE.MdiParent = MDIMain
                OBJPURCHASE.EDIT = EDIT
                OBJPURCHASE.TEMPBILLNO = BILLNO
                OBJPURCHASE.TEMPREGNAME = REGTYPE
                OBJPURCHASE.Show()

            ElseIf TYPE = "CHALLAN" Then

                Dim OBJGDN As New GDN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.EDIT = EDIT
                OBJGDN.TEMPGDNNO = BILLNO
                OBJGDN.Show()

            ElseIf TYPE = "SALE" Then

                Dim OBJSALE As New InvoiceMaster
                OBJSALE.MdiParent = MDIMain
                OBJSALE.EDIT = EDIT
                OBJSALE.TEMPINVOICENO = BILLNO
                OBJSALE.TEMPREGNAME = REGTYPE
                OBJSALE.Show()

            ElseIf TYPE = "MATREC" Then

                Dim OBJMATREC As New MaterialReceipt
                OBJMATREC.MdiParent = MDIMain
                OBJMATREC.EDIT = EDIT
                OBJMATREC.TEMPMATRECNO = BILLNO
                OBJMATREC.Show()

            ElseIf TYPE = "INHOUSECHECKING" Or TYPE = "INHOUSECHECKINGISS" Then

                Dim OBJCHECK As New InHouseChecking
                OBJCHECK.MdiParent = MDIMain
                OBJCHECK.EDIT = EDIT
                OBJCHECK.TEMPCHECKINGNO = BILLNO
                OBJCHECK.Show()

            ElseIf TYPE = "ISSUEPACKING" Then

                Dim OBJISS As New IssueToPacking
                OBJISS.MdiParent = MDIMain
                OBJISS.EDIT = EDIT
                OBJISS.TEMPISSUENO = BILLNO
                OBJISS.Show()

            ElseIf TYPE = "RECPACKING" Then

                Dim OBJREC As New RecFromPacking
                OBJREC.MdiParent = MDIMain
                OBJREC.EDIT = EDIT
                OBJREC.TEMPRECNO = BILLNO
                OBJREC.Show()

            ElseIf TYPE = "JOBOUT" Then

                Dim OBJJO As New JobOut
                OBJJO.MdiParent = MDIMain
                OBJJO.EDIT = EDIT
                OBJJO.TEMPJONO = BILLNO
                OBJJO.Show()

            ElseIf TYPE = "JOBIN" Then

                Dim OBJJI As New JobIn
                OBJJI.MdiParent = MDIMain
                OBJJI.EDIT = EDIT
                OBJJI.TEMPJOBINNO = BILLNO
                OBJJI.Show()

            ElseIf TYPE = "PAYMENT" Then

                Dim OBJPAYMENT As New PaymentMaster
                OBJPAYMENT.MdiParent = MDIMain
                OBJPAYMENT.EDIT = EDIT
                OBJPAYMENT.TEMPPAYMENTNO = BILLNO
                OBJPAYMENT.TEMPREGNAME = REGTYPE
                OBJPAYMENT.Show()

            ElseIf TYPE = "RECEIPT" Then

                Dim OBJREC As New Receipt
                OBJREC.MdiParent = MDIMain
                OBJREC.EDIT = EDIT
                OBJREC.TEMPRECEIPTNO = BILLNO
                OBJREC.TEMPREGNAME = REGTYPE
                OBJREC.Show()

            ElseIf TYPE = "JOURNAL" Then

                Dim OBJJV As New journal
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = EDIT
                OBJJV.TEMPJVNO = BILLNO
                OBJJV.TEMPREGNAME = REGTYPE
                OBJJV.Show()

            ElseIf TYPE = "DEBITNOTE" Then

                Dim OBJDN As New DebitNote
                OBJDN.MdiParent = MDIMain
                OBJDN.edit = EDIT
                OBJDN.TEMPDNNO = BILLNO
                OBJDN.TEMPREGNAME = REGTYPE
                OBJDN.Show()

            ElseIf TYPE = "CREDITNOTE" Then

                Dim OBJCN As New CREDITNOTE
                OBJCN.MdiParent = MDIMain
                OBJCN.edit = EDIT
                OBJCN.TEMPCNNO = BILLNO
                OBJCN.TEMPREGNAME = REGTYPE
                OBJCN.Show()

            ElseIf TYPE = "CONTRA" Then

                Dim OBJCON As New ContraEntry
                OBJCON.MdiParent = MDIMain
                OBJCON.EDIT = EDIT
                OBJCON.tempcontrano = BILLNO
                OBJCON.TEMPREGNAME = REGTYPE
                OBJCON.Show()

            ElseIf TYPE = "EXPENSE" Then

                Dim OBJEXP As New ExpenseVoucher
                OBJEXP.MdiParent = MDIMain
                OBJEXP.EDIT = EDIT
                OBJEXP.TEMPEXPNO = BILLNO
                OBJEXP.TEMPREGNAME = REGTYPE
                OBJEXP.FRMSTRING = "NONPURCHASE"
                OBJEXP.Show()

            ElseIf TYPE = "SALE RETURN" Then

                Dim OBJSALERET As New SaleReturn
                OBJSALERET.MdiParent = MDIMain
                OBJSALERET.EDIT = EDIT
                OBJSALERET.TEMPSALRETNO = BILLNO
                OBJSALERET.Show()

            ElseIf TYPE = "PUR RETURN" Then

                Dim OBJPURRET As New PurchaseReturn
                OBJPURRET.MdiParent = MDIMain
                OBJPURRET.EDIT = EDIT
                OBJPURRET.TEMPPRNO = BILLNO
                OBJPURRET.Show()

            ElseIf TYPE = "STKADJ" Then

                Dim OBJSTOCKADJ As New StockReco
                OBJSTOCKADJ.MdiParent = MDIMain
                OBJSTOCKADJ.EDIT = EDIT
                OBJSTOCKADJ.TEMPRECONO = BILLNO
                OBJSTOCKADJ.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ErrHandle(ByVal Errcode As Integer) As Boolean
        Dim bln As Boolean = False
        If Errcode = -675406840 Then
            MsgBox("Check Internet Connection")
            bln = True
        End If
        Return bln
    End Function

    Public Sub pcase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.ProperCase)
    End Sub

    Public Sub uppercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Uppercase)
    End Sub

    Public Sub lowercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Lowercase)
    End Sub

#Region "IN WORDS FUNCTION"

    Function CurrencyToWord(ByVal Num As Decimal) As String

        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        CurrencyToWord = StrWord & " Only"
        Return CurrencyToWord

    End Function

    Function NumToWord(ByVal Num As Decimal) As String

        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord

    End Function

    Function cWordG3(ByVal Num As Decimal) As String

        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3

    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String

        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        strReplicate = ""
        For i As Integer = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate

    End Function

    Function cWord3(ByVal Num As Decimal) As String

        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3

    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"},
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"},
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        For i As Integer = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord

    End Function

#End Region

    Function SENDMSG(ByVal MSG As String, ByVal MOBILENO As String) As String
        Try
            Dim WEBREQUEST As HttpWebRequest = Nothing
            Dim WEBRESPONSE As HttpWebResponse = Nothing
            Dim USERNAME As String = ""
            Dim PASSWORD As String = ""
            Dim SENDER As String = ""
            'Dim objSMS As New routesmsdll.SMS
            'If MOBILENO <> "" Then objSMS.MobileNo = MOBILENO

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If ClientName = "ALENCOT" Then
                USERNAME = "kumarsilk"
                PASSWORD = "infosys123"
                SENDER = "LRDASP"

            ElseIf ClientName = "MOHAN" Then
                USERNAME = "nako-mohanfab"
                PASSWORD = "mohanfab"
                SENDER = "MKNITT"

            ElseIf ClientName = "KCRAYON" Then
                USERNAME = "nako-kcryon"
                PASSWORD = "kcrayon"
                SENDER = "KCRYON"

            ElseIf ClientName = "KOTHARI" Then
                USERNAME = "nako-kothari"
                PASSWORD = "kothari1"
                SENDER = "LLUCAS"

            ElseIf ClientName = "YASHVI" Then
                USERNAME = "nako-yashvi"
                PASSWORD = "yashvi12"
                SENDER = "YSVCRN"

            ElseIf ClientName = "SANGHVI" Then
                USERNAME = "nako-sanghvi"
                PASSWORD = "sanghvi1"
                SENDER = "SSSONS"

            ElseIf ClientName = "DRDRAPES" Then
                USERNAME = "drdrape"
                PASSWORD = "drdrapes"
                SENDER = "DRDMUM"

            ElseIf ClientName = "SAKARIA" Then
                USERNAME = "sakaria"
                PASSWORD = "sakaria123"
                SENDER = "SAKRIA"

            ElseIf ClientName = "NVAHAN" Then
                WEBREQUEST = DirectCast(WEBREQUEST.Create("http://app.smsnix.com/vendorsms/pushsms.aspx?user=Girish Shah&password=tomstracy&msisdn=" & MOBILENO & "&sid=NVAHAN&msg=" & MSG & "&fl=0&gwid=2"), HttpWebRequest)
                Try
                    WEBRESPONSE = DirectCast(WEBREQUEST.GetResponse(), HttpWebResponse)
                Catch ex As WebException
                    WEBRESPONSE = DirectCast(ex.Response, HttpWebResponse)
                End Try
                Return "1701"
                Exit Function
            End If

            'OLD CODE
            'objSMS.Message = MSG
            'objSMS.IpAddress = "103.16.101.52"
            'objSMS.dlr = 1
            'objSMS.MessageType = routesmsdll.MESSAGE_TYPE.mTEXT
            'Dim response As String = objSMS.sendMessage()
            'Return (response.ToString.Substring(0, 4))

            Dim NEWMSG As String = System.Web.HttpUtility.UrlEncode(MSG)
            WEBREQUEST = DirectCast(WEBREQUEST.Create("http://nakoda.alert.ind.in/sms_api/sendsms.php?username=" & USERNAME & "&password=" & PASSWORD & "&mobile=" & MOBILENO & "&sendername=" & SENDER & "&message=" & NEWMSG), HttpWebRequest)
            Try
                WEBRESPONSE = DirectCast(WEBREQUEST.GetResponse(), HttpWebResponse)
            Catch ex As WebException
                WEBRESPONSE = DirectCast(ex.Response, HttpWebResponse)
            End Try
            Return "1701"

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub FILLCHALLANTYPE(ByRef CMBTYPE As ComboBox)
        Try
            If CMBTYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CHALLANTYPE_NAME ", "", " CHALLANTYPEMASTER ", " And CHALLANTYPE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CHALLANTYPE_NAME"
                    CMBTYPE.DataSource = dt
                    CMBTYPE.DisplayMember = "CHALLANTYPE_NAME"
                End If
                CMBTYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLJOBOUTTYPE(ByRef CMBTYPE As ComboBox)
        Try
            If CMBTYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" JOTYPE_NAME ", "", " JOBOUTTYPEMASTER ", " And JOTYPE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "JOTYPE_NAME"
                    CMBTYPE.DataSource = dt
                    CMBTYPE.DisplayMember = "JOTYPE_NAME"
                End If
                CMBTYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filldesignation(ByRef cmbdesignation As ComboBox)
        Try
            If cmbdesignation.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" designation_NAME ", "", " designationMaster ", " And designation_cmpid=" & CmpId & " And designation_locationid = " & Locationid & " And designation_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "designation_NAME"
                    cmbdesignation.DataSource = dt
                    cmbdesignation.DisplayMember = "designation_NAME"
                    cmbdesignation.Text = ""
                End If
                cmbdesignation.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillPIECETYPE(ByRef CMBPIECETYPE As ComboBox)
        Try
            If CMBPIECETYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PIECETYPE_NAME ", "", " PIECETYPEMaster ", " And PIECETYPE_cmpid=" & CmpId & " And PIECETYPE_locationid = " & Locationid & " And PIECETYPE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PIECETYPE_NAME"
                    CMBPIECETYPE.DataSource = dt
                    CMBPIECETYPE.DisplayMember = "PIECETYPE_NAME"
                    CMBPIECETYPE.Text = ""
                End If
                CMBPIECETYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCURRENCY(ByRef CMBCURRENCY As ComboBox)
        Try
            If CMBCURRENCY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CURR_NAME ", "", " CURRENCYMASTER ", " And CURR_cmpid=" & CmpId & " And CURR_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CURR_NAME"
                    CMBCURRENCY.DataSource = dt
                    CMBCURRENCY.DisplayMember = "CURR_NAME"
                    CMBCURRENCY.Text = ""
                End If
                CMBCURRENCY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub CURRENCYVALIDATE(ByRef CMBCURRENCY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBCURRENCY.Text.Trim <> "" Then
                uppercase(CMBCURRENCY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CURR_NAME ", "", " CURRENCYMASTER", " and CURR_NAME = '" & CMBCURRENCY.Text.Trim & "' and CURR_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Currancy not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBCURRENCY.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCURRENCY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(0)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)


                        Dim objRACK As New ClsCurrencyMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" CURR_NAME AS NAME ", "", " CURRENCYMASTER", " and CURR_NAME = '" & CMBCURRENCY.Text.Trim & "' and CURR_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBCURRENCY.DataSource
                            If CMBCURRENCY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCURRENCY.Text.Trim)
                                    CMBCURRENCY.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBCURRENCY.Focus()
                        CMBCURRENCY.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLCOLOR(ByRef CMBCOLOR As ComboBox, ByVal DESIGNNO As String)
        Try
            If CMBCOLOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERECLAUSE As String = ""
                If FETCHITEMWISEDESIGN = True And DESIGNNO <> "" Then WHERECLAUSE = " And ISNULL(DESIGNMASTER.DESIGN_NO,'')='" & DESIGNNO & "'"
                dt = objclscommon.search(" DISTINCT COLOR_ID, COLOR_NAME ", "", " DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID RIGHT OUTER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id  ", WHERECLAUSE & " and COLOR_yearid = " & YearId)
                CMBCOLOR.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COLOR_NAME"
                    CMBCOLOR.DisplayMember = "COLOR_NAME"
                    CMBCOLOR.ValueMember = "COLOR_ID"
                    CMBCOLOR.Text = ""
                    uppercase(CMBCOLOR)
                End If
                CMBCOLOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLDESIGN(ByRef cmbDESIGN As ComboBox, ByVal ITEMNAME As String)
        Try

            If cmbDESIGN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster

                Dim WHERECLAUSE As String = ""
                If FETCHITEMWISEDESIGN = True And ITEMNAME <> "" Then WHERECLAUSE = " AND ISNULL(ITEMMASTER.ITEM_NAME,'')='" & ITEMNAME & "'"
                Dim dt As DataTable = objclscommon.search(" DESIGN_ID, DESIGN_NO ", "", "  DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGNMASTER.DESIGN_ITEMID=ITEMMASTER.ITEM_ID ", WHERECLAUSE & " AND ISNULL(DESIGN_BLOCKED,0) = 'FALSE' and DESIGN_yearid = " & YearId)
                cmbDESIGN.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DESIGN_NO"
                    cmbDESIGN.DisplayMember = "DESIGN_NO"
                    cmbDESIGN.ValueMember = "DESIGN_ID"
                    cmbDESIGN.Text = ""
                End If
                cmbDESIGN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAREA(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" AREA_name ", "", " AREAMaster", " and AREA_cmpid=" & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "AREA_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "AREA_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AREAVALIDATE(ByRef CMBAREA As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAREA.Text.Trim <> "" Then
                pcase(CMBAREA)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("AREA_name", "", "AREAMaster", " and AREA_name = '" & CMBAREA.Text.Trim & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBAREA.Text.Trim
                    Dim tempmsg As Integer = MsgBox("AREA not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBAREA.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savearea(CMBAREA.Text.Trim, CmpId, Locationid, Userid, YearId, " and AREA_name = '" & CMBAREA.Text.Trim & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillCOUNTRY(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COUNTRY_name ", "", " COUNTRYMaster", " and COUNTRY_cmpid=" & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COUNTRY_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "COUNTRY_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COUNTRYVALIDATE(ByRef CMBCOUNTRY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOUNTRY.Text.Trim <> "" Then
                pcase(CMBCOUNTRY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("COUNTRY_name", "", "COUNTRYMaster", " and COUNTRY_name = '" & CMBCOUNTRY.Text.Trim & "' AND COUNTRY_CMPID = " & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCOUNTRY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("COUNTRY not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBCOUNTRY.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savecountry(CMBCOUNTRY.Text.Trim, CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & CMBCOUNTRY.Text.Trim & "' AND COUNTRY_CMPID = " & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillSTATE(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STATE_name ", "", " STATEMaster", " and STATE_cmpid=" & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STATE_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "STATE_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STATEVALIDATE(ByRef CMBSTATE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTATE.Text.Trim <> "" Then
                pcase(CMBSTATE)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("STATE_name", "", "STATEMaster", " and STATE_name = '" & CMBSTATE.Text.Trim & "' AND STATE_CMPID = " & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("STATE not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBSTATE.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savestate(CMBSTATE.Text.Trim, CmpId, Locationid, Userid, YearId, " and STATE_name = '" & CMBSTATE.Text.Trim & "' AND STATE_CMPID = " & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub designationvalidate(ByRef cmbdesignation As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbdesignation.Text.Trim <> "" Then
                lowercase(cmbdesignation)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" designation_NAME ", "", "designationMaster", " and designation_NAME = '" & cmbdesignation.Text.Trim & "' and designation_cmpid = " & CmpId & " and designation_locationid = " & Locationid & " and designation_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("designation not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbdesignation.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objdesignation As New ClsdesignationMaster
                        objdesignation.alParaval = alParaval
                        Dim IntResult As Integer = objdesignation.save()
                        'e.Cancel = True
                    Else
                        cmbdesignation.Focus()
                        cmbdesignation.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PIECETYPEvalidate(ByRef cmbPIECETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbPIECETYPE.Text.Trim <> "" Then
                uppercase(cmbPIECETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PIECETYPE_NAME ", "", "PIECETYPEMaster", " and PIECETYPE_NAME = '" & cmbPIECETYPE.Text.Trim & "' and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_locationid = " & Locationid & " and PIECETYPE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PIECETYPE not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbPIECETYPE.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objPIECETYPE As New ClsPieceTypeMaster
                        objPIECETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objPIECETYPE.save()
                        'e.Cancel = True
                    Else
                        cmbPIECETYPE.Focus()
                        cmbPIECETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COLORVALIDATE(ByRef cmbCOLOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal DESIGNNO As String)
        Try

            If cmbCOLOR.Text.Trim <> "" Then
                uppercase(cmbCOLOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If ClientName = "REAL" And DESIGNNO <> "" Then
                    dt = objclscommon.search(" COLOR_NAME ", "", " COLORMaster INNER JOIN DESIGNMASTER_COLOR ON COLOR_ID = DESIGN_COLORID INNER JOIN DESIGNMASTER ON DESIGNMASTER_COLOR.DESIGN_ID = DESIGNMASTER.DESIGN_ID", " AND DESIGNMASTER.DESIGN_NO = '" & DESIGNNO & "' and COLOR_NAME = '" & cmbCOLOR.Text.Trim & "'  and COLOR_yearid = " & YearId)
                    If dt.Rows.Count = 0 Then
                        e.Cancel = True
                        MsgBox("Add Shade From Design Master", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Else
                    dt = objclscommon.search(" COLOR_NAME ", "", " COLORMaster", " and COLOR_NAME = '" & cmbCOLOR.Text.Trim & "'  and COLOR_yearid = " & YearId)
                End If
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("COLOR not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbCOLOR.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objCOLOR As New ClsColorMaster
                        objCOLOR.alParaval = alParaval
                        Dim IntResult As Integer = objCOLOR.save()
                        'e.Cancel = True
                    Else
                        cmbCOLOR.Focus()
                        cmbCOLOR.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function setcolor(ByVal no As Integer) As String
        Try
            Dim str As String = String.Empty
            Dim remainder As Integer
            remainder = no Mod 30
            Select Case remainder
                Case 0
                    str = "Turquoise"
                Case 1
                    str = "LightGreen"
                Case 2
                    str = "LightSkyBlue"
                Case 3
                    str = "Lavender"
                Case 4
                    str = "Plum"
                Case 5
                    str = "Pink"
                Case 6
                    str = "LightCyan"
                Case 7
                    str = "Gold"
                Case 8
                    str = "Silver"
                Case 9
                    str = "Khaki"
                Case 10
                    str = "LIGHTCORAL"
                Case 11
                    str = "MISTYROSE"
                Case 12
                    str = "LIGHTSALMON"
                Case 13
                    str = "SEASHELL"
                Case 14
                    str = "PEACHPUFF"
                Case 15
                    str = "CORNSILK"
                Case 16
                    str = "YELLOWGREEN"
                Case 17
                    str = "HotPink"
                Case 18
                    str = "HONEYDEW"
                Case 19
                    str = "LAVENDER"
                Case 20
                    str = "THISTLE"
                Case 21
                    str = "PINK"
                Case 22
                    str = "GREENYELLOW"
                Case 23
                    str = "SkyBlue"
                Case 24
                    str = "LightCyan"
                Case 25
                    str = "Lime"
                Case 26
                    str = "Wheat"
                Case 27
                    str = "Cornsilk"
                Case 28
                    str = "DarkOrange"
                Case 29
                    str = "PaleVioletRed"
                Case 30
                    str = "LIGHTPINK"

            End Select
            Return str
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Sub fillform(ByRef CHKFORM As CheckedListBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CHKFORM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" form_name ", "", " FORMTYPE", WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FORM_name"
                    CHKFORM.DataSource = dt
                    CHKFORM.DisplayMember = "FORM_name"
                    If edit = False Then CHKFORM.Text = ""

                End If
                ''CHKFORM.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLFORMTYPE(ByRef CMBFORM As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBFORM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" form_name ", "", " FORMTYPE", WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FORM_name"
                    CMBFORM.DataSource = dt
                    CMBFORM.DisplayMember = "FORM_name"
                    If edit = False Then CMBFORM.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltax(ByRef cmbtax As ComboBox, ByRef edit As Boolean)
        Try
            If cmbtax.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" tax_name ", "", " TaxMaster", " and Tax_cmpid=" & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "tax_name"
                    cmbtax.DataSource = dt
                    cmbtax.DisplayMember = "tax_name"
                    If edit = False Then cmbtax.Text = ""
                End If
                cmbtax.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillUSER(ByRef CMBUSER As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DISTINCT User_Name as [UserName]", "", "USERMASTER", " and USERMASTER.USER_cmpid= " & CmpId & " ORDER BY USER_NAME ")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "USERNAME"
                CMBUSER.DataSource = dt
                CMBUSER.DisplayMember = "USERNAME"
                CMBUSER.Text = ""
            End If
            CMBUSER.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub USERvalidate(ByRef CMBUSER As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBUSER.Text.Trim <> "" Then
                uppercase(CMBUSER)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("User_Name ", "", " USERMASTER ", "   and User_Name = '" & CMBUSER.Text.Trim & "' and USER_cmpid = " & CmpId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBUSER.Text.Trim
                    Dim tempmsg As Integer = MsgBox("USER not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBUSER.Text = a
                        Dim objuser As New UserMaster
                        'objuser.TEMPUSER = CMBUSER.Text.Trim()
                        ' OBJDESIGN.TEMPMERCHANT = CMBMERCHANT.Text.Trim()
                        objuser.ShowDialog()
                        dt = objclscommon.search("User_Name ", "", " USERMASTER", " and User_Name = '" & CMBUSER.Text.Trim & "'  and User_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBUSER.DataSource
                            If CMBUSER.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("USER"), CMBUSER.Text.Trim)
                                    CMBUSER.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub ALPHEBETKEYPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If (AscW(han.KeyChar) >= 65 And AscW(han.KeyChar) <= 90) Or (AscW(han.KeyChar) >= 97 And AscW(han.KeyChar) <= 122) Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If
        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Public Sub GETMAXSERIES(ByVal TXTSERIES As TextBox)
        Try
            Dim DTTABLE As DataTable = getmax(" ISNULL(MAX(SERIES),0) + 1 ", " OUTWARDSERIES ", " AND YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTSERIES.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub numdot3(ByVal han As KeyPressEventArgs, ByVal txt As TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 3 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 2 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Function getmax(ByVal fldname As String, ByVal tbname As String, Optional ByVal whereclause As String = "") As DataTable
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim DTTABLE As DataTable

            Dim objclscommon As New ClsCommon()
            DTTABLE = objclscommon.GETMAXNO(fldname, tbname, whereclause)

            Return DTTABLE
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Function GETAGENTNAME(ByVal PARTYNAME As String) As String
        Try
            Dim OBJCMN As New ClsCommon()
            Dim DTTABLE As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') AS AGENTNAME FROM LEDGERS INNER JOIN LEDGERS AS AGENTLEDGERS ON LEDGERS.ACC_AGENTID = AGENTLEDGERS.ACC_ID WHERE LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "' AND LEDGERS.ACC_YEARID = " & YearId, "", "")
            If DTTABLE.Rows.Count > 0 Then Return DTTABLE.Rows(0).Item("AGENTNAME") Else Return ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Function getfirstdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function getlastdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function datecheck(ByVal dateval As Date) As Boolean
        Dim bln As Boolean = True
        If dateval.Date > AccTo.Date Or dateval.Date < AccFrom.Date Then
            bln = False
        End If
        Return bln
    End Function

    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            han.KeyChar = ""
        End If
    End Sub

    Sub FILLEMP(ByRef CMBEMP As ComboBox, ByRef edit As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" EMP_NAME ", "", " EMPLOYEEMASTER", " AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMP_NAME"
                    CMBEMP.DataSource = dt
                    CMBEMP.DisplayMember = "EMP_NAME"
                    If edit = False Then CMBEMP.Text = ""
                End If
                CMBEMP.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub EMPVALIDATE(ByRef CMBEMP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMP.Text.Trim <> "" Then
                pcase(CMBEMP)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EMP_add", "", "EMPLOYEEMASTER", " and EMP_NAME = '" & CMBEMP.Text.Trim & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBEMP.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        CMBEMP.Text = a
                        Dim OBJEMP As New EmployeeMaster
                        OBJEMP.TEMPEMPNAME = CMBEMP.Text.Trim()
                        OBJEMP.ShowDialog()
                        dt = objclscommon.search("EMP_add", "", "EMPLOYEEMASTER", " and EMP_name = '" & CMBEMP.Text.Trim & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBEMP.DataSource
                            If CMBEMP.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBEMP.Text.Trim)
                                    CMBEMP.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillACCCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DISTINCT ACC_CODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and ACC_cmpid=" & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ACC_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "ACC_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillname(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " AND ISNULL(ACC_BLOCKED,'FALSE') = 'FALSE' and LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_Locationid=" & Locationid & " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSACCODE(ByRef CMBSACCODE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSACCODE.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable = OBJCMN.search(" HSN_ITEMDESC ", "", " HSNMASTER ", " AND HSN_TYPE = 'Services' and HSN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "HSN_ITEMDESC"
                    CMBSACCODE.DataSource = dt
                    CMBSACCODE.DisplayMember = "HSN_ITEMDESC"
                    If edit = False Then CMBSACCODE.Text = ""
                End If
                CMBSACCODE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltransname(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" LEDGERS.ACC_ID, LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_Locationid=" & Locationid & " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ISNULL(ACC_BLOCKED,'FALSE') = 'FALSE' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLDISPATCH(ByRef CMBDISPATCH As ComboBox, ByRef EDIT As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDISPATCH.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("ADDRESS_ALIAS AS ALIAS", "", " LEDGERS INNER JOIN ADDRESSMASTER ON ADDRESS_LEDGERID = ACC_ID ", " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ALIAS"
                    CMBDISPATCH.DataSource = dt
                    CMBDISPATCH.DisplayMember = "ALIAS"
                    CMBDISPATCH.Text = ""
                End If
                CMBDISPATCH.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DISPATCHVALIDATE(ByRef CMBDISPATCH As ComboBox, ByRef CMBNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDISPATCH.Text.Trim <> "" Then
                uppercase(CMBDISPATCH)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("ADDRESS_ALIAS AS ALIAS, ISNULL(ADDRESS_FULL,'') AS [ADDRESS]", "", " LEDGERS INNER JOIN ADDRESSMASTER ON ADDRESS_LEDGERID = ACC_ID ", " AND ADDRESS_ALIAS = '" & CMBDISPATCH.Text.Trim & "' AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBDISPATCH.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBDISPATCH.Text = a
                        Dim OBJADDRESS As New addressMaster
                        OBJADDRESS.TEMPNAME = CMBNAME.Text.Trim()
                        OBJADDRESS.TEMPALIAS = CMBDISPATCH.Text.Trim()
                        OBJADDRESS.ShowDialog()
                        dt = objclscommon.search("ADDRESS_ALIAS AS ALIAS, ISNULL(ADDRESS_FULL,'') AS [ADDRESS]", "", " LEDGERS INNER JOIN ADDRESSMASTER ON ADDRESS_LEDGERID = ACC_ID ", " AND ADDRESS_ALIAS = '" & CMBDISPATCH.Text.Trim & "' AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBDISPATCH.DataSource
                            If CMBDISPATCH.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ALIAS"), CMBDISPATCH.Text.Trim)
                                    CMBDISPATCH.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item("ADDRESS")
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillagentledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSALESMAN(ByRef CMBSALESMAN As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSALESMAN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SALESMAN_NAME"
                    CMBSALESMAN.DataSource = dt
                    CMBSALESMAN.DisplayMember = "SALESMAN_NAME"
                    CMBSALESMAN.Text = ""
                End If
                CMBSALESMAN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SALESMANVALIDATE(ByRef CMBSALESMAN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSALESMAN.Text.Trim <> "" Then
                uppercase(CMBSALESMAN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_NAME = '" & CMBSALESMAN.Text.Trim & "' AND SALESMAN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSALESMAN.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Salesman not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBSALESMAN.Text = a
                        Dim OBJSALES As New SalesmanMaster
                        OBJSALES.TEMPNAME = CMBSALESMAN.Text.Trim()
                        OBJSALES.ShowDialog()
                        dt = objclscommon.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_NAME = '" & CMBSALESMAN.Text.Trim & "' AND SALESMAN_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSALESMAN.DataSource
                            If CMBSALESMAN.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSALESMAN.Text.Trim)
                                    CMBSALESMAN.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub


    Sub filljobbername(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" LEDGERS.ACC_ID, LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_Locationid=" & Locationid & " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.ValueMember = "ACC_ID"
                    cmbname.Text = ""
                    'If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub filldepartment(ByRef CMBDEPARTMENT As ComboBox, ByRef edit As Boolean)
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DEPARTMENT_name ", "", " DEPARTMENTMaster", " and DEPARTMENT_cmpid=" & CmpId & " AND DEPARTMENT_LOCATIONID = " & Locationid & " AND DEPARTMENT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DEPARTMENT_name"
                    CMBDEPARTMENT.DataSource = dt
                    CMBDEPARTMENT.DisplayMember = "DEPARTMENT_name"
                    If edit = False Then CMBDEPARTMENT.Text = ""
                End If
                CMBDEPARTMENT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLMILL(ByRef CMBMILLNAME As ComboBox, ByRef edit As Boolean)
        Try
            If CMBMILLNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" MILL_name ", "", " MILLMASTER", " AND MILL_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "MILL_name"
                    CMBMILLNAME.DataSource = dt
                    CMBMILLNAME.DisplayMember = "MILL_name"
                    CMBMILLNAME.Text = ""
                End If
                CMBMILLNAME.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillYARNQUALITY(ByRef CMBYARNQUALITY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" YARN_name ", "", " YARNQUALITYMASTER", " and YARN_cmpid=" & CmpId & " AND YARN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "YARN_name"
                    CMBYARNQUALITY.DataSource = dt
                    CMBYARNQUALITY.DisplayMember = "YARN_name"
                    CMBYARNQUALITY.Text = ""
                End If
                CMBYARNQUALITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillQUALITY(ByRef CMBQUALITY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBQUALITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" QUALITY_ID, QUALITY_name ", "", " QUALITYMaster", " and QUALITY_cmpid=" & CmpId & " AND QUALITY_LOCATIONID = " & Locationid & " AND QUALITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "QUALITY_name"
                    CMBQUALITY.DataSource = dt
                    CMBQUALITY.DisplayMember = "QUALITY_name"
                    CMBQUALITY.ValueMember = "QUALITY_ID"
                    uppercase(CMBQUALITY)
                    CMBQUALITY.Text = ""
                End If
                CMBQUALITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCATEGORY(ByRef CMBCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CATEGORY_name ", "", " CATEGORYMaster", " and CATEGORY_cmpid=" & CmpId & " AND CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CATEGORY_name"
                    CMBCATEGORY.DataSource = dt
                    CMBCATEGORY.DisplayMember = "CATEGORY_name"
                    If edit = False Then CMBCATEGORY.Text = ""
                End If
                CMBCATEGORY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCITY(ByRef CMBCITY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CITY_name ", "", " CITYMaster", " and CITY_cmpid=" & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CITY_name"
                    CMBCITY.DataSource = dt
                    CMBCITY.DisplayMember = "CITY_name"
                    CMBCITY.Text = ""
                End If
                CMBCITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPROCESS(ByRef CMBPROCESS As ComboBox)
        Try
            If CMBPROCESS.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" PROCESS_name ", "", " PROCESSMASTER", " AND PROCESS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PROCESS_name"
                    CMBPROCESS.DataSource = dt
                    CMBPROCESS.DisplayMember = "PROCESS_name"
                    CMBPROCESS.Text = ""
                End If
                CMBPROCESS.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillregister(ByRef cmbregister As ComboBox, ByVal condition As String)
        Try
            If cmbregister.Text.Trim = "" Then

                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search(" Register_name ", "", "RegisterMaster ", condition & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Register_name"
                    cmbregister.DataSource = dt
                    cmbregister.DisplayMember = "Register_name"
                    cmbregister.Text = ""
                End If
                cmbregister.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub namevalidate(ByRef cmbname As ComboBox, ByRef CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "", Optional ByVal TYPE As String = "ACCOUNTS", Optional ByRef TRANSNAME As String = "", Optional ByRef AGENTNAME As String = "", Optional ByRef SUBTYPE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                uppercase(cmbname)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.tempTYPE = TYPE
                        objVendormaster.TEMPSUBTYPE = SUBTYPE

                        objVendormaster.ShowDialog()
                        dt = OBJCMN.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    If TRANSNAME = "" Then TRANSNAME = dt.Rows(0).Item(2).ToString
                    If AGENTNAME = "" Then AGENTNAME = dt.Rows(0).Item(3).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub ledgervalidate(ByRef cmbname As ComboBox, ByVal CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                pcase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull( ACC_CODE,''), REGISTER_NAME AS REGISTERNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUPMASTER.group_id = LEDGERS.Acc_groupid AND GROUPMASTER.group_cmpid = LEDGERS.Acc_cmpid AND GROUPMASTER.group_locationid = LEDGERS.Acc_locationid AND GROUPMASTER.group_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id AND LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid ", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_add, REGISTER_NAME AS REGISTERNAME, ACC_ID AS ACCID", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUPMASTER.group_id = LEDGERS.Acc_groupid AND GROUPMASTER.group_cmpid = LEDGERS.Acc_cmpid AND GROUPMASTER.group_locationid = LEDGERS.Acc_locationid AND GROUPMASTER.group_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id AND LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid ", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ACCID"), cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    CMBACCCODE.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FORMvalidate(ByRef cmbform As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbform.Text.Trim <> "" Then
                uppercase(cmbform)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("FORM_NAME", "", "FORMTYPE", " and FORM_NAME = '" & cmbform.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbform.Text.Trim
                    Dim tempmsg As Integer = MsgBox("FORM not present, Add New?", MsgBoxStyle.YesNo, "YARNTRADE")
                    If tempmsg = vbYes Then
                        cmbform.Text = a
                        Dim OBJFORM As New citymaster
                        OBJFORM.frmstring = "FORMTYPE"
                        OBJFORM.txtname.Text = cmbform.Text.Trim()
                        OBJFORM.ShowDialog()
                        dt = objclscommon.search("FORM_name", "", "FORMTYPE", " and FORM_name = '" & cmbform.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbform.DataSource
                            If cmbform.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbform.Text.Trim)
                                    cmbform.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TAXvalidate(ByRef CMBTAX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTAX.Text.Trim <> "" Then
                pcase(CMBTAX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TAX_NAME", "", "TAXMaster", " and TAX_NAME = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTAX.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TAX not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBTAX.Text = a
                        Dim OBJTAX As New Taxmaster
                        OBJTAX.txtname.Text = CMBTAX.Text.Trim()
                        OBJTAX.ShowDialog()
                        dt = objclscommon.search("TAX_name", "", "TAXMaster", " and TAX_name = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBTAX.DataSource
                            If CMBTAX.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTAX.Text.Trim)
                                    CMBTAX.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DESIGNVALIDATE(ByRef CMBDESIGN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal ITEMNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDESIGN.Text.Trim <> "" Then
                uppercase(CMBDESIGN)
                Dim WHERECLAUSE As String = ""
                If FETCHITEMWISEDESIGN = True And ITEMNAME <> "" Then WHERECLAUSE = " AND ISNULL(ITEMMASTER.ITEM_NAME,'')='" & ITEMNAME & "'"
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("DESIGN_NO ", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGNMASTER.DESIGN_ITEMID=ITEMMASTER.ITEM_ID ", "  AND ISNULL(DESIGN_BLOCKED,0) = 'FALSE' " & WHERECLAUSE & " and DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' and DESIGN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBDESIGN.Text.Trim
                    Dim tempmsg As Integer = MsgBox("DESIGN not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBDESIGN.Text = a
                        Dim OBJDESIGN As New DesignMaster
                        OBJDESIGN.tempdesignno = CMBDESIGN.Text.Trim()
                        ' OBJDESIGN.TEMPMERCHANT = CMBMERCHANT.Text.Trim()
                        OBJDESIGN.ShowDialog()
                        dt = objclscommon.search("DESIGN_ID AS DESIGNID, DESIGN_NO ", "", "  DESIGNMASTER ", "  AND ISNULL(DESIGN_BLOCKED,0) = 'FALSE' and DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' and DESIGN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBDESIGN.DataSource
                            If CMBDESIGN.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("DESIGNID"), CMBDESIGN.Text.Trim)
                                    CMBDESIGN.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub




    Sub DEPARTMENTVALIDATE(ByRef CMBDEPARTMENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEPARTMENT.Text.Trim <> "" Then
                uppercase(CMBDEPARTMENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEPARTMENT_id", "", "DEPARTMENTMaster", " and DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_LOCATIONid = " & Locationid & " and DEPARTMENT_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEPARTMENT not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEPARTMENT.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEPARTMENT As New ClsDepartmentMaster
                        objclsDEPARTMENT.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEPARTMENT.SAVE()
                    Else
                        CMBDEPARTMENT.Focus()
                        CMBDEPARTMENT.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PROCESSVALIDATE(ByRef CMBPROCESS As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPROCESS.Text.Trim <> "" Then
                uppercase(CMBPROCESS)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PROCESS_id", "", "PROCESSMaster", " and PROCESS_NAME = '" & CMBPROCESS.Text.Trim & "' and PROCESS_cmpid = " & CmpId & " and PROCESS_LOCATIONid = " & Locationid & " and PROCESS_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PROCESS not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPROCESS.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsPROCESS As New ClsProcessMaster
                        objclsPROCESS.alParaval = alParaval
                        Dim IntResult As Integer = objclsPROCESS.save()
                    Else
                        CMBPROCESS.Focus()
                        CMBPROCESS.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub



    Sub FILLNATURE(ByRef CMBNATURE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" PAY_name ", "", " NATUREOFPAYMENTMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PAY_name"
                CMBNATURE.DataSource = dt
                CMBNATURE.DisplayMember = "PAY_name"
                CMBNATURE.Text = ""
            End If
            CMBNATURE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NATUREVALIDATE(ByRef CMBNATURE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNATURE.Text.Trim <> "" Then
                uppercase(CMBNATURE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAY_id", "", "NATUREOFPAYMENTMASTER", " and PAY_NAME = '" & CMBNATURE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("NATURE OF PAYMENT not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBNATURE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJNATUREOFPAYMENT As New ClsNatureOfPayment
                        OBJNATUREOFPAYMENT.alParaval = alParaval
                        Dim IntResult As Integer = OBJNATUREOFPAYMENT.SAVE()
                    Else
                        CMBNATURE.Focus()
                        CMBNATURE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSTOREITEMNAME(ByRef CMBSTOREITEM As ComboBox)
        Try
            If CMBSTOREITEM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STOREITEM_name ", "", " STOREITEMMaster", " AND STOREITEM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STOREITEM_name"
                    CMBSTOREITEM.DataSource = dt
                    CMBSTOREITEM.DisplayMember = "STOREITEM_name"
                    CMBSTOREITEM.Text = ""
                End If
                CMBSTOREITEM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLLOOMNO(ByRef CMBLOOMNO As ComboBox, ByVal WEAVERNAME As String, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBLOOMNO.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable = OBJCMN.search("  LOOMMASTER_DESC.LOOM_NO AS LOOMNO ", "", "  LOOMMASTER INNER JOIN LOOMMASTER_DESC ON LOOMMASTER.LOOM_ID = LOOMMASTER_DESC.LOOM_ID INNER JOIN LEDGERS ON LOOMMASTER.LOOM_WEAVERID = LEDGERS.Acc_id", WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & WEAVERNAME & "' AND LOOM_YEARID = " & YearId & " ORDER BY CAST(LOOM_NO AS INT)")
                If dt.Rows.Count > 0 Then
                    CMBLOOMNO.DataSource = dt
                    CMBLOOMNO.DisplayMember = "LOOMNO"
                    CMBLOOMNO.Text = ""
                End If
                CMBLOOMNO.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub LOOMVALIDATE(ByRef CMBLOOMNO As ComboBox, ByVal WEAVERNAME As String, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBLOOMNO.Text.Trim <> "" Then
                uppercase(CMBLOOMNO)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable = OBJCMN.search("  LOOMMASTER_DESC.LOOM_NO AS LOOMNO ", "", "  LOOMMASTER INNER JOIN LOOMMASTER_DESC ON LOOMMASTER.LOOM_ID = LOOMMASTER_DESC.LOOM_ID INNER JOIN LEDGERS ON LOOMMASTER.LOOM_WEAVERID = LEDGERS.Acc_id", WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & WEAVERNAME & "' AND LOOM_NO = '" & CMBLOOMNO.Text.Trim & "' AND LOOM_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBLOOMNO.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Loom No not present for selected Weaver, Add New?", MsgBoxStyle.YesNo, "PROCESS")
                    If tempmsg = vbYes Then
                        CMBLOOMNO.Text = a
                        Dim OBJBEAM As New LoomMaster
                        OBJBEAM.WEAVERNAME = WEAVERNAME
                        OBJBEAM.ShowDialog()
                        dt = OBJCMN.search("  LOOMMASTER_DESC.LOOM_NO AS LOOMNO ", "", "  LOOMMASTER INNER JOIN LOOMMASTER_DESC ON LOOMMASTER.LOOM_ID = LOOMMASTER_DESC.LOOM_ID INNER JOIN LEDGERS ON LOOMMASTER.LOOM_WEAVERID = LEDGERS.Acc_id", WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & WEAVERNAME & "' AND LOOM_NO = '" & CMBLOOMNO.Text.Trim & "' AND LOOM_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable = CMBLOOMNO.DataSource
                            If CMBLOOMNO.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBLOOMNO.Text.Trim)
                                    CMBLOOMNO.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub STOREITEMVALIDATE(ByRef CMBSTOREITEM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTOREITEM.Text.Trim <> "" Then
                uppercase(CMBSTOREITEM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("   STOREITEMMASTER.STOREITEM_name AS STOREITEM", "", "  STOREITEMMASTER ", " and  STOREITEMMASTER.STOREITEM_name = '" & CMBSTOREITEM.Text.Trim & "' and STOREITEMMASTER.STOREITEM_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTOREITEM.Text.Trim
                    Dim tempmsg As Integer = MsgBox("STOREITEM not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then
                        CMBSTOREITEM.Text = a
                        Dim objSTOREITEMmaster As New StoreItemMaster
                        objSTOREITEMmaster.TEMPNAME = CMBSTOREITEM.Text.Trim()

                        objSTOREITEMmaster.ShowDialog()
                        dt = objclscommon.search("   STOREITEMMASTER.STOREITEM_name AS STOREITEM ", "", "  STOREITEMMASTER ", " and  STOREITEMMASTER.STOREITEM_name = '" & CMBSTOREITEM.Text.Trim & "' and STOREITEMMASTER.STOREITEM_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSTOREITEM.DataSource
                            If CMBSTOREITEM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSTOREITEM.Text.Trim)
                                    CMBSTOREITEM.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub QUALITYVALIDATE(ByRef CMBQUALITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByRef unit As String = "", Optional ByRef ProcessNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBQUALITY.Text.Trim <> "" Then
                uppercase(CMBQUALITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("   QUALITYMASTER.QUALITY_name AS QUALITY, ProcessMASTER.Process_name AS Process, UNITMASTER.unit_abbr AS UNIT ", "", "  QUALITYMASTER LEFT OUTER JOIN ProcessMASTER ON QUALITYMASTER.QUALITY_ProcessID = ProcessMASTER.Process_id AND QUALITYMASTER.QUALITY_cmpid = ProcessMASTER.Process_cmpid AND QUALITYMASTER.QUALITY_locationid = ProcessMASTER.Process_locationid AND QUALITYMASTER.QUALITY_yearid = ProcessMASTER.Process_yearid LEFT OUTER JOIN UNITMASTER ON QUALITYMASTER.QUALITY_UNITID = UNITMASTER.unit_id AND QUALITYMASTER.QUALITY_cmpid = UNITMASTER.unit_cmpid AND QUALITYMASTER.QUALITY_locationid = UNITMASTER.unit_locationid AND QUALITYMASTER.QUALITY_yearid = UNITMASTER.unit_yearid", " and  QUALITYMASTER.QUALITY_name = '" & CMBQUALITY.Text.Trim & "' and QUALITYMASTER.QUALITY_cmpid = " & CmpId & " and QUALITYMASTER.QUALITY_Locationid = " & Locationid & " and QUALITYMASTER.QUALITY_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBQUALITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Quality not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then
                        CMBQUALITY.Text = a
                        Dim objqualitymaster As New QualityMaster
                        objqualitymaster.tempQualityName = CMBQUALITY.Text.Trim()

                        objqualitymaster.ShowDialog()
                        dt = objclscommon.search("   QUALITYMASTER.QUALITY_name AS QUALITY, ProcessMASTER.Process_name AS Process, UNITMASTER.unit_abbr AS UNIT, QUALITY_ID AS QUALITYID ", "", "  QUALITYMASTER LEFT OUTER JOIN ProcessMASTER ON QUALITYMASTER.QUALITY_ProcessID = ProcessMASTER.Process_id AND QUALITYMASTER.QUALITY_cmpid = ProcessMASTER.Process_cmpid AND QUALITYMASTER.QUALITY_locationid = ProcessMASTER.Process_locationid AND QUALITYMASTER.QUALITY_yearid = ProcessMASTER.Process_yearid LEFT OUTER JOIN UNITMASTER ON QUALITYMASTER.QUALITY_UNITID = UNITMASTER.unit_id AND QUALITYMASTER.QUALITY_cmpid = UNITMASTER.unit_cmpid AND QUALITYMASTER.QUALITY_locationid = UNITMASTER.unit_locationid AND QUALITYMASTER.QUALITY_yearid = UNITMASTER.unit_yearid", " and  QUALITYMASTER.QUALITY_name = '" & CMBQUALITY.Text.Trim & "' and QUALITYMASTER.QUALITY_cmpid = " & CmpId & " and QUALITYMASTER.QUALITY_Locationid = " & Locationid & " and QUALITYMASTER.QUALITY_Yearid = " & YearId)
                        'dt = objclscommon.search("Process_name", "", "ProcessMaster", " and Process_name = '" & CMBQUALITY.Text.Trim & "' and Process_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBQUALITY.DataSource
                            If CMBQUALITY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("QUALITYID"), CMBQUALITY.Text.Trim)
                                    CMBQUALITY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else

                    unit = dt.Rows(0).Item(2).ToString
                    ProcessNAME = dt.Rows(0).Item(1).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CATEGORYVALIDATE(ByRef CMBCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCATEGORY.Text.Trim <> "" Then
                uppercase(CMBCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CATEGORY_id", "", "CATEGORYMaster", " and CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' and CATEGORY_cmpid = " & CmpId & " and CATEGORY_LOCATIONid = " & Locationid & " and CATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CATEGORY not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCATEGORY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCATEGORY As New ClsCategoryMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.save()
                    Else
                        CMBCATEGORY.Focus()
                        CMBCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CITYVALIDATE(ByRef CMBCITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCITY.Text.Trim <> "" Then
                uppercase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CITY_id", "", "CITYMaster", " and CITY_NAME = '" & CMBCITY.Text.Trim & "' and CITY_cmpid = " & CmpId & " and CITY_LOCATIONid = " & Locationid & " and CITY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CITY not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(CMBCITY.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCITY As New ClsCityMaster
                        objclsCITY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCITY.save()
                    Else
                        CMBCITY.Focus()
                        CMBCITY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub MILLVALIDATE(ByRef CMBMILLNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBMILLNAME.Text.Trim <> "" Then
                uppercase(CMBMILLNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("MILL_id", "", "MILLMASTER", " and MILL_NAME = '" & CMBMILLNAME.Text.Trim & "' and MILL_cmpid = " & CmpId & "and MILL_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Mill not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBMILLNAME.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim objclsCATEGORY As New ClsMillMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.SAVE()
                    Else
                        CMBMILLNAME.Focus()
                        CMBMILLNAME.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub YARNQUALITYVALIDATE(ByRef CMBYARNQUALITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBYARNQUALITY.Text.Trim <> "" Then
                uppercase(CMBYARNQUALITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("YARN_id", "", "YARNQUALITYMASTER", " and YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "' and YARN_cmpid = " & CmpId & "and YARN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBYARNQUALITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Yarn Quality not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBYARNQUALITY.Text = a
                        Dim OBJYARN As New YarnQualityMaster
                        OBJYARN.tempname = CMBYARNQUALITY.Text.Trim()
                        OBJYARN.ShowDialog()
                        dt = objclscommon.search("YARN_name", "", " YARNQUALITYMASTER ", " and  YARN_name = '" & CMBYARNQUALITY.Text.Trim & "' and YARN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBYARNQUALITY.DataSource
                            If CMBYARNQUALITY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBYARNQUALITY.Text.Trim)
                                    CMBYARNQUALITY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillitemname(ByRef cmbitemname As ComboBox, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" ITEM_ID, item_name ", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid and MaterialTypeMaster.Material_cmpid = ItemMaster.Item_cmpid and MaterialTypeMaster.Material_locationid = ItemMaster.Item_locationid and MaterialTypeMaster.Material_yearid = ItemMaster.Item_yearid ", CONDITION & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' and item_Yearid=" & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "item_name"
                cmbitemname.DataSource = dt
                cmbitemname.DisplayMember = "item_name"
                cmbitemname.ValueMember = "ITEM_ID"
                cmbitemname.Text = ""
                uppercase(cmbitemname)
            End If
            cmbitemname.SelectAll()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillitemcode(ByRef cmbitemcode As ComboBox, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("ITEM_ID, item_code ", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid and MaterialTypeMaster.Material_cmpid = ItemMaster.Item_cmpid and MaterialTypeMaster.Material_locationid = ItemMaster.Item_locationid and MaterialTypeMaster.Material_yearid = ItemMaster.Item_yearid ", CONDITION & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' and item_Yearid=" & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "item_code"
                cmbitemcode.DataSource = dt
                cmbitemcode.DisplayMember = "item_code"
                cmbitemcode.Text = ""
                uppercase(cmbitemcode)
            End If
            cmbitemcode.SelectAll()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLBEAM(ByRef CMBBEAM As ComboBox, ByRef edit As Boolean)
        Try
            If CMBBEAM.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search(" BEAM_NAME ", "", " BEAMMASTER", " AND BEAM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "BEAM_NAME"
                    CMBBEAM.DataSource = dt
                    CMBBEAM.DisplayMember = "BEAM_NAME"
                    If edit = False Then CMBBEAM.Text = ""
                End If
                CMBBEAM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BEAMVALIDATE(ByRef CMBBEAM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBBEAM.Text.Trim <> "" Then
                uppercase(CMBBEAM)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("BEAM_NAME", "", "BEAMMASTER", " and BEAM_NAME = '" & CMBBEAM.Text.Trim & "' and BEAM_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBBEAM.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Beam Name not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBBEAM.Text = a
                        Dim OBJBEAM As New BeamMaster
                        OBJBEAM.TEMPBEAMNAME = CMBBEAM.Text.Trim()
                        OBJBEAM.ShowDialog()
                        dt = OBJCMN.search("BEAM_name", "", "BEAMMaster", " and BEAM_name = '" & CMBBEAM.Text.Trim & "' and BEAM_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBBEAM.DataSource
                            If CMBBEAM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBBEAM.Text.Trim)
                                    CMBBEAM.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillunit(ByRef cmbunit As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", " UnitMaster ", " and unit_cmpid=" & CmpId & " and unit_Locationid=" & Locationid & " and unit_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "unit_abbr"
                    cmbunit.DataSource = dt
                    cmbunit.DisplayMember = "unit_abbr"
                    cmbunit.Text = ""
                End If
                cmbunit.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub itemvalidate(ByRef cmbitemname As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal CONDITION As String, ByVal FRMSTRING As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbitemname.Text.Trim <> "" Then
                uppercase(cmbitemname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_name", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid and MaterialTypeMaster.Material_cmpid = ItemMaster.Item_cmpid and MaterialTypeMaster.Material_Locationid = ItemMaster.Item_Locationid and MaterialTypeMaster.Material_Yearid = ItemMaster.Item_Yearid ", CONDITION & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' and  item_name = '" & cmbitemname.Text.Trim & "' and item_cmpid = " & CmpId & " and item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbitemname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbitemname.Text = a
                        Dim objitemmaster As New ItemMaster
                        objitemmaster.TEMPITEMNAME = cmbitemname.Text.Trim()
                        objitemmaster.FRMSTRING = FRMSTRING
                        objitemmaster.ShowDialog()
                        dt = objclscommon.search("item_name, ITEM_ID AS ITEMID", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid and MaterialTypeMaster.Material_cmpid = ItemMaster.Item_cmpid and MaterialTypeMaster.Material_Locationid = ItemMaster.Item_Locationid and MaterialTypeMaster.Material_Yearid = ItemMaster.Item_Yearid ", CONDITION & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' and  item_name = '" & cmbitemname.Text.Trim & "' and item_cmpid = " & CmpId & " and item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                        'dt = objclscommon.search("item_name", "", "itemMaster", " and item_name = '" & cmbitemname.Text.Trim & "' and item_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbitemname.DataSource
                            If cmbitemname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ITEMID"), cmbitemname.Text.Trim)
                                    cmbitemname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub itemcodevalidate(ByRef cmbitemcode As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal CONDITION As String, ByVal FRMSTRING As String, ByRef itemname As String, Optional ByRef unit As String = "", Optional ByRef folds As String = "", Optional ByRef category As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbitemcode.Text.Trim <> "" Then
                uppercase(cmbitemcode)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_code,item_name as itemname, ITEM_ID AS ITEMID", "", " ITEMMASTER ", CONDITION & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' and  item_code = '" & cmbitemcode.Text.Trim & "' and item_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbitemcode.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbitemcode.Text = a
                        Dim objitemmaster As New ItemMaster
                        objitemmaster.TEMPITEMCODE = cmbitemcode.Text.Trim()
                        objitemmaster.FRMSTRING = FRMSTRING

                        objitemmaster.ShowDialog()
                        dt = objclscommon.search("item_code,item_name as itemname, ITEM_ID AS ITEMID", "", " ITEMMASTER ", CONDITION & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' and  item_code = '" & cmbitemcode.Text.Trim & "' and item_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbitemcode.DataSource
                            If cmbitemcode.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ITEMID"), cmbitemcode.Text.Trim)
                                    cmbitemcode.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    itemname = dt.Rows(0).Item("itemname")
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub unitvalidate(ByRef cmbunit As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            Cursor.Current = Cursors.WaitCursor
            If cmbunit.Text.Trim <> "" Then
                uppercase(cmbunit)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " and unit_Locationid = " & Locationid & " and unit_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbunit.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Unit not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbunit.Text = a
                        Dim objunitmaster As New UnitMaster
                        objunitmaster.frmString = "UNIT"
                        objunitmaster.txtabbr.Text = cmbunit.Text.Trim()
                        objunitmaster.ShowDialog()
                        dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " and unit_Locationid = " & Locationid & " and unit_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbunit.DataSource
                            If cmbunit.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbunit.Text.Trim)
                                    cmbunit.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLRACK(ByRef CMBRACK As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBRACK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" RACK_ID AS ID , RACK_NAME AS NAME ", "", "RACKMASTER", " And RACK_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBRACK.DataSource = dt
                    CMBRACK.DisplayMember = "NAME"
                    CMBRACK.ValueMember = "ID"
                    CMBRACK.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCONTRACT(ByRef CMBCONTRACT As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCONTRACT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CONTRACT_ID AS ID , CONTRACT_NAME AS NAME ", "", "CONTRACTMASTER", " And CONTRACT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBCONTRACT.DataSource = dt
                    CMBCONTRACT.DisplayMember = "NAME"
                    CMBCONTRACT.ValueMember = "ID"
                    CMBCONTRACT.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CONTRACTVALIDATE(ByRef cmbcontractor As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbcontractor.Text.Trim <> "" Then
                uppercase(cmbcontractor)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CONTRACT_NAME ", "", " CONTRACTMASTER", " and CONTRACT_NAME = '" & cmbcontractor.Text.Trim & "' and CONTRACT_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Contractor not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = cmbcontractor.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbcontractor.Text.Trim)
                        alParaval.Add(0)    'RATE
                        alParaval.Add("")   'REMARKS
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsContractMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" CONTRACT_ID AS ID, CONTRACT_NAME AS NAME ", "", " CONTRACTMASTER", " and CONTRACT_NAME = '" & cmbcontractor.Text.Trim & "' and CONTRACT_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbcontractor.DataSource
                            If cmbcontractor.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), cmbcontractor.Text.Trim)
                                    cmbcontractor.Text = a
                                End If
                            End If
                        End If

                    Else
                        cmbcontractor.Focus()
                        cmbcontractor.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub RACKVALIDATE(ByRef CMBRACK As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBRACK.Text.Trim <> "" Then
                uppercase(CMBRACK)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" RACK_NAME ", "", " RACKMASTER", " and RACK_NAME = '" & CMBRACK.Text.Trim & "' and RACK_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Rack not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBRACK.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBRACK.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsRackMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" RACK_ID AS ID, RACK_NAME AS NAME ", "", " RACKMASTER", " and RACK_NAME = '" & CMBRACK.Text.Trim & "' and RACK_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBRACK.DataSource
                            If CMBRACK.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBRACK.Text.Trim)
                                    CMBRACK.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBRACK.Focus()
                        CMBRACK.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLSHELF(ByRef CMBSHELF As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSHELF.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SHELF_ID AS ID , SHELF_NAME AS NAME ", "", "SHELFMASTER", " And SHELF_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBSHELF.DataSource = dt
                    CMBSHELF.DisplayMember = "NAME"
                    CMBSHELF.ValueMember = "ID"
                    CMBSHELF.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SHELFVALIDATE(ByRef CMBSHELF As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBSHELF.Text.Trim <> "" Then
                uppercase(CMBSHELF)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SHELF_NAME ", "", " SHELFMASTER", " and SHELF_NAME = '" & CMBSHELF.Text.Trim & "' and SHELF_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Shelf not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBSHELF.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSHELF.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsShelfMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search("SHELF_ID AS ID, SHELF_NAME AS NAME ", "", " SHELFMASTER", " and SHELF_NAME = '" & CMBSHELF.Text.Trim & "' and SHELF_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSHELF.DataSource
                            If CMBSHELF.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBSHELF.Text.Trim)
                                    CMBSHELF.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBSHELF.Focus()
                        CMBSHELF.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillTERM(ByRef CMBTERM As ComboBox, ByRef edit As Boolean)
        Try
            If CMBTERM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERECLAUSE As String = ""
                dt = objclscommon.search(" TERM_NAME ", "", "TERMMaster", WHERECLAUSE & " and TERM_cmpid=" & CmpId & " AND TERM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TERM_NAME"
                    CMBTERM.DataSource = dt
                    CMBTERM.DisplayMember = "TERM_NAME"
                    If edit = False Then CMBTERM.Text = ""
                End If
                CMBTERM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TERMVALIDATE(ByRef CMBTERM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBTERM.Text.Trim <> "" Then
                uppercase(CMBTERM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" TERM_NAME ", "", " TERMMASTER", " and TERM_NAME = '" & CMBTERM.Text.Trim & "' and TERM_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Term not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBTERM.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBTERM.Text.Trim)
                        alParaval.Add(0)    'CRDAYS
                        alParaval.Add(0)    'OTHER PER
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsTermMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" TERM_ID AS ID, TERM_NAME AS NAME ", "", " TERMMASTER", " and TERM_NAME = '" & CMBTERM.Text.Trim & "' and TERM_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBTERM.DataSource
                            If CMBTERM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBTERM.Text.Trim)
                                    CMBTERM.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBTERM.Focus()
                        CMBTERM.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If


        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGROUPCOMPANY(ByRef CMBGRPCOMPANY As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGRPCOMPANY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GOC_ID AS ID , GOC_NAME AS NAME ", "", "GROUPOFCOMPANIESMASTER", " And GOC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBGRPCOMPANY.DataSource = dt
                    CMBGRPCOMPANY.DisplayMember = "NAME"
                    CMBGRPCOMPANY.ValueMember = "ID"
                    CMBGRPCOMPANY.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GROUPCOMPANYVALIDATE(ByRef CMBGRPCOMPANY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBGRPCOMPANY.Text.Trim <> "" Then
                uppercase(CMBGRPCOMPANY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GOC_NAME ", "", " GROUPOFCOMPANIESMASTER ", " and GOC_NAME = '" & CMBGRPCOMPANY.Text.Trim & "' and GOC_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Company not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBGRPCOMPANY.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBGRPCOMPANY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsGroupOfCompanies
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" GOC_ID AS ID, GOC_NAME AS NAME ", "", " GROUPOFCOMPANIESMASTER", " and GOC_NAME = '" & CMBGRPCOMPANY.Text.Trim & "' and GOC_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBGRPCOMPANY.DataSource
                            If CMBGRPCOMPANY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBGRPCOMPANY.Text.Trim)
                                    CMBGRPCOMPANY.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBGRPCOMPANY.Focus()
                        CMBGRPCOMPANY.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLPACKINGTYPE(ByRef CMBGRPCOMPANY As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGRPCOMPANY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" PACKINGTYPE_ID AS ID , PACKINGTYPE_NAME AS NAME ", "", "PACKINGTYPEMASTER", " And PACKINGTYPE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBGRPCOMPANY.DataSource = dt
                    CMBGRPCOMPANY.DisplayMember = "NAME"
                    CMBGRPCOMPANY.ValueMember = "ID"
                    CMBGRPCOMPANY.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PACKINGTYPEVALIDATE(ByRef CMBPACKINGTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBPACKINGTYPE.Text.Trim <> "" Then
                uppercase(CMBPACKINGTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PACKINGTYPE_NAME ", "", " PACKINGTYPEMASTER ", " and PACKINGTYPE_NAME = '" & CMBPACKINGTYPE.Text.Trim & "' and PACKINGTYPE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Packing Type not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBPACKINGTYPE.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPACKINGTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(0)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objRACK As New ClsPackingTypeMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.save()


                        dt = objclscommon.search(" PACKINGTYPE_ID AS ID, PACKINGTYPE_NAME AS NAME ", "", " PACKINGTYPEMASTER", " and PACKINGTYPE_NAME = '" & CMBPACKINGTYPE.Text.Trim & "' and PACKINGTYPE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBPACKINGTYPE.DataSource
                            If CMBPACKINGTYPE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBPACKINGTYPE.Text.Trim)
                                    CMBPACKINGTYPE.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBPACKINGTYPE.Focus()
                        CMBPACKINGTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLMACHINE(ByRef CMBMACHINE As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBMACHINE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" MACHINE_ID AS ID , MACHINE_NAME AS NAME ", "", " MACHINEMASTER ", " And MACHINE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBMACHINE.DataSource = dt
                    CMBMACHINE.DisplayMember = "NAME"
                    CMBMACHINE.ValueMember = "ID"
                    CMBMACHINE.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub MACHINEVALIDATE(ByRef CMBMACHINE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBMACHINE.Text.Trim <> "" Then
                uppercase(CMBMACHINE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" MACHINE_NAME ", "", "MACHINEMASTER", " and MACHINE_NAME = '" & CMBMACHINE.Text.Trim & "' and MACHINE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Machine not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBMACHINE.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBMACHINE.Text.Trim)
                        alParaval.Add(0)    'AREA
                        alParaval.Add(0)    'LENGTH
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsMachineMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" MACHINE_ID AS ID, MACHINE_NAME AS NAME ", "", "MACHINEMASTER", " and MACHINE_NAME = '" & CMBMACHINE.Text.Trim & "' and MACHINE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBMACHINE.DataSource
                            If CMBMACHINE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBMACHINE.Text.Trim)
                                    CMBMACHINE.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBMACHINE.Focus()
                        CMBMACHINE.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub ACCCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBACCNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox, Optional ByVal WHERECLAUSE As String = "", Optional ByVal GROUPNAME As String = "")
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_CMPNAME, ACC_ADD", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsCode = CMBCODE.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("ACC_CODE", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBACCNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillGODOWN(ByRef CMBGODOWN As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBGODOWN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GODOWN_name ", "", " GODOWNMaster", WHERECLAUSE & " AND GODOWN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GODOWN_name"
                    CMBGODOWN.DataSource = dt
                    CMBGODOWN.DisplayMember = "GODOWN_name"
                    If edit = False Then CMBGODOWN.Text = ""
                End If
                CMBGODOWN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GODOWNVALIDATE(ByRef CMBGODOWN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGODOWN.Text.Trim <> "" Then
                uppercase(CMBGODOWN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GODOWN_id", "", "GODOWNMaster", " and GODOWN_NAME = '" & CMBGODOWN.Text.Trim & "' and GODOWN_cmpid = " & CmpId & " and GODOWN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("GODOWN not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(CMBGODOWN.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsGODOWN As New ClsGodownMaster
                        objclsGODOWN.alParaval = alParaval
                        Dim IntResult As Integer = objclsGODOWN.save()
                    Else
                        CMBGODOWN.Focus()
                        CMBGODOWN.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub HSNITEMDESCVALIDATE(ByRef CMBHSNCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHSNCODE.Text.Trim <> "" Then
                uppercase(CMBHSNCODE)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", "and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBHSNCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("HSN/SAC Code Not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then
                        CMBHSNCODE.Text = a
                        Dim OBJDELIVERY As New HSNMaster
                        OBJDELIVERY.tempHSNCODE = CMBHSNCODE.Text.Trim()

                        OBJDELIVERY.ShowDialog()
                        dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", " and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBHSNCODE.DataSource
                            If CMBHSNCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHSNCODE.Text.Trim)
                                    CMBHSNCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGROUP(ByRef CMBGROUP As ComboBox)
        Try
            If CMBGROUP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    CMBGROUP.DataSource = dt
                    CMBGROUP.DisplayMember = "group_name"
                    CMBGROUP.Text = ""
                End If
                CMBGROUP.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLBANK(ByRef CMBBANK As ComboBox)
        Try
            If CMBBANK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", " PARTYBANKMaster ", " and PARTYBANK_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PARTYBANK_name"
                    CMBBANK.DataSource = dt
                    CMBBANK.DisplayMember = "PARTYBANK_name"
                    CMBBANK.Text = ""
                End If
                CMBBANK.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PARTYBANKvalidate(ByRef CMBPARTYBANK As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBPARTYBANK.Text.Trim <> "" Then
                uppercase(CMBPARTYBANK)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", "PARTYBANKMaster", " and PARTYBANK_name = '" & CMBPARTYBANK.Text.Trim & "' and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_locationid = " & Locationid & " and PARTYBANK_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PARTYBANK Name not present, Add New?", MsgBoxStyle.YesNo, "BROKERMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPARTYBANK.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objPIECETYPE As New ClsPARTYBANKMaster
                        objPIECETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objPIECETYPE.save()
                        'e.Cancel = True
                    Else
                        CMBPARTYBANK.Focus()
                        CMBPARTYBANK.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "FUNCTION FOR EMAIL"

    Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal ALATTACHMENT As ArrayList = Nothing, Optional ByVal NOOFATTACHMENTS As Integer = 0, Optional ByVal TEMPATTACHMENT1 As String = "", Optional ByVal TEMPATTACHMENT2 As String = "", Optional ByVal TEMPATTACHMENT3 As String = "", Optional ByVal TEMPATTACHMENT4 As String = "", Optional ByVal TEMPATTACHMENT5 As String = "", Optional ByVal TEMPATTACHMENT6 As String = "")

        'Dim mailBody As String
        Try
            Cursor.Current = Cursors.WaitCursor

            'create the mail message
            Dim mail As New MailMessage
            Dim MAILATTACHMENT As Attachment

            'set the addresses
            'mail.From = New MailAddress("siddhivinayaksynthetics@gmail.com", CmpName)
            'mail.From = New MailAddress("gulkitjain@gmail.com", "TexPro V1.0")

            mail.To.Add(toMail)

            '''' GIVING ISSUE IN DIRECT MULTIPLE PRINT IN INVOICE.
            ''set the content
            'mail.Subject = subject
            'mail.Body = mailbody
            'mail.IsBodyHtml = True
            'MAILATTACHMENT = New Attachment(tempattachment)
            'mail.Attachments.Add(MAILATTACHMENT)

            'If TEMPATTACHMENT1 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT1)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT2 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT2)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT3 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT3)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT4 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT4)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If


            'If TEMPATTACHMENT5 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT5)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT6 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT6)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'set the content
            mail.Subject = subject
            mail.Body = mailbody
            mail.IsBodyHtml = True
            If NOOFATTACHMENTS <= 1 Then
                If ALATTACHMENT.Count > 0 Then MAILATTACHMENT = New Attachment(ALATTACHMENT(0)) Else MAILATTACHMENT = New Attachment(tempattachment)
                mail.Attachments.Add(MAILATTACHMENT)
            Else
                For I As Integer = 0 To NOOFATTACHMENTS - 1
                    MAILATTACHMENT = New Attachment(ALATTACHMENT(I))
                    mail.Attachments.Add(MAILATTACHMENT)
                Next
            End If


            'send the message
            Dim smtp As New SmtpClient

            'set username and password
            Dim nc As New System.Net.NetworkCredential


            'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")
                'smtp.Port = (25)
                smtp.Port = (587)


                smtp.EnableSsl = True
                mail.From = New MailAddress(DT.Rows(0).Item("EMAIL"), CmpName)
                nc.UserName = DT.Rows(0).Item("EMAIL")
                nc.Password = DT.Rows(0).Item("PASS") '"qhokuzymfmcxtoge"

            Else

                smtp.Host = "smtp.gmail.com"
                'smtp.Port = (25)
                smtp.Port = (587)
                smtp.EnableSsl = True

                mail.From = New MailAddress("noreply.textrade@gmail.com", CmpName)
                nc.UserName = "noreply.textrade@gmail.com"
                nc.Password = "qhokuzymfmcxtoge"

            End If


            'smtp.Timeout = 20000
            smtp.Timeout = 50000

            smtp.Credentials = nc

            smtp.Send(mail)
            mail.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

    Function checkrowlinedel(ByVal gridsrno As Integer, ByVal txtno As TextBox) As Boolean
        Dim bln As Boolean = True
        If gridsrno = Val(txtno.Text.Trim) Then
            bln = False
        End If
        Return bln
    End Function

    Sub commakeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 44 Then
            han.KeyChar = ""
        End If
    End Sub

    Function GETDEFAULTGODOWN() As String
        Try
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" GODOWN_NAME AS GODOWNNAME ", "", " GODOWNMASTER ", " and GODOWN_ISDEFAULT = 'True' and GODOWN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("GODOWNNAME") Else Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Module
