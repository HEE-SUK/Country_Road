using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfoTable : InfoTable<CarInfo>
{
    private string tableName = "CarTable";
    public CarInfoTable()
    {
        CarTable carTable = Resources.Load($"DataTable/{this.tableName}", typeof(CarTable)) as CarTable;
        foreach (var data in carTable.dataArray)
        {
            this.AddInfo(data);
        }
    }

    public void AddInfo(CarTableData _data)
    {   
        CarInfo carInfo = new CarInfo(_data);
        this.infoDictionary.Add(carInfo.id, carInfo);
    }
}
