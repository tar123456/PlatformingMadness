using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SettingsManager : MonoBehaviour
{
    public static SettingsManager settingsManager { get; private set; }

    public void Awake()
    {
        if (settingsManager == null)
        {
            settingsManager = this;
        }
        else 
        {
            Destroy(this);
        }
    }

    public void saveResolution(int width, int height)
    {
        PlayerPrefs.SetInt("Res_Width", width);
        PlayerPrefs.SetInt("Res_Height", height);
    }

    public int[] loadResolution()
    {
        int[] resolution = new int[2];

        resolution[0] = PlayerPrefs.GetInt("Res_Width");
        resolution[1] = PlayerPrefs.GetInt("Res_Height");

        return resolution;
    }

   

    public void ApplyResolution(int[] resolution)
    {

        if (PlayerPrefs.HasKey("Res_Width")&&PlayerPrefs.HasKey("Res_Height"))
        {
            Screen.SetResolution(resolution[0], resolution[1], true);
        }
    }

    public void setFullScren(bool set)
    {
            PlayerPrefs.SetString("FullScreen", set.ToString());
        
    }

    public bool getFullScreen()
    {
        bool full = bool.Parse(PlayerPrefs.GetString("FullScreen"));

        return full;
    }

    public void ApplyFullScreen(bool set)
    {
        if (PlayerPrefs.HasKey("FullScreen"))
        {
            Screen.fullScreen = set;
        }
    }

    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public float getVolume()
    {
        float vol = PlayerPrefs.GetFloat("Volume");
        return vol;
    }
    

}
