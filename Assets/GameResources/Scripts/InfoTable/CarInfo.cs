public class CarInfo
{
    
    public string id {get;}
    public int index {get;}

    public string name {get;}
    public string description {get;}
    public string image {get;}
    public string model {get;}
    public string color {get;}
    public string vfx {get;}

    public int def {get;}
    public int mSpd {get;}
    public int rhm {get;}
    public int atk {get;}
    public int reload {get;}
    public int price {get;}

    public UNITTYPE unitType {get;}
    public float lotto {get;}
    
    public CarInfo(CarTableData _data)
    {
        this.id = _data.ID;
        this.index = _data.Index;

        this.name = _data.Name;
        this.description = _data.Description;
        this.image = _data.Image;
        this.model = _data.Model;
        this.color = _data.Color;
        this.vfx = _data.VFX;

        this.def = _data.Def;
        this.mSpd = _data.Mspd;
        this.rhm = _data.Rhm;
        this.atk = _data.Atk;
        this.reload = _data.Reload;
        this.price = _data.Price;
        
        this.unitType = _data.UNITTYPE;
        this.lotto = _data.Lotto;
    }
}
