using UnityEngine;
using System.Collections;

public class Grille : MonoBehaviour {

    public GameObject bouletPrefab;

    public int nbInRowsPair = 10;

    public int nbRows = 6;

    public float bouletSize = 0.01f;

    public float gapSize = 0f;

	// Use this for initialization
	void Start () {
        
        //TestGrille();
	}

    private static Grille _instance = null;
    public static Grille instance
    {
        get
        {
            if(_instance == null){
                _instance = GameObject.Find("GridSystem").GetComponent<Grille>();
            }
            return _instance;
        }
    }

    public GameObject CreateABoulet(Vector3 position, Color color)
    {
        GameObject boulet = GameObject.Instantiate(bouletPrefab, position, Quaternion.identity) as GameObject;
        boulet.transform.parent = transform;
        boulet.GetComponent<SpriteRenderer>().color = color;

        return boulet;
    }

    public GameObject CreateARandomBoulet(Vector3 position)
    {
        return CreateABoulet(position, new Color(Random.Range(0,255),Random.Range(0,255),Random.Range(0,255), 1f));
    }

    void TestGrille()
    {
        Vector3 currentPosition = transform.position;
        int tmp = 0;
        float deltaPosition = 0f;
        Color currentColor = Color.red;
        for (int j = 0; j < nbRows; j++)
        {
            if(j % 2 == 0){
                tmp = nbInRowsPair;
                deltaPosition = 0f;
                currentColor = Color.blue;
            }
            else
            {
                tmp = nbInRowsPair - 1;
                deltaPosition =(gapSize + bouletSize) / 2f;
                currentColor = Color.green;
            }
            for (int i = 0; i < tmp; i++)
            {
                GameObject boulet = CreateABoulet(Vector3.zero, currentColor);
                boulet.transform.position = currentPosition;

                currentPosition = new Vector3(transform.position.x + i * (bouletSize+gapSize) + deltaPosition, 
                                              transform.position.y - j * (bouletSize + gapSize), 
                                              currentPosition.z);
            }            
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
