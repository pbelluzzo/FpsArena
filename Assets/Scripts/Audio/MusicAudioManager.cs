using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class MusicAudioManager : MonoBehaviour
    {
        [Range(0,100)]
        [SerializeField] int musicVolume = 100;

        AudioSource musicSource;
        bool isPlaying = false;
        
        public void HandlePlayMusic(AudioClip music)
        {
            if (!isPlaying)
            {
                PlayMusic(music);
                return;
            }
            StartCoroutine(HandleChangeMusic(music));
        }

        private IEnumerator HandleChangeMusic(AudioClip music)
        {
            yield return FadeOut();
            PlayMusic(music);
        }

        private void PlayMusic(AudioClip music)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.volume = musicVolume;
            musicSource.clip = music;
            musicSource.Play();
        }
        
        private IEnumerator FadeOut()
        {
            while (musicSource.volume > 0)
            {
                musicSource.volume -= Time.deltaTime / 1;
                yield return null;
            }
            Destroy(musicSource);
        }
    }
}

