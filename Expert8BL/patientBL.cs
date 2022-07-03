using System.ComponentModel.DataAnnotations;
using expert8DL;
using Expert8Model;

namespace patientBL
{
    public class patientBL : ipatientBL
    {
        private readonly iexpert8DL<Patient> _patientrepo;

        public patientBL(iexpert8DL<Patient> patientrepo)
        {
            
            _patientrepo = patientrepo;
        }

        public void addpatient(Patient p_patient)
        {
            Patient foundedpatient = searchpatientbyemailandpassword(p_patient.Email, p_patient.Password);
            if (foundedpatient == null)
            {
                _patientrepo.AddCus(p_patient);
            }
            else{
                throw new ValidationException("Patient Already Exist!");
            }
        }

        public List<Patient> GetAllPatients()
        {
            return _patientrepo.GetAll();
        }

        public Patient searchpatientbyemailandpassword(string p_email, string p_password)
        {
            return _patientrepo.GetAll().First(patient => patient.Email == p_email && patient.Password == p_password);
        }
    }

    
}