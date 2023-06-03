using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickUI : MonoBehaviour
{
    public RectTransform joystickObject;

    private void Start()
    {
        joystickObject = GetComponent<RectTransform>();

    }


} 
