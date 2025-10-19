# 🗃 File Organizer Tool

Configurable **C# console app** that automatically sorts files by type.  
Uses `appsettings.json` for folder path and extension mapping.

---

## ⚙️ Configuration (`appsettings.json`)

Before running the program, **open `appsettings.json`** and replace  
`<Your Username>` with your actual Windows username or a custom path.

Example:
```json
{
  "FolderPath": "C:\\Users\\<Your Username>\\Downloads",
  "ExtensionMapping": [
    {
      "Folder": "Images",
      "Extensions": [ "jpg", "jpeg", "png", "gif" ]
    },
    {
      "Folder": "Documents",
      "Extensions": [ "pdf", "doc", "docx", "txt" ]
    },
    {
      "Folder": "Videos",
      "Extensions": [ "mp4", "avi", "mov" ]
    },
    {
      "Folder": "Archives",
      "Extensions": [ "zip", "rar", "7z" ]
    }
  ]
}
```

📌 If you use Linux or macOS, change the path accordingly, e.g.:
```
/home/username/Downloads
```

---

## 🚀 How it works
- Reads `FolderPath` from configuration  
- Sorts files into subfolders defined in `ExtensionMapping`  
- Any unknown extension → goes to `Others/`  

---

## 📂 Example

**Before:**
```
Downloads/
├── report.docx
├── photo.jpg
├── movie.mp4
├── archive.zip
```

**After:**
```
Downloads/
├── Documents/
│   └── report.docx
├── Images/
│   └── photo.jpg
├── Videos/
│   └── movie.mp4
├── Archives/
│   └── archive.zip
├── Others/
│   └── readme.txt
```

---

## 🧠 Improvements ideas
- Logging into file  
- Ignore specific extensions  
- Add preview mode ("dry-run")  

---

## 🪪 License
This project is open source under the [MIT License](LICENSE).
