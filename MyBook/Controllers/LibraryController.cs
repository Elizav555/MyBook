﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers;

public class LibraryController: Controller
{
    private LibraryViewModel _viewModel;
    private readonly EfBookRepository _bookRepository;
    private readonly EfAuthorRepository _authorRepository;
    private readonly IGenericRepository<Genre> genreRepository;
    
    public LibraryController(
        EfBookRepository _bookRepository,
        EfAuthorRepository _authorRepository, IGenericRepository<Genre> genreRepository)
    {
        this._bookRepository = _bookRepository;
        this._authorRepository = _authorRepository;
        this.genreRepository = genreRepository;
    }

    public async Task<IActionResult> Index(string filterLanguage, string filterGenre)
    {
        if (String.IsNullOrEmpty(filterLanguage) || filterLanguage=="Все")
        {
            _viewModel = new LibraryViewModel(_bookRepository, _authorRepository, genreRepository);
        }
        else
        {
            _viewModel = new LibraryViewModel(_bookRepository, _authorRepository, filterLanguage, genreRepository, filterGenre);
        }

        return View(_viewModel);
    } 
    
    
}