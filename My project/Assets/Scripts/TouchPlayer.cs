using System.ComponentModel;
using UnityEngine;

public class TouchPlayer : MonoBehaviour
{
    //Camera getItem
    private Camera cam;
    private GameObject holdItem;
    private Rigidbody holdItemRB;
    private float distanceZ;
    private Vector3 offset;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        TouchScreen();
    }

    void TouchScreen()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = cam.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "CanEat" || hit.collider.gameObject.tag == "Can'tEat")
                        {
                            holdItem = hit.collider.gameObject;

                            holdItemRB = holdItem.GetComponent<Rigidbody>();
                            holdItemRB.useGravity = false;

                            distanceZ = cam.WorldToScreenPoint(holdItem.transform.position).z;

                            Vector3 positionTouchInWord = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distanceZ));
                            offset = holdItem.transform.position - positionTouchInWord;

                            print("Está segurando o item" + holdItem.name);
                        }
                        else
                        {
                            print("Tá querendo comer a mesa também?");
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (holdItem != null)
                    {
                        Vector3 positionTouchInWord = new Vector3(touch.position.x, touch.position.y, distanceZ);
                        holdItem.transform.position = cam.ScreenToWorldPoint(positionTouchInWord) + offset;

                        print("Está movimentando o item");
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (holdItem != null)
                    {
                        print("Soltou o item");
                        holdItem = null;
                        holdItemRB.useGravity = true;
                    }
                    break;
            }
        }
    }
}
