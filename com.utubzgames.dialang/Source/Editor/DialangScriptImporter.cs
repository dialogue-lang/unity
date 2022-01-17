using UnityEngine;
using UnityEditor.AssetImporters;

using System.IO;

using Dialang.Compilation.IO;

namespace Dialang.Unity.Editor
{
    [ScriptedImporter(0, "dlgscr")]
    public class DialangScriptImporter : ScriptedImporter
    {
        private void Log(string msg)
        {
            
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            DocumentParser parser = new DocumentParser(File.ReadAllText(ctx.assetPath), Log);
            DialangScriptAsset asset = ScriptableObject.CreateInstance<DialangScriptAsset>();
            asset.Set(parser.Parse());
            parser.Dispose();

            ctx.AddObjectToAsset("Dialang Document", asset);
            ctx.SetMainObject(asset);
        }
    }
}
