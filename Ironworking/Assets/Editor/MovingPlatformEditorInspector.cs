using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingPlatform))]
public class MovingPlatformEditorInspector : Editor
{
    SerializedProperty movementSpeed;
    SerializedProperty startingPoint;
    SerializedProperty rangePoints;
    SerializedProperty isPlatformAllowed;
    SerializedProperty playerTool;
    SerializedProperty numberTrigger;

    private void OnEnable()
    {
        movementSpeed = serializedObject.FindProperty("movementSpeed");
        startingPoint = serializedObject.FindProperty("startingPoint");
        rangePoints = serializedObject.FindProperty("rangePoints");
        isPlatformAllowed = serializedObject.FindProperty("isPlatformAllowed");
        playerTool = serializedObject.FindProperty("requiredTools");
        numberTrigger = serializedObject.FindProperty("npcCountTrigger");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(movementSpeed);
        EditorGUILayout.PropertyField(startingPoint);
        EditorGUILayout.PropertyField(rangePoints);
        EditorGUILayout.PropertyField(isPlatformAllowed);
        EditorGUILayout.PropertyField(playerTool);

        MovingPlatform movingPlatform = (MovingPlatform)target;

        // Check if the required tools are set to something other than NONE
        if (movingPlatform.requiredTools != PlayerTools.Tools.NONE)
        {
            EditorGUILayout.PropertyField(numberTrigger);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
