using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarEscape : MonoBehaviour
{
    private static CarEscape _instance;
    public static CarEscape Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CarEscape>();
                if (_instance == null)
                {
                    GameObject gO = new GameObject();
                    gO.name = "CarEscape";
                    _instance = gO.AddComponent<CarEscape>();
                    DontDestroyOnLoad(gO);
                }

            }
            return _instance;
        }

    } //Prop

    public List<GameObject> cars = new List<GameObject>();
    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }

    void StackCube(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPosition= cars[index].transform.localPosition;
        newPosition.z -= 1;
        other.transform.localPosition = newPosition;
        StartCoroutine(MakeCarsBigger());
    }

    IEnumerator MakeCarsBigger()
    {
        for(int i= cars.Count-1;i>0; i--)
        {
            Vector3 scale= new Vector3 (1,1,1);
            scale *= 1.3f;
            cars[i].transform.DOScale(scale, 0.2f).OnComplete(() => cars[i].transform.DOScale(new Vector3(1, 1, 1), 0.2f));
            yield return new WaitForSeconds(0.01f);
        }
    }

}
