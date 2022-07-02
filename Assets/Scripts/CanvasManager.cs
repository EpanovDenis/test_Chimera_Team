using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject ScaleForcePanel;       
    
    void Update()
    {
        if (Shell.currentChild > 0)
        {
            ScaleForcePanel.gameObject.SetActive(true);
        }
        else
        {
            ScaleForcePanel.gameObject.SetActive(false);
        }
    }
}
