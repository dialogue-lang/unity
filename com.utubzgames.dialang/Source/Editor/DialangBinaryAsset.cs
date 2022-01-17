using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;

using System.IO;

using Dialang;

namespace Dialang.Unity.Editor
{
    public sealed class DialangBinaryAsset : ScriptableObject
    {
        public Project Value { get; private set; }

        internal void Set(Project project)
        {
            Value = project;
        }
    }
}
