using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uinterface;
using UnityEngine.Events;
using Gameplay.ObjectPooling;
using Gameplay.DataManagement;
using Core;
using TMPro;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("Game Start Definitions")]
        [Tooltip("Default time before game starts. Overwriten by player settings.")]
        [SerializeField] int countdownTime = 3;
        [Tooltip("Default game time in seconds. Overwriten by player settings.")]
        [SerializeField] int gameTime = 180;
        [Space(5)]
        [SerializeField] UnityEvent startGameEvent;
        [Header("Skeleton Spawn Definitions")]
        [SerializeField] Transform[] spawnPositions;
        [Min(1f)]
        [SerializeField] float timeBetweenSpawns = 1f;
        [SerializeField] string[] skeletonPoolTags;
        [Header("General Definitions")]
        [SerializeField] TextMeshProUGUI gameTimeText;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] GameObject deathPanel;
        [SerializeField] GeneralInfoCanvas generalCanvas;
        [SerializeField] ObjectPooler objectPooler;

        SceneLoader sceneLoader;
        bool gameIsRunning = false;

        void Start()
        {
            gameTime = PlayerPrefs.HasKey("gameTime") ? PlayerPrefs.GetInt("gameTime") : gameTime;
            countdownTime = PlayerPrefs.HasKey("countdownTime") ? PlayerPrefs.GetInt("countdownTime") : this.countdownTime;
            sceneLoader = FindObjectOfType<SceneLoader>();

            StartCoroutine(StartCountdown(countdownTime));
        }

        private void Update()
        {
            scoreText.text = SessionDataManager.instance.GetScore().ToString();
        }

        private void GameStart()
        {
            gameIsRunning = true;
            StartCoroutine(SpawnSkeletons());
            StartCoroutine(GameTimeCountdown());
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
            GameStart();
            startGameEvent.Invoke();
        }

        private IEnumerator SpawnSkeletons()
        {
            while (gameIsRunning)
            {
                objectPooler.SpawnFromPool(
                    skeletonPoolTags[Random.Range(0, skeletonPoolTags.Length)],
                    spawnPositions[Random.Range(0, spawnPositions.Length)]);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }

        private IEnumerator GameTimeCountdown()
        {
            int i = gameTime;
            while ( i > 0)
            {
                yield return new WaitForSeconds(1);
                i--;
                gameTimeText.text = i.ToString();
            }
            GameOver();
        }

        public void GameOver()
        {
            StopAllCoroutines();
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }

        public void ReturnToMenu()
        {
            sceneLoader.LoadScene(1);
        }
    }

}
