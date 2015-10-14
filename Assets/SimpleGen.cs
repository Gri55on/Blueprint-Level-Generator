using UnityEngine;
using System.Collections;

public class SimpleGen : MonoBehaviour
{
	//Size vaiables
	public int wallSize = 5;
	
	//Image array 
	public Texture2D[] layer;
	int arraySize = 1;
	
	
	// Use this for initialization
	void Start() 
	{
		arraySize = layer.Length;
		Generate();
	}
	
	void Generate()
	{	
		//Layer iterator (Selects which floor to draw)
		for(int l=0;l<arraySize;l++)
		{
			//Game object that will be used as a building block
			GameObject cube;
			
			//Layer Select
			Texture2D blueprint = layer[l];
			
			//Size of image in width/Height
			int maxH = blueprint.height;
			int maxW= blueprint.width;
			int picSize = maxW*maxH;
			
			//Starting height depending on layer selected
			float layerHeight = (wallSize) *l-(l);
			
			//Iterators for pixel selection
			int i;
			int j;
			
			//check for image size
			//Small image
			if (picSize < 500)
			{
				//Full loop to read through each pixel
				for(i=0;i<maxW;i++)
				{
					for(j=0;j<maxH;j++)
					{
						//Get the color of the pixel (Pix = current pixel colour data)
						Color pix = blueprint.GetPixel(i,j);
						
						//Colour checks with tollerance see "colourCompare" function(returns colour) 
						//
						//Check for blank pixels, performs an action if that pixel has colour
						if(colourCompare(pix) != Color.clear)
						{
							//RED:Creates a Window 
							if(colourCompare(pix)== Color.red)
							{
								//Bottom half of window
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								
								cube.transform.localScale = new Vector3(1,(wallSize/2),1);
								cube.transform.position = new Vector3(i,layerHeight+(wallSize/4),j);
								cube.name = "cube"+i+j+"DoorBot";
								cube.GetComponent<Renderer>().material.color = pix;
								
								//Top half of window
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);	
								cube.transform.localScale = new Vector3(1,(wallSize/2),1);
								cube.transform.position = new Vector3(i,layerHeight+(wallSize)-(wallSize/4),j);
								cube.name = "cube"+i+j+"DoorTop";
								cube.GetComponent<Renderer>().material.color = pix;
							}
							
							//GREEN:Creates Grass
							if(colourCompare(pix)== Color.green)
							{
								//do green things
								
							}
							//BLUE:Creates Water
							if(colourCompare(pix)== Color.blue)
							{
								//do blue things
								
							}
							
							//CYAN
							if(colourCompare(pix)== Color.cyan)
							{
								
							}
							//MAGENTA
							if(colourCompare(pix)== Color.magenta)
							{
								
							}
							//YELLOW
							if(colourCompare(pix)== Color.yellow)
							{
								
							}
							
							//WHITE:Creates Floor
							if(colourCompare(pix)== Color.white)
							{
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.position = new Vector3(i,layerHeight+0.5f,j);
								
								cube.name = "cube"+i+j+"Floor";
								cube.GetComponent<Renderer>().material.color = pix;
								
							}
							//GREY: CreatesFloor and Ceiling 
							if(colourCompare(pix)== Color.grey)
							{
								//Floor
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.position = new Vector3(i,layerHeight + 0.5f,j);
								cube.name = "cube"+i+j+"Floor";
								cube.GetComponent<Renderer>().material.color = pix;
								
								
								//Ceiling
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.position = new Vector3(i,layerHeight+(-0.5f+wallSize),j);
								cube.name = "cube"+i+j+"Ceilng";
								cube.GetComponent<Renderer>().material.color = pix;
							}
							
							
							//BLACK:Creates Wall (Height dependant on alpha value)
							//Can be used to create "stairs"
							if(colourCompare(pix)== Color.black)
							{			
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.localScale = new Vector3(1,(wallSize*pix.a),1);
								cube.transform.position = new Vector3(i,layerHeight+((wallSize*pix.a)/2), j);
								
								cube.name = "cube"+i+j+"wall";
								cube.GetComponent<Renderer>().material.color = pix;
							}	
						}
					}
				}
			}
			
			//Same as above, but emits a warning of large file size
			else if (picSize> 1000)
			{
				Debug.LogWarning("Large file detected, expect wait;");
				//Full loop to read through each pixel
				for(i=0;i<maxW;i++)
				{
					for(j=0;j<maxH;j++)
					{
						//Get the color of the pixel (Pix = current pixel colour data)
						Color pix = blueprint.GetPixel(i,j);
						
						//Colour checks with tollerance see "colourCompare" function(returns colour) 
						//
						//Check for blank pixels, performs an action if that pixel has colour
						if(colourCompare(pix) != Color.clear)
						{
							//RED:Creates a Window 
							if(colourCompare(pix)== Color.red)
							{
								//Bottom half of window
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								
								cube.transform.localScale = new Vector3(1,(wallSize/2),1);
								cube.transform.position = new Vector3(i,layerHeight+(wallSize/4),j);
								cube.name = "cube"+i+j+"DoorBot";
								cube.GetComponent<Renderer>().material.color = pix;
								
								//Top half of window
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);	
								cube.transform.localScale = new Vector3(1,(wallSize/2),1);
								cube.transform.position = new Vector3(i,layerHeight+(wallSize)-(wallSize/4),j);
								cube.name = "cube"+i+j+"DoorTop";
								cube.GetComponent<Renderer>().material.color = pix;
							}
							
							//GREEN:Creates Grass
							if(colourCompare(pix)== Color.green)
							{
								//do green things
								
							}
							//BLUE:Creates Water
							if(colourCompare(pix)== Color.blue)
							{
								//do blue things
								
							}
							
							//CYAN
							if(colourCompare(pix)== Color.cyan)
							{
								
							}
							//MAGENTA
							if(colourCompare(pix)== Color.magenta)
							{
								
							}
							//YELLOW
							if(colourCompare(pix)== Color.yellow)
							{
								
							}
							
							//WHITE:Creates Floor
							if(colourCompare(pix)== Color.white)
							{
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.position = new Vector3(i,layerHeight+0.5f,j);
								
								cube.name = "cube"+i+j+"Floor";
								cube.GetComponent<Renderer>().material.color = pix;
								
							}
							//GREY: CreatesFloor and Ceiling 
							if(colourCompare(pix)== Color.grey)
							{
								//Floor
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.position = new Vector3(i,layerHeight + 0.5f,j);
								cube.name = "cube"+i+j+"Floor";
								cube.GetComponent<Renderer>().material.color = pix;
								
								
								//Ceiling
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.position = new Vector3(i,layerHeight+(-0.5f+wallSize),j);
								cube.name = "cube"+i+j+"Ceilng";
								cube.GetComponent<Renderer>().material.color = pix;
							}
							
							
							//BLACK:Creates Wall (Height dependant on alpha value)
							//Can be used to create "stairs"
							if(colourCompare(pix)== Color.black)
							{			
								cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
								cube.transform.localScale = new Vector3(1,(wallSize*pix.a),1);
								cube.transform.position = new Vector3(i,layerHeight+((wallSize*pix.a)/2), j);
								
								cube.name = "cube"+i+j+"wall";
								cube.GetComponent<Renderer>().material.color = pix;
							}	
						}
					}
				}
			}
		}
		
	}
	
	
	
	//Converts colours that are borderline to Unity standars colours so they can be easily checked
	Color colourCompare(Color colourToCheck)
	{
		//RED
		if (colourToCheck.r >= 0.9f && colourToCheck.g <= 0.1f && colourToCheck.b <= 0.1f && colourToCheck.a >= 0.9f)
		{
			return Color.red;
		}
		
		//GREEN
		if (colourToCheck.r <= 0.1f && colourToCheck.g >= 0.9f && colourToCheck.b <= 0.1f && colourToCheck.a >= 0.9f)
		{
			return Color.green;
		}
		
		//BLUE
		if (colourToCheck.r <= 0.1f && colourToCheck.g <= 0.1f && colourToCheck.b >= 0.9f && colourToCheck.a >= 0.9f)
		{
			return Color.blue;
		}
		
		//WHITE
		if (colourToCheck.r >= 0.9f && colourToCheck.g >= 0.9f && colourToCheck.b >= 0.9f && colourToCheck.a >= 0.9f)
		{
			return Color.white;
		}

		//BLACK
		if(colourToCheck.r <= 0.1f && colourToCheck.g <= 0.1f && colourToCheck.b <= 0.1f&&colourToCheck.a >= 0.2f)
		{
			return Color.black;
		}
		
		//CYAN
		if(colourToCheck.r <= 0.1f && colourToCheck.g >= 0.9f && colourToCheck.b >= 0.9f && colourToCheck.a >= 0.9f)
		{
			return Color.cyan;
		}

		//MAGENTA
		if(colourToCheck.r >= 0.9f && colourToCheck.g <= 0.1f && colourToCheck.b >= 0.9f && colourToCheck.a >= 0.9f)
		{
			return Color.magenta;
		}
		
		//YELLOW
		if(colourToCheck.r >= 0.9f && colourToCheck.g >= 0.9f && colourToCheck.b <= 0.1f && colourToCheck.a >= 0.9f)
		{
			return Color.yellow;
		}
		
		
		//GREY
		if(colourToCheck.r < 0.6f && colourToCheck.r > 0.4f && 
		   colourToCheck.g < 0.6f && colourToCheck.g > 0.4f && 
		   colourToCheck.b < 0.6f && colourToCheck.b > 0.4f &&
		   colourToCheck.a >= 0.09f)
			
		{
			return Color.grey;
		}
		
		//NON DEFINED COLOURS
		else
		{
			return Color.clear;
		}
	}	
	
	void neighborCheck()
	{
		
	}
}
