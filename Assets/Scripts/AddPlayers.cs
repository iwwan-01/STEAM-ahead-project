using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AddPlayers : MonoBehaviour
{
    // Singleton instance
    public static AddPlayers Instance { get; private set; }

    private TMP_InputField playerNameInput;

    private Button artistRoleButton;
    private Button designerRoleButton;
    private Button developerRoleButton;

    private Button addPlayerButton;
    private string playerRole = "";

    public List<PlayerCard> playerList = new List<PlayerCard>();
    //private List<GameObject> playerObject = new List<GameObject>();

    private GameObject playerTextPrefab;
    private Transform canvasTransform;

    private Vector2 playerTextSpawnPoint = new Vector2(200f, 100f);

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerNameInput = GameObject.Find("InputField_PlayerName").GetComponent<TMP_InputField>();

        artistRoleButton = GameObject.Find("Button_ArtistRole").GetComponent<Button>();
        designerRoleButton = GameObject.Find("Button_TechnicianRole").GetComponent<Button>();
        developerRoleButton = GameObject.Find("Button_EngineerRole").GetComponent<Button>();

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
        else if (clickedButtonName == "Button_TechnicianRole")
        {
            playerRole = "Technician";
        } else if (clickedButtonName == "Button_EngineerRole")
        {
            playerRole = "Engineer";
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

        //if(existingPlayer != null)
        //{
        //    existingPlayer.PlayerRole = playerCard.PlayerRole;
        //}
        
        if(existingPlayer != null)
        {
            Debug.Log("This player already exists!");
        }
        else
        {
            playerList.Add(playerCard);
            DisplayPlayer(playerCard);
        }

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

        TMP_Text playerTextComponent = playerTextObject.GetComponent<TMP_Text>();
        playerTextComponent.text = $"{playerCard.PlayerName} [{playerCard.PlayerRole}]";

        RectTransform rectTransformComponent = playerTextObject.GetComponent<RectTransform>();
        rectTransformComponent.anchoredPosition = playerTextSpawnPoint;

        playerTextSpawnPoint -= new Vector2(0, rectTransformComponent.sizeDelta.y);
    }
}
