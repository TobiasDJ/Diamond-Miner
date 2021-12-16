using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestory : MonoBehaviour
{

    void Awake()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Music");
        if (gameObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
