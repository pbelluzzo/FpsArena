using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfigsMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField gameTimeInput;
    [SerializeField] private TMP_InputField startCountdownInput;

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("gameTime",int.Parse(gameTimeInput.text));
        PlayerPrefs.SetInt("countdownTime", int.Parse(startCountdownInput.text));
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("gameTime"))
            gameTimeInput.text = PlayerPrefs.GetInt("gameTime").ToString();

        if (PlayerPrefs.HasKey("countdownTime"))
            startCountdownInput.text = PlayerPrefs.GetInt("countdownTime").ToString();
    }
}
