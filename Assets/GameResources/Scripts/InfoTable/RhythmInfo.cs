public class RhythmInfo
{
    public string id {get;}
    public int index {get;}

    public float barSize1 {get;}
    public float barSize2 {get;}
    public float spd {get;}
    
    public RhythmInfo(RhythmTableData _data)
    {
        this.id = _data.RID;
        this.index = _data.Index;

        this.barSize1 = _data.Barsize1;
        this.barSize2 = _data.Barsize2;
        this.spd = _data.Spd;
    }
}
