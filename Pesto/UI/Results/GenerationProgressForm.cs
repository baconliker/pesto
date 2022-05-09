using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ColinBaker.Pesto.UI.Results
{
    partial class GenerationProgressForm : Form
    {
        private delegate void FinishGeneratingResultsHandler(Models.Results.ResultsGenerationException generationException);

        public GenerationProgressForm(Models.Results.Results results, Models.Results.ResultsGenerationOptions options)
        {
            InitializeComponent();

            this.Results = results;
			this.Options = options;

            Thread thread = new Thread(new ThreadStart(StartGeneratingResults));
            thread.Start();
        }

        public Models.Results.Results Results { get; private set; }
		public Models.Results.ResultsGenerationOptions Options { get; private set; }

        private void StartGeneratingResults()
        {
            Models.Results.ResultsGenerationException generationException = null;

            try
            {
				// Load previous results if there are some. This allows us to do stuff like comparing the columns used last time
                if (!this.Results.Loaded && this.Results.Exists())
                {
                    this.Results.Load();
                }

                this.Results.Generate(this.Options);
            }
            catch (Models.Results.ResultsGenerationException ex)
            {
                generationException = ex;
            }

            FinishGeneratingResults(generationException);
        }

        private void FinishGeneratingResults(Models.Results.ResultsGenerationException generationException)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new FinishGeneratingResultsHandler(FinishGeneratingResults), new object[] {generationException});
            }
            else
            {
                if (generationException == null)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(generationException.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                this.Close();
            }
        }
    }
}
