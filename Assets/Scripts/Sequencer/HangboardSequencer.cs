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

    public AudioSource audioSource;
    public AudioClip bipHang;
    public AudioClip bipPause;
    public AudioClip bipRest;

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
            hangTimeText.text = "" + Mathf.Ceil(hangTimeLeft);
        }

        if(restBetweenHangLeft > 0)
        {
            restBetweenHangLeft -= Time.deltaTime;
            restBetweenHangsText.text = "" + Mathf.Ceil(restBetweenHangLeft);
        }

        if (restBetweenSetLeft > 0)
        {
            restBetweenSetLeft -= Time.deltaTime;
            restBetweenSetsText.text = "" + Mathf.Ceil(restBetweenSetLeft);
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
        hangNameText.text = hangsName[0];
    }

    public void StartSequencer()
    {
        StartCoroutine(Sequencer());
    }

    public IEnumerator Sequencer()
    {
        for(currentSet = 1; currentSet < numberOfSets + 1; currentSet++)
        {
            hangNameText.text = hangsName[currentSet-1];
            numberOfSetsText.text = currentSet + "/" + numberOfSets;

            for(currentRound = 1; currentRound<numberOfHangs + 1; currentRound++)
            {
                numberOfHangsText.text = currentRound + "/" + numberOfHangs;
                hangTimeLeft = hangTime;
                audioSource.PlayOneShot(bipHang, 1);
                yield return new WaitForSeconds(hangTime);
                restBetweenHangLeft = restBetweenHangs;
                audioSource.PlayOneShot(bipPause, 1);
                yield return new WaitForSeconds(restBetweenHangs);
            }

            restBetweenSetLeft = restBetweenSets;
            audioSource.PlayOneShot(bipRest, 1);
            yield return new WaitForSeconds(restBetweenSets);
            
        }
    }

    

    


}
