using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarController : MonoBehaviour
{
  
    // Start is called before the first frame update
    public void StarGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();// Fecha o aplicativo
    }
}
