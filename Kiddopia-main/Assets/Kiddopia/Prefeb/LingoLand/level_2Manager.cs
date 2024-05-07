
using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using UnityEngine;
using UnityEngine.UIElements;

public class level_2Manager : MonoBehaviour
{
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        //randomPos();
        this.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0));
    }

    private void OnMouseDown()
    {
        if (LingoLandManager.instance.iswin)
            return;

        string s = this.transform.GetComponent<SpriteRenderer>().sprite.name;
        string[] c = s.Split('@');
        Debug.Log(c[0]);
        if (c[0].ToUpper() == LingoLandManager.instance.c)
        {
            Debug.Log("win");
            this.transform.GetChild(0).gameObject.SetActive(true);
            LingoLandManager.instance.particleobj.SetActive(true);
            LingoLandManager.instance.iswin = true;
            if (LingoLandManager.instance.balls.Count < LingoLandManager.instance.countrightanswer)
            {
                DOTween.Sequence().AppendInterval(2f).OnComplete(() =>
                {
                    LingoLandManager.instance.Winpanel.SetActive(true);
                });

                print("gameclose");
            }
            else
            {
                DOTween.Sequence().AppendInterval(2f).OnComplete(() =>
                {
                    LingoLandManager.instance.changetitletext();
                    transform.GetChild(0).gameObject.SetActive(false);
                });
            }
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.DOScale(new Vector3(0.30f, 0.3f, 0.3f), 0.5f).OnComplete(() =>
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.DOScale(new Vector3(0.26f, 0.26f, 0.26f), 0.3f);
            });
        }
    }

    // Update is called once per frame

}
