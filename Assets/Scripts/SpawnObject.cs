using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<ObjectBehavior>().ChangeColor();
                }
                else
                    Instantiate(BundleHundler.GetObject(), hit.point, Quaternion.identity);
            }
        }
    }
}