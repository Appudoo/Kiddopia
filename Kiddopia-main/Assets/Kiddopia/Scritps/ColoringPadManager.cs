using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColoringPadManager : MonoBehaviour
{
    public string saveIndexString = "ColoringList";
    public void OnClickHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void LoadGame(int index)
    {
        MusicController.USE.PlaySound(MusicController.USE.clickSound);

        PlayerPrefs.SetInt(saveIndexString, index);
        PlayerPrefs.Save();

        if (transform.GetChild(index).childCount > 0)
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
