using System;

namespace AzChallangeCalicotApi.Data.Entities
{
    public class EntiteBase
    {
        public Guid NumeroUniqueGUID { get; set; }
        public string UsagerCreation { get; set; }
        public DateTime DateHeureCreation { get; set; }
        public string UsagerModification { get; set; }
        public DateTime? DateHeureModification { get; set; }
        public string UsagerSuppression { get; set; }
        public DateTime? DateHeureSuppression { get; set; }
    }
}