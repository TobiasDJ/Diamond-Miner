using System.Runtime.Serialization;
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

  [SerializeField] Transform History;
  [SerializeField] Transform MainMenu;
  [SerializeField] Transform ChooseName;

  private const string NAME_ID = "PLAYER_NAME";

  private void Awake(){
        PlayerName = GameObject.Find("PlayerText").GetComponent<TextMeshProUGUI>();
        ChooseNameButton = GameObject.Find("ChooseNameButton").GetComponent<TextMeshProUGUI>();
        Debug.Log("name is :" +  PlayerPrefs.GetString(NAME_ID));
        if (CheckIfUserNameIsChoosen()){
           History.gameObject.SetActive(false);
           MainMenu.gameObject.SetActive(true);
           ChooseName.gameObject.SetActive(false);
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
        return true;
    }
  }

}
