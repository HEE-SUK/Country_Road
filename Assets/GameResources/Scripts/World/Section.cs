using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    private SectionColumn[] columns = {};
    private void Awake()
    {
        this.columns = this.GetComponentsInChildren<SectionColumn>();
    }
    private void Start()
    {
        this.Init();
    }
    public void Init()
    {
        // 순서대로 배치
        this.StartCoroutine(this.StartInit());
    }

    private IEnumerator StartInit()
    {
        foreach (var column in this.columns)
        {
            column.Init();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
