using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LogInManager : MonoBehaviour
{
    public InputField EmailInp, PassInp;
    public GameObject warning;


    public void OnClickLogin()
    {
        if(EmailInp.text.Length!=0 && PassInp.text.Length!=0)
        {
            PlayerPrefs.SetString("email",EmailInp.text);
            Ui_manager.Instance.EnableSinglePanels(StatePanel.Home);

        }
        else
        {
            warning.SetActive(true);
            DOTween.Sequence().AppendInterval(1f).OnComplete(() => {
                warning.SetActive(false);
            });
        }
    }

}
