using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform cube;

    void Start()
    {
        cube = GameObject.Find("Cube").transform;
    }

    void Update()
    {
        LookAt3D();

        //LookAt2D();
    }

    private void LookAt3D()
    {
        transform.LookAt(cube);
    }

    private void LookAt2D()
    {
        var direction = cube.transform.position;
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }
}
