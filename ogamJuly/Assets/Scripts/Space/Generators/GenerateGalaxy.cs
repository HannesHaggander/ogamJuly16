using UnityEngine;
using System.Collections;

public class GenerateGalaxy : MonoBehaviour
{
    private int galaxiesToGenerate = 10;
    private bool isGenerated = false;
    private string pathToGalaxiy = "Prefabs/SpaceObjects/Galaxy";
    private float galaxySpawnDistanceMin = 2;
    private float galaxySpawnDistanceMax = 5;
    private float galaxyPaddingDistance = 3;

    private GameObject[] SpawnedGalaxies;

    Vector3 suggestedSpawn = Vector3.zero;

    void Start()
    {
        if (isGenerated)
        {
            PaintGalaxy();
        }
        else
        {
            CreateGalaxy();
        }
    }   


    /// <summary>
    /// Creates a Galaxy map 
    /// </summary>
    void CreateGalaxy()
    {
        SpawnedGalaxies = new GameObject[galaxiesToGenerate];
        GameObject galaxyPrefab = (GameObject)Resources.Load(pathToGalaxiy);
        for (int i = 0; i < galaxiesToGenerate; i++)
        {
            Vector3 OKSpawn = GetOkPosition();
            

            GameObject tmpGalaxy = (GameObject) Instantiate(galaxyPrefab, OKSpawn, Quaternion.identity);
            if (i == 0)
            {
                tmpGalaxy.transform.position = Vector3.zero;
                tmpGalaxy.GetComponent<GalaxyInformation>().Selected = true;
            }

            SpawnedGalaxies[i] = tmpGalaxy;
            SpawnedGalaxies[i].transform.parent = transform;
            SpawnedGalaxies[i].name = "Galaxy_" + i.ToString();
        }
        MakeConnections();
    }

    /// <summary>
    /// connect galaxies making it possible to travel between them... this is the #1 meeting place for lonely galaxies
    /// </summary>
    void MakeConnections()
    {
        //there has to be more than one galaxy to make connections
        if(SpawnedGalaxies.Length > 1)
        {
            GalaxyInformation gi;
            gi = SpawnedGalaxies[0].GetComponent<GalaxyInformation>();
            gi.SetConnection(SpawnedGalaxies[1]);
            foreach (GameObject g in SpawnedGalaxies)
            {
                gi = g.GetComponent<GalaxyInformation>();
                for(int i = 0; i < 3; i++)
                {
                    GameObject possibleSpawn = SpawnedGalaxies[Random.Range(0, SpawnedGalaxies.Length)];
                    while (gi.CheckIfConnected(possibleSpawn))
                    {
                        possibleSpawn = SpawnedGalaxies[Random.Range(0, SpawnedGalaxies.Length)];
                    }

                    gi.SetConnection(possibleSpawn);
                }

            }
        }
        isGenerated = true;
    }

    /// <summary>
    /// Gets an ok position for a galaxy to spawn, not to close to other galaxies
    /// </summary>
    /// <returns>an ok position in space to spawn a galaxy</returns>
    private Vector3 GetOkPosition()
    {
        suggestedSpawn.x += Random.Range(galaxySpawnDistanceMin, galaxySpawnDistanceMax);
        suggestedSpawn.y = Random.Range(0, 2) > 0 ? Random.Range(galaxySpawnDistanceMin, galaxySpawnDistanceMax) : Random.Range(-galaxySpawnDistanceMax, -galaxySpawnDistanceMin);
        foreach (GameObject g in SpawnedGalaxies)
        {
            if (!g)
            {
                break;
            }

            while(Vector2.Distance(suggestedSpawn, g.transform.position) < galaxyPaddingDistance)
            {
                suggestedSpawn.y += 0.2f;
            }
        }
        return suggestedSpawn;
    }

    /// <summary>
    /// Visualizes the galaxy that was created at the start
    /// </summary>
    void PaintGalaxy()
    {
        if(SpawnedGalaxies.Length <= 0)
        {
            return;
        }
        
        foreach(GameObject g in SpawnedGalaxies)
        {
            Instantiate(g, g.transform.position, g.transform.rotation);
        }
    }

    public void SetSelected(GameObject param)
    {
        if(!param)
        {
            return;
        }
        foreach(GameObject g in SpawnedGalaxies)
        {
            g.GetComponent<GalaxyInformation>().Selected = false;
            foreach(Transform t in g.transform)
            {
                Destroy(t.gameObject);
            }
        }

        param.GetComponent<GalaxyInformation>().Selected = true;
    }
}
