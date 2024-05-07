using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameManager : MonoBehaviour
{
    public GameObject WinPanel;

    public static AllGameManager Instance;
    public GameObject[] g;
    private void Awake()
    {
        Instance = this;
        HomeManager.instance.gameIndex = 3;

        //g = GameObject.FindGameObjectsWithTag("Currect");
    }
    public void OnClickRocketReskuToBackHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.RocketResku);
    }
    public void OnClickMathWlidToBack()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.MathWhiz);
    }
    public void OnClickNext()
    {

        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.RocketResku);
    }
}
