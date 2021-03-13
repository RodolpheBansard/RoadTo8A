using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HangboardSequencer : MonoBehaviour
{
    public TMP_Text programNameText;
    public TMP_Text hangTimeText;
    public TMP_Text restBetweenHangsText;
    public TMP_Text numberOfHangsText;
    public TMP_Text restBetweenSetsText;
    public TMP_Text numberOfSetsText;
    public TMP_Text hangNameText;

    private string programName;
    private int hangTime;
    private int restBetweenHangs;
    private int numberOfHangs;
    private int restBetweenSets;
    private int numberOfSets;
    private string[] hangsName;

    private int currentRound;
    private int currentSet;

    private float hangTimeLeft;
    private float restBetweenHangLeft;
    private float restBetweenSetLeft;


    private bool isRest = false;

    private void Update()
    {
        
        if(hangTimeLeft > 0)
        {
            hangTimeLeft -= Time.deltaTime;
            hangTimeText.text = "" + (int)hangTimeLeft;
        }

        if(restBetweenHangLeft > 0)
        {
            restBetweenHangLeft -= Time.deltaTime;
            restBetweenHangsText.text = "" + (int)restBetweenHangLeft;
        }

        if (restBetweenSetLeft > 0)
        {
            restBetweenSetLeft -= Time.deltaTime;
            restBetweenSetsText.text = "" + (int)restBetweenSetLeft;
        }
    }


    public void InitializeSequencer(HangboardProgram hangboardProgram)
    {
        programName = hangboardProgram.programName;
        hangTime = hangboardProgram.hangTime;
        restBetweenHangs = hangboardProgram.restBetweenHangs;
        numberOfHangs = hangboardProgram.numberOfHangs;
        restBetweenSets = hangboardProgram.restBetweenSets;
        numberOfSets = hangboardProgram.numberOfSets;
        hangsName = hangboardProgram.hangsName;

        programNameText.text = programName;
        numberOfHangsText.text = "1/" + numberOfHangs;
        numberOfSetsText.text = "1/" + numberOfSets;
        hangNameText.text = "test";
    }

    public void StartSequencer()
    {
        StartCoroutine(Sequencer());
    }

    public IEnumerator Sequencer()
    {
        for(currentSet = 1; currentSet < numberOfSets + 1; currentSet++)
        {
            hangNameText.text = "test" + currentSet;
            numberOfSetsText.text = currentSet + "/" + numberOfSets;

            for(currentRound = 1; currentRound<numberOfHangs + 1; currentRound++)
            {
                numberOfHangsText.text = currentRound + "/" + numberOfHangs;
                hangTimeLeft = hangTime;
                yield return new WaitForSeconds(hangTime);
                restBetweenHangLeft = restBetweenHangs;
                yield return new WaitForSeconds(restBetweenHangs);
            }

            restBetweenSetLeft = restBetweenSets;
            yield return new WaitForSeconds(restBetweenSets);
            
        }
    }

    

    


}
