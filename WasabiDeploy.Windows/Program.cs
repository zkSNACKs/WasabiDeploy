using System;
using System.IO;
using System.Threading.Tasks;

namespace WasabiDeploy.Windows
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var workingDirectory = Path.Combine(Path.GetTempPath(), "wasabi");
            var publishDirectory = Path.Combine(workingDirectory, "publish");
            var guiDirectory = Path.Combine(workingDirectory, "WalletWasabi", "WalletWasabi.Gui");

            var versionPrefix = "1.1.10.2";

            //IoHelpers.DeleteDirectory(workingDirectory);
            //Directory.CreateDirectory(workingDirectory);
            //await GitTools.CloneAsync("https://github.com/zkSNACKs/WalletWasabi.git", workingDirectory);

            IoHelpers.DeleteDirectory(publishDirectory);
            await ProcessTools.StartAsync(
                "dotnet",
                $"publish --configuration Release --force --output \"{publishDirectory}\" --self-contained true --runtime \"win7-x64\" /p:VersionPrefix={versionPrefix} --disable-parallel --no-cache /p:DebugType=none /p:DebugSymbols=false /p:ErrorReport=none /p:DocumentationFile=\"\" /p:Deterministic=true /p:PublishSingleFile=true",
                guiDirectory);
        }
    }
}
