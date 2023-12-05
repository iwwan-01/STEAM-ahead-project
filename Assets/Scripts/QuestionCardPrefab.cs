using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionCardPrefabController : MonoBehaviour
{

    // Reference to the QuestionCard data
    public QuestionCard questionCardData;

    // References to UI elements for visualization
    public TMP_Text taskDescriptionText;

    // Method to initialize the prefab with QuestionCard data
    public void Initialize(QuestionCard cardData)
    {
        questionCardData = cardData;

        // Customize the visualization with data from QuestionCard
        taskDescriptionText.text = cardData.CardQuestion;
    }
}
