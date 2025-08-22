using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GameManager : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject[] objectsToSpawn;

    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject newObject = Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation);
        XRGrabInteractable interactable = newObject.GetComponent<XRGrabInteractable>();
        interactable.firstSelectEntered.AddListener((args) =>
        {
            Destroy(newObject, 5f); // Destroy the object after 5 seconds if it is grabbed
            SpawnObject();
        });
    }

    public void Start()
    {
        SpawnObject();
    }
}