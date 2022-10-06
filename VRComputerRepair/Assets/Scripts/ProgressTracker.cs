using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


//TODO: make an active step and use that to check; don't forget a checker to see if it is active or not and it corresponds to the current step?
[Serializable]
public class Step
{
    //TODO: make this human readable and changeable in the inspector
    public string nameOfStep;
    public bool stepIsDone;
    public bool isAvailableOnStart = false;
    public List<Substep> subSteps;
    //public UnityEvent onStepCompleted = new UnityEvent();
}

[Serializable]
public class Substep
{
    public string nameOfSubStep;

    public bool stepIsDone;

    public UnityEvent actionTriggeredBySubstepActive = new UnityEvent();
}

public class ProgressTracker : MonoBehaviour
{
    // get list of steps
    //go through list of steps to see if they're done
    // do we want to track which step is active?
    public int currStep = 0;
    public int currSubStep = 0;
    public List<Step> stepList = new List<Step>();
    [SerializeField] public TMP_Text currentStepLabel;
    [SerializeField] public TMP_Text currentSubStepLabel;
    [SerializeField] public TMP_Text listOfStepsLabel; //get list of steps and separate by new lines?
    private String currentStepLabelText;

    private void Start()
    {
        //updates UI if a step is available on Start
        if (stepList[currStep].isAvailableOnStart)
        {
            currentStepLabel.text = stepList[currStep].nameOfStep;
            if (stepList[currStep].subSteps[currStep] != null)
            {
                currentSubStepLabel.text = stepList[currStep].subSteps[currSubStep].nameOfSubStep;
                stepList[currStep].subSteps[currSubStep].actionTriggeredBySubstepActive.Invoke();
            }
        }

        DisplayListUI();
        
        Debug.Log(currStep);
        Debug.Log(currSubStep);
    }

    public void CompleteStep(String nameOfStep) //parameter for which check
    {
        // go through substeps to see if those are done first
        //TODO: add a check to see if the step is already done
        // looks to the list for the corresponding 
        Step stepInList = stepList.Find(step => step.nameOfStep.Equals(nameOfStep));
        // change boolean
        stepInList.stepIsDone = true;
        Debug.Log("step done");
        NextStep();

        if (stepInList.stepIsDone == true)
        {
            //stepInList.onStepCompleted.Invoke();
            NextStep();
        }
    }
    
    
    public void CompleteSubStep(String nameOfSubStep) //parameter for which check
    {
        
        // go through substeps to see if those are done first
        //TODO: add a check to see if the step is already done
        // looks to the list for the corresponding 
        Substep substepInList = stepList[currStep].subSteps.Find(step => step.nameOfSubStep.Equals(nameOfSubStep));
        // change boolean
        substepInList.stepIsDone = true;

        if (substepInList.stepIsDone == true)
        {
            //stepInList.onStepCompleted.Invoke();
            NextSubStep();
        }
    }
    

    public void NextStep()
    {

        // increases current step by one
        currStep++;
        // increment which step is active
        // active step changes the UI and what is required
        currentStepLabel.text = stepList[currStep].nameOfStep;
        if (stepList[currStep].subSteps[currStep] != null)
        {
            currentSubStepLabel.text = stepList[currStep].subSteps[currStep].nameOfSubStep;
            stepList[currStep].subSteps[currSubStep].actionTriggeredBySubstepActive.Invoke();
        }
        Debug.Log(currStep);
        Debug.Log(stepList[currStep].nameOfStep);
        //currentStepLabel = stepList[currStep].nameOfStep

    }

    public void NextSubStep()
    {
        if (currSubStep == (stepList[currStep].subSteps.Count - 1))
        {
            NextStep();
        }
        else
        {
            currSubStep++;
            currentSubStepLabel.text = stepList[currStep].subSteps[currSubStep].nameOfSubStep;
            stepList[currStep].subSteps[currSubStep].actionTriggeredBySubstepActive.Invoke();
        }
    }
    
    /*
     * initially compiles the steps and displays the list UI
     */
    private void DisplayListUI()
    {
        // need to get the name of step
        string listUIString = "";

        for (int i = 0; i < stepList.Count; i++)
        {
            listUIString = (listUIString + "\n " + stepList[i].nameOfStep);
            if (stepList[i].subSteps != null)
            {
                for (int j = 0; j < stepList[i].subSteps.Count; j++)
                {
                    listUIString = ("\t" + listUIString + "\n " + stepList[i].subSteps[j].nameOfSubStep);
                }
            }
        }

        listOfStepsLabel.text = listUIString;
        Debug.Log(listUIString);
    }
    
    /*
     * Updates the list UI based on what has already been completed
     */
    private void UpdateListUI()
    {
        throw new NotImplementedException();
    }
    
}

