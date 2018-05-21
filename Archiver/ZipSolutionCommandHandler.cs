using System;
using Archiver.Extensions;
using Archiver.Helpers;
using MonoDevelop.Ide;

namespace Archiver
{
    public class ZipSolutionCommandHandler : BaseArchiverCommandHandler
    {

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
                    var result = BashHelper.ExecuteBashCommand($"cd {solutionFullPath}; zip -r \"{solution.Name}_{DateTime.Now.ToArhiveTimestamp()}.zip\" . -x packages/\\* */bin/\\* */obj/\\* *.git/\\* *.vs/\\*");

                    monitor.ReportSuccess($"Zip return code: {result.code} {Environment.NewLine}Zip log: {result}");
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
    }
}
