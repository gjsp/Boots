Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail
Imports System.Configuration.ConfigurationManager

Public Class clsLFL
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString

End Class
