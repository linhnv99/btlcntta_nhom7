using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class AddText : MonoBehaviour
{
    [SerializeField, Range(0,14)] public int index;
    public int Index { get =>index; set=>index = value; }
    TMP_Text text;
    private void OnEnable() {
        text = this.GetComponent<TMP_Text>();
    }
    public void CustomText(string content)
    {
        text.text = content;
        text.fontSize = 1;
        text.color = new Color(0,0,0,1);
    }
}



[CustomEditor(typeof(AddText))]
public class AddTextEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        AddText mytext = (AddText)target;
        if(GUILayout.Button("Custom"))
        {
            string s= "";
            if(mytext.Index ==0)
                s="Phòng công tác sinh viên";
            else if(mytext.Index == 1)
                s="Phòng nhân sự";
            else if(mytext.Index == 2)
                s="Phòng nhân sự";
            else if(mytext.Index == 3)
                s="Phòng nhân sự";
            else if(mytext.Index == 4)
                s="Phòng nhân sự";
            else if(mytext.Index == 5)
                s="Phòng nhân sự";
            else if(mytext.Index == 6)
                s="Phòng nhân sự";
            else if(mytext.Index == 7)
                s="Phòng nhân sự";
            else if(mytext.Index == 8)
                s="Phòng nhân sự";
            else if(mytext.Index == 9)
                s="Phòng nhân sự";
            else if(mytext.Index == 10)
                s="Phòng nhân sự";
            mytext.CustomText(s);
        }
    }
}
