using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Gameplay.DataManagement;

namespace Uinterface
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI killsText;

        void OnEnable()
        {
            scoreText.text = SessionDataManager.instance.GetScore().ToString();
            killsText.text = SessionDataManager.instance.GetKills().ToString();

        }

    }
}

