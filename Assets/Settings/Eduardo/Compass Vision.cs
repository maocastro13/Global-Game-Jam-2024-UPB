using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassVision : MonoBehaviour
{
    [SerializeField] private GameObject arrowUpGO;
    [SerializeField] private GameObject arrowDownGO;
    [SerializeField] private GameObject arrowLeftGO;
    [SerializeField] private GameObject arrowRightGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -GameObject.Find("Main Camera").transform.rotation.eulerAngles.y));
        SwitchArrows();
    }

    private void SwitchArrows()
    {
        if (Input.GetKey(KeyCode.W))
        {
            arrowUpGO.SetActive(true);
        }
        else
        {
            arrowUpGO.SetActive(false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            arrowDownGO.SetActive(true);
        }
        else
        {
            arrowDownGO.SetActive(false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            arrowLeftGO.SetActive(true);
        }
        else
        {
            arrowLeftGO.SetActive(false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            arrowRightGO.SetActive(true);
        }
        else
        {
            arrowRightGO.SetActive(false);
        }
    }
}
