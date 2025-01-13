using System.Collections.Generic;

namespace MediaVisualizer.DataImporter.Models;

public class InfoYaml
{
    public string Source { get; set; }

    public string URL { get; set; }

    public string Title { get; set; }

    public List<string> Artist { get; set; } = [];

    public List<string> Circle { get; set; } = [];

    public List<string> Parody { get; set; } = [];

    public List<string> Magazine { get; set; } = [];

    public List<string> Tags { get; set; } = [];

    public List<string> General { get; set; } = [];

    public long Released { get; set; }

    public int Pages { get; set; }

    public int Thumbnail { get; set; }
}