using UnityEngine;

public class MovingObjectsX : MonoBehaviour
{
    public GameObject gameManager;
    public float leftClamp;
    public float rightClamp;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && gameManager.GetComponent<RayObjectChecking>().currentObject == gameObject.name && Input.GetMouseButton(0))
        {
            Debug.Log(hit.point);

            float clampedX = Mathf.Clamp(hit.point.x, leftClamp, rightClamp);

            // Set the object's position
            Vector3 rayMovement = new Vector3(clampedX, transform.position.y, transform.position.z);
            transform.position = rayMovement;
        }
    }
}