public class UpgradeInfo
{
    public string id {get;}
    public int index {get;}

    public float bumper {get;}
    public float booster {get;}
    public float tire {get;}
    public float pricefactor {get;}

    public UpgradeInfo(UpgradeTableData _data)
    {
        this.id = _data.ID;
        this.index = _data.Index;
        
        this.bumper = _data.Bumper;
        this.booster = _data.Booster;
        this.tire = _data.Tire;
        this.pricefactor = _data.Pricefactor;
    }
}
