﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FilmCatalogCore.Models;
using JetBrains.Annotations;

namespace FilmCatalogCore.Services.Films
{
    public interface IFilmService
    {
        Task<IndexViewModel> GetFilmList(int page);
        Task<FilmViewDetailModel> GetById(int id);
        Task<FilmEditModel> EditFilm(FilmEditModel model);
        Task Delete(int id);
        Task Create(FilmCreateModel film);
        Task<FilmEditModel> GetEditFilm(int id);
    }
}