using UnityEngine;
using UnityEditor;

namespace Dialang.Unity.Editor
{
    [CustomEditor(typeof(DialangScriptAsset))]
    public class DialangScriptEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
        }
    }
}
