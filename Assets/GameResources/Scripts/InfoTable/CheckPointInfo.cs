public class CheckPointInfo
{
    public string id {get;}
    public int index {get;}

    public string name {get;}
    public string image {get;}

    
    public int distance {get;}
    public int gold {get;}
    public int dia {get;}
    public int exp {get;}
    
    public CheckPointInfo(CheckPointTableData _data)
    {
        this.id = _data.ID;
        this.index = _data.Index;

        this.name = _data.Name;
        this.image = _data.Image;
        
        this.distance = _data.Distance;
        this.gold = _data.Gold;
        this.dia = _data.Dia;
        this.exp =_data.Exp;
    }
}
