using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AssetBundle b = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/ABs/luca");
        GameObject g = b.LoadAsset<GameObject>("Panel");
        Instantiate(g).transform.SetParent(this.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
