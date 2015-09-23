using UnityEngine;
using System.Collections;

public class SimpleGen : MonoBehaviour
{
	public Texture2D blueprint;


	// Use this for initialization
	void Start() 
	{
		Generate();
	}
	
	// Update is called once per frame
	void Generate() 
	{	
		//Size of image in width/Height
		int maxH = blueprint.height;
		int maxW= blueprint.width;

		int i;
		int j;

		//check for image size
		if (maxH * maxW  < 500)
		{
			//Full loop
			//For loop
			for(i=0;i<maxW;i++)
			{
				for(j=0;j<maxH;j++)
				{
					//Gets colour of pixel at current location from colour image
					Color pix = blueprint.GetPixel(i,j);
					//Creates a cube
					GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
					//Places cube at position
					cube.transform.position = new Vector3(i, 0.5F, j);
					cube.name = "cube"+i+j;
					//Changes colour of cube
					cube.GetComponent<Renderer>().material.color = pix;

				}
			}
		}
		else if (maxH * maxW > 1000)
		{
			Debug.LogWarning("Large file detected, expect wait;");
			for(i=0;i<(maxW);i++)
			{
				for(j=0;j<maxH;j++)
				{
					Color pix = blueprint.GetPixel(i,j);;
					GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
					cube.transform.position = new Vector3(i, 0.5F, j);
                    cube.name = "cube"+i+j;
                    cube.GetComponent<Renderer>().material.color = pix;
                    
				}
			}
		}
		else if (maxH * maxW >10000)
		{
			Debug.LogWarning("File extreemely big expect crashes");
		}
			 


	}
}
