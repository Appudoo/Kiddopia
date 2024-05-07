using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class SplashManager : MonoBehaviour
{
    public static SplashManager instance;
    public Slider slider;
    public bool isDownloading, AnimalPart1, AnimalPart2;
    UnityWebRequest www;
    float sliderValue;
    public List<GameObject> list, list1;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {

        if (PlayerPrefs.GetString("email") == "")
        {
            Ui_manager.Instance.EnableSinglePanels(StatePanel.Login);
        }
        else
        {
            Ui_manager.Instance.EnableSinglePanels(StatePanel.Home);
        }
    }
    
}
