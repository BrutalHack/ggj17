using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSortingOrder : MonoBehaviour
{
    public Renderer _renderer;
    public string SortingLayer;
    public int SortingOrder;

	// Use this for initialization
	void Start ()
	{
	    _renderer = GetComponent<TrailRenderer>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    _renderer.sortingLayerName = SortingLayer;
	    _renderer.sortingOrder = SortingOrder;

	}
}
