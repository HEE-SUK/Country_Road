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
[CustomEditor(typeof(TextTable))]
public class TextTableEditor : BaseGoogleEditor<TextTable>
{	    
    public override bool Load()
    {        
        TextTable targetData = target as TextTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<TextTableData>(targetData.WorksheetName) ?? db.CreateTable<TextTableData>(targetData.WorksheetName);
        
        List<TextTableData> myDataList = new List<TextTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            TextTableData data = new TextTableData();
            
            data = Cloner.DeepCopy<TextTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
