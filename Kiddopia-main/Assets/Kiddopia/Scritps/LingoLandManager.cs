using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LingoLandManager : MonoBehaviour
{
    public static LingoLandManager instance;
    public Text titletxt;
    public List<string> lowercaseletters = new List<string>();
    public List<Button> characterbutton = new List<Button>();
    public List<Sprite> smallCharacter;
    public GameObject[] btns;
    public int currectanswer;
    public string c;
    public GameObject particleobj, middlerbar;
    public List<int> buttonIndex = new List<int>();
    public bool iswin;

    public int countrightanswer;

    public List<GameObject> balls;

    public GameObject Winpanel;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        changetitletext();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changetitletext()
    {
        buttonIndex.Clear();
        int r = Random.RandomRange(0, lowercaseletters.Count);
        titletxt.text = "Find the letter " + lowercaseletters[r].ToString();
        currectanswer = r;
        c = lowercaseletters[r].ToString();
        particleobj.SetActive(false);
        iswin = false;
        middlerbar.transform.localScale = new Vector3(0, 0, 0);
        middlerbar.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
        
        for (int i = 0; i < balls.Count; i++)
        {
            if (i < countrightanswer)
            {
                balls[i].SetActive(true);
            }
        }
        countrightanswer++;
        
        for (int i = 0; i < characterbutton.Count; i++)
        {
            //characterbutton[i].onClick.RemoveAllListeners();
            int index = i;
            int characterindex = Random.Range(0, smallCharacter.Count);
            while (buttonIndex.Contains(characterindex))
            {
                characterindex = Random.Range(0, smallCharacter.Count);
            }
            print("===>" + characterindex);
            buttonIndex.Add(characterindex);
            //characterbutton[i].gameObject.GetComponent<Image>().sprite = smallCharacter[characterindex];
            btns[i].gameObject.GetComponent<SpriteRenderer>().sprite = smallCharacter[characterindex];
            //characterbutton[i].onClick.AddListener(() =>
            //{
            //    Onclickbutton(index);
            //});
            if (r == characterindex)
            {
                currectanswer = index;
            }
            //characterbutton[index].transform.GetChild(0).gameObject.SetActive(false);
        }
        Debug.Log(r);

        if (!buttonIndex.Contains(r))
        {
            Debug.Log("-------------------------------------------------------------------");
            int randompoistion = Random.Range(0, characterbutton.Count);
            Debug.Log("------------------------------>" + randompoistion);
            btns[randompoistion].GetComponent<SpriteRenderer>().sprite = smallCharacter[r];
            Debug.Log("------------------------------>" + smallCharacter[r].name);
            //characterbutton[randompoistion].gameObject.GetComponent<Image>().sprite = smallCharacter[r];
            //characterbutton[randompoistion].onClick.AddListener(() => {
            //    Onclickbutton(randompoistion);
            //});
            currectanswer = randompoistion;
        }


    }

    public void Onclickbutton(int index)
    {
        print(index);
        if (iswin)
            return;
        if (index == currectanswer)
        {
            characterbutton[index].transform.GetChild(0).gameObject.SetActive(true);
            particleobj.SetActive(true);
            iswin = true;
            print("Win");
            if (balls.Count < countrightanswer)
            {
                DOTween.Sequence().AppendInterval(2f).OnComplete(() =>
                {
                    Winpanel.SetActive(true);
                });

                print("gameclose");
            }
            else
            {
                DOTween.Sequence().AppendInterval(2f).OnComplete(() =>
                {
                    changetitletext();
                });
            }

        }
        else
        {
            characterbutton[index].transform.GetChild(1).gameObject.SetActive(true);
            characterbutton[index].transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.5f).OnComplete(() =>
            {
                characterbutton[index].transform.GetChild(1).gameObject.SetActive(false);
                characterbutton[index].transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
            });
        }
    }

    public void OnClickBack()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.Lingoland);
    }
}
