using UnityEngine.UI;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Text indicator;
    public AudioSource takeBall;
    RaycastHit hit;       
        
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.tag == "Shell" && Shell.currentChild < 1)
            {
                indicator.gameObject.SetActive(true);
            }
            else
            {
                indicator.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //takeBall.Play();
                hit.collider.GetComponent<Shell>().PickUp();
            }
        }
        else
        {
            indicator.gameObject.SetActive(false);
        }
    }
}
