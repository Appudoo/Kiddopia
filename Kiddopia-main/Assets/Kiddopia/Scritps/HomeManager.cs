using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeManager : MonoBehaviour
{
    public static HomeManager instance;

    public GameObject MainHolder;

    public InputField email, pass;
    public GameObject worning;
    public GameObject login;

    public GameObject L;

    public int gameIndex;

    private void Awake()
    {
        instance = this;
    }
    public void OnClickAbcAnimalAdventures()
    {
        gameIndex = 0;
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }

    public void OnClickColoringPad()
    {
        SceneManager.LoadScene("MainScene");
        //Ui_manager.Instance.EnableSinglePanels(StatePanel.ColoringPad);
    }

    public void OnClickMathsWhiz()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.MathWhiz);
    }
    public void OnClickBuzzle()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.Buzzle);
    }

    public void OnClickHome()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.Home);

    }

    public void OnClickRocketResku()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.RocketResku);
    }

    public void OnClickKiddopiaSounds()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.KiddopiaSongs);
    }

    public void OnClickbacktohome()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.MathWhiz);
    }

    public void OnClickbackLingoLand()
    {
        Ui_manager.Instance.EnableSinglePanels(StatePanel.Lingoland);
    }

    public void OnClickSubmit()
    {
        if (email.text.Length!=0 && pass.text.Length!=0)
        {
            //login.SetActive(false);
            //homepanel.SetActive(true);
            Ui_manager.Instance.EnableSinglePanels(StatePanel.Home);
        }
        else
        {
           
            worning.SetActive(true);
            DOTween.Sequence().AppendInterval(2f).OnComplete(() => {
                worning.SetActive(false);
            });
        }
    }
}
