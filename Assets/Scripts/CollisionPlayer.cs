using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    public GameObject Shell;
    private Shell shell;
    public static bool flagRespawn;

    private void Start()
    {
        shell = Shell.GetComponent<Shell>();
    }

    private void Update()
    {
        if (flagRespawn == true)
        {
            shell.Respawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Barrier") && shell.arm.childCount > 0)
        {
            shell.Put();
            flagRespawn = true;
        }
    }
}
