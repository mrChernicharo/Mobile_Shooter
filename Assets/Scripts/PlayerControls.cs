using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 offset;

    private float maxTop;
    private float maxBottom;
    private float maxLeft;
    private float maxRight;

    void Start()
    {
        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                offset = touchPos - transform.position;
            }

            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            // movement restriction
            float minMaxX = Mathf.Clamp(transform.position.x, maxLeft, maxRight);
            float minMaxY = Mathf.Clamp(transform.position.y, maxBottom, maxTop);
            transform.position = new Vector3(minMaxX, minMaxY, 0);
        }
    }

    private IEnumerator SetBoundaries()
    {
        // accessing mainCam.ViewportToWorldPoint in start doesn't give Cinemachine enough time
        // to adjust the VirtualCamera to the viewport, that's why we create a coroutine here.

        // wait...
        yield return new WaitForSeconds(0.4f);

        // ...then
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0f)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0f)).x;
        maxTop = mainCam.ViewportToWorldPoint(new Vector2(0f, 0.85f)).y;
        maxBottom = mainCam.ViewportToWorldPoint(new Vector2(0f, 0.15f)).y;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}

/*

Viewport

ViewportSpace is relative to the camera

(0,1)   (1,1)
 ___________
 |         |
 |         |
 |         |
 |    x    |
 | (.5,.5) |
 |         |
 |         |
 ___________
(0,0)  (1,0)

*/