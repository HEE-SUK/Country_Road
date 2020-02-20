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
[CustomEditor(typeof(RhythmTable))]
public class RhythmTableEditor : BaseGoogleEditor<RhythmTable>
{	    
    public override bool Load()
    {        
        RhythmTable targetData = target as RhythmTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<RhythmTableData>(targetData.WorksheetName) ?? db.CreateTable<RhythmTableData>(targetData.WorksheetName);
        
        List<RhythmTableData> myDataList = new List<RhythmTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            RhythmTableData data = new RhythmTableData();
            
            data = Cloner.DeepCopy<RhythmTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
