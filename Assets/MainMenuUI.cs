using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject mainMenu;
    public Dictionary<int, Resolution> res;
    public Dropdown resolutionDropDown;
    public Toggle fullScreenToggle;
    

    public void Start()
    {
        int[] resolution = SettingsManager.settingsManager.loadResolution();
        SettingsManager.settingsManager.ApplyResolution(resolution);

        bool fullscreen = SettingsManager.settingsManager.getFullScreen();
        SettingsManager.settingsManager.ApplyFullScreen(fullscreen);


        

    }


    public void openLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void openSettings()
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void resume()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
    public void openMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void backToMainMenu()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ChangeResolution()
    {
        int selectedResolution = resolutionDropDown.value;
        Resolution res = resolutionDropDown.GetComponent<PopulateDropDown>().resolutionList[selectedResolution];
        SettingsManager.settingsManager.saveResolution(res.width, res.height);
        int[] resArr = { res.width, res.height };
        SettingsManager.settingsManager.ApplyResolution(resArr);
    }

    public void ChangeFullscreen()
    {
        SettingsManager.settingsManager.setFullScren(fullScreenToggle.isOn);
        SettingsManager.settingsManager.ApplyFullScreen(fullScreenToggle.isOn);
    }

   

}
