using expert8BL;
using expert8DL;
using Expert8Model;

namespace Expert8BL
{
    public class specialistBL : ispecialistBL
    {

        private readonly iexpert8DL<JoinTable> _specialistrepo;

        public specialistBL(iexpert8DL<JoinTable> specialistrepo)
        {
            _specialistrepo = specialistrepo;
        }

        public void addservices(JoinTable s_services)
        {
            _specialistrepo.AddCus(s_services);
        }
    }
}