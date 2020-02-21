using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/TextTable")]
    public static void CreateTextTableAssetFile()
    {
        TextTable asset = CustomAssetUtility.CreateAsset<TextTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "TextTable";
        EditorUtility.SetDirty(asset);        
    }
    
}