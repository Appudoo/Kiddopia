using DG.Tweening;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ABCAnimalsAdventures : MonoBehaviour
{

    public GameObject Winpanel, loader;

    public static ABCAnimalsAdventures Instance;
    UnityWebRequest www;
    public GameObject AbcAnimalPanel, FeedAnimalPanel, BathAnimalPanel, puzzlePanel, diffanimalPanel, joint, alpabet;
    bool isDownloading;
    public Slider progress, progress1;
    public void OnClickFeedAnimal()
    {
        AbcAnimalPanel.gameObject.SetActive(false);
        FeedAnimalPanel.gameObject.SetActive(true);
        //StartCoroutine(DownloadAssetsFromServer());
        //LoadAssetBundle();
    }
    public void OnClickBathAnimal()
    {
        AbcAnimalPanel.gameObject.SetActive(false);
        BathAnimalPanel.gameObject.SetActive(true);
        //StartCoroutine(DownloadAssetsFromServerBath());
    }

    public void OnClickBackToFeedAnimal()
    {
        AbcAnimalPanel.gameObject.SetActive(true);
        FeedAnimalPanel.gameObject.SetActive(false);
    }
    public void OnClickBackToBathAnimal()
    {
        AbcAnimalPanel.gameObject.SetActive(true);
        BathAnimalPanel.gameObject.SetActive(false);
    }
    public void onclickPuzzle()
    {
        puzzlePanel.gameObject.SetActive(true);
        AbcAnimalPanel.gameObject.SetActive(false);
    }

    public void onclickPuzzleBack()
    {
        puzzlePanel.gameObject.SetActive(false);
        AbcAnimalPanel.gameObject.SetActive(true);
    }

    public void onclickDiffAnimal()
    {
        diffanimalPanel.SetActive(true);
        AbcAnimalPanel.SetActive(false);
    }
    public void onclickBackDiffPanel()
    {
        diffanimalPanel.SetActive(false);
        AbcAnimalPanel.SetActive(true);
    }
    public void onclickJointAnimal()
    {
        joint.SetActive(true);
        AbcAnimalPanel.SetActive(false);
    }
    public void onclickBackJointAnimal()
    {
        Debug.Log("hello");
        joint.SetActive(false);
        AbcAnimalPanel.SetActive(true);
    }

    public void onclickAlpha()
    {
        alpabet.gameObject.SetActive(true);
        AbcAnimalPanel.gameObject.SetActive(false);
    }

    public void onclickAlphaBack()
    {
        alpabet.gameObject.SetActive(false);
        AbcAnimalPanel.gameObject.SetActive(true);
    }
    private void Awake()
    {
        Instance = this;
    }
    IEnumerator DownloadAssetsFromServer()
    {
        GameObject go = null;
        string url = "https://drive.google.com/uc?export=download&id=1fLpG3gkR6E74tQhVO2mxdvIy8iW1OX8Q"; // Replace with your direct asset bundle link
        using (www = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            isDownloading = true;

            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error on the GET request at: " + url + ". Error: " + www.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                go = bundle.LoadAsset<GameObject>(bundle.GetAllAssetNames()[0]); // Assuming your asset is a GameObject
                bundle.Unload(false);
            }
            www.Dispose();
            //AnimalPart1 = true;

            isDownloading = false;


        }
        instantiateGameObjectFromAssetBundle(go);
    }

    void instantiateGameObjectFromAssetBundle(GameObject go)
    {
        Debug.Log("----------------------------------------------------------------");
        if (go != null)
        {
            GameObject instanceGo = Instantiate(go);

            instanceGo.transform.SetParent(this.gameObject.transform);
            instanceGo.transform.position = new Vector3(0, 0, 0);
            instanceGo.transform.localScale = new Vector3(1, 1, 1);
            //FeedAnimal.Instance.Levels.Clear();
            for (int i = 0; i < go.GetComponent<allLevel>().levels.Count; i++)
            {

                FeedAnimal.Instance.Levels.Add(go.GetComponent<allLevel>().levels[i]);

            }
            //instanceGo.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width,Screen.height);
            //instanceGo.transform.DOMove(Vector2.zero,0f);
        }
        else
        {
            Debug.Log("Your asset bundle GameObject is null");
        }
    }


    IEnumerator DownloadAssetsFromServerBath()
    {
        GameObject go = null;
        string url = "https://drive.google.com/uc?export=download&id=1oqJ4zFDybyemwrZNUlcZenft1SdpSAW5"; // Replace with your direct asset bundle link
        using (www = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            isDownloading = true;
            progress1.gameObject.SetActive(true);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error on the GET request at: " + url + ". Error: " + www.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                go = bundle.LoadAsset<GameObject>(bundle.GetAllAssetNames()[0]); // Assuming your asset is a GameObject
                bundle.Unload(false);
            }
            www.Dispose();
            isDownloading = false;
            progress1.gameObject.SetActive(false);

        }
        instantiateGameObjectFromAssetBundleBath(go);
    }

    void instantiateGameObjectFromAssetBundleBath(GameObject go)
    {
        Debug.Log("----------------------------------------------------------------");
        if (go != null)
        {
            GameObject instanceGo = Instantiate(go);

            //instanceGo.transform.SetParent(this.gameObject.transform);
            instanceGo.transform.position = new Vector3(0, 0, 0);
            instanceGo.transform.localScale = new Vector3(1, 1, 1);
            Bath_Aimal.Instance.Levels.Clear();
            for (int i = 0; i < instanceGo.GetComponent<AllBathlevel>().BathANimalLvl.Count; i++)
            {

                Bath_Aimal.Instance.Levels.Add(instanceGo.GetComponent<AllBathlevel>().BathANimalLvl[i]);
            }
            //instanceGo.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width,Screen.height);
            //instanceGo.transform.DOMove(Vector2.zero,0f);
        }
        else
        {
            Debug.Log("Your asset bundle GameObject is null");
        }
    }

    #region Asset Bundle Handler
    void LoadAssetBundle()
    {
        string assetBundlePath = Path.Combine(Application.persistentDataPath, "FeedAnimal.bundle");
        Debug.Log(assetBundlePath);
        if (File.Exists(assetBundlePath))
        {
            // Asset bundle already exists in local storage, load it
            loader.SetActive(true);
            LoadAssetBundleFromFile(assetBundlePath);
            Debug.Log("FeedAnimal");

        }
        else
        {
            // Asset bundle doesn't exist locally, download it from server
            isDownloading = true;
            StartCoroutine(DownloadAssetBundle("https://drive.google.com/uc?export=download&id=1fLpG3gkR6E74tQhVO2mxdvIy8iW1OX8Q"));
            Debug.Log("FeedAnimal");

        }
    }

    void LoadAssetBundleFromFile(string path)
    {
        Debug.Log("FeedAnimal");

        AssetBundle bundle = AssetBundle.LoadFromFile(path);
        if (bundle != null)
        {

            // Example: Load a GameObject from the asset bundle

            GameObject go = bundle.LoadAsset<GameObject>(bundle.GetAllAssetNames()[0]);
            bundle.Unload(false);
            Debug.Log("-----------------");

            GameObject instanceGo = Instantiate(go);
            instanceGo.transform.SetParent(this.gameObject.transform);
            instanceGo.transform.position = new Vector3(0, 0, 0);
            instanceGo.transform.localScale = new Vector3(1, 1, 1);
            for (int i = 0; i < go.GetComponent<allLevel>().levels.Count; i++)
            {
                FeedAnimal.Instance.Levels.Add(go.GetComponent<allLevel>().levels[i]);
            }


            loader.SetActive(false);
        }
        else
        {
            Debug.LogError("Failed to load asset bundle from internal storage.");
        }
    }

    IEnumerator DownloadAssetBundle(string url)
    {
        Debug.Log("FeedAnimal");

        progress.gameObject.SetActive(true);
        www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to download asset bundle: " + www.error);
        }
        else
        {
            // Save downloaded asset bundle to local storage
            string assetBundlePath = Path.Combine(Application.persistentDataPath, "FeedAnimal.bundle");
            File.WriteAllBytes(assetBundlePath, www.downloadHandler.data);
            // Load asset bundle from local storage
            LoadAssetBundleFromFile(assetBundlePath);
            isDownloading = false;
            progress.gameObject.SetActive(false);
        }
    }
    #endregion

    //public void OnClickNext()
    //{
    //    OnClickFeedTheAnimal();
    //}
    private void Update()
    {
        if (isDownloading)
        {
            // Calculate and display download progress percentage
            float downloadProgress = www.downloadProgress;
            Debug.Log("Download progress: " + (downloadProgress * 100) + "%");
            progress.value = (downloadProgress * 100) / 2;
            progress1.value = (downloadProgress * 100);
        }
    }
}
