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

    public int bumper {get;}
    public int booster {get;}
    public float tire {get;}
    public int atk {get;}
    public float atkSpd {get;}
    public int bullet {get;}
    public int reload {get;}

    public int price {get;}
    public int convertPrice {get;}

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

        this.bumper = _data.Bumper;
        this.booster = _data.Booster;
        this.tire = _data.Tire;
        this.atk = _data.Atk;
        this.atkSpd = _data.Atkspd;
        this.bullet = _data.Bullet;
        this.reload = _data.Reload;

        this.convertPrice = _data.Convertprice;
        this.price = _data.Price;
        
        this.unitType = _data.UNITTYPE;
        this.lotto = _data.Lotto;
    }
}
