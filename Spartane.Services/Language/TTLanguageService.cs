using Spartane.Core.Data;
using Spartane.Core.Domain.Language;
using Spartane.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Language
{
    public partial class TTLanguageService : ITTLanguageService
    {
        #region Fields
        private readonly IRepository<TTLanguageTraduction> _ttlanguageTraductionRepository;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        #endregion

        #region Ctor
        public TTLanguageService(IRepository<TTLanguageTraduction> ttlanguageTraductionRepository, IDataProvider dataProvider, IDbContext dbContext)
        {
            this._ttlanguageTraductionRepository = ttlanguageTraductionRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public string GetMessage(int idLanguage, int idMessage)
        {
            var message = this._ttlanguageTraductionRepository
                .Table.SingleOrDefault(v => v.Idioma == idLanguage && v.RelacionMessage == idMessage);
            if (message == null)
                return string.Format("No existe Traduccion Para el Mensaje {0} en el idioma {1}", idMessage, idLanguage);
            else
                return message.Texto;
        }

        public string GetTextProcess(int idLanguage, int idProcess)
        {
            var message = this._ttlanguageTraductionRepository
                .Table.SingleOrDefault(v => v.Idioma == idLanguage && v.RelacionProceso == idProcess);
            if (message == null)
                return string.Format("No existe Traduccion Para el Proceso {0} en el idioma {1}", idProcess, idLanguage);
            else
                return message.Texto;
        }

        public string GetTextDTID(int idLanguage, int dtId)
        {
            var message = this._ttlanguageTraductionRepository
                .Table.SingleOrDefault(v => v.Idioma == idLanguage && v.RelacionDT == dtId);
            if (message == null)
                return string.Format("No existe Traduccion Para el Dato {0} en el idioma {1}", dtId, idLanguage);
            else
                return message.Texto;
        }

        public string GetTextDomain(int idLanguage, Core.Domain.Language.TraductorTypeDomain type, int idProcess, string domain)
        {
            var iDomain = Convert.ToInt32(domain);
            var message = this._ttlanguageTraductionRepository
                .Table.SingleOrDefault(v => v.Idioma == idLanguage &&
                    v.RelacionDominio == iDomain &&
                    v.RelacionProceso == idProcess);
            if (message == null)
                return string.Format("No existe Traduccion Para el Dato {0} en el idioma {1}", domain, idLanguage);
            else
                return message.Texto;
        }
        #endregion
    }
}
