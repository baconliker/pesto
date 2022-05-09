using NUnit.Framework;
using ColinBaker.Pesto.Services;
using ColinBaker.Pesto.Services.Pdf;

namespace ColinBaker.Pesto.Tests.Services.Pdf
{
    [TestFixture]
    class PdfWriterTests
    {
        [Test]
        public void Create()
        {
            Assert.IsNotNull(new PdfWriter());
        }

        [Test]
        public void WritePdf()
        {
            string pdfFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());

            PdfWriter writer = new PdfWriter();
            writer.ConfigFilePath = System.AppDomain.CurrentDomain.BaseDirectory + @"Services\Pdf\FopConfig.xml";

            // Preload factories - this is necessary for some reason because we're running a class library, not required for Windows Forms
            com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl s = new com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl();
            com.sun.org.apache.xalan.@internal.xsltc.trax.TransformerFactoryImpl t = new com.sun.org.apache.xalan.@internal.xsltc.trax.TransformerFactoryImpl();

            writer.Write(System.AppDomain.CurrentDomain.BaseDirectory + @"Services\Pdf\Input.xml", System.AppDomain.CurrentDomain.BaseDirectory + @"Services\Pdf\Stylesheet.xsl", pdfFilePath);

            if (System.IO.File.Exists(pdfFilePath))
            {
                System.IO.File.Delete(pdfFilePath);
            }
            else
            {
                Assert.Fail("PDF not created");
            }
        }
    }
}
