using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField PlayernameInput;
    public Text errorMessageText; // Referência ao objeto de texto para exibir a mensagem de erro
    // Start is called before the first frame update
    void Start()
    {
        errorMessageText.gameObject.SetActive(false); // Certifique-se de que a mensagem de erro esteja oculta no início
    }
    public void StartGame()
    {
        if (PlayernameInput.text.Length > 0)
        {
            GameController.PlayerName = PlayernameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            // Mostrar a mensagem de erro se o campo de nome estiver vazio
            errorMessageText.gameObject.SetActive(true);
            errorMessageText.text = "Por favor, insira um nome!";
        }
        
    }
   
}
