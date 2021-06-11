using Service;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class DinamickaOpremaController
    {
        DinamickaOpremaService dinamickaOpremaService = new DinamickaOpremaService();
        public bool DodajOpremu(DinamickaOpremaDTO dinamickaOpremaDTO)
        {
            return dinamickaOpremaService.DodajOpremu(dinamickaOpremaDTO);
        }
    }
}
