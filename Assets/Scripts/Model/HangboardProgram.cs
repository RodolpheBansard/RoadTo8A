using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HangboardProgram
{
    public string programName = "";
    public int restBetweenHangs = 0;
    public int hangTime = 0;
    public int restBetweenSets = 0;
    public int numberOfHangs = 0;
    public int numberOfSets = 0;
    public string[] hangsName = null;

    public HangboardProgram(string programName, int restBetweenHangs, int hangTime, int restBetweenSets, int numberOfHangs, int numberOfSets, string[] hangsName)
    {
        this.programName = programName;
        this.restBetweenHangs = restBetweenHangs;
        this.hangTime = hangTime;
        this.restBetweenSets = restBetweenSets;
        this.numberOfHangs = numberOfHangs;
        this.numberOfSets = numberOfSets;
        this.hangsName = hangsName;
    }
}
