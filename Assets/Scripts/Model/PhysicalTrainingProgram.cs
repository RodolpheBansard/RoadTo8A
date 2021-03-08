using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhysicalTrainingProgram
{
    public string programName = "";
    public int timeBetweenReps = 0;
    public int timeBetweenSets = 0;
    public int numberOfSets = 0;
    public string[] setsName = null;

    public PhysicalTrainingProgram(string programName, int timeBetweenReps, int timeBetweenSets, int numberOfSets, string[] setsName)
    {
        this.programName = programName;
        this.timeBetweenReps = timeBetweenReps;
        this.timeBetweenSets = timeBetweenSets;
        this.numberOfSets = numberOfSets;
        this.setsName = setsName;
    }
}
