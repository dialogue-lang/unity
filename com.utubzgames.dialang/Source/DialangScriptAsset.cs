using UnityEngine;
using System.Collections;

using Dialang;

namespace Dialang.Unity
{
    public sealed class DialangScriptAsset : ScriptableObject
    {
        public Hashtable Value { get; private set; }

        public void Set(Hashtable table)
        {
            Value = table;
        }
    }
}
