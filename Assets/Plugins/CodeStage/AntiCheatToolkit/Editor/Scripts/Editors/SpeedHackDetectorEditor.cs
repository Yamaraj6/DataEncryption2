#if UNITY_EDITOR
using CodeStage.AntiCheat.Detectors;
using UnityEditor;
using UnityEngine.UI;

namespace CodeStage.AntiCheat.EditorCode.Editors
{
	[CustomEditor(typeof (SpeedHackDetector))]
	internal class SpeedHackDetectorEditor : ActDetectorEditor
	{
		private SerializedProperty interval;
		private SerializedProperty maxFalsePositives;
		private SerializedProperty coolDown;
		private SerializedProperty text;

		protected override void FindUniqueDetectorProperties()
		{
			interval = serializedObject.FindProperty("interval");
			maxFalsePositives = serializedObject.FindProperty("maxFalsePositives");
			coolDown = serializedObject.FindProperty("coolDown");
			text = serializedObject.FindProperty("text");
		}

		protected override void DrawUniqueDetectorProperties()
		{
			EditorGUILayout.PropertyField(interval);
			EditorGUILayout.PropertyField(maxFalsePositives);
			EditorGUILayout.PropertyField(coolDown);
			EditorGUILayout.PropertyField(text);
		}
	}
}
#endif