Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data

Public Class ClsManage

    Public Shared msgLFLNone As String = "N/A"
    Public Shared formatDateTime As String = "d/M/yyyy"
    Public Shared msgRequiredFill As String = "Some information is required"
    Public Shared EmptyDataText As String = "<div style='color:red;text-align:center;border:solid 1px silver;'>Data not Found.</div>"

    Enum lflType
        LFL
        NonLFL
        Closed
        NewStore
        OtherBusincess
    End Enum

    Enum growthType
        LFL
        YOY
    End Enum
#Region "convert"

    'New LFL YOY
    Public Shared Function convert2PercenGrowth(ByVal str As String, gType As growthType) As String
        Try
            Dim strReturn As String = ""

            If gType = growthType.LFL Then
                strReturn = "N/A"
            Else
                strReturn = "100.0%"
            End If

            If str = "" Then
                Return strReturn
            End If

            Dim result As Decimal = Convert.ToDecimal(str)

            If result = 0 Then
                Return strReturn
            End If

            Return result.ToString("#,##0.0%")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2PercenGrowthTradingProfit(ByVal str As String, gType As growthType, thisTrade As Double, lastTrade As Double) As String
        Try
            Dim strReturn As String = ""

            If gType = growthType.LFL Then
                strReturn = "N/A"
            Else
                strReturn = "100.0%"
            End If

            If str = "" Then
                Return strReturn
            End If

            Dim result As Decimal = Convert.ToDecimal(str)

            If result = 0 Then
                Return strReturn
            End If

            'Trading Profit/loss ถ้าลดลงให้ติดลบ
            If thisTrade < lastTrade Then
                result = -Math.Abs(result)
            Else
                result = Math.Abs(result)
            End If

            Return result.ToString("#,##0.0%")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2Round(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return ""
            Else
                If str.Substring(0, 1) = "(" And str.Substring(str.Length - 1, 1) = ")" Then
                    Return str
                End If
                Dim result As Double = Double.Parse(str)
                If result < 0 Then
                    Return (-result).ToString("(###0)")
                Else
                    Return result.ToString("###0")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2Currency(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return Double.Parse("0").ToString("#,##0.00")
            Else
                Return Double.Parse(str).ToString("#,##0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2PercenNoneZero(ByVal str As String, ByVal divi As String) As String
        Try
            If str <> "" And divi <> "" Then
                If str <> 0 And divi <> 0 Then
                    Dim result As Decimal = 0
                    'ex case "3.72529029846191E-09"
                    Dim rValue As Double = str
                    Dim rDivi As Double = divi
                    result = (Convert.ToDecimal(rValue) / Convert.ToDecimal(rDivi)) * 100
                    If result < 0 Then
                        Return Double.Parse(-result).ToString("#,##0.0")
                    Else
                        Return Double.Parse(result).ToString("#,##0.0")
                    End If
                Else
                    Return 0.ToString("#,##0.0")
                End If
            Else
                Return 0.ToString("#,##0.0")
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2PercenLFLGrowth(ByVal str As String) As String
        Try
            If str = "" Then Return ""
            If str = "NaN" Then Return ""
            If str = "N/A" Then Return "N/A"
            If str = "100.0%" Then Return "100.0%"

            Dim result As Decimal = 0
            Dim rValue As Double = str
            result = Convert.ToDecimal(rValue)

            Return Decimal.Parse(result).ToString("#,##0.0%")


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2PercenGrowthLoss(thisLoss As Double, lastLoss As Double) As String
        Try
            'Dim result As Decimal = 0
            Dim result As Double = 0
            If lastLoss < 0 Then
                result = (thisLoss - lastLoss) / (-lastLoss)
            Else
                result = (thisLoss - lastLoss) / lastLoss
            End If
            Return Decimal.Parse(result).ToString("#,##0.0%")

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function compareLFLGrowth(ByVal str As String, ByVal divi As String) As String
        Try
            If str <> "" And divi <> "" Then
                If str <> 0 And divi <> 0 Then
                    Dim result As Decimal = 0
                    'ex case "3.72529029846191E-09"
                    Dim rValue As Double = str
                    Dim rDivi As Double = divi
                    result = (Convert.ToDecimal(rValue) / Convert.ToDecimal(rDivi)) - 1
                    If result < 0 Then
                        Return Double.Parse(-result).ToString("#,##0.0")
                    Else
                        Return Double.Parse(result).ToString("#,##0.0")
                    End If
                Else
                    Return 0.ToString("#,##0.0")
                End If
            Else
                Return 0.ToString("#,##0.0")
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2NoneZero(ByVal str As String, ByVal divi As String) As String
        Try
            If str <> "" And divi <> "" Then
                If str <> 0 And divi <> 0 Then
                    str = Convert.ToDecimal(str) / Convert.ToDecimal(divi)
                    Return Double.Parse(str).ToString("#,##0")
                Else
                    Return Double.Parse("0").ToString("#,##0")
                End If
            Else
                Return Double.Parse("0").ToString("#,##0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2Currency2(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return ""
            Else
                Return Double.Parse(str).ToString("#,##0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2Currency3(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return ""
            Else
                'set currency rate

                If str.Substring(0, 1) = "(" And str.Substring(str.Length - 1, 1) = ")" Then
                    Return str
                End If
                Dim result As Double = Double.Parse(str)
                If result < 0 Then
                    Return (-result).ToString("(#,##0)")
                Else
                    Return result.ToString("#,##0")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2Currency9(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return Double.Parse("0").ToString("#,##0")
            Else
                Return Double.Parse(str).ToString("#,##0")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2Currency4(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return ""
            Else
                If str.Substring(0, 1) = "(" And str.Substring(str.Length - 1, 1) = ")" Then
                    Return str
                    'str = "-" + str.Replace("(", "").Replace(")", "")
                End If

                Dim result As Double = Double.Parse(str)
                If result < 0 Then
                    Return (-result).ToString("#,##0.0")
                Else
                    Return result.ToString("#,##0.0")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function convert2Percent(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return Double.Parse("0").ToString("#,##0.00")
            Else
                Return Double.Parse(str * 100).ToString("#,##0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2zero(ByVal str As String) As Double
        Try
            If str = "" Then
                Return 0
            Else
                Return Double.Parse(str)
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'Public Shared Function convert2Round2digit(ByVal str As String) As Double
    '    Try
    '        If str = "" Then
    '            Return 0
    '        Else
    '            Dim result As Double = Math.Round(Double.Parse(str), 2)
    '            Return result
    '        End If
    '    Catch ex As Exception
    '        Return 0
    '    End Try
    'End Function
#End Region


#Region "Controls"
    Public Shared Sub convertMinus(pn As Panel)
        For Each ctrl As Control In pn.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl As Label = DirectCast(ctrl, Label)
                If lbl.Text <> "" Then
                    If lbl.Text.Substring(0, 1) = "-" Then
                        lbl.Text = "(" + lbl.Text.Remove(0, 1) + ")"
                    End If
                End If
            End If
        Next
    End Sub
#End Region

#Region "manage"
    Public Shared Sub alert(ByVal page As Page, ByVal msg As String, Optional ByVal clientId As String = "", Optional ByVal url As String = "", Optional ByVal key As String = "")
        Dim script_alert As String = ""
        If url = "" And clientId = "" Then
            script_alert = "<script language='javascript'>alert('{0}');</script>"
        ElseIf Not url = "" And clientId = "" Then
            script_alert = "<script language='javascript'>alert('{0}'); window.location='" & url & "'</script>"
        ElseIf Not clientId = "" And url = "" Then
            script_alert = "<script language='javascript'>alert('{0}'); document.getElementById('" & clientId & "').focus();</script>"
        End If
        msg = msg.Replace("'", "\")
        msg = msg.Replace("\n", "\\n")
        msg = msg.Replace("|n", "\n")
        msg = msg.Replace("\r", "\\r")
        ScriptManager.RegisterStartupScript(page, page.GetType(), key, String.Format(script_alert, msg), False)
    End Sub
    Public Shared Sub Script(ByVal page As Page, ByVal script As String, Optional ByVal key As String = "")
        Dim strScript As String = "<script language='javascript'>" & script & "</script>"
        ScriptManager.RegisterStartupScript(page, page.GetType(), key, strScript, False)
    End Sub
#End Region
End Class
