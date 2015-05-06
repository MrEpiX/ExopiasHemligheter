using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RankContainer
{
    public RankContainer()
    {
        focuses = new List<FocusStats>();
    }

    public int rank;
    public List<FocusStats> focuses;
}