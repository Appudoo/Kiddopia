using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diffANimal : MonoBehaviour
{
    public static diffANimal instance;
    public List<GameObject> level;
    public int levelNO;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("levelpuzzle"))
        {
            levelNO = PlayerPrefs.GetInt("levelpuzzle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickFeedTheAnimal(int index)
    {
        PlayerPrefs.SetInt("diffTheAnimal", index);
        Debug.Log(index);
        GameObject L = Instantiate(level[index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
    }
}
