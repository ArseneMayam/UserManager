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
        public Colonne RecupererColonneId(int id)
        {
            var colonne = DataAccessContext.Colonne.Find(id);

            return colonne.ToModel();
        }

        public IList<Colonne> RecupererListeColonnes()
        {
            var colonnes = DataAccessContext.Colonne.ToList();

            return colonnes.ToModel();
        }
    }
}
