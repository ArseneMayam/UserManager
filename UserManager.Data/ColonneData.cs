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
            var list = DataAccessContext.Colonne.Where(c => colonne_id.Contains(c.Colonne_Id)).ToList();
            return list.ToModel();
        }

        public IList<Colonne> List()
        {
            var list = DataAccessContext.Colonne.ToList();
            return list.ToModel();
        }
    }
}
