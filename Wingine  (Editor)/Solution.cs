using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine.Editor.Code
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal static class Solution
    {
        public static void Test()
        {
            string solutionName = "MySolution";
            string solutionPath = Environment.CurrentDirectory;

            CreateSolution(solutionName, solutionPath);
            CreateProject(solutionName, solutionPath, "MyProject");
            AddProjectToSolution(solutionName, solutionPath, "MyProject");

            Console.WriteLine("Solution and project created successfully!");
            //Process.Start($"explorer {solutionPath.Replace(@"\\", "\\")}");
        }

        public static void CreateSolution(string solutionName, string solutionPath)
        {
            string solutionFilePath = Path.Combine(solutionPath, $"{solutionName}.sln");

            using (StreamWriter writer = new StreamWriter(solutionFilePath))
            {
                writer.WriteLine("Microsoft Visual Studio Solution File, Format Version 12.00");
                writer.WriteLine("# Visual Studio 2022");

                // Add project entries
                writer.WriteLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"MyProject\", \"MyProject\\MyProject.csproj\", \"{GUID}\"");
                writer.WriteLine("EndProject");

                writer.WriteLine("Global");
                writer.WriteLine("\tGlobalSection(SolutionProperties) = preSolution");
                writer.WriteLine("\t\tHideSolutionNode = FALSE");
                writer.WriteLine("\tEndGlobalSection");
                writer.WriteLine("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution");
                writer.WriteLine("\t\t{GUID}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
                writer.WriteLine("\t\t{GUID}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                writer.WriteLine("\tEndGlobalSection");
                writer.WriteLine("\tGlobalSection(SolutionProperties) = preSolution");
                writer.WriteLine("\t\tHideSolutionNode = FALSE");
                writer.WriteLine("\tEndGlobalSection");
                writer.WriteLine("EndGlobal");
            }
        }

        public static void CreateProject(string solutionName, string solutionPath, string projectName)
        {
            string projectFolderPath = Path.Combine(solutionPath, projectName);
            string projectFilePath = Path.Combine(projectFolderPath, $"{projectName}.csproj");

            Directory.CreateDirectory(projectFolderPath);

            using (StreamWriter writer = new StreamWriter(projectFilePath))
            {
                writer.WriteLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
                writer.WriteLine("\t<PropertyGroup>");
                writer.WriteLine("\t\t<OutputType>Library</OutputType>");
                writer.WriteLine("\t\t<TargetFramework>netstandard2.0</TargetFramework>");
                writer.WriteLine("\t</PropertyGroup>");
                writer.WriteLine("</Project>");
            }
        }

        public static void AddProjectToSolution(string solutionName, string solutionPath, string projectName)
        {
            string solutionFilePath = Path.Combine(solutionPath, $"{solutionName}.sln");

            string projectEntry = $"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{projectName}\", \"{projectName}\\{projectName}.csproj\", \"{{GUID}}\"";
            string projectGuid = Guid.NewGuid().ToString().ToUpper();

            string solutionContents = File.ReadAllText(solutionFilePath);
            solutionContents = solutionContents.Replace("{GUID}", projectGuid);
            solutionContents += Environment.NewLine + projectEntry + Environment.NewLine + "EndProject";

            File.WriteAllText(solutionFilePath, solutionContents);
        }
    }

}
