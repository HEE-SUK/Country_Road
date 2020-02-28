public class LocalizeInfo
{
    public string id {get;}
    public string en {get;}
    public string ko {get;}
    public string zhTW {get;}
    public string zh {get;}
    public string ja {get;}
    public string es {get;}

    public LocalizeInfo(LocalizeTableData _data)
    {
        this.id = _data.ID;
        
        this.en = _data.En;
        this.ko = _data.Ko;
        this.zhTW = _data.Zhtw;
        this.zh = _data.Zh;
        this.ja = _data.Ja;
        this.es = _data.Es;
    }
}
