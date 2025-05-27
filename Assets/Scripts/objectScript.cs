using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectScript : MonoBehaviour
{
    public GameObject garbageTruck;
    public GameObject schoolBuss;
    public GameObject medic;

    public GameObject shuttleBus;
    public GameObject bike;
    public GameObject scooter;
    public GameObject lorry;
    public GameObject motorcycle;
    public GameObject policeCar;
    public GameObject moped;
    public GameObject sportCar;
    public GameObject van;


    [HideInInspector]
    public Vector2 gTruckPos;
    [HideInInspector]
    public Vector2 sBussPos;
    [HideInInspector]
    public Vector2 medicPos;

    [HideInInspector]
    public Vector2 shuttleBusPos;
    [HideInInspector]
    public Vector2 bikePos;
    [HideInInspector]
    public Vector2 scooterPos;
    [HideInInspector]
    public Vector2 lorryPos;
    [HideInInspector]
    public Vector2 motorcyclePos;
    [HideInInspector]
    public Vector2 policeCarPos;
    [HideInInspector]
    public Vector2 mopedPos;
    [HideInInspector]
    public Vector2 sportCarPos;
    [HideInInspector]
    public Vector2 vanPos;


    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector]
    public bool rightPlace = false;
    public GameObject lastDragged = null;

    [Header("Completion Panel")]
    public GameObject completionPanel;
    public TextMeshProUGUI timeText;
    public Image[] stars;

    private float startTime;
    private bool levelCompleted = false;

    void Start()
    {
        gTruckPos = garbageTruck.GetComponent<RectTransform>().localPosition;
        sBussPos = schoolBuss.GetComponent<RectTransform>().localPosition;
        medicPos = medic.GetComponent<RectTransform>().localPosition;

        shuttleBusPos = shuttleBus.GetComponent<RectTransform>().localPosition;
        bikePos = bike.GetComponent<RectTransform>().localPosition;
        scooterPos = scooter.GetComponent<RectTransform>().localPosition;
        lorryPos = lorry.GetComponent<RectTransform>().localPosition;
        motorcyclePos = motorcycle.GetComponent<RectTransform>().localPosition;
        policeCarPos = policeCar.GetComponent<RectTransform>().localPosition;
        mopedPos = moped.GetComponent<RectTransform>().localPosition;
        sportCarPos = sportCar.GetComponent<RectTransform>().localPosition;
        vanPos = van.GetComponent<RectTransform>().localPosition;

        startTime = Time.time;
        if (completionPanel != null)
            completionPanel.SetActive(false);
    }

    void Update()
    {
        if (!levelCompleted)
        {
            bool allInPlace = CheckAllCarsInPlace();
            if (allInPlace)
            {
                Debug.Log("All cars in place! Proceeding to show completion panel");
                levelCompleted = true;
                ShowCompletionPanel();
            }
        }
    }

    private void ShowCompletionPanel()
    {
        Debug.Log("ShowCompletionPanel called");
        completionPanel.SetActive(true);
        completionPanel.GetComponent<Image>().color = Color.red;
    }

    private IEnumerator ShowStarsOneByOne(int starsCount)
    {
        foreach (var star in stars)
        {
            if (star != null) star.gameObject.SetActive(false);
        }

        for (int i = 0; i < starsCount; i++)
        {
            if (stars[i] != null)
            {
                stars[i].gameObject.SetActive(true);
                stars[i].transform.localScale = Vector3.zero;

                float duration = 0.5f;
                float elapsed = 0f;

                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    stars[i].transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsed / duration);
                    yield return null;
                }

                yield return new WaitForSeconds(0.3f);
            }
        }
    }



    private int CalculateStars(float timeSpent)
    {
        if (timeSpent < 60) return 3;
        if (timeSpent < 120) return 2;
        return 1;
    }

    public bool CheckAllCarsInPlace()
    {
        Debug.Log("--- Checking car positions ---");

        bool garbageInPlace = CheckCarPosition(garbageTruck, gTruckPos, "Garbage Truck");
        bool schoolBusInPlace = CheckCarPosition(schoolBuss, sBussPos, "School Bus");
        bool medicInPlace = CheckCarPosition(medic, medicPos, "Medic");
        bool shuttleInPlace = CheckCarPosition(shuttleBus, shuttleBusPos, "Shuttle Bus");
        bool bikeInPlace = CheckCarPosition(bike, bikePos, "Bike");
        bool scooterInPlace = CheckCarPosition(scooter, scooterPos, "Scooter");
        bool lorryInPlace = CheckCarPosition(lorry, lorryPos, "Lorry");
        bool motorcycleInPlace = CheckCarPosition(motorcycle, motorcyclePos, "Motorcycle");
        bool policeInPlace = CheckCarPosition(policeCar, policeCarPos, "Police Car");
        bool mopedInPlace = CheckCarPosition(moped, mopedPos, "Moped");
        bool sportCarInPlace = CheckCarPosition(sportCar, sportCarPos, "Sport Car");
        bool vanInPlace = CheckCarPosition(van, vanPos, "Van");

        bool allCorrect = garbageInPlace && schoolBusInPlace && medicInPlace &&
                         shuttleInPlace && bikeInPlace && scooterInPlace &&
                         lorryInPlace && motorcycleInPlace && policeInPlace &&
                         mopedInPlace && sportCarInPlace && vanInPlace;

        if (!allCorrect)
        {
            Debug.Log("Some cars are NOT in place:");
            if (!garbageInPlace) Debug.Log("- Garbage Truck not in place");
            if (!schoolBusInPlace) Debug.Log("- School Bus not in place");
            if (!medicInPlace) Debug.Log("- Medic not in place");
            if (!shuttleInPlace) Debug.Log("- Shuttle Bus not in place");
            if (!bikeInPlace) Debug.Log("- Bike not in place");
            if (!scooterInPlace) Debug.Log("- Scooter not in place");
            if (!lorryInPlace) Debug.Log("- Lorry not in place");
            if (!motorcycleInPlace) Debug.Log("- Motorcycle not in place");
            if (!policeInPlace) Debug.Log("- Police Car not in place");
            if (!mopedInPlace) Debug.Log("- Moped not in place");
            if (!sportCarInPlace) Debug.Log("- Sport Car not in place");
            if (!vanInPlace) Debug.Log("- Van not in place");
        }

        return allCorrect;
    }

    private bool CheckCarPosition(GameObject car, Vector2 correctPosition, string carName)
    {
        if (car == null)
        {
            Debug.LogError($"{carName} is null!");
            return false;
        }

        RectTransform carTransform = car.GetComponent<RectTransform>();
        if (carTransform == null)
        {
            Debug.LogError($"{carName} has no RectTransform!");
            return false;
        }

        float distance = Vector2.Distance(carTransform.anchoredPosition, correctPosition);
        bool positionCorrect = distance < 20f;

        Debug.Log($"{carName} - Current: {carTransform.anchoredPosition} | Target: {correctPosition} | Distance: {distance} | InPlace: {positionCorrect}");

        return positionCorrect;
    }
}
