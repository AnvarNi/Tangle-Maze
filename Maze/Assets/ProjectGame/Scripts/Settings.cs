using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public Toggle toggle;

    private Resolution[] res;
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
        toggle.isOn = true;
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string[] strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].ToString();
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(strRes.ToList());
        dropdown.value = res.Length - 1;
        Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
    }

    public void SetRes()
    {
        Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, Screen.fullScreen);
    }

    public void ScreenMode()
    {
        Screen.fullScreen = toggle.isOn;
    }
}
