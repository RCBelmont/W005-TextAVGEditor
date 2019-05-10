using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class ABPacker : EditorWindow
{
    [MenuItem("Tools/ABPacker")]
    public static void OpenWin()
    {
        EditorWindow win = GetWindow<ABPacker>(); 
        win.Show();
    }

    private string _abSavePath = Application.streamingAssetsPath + "/ABs";
    private BuildTarget _buildTarget = BuildTarget.StandaloneWindows;
    private const string _abAssetFolderName = "ABAssets/";

    void OnEnable()
    {
        if (EditorPrefs.HasKey("KEY_TAGPackerTarget"))
        {
            _buildTarget = (BuildTarget)EditorPrefs.GetInt("KEY_TAGPackerTarget");
        }
    }
    void OnDisable()
    {
        EditorPrefs.SetInt("KEY_TAGPackerTarget", (int)_buildTarget);
    }
    void OnGUI()
    {
        if (GUILayout.Button("Set Bundle Name"))
        {
            LoopSetBundleName();
        }
        EditorGUILayout.Space();

        _buildTarget = (BuildTarget)EditorGUILayout.EnumPopup("打包平台:", _buildTarget);

        if (GUILayout.Button("Build Asset Bundle"))
        {
            BuildPipeline.BuildAssetBundles(_abSavePath, BuildAssetBundleOptions.None, _buildTarget);
        }

        
    }

    public static void LoopSetBundleName()
    {
        string[] allPaths = AssetDatabase.GetAllAssetPaths();
        foreach (string path in allPaths)
        {
            if (path.Contains(_abAssetFolderName))
            {
                if (File.Exists(path))
                {
                   string bundleName =  GetBundleName(path);
                   AssetImporter.GetAtPath(path).assetBundleName = bundleName;
                }
                else
                {
                    AssetImporter.GetAtPath(path).assetBundleName = "";
                }

            }
        }

    }

    private static string GetBundleName(string path)
    {
        string parent = Directory.GetParent(path).FullName.Replace('\\', '/');
      
        Regex r= new Regex("([^/]+)$");
        Match m = r.Match(parent);

        
        return parent.Substring(m.Index);
    }
    
}
