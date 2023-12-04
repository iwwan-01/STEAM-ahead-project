using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameplayLoop : MonoBehaviour
{
    // Singleton instance
    public static GameplayLoop Instance;
    [SerializeField]
    private GameObject[] popUps;
    [SerializeField]
    private GameObject[] instantiatedPopUps;
    private Transform canvasTransform;

    private int currentActive = 0;

    //public QuestionCard[] questionCardsArtist;
    //public QuestionCard[] questionCardsTechnician;
    //public QuestionCard[] questionCardsEngineer;

    private void Awake()
    {
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

        instantiatedPopUps[currentActive].SetActive(true);
    }

    public void NextPopUp()
    {
        if (currentActive < instantiatedPopUps.Length - 1)
        {
            instantiatedPopUps[currentActive].SetActive(false);
            instantiatedPopUps[currentActive + 1].SetActive(true);
            currentActive++;
        }
        else
        {
            instantiatedPopUps[currentActive].SetActive(false);
        }
    }

    public void PrevPopUp()
    {
        if (currentActive > 0)
        {
            instantiatedPopUps[currentActive].SetActive(false);
            instantiatedPopUps[currentActive - 1].SetActive(true);
            currentActive--;
        }
    }
}
