using UnityEngine;
using System.Collections;

public enum BossState
{
	enter,
	fire,
	special,
	death
}

public class BossController : MonoBehaviour
{
	[SerializeField] BossEnter bossEnter;
	[SerializeField] BossFire bossFire;
	[SerializeField] BossSpecial bossSpecial;
	[SerializeField] BossDeath bossDeath;

    [SerializeField] private bool test;
	[SerializeField] private BossState testState;

    void Start()
	{
		if (test)
		{
			ChangeState(testState);
		} else
		{
            ChangeState(BossState.enter);
        }
    }

	public void ChangeState(BossState state)
	{
		switch (state)
		{
			case BossState.enter:
				bossEnter.RunState();
				break;
            case BossState.fire:
				bossFire.RunState();
                break;
            case BossState.special:
				bossSpecial.RunState();
                break;
            case BossState.death:
				bossEnter.StopState();
				bossFire.StopState();
                bossSpecial.StopState();
                bossDeath.RunState();
				break;
        }
	}
}

