using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    void Start()
    {
        EndGameManager.instance.RegisterPanelController(this);
    }

    public void ActivateWinScreen()
    {
        canvasGroup.alpha = 1;
        winScreen.SetActive(true);
    }

    public void ActivateLoseScreen()
    {
        canvasGroup.alpha = 1;
        loseScreen.SetActive(true);
    }
}
