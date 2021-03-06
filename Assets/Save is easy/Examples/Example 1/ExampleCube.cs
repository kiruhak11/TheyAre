using SaveIsEasy;
using UnityEngine;

public class ExampleCube : MonoBehaviour, ISaveIsEasyEvents {

    public bool CreateRandomObjects;

    public float Speed;

    private Color color;
    public GameObject CreateRandomObjectsPrefab;
    void Awake() {
        Speed = Random.Range(.5f, 5f);
    }

    void Update() {

        if (CreateRandomObjects) {
            if (Random.Range(1, 70) == 1) {
                GameObject newObject = Instantiate<GameObject>(CreateRandomObjectsPrefab);
                newObject.transform.position = transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
            }
        } else {

            if (Random.Range(0, 500) == 1) {
                color = Color.blue;
            }
            if (Random.Range(0, 500) == 1) {
                color = Color.green;
            }
            if (Random.Range(0, 500) == 1) {
                color = Color.red;
            }
            if (Random.Range(0, 500) == 1) {
                color = Color.white;
            }

            gameObject.GetComponent<Renderer>().material.color = color;

            transform.Translate(Vector3.down * Time.deltaTime * Speed, Space.World);
            if (transform.position.y < 0) {
                Destroy(gameObject);
            }

            transform.Rotate(new Vector3(1, 1, 0) * Time.deltaTime * 10);
        }
    }

    void ISaveIsEasyEvents.OnLoad() {
        //Example of load event
        //Debug.Log("On Load event!");
    }

    void ISaveIsEasyEvents.OnSave() {
        //Example of save event
    }
}
