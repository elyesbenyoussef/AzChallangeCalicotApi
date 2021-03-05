using System;
using System.ComponentModel.DataAnnotations;

namespace AzChallangeCalicotApi.Type.Models
{
    public abstract class ModelBase
    {
        private Guid _numeroUniqueGUID;
        public Guid NumeroUniqueGUID
        {
            get
            {
                if (_numeroUniqueGUID == Guid.Empty)
                    _numeroUniqueGUID = Guid.NewGuid();

                return _numeroUniqueGUID;
            }
            set
            {
                _numeroUniqueGUID = value;
            }
        }

        [StringLength(128)]
        public string UsagerCreation { get; set; }

        public DateTime DateHeureCreation { get; set; }

        [StringLength(128)]
        public string UsagerModification { get; set; }

        public DateTime? DateHeureModification { get; set; }

        [StringLength(128)]
        public string UsagerSuppression { get; set; }

        public DateTime? DateHeureSuppression { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] NumeroVersionEnregistrement { get; set; }
    }
}
