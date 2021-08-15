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
        [Header("Skeleton Spawn Definitions")]
        [SerializeField] Transform[] spawnPositions;
        [Min(1f)]
        [SerializeField] float timeBetweenSpawns = 1f;
        [SerializeField] string[] skeletonPoolTags;
        [Header("General Definitions")]
        [SerializeField] GeneralInfoCanvas generalCanvas;
        [SerializeField] ObjectPooler objectPooler;

        bool gameIsRunning = false;

        void Start()
        {
            int countdownTime = PlayerPrefs.HasKey("countdownTime") ? PlayerPrefs.GetInt("countdownTime") : defaultCountdownTime;

            StartCoroutine(StartCountdown(countdownTime));
        }

        private void GameStart()
        {
            gameIsRunning = true;
            StartCoroutine(SpawnSkeletons());
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
                Debug.Log("SpawnSkeleton");
                objectPooler.SpawnFromPool(
                    skeletonPoolTags[Random.Range(0, skeletonPoolTags.Length - 1)],
                    spawnPositions[Random.Range(0, spawnPositions.Length - 1)]);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
    }

}
