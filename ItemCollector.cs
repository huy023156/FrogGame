using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour {
    public static ItemCollector Instance { get; private set; }

    private const string CHERRY_TAG = "Cherry";

    [SerializeField] private TextMeshProUGUI cherryCountText;
    public int cherryCount;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start() {
        Instance = this;
        cherryCount = PlayerPrefs.GetInt("CherryCount");
        cherryCountText.text = cherryCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(CHERRY_TAG)) {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherryCount++;
            cherryCountText.text = cherryCount.ToString();
        }
    }
}