using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Text;

public class ReceiptPrinter58mm
{
    private int transactionId;
    private string customerName;
    private string cashierName;
    private decimal totalAmount;
    private decimal cash;
    private decimal change;
    private List<(string productName, decimal qty, decimal price)> items;

    private Image storeLogo;

    // ✅ Store info
    private string storeName = "JAN'M Convenience Store";
    private string storeAddress = "P. Dagani St. City of Cabadbaran 8605 Agusan Del Norte";
    private string storePhone = "Contact No.: 09389102318";

    public ReceiptPrinter58mm(int transactionId, string customerName, string cashierName,
                              decimal totalAmount, decimal cash, decimal change,
                              List<(string productName, decimal qty, decimal price)> items)
    {
        this.transactionId = transactionId;
        this.customerName = customerName;
        this.cashierName = cashierName;
        this.totalAmount = totalAmount;
        this.cash = cash;
        this.change = change;
        this.items = items;

        // ✅ Load store logo (optional, scale down to fit)
        try
        {
            Image logo = Image.FromFile("C:\\Users\\Jomark Domiquel\\Downloads\\JAN'M Images\\jan'm_logo.jpg");
            storeLogo = new Bitmap(logo, new Size(200, 200)); // resize for 58mm
        }
        catch { storeLogo = null; }
    }

    public void Print()
    {
        PrintDocument printDoc = new PrintDocument();

        // ✅ Set paper size to 58mm width (220px)
        printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 220, 1000);
        // ✅ Remove margins
        printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0); // Left, Right, Top, Bottom

        printDoc.PrintPage += new PrintPageEventHandler(PrintReceiptPage);

        printDoc.Print();
    }

    // ✅ Helper: wrap long text for 58mm
    private string WrapText(string text, int lineWidth = 32)
    {
        if (text.Length <= lineWidth) return text;
        var sb = new StringBuilder();
        for (int i = 0; i < text.Length; i += lineWidth)
        {
            sb.AppendLine(text.Substring(i, Math.Min(lineWidth, text.Length - i)));
        }
        return sb.ToString();
    }

    // ✅ Helper: format item line properly
    private string FormatLine(string item, string qty, string price, string sub)
    {
        string itemStr = item.Length > 12 ? item.Substring(0, 12) : item;
        return itemStr.PadRight(13) + // Item name (12 chars + 1 space)
               qty.PadLeft(4) + "  " +  // Qty (3 digits + 2 spaces)
               price.PadLeft(6) + "  " + // Price (6 digits + 2 spaces)
               sub.PadLeft(6);          // Subtotal (6 digits)
    }

    private void PrintReceiptPage(object sender, PrintPageEventArgs e)
    {
        Graphics g = e.Graphics;
        float y = 0;
        int pageWidth = e.PageBounds.Width;

        // ✅ Smaller fonts for 58mm
        Font smallFont = new Font("Consolas", 6);
        Font normalFont = new Font("Arial", 7);
        Font boldFont = new Font("Arial", 7, FontStyle.Bold);

        // ✅ Draw store logo (scaled)
        if (storeLogo != null)
        {
            g.DrawImage(storeLogo, new Rectangle(60, (int)y, 100, 100)); // center in 58mm
            y += 100;
        }

        // ✅ Store Name
        g.DrawString(storeName, boldFont, Brushes.Black, new RectangleF(0, y, pageWidth, 12),
                     new StringFormat() { Alignment = StringAlignment.Center });
        y += 14;

        // ✅ Store Address & Phone
        g.DrawString(WrapText(storeAddress, 32), smallFont, Brushes.Black, new RectangleF(0, y, pageWidth, 25),
                     new StringFormat() { Alignment = StringAlignment.Center });
        y += 22;

        g.DrawString(storePhone, smallFont, Brushes.Black, new RectangleF(0, y, pageWidth, 15),
                     new StringFormat() { Alignment = StringAlignment.Center });
        y += 18;

        // ✅ Transaction info
        g.DrawString($"Trans#: {transactionId}", normalFont, Brushes.Black, 0, y); y += 12;
        g.DrawString($"Customer: {customerName}", normalFont, Brushes.Black, 0, y); y += 12;
        g.DrawString($"Cashier: {cashierName}", normalFont, Brushes.Black, 0, y); y += 12;
        g.DrawString($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}", normalFont, Brushes.Black, 0, y); y += 20;

        // Items header
        g.DrawString("Item                  Qty  Price      Sub", normalFont, Brushes.Black, 0, y); y += 12;
        g.DrawLine(Pens.Black, 0, (int)y, pageWidth, (int)y); y += 8;

        // Items
        foreach (var item in items)
        {
            decimal subtotal = item.qty * item.price;
            string line = FormatLine(
                item.productName,
                item.qty.ToString("0"),
                item.price.ToString("0.00"),
                subtotal.ToString("0.00")
            );
            g.DrawString(line, smallFont, Brushes.Black, 0, y);
            y += 12;
        }

        y += 5;
        g.DrawString("--------------------------------", smallFont, Brushes.Black, 0, y); y += 12;

        g.DrawString($"TOTAL:   ₱{totalAmount,10:N2}", boldFont, Brushes.Black, 0, y); y += 12;
        g.DrawString($"CASH:    ₱{cash,10:N2}", normalFont, Brushes.Black, 0, y); y += 12;
        g.DrawString($"CHANGE:  ₱{change,10:N2}", normalFont, Brushes.Black, 0, y); y += 50;

        // Footer
        g.DrawString("Thank you for shopping!", normalFont, Brushes.Black, new RectangleF(0, y, pageWidth, 20),
                     new StringFormat() { Alignment = StringAlignment.Center });y += 12;

        g.DrawString("Developed By: Jomark Domiquel", normalFont, Brushes.Black, new RectangleF(0, y, pageWidth, 20),
                     new StringFormat() { Alignment = StringAlignment.Center }); y += 12;
        g.DrawString("Contact No: 09454505623", normalFont, Brushes.Black, new RectangleF(0, y, pageWidth, 20),
                     new StringFormat() { Alignment = StringAlignment.Center }); y += 12;

        g.DrawString("--------------------------------", smallFont, Brushes.Black, 0, y); 
    }
}
