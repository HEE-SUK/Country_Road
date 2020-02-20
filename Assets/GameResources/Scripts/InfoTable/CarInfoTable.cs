using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfoTable : IInfoTable<CarInfo, CarTableData>
{
    private Dictionary<string, CarInfo> carInfoDictionary = new Dictionary<string, CarInfo>();

    private string tableName = "CarTable";
    public CarInfoTable()
    {
        CarTable carTable = Resources.Load($"DataTable/{this.tableName}", typeof(CarTable)) as CarTable;
        foreach (var data in carTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    
    public CarInfo GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.carInfoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.carInfoDictionary.ContainsKey(_id);
    }

    public int GetLength() 
    {
        return this.carInfoDictionary.Count;
    }

    public void AddInfo(CarTableData _data)
    {   
        CarInfo carInfo = new CarInfo(_data);
        this.carInfoDictionary.Add(carInfo.id, carInfo);
    }
}
