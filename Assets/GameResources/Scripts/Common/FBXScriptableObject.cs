using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FBXScriptableObject", menuName = "Scriptable")]
public class FBXScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject[] fbxArray = {};
    public GameObject[] FBXArray{
        get {
            return fbxArray;
        }set{}
    }
}
