using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] popUps;
    [SerializeField]
    private GameObject[] instantiatedPopUps;
    private Transform canvasTransform;

    public AddPlayers addPlayers;

    private int currentActive = 0;

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
        instantiatedPopUps = new GameObject[popUps.Length];

        for (int i = 0; i < popUps.Length; i++)
        {
            GameObject popUpObject = Instantiate(popUps[i], canvasTransform);
            //TMP_Text popUpObjectPlayerName = popUpObject.transform.Find("Text_Player").gameObject.GetComponent<TMP_Text>();
            //popUpObjectPlayerName.text = addPlayers.playerList[i].PlayerName;
            instantiatedPopUps[i] = popUpObject;
            popUpObject.SetActive(false);
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
}
