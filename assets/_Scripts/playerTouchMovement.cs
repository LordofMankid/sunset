using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch; // use alias cuz of the 'touch' class is ambiguous in namespace thing (syntax weird stuff)

public class playerTouchMovement : MonoBehaviour
{
    public CharacterData data;
    // note for later: probably want to add to floating joystick class for later
    [SerializeField]
    private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField]
    private floatingJoystick Joystick;
    [SerializeField]
    private Rigidbody2D Player;
    [SerializeField]
    [Range(0, 100)] private float MaxSpeed = 2.75f;

    private Finger MovementFinger; // finger used as reference through all touch functions
    private Vector2 MovementAmount;

    private void OnEnable()
    {
     
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += Touch_onFingerDown;
        ETouch.Touch.onFingerMove += Touch_onFingerMove;
        ETouch.Touch.onFingerUp += Touch_onFingerUp;

    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= Touch_onFingerDown;
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
        ETouch.Touch.onFingerMove -= Touch_onFingerMove;
        
        EnhancedTouchSupport.Disable();
    }

    private void Touch_onFingerDown(Finger touchedFinger)
    {
        if(MovementFinger == null) // check if another finger isn't something, can add screen position limits for UI positions, etc 
        {
            MovementFinger = touchedFinger; // puts input finger into "reference" finger
           
            MovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            
            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
        }

    }


    // keeps joystick position within borders of scree
    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
        if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.y / 2)
        {
            StartPosition.y = JoystickSize.y / 2;
        } 
        else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.y / 2;
        }

        return StartPosition;
    }



    ///////////////////////

    /// <summary>
    ///  sets the speed values based on amount dragged
    ///  values will be between 1 and -1 
    /// </summary>
    /// <param name="movedFinger"></param>
    private void Touch_onFingerMove(Finger movedFinger)
    {
        if(movedFinger == MovementFinger) // checks if the input finger (when dragging) is the same as the "reference" finger (set on touch)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f; // off the joystick size
            ETouch.Touch currentTouch = movedFinger.currentTouch; // just for reference

            // check if we drag further than the joystick radius (centered at anchoredPosition, set in canvas)
            if (Vector2.Distance(
                    currentTouch.screenPosition, 
                    Joystick.RectTransform.anchoredPosition) 
                    > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition).normalized * maxMovement;
            } else
            {
                knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
            }

            Joystick.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;


        }


    }



    private void Touch_onFingerUp(Finger LostFinger)
    {
        if(LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }


    private void Update()
    {
        Vector3 scaledMovement = MaxSpeed * Time.deltaTime * new Vector3(
            MovementAmount.x,
            0,
            MovementAmount.y);

        
        //Player.transform.LookAt(Player.transform.position + scaledMovement, Vector3.up);

        Player.MovePosition(Player.position + MovementAmount * data.speed * Time.deltaTime); //rigidbody 2d movement ? 
    }
}
