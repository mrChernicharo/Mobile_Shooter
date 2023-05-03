using UnityEngine;
using System.Collections;

public class BossBaseState : MonoBehaviour
{
    protected Camera mainCam;

    protected float maxTop;
    protected float maxBottom;
    protected float maxLeft;
    protected float maxRight;


    protected BossController bossController;

    private void Awake()
    {
        mainCam = Camera.main;
        bossController = GetComponent<BossController>();
    }

    protected virtual void Start()
    {
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.2f, 0f)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.8f, 0f)).x;
        maxTop = mainCam.ViewportToWorldPoint(new Vector2(0f, 0.95f)).y;
        maxBottom = mainCam.ViewportToWorldPoint(new Vector2(0f, 0.6f)).y;
    }

    public virtual void RunState()
    {

    }

    public virtual void StopState()
    {
        StopAllCoroutines();
    }
}

