using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Services
{
    class ResultsPublisher
    {
        public ResultsPublisher(string competitionFilePath)
        {
            this.CompetitionFilePath = competitionFilePath;
        }

        public void PublishTaskResults(Models.Results.TaskResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            Pdf.PdfWriter writer = new Pdf.PdfWriter();
            writer.Write(pathBuilder.GetTaskResultsFilePath(results), System.Windows.Forms.Application.StartupPath + @"\Resources\Xsl\Results-Task.xsl", pathBuilder.GetNextPublishedTaskResultsFilePath(results));
        }

        public string GetPublishedTaskResultsFilePath(Models.Results.TaskResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            return pathBuilder.GetPublishedTaskResultsFilePath(results);
        }

        public void PublishOverallResults(Models.Results.OverallResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            Pdf.PdfWriter writer = new Pdf.PdfWriter();
            writer.Write(pathBuilder.GetOverallResultsFilePath(results), System.Windows.Forms.Application.StartupPath + @"\Resources\Xsl\Results-Overall.xsl", pathBuilder.GetNextPublishedOverallResultsFilePath(results));
        }

        public string GetPublishedOverallResultsFilePath(Models.Results.OverallResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            return pathBuilder.GetPublishedOverallResultsFilePath(results);
        }

        public void PublishTeamResults(Models.Results.TeamResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            Pdf.PdfWriter writer = new Pdf.PdfWriter();
            writer.Write(pathBuilder.GetTeamResultsFilePath(results), System.Windows.Forms.Application.StartupPath + @"\Resources\Xsl\Results-Team.xsl", pathBuilder.GetNextPublishedTeamResultsFilePath(results));
        }

        public string GetPublishedTeamResultsFilePath(Models.Results.TeamResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            return pathBuilder.GetPublishedTeamResultsFilePath(results);
        }

        public void PublishNationResults()
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            Pdf.PdfWriter writer = new Pdf.PdfWriter();
            writer.Write(pathBuilder.GetNationResultsFilePath(), System.Windows.Forms.Application.StartupPath + @"\Resources\Xsl\Results-Nation.xsl", pathBuilder.GetNextPublishedNationResultsFilePath());
        }

        public string GetPublishedNationResultsFilePath()
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.CompetitionFilePath);

            return pathBuilder.GetPublishedNationResultsFilePath();
        }

        public string CompetitionFilePath { get; set; }
    }
}
