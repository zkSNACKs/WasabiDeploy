using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WasabiDeploy
{
    public static class IoHelpers
    {
        public static void DeleteDirectory(string pathToDirectory)
        {
            int attemps = 0;
            if (Directory.Exists(pathToDirectory))
            {
                do
                {
                    try
                    {
                        attemps++;

                        if (attemps > 1)
                        {
                            foreach (var f in Directory.GetFiles(pathToDirectory, "*.*", SearchOption.AllDirectories))
                            {
                                File.SetAttributes(f, FileAttributes.Normal);
                                File.Delete(f);
                            }
                        }

                        Directory.Delete(pathToDirectory, true);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (attemps > 10)
                        {
                            throw ex;
                        }
                    }
                }
                while (Directory.Exists(pathToDirectory));
            }
        }

        public static string FindDirectoryByName(string path, string directoryName)
        {
            var currentDirectory = new DirectoryInfo(path);
            do
            {
                if (string.Equals(currentDirectory.Name, directoryName, StringComparison.InvariantCulture))
                {
                    return currentDirectory.FullName;
                }

                currentDirectory = Directory.GetParent(currentDirectory.FullName);
            }
            while (currentDirectory.Parent is { });

            return null;
        }

        public static string GetWorkingDirectory()
        {
            var rootDirectory = FindDirectoryByName("./", "WasabiDeploy");
            return Path.Combine(rootDirectory, "WasabiDeploy.Temp");
        }
    }
}
