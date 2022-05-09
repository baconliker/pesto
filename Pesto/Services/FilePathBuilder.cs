using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Services
{
    class FilePathBuilder
    {
        public FilePathBuilder(string competitionFilePath)
        {
            this.CompetitionFilePath = competitionFilePath;
        }

        public string GetRemindersFilePath()
        {
            System.IO.FileInfo competitionFile = new System.IO.FileInfo(this.CompetitionFilePath);

            return string.Format(@"{0}\Reminders.xml", competitionFile.DirectoryName);
        }

        public string GetTaskResultsFilePath(Models.Results.TaskResults results)
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedTaskResultsFilePath(results, version, "xml", true)))
            {
                version++;
            }

            if (version > 1)
            {
                return BuildProposedTaskResultsFilePath(results, version - 1, "xml", true);
            }
            else
            {
                // For backward compatibility

                while (System.IO.File.Exists(BuildProposedTaskResultsFilePath(results, version, "xml", false)))
                {
                    version++;
                }

                if (version > 1)
                {
                    return BuildProposedTaskResultsFilePath(results, version - 1, "xml", false);
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetNextTaskResultsFilePath(Models.Results.TaskResults results)
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedTaskResultsFilePath(results, version, "xml", true)))
            {
                version++;
            }

            return BuildProposedTaskResultsFilePath(results, version, "xml", true);
        }

        public string GetPublishedTaskResultsFilePath(Models.Results.TaskResults results)
        {
            return System.IO.Path.ChangeExtension(GetTaskResultsFilePath(results), "pdf");
        }

        public string GetNextPublishedTaskResultsFilePath(Models.Results.TaskResults results)
        {
            return System.IO.Path.ChangeExtension(GetTaskResultsFilePath(results), "pdf");
        }

        public string GetOverallResultsFilePath(Models.Results.OverallResults results)
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedOverallResultsFilePath(results, version, "xml", true)))
            {
                version++;
            }

            if (version > 1)
            {
                return BuildProposedOverallResultsFilePath(results, version - 1, "xml", true);
            }
            else
            {
                // For backward compatibility

                while (System.IO.File.Exists(BuildProposedOverallResultsFilePath(results, version, "xml", false)))
                {
                    version++;
                }

                if (version > 1)
                {
                    return BuildProposedOverallResultsFilePath(results, version - 1, "xml", false);
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetNextOverallResultsFilePath(Models.Results.OverallResults results)
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedOverallResultsFilePath(results, version, "xml", true)))
            {
                version++;
            }

            return BuildProposedOverallResultsFilePath(results, version, "xml", true);
        }

        public string GetPublishedOverallResultsFilePath(Models.Results.OverallResults results)
        {
            return System.IO.Path.ChangeExtension(GetOverallResultsFilePath(results), "pdf");
        }

        public string GetNextPublishedOverallResultsFilePath(Models.Results.OverallResults results)
        {
            return System.IO.Path.ChangeExtension(GetOverallResultsFilePath(results), "pdf");
        }

        public string GetTeamResultsFilePath(Models.Results.TeamResults results)
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedTeamResultsFilePath(results, version, "xml", true)))
            {
                version++;
            }

            if (version > 1)
            {
                return BuildProposedTeamResultsFilePath(results, version - 1, "xml", true);
            }
            else
            {
                // For backward compatibility

                while (System.IO.File.Exists(BuildProposedTeamResultsFilePath(results, version, "xml", false)))
                {
                    version++;
                }

                if (version > 1)
                {
                    return BuildProposedTeamResultsFilePath(results, version - 1, "xml", false);
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetNextTeamResultsFilePath(Models.Results.TeamResults results)
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedTeamResultsFilePath(results, version, "xml", true)))
            {
                version++;
            }

            return BuildProposedTeamResultsFilePath(results, version, "xml", true);
        }

        public string GetPublishedTeamResultsFilePath(Models.Results.TeamResults results)
        {
            return System.IO.Path.ChangeExtension(GetTeamResultsFilePath(results), "pdf");
        }

        public string GetNextPublishedTeamResultsFilePath(Models.Results.TeamResults results)
        {
            return System.IO.Path.ChangeExtension(GetTeamResultsFilePath(results), "pdf");
        }

        public string GetNationResultsFilePath()
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedNationResultsFilePath(version, "xml")))
            {
                version++;
            }

            if (version > 1)
            {
                return BuildProposedNationResultsFilePath(version - 1, "xml");
            }
            else
            {
                return null;
            }
        }

        public string GetNextNationResultsFilePath()
        {
            int version = 1;

            while (System.IO.File.Exists(BuildProposedNationResultsFilePath(version, "xml")))
            {
                version++;
            }

            return BuildProposedNationResultsFilePath(version, "xml");
        }

        public string GetPublishedNationResultsFilePath()
        {
            return System.IO.Path.ChangeExtension(GetNationResultsFilePath(), "pdf");
        }

        public string GetNextPublishedNationResultsFilePath()
        {
            return System.IO.Path.ChangeExtension(GetNationResultsFilePath(), "pdf");
        }

        public string GetBackupSourceFolderPath()
        {
            System.IO.FileInfo competitionFile = new System.IO.FileInfo(this.CompetitionFilePath);

            return competitionFile.DirectoryName;
        }

        public string GetBackupDestinationFilePath(string backupFolderPath)
        {
            return System.IO.Path.Combine(backupFolderPath, String.Format("{0:yyyyMMddTHHmmssZ}.zip", DateTime.UtcNow));
        }

        public string CompetitionFilePath { get; set; }

        private string BuildProposedTaskResultsFilePath(Models.Results.TaskResults results, int version, string extension, bool separateClasses)
        {
            System.IO.FileInfo competitionFile = new System.IO.FileInfo(this.CompetitionFilePath);

            if (separateClasses)
            {
                return string.Format(@"{0}\Task {1}\{2}\{2} - Task {1:00} - {3:00}.{4}", competitionFile.DirectoryName, results.Task.Number, results.AircraftClass.Code, version, extension);
            }
            else
            {
                return competitionFile.DirectoryName + @"\Task " + String.Format("{0}", results.Task.Number) + @"\Task " + String.Format("{0}", results.Task.Number) + " - " + version.ToString("00") + "." + extension;
            }
        }

        private string BuildProposedOverallResultsFilePath(Models.Results.OverallResults results, int version, string extension, bool separateClasses)
        {
            System.IO.FileInfo competitionFile = new System.IO.FileInfo(this.CompetitionFilePath);

            if (separateClasses)
            {
                return string.Format(@"{0}\Overall\{1}\{1} - Overall - {2:00}.{3}", competitionFile.DirectoryName, results.AircraftClass.Code, version, extension);
            }
            else
            {
                return competitionFile.DirectoryName + @"\Overall - " + version.ToString("00") + "." + extension;
            }
        }

        private string BuildProposedTeamResultsFilePath(Models.Results.TeamResults results, int version, string extension, bool separateClasses)
        {
            System.IO.FileInfo competitionFile = new System.IO.FileInfo(this.CompetitionFilePath);

            if (separateClasses)
            {
                return string.Format(@"{0}\Team\{1}\{1} - Team - {2:00}.{3}", competitionFile.DirectoryName, results.AircraftClass.Code, version, extension);
            }
            else
            {
                return competitionFile.DirectoryName + @"\Team - " + version.ToString("00") + "." + extension;
            }
        }

        private string BuildProposedNationResultsFilePath(int version, string extension)
        {
            System.IO.FileInfo competitionFile = new System.IO.FileInfo(this.CompetitionFilePath);

            return string.Format(@"{0}\Nation\Nation - {1:00}.{2}", competitionFile.DirectoryName, version, extension);
        }
    }
}
