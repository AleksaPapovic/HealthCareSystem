using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.UpravnikCRUD;

namespace Controller
{
    public class RenoviranjeController
    {
        RenoviranjeService renoviranjeServis = new RenoviranjeService();
        public Boolean ZakaziRenoviranje(ZahtevRenoviranjeDTO zahtevRenoviranja)
        {
            return renoviranjeServis.ZakaziRenoviranje(zahtevRenoviranja);
        }

      public ObservableCollection<ZahtevRenoviranjeDTO> pregledSvihZahtevaRenoviranjaDTO()
        {
            return renoviranjeServis.pregledSvihZahtevaRenoviranjaDTO();
        }

       public bool ObrisiZahtevRenoviranja(ZahtevRenoviranjeDTO renoviranjeZahtevDTO)
        {
            return renoviranjeServis.ObrisiZahtevRenoviranja(renoviranjeZahtevDTO);
        }
    }
}
