public class SectionInfo
{
    public string id {get;}
    public int index {get;}

    public int sectionBlocks {get;}
    public int rhyChance {get;}
    public string model {get;}
    public string color {get;}

    public string wallID {get;}
    public string rhythmID {get;}
    public string checkPointID {get;}
    public string themeID {get;}
    public string zombieID {get;}
    public float zombieInterval {get;}
    
    public SectionInfo(SectionTableData _data)
    {
        this.id = _data.SID;
        this.index = _data.Index;

        this.sectionBlocks = _data.Sectionblocks;
        this.rhyChance = _data.Rhychance;
        this.model = _data.Model;
        this.color = _data.Color;

        this.wallID = _data.Wallid;
        this.rhythmID = _data.Rhythmid;
        this.checkPointID = _data.Checkpointid;
        this.themeID = _data.Themeid;
        this.zombieID = _data.Zombieid;
        this.zombieInterval = _data.Zombieinterval;
    }
}
