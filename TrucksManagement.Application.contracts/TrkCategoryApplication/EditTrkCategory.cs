﻿namespace TrucksManagement.Application.contracts.TrkCategoryApplication;

public class EditTrkCategory : CreateTrkCategory
{
    public long Id { get; set; }
    public string? PictureName { get; set; }
}