using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UnityGameTooling.Editor.game_tooling.Scripts.Editor.Provider
{
    public sealed class TutorialStepList : ReorderableList
    {
        public TutorialStepList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
            drawHeaderCallback += DrawHeaderCallback;
            drawElementCallback += DrawElementCallback;
        }

        private void DrawHeaderCallback(Rect rect)
        {
            GUI.Label(rect, "Tutorial Steps", EditorStyles.boldLabel);
        }

        private void DrawElementCallback(Rect rect, int i, bool isactive, bool isfocused)
        {
            var property = serializedProperty.GetArrayElementAtIndex(i);
            var identifierProperty = property.FindPropertyRelative("identifier");
            var dialogProperty = property.FindPropertyRelative("dialog");
                
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 200f, 20f), identifierProperty, GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + 205f, rect.y, rect.width - 205f, 20f), dialogProperty, GUIContent.none);
        }
    }
}