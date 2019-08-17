using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    public class UIElement_ProjInfo
    {
        static private Vector2 _scrollVec;


        public static void DrawProjInfo(Rect areaRect, Proj projObj)
        {
            if (projObj == null)
            {
                return;
            }
            GUI.Box(areaRect, "ProjInfoBox");
            GUILayout.BeginArea(new Rect(areaRect.x, areaRect.y + 20, areaRect.width, areaRect.height - 20));
            GUILayout.BeginHorizontal();
            GUILayout.Label("项目名称：");
            projObj.ProjName = GUILayout.TextField(projObj.ProjName);
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
            
        }
    }

}

