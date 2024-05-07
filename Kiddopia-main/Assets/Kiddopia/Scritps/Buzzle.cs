using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Buzzle : MonoBehaviour
{
    public GameObject[] Level;
    public GameObject[] Levelbutton;

    public static Buzzle Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        int currentlevel = PlayerPrefs.GetInt("Level6");
        for (int i = 0; i <= currentlevel; i++)
        {
            Levelbutton[i].GetComponent<Button>().interactable = true;
        }
    }
    public void OnClickGamePlay(int Index)
    {
        print("Levelstart");
        GameObject L = Instantiate(Level[Index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();

    }
}
