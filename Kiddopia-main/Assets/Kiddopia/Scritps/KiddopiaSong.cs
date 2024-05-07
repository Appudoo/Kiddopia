using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiddopiaSong : MonoBehaviour
{
    public GameObject Level;
    public void OnClickPlayVideo(int index)
    {
        PlayerPrefs.SetInt("Video",index);
        GameObject L =  Instantiate(Level);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();

    }

    public void OnClickHome()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.Home);
    }
}
