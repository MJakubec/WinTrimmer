using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AsBest.WinTrimmer
{
  public class TrimmingManager
  {
    private static readonly TrimmingManager instance = new TrimmingManager();

    private readonly List<Template> templates = new List<Template>();
    private readonly List<WindowMapper> mappers = new List<WindowMapper>();

    private void LoadTemplateFromFiles(IEnumerable<string> files)
    {
      foreach (string file in files)
      {
        var template = Template.FromFile(file);

        if (template.MajorSystemVersion.HasValue)
          if (template.MajorSystemVersion != ConfigurationManager.MajorSystemVersion)
            continue;

        if (template.MinorSystemVersion.HasValue)
          if (template.MinorSystemVersion != ConfigurationManager.MinorSystemVersion)
            continue;

        Templates.Add(template);
      }
    }

    private void MatchTemplate(Template template, IntPtr windowHandle, List<WindowMapper> activeMappers)
    {
      WindowMapper mapper = new WindowMapper();

      bool withoutMatch = !template.Window.Match(windowHandle, mapper);
      if (withoutMatch)
        return;

      IntPtr marker = mapper.LookupMarkerHandle();
      activeMappers.AddRange(Mappers.Where(m => m.LookupMarkerHandle() == marker));

      bool alreadyDetected = (activeMappers.Count > 0);
      if (alreadyDetected)
        return;

      template.Execute(mapper);

      Mappers.Add(mapper);
      activeMappers.Add(mapper);
    }

    private void MatchTemplates(IntPtr windowHandle, List<WindowMapper> activeMappers)
    {
      foreach (Template template in Templates)
        if (template.Enabled)
          MatchTemplate(template, windowHandle, activeMappers);
    }

    private void MatchWindowHandles(IEnumerable<IntPtr> windowHandles, List<WindowMapper> activeMappers)
    {
      foreach (IntPtr windowHandle in windowHandles)
      {
        MatchTemplates(windowHandle, activeMappers);
      }
    }

    private void RemoveObsoleteMappers(IEnumerable<WindowMapper> activeMappers)
    {
      WindowMapper[] obsoleteMappers = Mappers.Except(activeMappers).ToArray();
      Array.ForEach(obsoleteMappers, m => Mappers.Remove(m));
    }

    public List<Template> Templates
    {
      get { return templates; }
    }

    public void LoadTemplates(string folderPath)
    {
      bool pathExists = Directory.Exists(folderPath);
      if (!pathExists)
        return;
      string[] files = Directory.GetFiles(folderPath);
      LoadTemplateFromFiles(files);
    }

    public void LoadTemplates()
    {
      string templatePath = ConfigurationManager.Instance.CommonTemplatePath;
      LoadTemplates(templatePath);
    }

    public void LookupMatchingWindows()
    {
      IntPtr[] windowHandles = WindowHelper.EnumVisibleWindows();
      List<WindowMapper> activeMappers = new List<WindowMapper>();
      MatchWindowHandles(windowHandles, activeMappers);
      RemoveObsoleteMappers(activeMappers);
    }

    public static TrimmingManager Instance
    {
      get { return instance; }
    }

    public List<WindowMapper> Mappers
    {
      get { return mappers; }
    }
  }
}
