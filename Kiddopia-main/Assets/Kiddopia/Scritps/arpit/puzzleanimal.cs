using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleanimal : MonoBehaviour
{
    public static puzzleanimal instance;
    public List<GameObject> Levels;
    public List<GameObject> AnimalsLevel;
    public int levelNo;
    private void Awake()
    {
        if(instance == null)
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickPuzzleTheAnimal(int index)
    {
        PlayerPrefs.SetInt("puzzleTheAnimal", index);
        Debug.Log(index);
        GameObject L = Instantiate(Levels[index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
    }

}
