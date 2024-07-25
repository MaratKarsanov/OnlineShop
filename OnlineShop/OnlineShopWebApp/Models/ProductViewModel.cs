﻿using Microsoft.Identity.Client;
using OnlineShopWebApp.ApiModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указано имя товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость товара")]
        [Range(typeof(decimal), "0", "100000000", ErrorMessage = "Цена должна быть положительной!")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Нет описания")]
        public string Description { get; set; } = "";
        public bool IsInFavourites { get; set; }
        public bool IsInComparison { get; set; }
        public string[] ImagesPaths { get; set; }
        public string ImagePath => ImagesPaths == null || ImagesPaths.Length == 0
                           ? "/images/DefaultImg.jpg"
                           : ImagesPaths[0];
        public List<ReviewApiModel>? Reviews { get; set; } = new List<ReviewApiModel>();
        public decimal AverageGrade
        {
            get
            {
                if (Reviews.Count != 0)
                    return Reviews.Sum(r => r.Grade) / Reviews.Count;
                return 0;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ProductViewModel)
                return false;
            return ((ProductViewModel)obj).Id == Id;
        }
    }
}