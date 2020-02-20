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
[CustomEditor(typeof(WallTable))]
public class WallTableEditor : BaseGoogleEditor<WallTable>
{	    
    public override bool Load()
    {        
        WallTable targetData = target as WallTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<WallTableData>(targetData.WorksheetName) ?? db.CreateTable<WallTableData>(targetData.WorksheetName);
        
        List<WallTableData> myDataList = new List<WallTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            WallTableData data = new WallTableData();
            
            data = Cloner.DeepCopy<WallTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
