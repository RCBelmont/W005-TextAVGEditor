//============================
//Created By RCBelmont on 2019年4月30日
//Description Editor窗口的节点管理器
//============================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
    public class EditorNodeMgr
    {
        public static EditorNodeMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EditorNodeMgr();
                    
                }

                return _instance;
            }
        }
        private static EditorNodeMgr _instance;
        
        

    }
}