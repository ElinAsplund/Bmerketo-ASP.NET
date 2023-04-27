﻿using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo_WebApp.ViewModels;

public class AccountIndexViewModel
{
    public string? Title { get; set; }
    public UserProfileEntity UserProfile { get; set; } = null!;
}