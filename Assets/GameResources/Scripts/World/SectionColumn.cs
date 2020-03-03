using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SectionColumn : MonoBehaviour
{
    private SectionRow[] rows = {};

    private void Awake()
    {
        this.rows = this.GetComponentsInChildren<SectionRow>();
        foreach (var row in this.rows)
        {
            row.transform.localPosition = new Vector3(row.transform.localPosition.x, -20f, row.transform.localPosition.z);
        }
    }

    public void Init()
    {
        // 랜덤하게 배치
        this.rows = Utility.ShuffleArray<SectionRow>(this.rows);
        this.StartCoroutine(this.StartInit());
    }
    
    private IEnumerator StartInit()
    {
        foreach (var row in this.rows)
        {
            row.Init();
            yield return new WaitForSeconds(0.01f);
        }
    }

}
