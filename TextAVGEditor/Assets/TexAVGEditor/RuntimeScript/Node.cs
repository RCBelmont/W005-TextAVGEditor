//============================
//Created By RCBelmont on 2019年4月30日
//Description 编辑器节点信息
//============================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    [System.Serializable]
    public class Node
    {
        //节点在编辑窗口的位置
        private Vector2 pos = Vector2.zero;
        public Vector2 Pos
        {
            get => pos;
            set => pos = value;
        }
        //节点ID
        private ulong _id;
        public ulong ID => _id;
        
        //构造函数
        public Node()
        {
            _id = CommonUtils.Instance.GetUID();
        }
        
    }

}

