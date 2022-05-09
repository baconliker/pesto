using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI
{
    class TemplateFileListItem
    {

        public TemplateFileListItem(string filePath)
        {
            this.FilePath = filePath;
        }

        public override string ToString()
        {
            System.IO.FileInfo file = new System.IO.FileInfo(this.FilePath);

            return file.Name;
        }

        public string FilePath { get; set; }
    }
}
