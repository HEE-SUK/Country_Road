public class SectionInfo
{
    public string id {get;}
    public int index {get;}
    public int themeIndex {get;}

    public bool wallBool {get;}
    public string wallID {get;}
    public bool rhyBool {get;}
    public string rhythmID {get;}
    
    public string checkPointID {get;}
    public string zombieID {get;}
    public float zombieInterval {get;}
    
    public SectionInfo(SectionTableData _data)
    {
        this.id = _data.SID;
        this.index = _data.Index;
        this.themeIndex = _data.Themeindex;

        this.wallBool = _data.Wallbool;
        this.wallID = _data.Wallid;
        this.rhyBool = _data.Rhybool;
        this.rhythmID = _data.Rhythmid;

        this.checkPointID = _data.Checkpointid;
        this.zombieID = _data.Zombieid;
        this.zombieInterval = _data.Zombieinterval;
    }
}
