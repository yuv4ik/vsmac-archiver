using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace Archiver
{
    public abstract class BaseArchiverCommandHandler : CommandHandler
    {
        protected ProjectOperations ProjectOperations = IdeApp.ProjectOperations;
        protected bool IsWorkspaceOpen() => IdeApp.Workspace.IsOpen;
        protected bool IsASolution() => ProjectOperations.CurrentSelectedItem is Solution;

        protected bool ProjectIsNotBuildingOrRunning()
        {
            var isBuild = ProjectOperations.IsBuilding(ProjectOperations.CurrentSelectedSolution);
            var isRun = ProjectOperations.IsRunning(ProjectOperations.CurrentSelectedSolution);

            return !isBuild && !isRun && IdeApp.ProjectOperations.CurrentBuildOperation.IsCompleted
                         && IdeApp.ProjectOperations.CurrentRunOperation.IsCompleted;
        }
    }
}
