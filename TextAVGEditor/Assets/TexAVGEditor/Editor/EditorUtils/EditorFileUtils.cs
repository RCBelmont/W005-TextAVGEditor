//============================
//Created By RCBelmont on 2019年5月1日
//Description 编辑器文件工具
//============================


using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    public class EditorFileUtils
    {
        //单例
        private static EditorFileUtils _instance;

        public static EditorFileUtils Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EditorFileUtils();
                }

                return _instance;
            }
        }

        #region Public Method
        //创建一个新的工程
        public Proj CreateNewProj(string name = "New Project")
        {
            Proj proj = ScriptableObject.CreateInstance<Proj>();
            proj.ProjName = name;
            string savePath = GetProjSavePath() + "/" + name + ".asset";
            string relativePath = GetAssetRelativePath(savePath);
            AssetDatabase.CreateAsset(proj, relativePath);
            AssetDatabase.Refresh();
            return AssetDatabase.LoadAssetAtPath<Proj>(relativePath);
        }

        //获取默认的项目存放路径,若不存在则创建
        public string GetProjSavePath()
        {
            string path = Application.dataPath + "/TAGProj";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                AssetDatabase.Refresh();
            }

            return path;
        }
        //将路径转为相对于Assets的相对路径（Assets开头）
        public string GetAssetRelativePath(string path)
        {
            string temp = path.Replace(Application.dataPath, "");
            return "Assets" + temp;
        } 

        #endregion

        #region Private Method
       
        

        #endregion
    }
}