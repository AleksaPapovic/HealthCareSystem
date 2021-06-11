using Service;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class ZahtevPremestanjaController
    {
        ZahtevPremestanjaService zahteviPremestanjaService = new ZahtevPremestanjaService();
        public ObservableCollection<ZahtevPremestanjaDTO> PregledSveOpremeDTO()
        {
            return zahteviPremestanjaService.PregledSveOpremeDTO();
        }

        public bool ObrisiZahtevPremestanja(ZahtevPremestanjaDTO zahtevPremestanjaDTO)
        {
            return zahteviPremestanjaService.ObrisiZahtevPremestanja(zahtevPremestanjaDTO);
        }

        public bool ZakaziPremestanje(InventarDTO selectedItem1, ZahtevPremestanjaDTO zahtevPremestanjaDTO, string selectedItem2, string text)
        {
            return zahteviPremestanjaService.ZakaziPremestanje(selectedItem1, zahtevPremestanjaDTO, selectedItem2, text);
        }
    }
}
