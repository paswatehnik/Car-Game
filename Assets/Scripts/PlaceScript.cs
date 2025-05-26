using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScript : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScript objectScript;

    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && Input.GetMouseButtonUp(0)
            && Input.GetMouseButton(2) == false)
        {

            if (eventData.pointerDrag.tag.Equals(tag))
            {
                placeZRotation =
                eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;

                carZRotation = GetComponent<RectTransform>().transform.eulerAngles.z;

                difZRotation = Mathf.Abs(placeZRotation - carZRotation);
                Debug.Log("Dif Z Rotation: " + difZRotation);

                placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
                carSize = GetComponent<RectTransform>().localScale;
                xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
                ySizeDif = Mathf.Abs(placeSize.y - carSize.y);
                Debug.Log("Dif X Size: " + xSizeDif + " Dif Y Size: " + ySizeDif);

                if ((difZRotation <=10 || (difZRotation >=350 && difZRotation <=360)) && 
                    (xSizeDif <= 0.3 && ySizeDif <= 0.3)){
                    Debug.Log("Right Place");
                    objectScript.rightPlace = true;

                    // Iecentrē pozīciju
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        GetComponent<RectTransform>().anchoredPosition;

                    // Pielāgo rotāciju
                    eventData.pointerDrag.GetComponent<RectTransform>().localRotation = 
                        GetComponent<RectTransform>().localRotation;

                    // Pielāgo izmēru
                    eventData.pointerDrag.GetComponent<RectTransform>().localScale = 
                        GetComponent<RectTransform>().localScale;

                    switch(eventData.pointerDrag.tag)
                    {
                        case "Garbage":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]);
                            break;

                        case "Medic":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]);
                            break;

                        case "School":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;



                        case "shuttleBus":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "bike":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "scooter":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "lorry":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "motorcycle":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "policeCar":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "moped":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "sportCar":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;   

                        case "van":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;


                        default:
                            Debug.LogError("Unknown tag!");
                            break;
                    }
                }

            }
            else
            {
                objectScript.rightPlace = false;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);

                switch (eventData.pointerDrag.tag)
                {
                    case "Garbage":
                        objectScript.garbageTruck.GetComponent<RectTransform>().localPosition 
                            = objectScript.gTruckPos;
                        break;

                    case "Medic":
                        objectScript.medic.GetComponent<RectTransform>().localPosition
                            = objectScript.medicPos;
                        break;

                    case "School":
                        objectScript.schoolBuss.GetComponent<RectTransform>().localPosition
                             = objectScript.sBussPos;
                        break;

                    case "shuttleBus":
                        objectScript.shuttleBus.GetComponent<RectTransform>().localPosition
                             = objectScript.shuttleBusPos;
                        break;

                    case "bike":
                        objectScript.bike.GetComponent<RectTransform>().localPosition
                             = objectScript.bikePos;
                        break;

                    case "scooter":
                        objectScript.scooter.GetComponent<RectTransform>().localPosition
                             = objectScript.scooterPos;
                        break;

                    case "lorry":
                        objectScript.lorry.GetComponent<RectTransform>().localPosition
                             = objectScript.lorryPos;
                        break;

                    case "motorcycle":
                        objectScript.motorcycle.GetComponent<RectTransform>().localPosition
                             = objectScript.motorcyclePos;
                        break;

                    case "policeCar":
                        objectScript.policeCar.GetComponent<RectTransform>().localPosition
                             = objectScript.policeCarPos;
                        break;

                    case "moped":
                        objectScript.moped.GetComponent<RectTransform>().localPosition
                             = objectScript.mopedPos;
                        break;

                    case "sportCar":
                        objectScript.sportCar.GetComponent<RectTransform>().localPosition
                             = objectScript.sportCarPos;
                        break;

                    case "van":
                        objectScript.van.GetComponent<RectTransform>().localPosition
                             = objectScript.vanPos;
                        break;


                    default:
                        Debug.LogError("Unknown tag!");
                        break;
                }

            }
        }
    }
}
