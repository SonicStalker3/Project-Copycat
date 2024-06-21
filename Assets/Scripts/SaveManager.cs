using System.IO;
using ScriptableObjects;
using UnityEngine;

public static class SaveManager
{
    public static readonly string _defaultSaveDir = Application.persistentDataPath + "/";
    public static string SaveDir = _defaultSaveDir;
    
    public static string SaveName = "game.save";
    public static string SavePath => Path.Combine(SaveDir, SaveName);

    public static Save SaveFile;
        
    public static void Save(Save save)
    {
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(SavePath, json);
    }

    public static Save Load()
    {
        if (!File.Exists(SavePath)) return null;
        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<Save>(json);
    }
}