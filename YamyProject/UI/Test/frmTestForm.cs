using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Test
{
    public partial class frmTestForm : Form
    {
        private PrintDocument printDoc;
        public frmTestForm()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            printDoc = new PrintDocument();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                printDoc.Print();
                MessageBox.Show("Receipt printed.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to print: " + ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaperSize paperSize = new PaperSize("Custom Receipt", 322, 1169);
            printDoc.DefaultPageSettings.PaperSize = paperSize;
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = printDoc;
            previewDlg.Width = 400;  // Match 72mm layout
            previewDlg.Height = 600;
            previewDlg.ShowDialog();
        }

        private void frmTestForm_Load(object sender, EventArgs e)
        {
            printDoc.PrintPage += PrintDoc_PrintPage;
        }
        // Example PrintPage event snippet:

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Use printable area inside margins
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float pageWidth = e.MarginBounds.Width;
            float yPos = topMargin + 10f;

            string logoPath = @"D:\logo.png";
            try
            {
                using (Image logo = Image.FromFile(logoPath))
                {
                    float logoWidth = pageWidth * 0.5f;
                    float logoHeight = logo.Height * (logoWidth / logo.Width);
                    float logoX = leftMargin + (pageWidth - logoWidth) / 2;
                    g.DrawImage(logo, logoX, yPos, logoWidth, logoHeight);
                    yPos += logoHeight + 10f;
                }
            }
            catch
            {
                // Logo missing
            }

            // Company name
            string companyName = "My Restaurant";
            Font companyFont = new Font("Arial", 18, FontStyle.Bold);
            SizeF companySize = g.MeasureString(companyName, companyFont);
            float companyX = leftMargin + (pageWidth - companySize.Width) / 2;
            g.DrawString(companyName, companyFont, Brushes.Black, companyX, yPos);
            yPos += companySize.Height + 5;

            // Address & Phone
            string address = "123 Main St, City, Country";
            string phone = "Phone: (123) 456-7890";
            Font infoFont = new Font("Arial", 10);
            SizeF addressSize = g.MeasureString(address, infoFont);
            float addressX = leftMargin + (pageWidth - addressSize.Width) / 2;
            g.DrawString(address, infoFont, Brushes.Black, addressX, yPos);
            yPos += addressSize.Height;

            SizeF phoneSize = g.MeasureString(phone, infoFont);
            float phoneX = leftMargin + (pageWidth - phoneSize.Width) / 2;
            g.DrawString(phone, infoFont, Brushes.Black, phoneX, yPos);
            yPos += phoneSize.Height + 10;

            // Columns
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font itemFont = new Font("Arial", 9);

            float colDescWidth = pageWidth * 0.5f;
            float colQtyWidth = pageWidth * 0.15f;
            float colPriceWidth = pageWidth * 0.15f;
            float colTotalWidth = pageWidth * 0.2f;

            float colDescX = leftMargin;
            float colQtyX = colDescX + colDescWidth;
            float colPriceX = colQtyX + colQtyWidth;
            float colTotalX = colPriceX + colPriceWidth;

            // Table headers
            g.DrawString("Description", headerFont, Brushes.Black, colDescX, yPos);
            SizeF qtySize = g.MeasureString("Qty", headerFont);
            g.DrawString("Qty", headerFont, Brushes.Black, colQtyX + (colQtyWidth - qtySize.Width) / 2, yPos);
            SizeF priceSize = g.MeasureString("Price", headerFont);
            g.DrawString("Price", headerFont, Brushes.Black, colPriceX + (colPriceWidth - priceSize.Width) / 2, yPos);
            SizeF totalSize = g.MeasureString("Total", headerFont);
            g.DrawString("Total", headerFont, Brushes.Black, colTotalX + (colTotalWidth - totalSize.Width) / 2, yPos);

            yPos += headerFont.GetHeight(g) + 5;
            g.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + pageWidth, yPos);
            yPos += 5;

            // Sample items
            var items = new[]
            {
                new { Description = "Burger", Qty = "2", Price = "$5.00", Total = "$10.00" },
                new { Description = "Coke", Qty = "1", Price = "$2.00", Total = "$2.00" },
                new { Description = "Fries", Qty = "1", Price = "$3.00", Total = "$3.00" },
            };

            foreach (var item in items)
            {
                g.DrawString(item.Description, itemFont, Brushes.Black, colDescX, yPos);
                SizeF qtyTextSize = g.MeasureString(item.Qty, itemFont);
                g.DrawString(item.Qty, itemFont, Brushes.Black, colQtyX + (colQtyWidth - qtyTextSize.Width) / 2, yPos);
                SizeF priceTextSize = g.MeasureString(item.Price, itemFont);
                g.DrawString(item.Price, itemFont, Brushes.Black, colPriceX + (colPriceWidth - priceTextSize.Width) / 2, yPos);
                SizeF totalTextSize = g.MeasureString(item.Total, itemFont);
                g.DrawString(item.Total, itemFont, Brushes.Black, colTotalX + (colTotalWidth - totalTextSize.Width) / 2, yPos);
                yPos += itemFont.GetHeight(g);
            }

            yPos += 5;
            g.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + pageWidth, yPos);
            yPos += 5;

            // Footer total
            string totalAmount = "TOTAL: $15.00";
            Font totalFont = new Font("Arial", 14, FontStyle.Bold);
            SizeF totalAmountSize = g.MeasureString(totalAmount, totalFont);
            g.DrawString(totalAmount, totalFont, Brushes.Black, leftMargin + pageWidth - totalAmountSize.Width, yPos);
            yPos += totalFont.GetHeight(g) + 10;

            // Thank you message
            string thankYou = "Thank you for your visit!";
            Font thankFont = new Font("Arial", 12, FontStyle.Italic);
            SizeF thankSize = g.MeasureString(thankYou, thankFont);
            float thankX = leftMargin + (pageWidth - thankSize.Width) / 2;
            g.DrawString(thankYou, thankFont, Brushes.Black, thankX, yPos);
        }
    }
}

class PrinterHelper
{
    public static void PrintReceipt()
    {
        PrintDocument printDoc = new PrintDocument();

        // Use the default printer (set your thermal printer as default)
        printDoc.PrinterSettings.PrinterName = new PrinterSettings().PrinterName;

        printDoc.PrintPage += (sender, e) =>
        {
            string receiptText =
                @"My Restaurant
                ------------------------
                Burger         x2     $10.00
                Coke           x1      $2.00
                Fries          x1      $3.00
                ------------------------
                TOTAL                $15.00
                Thank you!

                ";

            // Print with font and position
            Font font = new Font("Arial", 10);
            e.Graphics.DrawString(receiptText, font, Brushes.Black, new PointF(10, 10));
        };

        try
        {
            printDoc.Print();
            Console.WriteLine("Printed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Print failed: " + ex.Message);
        }
    }
}
