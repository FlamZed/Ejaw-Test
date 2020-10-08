using System.IO;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    private static string path;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, "Resources/Game Data/GameObject.json");
    }

    static public T LoadingJson<T>()
    {
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
        else return default(T);
    }
}