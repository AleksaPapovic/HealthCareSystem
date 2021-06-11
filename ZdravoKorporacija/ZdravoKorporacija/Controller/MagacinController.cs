using Service;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class MagacinController
    {
        MagacinService magacinService = new MagacinService();
        public ObservableCollection<InventarDTO> PregledSveOpremeDTO()
        {
            return magacinService.PregledSveOpremeDTO();
        }
    }
}
