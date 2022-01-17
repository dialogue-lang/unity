using UnityEngine;
using System.Collections;

using Dialang;

namespace Dialang.Unity.Editor
{
    public sealed class DialangScriptAsset : ScriptableObject
    {
        public Hashtable Value { get; private set; }

        internal void Set(Hashtable table)
        {
            Value = table;
        }
    }
}
