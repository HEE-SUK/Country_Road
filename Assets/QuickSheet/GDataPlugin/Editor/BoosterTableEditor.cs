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
[CustomEditor(typeof(BoosterTable))]
public class BoosterTableEditor : BaseGoogleEditor<BoosterTable>
{	    
    public override bool Load()
    {        
        BoosterTable targetData = target as BoosterTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<BoosterTableData>(targetData.WorksheetName) ?? db.CreateTable<BoosterTableData>(targetData.WorksheetName);
        
        List<BoosterTableData> myDataList = new List<BoosterTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            BoosterTableData data = new BoosterTableData();
            
            data = Cloner.DeepCopy<BoosterTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
