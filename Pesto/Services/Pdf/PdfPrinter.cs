using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using PdfiumViewer;

namespace ColinBaker.Pesto.Services.Pdf
{
    class PdfPrinter
    {
        public void Print(PdfDocument pdf, PrinterSettings settings)
        {
            PrintDocument pd = pdf.CreatePrintDocument();
            pd.PrinterSettings = settings;
            
            pd.Print();
        }
    }
}
