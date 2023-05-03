using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : BossBaseState
{
    private Vector2 enterPoint;
    [SerializeField] private float speed;

    //protected override void Start()
    //{
    //    base.Start();
    //    enterPoint = mainCam.ViewportToWorldPoint(new Vector2(0.5f, 0.7f));
    //}



    //IEnumerator RunEnterState()
    //{
    //    while (Vector2.Distance(transform.position, enterPoint) > 0.01f)
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, enterPoint, speed * Time.deltaTime);
    //        yield return new WaitForEndOfFrame();
    //    }
    //    // change state
    //    bossController.ChangeState(BossState.fire);
    //}

    public override void RunState()
    {
        base.RunState();
        EndGameManager.instance.StartResolveSequence();
        gameObject.SetActive(false);
    }

    //public override void StopState()
    //{
    //    base.StopState();
    //}
}
