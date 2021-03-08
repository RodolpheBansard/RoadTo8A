using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataModel
{
    public HangboardProgram[] hangboardPrograms = null;
    public PhysicalTrainingProgram[] physicalTrainingPrograms = null;
    public Warmup[] warmups = null;
    public Stretching[] stretchings = null;
    public TrainingLog[] trainingLogs = null;

    public DataModel(HangboardProgram[] hangboardPrograms, PhysicalTrainingProgram[] physicalTrainingPrograms, Warmup[] warmups, Stretching[] stretchings, TrainingLog[] trainingLogs)
    {
        this.hangboardPrograms = hangboardPrograms;
        this.physicalTrainingPrograms = physicalTrainingPrograms;
        this.warmups = warmups;
        this.stretchings = stretchings;
        this.trainingLogs = trainingLogs;
    }

    public DataModel()
    {
        
    }
}
