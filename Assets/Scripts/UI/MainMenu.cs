using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    TextMeshProUGUI textMeshProUGUI;
   
   public void Awake(){

        textMeshProUGUI = GameObject.Find("usernameLoggedIn").GetComponent<TextMeshProUGUI>();
       // PlayerNamePersistance playerNamePersistance = new PlayerNamePersistance();
        string userName = PlayerNamePersistance.getPlayername();
        Debug.Log("This is received: " + userName);

        textMeshProUGUI.SetText(userName);
   }

    public void PlayGame(){
        ScoresModel.ResetLocals();
        SceneManager.LoadScene(1);
    }

    
    public void QuitGame(){
        Debug.Log("Quit pressed");
        Application.Quit();
    }

}
