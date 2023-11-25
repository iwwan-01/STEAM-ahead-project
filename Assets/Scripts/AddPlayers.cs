using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AddPlayers : MonoBehaviour
{
    private InputField playerNameInput;

    private Button artistRoleButton;
    private Button designerRoleButton;
    private Button developerRoleButton;

    private Button addPlayerButton;
    private string playerRole = "";

    private List<PlayerCard> playerList = new List<PlayerCard>();
    //private List<GameObject> playerObject = new List<GameObject>();

    private GameObject playerTextPrefab;
    private Transform canvasTransform;

    private Vector2 playerTextSpawnPoint = new Vector2(210f, 100f);

    void Awake()
    {
        playerNameInput = GameObject.Find("InputField_PlayerName").GetComponent<InputField>();

        artistRoleButton = GameObject.Find("Button_ArtistRole").GetComponent<Button>();
        designerRoleButton = GameObject.Find("Button_DesignerRole").GetComponent<Button>();
        developerRoleButton = GameObject.Find("Button_DeveloperRole").GetComponent<Button>();

        addPlayerButton = GameObject.Find("Button_AddPlayer").GetComponent<Button>();

        playerTextPrefab = Resources.Load<GameObject>("Prefabs/Text_Player");
        canvasTransform = GameObject.Find("Canvas").GetComponent<Transform>();
    }

    void Start()
    {
        BindEventListeners();
    }

    void BindEventListeners()
    {
        artistRoleButton.onClick.AddListener(() => HandleOnClick());
        designerRoleButton.onClick.AddListener(() => HandleOnClick());
        developerRoleButton.onClick.AddListener(() => HandleOnClick());

        addPlayerButton.onClick.AddListener(() => HandleOnSubmit());
    }

    void HandleOnClick()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        if (clickedButtonName == "Button_ArtistRole")
        {
            playerRole = "Artist";
        }
        else if (clickedButtonName == "Button_DesignerRole")
        {
            playerRole = "Designer";
        } else if (clickedButtonName == "Button_DeveloperRole")
        {
            playerRole = "Developer";
        }
    }

    void HandleOnSubmit()
    {
        if (playerRole == "")
        {
            Debug.Log("You need to first select a role!");
            return;
        }

        var playerCard = new PlayerCard { 
            PlayerName = playerNameInput.text, 
            PlayerRole = playerRole 
        };

        var existingPlayer = playerList.Find(player => player.PlayerName == playerCard.PlayerName);

        if(existingPlayer != null)
        {
            existingPlayer.PlayerRole = playerCard.PlayerRole;
        }    
        else
        {
            playerList.Add(playerCard);
        }

        DisplayPlayer(playerCard);
        PrintPlayerList();
    }

    void PrintPlayerList()
    {
        foreach (PlayerCard player in playerList)
        {
            Debug.Log($"{player.PlayerName} ({player.PlayerRole})");
        }

        Debug.Log($"Count: {playerList.Count}");
    }

    void DisplayPlayer(PlayerCard playerCard)
    {
        GameObject playerTextObject = Instantiate(playerTextPrefab, canvasTransform);

        Text playerTextComponent = playerTextObject.GetComponent<Text>();
        playerTextComponent.text = $"{playerCard.PlayerName} ({playerCard.PlayerRole})";

        RectTransform rectTransformComponent = playerTextObject.GetComponent<RectTransform>();
        rectTransformComponent.anchoredPosition = playerTextSpawnPoint;

        playerTextSpawnPoint -= new Vector2(0, rectTransformComponent.sizeDelta.y);
    }
}