using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class QuestionCardCreator : MonoBehaviour
{
    private Dropdown cardCategoryDropdown;
    private InputField cardTitleInput;
    private InputField cardQuestionInput;
    private Button submitCardButton;

    private Text cardCategoryText;
    private Text cardTitleText;
    private Text cardQuestionText;

    void Awake()
    {
        cardTitleInput = GameObject.Find("InputField_CardTitle").GetComponent<InputField>();  
        cardQuestionInput = GameObject.Find("InputField_CardQuestion").GetComponent<InputField>();
        cardCategoryDropdown = GameObject.Find("Dropdown_CardCategory").GetComponent<Dropdown>();
        submitCardButton = GameObject.Find("Button_SubmitCard").GetComponent<Button>();

        cardCategoryText = GameObject.Find("Text_CardCategory").GetComponent<Text>();
        cardTitleText = GameObject.Find("Text_CardTitle").GetComponent<Text>();
        cardQuestionText = GameObject.Find("Text_CardQuestion").GetComponent<Text>();

    }

    void Start()
    {
        InitOptions();
        BindEventListeners();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            HandleOnSubmit();
        }
    }

    void InitOptions()
    {
        List<string> DropdownOptions = new List<string>();

        var options = Enum.GetValues(typeof(GameManager.CardDeck)).Cast<GameManager.CardDeck>();

        foreach (var option in options)
        {
            var optionStr = option.ToString();
            DropdownOptions.Add(optionStr);
        }

        cardCategoryDropdown.AddOptions(DropdownOptions);
    }

    void BindEventListeners()
    {
        submitCardButton.onClick.AddListener(() => HandleOnSubmit());
    }

    void DisplayCard(QuestionCard card)
    {
        cardCategoryText.text = $"Current Card Category: {card.CardCategory}";
        cardTitleText.text = $"Current Card Title: {card.CardTitle}";
        cardQuestionText.text = $"Current Card Question: {card.CardQuestion}";
    }

    void HandleOnSubmit()
    {

        if (cardTitleInput.text.Length > 0 && cardQuestionInput.text.Length > 0)
        {
            var card = new QuestionCard
            {
                CardCategory = cardCategoryDropdown.options[cardCategoryDropdown.value].text,
                CardTitle = cardTitleInput.text,
                CardQuestion = cardQuestionInput.text
            };


            DisplayCard(card);

            var cardJSON = JsonConvert.SerializeObject(card);
            Debug.Log(cardJSON);
        }
        else
        {
            Debug.Log("Please fill in all the input field!");
        }

    }
}
