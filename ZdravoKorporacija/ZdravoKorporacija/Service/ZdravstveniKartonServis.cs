using Model;
using Repository;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace Service
{
    public class ZdravstveniKartonServis
    {
        private static ZdravstveniKartonServis _instance;
        
        public static ZdravstveniKartonServis Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ZdravstveniKartonServis();
                }
                return _instance;
            }
        }
        public bool KreirajZdravstveniKarton(ZdravstveniKarton ZdravstveniKarton, Dictionary<int, int> id_map)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZdravstveniKarton");


            foreach (ZdravstveniKarton pr in zdravstveniKartoni)
            {
                if (pr.Id.Equals(ZdravstveniKarton.Id))
                {
                    return false;
                }
            }
            zdravstveniKartoni.Add(ZdravstveniKarton);
            datoteka.Sacuvaj(zdravstveniKartoni);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool KreirajZdravstveniKarton(ZdravstveniKartonDTO ZdravstveniKarton, Dictionary<int, int> id_map)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZdravstveniKarton");


            foreach (ZdravstveniKarton pr in zdravstveniKartoni)
            {
                if (pr.Id.Equals(ZdravstveniKarton.Id))
                {
                    return false;
                }
            }
            zdravstveniKartoni.Add(new ZdravstveniKarton(ZdravstveniKarton));
            datoteka.Sacuvaj(zdravstveniKartoni);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool KreirajZdravstveniKarton2(ZdravstveniKartonDTO ZdravstveniKarton)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
           
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZdravstveniKarton");

            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            ZdravstveniKarton.Id = id;

            foreach (ZdravstveniKarton pr in zdravstveniKartoni)
            {
                if (pr.Id.Equals(ZdravstveniKarton.Id))
                {
                    return false;
                }
            }
            zdravstveniKartoni.Add(new ZdravstveniKarton(ZdravstveniKarton));
            datoteka.Sacuvaj(zdravstveniKartoni);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool KreirajZdravstveniKartonJMBG(ZdravstveniKarton ZdravstveniKarton)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();

            foreach (ZdravstveniKarton pr in zdravstveniKartoni)
            {
                if (pr.Id.Equals(ZdravstveniKarton.Id))
                {
                    return false;
                }
            }
            zdravstveniKartoni.Add(ZdravstveniKarton);
            datoteka.Sacuvaj(zdravstveniKartoni);

            return true;
        }

        public bool ObrisiZdravstveniKarton(ZdravstveniKarton zdravstveniKarton, Dictionary<int, int> id_map)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZdravstveniKartoni");
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in zdravstveniKartoni)
            {
                if (zk.Id.Equals(zdravstveniKarton.Id))
                {
                    zdravstveniKartoni.Remove(zk);
                    datoteka.Sacuvaj(zdravstveniKartoni);
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }


        public ZdravstveniKarton findById(long id)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();

            List<ZdravstveniKarton> kartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in kartoni)
            {
                if (zk.Id == id)
                    return zk;

            }
            return null;
        }


        public void DodajAlergen(ZdravstveniKartonDTO k1DTO, ZdravstveniKartonDTO k2DTO, string alergija, Pacijent pacijent)
        {
            ZdravstveniKarton k1 = DTO2Model(k1DTO);
            ZdravstveniKarton k2 = DTO2Model(k2DTO);
            k2.dodajAlergije(alergija);
            if (AzurirajZdravstveniKarton(k2))
            {
                PregledSvihZdravstvenihKartona().Remove(k1);
                PregledSvihZdravstvenihKartona().Add(k2);
            }
            pacijent.ZdravstveniKarton = k2;
        }
        public bool AzurirajZdravstveniKarton(ZdravstveniKarton zdravstveniKarton)

        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in zdravstveniKartoni)
            {
                if (zk.Id.Equals(zdravstveniKarton.Id))
                {
                    zdravstveniKartoni.Remove(zk);
                    zdravstveniKartoni.Add(zdravstveniKarton);
                    datoteka.Sacuvaj(zdravstveniKartoni);
                    return true;
                }
            }
            return false;
        }

        public ZdravstveniKarton PregledZdravstvenogKartona(long id)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in zdravstveniKartoni)
            {
                if (zk.Id.Equals(id))
                {
                    return zk;
                }
            }
            return null;
        }

        public List<ZdravstveniKarton> PregledSvihZdravstvenihKartona()
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            return zdravstveniKartoni;
        }

        public ZdravstveniKartonDTO Model2DTO(ZdravstveniKarton model)
        {
            ZdravstveniKartonDTO dto = new ZdravstveniKartonDTO();

            if (model != null)
            {
                dto.Id = model.Id;
                return dto;
            }
            else
                return null;
        }

        public ZdravstveniKarton DTO2Model(ZdravstveniKartonDTO dto)
        {
            return findById(dto.Id);
        }
    }
}