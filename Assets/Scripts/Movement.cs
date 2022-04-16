using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

    }
    public void Move()
    {
        Vector3 mousePos= Input.mousePosition;
        Ray ray= Camera.main.ScreenPointToRay(mousePos);
        RaycastHit rayHit;

        Debug.Log("action");
        if (Physics.Raycast(ray, out rayHit,100f))
        {
            GameObject firstCar= CarEscape.Instance.cars[0];
            Vector3 hitVec= rayHit.point;
            hitVec.y= firstCar.transform.localPosition.y;
            hitVec.z= firstCar.transform.localPosition.z;
            firstCar.transform.localPosition=Vector3.MoveTowards(firstCar.transform.localPosition, hitVec,Time.deltaTime*speed);
        }
    }
}
