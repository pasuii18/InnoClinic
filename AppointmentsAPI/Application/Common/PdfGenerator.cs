
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Application.Common;

public class PdfGenerator
{
    public static byte[] GeneratePdf<T>(T entity)
    {
        using (var stream = new MemoryStream())
        {
            var document = new Document(new PdfDocument(new PdfWriter(stream)));
            
            var properties = typeof(T).GetProperties()
                .Where(prop => prop.GetValue(entity) != null)
                .Select(prop => new
                {
                    Name = prop.Name,
                    Value = prop.GetValue(entity)
                });
        
            document.Add(new Paragraph($"Details").SetBold().SetFontSize(18));
            foreach (var property in properties)
            {
                document.Add(new Paragraph($"{property.Name}: {property.Value}"));
            }
        
            document.Close();
            return stream.ToArray();
        }
    }
}