using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerNameTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private const string NAME_ID = "PLAYER_NAME";



  public void PersistPlayerName(string name){
      PlayerPrefs.SetString(NAME_ID, name); 
  }

  public bool CheckIfUserNameIsChoosen(){
    if(string.IsNullOrEmpty(PlayerPrefs.GetString(NAME_ID))){
        return false;
    }
    else{
        return false;
    }
  }

  public void OnChooseNamePressed(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
  }
}
