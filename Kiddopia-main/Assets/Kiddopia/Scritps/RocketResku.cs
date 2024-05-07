using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketResku : MonoBehaviour
{
    public GameObject[] Level;
    public GameObject[] Levelbutton;
    public GameObject[] Rocketparts;

    public static RocketResku Instance;

    private void Awake()
    {
        Instance = this;    
    }

    private void OnEnable()
    {
        int currentlevel = PlayerPrefs.GetInt("Level3");
        for (int i = 0; i <=currentlevel; i++)
        {
            //Levelbutton[i].GetComponent<Button>().interactable = true;
            //Rocketparts[i].SetActive(true);
        }
    }
    public void OnClickGamePlay(int Index)
    {
       
        GameObject L =  Instantiate(Level[Index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();

    }
}
