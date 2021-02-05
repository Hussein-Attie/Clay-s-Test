using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIupdates : MonoBehaviour
{
    int points;
    int deaths;
    public TextMeshProUGUI pointstext;
    public TextMeshProUGUI deathtxt;
    private static UIupdates instance;
    ////void Awake()
    ////{
    ////    DontDestroyOnLoad(this);

    ////    if (instance == null)
    ////    {
    ////        instance = this;
    ////    }
    ////    else
    ////    {
    ////        DestroyObject(gameObject);
    ////    }
    ////}

    // Start is called before the first frame update
    void Start()
    {
        deaths = PlayerPrefs.GetInt("deaths");
        points = PlayerPrefs.GetInt("points");
        PlayerController.OnObstacleOvioded += Win ;
        PlayerController.Ondeath           += Lose;
    }

    // Update is called once per frame
    void Update()
    {
      
        Debug.Log(deaths);
        pointstext.text = "Points :"+ PlayerPrefs.GetInt("points").ToString();
        deathtxt.text = "Deaths :" + PlayerPrefs.GetInt("deaths").ToString();
    }
    void Win()
    {
        points++;
        PlayerPrefs.SetInt("points", points);
    }
    void Lose()
    {
        deaths++;
        PlayerPrefs.SetInt("deaths", deaths);
    }
   
}
