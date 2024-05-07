

using UnityEditor;
using UnityEngine;

public class assetbundleCreator 
{
    [MenuItem("Assets/Build Asset Bundle")]
    static void BuildBundles()
    {
        string path = Application.dataPath + "/../AssetBundle";
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None,BuildTarget.Android );
        Debug.Log("hello");
    }

}
