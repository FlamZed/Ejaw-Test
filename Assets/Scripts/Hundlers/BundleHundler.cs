using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BundleHundler : MonoBehaviour
{
    static private List<Object> loadedObjects = new List<Object>();
    static private List<string> loadedName = new List<string>();

    private void Start()
    {
        try
        {
            ListItem items = JsonHandler.LoadingJson<ListItem>();

            foreach (var item in items.Objects)
            {
                loadedName.Add(item.Name);
            }

            LoadBundle();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void LoadBundle()
    {
        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/prefabsbundle"));
        foreach (string item in loadedName)
        {
            loadedObjects.Add(assetBundle.LoadAssetAsync(item, typeof(GameObject)).asset);
        }
    }

    // Instantiate object from SpawnObject
    public static Object GetObject()
    {
        return loadedObjects[Random.Range(0, loadedObjects.Count)];
    }
}