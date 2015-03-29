using System;
using System.IO;

namespace AsBest.WinTrimmer
{
  public sealed class ConfigurationManager
  {
    private const string ApplicationPath = @"AsBEST\WinTrimmer";
    private const string TemplatePath = @"Templates";

    public static readonly int MajorSystemVersion = Environment.OSVersion.Version.Major;
    public static readonly int MinorSystemVersion = Environment.OSVersion.Version.Minor;

    private static readonly ConfigurationManager instance = new ConfigurationManager();

    public static ConfigurationManager Instance
    {
      get { return instance; }
    }

    private string CommonDataPath
    {
      get { return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData); }
    }

    private string UserDataPath
    {
      get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
    }

    public string CommonTemplatePath
    {
      get { return Path.Combine(CommonDataPath, ApplicationPath, TemplatePath); }
    }

    public string UserTemplatePath
    {
      get { return Path.Combine(UserDataPath, ApplicationPath, TemplatePath); }
    }
  }
}
