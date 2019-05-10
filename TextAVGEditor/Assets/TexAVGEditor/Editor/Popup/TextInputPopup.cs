//============================
//Created By RCBelmont on 2019年5月1日
//Description 文本输入弹窗
//============================


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    public class TextInputPopup : EditorWindow
    {
        private static string _title, _tip, _placeHolder;
        private static Action<string> _sureCb;

        public static void Open(string title = "", string placeHolder = "", string tip = "",
            Action<string> sureCb = null)
        {
            _title = title;
            _tip = tip;
            _sureCb = sureCb;
            _placeHolder = string.IsNullOrEmpty(placeHolder) ? "PlaceInput" : placeHolder;
            EditorWindow win = GetWindow<TextInputPopup>();
            win.name = title;
            win.minSize = new Vector2(400, 200);
            win.maxSize = new Vector2(400, 200);
            win.Show();
        }

        private string _text = _placeHolder;

        private void OnGUI()
        {
            _text = EditorGUILayout.TextField(_tip, _text);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("OK"))
            {
                _sureCb?.Invoke(_text);
                this.Close();
            }

            if (GUILayout.Button("Cancel"))
            {
                this.Close();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}