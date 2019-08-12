using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject MainUIPanel;
    public GameObject PauseMenu;
    public Transform LevelsButton;
    public GameObject InstructionPanel;
    private Button LevelSelectButton;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1.0f;
        MainUIPanel.SetActive(true);
        PauseMenu.SetActive(false);
        InstructionPanel.SetActive(false);
        

    }
	
   public void ShowInstructions()
    {
        InstructionPanel.SetActive(true);
    }
    public void HideInstructions()
    {
        InstructionPanel.SetActive(false);
    }
    
    public void GamePaused()
    {
        Time.timeScale = 0.0f;
        LevelsButton.GetComponent<Button>().interactable = false;
        PauseMenu.SetActive(true);
    }

    public void GameUnpaused()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MAIN MENU");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.visible = true;
            GamePaused();
        }
	}
}
