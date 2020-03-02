using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private BlockObjectSet blockObjectSet;
    private Vector3 endPos = new Vector3(0f, 0f, 0f);
    private EndPosAction endPosAction = null;
    public void Init(Vector3 endPos, EndPosAction endPosCallback, BlockObjectSettingInfo settingInfo)
    {
        this.endPos = endPos;
        this.endPosAction = endPosCallback;
        SetBlockObject(settingInfo);
    }
    public void SetBlockObject(BlockObjectSettingInfo settingInfo)
    {
        blockObjectSet.SetBlock(settingInfo);
    }

    void Awake()
    {
        if (this.blockObjectSet == null)
            blockObjectSet = GetComponent<BlockObjectSet>();
    }
    void Update()
    {
        if (transform.position.z < endPos.z)
        {
            if (endPosAction != null)
            {
                endPosAction(this);
                return;
            }
        }
    }
}
