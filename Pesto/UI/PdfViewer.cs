using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
    public partial class PdfViewer : UserControl
    {
        PdfiumViewer.PdfDocument m_pdfDocument;
        PdfiumViewer.PdfRenderer m_pdfRenderer;
        
        public PdfViewer()
        {
            InitializeComponent();

            m_pdfRenderer = new PdfiumViewer.PdfRenderer();
            m_pdfRenderer.BackColor = Color.FromKnownColor(KnownColor.Window);
            m_pdfRenderer.Name = "pdfRenderer";
            m_pdfRenderer.Dock = DockStyle.Fill;
            m_pdfRenderer.TabIndex = 0;
            m_pdfRenderer.TabStop = false;
            m_pdfRenderer.Visible = false;
            m_pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            this.Controls.Add(m_pdfRenderer);
        }

        public void Clear()
        {
            m_pdfDocument = null;
            m_pdfRenderer.Visible = false;

            unableToDisplayLabel.Visible = false;
        }

        public void LoadPdf(string path)
        {
            Clear();

            try
            {
                m_pdfDocument = PdfiumViewer.PdfDocument.Load(path);
                m_pdfRenderer.Load(m_pdfDocument);

                m_pdfRenderer.Visible = true;
            }
            catch
            {
                unableToDisplayLabel.Visible = true;
            }
        }

        public void Print()
        {
            if (pdfPrintDialog.ShowDialog() == DialogResult.OK)
            {
                Services.Pdf.PdfPrinter printer = new Services.Pdf.PdfPrinter();
                printer.Print(m_pdfDocument, pdfPrintDialog.PrinterSettings);
            }
        }
    }
}
