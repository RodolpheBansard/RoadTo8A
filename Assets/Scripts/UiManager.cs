using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject programListCanvas;
    public GameObject addProgramModal;
    public GameObject addHangboardCanvas;
    public GameObject addhangboardModal;

    public GameObject volume;


    private void Start()
    {
        programListCanvas.SetActive(true);
        addProgramModal.SetActive(false);
        addHangboardCanvas.SetActive(false);
        addhangboardModal.SetActive(false);

        volume.SetActive(false);
    }
}
