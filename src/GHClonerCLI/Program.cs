using GHClonerCLI.Services;
using System;
using System.Threading.Tasks;

namespace GHClonerCLI;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
                return;

            switch(args[0])
            {
                case "--version":
                    ShowVersion();
                    break;

                case "-v":
                    ShowVersion();
                    break;

                case "backup":
                    StartClone(args)
                        .GetAwaiter()
                        .GetResult();
                    break;

                default:
                    ShowHelpMessage();
                    break;
            }
        }
        catch (Exception)
        {
            ShowHelpMessage();
        }
    }

    private static void ShowHelpMessage()
    {
        Console.WriteLine("+--------------------------------------------------------------------------------------------+");
        Console.WriteLine("+                                                                                            +");
        Console.WriteLine("+          ghcloner v0.0.1                                                                   +");
        Console.WriteLine("+          usage: ghcloner <command>                                                         +");
        Console.WriteLine("+          example: ghcloner backup --t <github_token> --f <folder_to_clone> --p <page>      +");
        Console.WriteLine("+                                                                                            +");
        Console.WriteLine("+--------------------------------------------------------------------------------------------+");
    }
    
    public static void ShowVersion()
    {
        Console.WriteLine("+------------------------------------------------+");
        Console.WriteLine("+                                                +");
        Console.WriteLine("+          ghcloner v0.0.1                       +");
        Console.WriteLine("+                                                +");
        Console.WriteLine("+------------------------------------------------+");
    }

    public static async Task StartClone(string[] args)
    {
        var _clonerService = new ClonerService();
        
        string githubToken = args[2];
        string folderToSave = args[4];
        int repositoriesPage = int.Parse(args[6]);

        await _clonerService.StartClone(githubToken, folderToSave, repositoriesPage);
    }
}