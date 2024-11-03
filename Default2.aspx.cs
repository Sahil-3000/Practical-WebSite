using System;
using System.IO;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This can be used to initialize any data if needed
    }
    protected void btnGeneratePDF_Click(object sender, EventArgs e)
    {
        // Validate input fields
        if (string.IsNullOrWhiteSpace(txtUniversity.Text) ||
            string.IsNullOrWhiteSpace(txtDepartment.Text) ||
            string.IsNullOrWhiteSpace(txtSubject.Text) ||
            string.IsNullOrWhiteSpace(txtSubmittedTo.Text) ||
            string.IsNullOrWhiteSpace(txtSubmittedBy.Text))
        {
            Response.Write("<script>alert('Please fill in all fields.');</script>");
            return; // Exit the method
        }

        // Create a timestamp for the PDF file name
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        string titlePagePath = Server.MapPath($"~/GeneratedPDFs/TitlePage_{timestamp}.pdf");
        string programsPdfPath = Server.MapPath("~/OOPs Practical File.pdf"); // Change this path to your existing PDF location
        string outputPath = Server.MapPath($"~/GeneratedPDFs/FinalPDF_{timestamp}.pdf");

        // Ensure the directory exists
        string dirPath = Server.MapPath("~/GeneratedPDFs/");
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        // Create the title page PDF
        using (PdfWriter writer = new PdfWriter(titlePagePath))
        {
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);
                // Optional: Add spacing
                document.Add(new Paragraph("\n\n\n\n")); // Extra spacing before the next section
                // Add an image at the top of the title page
                string imagePath = Server.MapPath("~/mdu logo.jpg"); // Update with your image path
                Image img = new Image(ImageDataFactory.Create(imagePath))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetWidth(200) // Set the width as needed
                    .SetMarginLeft(150)
                    .SetMarginBottom(10); // Add space below the image

                document.Add(img);

                // Title Page Formatting
                document.Add(new Paragraph(txtUniversity.Text)
                    .SetFontSize(24)
                    .SetBold()
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetMarginBottom(10));

                // Optional: Add a horizontal line
                document.Add(new LineSeparator(new SolidLine()));

                document.Add(new Paragraph(txtDepartment.Text)
                    .SetFontSize(22)
                    .SetBold()
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetMarginBottom(5));

                document.Add(new Paragraph("Practical of " + txtSubject.Text)
                    .SetFontSize(20)
                    .SetBold()
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetMarginBottom(5));

                // Create a table for layout
                Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
                // Set the table border to invisible
                table.SetBorder(Border.NO_BORDER);

                // Submitted To / Submitted By row
                Cell submittedToCell = new Cell()
                    .Add(new Paragraph("Submitted To:").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold())
                    .SetBorder(Border.NO_BORDER); // No border for this cell
                table.AddCell(submittedToCell);

                Cell submittedByCell = new Cell()
                    .Add(new Paragraph("Submitted By:").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold())
                    .SetBorder(Border.NO_BORDER); // No border for this cell
                table.AddCell(submittedByCell);

                // Add the actual names with formatting
                Cell profNameCell = new Cell()
                    .Add(new Paragraph("Prof." +txtSubmittedTo.Text).SetBold().SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold())
                    .SetBorder(Border.NO_BORDER); // No border for this cell
                table.AddCell(profNameCell);

                Cell studentNameCell = new Cell()
                    .Add(new Paragraph(txtSubmittedBy.Text).SetBold().SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold())
                    .SetBorder(Border.NO_BORDER); // No border for this cell
                table.AddCell(studentNameCell);
                Cell newCell = new Cell().SetBorder(Border.NO_BORDER);
                table.AddCell(newCell);
                Cell rollNoCell = new Cell()
                    .Add(new Paragraph("Roll No: "+txtRollNo.Text).SetFontSize(14).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold())
                    .SetBorder(Border.NO_BORDER); // No border for this cell
                table.AddCell(rollNoCell);

                // Add the table to the document
                document.Add(table);

               
                // Optional: Add spacing
                document.Add(new Paragraph("\n")); // Extra spacing before the next section
                document.Add(new Paragraph("5-Year Integrated M.Sc.(Hons.) Mathematics (7th Sem)")
                    .SetFontSize(20)
                    .SetBold()
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetMarginBottom(5));
                // Optional: Add a horizontal line
                document.Add(new LineSeparator(new SolidLine()));

                // Close the document
                document.Close();
            }
        }
    


        // Merge the title page with the existing programs PDF
        using (PdfWriter writer = new PdfWriter(outputPath))
        {
            using (PdfDocument mergedPdf = new PdfDocument(writer))
            {
                // Add the title page
                using (PdfDocument titlePdf = new PdfDocument(new PdfReader(titlePagePath)))
                {
                    titlePdf.CopyPagesTo(1, titlePdf.GetNumberOfPages(), mergedPdf);
                }

                // Add the existing programs PDF
                using (PdfDocument programsPdf = new PdfDocument(new PdfReader(programsPdfPath)))
                {
                    programsPdf.CopyPagesTo(1, programsPdf.GetNumberOfPages(), mergedPdf);
                }
            }
        }

        // Check if the combined PDF file was created successfully
        FileInfo fileInfo = new FileInfo(outputPath);
        if (fileInfo.Length == 0)
        {
            Response.Write("<script>alert('Combined PDF was generated but contains no data.');</script>");
            return;
        }

        // Set the response to send the combined PDF to the client
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", $"attachment; filename = {txtSubmittedBy.Text}_OOPs with C++ Practical .pdf");
        Response.TransmitFile(outputPath);
        Response.End();
    }

}
