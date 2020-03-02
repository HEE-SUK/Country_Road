using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBXLoader : MonoBehaviour
{
    [SerializeField]
    private FBXScriptableObject fBXScriptableObject = null;
    private Dictionary<string, GameObject> towerBodyDic = new Dictionary<string, GameObject>();

    void Awake()
    {
        var towerFbx = fBXScriptableObject.FBXArray;
        for (int i = 0; i < fBXScriptableObject.FBXArray.Length; i++)
        {
            // Debug.Log(towerFbx[i].name);
            towerBodyDic.Add(towerFbx[i].name, towerFbx[i]);
        }
    }

    public GameObject GetObjectPrefab(string key)
    {
        if (towerBodyDic.ContainsKey(key) == false)
            Debug.Log(key + " key not found");
        return towerBodyDic[key];
    }
}
