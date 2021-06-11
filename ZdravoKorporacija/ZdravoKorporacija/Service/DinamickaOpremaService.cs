using Model;
using Repository;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
    public class DinamickaOpremaService
    {

        MagacinService magacinServis = new MagacinService();
        DinamickaOpremaRepozitorijum dinamickaOpremaRepozitorijum = DinamickaOpremaRepozitorijum.Instance;
        public bool DodajOpremu(DinamickaOpremaDTO opremaDTO)
        {

            if (opremaDTO.Prostorija == null)
            {
                return false;
            }


            DinamickaOprema dinamickaOprema = new DinamickaOprema(opremaDTO, opremaDTO.Kolicina);
            dinamickaOprema.Prostorija = new Prostorija(opremaDTO.Prostorija);
            InventarDTO inventar = new InventarDTO(opremaDTO.Id, opremaDTO.Naziv, opremaDTO.UkupnaKolicina, opremaDTO.Proizvodjac, opremaDTO.DatumNabavke);
          

            if (dinamickaOprema.Kolicina <= dinamickaOprema.UkupnaKolicina)
            {
                dinamickaOprema.UkupnaKolicina -= dinamickaOprema.Kolicina;
                inventar.UkupnaKolicina = dinamickaOprema.UkupnaKolicina;
                DinamickaOpremaRepozitorijum.Instance.magacinDinamickaOprema.Add(dinamickaOprema);
              
                dinamickaOpremaRepozitorijum.Sacuvaj();

               ObservableCollection<InventarDTO> magacin = magacinServis.PregledSveOpremeDTO();
               
                foreach (InventarDTO magacinskaOprema in magacin)
                {
                    if (inventar.Id.Equals(magacinskaOprema.Id))
                    {
                        magacinServis.ObrisiOpremu(magacinskaOprema);
                        magacinServis.DodajOpremu(inventar);
                        
                        return true;
                    }
                }
            }
            return false;
        }


        public ObservableCollection<DinamickaOprema> PregledSveOpreme()
        {
            return dinamickaOpremaRepozitorijum.DobaviSve();

        }

        public ObservableCollection<DinamickaOpremaDTO> PregledSveOpremeDTO()
        {
            ObservableCollection<DinamickaOprema> dinamickaOprema = dinamickaOpremaRepozitorijum.DobaviSve();
            ObservableCollection<DinamickaOpremaDTO> dinamickaOpremaDTO = new ObservableCollection<DinamickaOpremaDTO>();
            foreach (DinamickaOprema oprema in dinamickaOprema)
            {
                dinamickaOpremaDTO.Add(konvertujEntitetUDTO(oprema));
            }
            return dinamickaOpremaDTO;

        }

        public DinamickaOpremaDTO konvertujEntitetUDTO(DinamickaOprema dinamickaOprema)
        {
            return new DinamickaOpremaDTO(dinamickaOprema);
        }

        public DinamickaOprema PregledJedneOpreme()
        {
            // TODO: implement
            return null;
        }

    }
}