using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FocusStats
{
    public FocusStats() { }
    public FocusStats(string p_attributeFocus = "General", int p_strength = 0, int p_toughness = 0, int p_intellect = 0, int p_mind = 0, int p_agility = 0, int p_health = 0, string p_damage = "D10")
    {
        AttributeFocus = p_attributeFocus;
        Strength = p_strength;
        Toughness = p_toughness;
        Intellect = p_intellect;
        Mind = p_mind;
        Agility = p_agility;
        Health = p_health;
        Damage = p_damage;
    }

    public string AttributeFocus { get; set; }
    public int Strength { get; set; }
    public int Toughness { get; set; }
    public int Intellect { get; set; }
    public int Mind { get; set; }
    public int Agility { get; set; }
    public int Health { get; set; }
    public string Damage { get; set; }
}
