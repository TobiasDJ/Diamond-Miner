using System;
using System.Net.Mime;
using System.Numerics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Random = UnityEngine.Random;
using TMPro;

public class Hiscore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    

    private MongoDbStorage storage = new MongoDbStorage();

    // Called when hiscore is showed
    private void Awake(){
        entryContainer = transform.Find("HiscoreEntryContainer");
        entryTemplate = entryContainer.Find("HiscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        List<HiscoreModel> top10Models =  storage.FetchTop15Scores();
        float templateSpacing = 20;
        int rows = 15;
        for(int i = 0; i<rows; i++){
            Transform entryTranform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTranform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateSpacing*i);
            entryTranform.gameObject.SetActive(true);

           entryTranform.Find("NameText").GetComponent<TextMeshProUGUI>().SetText(top10Models[i].Name);
            var rank = entryTranform.Find("RankText").GetComponent<TextMeshProUGUI>().text =(i+1).ToString();
           entryTranform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = top10Models[i].Score.ToString();

            if(rank == "1"){
                entryTranform.Find("NameText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 108, 0, 255);
                entryTranform.Find("RankText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 108, 0, 255);
                entryTranform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 108, 0, 255);
            }if(rank == "2"){
                entryTranform.Find("NameText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 0, 255);
                entryTranform.Find("RankText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 0, 255);
                entryTranform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 0, 255);
            }if(rank == "3"){
                entryTranform.Find("NameText").GetComponent<TextMeshProUGUI>().color = new Color32(47, 200, 29, 255);
                entryTranform.Find("RankText").GetComponent<TextMeshProUGUI>().color = new Color32(47, 200, 29, 255);
                entryTranform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color32(47, 200, 29, 255);
            }
            
        }

    }

}
