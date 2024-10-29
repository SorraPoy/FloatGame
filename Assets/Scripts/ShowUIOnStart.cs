using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShowUIOnStart : MonoBehaviour
{
    public GameObject TargetPaneltoHide;
    public GameObject TargetPaneltoShow;
    public GameObject TargetPanelonStart;


    private void Start()
    {
        // Show the UI panel when the scene starts
        ShowPanelonStart();
    }

    public void ShowPanelonStart()
    {
        TargetPanelonStart.SetActive(true);
        TargetPaneltoHide.SetActive(false);
    }

    public void ShowPanel()
    {
        TargetPaneltoShow.SetActive(true);
        TargetPaneltoHide.SetActive(false);
    }

    public void HidePanel()
    {
        TargetPaneltoHide.SetActive(false);
        TargetPaneltoShow.SetActive(true);
    }
}
