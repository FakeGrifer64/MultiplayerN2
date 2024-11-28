using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviourPunCallbacks
{
    public Rigidbody2D myRigidbody;
    public float flapForca;
    public LogicScript logic;
    public static bool birdIsAlive = true;

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    public AudioClip backgroundMusicClip;
    public AudioClip badsoundEffectClip;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.enabled = true;
        logic.esperandoPlayer2Text.SetActive(true);

        logic.numOfPlayers += 1;

        if (backgroundMusicSource != null && backgroundMusicClip != null)
        {
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.numOfPlayers == 2)
        {
            if (photonView.IsMine)
            {
                if (Input.GetMouseButtonDown(0) && birdIsAlive)
                {
                    myRigidbody.velocity = Vector2.up * flapForca;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("EsperandoPlayer2"))
        {
            Debug.Log("Colisão detectada!");
            logic.gameOver();
            birdIsAlive = false;
            PlayBadSoundEffect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisão detectada!");
        logic.gameOver();
        birdIsAlive = false;
        PlayBadSoundEffect();
    }

    public void PlayBadSoundEffect()
    {
        if (soundEffectSource != null && badsoundEffectClip != null)
        {
            soundEffectSource.PlayOneShot(badsoundEffectClip);
        }
    }
}
