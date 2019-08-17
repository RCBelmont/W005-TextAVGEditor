using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RCBelmont.TAGEditor
{
    [System.Serializable]
    public class EntryNode
    {
        
        public Vector2 Pos = Vector2.zero;
        //节点ID
        private ulong _nextId;
        public ulong NextID => _nextId;
        
    }  

}

