using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<AudioClip> soundsNobileM;
    public AudioSource audioSource;
    System.Random rnd;
    private bool isTalking= false;

    public void Talk(GameObject caller)
    {
        rnd = new System.Random();
        int index = rnd.Next(1, 13);
        if (!audioSource.isPlaying)
        {
            switch (caller.tag)
            {
                case "Player_Nobile":
                    // Audio nobili: prendi negli asset la stringa corrispondente a "Nobile_NobileM + (index)"
                    audioSource.Play();
                    isTalking = true;
                    break;
                case "Player_Schiavo":
                    // AUdio schiavo: prendi negli asset la stringa corrispondente a "Schiavo_NobileM + (index)"
                    isTalking = true;
                    break;
            }
        }
    }

}
