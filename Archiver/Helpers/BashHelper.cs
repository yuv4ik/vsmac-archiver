using System.Diagnostics;

namespace Archiver.Helpers
{
    public static class BashHelper
    {
        public static (int code, string output) ExecuteBashCommand(string command)
        {
            // Escape double quotes:
            // https://stackoverflow.com/a/15262019/637142
            command = command.Replace("\"", "\"\"");

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                }
            };

            proc.Start();
            proc.WaitForExit();

            return (proc.ExitCode, proc.StandardOutput.ReadToEnd());
        }
    }
}
