using Microsoft.EntityFrameworkCore;
using StoreApi.Notifications;
using StoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Repository
{
    public class PlaceRepository : IPlaceRepository
    {

        private readonly StoresContext _context;

        public PlaceRepository(StoresContext db)
        {
            _context = db;
        }
        public List<VwPlacesCategory> GetAllPlaces()
        {
            var places = _context.VwPlacesCategory.ToList();
            return places.ToList();
        }

        public Place GetPlace(long id)
        {
            return _context.Place.FirstOrDefault(p => p.Id == id);
        }

        public List<Place> GetAllPlacesByCategory(long CategoryId)
        {
            var places = _context.Place.FromSql("dbo.GetPlacesByCategory @p0", CategoryId);
            return places.ToList();
        }

        public Place CreatePlace(string name, string address, long category)
        {
            _context.Database.BeginTransaction();
            Place singlePlace = new Place() { Name = name, Address = address };
            _context.Place.Add(singlePlace);
            _context.SaveChanges();

            Category _category = _context.Category.Find(category);

            PlaceCategory placeCategory = new PlaceCategory() { PlaceId = singlePlace.Id, CategoryId = _category.Id };
            _context.PlaceCategory.Add(placeCategory);

            _context.SaveChanges();
            var account = _context.Account.FromSql("dbo.GetAccountsAllowNotification");
            Notification notification = new Notification();
            if (account != null)
                if (notification.SendEmail(account.ToList()))
                    _context.Database.CommitTransaction();
                else
                    _context.Database.RollbackTransaction();

            return singlePlace;
        }

    }
}


