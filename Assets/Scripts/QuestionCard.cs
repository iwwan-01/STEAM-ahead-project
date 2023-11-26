using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionCard", menuName = "ScriptableObjects/QuestionCard", order = 1)]
public class QuestionCard:ScriptableObject { 
    public GameManager.PlayerRole CardCategory;
    public string CardTitle;
    public string CardQuestion;
    [Multiline]
    public string CardDescription;

}
