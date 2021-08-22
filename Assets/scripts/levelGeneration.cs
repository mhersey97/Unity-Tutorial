using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneration : MonoBehaviour
{
    public GameObject[] level;
    public int xPos;
    public bool creatingLevel = false;
    private int sectionNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingLevel)
        {
            creatingLevel = true;
            StartCoroutine(GenerateSection());
        }
    }

    private IEnumerator GenerateSection()
    {
        sectionNum = Random.Range(0, 4);
        if (sectionNum != 3)
        {
            Instantiate(level[sectionNum], new Vector3(xPos, 0, 0), Quaternion.identity);
        }
        xPos += 1;
        yield return new WaitForSeconds(2);
        creatingLevel = false;
    }
}
