using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

#if UNITY_WEBGL
using System.IO;
#endif

public class ScrollListManager : MonoBehaviour
{
    public string saveIndexString = "ColoringList";

    public void LoadGame(int index)
    {
        MusicController.USE.PlaySound(MusicController.USE.clickSound);

        PlayerPrefs.SetInt(saveIndexString, index);
        PlayerPrefs.Save();

        if (transform.GetChild(0).transform.GetChild(index).childCount > 0)
        {
            ColoringBookManager.maskTexIndex = index;
        }
        else
        {
            ColoringBookManager.maskTexIndex = -1;
        }

        ColoringBookManager.ID = saveIndexString + index.ToString();
        SceneManager.LoadScene("PaintScene");
    }
}