# PDF操作

## 使用iTextSharp类库操作PDF

详细文档与例子 <https://kb.itextpdf.com/home/it7kb/examples>

### 例子

1. 创建一个简单表格

   ```C#
   using System;
   using System.IO;
   using iText.Kernel.Pdf;
   using iText.Layout;
   using iText.Layout.Element;
   using iText.Layout.Properties;

   namespace iText.Samples.Sandbox.Tables
   {
       public class SimpleTable
       {
           public static readonly string DEST = "results/sandbox/tables/simple_table.pdf";

           public static void Main(String[] args)
           {
               FileInfo file = new FileInfo(DEST);
               file.Directory.Create();

               new SimpleTable().ManipulatePdf(DEST);
           }

           private void ManipulatePdf(String dest)
           {
               PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
               Document doc = new Document(pdfDoc);

               Table table = new Table(UnitValue.CreatePercentArray(8)).UseAllAvailableWidth();

               for (int i = 0; i < 16; i++)
               {
                   table.AddCell("hi");
               }

               doc.Add(table);

               doc.Close();
           }
       }
   }
   ```
