using UnityEngine;
using UnityEngine.UI;

public class ScaleForceBar : MonoBehaviour
{
    public Image scaleForceBar;    
    public static float currecnForce;

    void Start()
    {
        scaleForceBar = GetComponent<Image>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            scaleForceBar.fillAmount += Time.deltaTime / 2.5f;
            currecnForce = scaleForceBar.fillAmount;
        }
        else
        {
            scaleForceBar.fillAmount = 0;
        }
    }
}
