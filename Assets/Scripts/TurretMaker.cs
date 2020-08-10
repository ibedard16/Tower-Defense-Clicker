using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMaker : MonoBehaviour
{
    public WaveMaker WM;
    public GameObject TurretParent;
    public Turret TurretPrefab;
    public int TurretsRemaining = 3;
    public GameObject TurretText;
    
    private List<Turret> TurretList;

    void Start()
    {
        TurretList = new List<Turret>();
        TurretText.GetComponent<UnityEngine.UI.Text>().text = "" + TurretsRemaining;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(TurretsRemaining > 0){
                TurretsRemaining -= 1;
                TurretText.GetComponent<UnityEngine.UI.Text>().text = "" + TurretsRemaining;
                makeTurret(p);
            }
        }
    }

    void makeTurret(Vector3 p){
        Turret newTurret = Instantiate(TurretPrefab, new Vector3(p.x, p.y, 0), Quaternion.identity);
        newTurret.transform.parent = TurretParent.transform;
        newTurret.parent = this;
        TurretList.Add(newTurret);
    }
}
