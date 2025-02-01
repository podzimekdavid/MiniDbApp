﻿using Microsoft.AspNetCore.Mvc;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Services;

namespace MiniDbApp.API.Controllers;

[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ProductController : Controller
{
    private readonly ProductDbService _productDb;

    public ProductController(ProductDbService productDb)
    {
        _productDb = productDb;
    }
}