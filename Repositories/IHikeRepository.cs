using OregonHikes3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonHikes3.Repositories
{
    public interface IHikeRepository
    {
        List<Hike> Hikes { get; }
        void AddHike(Hike hike);
        Hike GetHikeByTrailName(string trailName);
        Hike GetHikeByRegion(string region);
       
    }
}
