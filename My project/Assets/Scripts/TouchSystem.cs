using System.ComponentModel;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    private Camera cam;
    private GameObject holdItem;

    private float distanceZ;
    private Vector3 offset;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = cam.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))
                    {
                        holdItem = hit.collider.gameObject;

                        distanceZ = cam.WorldToScreenPoint(holdItem.transform.position).z;

                        Vector3 positionTouchInWord = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distanceZ));
                        offset = holdItem.transform.position - positionTouchInWord;

                        print("Está segurando o item" + holdItem.name);
                    }
                    break;

                case TouchPhase.Moved:
                    if(holdItem != null)
                    {
                        Vector3 positionTouchInWord = new Vector3(touch.position.x, touch.position.y, distanceZ);
                        holdItem.transform.position = cam.ScreenToWorldPoint(positionTouchInWord) + offset;

                        print("Está movimentando o item");
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if(holdItem != null)
                    {
                        print("Soltou o item");
                        holdItem = null;
                    }
                    break;
            }
        }
    }
}
