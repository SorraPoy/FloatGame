using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowandClosePopUp : MonoBehaviour
{
    public GameObject TargetPanel;

    public void ShowPanel()
    {
        TargetPanel.SetActive(true);
    }

    public void HidePanel()
    {
        TargetPanel.SetActive(false);
    }
}
