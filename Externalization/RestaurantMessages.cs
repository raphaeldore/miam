using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Externalization
{
    public static class RestaurantsMessages
    {
        public const string NAME_LABEL = "Nom";
        public const string CITY_LABEL = "Ville";
        public const string COUNTRY_LABEL = "Pays";

        // error messages
        public const string NAME_REQUIRED_ERROR = "Le champ nom est requis";
        public const string CITY_REQUIRED_ERROR = "Le champ ville est requis";
        public const string COUNTRY_REQUIRED_ERROR = "Le champ pays est requis";
    }
}
