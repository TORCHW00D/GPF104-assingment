using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public GameObject MenuPanel;
    public GameObject LevelSelectPanel;

	// Use this for initialization
	void Start () {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
	}
	
	public void ShowLevelPanel()
    {
        LevelSelectPanel.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Practice Level");
    }

    public void Level1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Scene()
    {
        SceneManager.LoadScene("Level3");
    }
}
