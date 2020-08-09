using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMaker : MonoBehaviour
{
    public GameObject TurretParent;
    public GameObject TurretPrefab;
    
    private List<GameObject> TurretList;

    void Start()
    {
        TurretList = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            makeTurret(p);
        }
    }

    void makeTurret(Vector3 p){
        GameObject newTurret = Instantiate(TurretPrefab, new Vector3(p.x, p.y, 0), Quaternion.identity);
        newTurret.transform.parent = TurretParent.transform;
        TurretList.Add(newTurret);
    }
}
