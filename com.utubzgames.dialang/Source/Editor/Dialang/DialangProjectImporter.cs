using UnityEngine;
using UnityEditor.AssetImporters;

namespace Dialang.Unity.Editor
{
    [ScriptedImporter(0, "dlgproj")]
    public class DialangProjectImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            DialangProjectAsset asset = ScriptableObject.CreateInstance<DialangProjectAsset>();
            asset.Set(ctx.assetPath);

            ctx.AddObjectToAsset("Dialang Project", asset);
            ctx.SetMainObject(asset);
        }
    }
}
