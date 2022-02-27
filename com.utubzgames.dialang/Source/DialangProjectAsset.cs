using UnityEngine;

namespace Dialang.Unity
{
    public sealed class DialangProjectAsset : ScriptableObject
    {
        public string Value { get; private set; }

        public void Set(string path)
        {
            Value = path;
        }
    }
}
