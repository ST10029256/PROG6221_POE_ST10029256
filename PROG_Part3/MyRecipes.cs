using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Part3
{
    public static class MyRecipes
    {
        // Singleton instance of ManageMyRecipes class
        public static ManageMyRecipes manageMyRecipes { get; } = new ManageMyRecipes();
    }
}

