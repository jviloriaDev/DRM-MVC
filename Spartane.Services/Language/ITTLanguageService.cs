using Spartane.Core.Domain.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Language
{
    public partial interface ITTLanguageService
    {
        String GetMessage(int idLanguage, int idMessage);
        String GetTextProcess(int idLanguage, int idProcess);
        String GetTextDTID(int idLanguage, int dtId);
        String GetTextDomain(int idLanguage, TraductorTypeDomain type, int idProcess, String domain);
        //Image GetImage(int idLanguage);
    }
}
