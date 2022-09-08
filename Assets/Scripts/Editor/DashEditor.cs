
using UnityEngine;
using UnityEditor;
using UnityEditor.Search;
using System.Xml.Schema;

public class DashEditor : EditorWindow
{
    float zValue;
    float xValue;
    int count = 5;
    GameObject parent;

    [MenuItem("Window/Dash")]
    public static void ShowWindow()
    {
        GetWindow<DashEditor>("DashEditor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create From Selected Object.", EditorStyles.boldLabel);
        GUILayout.Label("X Value", EditorStyles.boldLabel);
        xValue = EditorGUILayout.FloatField(xValue);
        GUILayout.Label("Z Value", EditorStyles.boldLabel);
        zValue = EditorGUILayout.FloatField(zValue);
        Debug.Log("Z Value: " + zValue);
        GUILayout.Label("Count", EditorStyles.boldLabel);
        count = EditorGUILayout.IntField(count);
        parent = GameObject.FindGameObjectWithTag("Parent");

        if(GUILayout.Button("Create"))
        {
            foreach(GameObject obj in Selection.gameObjects)
            {
                for(int i = 0; i < count; i++)
                {
                    GameObject go = Instantiate(obj);
                    Vector3 pos = obj.transform.position;
                    pos.x += xValue * (i + 1);
                    pos.z += zValue * (i + 1);
                    go.transform.position = pos;
                    go.transform.SetParent(parent.transform);
                }
            }
        }

    }
}
