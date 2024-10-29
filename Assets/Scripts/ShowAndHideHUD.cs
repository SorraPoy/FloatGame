using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideHUD : MonoBehaviour
{
    public GameObject TargetPaneltoHide;
    public GameObject TargetPaneltoShow;
    public void ShowPanel()
    {
        TargetPaneltoShow.SetActive(true);
        TargetPaneltoHide.SetActive(false);

    }

    public void HidePanel()
    {
        TargetPaneltoShow.SetActive(false);
        TargetPaneltoHide.SetActive(true);
    }
}
