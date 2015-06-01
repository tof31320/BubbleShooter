using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CanonController : MonoBehaviour {

    public Transform canon;

    public GameObject nextBoulet;

    public float power = 10.0f;

    public Vector3 currentDirection = Vector3.zero;

    public float lastFireTime = 0f;
    public float fireInterval = 1f;

    public int currentBouletIndex = 0;
    public List<GameObject> boulets = new List<GameObject>();

	// Use this for initialization
	void Start () {
        nextBoulet = Grille.instance.CreateARandomBoulet(canon.position);

        for (int i = 0; i < 5; i++) {
            boulets.Add( Grille.instance.CreateARandomBoulet(canon.position));
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector3 direction = (canon.position - mousePosition).normalized;
        currentDirection = -direction;
        float angle = Mathf.Atan2(currentDirection.x, currentDirection.y) * Mathf.Rad2Deg;

        canon.rotation = Quaternion.AngleAxis(angle, -canon.forward);

        if(Input.GetMouseButtonUp(0) && currentBouletIndex < boulets.Count){
            // Lance le prochain boulet
            //if(Time.time - lastFireTime > lastFireTime){
                Fire();
                Debug.Log("Fire !");
            //}
        }        
	}

    public void Fire()
    {
        nextBoulet = boulets[currentBouletIndex++];

        nextBoulet.GetComponent<Rigidbody2D>().AddForce(currentDirection * power, ForceMode2D.Impulse);
    }
}
