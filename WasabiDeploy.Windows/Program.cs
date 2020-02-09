using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace WasabiDeploy.Windows
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dir = new DirectoryInfo("./../win").FullName;

            Console.WriteLine(dir);
            Console.WriteLine(string.Join(Environment.NewLine, Directory.EnumerateFileSystemEntries(dir)));
        }
    }
}
