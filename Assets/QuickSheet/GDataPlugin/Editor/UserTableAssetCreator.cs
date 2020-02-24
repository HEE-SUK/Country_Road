using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/UserTable")]
    public static void CreateUserTableAssetFile()
    {
        UserTable asset = CustomAssetUtility.CreateAsset<UserTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "UserTable";
        EditorUtility.SetDirty(asset);        
    }
    
}