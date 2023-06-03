using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class floatingJoystick : MonoBehaviour
{
    [HideInInspector]
    public RectTransform RectTransform;
    public RectTransform Knob;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}
