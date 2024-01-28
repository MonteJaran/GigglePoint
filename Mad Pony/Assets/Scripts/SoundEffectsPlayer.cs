using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    
    public AudioSource ASourceMonsters;
    public AudioClip[] laugh_low;
    public AudioClip[] laugh_Medium;
    public AudioClip[] laugh_High;
    public AudioClip[] mad_sound;
    public int rememberTheSoundID; 
    [Header("Soundtracks")]
    public AudioSource ASourceMusic;
    public AudioClip classical_music, rap_music, rock_music;
    public int rememberTheMusicID; 

    /// <summary>
    /// All the tracks will last this seconds. If we get a signal that the laugh is continuing to play, we do not stop it.
    /// </summary>
    public float trackRunningTime;

    private float trackRunningTimeCopy;
    
    void Start()
    {
        trackRunningTimeCopy = trackRunningTime;
    }
    void Update()
    {
        trackRunningTime -= Time.deltaTime;
        if(ASourceMonsters.clip != null && trackRunningTime < 0f)
        {
            ASourceMonsters.Stop();
        }
    }
    public void StartCoundCalculation(int levelOfLaugh)
    {
        trackRunningTime = trackRunningTimeCopy;
        AudioClip newSound = laugh_low[0];
        if(rememberTheSoundID == levelOfLaugh && levelOfLaugh != 0)
        {
            newSound = ASourceMonsters.clip;
            if (!ASourceMonsters.isPlaying)
            {
                ASourceMonsters.Play();
                // Additional actions if needed
            }
        }
        else
        {
            
            if (levelOfLaugh == 0)
            {
                newSound = mad_sound[Random.Range(0,mad_sound.Length-1)];
            } else if (levelOfLaugh == 1)
            {
                newSound = laugh_low[Random.Range(0,laugh_low.Length-1)];
            } else if (levelOfLaugh == 2)
            {
                newSound = laugh_Medium[Random.Range(0,laugh_Medium.Length-1)];
            } else if (levelOfLaugh == 3)
            {
                newSound = laugh_High[Random.Range(0,laugh_High.Length-1)];
            }

            ASourceMonsters.clip = newSound; 
            ASourceMonsters.Play();
        }
        
        // Now we changed the state of sound 
        // Decide on the new sound effect
        
        rememberTheSoundID = levelOfLaugh;
        
    }

    public void PutMusicSoundtrack(int musicLevel)
    {
        ASourceMusic.Stop();
        rememberTheMusicID = musicLevel;
        if(musicLevel == 0)
        {
            ASourceMusic.clip = classical_music; 
            ASourceMusic.Play();
        } else if(musicLevel == 1)
        {
            ASourceMusic.clip = rap_music; 
            ASourceMusic.Play();
        } else if(musicLevel == 2)
        {
            ASourceMusic.clip = rock_music; 
            ASourceMusic.Play();
        }
    }
}
