using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameplayLoop : MonoBehaviour
{
    public static GameplayLoop Instance { get; private set; }

    [SerializeField]
    private GameObject[] popUps;
    [SerializeField]
    private GameObject[] instantiatedPopUps;
    private Transform canvasTransform;

    private int currentActivePopup = 0;
    private int currentActiveQuestion = 0;

    public GameObject[] questionCardPrefabs;

    public QuestionCard[] questionCardsArtist;
    public QuestionCard[] questionCardsTechnician;
    public QuestionCard[] questionCardsEngineer;

    [SerializeField]
    private GameObject[] instantiatedQuestionCards;

    int orangeIndex = 0;
    int yellowIndex = 0;
    int purpleIndex = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        canvasTransform = GameObject.Find("Canvas").GetComponent<Transform>();
    }

    void Start()
    {
        InstantiatePopUps();
    }

    void InstantiatePopUps()
    {
        instantiatedPopUps = new GameObject[10];
        int index = 0;

        foreach(PlayerCard player in AddPlayers.Instance.playerList)
        {
            if(player.PlayerRole == "Artist")
            {
                GameObject popUpObject = Instantiate(popUps[0], canvasTransform);
                TMP_Text popUpObjectPlayerName = popUpObject.transform.Find("Text_Player").gameObject.GetComponent<TMP_Text>();
                popUpObjectPlayerName.text = player.PlayerName;
                instantiatedPopUps[index] = popUpObject;
                popUpObject.SetActive(false);
                index++;
            } else if(player.PlayerRole == "Technician")
            {
                GameObject popUpObject = Instantiate(popUps[1], canvasTransform);
                TMP_Text popUpObjectPlayerName = popUpObject.transform.Find("Text_Player").gameObject.GetComponent<TMP_Text>();
                popUpObjectPlayerName.text = player.PlayerName;
                instantiatedPopUps[index] = popUpObject;
                popUpObject.SetActive(false);
                index++;
            } else if(player.PlayerRole == "Engineer")
            {
                GameObject popUpObject = Instantiate(popUps[2], canvasTransform);
                TMP_Text popUpObjectPlayerName = popUpObject.transform.Find("Text_Player").gameObject.GetComponent<TMP_Text>();
                popUpObjectPlayerName.text = player.PlayerName;
                instantiatedPopUps[index] = popUpObject;
                popUpObject.SetActive(false);
                index++;
            }
        }

        instantiatedPopUps[currentActivePopup].SetActive(true);
    }

    public void NextPopUp()
    {
        if (currentActivePopup < instantiatedPopUps.Length - 1)
        {
            instantiatedPopUps[currentActivePopup].SetActive(false);
            instantiatedPopUps[currentActivePopup + 1].SetActive(true);
            currentActivePopup++;
        }
        else
        {
            instantiatedPopUps[currentActivePopup].SetActive(false);
        }
    }

    public void PrevPopUp()
    {
        if (currentActivePopup > 0)
        {
            instantiatedPopUps[currentActivePopup].SetActive(false);
            instantiatedPopUps[currentActivePopup - 1].SetActive(true);
            currentActivePopup--;
        }
    }

    public void InstantiateQuestionCard(string GridColor) {
        if(GridColor == "GridOrange")
        {
            Debug.Log("Instantiated an artist card!");
            GameObject questionCardObject = Instantiate(questionCardPrefabs[0], canvasTransform);
            QuestionCardPrefabController controller = questionCardObject.GetComponent<QuestionCardPrefabController>();
            controller.Initialize(questionCardsArtist[orangeIndex]);
            orangeIndex++;
            Debug.Log($"Orange Index:{orangeIndex}");
        } else if (GridColor == "GridPurple")
        {
            Debug.Log("Instantiated a engineer card!");
            GameObject questionCardObject = Instantiate(questionCardPrefabs[1], canvasTransform);
            QuestionCardPrefabController controller = questionCardObject.GetComponent<QuestionCardPrefabController>();
            controller.Initialize(questionCardsEngineer[purpleIndex]);
            purpleIndex++;
            Debug.Log($"Purple Index:{purpleIndex}");
        }
        else if (GridColor == "GridYellow")
        {
            Debug.Log("Instantiated an technician card!");
            GameObject questionCardObject = Instantiate(questionCardPrefabs[2], canvasTransform);
            QuestionCardPrefabController controller = questionCardObject.GetComponent<QuestionCardPrefabController>();
            controller.Initialize(questionCardsTechnician[yellowIndex]);
            yellowIndex++;
            Debug.Log($"Yellow Index:{yellowIndex}");
        }

    }
}
