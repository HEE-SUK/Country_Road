using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/SectionTable")]
    public static void CreateSectionTableAssetFile()
    {
        SectionTable asset = CustomAssetUtility.CreateAsset<SectionTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "SectionTable";
        EditorUtility.SetDirty(asset);        
    }
    
}