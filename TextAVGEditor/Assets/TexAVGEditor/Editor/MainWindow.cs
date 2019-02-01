//====================================================
//Created By RaphaelBelmont On 2019年1月26日
//Description: 编辑器主窗口
//====================================================

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RaphaelBelmont.TAGEditor
{
    public class MainWindow : EditorWindow
    {
       

        private const int WinMinWidth = 1000;
        private const int WinMinHeight = 800;
        private Color _backgroudColor;
        [MenuItem("Tools/TAGEditor")]
        public static void OpenWin()
        {
            EditorWindow win = GetWindow<MainWindow>();
            win.minSize = new Vector2(WinMinWidth, WinMinHeight);
            win.Show();
            win.titleContent = new GUIContent("编辑器主窗口");
        }

        public void OnEnable()
        {
            _backgroudColor = GUI.backgroundColor;
        }
        public void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 5, this.position.width, 30));
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("About", new GUILayoutOption[] {GUILayout.Height(30)}))
            {
                Debug.Log("==============>" + "About");
            }

            if (GUILayout.Button("About", new GUILayoutOption[] {GUILayout.Height(30)}))
            {
                Debug.Log("==============>" + "About");
            }

            if (GUILayout.Button("About", new GUILayoutOption[] {GUILayout.Height(30)}))
            {
                Debug.Log("==============>" + "About");
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.EndArea();

            
            GUILayout.BeginArea(new Rect(5, 40, 260, this.position.height));
            GUI.Box(new Rect(0, 0, 260, this.position.height), "");
            GUI.backgroundColor = Color.cyan;
            if (GUI.Button(new Rect(234
                , 0, 25, 25), "+"))
            {
                StoryEditorLib.CrateNewClip();
            }
            GUI.backgroundColor = _backgroudColor;
            GUILayout.EndArea();
      
        }
    }
}