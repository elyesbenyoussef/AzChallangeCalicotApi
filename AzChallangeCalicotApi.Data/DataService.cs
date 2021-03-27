using AutoMapper;
using AzChallangeCalicotApi.Data.Extensions;
using AzChallangeCalicotApi.Type.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MODELS = AzChallangeCalicotApi.Type.Models;

namespace AzChallangeCalicotApi.Data
{
    public class DataService : DataServiceBase, IDataService
    {
        private IMapper _mapper;
        private CalicotContextExtension _context;

        public DataService(IMapper mapper, CalicotContextExtension context) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<MODELS.Produit> ObtenirListeProduits()
        {
            var products = _context.Produit.Include(x => x.Images).Actifs().ToList();

            return _mapper.Map<List<MODELS.Produit>>(products);
        }

        public List<MODELS.Produit> ObtenirListeProduitsActives()
        {
            var products = _context.Produit
                .Include(x => x.Images)
                .Actifs()
                .Where(x => x.IndActive)
                .ToList();

            return _mapper.Map<List<MODELS.Produit>>(products);
        }

        public MODELS.Produit AjouterProduit(MODELS.Produit product)
        {
            var entity = _mapper.Map<Entities.Produit>(product);
            entity = Add(entity);
            return _mapper.Map<MODELS.Produit>(entity);
        }

        public MODELS.Produit ModifierProduit(MODELS.Produit product)
        {
            var entity = _mapper.Map<Entities.Produit>(product);
            entity = Update(entity);
            return _mapper.Map<MODELS.Produit>(entity);
        }

        public bool SupprimerProduit(MODELS.Produit product)
        {
            var entity = _mapper.Map<Entities.Produit>(product);
             Delete(entity);
            return _context.SaveChanges() > 0;
        }

        public MODELS.Produit ObtenirProduit(int produitId)
        {
            var entity = _context.Produit.Include(x => x.Images).Actifs().FirstOrDefault(x => x.ProduitId == produitId);
            if(entity != null)
            {
                DetachedEntity(entity);
            }
            return _mapper.Map<MODELS.Produit>(entity);
        }

        public MODELS.Image AjouterImage(MODELS.Image image)
        {
            var entity = _mapper.Map<Entities.Image>(image);
            entity = Add(entity);
            return _mapper.Map<MODELS.Image>(entity);
        }
    }
}
