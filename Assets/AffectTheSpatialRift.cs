using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.Events;

public class AffectTheSpatialRift : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnityEvent<Material> m_SeasonalDrift = new UnityEvent<Material>();
    public float responsiveness = 2;
    private GameObject previousBlock;
    private GameObject newBlock;
    private Color prevColor;
    private Color newColor;
    private List<GameObject> seasons = new List<GameObject>();
    Camera cam;
    private int[] sequence = { 0, 1, 0, 2, 3, 2, 0, 3, 666 };
    private int i = 0;
    public float pulseSpeed = 2f;


    void Start()
    {
        cam = GetComponent<Camera>();
        m_SeasonalDrift.AddListener(SeasonalDrift);
        seasons.Add(GameObject.Find("Spring"));
        seasons.Add(GameObject.Find("Summer"));
        seasons.Add(GameObject.Find("Fall"));
        seasons.Add(GameObject.Find("Winter"));
        newBlock = seasons[0];
        prevColor = cam.backgroundColor;
        newColor = GetColorFromSeason(newBlock);
    }

    // Update is called once per frame
    void Update()
    {
        float prox = ProximityScore(GameObject.Find("You").transform.position, newBlock.transform.position);
        Color color = Color.Lerp(prevColor, newColor, prox);
        cam.backgroundColor = CalculatePulsatingColor(color, prevColor);
    }

    void SeasonalDrift(Material m)
    {
        cam.backgroundColor = m.color;
        prevColor = GetColorFromSeason(seasons[sequence[i]]);
        previousBlock = seasons[sequence[i]];
        i++;
        newBlock = seasons[sequence[i]];
        newColor = GetColorFromSeason(seasons[sequence[i]]);
    }

    Color GetColorFromSeason(GameObject season)
    {
        
        if (season.TryGetComponent(out Renderer r))
        {
            Color c = r.material.color;
            return c;
        } else
        {
            return Color.white;
        }
    }

    float ProximityScore(Vector3 object1, Vector3 object2)
    {
        // Assuming object1 and object2 are Vector3 representing (x, y, z) coordinates
        float distance = CalculateEuclideanDistance(object1, object2);
        float proximity = 1 / (1 + distance / responsiveness);
        return proximity;
    }

    float CalculateEuclideanDistance(Vector3 point1, Vector3 point2)
    {
        return Mathf.Sqrt(Mathf.Pow(point1.x - point2.x, 2) +
                          Mathf.Pow(point1.y - point2.y, 2) +
                          Mathf.Pow(point1.z - point2.z, 2));
    }

    Color CalculatePulsatingColor(Color start, Color end)
    {
        // Use Mathf.Sin to oscillate between 0 and 1 smoothly
        float lerpFactor = Mathf.Sin(Time.time * pulseSpeed) * 0.5f + 0.5f;

        // Use Color.Lerp to interpolate between startColor and endColor
        return Color.Lerp(start, end, lerpFactor);
    }
}
