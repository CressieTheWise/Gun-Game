using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class RifleBehavior : MonoBehaviour
{
    Vector2 mousePosition;
    Camera mainCamera;
    [SerializeField]int lookOffSet;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        float angle = getAngle(mousePosition);
        transform.eulerAngles = new Vector3(0,0,angle);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private float getAngle(Vector2 positionTolookAt)
    {
        Vector2 lookDir = positionTolookAt - (Vector2)transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - lookOffSet;
        return angle;
    }
    void Shoot() 
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
} 