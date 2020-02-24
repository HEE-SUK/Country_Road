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
[CustomEditor(typeof(UserTable))]
public class UserTableEditor : BaseGoogleEditor<UserTable>
{	    
    public override bool Load()
    {        
        UserTable targetData = target as UserTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<UserTableData>(targetData.WorksheetName) ?? db.CreateTable<UserTableData>(targetData.WorksheetName);
        
        List<UserTableData> myDataList = new List<UserTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            UserTableData data = new UserTableData();
            
            data = Cloner.DeepCopy<UserTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
