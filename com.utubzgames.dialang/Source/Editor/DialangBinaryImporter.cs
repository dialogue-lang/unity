using UnityEngine;
using UnityEditor.AssetImporters;

using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Dialang.Unity.Editor
{
    [ScriptedImporter(0, "dlg")]
    public class DialangBinaryImporter : ScriptedImporter
    {
        private class DialangBinaryImportException : System.Exception
        {
            public DialangBinaryImportException() : base("DiaLang project could not be imported properly.")
            {

            }
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            Project project = Project.Parse(File.OpenRead(UnityUtility.GetFullPath(ctx.assetPath)), true);

            if (project == null)
                Throw();

            DialangBinaryAsset asset = ScriptableObject.CreateInstance<DialangBinaryAsset>();
            asset.Set(project);

            ctx.AddObjectToAsset("Dialang Binary", asset);
            ctx.SetMainObject(asset);
        }

        private void Throw()
        {
            throw new DialangBinaryImportException();
        }
    }
}
