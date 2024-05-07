using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatePanel
{
    Home,
    ABCAnimalsAdventures,
    ColoringPad,
    MathWhiz,
    Login,
    Over,
    RocketResku,
    Buzzle,
    KiddopiaSongs,
    SplashScreen,
    Lingoland
    
}

public class Ui_manager : MonoBehaviour
{
    public static Ui_manager Instance;
    

    public List<PanelManage> Panel = new List<PanelManage>();

    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
       
        

    }


    public void EnableSinglePanels(StatePanel CurrentPanel)
    {
        foreach (var item in Panel)
            item.Panel.SetActive(false);

        Panel.Find(x => x.Sp == CurrentPanel).Panel.SetActive(true);
       
    }
    public void DisableAllPanel()
    {
        foreach (var item in Panel)
            item.Panel.SetActive(false);
       
    }
}
[System.Serializable]
public class PanelManage
{
    public GameObject Panel;
    public StatePanel Sp;
}