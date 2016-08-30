using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Event))]
public class EventEditor : Editor {

    // should provide easy UI to make an event as well as enforce restrictions such as one event per gameobject.

    public SerializedProperty addChildrenToOptions;
    public SerializedObject myTarget;

    void Start()
    {
        Event targetEvent = (Event)target;
        myTarget = new SerializedObject(target);

    }

    public override void OnInspectorGUI()
    {
        Event targetEvent = (Event)target;
        if (targetEvent.gameObject.GetComponents<Event>()[0] != targetEvent)
        {
            Destroy(targetEvent);
            return;
        }

        targetEvent.optionText = EditorGUILayout.TextField("Button Text", targetEvent.optionText);

        targetEvent.addChildrenToOptions = EditorGUILayout.Toggle("Add children Events to options", targetEvent.addChildrenToOptions);

        EditorGUILayout.LabelField("Available options :");

        for( int i = 0; i < targetEvent.options.Count; ++i)
        {
            Event e = targetEvent.options[i];
            if (EditorGUILayout.ObjectField(e.optionText, e.gameObject, typeof(GameObject), true) == null)
                targetEvent.options.RemoveAt(i--);
        }
        if (targetEvent.addChildrenToOptions)
        {
            foreach (Transform t in targetEvent.transform)
            {
                Event e = t.gameObject.GetComponent<Event>();
                if (e != null)
                    EditorGUILayout.ObjectField(e.optionText, e.gameObject, typeof(GameObject), true);
            }
        }

        GameObject newOption = (GameObject)EditorGUILayout.ObjectField("Add Event: ", null, typeof(GameObject), true);
        if (newOption != null)
        {
            Event newEvent = newOption.GetComponent<Event>();
            if (newEvent != null)
                targetEvent.options.Add(newEvent);
        }

    }
}
