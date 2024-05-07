using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathWhiz : MonoBehaviour
{
    public List<GameObject> Levels;
    public void OnClickGamePlay(int Index)
    {
        GameObject L = Instantiate(Levels[Index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
    }
}
