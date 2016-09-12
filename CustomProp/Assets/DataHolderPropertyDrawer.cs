using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(DataHolder))]
public class DataHolderPropertyDrawer : PropertyDrawer
{
	private int fieldCount = 0;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.serializedObject.targetObject == null)
		{
			EditorGUI.PropertyField(position, property, label);
			return;
		}

		if (property.type != "DataHolder")
			return;

		SerializedProperty original = property.Copy();
		fieldCount = property.CountRemaining() + 1;
		Rect posRect = new Rect(position.x, position.y, 200, position.height / fieldCount);

		property = original;
		EditorGUI.LabelField(posRect, new GUIContent(property.type));
		property.Next(true);

		posRect.y += posRect.height;
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 1;

		do
		{
			DrawPropertyField(property, ref posRect);
			position.height += EditorGUIUtility.singleLineHeight;
		} while (property.Next(false) && property.depth > 0);

		property.Reset();

		EditorGUI.indentLevel = indent;
	}

	void DrawPropertyField(SerializedProperty property, ref Rect r)
	{
		EditorGUI.PrefixLabel(r, new GUIContent(property.displayName));
		r.x += EditorGUIUtility.labelWidth;
		EditorGUI.BeginChangeCheck();
		EditorGUI.PropertyField(r, property, GUIContent.none);
		EditorGUI.EndChangeCheck();
		r.x -= EditorGUIUtility.labelWidth;

		r.y += r.height;
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight(property, label) * fieldCount;
	}
}
