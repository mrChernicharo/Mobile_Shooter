using UnityEngine;
using System.Collections;

public class BossBaseState : MonoBehaviour
{
    private Camera mainCam;

    private float maxTop;
    private float maxBottom;
    private float maxLeft;
    private float maxRight;

    void Start()
    {
        mainCam = Camera.main;
    }

}

