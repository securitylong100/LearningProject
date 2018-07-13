using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UpdateCost.Vo
{
    public class CheckConnectionVo
    {
        public int MaxId { get; set; }
        public DataTable dt { get; set; }

        public List<CheckConnectionVo> AssetListVo = new List<CheckConnectionVo>();
    }
}
