using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinMovement : MonoBehaviour
{
    public GameObject Pin;
    public List<Transform> grids;
    public float speed;
    public int destinationGrid;
    public int currentGrid;
    public bool tagCheck;

    public TMP_Text diceResult;
    public Button rollDiceBtn;

    private void Start()
    {
        destinationGrid = 0;
        currentGrid = 0;

        rollDiceBtn.onClick.AddListener(() => ThrowDice());
    }

    private void Update()
    {
        MovePin();
    }

    private void MovePin() 
    {
        Pin.transform.position = Vector3.MoveTowards(Pin.transform.position, grids[currentGrid].transform.position, speed);

        var magnitude = (grids[currentGrid].transform.position - Pin.transform.position).magnitude;

        if(magnitude < 0.1f && currentGrid < destinationGrid)
        {
            currentGrid += 1;
        }

        if(currentGrid == destinationGrid && magnitude < 0.1f && currentGrid != 0 && tagCheck)
        {
            Debug.Log(grids[destinationGrid].tag);

            if (grids[destinationGrid].tag == "GridOrange")
            {
                GameplayLoop.Instance.InstantiateQuestionCard("GridOrange");
            } else if (grids[destinationGrid].tag == "GridYellow")
            {
                GameplayLoop.Instance.InstantiateQuestionCard("GridYellow");
            }
            else if (grids[destinationGrid].tag == "GridPurple")
            {
                GameplayLoop.Instance.InstantiateQuestionCard("GridPurple");
            }

            tagCheck = false;
        }
    }

    public void DiceResult(int die)
    {
        var result = die + destinationGrid;

        destinationGrid = result >= grids.Count ? grids.Count - 1 : result;
    }

    [ContextMenu("throwDice")] //call func from component
    public void ThrowDice()
    {
        tagCheck = true; //need to be used somewhere

        var num = Random.Range(1, 7);

        DiceResult(num); //result of the dice should start this func.

        Debug.Log(num);
        diceResult.text = $"Dice Roll: {num.ToString()}";

        MovePin();
    }
}
