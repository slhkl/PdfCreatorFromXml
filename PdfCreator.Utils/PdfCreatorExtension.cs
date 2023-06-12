namespace PdfCreator.Utils
{
    public static class PdfCreatorExtension
    {
        public static void CreatePdfFromIronPdf(this string xml)
        {
            var renderer = new ChromePdfRenderer();
            using var cover = renderer.RenderHtmlAsPdf("<h1>first Page</h1>");
            renderer.RenderingOptions.FirstPageNumber = 2;
            renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter
            {
                MaxHeight = 15,
                HtmlFragment = "<center><i>{page} of {total-pages}<i></center>",
                DrawDividerLine = true
            };

            using PdfDocument pdf = renderer.RenderHtmlAsPdf(xml);
            using PdfDocument merge = PdfDocument.Merge(cover, pdf);
            merge.SecuritySettings.AllowUserCopyPasteContent = false;
            merge.SaveAs("CreatedFromIronPdf.pdf");
        }
    }
}
