using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stretching
{
    public string programName = "";
    public Dictionary<string,int> stretches = null;

    public Stretching(string programName, Dictionary<string, int> stretches)
    {
        this.programName = programName;
        this.stretches = stretches;
    }
}
