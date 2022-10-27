using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Graph : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointPrefab;
    const float degree = 30f;

    [Range(10, 100)]
    public int resolution = 10;
    Transform[] points;

    void Awake(){
        //Instantiate(pointPrefab);
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.y = 0f;
        position.z = 0f;

        points = new Transform[resolution];

        int i;
        for(i = 0; i < points.Length; i ++){
            Transform point = Instantiate(pointPrefab);
            //point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f);
            //point.localScale = scale;

            position.x = (i + 0.5f) * step - 1f;
            //position.y = position.x * position.x * position.x;
            point.position = position;
            point.localScale = scale;
            point.SetParent(transform);
            points[i] = point;
        }        
    }

    void Update(){
        for(int i = 0; i < points.Length; i ++){
            Transform point = points[i];

            Vector3 position = point.localPosition;
            //position.y = position.x * position.x * position.x;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time)) * 0.2f;
            point.localPosition = position;

            point.localRotation = Quaternion.Euler(0f, (float)DateTime.Now.TimeOfDay.TotalSeconds * degree + position.x * 100f, 0f);

            transform.localRotation = Quaternion.Euler(0f, (float)DateTime.Now.TimeOfDay.TotalSeconds * degree + position.x * 100f, 0f);
           }
        }
}
