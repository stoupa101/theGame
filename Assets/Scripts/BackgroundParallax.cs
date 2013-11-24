using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {

	public Transform[] backgrounds;			//Pole vsech pozadi, ktere budou paralaxovany
	public float parallaxScale;				//Proporce mezi pohybem kamery a pohybem pozadi.
	public float parallaxReductionFactor;	//
	public float smoothing;					//Jak hladky bude paralax efekt

	private Transform cam;					//odkaz na pozici hlavni kamery
	private Vector3 previousCamPos;			//pozice kamery v predeslem framu


	void Awake () {
		cam = Camera.main.transform;
	}

	void Start () {
		//pri startu je predchozi pozice aktualni
		previousCamPos = cam.position;
	}

	void Update () {
		float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;
		for (int i = 0; i < backgrounds.Length; i++) {
			float backgroundTargetPosX = backgrounds[i].position.x + parallax * (i * parallaxReductionFactor + 1);
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCamPos = cam.position;
	}
}
