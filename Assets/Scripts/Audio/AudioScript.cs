using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    public static AudioClip purchaseSound, coinSound, DeathSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        purchaseSound = Resources.Load<AudioClip>("Purchase");
        coinSound = Resources.Load<AudioClip>("Coinpickup");
        DeathSound = Resources.Load<AudioClip>("Death");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Purchase" : audioSrc.PlayOneShot(purchaseSound); break;
            case "Coinpickup": audioSrc.PlayOneShot(coinSound); break;
            case "Death": audioSrc.PlayOneShot(DeathSound); break;
        }
    }
}
