using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace AzChallangeCalicotApi.Data
{
    public class DataServiceBase
    {
        private readonly CalicotContextExtension _context;
        private const string DEFAULTUSER = "defaultuser";
        public DataServiceBase(CalicotContextExtension context)
        {
            _context = context;
        }

        public virtual TEntity Add<TEntity>(TEntity entity, int evenementId = 0) where TEntity : class
        {
            if (entity == null)
            {
                return entity;
            }

            typeof(TEntity).GetProperty("UsagerCreation")?.SetValue(entity, DEFAULTUSER);
            if (typeof(TEntity).GetProperty("DateHeureCreation")?.GetValue(entity) == null || (DateTime)(typeof(TEntity).GetProperty("DateHeureCreation")?.GetValue(entity)) == new DateTime(1, 1, 1, 0, 0, 0))
            {
                typeof(TEntity).GetProperty("DateHeureCreation")?.SetValue(entity, DateTime.Now);
            }

            typeof(TEntity).GetProperty("UsagerModification")?.SetValue(entity, null);
            typeof(TEntity).GetProperty("DateHeureModification")?.SetValue(entity, null);
            _context.Set<TEntity>().Add(entity);
            var state = _context.SaveChanges() > 0;
            
            return entity;
        }

        public virtual TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                if (entity != null)
                {
                    typeof(TEntity).GetProperty("UsagerModification")?.SetValue(entity, DEFAULTUSER);
                    typeof(TEntity).GetProperty("DateHeureModification")?.SetValue(entity, DateTime.Now);
                    _context.Update(entity);
                    var state = _context.SaveChanges() > 0;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    var databaseValues = entry.GetDatabaseValues();
                    // Actualiser les valeurs d'origine pour ignorer la prochaine vérification de la concurrence
                    entry.OriginalValues.SetValues(databaseValues);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException($"Entité introuvable. Mise à jour impossible.  Exception: {e.Message}. {e.StackTrace}");
            }
            return entity;
        }

        public virtual TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                if (entity != null)
                {
                    typeof(TEntity).GetProperty("UsagerSuppression")?.SetValue(entity, DEFAULTUSER);
                    typeof(TEntity).GetProperty("DateHeureSuppression")?.SetValue(entity, DateTime.Now);

                    _context.Update(entity);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException($"Entité introuvable. Mise à jour impossible.  Exception: {e.Message}. {e.StackTrace}");
            }
            return entity;
        }

        public virtual int Remove<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                if (entity != null)
                {
                    _context.Remove(entity);
                    var state = _context.SaveChanges();
                    return state;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"Erreur arrivé pendant la suppression. {ex}");
            }
        }

        public virtual IEnumerable<TEntity> Update<TEntity>(IEnumerable<TEntity> entites, string usagerModification) where TEntity : class
        {
            var dt = DateTime.Now;
            foreach (var entity in entites)
            {
                typeof(TEntity).GetProperty("UsagerModification")?.SetValue(entity, dt);
                typeof(TEntity).GetProperty("UsagerModification")?.SetValue(entity, usagerModification);
                _context.Entry(entity).State = EntityState.Modified;
            }
            return entites;
        }

        public virtual IEnumerable<TEntity> Update<TEntity>(Expression<Func<TEntity, bool>> predicate, string usagerModification) where TEntity : class
        {
            var entites = _context.Set<TEntity>().Where(predicate).ToList();
            var dt = DateTime.Now;
            foreach (var entity in entites)
            {
                typeof(TEntity).GetProperty("UsagerModification")?.SetValue(entity, dt);
                typeof(TEntity).GetProperty("UsagerModification")?.SetValue(entity, usagerModification);
                _context.Entry(entity).State = EntityState.Modified;
            }
            return entites;
        }

        public void DetachedEntity<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void DetachedEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
        }
    }

}
