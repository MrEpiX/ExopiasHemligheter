using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Terrain
{
    public Terrain()
    {
        Enemies = new List<EnemyType>();
        Weathers = new List<WeatherType>();
        Locations = new List<LocationType>();
    }

    public string Name;
    public List<EnemyType> Enemies;
    public List<WeatherType> Weathers;
    public List<LocationType> Locations;
}