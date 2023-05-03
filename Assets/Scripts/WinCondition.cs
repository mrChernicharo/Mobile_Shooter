using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public event System.Action OnReachedEndOfLevel;

    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private bool hasBoss;




    void Start()
    {

    }

    void Update()
    {
        if (EndGameManager.instance.gameOver == true) return;

        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            // disable spawners
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].SetActive(false);
            }

            if (hasBoss == false)
            {
                EndGameManager.instance.StartResolveSequence();
            }
            else if (OnReachedEndOfLevel != null)
            {
                OnReachedEndOfLevel();
            }

            gameObject.SetActive(false);
        }
    }
}
