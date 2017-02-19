using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

	public int FPS { get; private set; }

	public int AverageFPS { get; private set; }

	public int HighestFPS { get; private set; }
	public int LowestFPS { get; private set; }

	public int frameRange = 60;

	int[] fpsBuffer;
	int fpsBufferIndex;

	void initBuffer()
	{
		if (frameRange < 0)
		{
			frameRange = 1;
		}
		fpsBuffer = new int[frameRange];
		fpsBufferIndex = 0;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fpsBuffer == null || fpsBuffer.Length != frameRange)
		{
			initBuffer ();
		}
		UpdateBuffer ();
		CalculateFPS ();
	}

	void UpdateBuffer()
	{
		fpsBuffer [fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
		if (fpsBufferIndex >= frameRange)
		{
			fpsBufferIndex = 0;
		}
	}

	void CalculateFPS()
	{
		int sum = 0;
		int hightest = 0;
		int lowest = int.MaxValue;
		for (int i = 0; i < frameRange; ++i)
		{
			sum += fpsBuffer [i];
			hightest = fpsBuffer [i] > hightest ? fpsBuffer [i] : hightest;
			lowest = fpsBuffer [i] < lowest ? fpsBuffer [i] : lowest;
		}
		AverageFPS = sum / frameRange;
		HighestFPS = hightest;
		LowestFPS = lowest;
	}
}
