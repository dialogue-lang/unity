using UnityEngine;
using UnityEditor.AssetImporters;

using System.IO;

namespace Dialang.Unity.Editor
{
    [ScriptedImporter(0, "dlg")]
    public class DialangBinaryImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            Project project = Project.Parse(File.OpenRead(UnityUtility.GetFullPath(ctx.assetPath)), true);
            DialangBinaryAsset asset = ScriptableObject.CreateInstance<DialangBinaryAsset>();
            asset.Set(project);

            ctx.AddObjectToAsset("Dialang Binary", asset);
            ctx.SetMainObject(asset);
        }
    }
}
