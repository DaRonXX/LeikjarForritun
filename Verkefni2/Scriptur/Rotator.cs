using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update er kallað einu sinni á hverju ramma
    void Update()
    {
        // Snúa hlutnum með nýju hornin
        transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);
    }
}