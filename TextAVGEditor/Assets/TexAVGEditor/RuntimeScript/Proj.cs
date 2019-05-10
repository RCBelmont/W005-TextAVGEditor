//============================
//Created By RCBelmont on 2019年4月30日
//Description 编辑器项目信息
//============================


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    public class Proj:ScriptableObject
    {
        public String ProjName = "New Project";
        public List<Node> NodeList = new List<Node>();
    }
}