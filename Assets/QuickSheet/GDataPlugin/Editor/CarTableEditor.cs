using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(CarTable))]
public class CarTableEditor : BaseGoogleEditor<CarTable>
{	    
    public override bool Load()
    {        
        CarTable targetData = target as CarTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<CarTableData>(targetData.WorksheetName) ?? db.CreateTable<CarTableData>(targetData.WorksheetName);
        
        List<CarTableData> myDataList = new List<CarTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            CarTableData data = new CarTableData();
            
            data = Cloner.DeepCopy<CarTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
