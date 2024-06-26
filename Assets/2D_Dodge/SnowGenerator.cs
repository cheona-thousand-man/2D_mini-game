using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject aPrefab;
    [SerializeField]
    private GameObject bPrefab;
    [SerializeField]
    private GameObject cPrefab;
    [SerializeField]
    private GameObject dPrefab;
    [SerializeField]
    private GameObject ePrefab;
    private List<GameObject> allPrefab = new List<GameObject>();

    float span = 0.5f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        allPrefab.Add(aPrefab);
        allPrefab.Add(bPrefab);
        allPrefab.Add(cPrefab);
        allPrefab.Add(dPrefab);
        allPrefab.Add(ePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; // 게임 내 지정된 시간마다 delta++
        if(this.delta > this.span)
        {
            for (int i = 0; i < Random.Range(2, 10); i++)
            {
                this.delta = 0;
                GameObject snowInstance = Instantiate(allPrefab[Random.Range(0, 4)]);
                int xPosition = Random.Range(-8, 8);
                snowInstance.transform.position = new Vector2(xPosition, Random.Range(5, 35));
            }
        }
    }
}
