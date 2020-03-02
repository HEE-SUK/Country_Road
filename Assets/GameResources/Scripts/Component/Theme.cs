using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    [SerializeField] private GameObject[] sections = null;

    public void Init()
    {
        // 모두 disable 시키기
        DisableObjectArr(sections);
        // 랜덤 엑티브 
        sections[Random.Range(0, sections.Length)].SetActive(true);
    }

    private void DisableObjectArr(GameObject[] objArr)
    {
        if (objArr.Length == 0)
        {
            Debug.Log("DisableObjectArr Failed, objArr.Length is " + objArr.Length);
            return;
        }
        for (int i = 0; i < objArr.Length; i++)
        {
            objArr[i].SetActive(false);
        }
    }
}
