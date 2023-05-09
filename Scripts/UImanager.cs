using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public void StartButton()
    {
        //Bæta við Animation keyrlsu
        SceneManager.LoadScene(1); // byrja borðið
    }
    public void InfoButton() 
    {
        SceneManager.LoadScene(3); // fer yfir á info scenes
    }
    public void QuitButton()
    {
        SceneManager.LoadScene(0); // fer aftur á Start page
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(1); // fer aftur á leiksvæðið, endurræst
    }
}
