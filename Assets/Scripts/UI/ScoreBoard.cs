using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]  Canvas ScoreBoardContainer;
    [SerializeField]  Canvas LevelScoreTemplate;

   private void Awake(){

        float templateSpacing = 1f;
        float startX = 3.795f;
        float startY = 10.16f;
        int lvls = 5;
        int currentLvl = SceneManager.GetActiveScene().buildIndex-1;
        for(int i = 0; i<lvls; i++){
            Transform entryTranform = Instantiate(LevelScoreTemplate.transform, ScoreBoardContainer.transform);
            RectTransform entryRectTransform = entryTranform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(startX, startY-(templateSpacing*i));
            entryTranform.gameObject.SetActive(true);
            
            // Start timer of current lvl
            if(i== currentLvl){
                var script =  entryTranform.Find("CurrentTimeText").gameObject.GetComponent<LevelTimeTicker>();
                script.StartTimer();
            }

            ScoresModel.SetLevel(i, (i+1).ToString());
            entryTranform.Find("LevelText").GetComponent<TextMeshProUGUI>().SetText(ScoresModel.GetLevel(i));
            
            if(!string.IsNullOrEmpty(ScoresModel.GetDeath(i))){
                entryTranform.Find("CurrentDeathsText").GetComponent<TextMeshProUGUI>().SetText(ScoresModel.GetDeath(i));
            }
            else{
                ScoresModel.SetDeath(i, "0");
                entryTranform.Find("CurrentDeathsText").GetComponent<TextMeshProUGUI>().SetText(ScoresModel.GetDeath(i));
            }
            var deathUpdater =  entryTranform.Find("CurrentDeathsText").gameObject.GetComponent<DeathUpdater>();
            deathUpdater.SetIndex(i);

            if(!string.IsNullOrEmpty(ScoresModel.GetTime(i))){
                entryTranform.Find("CurrentTimeText").GetComponent<TextMeshProUGUI>().SetText(ScoresModel.GetTime(i));
            }
            else{
                ScoresModel.SetTime(i, "0");
                entryTranform.Find("CurrentTimeText").GetComponent<TextMeshProUGUI>().SetText(ScoresModel.GetTime(i));
            }
        }

    }
}


public static class ScoresModel
{
    private static string BASE_LEVEL = "LEVEL-";
    private static string BASE_TIMER = "TIMER-";
    private static string BASE_DEATHS= "DEATH-";
    

    public static string GetLevel(int index){
        return PlayerPrefs.GetString(BASE_LEVEL+index.ToString()); 
    }

    public static void SetLevel(int index, string level){
        PlayerPrefs.SetString(BASE_LEVEL+index.ToString(), level); 
    }

     public static string GetTime(int index){
        return PlayerPrefs.GetString(BASE_TIMER+index.ToString()); 
    }

    public static void SetTime(int index, string time){
        PlayerPrefs.SetString(BASE_TIMER+index.ToString(), time); 
    }

    public static string GetDeath(int index){
        return PlayerPrefs.GetString(BASE_DEATHS+index.ToString()); 
    }

    public static void SetDeath(int index, string death){
        PlayerPrefs.SetString(BASE_DEATHS+index.ToString(), death); 
    }

    public static void ResetLocals()
    {
        int lvls = 5;
        for(int i=0; i<lvls; i++){
            SetDeath(i,"0");
            SetTime(i, "0");
        }
    }

}
