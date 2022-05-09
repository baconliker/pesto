using System;
using System.Text;
using System.Diagnostics;

namespace ColinBaker.Pesto.Services.Pdf
{
    class PdfWriter
    {
        public PdfWriter()
        {
            this.ConfigFilePath = System.Windows.Forms.Application.StartupPath + @"\Services\Pdf\FopConfig.xml";
        }

        public static bool IsConfigured()
        {
            return true;

            //SettingsStore store = new SettingsStore();

            //return (!string.IsNullOrEmpty(store.FopPath));
        }

        public void Write(string inputFilePath, string styleSheetFilePath, string outputFilePath)
        {
            //WriteUsingCommandLineFop(inputFilePath, styleSheetFilePath, outputFilePath);
            WriteUsingIkvmFop(inputFilePath, styleSheetFilePath, outputFilePath);
            //WriteUsingIkvmFop2(inputFilePath, styleSheetFilePath, outputFilePath);
        }

        private void WriteUsingCommandLineFop(string inputFilePath, string styleSheetFilePath, string outputFilePath)
        {
            StringBuilder fopArguments = new StringBuilder();

            fopArguments.Append(" -xml \"");
            fopArguments.Append(inputFilePath);
            fopArguments.Append("\"");

            fopArguments.Append(" -xsl \"");
            fopArguments.Append(styleSheetFilePath);
            fopArguments.Append("\"");

            fopArguments.Append(" -c \"");
            fopArguments.Append(this.ConfigFilePath);
            fopArguments.Append("\"");

            fopArguments.Append(" -pdf \"");
            fopArguments.Append(outputFilePath);
            fopArguments.Append("\"");

            SettingsStore store = new SettingsStore();

            ProcessStartInfo startInfo = new ProcessStartInfo(store.FopPath);

            startInfo.Arguments = fopArguments.ToString();
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (Process process = Process.Start(startInfo))
            {
                string standardError = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception("Fop returned the following error: \n\n" + standardError);
                }
            }
        }

        private void WriteUsingIkvmFop(string inputFilePath, string styleSheetFilePath, string outputFilePath)
        {
            string foFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());

            // Transform input file into XSL-FO using .NET first
            // Attempting to do this using IKVM as part of FOP transform fails for some reason I don't have time to diagnose
            TransformXml(inputFilePath, styleSheetFilePath, foFilePath);

            try
            {
                org.apache.fop.apps.FopFactory fopFactory = org.apache.fop.apps.FopFactory.newInstance(new java.io.File(this.ConfigFilePath));
                
                java.io.OutputStream outputStream = new java.io.BufferedOutputStream(new java.io.FileOutputStream(new java.io.File(outputFilePath)));

                try
                {
                    org.apache.fop.apps.FOUserAgent userAgent = fopFactory.newFOUserAgent();
                    userAgent.setProducer(System.Windows.Forms.Application.ProductName);
                    userAgent.setCreationDate(new java.util.Date());
                    //userAgent.setTitle(title);
                    
                    org.apache.fop.apps.Fop fop = fopFactory.newFop(org.apache.fop.apps.MimeConstants.MIME_PDF, userAgent, outputStream);
                    
                    javax.xml.transform.TransformerFactory xslFactory = javax.xml.transform.TransformerFactory.newInstance();
                    javax.xml.transform.Transformer transformer = xslFactory.newTransformer();

                    javax.xml.transform.Source src = new javax.xml.transform.stream.StreamSource(new java.io.File(foFilePath));
                    javax.xml.transform.Result res = new javax.xml.transform.sax.SAXResult(fop.getDefaultHandler());
                    transformer.transform(src, res);
                }
                finally
                {
                    outputStream.close();
                }
            }
            finally
            {
                System.IO.File.Delete(foFilePath);
            }
        }

        private void WriteUsingIkvmFop2(string inputFilePath, string styleSheetFilePath, string outputFilePath)
        {
            string foFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());

            // Transform input file into XSL-FO using .NET first
            // Attempting to do this using IKVM as part of FOP transform fails for some reason I don't have time to diagnose
            TransformXml(inputFilePath, styleSheetFilePath, foFilePath);

            try
            {
                org.apache.fop.apps.FopFactory fopFactory;
                java.io.OutputStream outS;
                org.apache.fop.apps.Fop fop;
                javax.xml.transform.TransformerFactory factory;
                javax.xml.transform.Transformer transformer;
                javax.xml.transform.Source src;
                javax.xml.transform.Result res;

                fopFactory = org.apache.fop.apps.FopFactory.newInstance(new java.io.File(this.ConfigFilePath));

                outS = new java.io.BufferedOutputStream(new java.io.FileOutputStream(new java.io.File(outputFilePath)));

                try
                {
                    fop = fopFactory.newFop(org.apache.fop.apps.MimeConstants.MIME_PDF, outS);

                    factory = javax.xml.transform.TransformerFactory.newInstance();

                    transformer = factory.newTransformer();

                    src = new javax.xml.transform.stream.StreamSource(new java.io.File(foFilePath));

                    res = new javax.xml.transform.sax.SAXResult(fop.getDefaultHandler());

                    transformer.transform(src, res);
                }
                finally
                {
                    outS.close();
                }
            }
            finally
            {
                System.IO.File.Delete(foFilePath);
            }
        }

        private static void TransformXml(string inputFilePath, string styleSheetFilePath, string outputFilePath)
        {
            System.Xml.XPath.XPathDocument document = new System.Xml.XPath.XPathDocument(inputFilePath);

            System.Xml.Xsl.XslCompiledTransform transform = new System.Xml.Xsl.XslCompiledTransform();
            transform.Load(styleSheetFilePath);

            using (System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(outputFilePath, null))
            {
                transform.Transform(document, null, xmlWriter);
            }
        }

        public string ConfigFilePath { get; set; }
    }
}
