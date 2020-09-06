# Excel和Word

## 使用iTextSharp类库操作Excel和Word

### 名称空间及描述

| Assembly Name           | Module/Namespace    | Description                                                  |
| ----------------------- | ------------------- | ------------------------------------------------------------ |
| NPOI.DLL                | OLE2/ActiveX        | OLE2/ActiveX document properties library                     |
| NPOI.DLL                | NPOI.DDF            | Microsoft Office Drawing read/write library                  |
| NPOI.DLL                | NPOI.HPSF           | OLE2/ActiveX document read/write library                     |
| NPOI.DLL                | NPOI.HSSF           | Microsoft Excel BIFF(Excel 97-2003, xls) format library      |
| NPOI.DLL                | NPOI.SS             | Excel common interface and Excel formula engine              |
| NPOI.DLL                | NPOI.Util           | base utility library, these classes can be used for other projects |
| NPOI.OOXML.DLL          | NPOI.XSSF           | Excel 2007(xlsx) format library                              |
| NPOI.OOXML.DLL          | NPOI.XWPF           | Word 2007(docx) format library                               |
| NPOI.OpenXml4Net.DLL    | NPOI.OpenXml4Net    | OpenXml zip package library                                  |
| NPOI.OpenXmlFormats.DLL | NPOI.OpenXmlFormats | Microsoft Office OpenXml object relationship library         |

### 详细文档及例子

.net <https://github.com/tonyqus/npoi/tree/master/examples>

.net core <https://github.com/dotnetcore/NPOI>

### 例子

1. ExportExcel

   ```C#
   var newFile = @"newbook.core.xlsx";

   using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write)) {

       IWorkbook workbook = new XSSFWorkbook();

       ISheet sheet1 = workbook.CreateSheet("Sheet1");

       sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
       var rowIndex = 0;
       IRow row = sheet1.CreateRow(rowIndex);
       row.Height = 30 * 80;
       row.CreateCell(0).SetCellValue("this is content");
       sheet1.AutoSizeColumn(0);
       rowIndex++;

       var sheet2 = workbook.CreateSheet("Sheet2");
       var style1 = workbook.CreateCellStyle();
       style1.FillForegroundColor = HSSFColor.Blue.Index2;
       style1.FillPattern = FillPattern.SolidForeground;

       var style2 = workbook.CreateCellStyle();
       style2.FillForegroundColor = HSSFColor.Yellow.Index2;
       style2.FillPattern = FillPattern.SolidForeground;

       var cell2 = sheet2.CreateRow(0).CreateCell(0);
       cell2.CellStyle = style1;
       cell2.SetCellValue(0);

       cell2 = sheet2.CreateRow(1).CreateCell(0);
       cell2.CellStyle = style2;
       cell2.SetCellValue(1);

       workbook.Write(fs);
   }
   ```

2. ExportWord

   ```C#
   var newFile2 = @"newbook.core.docx";
   using (var fs = new FileStream(newFile2, FileMode.Create, FileAccess.Write)) {
       XWPFDocument doc = new XWPFDocument();
       var p0 = doc.CreateParagraph();
       p0.Alignment = ParagraphAlignment.CENTER;
       XWPFRun r0 = p0.CreateRun();
       r0.FontFamily = "microsoft yahei";
       r0.FontSize = 18;
       r0.IsBold = true;
       r0.SetText("This is title");

       var p1 = doc.CreateParagraph();
       p1.Alignment = ParagraphAlignment.LEFT;
       p1.IndentationFirstLine = 500;
       XWPFRun r1 = p1.CreateRun();
       r1.FontFamily = "·ÂËÎ";
       r1.FontSize = 12;
       r1.IsBold = true;
       r1.SetText("This is content, content content content content content content content content content");

       doc.Write(fs);
   }
   ```
