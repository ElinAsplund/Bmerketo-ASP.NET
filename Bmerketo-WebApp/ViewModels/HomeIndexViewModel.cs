﻿using Bmerketo_WebApp.Models;

namespace Bmerketo_WebApp.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public GridCollectionViewModel BestCollection { get; set; } = null!;
    public GridCollectionViewModel NextCollection { get; set; } = null!;
}
