using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupNavigation : MonoBehaviour
{
    [SerializeField]
    private GameplayLoop gameplayLoop;

    void Awake()
    {
        gameplayLoop = GameObject.Find("GameplayLoop").GetComponent<GameplayLoop>();
    }

    public void NextPlayerCard()
    {
        gameplayLoop.NextPopUp();
    }


    public void PrevPlayerCard()
    {
        gameplayLoop.PrevPopUp();
    }

    public void CloseQuestion()
    {
        gameplayLoop.FinishQuestion();
    }

    public void PrevQuestion()
    {
        gameplayLoop.PrevQuestion();
    }
}
