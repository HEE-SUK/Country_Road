using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoosterPanel : MonoBehaviour
{
    [SerializeField]
    private TouchPanel touchPanel = null;
    [SerializeField]
    private BoosterGauge boosterGauge = null;

    private BoosterInfo boosterInfo = null;

    void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        
        // for DEBUG 좀더 뚜렷한 로직 필요
        this.boosterInfo = TableManager.BoosterInfoTable.GetInfo("B001");
        this.gameObject.SetActive(true);
        this.boosterGauge.Init(this.boosterInfo.barSize1, this.boosterInfo.barSize2);

        this.touchPanel.Init(this.StartTouch, this.EndTouch);
    }
    private void StartTouch()
    {
        // TODO: 누르는 효과!
    }

    private void EndTouch()
    {
        float extraSpeed = 0f;
        switch (this.boosterGauge.Stop())
        {
            case BOOSTERTYPE.GOOD:
                extraSpeed = this.boosterInfo.spd1;
                break;
            case BOOSTERTYPE.GREAT:
                extraSpeed = this.boosterInfo.spd2;
                break;
            default:
                extraSpeed = this.boosterInfo.spd3;
                break;
        }
        EventManager.emit(EVENT_TYPE.TOUCH_BOOSTER, this, extraSpeed);
        this.gameObject.SetActive(false);
    }
}
