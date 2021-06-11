using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;


namespace Service
{
    public class MagacinService
    {

        MagacinRepozitorijum magacinRepozitorijum = MagacinRepozitorijum.Instance;
        public bool DodajOpremu(InventarDTO inventarDTO)
        {
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapMagacin");
            Dictionary<int, int> id_map = datotekaID.dobaviSve();

            int id = nadjiSlobodanID(id_map);
            id_map[id] = 1;

            inventarDTO.Id = id;
            Inventar inventar = new Inventar(inventarDTO);

            datotekaID.sacuvaj(id_map);
            magacinRepozitorijum.Sacuvaj(inventar);
            return true;
        }

        public bool ObrisiOpremu(InventarDTO opremaDTO)
        {
            Inventar oprema = new Inventar(opremaDTO);
            ObservableCollection<Inventar> magacin = magacinRepozitorijum.DobaviSve();
            foreach (Inventar inventar in magacin)
            {
                if (inventar.Id.Equals(opremaDTO.Id))
                {
                    MagacinRepozitorijum.Instance.magacinOprema.Remove(inventar);
                    magacin.Add(oprema);
                    magacinRepozitorijum.Sacuvaj(oprema);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajOpremu(InventarDTO oprema)
        {
            // TODO: implement
            return false;
        }

        public Inventar PregledJedneopreme()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Inventar> PregledSveOpreme()
        {
            MagacinRepozitorijum mr = MagacinRepozitorijum.Instance;
            return mr.DobaviSve();

        }

        public ObservableCollection<InventarDTO> PregledSveOpremeDTO()
        {
            ObservableCollection<Inventar> inventar = magacinRepozitorijum.DobaviSve();
            ObservableCollection<InventarDTO> inventarDTO = new ObservableCollection<InventarDTO>();
            foreach (Inventar oprema in inventar)
            {
                inventarDTO.Add(konvertujEntitetUDTO(oprema));
            }
            return inventarDTO;

        }

        public InventarDTO konvertujEntitetUDTO(Inventar inventar)
        {
            return new InventarDTO(inventar);
        }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
        }

    }
}
