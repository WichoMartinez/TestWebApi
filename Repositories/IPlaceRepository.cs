using StoreApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreApi.Repository
{
    public interface IPlaceRepository
    {
        List<VwPlacesCategory> GetAllPlaces();
        Place GetPlace(long id);
        List<Place> GetAllPlacesByCategory(long CategoryId);
        Place CreatePlace(string name, string address, long category);
    }
}