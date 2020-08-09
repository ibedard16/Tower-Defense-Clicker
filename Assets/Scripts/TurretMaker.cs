using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMaker : MonoBehaviour
{
    public WaveMaker WM;
    public GameObject TurretParent;
    public Turret TurretPrefab;
    
    private List<Turret> TurretList;

    void Start()
    {
        TurretList = new List<Turret>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            makeTurret(p);
        }
    }

    void makeTurret(Vector3 p){
        Turret newTurret = Instantiate(TurretPrefab, new Vector3(p.x, p.y, 0), Quaternion.identity);
        newTurret.transform.parent = TurretParent.transform;
        newTurret.parent = this;
        TurretList.Add(newTurret);
    }
}
