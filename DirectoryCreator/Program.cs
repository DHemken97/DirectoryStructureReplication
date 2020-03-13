using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCreator
{
    class Program
    {
        private static List<string> Directories { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Source:");
            var sourceRoot = Console.ReadLine();
            Console.WriteLine("Target:");
            var targetRoot = Console.ReadLine();
            Console.Write("Reading Folders...0 Found");
            Directories = new List<string>();
            SearchForDirectories(sourceRoot);
            Console.WriteLine();
            DeployDirectories(sourceRoot, targetRoot);
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private static void SearchForDirectories(string path)
        {
            var dirs = Directory.GetDirectories(path);
            if (dirs.Any())
                foreach (var directory in dirs)
                {
                    try
                    {
                        SearchForDirectories(directory);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            else
            {
                Directories.Add(path);
                Console.Write($"\rReading Folders...{Directories.Count} Found");

            }

        }

        private static void DeployDirectories(string sourceRoot, string TargetRoot)
        {
            foreach (var directory in Directories)
            {
                try
                {
                var path = directory.Replace(sourceRoot, TargetRoot);
                Console.WriteLine($"Deploying: {path}");
                Directory.CreateDirectory(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }
    }
}
