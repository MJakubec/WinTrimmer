using System;

namespace AsBest.WinTrimmer
{
  internal static class StartupManager
  {
    private static bool hasArguments;
    private static string commandName;
    private static string commandParameter;

    private static void DisplayUsageInformation()
    {
      Console.WriteLine("AsBEST WinTrimmer Console Utility");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine();
      Console.WriteLine("Usage: WinTrimmer.Console.exe apply [template-path]");
      Console.WriteLine("       WinTrimmer.Console.exe lookup <window-caption>");
      Console.WriteLine();
    }

    private static void ParseCommandArguments(string[] args)
    {
      hasArguments = (args.Length != 0);
      commandName = (args.Length > 0 ? args[0] : null);
      commandParameter = (args.Length > 1 ? args[1] : null);
    }

    private static void ExecuteCommand()
    {
      switch (commandName)
      {
        case "apply":
          ApplyCommand.Execute(commandParameter);
          break;
        case "lookup":
          LookupCommand.Execute(commandParameter);
          break;
      }
    }
    
    private static int Main(string[] args)
    {
      ParseCommandArguments(args);

      if (!hasArguments)
      {
        DisplayUsageInformation();
        return 128;
      }

      ExecuteCommand();
      return 0;
    }
  }
}
