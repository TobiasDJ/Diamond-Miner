using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;


public class PlayerNamePersistance : MonoBehaviour
{

  TextMeshProUGUI PlayerName;
  TextMeshProUGUI ChooseNameButton;

  private const string NAME_ID = "PLAYER_NAME";

  private void Awake(){
        PlayerName = GameObject.Find("PlayerText").GetComponent<TextMeshProUGUI>();
        ChooseNameButton = GameObject.Find("ChooseNameButton").GetComponent<TextMeshProUGUI>();

        // If username is picked, to to main menu 
        // TODO does this actually work?
        if (CheckIfUserNameIsChoosen()){
            ChooseNameButton.GetComponent<Button>().onClick.Invoke();
        }
    }



  public async void PersistPlayerName(string name){
      if(PlayerName != null){
        await Task.Delay(100);
        PlayerPrefs.SetString(NAME_ID,PlayerName.text); 
        Debug.Log(PlayerPrefs.GetString(NAME_ID).ToString());
      }
  }

  public bool CheckIfUserNameIsChoosen(){
    if(string.IsNullOrEmpty(PlayerPrefs.GetString(NAME_ID))){
        return false;
    }
    else{
        return false;
    }
  }

}
