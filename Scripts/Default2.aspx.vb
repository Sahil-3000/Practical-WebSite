'<% @Page Language="VB" AutoEventWireup="true" CodeFile="Default2.aspx.vb" Inherits="_Default2" %>

'Imports System.IO
'Imports iText.Kernel.Pdf
'Imports iText.Layout
'Imports iText.Layout.Element

'Partial Class _Default
'    Inherits System.Web.UI.Page

'    Protected Sub btnGeneratePDF_Click(sender As Object, e As EventArgs)
'        Dim outputPath As String = Server.MapPath("~/PracticalFile.pdf")

'        Using writer As New PdfWriter(outputPath)
'            Using pdf As New PdfDocument(writer)
'                Dim document As New Document(pdf)
'                document.Add(New Paragraph("University Name: " & txtUniversity.Text))
'                document.Add(New Paragraph("Department: " & txtDepartment.Text))
'                document.Add(New Paragraph("Subject: " & txtSubject.Text))
'                document.Add(New Paragraph("Submitted To: " & txtSubmittedTo.Text))
'                document.Add(New Paragraph("Submitted By: " & txtSubmittedBy.Text))
'            End Using
'        End Using

'        Response.ContentType = "application/pdf"
'        Response.AppendHeader("Content-Disposition", "attachment; filename=PracticalFile.pdf")
'        Response.TransmitFile(outputPath)
'        Response.End()
'    End Sub
'End Class

''<!DOCTYPE html>

''<html xmlns="http://www.w3.org/1999/xhtml">
''<head runat="server">
''    <title></title>
''</head>
''<body>
''    <form id="form1" runat="server">
''        <div>
''        </div>
''    </form>
''</body>
''</html>
