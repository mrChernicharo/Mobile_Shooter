using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;
    public bool gameOver = false;

    private PanelController panelController;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2.4f);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        // activate panel
        panelController.ActivateWinScreen();
        // unlock next level
        // score
    }

    public void LoseGame()
    {
        panelController.ActivateLoseScreen();

    }

    public void RegisterPanelController(PanelController pc)
    {
        panelController = pc;
    }
}
