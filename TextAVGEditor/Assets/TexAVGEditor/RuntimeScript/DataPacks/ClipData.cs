using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaphaelBelmont.TAGEditor
{

    public class ClipData : ScriptableObject
    {
        public List<FrameData> FrameList = new List<FrameData>();
       

       
        public void InsertFrameList(int idx)
        {
            idx = Mathf.Clamp(idx, 0, FrameList.Count);
            FrameData frame = new FrameData();
            FrameList.Insert(idx, frame);
        }
    }
}

