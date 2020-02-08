using System.Diagnostics;
using System.Threading.Tasks;

namespace WasabiDeploy
{
    public static class ProcessTools
    {
        public static async Task<string> StartAsync(string fileName, string arguments, string workingDirectory, bool redirectStandardOutput = false)
        {
            using var process = Process.Start(new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = redirectStandardOutput
            });
            process.WaitForExit();
            if (redirectStandardOutput)
            {
                return await process.StandardOutput.ReadToEndAsync();
            }
            return null;
        }
    }
}
