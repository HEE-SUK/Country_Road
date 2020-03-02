using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Transform CarSpawnPos = null;
    public CarController CarChange(string prefabName)
    {
        for (int i = 0; i < CarSpawnPos.childCount; i++) // 전에 존재한 차들을 지워줌
        {
            Destroy(CarSpawnPos.GetChild(i).gameObject);
        }
        GameObject obj = ResourceManager.Instance.Instantiate("Prefab/Car/" + prefabName);
        if (obj == null)
        {
            Debug.Log("CarChange Load Faild : " + prefabName);
            return null;
        }
        obj.transform.SetParent(CarSpawnPos);
        obj.transform.position = CarSpawnPos.position;
        obj.SetActive(true);
        return obj.GetComponent<CarController>();

    }
}
