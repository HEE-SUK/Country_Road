public class ZombieInfo
{
    public string id {get;}
    public int index {get;}

    public string model {get;}
    public string color {get;}
    public string vfx {get;}

    public int zone {get;}
    public int interval {get;}

    public int hp {get;}
    public int atk {get;}
    public float spd {get;}
    public int exp {get;}
    public int gold {get;}
    public int dia {get;}
    public int diaPer {get;}
    
    public ZombieInfo(ZombieTableData _data)
    {
        this.id = _data.ID;
        this.index = _data.Index;

        this.model = _data.Model;
        this.color = _data.Color;
        this.vfx = _data.VFX;

        // this.zone = _data.Zone;
        // this.interval = _data.Interval;

        this.hp = _data.Hp;
        this.atk = _data.Atk;
        this.spd = _data.Spd;
        this.exp = _data.Exp;
        this.gold = _data.Gold;
        this.dia = _data.Dia;
        this.diaPer = _data.Diaper;
    }
}
