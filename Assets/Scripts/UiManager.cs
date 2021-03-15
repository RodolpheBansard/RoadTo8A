using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public SaveSystemLogic saveSystem;
    public GameObject volume;

    public GameObject programListCanvas;
    public GameObject addProgramModal;
    public GameObject addHangboardCanvas;
    public GameObject addhangboardModal;
    public GameObject hangboardProgramCanvas;

    public HangboardSequencer hangboardSequencer;

    public GameObject programsContainer;
    public GameObject buttonPrefab;

    public TMP_Dropdown programTypeDropdown;

    public TMP_InputField[] hangboardForm;
    public TMP_InputField HangboardNameInput;
    public TMP_Text exercicesNameText;
    private List<string> hangboardExercicesList = new List<string>();
    private int numberOfSet = 0;
    
    


    private void Start()
    {
        programListCanvas.SetActive(true);
        addProgramModal.SetActive(false);
        addHangboardCanvas.SetActive(false);
        addhangboardModal.SetActive(false);
        hangboardProgramCanvas.SetActive(false);

        volume.SetActive(false);

        LoadPrograms();
    }

    public void OnSubmitHangboardExercice()
    {
        hangboardExercicesList.Add(HangboardNameInput.text);

        numberOfSet++;
        hangboardForm[5].text = "" + numberOfSet;

        volume.SetActive(false);
        addhangboardModal.SetActive(false);

        exercicesNameText.text = "";
        foreach (string exercice in hangboardExercicesList)
        {
            exercicesNameText.text += exercice;
            Debug.Log(exercice + "  " + hangboardExercicesList[numberOfSet - 1] + "   " + numberOfSet);
            if (!exercice.Equals(hangboardExercicesList[numberOfSet - 1]))
            {
                exercicesNameText.text += " / ";
            }
            
        }
    }

    public void OnSubmitHangboardProgram()
    {
        string programName = hangboardForm[0].text;
        int restBetweenHangs = int.Parse(hangboardForm[1].text);
        int hangTime = int.Parse(hangboardForm[2].text);
        int restBetweenSets = int.Parse(hangboardForm[3].text);
        int numberOfHangs = int.Parse(hangboardForm[4].text);
        int numberOfSets = int.Parse(hangboardForm[5].text);
        string[] hangsName = hangboardExercicesList.ToArray();

        HangboardProgram hangboardProgram = new HangboardProgram(programName,restBetweenHangs,hangTime,restBetweenSets,numberOfHangs,numberOfSets,hangsName);
        saveSystem.SaveHangboardProgram(hangboardProgram);

        addHangboardCanvas.SetActive(false);
        programListCanvas.SetActive(true);

        LoadPrograms();

    }

    public void OnAddNewProgram()
    {
        volume.SetActive(true);
        addProgramModal.SetActive(true);
    }

    public void OnAddNewHangboardExercice()
    {
        volume.SetActive(true);
        addhangboardModal.SetActive(true);
    }

    public void OnSubmitAddProgramModal()
    {
        programListCanvas.SetActive(false);
        volume.SetActive(false);
        addProgramModal.SetActive(false);

        if(programTypeDropdown.options[programTypeDropdown.value].text == "Hangboard")
        {
            addHangboardCanvas.SetActive(true);
            exercicesNameText.text = "empty...";
            numberOfSet = 0;
            foreach(TMP_InputField input in hangboardForm)
            {
                input.placeholder.GetComponent<Text>().text = "";
            }
        }
    }

    public void LoadPrograms()
    {
        foreach (Transform child in programsContainer.transform)
        {
            Destroy(child.gameObject);
        }

        DataModel dataModel = saveSystem.LoadDataModel();
        if(dataModel.hangboardPrograms != null)
        {
            foreach(HangboardProgram hangboardProgram in dataModel.hangboardPrograms)
            {
                GameObject program = Instantiate(buttonPrefab, programsContainer.transform);
                program.transform.SetParent(programsContainer.transform);
                program.GetComponentInChildren<TMP_Text>().text = hangboardProgram.programName;
                program.GetComponent<Button>().onClick.AddListener(delegate () { 
                    hangboardProgramCanvas.SetActive(true);
                    programListCanvas.SetActive(false);
                    hangboardSequencer.InitializeSequencer(hangboardProgram);
                });
            }
        }
    }
}
