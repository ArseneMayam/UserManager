using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Common.Models;
using UserManager.Data.Interfaces;
using UserManager.Data.Extensions;
using UserManager.Data.Entities;
using System.Linq;


namespace UserManager.Data
{
    public class ColonneData : IColonneData
    {
        internal DataAccessContext DataAccessContext { get; set; }

        public ColonneData(IServiceProvider serviceProvider)
        {
            DataAccessContext = serviceProvider.GetService(typeof(DataAccessContext)) as DataAccessContext;
        }

        // recuperer les colonnes avec une liste de colonne_id
        public IList<Colonne> RecupererColonnes(IList<int> colonne_id)
        {
            throw new NotImplementedException();
        }

        public IList<Colonne> getAll()
        {
            return null;
        }
    }
}
