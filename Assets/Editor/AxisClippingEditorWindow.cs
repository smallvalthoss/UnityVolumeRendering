using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AxisClippingEditorWindow : EditorWindow
{
    private GameObject CutoutObject;
    private void OnEnable()
    {
        CutoutObject = Instantiate(GameObject)
    }

    private void OnDisable()
    {
        
    }
}
