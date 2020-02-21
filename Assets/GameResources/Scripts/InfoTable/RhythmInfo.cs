public class RhythmInfo
{
    public string id {get;}
    public int index {get;}

    public float barSize1 {get;}
    public float barSize2 {get;}
    public float barSize3 {get;}
    public float spd1 {get;}
    public float spd2 {get;}
    public float spd3 {get;}
    
    public RhythmInfo(RhythmTableData _data)
    {
        this.id = _data.RID;
        this.index = _data.Index;

        this.barSize1 = _data.Barsize1;
        this.barSize2 = _data.Barsize2;
        this.barSize3 = _data.Barsize3;
        this.spd1 = _data.Spd1;
        this.spd2 = _data.Spd2;
        this.spd3 = _data.Spd3;
    }
}
