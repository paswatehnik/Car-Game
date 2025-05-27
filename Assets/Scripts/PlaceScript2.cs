using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScript2 : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScript2 objectScript2;

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
                    objectScript2.rightPlace = true;

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
                        case "airplane":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[2]);
                            break;

                        case "boat":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[3]);
                            break;

                        case "bus":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[4]);
                            break;

                        case "cat":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[5]);
                            break;

                        case "firecar":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[6]);
                            break;

                        case "helicopter":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[7]);
                            break;

                        case "house":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[8]);
                            break;

                        case "skateboard":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[9]);
                            break;

                        case "sun":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[10]);
                            break;

                        case "taxi":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[11]);
                            break;

                        case "traficlight":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[12]);
                            break;   

                        case "tree":
                            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[13]);
                            break;


                        default:
                            Debug.LogError("Unknown tag!");
                            break;
                    }
                }

            }
            else
            {
                objectScript2.rightPlace = false;
                objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[1]);

                switch (eventData.pointerDrag.tag)
                {
                    case "airplane":
                        objectScript2.airplane.GetComponent<RectTransform>().localPosition 
                            = objectScript2.airplanePlace;
                        break;

                    case "boat":
                        objectScript2.boat.GetComponent<RectTransform>().localPosition
                            = objectScript2.boatPlace;
                        break;

                    case "bus":
                        objectScript2.bus.GetComponent<RectTransform>().localPosition
                             = objectScript2.busPlace;
                        break;

                    case "cat":
                        objectScript2.cat.GetComponent<RectTransform>().localPosition
                             = objectScript2.catPlace;
                        break;

                    case "firecar":
                        objectScript2.firecar.GetComponent<RectTransform>().localPosition
                             = objectScript2.firecarPlace;
                        break;

                    case "helicopter":
                        objectScript2.helicopter.GetComponent<RectTransform>().localPosition
                             = objectScript2.helicopterPlace;
                        break;

                    case "house":
                        objectScript2.house.GetComponent<RectTransform>().localPosition
                             = objectScript2.housePlace;
                        break;

                    case "skateboard":
                        objectScript2.skateboard.GetComponent<RectTransform>().localPosition
                             = objectScript2.skateboardPlace;
                        break;

                    case "sun":
                        objectScript2.sun.GetComponent<RectTransform>().localPosition
                             = objectScript2.sunPlace;
                        break;

                    case "taxi":
                        objectScript2.taxi.GetComponent<RectTransform>().localPosition
                             = objectScript2.taxiPlace;
                        break;

                    case "traficlight":
                        objectScript2.traficlight.GetComponent<RectTransform>().localPosition
                             = objectScript2.traficlightPlace;
                        break;

                    case "tree":
                        objectScript2.tree.GetComponent<RectTransform>().localPosition
                             = objectScript2.treePlace;
                        break;


                    default:
                        Debug.LogError("Unknown tag!");
                        break;
                }

            }
        }
    }
}
