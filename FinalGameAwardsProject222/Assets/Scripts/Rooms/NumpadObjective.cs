using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadObjective : Objective {


    [SerializeField] private string correctCombination;
    [SerializeField] private string currentCombination;

    public void AddToCombination(string characterToAdd)
    {
        currentCombination += characterToAdd;
        if(currentCombination == correctCombination)
        {
            Complete();
        }
    }

    public override void Complete()
    {
        base.Complete();
    }
}
