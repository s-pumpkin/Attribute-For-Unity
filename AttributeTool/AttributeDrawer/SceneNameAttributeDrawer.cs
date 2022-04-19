using Attribute.ListToPopup;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneNameAttribute : ListToPopupAttribute
{
    public SceneNameAttribute() { }
}


[CustomPropertyDrawer(typeof(SceneNameAttribute))]
public class SceneNameAttributeDrawer : ListToPopupAttributeDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
    }

    public override List<string> StringList(ListToPopupAttribute trager)
    {
        List<string> stringList = new List<string>();

        foreach (var scene in EditorBuildSettings.scenes)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scene.path);
            stringList.Add(sceneName);
        }

        return stringList;
    }
}

