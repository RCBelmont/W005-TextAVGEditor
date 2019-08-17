//====================================================
//Created By RaphaelBelmont On 2019年1月26日
//Description: 编辑器主窗口
//====================================================

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    public class MainWindow : EditorWindow
    {
        private const int WinMinWidth = 1000;
        private const int WinMinHeight = 800;
        private Color _backgroudColor;
        private UIElement_NodeView _nodeView;

        [MenuItem("Tools/TAGEditor &e")]
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
            _nodeView = new UIElement_NodeView();
        }

        private Proj _proj;

        public void OnGUI()
        {
            DrawHeadBar();
            //绘制工程信息栏
            if (_proj)
            {
                UIElement_ProjInfo.DrawProjInfo(new Rect(0, 40, 150, position.height - 40), _proj);
            }
        }

        #region UI Method

        //绘制头部工具栏
        private void DrawHeadBar()
        {
            GUILayout.BeginArea(new Rect(0, 0, position.width, 60));
            EditorGUILayout.BeginHorizontal();
            _proj = (Proj) EditorGUILayout.ObjectField("选择工程:", _proj, typeof(Proj), false);
            if (_proj == null && GUILayout.Button("创建新的工程"))
            {
                TextInputPopup.Open("创建新的工程", "NewProject", "输入工程名称",
                    (string name) => { _proj = EditorFileUtils.Instance.CreateNewProj(name); });
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        #endregion
    }
}