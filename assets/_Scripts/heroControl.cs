using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroControl : MonoBehaviour
{

    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA; // starting point for joystick (where finger is pressed)
    private Vector2 pointB; // endin

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // on click, record point A to wherever we touched
        if (Input.GetMouseButtonDown(0))
        {

            pointA = Input.mousePosition;// returns 


        }

        // on hold, record point B to wherever mouse moves to  
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            Debug.Log("holding");
            pointB = Input.mousePosition;
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {


        // calculate the offset between initial push and where you dragged it to
        if (touchStart)
        {
            Debug.Log("fixedUpdate\n");
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f); // takes offset and sets magnitude to constant while maintaining direction
            moveHero(direction); //accounts for camera coordinates

        }
    }

    void moveHero(Vector2 direction)
    {
        // direction is the input from the joystick (which needs vector2)
        // speed will be a public float
        // time.deltaTime is for frame rate
        player.Translate(direction * speed * Time.deltaTime);
    }
}




