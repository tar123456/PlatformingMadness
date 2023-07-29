using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDropDown : MonoBehaviour
{

    private Dropdown dropdown;
    [HideInInspector]
    public Dictionary<int, Resolution> resolutionList;
    List<string> resolutionOptions;
    void Start()
    {
        dropdown = GetComponent<Dropdown>();

        resolutionList = new Dictionary<int,Resolution>();
        resolutionOptions = new List<string>();

        Resolution[] resolutions = Screen.resolutions;
        dropdown.ClearOptions();

        for(int i =0;i<resolutions.Length; i++)
        {
            resolutionList.Add(i, resolutions[i]);
            string resolutionOption = resolutions[i].width + "x" + resolutions[i].height;

            resolutionOptions.Add(resolutionOption);
        }

        
        dropdown.AddOptions(resolutionOptions);


    }

   
}
