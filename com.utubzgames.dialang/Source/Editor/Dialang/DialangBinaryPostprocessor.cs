using UnityEngine;
using UnityEditor;

namespace Dialang.Unity.Editor
{
    public class DialangBinaryPostprocessor : AssetPostprocessor
    {
        public static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFromAssetPaths)
        {
            foreach (string str in imported)
            {
                if (str.EndsWith(".dlgscr"))
                {
                    UnityUtility.CompileAllProjects();
                }

                if (str.EndsWith(".dlg"))
                {
                    UnityUtility.InvokeProjectUpdated(Project.Parse(System.IO.File.OpenRead(UnityUtility.GetFullPath(str))));
                }
            }
        }
    }
}
