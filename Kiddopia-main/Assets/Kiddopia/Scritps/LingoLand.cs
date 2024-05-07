using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingoLand : MonoBehaviour
{
    public static LingoLand Instance;
    public List<GameObject> Level;
    public GameObject Alpha,btn;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    public void Onclicklevel(int index)
    {

        GameObject L =  Instantiate(Level[index], new Vector3(0,0,0),Quaternion.identity);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
    }

    public void onclickPhonix()
    {

    }

    public void OnclickAlphabet()
    {
        btn.SetActive(false);
        Alpha.SetActive(true);
    }

    public void onclickHome()
    {
        btn.SetActive(false);
        
    }
}
