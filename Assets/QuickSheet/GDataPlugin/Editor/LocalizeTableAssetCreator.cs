using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/LocalizeTable")]
    public static void CreateLocalizeTableAssetFile()
    {
        LocalizeTable asset = CustomAssetUtility.CreateAsset<LocalizeTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "LocalizeTable";
        EditorUtility.SetDirty(asset);        
    }
    
}