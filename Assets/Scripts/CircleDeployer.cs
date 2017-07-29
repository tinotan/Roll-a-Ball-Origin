using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDeployer : MonoBehaviour
{
	  [SerializeField]
    private float _radius;

    // Use this for initialization
    void Start()
    {
        Deploy();
    }

    private void Awake()
    {
        Deploy();
    }

    private void OnValidate()
    {
        Deploy();
    }

    private void Deploy()
    {

        List<GameObject> childList = new List<GameObject>();

        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
        }

        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        float angleDiff = 360f / (float)childList.Count;

        for (int i = 0; i < childList.Count; i++)
        {
            Vector3 childPosition = transform.position;

						float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;

            childPosition.x += _radius * Mathf.Cos(angle);
            childPosition.z += _radius * Mathf.Sin(angle);

            childList[i].transform.position = childPosition;


        }
    }
}
