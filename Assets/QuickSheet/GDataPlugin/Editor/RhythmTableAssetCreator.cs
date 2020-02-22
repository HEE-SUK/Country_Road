using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/RhythmTable")]
    public static void CreateRhythmTableAssetFile()
    {
        RhythmTable asset = CustomAssetUtility.CreateAsset<RhythmTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "RhythmTable";
        EditorUtility.SetDirty(asset);        
    }
    
}