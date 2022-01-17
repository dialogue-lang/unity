using UnityEngine;
using UnityEditor;

namespace Dialang.Unity.Editor
{
    [CustomEditor(typeof(DialangProjectAsset))]
    public class DialangProjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
        }
    }
}
