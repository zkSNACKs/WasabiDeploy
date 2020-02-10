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
            var workingDirectory = IoHelpers.GetWorkingDirectory();
        }
    }
}
