namespace FileOrganizerTool;

class Config
{
    public string FolderPath { get; set; } = string.Empty;
    public List<ExtensionGroup> ExtensionMapping { get; set; } = new();
}
