using TMPro;
using UnityEngine;

public class GameplayLoop : MonoBehaviour
{
    public static GameplayLoop Instance { get; private set; }

    [SerializeField]
    private GameObject[] popUps;
    [SerializeField]
    private GameObject[] instantiatedPopUps;
    [SerializeField]
    private GameObject[] instantiatedQuestionCards = new GameObject[15];
    private Transform canvasTransform;

    private int currentActivePopup = 0;
    private int currentActiveQuestion = -1;

    public GameObject[] questionCardPrefabs;

    public QuestionCard[] questionCardsArtist;
    public QuestionCard[] questionCardsTechnician;
    public QuestionCard[] questionCardsEngineer;

    int orangeIndex = 0;
    int yellowIndex = 0;
    int purpleIndex = 0;

    int allIndex = 0;


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

        foreach (PlayerCard player in AddPlayers.Instance.playerList)
        {
            if (player.PlayerRole == "Artist")
            {
                GameObject popUpObject = Instantiate(popUps[0], canvasTransform);
                TMP_Text popUpObjectPlayerName = popUpObject.transform.Find("Text_Player").gameObject.GetComponent<TMP_Text>();
                popUpObjectPlayerName.text = player.PlayerName;
                instantiatedPopUps[index] = popUpObject;
                popUpObject.SetActive(false);
                index++;
            }
            else if (player.PlayerRole == "Technician")
            {
                GameObject popUpObject = Instantiate(popUps[1], canvasTransform);
                TMP_Text popUpObjectPlayerName = popUpObject.transform.Find("Text_Player").gameObject.GetComponent<TMP_Text>();
                popUpObjectPlayerName.text = player.PlayerName;
                instantiatedPopUps[index] = popUpObject;
                popUpObject.SetActive(false);
                index++;
            }
            else if (player.PlayerRole == "Engineer")
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



    public void InstantiateQuestionCard(string GridColor)
    {
        if (GridColor == "GridOrange")
        {
            Debug.Log("Instantiated an artist card!");
            GameObject questionCardObject = Instantiate(questionCardPrefabs[0], canvasTransform);
            //
            questionCardObject.SetActive(false);
            instantiatedQuestionCards[allIndex] = questionCardObject;
            QuestionCardPrefabController controller = questionCardObject.GetComponent<QuestionCardPrefabController>();
            controller.Initialize(questionCardsArtist[orangeIndex]);
            orangeIndex++;
            allIndex++;
            Debug.Log($"Orange Index:{orangeIndex}");
        }
        else if (GridColor == "GridPurple")
        {
            Debug.Log("Instantiated a engineer card!");
            GameObject questionCardObject = Instantiate(questionCardPrefabs[1], canvasTransform);
            //
            questionCardObject.SetActive(false);
            instantiatedQuestionCards[allIndex] = questionCardObject;
            QuestionCardPrefabController controller = questionCardObject.GetComponent<QuestionCardPrefabController>();
            controller.Initialize(questionCardsEngineer[purpleIndex]);
            purpleIndex++;
            allIndex++;
            Debug.Log($"Purple Index:{purpleIndex}");
        }
        else if (GridColor == "GridYellow")
        {
            Debug.Log("Instantiated an technician card!");
            GameObject questionCardObject = Instantiate(questionCardPrefabs[2], canvasTransform);
            //
            questionCardObject.SetActive(false);
            instantiatedQuestionCards[allIndex] = questionCardObject;
            QuestionCardPrefabController controller = questionCardObject.GetComponent<QuestionCardPrefabController>();
            controller.Initialize(questionCardsTechnician[yellowIndex]);
            yellowIndex++;
            allIndex++;
            Debug.Log($"Yellow Index:{yellowIndex}");
        }

        currentActiveQuestion++;
        instantiatedQuestionCards[currentActiveQuestion].SetActive(true);
    }

    public void PrevQuestion()
    {
        Debug.Log($"Current Active Question: {currentActiveQuestion}");
        if (currentActiveQuestion > 0 && currentActiveQuestion != 0)
        {
            instantiatedQuestionCards[currentActiveQuestion].SetActive(false);
            instantiatedQuestionCards[currentActiveQuestion - 1].SetActive(true);
            //currentActiveQuestion--;
        }
    }

    public void FinishQuestion()
    {
        if (currentActiveQuestion > 0 && currentActiveQuestion != 0)
        {
            Debug.Log($"Current Active Question: {currentActiveQuestion}");
            instantiatedQuestionCards[currentActiveQuestion].SetActive(false);
            //currentActiveQuestion--;
        } else if (currentActiveQuestion == 0)
        {
            instantiatedQuestionCards[currentActiveQuestion].SetActive(false);
        }

    }
}
