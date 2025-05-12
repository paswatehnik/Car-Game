using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : MonoBehaviour
{
    public GameObject GarbageTruck;
    public GameObject Bus;
    public GameObject MedicBus;

    [HideInInspector]
    public Vector2 gTruckPos;
    [HideInInspector]
    public Vector2 sBussPos;
    [HideInInspector]
    public Vector2 medicPos;

    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector]
    public bool rightPlace = false;
    public GameObject lastDragged = null;


    void Start()
    {
        gTruckPos = GarbageTruck.GetComponent<RectTransform>().localPosition;
        sBussPos = Bus.GetComponent<RectTransform>().localPosition;
        medicPos = MedicBus.GetComponent<RectTransform>().localPosition;
    }
}
