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
    private MongoDbStorage storage;
    


    // Called when hiscore is showed
    private void Awake(){
        entryContainer = transform.Find("HiscoreEntryContainer");
        entryTemplate = entryContainer.Find("HiscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        storage = new MongoDbStorage();
        storage.AddOrUpdate(new HiscoreModel("peter", 8200));

        List<HiscoreModel> top10Models =  storage.FetchTop15Scores();
        float templateSpacing = 50;
        int rows = 15;
        for(int i = 0; i<rows; i++){
            Transform entryTranform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTranform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateSpacing*i);
            entryTranform.gameObject.SetActive(true);


            entryTranform.Find("NameText").GetComponent<TextMeshProUGUI>().SetText(top10Models[i].Name);
            entryTranform.Find("RankText").GetComponent<TextMeshProUGUI>().text =(i+1).ToString();
            entryTranform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = top10Models[i].Score.ToString();
        }

    }

}
