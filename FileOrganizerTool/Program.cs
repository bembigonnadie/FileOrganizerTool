using System.Text.Json;
using FileOrganizerTool;

// === Load configuration ===
var configText = File.ReadAllText("appsettings.json");
var config = JsonSerializer.Deserialize<Config>(configText)
             ?? throw new Exception("Invalid configuration file");

var folderPath = config.FolderPath;
if (!Directory.Exists(folderPath))
{
    Console.WriteLine($"❌ Folder not found: {folderPath}");
    return;
}

Console.WriteLine($"📁 Organizing files in: {folderPath}");
var files = Directory.GetFiles(folderPath);
if (files.Length == 0)
{
    Console.WriteLine("⚠️ No files found in the folder.");
    return;
}

Console.WriteLine($"Found {files.Length} files.");
foreach (var file in files)
{
    var ext = Path.GetExtension(file).TrimStart('.').ToLowerInvariant();
    if (string.IsNullOrEmpty(ext)) ext = "unknown";

    // Determine target folder by extension
    var matchedGroup = config.ExtensionMapping
        .FirstOrDefault(x => x.Extensions.Contains(ext));

    var targetFolderName = matchedGroup?.Folder ?? "Others";

    var targetDir = Path.Combine(folderPath, targetFolderName);
    Directory.CreateDirectory(targetDir);

    var destPath = Path.Combine(targetDir, Path.GetFileName(file));

    try
    {
        File.Move(file, destPath, overwrite: true);
        Console.WriteLine($"✅ {Path.GetFileName(file)} → {targetFolderName}/");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"⚠️ Skipped {file}: {ex.Message}");
    }
}

Console.WriteLine("\n🎉 Done! Files organized successfully.");

