using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class AudioController : MonoBehaviour
    {
        [Header("Main Setting: ")]
        [Range(0f, 1f)] public float musicVol = 0.3f;
        [Range(0f, 1f)] public float soundVol = 1f;

        public AudioSource musicAus;
        public AudioSource soundAus;

        [Header("Music and Sound in Gameplay: ")]
        public AudioClip playerAtk;
        public AudioClip enemyDead;
        public AudioClip gameover;
        public AudioClip[] bgms;

        public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
        {
            if (!aus)
            {
                aus = soundAus;
            }
            if(aus==null) return;

            if (sounds == null || sounds.Length <= 0) return;
            int  randIdx = Random.Range(0, sounds.Length);
            if (sounds[randIdx])
            {
                aus.PlayOneShot(sounds[randIdx], soundVol);
            }
        }

        public void PlaySound(AudioClip sound, AudioSource aus = null)
        {
            if (!aus)
            {
                aus = soundAus;
            }
            if(aus == null) return;
            if (sound)
            {
                aus.PlayOneShot(sound, soundVol);
            }
        }

        public void PlayMusic(AudioClip[] musics, bool isLoop = true)
        {
            if (musics == null || musics.Length <= 0 || musicAus == null) return;

            int randIdx = Random.Range(0, musics.Length);
            if (musics[randIdx])
            {
                musicAus.clip = musics[randIdx];
                musicAus.loop = isLoop;
                musicAus.volume = musicVol;
                musicAus.Play();
            }
        }

        public void PlayMusic(AudioClip music, bool isLoop = true)
        {
            if(music != null && musicAus != null)
            {
                musicAus.clip = music;
                musicAus.loop = isLoop;
                musicAus.volume = musicVol;
                musicAus.Play();
            }
        }

        public void SetMusicVolume(float vol)
        {
            if(musicAus != null)
            {
                musicAus.volume = vol;
            }
        }

        public void StopMusic()
        {
            if(musicAus != null)
            {
                musicAus.Stop();
            }
        }
        public void Playbgms()
        {
            PlayMusic(bgms);
        }
    }
}

