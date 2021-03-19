using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WasabiDeploy
{
    public static class GitTools
    {
        public static async Task CloneAsync(string url, string destinationPath)
        {
            await ProcessTools.StartAsync("git", $"clone --depth 1 --branch master {url}", destinationPath);
        }
    }
}
