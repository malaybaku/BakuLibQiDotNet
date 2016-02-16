using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardSamples
{
    static class PathModifier
    {
        public static void AddEnvironmentPaths(params string[] paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? "" };

            string newPath = string.Join(System.IO.Path.PathSeparator.ToString(), path.Concat(paths));

            Environment.SetEnvironmentVariable("PATH", newPath);
        }
    }
}
