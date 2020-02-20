public class WallInfo
{
    public string id {get;}
    public int index {get;}

    public string model {get;}
    public string color {get;}
    public string vfx {get;}

    public int def {get;}
    public int exp {get;}
    public int gold {get;}
    public int dia {get;}
    public int diaPer {get;}
    
    public WallInfo(WallTableData _data)
    {
        this.id = _data.ID;
        this.index = _data.Index;

        this.model = _data.Model;
        this.color = _data.Color;
        this.vfx = _data.VFX;

        this.def = _data.Def;
        this.exp = _data.Exp;
        this.gold = _data.Gold;
        this.dia = _data.Dia;
        this.diaPer = _data.Diaper;
    }
}
