using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    int turnNumber;
    public float delayBetweenTurns;
    bool EndTurnIteration;

    private void Start()
    {
        EndTurnIteration = true;
        turnNumber = 0;
    }
    private void Update()
    {
        if (EndTurnIteration)
        {
            StartCoroutine(TurnIteration());
        }
    }
    IEnumerator TurnIteration()
    {
        EndTurnIteration = false;
        FindObjectOfType<TextBox>().DisplayMessage("-- Turn " + turnNumber + " --");
        foreach (var entity in FindObjectsOfType<MovableEntities>())
        {
            if (entity == null) continue;
            FindObjectOfType<TextBox>().DisplayMessage(entity.name + " Turn");
            entity.StartCoroutine("TurnUpdate");

            yield return new WaitUntil(() => entity.endTurn);

            //FindObjectOfType<TextBox>().DisplayMessage("End Turn");
            yield return new WaitForSeconds(delayBetweenTurns);
        }
        turnNumber++;
        EndTurnIteration = true;
    }
}
