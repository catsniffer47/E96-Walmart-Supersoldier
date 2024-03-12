using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonForEndings : MonoBehaviour
{
    public DoNotDestroy musicController;
    // Start is called before the first frame update


    void Start()
    {
    }

    public void LoadScene()
    {


        SceneManager.LoadScene("Start Screen");
        musicController = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<DoNotDestroy>();
        if (musicController != null)
        {
            musicController.StartMusic();
        }

    }


}
