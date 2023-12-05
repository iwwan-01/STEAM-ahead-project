using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EmojiRating : MonoBehaviour
{
    private int index = 0;
    public TMP_Text playerName;

    public Button emojiHeart;
    public Button emojiStar;
    public Button emojiHands;

    private Transform canvasTransform;
    private Vector2 emojiSpawnPoint = new Vector2(200f, 80f);

    public GameObject[] emojiPrefabs;

    void Awake()
    {
        canvasTransform = GameObject.Find("Canvas").GetComponent<Transform>();
    }

    void Start()
    {
        BindEventListeners();
        UpdatePlayer();
    }

    void BindEventListeners()
    {
        emojiHeart.onClick.AddListener(() => InstantiateEmoji());
        emojiStar.onClick.AddListener(() => InstantiateEmoji());
        emojiHands.onClick.AddListener(() => InstantiateEmoji());

    }

    void UpdatePlayer() 
    {
        playerName.text = AddPlayers.Instance.playerList[index].PlayerName;
        index++;
    }

    void InstantiateEmoji()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        if (clickedButtonName == "Emoji_Star")
        {
            GameObject playerTextObject = Instantiate(emojiPrefabs[0], canvasTransform);

            RectTransform rectTransformComponent = playerTextObject.GetComponent<RectTransform>();
            rectTransformComponent.anchoredPosition = emojiSpawnPoint;

            emojiSpawnPoint -= new Vector2(0, rectTransformComponent.sizeDelta.y);
        } else if(clickedButtonName == "Emoji_Heart")
        {
            GameObject playerTextObject = Instantiate(emojiPrefabs[1], canvasTransform);

            RectTransform rectTransformComponent = playerTextObject.GetComponent<RectTransform>();
            rectTransformComponent.anchoredPosition = emojiSpawnPoint;

            emojiSpawnPoint -= new Vector2(0, rectTransformComponent.sizeDelta.y);
        } else if(clickedButtonName == "Emoji_Hands")
        {
            GameObject playerTextObject = Instantiate(emojiPrefabs[2], canvasTransform);

            RectTransform rectTransformComponent = playerTextObject.GetComponent<RectTransform>();
            rectTransformComponent.anchoredPosition = emojiSpawnPoint;

            emojiSpawnPoint -= new Vector2(0, rectTransformComponent.sizeDelta.y);
        }
    }
}
