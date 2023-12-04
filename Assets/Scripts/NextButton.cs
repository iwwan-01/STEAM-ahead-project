using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    [SerializeField]
    private GameplayLoop gameplayLoop;

    void Awake()
    {
        gameplayLoop = GameObject.Find("GameplayLoop").GetComponent<GameplayLoop>();
    }

    public void nextPlayerCard()
    {
        gameplayLoop.NextPopUp();
    }

}
