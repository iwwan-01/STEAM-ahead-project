using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private enum GameState
    {
        Empathize,
        Ideate,
        Prototype,
        Evaluate,
    }

    private enum CardDeck
    {
        EmpathizeDeck,
        IdeateDeck,
        PrototypeDeck,
        EvaluateDeck
    }

    private GameState currentState;
    private CardDeck currentDeck;
    
    private Text currentStateText;
    private Text diceRollText;
    private Text currentCardDeckText;

    private Button updateStateButton;
    private Button rollDiceButton;

    void Awake()
    {
        currentStateText = GameObject.Find("Text_GameState").GetComponent<Text>();
        currentCardDeckText = GameObject.Find("Text_CardDeck").GetComponent<Text>();
        updateStateButton = GameObject.Find("Button_UpdateState").GetComponent<Button>();

        diceRollText = GameObject.Find("Text_DiceRoll").GetComponent<Text>();
        rollDiceButton = GameObject.Find("Button_RollDice").GetComponent<Button>();
    }


    void Start()
    {
        InitGameState();
        BindEventListeners();
    }

    void Update()
    {
       switch(currentState)
        {
            case GameState.Emphatize:
                currentStateText.text = $"Current Game State: {currentState}";
                currentCardDeckText.text = $"Current Card Deck: {currentDeck}";
                break;
            case GameState.Ideate:
                currentStateText.text = $"Current Game State: {currentState}";
                currentCardDeckText.text = $"Current Card Deck: {currentDeck}";
                break;
            case GameState.Prototype:
                currentStateText.text = $"Current Game State: {currentState}";
                currentCardDeckText.text = $"Current Card Deck: {currentDeck}";
                break;
            case GameState.Evaluate:
                currentStateText.text = $"Current Game State: {currentState}";
                currentCardDeckText.text = $"Current Card Deck: {currentDeck}";
                break;
        }
    }

    void InitGameState()
    {
        currentState = (GameState)0;
    }

    void BindEventListeners()
    {
        updateStateButton.onClick.AddListener(() => UpdateGameState());
        rollDiceButton.onClick.AddListener(() => RollDice());
    }

    void UpdateGameState() {
        if (currentState == Enum.GetValues(typeof(GameState)).Cast<GameState>().Last())
        {
            currentState = (GameState)0;
            UpdateCardDeck();
        } else {
            currentState++;
            UpdateCardDeck();
        }
    }

    void UpdateCardDeck()
    {
        switch(currentState)
        {
            case GameState.Emphatize:
                currentDeck = (CardDeck)0;
                break;
            case GameState.Ideate:
                currentDeck = (CardDeck)1;
                break;
            case GameState.Prototype:
                currentDeck = (CardDeck)2;
                break;
            case GameState.Evaluate:
                currentDeck = (CardDeck)3;
                break;
        }
    }

    void RollDice()
    {
        int diceRoll = new System.Random().Next(1, 5);
        diceRollText.text = $"Current Dice Roll: {diceRoll}";
    }
}
