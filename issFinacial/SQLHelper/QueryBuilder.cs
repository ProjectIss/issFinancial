using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.SQLHelper
{
    public class QueryBuilder
    {
        public string BuildQuery(string queryName)
        {
            string query = string.Empty;
            switch (queryName)
            {
                case "login":
                    query = "select * from UserDetails ud " +
                            "inner join CompanyDetails cd on cd.Id = ud.CompanyId " +
                            "inner join SubRole sr on ud.Role = sr.Id "+
                            "where ud.UserName = @username and ud.Password = @Password and cd.CompanyCode=@cCode and ud.IsDeleted = 0 AND ud.IsActive = 0";

                    break;
            }
            return query;
        }
    }
}