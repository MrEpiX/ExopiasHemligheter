using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enemy
{
    public Enemy()
    {
        variantList = new List<EnemyVariant>();
    }

    public string name { get; set; }
    public List<EnemyVariant> variantList { get; set; }
}