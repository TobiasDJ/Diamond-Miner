using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class DeathUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CurrentDeathsText;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDeathsText.text = ScoresModel.GetDeath(index);
    }

    public void SetIndex(int i){
        index = i;
    }
}
