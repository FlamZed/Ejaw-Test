using UnityEditor;

public class CreateAssetBundle
{
    [MenuItem("Assets/Build AssetBundle")]
    static void BuildAssetBundle()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}