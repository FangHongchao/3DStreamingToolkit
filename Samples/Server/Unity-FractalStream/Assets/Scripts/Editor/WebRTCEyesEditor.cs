﻿using UnityEditor;
using UnityEngine;

namespace Microsoft.Toolkit.ThreeD
{
    /// <summary>
    /// Custom editor for <see cref="WebRTCEyes"/>
    /// </summary>
    [CustomEditor(typeof(WebRTCEyes))]
    public class WebRTCEyesEditor : Editor
    {
        /// <summary>
        /// Unity inspector hook
        /// </summary>
        /// <remarks>
        /// This allows us to modify the behavior to show EyeTwo only if TotalEyes == EyeCount.Two
        /// </remarks>
        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            var totalEyes = serializedObject.FindProperty("TotalEyes");

            EditorGUILayout.PropertyField(totalEyes);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("EyeOne"));

            if (totalEyes.enumValueIndex == (int)WebRTCEyes.EyeCount.Two)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("EyeTwo"));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
