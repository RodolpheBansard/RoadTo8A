using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Warmup
{
    public string programName = "";
    public string[] warmupsName = null;

    public Warmup(string programName, string[] warmupsName)
    {
        this.programName = programName;
        this.warmupsName = warmupsName;
    }
}
