using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInterface;
using UnityEngine.Events;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("Game Start Definitions")]
        [Tooltip("Default time before game starts. Overwriten by player settings.")]
        [SerializeField] int defaultCountdownTime = 3;
        [Space(5)]
        [SerializeField] UnityEvent startGameEvent;
        [Header("General Definitions")]
        [SerializeField] GeneralInfoCanvas generalCanvas;

        void Start()
        {
            GameStart();
        }

        private void GameStart()
        {
            int countdownTime = PlayerPrefs.HasKey("countdownTime") ? PlayerPrefs.GetInt("countdownTime") : defaultCountdownTime;

            StartCoroutine(StartCountdown(countdownTime));
        }

        private IEnumerator StartCountdown(int countdownTime)
        {
            yield return new WaitForSeconds(1f);

            while (countdownTime > 0)
            {
                generalCanvas.SetAlertText(countdownTime);
                yield return new WaitForSeconds(1f);
                countdownTime--;
            }

            generalCanvas.HideAlertText();
            startGameEvent.Invoke();
        }
    }

}
