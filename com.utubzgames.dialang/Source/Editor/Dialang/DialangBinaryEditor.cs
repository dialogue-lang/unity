using UnityEngine;
using UnityEditor;

namespace Dialang.Unity.Editor
{
    [CustomEditor(typeof(DialangBinaryAsset))]
    public class DialangBinaryEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
        }
    }
}
