using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.instance.gameOver == true) return;

        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].SetActive(false);
            }

            EndGameManager.instance.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}
