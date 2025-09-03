using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
public class SalesReportDocument : IDocument
{

    private readonly List<SalesReportItem> _items;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public SalesReportDocument(List<SalesReportItem> items, DateTime startDate, DateTime endDate)
    {
        _items = items;
        _startDate = startDate;
        _endDate = endDate;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Legal);
            page.Margin(40);

            // HEADER
            page.Header().Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem(1).AlignLeft().Image("C:\\Users\\Jomark Domiquel\\Downloads\\JAN'M Images\\jan_m_logo200px.png", ImageScaling.FitArea); // put your store logo file
                    row.RelativeItem(3).AlignRight().Column(inner =>
                    {
                        inner.Item().Text("JAN'M Convenience Store").FontSize(16).Bold();
                        inner.Item().Text("P. Dagani St. City of Cabadbaran 8605 Agusan Del Norte");
                        inner.Item().Text("Contact No.: 09389102318");
                    });
                });

                col.Item().PaddingTop(10).AlignCenter()
                   .Text($"Sales Report from {_startDate:MM-dd-yyyy} to {_endDate:MM-dd-yyyy}")
                   .FontSize(14)
                   .Bold();

                col.Item().Height(30).AlignCenter()
                   .Text($"Generated on {DateTime.Now:MM-dd-yyyy HH:mm}");

            });

            // CONTENT (Table)
            page.Content().Column(col =>
            {
                // Group by DateSaved (ascending)
                var groupedByDate = _items
                    .GroupBy(i => i.DateSaved.Date)
                    .OrderBy(g => g.Key);

                foreach (var dateGroup in groupedByDate)
                {
                    // --- DATE HEADER ---
                    col.Item().PaddingVertical(10).Text($"Date: {dateGroup.Key:MM-dd-yyyy}")
                       .FontSize(13).Bold().FontColor(Colors.Blue.Medium);

                    // --- TABLE FOR THIS DATE ---
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2); // Cashier
                            columns.RelativeColumn(3); // Product
                            columns.RelativeColumn(1); // Qty
                            columns.RelativeColumn(1); // Unit
                            columns.RelativeColumn(1.5f); // Price
                            columns.RelativeColumn(1.5f); // Subtotal
                        });

                        // Header
                        table.Header(header =>
                        {
                            header.Cell().Border(1).Padding(5).Text("Cashier").Bold();
                            header.Cell().Border(1).Padding(5).Text("Product").Bold();
                            header.Cell().Border(1).Padding(5).Text("Qty").Bold();
                            header.Cell().Border(1).Padding(5).Text("Unit").Bold();
                            header.Cell().Border(1).Padding(5).Text("Price").Bold();
                            header.Cell().Border(1).Padding(5).Text("Subtotal").Bold();
                        });

                        // Rows
                        foreach (var item in dateGroup)
                        {
                            table.Cell().BorderBottom(0.5f).Padding(5).Text(item.CashierName);
                            table.Cell().BorderBottom(0.5f).Padding(5).Text(item.ProductName);
                            table.Cell().BorderBottom(0.5f).Padding(5).Text(item.Quantity.ToString());
                            table.Cell().BorderBottom(0.5f).Padding(5).Text(item.Unit);
                            table.Cell().BorderBottom(0.5f).Padding(5).Text($"₱{item.Price:N2}");
                            table.Cell().BorderBottom(0.5f).Padding(5).Text($"₱{item.SubTotal:N2}");
                        }
                    });

                    // --- SUBTOTAL FOR THIS DATE ---
                    col.Item().AlignRight().PaddingTop(5).Text(
                        $"Subtotal ({dateGroup.Key:MM-dd-yyyy}): ₱{dateGroup.Sum(i => i.SubTotal):N2}"
                    ).Bold();
                }

                // --- GRAND TOTAL (all dates combined) ---
                col.Item()
                   .PaddingTop(15)
                   .Border(1)
                   .Background(QuestPDF.Infrastructure.Color.FromRGB(178, 190, 195))
                   .Padding(10)
                   .Row(row =>
                   {
                       row.RelativeItem()
                          .AlignRight()
                          .Text("GRAND TOTAL SALES:")
                          .FontSize(14)
                          .Bold()
                          .FontColor(Colors.Black);

                       row.ConstantItem(150)
                          .AlignRight()
                          .Text($"₱{_items.Sum(i => i.SubTotal):N2}")
                          .FontSize(14)
                          .Bold()
                          .FontColor(Colors.Black);
                   });
            });


        });


    }
}
