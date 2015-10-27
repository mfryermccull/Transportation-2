using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	public GameObject cubePrefab;
	private GameObject[,] allCubes;
	public GameObject aCube;
	public Airplane airplane;
	int gridWidth = 16;
	int gridHeight = 9;

	// If the player clicks an inactive airplane, it should highlight
	// If the player clicks an active airplane, it should unhighlight
	// If the player clicks the sky and there isn’t an active airplane, 
	//   nothing happens.
	// If the player clicks the sky and there is an active airplane,
	//   the airplane teleports to that location
	public void ProcessClickedCube (GameObject clickedCube, int x, int y) {

		if (x == airplane.x && y == airplane.y && airplane.active == false) {
			airplane.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
		} else if (x == airplane.x && y == airplane.y && airplane.active) {
			airplane.active = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		} else if (airplane.active && (x != airplane.x || y != airplane.y)) {
			allCubes [airplane.x, airplane.y].GetComponent<Renderer> ().material.color = Color.white;
			allCubes [x, y].GetComponent<Renderer> ().material.color = Color.yellow;
			airplane.x = x;
			airplane.y = y;
		}
	}
		//rules need to be set before game start
	// Use this for initialization
	void Start () {

		allCubes = new GameObject[gridWidth, gridHeight];
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes[x,y] = (GameObject) Instantiate(aCube, new Vector3(x*2 - 14, y*2 - 8, 10), Quaternion.identity);
				allCubes[x,y].GetComponent<CubeBehaviour>().x = x;
				allCubes[x,y].GetComponent<CubeBehaviour>().y = y;
			}
		}

		foreach (GameObject oneCube in allCubes) {
			oneCube.GetComponent<Renderer>().material.color = Color.white;
		}
		
		airplane = new Airplane();
		airplane.x = 0;
		airplane.y = 8;
		allCubes[0,8].GetComponent<Renderer>().material.color = Color.red;
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
