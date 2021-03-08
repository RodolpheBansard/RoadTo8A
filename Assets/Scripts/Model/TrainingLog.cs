using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingLog
{
    public string logDate = "";
    public string logContent = "";

    public TrainingLog(string logDate, string logContent)
    {
        this.logDate = logDate;
        this.logContent = logContent;
    }
}
