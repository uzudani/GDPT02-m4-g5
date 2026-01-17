using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Options : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;

    public void OnNewGameClick() // Funzione
    {
        Debug.Log("Hai premuto NEW GAME"); // Conferma del funzionamento con Debug.Log
        gameObject.SetActive(false); // Nascondo il menu (lo fa in automatico?)

        SceneManager.LoadScene(1); // Carico la scena in build posizione 1
    }
    public void OnSaveOptionsClick()
    {
        Debug.Log("Le opzioni sono state salvate");
    }
    public void OnOptionsClick()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void OnReturnClick()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void OnCreditsClick()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void OnCreditsReturnClick()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void OnExitClick()
    {
        Debug.Log("Sei uscito dal gioco");

        Application.Quit(); // Funziona solo in build
    }
}
