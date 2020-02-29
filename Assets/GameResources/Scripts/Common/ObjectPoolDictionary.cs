using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolDictionary : MonoSingleton<ObjectPoolDictionary>
{
    [SerializeField] private FBXScriptableObject fBXScriptableObject = null;
    private Dictionary<string, GameObjectPool<GameObject>> fbxPoolDic = new Dictionary<string, GameObjectPool<GameObject>>();
    private List<GameObject> activeList = new List<GameObject>();
    void Awake()
    {
        var fbxArr = fBXScriptableObject.FBXArray;
        for (int i = 0; i < fBXScriptableObject.FBXArray.Length; i++)
        {
            var pool = new GameObjectPool<GameObject>(10, () =>
            {
                GameObject obj = Instantiate(fbxArr[i],this.transform);
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                return obj;
            });
            fbxPoolDic.Add(fbxArr[i].name, pool);
        }
    }

    public GameObject GetObjectPrefab(string key)
    {
        if (fbxPoolDic.ContainsKey(key) == false)
            Debug.Log(key + " key not found");
        var prefab = fbxPoolDic[key].pop();
        activeList.Add(prefab);
        return prefab;
    }
    public void RemoveObject(GameObject obj, string key){
        if(activeList.Contains(obj)){
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            fbxPoolDic[key].push(obj);
            activeList.Remove(obj);
        }else{
            Debug.Log("ActiveList not found :" + key);
        }
    }
}
