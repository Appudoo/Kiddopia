
using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;



public class level4 : MonoBehaviour
{
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        //randomPos();
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0));
    }

    private void OnMouseDown()
    {
        if (lingo2.instance.iswin)
            return;

        string s = this.transform.GetComponent<SpriteRenderer>().sprite.name;
        string[] c = s.Split('@');
        Debug.Log(c[0]);
        if (c[0] == lingo2.instance.c.ToLower())
        {
            Debug.Log("win");
            this.transform.GetChild(0).gameObject.SetActive(true);
            lingo2.instance.particleobj.SetActive(true);
            lingo2.instance.iswin = true;
            if (lingo2.instance.balls.Count < lingo2.instance.countrightanswer)
            {

                DOTween.Sequence().AppendInterval(2f).OnComplete(() =>
                {

                    lingo2.instance.Winpanel.SetActive(true);
                });

                print("gameclose");
            }
            else
            {
                for (int i = 0; i < lingo2.instance.btns.Length; i++)
                {
                    lingo2.instance.btns[i].transform.DOScale(Vector3.zero, 0.5f);
                }
                DOTween.Sequence().AppendInterval(1f).OnComplete(() =>
                {
                    lingo2.instance.changetitletext();
                    transform.GetChild(0).gameObject.SetActive(false);
                });
            }
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.5f).OnComplete(() =>
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.DOScale(new Vector3(0.26f, 0.26f, 0.26f), 0.3f);
            });
        }
    }

    // Update is called once per frame

}
