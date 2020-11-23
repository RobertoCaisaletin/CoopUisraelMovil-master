using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoopUisraelSQlite
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
