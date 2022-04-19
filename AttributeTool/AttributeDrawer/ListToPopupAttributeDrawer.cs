using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Attribute.ListToPopup;
using System;

namespace Attribute.ListToPopup
{
    public class ListToPopupAttribute : PropertyAttribute
    {
        public Type MyType;
        public string PropertyName;

        public ListToPopupAttribute() { }

        /// <summary>
        /// staticList
        /// </summary>
        /// <param name="_MyType"></param>
        /// <param name="_PropertyName"></param>
        public ListToPopupAttribute(Type _MyType, string _PropertyName)
        {
            MyType = _MyType;
            PropertyName = _PropertyName;
        }
    }
}

[CustomPropertyDrawer(typeof(ListToPopupAttribute))]
public class ListToPopupAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ListToPopupAttribute trager = attribute as ListToPopupAttribute;
        List<string> stringList = new List<string>();

        stringList = StringList(trager);

        if (stringList != null && stringList.Count != 0)
        {
            int selectedIndex = Mathf.Max(stringList.IndexOf(property.stringValue), 0);
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, stringList.ToArray());
            property.stringValue = stringList[selectedIndex];
        }
        else EditorGUI.PropertyField(position, property, label);
    }

    public virtual List<string> StringList(ListToPopupAttribute trager)
    {
        List<string> stringList = new List<string>();

        if (trager.MyType.GetField(trager.PropertyName) != null)
        {
            stringList = trager.MyType.GetField(trager.PropertyName).GetValue(trager.MyType) as List<string>;
        }

        return stringList;
    }
}
