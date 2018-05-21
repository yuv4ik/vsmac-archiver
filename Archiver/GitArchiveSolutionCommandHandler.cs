using System;
using Archiver.Extensions;
using Archiver.Helpers;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace Archiver
{
    public class GitArchiveSolutionCommandHandler : BaseArchiverCommandHandler
    {
        protected override void Update(CommandInfo info)
        {
            info.Enabled = IsWorkspaceOpen() && IsASolution() && ProjectIsNotBuildingOrRunning() && GitRepoIsNotBlank(ProjectOperations.CurrentSelectedSolution.BaseDirectory.FullPath);
        }

        protected override void Run()
        {
            using (var monitor = IdeApp.Workbench.ProgressMonitors.GetToolOutputProgressMonitor(true))
            {
                monitor.BeginTask(1);

                try
                {
                    var solution = ProjectOperations.CurrentSelectedSolution;
                    var solutionFullPath = solution.BaseDirectory.FullPath;

                    monitor.Log.WriteLine($"Archiving {solutionFullPath}");
                    var result = BashHelper.ExecuteBashCommand($"cd {solutionFullPath};git archive --format zip --output \"{solution.Name}_{DateTime.Now.ToArhiveTimestamp()}.zip\" HEAD");

                    monitor.ReportSuccess($"Git archive return code: {result.code} {Environment.NewLine}Git archive log: {result}");
                }
                catch (Exception ex)
                {
                    monitor.ReportError($"Archiving failed with: ", ex);
                }
                finally
                {
                    monitor.EndTask();
                }
            }
        }

        bool GitRepoIsNotBlank(string solutionFullPath)
        {
            var executionResult = BashHelper.ExecuteBashCommand($"cd {solutionFullPath};git log --oneline | wc -l");
            var commitsNumberBiggerThanZero = int.Parse(executionResult.output.Trim()) > 0;
            return executionResult.code == 0 && commitsNumberBiggerThanZero;
        }
    }
}
