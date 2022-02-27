using UnityEngine;

using System.IO;

using Dialang;

namespace Dialang.Unity
{
    public sealed class DialangBinaryAsset : ScriptableObject
    {
        public Project Value { get; private set; }

        public void Set(Project project)
        {
            Value = project;
        }
    }
}
