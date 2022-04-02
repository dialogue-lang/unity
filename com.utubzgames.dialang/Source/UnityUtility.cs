using UnityEngine;
using System.Collections.Generic;


#if UNITY_EDITOR
using UnityEditor;
using Dialang.Compilation;
#endif

namespace Dialang.Unity
{
    public delegate void DialangProjectReimportedHandle(Project project);
    public static class UnityUtility
    {
        /// <summary>
        /// Called when a DiaLang project gets updated.
        /// </summary>
        public static event DialangProjectReimportedHandle ProjectUpdated;

        public static void InvokeProjectUpdated(Project project)
        {
#if UNITY_EDITOR
            ProjectUpdated?.Invoke(project);
#endif
        }

        /// <summary>
        /// Gets the full OS directory from the provided path from the root Unity directory.
        /// </summary>
        /// <param name="assetPath">The relative path located in the project directory.</param>
        /// <returns>The combined directory of the path leading to the project directory and the provided path.</returns>
        public static string GetFullPath(string assetPath)
        {
#if UNITY_EDITOR
            return System.IO.Path.Join(System.IO.Path.GetDirectoryName(Application.dataPath), assetPath).Replace('\\', '/');
#else
            Debug.LogError("You cannot run editor code outside of the editor.");
            return "";
#endif
        }

        /// <summary>
        /// Compiles all found DiaLang projects within the Unity project.
        /// </summary>
#if UNITY_EDITOR
        [MenuItem("Window/DiaLang/Compile Projects")]
#endif
        public static void CompileAllProjects()
        {
#if UNITY_EDITOR
            string[] assets = AssetDatabase.FindAssets("t:DialangProjectAsset");
            if (assets.Length < 0)
            {
                Debug.LogWarning("No DiaLang projects found. Try adding a .dlgproj file to your assets directory.");
                return;
            }

            for (int i = 0; i < assets.Length; i++)
            {
                Compiler c = new Compiler(GetFullPath(AssetDatabase.GUIDToAssetPath(assets[i])), DummyLog);
                CompileResult r = c.Compile(System.IO.Path.Combine(Application.dataPath, "Dialogue"));
                
                Debug.Log($"{c.Project.Name}: {r}");
            }

            AssetDatabase.Refresh();
#else
            Debug.LogError("You cannot run editor code outside of the editor.");
#endif
        }

#if UNITY_EDITOR
        private static void DummyLog(string msg)
        {
        }
#endif
    }
}
