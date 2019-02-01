using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using Object = UnityEngine.Object;

namespace RaphaelBelmont.TAGEditor
{
    public class StoryEditorLib : Editor
    {
        public Object ClipFolder;
        private static StoryEditorLib _instane;

        public static StoryEditorLib Instance
        {
            get
            {
                if (_instane == null)
                {
                    _instane = new StoryEditorLib();
                }

                return _instane;
            }
        }

        #region EditorEvent

       //private delegate StroyEditorEvent (string )

        #endregion
        #region StaticMethod

        public static ClipData CrateNewClip()
        {
            ClipData c = CreateInstance<ClipData>();
            string name = Instance.GetNewClipName();
            string savePath = AssetDatabase.GetAssetPath(Instance.ClipFolder);
            AssetDatabase.CreateAsset(c, savePath + "/" + name + ".asset");
            return AssetDatabase.LoadAssetAtPath<ClipData>(savePath + "/" + name + ".asset");
        }

        #endregion

        #region PublicFunc

        public string GetClipFolderPath()
        {
            return AssetDatabase.GetAssetPath(ClipFolder);
        }

        public string GetNewClipName()
        {
            string[] clipGuidL =
                AssetDatabase.FindAssets("t:ClipData", new string[] {GetClipFolderPath()});
            int idx = 0;
            Regex r = new Regex("(NewClip_)[0-9]+$");
            Match m;
            foreach (string guid in clipGuidL)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ClipData clip = AssetDatabase.LoadAssetAtPath<ClipData>(path);
                m = r.Match(clip.name);
                if (m.Success)
                {
                    int i = Int32.Parse(clip.name.Split('_')[1]);
                    if (i > idx)
                    {
                        idx = i;
                    }
                }
            }

            return "NewClip_" + (idx + 1);
        }

        #endregion
    }
}